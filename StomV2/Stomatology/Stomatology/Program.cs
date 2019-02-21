using System;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;

namespace Stomatology
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
           
        }

    }
}
