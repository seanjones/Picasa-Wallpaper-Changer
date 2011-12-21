namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class TimingsPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimingsPanel));
            this.label9 = new System.Windows.Forms.Label();
            this.m_timingChangeCancel = new System.Windows.Forms.Button();
            this.m_timingChangeOk = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.m_timingsPanel = new System.Windows.Forms.Panel();
            this.mReindexTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.m_pictureChangeFrequency = new System.Windows.Forms.NumericUpDown();
            this.m_timingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureChangeFrequency)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoEllipsis = true;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(459, 32);
            this.label9.TabIndex = 13;
            this.label9.Text = "These settings will effect how often your wallpaper will change, and how often\r t" +
                "he web is checked for new images";
            // 
            // m_timingChangeCancel
            // 
            this.m_timingChangeCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_timingChangeCancel.ForeColor = System.Drawing.Color.Black;
            this.m_timingChangeCancel.ImageKey = "(none)";
            this.m_timingChangeCancel.Location = new System.Drawing.Point(483, 345);
            this.m_timingChangeCancel.Name = "m_timingChangeCancel";
            this.m_timingChangeCancel.Size = new System.Drawing.Size(57, 27);
            this.m_timingChangeCancel.TabIndex = 12;
            this.m_timingChangeCancel.Text = "Cancel";
            this.m_timingChangeCancel.UseVisualStyleBackColor = false;
            this.m_timingChangeCancel.Click += new System.EventHandler(this.m_timingChangeCancel_Click);
            // 
            // m_timingChangeOk
            // 
            this.m_timingChangeOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_timingChangeOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_timingChangeOk.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.m_timingChangeOk.FlatAppearance.BorderSize = 0;
            this.m_timingChangeOk.ForeColor = System.Drawing.Color.Black;
            this.m_timingChangeOk.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_timingChangeOk.Location = new System.Drawing.Point(410, 345);
            this.m_timingChangeOk.Name = "m_timingChangeOk";
            this.m_timingChangeOk.Size = new System.Drawing.Size(57, 27);
            this.m_timingChangeOk.TabIndex = 11;
            this.m_timingChangeOk.Text = "Ok";
            this.m_timingChangeOk.UseVisualStyleBackColor = false;
            this.m_timingChangeOk.Click += new System.EventHandler(this.m_timingChangeOk_Click);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(20, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(298, 30);
            this.label8.TabIndex = 10;
            this.label8.Text = "Choose when you want to check for new pictures.";
            // 
            // m_timingsPanel
            // 
            this.m_timingsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_timingsPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_timingsPanel.BackgroundImage")));
            this.m_timingsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_timingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_timingsPanel.Controls.Add(this.mReindexTime);
            this.m_timingsPanel.Controls.Add(this.label9);
            this.m_timingsPanel.Controls.Add(this.m_timingChangeCancel);
            this.m_timingsPanel.Controls.Add(this.m_timingChangeOk);
            this.m_timingsPanel.Controls.Add(this.label8);
            this.m_timingsPanel.Controls.Add(this.label7);
            this.m_timingsPanel.Controls.Add(this.m_pictureChangeFrequency);
            this.m_timingsPanel.Location = new System.Drawing.Point(0, 0);
            this.m_timingsPanel.Name = "m_timingsPanel";
            this.m_timingsPanel.Size = new System.Drawing.Size(556, 389);
            this.m_timingsPanel.TabIndex = 6;
            // 
            // mReindexTime
            // 
            this.mReindexTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.mReindexTime.Location = new System.Drawing.Point(443, 156);
            this.mReindexTime.Name = "mReindexTime";
            this.mReindexTime.ShowUpDown = true;
            this.mReindexTime.Size = new System.Drawing.Size(75, 20);
            this.mReindexTime.TabIndex = 14;
            this.mReindexTime.Value = new System.DateTime(2009, 12, 13, 3, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(20, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Choose the number of minutes between photo changes";
            // 
            // m_pictureChangeFrequency
            // 
            this.m_pictureChangeFrequency.Location = new System.Drawing.Point(470, 111);
            this.m_pictureChangeFrequency.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.m_pictureChangeFrequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_pictureChangeFrequency.Name = "m_pictureChangeFrequency";
            this.m_pictureChangeFrequency.Size = new System.Drawing.Size(48, 20);
            this.m_pictureChangeFrequency.TabIndex = 7;
            this.m_pictureChangeFrequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TimingsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_timingsPanel);
            this.Name = "TimingsPanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.m_timingsPanel.ResumeLayout(false);
            this.m_timingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureChangeFrequency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button m_timingChangeCancel;
        private System.Windows.Forms.Button m_timingChangeOk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown m_pictureChangeFrequency;
        protected System.Windows.Forms.Panel m_timingsPanel;
        private System.Windows.Forms.DateTimePicker mReindexTime;


    }
}
