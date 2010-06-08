using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Sharpotify.Controls
{
    public class MenuListItem : IListItem
    {
        private ScrollableControl parent;
        private Image image;
        private string id, text;
        private bool visibility;

        public ScrollableControl Parent { get { return parent; } set { parent = value; } }
        public Image Image { get { return image; } set { image = value; } }
        public string Id { get { return id; } set { id = value; } }
        public string Text { get { return text; } set { text = value; } }
        public bool Visible { get { return visibility; } set { visibility = value; } }
        public bool IsSelectable { get { return (text != "-"); } }

        public MenuListItem() { }
        public MenuListItem(string text, string id) 
        {
            this.text = text;
            this.id = id;
            visibility = true;
        }

        public virtual void Draw(Graphics g, int x, int y, int w, int h)
        {
            if (text == "-")
            {
                int centerH = h / 2;
                g.DrawLine(Pens.Black, x, y + centerH, x + w, y + centerH);
                return;
            }
           
            if (image != null)
            {
                Image thumbnail = image.GetThumbnailImage(16, 16, null, IntPtr.Zero);
                g.DrawImage(thumbnail, x, y, 16, 16);
            }
            Font font = new Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Brush brush = Brushes.Black;
            g.DrawString(text, font, brush, 21 + x, y);
        }
    }
}
