using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Sharpotify.Controls
{
    public class AlbumTrackListBox : GenericListBox<AlbumTrackListItem>
    {
        public AlbumTrackListBox()
        {
            this.BackColor = Color.White;
            this.HoverBackColor = Color.White;
            this.SelectedBackColor = Color.Gold;
            this.ItemHeight = 49;
        }
    }
}
