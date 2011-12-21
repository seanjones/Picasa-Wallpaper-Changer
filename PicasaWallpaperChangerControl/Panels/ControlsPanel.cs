using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class ControlsPanel : ControlPanel
    {
        public ControlsPanel() : base(AvailablePanels.Controls)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "ControlsPanel";
            this.Size = new System.Drawing.Size(556, 389);
        }
        public delegate void OptionSelected (object sender, ButtonClicked option);
        public event OptionSelected ev_OptionSelected;
        public enum ButtonClicked { TimingsPanel, TagsPanel, SourcePanel, ChangerPanel, SizePanel };
        private void m_timing_Click(object sender, EventArgs e)
        {
            this.ev_OptionSelected(this, ButtonClicked.TimingsPanel);
        }

        private void m_tags_Click(object sender, EventArgs e)
        {
            this.ev_OptionSelected(this, ButtonClicked.TagsPanel);
        }

        private void m_source_Click(object sender, EventArgs e)
        {
            this.ev_OptionSelected(this, ButtonClicked.SourcePanel);
        }

        private void m_size_Click(object sender, EventArgs e)
        {
            this.ev_OptionSelected(this, ButtonClicked.SizePanel);
        }

        private void m_start_Click(object sender, EventArgs e)
        {
            this.ev_OptionSelected(this, ButtonClicked.ChangerPanel);
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            lock (this)
            {
                Button me = (Button)sender;
                me.ImageKey = me.Name + "_down";
            }
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            lock (this)
            {
                Button me = (Button)sender;
                me.ImageKey = me.Name + "_up";
            }
        }

        public override event EventFired ev_EventFired;
    }
}
