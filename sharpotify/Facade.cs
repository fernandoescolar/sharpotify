using System;
using System.Collections.Generic;
using System.Linq;

using Sharpotify;
using Sharpotify.Media;

namespace Sharpotify
{
    public delegate void DownloadHandler(Track t, int index);
    public delegate void PlayListHandler(List<Track> tracks, bool random);
    public class Facade
    {
        #region Fields
        private static ISpotify connection;
        private static User userInfo;
        private static List<Playlist> playlists;
        private static Library lib;
        private static List<string> currentDownloads;
        private static Track playingTrack;
        #endregion
        #region Events
        public static event EventHandler LoggedIn;
        public static event EventHandler Closed;
        public static event EventHandler RefreshMenu;
        public static event DownloadHandler DownloadItem;
        public static event DownloadHandler ItemDownloaded;
        public static event DownloadHandler PlayTrackRequest;
        public static event PlayListHandler PlayListTracksRequest;
        #endregion
        #region Properties
        public static ISpotify Spotify { get { return connection; } }
        public static User User { get { return userInfo; } }
        public static List<Playlist> Playlists { get { return playlists; } }
        public static Library Library { get { return lib; } }
        public static List<string> CurrentDownloads { get { return currentDownloads; } }
        public static Track PlayingTrack { get { return playingTrack; } set { playingTrack = value; } }
        #endregion
        #region Methods
        public static void Init()
        {
            SpotifyPool.MaxConnections = Properties.Settings.Default.ConnectionsNumber;
            connection = SpotifyPool.Instance;
            playlists = new List<Playlist>();
            currentDownloads = new List<string>();
        }
        public static bool Login(string user, string password)
        {
            try
            {
                try
                {
                    connection.Login(user, password);
                }
                catch (Sharpotify.Exceptions.AuthenticationException ex)
                {
                    throw new Exception("Unable to login: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Unspected Exception: " + ex.Message);
                }

                userInfo = connection.User();
                ReloadPlaylists();
                
                lib = new Library();

                if (LoggedIn != null)
                    LoggedIn(connection, new EventArgs());

                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Error loging in...", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                connection.Close();
                return false;
            }
        }
        public static void Download(Track t, int index)
        {
            if (Properties.Settings.Default.AllowDownloads)
            {
                if (!currentDownloads.Contains(t.Id))
                {
                    currentDownloads.Add(t.Id);
                    if (DownloadItem != null)
                        DownloadItem(t, index);
                }
            }
        }
        public static void Downloaded(Track t)
        {
            currentDownloads.Remove(t.Id);
            if (ItemDownloaded != null)
                ItemDownloaded(t, 0);
        }
        public static void ReloadPlaylists()
        {
            playlists.Clear();
            PlaylistContainer temp = connection.PlaylistContainer();
            foreach (Playlist pl in temp.Playlists)
            {
                try
                {
                    Playlist newPL = connection.Playlist(pl.Id);
                    playlists.Add(newPL);
                }
                catch { }
            }
        }
        public static void RefreshMainMenu()
        {
            if (RefreshMenu != null)
                RefreshMenu(Spotify, new EventArgs());
        }
        public static void PlayTrack(Track t)
        {
            if (PlayTrackRequest != null)
                PlayTrackRequest(t, 0);
        }
        public static void PlayListTracks(List<Track> t, bool random)
        {
            if (PlayListTracksRequest != null)
                PlayListTracksRequest(t, random);
        }
        public static void Close()
        {
            if (lib != null)
                lib.Save();

            if (connection != null)
                connection.Close();

            if (Closed != null)
                Closed(connection, new EventArgs());
        }
        #endregion
    }
}
