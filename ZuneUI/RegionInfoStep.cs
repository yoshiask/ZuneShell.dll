﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.RegionInfoStep
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Zune.Service;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace ZuneUI
{
    public abstract class RegionInfoStep : AccountManagementStep
    {
        private static IList _supportedCountries;
        private IList _supportedLanguages;
        private IList _supportedStates;
        private bool _loadStates;
        private bool _loadLanguages;
        private bool _initializeOnce;

        public RegionInfoStep(Wizard owner, AccountManagementWizardState state, bool parentAccount)
          : base(owner, state, parentAccount)
        {
            _supportedCountries = null;
            this._supportedLanguages = null;
            this._supportedStates = null;
        }

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
            {
                if (this.CountryDescriptor != null)
                    this.WizardPropertyEditor.GetProperty(this.CountryDescriptor).PropertyChanged -= new PropertyChangedEventHandler(this.OnCountryPropertyChanged);
                if (this.LanguageDescriptor != null)
                    this.WizardPropertyEditor.GetProperty(this.LanguageDescriptor).PropertyChanged -= new PropertyChangedEventHandler(this.OnLanguagePropertyChanged);
            }
            base.OnDispose(disposing);
        }

        protected bool LoadStates
        {
            get => this._loadStates;
            set
            {
                if (this._loadStates == value)
                    return;
                this._loadStates = value;
                this.FirePropertyChanged(nameof(LoadStates));
            }
        }

        protected bool LoadLanguages
        {
            get => this._loadLanguages;
            set
            {
                if (this._loadLanguages == value)
                    return;
                this._loadLanguages = value;
                this.FirePropertyChanged(nameof(LoadLanguages));
            }
        }

        public string SelectedLocale
        {
            get
            {
                string str = string.Empty;
                string selectedCountry = this.SelectedCountry;
                string selectedLanguage = this.SelectedLanguage;
                if (!string.IsNullOrEmpty(selectedCountry) && !string.IsNullOrEmpty(selectedLanguage))
                    str = string.Format("{0}-{1}", selectedLanguage, selectedCountry);
                return str;
            }
            set
            {
                if (value == null)
                    return;
                string language;
                string country;
                GetLanguageAndCountry(value, out language, out country);
                this.SelectedLanguage = language;
                this.SelectedCountry = country;
            }
        }

        public string SelectedCountry
        {
            get => this.CountryDescriptor != null ? this.GetUncommittedValue(this.CountryDescriptor) as string : null;
            set
            {
                if (this.CountryDescriptor == null || !(this.GetCommittedValue(this.CountryDescriptor) as string != value))
                    return;
                this.SetCommittedValue(this.CountryDescriptor, value);
            }
        }

        public string SelectedLanguage
        {
            get => this.LanguageDescriptor != null ? this.GetUncommittedValue(this.LanguageDescriptor) as string : null;
            set
            {
                if (this.LanguageDescriptor == null)
                    return;
                this.SetCommittedValue(this.LanguageDescriptor, value);
            }
        }

        public string SelectedState
        {
            get => this.StateDescriptor != null ? this.GetUncommittedValue(this.StateDescriptor) as string : null;
            set
            {
                bool flag = this.SupportedStates == null || this.SupportedStates.Count == 0 || this.SupportedStates.Contains(value);
                if (this.StateDescriptor == null || !flag)
                    return;
                this.SetCommittedValue(this.StateDescriptor, value);
            }
        }

        protected virtual PropertyDescriptor CountryDescriptor => (PropertyDescriptor)null;

        protected virtual PropertyDescriptor LanguageDescriptor => (PropertyDescriptor)null;

        protected virtual PropertyDescriptor StateDescriptor => (PropertyDescriptor)null;

        public IList SupportedCountries
        {
            get => _supportedCountries;
            protected set
            {
                if (_supportedCountries == value)
                    return;
                _supportedCountries = value;
                string str = this.SelectBestCountry(_supportedCountries, this.SelectedCountry);
                if (str != null)
                    this.SelectedCountry = str;
                this.FirePropertyChanged(nameof(SupportedCountries));
            }
        }

        public IList SupportedLanguages
        {
            get => this._supportedLanguages;
            protected set
            {
                if (this._supportedLanguages == value)
                    return;
                this._supportedLanguages = value;
                string str = this.SelectBestLanguage(this._supportedLanguages, this.SelectedLanguage);
                if (str != null)
                    this.SelectedLanguage = str;
                this.FirePropertyChanged(nameof(SupportedLanguages));
            }
        }

        public IList SupportedStates
        {
            get => this._supportedStates;
            protected set
            {
                if (this._supportedStates == value)
                    return;
                this._supportedStates = value;
                string str = null;
                if (this._supportedStates != null && this._supportedStates.Count > 0)
                    str = !this._supportedStates.Contains(SelectedState) ? this._supportedStates[0] as string : this.SelectedState;
                if (str != null)
                    this.SelectedState = str;
                this.FirePropertyChanged(nameof(SupportedStates));
            }
        }

        public IList GetCountryDisplayNames()
        {
            List<string> stringList = null;
            if (_supportedCountries != null)
            {
                stringList = new List<string>(_supportedCountries.Count);
                foreach (string supportedCountry in _supportedCountries)
                    stringList.Add(CountryHelper.GetDisplayName(supportedCountry));
            }
            return stringList;
        }

        public IList GetLanguageDisplayNames()
        {
            List<string> stringList = null;
            if (this._supportedLanguages != null)
            {
                stringList = new List<string>(this._supportedLanguages.Count);
                foreach (string supportedLanguage in _supportedLanguages)
                    stringList.Add(LanguageHelper.GetDisplayName(supportedLanguage));
            }
            return stringList;
        }

        public IList GetStateDisplayNames()
        {
            IList list = null;
            AccountCountry country = AccountCountryList.Instance.GetCountry(this.SelectedCountry);
            if (country != null)
                list = country.States;
            return list;
        }

        internal static void GetLanguageAndCountry(
          string locale,
          out string language,
          out string country)
        {
            language = null;
            country = null;
            if (string.IsNullOrEmpty(locale))
                return;
            try
            {
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture(locale);
                while (!cultureInfo.IsNeutralCulture && cultureInfo.LCID != 1044)
                    cultureInfo = cultureInfo.Parent;
                language = cultureInfo.Name;
                string name = locale;
                string[] strArray = locale.Split('-');
                if (strArray.Length >= 2)
                    name = strArray[strArray.Length - 1];
                RegionInfo regionInfo = new RegionInfo(name);
                country = regionInfo.TwoLetterISORegionName;
            }
            catch (ArgumentException ex)
            {
            }
        }

        protected override void OnActivate()
        {
            this.IntializeOnce();
            RegionServiceData regionServiceData = new RegionServiceData();
            regionServiceData.SelectedCountry = this.SelectedCountry;
            regionServiceData.SelectedLanguage = this.SelectedLanguage;
            regionServiceData.SupportedStates = this._loadStates ? this.SupportedStates : new ArrayList(0);
            regionServiceData.SupportedLanguages = this._loadLanguages ? this.SupportedLanguages : new ArrayList(0);
            if (!string.IsNullOrEmpty(regionServiceData.SelectedCountry))
                regionServiceData.SupportedCountries = this.SupportedCountries;
            this.ServiceActivationRequestsDone = this.ServiceActivationRequestsDone && regionServiceData.SupportedStates != null && regionServiceData.SupportedLanguages != null && regionServiceData.SupportedCountries != null;
            if (this.ServiceActivationRequestsDone)
                return;
            this.StartActivationRequests(regionServiceData);
        }

        private void IntializeOnce()
        {
            if (this._initializeOnce)
                return;
            this._initializeOnce = true;
            if (SignIn.Instance.SignedIn)
                this.SelectedCountry = SignIn.Instance.CountryCode;
            if (this.WizardPropertyEditor != null)
            {
                if (this.CountryDescriptor != null)
                    this.WizardPropertyEditor.GetProperty(this.CountryDescriptor).PropertyChanged += new PropertyChangedEventHandler(this.OnCountryPropertyChanged);
                if (this.LanguageDescriptor != null)
                    this.WizardPropertyEditor.GetProperty(this.LanguageDescriptor).PropertyChanged += new PropertyChangedEventHandler(this.OnLanguagePropertyChanged);
            }
            this.OnCountryChangedInternal(false);
            this.OnLanguageChangedInternal();
        }

        private void OnCountryPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (!(args.PropertyName == "Value"))
                return;
            this.OnCountryChangedInternal(true);
        }

        private void OnLanguagePropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (!(args.PropertyName == "Value"))
                return;
            this.OnLanguageChangedInternal();
        }

        private void OnCountryChangedInternal(bool refreshLanguagesStates)
        {
            this.FirePropertyChanged("SelectedLocale");
            if (refreshLanguagesStates)
                this.RefreshLanguagesStates();
            if (this.WizardPropertyEditor != null && this.StateDescriptor != null)
                this.WizardPropertyEditor.SetPropertyState(this.StateDescriptor, SelectedCountry);
            this.OnCountryChanged();
        }

        private void OnLanguageChangedInternal()
        {
            this.FirePropertyChanged("SelectedLocale");
            this.OnLanguageChanged();
        }

        protected virtual void OnCountryChanged()
        {
        }

        protected virtual void OnLanguageChanged()
        {
        }

        protected void RefreshLanguagesStates()
        {
            if (this.WizardPropertyEditor != null && this.StateDescriptor != null)
                this.WizardPropertyEditor.SetPropertyState(this.StateDescriptor, SelectedCountry);
            if (!this.ServiceActivationRequestsDone)
                return;
            this.SupportedLanguages = null;
            this.SupportedStates = null;
            this.Activate();
        }

        protected override void OnStartActivationRequests(object state)
        {
            RegionServiceData regionServiceData = (RegionServiceData)state;
            if (regionServiceData.SupportedCountries == null)
            {
                regionServiceData.SupportedCountries = this.ObtainSupportedCountries();
                regionServiceData.SelectedCountry = regionServiceData.SupportedCountries == null || regionServiceData.SupportedCountries.Count == 0 ? null : this.SelectBestCountry(regionServiceData.SupportedCountries, regionServiceData.SelectedCountry);
            }
            if (regionServiceData.SupportedLanguages == null)
            {
                regionServiceData.SupportedLanguages = this.ObtainSupportedLanguages(regionServiceData.SelectedCountry);
                regionServiceData.SelectedLanguage = this.SelectBestLanguage(regionServiceData.SupportedLanguages, regionServiceData.SelectedLanguage);
            }
            if (regionServiceData.SupportedStates == null)
                regionServiceData.SupportedStates = this.ObtainSupportedStates(regionServiceData.SelectedCountry);
            this.EndActivationRequests(regionServiceData);
        }

        protected override void OnEndActivationRequests(object args)
        {
            RegionServiceData regionServiceData = (RegionServiceData)args;
            if (regionServiceData.SupportedCountries != null)
                this.SupportedCountries = regionServiceData.SupportedCountries;
            if (regionServiceData.SupportedLanguages != null)
                this.SupportedLanguages = regionServiceData.SupportedLanguages;
            if (regionServiceData.SupportedStates != null)
                this.SupportedStates = regionServiceData.SupportedStates;
            if (regionServiceData.SupportedCountries != null && (regionServiceData.SupportedLanguages != null || !this.LoadLanguages))
                return;
            this.SetError(HRESULT._E_FAIL, null);
            this.NavigateToErrorHandler();
        }

        private IList ObtainSupportedCountries() => AccountCountryList.Instance.LoadDataOnWorkerThread() ? AccountCountryList.Instance.CountryAbbreviations : null;

        private IList ObtainSupportedLanguages(string country)
        {
            AccountCountry country1 = AccountCountryList.Instance.GetCountry(country);
            return country1 == null || country1.LanguageAbbreviations == null ? new ArrayList(0) : (IList)country1.LanguageAbbreviations;
        }

        private IList ObtainSupportedStates(string country)
        {
            AccountCountry country1 = AccountCountryList.Instance.GetCountry(country);
            return country1 == null || country1.StatesAbbreviations == null ? new List<string>(0) : country1.StatesAbbreviations;
        }

        private string SelectBestCountry(IList supportedCountries, string currentCountry)
        {
            string str = null;
            if (supportedCountries != null && supportedCountries.Count > 0)
            {
                str = currentCountry;
                if (string.IsNullOrEmpty(str))
                    str = CultureHelper.GetDefaultCountry();
                if (!supportedCountries.Contains(str))
                    str = supportedCountries[0] as string;
            }
            return str;
        }

        private string SelectBestLanguage(IList supportedLanguage, string currentLanguage)
        {
            string str = null;
            if (supportedLanguage != null && supportedLanguage.Count > 0)
            {
                str = currentLanguage;
                if (string.IsNullOrEmpty(str))
                    str = CultureHelper.GetDefaultLanguage();
                if (!supportedLanguage.Contains(str))
                    str = supportedLanguage[0] as string;
            }
            return str;
        }

        protected class RegionServiceData
        {
            public IList SupportedCountries;
            public IList SupportedLanguages;
            public IList SupportedStates;
            public string SelectedCountry;
            public string SelectedLanguage;
        }
    }
}
