﻿using System;
using System.Net.Mail;

using Libretto;
using Libretto.Model;

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
            _smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = LibrettoCommon.EmailCredentials,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                DeliveryFormat = SmtpDeliveryFormat.International
            };

            _smtp.SendCompleted += (sender, args) =>
            {
                var emailData = args.UserState as MailMessage;

                if (emailData == null)
                {
                    Console.WriteLine(@"[Mailer] Received wrong format!");
                }
                else if (args.Error == null)
                {
                    Console.WriteLine(@"[Mailer] Email successfully sended!");
                }
                else
                {
                    Console.WriteLine(@"[Mailer] Error while sending email...");
                }
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
        public void Send(Customer customerInformation, string emailSubject, string emailBody)
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
            catch (SmtpException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}