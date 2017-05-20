using System.Data.Entity;
using System.Data.SqlClient;

using Libretto.Model;

using LibrettoWCF.Properties;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class LibrettoDatabase : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        private LibrettoDatabase() : base("name=LibrettoDatabase")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly LibrettoDatabase Instance = new LibrettoDatabase();

        /// <summary>
        /// 
        /// </summary>
        public static BookIntegration BookIntegration
        {
            get;
        } = new BookIntegration(Instance);

        /// <summary>
        /// 
        /// </summary>
        public static ClerkIntegration ClerkIntegration
        {
            get;
        } = new ClerkIntegration(Instance);

        /// <summary>
        /// 
        /// </summary>
        public static CustomerIntegration CustomerIntegration
        {
            get;
        } = new CustomerIntegration(Instance);

        /// <summary>
        /// 
        /// </summary>
        public static OrderIntegration OrderIntegration
        {
            get;
        } = new OrderIntegration(Instance);

        /// <summary>
        /// 
        /// </summary>
        public static PurchaseIntegration PurchaseIntegration
        {
            get;
        } = new PurchaseIntegration(Instance);

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Book> Books
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Clerk> Clerks
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Customer> Customers
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Order> Orders
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Purchase> Purchases
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(e => e.Title).IsUnicode(false);
            modelBuilder.Entity<Clerk>().Property(e => e.Name).IsUnicode(false);
            modelBuilder.Entity<Clerk>().Property(e => e.Email).IsUnicode(false);
            modelBuilder.Entity<Clerk>().Property(e => e.Password).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Name).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Email).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Password).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Location).IsUnicode(false);
            modelBuilder.Entity<Purchase>().Property(e => e.BookTitle).IsFixedLength();
            modelBuilder.Entity<Purchase>().Property(e => e.CustomerName).IsFixedLength();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDirectory"></param>
        public bool CreateDatabase(string baseDirectory)
        {
            using (var sqlConection = new SqlConnection
            {
                ConnectionString = "SERVER=localhost;DATABASE=master;User ID = sa; Pwd = sa"
            })
            using (var sqlCommand = new SqlCommand(string.Format(Resources.GenerateDatabase, baseDirectory, baseDirectory), sqlConection))
            {
                try
                {
                    sqlConection.Open();
                    sqlCommand.ExecuteNonQuery();
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }
    }
}