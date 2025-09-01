using System;
using System.Windows.Forms;

namespace Guan
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] str)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (str.Length > 0)
            {
                Application.Run(new FormGuan(str[0]));
                return;
            }
            Application.Run(new FormGuan());
        }
    }
}
