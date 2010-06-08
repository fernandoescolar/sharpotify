namespace Sharpotify.Frames
{
    partial class LibraryControl
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
            this.trackList = new Sharpotify.Controls.TrackListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // trackList
            // 
            this.trackList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackList.AutoScroll = true;
            this.trackList.AutoScrollMinSize = new System.Drawing.Size(386, 0);
            this.trackList.BackColor = System.Drawing.Color.White;
            this.trackList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackList.HoverBackColor = System.Drawing.Color.White;
            this.trackList.ItemHeight = 54;
            this.trackList.Location = new System.Drawing.Point(0, 20);
            this.trackList.Name = "trackList";
            this.trackList.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackList.SelectedIndex = -1;
            this.trackList.SelectedItem = null;
            this.trackList.Size = new System.Drawing.Size(406, 310);
            this.trackList.TabIndex = 7;
            this.trackList.Text = "trackListBox1";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(60, 16);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Library:";
            // 
            // LibraryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.lblTitle);
            this.Name = "LibraryControl";
            this.Size = new System.Drawing.Size(409, 333);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sharpotify.Controls.TrackListBox trackList;
        private System.Windows.Forms.Label lblTitle;
    }
}
