﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.CDAccess
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Iris;
using Microsoft.Zune.Shell;
using Microsoft.Zune.Util;
using MicrosoftZuneLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UIXControls;

namespace ZuneUI
{
    public class CDAccess : ModelItem
    {
        private static string _ripCompleteMessage = Shell.LoadString(StringId.IDS_RIP_COMPLETE_NOTIFICATION);
        private static string _ripCanceledMessage = Shell.LoadString(StringId.IDS_RIP_CANCELED_NOTIFICATION);
        private static string _ripFailedMessage = Shell.LoadString(StringId.IDS_RIP_FAILED_NOTIFICATION);
        private static string _ripProgressMessage = Shell.LoadString(StringId.IDS_RIP_PROGRESS_NOTIFICATION);
        private static string _ripCurrentMessage = Shell.LoadString(StringId.IDS_RIP_CURRENT_NOTIFICATION);
        private static CDAccess _singletonInstance;
        private static bool s_phase2Complete = false;
        private ZuneLibraryCDDeviceList _cdDeviceList;
        private ArrayListDataSet _CDs;
        private IList _discardedCDs;
        private AutoplayInfo _pendingAutoPlay;
        private ZuneLibraryCDRecorder _recorder;
        private bool _isRipping;
        private ProgressNotification _ripNotification;
        private int _ripTotalTracks;
        private int _ripPercent;
        private int _ripCurrentTrack = 1;
        private int _ripTrackProgress;
        private char _activeDriveLetter;
        private bool _isBurning;
        private bool _isErasing;
        private bool _hasBurner;
        private BurnableCD _activeBurnCD;
        private BurnableCD _burnCDForNextSession;
        private int _burnListId = int.MinValue;
        private bool _isBurnListEmpty = true;
        private bool _hasBurnedBurnList;
        private DRMCanDoQuery _drmQuery;
        private ProgressNotification _burnNotification;

        private CDAccess()
        {
            this._CDs = new ArrayListDataSet();
            if (!s_phase2Complete)
                return;
            this.Initialize();
        }

        public static void Phase2Catchup()
        {
            s_phase2Complete = true;
            if (Instance == null)
                return;
            Instance.Initialize();
        }

        private void Initialize()
        {
            this._cdDeviceList = ZuneApplication.ZuneLibrary.GetCDDeviceList();
            DiscExperience disc = Shell.MainFrame.Disc;
            if (this._cdDeviceList != null)
            {
                this._cdDeviceList.MediaChangedHandler += new OnMediaChangedHandler(this.OnMediaChanged);
                for (int index = 0; index < this._cdDeviceList.Count; ++index)
                    this._CDs.Add(null);
            }
            disc.RecalculateAvailableNodes();
            this._recorder = ZuneApplication.ZuneLibrary.GetRecorder();
            if (this._recorder == null)
                return;
            this._recorder.RecordStopHandler += new OnRecordStopHandler(this.OnRecordStop);
            this._recorder.RecordProgressHandler += new OnRecordProgressHandler(this.OnRecordProgress);
        }

        protected override void OnDispose(bool fDisposing)
        {
            base.OnDispose(fDisposing);
            if (fDisposing)
            {
                if (this._cdDeviceList != null)
                {
                    this._cdDeviceList.MediaChangedHandler -= new OnMediaChangedHandler(this.OnMediaChanged);
                    int num = (int)this._cdDeviceList.Release();
                    this._cdDeviceList = null;
                }
                if (this._recorder != null)
                {
                    this._recorder.RecordStopHandler -= new OnRecordStopHandler(this.OnRecordStop);
                    this._recorder.RecordProgressHandler -= new OnRecordProgressHandler(this.OnRecordProgress);
                    this._recorder = null;
                }
                foreach (CDAlbumCommand cd in _CDs)
                    cd?.Dispose();
                this._CDs.Clear();
            }
            if (this._drmQuery == null)
                return;
            this._drmQuery.Dispose();
        }

        public static CDAccess Instance
        {
            get
            {
                if (_singletonInstance == null)
                    _singletonInstance = new CDAccess();
                return _singletonInstance;
            }
        }

        public static void HandleDiskFromAutoplay(string path, CDAction action)
        {
            int num = path.IndexOf(':');
            if (num <= 0)
                return;
            char upperInvariant = char.ToUpperInvariant(path[num - 1]);
            if (upperInvariant < 'A' || upperInvariant > 'Z')
                return;
            HandleDiskFromAutoplay(upperInvariant, action);
        }

