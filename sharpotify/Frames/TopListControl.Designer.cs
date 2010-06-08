namespace Sharpotify.Frames
{
    partial class TopListControl
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
            this.trackList = new Sharpotify.Controls.TrackListBox();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.browseTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(72, 16);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Top List: ";
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.AutoDragAndDrop = false;
            this.trackList.AutoScroll = true;
            this.trackList.AutoScrollMinSize = new System.Drawing.Size(405, 0);
            this.trackList.BackColor = System.Drawing.Color.White;
            this.trackList.ContextMenuStrip = this.contextMenu;
            this.trackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackList.HoverBackColor = System.Drawing.Color.White;
            this.trackList.ItemHeight = 54;
            this.trackList.Location = new System.Drawing.Point(0, 19);
            this.trackList.Name = "trackList";
            this.trackList.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackList.SelectedIndex = -1;
            this.trackList.SelectedItem = null;
            this.trackList.Size = new System.Drawing.Size(425, 283);
            this.trackList.TabIndex = 5;
            this.trackList.Text = "trackListBox1";
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
            // TopListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.lblTitle);
            this.Name = "TopListControl";
            this.Size = new System.Drawing.Size(425, 302);
            this.Load += new System.EventHandler(this.TopListControl_Load);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Sharpotify.Controls.TrackListBox trackList;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem browseTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadTrackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playTrackToolStripMenuItem;
    }
}
