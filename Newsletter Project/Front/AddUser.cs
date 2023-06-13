using Negocio;
using Services;
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = txtEmail.Text;
            if (Validations.emptyTxt(email))
            {
                errorP.SetError(txtEmail, "You can't leave this data empty");
                txtEmail.Focus();
            }
            if (Validations.emailFormatValidation(email).Equals(1))
            {
                errorP.SetError(txtEmail, $"Email must have {"@"} character");
                txtEmail.Focus();
            }
            if (Validations.emailFormatValidation(email).Equals(2))
            {
                errorP.SetError(txtEmail, "The domain is not valid");
                txtEmail.Focus();
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

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            string username = txtUsername.Text;
            if (Validations.emptyTxt(username))
            {
                errorP.SetError(txtUsername, "You can't leave this data empty");
                txtUsername.Focus();
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            string password = txtPassword.Text;
            if (Validations.emptyTxt(password))
            {
                errorP.SetError(txtPassword, "You can't leave this data empty");
                txtPassword.Focus();
            }
            if(Validations.minLengthPasswordValidated(password))
            {
                errorP.SetError(txtPassword, "The password length must be at least 5 characters long");
                txtPassword.Focus();
            }
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
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            if (Validations.emptyTxt(username))
            {
                errorP.SetError(txtUsername, "You can't leave this data empty");
                txtUsername.Focus();
                return;
            }
            if (Validations.emptyTxt(email))
            {
                errorP.SetError(txtEmail, "You can't leave this data empty");
                txtEmail.Focus();
                return;
            }
            if (Validations.emptyTxt(password))
            {
                errorP.SetError(txtPassword, "You can't leave this data empty");
                txtPassword.Focus();
                return;
            }
            if (Validations.minLengthPasswordValidated(password))
            {
                errorP.SetError(txtPassword, "The password length must be at least 5 characters long");
                txtPassword.Focus();
                return;
            }
            if (Validations.emailFormatValidation(email).Equals(1))
            {
                errorP.SetError(txtEmail, $"Email must have {"@"} character");
                txtEmail.Focus();
                return;
            }
            if (Validations.emailFormatValidation(email).Equals(2))
            {
                errorP.SetError(txtEmail, "The domain is not valid");
                txtEmail.Focus();
                return;
            }
            if (userHandler.validateUniqueUsername(username))
            {
                msgDlgError.Caption = "ERROR";
                msgDlgError.Text = "The username is already taken, try another";
                msgDlgError.Show();
                return;
            }
            if (userHandler.validateUniqueEmail(email))
            {
                msgDlgError.Caption = "ERROR";
                msgDlgError.Text = "The email is already registered";
                msgDlgError.Show();
                return;
            }
            userHandler.addUser(username, password, email);
            msgDlgInfo.Caption = "Successfully registered";
            msgDlgInfo.Show();
        }

        private void clean()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }
    }
}
