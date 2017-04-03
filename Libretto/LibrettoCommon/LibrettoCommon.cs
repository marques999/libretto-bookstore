using System.Net;
using System.Net.Mail;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoCommon
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string DisplayName = "Alertas Libretto";
        public static readonly string EmailAddress = "libretto.alertas@gmail.com";
        public static readonly string EmailPassword = "tdin1617-g10";

        /// <summary>
        /// 
        /// </summary>
        public static NetworkCredential EmailCredentials => new NetworkCredential(EmailAddress, EmailPassword);

        /// <summary>
        /// 
        /// </summary>
        public static MailAddress EmailAccount => new MailAddress(EmailAddress, DisplayName);
    }
}