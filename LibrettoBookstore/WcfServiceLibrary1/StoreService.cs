using System;
using System.Collections.Generic;
using Libretto.Messaging;
using Libretto.Model;
using Libretto.Warehouse;
using LibrettoWCF.Database;
using LibrettoWCF.Tools;
using System.ServiceModel;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    public delegate void ChangeUser();

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class StoreService : IStoreService
    {

        public static IStoreUpdated Callback;
        public static ChangeUser changeUser = null;

        public void Unsubscribe()
        {
        }

        public void Subscribe()
        {
        }

        public static void Notify()
        {
            Callback = OperationContext.Current.GetCallbackChannel<IStoreUpdated>();
            Callback.UserAdded();
        }
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
            Response r = LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
            Notify();
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderForm"></param>
        /// <returns></returns>
        public Response InsertOrder(OrderTemplate orderForm)
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

            LibrettoHost.WarehouseQueue.Send(WarehouseOrder.FromOrder(orderInformation));
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

            LibrettoHost.InvoiceQueue.Send(Invoice.FromPurchase(purchaseInformation));
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
            var beforeUpdate = LibrettoDatabase.OrderIntegration.Lookup(orderInformation.Id);

            if (beforeUpdate == null)
            {
                return Response.NotFound;
            }

            if (beforeUpdate.Quantity == orderInformation.Quantity && Math.Abs(beforeUpdate.Total - orderInformation.Total) < 1e-6)
            {
                return Response.Success;
            }

            var operationResult = LibrettoDatabase.OrderIntegration.Update(orderInformation, true);

            if (operationResult == Response.Success)
            {
                LibrettoHost.WarehouseQueue.Send(new MessageUpdate
                {
                    Total = orderInformation.Total,
                    Identifier = orderInformation.Id,
                    Quantity = orderInformation.Quantity
                });
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public Response UpdateOrderStatus(Guid orderIdentifier, Status orderStatus)
        {
            var beforeUpdate = LibrettoDatabase.OrderIntegration.Lookup(orderIdentifier);

            if (beforeUpdate == null)
            {
                return Response.NotFound;
            }

            if (beforeUpdate.Status == orderStatus)
            {
                return Response.Success;
            }

            var orderTimestamp = new DateTime();
            var operationResult = LibrettoDatabase.OrderIntegration.UpdateStatus(orderIdentifier, orderTimestamp, orderStatus);

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            if (orderStatus == Status.Cancelled)
            {
                LibrettoHost.WarehouseQueue.Send(new MessageCancel
                {
                    Timestamp = orderTimestamp,
                    Identifier = orderIdentifier
                });
            }

            return EmailClient.Instance.SendEmail(LibrettoDatabase.OrderIntegration.Lookup(orderIdentifier));
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