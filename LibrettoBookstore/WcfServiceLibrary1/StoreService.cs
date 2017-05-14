using System;
using System.Messaging;
using System.Collections.Generic;

using Libretto.Model;
using Libretto.Messaging;
using Libretto.Warehouse;

using LibrettoWCF.Database;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class StoreService : IStoreService
    {
        /// <summary>
        /// 
        /// </summary>
        private MessageQueue InvoiceQueue
        {
            get;
        } = MessagingCommon.InitializeInvoiceQueue();

        /// <summary>
        /// 
        /// </summary>
        private MessageQueue WarehouseQueue
        {
            get;
        } = MessagingCommon.InitializeWarehouseQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response AddBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response AddCustomer(Customer customerInformation)
        {
            return LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderForm"></param>
        /// <returns></returns>
        public Response AddOrder(OrderTemplate orderForm)
        {
            var orderInformation = new Order
            {
                Quantity = orderForm.quantity,
                Total = orderForm.total,
                BookId = new Guid(orderForm.bookId),
                CustomerId = new Guid(orderForm.customerId),
                BookTitle = orderForm.bookTitle,
                CustomerName = orderForm.customerName
            };

            var operationResult = LibrettoDatabase.OrderIntegration.Insert(orderInformation);

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            WarehouseQueue.Send(WarehouseOrder.FromOrder(orderInformation));
            LibrettoDatabase.BookIntegration.UpdateStock(orderInformation.BookId, orderInformation.Quantity);

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseForm"></param>
        /// <returns></returns>
        public Response AddPurchase(OrderTemplate purchaseForm)
        {
            var purchaseInformation = new Purchase
            {
                Quantity = purchaseForm.quantity,
                Total = purchaseForm.total,
                BookId = new Guid(purchaseForm.bookId),
                CustomerId = new Guid(purchaseForm.customerId),
                BookTitle = purchaseForm.bookTitle,
                CustomerName = purchaseForm.customerName
            };

            var operationResult = LibrettoDatabase.PurchaseIntegration.Insert(purchaseInformation);

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            InvoiceQueue.Send(Invoice.FromPurchase(purchaseInformation));
            LibrettoDatabase.BookIntegration.UpdateStock(purchaseInformation.BookId, purchaseInformation.Quantity);

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response DeleteBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Delete(bookInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response DeleteCustomer(Customer customerInformation)
        {
            return LibrettoDatabase.CustomerIntegration.Delete(customerInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response DeleteOrder(Order orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.DeleteOrder(orderInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public Response DeletePurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Delete(purchaseInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book GetBookById(string bookIdentifier)
        {
            return LibrettoDatabase.BookIntegration.Lookup(new Guid(bookIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksList()
        {
            return LibrettoDatabase.BookIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string customerIdentifier)
        {
            return LibrettoDatabase.CustomerIntegration.Lookup(new Guid(customerIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomersList()
        {
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Order GetOrderById(string orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Lookup(new Guid(orderIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public List<Order> GetOrdersByUser(string customerIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.List(new Guid(customerIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrdersList()
        {
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        public Purchase GetPurchaseById(string purchaseIdentifier)
        {
            return LibrettoDatabase.PurchaseIntegration.Lookup(new Guid(purchaseIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> GetPurchasesList()
        {
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public Clerk Login(LoginTemplate loginForm)
        {
            if (string.IsNullOrEmpty(loginForm?.Email) || string.IsNullOrEmpty(loginForm.Password))
            {
                return null;
            }

            var clerkInformation = LibrettoDatabase.ClerkIntegration.LookupByEmail(loginForm.Email);

            if (clerkInformation == null || clerkInformation.Password != loginForm.Password)
            {
                return null;
            }

            return clerkInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response UpdateBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Update(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response UpdateCustomer(Customer customerInformation)
        {
            return LibrettoDatabase.CustomerIntegration.Update(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response UpdateOrder(Order orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.Update(orderInformation, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public Response UpdatePurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Update(purchaseInformation);
        }
    }
}