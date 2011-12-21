namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class SizePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SizePanel));
            this.m_sizePercent = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cancelSizePanel = new System.Windows.Forms.Button();
            this.m_sizePanel = new System.Windows.Forms.Panel();
            this.m_okSizePanel = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_sizePercent)).BeginInit();
            this.m_sizePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_sizePercent
            // 
            this.m_sizePercent.Location = new System.Drawing.Point(410, 142);
            this.m_sizePercent.Name = "m_sizePercent";
            this.m_sizePercent.Size = new System.Drawing.Size(82, 20);
            this.m_sizePercent.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoEllipsis = true;
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(14, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(425, 32);
            this.label14.TabIndex = 20;
            this.label14.Text = "You can choose how much of your desktop is used to display pictures. \rUse the set" +
                "tings below to do so.";
            // 
            // m_cancelSizePanel
            // 
            this.m_cancelSizePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_cancelSizePanel.ForeColor = System.Drawing.Color.Black;
            this.m_cancelSizePanel.ImageKey = "(none)";
            this.m_cancelSizePanel.Location = new System.Drawing.Point(483, 345);
            this.m_cancelSizePanel.Name = "m_cancelSizePanel";
            this.m_cancelSizePanel.Size = new System.Drawing.Size(57, 27);
            this.m_cancelSizePanel.TabIndex = 19;
            this.m_cancelSizePanel.Text = "Cancel";
            this.m_cancelSizePanel.UseVisualStyleBackColor = false;
            this.m_cancelSizePanel.Click += new System.EventHandler(this.m_cancelSizePanel_Click);
            // 
            // m_sizePanel
            // 
            this.m_sizePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_sizePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_sizePanel.BackgroundImage")));
            this.m_sizePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_sizePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_sizePanel.Controls.Add(this.m_sizePercent);
            this.m_sizePanel.Controls.Add(this.label14);
            this.m_sizePanel.Controls.Add(this.m_cancelSizePanel);
            this.m_sizePanel.Controls.Add(this.m_okSizePanel);
            this.m_sizePanel.Controls.Add(this.label18);
            this.m_sizePanel.Location = new System.Drawing.Point(0, 0);
            this.m_sizePanel.Name = "m_sizePanel";
            this.m_sizePanel.Size = new System.Drawing.Size(556, 389);
            this.m_sizePanel.TabIndex = 9;
            this.m_sizePanel.Visible = true;
            // 
            // m_okSizePanel
            // 
            this.m_okSizePanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_okSizePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_okSizePanel.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.m_okSizePanel.FlatAppearance.BorderSize = 0;
            this.m_okSizePanel.ForeColor = System.Drawing.Color.Black;
            this.m_okSizePanel.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.m_okSizePanel.Location = new System.Drawing.Point(410, 345);
            this.m_okSizePanel.Name = "m_okSizePanel";
            this.m_okSizePanel.Size = new System.Drawing.Size(57, 27);
            this.m_okSizePanel.TabIndex = 18;
            this.m_okSizePanel.Text = "Ok";
            this.m_okSizePanel.UseVisualStyleBackColor = false;
            this.m_okSizePanel.Click += new System.EventHandler(this.m_okSizePanel_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(14, 144);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(297, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Choose the percentage of the desktop taken up by the image";
            // 
            // SizePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_sizePanel);
            this.Name = "SizePanel";
            this.Size = new System.Drawing.Size(556, 389);
            ((System.ComponentModel.ISupportInitialize)(this.m_sizePercent)).EndInit();
            this.m_sizePanel.ResumeLayout(false);
            this.m_sizePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown m_sizePercent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button m_cancelSizePanel;
        private System.Windows.Forms.Button m_okSizePanel;
        private System.Windows.Forms.Label label18;
        protected System.Windows.Forms.Panel m_sizePanel;

    }
}
