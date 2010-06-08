namespace Sharpotify.Frames
{
    partial class AlbumControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.lblDiscs = new System.Windows.Forms.Label();
            this.lblReview = new System.Windows.Forms.TextBox();
            this.btnAddAsPlaylist = new System.Windows.Forms.Button();
            this.lblArtist = new Sharpotify.Controls.WarpLinkListPanel();
            this.lblbSimilar = new Sharpotify.Controls.WarpLinkListPanel();
            this.trackList = new Sharpotify.Controls.AlbumTrackListBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(206, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "label1";
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(200, 200);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 3;
            this.image.TabStop = false;
            // 
            // lblDiscs
            // 
            this.lblDiscs.AutoSize = true;
            this.lblDiscs.Location = new System.Drawing.Point(209, 74);
            this.lblDiscs.Name = "lblDiscs";
            this.lblDiscs.Size = new System.Drawing.Size(36, 13);
            this.lblDiscs.TabIndex = 8;
            this.lblDiscs.Text = "Discs:";
            // 
            // lblReview
            // 
            this.lblReview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReview.Location = new System.Drawing.Point(209, 99);
            this.lblReview.Multiline = true;
            this.lblReview.Name = "lblReview";
            this.lblReview.ReadOnly = true;
            this.lblReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblReview.Size = new System.Drawing.Size(536, 104);
            this.lblReview.TabIndex = 10;
            // 
            // btnAddAsPlaylist
            // 
            this.btnAddAsPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAsPlaylist.Image = global::Sharpotify.Properties.Resources.add;
            this.btnAddAsPlaylist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddAsPlaylist.Location = new System.Drawing.Point(556, 74);
            this.btnAddAsPlaylist.Name = "btnAddAsPlaylist";
            this.btnAddAsPlaylist.Size = new System.Drawing.Size(189, 24);
            this.btnAddAsPlaylist.TabIndex = 12;
            this.btnAddAsPlaylist.Text = "Add album as a new playlist";
            this.btnAddAsPlaylist.UseVisualStyleBackColor = true;
            this.btnAddAsPlaylist.Click += new System.EventHandler(this.btnAddAsPlaylist_Click);
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(209, 27);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.SelectedIndex = -1;
            this.lblArtist.Size = new System.Drawing.Size(536, 20);
            this.lblArtist.TabIndex = 5;
            this.lblArtist.Text = "Artist:";
            this.lblArtist.Title = "Artist:";
            // 
            // lblbSimilar
            // 
            this.lblbSimilar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbSimilar.ForeColor = System.Drawing.Color.Gray;
            this.lblbSimilar.Location = new System.Drawing.Point(209, 51);
            this.lblbSimilar.Name = "lblbSimilar";
            this.lblbSimilar.SelectedIndex = -1;
            this.lblbSimilar.Size = new System.Drawing.Size(536, 20);
            this.lblbSimilar.TabIndex = 11;
            this.lblbSimilar.Text = "Similar Album(s):";
            this.lblbSimilar.Title = "Similar Album(s):";
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.AutoDragAndDrop = false;
            this.trackList.AutoScroll = true;
            this.trackList.AutoScrollMinSize = new System.Drawing.Size(722, 0);
            this.trackList.BackColor = System.Drawing.Color.White;
            this.trackList.ContextMenuStrip = this.contextMenu;
            this.trackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackList.HoverBackColor = System.Drawing.Color.White;
            this.trackList.ItemHeight = 49;
            this.trackList.Location = new System.Drawing.Point(3, 209);
            this.trackList.Name = "trackList";
            this.trackList.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackList.SelectedIndex = -1;
            this.trackList.SelectedItem = null;
            this.trackList.Size = new System.Drawing.Size(742, 251);
            this.trackList.TabIndex = 9;
            this.trackList.Text = "albumTrackListBox1";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Image = global::Sharpotify.Properties.Resources.download;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(283, 74);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(155, 24);
            this.btnDownload.TabIndex = 13;
            this.btnDownload.Text = "Download all tracks";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownloads_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.Image = global::Sharpotify.Properties.Resources.player_play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(444, 74);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(106, 24);
            this.btnPlay.TabIndex = 14;
            this.btnPlay.Text = "Play album";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseTrackToolStripMenuItem,
            this.downloadTrackToolStripMenuItem,
            this.playTrackToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(162, 92);
            // 
            // browseTrackToolStripMenuItem
            // 
            this.browseTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.track;
            this.browseTrackToolStripMenuItem.Name = "browseTrackToolStripMenuItem";
            this.browseTrackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.browseTrackToolStripMenuItem.Text = "Browse Track";
            this.browseTrackToolStripMenuItem.Click += new System.EventHandler(this.browseTrackToolStripMenuItem_Click);
            // 
            // downloadTrackToolStripMenuItem
            // 
            this.downloadTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.download;
            this.downloadTrackToolStripMenuItem.Name = "downloadTrackToolStripMenuItem";
            this.downloadTrackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.downloadTrackToolStripMenuItem.Text = "Download Track";
            this.downloadTrackToolStripMenuItem.Click += new System.EventHandler(this.downloadTrackToolStripMenuItem_Click);
            // 
            // playTrackToolStripMenuItem
            // 
            this.playTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.player_play;
            this.playTrackToolStripMenuItem.Name = "playTrackToolStripMenuItem";
            this.playTrackToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.playTrackToolStripMenuItem.Text = "Play Track";
            this.playTrackToolStripMenuItem.Click += new System.EventHandler(this.playTrackToolStripMenuItem_Click);
            // 
            // AlbumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnAddAsPlaylist);
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.lblbSimilar);
            this.Controls.Add(this.lblReview);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.lblDiscs);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.image);
            this.Name = "AlbumControl";
            this.Size = new System.Drawing.Size(748, 463);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WarpLinkListPanel lblArtist;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Label lblDiscs;
        private Controls.AlbumTrackListBox trackList;
        private System.Windows.Forms.TextBox lblReview;
        private Controls.WarpLinkListPanel lblbSimilar;
        private System.Windows.Forms.Button btnAddAsPlaylist;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem browseTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playTrackToolStripMenuItem;
    }
}
