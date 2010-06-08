using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace Sharpotify.Controls
{
    public class TrackListItem : IListItem
    {
        private Sharpotify.Media.Track track;
        private ScrollableControl parent;
        private Image image;
        private bool haveTriedDownloadImage;
        private bool visibility;

        public Sharpotify.Media.Track Track { get { return track; } set { track = value; LoadImage(); } }
        public ScrollableControl Parent { get { return parent; } set { parent = value; } }
        public Image Image { get { return image; } }
        public string Id { get { return track.Id; } }
        public bool Visible { get { return visibility; } set { visibility = value; } }
        public bool IsSelectable { get { return true; } }


        public TrackListItem()
        {
            this.track = null;
            this.image = null;
            this.parent = null;
            visibility = true;
        }
        public TrackListItem(Sharpotify.Media.Track track) : this()
        {
            this.track = track;
            haveTriedDownloadImage = false;
        }

        public virtual void Draw(Graphics g, int x, int y, int w, int h)
        {
            if (!haveTriedDownloadImage && image == null)
                LoadImage();
            if (image != null)
            {
                Image thumbnail = image.GetThumbnailImage(50, 50, null, IntPtr.Zero);
                g.DrawImage(thumbnail, x, y, 50, 50);
            }
            if (track != null)
            { 
                Font font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Brush brush = Brushes.Black;
                g.DrawString(track.Title, font, brush, 55 + x, y);
                font = new Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                brush = Brushes.Gray;
                g.DrawString(track.Artist.Name, font, brush, x + 60, y + 15);
                brush = Brushes.DarkGray;
                g.DrawString(track.Album.Name, font, brush, x + 60, y + 30);

                //draw stars
                Image starImg = Properties.Resources.star.GetThumbnailImage(12, 12, null, IntPtr.Zero);
                int popularity = (int)Math.Round(track.Popularity * 5, 0);
                for (int i = 1; i < popularity; i++)
                {
                    g.DrawImage(starImg, (int)(x + w - ((14 * i) + 2)), y + 2, 12, 12);
                }
                if (Facade.Library != null)
                    if (Facade.Library.Contains(track))
                    {
                        starImg = Properties.Resources.saved.GetThumbnailImage(12, 12, null, IntPtr.Zero);
                        g.DrawImage(starImg, (int)(x + w - ((14 * 6) + 2)), y + 2, 12, 12);
                    }
                if (Facade.CurrentDownloads != null)
                    if (Facade.CurrentDownloads.Contains(track.Id))
                    {
                        starImg = Properties.Resources.download.GetThumbnailImage(12, 12, null, IntPtr.Zero);
                        g.DrawImage(starImg, (int)(x + w - ((14 * 6) + 2)), y + 2, 12, 12);
                    }
                if (Facade.PlayingTrack != null)
                    if (Facade.PlayingTrack.Id == track.Id)
                    {
                        starImg = Properties.Resources.Speaker.GetThumbnailImage(14, 14, null, IntPtr.Zero);
                        g.DrawImage(starImg, (int)(x + w - ((14 * 7) + 1)), y + 1, 14, 14);
                    }
            }
        }
        private void LoadImage()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.LoadImageRun));
        }
        private void LoadImageRun(object stateInfo)
        {
            try
            {
                haveTriedDownloadImage = true;
                if (track != null)
                    if (!string.IsNullOrEmpty(track.Cover))
                        image = Facade.Spotify.Image(track.Cover);
                if (image != null && parent != null)
                    parent.Invalidate();
            }
            catch 
            {
                image = null;
                haveTriedDownloadImage = false;
            }
        }
    }
}
