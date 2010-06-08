namespace Sharpotify.Forms
{
    partial class TestForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackListBox1 = new Sharpotify.Controls.TrackListBox();
            this.warpLinkListPanel1 = new Sharpotify.Controls.WarpLinkListPanel();
            this.mainMenu = new Sharpotify.Controls.MenuListBox();
            this.SuspendLayout();
            // 
            // trackListBox1
            // 
            this.trackListBox1.AutoScroll = true;
            this.trackListBox1.AutoScrollMinSize = new System.Drawing.Size(434, 0);
            this.trackListBox1.BackColor = System.Drawing.Color.White;
            this.trackListBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackListBox1.HoverBackColor = System.Drawing.Color.White;
            this.trackListBox1.ItemHeight = 54;
            this.trackListBox1.Location = new System.Drawing.Point(12, 117);
            this.trackListBox1.Name = "trackListBox1";
            this.trackListBox1.SelectedBackColor = System.Drawing.Color.Gold;
            this.trackListBox1.SelectedIndex = -1;
            this.trackListBox1.SelectedItem = null;
            this.trackListBox1.Size = new System.Drawing.Size(454, 291);
            this.trackListBox1.TabIndex = 0;
            this.trackListBox1.Text = "trackListBox1";
            // 
            // warpLinkListPanel1
            // 
            this.warpLinkListPanel1.Location = new System.Drawing.Point(12, 12);
            this.warpLinkListPanel1.Name = "warpLinkListPanel1";
            this.warpLinkListPanel1.SelectedIndex = -1;
            this.warpLinkListPanel1.Size = new System.Drawing.Size(445, 99);
            this.warpLinkListPanel1.TabIndex = 1;
            this.warpLinkListPanel1.Text = "warpLinkListPanel1";
            this.warpLinkListPanel1.Title = "Album(s):";
            // 
            // mainMenu
            // 
            this.mainMenu.AutoScroll = true;
            this.mainMenu.AutoScrollMinSize = new System.Drawing.Size(195, 0);
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainMenu.HoverBackColor = System.Drawing.Color.DarkGray;
            this.mainMenu.ItemHeight = 20;
            this.mainMenu.Location = new System.Drawing.Point(487, 24);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.SelectedBackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.SelectedIndex = -1;
            this.mainMenu.SelectedItem = null;
            this.mainMenu.Size = new System.Drawing.Size(215, 384);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuListBox1";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 447);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.warpLinkListPanel1);
            this.Controls.Add(this.trackListBox1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sharpotify.Controls.TrackListBox trackListBox1;
        private Sharpotify.Controls.WarpLinkListPanel warpLinkListPanel1;
        private Sharpotify.Controls.MenuListBox mainMenu;
    }
}