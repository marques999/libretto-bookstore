using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace Libretto.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class BookIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public BookIntegration(LibrettoDatabase sqlContext)
        {
            _context = sqlContext;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count()
        {
            return _context.Books.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Book> List()
        {
            return _context.Books.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book Lookup(Guid bookIdentifier)
        {
            return _context.Books.FirstOrDefault(bookInformation => bookInformation.Id == bookIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public bool Insert(Book bookInformation)
        {
            try
            {
                _context.Books.Add(bookInformation);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public bool Update(Book bookInformation)
        {
            var sqlEntity = _context.Books.SingleOrDefault(previousBook => previousBook.Id == bookInformation.Id);

            if (sqlEntity == null)
            {
                return false;
            }

            try
            {
                sqlEntity.Price = bookInformation.Price;
                sqlEntity.Stock = bookInformation.Stock;
                sqlEntity.Title = bookInformation.Title;
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public bool Delete(Guid bookIdentifier)
        {
            var sqlEntity = _context.Books.SingleOrDefault(bookInformation => bookInformation.Id == bookIdentifier);

            if (sqlEntity == null)
            {
                return false;
            }

            try
            {
                _context.Books.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}