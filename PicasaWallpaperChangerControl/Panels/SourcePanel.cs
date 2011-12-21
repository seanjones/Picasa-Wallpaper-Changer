using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Net;
using System.IO;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class SourcePanel : ControlPanel
    {
        bool mPasswordChanged = false;
        bool mUserChanged = false;
        public SourcePanel(string userName,string password, string passwordKey, string passwordIV)
            : base(AvailablePanels.Source)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "SourcePanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.mUserName.Text = userName;
            
            this.mPasswordChanged = false;
            this.mUserChanged = false;
        }
        
       
      
        public override event EventFired ev_EventFired;
        
        private WebProxy CreateProxy()
        {
            IWebProxy proxyServer = WebRequest.DefaultWebProxy;
            UriBuilder ub = new UriBuilder("www.google.co.uk");
            WebProxy myProxy = new WebProxy(proxyServer.GetProxy(ub.Uri));
            myProxy.Credentials = CredentialCache.DefaultCredentials;
            myProxy.UseDefaultCredentials = true;
            return myProxy;
         
        }

        private void m_sourcePanelOk_Click(object sender, EventArgs e)
        {
            string password = string.Empty;
            string username = string.Empty;
            string usertoken = string.Empty;
            if (this.mPasswordChanged)
            {
                password = this.mPassword.Text;
            }
            if (this.mUserChanged)
            {
                username = this.mUserName.Text;
            }

            // login request
            WebRequest loginRequest = (WebRequest)HttpWebRequest.Create("https://www.google.com/accounts/ClientLogin?accountType=GOOGLE_OR_HOSTED&Email=" + this.mUserName.Text + "&Passwd=" + this.mPassword.Text + "&service=lh2&source=WallpaperChanger");
            loginRequest.Proxy = this.CreateProxy();
            HttpWebResponse loginResponse = null;
            StreamReader responseStreamReader = null;
            string result = string.Empty;

            try
            {
                // try the web request
                
                loginResponse = (HttpWebResponse)loginRequest.GetResponse();
            }
            catch (WebException wex)
            {
                
                // login validation failed, so find out why
                loginResponse = (HttpWebResponse)wex.Response;
                responseStreamReader = new StreamReader(loginResponse.GetResponseStream());
                // result contains the error.
                result = responseStreamReader.ReadToEnd();
                if (loginResponse.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    this.m_sourcePanelOk_ClickNoProxy(sender, e);
                    return;
                }
                switch (result.Trim())
                {
                    case ("Error=BadAuthentication"):
                        MessageBox.Show("Username or Password error.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                       // break;
                    case ("NotVerified"):
                        MessageBox.Show("The account email address has not been verified.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case ("TermsNotAgreed"):
                        MessageBox.Show("The user has not agreed to terms. The user will need to access their Google account directly to resolve the issue before logging in.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case ("CaptchaRequired"):
                        //A CAPTCHA is required. (A response with this error code will also contain an image URL and a CAPTCHA token.) 
                        break;
                    case ("Unknown"):
                        MessageBox.Show("The error is unknown or unspecified; the request contained invalid input or was malformed.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    default:
                        MessageBox.Show("An error occurred: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your connection is down.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            responseStreamReader = new StreamReader(loginResponse.GetResponseStream());
            result = responseStreamReader.ReadToEnd();
            int start = result.IndexOf("Auth=");
            string token = result.Remove(0, start + 5);
            token = token.Trim();
            
            /* try
             {
                 Changer changer = new Changer(new string[0], password, username);
                
                 usertoken = changer.CheckLogin();
                 if(usertoken == string.Empty)
                 {

                 }
                 catch(
                 //CreateAlbumProxy();
                 this.m_albumFeed = this.m_albumService.Query(this.m_albumQuery);
                 try
                 {
                 string token = this.m_albumService.QueryAuthenticationToken();
             }*/

            PicasaWallpaperEventArgs ev = new PicasaWallpaperEventArgs(username, password,token);
            this.ev_EventFired(sender, ev, DialogResult.OK);
        }

        private void m_sourcePanelOk_ClickNoProxy(object sender, EventArgs e)
        {
            string password = string.Empty;
            string username = string.Empty;
            string usertoken = string.Empty;
            if (this.mPasswordChanged)
            {
                password = this.mPassword.Text;
            }
            if (this.mUserChanged)
            {
                username = this.mUserName.Text;
            }

            // login request
            WebRequest loginRequest = (WebRequest)HttpWebRequest.Create("https://www.google.com/accounts/ClientLogin?accountType=GOOGLE_OR_HOSTED&Email=" + this.mUserName.Text + "&Passwd=" + this.mPassword.Text + "&service=lh2&source=WallpaperChanger");
          //  loginRequest.Proxy = this.CreateProxy();
            HttpWebResponse loginResponse = null;
            StreamReader responseStreamReader = null;
            string result = string.Empty;

            try
            {
                // try the web request

                loginResponse = (HttpWebResponse)loginRequest.GetResponse();
            }
            catch (WebException wex)
            {

                // login validation failed, so find out why
                loginResponse = (HttpWebResponse)wex.Response;
                responseStreamReader = new StreamReader(loginResponse.GetResponseStream());
                // result contains the error.
                result = responseStreamReader.ReadToEnd();
               
                switch (result.Trim())
                {
                    case ("Error=BadAuthentication"):
                        MessageBox.Show("Username or Password error.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    //    break;
                    case ("NotVerified"):
                        MessageBox.Show("The account email address has not been verified.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case ("TermsNotAgreed"):
                        MessageBox.Show("The user has not agreed to terms. The user will need to access their Google account directly to resolve the issue before logging in.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    case ("CaptchaRequired"):
                        //A CAPTCHA is required. (A response with this error code will also contain an image URL and a CAPTCHA token.) 
                        break;
                    case ("Unknown"):
                        MessageBox.Show("The error is unknown or unspecified; the request contained invalid input or was malformed.", "Bad Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    default:
                        MessageBox.Show("An error occurred: " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your connection is down.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            responseStreamReader = new StreamReader(loginResponse.GetResponseStream());
            result = responseStreamReader.ReadToEnd();
            int start = result.IndexOf("Auth=");
            string token = result.Remove(0, start + 5);
            token = token.Trim();

            /* try
             {
                 Changer changer = new Changer(new string[0], password, username);
                
                 usertoken = changer.CheckLogin();
                 if(usertoken == string.Empty)
                 {

                 }
                 catch(
                 //CreateAlbumProxy();
                 this.m_albumFeed = this.m_albumService.Query(this.m_albumQuery);
                 try
                 {
                 string token = this.m_albumService.QueryAuthenticationToken();
             }*/

            PicasaWallpaperEventArgs ev = new PicasaWallpaperEventArgs(username, password, token);
            this.ev_EventFired(sender, ev, DialogResult.OK);
        }

        private void m_sourcePanelCancel_Click(object sender, EventArgs e)
        {
                       
            this.ev_EventFired(sender,null,DialogResult.Cancel);
        }
                    

        private void CurrentUserNames_TextChanged(object sender, EventArgs e)
        {
            this.mUserChanged = true;
        }

        private void AddUsername_TextChanged(object sender, EventArgs e)
        {
            this.mPasswordChanged = true;
        }
    }
}
   
      

      