using ImageFilteringMMS.Controller;
using ImageFilteringMMS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageFilteringMMS
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
            Controller.Controller controler = new Controller.Controller();
            IView View1 = new View1();
            IView View2 = new View2();
            controler.AddView(View1);
            controler.AddView(View2);
            Application.Run(new Form1(controler, View1, View2));
        }
    }
}
