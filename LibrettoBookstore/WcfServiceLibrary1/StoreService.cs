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
        public List<Book> AddBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public string AddCustomer(Customer customerInformation)
        {
            customerInformation.Id = Guid.NewGuid();
            return LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public string AddOrder(OrderForm orderInformation)
        {
            if (LibrettoDatabase.OrderIntegration.Insert(new Order
            {
                Quantity = orderInformation.quantity,
                Total = orderInformation.total,
                BookId = new Guid(orderInformation.bookId),
                CustomerId = new Guid(orderInformation.customerId),
                BookTitle = orderInformation.bookTitle,
                CustomerName = orderInformation.customerName
            }))
            {
                LibrettoDatabase.BookIntegration.UpdateStock(new Guid(orderInformation.bookId), orderInformation.quantity);

                WarehouseQueue.Send(orderInformation);
            }
            else
            {
                return "ERROR";
            }

            return "Ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> AddPurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Insert(purchaseInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> DeleteBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Delete(bookInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInfromation"></param>
        /// <returns></returns>
        public List<Customer> DeleteCustomer(Customer customerInfromation)
        {
            return LibrettoDatabase.CustomerIntegration.Delete(customerInfromation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> DeleteOrder(OrderId orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.DeleteOrder(new Guid(orderInformation.Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> DeletePurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Delete(purchaseInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book GetBookById(string id)
        {
            return LibrettoDatabase.BookIntegration.Lookup(new Guid(id));
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
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string id)
        {
            return LibrettoDatabase.CustomerIntegration.Lookup(new Guid(id));
        }

        public List<Customer> GetCustomersList()
        {
            return LibrettoDatabase.CustomerIntegration.List();
        }

        public Order GetOrderById(string id)
        {
            return LibrettoDatabase.OrderIntegration.Lookup(new Guid(id));
        }

        public List<Order> GetOrdersByUser(string id)
        {
            return LibrettoDatabase.OrderIntegration.List(new Guid(id));
        }

        public List<Order> GetOrdersList()
        {
            return LibrettoDatabase.OrderIntegration.List();
        }

        public Purchase GetPurchaseById(string id)
        {
            return LibrettoDatabase.PurchaseIntegration.Lookup(new Guid(id));
        }

        public List<Purchase> GetPurchasesList()
        {
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        public Customer Login(LoginForm loginForm)
        {
            var customerInformation = LibrettoDatabase.CustomerIntegration.LookupByEmail(loginForm.Email);

            if (customerInformation == null)// || loginForm.Password != customerInformation.Password)
            {
                return null;
            }

            return customerInformation;
        }

        public List<Book> UpdateBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Update(bookInformation);
        }

        public List<Customer> UpdateCustomer(Customer customerInformation)
        {
            return LibrettoDatabase.CustomerIntegration.Update(customerInformation);
        }

        public List<Order> UpdateOrder(Order orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.Update(orderInformation);
        }

        public List<Purchase> UpdatePurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Update(purchaseInformation);
        }
    }
}
