﻿// Decompiled with JetBrains decompiler
// Type: ZuneUI.AlbumMetadataPropertySource
// Assembly: ZuneShell, Version=4.7.0.0, Culture=neutral, PublicKeyToken=ddd0da4d3e678217
// MVID: FC8028F3-A47B-4FB4-B35B-11D1752D8264
// Assembly location: C:\Program Files\Zune\ZuneShell.dll

using Microsoft.Zune.Shell;
using MicrosoftZuneLibrary;
using System;
using UIXControls;

namespace ZuneUI
{
    public class AlbumMetadataPropertySource : PropertySource
    {
        private static PropertySource _instance;

        protected AlbumMetadataPropertySource()
        {
        }

        public static PropertySource Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AlbumMetadataPropertySource();
                return _instance;
            }
        }

        public override object Get(object media, PropertyDescriptor property)
        {
            AlbumMetadata albumMetadata = media as AlbumMetadata;
            string descriptorName = property.DescriptorName;
            if (descriptorName == MetadataEditMedia.s_Title.DescriptorName)
                return albumMetadata.AlbumTitle;
            if (descriptorName == MetadataEditMedia.s_AlbumTitleYomi.DescriptorName)
                return albumMetadata.AlbumTitleYomi;
            if (descriptorName == MetadataEditMedia.s_Artist.DescriptorName)
                return albumMetadata.AlbumArtist;
            if (descriptorName == MetadataEditMedia.s_AlbumArtistYomi.DescriptorName)
                return albumMetadata.AlbumArtistYomi;
            if (descriptorName == MetadataEditMedia.s_TrackCount.DescriptorName)
                return albumMetadata.TrackCount;
            if (descriptorName == MetadataEditMedia.s_CoverUrl.DescriptorName)
                return albumMetadata.CoverUrl;
            return descriptorName == MetadataEditMedia.s_ReleaseYear.DescriptorName ? albumMetadata.ReleaseYear : (object)null;
        }

        public override void Set(object media, PropertyDescriptor property, object value)
        {
            AlbumMetadata albumMetadata = media as AlbumMetadata;
            string descriptorName = property.DescriptorName;
            if (descriptorName == MetadataEditMedia.s_Title.DescriptorName)
                albumMetadata.AlbumTitle = (string)value;
            else if (descriptorName == MetadataEditMedia.s_AlbumTitleYomi.DescriptorName)
                albumMetadata.AlbumTitleYomi = (string)value;
            else if (descriptorName == MetadataEditMedia.s_Artist.DescriptorName)
                albumMetadata.AlbumArtist = (string)value;
            else if (descriptorName == MetadataEditMedia.s_AlbumArtistYomi.DescriptorName)
                albumMetadata.AlbumArtistYomi = (string)value;
            else if (descriptorName == MetadataEditMedia.s_CoverUrl.DescriptorName)
            {
                albumMetadata.CoverUrl = (string)value;
            }
            else
            {
                if (!(descriptorName == MetadataEditMedia.s_ReleaseYear.DescriptorName))
                    return;
                albumMetadata.ReleaseYear = (int)value;
            }
        }

        public override void Commit(object media)
        {
            AlbumMetadata albumMetadata = media as AlbumMetadata;
            try
            {
                ZuneApplication.ZuneLibrary.UpdateAlbumMetadata(albumMetadata.MediaId, albumMetadata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Shell.LoadString(StringId.IDS_EMI_UPDATEFAILED_TITLE), Shell.LoadString(StringId.IDS_EMI_UPDATEFAILED), null);
            }
        }

        public override bool NeedsCommit => true;
    }
}
