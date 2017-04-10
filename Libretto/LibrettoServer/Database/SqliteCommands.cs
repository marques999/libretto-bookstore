namespace Libretto.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class SqliteCommands
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ExecuteOrder = @"
            UPDATE Transactions SET
            status = @status,
            execution_date = @execution_date
            WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DispatchOrder = @"
            UPDATE Transactions SET
            status = @status,
            dispatch_date = @dispatch_date
            WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string UpdateBoook = @"
            UPDATE Books SET
            title = @title
            price = @price
            stock = @stock
            WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string UpdatePrice = @"UPDATE Books SET price = @price WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string UpdateStock = @"UPDATE Books SET stock = @stock WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string InsertBook = @"
            INSERT INTO Books(id, title, price, stock)
            VALUES(@id, @title, @price, @stock";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string InsertCustomer = @"
            INSERT INTO Customers(id, name, email, location)
            VALUES(@id, @name, @email, @location)";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string InsertOrder = @"
            INSERT INTO Transactions(id, type, book_id, customer_id, quantity, timestamp, total, status)
            VALUES(@id, @type, @book_id, @customer_id, @quantity, @timestamp, @total, @status)";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListBook = "SELECT * FROM Books ORDER BY Title";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListCustomer = "SELECT * FROM Customers ORDER BY Name";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListOrder = "SELECT * FROM Transactions";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteBook = "DELETE FROM Books WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteCustomer = "DELETE From Customers WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteTransaction = "DELETE FROM Transactions WHERE id = @id";
    }
}