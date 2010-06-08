using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class ArtistControl : UserControl
    {
        private int loadImageTries = 0;
        private Artist artist;

        public Artist Artist { get { return artist; } set { artist = value; LoadArtist(); } }

        public event BrowseAlbumHandler BrowseAlbum;
        public event BrowseArtistHandler BrowseArtist;

        public ArtistControl()
        {
            InitializeComponent();
            albumList.DoubleClick += new EventHandler(albumList_DoubleClick);
            lblArtist.Click += new EventHandler(lblArtist_Click);
        }

        void lblArtist_Click(object sender, EventArgs e)
        {
            if (lblArtist.SelectedIndex >= 0)
            {
                if (BrowseArtist != null)
                {
                    Artist a = new Artist();
                    a.Id = lblArtist.Items[lblArtist.SelectedIndex].Value;
                    BrowseArtist(a);
                }
                lblArtist.SelectedIndex = -1;
            }
        }

        void albumList_DoubleClick(object sender, EventArgs e)
        {
            if (albumList.SelectedIndex >= 0)
            {
                if (BrowseAlbum != null)
                    BrowseAlbum(albumList.SelectedItem.Album);
            }
        }
        protected void LoadArtist()
        {
            this.image.Image = null;
            albumList.Reset();
            lblArtist.Items.Clear();
            albumList.Items.Clear();

            lblArtist.Visible = false;

            if (artist == null)
                return;

            lblName.Text = artist.Name;

            if (artist.SimilarArtists !=null)
                if (artist.SimilarArtists.Count > 0)
                { 
                    foreach(Artist a in artist.SimilarArtists)
                        lblArtist.Items.Add(new WarpLink(a.Name, a.Id));

                    lblArtist.Visible = true;
                }

            if (artist.Bios != null)
                if (artist.Bios.Count > 0)
                {
                    txtBio.Text = "";
                    foreach (Biography b in artist.Bios)
                        txtBio.Text += RemoveHTML(b.Text);
                }

            if (artist.Albums != null)
                if (artist.Albums.Count > 0)
                    foreach (Album a in artist.Albums)
                        albumList.Items.Add(new AlbumListItem(a));
            LoadImage();
        }
        public string RemoveHTML(string strSource)
        {
            if (string.IsNullOrEmpty(strSource))
                return string.Empty;
            //Here strSource is string containing HTML Code
            return System.Web.HttpUtility.HtmlDecode(System.Text.RegularExpressions.Regex.Replace(strSource, "<(.|\n)*?>", ""));
        }
        private void LoadImage()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.LoadImageRun));
        }

        private void LoadImageRun(object stateInfo)
        {
            try
            {
                if (artist != null)
                    if (!string.IsNullOrEmpty(artist.Portrait))
                    {
                        Image img = Facade.Spotify.Image(artist.Portrait);
                        image.Invoke(new AnonimousMethod(delegate()
                        {
                            image.Image = img;
                        }));
                    }
            }
            catch
            {
                loadImageTries++;
                if (loadImageTries <= 3)
                    LoadImageRun(stateInfo);
            }
        }
    }
}
