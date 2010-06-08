using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class ResultControl : UserControl
    {
        private List<string> artistIds = new List<string>();
        private List<string> albumIds = new List<string>();
        private Result result;

        public Result Result { get { return result; } set { result = value; LoadResult(); } }

        public event SelectSearchHandler SearchQuery;
        public event BrowseArtistHandler BrowseArtist;
        public event BrowseAlbumHandler BrowseAlbum;
        public event BrowseTrackHandler BrowseTrack;
        

        public ResultControl()
        {
            InitializeComponent(); 
            trackList.DoubleClick += new EventHandler(trackList_DoubleClick);
            panelArtists.Click += new EventHandler(Artist_Click);
            panelAlbums.Click += new EventHandler(Album_Click);
            panelSuggestion.Click += new EventHandler(Suggestion_Click);
        }

        protected void trackList_DoubleClick(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }
        protected void LoadResult()
        {
            artistIds.Clear();
            albumIds.Clear();

            panelArtists.Items.Clear();
            panelAlbums.Items.Clear();
            panelSuggestion.Items.Clear();

            trackList.Reset();
            trackList.Items.Clear();

            downloadTrackToolStripMenuItem.Visible = Properties.Settings.Default.AllowDownloads;

            if (result == null)
            {
                return;
            }
            else
            {
                lblTitle.Text = "Search: " + result.Query;
                if (result.Tracks != null)
                    if (result.Tracks.Count > 0)
                        foreach (Track t in result.Tracks)
                        {
                            trackList.Items.Add(new TrackListItem(t));
                            //AddArtist(t.Artist);
                            //AddAlbum(t.Album);
                        }
                
                if (result.Albums != null)
                    if (result.Albums.Count > 0)
                        foreach (Album a in result.Albums)
                            AddAlbum(a);

                if (result.Artists != null)
                    if (result.Artists.Count > 0)
                        foreach (Artist a in result.Artists)
                            AddArtist(a);

                if (!string.IsNullOrEmpty(result.Suggestion))
                {
                    WarpLink w = new WarpLink(result.Suggestion, string.Empty);
                    panelSuggestion.Items.Add(w);

                    panelSuggestion.Visible = true;
                    panelArtists.Location = new Point(3, 61);
                    panelArtists.Size = new Size(296, 111);
                }
                else
                {
                    panelSuggestion.Visible = false;
                    panelArtists.Location = new Point(3, 19);
                    panelArtists.Size = new Size(296, 150);
                }
            }
        }

        void Artist_Click(object sender, EventArgs e)
        {
            if (panelArtists.SelectedIndex >= 0)
            {
                if (BrowseArtist != null)
                {
                    Artist a = new Artist();
                    a.Id = panelArtists.Items[panelArtists.SelectedIndex].Value;
                    BrowseArtist(a);
                }
                panelArtists.SelectedIndex = -1;
            }
        }
        void Album_Click(object sender, EventArgs e)
        {
            if (panelAlbums.SelectedIndex >= 0)
            {
                if (BrowseAlbum != null)
                {
                    Album a = new Album();
                    a.Id = panelAlbums.Items[panelAlbums.SelectedIndex].Value;
                    BrowseAlbum(a);
                }
                panelAlbums.SelectedIndex = -1;
            }
        }
        void Suggestion_Click(object sender, EventArgs e)
        {
            if (panelSuggestion.SelectedIndex >= 0)
            {
                if (SearchQuery != null)
                    SearchQuery(result.Suggestion);

                panelSuggestion.SelectedIndex = -1;
            }
        }
        protected void AddArtist(Artist a)
        {
            if (a != null)
            {
                if (!string.IsNullOrEmpty(a.Id))
                {
                    if (!artistIds.Contains(a.Id))
                    {
                        if (string.IsNullOrEmpty(a.Name))
                            a = Facade.Spotify.Browse(a);

                        WarpLink w = new WarpLink(a.Name, a.Id);
                        panelArtists.Items.Add(w);
                    }
                }
            }
        }

       
        protected void AddAlbum(Album a)
        {
            if (a != null)
            {
                if (!string.IsNullOrEmpty(a.Id))
                {
                    if (!albumIds.Contains(a.Id))
                    {
                        if (string.IsNullOrEmpty(a.Name))
                            a = Facade.Spotify.Browse(a);


                        WarpLink w = new WarpLink(a.Name, a.Id);
                        panelAlbums.Items.Add(w);
                    }
                }
            }
        }

        private void browseTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }

        private void downloadTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                Track t = trackList.SelectedItem.Track;

                if (Facade.CurrentDownloads.Contains(t.Id))
                    return;
                if (Facade.Library.Contains(t))
                    return;

                if (t.Files != null)
                    if (t.Files.Count > 0)
                        Facade.Download(t, t.Files.Count - 1);
            }
        }

        private void playTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                Track t = trackList.SelectedItem.Track;
                Facade.PlayTrack(t);
            }
        }
    }
}
