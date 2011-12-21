using System;
using System.Collections.Generic;
using System.Text;

namespace Sean_Jones.PicasaReader
{
    public class PicasaWebAlbum : IDisposable
    {
        string m_albumName;
        DateTime m_lastUpdated;
        int m_numberOfPhotos = 0;
        UInt64 m_albumId = 0;

        public PicasaWebAlbum(string name,DateTime date,uint numberofphotos,UInt64 albumId)
        {
            this.m_numberOfPhotos = Convert.ToInt32(numberofphotos);
            this.m_albumName = name;
            this.m_lastUpdated = date;
            this.m_albumId = albumId;
        }

        public int NumberOfPhotos
        {
            get
            {
                return this.m_numberOfPhotos;
            }

        }
        public string AlbumName
        {
            get
            {
                return this.m_albumName;
            }
        }
        public DateTime LastUpdated
        {
            get
            {
                return this.m_lastUpdated;
            }
        }
        public ulong Id
        {
            get
            {
                return this.m_albumId;
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
        ~PicasaWebAlbum()
        {
          Dispose(false);
          //  Console.WriteLine("In destructor.");
        }
	#endregion        
      
    }
}
