using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class TimingsPanel : ControlPanel
    {
        public override event  EventFired ev_EventFired;
        public TimingsPanel(int changeInterval, DateTime reindexTime) : base(AvailablePanels.Timings)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "TimingsPanel";
            this.Size = new System.Drawing.Size(556, 389);
           
            this.m_pictureChangeFrequency.Value = (decimal)changeInterval;
            this.mReindexTime.Value = reindexTime;
        }
        
        
       
        private void m_timingChangeOk_Click(object sender, EventArgs e)
        {
            
            this.ev_EventFired(sender, new PicasaWallpaperEventArgs(this.m_pictureChangeFrequency.Value,this.mReindexTime.Value), DialogResult.OK);

        }

        private void m_timingChangeCancel_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, null, DialogResult.Cancel);
        }
        
        
    }
}
