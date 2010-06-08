using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Text;
using System.Windows.Forms;

using Sharpotify.Controls;

namespace Sharpotify.Frames
{
    public partial class SearchControl : UserControl
    {
        private Sharpotify.Media.Result result = null;

        public event SearchResultHandler SearchResult;
        protected event EventHandler EndOfSearch;

        public SearchControl()
        {
            InitializeComponent();
            this.EndOfSearch += new EventHandler(SearchControl_EndOfSearch);
        }

        void SearchControl_EndOfSearch(object sender, EventArgs e)
        {
            this.Invoke(new AnonimousMethod(delegate() {
                this.pictureBox1.Visible = false;
            }));
        }
        public void Search(string query)
        {
            textBox1.Text = query;
            btnSearch_Click(this, new EventArgs());
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object status) {
                RunSearch(textBox1.Text);
            }));
        }
        private void RunSearch(string query)
        {
            result = Facade.Spotify.Search(query);
            if (result != null)
            {
                this.Invoke(new AnonimousMethod(delegate()
                {
                    if (SearchResult != null)
                        SearchResult(result);
                }));
            }
            if (EndOfSearch != null)
                EndOfSearch(this, new EventArgs());
        }
        protected void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSearch_Click(sender, new EventArgs());
            }
        }
    }
}
