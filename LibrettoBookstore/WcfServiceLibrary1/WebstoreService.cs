using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

using Libretto.Model;

using LibrettoWCF.Database;
using LibrettoWCF.Model;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class WebstoreService : IWebstoreService
    {
        /// <summary>
        /// 
        /// </summary>
        private static void SetDefaultHeaders()
        {
            if (WebOperationContext.Current == null)
            {
                return;
            }

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
            SetDefaultHeaders();
            return "Ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public string AddCustomer(Customer customerInformation)
        {
            SetDefaultHeaders();
            customerInformation.Id = Guid.NewGuid();
            return LibrettoDatabase.CustomerIntegration.Insert(customerInformation) == Response.Success ? "Ok" : "ERROR";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseForm"></param>
        /// <returns></returns>
        public string AddPurchase(OrderTemplate purchaseForm)
        {
            SetDefaultHeaders();

            return LibrettoDatabase.PurchaseIntegration.Insert(new Purchase
            {
                Quantity = purchaseForm.quantity,
                Total = purchaseForm.total,
                BookId = new Guid(purchaseForm.bookId),
                CustomerId = new Guid(purchaseForm.customerId),
                BookTitle = purchaseForm.bookTitle,
                CustomerName = purchaseForm.customerName
            }) == Response.Success ? "Ok" : "ERROR";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book GetBookById(string bookIdentifier)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.BookIntegration.Lookup(new Guid(bookIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksList()
        {
            SetDefaultHeaders();
            return LibrettoDatabase.BookIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string customerIdentifier)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.CustomerIntegration.Lookup(new Guid(customerIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomersList()
        {
            SetDefaultHeaders();
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        public Purchase GetPurchaseById(string purchaseIdentifier)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.PurchaseIntegration.Lookup(new Guid(purchaseIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> GetPurchasesList()
        {
            SetDefaultHeaders();
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrdersList()
        {
            SetDefaultHeaders();
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Order GetOrderById(string orderIdentifier)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.OrderIntegration.Lookup(new Guid(orderIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderForm"></param>
        /// <returns></returns>
        public string AddOrder(OrderTemplate orderForm)
        {
            SetDefaultHeaders();

            return LibrettoDatabase.OrderIntegration.Insert(new Order
            {
                Quantity = orderForm.quantity,
                Total = orderForm.total,
                BookId = new Guid(orderForm.bookId),
                CustomerId = new Guid(orderForm.customerId),
                BookTitle = orderForm.bookTitle,
                CustomerName = orderForm.customerName
            }) == Response.Success ? "Ok" : "ERROR";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Order> GetOrdersByUser(string id)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.OrderIntegration.List(new Guid(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Purchase> GetPurchasesByUser(string id)
        {
            SetDefaultHeaders();
            return LibrettoDatabase.PurchaseIntegration.List(new Guid(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> DeleteOrder(OrderId orderInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.OrderIntegration.Cancel(new Guid(orderInformation.Id));
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public Customer Login(LoginTemplate loginForm)
        {
            SetDefaultHeaders();

            var customerInformation = LibrettoDatabase.CustomerIntegration.LookupByEmail(loginForm.Email);

            if (customerInformation == null)// || PasswordUtilities.Verify(loginForm.Password, customerInformation.Password) == false)
            {
                return null;
            }

            return customerInformation;
        }
    }
}