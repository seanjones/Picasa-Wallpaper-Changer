using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;
using Sean_Jones.AutoProxy;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Sean_Jones.PicasaReader
{
    public class PicasaWebPhotoConverter : IDisposable
    {

        string mLocation = string.Empty;
        int mWidth = 0;
        int mHeight =0;
        Image mPhotoImage = null;
       
        public PicasaWebPhotoConverter(string location, string height, string width)
        {
            this.mLocation = location;
            this.mHeight = int.Parse(height);
            this.mWidth = int.Parse(width);
        }
       
        public string Location
        {
            get
            {
                return this.mLocation;
            }
        }

        public bool CreateImage()
        {

            WebRequest webRequest = WebRequest.Create(this.mLocation);
            AutoProxyClass ap = new AutoProxyClass(new Uri(this.mLocation));
           // webRequest.Proxy = ap.TheAutoProxy;
            try
            {
                this.mPhotoImage = Bitmap.FromStream(webRequest.GetResponse().GetResponseStream());
            }
            catch (Exception e)
            {
               throw new Exception(e.Message, e);
            }
            finally
            {
                ap = null;
                webRequest = null;
            }
            return true;
        }

        public Image Photo
        {
            get
            {
                return this.mPhotoImage;
            }
        }

        public Rectangle Full
        {
            get
            {
                return new Rectangle(0, 0, Convert.ToInt32(this.mWidth), Convert.ToInt32(this.mHeight));
            }
        }

        /// <summary>
        /// Attempts to resize the image to fit the designated screen % fill
        /// </summary>
        /// <param name="pictureSize"></param>
        /// <returns></returns>
        public Bitmap Scale(decimal pictureSize)
        {
           
            int percent = 0;
            int biggestSideDifference = 0;
            
            // try to resolve portrait or landscape
            percent = this.GetPhotoSize(percent,biggestSideDifference,pictureSize);

            int targetHeight = (int)((Convert.ToDecimal(this.mHeight) / 100) * (percent));
            int targetWidth = (int)((Convert.ToDecimal(this.mWidth) / 100) * (percent));


            int sourceWidth = this.mPhotoImage.Width;
            int sourceHeight = this.mPhotoImage.Height;
            Rectangle target = new Rectangle(0, 0, targetWidth, targetHeight);
            Rectangle source = new Rectangle(0, 0, sourceWidth, sourceHeight);

            Bitmap newBitmap = new Bitmap(targetWidth, targetHeight, PixelFormat.Format32bppRgb);
            newBitmap.SetResolution(this.mPhotoImage.HorizontalResolution, this.mPhotoImage.VerticalResolution);

            Graphics gr = Graphics.FromImage(newBitmap);
            gr.PageUnit = GraphicsUnit.Pixel;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            gr.DrawImage(this.mPhotoImage, target, source, GraphicsUnit.Pixel);
            gr.Flush();
            gr.Dispose();
            gr = null;
            
            
            return newBitmap;
        }

        int GetPhotoSize(int percent, int biggestSideDifference,decimal pictureSize)
        {
            if (this.mWidth > this.mHeight)
                if (this.mWidth > (int)Math.Round((Screen.PrimaryScreen.Bounds.Width * pictureSize), 0))
                {
                    biggestSideDifference = (int)Math.Round((decimal)(Screen.PrimaryScreen.Bounds.Width * pictureSize), 0);
                    percent = (int)Math.Round(((decimal)biggestSideDifference / (decimal)this.mWidth) * 100, 0);
                }
                else
                    percent = 100;
            if (this.mPhotoImage.Height > this.mPhotoImage.Width)
                if (this.mHeight > (int)Math.Round((Screen.PrimaryScreen.Bounds.Height * pictureSize), 0))
                {
                    biggestSideDifference = (int)Math.Round((decimal)(Screen.PrimaryScreen.Bounds.Height * pictureSize), 0);
                    percent = (int)Math.Round(((decimal)biggestSideDifference / (decimal)this.mHeight) * 100, 0);
                }
                else
                    percent = 100;
            return percent;
        }
        
        #region Disposal
        bool is_disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!is_disposed) // only dispose once!
            {
                if (disposing)
                {
                  
                    this.mLocation = null;
                    if(this.mPhotoImage != null)
                        this.mPhotoImage.Dispose();
                    this.mPhotoImage = null;
                   
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
        ~PicasaWebPhotoConverter()
        {
            Dispose(false);
            //  Console.WriteLine("In destructor.");
        }
        #endregion


    }
}
