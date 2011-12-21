using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace Sean_Jones.PicasaWallpaperChangerControl
{
    public partial class TagsPanel : ControlPanel
    {
        bool mTagsChanged = false;
        public TagsPanel(StringCollection tags) : base(AvailablePanels.Tags)
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Location = new System.Drawing.Point(189, 29);
            this.Name = "TagsPanel";

            this.Size = new System.Drawing.Size(556, 389);
            foreach (string tag in tags)
            {
                this.m_currentTags.Items.Add(tag);
            }
        }


       
        public override event EventFired ev_EventFired;

        private void RemoveTagsButton_Click(object sender, EventArgs e)
        {
            if (this.m_currentTags.SelectedIndices.Count > 0)
            {
                this.mTagsChanged = true;
                for (int i = 0; i < this.m_currentTags.Items.Count; i++)
                {
                    if (this.m_currentTags.SelectedIndices.Contains(i))
                    {
                        this.m_currentTags.Items.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void AddTagsButton_Click(object sender, EventArgs e)
        {
            if (this.m_addTags.Text.Length > 0)
            {
                this.mTagsChanged = true;
                foreach (string tag in this.m_addTags.Text.Split(new char[1] { ' ' }))
                {
                    if (this.m_currentTags.Items.IndexOf(tag.Trim()) < 0)
                        this.m_currentTags.Items.Add(tag.Trim());
                }
                this.m_addTags.Text = "";
            }
        }

        private void TagsPanelOk_Click(object sender, EventArgs e)
        {
            List<string> items = new List<string>();
            if (this.mTagsChanged)
            {
                foreach (string tag in this.m_currentTags.Items)
                {
                    if (tag != "")
                    {
                        items.Add(tag);
                    }
                }
            }
            PicasaWallpaperEventArgs ev = new PicasaWallpaperEventArgs(items);
            this.ev_EventFired(sender, ev, DialogResult.OK);
        }

        private void TagsPanelCancel_Click(object sender, EventArgs e)
        {
            this.ev_EventFired(sender, null, DialogResult.Cancel);
        }
    }
}
