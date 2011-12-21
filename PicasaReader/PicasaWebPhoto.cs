using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Photos;
using Google.GData.Extensions.MediaRss;
namespace Sean_Jones.PicasaReader
{
    public class PicasaWebPhoto : IDisposable
    {
        string m_id = "";
        string m_accessId = "";
        string m_title = "";
        int m_height = 0;
        string m_uploaded = "";
        string m_location = "";
        int m_width = 0;
        string m_albumName = "";
        MediaGroup m_media = null;
        public PicasaWebPhoto(PicasaEntry photo, string albumName)
        {
            PhotoAccessor pa = new PhotoAccessor(photo);
            this.m_accessId = pa.Id;
            this.m_media = photo.Media;
            this.m_id = photo.Id.Uri.ToString();
            this.m_title = photo.Title.Text;
            this.m_albumName = albumName;
            this.m_height = pa.Height;
            this.m_width = pa.Width;
            this.m_uploaded = photo.Updated.ToShortDateString() + " " + photo.Updated.ToShortTimeString();
            this.m_location = (string)photo.Media.Content.Attributes["url"];
            pa = null;
        }
        public string Id
        {
            get
            {
                return this.m_id;
            }
        }

        public string AccessId
        {
            get
            {
                return this.m_accessId;
            }
        }

        public string Title
        {
            get
            {
                return this.m_title;
            }
        }
        public string Uploaded
        {
            get
            {
                return this.m_uploaded;
            }
        }
        public string Location
        {
            get
            {
                return this.m_location;
            }
        }

        public MediaGroup Media
        {
            get
            {
                return this.m_media;
            }
        }


        public int Width
        {
            get
            {
                return this.m_width;
            }
        }
        public int Height
        {
            get
            {
                return this.m_height;
            }
        }
        public string AlbumName
        {
            get
            {
                return this.m_albumName;
            }
        }

	#region Disposal
        bool is_disposed = false;
        protected virtual void Dispose(bool disposing)
        {
          if (!is_disposed) // only dispose once!
          {
            if (disposing)
            {
                this.m_id = null;
                this.m_title = null;
                this.m_uploaded = null;
                this.m_location = null;
                this.m_albumName = null;
            }
            // perform cleanup for this object
            // Console.WriteLine("Disposing...");
          }
          this.is_disposed = true;
        }
        public void Dispose()
        {
          Dispose(true);
          // tell the GC not to finalize
          GC.SuppressFinalize(this);
        }
        ~PicasaWebPhoto()
        {
          Dispose(false);
          //  Console.WriteLine("In destructor.");
        }
	#endregion        
      

    }
}
