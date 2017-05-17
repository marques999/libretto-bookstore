using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

using Libretto.Messaging;
using Libretto.Model;
using Libretto.Warehouse;

using LibrettoWCF.Database;
using LibrettoWCF.Tools;

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
        /// <returns></returns>
        public Clerk Profile()
        {
            var identity = ServiceSecurityContext.Current.PrimaryIdentity;
            return identity == null ? null : LibrettoDatabase.ClerkIntegration.LookupByEmail(identity.Name);
        }

        /*-------------------------------------------------------------------+
         | BOOKS                                                             |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
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
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
        public Response InsertBook(Book bookInformation)
        {
            return LibrettoDatabase.BookIntegration.Insert(bookInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
        public Response DeleteBook(Guid bookIdentifier)
        {
            return LibrettoDatabase.BookIntegration.Delete(bookIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
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
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public List<Customer> ListCustomers()
        {
            return LibrettoDatabase.CustomerIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
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
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public List<Purchase> ListPurchases()
        {
            return LibrettoDatabase.PurchaseIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Purchase LookupPurchase(Guid purchaseIdentifier)
        {
            return LibrettoDatabase.PurchaseIntegration.Lookup(purchaseIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response InsertPurchase(Purchase purchaseInformation)
        {
            purchaseInformation.Timestamp = DateTime.Now;

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
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
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
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public List<Order> ListOrders()
        {
            return LibrettoDatabase.OrderIntegration.List();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Order LookupOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Lookup(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response InsertOrder(Order orderInformation)
        {
            orderInformation.Timestamp = DateTime.Now;

            var operationResult = LibrettoDatabase.OrderIntegration.Insert(orderInformation);

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            LibrettoHost.WarehouseQueue.Send(WarehouseOrder.FromOrder(orderInformation));
            LibrettoDatabase.BookIntegration.UpdateStock(orderInformation.BookId, orderInformation.Quantity);

            return EmailClient.Instance.NotifyInsert(orderInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrator")]
        public Response DeleteOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.DeleteOrder(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response UpdateOrder(Order orderInformation)
        {
            var orderExists = LibrettoDatabase.OrderIntegration.Lookup(orderInformation.Id);

            if (orderExists == null)
            {
                return Response.NotFound;
            }

            if (orderInformation.Status == Status.Cancelled)
            {
                orderInformation.StatusTimestamp = DateTime.Now;
            }

            var operationResult = LibrettoDatabase.OrderIntegration.Update(orderInformation);

            if (operationResult != Response.Success)
            {
                return operationResult;
            }

            if (orderInformation.Status == Status.Cancelled)
            {
                LibrettoHost.WarehouseQueue.Send(new MessageCancel
                {
                    Identifier = orderInformation.Id,
                    Timestamp = orderInformation.StatusTimestamp
                });  
            }
            else
            {
                LibrettoHost.WarehouseQueue.Send(WarehouseOrder.FromOrder(orderInformation));   
            }

            return orderExists.Status == orderInformation.Status ? Response.Success : EmailClient.Instance.NotifyUpdate(orderInformation);
        }
    }
}