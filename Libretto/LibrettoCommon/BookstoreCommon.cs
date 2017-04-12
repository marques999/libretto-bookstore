using System.Messaging;
using System.Net;
using System.Net.Mail;

using Libretto.Model;

namespace Libretto.Bookstore
{
    /// <summary>
    /// 
    /// </summary>
    public class BookstoreCommon
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
        public static NetworkCredential EmailCredentials => new NetworkCredential(EmailAddress, EmailPassword);

        /// <summary>
        /// 
        /// </summary>
        public static MailAddress EmailAccount => new MailAddress(EmailAddress, DisplayName);


        /// <summary>
        /// 
        /// </summary>
        private const string MsmqPath = @".\private$\InvoiceMsmq";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MessageQueue InitializeInvoiceQueue()
        {
            var messageQueue = MessageQueue.Exists(MsmqPath) ? new MessageQueue(MsmqPath) : MessageQueue.Create(MsmqPath);

            messageQueue.Formatter = new XmlMessageFormatter(new[]
            {
                typeof(Purchase)
            });

            return messageQueue;
        }
    }
}