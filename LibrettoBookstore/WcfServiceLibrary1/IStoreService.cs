﻿using System;
using System.Collections.Generic;
using System.ServiceModel;

using Libretto.Model;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IStoreCallbacks))]
    public interface IStoreService
    {
        /*-------------------------------------------------------------------+
         | CALLBACKS                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        [OperationContract] void Subscribe();

        /// <summary>
        /// 
        /// </summary>
        [OperationContract] void Unsubscribe();

        /*-------------------------------------------------------------------+
         | CLERKS                                                            |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract] Clerk Profile();

        /*-------------------------------------------------------------------+
         | BOOKS                                                             |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract] List<Book> ListBooks();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Response DeleteBook(Guid bookIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract] Response UpdateBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract] Response InsertBook(Book bookInformation);

        /*-------------------------------------------------------------------+
         | CUSTOMERS                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract] List<Customer> ListCustomers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract] Response InsertCustomer(Customer customerInformation);

        /*-------------------------------------------------------------------+
         | PURCHASES                                                         |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract] List<Purchase> ListPurchases();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Purchase LookupPurchase(Guid purchaseIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Response DeletePurchase(Guid purchaseIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract] Response InsertPurchase(Purchase purchaseInformation);

        /*-------------------------------------------------------------------+
         | ORDERS                                                            |
         +-------------------------------------------------------------------*/

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract] List<Order> ListOrders();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Order LookupOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Response CancelOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Response DeleteOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        [OperationContract] Response DispatchOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract] Response InsertOrder(Order orderInformation);
    }
}