using System;
using System.Collections.Generic;
using System.Text;

namespace Sean_Jones.PicasaWallpaperChangerControl
{

    public class PicasaWallpaperEventArgs : EventArgs
    {
        List<string> m_items = null;
        decimal m_changeInterval;
    
        decimal m_sizePercent;
        string mUserName = string.Empty;
        string mPassword = string.Empty;
        bool m_autorun;
        DateTime mReindexTime;
        bool m_startNow;
        bool m_stopNow;
        string mToken = string.Empty;
        public PicasaWallpaperEventArgs(List<string> items)
        {
            m_items = items;
        }
        public PicasaWallpaperEventArgs(decimal changeInterval, DateTime reindexTime)
        {
            this.m_changeInterval = changeInterval;
           
            this.mReindexTime = reindexTime;
        }
        public PicasaWallpaperEventArgs(decimal sizePercent)
        {

            this.m_sizePercent = sizePercent;
        }
        public PicasaWallpaperEventArgs(bool autoRun, bool startnow, bool stopnow)
        {
            this.m_autorun = autoRun;
            this.m_startNow = startnow;
            this.m_stopNow = stopnow;
        }

        public PicasaWallpaperEventArgs(string userName, string password, string token)
        {
            if (userName != string.Empty)
                this.mUserName = userName;
            if (password != string.Empty)
                this.mPassword = password;
            if (token != string.Empty)
                this.mToken = token;
        }

        public string UserName
        {
            get
            {
                return this.mUserName;
            }
        }
        public string Password
        {
            get
            {
                return this.mPassword;
            }
        }
        public string Token
        {
            get
            {
                return this.mToken;
            }
        }
        public List<string> Items
        {
            get
            {
                return m_items;
            }
        }
        public decimal ChangeInterval
        {
            get
            {
                return this.m_changeInterval;
            }
        }
        public decimal SizePercent
        {
            get
            {
                return this.m_sizePercent;
            }
        }
        
        public DateTime ReindexTime
        {
            get
            {
                return this.mReindexTime;
            }
        }
        public bool StartNow
        {
            get
            {
                return this.m_startNow;
            }
        }
        public bool Autorun
        {
            get
            {
                return this.m_autorun;
            }
        }
        public bool StopNow
        {
            get
            {
                return this.m_stopNow;
            }
        }
    }
}
