using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Photos;
using Google.GData.Client;
using System.Net;
using System.Xml;
using System.ComponentModel;

namespace Sean_Jones.PicasaReader
{
    public class PicasaWebReader : IDisposable
    {
        PicasaService m_albumService = null;
        PicasaFeed m_albumFeed = null;
        AlbumQuery m_albumQuery = null;
        PicasaService m_photoService = null;
        PhotoQuery m_photoQuery = null;
        TagQuery m_tagQuery = null;
        PicasaService m_tagService = null;
        PicasaFeed m_photoFeed = null;
        PicasaFeed m_tagFeed = null;
        WebProxy m_myProxy = null;
        string m_userName = "";
        string m_serviceName = "";
        string m_albumName = "";
        string m_password = string.Empty;
        string mUserToken = string.Empty;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userName">The picasa web username</param>
        /// <param name="serviceName">The service name you wish to use (can be anything)</param>
        /// <param name="password">The google password</param>
        /// <param name="myProxy">The proxy used to connect to the web</param>
        public PicasaWebReader(string userName,string serviceName,WebProxy myProxy,string token)
        {
            this.m_userName = userName;
        
            this.m_serviceName = serviceName;
           // this.m_myProxy = myProxy;
            this.mUserToken = token;

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="userName">The picasa web username</param>
        /// <param name="serviceName">The service name you wish to use (can be anything)</param>
        /// <param name="albumName">a specific album name</param>
        /// <param name="password">The google usertoken</param>
        /// <param name="myProxy">The proxy used to connect to the web</param>
        public PicasaWebReader(string userName, string serviceName, string albumName, WebProxy myProxy,string token)
        {
            this.m_userName = userName;
            //this.m_password = password;
            this.m_serviceName = serviceName;
            this.m_albumName = albumName;
         //   this.m_myProxy = myProxy;
            this.mUserToken =token;
        }

      /*  public string LoginToGoogle(out string token)
        {
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", this.m_serviceName);
            authFactory.AccountType = "GOOGLE_OR_HOSTED";

            this.m_albumService = new PicasaService(authFactory.ApplicationName);
            try
            {
                this.m_albumService.setUserCredentials(this.m_userName, this.m_password);
                this.m_albumService.QueryAuthenticationToken(); // Authenticate the user immediately
            }
            catch (CaptchaRequiredException e)
            {
                token = e.Token;
                return e.Url;
            }
        }

        public string LoginToGoogle(out string token, string CAPTCHAAnswer, string CAPTCHAToken)
        {
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", this.m_serviceName);
            authFactory.AccountType = "GOOGLE_OR_HOSTED";
            string token = string.Empty;
            this.m_albumService = new PicasaService(authFactory.ApplicationName);
            authFactory.CaptchaAnswer = CAPTCHAAnswer;
            authFactory.CaptchaToken = CAPTCHAToken;
            this.m_albumService.setUserCredentials(this.m_userName, this.m_password);

            token = this.m_albumService.QueryAuthenticationToken(); // Authenticate the user immediately
            return token;


        }
        */
        public List<PicasaWebAlbum> QueryAlbums()
        {
            // Create an authentication factory to deal with logging in.
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", this.m_serviceName);
            authFactory.AccountType = "GOOGLE_OR_HOSTED";
                       
            this.m_albumService = new PicasaService(authFactory.ApplicationName);
            this.m_albumService.RequestFactory = authFactory;
            this.m_albumService.SetAuthenticationToken(this.mUserToken);
           
         
            this.m_albumQuery = new AlbumQuery(PicasaQuery.CreatePicasaUri("default"));
            this.m_albumQuery.Access = PicasaQuery.AccessLevel.AccessAll;
           

            List<PicasaWebAlbum> retval = new List<PicasaWebAlbum>();
           
            try
            {
                CreateAlbumProxy();
                this.m_albumFeed = this.m_albumService.Query(this.m_albumQuery);
                
            }
            catch (Exception e)
            {
                this.m_albumQuery = null;
                this.m_albumService.RequestFactory = null;
                this.m_albumService = null;
                this.m_albumFeed = null;
                retval = null;
                throw new Exception("PicasaReader failed when downloading album feed for "+this.m_userName, e);

            }
            foreach (PicasaEntry entry in this.m_albumFeed.Entries)
            {
                AlbumAccessor ac = new AlbumAccessor(entry);
                retval.Add(new PicasaWebAlbum(entry.Title.Text, entry.Updated,ac.NumPhotos,Convert.ToUInt64(ac.Id)));
            }
            this.m_albumQuery = null;
            this.m_albumService.RequestFactory = null;
            this.m_albumService = null;
            this.m_albumFeed = null;
            return retval;
        }
       
        public List<PicasaWebAlbum> QueryAlbums(BackgroundWorker worker, int overallJobPercent)
        {
            // Create an authentication factory to deal with logging in.
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", this.m_serviceName);
            authFactory.AccountType = "GOOGLE_OR_HOSTED";


            this.m_albumQuery = new AlbumQuery(PicasaQuery.CreatePicasaUri("default"));
            this.m_albumQuery.Access = PicasaQuery.AccessLevel.AccessAll;
            this.m_albumService = new PicasaService(authFactory.ApplicationName);
            this.m_albumService.RequestFactory = authFactory;
           // this.m_albumService.setUserCredentials(this.m_userName, this.m_password);
            //string token = this.m_albumService.QueryAuthenticationToken();
            this.m_albumService.SetAuthenticationToken(this.mUserToken);
            List<PicasaWebAlbum> retval = new List<PicasaWebAlbum>();
            decimal count = ((decimal)overallJobPercent / 100) * 10;
            int smallCount = (int)count;
            try
            {
                worker.ReportProgress(0, (object)"Creating proxy");
                CreateAlbumProxy();
                worker.ReportProgress(smallCount, (object)"Proxy created");
                worker.ReportProgress(0, (object)"Querying google");
                this.m_albumFeed = this.m_albumService.Query(this.m_albumQuery);
                worker.ReportProgress(smallCount, (object)"Done");
            }
            catch (Exception e)
            {
                this.m_albumQuery = null;
                this.m_albumService.RequestFactory = null;
                this.m_albumService = null;
                this.m_albumFeed = null;
                retval = null;
                throw new Exception("PicasaReader failed when downloading album feed for " + this.m_userName, e);

            }
            if (this.m_albumFeed.Entries.Count > 0)
            {
                int percent = (int)Math.Round((decimal)((overallJobPercent - (smallCount * 2)) / this.m_albumFeed.Entries.Count), 0);
                worker.ReportProgress(0, (object)"Processing album data");
                foreach (PicasaEntry entry in this.m_albumFeed.Entries)
                {

                    AlbumAccessor ac = new AlbumAccessor(entry);

                    retval.Add(new PicasaWebAlbum(entry.Title.Text, entry.Updated, ac.NumPhotos, Convert.ToUInt64(ac.Id)));
                    worker.ReportProgress(percent, null);

                }
            }
            this.m_albumQuery = null;
            this.m_albumService.RequestFactory = null;
            this.m_albumService = null;
            this.m_albumFeed = null;
            return retval;
        }

        public List<PicasaWebPhoto> QueryPhoto(string tags)
        {
            List<PicasaWebPhoto> retval = new List<PicasaWebPhoto>();
            GDataGAuthRequestFactory authFactory = new GDataGAuthRequestFactory("lh2", this.m_serviceName);
            authFactory.AccountType = "GOOGLE_OR_HOSTED";
            this.m_photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri(this.m_userName, this.m_albumName));
            this.m_photoQuery.Tags = tags;
           
            this.m_photoService = new PicasaService(authFactory.ApplicationName);
            this.m_photoService.RequestFactory = authFactory;
            //this.m_photoService.setUserCredentials(this.m_userName, this.m_password);
            this.m_photoService.SetAuthenticationToken(this.mUserToken);


          
          
            CreatePhotoProxy();
            try
            {
                this.m_photoFeed = this.m_photoService.Query(this.m_photoQuery);

                foreach (PicasaEntry photo in this.m_photoFeed.Entries)
                {
                    retval.Add(new PicasaWebPhoto(photo, this.m_albumName));
                }
            }
            catch (Exception e)
            {
                
                throw new Exception("Query Photo Exception", e);
            }
            finally
            {
                this.m_photoQuery = null;
                this.m_photoService.RequestFactory = null;
                this.m_photoService = null;
                this.m_photoFeed = null;
            }

          
            return retval;
        }

