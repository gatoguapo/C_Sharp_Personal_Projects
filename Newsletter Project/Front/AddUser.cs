using Negocio;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Front
{
    public partial class AddUser : Form
    {
        private UserHandler userHandler;
        public AddUser(UserHandler userHandler)
        {
            this.userHandler = userHandler;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '@')
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
            string email = txtEmail.Text;
            if (!domainPasswordValidated(email))
            {
                errorP.SetError(txtEmail, "The domain is not valid");
                txtEmail.Focus();
                return;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_')
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

        public bool domainPasswordValidated(string email)
        {
            string dominiosValidos = @"\.com$|\.org$|\.net$|\.edu$";
            Regex regex = new Regex(dominiosValidos);

            return regex.IsMatch(email);
        }

        public bool emptyPasswordValidated()
        {
            string password = txtPassword.Text;
            if (string.IsNullOrEmpty(password))
            {
                errorP.SetError(txtPassword, "You must enter a password");
                txtPassword.Focus();
                return false;
            }
            return true;
        }

        public bool minLengthPasswordValidated()
        {
            string password = txtPassword.Text;
            if (password.Length < 5)
            {
                errorP.SetError(txtPassword, "Your password must be at least 5 characters long");
                txtPassword.Focus();
                return false;
            }
            return true;

        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            emptyPasswordValidated();
            minLengthPasswordValidated();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!emptyUsernameValidated()) return;
            if (!emptyEmailValidated()) return;
            if (!emptyPasswordValidated()) return;
            if (!minLengthPasswordValidated()) return;
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (!domainPasswordValidated(email))
            {
                errorP.SetError(txtEmail, "The domain is not valid");
                txtEmail.Focus();
                return;
            }
            if (userHandler.validateUniqueUsername(username))
            {
                msgDlgError.Caption = "ERROR";
                msgDlgError.Text = "That username is already taken, try another";
                msgDlgError.Show();
                return;
            }
            if (userHandler.validateUniqueEmail(email))
            {
                msgDlgError.Caption = "ERROR";
                msgDlgError.Text = "That email is already registered";
                msgDlgError.Show();
                return;
            }
            userHandler.addUser(username, password, email);
            msgDlgInfo.Caption = "Successfully registered";
            msgDlgInfo.Show();
        }
    }
}
