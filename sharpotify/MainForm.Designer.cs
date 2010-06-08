namespace Sharpotify
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PanelContainer = new System.Windows.Forms.Panel();
            this.mainMenu = new Sharpotify.Controls.MenuListBox();
            this.searchControl1 = new Sharpotify.Frames.SearchControl();
            this.playerControl = new Sharpotify.Frames.PlayerControl();
            this.SuspendLayout();
            // 
            // PanelContainer
            // 
            this.PanelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelContainer.Location = new System.Drawing.Point(210, 36);
            this.PanelContainer.Name = "PanelContainer";
            this.PanelContainer.Size = new System.Drawing.Size(662, 520);
            this.PanelContainer.TabIndex = 8;
            // 
            // mainMenu
            // 
            this.mainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.mainMenu.AutoDragAndDrop = false;
            this.mainMenu.AutoScroll = true;
            this.mainMenu.AutoScrollMinSize = new System.Drawing.Size(180, 0);
            this.mainMenu.BackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mainMenu.HoverBackColor = System.Drawing.Color.DarkGray;
            this.mainMenu.ItemHeight = 20;
            this.mainMenu.Location = new System.Drawing.Point(4, 12);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.SelectedBackColor = System.Drawing.SystemColors.Control;
            this.mainMenu.SelectedIndex = -1;
            this.mainMenu.SelectedItem = null;
            this.mainMenu.Size = new System.Drawing.Size(200, 302);
            this.mainMenu.TabIndex = 12;
            this.mainMenu.Text = "menuListBox1";
            // 
            // searchControl1
            // 
            this.searchControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchControl1.Location = new System.Drawing.Point(562, 8);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Size = new System.Drawing.Size(310, 22);
            this.searchControl1.TabIndex = 7;
            // 
            // playerControl
            // 
            this.playerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playerControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playerControl.Location = new System.Drawing.Point(4, 320);
            this.playerControl.Name = "playerControl";
            this.playerControl.Size = new System.Drawing.Size(200, 237);
            this.playerControl.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.playerControl);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.PanelContainer);
            this.Controls.Add(this.searchControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sharpotify";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sharpotify.Frames.SearchControl searchControl1;
        private System.Windows.Forms.Panel PanelContainer;
        private Sharpotify.Controls.MenuListBox mainMenu;
        private Sharpotify.Frames.PlayerControl playerControl;
    }
}