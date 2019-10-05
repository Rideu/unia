using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Runtime.InteropServices;
using static UniaCore.Helper;

namespace UniaCore
{
    static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var self = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(Assembly.GetCallingAssembly().CodeBase));
            if (self.Length > 1)
            {
                var notthis = ShowWindow((self.Where(n => n.MainWindowHandle != IntPtr.Zero).First().MainWindowHandle), 9);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainWindow());
            }
        }
    }
}
