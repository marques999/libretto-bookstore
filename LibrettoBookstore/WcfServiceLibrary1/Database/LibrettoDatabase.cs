using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceModel;
using Libretto.Model;
using LibrettoWCF.Properties;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    public class LibrettoDatabase : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public LibrettoDatabase() : base("name=LibrettoDatabase")
        {
        }

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
        public virtual DbSet<Customer> Customers
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
        public virtual DbSet<Order> Orders
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
            modelBuilder.Entity<Customer>().Property(e => e.Name).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Email).IsUnicode(false);
            modelBuilder.Entity<Customer>().Property(e => e.Location).IsUnicode(false);
            modelBuilder.Entity<Purchase>().Property(e => e.BookTitle).IsFixedLength();
            modelBuilder.Entity<Purchase>().Property(e => e.CustomerName).IsFixedLength();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseDirectory"></param>
        public void CreateDatabase(string baseDirectory)
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
                catch (Exception ex)
                {
                    Debug.Print(ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WebstoreService)))
            {
                host.Open();
                Console.WriteLine(@"WebstoreService ready. Press any key to close.");
                Console.ReadKey(true);
                host.Close();
            }
        }
    }
}