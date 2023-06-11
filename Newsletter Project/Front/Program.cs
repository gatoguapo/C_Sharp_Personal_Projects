using Negocio;
using System;
using System.Windows.Forms;

namespace Front
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserHandler userHandler = new UserHandler();
            Application.Run(new MainPage(userHandler));
        }
    }
}
