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
            UPDATE Order SET
            status=@status,
            execution_date=@execution_date
            WHERE id=@id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DispatchOrder = @"
            UPDATE Order SET
            status=@status,
            dispatch_date=@dispatch_date
            WHERE id=@id";

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
            INSERT INTO Customers(id, username, email, address)
            VALUES(@id, @username, @email, @address)";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string InsertOrder = @"
            INSERT INTO Books(id, customer, quantity, timestamp, total, status)
            VALUES(@id, @customer, @quantity, @timestamp, @total, @status)";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListBook = "SELECT * FROM Book";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListCustomer = "SELECT * FROM Customer";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ListOrder = "SELECT * FROM Order WHERE id=@id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteBook = "DELETE FROM Book WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteCustomer = "DELETE From Customer WHERE id = @id";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DeleteOrder = "DELETE FROM Order WHERE id = @id";
    }
}