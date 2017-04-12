using System;
using System.Messaging;
using System.Threading;
using System.Windows.Forms;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class InvoiceClient : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        private static MessageQueue _invoiceQueue;

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Console.CursorVisible = false;
            Console.Title = @"Libretto Invoices";
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.WriteLine(
@"   _ _ _              _   _
  | (_) |__  _ __ ___| |_| |_ ___
  | | | '_ \| '__/ _ \ __| __/ _ \
  | | | |_) | | |  __/ |_| || (_) |
  |_|_|_.__/|_|  \___|\__|\__\___/
");
            InitalizeMsmq();
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverMessage"></param>
        private static void LogMessage(string serverMessage)
        {
            Console.WriteLine($@"  [{DateTime.Now.ToLongTimeString()}] {serverMessage}");
        }

        /// <summary>
        /// 
        /// </summary>
        private static void InitalizeMsmq()
        {
            _invoiceQueue = BookstoreCommon.InitializeInvoiceQueue();
            LogMessage($"Messaging: Initializing private queue ({_invoiceQueue.Path})...");

            try
            {
                _invoiceQueue.ReceiveCompleted += (src, receiveCompleted) =>
                {
                    if (_invoiceQueue.EndReceive(receiveCompleted.AsyncResult)?.Body is Purchase msmqBody)
                    {
                        LogMessage($"Messaging: Received invoice {msmqBody.Identifier:B}");
                        new Thread(() => Application.Run(new InvoiceForm(msmqBody))).Start();
                    }

                    _invoiceQueue.BeginReceive();
                };

                _invoiceQueue.BeginReceive();
                LogMessage("Messaging: Service running and receiving messages asynchronously.");
            }
            catch (Exception ex)
            {
                LogMessage($"{ex.Source}: {ex.Message}");
            }
        }
    }
}