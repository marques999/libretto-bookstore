using Libretto.Model;
using LibrettoWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LibrettoWCF
{
    [ServiceContract]
    public interface IStoreService
    {

        [OperationContract]
        List<Book> GetBooksList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Book GetBookById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Book> AddBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Book> DeleteBook(Book bookInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Book> UpdateBook(Book bookInformation);

        // ----------------------------------------------------------------------------------------------

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Customer> GetCustomersList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Customer GetCustomerById(string id);

        [OperationContract]
        Customer Login(LoginForm loginForm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        string AddCustomer(Customer customerInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInfromation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Customer> DeleteCustomer(Customer customerInfromation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Customer> UpdateCustomer(Customer customerInformation);

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
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Purchase GetPurchaseById(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract]
        string AddPurchase(PurchaseForm purchaseInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Purchase> DeletePurchase(Purchase purchaseInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Purchase> UpdatePurchase(Purchase purchaseInformation);

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
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Order GetOrderById(string id);

        [OperationContract]
        List<Order> GetOrdersByUser(string id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract]
        string AddOrder(OrderForm orderInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Order> DeleteOrder(OrderId orderInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        [OperationContract]
        List<Order> UpdateOrder(Order orderInformation);
    }
}
