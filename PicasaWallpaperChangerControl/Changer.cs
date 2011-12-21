using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using Sean_Jones.PicasaReader;

using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Specialized;
using System.Net;
using System.ComponentModel;
using System.Xml.Linq;
using System.Data;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    class Changer : IDisposable
    {
        public struct PictureChangerInfo
        {
            public static PictureChangerInfo nothing = new PictureChangerInfo("", "", "");
            string mPicturePath;
            string mPictureTitle;
            string mPictureId;
            public PictureChangerInfo(string path, string title, string id)
            {
                this.mPictureId = id;
                this.mPicturePath = path;
                this.mPictureTitle = title;
            }
            public string Path
            {
                get
                {
                    return this.mPicturePath;
                }
            }
            public string Title
            {
                get
                {
                    return this.mPictureTitle;
                }
            }
            public string ID
            {
                get
                {
                    return this.mPictureId;
                }
            }
            
        }
      
        string mTag = string.Empty;
        
        XPathNavigator mDatabaseNav = null;
        
        Random mRandom = null;

        private string mUserName = string.Empty;
        string mToken = string.Empty;
        public delegate void ExceptionThrown(Exception e, string action);
        public event ExceptionThrown ev_ExceptionThrown;
        private PhotoDataSet mDatabase = null;

        /// <summary>
        /// Create a new changer object
        /// </summary>
        public Changer(StringCollection tags, string password, string username)
        {
            StringBuilder tagbuild = new StringBuilder();
            this.mToken = password;
            foreach (string tag in tags)
            {
                tagbuild.Append(tag + " ");
            }
            this.mTag = tagbuild.ToString().Trim();
            tagbuild = null;
           
            this.mUserName = username;
        }

        /// <summary>Password1
        /// 
        /// Gets a picture changer info object
        /// </summary>
        /// <param name="database">The xml document containg the data</param>
        /// <param name="datapath">The path to the database</param>
        /// <param name="wallpaperSize">The %screen size of the wall paper</param>
        /// <returns>A picture change info object that will be used to change the wallpaper</returns>
        protected internal PictureChangerInfo ChangePhoto(PhotoDataSet database,string datapath, Decimal wallpaperSize)
        {
                      
            this.mRandom = new Random();
            int next = 0;
            if (database.Photo.Count > 0)
            {
                // get a random number to determine which photo
                try
                {
                    next = this.mRandom.Next(0, database.Photo.Count - 1);
                    if (next == -1)
                        next = 0;
                }
                catch (Exception ex)
                {

                    this.ev_ExceptionThrown(ex, "Changing photo. Getting a random number returned an out of range value");

                    this.mRandom = null;
                    return PictureChangerInfo.nothing;
                }


                PicasaWebPhotoConverter photo = null;

                try
                {
                    // downloads the photo
                    photo = new PicasaWebPhotoConverter(database.Photo[next].Location, database.Photo[next].Height.ToString(), database.Photo[next].Width.ToString());
                    try
                    {
                        // create the photo as file
                        photo.CreateImage();
                    }
                    catch (Exception ex)
                    {
                        this.ev_ExceptionThrown(ex, "Creating photo. Downloading from web. Photo Id " + database.Photo[next].ID);
                        if (photo != null)
                            photo.Dispose();
                        photo = null;

                        this.mRandom = null;

                        return PictureChangerInfo.nothing;
                    }
                }
                catch (Exception ex)
                {
                    this.ev_ExceptionThrown(ex, "Creating photo. Creating converter. Photo Id " + database.Photo[next].ID);
                    if (photo != null)
                        photo.Dispose();
                    photo = null;

                    this.mRandom = null;

                    return PictureChangerInfo.nothing;
                }

                try
                {
                    // look for and deletes any bitmaps in the  program directory               
                    foreach (string file in Directory.GetFiles(datapath, "*.bmp"))
                    {
                        File.Delete(file);
                    }
                }
                catch (Exception ex)
                {
                    this.ev_ExceptionThrown(ex, "Deleting old image. Deleting old bitmaps.");
                    if (photo != null)
                        photo.Dispose();
                    photo = null;

                    this.mRandom = null;

                    return PictureChangerInfo.nothing;

                }
                try
                {
                    // scales the photo to display on the screen.
                    photo.Scale(wallpaperSize).Save(datapath + "\\" + database.Photo[next].PhotoID + ".bmp", ImageFormat.Bmp);
                }
                catch (Exception ex)
                {
                    this.ev_ExceptionThrown(ex, "Creating photo. Saving and scaling. Photo Id " + database.Photo[next].ID);
                    if (photo != null)
                        photo.Dispose();
                    photo = null;
                    return PictureChangerInfo.nothing;
                }

                if (photo != null)
                    photo.Dispose();
                photo = null;
            }
            else
                return new PictureChangerInfo(string.Empty, string.Empty, string.Empty);


            return new PictureChangerInfo(datapath + "\\" + database.Photo[next].PhotoID + ".bmp", database.Photo[next].Title, database.Photo[next].ID);
        }

        /// <summary>
        /// Attempts to login to Google Accounts
        /// </summary>
        /// <returns></returns>
      /*  public bool CheckLogin(out token)
        {
            WebProxy myProxy = CreateProxy();
            PicasaWebReader reader = new PicasaWebReader(this.mUserName, this.mPassword, "WallpaperReader", myProxy);
            string CAPTCHA = string.Empty;
            string temptoken = reader.LoginToGoogle(out CAPTCHA);
            if(temptoken == string.Empty)
                return false;
            else
                token = temptoken;

            reader.Dispose();
            reader = null;
            myProxy = null;
            if (token == string.Empty)
                return CAPTCHA;
            else
                return token;
        }*/

        /// <summary>
        /// Looks for changes in the web album
        /// </summary>
        /// <param name="database"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public int Reindex(ref PhotoDataSet database, bool tags)
        {
            this.mDatabase = database;
            DateTime lastUpdated;
            if (tags)
                lastUpdated= this.GetAllAvailablePhotos();
            else
                lastUpdated = this.GetUpdatedPhotos();
            return Update(lastUpdated);
        }

        private WebProxy CreateProxy()
        {
            IWebProxy proxyServer = WebRequest.DefaultWebProxy;
            UriBuilder ub = new UriBuilder("www.google.co.uk");
            WebProxy myProxy = new WebProxy(proxyServer.GetProxy(ub.Uri));
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.UseDefaultCredentials = true;
            return myProxy;
        }

        private DateTime GetAllAvailablePhotos()
        {
           
            return new DateTime(1927, 1, 1);
        }

        private int Update(DateTime lastUpdated)
        {
            PicasaWebReader reader = null;
            WebProxy myProxy = CreateProxy();
            var albums = GetWebAlbums(myProxy);

            GetWebAlbumPhotos(albums, lastUpdated);

            TidyUp();

            if (reader != null)
            {
                reader.Dispose();
            }
            reader = null;

            int numberOfPhotos = this.mDatabase.Photo.Count;

            //database.LoadXml(photoDoc.OuterXml);

            return numberOfPhotos;
        }


        private DateTime GetUpdatedPhotos()
        {

           
            PhotoDataSet.LogRow header = null;

            // Get the last updated date
            try
            {
                header = this.mDatabase.Log.Rows[0] as PhotoDataSet.LogRow;
            }
            catch
            {
                header = this.mDatabase.Log.NewLogRow();
                header.LastModified = new DateTime(1922, 1, 1);
                this.mDatabase.Log.AddLogRow(header);
            }
            return header.LastModified;
        }

        private void TidyUp()
        {
            
          
            DataRow[] rows = this.mDatabase.Photo.Select("Keep ='false'");
            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Delete();
            }
            
        }

        

        private List<PicasaWebAlbum> GetWebAlbums(WebProxy myProxy)
        {
            List<PicasaWebAlbum> retval = new List<PicasaWebAlbum>();
            var reader = new PicasaWebReader(this.mUserName, "WallpaperReader", myProxy,this.mToken);
            try
            {
                retval.AddRange(reader.QueryAlbums());
            }
            catch (Exception e)
            {
                this.ev_ExceptionThrown(e, "Quering Albums. Album Access Error :" + e.Message);
            }
            finally
            {
                reader.Dispose();
                reader = null;
            }
            return retval;
        }

        private void GetWebAlbumPhotos(List<PicasaWebAlbum> albums,DateTime modified)
        {
            DateTime lastModified;   
            foreach (PicasaWebAlbum webAlbum in albums)
            {
                lastModified = webAlbum.LastUpdated;
                try
                {
                    if ((lastModified > modified) || (this.mDatabase.Photo.Select("Album ='" + webAlbum.AlbumName + "'").Length == 0))
                    {
                        try
                        {
                            AddPhotos(webAlbum);
                        }
                        catch (Exception ex)
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
                webAlbum.Dispose();
              
            }
            
        }

        private void CreatePhotoElement(PicasaWebPhoto photo,PicasaWebAlbum album)
        {
            bool update = false;
            var query = from photoRow in ((DataTable)this.mDatabase.Photo).AsEnumerable() 
                        where photoRow.Field<string>("ID") == photo.Id 
                        select photoRow;
            foreach (PhotoDataSet.PhotoRow photoRow in query)
            {
                if(photoRow.PhotoID != Convert.ToUInt64(photo.AccessId))
                    photoRow.PhotoID = Convert.ToUInt64(photo.AccessId);
                if(photoRow.Title != photo.Title)
                    photoRow.Title = photo.Title;
                if(photoRow.Album != photo.AlbumName)
                    photoRow.Album = photo.AlbumName;
                if(photoRow.Height != Convert.ToUInt16(photo.Height))
                    photoRow.Height = Convert.ToUInt16(photo.Height);
                if(photoRow.Width != Convert.ToUInt16(photo.Width.ToString()))
                    photoRow.Width = Convert.ToUInt16(photo.Width.ToString());
                if(photoRow.Uploaded!= photo.Uploaded)
                    photoRow.Uploaded= photo.Uploaded;
                if(photoRow.Location != photo.Location)
                    photoRow.Location = photo.Location;
                photoRow.Keep = true;
                update = true;
            }
            if(!update)
                this.mDatabase.Photo.AddPhotoRow(photo.Id, Convert.ToUInt64(photo.AccessId), photo.Title, photo.AlbumName, Convert.ToUInt16(photo.Height), Convert.ToUInt16(photo.Width.ToString()), photo.Uploaded, photo.Location,true,album.Id);
        }

        private void AddPhotos(PicasaWebAlbum album)
        {

            PicasaWebReader reader = null;
            WebProxy myProxy = CreateProxy();
            var query = from photoRow in ((DataTable)this.mDatabase.Photo).AsEnumerable()
                        where photoRow.Field<ulong>("AlbumId") == album.Id
                        select photoRow;

            foreach (PhotoDataSet.PhotoRow photoRow in query)
            {
                try
                {
                    photoRow.Keep = false;
                }
                catch
                {
                }
            }


            try
            {
                reader = new PicasaWebReader(this.mUserName,  "WebAlbum",album.Id.ToString()/* album.AlbumName.Replace(" ", "")*/, myProxy,this.mToken);
            }
            catch (Exception e)
            {
                this.ev_ExceptionThrown(e, "Collecting photos from: " + album.AlbumName + " " + this.mUserName);
                if (reader != null)
                {
                    reader.Dispose();
                }
                reader = null;

            }
            string[] tags = this.mTag.Split(" ".ToCharArray());

            List<PicasaWebPhoto> photos = null;

            foreach (string tag in tags)
            {

                photos = reader.QueryPhoto(tag);
                try
                {
                    foreach (PicasaWebPhoto webphoto in photos)
                    {

                        this.CreatePhotoElement(webphoto, album);
                        webphoto.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    this.ev_ExceptionThrown(ex, "Adding Photos to the data file");
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                    reader = null;
                    photos.Clear();
                    photos = null;
                }
            }
            if (reader != null)
            {
                reader.Dispose();
            }
            reader = null;
            photos.Clear();
            photos = null;

        }
            
        

        #region Disposal
        bool is_disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!is_disposed) // only dispose once!
            {
                if (disposing)
                {
                    this.mUserName = null;
                    this.mToken = null;
                    this.mTag = null;
                    this.mDatabaseNav = null;
                    this.mRandom = null;
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
        ~Changer()
        {
            Dispose(false);
            //  Console.WriteLine("In destructor.");
        }
        #endregion
        /*
        internal void ChangeNow()
        {
            this.ChangePhoto_Elapsed(null, null);
        }
         * */

     
    }
}
