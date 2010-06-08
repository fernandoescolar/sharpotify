using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;

using Sharpotify;
using Sharpotify.Cache;
using Sharpotify.Media;
using Sharpotify.Frames;
using Sharpotify.Forms;

namespace Sharpotify
{
    public partial class MainForm : Form
    {
        private int menuSearchIndex;
        private int menuArtistIndex;
        private int menuAlbumIndex;
        private int menuTrackIndex;

        private bool canClose;
        private ResultControl resultControl;
        private TopListControl topListControl;
        private PlaylistControl playlistControl;
        private DownloadControl downloadControl;
        private TrackControl trackControl;
        private AlbumControl albumControl;
        private ArtistControl artistControl;
        private ConfigControl configControl;
        private LibraryControl libraryControl;

        public MainForm()
        {
            InitializeComponent();

            LoadSettings();

            resultControl = new ResultControl();
            topListControl = new TopListControl();
            playlistControl = new PlaylistControl();
            downloadControl = new DownloadControl();
            trackControl = new TrackControl();
            albumControl = new AlbumControl();
            artistControl = new ArtistControl();
            configControl = new ConfigControl();
            libraryControl = new LibraryControl();

            resultControl.Dock = DockStyle.Fill;
            topListControl.Dock = DockStyle.Fill;
            playlistControl.Dock = DockStyle.Fill;
            downloadControl.Dock = DockStyle.Fill;
            trackControl.Dock = DockStyle.Fill;
            albumControl.Dock = DockStyle.Fill;
            artistControl.Dock = DockStyle.Fill;
            configControl.Dock = DockStyle.Fill;
            libraryControl.Dock = DockStyle.Fill;

            canClose = false;

            Facade.Closed += new EventHandler(Facade_Closed);
            Facade.DownloadItem += new DownloadHandler(Facade_DownloadItem);
            Facade.ItemDownloaded += new DownloadHandler(Facade_ItemDownloaded);
            Facade.RefreshMenu += new EventHandler(Facade_RefreshMenu);

            searchControl1.SearchResult += new Sharpotify.Frames.SearchResultHandler(searchControl1_SearchResult);
            
            resultControl.SearchQuery += new SelectSearchHandler(resultControl_SearchQuery);
            
            resultControl.BrowseTrack += new BrowseTrackHandler(OnBrowseTrack);
            playlistControl.BrowseTrack += new BrowseTrackHandler(OnBrowseTrack);
            topListControl.BrowseTrack += new BrowseTrackHandler(OnBrowseTrack);
            albumControl.BrowseTrack += new BrowseTrackHandler(OnBrowseTrack);

            resultControl.BrowseAlbum += new BrowseAlbumHandler(OnBrowseAlbum);
            trackControl.BrowseAlbum += new BrowseAlbumHandler(OnBrowseAlbum);
            albumControl.BrowseAlbum += new BrowseAlbumHandler(OnBrowseAlbum);
            artistControl.BrowseAlbum += new BrowseAlbumHandler(OnBrowseAlbum);

            resultControl.BrowseArtist += new BrowseArtistHandler(OnBrowseArtist);
            trackControl.BrowseArtist += new BrowseArtistHandler(OnBrowseArtist);
            albumControl.BrowseArtist += new BrowseArtistHandler(OnBrowseArtist);
            artistControl.BrowseArtist += new BrowseArtistHandler(OnBrowseArtist);
        }

        protected void Facade_RefreshMenu(object sender, EventArgs e)
        {
            CreateMainMenu();
        }

        protected void Facade_ItemDownloaded(Track t, int index)
        {
            libraryControl.Reload();
        }

