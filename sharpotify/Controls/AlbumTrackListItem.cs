using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Sharpotify.Controls
{
    public class AlbumTrackListItem : IListItem
    {
        private Sharpotify.Media.Track track;
        private ScrollableControl parent;
        private bool visibility;
        public int disc;

        public Sharpotify.Media.Track Track { get { return track; } set { track = value; } }
        public ScrollableControl Parent { get { return parent; } set { parent = value; } }
        public string Id { get { return track.Id; } }
        public bool Visible { get { return visibility; } set { visibility = value; } }
        public bool IsSelectable { get { return true; } }
        public int Disc { get { return disc; } set { disc = value; } }


        public AlbumTrackListItem()
        {
            this.track = null;
            this.parent = null;
            this.visibility = true;
            this.disc = 0;
        }
        public AlbumTrackListItem(Sharpotify.Media.Track track, int disc) : this()
        {
            this.track = track;
            this.disc = disc;
        }

        public virtual void Draw(Graphics g, int x, int y, int w, int h)
        {
            if (track != null)
            { 
                Font font = new Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                Brush brush = Brushes.Black;
                g.DrawString(track.Title, font, brush, x, y);
                font = new Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                brush = Brushes.Gray;
                g.DrawString("#" + track.TrackNumber.ToString("00") + "", font, brush, x + 2, y + 15);
                brush = Brushes.DarkGray;
                g.DrawString("Disc " + disc, font, brush, x + 2, y + 30);

                //draw stars
                Image starImg = Properties.Resources.star.GetThumbnailImage(12, 12, null, IntPtr.Zero);
                int popularity = (int)Math.Round(track.Popularity * 5, 0);
                for (int i = 1; i < popularity; i++)
                {
                    g.DrawImage(starImg, (int)(x + w - ((14 * i) + 2)), y + 2, 12, 12);
                }
            }
        }
    }
}
