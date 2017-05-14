using System;
using System.Messaging;
using System.Collections.Generic;

using Libretto.Messaging;
using Libretto.Model;

using LibrettoWCF.Model;
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
            set;
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
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public Response AddOrder(OrderForm orderInformation)
        {
            var operationResult = LibrettoDatabase.OrderIntegration.Insert(new Order
            {
                Quantity = orderInformation.quantity,
                Total = orderInformation.total,
                BookId = new Guid(orderInformation.bookId),
                CustomerId = new Guid(orderInformation.customerId),
                BookTitle = orderInformation.bookTitle,
                CustomerName = orderInformation.customerName
            });

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            LibrettoDatabase.BookIntegration.UpdateStock(new Guid(orderInformation.bookId), orderInformation.quantity);
            WarehouseQueue.Send(orderInformation);

            return Response.Success;
        }

        public string AddPurchase(PurchaseTemplate purchaseInformation)
        {
            if (LibrettoDatabase.PurchaseIntegration.Insert(new Purchase
            {
                Quantity = purchaseInformation.quantity,
                Total = purchaseInformation.total,
                BookId = new Guid(purchaseInformation.bookId),
                CustomerId = new Guid(purchaseInformation.customerId),
                BookTitle = purchaseInformation.bookTitle,
                CustomerName = purchaseInformation.customerName
            }))
            {
                LibrettoDatabase.BookIntegration.UpdateStock(new Guid(purchaseInformation.bookId), purchaseInformation.quantity);

                InvoiceQueue.Send(purchaseInformation);
            }
            else
            {
                return operationResult;
            }

            LibrettoDatabase.BookIntegration.UpdateStock(new Guid(orderInformation.bookId), orderInformation.quantity);
            WarehouseQueue.Send(orderInformation);

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
        public Response DeleteOrder(OrderId orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.DeleteOrder(new Guid(orderInformation.Id));
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
        public Clerk Login(LoginForm loginForm)
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
            return LibrettoDatabase.OrderIntegration.Update(orderInformation);
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