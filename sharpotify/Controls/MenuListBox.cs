using System;
using System.Collections.Generic;
using System.Drawing;

namespace Sharpotify.Controls
{
    public class MenuListBox : GenericListBox<MenuListItem>
    {
        public MenuListBox()
        {
            this.BackColor = SystemColors.Control;
            this.SelectedBackColor = SystemColors.Control;
            this.HoverBackColor = Color.DarkGray;
            this.ItemHeight = 20;
        }
    }
}
