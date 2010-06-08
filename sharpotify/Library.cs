using System;
using System.IO;
using System.Collections.Generic;

using Sharpotify.Media;

namespace Sharpotify
{
    public class Library
    {
        private const string filename = "library.lib";
        private Dictionary<string, string> songs;
        private Dictionary<string, Track> tracks;

        public IEnumerable<Track> Tracks { get { return tracks.Values; } }

        public Library()
        {
            songs = new Dictionary<string, string>();
            tracks = new Dictionary<string, Track>();
            Reload();
        }
        public bool Contains(Track t)
        {
            return (songs.ContainsKey(t.Id));
        }
        public void Add(Track t, string file)
        {
            if (!string.IsNullOrEmpty(t.Id))
            {
                if (!songs.ContainsKey(t.Id))
                    songs.Add(t.Id, file);
                if (!tracks.ContainsKey(t.Id))
                    tracks.Add(t.Id, t);
            }
        }
        public void Reload()
        {
            Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename));
        }
        protected void Load(string path)
        {
            if (System.IO.File.Exists(path))
            {
                songs.Clear();
                tracks.Clear();

                StreamReader reader = new StreamReader(path);
                while(!reader.EndOfStream)
                {
                    try
                    {
                        string line = reader.ReadLine();
                        if (string.IsNullOrEmpty(line.Trim()))
                            continue;

                        string[] part = line.Split(new string[] { "<%>" }, StringSplitOptions.RemoveEmptyEntries);
                        string key = string.Empty, value = string.Empty;
                        if (part.Length > 0)
                            key = part[0];
                        if (part.Length > 1)
                            value = part[1];

                        if (!string.IsNullOrEmpty(key))
                            songs.Add(key, value);
                    }
                    catch (Exception ex) { }
                }
                reader.Close();

                if (songs.Count > 0)
                {
                    List<string> ids = new List<string>();
                    foreach (string key in songs.Keys)
                        ids.Add(key);

                    List<Track> trks = Facade.Spotify.BrowseTracks(ids);
                    foreach (Track t in trks)
                        tracks.Add(t.Id, t);
                }
                
            }
        }
        public void Save()
        {
            Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename));
        }
        protected void Save(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (KeyValuePair<string, string> kvp in songs)
            {
                string line = kvp.Key + "<%>" + kvp.Value;
                writer.WriteLine(line);
            }
            writer.Close();
        }
    }
}
