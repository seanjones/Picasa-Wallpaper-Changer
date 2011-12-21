using System;
using System.Threading;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using System.Xml;
using System.Xml.XPath;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    /// <summary>
    /// The panels that can be viewed
    /// </summary>
    public enum AvailablePanels 
    {
        Controls,Size,Tags,Source,Changer,Timings,None,Wizard_Start
    };

    public partial class Controller : Form
    {
        private static EventLogger eventLog = new EventLogger(Application.UserAppDataPath + "\\Events.Xml");

        const int NumberOfPanels = 6;
        ControlsPanel mControlsPanel = null; 
        SourcePanel mSourcePanel = null;
        SizePanel mSizePanel = null;
        TagsPanel mTagsPanel = null;
        TimingsPanel mTimingsPanel = null;
        ChangerPanel mChangerPanel = null;
        FormWindowState mLastState;
        AvailablePanels mCurrentPanelIndex;
        ControlPanel mCurrentPanel = null;
        internal int mPictureChangeInterval = 0;
        string mDataPath = string.Empty;
        bool mAutoRun;
        int mNumberOfPictures;
        string mToken = string.Empty;
        /// <summary>
        /// Whether or not the app has been run before
        /// </summary>
        internal bool mRunBefore = false;

        /// <summary>
        /// The size of the wallpaper as a % of screensize
        /// </summary>
        internal decimal mWallpaperSize = 0.0M;

        /// <summary>
        /// The tags to use when choosing pictures
        /// </summary>
        internal StringCollection mTags = null;

        /// <summary>
        /// The collection of users to collect pictures from
        /// </summary>
        internal string mUserName = string.Empty;

        internal string mPasswordKey = string.Empty;

        internal DateTime mReindexedDate;

        internal string mPasswordIV = string.Empty;

        internal string mEncryptedToken = string.Empty;

        internal DateTime mReindexTime;
        

        // Set initial variables for running the app
        PhotoDataSet database = new PhotoDataSet();

        Mutex mutex = new Mutex();


        /// <summary>
        /// Call this to check/create an xml file of avaliable photos
        /// </summary>
        /// <param name="datapath">The path were the data should be saved</param>
        /// <param name="numberOfPhotos">the number of photos found</param>
        /// <param name="database">The Xml database</param>
        void ValidateDatabaseFile(ref string datapath, ref PhotoDataSet database)
        {
            // check that the database exists if not create it
            if (!System.IO.File.Exists(datapath))
            {
                System.IO.File.Create(datapath).Close();
            }
            try
            {
                // check the xml document exists
                if (database == null)
                    database = new PhotoDataSet();
                // lock it

                if (database.Log.Rows.Count == 0)
                {
                    // load into it
                    database.ReadXml(datapath, XmlReadMode.Auto);
                }
                this.mNumberOfPictures = database.Photo.Count;


            }
            catch (Exception er)
            {
                database = new PhotoDataSet();
                this.mNumberOfPictures = -1;
            }
        }

        /// <summary>
        /// Loads up settings from the setting file
        /// </summary>
        private void LoadSettings()
        {
            Properties.Settings SettingsData = Properties.Settings.Default;
            // Load up the settings data

            this.mRunBefore = SettingsData.RunBefore;

            // the size of the wallpaper
            this.mWallpaperSize = SettingsData.SizePercent;
            // Where to get pictures from
            this.mUserName = SettingsData.PictureSource;
            // The tags to use when choosing pictures
            this.mTags = SettingsData.Tags;
            // the user password
            this.mEncryptedToken = SettingsData.UserToken;
            // the number of stored pics
            this.mNumberOfPictures = SettingsData.numberOfPhotos;
            // how often to change the picture
            this.mPictureChangeInterval = SettingsData.ChangeInterval;
            // the time of day to look for new pictures
            this.mReindexTime = SettingsData.IndexTime;
            this.mReindexedDate = SettingsData.reindexedDate;
            // the encryption vectors
            this.mPasswordIV = SettingsData.SourcePasswordIV;
            this.mPasswordKey = SettingsData.SourcePasswordKey;

        }

        /// <summary>
        /// Loads up settings from the setting file
        /// </summary>
        private void SaveSettings()
        {
            Properties.Settings SettingsData = Properties.Settings.Default;
            // Load up the settings data

            SettingsData.RunBefore = this.mRunBefore;

            // the size of the wallpaper
            SettingsData.SizePercent = this.mWallpaperSize;
            // Where to get pictures from
            SettingsData.PictureSource = this.mUserName;
            // The tags to use when choosing pictures
            SettingsData.Tags = this.mTags;
            // the user password
            SettingsData.UserToken = this.mEncryptedToken;
            // the number of stored pics
            SettingsData.numberOfPhotos = this.mNumberOfPictures;
            // how often to change the picture
            SettingsData.ChangeInterval = this.mPictureChangeInterval;
            // the time of day to look for new pictures
            SettingsData.IndexTime  = this.mReindexTime;
            SettingsData.reindexedDate= this.mReindexedDate;
            // the encryption vectors
            SettingsData.SourcePasswordIV = this.mPasswordIV ;
            SettingsData.SourcePasswordKey = this.mPasswordKey;
            SettingsData.Save();

        }
      
       

        private void Reindex(bool reindexAll)
        {
            
            lock (mutex)
            {
                if(reindexAll)
                    this.UpdateStatus("Currently reindexing all photos");
                else
                    this.UpdateStatus("Currently checking for new photos");
                Changer changer = new Changer(this.mTags, AccountLogin.DecryptPassword(this.mUserName, this.mEncryptedToken, this.mPasswordKey, this.mPasswordIV), this.mUserName);
                changer.ev_ExceptionThrown += new Changer.ExceptionThrown(changer_ev_ExceptionThrown);
                
                this.ValidateDatabaseFile(ref mDataPath, ref database);
                changer.Reindex(ref this.database, reindexAll);
                changer.Dispose();
                changer = null;

                this.mNumberOfPictures = database.Photo.Count;
                
                this.mReindexedDate = DateTime.Now;
                
                PhotoDataSet.LogRow header = null;

                // Get the last updated date
                try
                {
                    header = this.database.Log.Rows[0] as PhotoDataSet.LogRow;
                    header.LastModified = DateTime.Now;
                }
                catch
                {

                    header = this.database.Log.NewLogRow();
                    header.LastModified = DateTime.Now;
                    this.database.Log.AddLogRow(header);
                }
                this.database.WriteXml(this.mDataPath);
                this.UpdateStatus("Currently waiting to change pictures");
                this.UpdateNumberOfPhotosIndexed("There are "+this.mNumberOfPictures.ToString()+" photos available");
                this.UpdateLastIndexed("Last Updated " + DateTime.Now.ToShortDateString());

            }
        }

        private delegate void UpdateStatusDelegate(string status);
        
        private void UpdateStatus(string status)
        {
            if(this.mChangerStatus.InvokeRequired)
            {
                this.mChangerStatus.BeginInvoke(new UpdateStatusDelegate(UpdateStatus), new object[] { status });
            }
            else
            {
                this.mChangerStatus.Text = status;
            }
        }

        private delegate void UpdateLastIndexedDelegate(string lastIndexed);

        private void UpdateLastIndexed(string status)
        {
            if (this.mChangerStatus.InvokeRequired)
            {
                this.mLastIndexed.BeginInvoke(new UpdateLastIndexedDelegate(UpdateLastIndexed), new object[] { status });
            }
            else
            {
                this.mLastIndexed.Text = status;
            }
        }

        private delegate void UpdateNumberOfPhotosDelegate(string numberOfPhotos);

        private void UpdateNumberOfPhotosIndexed(string status)
        {
            if (this.mChangerStatus.InvokeRequired)
            {
                this.mNumberOfPhotos.BeginInvoke(new UpdateNumberOfPhotosDelegate(UpdateNumberOfPhotosIndexed), new object[] { status });
            }
            else
            {
                this.mNumberOfPhotos.Text = status;
            }
        }


       

        void changer_ev_ExceptionThrown(Exception e, string action)
        {
           // MessageBox.Show(e.Message,"Picasa Wallpaper Changer");
           
            //MessageBox.Show(e.Message + " whilst doing: " + p, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lock (Controller.eventLog)
            {
                Controller.eventLog.LogEvent(e.Message + " whilst doing: " + action, "Controller");
                //EventLog.WriteEntry("PicasaWallpaperChangerControl", e.Message + " whilst doing: " + action, EventLogEntryType.Error);
            }
        }
        
        public void Change()
        {
            bool reindex = false;
            lock (mutex)
            {
                Changer changer = new Changer(this.mTags, AccountLogin.DecryptPassword(this.mUserName, this.mEncryptedToken, this.mPasswordKey, this.mPasswordIV), this.mUserName);
                changer.ev_ExceptionThrown += new Changer.ExceptionThrown(changer_ev_ExceptionThrown);
                this.ValidateDatabaseFile(ref mDataPath, ref database);
                Changer.PictureChangerInfo newPicture = changer.ChangePhoto(database, Application.UserAppDataPath, this.mWallpaperSize);
                if (newPicture.Path.Length > 0 && newPicture.ID.Length > 0 && newPicture.Title.Length > 0)
                {
                    Program.ChangePicture(changer.ChangePhoto(database, Application.UserAppDataPath, this.mWallpaperSize));
                }
                else if (database.Photo.Count == 0)
                {
                    reindex = true;
                }
                changer.ev_ExceptionThrown -= new Changer.ExceptionThrown(changer_ev_ExceptionThrown);
                changer.Dispose();
                changer = null;

            }
            if (reindex)
                this.Reindex(true);
        }

        
        /// <summary>
        /// This is the container for the various control panels that can be displayed.
        /// </summary>
        public Controller()
        {
          
            InitializeComponent();



            this.mDataPath = Application.UserAppDataPath + "\\database.xml";
            
            this.LoadSettings();
            //lock (eventLog)
            //{
            //    eventLog.LogEvent("Starting", "Startup");
            //}
            // the time that should elapse between firing the changephoto action
            this.mChangePhotoTimer.Interval = (this.mPictureChangeInterval * 60) * 1000;

            // set up the event handler for the photo change action
            this.mChangePhotoTimer.Tick += new EventHandler(ChangePhotoTimer_Tick);

            // the time that should elapse between firing the re-index action
            TimeSpan when = this.mReindexTime.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);

            // workout the ticks for the reindex interval days, and sets the time accordingly.
            if (when.Ticks < 0)
                when = when.Add(new TimeSpan(1, 0, 0, 0));
            this.mReindexTimer.Interval = (int)when.TotalMilliseconds;


            // set up the event handler for the index change action
            this.mReindexTimer.Tick += new EventHandler(ReindexTimer_Tick);

            // start the timers
            this.mReindexTimer.Start();
            this.mChangePhotoTimer.Start();
            
        }

       

        /// <summary>
        /// The Controller has loaded so lets fill it with joy.
        /// </summary>
        /// <param name="sender">The controller</param>
        /// <param name="e"></param>
        private void Controller_Load(object sender, EventArgs e)
        {
            // the program has not run before so pull some data from the settings file. The visible control panel will be the wizard
            // start panel
            if (this.mRunBefore == false)
            {
                this.UpdateNumberOfPhotosIndexed("There are " + this.mNumberOfPictures.ToString() + " photos available");

                this.UpdateLastIndexed("Last Updated " + this.mReindexedDate.ToShortDateString());

                this.UpdateStatus("Currently idle");
               
                this.WindowState = FormWindowState.Normal;
                this.mNotifyIcon.Visible = false;
            }
            else // the app has run before.
            {
                this.UpdateNumberOfPhotosIndexed("There are " + this.mNumberOfPictures.ToString() + " photos available");

                this.UpdateLastIndexed("Last Updated " + this.mReindexedDate.ToShortDateString());

                this.UpdateStatus("Currently waiting to change pictures");

                this.mCurrentPanelIndex = AvailablePanels.Controls;
                // Kill off the Wizard Panel
                this.mNewPanel.Dispose();
                this.mNewPanel = null;
                // and minimize
                this.WindowState = FormWindowState.Minimized;
            }

        }

        /// <summary>
        /// Fires when its time to re-index (check for new photos)
        /// </summary>
        /// <remarks>
        /// This will add a reindex action to the action queue.
        /// </remarks>
        /// <param name="sender">The reindex timer</param>
        /// <param name="e">Who knows</param>
        void ReindexTimer_Tick(object sender, EventArgs e)
        {
            this.mReindexTimer.Stop();

            TimeSpan when;
            // Check that the current time matches the requested reindex time. If it doesn't calculate when it does.
            if ((DateTime.Now.TimeOfDay.Hours != this.mReindexTime.TimeOfDay.Hours) || (DateTime.Now.TimeOfDay.Minutes != this.mReindexTime.TimeOfDay.Minutes))
            {
                // this code updates the reindex timer with the correct number of elapsed seconds before the timer tries to reindex
                when = this.mReindexTime.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);
                if (when.Ticks < 0)
                    when = when.Add(new TimeSpan(1, 0, 0, 0));
                try
                {
                    this.mReindexTimer.Interval = (int)when.TotalMilliseconds;
                }
                catch (Exception ex)
                {
                    this.mReindexTimer.Interval = (int)(new TimeSpan(1, 0, 0, 0)).TotalMilliseconds;
                }
                    
            }
            else // Its time to reindex
            {

                ThreadPool.QueueUserWorkItem(new WaitCallback(this.CheckForUpdatesHandler));
                
                // calculate when the next run is needed
                when = new TimeSpan(1, 0, 0, 0);
                this.mReindexTimer.Interval = (int)when.TotalMilliseconds;
            }
            // restart the Timer.
            this.mReindexTimer.Start();
        }

        /// <summary>
        /// Fires when its time to change the wallpaper
        /// </summary>
        /// <param name="sender">the changer timer</param>
        /// <param name="e"></param>
        void ChangePhotoTimer_Tick(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ChangePhotoHandler));
          
        }

        /// <summary>
        /// Delegate for displaying a control panel to the user, and removing the old one on the main thread
        /// </summary>
        /// <param name="newOne">The new control to create</param>
        /// <param name="oldOne">The old control to destroy</param>
        public delegate void DisplayMe(AvailablePanels newOne, AvailablePanels oldOne);
        
        /// <summary>
        /// The delegate method which calls the function to do the destruction
        /// </summary>
        /// <param name="newOne">The new control to create</param>
        /// <param name="oldOne">The old control to destroy</param>
        public void DisplayMeHandler(AvailablePanels newOne, AvailablePanels oldOne)
        {
            this.DisplayPanel(newOne, oldOne);
        }


        public void ReindexTagsHandler(object o)
        {
            this.Reindex(true);
        }


        public void CheckForUpdatesHandler(object tags)
        {
            this.Reindex(false);
        }


        public void ChangePhotoHandler(object tags)
        {
            this.Change();
        }



        /// <summary>
        /// The mouse has been clicked on the notify icon by the clock
        /// </summary>
        /// <remarks>
        /// Left click changes the photo, right click opens the control panel
        /// </remarks>
        /// <param name="sender">The icon clicked on</param>
        /// <param name="e">The mouse</param>
        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case (MouseButtons.Left): // Change the photo
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ChangePhotoHandler));
                    break;
                case (MouseButtons.Right): // open the control panel
                    lock (this)
                    {
                        if (this.WindowState == FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// The next button has been clicked on the wizard start page
        /// </summary>
        /// <param name="sender">The next button</param>
        /// <param name="e">nothing</param>
        private void NewPanelNext_Click(object sender, EventArgs e)
        {
            // Create the next panel that needs to be displayed.
            BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Source, AvailablePanels.Wizard_Start });
        }

        /// <summary>
        /// Fired when the Source Panel OK button is clicked.
        /// </summary>
        /// <remarks>
        /// Once complete it will either return to the controls panel, or the next panel in the wizard sequence ( Timings)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SourcePanel_ev_EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result)
        {
            bool userChanged = false;
            // The user OKed the changes
            if (result == DialogResult.OK)
            {
                // And a new username was added.
                if (e.UserName != string.Empty)
                {
                    this.mUserName = e.UserName;
                }
                // if  a new password was added
                if (e.Password != string.Empty)
                {
                    // set the settings
                   // this.mEncryptedToken = AccountLogin.EncryptPassword(this.mUserName, e.Password, ref this.mPasswordKey, ref this.mPasswordIV);

                }
                // if a token was created
                if (e.Token != string.Empty)
                {
                    this.mEncryptedToken = AccountLogin.EncryptPassword(this.mUserName, e.Token, ref this.mPasswordKey, ref this.mPasswordIV);
                   // this.mToken = e.Token;
                }
                // only update anything if we have run before, and the user has changed
                if ((this.mRunBefore) && (userChanged == true))
                {
                    // reindex
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ReindexTagsHandler));
                }
            }
            if (this.mRunBefore)
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Controls, AvailablePanels.Source });
            }
            else
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Timings, AvailablePanels.Source });
            }
        }
       
        /// <summary>
        /// Fired when the timings Panel OK button is clicked.
        /// </summary>
        /// <remarks>
        /// Once complete it will either return to the controls panel, or the next panel in the wizard sequence ( Tags)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TimingsPanel_ev_EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result)
        {
            // We have okayed the dialog
            if (result == DialogResult.OK)
            {
                this.mReindexTime = e.ReindexTime;
                this.mPictureChangeInterval = (int)e.ChangeInterval;
                // stop the times and recalculate the ticks before next firing
                this.mReindexTimer.Stop();
                this.mChangePhotoTimer.Stop();

                TimeSpan when = this.mReindexTime.TimeOfDay.Subtract(DateTime.Now.TimeOfDay);

                // workout the ticks for the reindex interval days, and sets the time accordingly.
                if (when.Ticks < 0)
                    when = when.Add(new TimeSpan(1, 0, 0, 0)); // we have missed the reindex time, so add a day
                this.mReindexTimer.Interval = (int)when.TotalMilliseconds;

                // set the photo changer time
                this.mChangePhotoTimer.Interval = ((int)e.ChangeInterval * 60) * 1000;
                this.mReindexTimer.Start();
                this.mChangePhotoTimer.Start();
            }
            if (this.mRunBefore)
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Controls, AvailablePanels.Timings });
            }
            else
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Tags, AvailablePanels.Timings });
            }
        }

        /// <summary>
        /// Fired when the tags Panel OK button is clicked.
        /// </summary>
        /// <remarks>
        /// Once complete it will either return to the controls panel, or the next panel in the wizard sequence ( Size)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TagsPanel_ev_EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result)
        {
            // Tags okayed
            if (result == DialogResult.OK)
            {
                if (e.Items.Count > 0)
                {
                    this.mTags.Clear();

                    foreach (string s in e.Items)
                    {
                        this.mTags.Add(s);

                    }
                }
            }
            if (this.mRunBefore)
            {
                if (result == DialogResult.OK)
                {
                    // Reindex
                    if (e.Items.Count > 0)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(ReindexTagsHandler));
                    }
                }
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Controls, AvailablePanels.Tags });
            }
            else
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Size, AvailablePanels.Tags });
            }
        }
        
        /// <summary>
        /// Fired when the size Panel OK button is clicked.
        /// </summary>
        /// <remarks>
        /// Once complete it will either return to the controls panel, or the next panel in the wizard sequence ( changer)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SizePanel_ev_EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result)
        {
            // SizePanel panel = this.mCurrentPanel.Controls[0] as SizePanel;
            if (result == DialogResult.OK)
            {
                this.mWallpaperSize = e.SizePercent;
            }
            if (this.mRunBefore)
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Controls, AvailablePanels.Size });
            }
            else
            {
                BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Changer, AvailablePanels.Size });
            }
        }

        /// <summary>
        /// Fired when the changer Panel OK button is clicked.
        /// </summary>
        /// <remarks>
        /// Once complete it will either return to the controls panel, or the next panel in the wizard sequence ( Controls)
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ChangerPanel_ev_EventFired(object sender, PicasaWallpaperEventArgs e, DialogResult result)
        {

            // ChangerPanel panel = this.mCurrentPanel.Controls[0] as ChangerPanel;
            if (result == DialogResult.OK)
            {

                this.mAutoRun = e.Autorun;

                if (!e.Autorun)
                {
                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Picasa Wallpaper Changer.lnk"))
                    {
                        System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Picasa Wallpaper Changer.lnk");
                    }
                }
                else
                {
                    if (!System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Picasa Wallpaper Changer.lnk"))
                    {
                        WshShellClass shell = new WshShellClass();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\Picasa Wallpaper Changer.lnk");
                        shortcut.TargetPath = Application.ExecutablePath;
                        shortcut.Description = "Picasa Wallpaper Changer";
                        shortcut.IconLocation = Application.StartupPath + "\\pwcc.ico";
                        shortcut.Save();
                        shortcut = null;
                        shell = null;
                    }
                }

                if (e.StopNow)
                {
          

                    this.UpdateStatus("Currently idle");
                    this.mChangePhotoTimer.Stop();
                    this.mReindexTimer.Stop();
                  
                }
                if (e.StartNow)
                {
                    this.UpdateStatus("Currently waiting to change pictures");
                    this.mChangePhotoTimer.Start();
                    this.mReindexTimer.Start();
                  
                }
            }
            if (!this.mRunBefore)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ReindexTagsHandler));
                this.mRunBefore = true;
            }
            BeginInvoke(new DisplayMe(DisplayMeHandler), new object[] { AvailablePanels.Controls, AvailablePanels.Changer });
        }

        /// <summary>
        /// One of the controls buttons have been clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="option"></param>
        void ControlsPanel_ev_OptionSelected(object sender, ControlsPanel.ButtonClicked option)
        {
            switch (option)
            {
                case (ControlsPanel.ButtonClicked.SizePanel):
                    this.DisplayPanel(AvailablePanels.Size, AvailablePanels.Controls);
                    break;
                case (ControlsPanel.ButtonClicked.SourcePanel):
                    this.DisplayPanel(AvailablePanels.Source, AvailablePanels.Controls);
                    break;
                case (ControlsPanel.ButtonClicked.ChangerPanel):
                    this.DisplayPanel(AvailablePanels.Changer, AvailablePanels.Controls);
                    break;
                case (ControlsPanel.ButtonClicked.TagsPanel):
                    this.DisplayPanel(AvailablePanels.Tags, AvailablePanels.Controls);
                    break;
                case (ControlsPanel.ButtonClicked.TimingsPanel):
                    this.DisplayPanel(AvailablePanels.Timings, AvailablePanels.Controls);
                    break;
            }

        }

        /// <summary>
        /// Disposes of an open control panel
        /// </summary>
        /// <param name="panel">The panel type being disposed</param>
        private void RemovePanel(AvailablePanels panel)
        {
            switch (panel)
            {
                case (AvailablePanels.Controls):
                    if (this.mControlsPanel != null)
                    {
                        this.mControlsPanel.ev_OptionSelected -= ControlsPanel_ev_OptionSelected;
                        this.mControlsPanel.Dispose();
                        this.mControlsPanel = null;
                    }
                    break;
                case (AvailablePanels.Size):
                    if (this.mSizePanel != null)
                    {
                        this.mSizePanel.ev_EventFired -= SizePanel_ev_EventFired;
                        this.mSizePanel.Dispose();
                        this.mSizePanel = null;
                    }

                    break;
                case (AvailablePanels.Tags):
                    if (this.mTagsPanel != null)
                    {
                        this.mTagsPanel.ev_EventFired -= TagsPanel_ev_EventFired;
                        this.mTagsPanel.Dispose();
                        this.mTagsPanel = null;
                    }
                    break;
                case (AvailablePanels.Source):
                    if (this.mSourcePanel != null)
                    {
                        this.mSourcePanel.ev_EventFired -= SourcePanel_ev_EventFired;
                        this.mSourcePanel.Dispose();
                        this.mSourcePanel = null;
                    }
                    break;
                case (AvailablePanels.Changer):
                    if (this.mChangerPanel != null)
                    {
                        this.mChangerPanel.ev_EventFired -= ChangerPanel_ev_EventFired;
                        this.mChangerPanel.Dispose();
                        this.mChangerPanel = null;
                    }
                    break;
                case (AvailablePanels.Timings):
                    if (this.mTimingsPanel != null)
                    {
                        this.mTimingsPanel.ev_EventFired -= TimingsPanel_ev_EventFired;
                        this.mTimingsPanel.Dispose();
                        this.mTimingsPanel = null;
                    }
                    break;
                case (AvailablePanels.Wizard_Start):
                    if (this.mNewPanel != null)
                    {

                        this.mNewPanel.Dispose();
                        this.mNewPanel = null;
                    }
                    break;
            }
        }

        /// <summary>
        /// Removes whatever the current panel is.
        /// </summary>
        private void RemovePanel()
        {
            this.RemovePanel(this.mCurrentPanel.PanelType);
        }

        /// <summary>
        /// Display a control panel to the user
        /// </summary>
        /// <param name="availablePanels">The panel to display</param>
        private void DisplayPanel(AvailablePanels availablePanels)
        {
            switch (availablePanels)
            {
                case (AvailablePanels.Controls):
                    CreatePanel(AvailablePanels.Controls);
                    this.mCurrentPanel = this.mControlsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Source):
                    CreatePanel(AvailablePanels.Source);
                    this.mCurrentPanel = this.mSourcePanel as ControlPanel;
                    break;
                case (AvailablePanels.Timings):
                    CreatePanel(AvailablePanels.Timings);
                    this.mCurrentPanel = this.mTimingsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Tags):
                    CreatePanel(AvailablePanels.Tags);
                    this.mCurrentPanel = this.mTagsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Size):
                    CreatePanel(AvailablePanels.Size);
                    this.mCurrentPanel = this.mSizePanel as ControlPanel;
                    break;
                case (AvailablePanels.Changer):
                    CreatePanel(AvailablePanels.Changer);
                    this.mCurrentPanel = this.mChangerPanel as ControlPanel;
                    break;

            }
            this.mCurrentPanelIndex = availablePanels;
        }
        
        /// <summary>
        /// Brings a panel into view, this kills off the current panel, and brings a new panel into view
        /// </summary>
        /// <param name="panelName">The panel to display.</param>
        /// <param name="previousPanel">The old panel to remove</param>
        private void DisplayPanel(AvailablePanels panelName, AvailablePanels previousPanel)
        {
            switch (panelName)
            {
                case (AvailablePanels.Controls):
                    CreatePanel(AvailablePanels.Controls);
                    this.mCurrentPanel = this.mControlsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Source):
                    CreatePanel(AvailablePanels.Source);
                    this.mCurrentPanel = this.mSourcePanel as ControlPanel;
                    break;
                case (AvailablePanels.Timings):
                    CreatePanel(AvailablePanels.Timings);
                    this.mCurrentPanel = this.mTimingsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Tags):
                    CreatePanel(AvailablePanels.Tags);
                    this.mCurrentPanel = this.mTagsPanel as ControlPanel;
                    break;
                case (AvailablePanels.Size):
                    CreatePanel(AvailablePanels.Size);
                    this.mCurrentPanel = this.mSizePanel as ControlPanel;
                    break;
                case (AvailablePanels.Changer):
                    CreatePanel(AvailablePanels.Changer);
                    this.mCurrentPanel = this.mChangerPanel as ControlPanel;
                    break;
            }
            this.RemovePanel(previousPanel);
            this.mCurrentPanelIndex = panelName;
        }
        
        /// <summary>
        /// Creates a panel that needs to be displayed.
        /// </summary>
        /// <param name="panel">The panel to create</param>
        private void CreatePanel(AvailablePanels panel)
        {
            switch (panel)
            {
                case (AvailablePanels.Controls):
                    this.mControlsPanel = new ControlsPanel();
                    this.mControlsPanel.ev_OptionSelected += new ControlsPanel.OptionSelected(ControlsPanel_ev_OptionSelected);
                    this.Controls.Add(this.mControlsPanel);
                    break;
                case (AvailablePanels.Size):
                    this.mSizePanel = new SizePanel(this.mWallpaperSize);
                    this.mSizePanel.ev_EventFired += new EventFired(SizePanel_ev_EventFired);
                    this.Controls.Add(this.mSizePanel);
                    break;
                case (AvailablePanels.Tags):
                    this.mTagsPanel = new TagsPanel(this.mTags);
                    this.mTagsPanel.ev_EventFired += new EventFired(TagsPanel_ev_EventFired);
                    this.Controls.Add(this.mTagsPanel);
                    break;
                case (AvailablePanels.Source):
                    this.mSourcePanel = new SourcePanel(this.mUserName,this.mEncryptedToken,this.mPasswordKey,this.mPasswordIV);
                    this.mSourcePanel.ev_EventFired += new EventFired(SourcePanel_ev_EventFired);
                    this.Controls.Add(this.mSourcePanel);
                    break;
                case (AvailablePanels.Changer):
                    this.mChangerPanel = new ChangerPanel(this.mAutoRun, this.mRunBefore);
                    this.mChangerPanel.ev_EventFired += new EventFired(ChangerPanel_ev_EventFired);
                    this.Controls.Add(this.mChangerPanel);
                    break;
                case (AvailablePanels.Timings):
                    this.mTimingsPanel = new TimingsPanel(this.mPictureChangeInterval, this.mReindexTime);
                    this.mTimingsPanel.ev_EventFired += new EventFired(TimingsPanel_ev_EventFired);
                    this.Controls.Add(this.mTimingsPanel);
                    break;
            }

        }

        
        /// <summary>
        /// The application is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
                       
            this.UpdateStatus("Currently waiting to close");
            this.Hide();
            lock (this.mutex)
            {
                this.SaveSettings();
            }
            
           
        }

        
    
        /// <summary>
        /// Deals with minimizing and maximizing the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Controller_ResizeEnd(object sender, EventArgs e)
        {
            if (this.mLastState != this.WindowState)
            {
                if (this.WindowState == FormWindowState.Minimized)
                {
                    this.mNotifyIcon.Visible = true;
                    this.mLastState = FormWindowState.Minimized;

                    if (this.mNewPanel != null)
                    {
                        this.mCurrentPanelIndex = AvailablePanels.Wizard_Start;
                    }
                    else if (this.mCurrentPanel != null)
                    {
                        this.mCurrentPanelIndex = this.mCurrentPanel.PanelType;
                        this.RemovePanel();
                    }
                    try
                    {
                        if (this.ShowInTaskbar == true)
                            this.ShowInTaskbar = false;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    this.mLastState = FormWindowState.Normal;
                    this.mNotifyIcon.Visible = false;


                    this.DisplayPanel(this.mCurrentPanelIndex);



                    this.ShowInTaskbar = true;



                }

            }

        }

        
        

      

       

       

      

    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    