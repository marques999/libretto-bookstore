using System;
using System.Collections.Generic;
using System.ServiceModel.Web;

using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Database;
using LibrettoWCF.Tools;

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
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> AddBook(Book bookInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.BookIntegration.Insert(bookInformation);
            return LibrettoDatabase.BookIntegration.List();
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
            customerInformation.Password = PasswordUtilities.Hash(customerInformation.Password);
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

            var purchaseInformation = new Purchase
            {
                Quantity = purchaseForm.quantity,
                Total = purchaseForm.total,
                BookId = new Guid(purchaseForm.bookId),
                CustomerId = new Guid(purchaseForm.customerId),
                BookTitle = purchaseForm.bookTitle,
                CustomerName = purchaseForm.customerName
            };

            if (LibrettoDatabase.PurchaseIntegration.Insert(purchaseInformation) == Response.Success)
            {
                LibrettoHost.InvoiceQueue.Send(Invoice.FromPurchase(purchaseInformation));
                LibrettoDatabase.BookIntegration.UpdateStock(purchaseInformation.BookId, purchaseInformation.Quantity);
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
            SetDefaultHeaders();
            LibrettoDatabase.BookIntegration.Delete(bookInformation.Id);
            return LibrettoDatabase.BookIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public List<Customer> DeleteCustomer(Customer customerInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.CustomerIntegration.Delete(customerInformation.Id);
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> DeletePurchase(PurchaseId purchaseInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.PurchaseIntegration.Delete(new Guid(purchaseInformation.Id));
            return LibrettoDatabase.PurchaseIntegration.List();
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
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public List<Customer> UpdateCustomer(Customer customerInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.CustomerIntegration.Update(customerInformation);
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public List<Purchase> UpdatePurchase(Purchase purchaseInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.PurchaseIntegration.Update(purchaseInformation);
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public List<Book> UpdateBook(Book bookInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.BookIntegration.Update(bookInformation);
            return LibrettoDatabase.BookIntegration.List();
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

            var orderInformation = new Order
            {
                Quantity = orderForm.quantity,
                Total = orderForm.total,
                BookId = new Guid(orderForm.bookId),
                CustomerId = new Guid(orderForm.customerId),
                BookTitle = orderForm.bookTitle,
                CustomerName = orderForm.customerName
            };

            if (LibrettoDatabase.OrderIntegration.Insert(orderInformation) == Response.Success)
            {
                LibrettoHost.WarehouseQueue.Send(WarehouseOrder.FromOrder(orderInformation));
                LibrettoDatabase.BookIntegration.UpdateStock(orderInformation.Id, orderInformation.Quantity);
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
            SetDefaultHeaders();
            return LibrettoDatabase.OrderIntegration.List(new Guid(id));
        }

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
            LibrettoDatabase.OrderIntegration.UpdateStatus(new Guid(orderInformation.Id), new DateTime(), Status.Cancelled);
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public List<Order> UpdateOrder(Order orderInformation)
        {
            SetDefaultHeaders();
            LibrettoDatabase.OrderIntegration.UpdateQuantity(orderInformation.Id, orderInformation.Quantity, orderInformation.Total);
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