namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class ChangerPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangerPanel));
            this.m_stopNow = new System.Windows.Forms.RadioButton();
            this.m_startNow = new System.Windows.Forms.RadioButton();
            this.m_startPanelCancel = new System.Windows.Forms.Button();
            this.m_StartPanelOk = new System.Windows.Forms.Button();
            this.m_autostart = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_changerPanel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_changerPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_stopNow
            // 
            this.m_stopNow.AutoSize = true;
            this.m_stopNow.BackColor = System.Drawing.Color.Transparent;
            this.m_stopNow.Location = new System.Drawing.Point(390, 39);
            this.m_stopNow.Name = "m_stopNow";
            this.m_stopNow.Size = new System.Drawing.Size(14, 13);
            this.m_stopNow.TabIndex = 33;
            this.m_stopNow.UseVisualStyleBackColor = false;
            // 
            // m_startNow
            // 
            this.m_startNow.AutoSize = true;
            this.m_startNow.BackColor = System.Drawing.Color.Transparent;
            this.m_startNow.Location = new System.Drawing.Point(388, 84);
            this.m_startNow.Name = "m_startNow";
            this.m_startNow.Size = new System.Drawing.Size(14, 13);
            this.m_startNow.TabIndex = 32;
            this.m_startNow.UseVisualStyleBackColor = false;
            // 
            // m_startPanelCancel
            // 
            this.m_startPanelCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_startPanelCancel.ForeColor = System.Drawing.Color.Black;
            this.m_startPanelCancel.ImageKey = "(none)";
            this.m_startPanelCancel.Location = new System.Drawing.Point(483, 345);
            this.m_startPanelCancel.Name = "m_startPanelCancel";
            this.m_startPanelCancel.Size = new System.Drawing.Size(57, 27);
            this.m_startPanelCancel.TabIndex = 31;
            this.m_startPanelCancel.Text = "Cancel";
            this.m_startPanelCancel.UseVisualStyleBackColor = false;
            this.m_startPanelCancel.Click += new System.EventHandler(this.m_startPanelCancel_Click);
            // 
            // m_StartPanelOk
            // 
            this.m_StartPanelOk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_StartPanelOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_StartPanelOk.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.m_StartPanelOk.FlatAppearance.BorderSize = 0;
            this.m_StartPanelOk.ForeColor = System.Drawing.Color.Black;
            this.m_StartPanelOk.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_StartPanelOk.Location = new System.Drawing.Point(410, 345);
            this.m_StartPanelOk.Name = "m_StartPanelOk";
            this.m_StartPanelOk.Size = new System.Drawing.Size(57, 27);
            this.m_StartPanelOk.TabIndex = 30;
            this.m_StartPanelOk.Text = "Ok";
            this.m_StartPanelOk.UseVisualStyleBackColor = false;
            this.m_StartPanelOk.Click += new System.EventHandler(this.m_StartPanelOk_Click);
            // 
            // m_autostart
            // 
            this.m_autostart.AutoSize = true;
            this.m_autostart.BackColor = System.Drawing.Color.Transparent;
            this.m_autostart.Location = new System.Drawing.Point(408, 150);
            this.m_autostart.Name = "m_autostart";
            this.m_autostart.Size = new System.Drawing.Size(15, 14);
            this.m_autostart.TabIndex = 27;
            this.m_autostart.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.m_autostart.UseVisualStyleBackColor = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Location = new System.Drawing.Point(6, 79);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(166, 13);
            this.label21.TabIndex = 26;
            this.label21.Text = "Start the wallpaper changer now?";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Location = new System.Drawing.Point(6, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(166, 13);
            this.label20.TabIndex = 25;
            this.label20.Text = "Stop the wallpaper changer now?";
            // 
            // m_changerPanel
            // 
            this.m_changerPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_changerPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_changerPanel.BackgroundImage")));
            this.m_changerPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_changerPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_changerPanel.Controls.Add(this.groupBox1);
            this.m_changerPanel.Controls.Add(this.m_startPanelCancel);
            this.m_changerPanel.Controls.Add(this.m_StartPanelOk);
            this.m_changerPanel.Controls.Add(this.m_autostart);
            this.m_changerPanel.Controls.Add(this.label17);
            this.m_changerPanel.Controls.Add(this.label19);
            this.m_changerPanel.Location = new System.Drawing.Point(0, 0);
            this.m_changerPanel.Name = "m_changerPanel";
            this.m_changerPanel.Size = new System.Drawing.Size(556, 389);
            this.m_changerPanel.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoEllipsis = true;
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(26, 34);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(430, 32);
            this.label17.TabIndex = 23;
            this.label17.Text = "Use these setting to control how the wallpaper changer runs. Make your \rselection" +
                "s then click OK";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(26, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(209, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Start the wallpaper changer with windows?";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.m_stopNow);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.m_startNow);
            this.groupBox1.Location = new System.Drawing.Point(20, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 121);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wallpaper Changer Control";
            // 
            // ChangerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_changerPanel);
            this.Name = "ChangerPanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.m_changerPanel.ResumeLayout(false);
            this.m_changerPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton m_stopNow;
        private System.Windows.Forms.RadioButton m_startNow;
        private System.Windows.Forms.Button m_startPanelCancel;
        private System.Windows.Forms.Button m_StartPanelOk;
        private System.Windows.Forms.CheckBox m_autostart;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.Panel m_changerPanel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
