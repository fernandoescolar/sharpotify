using System;
using System.Drawing;

namespace Sharpotify.Controls
{
    public interface IListItem
    {
        string Id { get; }
        ScrollableControl Parent { get; set; }
        bool Visible { get; set; }
        bool IsSelectable { get; }
        void Draw(Graphics g, int c, int y, int width, int height);
    }
}
