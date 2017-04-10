using System;
using System.Messaging;
using System.Threading;

using Libretto.Forms;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal static class LibrettoInvoice
    {
        /// <summary>
        /// 
        /// </summary>
        private static bool _keepAlive = true;

        /// <summary>
        /// 
        /// </summary>
        private static readonly object KeepLock = new object();

        /// <summary>
        /// 
        /// </summary>
        private const string DefaultPath = @".\private$\LibrettoInvoiceServer";

        /// <summary>
        /// 
        /// </summary>
        private static readonly MessageQueue MessageQueue = MessageQueue.Exists(DefaultPath) ? new MessageQueue(DefaultPath) : MessageQueue.Create(DefaultPath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="receiveCompleted"></param>
        private static void OnReceive(object src, ReceiveCompletedEventArgs receiveCompleted)
        {
            var msmqBody = MessageQueue.EndReceive(receiveCompleted.AsyncResult).Body as Invoice;

            if (msmqBody == null)
            {
                lock (KeepLock)
                {
                    _keepAlive = false;
                }
            }
            else
            {
                new InvoiceForm(msmqBody).Show();
            }

            MessageQueue.BeginReceive();
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            MessageQueue.Formatter = new XmlMessageFormatter();
            MessageQueue.ReceiveCompleted += OnReceive;
            MessageQueue.BeginReceive(TimeSpan.FromSeconds(1));

            while (_keepAlive)
            {
                Thread.Sleep(1000);
            }
        }
    }
}