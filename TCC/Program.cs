using System;
using System.Windows.Forms;
using TCC.View;

namespace TCC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormLogin frmNovo = new FormLogin();
            if (frmNovo.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MenuPrincipal());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}