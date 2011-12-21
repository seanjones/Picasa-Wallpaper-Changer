using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class ChangerPanel : ControlPanel
    {
        public ChangerPanel(bool autorun,bool runBefore) : base(AvailablePanels.Changer)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "ChangerPanel";
            this.Size = new System.Drawing.Size(556, 389);
            if (autorun)
                this.m_autostart.Checked = true;
            if (!runBefore)
            {
                this.m_stopNow.Checked = false;
                this.m_stopNow.Enabled = false;
                this.m_startNow.Checked = true;
                this.m_startNow.Enabled = false;
            }


        }
       
        public override event EventFired ev_EventFired;

        private void m_StartPanelOk_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, new PicasaWallpaperEventArgs(this.m_autostart.Checked, this.m_startNow.Checked, this.m_stopNow.Checked), DialogResult.OK);
        }

        private void m_startPanelCancel_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, null, DialogResult.Cancel);
        }
    }
}
