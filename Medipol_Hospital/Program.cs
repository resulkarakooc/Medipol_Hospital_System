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
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;

            string errorMessage = ex.ToString();

            // Hata durumunda burası çalışacak
            MessageBox.Show("Hata oluştu: " + errorMessage);
            // Hata durumunda burası çalışacak
           
            // Hata işleme kodları buraya eklenebilir

            // Uygulamayı durdurabilir veya gerekli diğer işlemleri yapabilirsiniz
            
        }
    }
}
