using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sharpotify.Frames
{
    public partial class ConfigControl : UserControl
    {
        public ConfigControl()
        {
            InitializeComponent();
        }

        private void ConfigControl_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }
        public static long DirSize(System.IO.DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes.
            System.IO.FileInfo[] fis = d.GetFiles();
            foreach (System.IO.FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes.
            System.IO.DirectoryInfo[] dis = d.GetDirectories();
            foreach (System.IO.DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }
        public static void DirRelease(System.IO.DirectoryInfo d)
        {
            
            // Add file sizes.
            System.IO.FileInfo[] fis = d.GetFiles();
            foreach (System.IO.FileInfo fi in fis)
            {
                fi.Delete();
            }
            // Add subdirectory sizes.
            System.IO.DirectoryInfo[] dis = d.GetDirectories();
            foreach (System.IO.DirectoryInfo di in dis)
            {
                di.Delete(true);
            }
        }
        private void LoadInfo()
        {
            //Cache
            txtCacheSize.Text = DirSize(new System.IO.DirectoryInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache"))).ToString();

            //Credentials
            if (Properties.Settings.Default.Autologin)
            {
                chkAutoLogin.Checked = true;
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
            }
            else
            {
                chkAutoLogin.Checked = false;
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
            }
            txtUser.Text = Properties.Settings.Default.Username;
            txtPassword.Text = Properties.Settings.Default.Password;

            //Tweaks
            txtConnections.Value = Properties.Settings.Default.ConnectionsNumber;
            if (Properties.Settings.Default.AllowDownloads)
            {
                chkDowload.Checked = true;
                grpDownloads.Visible = true;
            }
            else
            {
                chkDowload.Checked = false;
                chkDowload.Visible = false;
                grpDownloads.Visible = false;
            }

            //Downloads
            string[] formats = Properties.Settings.Default.DownloadFormat.Split(',');

            chkOgg.Checked = formats.Contains<string>("ogg");
            chkMp3.Checked = formats.Contains<string>("mp3");

            txtFolder.Text = Properties.Settings.Default.DownloadFolder;
            txtMask.Text = Properties.Settings.Default.DownloadMask;
            txtCommand.Text = Properties.Settings.Default.DownloadCommand;
            txtArgs.Text = Properties.Settings.Default.DownloadArguments;
        }

        private void btnFreeCache_Click(object sender, EventArgs e)
        {
            DirRelease(new System.IO.DirectoryInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache")));
            txtCacheSize.Text = DirSize(new System.IO.DirectoryInfo(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "cache"))).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Autologin = chkAutoLogin.Checked;
            Properties.Settings.Default.Username = txtUser.Text;
            Properties.Settings.Default.Password = txtPassword.Text;

            Properties.Settings.Default.ConnectionsNumber = (int)txtConnections.Value;
            Properties.Settings.Default.AllowDownloads = chkDowload.Checked;

            string formats = string.Empty;
            if (chkOgg.Checked)
                formats += "ogg";
            if (chkMp3.Checked)
            {
                if (!string.IsNullOrEmpty(formats))
                    formats += ",";
                formats += "mp3";
            }
            Properties.Settings.Default.DownloadFormat = formats;
            Properties.Settings.Default.DownloadFolder = txtFolder.Text;
            Properties.Settings.Default.DownloadMask = txtMask.Text;
            Properties.Settings.Default.DownloadCommand = txtCommand.Text;
            Properties.Settings.Default.DownloadArguments = txtArgs.Text;
            
            Properties.Settings.Default.Save();
            Facade.RefreshMainMenu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadInfo();
        }

        private void chkAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            txtUser.Enabled = chkAutoLogin.Checked;
            txtPassword.Enabled = chkAutoLogin.Checked;
        }

        private void chkDowload_CheckedChanged(object sender, EventArgs e)
        {
            grpDownloads.Visible = chkDowload.Checked;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = fbd.SelectedPath;
            }
        }
    }
}
