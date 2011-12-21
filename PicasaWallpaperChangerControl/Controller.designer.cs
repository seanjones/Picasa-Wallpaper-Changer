namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class Controller
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            this.mNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.mChangerStatus = new System.Windows.Forms.TextBox();
            this.mLastIndexed = new System.Windows.Forms.TextBox();
            this.mNumberOfPhotos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mNewPanel = new System.Windows.Forms.Panel();
            this.mNewPanelNext = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.mReindexTimer = new System.Windows.Forms.Timer(this.components);
            this.mChangePhotoTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.mNewPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mNotifyIcon
            // 
            this.mNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.mNotifyIcon.BalloonTipText = "Click here to change the picture";
            this.mNotifyIcon.BalloonTipTitle = "Instant Change";
            this.mNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mNotifyIcon.Icon")));
            this.mNotifyIcon.Text = "Left Click to change picture, Right Click for options";
            this.mNotifyIcon.Visible = true;
            this.mNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.mChangerStatus);
            this.panel2.Controls.Add(this.mLastIndexed);
            this.panel2.Controls.Add(this.mNumberOfPhotos);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 389);
            this.panel2.TabIndex = 4;
            // 
            // mChangerStatus
            // 
            this.mChangerStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mChangerStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mChangerStatus.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.mChangerStatus.Location = new System.Drawing.Point(12, 209);
            this.mChangerStatus.Multiline = true;
            this.mChangerStatus.Name = "mChangerStatus";
            this.mChangerStatus.ReadOnly = true;
            this.mChangerStatus.Size = new System.Drawing.Size(143, 54);
            this.mChangerStatus.TabIndex = 6;
            this.mChangerStatus.TabStop = false;
            // 
            // mLastIndexed
            // 
            this.mLastIndexed.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mLastIndexed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mLastIndexed.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.mLastIndexed.Location = new System.Drawing.Point(12, 118);
            this.mLastIndexed.Multiline = true;
            this.mLastIndexed.Name = "mLastIndexed";
            this.mLastIndexed.ReadOnly = true;
            this.mLastIndexed.Size = new System.Drawing.Size(143, 54);
            this.mLastIndexed.TabIndex = 5;
            this.mLastIndexed.TabStop = false;
            // 
            // mNumberOfPhotos
            // 
            this.mNumberOfPhotos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mNumberOfPhotos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mNumberOfPhotos.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.mNumberOfPhotos.Location = new System.Drawing.Point(12, 27);
            this.mNumberOfPhotos.Multiline = true;
            this.mNumberOfPhotos.Name = "mNumberOfPhotos";
            this.mNumberOfPhotos.ReadOnly = true;
            this.mNumberOfPhotos.Size = new System.Drawing.Size(143, 54);
            this.mNumberOfPhotos.TabIndex = 4;
            this.mNumberOfPhotos.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 49);
            this.label2.TabIndex = 3;
            this.label2.Text = "Please choose an option from the right.";
            // 
            // mNewPanel
            // 
            this.mNewPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mNewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.mNewPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mNewPanel.Controls.Add(this.mNewPanelNext);
            this.mNewPanel.Controls.Add(this.label24);
            this.mNewPanel.Location = new System.Drawing.Point(189, 29);
            this.mNewPanel.Name = "mNewPanel";
            this.mNewPanel.Size = new System.Drawing.Size(556, 389);
            this.mNewPanel.TabIndex = 10;
            // 
            // mNewPanelNext
            // 
            this.mNewPanelNext.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mNewPanelNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mNewPanelNext.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.mNewPanelNext.FlatAppearance.BorderSize = 0;
            this.mNewPanelNext.ForeColor = System.Drawing.Color.Black;
            this.mNewPanelNext.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.mNewPanelNext.Location = new System.Drawing.Point(410, 345);
            this.mNewPanelNext.Name = "mNewPanelNext";
            this.mNewPanelNext.Size = new System.Drawing.Size(57, 27);
            this.mNewPanelNext.TabIndex = 27;
            this.mNewPanelNext.Text = "Start";
            this.mNewPanelNext.UseVisualStyleBackColor = false;
            this.mNewPanelNext.Click += new System.EventHandler(this.NewPanelNext_Click);
            // 
            // label24
            // 
            this.label24.AutoEllipsis = true;
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(20, 126);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(464, 32);
            this.label24.TabIndex = 15;
            this.label24.Text = "This is the first time you have run the Picasa Wallpaper Changer. \rYou will now b" +
                "e asked for some details to enable everything to work correctly.";
            // 
            // Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(782, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mNewPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Controller";
            this.Text = "Picasa Wallpaper Changer";
            this.Load += new System.EventHandler(this.Controller_Load);
            this.SizeChanged += new System.EventHandler(this.Controller_ResizeEnd);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.mNewPanel.ResumeLayout(false);
            this.mNewPanel.PerformLayout();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.NotifyIcon mNotifyIcon;
        private System.Windows.Forms.ToolTip mToolTip;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel mNewPanel;
        private System.Windows.Forms.Button mNewPanelNext;
        private System.Windows.Forms.Label label24;
        //  private CurrentPanel mCurrentPanel;
        private System.Windows.Forms.TextBox mNumberOfPhotos;
        private System.Windows.Forms.TextBox mChangerStatus;
        private System.Windows.Forms.TextBox mLastIndexed;
        private System.Windows.Forms.Timer mReindexTimer;
        private System.Windows.Forms.Timer mChangePhotoTimer;
    }
}

