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
    public partial class TopListControl : UserControl
    {
        public event BrowseTrackHandler BrowseTrack;

        public TopListControl()
        {
            InitializeComponent();
            trackList.DoubleClick += new EventHandler(trackList_DoubleClick);
        }

        protected void trackList_DoubleClick(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex >= 0)
            {
                if (BrowseTrack != null)
                    BrowseTrack(trackList.SelectedItem.Track);
            }
        }

        private void TopListControl_Load(object sender, EventArgs e)
        {
            trackList.Reset();
            trackList.Items.Clear();
            downloadTrackToolStripMenuItem.Visible = Properties.Settings.Default.AllowDownloads;

            List<Track> tracks = Facade.Spotify.Toplist(Sharpotify.Enums.ToplistType.TRACK, Facade.User.Country, Facade.User.Name).Tracks;
            foreach (Track t in tracks)
                trackList.Items.Add(new TrackListItem(t));
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
