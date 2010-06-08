using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sharpotify.Forms
{
    public partial class PlaylistNameForm : Form
    {
        public string TextName { get { return textBox1.Text; } }
        public PlaylistNameForm()
        {
            InitializeComponent();
        }

        public PlaylistNameForm(string text) : this()
        {
            textBox1.Text = text;
        }
        public DialogResult ShowForm()
        {
            this.ShowDialog();
            return DialogResult;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextName))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
