namespace Sharpotify.Frames
{
    partial class PlaylistControl
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
            this.trackList = new Sharpotify.Controls.TrackListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTrackFromPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPlay = new Sharpotify.Controls.SplitButton();
            this.menuPlay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playInRandomModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.playTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDownload = new System.Windows.Forms.Button();
            this.contextMenu.SuspendLayout();
            this.menuPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.AutoDragAndDrop = false;
            this.trackList.AutoScroll = true;
            this.trackList.AutoScrollMinSize = new System.Drawing.Size(468, 0);
            this.trackList.BackColor = System.Drawing.Color.White;
            this.trackList.ContextMenuStrip = this.contextMenu;
            this.trackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackList.HoverBackColor = System.Drawing.Color.White;
            this.trackList.ItemHeight = 54;
            this.trackList.Location = new System.Drawing.Point(0, 45);
            this.trackList.Name = "trackList";
            this.trackList.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackList.SelectedIndex = -1;
            this.trackList.SelectedItem = null;
            this.trackList.Size = new System.Drawing.Size(488, 300);
            this.trackList.TabIndex = 7;
            this.trackList.Text = "trackListBox1";
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseTrackToolStripMenuItem,
            this.downloadTrackToolStripMenuItem,
            this.playTrackToolStripMenuItem,
            this.deleteTrackFromPlaylistToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(205, 92);
            // 
            // browseTrackToolStripMenuItem
            // 
            this.browseTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.track;
            this.browseTrackToolStripMenuItem.Name = "browseTrackToolStripMenuItem";
            this.browseTrackToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.browseTrackToolStripMenuItem.Text = "Browse Track";
            this.browseTrackToolStripMenuItem.Click += new System.EventHandler(this.browseTrackToolStripMenuItem_Click);
            // 
            // deleteTrackFromPlaylistToolStripMenuItem
            // 
            this.deleteTrackFromPlaylistToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.delete;
            this.deleteTrackFromPlaylistToolStripMenuItem.Name = "deleteTrackFromPlaylistToolStripMenuItem";
            this.deleteTrackFromPlaylistToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.deleteTrackFromPlaylistToolStripMenuItem.Text = "Delete track from playlist";
            this.deleteTrackFromPlaylistToolStripMenuItem.Click += new System.EventHandler(this.deleteTrackFromPlaylistToolStripMenuItem_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(67, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Playlist: ";
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlay.AutoSize = true;
            this.btnPlay.ContextMenuStrip = this.menuPlay;
            this.btnPlay.Image = global::Sharpotify.Properties.Resources.player_play;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlay.Location = new System.Drawing.Point(202, 15);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 23);
            this.btnPlay.SplitMenuStrip = this.menuPlay;
            this.btnPlay.TabIndex = 15;
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // menuPlay
            // 
            this.menuPlay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playPlaylistToolStripMenuItem,
            this.playInRandomModeToolStripMenuItem});
            this.menuPlay.Name = "menuPlay";
            this.menuPlay.Size = new System.Drawing.Size(188, 48);
            // 
            // playPlaylistToolStripMenuItem
            // 
            this.playPlaylistToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.player_play;
            this.playPlaylistToolStripMenuItem.Name = "playPlaylistToolStripMenuItem";
            this.playPlaylistToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.playPlaylistToolStripMenuItem.Text = "Play playlist";
            this.playPlaylistToolStripMenuItem.Click += new System.EventHandler(this.playPlaylistToolStripMenuItem_Click);
            // 
            // playInRandomModeToolStripMenuItem
            // 
            this.playInRandomModeToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.finish;
            this.playInRandomModeToolStripMenuItem.Name = "playInRandomModeToolStripMenuItem";
            this.playInRandomModeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.playInRandomModeToolStripMenuItem.Text = "Play in Random mode";
            this.playInRandomModeToolStripMenuItem.Click += new System.EventHandler(this.playInRandomModeToolStripMenuItem_Click);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.Image = global::Sharpotify.Properties.Resources.GripNormal;
            this.btnRename.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRename.Location = new System.Drawing.Point(248, 15);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(111, 24);
            this.btnRename.TabIndex = 14;
            this.btnRename.Text = "Rename album";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::Sharpotify.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(365, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(120, 24);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Playlist";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // playTrackToolStripMenuItem
            // 
            this.playTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.player_play;
            this.playTrackToolStripMenuItem.Name = "playTrackToolStripMenuItem";
            this.playTrackToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.playTrackToolStripMenuItem.Text = "Play Track";
            this.playTrackToolStripMenuItem.Click += new System.EventHandler(this.playTrackToolStripMenuItem_Click);
            // 
            // downloadTrackToolStripMenuItem
            // 
            this.downloadTrackToolStripMenuItem.Image = global::Sharpotify.Properties.Resources.download;
            this.downloadTrackToolStripMenuItem.Name = "downloadTrackToolStripMenuItem";
            this.downloadTrackToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.downloadTrackToolStripMenuItem.Text = "Download Track";
            this.downloadTrackToolStripMenuItem.Click += new System.EventHandler(this.downloadTrackToolStripMenuItem_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Image = global::Sharpotify.Properties.Resources.download;
            this.btnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownload.Location = new System.Drawing.Point(76, 15);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(120, 24);
            this.btnDownload.TabIndex = 16;
            this.btnDownload.Text = "Download All";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // PlaylistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.lblTitle);
            this.Name = "PlaylistControl";
            this.Size = new System.Drawing.Size(488, 345);
            this.contextMenu.ResumeLayout(false);
            this.menuPlay.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sharpotify.Controls.TrackListBox trackList;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem browseTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTrackFromPlaylistToolStripMenuItem;
        private System.Windows.Forms.Button btnRename;
        private Sharpotify.Controls.SplitButton btnPlay;
        private System.Windows.Forms.ContextMenuStrip menuPlay;
        private System.Windows.Forms.ToolStripMenuItem playPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playInRandomModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playTrackToolStripMenuItem;
        private System.Windows.Forms.Button btnDownload;
    }
}
