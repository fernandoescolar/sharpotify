using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;
using Sharpotify.Forms;
using Sharpotify.Media;

namespace Sharpotify.Frames
{
    public partial class PlaylistControl : UserControl
    {
        private Playlist playlist;
        private List<Track> tracks;

        public Playlist Playlist { get { return playlist; } set { playlist = value; LoadData(); } }

        public event BrowseTrackHandler BrowseTrack;

        public PlaylistControl()
        {
            InitializeComponent();
            trackList.AutoDragAndDrop = true;
            trackList.DoubleClick += new EventHandler(trackList_DoubleClick);
            trackList.ItemMoved += new ItemMovedHandler(trackList_ItemMoved);
            
        }

        protected void trackList_ItemMoved(object sender, int sourceIndex, int destIndex)
        {
            if (sourceIndex < destIndex)
                destIndex++;
            Facade.Spotify.PlaylistMoveTrack(playlist, sourceIndex, destIndex);
            Facade.ReloadPlaylists();
            foreach (Playlist p in Facade.Playlists)
                if (p.Id == playlist.Id)
                    Playlist = p;
        }

        protected void trackList_DoubleClick(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }

        protected void LoadData()
        {
            trackList.Reset();
            trackList.Items.Clear();

            if (playlist != null)
            {
                lblTitle.Text = "Playlist: " + playlist.Name;
                List<string> ids = new List<string>();
                foreach (Track t in playlist.Tracks)
                        ids.Add(t.Id);
                if (ids.Count > 0)
                {
                    tracks = Facade.Spotify.BrowseTracks(ids);
                    foreach (Track t in tracks)
                        trackList.Items.Add(new TrackListItem(t));
                }
            }
            downloadTrackToolStripMenuItem.Visible = Properties.Settings.Default.AllowDownloads;
            btnDownload.Visible = Properties.Settings.Default.AllowDownloads;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this playlist?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PlaylistContainer pContainer = Facade.Spotify.PlaylistContainer();
                int position = -1;
                for (int i=0; i< pContainer.Playlists.Count; i++)
                {
                    if (playlist.Id == pContainer.Playlists[i].Id)
                    {
                        position = i;
                        break;
                    }
                }
                if (position >= 0)
                {
                    Facade.Spotify.PlaylistContainerRemovePlaylist(pContainer, position);
                    Facade.Spotify.PlaylistDestroy(playlist);
                    Facade.ReloadPlaylists();
                    Facade.RefreshMainMenu();
                    this.Hide();
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

        private void deleteTrackFromPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this song from the playlist?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int position = -1;
                    for (int i = 0; i < playlist.Tracks.Count; i++)
                        if (trackList.SelectedItem.Track.Id == playlist.Tracks[i].Id)
                        {
                            position = i;
                            break;
                        }
                    if (position >= 0)
                    {
                        if (Facade.Spotify.PlaylistRemoveTrack(playlist, position))
                        {
                            Facade.ReloadPlaylists();
                            foreach (Playlist p in Facade.Playlists)
                                if (p.Id == playlist.Id)
                                {
                                    Playlist = p;
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            PlaylistNameForm f = new PlaylistNameForm(playlist.Name);
            if (f.ShowForm() == DialogResult.OK)
            {
                Facade.Spotify.PlaylistRename(playlist, f.TextName);
                Facade.ReloadPlaylists();
                Facade.RefreshMainMenu();
                lblTitle.Text = f.TextName;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Facade.PlayListTracks(tracks, false);
        }

        private void playPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.PlayListTracks(tracks, false);
        }

        private void playInRandomModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facade.PlayListTracks(tracks, true);
        }

        private void downloadTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                Track t = trackList.SelectedItem.Track;
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            foreach (Track t in tracks)
            {
                if (Facade.CurrentDownloads.Contains(t.Id))
                    continue;
                if (Facade.Library.Contains(t))
                    continue;

                if (t.Files != null)
                    if (t.Files.Count > 0)
                        Facade.Download(t, t.Files.Count - 1);
            }
        }
    }
}
