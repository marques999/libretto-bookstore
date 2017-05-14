using System;

using Libretto.Messaging;
using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class InvoiceTest
    {
        /// <summary>
        /// 
        /// </summary>
        private static void Main()
        {
            try
            {
                MessagingCommon.InitializeInvoiceQueue().Send(new Invoice
                {
                    Quantity = 5,
                    Total = 9.99,
                    Title = "Dummy Book A",
                    Timestamp = DateTime.Now,
                    Customer = "Diogo Marques",
                    Identifier = Guid.NewGuid()
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}