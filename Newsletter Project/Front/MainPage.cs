using System;
using System.Drawing;
using System.Windows.Forms;
using Negocio;

namespace Front
{
    public partial class MainPage : Form
    {
        private UserHandler handler; 
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            errorP.SetError(txtUsername, "Pene parado");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
