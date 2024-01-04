using SoftwareAccounting.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareAccounting
{
    internal static class Program
    {
        public static bool runApplication = true;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (runApplication)
            {
                LoginForm frmLog = new LoginForm();
                Application.Run(frmLog);
                if (frmLog.IsLoggedIn)
                    Application.Run(new MainForm());
            }
        }
    }
}
