using System;
using System.Collections.Generic;
using System.ServiceModel;

using Libretto.Model;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IStoreService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginForm"></param>
        /// <returns></returns>
        [OperationContract]
        Clerk Login(LoginTemplate loginForm);

        //----------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Book> GetBooksList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Book GetBookById(string bookIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response AddBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeleteBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdateBook(Book bookInformation);

        //----------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Customer> GetCustomersList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Customer GetCustomerById(string customerIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response AddCustomer(Customer customerInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeleteCustomer(Customer customerInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdateCustomer(Customer customerInformation);

        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Purchase> GetPurchasesList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Purchase GetPurchaseById(string purchaseIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseForm"></param>
        /// <returns></returns>
        [OperationContract]
        Response AddPurchase(OrderTemplate purchaseForm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeletePurchase(Purchase purchaseInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdatePurchase(Purchase purchaseInformation);

        //---------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Order> GetOrdersList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        Order GetOrderById(string orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        [OperationContract]
        List<Order> GetOrdersByUser(string customerIdentifier);

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
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response DeleteOrder(Order orderInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract]
        Response UpdateOrder(Order orderInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        Response UpdateOrderStatus(Guid orderIdentifier, Status orderStatus);
    }
}