        public static void HandleDiskFromAutoplay(char driveLetter, CDAction action)
        {
            CDAlbumCommand cdAlbumCommand = null;
            foreach (CDAlbumCommand cd in Instance.CDs)
            {
                if (cd != null && cd.CDDevice.DrivePath == driveLetter)
                {
                    cdAlbumCommand = cd;
                    break;
                }
            }
            if (cdAlbumCommand == null)
            {
                Instance._pendingAutoPlay = new AutoplayInfo(driveLetter, action);
            }
            else
            {
                cdAlbumCommand.Invoke();
                if (action == CDAction.Rip && cdAlbumCommand.InsertedDuringSession && ZuneShell.DefaultInstance.Management.AutoCopyCD.Value || !cdAlbumCommand.CDDevice.IsDriveReady)
                    return;
                cdAlbumCommand.AutoPlayAction = action;
            }
        }

        public ArrayListDataSet CDs => this._CDs;

        public BurnableCD BurnCDForNextSession
        {
            get => this._burnCDForNextSession;
            private set
            {
                if (this._burnCDForNextSession == value)
                    return;
                this._burnCDForNextSession = value;
                this.EnsureBurnList(false);
                this.FirePropertyChanged(nameof(BurnCDForNextSession));
            }
        }

        internal ZuneLibraryCDRecorder Recorder => this._recorder;

        public bool IsRipping
        {
            get => this._isRipping;
            set
            {
                if (this._isRipping == value)
                    return;
                this._isRipping = value;
                this.FirePropertyChanged(nameof(IsRipping));
            }
        }

        public bool IsAudioBurn => ((NamedIntOption)ZuneShell.DefaultInstance.Management.BurnFormat.ChosenValue).Value == 0;

        internal void UpdateIsAudioBurn() => this.FirePropertyChanged("IsAudioBurn");

        public bool IsBurning
        {
            get => this._isBurning;
            internal set
            {
                if (this._isBurning == value)
                    return;
                this._isBurning = value;
                this.FirePropertyChanged(nameof(IsBurning));
            }
        }

        public bool IsErasing
        {
            get => this._isErasing;
            internal set
            {
                if (this._isErasing == value)
                    return;
                this._isErasing = value;
                this.FirePropertyChanged(nameof(IsErasing));
            }
        }

        public char ActiveDriveLetter
        {
            get => this._activeDriveLetter;
            set => this._activeDriveLetter = value;
        }

        public bool IsBurnCanceling => this._activeBurnCD != null && this._activeBurnCD.IsBurnCanceling;

        public bool HasBurner
        {
            get => this._hasBurner;
            private set
            {
                if (this._hasBurner == value)
                    return;
                this._hasBurner = value;
                this.FirePropertyChanged(nameof(HasBurner));
            }
        }

        public TimeSpan DefaultBurnTimeAvailable => TimeSpan.FromMinutes(0.0);

        public long DefaultBurnSpaceAvailable => 0;

        public ProgressNotification BurnNotification
        {
            get => this._burnNotification;
            internal set
            {
                if (this._burnNotification == value)
                    return;
                this._burnNotification = value;
                this.FirePropertyChanged(nameof(BurnNotification));
            }
        }

        public void AddToBurnList(IList items)
        {
            if (this._burnListId >= 0 && this._hasBurnedBurnList && !this._isBurnListEmpty)
            {
                Command yesCommand = new Command(null, Shell.LoadString(StringId.IDS_CREATE_BURN_LIST_YES_CREATE), null);
                yesCommand.Invoked += delegate
               {
                   this.AddToBurnPlaylist(items, true);
               };
                Command noCommand = new Command(null, Shell.LoadString(StringId.IDS_CREATE_BURN_LIST_NO_ADD), null);
                noCommand.Invoked += delegate
               {
                   this.AddToBurnPlaylist(items, false);
               };
                MessageBox.Show(Shell.LoadString(StringId.IDS_CREATE_BURN_LIST_DIALOG_TITLE), Shell.LoadString(StringId.IDS_CREATE_BURN_LIST_QUESTION), yesCommand, noCommand, null);
            }
            else
                this.AddToBurnPlaylist(items, false);
        }

