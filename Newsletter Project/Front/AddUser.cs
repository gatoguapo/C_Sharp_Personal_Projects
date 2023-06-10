using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Front
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '#' && e.KeyChar != '@')
            {
                errorP.SetError(txtEmail, "You can't enter special characters");
                e.Handled = true;
            }
        }

        public bool emptyEmailValidated()
        {
            string email = txtEmail.Text;
            if(string.IsNullOrEmpty(email))
            {
                errorP.SetError(txtEmail, "You must enter an email");
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            emptyEmailValidated();
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '#' && e.KeyChar != '!')
            {
                errorP.SetError(txtUsername, "You can't enter special characters");
                e.Handled = true;
            }
        }

        public bool emptyUsernameValidated()
        {
            string username = txtUsername.Text;
            if (string.IsNullOrEmpty(username))
            {
                errorP.SetError(txtUsername, "You must enter an username");
                txtUsername.Focus();
                return false;
            }
            return true;
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            emptyUsernameValidated();
        }

        public bool emptyPasswordValidated()
        {
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                errorP.SetError(txtPassword, "You must enter a password");
                txtUsername.Focus();
                return false;
            }
            return true;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            emptyPasswordValidated();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (e.KeyChar == (char)Keys.Space)
            {
                errorP.SetError(txtUsername, "You can't enter a blank space");
                e.Handled = true;
            }
        }
    }
}
