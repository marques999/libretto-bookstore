using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Libretto.Model;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
public class WebstoreService : WCFService.InterfaceProvider
    {
    public List<Book> AddBook(Book book)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        try
        {
            db.Books.Add(book);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }
        return db.Books.ToList();
    }

    public List<Customer> AddCustomer(Customer customer)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        try
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }
        return db.Customers.ToList();
    }

    public List<Purchase> AddPurchase(Purchase purchase)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        try
        {
            db.Purchases.Add(purchase);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }
        return db.Purchases.ToList();
    }

    public List<Book> DeleteBook(Book book)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Books.SingleOrDefault(bookInformation => bookInformation.Id == book.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            db.Books.Remove(sqlEntity);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Books.ToList();
    }

    public List<Customer> DeleteCustomer(Customer customer)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customer.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            db.Customers.Remove(sqlEntity);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Customers.ToList();
    }

    public List<Purchase> DeletePurchase(Purchase purchase)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id == purchase.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            db.Purchases.Remove(sqlEntity);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Purchases.ToList();
    }

    public Book GetBookById(string id)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Books.SingleOrDefault(bookInformation => bookInformation.Id.ToString() == id);
    }

    public List<Book> GetBooksList()
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Books.ToList();
    }

    public Customer GetCustomerById(string id)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Customers.SingleOrDefault(customerInformation => customerInformation.Id.ToString() == id);
    }

    public List<Customer> GetCustomersList()
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Customers.ToList();
    }

    public Purchase GetPurchaseById(string id)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Purchases.SingleOrDefault(purchaseInformation => purchaseInformation.Id.ToString() == id);
    }

    public List<Purchase> GetPurchasesList()
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Purchases.ToList();
    }

    public List<Customer> UpdateCustomer(Customer customer)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Customers.SingleOrDefault(previousCustomer => previousCustomer.Id == customer.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            sqlEntity.Email = customer.Email;
            sqlEntity.Name = customer.Name;
            sqlEntity.Location = customer.Location;
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Customers.ToList();
    }

    public List<Purchase> UpdatePurchase(Purchase purchase)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Purchases.SingleOrDefault(previousPurchase => previousPurchase.Id == purchase.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            sqlEntity.Quantity = purchase.Quantity;
            sqlEntity.Timestamp = purchase.Timestamp;
            sqlEntity.Total = purchase.Total;
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Purchases.ToList();
    }

    public List<Book> UpdateBook(Book book)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Books.SingleOrDefault(previousBook => previousBook.Id == book.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            sqlEntity.Price = book.Price;
            sqlEntity.Stock = book.Stock;
            sqlEntity.Title = book.Title;
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Books.ToList();
    }

    public List<Order> GetOrdersList()
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Orders.ToList();
    }

    public Order GetOrderById(string id)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        return db.Orders.SingleOrDefault(bookInformation => bookInformation.Id.ToString() == id);
    }

    public List<Order> AddOrder(Order order)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        try
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }
        return db.Orders.ToList();
    }

    public List<Order> DeleteOrder(Order order)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Orders.SingleOrDefault(orderInformation => orderInformation.Id == order.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            db.Orders.Remove(sqlEntity);
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Orders.ToList();
    }

    public List<Order> UpdateOrder(Order order)
    {
        LibrettoWCF.LibrettoDatabase db = new LibrettoWCF.LibrettoDatabase();

        var sqlEntity = db.Orders.SingleOrDefault(previousOrder => previousOrder.Id == order.Id);

        if (sqlEntity == null)
        {
            return null;
        }

        try
        {
            sqlEntity.Quantity = order.Quantity;
            sqlEntity.Timestamp = order.Timestamp;
            sqlEntity.Total = order.Total;
            db.SaveChanges();
        }
        catch
        {
            return null;
        }

        return db.Orders.ToList();
    }
}

