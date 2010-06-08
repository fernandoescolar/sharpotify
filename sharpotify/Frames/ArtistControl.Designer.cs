namespace Sharpotify.Frames
{
    partial class ArtistControl
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
            this.lblName = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.albumList = new Sharpotify.Controls.AlbumListBox();
            this.lblArtist = new Sharpotify.Controls.WarpLinkListPanel();
            this.txtBio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(206, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 16);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "label1";
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(3, 3);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(200, 200);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 5;
            this.image.TabStop = false;
            // 
            // albumList
            // 
            this.albumList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.albumList.AutoScroll = true;
            this.albumList.AutoScrollMinSize = new System.Drawing.Size(697, 0);
            this.albumList.BackColor = System.Drawing.Color.White;
            this.albumList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.albumList.HoverBackColor = System.Drawing.Color.White;
            this.albumList.ItemHeight = 49;
            this.albumList.Location = new System.Drawing.Point(3, 209);
            this.albumList.Name = "albumList";
            this.albumList.SelectedBackColor = System.Drawing.Color.Gold;
            this.albumList.SelectedIndex = -1;
            this.albumList.SelectedItem = null;
            this.albumList.Size = new System.Drawing.Size(717, 242);
            this.albumList.TabIndex = 7;
            this.albumList.Text = "albumListBox1";
            // 
            // lblArtist
            // 
            this.lblArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblArtist.ForeColor = System.Drawing.Color.Gray;
            this.lblArtist.Location = new System.Drawing.Point(209, 27);
            this.lblArtist.Name = "lblArtist";
            this.lblArtist.SelectedIndex = -1;
            this.lblArtist.Size = new System.Drawing.Size(511, 20);
            this.lblArtist.TabIndex = 8;
            this.lblArtist.Text = "Similar Artist(s):";
            this.lblArtist.Title = "Similar Artist(s):";
            // 
            // txtBio
            // 
            this.txtBio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBio.Location = new System.Drawing.Point(209, 53);
            this.txtBio.Multiline = true;
            this.txtBio.Name = "txtBio";
            this.txtBio.ReadOnly = true;
            this.txtBio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBio.Size = new System.Drawing.Size(511, 150);
            this.txtBio.TabIndex = 9;
            // 
            // ArtistControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblArtist);
            this.Controls.Add(this.txtBio);
            this.Controls.Add(this.albumList);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.image);
            this.Name = "ArtistControl";
            this.Size = new System.Drawing.Size(723, 454);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox image;
        private Controls.AlbumListBox albumList;
        private Controls.WarpLinkListPanel lblArtist;
        private System.Windows.Forms.TextBox txtBio;
    }
}
