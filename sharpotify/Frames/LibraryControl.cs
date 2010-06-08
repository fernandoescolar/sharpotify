using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Media;
using Sharpotify.Controls;

namespace Sharpotify.Frames
{
    public partial class LibraryControl : UserControl
    {
        public LibraryControl()
        {
            InitializeComponent();
        }
        public void Reload()
        {
            trackList.Items.Clear();

            foreach (Track t in Facade.Library.Tracks)
                trackList.Items.Add(new TrackListItem(t));
        }

    }
}
