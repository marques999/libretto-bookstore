using System;
using System.Collections.Generic;
using System.ServiceModel.Web;

using Libretto.Model;
using Libretto.Warehouse;
using LibrettoWCF.Database;

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
            setCrossOrigin();
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
            setCrossOrigin();

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
            setCrossOrigin();
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
            setCrossOrigin();
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
            setCrossOrigin();
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
            setCrossOrigin();
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
            setCrossOrigin();
            LibrettoDatabase.BookIntegration.Update(bookInformation);
            return LibrettoDatabase.BookIntegration.List();
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
        /// <param name="orderForm"></param>
        /// <returns></returns>
        public string AddOrder(OrderTemplate orderForm)
        {
            setCrossOrigin();

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
            setCrossOrigin();
            LibrettoDatabase.OrderIntegration.Update(orderInformation, false);
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public Customer Login(LoginTemplate loginForm)
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