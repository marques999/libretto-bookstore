using System;
using System.Collections.Generic;
using System.ServiceModel;

using Libretto.Model;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IStoreUpdated))]
    public interface IStoreService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        [OperationContract]
        Clerk Login(LoginTemplate loginForm);

        /*-------------------------------------------------------------------+
         | BOOKS                                                             |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Book> ListBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response InsertBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        Response DeleteBook(Guid bookIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdateBook(Book bookInformation);

        /*-------------------------------------------------------------------+
         | CUSTOMERS                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Customer> ListCustomers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response InsertCustomer(Customer customerInformation);

        /*-------------------------------------------------------------------+
         | PURCHASES                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Purchase> ListPurchases();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseForm"></param>
        /// <returns></returns>
        [OperationContract]
        Response InsertPurchase(OrderTemplate purchaseForm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeletePurchase(Guid purchaseIdentifier);

        /*-------------------------------------------------------------------+
         | ORDERS                                                            |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Order> ListOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderForm"></param>
        /// <returns></returns>
        [OperationContract]
        Response InsertOrder(OrderTemplate orderForm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeleteOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdateQuantity(Guid orderIdentifier, int orderQuantity, double orderTotal);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        Response UpdateOrderStatus(Guid orderIdentifier, Status orderStatus);

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();


        Response UpdateStatus(Guid orderIdentifier, Status orderStatus);
    }

    public interface IStoreUpdated
    {

        [OperationContract]
        void UserAdded();

        
    }
}