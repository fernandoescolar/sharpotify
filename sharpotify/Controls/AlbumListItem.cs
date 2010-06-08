using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;

namespace Sharpotify.Controls
{
    public class AlbumListItem : IListItem
    {
        private Sharpotify.Media.Album album;
        private ScrollableControl parent;
        private Image image;
        private bool haveTriedDownloadImage;
        private bool visibility;

        public Sharpotify.Media.Album Album { get { return album; } set { album = value; LoadImage(); } }
        public ScrollableControl Parent { get { return parent; } set { parent = value; } }
        public Image Image { get { return image; } }
        public string Id { get { return album.Id; } }
        public bool Visible { get { return visibility; } set { visibility = value; } }
        public bool IsSelectable { get { return true; } }


        public AlbumListItem()
        {
            this.album = null;
            this.image = null;
            this.parent = null;
            visibility = true;
        }
        public AlbumListItem(Sharpotify.Media.Album album)  : this()
        {
            this.album = album;
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
            if (album != null)
            { 
                Font font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Brush brush = Brushes.Black;
                g.DrawString(album.Name, font, brush, 55 + x, y);
                font = new Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                brush = Brushes.Gray;
                g.DrawString(album.Type, font, brush, x + 60, y + 15);
                brush = Brushes.DarkGray;
                g.DrawString("#" + album.Year, font, brush, x + 60, y + 30);

                //draw stars
                Image starImg = Properties.Resources.star.GetThumbnailImage(12, 12, null, IntPtr.Zero);
                int popularity = (int)Math.Round(album.Popularity * 5, 0);
                for (int i = 1; i < popularity; i++)
                {
                    g.DrawImage(starImg, (int)(x + w - ((14 * i) + 2)), y + 2, 12, 12);
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
                if (album != null)
                    if (!string.IsNullOrEmpty(album.Cover))
                        image = Facade.Spotify.Image(album.Cover);
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
