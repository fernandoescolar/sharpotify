namespace Sharpotify.Frames
{
    partial class ConfigControl
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
            this.grpDownloads = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.chkMp3 = new System.Windows.Forms.CheckBox();
            this.chkOgg = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnFreeCache = new System.Windows.Forms.Button();
            this.txtCacheSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkDowload = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtConnections = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.grpDownloads.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnections)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDownloads
            // 
            this.grpDownloads.Controls.Add(this.label6);
            this.grpDownloads.Controls.Add(this.groupBox2);
            this.grpDownloads.Controls.Add(this.label2);
            this.grpDownloads.Controls.Add(this.txtMask);
            this.grpDownloads.Controls.Add(this.btnFolder);
            this.grpDownloads.Controls.Add(this.label1);
            this.grpDownloads.Controls.Add(this.txtFolder);
            this.grpDownloads.Controls.Add(this.chkMp3);
            this.grpDownloads.Controls.Add(this.chkOgg);
            this.grpDownloads.Location = new System.Drawing.Point(3, 289);
            this.grpDownloads.Name = "grpDownloads";
            this.grpDownloads.Size = new System.Drawing.Size(680, 151);
            this.grpDownloads.TabIndex = 0;
            this.grpDownloads.TabStop = false;
            this.grpDownloads.Text = "Downloads";
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.BackColor = System.Drawing.SystemColors.Info;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(71, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 46);
            this.label6.TabIndex = 7;
            this.label6.Text = "%artist%: artist name; %album%: album name; %track%: track title; %number%: track" +
                " number; %year%: album year";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCommand);
            this.groupBox2.Controls.Add(this.txtArgs);
            this.groupBox2.Location = new System.Drawing.Point(349, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 109);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Convert";
            // 
            // label7
            // 
            this.label7.AutoEllipsis = true;
            this.label7.BackColor = System.Drawing.SystemColors.Info;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(81, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(232, 31);
            this.label7.TabIndex = 11;
            this.label7.Text = "%source%: source temp file;                              %result%: result file;";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Args:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Command:";
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(81, 21);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(232, 20);
            this.txtCommand.TabIndex = 7;
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(81, 47);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.Size = new System.Drawing.Size(232, 20);
            this.txtArgs.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Filename:";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(71, 79);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(232, 20);
            this.txtMask.TabIndex = 5;
            // 
            // btnFolder
            // 
            this.btnFolder.BackgroundImage = global::Sharpotify.Properties.Resources.searchFolder;
            this.btnFolder.Location = new System.Drawing.Point(303, 53);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(20, 20);
            this.btnFolder.TabIndex = 4;
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(71, 53);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(232, 20);
            this.txtFolder.TabIndex = 2;
            // 
            // chkMp3
            // 
            this.chkMp3.AutoSize = true;
            this.chkMp3.Location = new System.Drawing.Point(165, 22);
            this.chkMp3.Name = "chkMp3";
            this.chkMp3.Size = new System.Drawing.Size(87, 17);
            this.chkMp3.TabIndex = 1;
            this.chkMp3.Text = "Save in MP3";
            this.chkMp3.UseVisualStyleBackColor = true;
            // 
            // chkOgg
            // 
            this.chkOgg.AutoSize = true;
            this.chkOgg.Location = new System.Drawing.Point(20, 22);
            this.chkOgg.Name = "chkOgg";
            this.chkOgg.Size = new System.Drawing.Size(89, 17);
            this.chkOgg.TabIndex = 0;
            this.chkOgg.Text = "Save in OGG";
            this.chkOgg.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnFreeCache);
            this.groupBox3.Controls.Add(this.txtCacheSize);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(680, 62);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cache";
            // 
            // btnFreeCache
            // 
            this.btnFreeCache.Location = new System.Drawing.Point(228, 21);
            this.btnFreeCache.Name = "btnFreeCache";
            this.btnFreeCache.Size = new System.Drawing.Size(184, 23);
            this.btnFreeCache.TabIndex = 2;
            this.btnFreeCache.Text = "Release cache memory";
            this.btnFreeCache.UseVisualStyleBackColor = true;
            this.btnFreeCache.Click += new System.EventHandler(this.btnFreeCache_Click);
            // 
            // txtCacheSize
            // 
            this.txtCacheSize.Location = new System.Drawing.Point(88, 23);
            this.txtCacheSize.Name = "txtCacheSize";
            this.txtCacheSize.ReadOnly = true;
            this.txtCacheSize.Size = new System.Drawing.Size(68, 20);
            this.txtCacheSize.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Current size:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(500, 454);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(590, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkDowload);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtConnections);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(3, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 105);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Tweak Options";
            // 
            // chkDowload
            // 
            this.chkDowload.AutoSize = true;
            this.chkDowload.Location = new System.Drawing.Point(20, 82);
            this.chkDowload.Name = "chkDowload";
            this.chkDowload.Size = new System.Drawing.Size(137, 17);
            this.chkDowload.TabIndex = 13;
            this.chkDowload.Text = "Allow download options";
            this.chkDowload.UseVisualStyleBackColor = true;
            this.chkDowload.CheckedChanged += new System.EventHandler(this.chkDowload_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoEllipsis = true;
            this.label9.BackColor = System.Drawing.SystemColors.Info;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(268, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(304, 31);
            this.label9.TabIndex = 12;
            this.label9.Text = "Do not change it if you are not sure you are doing.\r\nIn order this change takes e" +
                "ffect you should restart Sharpotify.\r\n";
            // 
            // txtConnections
            // 
            this.txtConnections.Location = new System.Drawing.Point(208, 26);
            this.txtConnections.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.txtConnections.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtConnections.Name = "txtConnections";
            this.txtConnections.Size = new System.Drawing.Size(44, 20);
            this.txtConnections.TabIndex = 1;
            this.txtConnections.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(185, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Number of active spotify connections:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkAutoLogin);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtPassword);
            this.groupBox5.Controls.Add(this.txtUser);
            this.groupBox5.Location = new System.Drawing.Point(3, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(680, 101);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Creadentials";
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Location = new System.Drawing.Point(27, 19);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(229, 17);
            this.chkAutoLogin.TabIndex = 5;
            this.chkAutoLogin.Text = "Use this credentials to auto-login on startup";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            this.chkAutoLogin.CheckedChanged += new System.EventHandler(this.chkAutoLogin_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Password:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Username:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(130, 69);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(164, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(130, 43);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(164, 20);
            this.txtUser.TabIndex = 0;
            // 
            // ConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpDownloads);
            this.Name = "ConfigControl";
            this.Size = new System.Drawing.Size(686, 480);
            this.Load += new System.EventHandler(this.ConfigControl_Load);
            this.grpDownloads.ResumeLayout(false);
            this.grpDownloads.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConnections)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDownloads;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.CheckBox chkMp3;
        private System.Windows.Forms.CheckBox chkOgg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.Button btnFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCacheSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFreeCache;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown txtConnections;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDowload;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.Label label12;
    }
}
