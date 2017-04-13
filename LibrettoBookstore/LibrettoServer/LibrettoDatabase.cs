using Libretto.Model;

namespace Libretto
{
    using System.Data.Entity;

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
    }
}