using System;
using System.Threading;
using System.Windows.Forms;
using TCC.View;

namespace TCC
{
    static class Program
    {
        public static SplashScreen splashScreen = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /*FormLogin frmNovo = new FormLogin();
            if (frmNovo.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MenuPrincipal());
            }
            else
            {
                Application.Exit();
            }*/
            // Show splash
            Thread splashThread = new Thread(new ThreadStart(
                delegate
                {
                    splashScreen = new SplashScreen();
                    Application.Run(splashScreen);
                }
                ));

            splashThread.SetApartmentState(ApartmentState.STA);
            splashThread.Start();

            // Run form - time taking operation
            FormLogin login= new FormLogin();
            login.Load += new EventHandler(loginForm_Load);
            Application.Run(login);
        }

        static void loginForm_Load(object sender, EventArgs e)
        {
            // Close splash
            if (splashScreen == null)
            {
                return;
            }

            splashScreen.Invoke(new Action(splashScreen.Close));
            splashScreen.Dispose();
            splashScreen = null;
        }
    }
}