        private void AddToBurnPlaylist(IList items, bool createNew)
        {
            this.EnsureBurnList(createNew);
            int playlist = (int)PlaylistManager.Instance.AddToPlaylist(this._burnListId, items, false);
            this._hasBurnedBurnList = false;
            this._isBurnListEmpty = false;
            Shell.MainFrame.Disc.RecalculateAvailableNodes();
            Shell.MainFrame.Disc.Nodes.ChosenValue = Shell.MainFrame.Disc.BurnList;
        }

        public int BurnListId => this._burnListId;

        public bool IsBurnListEmpty => this._isBurnListEmpty;

        public bool HasLoadedMedia
        {
            get
            {
                foreach (CDAlbumCommand cd in _CDs)
                {
                    if (cd != null && cd.IsMediaLoaded && (cd.TOC != null || cd.CanWrite))
                        return true;
                }
                return false;
            }
        }

        private void EnsureBurnList(bool forceCreate)
        {
            if (this._burnListId >= 0 && !forceCreate)
                return;
            this._burnListId = PlaylistManager.Instance.CreatePlaylist(Shell.LoadString(StringId.IDS_PLAYLIST_BURN_LIST), true).PlaylistId;
            this._isBurnListEmpty = true;
            Shell.MainFrame.Disc.RecalculateAvailableNodes();
            this.FirePropertyChanged("BurnListId");
        }

        public void ClearBurnList() => this.EnsureBurnList(true);

        public bool DRMCanBurnFile(string filePath)
        {
            if (this._drmQuery == null)
            {
                try
                {
                    this._drmQuery = new DRMCanDoQuery();
                }
                catch (ApplicationException ex)
                {
                }
            }
            return this._drmQuery == null || this._drmQuery.CanBurnFile(filePath);
        }

        public void PrepareForBurn(string burnTitle, int playlistId, IList burnListItems)
        {
            if (this._burnCDForNextSession == null)
                return;
            this.IsBurning = true;
            this._activeBurnCD = this._burnCDForNextSession;
            this._activeDriveLetter = this._activeBurnCD.DriveLetter;
            this._hasBurnedBurnList = true;
            this._activeBurnCD.PrepareForBurn(burnTitle, playlistId, burnListItems);
        }

        public void StartBurn() => this._activeBurnCD.StartBurn();

        public void CancelBurn()
        {
            if (this._activeBurnCD == null)
                return;
            this._activeBurnCD.CancelBurn();
        }

        public BurnSessionItem GetBurnItemByPlaylistContentId(int playlistContentId) => this._activeBurnCD != null ? this._activeBurnCD.GetBurnItemByPlaylistContentId(playlistContentId) : null;

        public string TimeSpanToStringForBurnTime(TimeSpan time) => string.Format("{1:0}{0}{2:00}", CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator, (int)time.TotalMinutes, time.Seconds);

        public event EventHandler MediaChanged;

        public IList DiscardedCDs
        {
            get => this._discardedCDs;
            set => this._discardedCDs = value;
        }

        private void OnMediaChanged(char driveLetter, bool fMediaArrived)
        {
            ChangeInfo changeInfo = new ChangeInfo(driveLetter, fMediaArrived);
            for (int idx = 0; idx < this._cdDeviceList.Count; ++idx)
            {
                ZuneLibraryCDDevice zuneLibraryCdDevice = this._cdDeviceList.GetItem(idx);
                if (zuneLibraryCdDevice.DrivePath == changeInfo.DriveLetter)
                {
                    changeInfo.Index = idx;
                    changeInfo.Device = zuneLibraryCdDevice;
                    break;
                }
            }
            this.WaitForDrive(changeInfo);
        }

        private void WaitForDrive(object arg)
        {
            ChangeInfo changeInfo = (ChangeInfo)arg;
            if (changeInfo.Device == null || !changeInfo.MediaArrived || changeInfo.Device.IsDriveReady)
                Application.DeferredInvoke(new DeferredInvokeHandler(this.DeferredOnMediaChanged), changeInfo);
            else
                Application.DeferredInvoke(new DeferredInvokeHandler(this.WaitForDrive), changeInfo, TimeSpan.FromMilliseconds(500.0));
        }

