using System;
using System.Messaging;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    ///
    /// </summary>
    public class MessagingCommon
    {
        /// <summary>
        /// 
        /// </summary>
        private const string InvoiceMsmqPath = @".\private$\InvoiceMsmq";

        /// <summary>
        /// 
        /// </summary>
        private const string WarehouseMsmqPath = @".\private$\WarehouseMsmq";

        /// <summary>
        /// 
        /// </summary>
        public static readonly TimeSpan MsmqTimeout = TimeSpan.FromMinutes(5);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MessageQueue InitializeInvoiceQueue()
        {
            var messageQueue = MessageQueue.Exists(InvoiceMsmqPath) ? new MessageQueue(InvoiceMsmqPath) : MessageQueue.Create(InvoiceMsmqPath);

            messageQueue.Formatter = new XmlMessageFormatter(new[]
            {
                typeof(Invoice)
            });

            return messageQueue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MessageQueue InitializeWarehouseQueue()
        {
            return MessageQueue.Exists(WarehouseMsmqPath) ? new MessageQueue(WarehouseMsmqPath) : MessageQueue.Create(WarehouseMsmqPath, true);
        }
    }
}