using System;
using System.Messaging;
using System.Text.RegularExpressions;

using Libretto.Messaging;
using Libretto.Model;

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
        private static readonly Regex EmailRegex = new Regex(@"^[-!#$%&'*+/0-9=?A-Z^_a-z{|}~](\.?[-!#$%&'*+/0-9=?A-Z^_a-z{|}~])*@[a-zA-Z](-?[a-zA-Z0-9])*(\.[a-zA-Z](-?[a-zA-Z0-9])*)+$");

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
        private const string MsmqPath = @".\private$\WarehouseMsmq";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MessageQueue InitializeQueue()
        {
            var messageQueue = MessageQueue.Exists(MsmqPath) ? new MessageQueue(MsmqPath) : MessageQueue.Create(MsmqPath);

            messageQueue.Formatter = new XmlMessageFormatter(new[]
            {
                typeof(Order),
                typeof(MessageCancel),
                typeof(MessageUpdate)
            });

            return messageQueue;
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