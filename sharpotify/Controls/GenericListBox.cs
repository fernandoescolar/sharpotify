using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Sharpotify.Controls
{
    public delegate void ItemMovedHandler(object sender, int sourceIndex, int destIndex);
    public delegate void ItemAddedHandler(object sender, int index);
    public class GenericListBox<T> : ScrollableControl where T : class, IListItem
    {
        private Color selectedBackColor;
        private Color hoverBackColor;
        private int itemHeight;
        private int selectedIndex;
        private int hoverIndex;
        private bool autoDragAndDrop;
        private List<T> items;
        //private List<int> itemsPositions;

        public List<T> Items { get { return items; } }
        public int SelectedIndex { get { return selectedIndex; } set { selectedIndex = value; Invalidate(); } }
        public int HoverIndex { get { return hoverIndex; } }
        public int ItemHeight { get { return itemHeight; } set { itemHeight = value; } }
        public Color SelectedBackColor { get { return selectedBackColor; } set { selectedBackColor = value; } }
        public Color HoverBackColor { get { return hoverBackColor; } set { hoverBackColor = value; } }
        public bool AutoDragAndDrop 
        { 
            get { return autoDragAndDrop; } 
            set 
            { 
                autoDragAndDrop = value;
                if (value)
                {
                    this.AllowDrop = true;
                    this.DragItem += new DrawItemEventHandler(OnDragItem);
                    this.DragDrop += new DragEventHandler(OnDragDrop);
                    this.DragOver += new DragEventHandler(OnDragEvent);
                    this.DragEnter += new DragEventHandler(OnDragEnter);
                    this.DragLeave += new EventHandler(OnDragLeave);
                }
                else
                {
                    this.DragItem -= new DrawItemEventHandler(OnDragItem);
                    this.DragDrop -= new DragEventHandler(OnDragDrop);
                    this.DragOver -= new DragEventHandler(OnDragEvent);
                    this.DragEnter -= new DragEventHandler(OnDragEnter);
                    this.DragLeave -= new EventHandler(OnDragLeave);
                }
            } 
        }

        public event EventHandler SelectedIndexChanged;
        public event DrawItemEventHandler DragItem;
        public event ItemMovedHandler ItemMoved;
        public event ItemAddedHandler ItemAdded;

        public T SelectedItem
        {
            get 
            {
                if (items != null && selectedIndex >= 0 && selectedIndex < items.Count)
                    return items[selectedIndex];
                return null;
            }
            set
            {
                try
                {
                    selectedIndex = items.FindIndex(new Predicate<T>((s) => (s.Id == value.Id)));
                }
                catch { selectedIndex = -1; }
            }
        }

        public GenericListBox() : base()
        {
            this.items = new List<T>();
            this.DoubleBuffered = true;
            this.selectedIndex = -1;
            this.AutoScroll = true;
            this.autoDragAndDrop = false;
            //this.MouseDown += new MouseEventHandler(GenericListBox_MouseDown);
            //this.MouseUp += new MouseEventHandler(GenericListBox_MouseUp);
            this.MouseDown += new MouseEventHandler(GenericListBox_MouseDown);
            this.MouseEnter += new EventHandler(GenericListBox_MouseEnter);
            this.MouseMove += new MouseEventHandler(GenericListBox_MouseMove);
            this.MouseLeave += new EventHandler(GenericListBox_MouseLeave);
            //this.LostFocus += new EventHandler(GenericListBox_LostFocus);
        }

        public void Reset()
        {
            this.AutoScrollPosition = new Point(0, 0);
            this.selectedIndex = -1;
            this.hoverIndex = -1;
        }
      
        void GenericListBox_MouseLeave(object sender, EventArgs e)
        {
            if (hoverIndex != -1)
            {
                hoverIndex = -1;
                Invalidate();
            }
        }

        void GenericListBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = GetVirtualMouseLocation(e);
            int index = GetIndexFromHeight(p.Y);

            if (e.Button == MouseButtons.Left && selectedIndex >= 0 && selectedIndex == index)
            {
                RaiseDragItem(index);
            }

            
            if (p.X <= this.Width - 19)
            {
                if (hoverIndex != index)
                {
                    hoverIndex = index;
                    Invalidate();
                }
            }
            else
            {
                if (hoverIndex != -1)
                {
                    hoverIndex = -1;
                    Invalidate();
                }
            }

            
        }

        void GenericListBox_MouseEnter(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void GenericListBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = GetVirtualMouseLocation(e);
            int index = GetIndexFromHeight(p.Y);
            if (p.X <= this.Width - 19)
            {
                if (selectedIndex != index)
                {
                    selectedIndex = index;
                    if (SelectedIndexChanged != null)
                        SelectedIndexChanged(this, e);
                    Invalidate();
                }
            }
            else
            {
                if (selectedIndex != -1)
                {
                    selectedIndex = -1;
                    Invalidate();
                }
            }

        }

        #region Auto Drag and Drop
        private int startDragIndex;
        private T draggedItem;
        protected void RaiseDragItem(int index)
        {
            if (DragItem != null)
            {
                Graphics g = this.CreateGraphics();
                Rectangle rect = new Rectangle(0, index * itemHeight, this.Width - 19, itemHeight);
                startDragIndex = index;
                items[index].Draw(g, rect.X + 2, rect.Y + 2, rect.Width, itemHeight - 2);
                DrawItemEventArgs args = new DrawItemEventArgs(this.CreateGraphics(), this.Font, rect, index, DrawItemState.Grayed);
                DragItem(this, args);
            }
        }
        protected void OnDragEnter(object sender, DragEventArgs e)
        {
            object data = null;
            string[] formats = e.Data.GetFormats();
            foreach(string f in formats)
            {
                data = e.Data.GetData(f);
                if (data is IListItem)
                    break;
                data = null;
            }

            if (data != null)
            {
                T tli = (data as T);
                draggedItem = tli;
            }
            
        }
        protected void OnDragEvent(object sender, DragEventArgs e)
        {
            object data = null;
            string[] formats = e.Data.GetFormats();
            foreach(string f in formats)
            {
                data = e.Data.GetData(f);
                if (data is IListItem)
                    break;
                data = null;
            }

            if (data == draggedItem)
            {
                T tli = (data as T);
                e.Effect = DragDropEffects.Link;
                this.Items.Remove(tli);
                Point p = this.PointToClient(new Point(e.X, e.Y));
                int index = (p.Y + Math.Abs(AutoScrollPosition.Y)) / this.ItemHeight;
                index = (index >= 0) ? index : 0;
                //System.Console.WriteLine("e.Y = " + p.Y + "; S.Y = " + AutoScrollPosition.Y + "; L.Y = " + this.Location.Y + "; Index = " + index);
                this.Items.Insert(index, tli);
                this.selectedIndex = index;
                this.Invalidate();
            }
        }
        protected void OnDragDrop(object sender, DragEventArgs e)
        {
            object data = null;
            string[] formats = e.Data.GetFormats();
            foreach (string f in formats)
            {
                data = e.Data.GetData(f);
                if (data is IListItem)
                    break;
                data = null;
            }

            if (data == draggedItem)
            {
                T tli = (data as T);
                e.Effect = DragDropEffects.Link;
                this.Items.Remove(tli);
                Point p = this.PointToClient(new Point(e.X, e.Y));
                int index = (p.Y + Math.Abs(AutoScrollPosition.Y)) / this.ItemHeight;
                index = (index >= 0) ? index : 0;
                //System.Console.WriteLine("e.Y = " + p.Y + "; S.Y = " + AutoScrollPosition.Y + "; L.Y = " + this.Location.Y + "; Index = " + index);
                this.Items.Insert(index, tli);
                this.selectedIndex = index;
                this.Invalidate();

                if (startDragIndex >= 0)
                    if (ItemMoved != null)
                        ItemMoved(this, startDragIndex, index);
                else
                    if (ItemAdded != null)
                        ItemAdded(this, index);
            }
        }
        protected void OnDragItem(object sender, DrawItemEventArgs e)
        {
            this.DoDragDrop(this.SelectedItem, DragDropEffects.Link);
            startDragIndex = -1;
            draggedItem = null;
        }
        protected void OnDragLeave(object sender, EventArgs e)
        {
            this.Items.Remove(draggedItem);
            if (startDragIndex >= 0)
                this.Items.Insert(startDragIndex, draggedItem);
            this.selectedIndex = startDragIndex;
            startDragIndex = -1;
            draggedItem = null;
        }
        #endregion


        protected Point GetVirtualMouseLocation(MouseEventArgs e)
        {
            int _zoom = 1;
            System.Drawing.Drawing2D.Matrix mx = new System.Drawing.Drawing2D.Matrix(_zoom, 0, 0, _zoom, 0, 0);
            //pans it according to the scroll bars
            mx.Translate(this.AutoScrollPosition.X * (1.0f / _zoom), this.AutoScrollPosition.Y * (1.0f / _zoom));
            //inverts it
            mx.Invert();

            //uses it to transform the current mouse position
            Point[] pa = new Point[] { new Point(e.X, e.Y) };
            mx.TransformPoints(pa);

            return pa[0];
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //this.Size = new Size(this.Width, itemHeight * tracks.Count);
            base.OnPaint(e);
            Point pt = AutoScrollPosition;
            e.Graphics.TranslateTransform(pt.X, pt.Y);
            if (items == null)
                return;
            int counter = 0;
            for (int i = 0; i < items.Count; i++)
            {
                T item = items[i];
                if (!item.Visible)
                    continue;

                Rectangle rect = new Rectangle(0, itemHeight * counter, this.Width, itemHeight);
                counter++;

                if (!IsItemVisible(i))
                    continue;
                
                item.Parent = this;

                e.Graphics.FillRectangle(new SolidBrush((selectedIndex == i) ? selectedBackColor : (hoverIndex == i) ? hoverBackColor : this.BackColor), rect);
                item.Draw(e.Graphics, rect.X + 2, rect.Y + 2, rect.Width - 19, rect.Height - 2);
                
            }
            AutoScrollMinSize = new Size(this.Width - 20, itemHeight * counter);
        }
        protected bool IsItemVisible(int position)
        { 
            int itemY = (itemHeight * position);
            int viewY = Math.Abs(AutoScrollPosition.Y);
            if ((itemY + itemHeight) >= viewY && itemY <= (viewY + this.Height))
                return true;
            return false;
        }
        protected int GetIndexFromHeight(int height)
        {
            int index = height / itemHeight;
            int counter = 0;
            for (int i = 0; i < items.Count; i++)
            {
                T item = items[i];
                if (item.Visible)
                {
                    if (counter == index)
                    {
                        if (item.IsSelectable)
                            return i;
                        else return -1;
                    }
                    counter++;
                }
            }
            return -1;
        }
        public new void Invalidate()
        {
            if (InvokeRequired)
                base.Invoke(new AnonimousMethod(delegate() { base.Invalidate(); }));
            else
                base.Invalidate();
        }
    }
}
