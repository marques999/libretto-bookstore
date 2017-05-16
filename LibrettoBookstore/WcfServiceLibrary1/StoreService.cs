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
        /// <param name="loginForm"></param>
        /// <returns></returns>
        public Clerk Login(LoginTemplate loginForm)
        {
            if (string.IsNullOrEmpty(loginForm?.Email) || string.IsNullOrEmpty(loginForm.Password))
            {
                return null;
            }

            var clerkInformation = LibrettoDatabase.ClerkIntegration.LookupByEmail(loginForm.Email);

            if (clerkInformation == null || PasswordUtilities.Verify(loginForm.Password, clerkInformation.Password) == false)
            {
                return null;
            }

            return clerkInformation;
        }

        /*-------------------------------------------------------------------+
         | BOOKS                                                             |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> ListBooks()
        {
            /*Response r = LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
            Notify();
            return r;*/
            return LibrettoDatabase.BookIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response InsertBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Response DeleteBook(Guid bookIdentifier)
        {
            return LibrettoDatabase.BookIntegration.Delete(bookIdentifier);
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

        /*-------------------------------------------------------------------+
         | CUSTOMERS                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> ListCustomers()
        {
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response InsertCustomer(Customer customerInformation)
        {
            return LibrettoDatabase.CustomerIntegration.Insert(customerInformation);
        }

        /*-------------------------------------------------------------------+
         | PURCHASES                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Purchase> ListPurchases()
        {
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseForm"></param>
        /// <returns></returns>
        public Response InsertPurchase(OrderTemplate purchaseForm)
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
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        public Response DeletePurchase(Guid purchaseIdentifier)
        {
            return LibrettoDatabase.PurchaseIntegration.Delete(purchaseIdentifier);
        }

        /*-------------------------------------------------------------------+
         | ORDERS                                                            |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> ListOrders()
        {
            return LibrettoDatabase.OrderIntegration.List();
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

            return EmailClient.Instance.InsertOrder(orderInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public Response DeleteOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.DeleteOrder(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        /// <returns></returns>
        public Response UpdateQuantity(Guid orderIdentifier, int orderQuantity, double orderTotal)
        {
            var beforeUpdate = LibrettoDatabase.OrderIntegration.Lookup(orderIdentifier);

            if (beforeUpdate == null)
            {
                return Response.NotFound;
            }

            if (beforeUpdate.Quantity == orderQuantity && Math.Abs(beforeUpdate.Total - orderTotal) < 1e-6)
            {
                return Response.Success;
            }

            var operationResult = LibrettoDatabase.OrderIntegration.Update(orderIdentifier, orderQuantity, orderTotal, true);

            if (operationResult == Response.Success)
            {
                LibrettoHost.WarehouseQueue.Send(new MessageUpdate
                {
                    Total = orderTotal,
                    Quantity = orderQuantity,
                    Identifier = orderIdentifier
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
        public Response UpdateStatus(Guid orderIdentifier, Status orderStatus)
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

            return EmailClient.Instance.UpdateStatus(LibrettoDatabase.OrderIntegration.Lookup(orderIdentifier));
        }
    }
}