using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sharpotify.Controls
{
    public class ScrollableControl : Control, IComponent, IDisposable
    {
        #region Fields
        private ScrollbarControl vScrollbar, hScrollbar;
        private bool autoScroll;
        private Size scrollSize;
        private Point scrollPosition;
        private int minimumScrollChange = 20;
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the container enables the user to
        /// scroll to any controls placed outside of its visible boundaries.
        /// </summary>
        /// <remarks>
        /// Returns true if the container enables auto-scrolling; otherwise, false. The default
        /// value is false.
        /// </remarks>
        [DefaultValue(false)]
        [Localizable(true)]
        public virtual bool AutoScroll { get { return autoScroll; } set { autoScroll = value; } }
        //
        // Summary:
        //     Gets or sets the minimum size of the auto-scroll.
        //
        // Returns:
        //     A System.Drawing.Size that determines the minimum size of the virtual area
        //     through which the user can scroll.
        [Localizable(true)]
        public Size AutoScrollMinSize { get { return scrollSize; } set { scrollSize = value; } }
        //
        // Summary:
        //     Gets or sets the location of the auto-scroll position.
        //
        // Returns:
        //     A System.Drawing.Point that represents the auto-scroll position in pixels.
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Point AutoScrollPosition { get { return scrollPosition; } set { scrollPosition = value; } }
        [DefaultValue(20)]
        [Localizable(true)]
        public int MinimumScrollChange { get { return minimumScrollChange; } set { minimumScrollChange = value; } }
        #endregion
        #region Factory
        public ScrollableControl()
        {
            this.Cursor = Cursors.Hand;
            this.MouseWheel += new MouseEventHandler(ScrollableControl_MouseWheel);
            this.vScrollbar = new ScrollbarControl();
            this.hScrollbar = new ScrollbarControl();

            this.hScrollbar.Orientation = ScrollbarOrientation.Horizontal;
            this.hScrollbar.Height = 19;

            this.vScrollbar.Scroll += new ScrollEventHandler(vScrollbar_Scroll);
            this.hScrollbar.Scroll += new ScrollEventHandler(hScrollbar_Scroll);

            this.Controls.Add(vScrollbar);
            this.Controls.Add(hScrollbar);
        }
        #endregion
        #region Event Handlers
        void ScrollableControl_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.vScrollbar.Visible)
            {
                int delta = (int)Math.Round((double)(e.Delta / minimumScrollChange), 0);
                int yPosition = 0;
                if (delta > 0)
                {
                    if (delta < vScrollbar.Value)
                        yPosition = -Math.Abs(vScrollbar.Value - delta);
                }
                else
                {
                    yPosition = Math.Abs(delta - vScrollbar.Value);
                    if (yPosition > vScrollbar.Maximum)
                        yPosition = -vScrollbar.Maximum;
                }
                yPosition *= minimumScrollChange;
                scrollPosition = new Point(scrollPosition.X, yPosition);
                Invalidate();
            }
        }
        private void hScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollPosition = new Point(-(hScrollbar.Value * minimumScrollChange), scrollPosition.Y);
            Invalidate();
        }

        private void vScrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            scrollPosition = new Point(scrollPosition.X, - (vScrollbar.Value * minimumScrollChange));
            Invalidate();
        }
        #endregion
        #region Methods
        protected void PrepareControl()
        {
            if (autoScroll)
            {
                hScrollbar.Visible = (scrollSize.Width > this.Width);
                vScrollbar.Visible = (scrollSize.Height > this.Height);

                if (hScrollbar.Visible)
                {
                    hScrollbar.BeginUpdate();
                    hScrollbar.Minimum = 0;
                    hScrollbar.Maximum = ((scrollSize.Width - this.Width) / minimumScrollChange) + 1;
                    vScrollbar.LargeChange = 2;
                    vScrollbar.SmallChange = 1;
                    hScrollbar.Value = Math.Abs(scrollPosition.X / minimumScrollChange);
                    hScrollbar.Location = new Point(0, this.Height - 19);
                    hScrollbar.Size = new Size(this.Width + (vScrollbar.Visible ? -19 : 0), 19);
                    hScrollbar.EndUpdate();
                }
                if (vScrollbar.Visible)
                {
                    vScrollbar.BeginUpdate();
                    vScrollbar.Minimum = 0;
                    vScrollbar.Maximum = ((scrollSize.Height - this.Height) / minimumScrollChange) + 1;
                    vScrollbar.LargeChange = 2;
                    vScrollbar.SmallChange = 1;
                    vScrollbar.Value = Math.Abs(scrollPosition.Y / minimumScrollChange);
                    vScrollbar.Location = new Point(this.Width - 19, 0);
                    vScrollbar.Size = new Size(19, this.Height + (hScrollbar.Visible ? -19 : 0));
                    vScrollbar.EndUpdate();
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            PrepareControl();
            base.OnPaint(e);
        }
        #endregion

    }
}
