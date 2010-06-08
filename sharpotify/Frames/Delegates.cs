using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpotify.Frames
{
    public delegate void SearchResultHandler(Sharpotify.Media.Result result);
    public delegate void BrowseAlbumHandler(Sharpotify.Media.Album album);
    public delegate void BrowseArtistHandler(Sharpotify.Media.Artist artist);
    public delegate void BrowseTrackHandler(Sharpotify.Media.Track track);
    public delegate void SelectSearchHandler(string query);
    
}