        public List<PicasaWebPhoto> QueryPhoto(BackgroundWorker worker, int overallJobPercent)
        {
            List<PicasaWebPhoto> retval = new List<PicasaWebPhoto>();
            this.m_photoQuery = new PhotoQuery(PicasaQuery.CreatePicasaUri(this.m_userName, this.m_albumName));
      
            this.m_photoService = new PicasaService(this.m_serviceName);
            //this.m_photoService.setUserCredentials(this.m_userName, this.m_password);
            this.m_photoService.SetAuthenticationToken(this.mUserToken);
            decimal count = ((decimal)overallJobPercent / 100) * 10;
            int smallCount = (int)count;
            worker.ReportProgress(0, (object)"Creating proxy");
            CreatePhotoProxy();
            try
            {
                worker.ReportProgress(smallCount, (object)"Proxy created");
                worker.ReportProgress(0, (object)"Querying google");
                this.m_photoFeed = this.m_photoService.Query(this.m_photoQuery);
                worker.ReportProgress(smallCount, (object)"Done");
                if (this.m_photoFeed.Entries.Count > 0)
                {
                    int percent = (int)Math.Round((decimal)((overallJobPercent - (smallCount * 2)) / this.m_photoFeed.Entries.Count), 0);
                    worker.ReportProgress(0, (object)"Processing photo data");
                    foreach (PicasaEntry photo in this.m_photoFeed.Entries)
                    {
                        retval.Add(new PicasaWebPhoto(photo, this.m_albumName));
                        worker.ReportProgress(percent, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.m_photoQuery = null;
                this.m_photoService.RequestFactory = null;
                this.m_photoService = null;
                this.m_photoFeed = null;
                throw new Exception("Query Photo Exception", e);

            }

            this.m_photoQuery = null;
            this.m_photoService.RequestFactory = null;
            this.m_photoService = null;
            this.m_photoFeed = null;
            return retval;
        }

        public List<string> QueryTag(PicasaWebPhoto photo)
        {
            List<string> retval = new List<string>();
            this.m_tagQuery = new TagQuery(TagQuery.CreatePicasaUri(this.m_userName, this.m_albumName, photo.AccessId));
            this.m_tagService = new PicasaService("Tags");
            //this.m_tagService.setUserCredentials(this.m_userName, this.m_password);
            this.m_tagService.SetAuthenticationToken(this.mUserToken);
            CreateTagProxy();
            try
            {
                this.m_tagFeed = this.m_tagService.Query(this.m_tagQuery);

                foreach (PicasaEntry entry in m_tagFeed.Entries)
                {
                    retval.Add(entry.Title.Text);
                }
            }
            catch (Exception e)
            {
                this.m_tagQuery = null;
                this.m_tagService.RequestFactory = null;
                this.m_tagService = null;
                this.m_tagFeed = null;
                throw new Exception("Query Tag Exception", e);

            }


            this.m_tagQuery = null;
            this.m_tagService.RequestFactory = null;
            this.m_tagService = null;
            this.m_tagFeed = null;
            return retval;

        }

        public List<string> QueryTag(PicasaWebPhoto photo, BackgroundWorker worker, int overallJobPercent)
        {
            List<string> retval = new List<string>();
            this.m_tagQuery = new TagQuery(TagQuery.CreatePicasaUri(this.m_userName, this.m_albumName, photo.AccessId));
            this.m_tagService = new PicasaService("Tags");
            //this.m_tagService.setUserCredentials(this.m_userName, this.m_password);
            this.m_tagService.SetAuthenticationToken(this.mUserToken);
            decimal count = ((decimal)overallJobPercent / 100) * 10;
            int smallCount = (int)count;
            worker.ReportProgress(0, (object)"Creating proxy");
            CreateTagProxy();
            try
            {
                worker.ReportProgress(smallCount, (object)"Proxy created");
                worker.ReportProgress(0, (object)"Querying google");
                this.m_tagFeed = this.m_tagService.Query(this.m_tagQuery);
                worker.ReportProgress(smallCount, (object)"Done");
                if (this.m_tagFeed.Entries.Count > 0)
                {
                    int percent = (int)Math.Round((decimal)((overallJobPercent - (smallCount * 2)) / this.m_tagFeed.Entries.Count), 0);
                    worker.ReportProgress(0, (object)"Processing tag data");
                    foreach (PicasaEntry entry in m_tagFeed.Entries)
                    {
                        retval.Add(entry.Title.Text);
                        worker.ReportProgress(percent, null);
                    }
                }
            }
            catch (Exception e)
            {
                this.m_tagQuery = null;
                this.m_tagService.RequestFactory = null;
                this.m_tagService = null;
                this.m_tagFeed = null;
                throw new Exception("Query Tag Exception", e);

            }


            this.m_tagQuery = null;
            this.m_tagService.RequestFactory = null;
            this.m_tagService = null;
            this.m_tagFeed = null;
            return retval;
        }

        public List<string> UpdatePhotoTag()
        {
            return null;
        }
        
        
        
        
        private void CreateTagProxy()
        {
            GDataRequestFactory requestFactory = (GDataRequestFactory)this.m_tagService.RequestFactory;

            /*IWebProxy iProxy = WebRequest.DefaultWebProxy;
            WebProxy myProxy = new WebProxy(iProxy.GetProxy(this.m_albumQuery.Uri));
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.UseDefaultCredentials = true;*/
            requestFactory.Proxy = this.m_myProxy;
        }

        private void CreateAlbumProxy()
        {
          //  GDataRequestFactory requestFactory = (GDataRequestFactory)this.m_albumService.RequestFactory;
            
            /*IWebProxy iProxy = WebRequest.DefaultWebProxy;
            WebProxy myProxy = new WebProxy(iProxy.GetProxy(this.m_albumQuery.Uri));
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.UseDefaultCredentials = true;*/
          // requestFactory.Proxy = this.m_myProxy;
        }

        private void CreatePhotoProxy()
        {
           // GDataRequestFactory requestFactory = (GDataRequestFactory)this.m_photoService.RequestFactory;
            /*IWebProxy iProxy = WebRequest.DefaultWebProxy;
            WebProxy myProxy = new WebProxy(iProxy.GetProxy(this.m_photoQuery.Uri));
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.UseDefaultCredentials = true;*/
          //  requestFactory.Proxy = this.m_myProxy;
        }

        #region Disposal
        bool is_disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!is_disposed) // only dispose once!
            {
                if (disposing)
                {
                    
                    m_albumService = null;
                    m_albumFeed = null;
                    m_albumQuery = null;
                    m_photoService = null;
                    m_photoQuery = null;
                    m_photoFeed = null;
                    m_userName = null;
                    m_serviceName = null;
                    m_albumName = null;
                }

            }
            this.is_disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            // tell the GC not to finalize
            GC.SuppressFinalize(this);
        }
        ~PicasaWebReader()
        {
            Dispose(false);
            //  Console.WriteLine("In destructor.");
        }
        #endregion




    }
}
