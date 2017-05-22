using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace LibrettoWCF.Database
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
        /// <returns></returns>
        public List<Book> List()
        {
            try
            {
                return _context.Books.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book Lookup(Guid bookIdentifier)
        {
            try
            {
                return _context.Books.SingleOrDefault(bookInformation => bookInformation.Id == bookIdentifier);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response Insert(Book bookInformation)
        {
            try
            {
                if (bookInformation == null)
                {
                    return Response.InvalidArguments;
                }

                _context.Books.Add(bookInformation);
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public Response UpdateStock(Guid bookIdentifier, int quantity)
        {
            try
            {
                var bookInformation = _context.Books.SingleOrDefault(bookInfo => bookInfo.Id == bookIdentifier);

                if (bookInformation == null)
                {
                    return Response.Success;
                }

                bookInformation.Stock += quantity;
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public Response Update(Book bookInformation)
        {
            try
            {
                if (bookInformation == null)
                {
                    return Response.InvalidArguments;
                }

                var sqlEntity = _context.Books.SingleOrDefault(previousBook => previousBook.Id == bookInformation.Id);

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                sqlEntity.Price = bookInformation.Price;
                sqlEntity.Stock = bookInformation.Stock;
                sqlEntity.Title = bookInformation.Title;
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Response Delete(Guid bookIdentifier)
        {
            try
            {
                var sqlEntity = _context.Books.SingleOrDefault(bookInformation => bookInformation.Id == bookIdentifier);

                System.Diagnostics.Debug.Print(bookIdentifier.ToString("B"));

                if (sqlEntity == null)
                {
                    return Response.NotFound;
                }

                _context.Books.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return Response.DatabaseError;
            }

            return Response.Success;
        }
    }
}