namespace Sharpotify.Frames
{
    partial class PlayerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerControl));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.bass = new nBASS.BASS(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlVolume = new System.Windows.Forms.Panel();
            this.chkMute = new System.Windows.Forms.CheckBox();
            this.barVolume = new System.Windows.Forms.TrackBar();
            this.btnVolume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlVolume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Image = global::Sharpotify.Properties.Resources.player_play;
            this.btnPlay.Location = new System.Drawing.Point(1, 206);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(26, 26);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Image = global::Sharpotify.Properties.Resources.player_pause;
            this.btnPause.Location = new System.Drawing.Point(33, 206);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(26, 26);
            this.btnPause.TabIndex = 1;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Image = global::Sharpotify.Properties.Resources.player_stop;
            this.btnStop.Location = new System.Drawing.Point(65, 206);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(26, 26);
            this.btnStop.TabIndex = 2;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // bass
            // 
            this.bass.Device = "Default";
            this.bass.Frequency = 44100;
            this.bass.MusicVolume = 100;
            this.bass.ParentForm = null;
            this.bass.SampleVolume = 100;
            this.bass.SetupFlags = nBASS.DeviceSetupFlags.Default;
            this.bass.StreamVolume = 50;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(1, 187);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(35, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "label1";
            this.lblStatus.Visible = false;
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(97, 206);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(26, 26);
            this.btnNext.TabIndex = 4;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlVolume
            // 
            this.pnlVolume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVolume.Controls.Add(this.chkMute);
            this.pnlVolume.Controls.Add(this.barVolume);
            this.pnlVolume.Location = new System.Drawing.Point(148, 78);
            this.pnlVolume.Name = "pnlVolume";
            this.pnlVolume.Size = new System.Drawing.Size(49, 128);
            this.pnlVolume.TabIndex = 6;
            this.pnlVolume.Visible = false;
            // 
            // chkMute
            // 
            this.chkMute.AutoSize = true;
            this.chkMute.Location = new System.Drawing.Point(3, 108);
            this.chkMute.Name = "chkMute";
            this.chkMute.Size = new System.Drawing.Size(50, 17);
            this.chkMute.TabIndex = 1;
            this.chkMute.Text = "Mute";
            this.chkMute.UseVisualStyleBackColor = true;
            this.chkMute.CheckedChanged += new System.EventHandler(this.chkMute_CheckedChanged);
            // 
            // barVolume
            // 
            this.barVolume.Location = new System.Drawing.Point(7, 0);
            this.barVolume.Name = "barVolume";
            this.barVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.barVolume.Size = new System.Drawing.Size(45, 103);
            this.barVolume.TabIndex = 0;
            this.barVolume.Scroll += new System.EventHandler(this.barVolume_Scroll);
            this.barVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.barVolume_MouseUp);
            // 
            // btnVolume
            // 
            this.btnVolume.Image = global::Sharpotify.Properties.Resources.Speaker;
            this.btnVolume.Location = new System.Drawing.Point(161, 206);
            this.btnVolume.Name = "btnVolume";
            this.btnVolume.Size = new System.Drawing.Size(26, 26);
            this.btnVolume.TabIndex = 7;
            this.btnVolume.UseVisualStyleBackColor = true;
            this.btnVolume.Click += new System.EventHandler(this.btnVolume_Click);
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnVolume);
            this.Controls.Add(this.pnlVolume);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(200, 237);
            ((System.ComponentModel.ISupportInitialize)(this.bass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlVolume.ResumeLayout(false);
            this.pnlVolume.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStop;
        private nBASS.BASS bass;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlVolume;
        private System.Windows.Forms.TrackBar barVolume;
        private System.Windows.Forms.Button btnVolume;
        private System.Windows.Forms.CheckBox chkMute;
    }
}
