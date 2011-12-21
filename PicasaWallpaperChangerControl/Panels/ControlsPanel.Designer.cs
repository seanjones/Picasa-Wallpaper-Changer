namespace Sean_Jones.PicasaWallpaperChangerControl
{
    partial class ControlsPanel
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlsPanel));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_start = new System.Windows.Forms.Button();
            this.m_controllButtons = new System.Windows.Forms.ImageList(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_size = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_source = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.m_controlsPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_tags = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_timing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_controlsPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.m_start);
            this.groupBox5.Location = new System.Drawing.Point(23, 306);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(511, 69);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Start or stop the PicasaPhotoChanger";
            // 
            // m_start
            // 
            this.m_start.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_start.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.m_start.FlatAppearance.BorderSize = 0;
            this.m_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.m_start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.m_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_start.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_start.ForeColor = System.Drawing.Color.Black;
            this.m_start.ImageKey = "m_start_up";
            this.m_start.ImageList = this.m_controllButtons;
            this.m_start.Location = new System.Drawing.Point(6, 10);
            this.m_start.Name = "m_start";
            this.m_start.Size = new System.Drawing.Size(101, 50);
            this.m_start.TabIndex = 4;
            this.m_start.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_start.UseVisualStyleBackColor = false;
            this.m_start.Click += new System.EventHandler(this.m_start_Click);
            this.m_start.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.m_start.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // m_controllButtons
            // 
            this.m_controllButtons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_controllButtons.ImageStream")));
            this.m_controllButtons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_controllButtons.Images.SetKeyName(0, "m_start_up");
            this.m_controllButtons.Images.SetKeyName(1, "m_size_down");
            this.m_controllButtons.Images.SetKeyName(2, "m_size_up");
            this.m_controllButtons.Images.SetKeyName(3, "m_source_down");
            this.m_controllButtons.Images.SetKeyName(4, "m_source_up");
            this.m_controllButtons.Images.SetKeyName(5, "m_tags_down");
            this.m_controllButtons.Images.SetKeyName(6, "m_tags_up");
            this.m_controllButtons.Images.SetKeyName(7, "m_timing_down");
            this.m_controllButtons.Images.SetKeyName(8, "m_timing_up");
            this.m_controllButtons.Images.SetKeyName(9, "m_start_down");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.m_size);
            this.groupBox4.Location = new System.Drawing.Point(23, 231);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(511, 69);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Change the size of pictures displayed";
            // 
            // m_size
            // 
            this.m_size.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_size.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.m_size.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.m_size.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.m_size.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_size.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_size.ForeColor = System.Drawing.Color.Black;
            this.m_size.ImageKey = "m_size_up";
            this.m_size.ImageList = this.m_controllButtons;
            this.m_size.Location = new System.Drawing.Point(6, 10);
            this.m_size.Name = "m_size";
            this.m_size.Size = new System.Drawing.Size(100, 50);
            this.m_size.TabIndex = 3;
            this.m_size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_size.UseVisualStyleBackColor = true;
            this.m_size.Click += new System.EventHandler(this.m_size_Click);
            this.m_size.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.m_size.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_source);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(23, 156);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(511, 69);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // m_source
            // 
            this.m_source.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_source.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_source.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.m_source.FlatAppearance.BorderSize = 0;
            this.m_source.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.m_source.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.m_source.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_source.Font = new System.Drawing.Font("Comic Sans MS", 9F);
            this.m_source.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_source.ImageKey = "m_source_up";
            this.m_source.ImageList = this.m_controllButtons;
            this.m_source.Location = new System.Drawing.Point(6, 10);
            this.m_source.Name = "m_source";
            this.m_source.Size = new System.Drawing.Size(100, 50);
            this.m_source.TabIndex = 2;
            this.m_source.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_source.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_source.UseVisualStyleBackColor = false;
            this.m_source.Click += new System.EventHandler(this.m_source_Click);
            this.m_source.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.m_source.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Change the picasa sites used for photos";
            // 
            // m_controlsPanel
            // 
            this.m_controlsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_controlsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_controlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_controlsPanel.Controls.Add(this.groupBox5);
            this.m_controlsPanel.Controls.Add(this.groupBox4);
            this.m_controlsPanel.Controls.Add(this.groupBox3);
            this.m_controlsPanel.Controls.Add(this.groupBox2);
            this.m_controlsPanel.Controls.Add(this.groupBox1);
            this.m_controlsPanel.Location = new System.Drawing.Point(0, 0);
            this.m_controlsPanel.Name = "m_controlsPanel";
            this.m_controlsPanel.Size = new System.Drawing.Size(556, 389);
            this.m_controlsPanel.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_tags);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(23, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 69);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // m_tags
            // 
            this.m_tags.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_tags.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.m_tags.FlatAppearance.BorderSize = 0;
            this.m_tags.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.m_tags.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.m_tags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_tags.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_tags.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_tags.ImageKey = "m_tags_up";
            this.m_tags.ImageList = this.m_controllButtons;
            this.m_tags.Location = new System.Drawing.Point(6, 10);
            this.m_tags.Name = "m_tags";
            this.m_tags.Size = new System.Drawing.Size(100, 50);
            this.m_tags.TabIndex = 1;
            this.m_tags.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_tags.UseVisualStyleBackColor = true;
            this.m_tags.Click += new System.EventHandler(this.m_tags_Click);
            this.m_tags.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.m_tags.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Change the tags used to choose which pictures to show";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_timing);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(23, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 69);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // m_timing
            // 
            this.m_timing.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_timing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_timing.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.m_timing.FlatAppearance.BorderSize = 0;
            this.m_timing.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.m_timing.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.m_timing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_timing.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_timing.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_timing.ImageKey = "m_timing_up";
            this.m_timing.ImageList = this.m_controllButtons;
            this.m_timing.Location = new System.Drawing.Point(6, 10);
            this.m_timing.Name = "m_timing";
            this.m_timing.Size = new System.Drawing.Size(100, 50);
            this.m_timing.TabIndex = 0;
            this.m_timing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_timing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_timing.UseVisualStyleBackColor = false;
            this.m_timing.Click += new System.EventHandler(this.m_timing_Click);
            this.m_timing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.m_timing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Adjust the frequency of index builds and picture changes";
            // 
            // ControlsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_controlsPanel);
            this.Name = "ControlsPanel";
            this.Size = new System.Drawing.Size(556, 389);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.m_controlsPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button m_start;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_size;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button m_source;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_tags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_timing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList m_controllButtons;
        public System.Windows.Forms.Panel m_controlsPanel;
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             