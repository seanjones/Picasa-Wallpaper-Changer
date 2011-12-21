using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class SizePanel : ControlPanel
    {
        public SizePanel(decimal sizePercent) : base(AvailablePanels.Size)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "SizePanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.m_sizePercent.Value = sizePercent * 100;

        }

       
        public override event EventFired ev_EventFired;

        private void m_okSizePanel_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, new PicasaWallpaperEventArgs(this.m_sizePercent.Value/100), DialogResult.OK);
        }

        private void m_cancelSizePanel_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, null, DialogResult.Cancel);
        }

    }
}
