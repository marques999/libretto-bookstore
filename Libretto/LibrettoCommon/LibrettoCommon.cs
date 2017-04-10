using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dummyIdentifier"></param>
        /// <returns></returns>
        public static string FormatGuid(Guid dummyIdentifier)
        {
            return dummyIdentifier.ToString("N").ToUpper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string FormatDate(DateTime dateTime)
        {
            return $"{dateTime.ToShortDateString()} {dateTime.ToShortTimeString()}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyValue"></param>
        /// <returns></returns>
        public static string FormatCurrency(double currencyValue)
        {
            return $"{currencyValue:C2}";
        }
    }
}