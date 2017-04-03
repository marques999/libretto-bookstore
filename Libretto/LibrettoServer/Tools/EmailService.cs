﻿using System;
using System.ComponentModel;
using System.Net.Mail;

using Libretto.Model;

namespace Libretto
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

            _smtp.SendCompleted += delegate (object sender, AsyncCompletedEventArgs args)
            {
                var emailData = args.UserState as MailMessage;

                if (emailData == null)
                {
                    Console.WriteLine("[Mailer] Received wrong format!");
                }
                else if (args.Error == null)
                {
                    Console.WriteLine("[Mailer] Email successfully sended!");
                }
                else
                {
                    Console.WriteLine("[Mailer] Error while sending email...");
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
            var mail = new MailMessage
            {
                Body = emailBody,
                IsBodyHtml = true,
                Subject = emailSubject,
                Priority = MailPriority.High,
                From = LibrettoCommon.EmailAccount,
                To = { new MailAddress(customerInformation.Email, customerInformation.Name) }
            };

            try
            {
                _smtp.SendAsync(mail, mail);
            }
            catch (SmtpException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}