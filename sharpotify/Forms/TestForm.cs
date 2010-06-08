using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;

namespace Sharpotify.Forms
{
    public partial class TestForm : Form
    {
        private int menuSearchIndex;
        private int menuArtistIndex;
        private int menuAlbumIndex;
        private int menuTrackIndex;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            for (int i=0; i < 20; i++)
            {
                Sharpotify.Controls.DownloadTrackListItem item = new Sharpotify.Controls.DownloadTrackListItem();
                Sharpotify.Media.Track track = new Sharpotify.Media.Track();
                track.Cover = null;
                track.Title = "Track " + i.ToString("00");
                track.Artist = new Sharpotify.Media.Artist();
                track.Artist.Name = "Artist" + i.ToString("00");
                track.Album = new Sharpotify.Media.Album();
                track.Album.Name = "Album" + i.ToString("00");
                track.Popularity = (float)((float)rnd.Next(0, 10) / 10);

                item.Track = track;
                trackListBox1.Items.Add(item);

                Sharpotify.Controls.WarpLink wl = new Sharpotify.Controls.WarpLink("Name of one if the Albums relate with the search " + i.ToString("00"), null);
                warpLinkListPanel1.Items.Add(wl);
            }
            trackListBox1.AllowDrop = true;
            trackListBox1.AutoDragAndDrop = true;
            CreateMainMenu();
        }

        protected void CreateMainMenu()
        {
            MenuListItem m0 = new MenuListItem("Start", "start");
            m0.Image = Properties.Resources.star;

            MenuListItem m1 = new MenuListItem("Search", "search");
            m1.Image = Properties.Resources.searchFolder;
            m1.Visible = false;

            MenuListItem m2 = new MenuListItem("Downloads", "download");
            m2.Image = Properties.Resources.searchFolder;
            m2.Visible = false;

            MenuListItem ms1 = new MenuListItem("-", "-");

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

            mainMenu.Items.AddRange(new MenuListItem[] { m0, m1, m2, ms1, m3, m4, m5, ms2 });

            //foreach (Playlist p in Facade.Playlists)
            //{
            //    MenuListItem mp = new MenuListItem(p.Name, p.Id);
            //    mp.Image = Properties.Resources.playlist;
            //    mainMenu.Items.Add(mp);
            //}

            menuSearchIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m1.Id)));
            menuArtistIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m3.Id)));
            menuAlbumIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m4.Id)));
            menuTrackIndex = mainMenu.Items.FindIndex(new Predicate<MenuListItem>((s) => (s.Id == m5.Id)));

            mainMenu.SelectedIndexChanged += new EventHandler(mainMenu_SelectedIndexChanged);
        }

        protected void mainMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainMenu.SelectedIndex >= 0)
            {
                Control c = null;
                switch (mainMenu.SelectedItem.Id)
                {
                    case "start":
                        c = new Control();
                        break;
                    case "search":
                        c = new Control();
                        break;
                    case "download":
                        c = new Control();
                        break;
                    case "artist":
                        c = new Control();
                        break;
                    case "album":
                        c = new Control();
                        break;
                    case "track":
                        c = new Control();
                        break;
                    default:
                        
                        break;
                }
                if (c != null)
                {
                    mainMenu.SelectedIndex = -1;
                }
            }
        }
    }
}
