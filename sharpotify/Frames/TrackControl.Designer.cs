namespace Sharpotify.Frames
{
    partial class TrackControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelDownload = new System.Windows.Forms.FlowLayoutPanel();
            this.txtLyrics = new System.Windows.Forms.TextBox();
            this.image = new System.Windows.Forms.PictureBox();
            this.menuPlayList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDownload = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblArtist = new Sharpotify.Controls.WarpLinkListPanel();
            this.lblAlbum = new Sharpotify.Controls.WarpLinkListPanel();
            this.trackList = new Sharpotify.Controls.TrackListBox();
            this.btnPlaylist = new Sharpotify.Controls.SplitButton();
            this.btnDownload = new Sharpotify.Controls.SplitButton();
            this.groupBox1.SuspendLayout();
            this.panelDownload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(217, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(51, 16);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panelDownload);
            this.groupBox1.Location = new System.Drawing.Point(220, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 118);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // panelDownload
            // 
            this.panelDownload.Controls.Add(this.btnPlaylist);
            this.panelDownload.Controls.Add(this.btnDownload);
            this.panelDownload.Controls.Add(this.btnPlay);
            this.panelDownload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownload.Location = new System.Drawing.Point(3, 16);
            this.panelDownload.Name = "panelDownload";
            this.panelDownload.Size = new System.Drawing.Size(423, 99);
            this.panelDownload.TabIndex = 0;
            // 
            // txtLyrics
            // 
            this.txtLyrics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLyrics.Location = new System.Drawing.Point(14, 206);
            this.txtLyrics.Multiline = true;
            this.txtLyrics.Name = "txtLyrics";
            this.txtLyrics.ReadOnly = true;
            this.txtLyrics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLyrics.Size = new System.Drawing.Size(255, 242);
            this.txtLyrics.TabIndex = 5;
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(14, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(200, 200);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // menuPlayList
            // 
            this.menuPlayList.Name = "menuPlayList";
            this.menuPlayList.Size = new System.Drawing.Size(61, 4);
            // 
            // menuDownload
            // 
            this.menuDownload.Name = "menuPlayList";
            this.menuDownload.Size = new System.Drawing.Size(61, 4);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(199, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 2;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(220, 36);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.SelectedIndex = -1;
            this.lblArtist.Size = new System.Drawing.Size(429, 20);
            this.lblArtist.TabIndex = 2;
            this.lblArtist.Text = "Artist:";
            this.lblArtist.Title = "Artist:";
            // 
            // lblAlbum
            // 
            this.lblAlbum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAlbum.ForeColor = System.Drawing.Color.Gray;
            this.lblAlbum.Location = new System.Drawing.Point(220, 56);
            this.lblAlbum.Name = "lblAlbum";
            this.lblAlbum.SelectedIndex = -1;
            this.lblAlbum.Size = new System.Drawing.Size(429, 20);
            this.lblAlbum.TabIndex = 3;
            this.lblAlbum.Text = "Album:";
            this.lblAlbum.Title = "Album:";
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.AutoDragAndDrop = false;
            this.trackList.AutoScroll = true;
            this.trackList.AutoScrollMinSize = new System.Drawing.Size(354, 0);
            this.trackList.BackColor = System.Drawing.Color.White;
            this.trackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackList.HoverBackColor = System.Drawing.Color.White;
            this.trackList.ItemHeight = 54;
            this.trackList.Location = new System.Drawing.Point(275, 206);
            this.trackList.Name = "trackList";
            this.trackList.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackList.SelectedIndex = -1;
            this.trackList.SelectedItem = null;
            this.trackList.Size = new System.Drawing.Size(374, 242);
            this.trackList.TabIndex = 6;
            this.trackList.Text = "trackListBox1";
            // 
            // btnPlaylist
            // 
            this.btnPlaylist.AutoSize = true;
            this.btnPlaylist.ContextMenuStrip = this.menuPlayList;
            this.btnPlaylist.Location = new System.Drawing.Point(3, 3);
            this.btnPlaylist.Name = "btnPlaylist";
            this.btnPlaylist.Size = new System.Drawing.Size(101, 23);
            this.btnPlaylist.SplitMenuStrip = this.menuPlayList;
            this.btnPlaylist.TabIndex = 0;
            this.btnPlaylist.Text = "Add to Playlist";
            this.btnPlaylist.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoSize = true;
            this.btnDownload.ContextMenuStrip = this.menuDownload;
            this.btnDownload.Location = new System.Drawing.Point(110, 3);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(83, 23);
            this.btnDownload.SplitMenuStrip = this.menuDownload;
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // TrackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblAlbum);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.txtLyrics);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.image);
            this.Name = "TrackControl";
            this.Size = new System.Drawing.Size(665, 463);
            this.groupBox1.ResumeLayout(false);
            this.panelDownload.ResumeLayout(false);
            this.panelDownload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Label lblTitle;
        private Controls.WarpLinkListPanel lblArtist;
        private Controls.WarpLinkListPanel lblAlbum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel panelDownload;
        private System.Windows.Forms.TextBox txtLyrics;
        private Controls.TrackListBox trackList;
        private Sharpotify.Controls.SplitButton btnPlaylist;
        private System.Windows.Forms.ContextMenuStrip menuPlayList;
        private Sharpotify.Controls.SplitButton btnDownload;
        private System.Windows.Forms.ContextMenuStrip menuDownload;
        private System.Windows.Forms.Button btnPlay;
    }
}
