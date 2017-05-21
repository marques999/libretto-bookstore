using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.ServiceModel;

using Libretto.Model;

using LibrettoWCF.Database;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class StoreService : IStoreService
    {
        /*-------------------------------------------------------------------+
         | CALLBACKS                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        private readonly IStoreCallbacks _callback = OperationContext.Current.GetCallbackChannel<IStoreCallbacks>();

        /// <summary>
        /// 
        /// </summary>
        public void Unsubscribe()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Subscribe()
        {
        }

        /*-------------------------------------------------------------------+
         | CLERKS                                                            |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Clerk Profile()
        {
            return LibrettoDatabase.ClerkIntegration.Lookup(ServiceSecurityContext.Current.PrimaryIdentity);
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
            return LibrettoDatabase.BookIntegration.List();
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
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response DeletePurchase(Guid purchaseIdentifier)
        {
            return LibrettoDatabase.PurchaseIntegration.Delete(purchaseIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response InsertPurchase(Purchase purchaseInformation)
        {
            return LibrettoDatabase.PurchaseIntegration.Insert(purchaseInformation);
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
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response CancelOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Cancel(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response DeleteOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Delete(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response InsertOrder(Order orderInformation)
        {
            return LibrettoDatabase.OrderIntegration.Insert(orderInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [PrincipalPermission(SecurityAction.Demand, Role = "Clerk")]
        public Response DispatchOrder(Guid orderIdentifier)
        {
            return LibrettoDatabase.OrderIntegration.Dispatch(orderIdentifier);
        }
    }
}