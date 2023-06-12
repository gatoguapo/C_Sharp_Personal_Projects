using System;
using System.Drawing;
using System.Windows.Forms;
using Negocio;
using Services;

namespace Front
{
    public partial class MainPage : Form
    {
        private UserHandler userHandler; 
        public MainPage(UserHandler userHandler)
        {
            this.userHandler = userHandler;
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (Validations.emptyTxt(username))
            {
                errorP.SetError(txtUsername, "You can't leave this data empty");
                txtUsername.Focus();
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
            if (!userHandler.searchUser(username))
            {
                msgDlgError.Caption = "ERROR";
                msgDlgError.Text = "Username or Email not found!";
                msgDlgError.Show();
                return;
            }
            msgDlgInfo.Caption = "User found succesfully";
            msgDlgInfo.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            AddUser frmAddUser = new AddUser(userHandler);
            frmAddUser.ShowDialog();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string username = txtUsername.Text;
            if (Validations.emptyTxt(username))
            {
                errorP.SetError(txtUsername, "You can't leave this data empty");
                txtUsername.Focus();
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '@')
            {
                errorP.SetError(txtUsername, "You can't enter that character");
                e.Handled = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

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

        private void txtPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string password = txtPassword.Text;
            if (Validations.emptyTxt(password))
            {
                errorP.SetError(txtPassword, "You can't leave this data empty");
                txtPassword.Focus();
            }
            if (Validations.minLengthPasswordValidated(password))
            {
                errorP.SetError(txtPassword, "The password length must be at least 5 characters long");
                txtPassword.Focus();
            }
        }
    }
}
