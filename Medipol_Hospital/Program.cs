using System;
using System.Windows.Forms;

namespace Medipol_Hospital
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());

            }
            catch(Exception ex) 
            {
                MessageBox.Show("hata :" + ex);
            }
            
        }
    }
}
