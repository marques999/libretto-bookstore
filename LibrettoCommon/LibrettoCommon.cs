using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

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

        /// <summary>
        /// 
        /// </summary>
        public static readonly string EmailAddress = "libretto.alertas@gmail.com";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string EmailPassword = "tdin1617-g10";

        /// <summary>
        /// 
        /// </summary>
        public static MailAddress EmailAccount => new MailAddress(EmailAddress, DisplayName);

        /// <summary>
        /// 
        /// </summary>
        public static NetworkCredential EmailCredentials => new NetworkCredential(EmailAddress, EmailPassword);

        /// <summary>
        /// 
        /// </summary>
        private static readonly Regex EmailRegex = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currencyValue"></param>
        /// <returns></returns>
        public static string FormatCurrency(double currencyValue)
        {
            return $"{currencyValue:C2}";
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
        /// <param name="decimalValue"></param>
        /// <returns></returns>
        public static string FormatDecimal(double decimalValue)
        {
            return decimalValue.ToString("#,##0.00");
        }

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
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public static bool VerifyEmail(string userEmail)
        {
            try
            {
                return EmailRegex.IsMatch(userEmail);
            }
            catch
            {
                return false;
            }
        }
    }
}