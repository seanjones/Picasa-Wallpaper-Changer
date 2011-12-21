using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Xml;
using System.Xml.XPath;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;
using Sean_Jones.PicasaWallpaperChangerControl.Properties;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public enum Actions
    {
        Reindex_Photos, Change_Wallpaper, Add_Tags, Change_Wallpaper_Size,Start_Server,Stop_Server
    };
    static class Program
    {
        /// <summary>
        /// The thread that run and changes the wallpaper/reindex etc.
        /// </summary>
        internal static Thread ActionControllingServer;

     

        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            string[] arguments  = Environment.GetCommandLineArgs();
           
            foreach (string argument in arguments)
            {
                // Uninstall
                if (argument.Split(new char[] { '=' })[0].ToLower() == "/u")
                {
                    string guid = argument.Split(new char[] { '=' })[1];
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                    if (System.IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Picasa Wallpaper Changer.lnk"))
                    {
                        System.IO.File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\Picasa Wallpaper Changer.lnk");
                    }
                    ProcessStartInfo si = new ProcessStartInfo(path + "\\msiexec.exe", "/i " + guid);
                    Process.Start(si);
                    Application.Exit();
                    return;
                    
                }
            }
            
            // start the app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Controller());

        }
        
        

        /// <summary>
        /// This method runs in the background and handles what the controller should do
        /// </summary>
        //static void Server()
        //{

        //    // Set initial variables for running the app
        //    XmlDocument database = new XmlDocument();

        //    // try and connect to the registry
        //    RegistryKey deskTopKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

        //    // set registry options for the display of wallpaper
        //    deskTopKey.SetValue("TileWallpaper", "0");
        //    deskTopKey.SetValue("WallpaperStyle", "1");
        //    deskTopKey.Flush();
        //    deskTopKey.Close();
        //    deskTopKey = null;

        //    Program.LoadSettings();

        //    // the path to the database
        //    string datapath = Application.StartupPath + "\\database.xml";

        //    // the number of photos
        //    int numberOfPhotos = 0;

        //    // check and create (if needed) the database
        //    //ValidateDatabaseFile(ref datapath, ref database);


        //    // the changer object
        //    Changer changer = null;

        //    Actions action;

        //    // all the time the server is running
        //    while (Program.ActionControllingServerRunningStatus)
        //    {
        //        // Check for some waiting actions. If there are none, have a sleep
        //        if (ActionsQueue.Count == 0)
        //        {
        //            try
        //            {
        //                GC.Collect();
        //                Thread.Sleep(Timeout.Infinite);
        //            }
        //            catch (ThreadInterruptedException)
        //            {
        //                continue;
        //            }
        //        }
                
        //        // lock the action queue and get the next action in the list
        //        lock (ActionsQueue)
        //        {
        //            action = ActionsQueue[0];
        //            // tidy
        //            ActionsQueue.RemoveAt(0);
        //            Monitor.Pulse(ActionsQueue);
        //        }


        //        // Check the database file
        //      //  ValidateDatabaseFile(ref datapath, ref database);
        //        // create a new changer
        //        changer = new Changer();
        //        changer.ev_ExceptionThrown += new Changer.ExceptionThrown(Changer_ev_ExceptionThrown);
        //        switch (action)
        //        {
        //            case (Actions.Stop_Server):
        //                changer.ev_ExceptionThrown -= Changer_ev_ExceptionThrown;
        //                changer.Dispose();
        //                changer = null;
        //                break;
        //            case (Actions.Reindex_Photos): // Check for new photos.
        //                lock (database)
        //                {
        //                    long ii = 0;
        //                    while (ii < 10000000000000)
        //                    {
        //                        ii++;
        //                    }
        //                    // reindex the photos.
        //                    Program.NumberOfPictures = changer.Reindex(database, false);
        //                    // save them
        //                    database.Save(datapath);

        //                    // Update the settings file
        //                    lock (Program.SettingsData)
        //                    {
        //                        Program.SettingsData.numberOfPhotos = Program.NumberOfPictures;
        //                        Program.ReindexedDate = DateTime.Now;
        //                        Program.SettingsData.reindexedDate = DateTime.Now;
        //                        Program.SettingsData.Save();
        //                        Monitor.Pulse(Program.SettingsData);
        //                    }
        //                    Monitor.Pulse(database);
        //                }
        //                break;
        //            case (Actions.Change_Wallpaper): // Change the current Picture
        //                lock (database)
        //                {
        //                    // if there are no photos to show
        //                    if (Program.NumberOfPictures < 1)
        //                    {
        //                        // find some photos
        //                        Program.NumberOfPictures = changer.Reindex(database, false);
        //                        database.Save(datapath);
        //                        lock (Program.SettingsData)
        //                        {
        //                            Program.SettingsData.numberOfPhotos = numberOfPhotos;
        //                            Program.SettingsData.reindexedDate = DateTime.Now;
        //                            Program.ReindexedDate = DateTime.Now;
        //                            Program.SettingsData.Save();
        //                            Monitor.Pulse(Program.SettingsData);
        //                        }
        //                    }
        //                    else
        //                        ChangePicture(changer.ChangePhoto(database, Application.StartupPath));
        //                    Monitor.Pulse(database);
        //                }
        //                break;
        //            case (Actions.Add_Tags):
        //                lock (database)
        //                {
        //                    long ii = 0;
        //                    while (ii < 10000000000000)
        //                    {
        //                        ii++;
        //                    }
        //                    Program.NumberOfPictures = changer.Reindex(database, true);
        //                    database.Save(datapath);
        //                    lock (Program.SettingsData)
        //                    {
        //                        Program.SettingsData.numberOfPhotos = Program.NumberOfPictures;
        //                        Program.ReindexedDate = DateTime.Now;
        //                        Program.SettingsData.reindexedDate = DateTime.Now;
        //                        Program.SettingsData.Save();
        //                        Monitor.Pulse(Program.SettingsData);
        //                    }
        //                    Monitor.Pulse(database);
        //                }
        //                break;
        //            case (Actions.Change_Wallpaper_Size):
        //                WallpaperSize = Program.SettingsData.SizePercent;
        //                Monitor.Pulse(Program.SettingsData);
        //                break;
        //        } // end of switch
        //        changer.ev_ExceptionThrown -= Changer_ev_ExceptionThrown;
        //        changer.Dispose();
        //        changer = null;
               
                
   

        //    } // end of thread loop
        //}

       
       
        


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_SENDCHANGE = 0x2;
        internal static void ChangePicture(Sean_Jones.PicasaWallpaperChangerControl.Changer.PictureChangerInfo newPicture)
        {
            // try and connect to the registry
            RegistryKey deskTopKey = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            // set registry options for the display of wallpaper
            deskTopKey.SetValue("TileWallpaper", "0");
            deskTopKey.SetValue("WallpaperStyle", "1");
            deskTopKey.Flush();
            deskTopKey.Close();
            deskTopKey = null;
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 1, newPicture.Path, SPIF_SENDCHANGE);
           // File.Delete(newPicture.Path);
          
           
        }
    
       

        

        /// <summary>
        /// Controls the starting of the changer thread
        /// </summary>
        //internal static void StartChanager()
        //{
        //    // if the thread doesn't exist
        //    if (ActionControllingServer == null)
        //    {
        //        // create the new thread
        //        ActionControllingServer = new Thread(Server);
                
        //        // set its priority
        //        ActionControllingServer.Priority = ThreadPriority.Lowest;
        //    }

        //    try
        //    {
        //        ActionControllingServer.Start();
        //    }
        //    catch(Exception ex)
        //    {
        //        Changer_ev_ExceptionThrown(ex, "Starting changer thread");
        //    }
        //    int i = 0;
            
        //    // Wait for the thread to start
        //    while (ActionControllingServer.ThreadState != System.Threading.ThreadState.Running)
        //    {
        //        i++;
        //    }
            
        //    lock (Program.SettingsData)
        //    {
        //        Program.SettingsData.RunBefore = true;
        //        Program.SettingsData.Save();
        //        Monitor.Pulse(Program.SettingsData);
        //    }
        //}
        
        
        
       
      
    }

}