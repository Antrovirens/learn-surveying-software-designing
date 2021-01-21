using PIEAppication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PIEAppicationNew
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Main());
        }
    }
}
