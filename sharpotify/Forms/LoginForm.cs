using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace Sharpotify.Forms
{
    public partial class LoginForm : Form
    {
        bool canClose;
        private string user, password;
        protected event EventHandler onLoggedIn;
        protected event EventHandler onFail;

        public LoginForm()
        {
            InitializeComponent();
            canClose = false;
            Facade.LoggedIn += new EventHandler(Facade_LoggedIn);
            Facade.Closed += new EventHandler(Facade_Closed);

            this.onLoggedIn += new EventHandler(LoginForm_onLoggedIn);
            this.onFail += new EventHandler(LoginForm_onFail);

            Program.Exit = true;
        }

        void LoginForm_onFail(object sender, EventArgs e)
        {
            this.Invoke(new Controls.AnonimousMethod(delegate() {
                this.txtUser.Enabled = true;
                this.txtPassword.Enabled = true;
                this.btnLogin.Enabled = true;
                this.btnClose.Enabled = true;
                this.panelLoading.Visible = false;
            }));
        }

        void LoginForm_onLoggedIn(object sender, EventArgs e)
        {
            this.Invoke(new Controls.AnonimousMethod(delegate()
            {
                Program.Exit = false;
                this.Close();
            }));
        }

        private void Facade_Closed(object sender, EventArgs e)
        {
            canClose = true;
        }

        private void Facade_LoggedIn(object sender, EventArgs e)
        {
            if (onLoggedIn != null)
                onLoggedIn(this, new EventArgs());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnLogin.Enabled = false;
            this.btnClose.Enabled = false;

            Facade.Close();
            while (!canClose) { }
            
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.txtUser.Enabled = false;
            this.txtPassword.Enabled = false;
            this.btnLogin.Enabled = false;
            this.btnClose.Enabled = false;
            this.panelLoading.Visible = true;

            user = txtUser.Text;
            password = txtPassword.Text;

            Thread th = new Thread(delegate() { RunLogin(); });
            th.Start();
        }

        private void RunLogin()
        {
            if (!Facade.Login(user, password))
                onFail(this, new EventArgs());
        }

        protected void txtPassword_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btnLogin_Click(sender, new EventArgs());
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            if (Properties.Settings.Default.Autologin)
            {
                txtUser.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
