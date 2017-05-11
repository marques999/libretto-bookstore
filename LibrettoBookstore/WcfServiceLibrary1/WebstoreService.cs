using System;
using System.Collections.Generic;

using Libretto.Model;
using LibrettoWCF.Database;
using System.ServiceModel.Web;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    public class WebstoreService : IWebstoreService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly LibrettoDatabase DatabaseContext = new LibrettoDatabase();

        /// <summary>
        /// 
        /// </summary>
        private BookIntegration Books
        {
            get;
        } = new BookIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        private CustomerIntegration Customers
        {
            get;
        } = new CustomerIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        private OrderIntegration Orders
        {
            get;
        } = new OrderIntegration(DatabaseContext);

        /// <summary>
        /// 
        /// </summary>
        private PurchaseIntegration Purchases
        {
            get;
        } = new PurchaseIntegration(DatabaseContext);

        private void setCrossOrigin()
        {
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Origin", "*");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Methods", "GET, POST, DELETE, PUT, OPTIONS");
            WebOperationContext.Current.OutgoingResponse.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Accept, Authorization");
        }

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
            return Books.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public string AddCustomer(Customer customerInformation)
        {
            setCrossOrigin();
            Customer c = new Customer();
            c.Name = customerInformation.Name;
            c.Email = customerInformation.Email;
            c.Location= customerInformation.Location;
            
            return Customers.Insert(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> AddPurchase(Purchase purchaseInformation)
        {
            setCrossOrigin();
            return Purchases.Insert(purchaseInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> DeleteBook(Book bookInformation)
        {
            setCrossOrigin();
            return Books.Delete(bookInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInfromation"></param>
        /// <returns></returns>
        public List<Customer> DeleteCustomer(Customer customerInfromation)
        {
            setCrossOrigin();
            return Customers.Delete(customerInfromation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> DeletePurchase(Purchase purchaseInformation)
        {
            setCrossOrigin();
            return Purchases.Delete(purchaseInformation.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book GetBookById(string bookIdentifier)
        {
            setCrossOrigin();
            return Books.Lookup(new Guid(bookIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooksList()
        {
            setCrossOrigin();
            return Books.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer GetCustomerById(string customerIdentifier)
        {
            setCrossOrigin();
            return Customers.Lookup(new Guid(customerIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomersList()
        {
            setCrossOrigin();
            return Customers.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        public Purchase GetPurchaseById(string purchaseIdentifier)
        {
            setCrossOrigin();
            return Purchases.Lookup(new Guid(purchaseIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> GetPurchasesList()
        {
            setCrossOrigin();
            return Purchases.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public List<Customer> UpdateCustomer(Customer customerInformation)
        {
            setCrossOrigin();
            return Customers.Update(customerInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> UpdatePurchase(Purchase purchaseInformation)
        {
            setCrossOrigin();
            return Purchases.Update(purchaseInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> UpdateBook(Book bookInformation)
        {
            setCrossOrigin();
            return Books.Update(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> GetOrdersList()
        {
            setCrossOrigin();
            return Orders.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Order GetOrderById(string orderIdentifier)
        {
            setCrossOrigin();
            return Orders.Lookup(new Guid(orderIdentifier));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public string AddOrder(OrderForm orderInformation)
        {
            setCrossOrigin();
            Order c = new Order();
            c.Quantity = orderInformation.quantity;
            c.Total = orderInformation.total;
            c.BookId = new Guid(orderInformation.bookId);
            c.CustomerId = new Guid(orderInformation.customerId);
            c.BookTitle = orderInformation.bookTitle;
            c.CustomerName = orderInformation.customerName;

            Books.UpdateStock(new Guid(orderInformation.bookId), orderInformation.quantity);

            return Orders.Insert(c);
        }

        public List<Order> GetOrdersByUser(string id)
        {
            setCrossOrigin();
            return Orders.List(new Guid(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> DeleteOrder(OrderId orderInformation)
        {
            setCrossOrigin();
            return Orders.DeleteOrder(new Guid(orderInformation.Id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> UpdateOrder(Order orderInformation)
        {
            setCrossOrigin();
            return Orders.Update(orderInformation);
        }

        public Customer Login(LoginForm creds)
        {
            //TODO Ver palavra passe!
            setCrossOrigin();
            return Customers.LookupEmail(creds.Email);
        }
    }
}