        protected void CreateMainMenu()
        {
            mainMenu.Items.Clear();

            MenuListItem m0 = new MenuListItem("Start", "start");
            m0.Image = Properties.Resources.star;

            MenuListItem m2 = new MenuListItem("Downloads", "download");
            m2.Image = Properties.Resources.download;

            MenuListItem m21 = new MenuListItem("Library", "library");
            m21.Image = Properties.Resources.folder;

            MenuListItem m22 = new MenuListItem("Configuration", "config");
            m22.Image = Properties.Resources.configuration;

            MenuListItem m23 = new MenuListItem("Exit", "exit");
            m23.Image = Properties.Resources.exit;


            MenuListItem ms1 = new MenuListItem("-", "-");

            MenuListItem m1 = new MenuListItem("Search", "search");
            m1.Image = Properties.Resources.searchFolder;
            m1.Visible = false;

            MenuListItem m3 = new MenuListItem("Artist", "artist");
            m3.Image = Properties.Resources.author;
            m3.Visible = false;

            MenuListItem m4 = new MenuListItem("Album", "album");
            m4.Image = Properties.Resources.album;
            m4.Visible = false;

            MenuListItem m5 = new MenuListItem("Track", "track");
            m5.Image = Properties.Resources.track;
            m5.Visible = false;

            MenuListItem ms2 = new MenuListItem("-", "-");

            if (Properties.Settings.Default.AllowDownloads)
                mainMenu.Items.AddRange(new MenuListItem[] { m0, m2, m21, m22, m23, ms1, m1, m3, m4, m5, ms2 });
            else
                mainMenu.Items.AddRange(new MenuListItem[] { m0, m22, m23, ms1, m1, m3, m4, m5, ms2 });

            foreach (Playlist p in Facade.Playlists)
            { 
                MenuListItem mp = new MenuListItem(p.Name, p.Id);
                mp.Image = Properties.Resources.playlist;
                mainMenu.Items.Add(mp);
            }

            MenuListItem mAdd = new MenuListItem("Add new playlist", "addnew");
            mAdd.Image = Properties.Resources.add;
            mainMenu.Items.Add(mAdd);

            menuSearchIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m1.Id)));
            menuArtistIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m3.Id)));
            menuAlbumIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m4.Id)));
            menuTrackIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m5.Id)));

            mainMenu.SelectedIndexChanged += new EventHandler(mainMenu_SelectedIndexChanged);

            mainMenu.Invalidate();
        }

        protected void mainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainMenu.SelectedIndex >= 0)
            {
                Control c = null;
                switch (mainMenu.SelectedItem.Id)
                { 
                    case "start":
                        c = topListControl;
                        break;
                    case "config":
                        c = configControl;
                        break;
                    case "library":
                        c = libraryControl;
                        break;
                    case "exit":
                        this.Close();
                        return;
                    case "search":
                        c = resultControl;
                        break;
                    case "download":
                        c = downloadControl;
                        break;
                    case "artist":
                        c = artistControl;
                        break;
                    case "album":
                        c = albumControl;
                        break;
                    case "track":
                        c = trackControl;
                        break;
                    case "addnew":
                        PlaylistNameForm f = new PlaylistNameForm();
                        if (f.ShowForm() == System.Windows.Forms.DialogResult.OK)
                        {
                            Playlist p = Facade.Spotify.PlaylistCreate(f.TextName);
                            PlaylistContainer pContainer = Facade.Spotify.PlaylistContainer();
                            Facade.Spotify.PlaylistContainerAddPlaylist(pContainer, p);
                            Facade.ReloadPlaylists();
                            CreateMainMenu();
                        }
                        break;
                    default:
                        foreach (Playlist p in Facade.Playlists)
                            if (p.Id == mainMenu.SelectedItem.Id)
                            {
                                playlistControl.Playlist = p;
                                c = playlistControl;
                            }
                        break;
                }
                if (c != null)
                {
                    PanelContainer.Controls.Clear();
                    PanelContainer.Controls.Add(c);
                    c.Show();
                }
                mainMenu.SelectedIndex = -1;
            }
        }

        protected void resultControl_SearchQuery(string query)
        {
            searchControl1.Search(query);
        }

        protected void OnBrowseTrack(Track track)
        {
            mainMenu.Items[menuTrackIndex].Text = "Track: " + track.Title;
            mainMenu.Items[menuTrackIndex].Visible = true;
            mainMenu.Invalidate();

            trackControl.Track = track;
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(trackControl);
        }
        protected void OnBrowseAlbum(Album album)
        {
            if (string.IsNullOrEmpty(album.Name))
                album = Facade.Spotify.BrowseAlbum(album.Id);

            if (album == null)
            {
                MessageBox.Show("Album not found!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mainMenu.Items[menuAlbumIndex].Text = "Album: " + album.Name;
                mainMenu.Items[menuAlbumIndex].Visible = true;
                mainMenu.Invalidate();

                albumControl.Album = album;
                PanelContainer.Controls.Clear();
                PanelContainer.Controls.Add(albumControl);
            }
        }
        protected void OnBrowseArtist(Artist artist)
        {
            if (string.IsNullOrEmpty(artist.Name))
                artist = Facade.Spotify.BrowseArtist(artist.Id);

            if (artist == null)
            {
                MessageBox.Show("Artist not found!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                mainMenu.Items[menuArtistIndex].Text = "Artist: " + artist.Name;
                mainMenu.Items[menuArtistIndex].Visible = true;
                mainMenu.Invalidate();

                artistControl.Artist = artist;
                PanelContainer.Controls.Clear();
                PanelContainer.Controls.Add(artistControl);
            }
        }

        private void Facade_DownloadItem(Track t, int index)
        {
            downloadControl.AddTrack(t, index);
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(downloadControl);
        }

        private void searchControl1_SearchResult(Result result)
        {
            mainMenu.Items[menuSearchIndex].Text = "Search: " + result.Query;
            mainMenu.Items[menuSearchIndex].Visible = true;
            mainMenu.Invalidate();

            resultControl.Result = result;
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(resultControl);
        }

        private void Facade_Closed(object sender, EventArgs e)
        {
            canClose = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateMainMenu();
            PanelContainer.Controls.Clear();
            PanelContainer.Controls.Add(topListControl);
            libraryControl.Reload();
            downloadControl.Load();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            downloadControl.Dispose();
            playerControl.Dispose();
            Facade.Close();
            SaveSettings();
            while (!canClose) { }
            base.OnClosing(e);
        }

        protected override void OnResize(EventArgs e)
        {
            foreach (Control c in this.Controls)
                c.Refresh();
            base.OnResize(e);
        }

        protected void SaveSettings()
        {
            Properties.Settings.Default.WindowPosition = this.Location;
            Properties.Settings.Default.WindowSize = this.Size;
            Properties.Settings.Default.WindowState = this.WindowState;
            Properties.Settings.Default.Save();
        }
        protected void LoadSettings()
        {
            this.Location = Properties.Settings.Default.WindowPosition;
            this.Size = Properties.Settings.Default.WindowSize;
            this.WindowState = Properties.Settings.Default.WindowState;
        }
    }
}
