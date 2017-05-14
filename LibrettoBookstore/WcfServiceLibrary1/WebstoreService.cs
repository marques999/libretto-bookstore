using System;
using System.Collections.Generic;
using System.ServiceModel.Web;

using Libretto.Model;
using LibrettoWCF.Database;
using LibrettoWCF.Model;
using System.Messaging;
using Libretto.Messaging;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class WebstoreService : IWebstoreService
    {


        private MessageQueue warehouseQ
        {
            get;
            set;
        } = LibrettoHost.InitializeWarehouseQueue();

        private MessageQueue invoiceQ
        {
            get;
            set;
        } = LibrettoHost.InitializeInvoiceQueue();

        /// <summary>
        /// 
        /// </summary>
        private void setCrossOrigin()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetOptions()
        {
            setCrossOrigin();
            return "Ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> AddBook(Book bookInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.BookIntegration.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public string AddCustomer(Customer customerInformation)
        {
            setCrossOrigin();
            customerInformation.Id = Guid.NewGuid();
            return LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public string AddPurchase(PurchaseForm purchaseInformation)
        {
            setCrossOrigin();

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

                invoiceQ.Send(purchaseInformation);
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
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> DeleteBook(Book bookInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.BookIntegration.Delete(bookInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInfromation"></param>
        /// <returns></returns>
        public List<Customer> DeleteCustomer(Customer customerInfromation)
        {
            setCrossOrigin();
            return LibrettoDatabase.CustomerIntegration.Delete(customerInfromation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> DeletePurchase(PurchaseId purchaseInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.PurchaseIntegration.Delete(new Guid(purchaseInformation.Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book GetBookById(string bookIdentifier)
        {
            setCrossOrigin();
            return LibrettoDatabase.BookIntegration.Lookup(new Guid(bookIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksList()
        {
            setCrossOrigin();
            return LibrettoDatabase.BookIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string customerIdentifier)
        {
            setCrossOrigin();
            return LibrettoDatabase.CustomerIntegration.Lookup(new Guid(customerIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomersList()
        {
            setCrossOrigin();
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        public Purchase GetPurchaseById(string purchaseIdentifier)
        {
            setCrossOrigin();
            return LibrettoDatabase.PurchaseIntegration.Lookup(new Guid(purchaseIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> GetPurchasesList()
        {
            setCrossOrigin();
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public List<Customer> UpdateCustomer(Customer customerInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.CustomerIntegration.Update(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> UpdatePurchase(Purchase purchaseInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.PurchaseIntegration.Update(purchaseInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> UpdateBook(Book bookInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.BookIntegration.Update(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrdersList()
        {
            setCrossOrigin();
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Order GetOrderById(string orderIdentifier)
        {
            setCrossOrigin();
            return LibrettoDatabase.OrderIntegration.Lookup(new Guid(orderIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public string AddOrder(OrderForm orderInformation)
        {
            setCrossOrigin();

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

                warehouseQ.Send(orderInformation);
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
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrdersByUser(string id)
        {
            setCrossOrigin();
            return LibrettoDatabase.OrderIntegration.List(new Guid(id));
        }

        public List<Purchase> GetPurchasesByUser(string id)
        {
            setCrossOrigin();
            return LibrettoDatabase.PurchaseIntegration.List(new Guid(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> DeleteOrder(OrderId orderInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.OrderIntegration.DeleteOrder(new Guid(orderInformation.Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> UpdateOrder(Order orderInformation)
        {
            setCrossOrigin();
            return LibrettoDatabase.OrderIntegration.Update(orderInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public Customer Login(LoginForm loginForm)
        {
            setCrossOrigin();

            var customerInformation = LibrettoDatabase.CustomerIntegration.LookupByEmail(loginForm.Email);

            if (customerInformation == null)// || loginForm.Password != customerInformation.Password)
            {
                return null;
            }

            return customerInformation;
        }

        
    }
}