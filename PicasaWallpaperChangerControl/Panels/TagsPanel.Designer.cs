namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class TagsPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagsPanel));
            this.m_addTagsButton = new System.Windows.Forms.Button();
            this.m_addTags = new System.Windows.Forms.TextBox();
            this.m_removeTagsButton = new System.Windows.Forms.Button();
            this.m_currentTags = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_tagsPanelCancel = new System.Windows.Forms.Button();
            this.m_tagsPanelOk = new System.Windows.Forms.Button();
            this.m_tagsPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_tagsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_addTagsButton
            // 
            this.m_addTagsButton.Location = new System.Drawing.Point(400, 284);
            this.m_addTagsButton.Name = "m_addTagsButton";
            this.m_addTagsButton.Size = new System.Drawing.Size(75, 23);
            this.m_addTagsButton.TabIndex = 24;
            this.m_addTagsButton.Text = "Add to List";
            this.m_addTagsButton.UseVisualStyleBackColor = true;
            this.m_addTagsButton.Click += new System.EventHandler(this.AddTagsButton_Click);
            // 
            // m_addTags
            // 
            this.m_addTags.Location = new System.Drawing.Point(347, 258);
            this.m_addTags.Name = "m_addTags";
            this.m_addTags.Size = new System.Drawing.Size(181, 20);
            this.m_addTags.TabIndex = 23;
            // 
            // m_removeTagsButton
            // 
            this.m_removeTagsButton.Location = new System.Drawing.Point(384, 201);
            this.m_removeTagsButton.Name = "m_removeTagsButton";
            this.m_removeTagsButton.Size = new System.Drawing.Size(106, 26);
            this.m_removeTagsButton.TabIndex = 22;
            this.m_removeTagsButton.Text = "Remove Selected";
            this.m_removeTagsButton.UseVisualStyleBackColor = true;
            this.m_removeTagsButton.Click += new System.EventHandler(this.RemoveTagsButton_Click);
            // 
            // m_currentTags
            // 
            this.m_currentTags.FormattingEnabled = true;
            this.m_currentTags.Location = new System.Drawing.Point(347, 100);
            this.m_currentTags.Name = "m_currentTags";
            this.m_currentTags.Size = new System.Drawing.Size(181, 95);
            this.m_currentTags.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoEllipsis = true;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(502, 32);
            this.label10.TabIndex = 20;
            this.label10.Text = "These settings will effect which pictures will be shown on your wallpaper. All pi" +
                "ctures \rwhich are tagged with any of the words you choose will be indexed.";
            // 
            // m_tagsPanelCancel
            // 
            this.m_tagsPanelCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_tagsPanelCancel.ForeColor = System.Drawing.Color.Black;
            this.m_tagsPanelCancel.ImageKey = "(none)";
            this.m_tagsPanelCancel.Location = new System.Drawing.Point(483, 345);
            this.m_tagsPanelCancel.Name = "m_tagsPanelCancel";
            this.m_tagsPanelCancel.Size = new System.Drawing.Size(57, 27);
            this.m_tagsPanelCancel.TabIndex = 19;
            this.m_tagsPanelCancel.Text = "Cancel";
            this.m_tagsPanelCancel.UseVisualStyleBackColor = false;
            this.m_tagsPanelCancel.Click += new System.EventHandler(this.TagsPanelCancel_Click);
            // 
            // m_tagsPanelOk
            // 
            this.m_tagsPanelOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_tagsPanelOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_tagsPanelOk.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.m_tagsPanelOk.FlatAppearance.BorderSize = 0;
            this.m_tagsPanelOk.ForeColor = System.Drawing.Color.Black;
            this.m_tagsPanelOk.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_tagsPanelOk.Location = new System.Drawing.Point(410, 345);
            this.m_tagsPanelOk.Name = "m_tagsPanelOk";
            this.m_tagsPanelOk.Size = new System.Drawing.Size(57, 27);
            this.m_tagsPanelOk.TabIndex = 18;
            this.m_tagsPanelOk.Text = "Ok";
            this.m_tagsPanelOk.UseVisualStyleBackColor = false;
            this.m_tagsPanelOk.Click += new System.EventHandler(this.TagsPanelOk_Click);
            // 
            // m_tagsPanel
            // 
            this.m_tagsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_tagsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_tagsPanel.BackgroundImage")));
            this.m_tagsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_tagsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_tagsPanel.Controls.Add(this.m_addTagsButton);
            this.m_tagsPanel.Controls.Add(this.m_addTags);
            this.m_tagsPanel.Controls.Add(this.m_removeTagsButton);
            this.m_tagsPanel.Controls.Add(this.m_currentTags);
            this.m_tagsPanel.Controls.Add(this.label10);
            this.m_tagsPanel.Controls.Add(this.m_tagsPanelCancel);
            this.m_tagsPanel.Controls.Add(this.m_tagsPanelOk);
            this.m_tagsPanel.Controls.Add(this.label11);
            this.m_tagsPanel.Controls.Add(this.label12);
            this.m_tagsPanel.Location = new System.Drawing.Point(0, 0);
            this.m_tagsPanel.Name = "m_tagsPanel";
            this.m_tagsPanel.Size = new System.Drawing.Size(556, 389);
            this.m_tagsPanel.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(16, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(312, 26);
            this.label11.TabIndex = 17;
            this.label11.Text = "Enter new tags you wish to add to the list. Tags are single words,\rso spaces indi" +
                "cate multiple tags. THEY ARE CASE SENSITIVE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(16, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(316, 26);
            this.label12.TabIndex = 16;
            this.label12.Text = "These are the tags you have currently selected.\rSelect entries and click the remo" +
                "ve button to remove any entries. ";
            // 
            // TagsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tagsPanel);
            this.Name = "TagsPanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.m_tagsPanel.ResumeLayout(false);
            this.m_tagsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_addTagsButton;
        private System.Windows.Forms.TextBox m_addTags;
        private System.Windows.Forms.Button m_removeTagsButton;
        private System.Windows.Forms.ListBox m_currentTags;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button m_tagsPanelCancel;
        private System.Windows.Forms.Button m_tagsPanelOk;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Panel m_tagsPanel;
    }
}
