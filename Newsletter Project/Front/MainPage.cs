using System;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

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
            emptyUsernameValidated();
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

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorP.Clear();
            if (!char.IsLetter(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '_' && e.KeyChar != '@')
            {
                errorP.SetError(txtUsername, "You can't enter special characters");
                e.Handled = true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

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
            emptyPasswordValidated();
            minLengthPasswordValidated();
        }
    }
}
