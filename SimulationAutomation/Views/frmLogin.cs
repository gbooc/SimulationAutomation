using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAutomation.Views
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (System.DirectoryServices.AccountManagement.PrincipalContext pc = new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain, "pri.Local"))
                {
                    if (pc.ValidateCredentials(this.txtUsername.Text, this.txtPassword.Text))
                    {
                        if (new Controllers.UserLoginController().IsLogin(this.txtUsername.Text))
                        {
                            Views.MDIMain main = new MDIMain();
                            this.Hide();
                            main.Show();
                        }
                        else
                        {
                            Util.MessageUtil.ShowError("Invalid Username and Password!", string.Format(Util.Messages.ERROR_FOUND, "Invalid"));
                            this.txtPassword.Text = string.Empty;
                        }
                    }
                    else
                    {
                        Util.MessageUtil.ShowError("Invalid Username and Password!", string.Format(Util.Messages.ERROR_FOUND, "Invalid"));
                        this.txtPassword.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.MessageUtil.ShowError(ex.Message, string.Format(Util.Messages.ERROR_FOUND, ""));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtUsername.Text = Environment.UserName;
            this.txtPassword.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}