using System;
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
                BookstoreCommon.InitializeInvoiceQueue().Send(new Purchase
                {
                    BookId = Guid.NewGuid(),
                    BookTitle = "Dummy Book A",
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "Diogo Marques",
                    Identifier = Guid.NewGuid(),
                    Quantity = 5,
                    Status = Status.StorePurchased,
                    Timestamp = DateTime.Now,
                    Total = 9.99
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}