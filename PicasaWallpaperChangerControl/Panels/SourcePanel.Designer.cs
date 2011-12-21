namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class SourcePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourcePanel));
            this.mPassword = new System.Windows.Forms.TextBox();
            this.m_sourcePanelCancel = new System.Windows.Forms.Button();
            this.m_sourcePanelOk = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.m_sourcePanel = new System.Windows.Forms.Panel();
            this.mCAPTCHAImage = new System.Windows.Forms.PictureBox();
            this.mCAPTCHA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mUserName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.m_sourcePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCAPTCHAImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mPassword
            // 
            this.mPassword.Location = new System.Drawing.Point(347, 183);
            this.mPassword.Name = "mPassword";
            this.mPassword.Size = new System.Drawing.Size(181, 20);
            this.mPassword.TabIndex = 34;
            this.mPassword.UseSystemPasswordChar = true;
            this.mPassword.TextChanged += new System.EventHandler(this.AddUsername_TextChanged);
            // 
            // m_sourcePanelCancel
            // 
            this.m_sourcePanelCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_sourcePanelCancel.ForeColor = System.Drawing.Color.Black;
            this.m_sourcePanelCancel.ImageKey = "(none)";
            this.m_sourcePanelCancel.Location = new System.Drawing.Point(483, 345);
            this.m_sourcePanelCancel.Name = "m_sourcePanelCancel";
            this.m_sourcePanelCancel.Size = new System.Drawing.Size(57, 27);
            this.m_sourcePanelCancel.TabIndex = 36;
            this.m_sourcePanelCancel.Text = "Cancel";
            this.m_sourcePanelCancel.UseVisualStyleBackColor = false;
            this.m_sourcePanelCancel.Click += new System.EventHandler(this.m_sourcePanelCancel_Click);
            // 
            // m_sourcePanelOk
            // 
            this.m_sourcePanelOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_sourcePanelOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_sourcePanelOk.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.m_sourcePanelOk.FlatAppearance.BorderSize = 0;
            this.m_sourcePanelOk.ForeColor = System.Drawing.Color.Black;
            this.m_sourcePanelOk.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_sourcePanelOk.Location = new System.Drawing.Point(410, 345);
            this.m_sourcePanelOk.Name = "m_sourcePanelOk";
            this.m_sourcePanelOk.Size = new System.Drawing.Size(57, 27);
            this.m_sourcePanelOk.TabIndex = 35;
            this.m_sourcePanelOk.Text = "Ok";
            this.m_sourcePanelOk.UseVisualStyleBackColor = false;
            this.m_sourcePanelOk.Click += new System.EventHandler(this.m_sourcePanelOk_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(16, 183);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(280, 26);
            this.label15.TabIndex = 26;
            this.label15.Text = "Enter the password you use to login to picasaweb. This password is not stored";
            // 
            // m_sourcePanel
            // 
            this.m_sourcePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_sourcePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_sourcePanel.BackgroundImage")));
            this.m_sourcePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_sourcePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_sourcePanel.Controls.Add(this.mCAPTCHAImage);
            this.m_sourcePanel.Controls.Add(this.mCAPTCHA);
            this.m_sourcePanel.Controls.Add(this.label1);
            this.m_sourcePanel.Controls.Add(this.mUserName);
            this.m_sourcePanel.Controls.Add(this.mPassword);
            this.m_sourcePanel.Controls.Add(this.m_sourcePanelCancel);
            this.m_sourcePanel.Controls.Add(this.m_sourcePanelOk);
            this.m_sourcePanel.Controls.Add(this.label15);
            this.m_sourcePanel.Controls.Add(this.label16);
            this.m_sourcePanel.Controls.Add(this.label13);
            this.m_sourcePanel.Location = new System.Drawing.Point(0, 0);
            this.m_sourcePanel.Name = "m_sourcePanel";
            this.m_sourcePanel.Size = new System.Drawing.Size(556, 389);
            this.m_sourcePanel.TabIndex = 8;
            // 
            // mCAPTCHAImage
            // 
            this.mCAPTCHAImage.Location = new System.Drawing.Point(19, 247);
            this.mCAPTCHAImage.Name = "mCAPTCHAImage";
            this.mCAPTCHAImage.Size = new System.Drawing.Size(177, 66);
            this.mCAPTCHAImage.TabIndex = 39;
            this.mCAPTCHAImage.TabStop = false;
            // 
            // mCAPTCHA
            // 
            this.mCAPTCHA.Location = new System.Drawing.Point(347, 230);
            this.mCAPTCHA.Name = "mCAPTCHA";
            this.mCAPTCHA.Size = new System.Drawing.Size(181, 20);
            this.mCAPTCHA.TabIndex = 38;
            this.mCAPTCHA.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(16, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 26);
            this.label1.TabIndex = 37;
            this.label1.Text = "A CAPTCHA challenge was issued.";
            // 
            // mUserName
            // 
            this.mUserName.Location = new System.Drawing.Point(347, 137);
            this.mUserName.Name = "mUserName";
            this.mUserName.Size = new System.Drawing.Size(181, 20);
            this.mUserName.TabIndex = 33;
            this.mUserName.TextChanged += new System.EventHandler(this.CurrentUserNames_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(16, 137);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(252, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Enter the user name you use to login to Picasaweb. ";
            // 
            // label13
            // 
            this.label13.AutoEllipsis = true;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(479, 16);
            this.label13.TabIndex = 15;
            this.label13.Text = "This setting controls the picasa users you access for pictures for your wallpaper" +
                ".";
            // 
            // SourcePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_sourcePanel);
            this.Name = "SourcePanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.m_sourcePanel.ResumeLayout(false);
            this.m_sourcePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCAPTCHAImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox mPassword;
        protected System.Windows.Forms.Button m_sourcePanelCancel;
        protected System.Windows.Forms.Button m_sourcePanelOk;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Panel m_sourcePanel;
        protected System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Label label13;
        protected System.Windows.Forms.TextBox mUserName;
        private System.Windows.Forms.PictureBox mCAPTCHAImage;
        protected System.Windows.Forms.TextBox mCAPTCHA;
        protected System.Windows.Forms.Label label1;
    }
}
