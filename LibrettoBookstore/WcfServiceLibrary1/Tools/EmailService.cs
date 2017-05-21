using System;
using System.Net.Mail;

using Libretto;
using Libretto.Model;

using LibrettoWCF.Database;

namespace LibrettoWCF.Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailClient
    {
        /// <summary>
        /// 
        /// </summary>
        private EmailClient()
        {
            _smtp = new SmtpClient(LibrettoCommon.SmtpServer, 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = LibrettoCommon.EmailCredentials,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                DeliveryFormat = SmtpDeliveryFormat.International
            };

            _smtp.SendCompleted += (sender, args) =>
            {
                Console.WriteLine(args.Error == null ? @"[Mailer] Email successfully sent!" : @"[Mailer] Error sending email...");
            };
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly SmtpClient _smtp;

        /// <summary>
        /// 
        /// </summary>
        private static EmailClient _instance;

        /// <summary>
        /// 
        /// </summary>
        public static EmailClient Instance => _instance ?? (_instance = new EmailClient());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <param name="emailSubject"></param>
        /// <param name="emailBody"></param>
        /// <returns></returns>
        public bool Send(Customer customerInformation, string emailSubject, string emailBody)
        {
            try
            {
                _smtp.SendAsync(new MailMessage
                {
                    Body = emailBody,
                    IsBodyHtml = true,
                    Subject = emailSubject,
                    Priority = MailPriority.High,
                    From = LibrettoCommon.EmailAccount,
                    To = { new MailAddress(customerInformation.Email, customerInformation.Name) }
                }, customerInformation.Id);
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response NotifyInsert(Order orderInformation)
        {
            var customerInformation = LibrettoDatabase.CustomerIntegration.Lookup(orderInformation.CustomerId);

            if (customerInformation == null)
            {
                return Response.NotFound;
            }

            return Send(customerInformation, $"Order {orderInformation.Id:B}", $@"
BookId: {orderInformation.BookId}
BookTitle: {orderInformation.BookId}
CustomerId: {orderInformation.CustomerId}
CustomerName: {orderInformation.CustomerName}
Quantity: {orderInformation.Quantity}
Total: {LibrettoCommon.FormatCurrency(orderInformation.Total)}
Timestamp: {LibrettoCommon.FormatDate(orderInformation.Timestamp)}
Status: {orderInformation.Status.GetDescription()}
StatusTimestamp: {LibrettoCommon.FormatDate(orderInformation.StatusTimestamp)}") ? Response.Success : Response.EmailFailure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response NotifyCancel(Order orderInformation)
        {
            var customerInformation = LibrettoDatabase.CustomerIntegration.Lookup(orderInformation.CustomerId);

            if (customerInformation == null)
            {
                return Response.NotFound;
            }

            return Send(
                customerInformation,
                $"Order {orderInformation.Id:B} Status: Cancelled",
                $"StatusTimestamp: {LibrettoCommon.FormatDate(orderInformation.StatusTimestamp)}"
            ) ? Response.Success : Response.EmailFailure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response NotifyUpdate(Order orderInformation)
        {
            var customerInformation = LibrettoDatabase.CustomerIntegration.Lookup(orderInformation.CustomerId);

            if (customerInformation == null)
            {
                return Response.NotFound;
            }

            return Send(
                customerInformation,
                $"Order {orderInformation.Id:B} Status: {orderInformation.Status.GetDescription()}",
                $"StatusTimestamp: {LibrettoCommon.FormatDate(orderInformation.StatusTimestamp)}"
            ) ? Response.Success : Response.EmailFailure;
        }
    }
}