        private void DeferredOnMediaChanged(object arg)
        {
            ChangeInfo changeInfo = (ChangeInfo)arg;
            ZuneLibraryCDDevice device = changeInfo.Device;
            int index = changeInfo.Index;
            bool flag = _activeDriveLetter == changeInfo.DriveLetter && !changeInfo.MediaArrived;
            if (device != null)
            {
                CDAlbumCommand cd = (CDAlbumCommand)this._CDs[index];
                if (!ZuneLibraryCDDevice.IsImapiv2Installed && flag && (cd.BurnCD.IsBurning || cd.BurnCD.IsErasing))
                {
                    device.Dispose();
                    return;
                }
                if (cd == null || !changeInfo.MediaArrived || device.TOC != cd.TOC)
                {
                    CDAlbumCommand cdAlbumCommand = null;
                    if (changeInfo.MediaArrived)
                        cdAlbumCommand = new CDAlbumCommand(Shell.MainFrame.Disc, this, device, true);
                    this._CDs[index] = cdAlbumCommand;
                    if (cd != null)
                    {
                        if (this._discardedCDs == null)
                            this._discardedCDs = new List<object>();
                        this._discardedCDs.Add(cd);
                    }
                    if (cdAlbumCommand == null)
                        device.Dispose();
                    else
                        device.Close();
                }
                else
                    device.Dispose();
            }
            if (this._pendingAutoPlay != null && _pendingAutoPlay.DriveLetter == changeInfo.DriveLetter)
            {
                HandleDiskFromAutoplay(this._pendingAutoPlay.DriveLetter, this._pendingAutoPlay.Action);
                this._pendingAutoPlay = null;
            }
            if (flag && this._activeBurnCD != null)
            {
                if (this._activeBurnCD.IsBurning)
                    this._activeBurnCD.CancelBurn();
                else
                    this._activeBurnCD.ClearBurnItems();
                this._activeDriveLetter = char.MinValue;
            }
            this.UpdateBurnState();
            Shell.MainFrame.Disc.UpdateNodes(this, changeInfo.DriveLetter, changeInfo.MediaArrived);
            this.NotifyMediaChanged();
        }

        private void UpdateBurnState()
        {
            BurnableCD burnableCd = null;
            foreach (CDAlbumCommand cd in _CDs)
            {
                if (cd != null && cd.CanWrite)
                {
                    burnableCd = cd.BurnCD;
                    break;
                }
            }
            this.BurnCDForNextSession = burnableCd;
            bool flag = false;
            for (int idx = 0; idx < this._cdDeviceList.Count; ++idx)
            {
                ZuneLibraryCDDevice zuneLibraryCdDevice = this._cdDeviceList.GetItem(idx);
                flag |= zuneLibraryCdDevice.IsBurner;
                zuneLibraryCdDevice.Dispose();
            }
            this.HasBurner = flag;
        }

        private void NotifyMediaChanged()
        {
            this.FirePropertyChanged("MediaChanged");
            if (this.MediaChanged == null)
                return;
            this.MediaChanged(this, new EventArgs());
        }

        internal void StartRip(int trackCount)
        {
            this._ripTotalTracks += trackCount;
            this.IsRipping = true;
            this.UpdateMessage(false);
        }

        internal void StopRip(int trackCount)
        {
            this._ripTotalTracks -= trackCount;
            if (this._ripCurrentTrack > this._ripTotalTracks)
                this.ShowCompletedMessage(RipState.Incomplete);
            else
                this.UpdateMessage(false);
        }

        private void OnRecordProgress(string strSourceUrl, int percentComplete) => Application.DeferredInvoke(delegate
       {
           this._ripTrackProgress = percentComplete;
           this.UpdateMessage(true);
           CDAlbumTrack trackBySourceUrl = this.GetTrackBySourceUrl(strSourceUrl);
           if (trackBySourceUrl == null)
               return;
           trackBySourceUrl.RipState = RipState.InProgress;
           trackBySourceUrl.PercentComplete = percentComplete;
       }, null);

