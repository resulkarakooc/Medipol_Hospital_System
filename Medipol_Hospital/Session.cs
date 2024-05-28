using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medipol_Hospital
{
    public class Session
    {
        public static int sessionId { get; set; }
        public static string UserName { get; set; }
        public static string UserSurname { get; set; }
        public static string Password { get; set; }
        public static int WhoIsLoggedIn { get; set; }
        public static bool MailConfirm { get; set; } = false;
    }
}
