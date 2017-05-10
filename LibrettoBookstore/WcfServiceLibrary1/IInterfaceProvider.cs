using Libretto.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface InterfaceProvider
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "books")]
        List<Libretto.Model.Book> GetBooksList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "book/{id}")]
        Libretto.Model.Book GetBookById(string id);

        [OperationContract]
        [WebInvoke(Method ="POST", 
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/books/addbook")]
        List<Book> AddBook(Book book);
        [OperationContract]
        [WebInvoke(Method = "DELETE", 
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/books/deletebook")]
        List<Book> DeleteBook(Book book);
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/books/updatebook")]
        List<Book> UpdateBook(Book book);


        // ----------------------------------------------------------------------------------------------
        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "customers")]
        List<Customer> GetCustomersList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "customer/{id}")]
        Customer GetCustomerById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/customers/addcustomer")]
        List<Customer> AddCustomer(Customer customer);
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/customers/deletecustomer")]
        List<Customer> DeleteCustomer(Customer customer);
        [OperationContract]
        [WebInvoke(Method = "PUT", 
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/customers/updatecustomer")]
        List<Customer> UpdateCustomer(Customer customer);

        //---------------------------------------------------------------------------------------------------------

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "purchases")]
        List<Purchase> GetPurchasesList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "purchase/{id}")]
        Purchase GetPurchaseById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/purchases/addpurchase")]
        List<Purchase> AddPurchase(Purchase purchase);
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/purchases/deletepurchase")]
        List<Purchase> DeletePurchase(Purchase purchase);
        [OperationContract]
        [WebInvoke(Method = "PUT",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/purchases/updatepurchase")]
        List<Purchase> UpdatePurchase(Purchase purchase);


        //---------------------------------------------------------------------------------------------------------

        [OperationContract]
        [WebInvoke(Method = "GET",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped,
                    UriTemplate = "orders")]
        List<Order> GetOrdersList();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "order/{id}")]
        Order GetOrderById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/orders/addorder")]
        List<Order> AddOrder(Order order);
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/orders/deleteorder")]
        List<Order> DeleteOrder(Order order);
        [OperationContract]
        [WebInvoke(Method = "PUT",
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare,
                    UriTemplate = "/orders/updateorder")]
        List<Order> UpdateOrder(Order order);

    }

    [DataContract]
    public class Texto
    {
        [DataMember]
        public string Title { get; set; }

    }


}