        private void OnRecordStop(string strSourceUrl, int hr) => Application.DeferredInvoke(delegate
       {
           ++this._ripCurrentTrack;
           this._ripTrackProgress = 0;
           bool flag = this._ripCurrentTrack > this._ripTotalTracks;
           CDAlbumTrack trackBySourceUrl = this.GetTrackBySourceUrl(strSourceUrl);
           RipState ripState = RipState.InLibrary;
           if (trackBySourceUrl != null)
           {
               if (hr == HRESULT._E_ABORT)
                   ripState = RipState.Incomplete;
               else if (hr < 0)
               {
                   ripState = RipState.Error;
                   trackBySourceUrl.RipErrorCode = hr;
               }
               else
               {
                   ripState = RipState.InLibrary;
                   trackBySourceUrl.RipTrack = false;
                   if (flag && ZuneShell.DefaultInstance.Management.AutoEjectCD.Value)
                       trackBySourceUrl.Album.CDDevice.Eject();
               }
               trackBySourceUrl.RipState = ripState;
               if (flag)
                   trackBySourceUrl.Album.IsRipping = false;
           }
           if (flag)
           {
               this._ripTotalTracks = 0;
               this._ripCurrentTrack = 1;
               this._ripPercent = 0;
               this._ripTrackProgress = 0;
               this.ShowCompletedMessage(ripState);
           }
           else
               this.UpdateMessage(false);
       }, null);

        public ProgressNotification Notification
        {
            get => this._ripNotification;
            set
            {
                if (this._ripNotification == value)
                    return;
                this._ripNotification = value;
                this.FirePropertyChanged(nameof(Notification));
            }
        }

        private void ShowCompletedMessage(RipState ripState)
        {
            this.IsRipping = false;
            if (this._ripNotification != null && this._ripNotification.Type != NotificationState.Completed)
            {
                this._ripNotification.Type = NotificationState.Completed;
                switch (ripState)
                {
                    case RipState.Incomplete:
                        this._ripNotification.Message = _ripCanceledMessage;
                        break;
                    case RipState.Error:
                        this._ripNotification.Message = _ripFailedMessage;
                        break;
                    default:
                        this._ripNotification.Message = _ripCompleteMessage;
                        this._ripNotification.Percentage = 100;
                        break;
                }
                this._ripNotification.SubMessage = null;
                this.Notification = null;
            }
            SoundHelper.Play(SoundId.RipComplete);
        }

        private void UpdateMessage(bool trackProgress)
        {
            if (this._ripNotification == null)
            {
                this.Notification = new ProgressNotification(_ripProgressMessage, NotificationTask.Rip, NotificationState.Normal, 0);
            }
            else
            {
                this._ripNotification.Type = NotificationState.Normal;
                this._ripNotification.Message = _ripProgressMessage;
            }
            int num = 0;
            if (this._ripTotalTracks != 0)
                num = ((this._ripCurrentTrack - 1) * 100 + this._ripTrackProgress) / this._ripTotalTracks;
            if (trackProgress && this._ripPercent == num)
                return;
            this._ripPercent = num;
            this._ripNotification.Percentage = num;
            this._ripNotification.SubMessage = string.Format(_ripCurrentMessage, _ripCurrentTrack, _ripTotalTracks);
        }

        private CDAlbumTrack GetTrackBySourceUrl(string strSourceUrl)
        {
            int num1 = strSourceUrl.LastIndexOf('/');
            int num2 = strSourceUrl.LastIndexOf('/', num1 - 1);
            int num3 = int.Parse(strSourceUrl.Substring(num1 + 1));
            ZuneLibraryCDDevice zuneLibraryCdDevice = this._cdDeviceList.GetItem(int.Parse(strSourceUrl.Substring(num2 + 1, num1 - num2 - 1)));
            for (int itemIndex = 0; itemIndex < this.CDs.Count; ++itemIndex)
            {
                CDAlbumCommand cd = (CDAlbumCommand)this.CDs[itemIndex];
                if (cd != null && cd.CDDevice.DrivePath == zuneLibraryCdDevice.DrivePath)
                    return cd.CDDevice.IsMediaLoaded ? cd.GetTrack(num3 - 1) : null;
            }
            return null;
        }

        private class AutoplayInfo
        {
            public char DriveLetter;
            public CDAction Action;

            public AutoplayInfo(char driveLetter, CDAction action)
            {
                this.DriveLetter = driveLetter;
                this.Action = action;
            }
        }

        private class ChangeInfo
        {
            public ZuneLibraryCDDevice Device;
            public int Index;
            public char DriveLetter;
            public bool MediaArrived;

            public ChangeInfo(char driveLetter, bool mediaArrived)
            {
                this.DriveLetter = driveLetter;
                this.MediaArrived = mediaArrived;
            }
        }
    }
}
