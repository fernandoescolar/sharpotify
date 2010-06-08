using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sharpotify.Controls
{
    [Serializable()]
    public class WarpLink
    {
        private string text;
        private string value;

        public string Text { get { return text; } set { text = value; } }
        public string Value { get { return value; } set { this.value = value; } }

        public WarpLink() { }
        public WarpLink(string text) : this() { this.text = text; }
        public WarpLink(string text, string value) : this(text) { this.value = value; }
    }
    public class WarpLinkListPanel : Control
    {
        protected class Word
        {
            public Point Location;
            public SizeF Size;
            public int Index;
            public string Text;
        }
        private string title;
        private int baseHeight = -1;
        private int selectedIndex = -1;
        protected int selectedIndexHover = -1;
        private bool isMouseIn;
        private List<Word> words;
        private List<WarpLink> links;
        public List<WarpLink> Items { get { return links; }}
        public string Title { get { return title; } set { title = value; } }
        public int SelectedIndex { get { return selectedIndex; } set { selectedIndex = value; } }


        public WarpLinkListPanel() : base()
        {
            isMouseIn = false;
            this.DoubleBuffered = true;
            links = new List<WarpLink>();
            this.MouseMove += new MouseEventHandler(WarpLinkListPanel_MouseMove);
            this.MouseDown += new MouseEventHandler(WarpLinkListPanel_MouseDown);
            this.MouseEnter += new EventHandler(WarpLinkListPanel_MouseEnter);
            this.MouseLeave += new EventHandler(WarpLinkListPanel_MouseLeave);
        }

        void WarpLinkListPanel_MouseLeave(object sender, EventArgs e)
        {
            isMouseIn = false;
            selectedIndexHover = -1;
            this.Invalidate();
        }

        void WarpLinkListPanel_MouseEnter(object sender, EventArgs e)
        {
            isMouseIn = true;
            this.Invalidate();
        }

        void WarpLinkListPanel_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < words.Count; i++)
            {
                Word w = words[i];

                if (w.Location.X <= e.X && (w.Location.X + w.Size.Width) >= e.X
                    && w.Location.Y <= e.Y && (w.Location.Y + w.Size.Height) >= e.Y)
                {
                    if (selectedIndex != w.Index)
                    {
                        selectedIndex = w.Index;
                        this.Invalidate();
                    }
                    return;
                }
            }
            if (selectedIndex != -1)
            {
                selectedIndex = -1;
                this.Invalidate();
            }
        }

        private void WarpLinkListPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (words == null)
                return;

            for (int i = 0; i < words.Count; i++)
            { 
                Word w = words[i];

                if (w.Location.X <= e.X && (w.Location.X + w.Size.Width) >= e.X
                    && w.Location.Y <= e.Y && (w.Location.Y + w.Size.Height) >= e.Y)
                {
                    if (selectedIndexHover != w.Index)
                    {
                        this.Cursor = Cursors.Hand;
                        selectedIndexHover = w.Index;
                        this.Invalidate();
                    }
                    return;
                }
            }
            if (selectedIndexHover != -1)
            {
                this.Cursor = Cursors.Arrow;
                selectedIndexHover = -1;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (baseHeight < 0)
                baseHeight = this.Height;

            words = new List<Word>();
            int index = 0;
            int currentX = 0;
            int currentY = 0;
            SizeF spaceSize = e.Graphics.MeasureString(" ", this.Font);
            spaceSize = new SizeF(spaceSize.Width / 2, spaceSize.Height);

            if (!string.IsNullOrEmpty(title))
            {
                Font font = new Font(this.Font, FontStyle.Bold);
                int width = (int)e.Graphics.MeasureString(title, this.Font).Width;
                e.Graphics.DrawString(title, font, new SolidBrush(this.ForeColor), new Point(currentX, currentY));
                currentX += width + (int)font.Size;
            }
            if (links == null)
                return;

            if (links.Count <= 0)
                return;
            foreach (WarpLink w in links)
            {
                string[] tokens = w.Text.Split(new char[] { ' ' });

                foreach (string s in tokens)
                {
                    Word word = new Word();
                    word.Size = e.Graphics.MeasureString(s, this.Font);
                    word.Index = index;
                    word.Text = s;

                    if (currentX + word.Size.Width > this.Width)
                    {
                        currentY += (int)word.Size.Height;
                        currentX = 0;
                    }
                    word.Location = new Point(currentX, currentY);

                    Font font = this.Font;

                    Color c = this.ForeColor;
                    if (selectedIndexHover == index)
                        font = new Font(font, FontStyle.Underline);
                    if (selectedIndex == index)
                        c = Color.Gold;

                    e.Graphics.DrawString(s, font, new SolidBrush(c), new Point(currentX, currentY));
                    currentX += (int)word.Size.Width;
                    //e.Graphics.DrawString(" ", this.Font, new SolidBrush(this.ForeColor), new Point(currentX, currentY));
                    currentX += (int)(spaceSize.Width/4);
                    
                    words.Add(word);
                }
                index++;
                if (index < links.Count)
                {
                    Rectangle rect = new Rectangle(currentX + 2, currentY + 2, 7, 7);
                    e.Graphics.FillPie(new SolidBrush(this.ForeColor), rect, 0.0F, 360.0F);
                    currentX += 10 + (int)spaceSize.Width;
                }
            }
            if (words.Count>0)
                if ((currentY + words[0].Size.Height) > baseHeight)
                {
                    if (isMouseIn)
                    {
                        this.Height = (currentY + (int)words[0].Size.Height);
                        Rectangle rect = new Rectangle(0, 0, this.Width-1, this.Height-1);
                        e.Graphics.DrawRectangle(new Pen(this.ForeColor), rect);
                    }
                    else
                    {
                        this.Height = baseHeight;
                    }
                }
        }
    }
}
