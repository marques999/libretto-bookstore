using System;
using System.Collections.Generic;

using Libretto.Database;
using Libretto.Model;

namespace Libretto.Integration
{
    /// <summary>
    /// 
    /// </summary>
    internal class BookIntegration : SqliteDatabase
    {
        /// <summary>
        ///
        /// </summary>
        public BookIntegration()
        {
            _books = ListBooks();
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Guid, Book> _books;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Book> ListBooks()
        {
            var customerList = new Dictionary<Guid, Book>();

            using (var sqlReader = Query(SqliteCommands.ListCustomer).ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    customerList.Add(sqlReader.GetGuid(0), new Book
                    {
                        Identifier = ReadGuid(sqlReader, SqliteColumns.Identifier),
                        Title = ReadString(sqlReader, SqliteColumns.Title),
                        Price = ReadFloat(sqlReader, SqliteColumns.Price),
                        Stock = ReadInteger(sqlReader, SqliteColumns.Stock)
                    });
                }
            }

            return customerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book LookupBook(Guid bookIdentifier)
        {
            return _books.ContainsKey(bookIdentifier) == false ? null : _books[bookIdentifier];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="bookRegistration"></param>
        /// <returns></returns>
        public bool InsertCustomer(Guid bookIdentifier, Book bookRegistration)
        {
            bool operationResult;

            using (var myCommand = Query(SqliteCommands.InsertBook))
            {
                myCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookIdentifier);
                myCommand.Parameters.AddWithValue(SqliteParameters.Title, bookRegistration.Title);
                myCommand.Parameters.AddWithValue(SqliteParameters.Price, bookRegistration.Price);
                myCommand.Parameters.AddWithValue(SqliteParameters.Stock, bookRegistration.Stock);
                operationResult = myCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _books.Add(bookIdentifier, new Book
                {
                    Identifier = bookIdentifier,
                    Title = bookRegistration.Title,
                    Price = bookRegistration.Price,
                    Stock = bookRegistration.Stock
                });
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="bookPrice"></param>
        /// <returns></returns>
        public bool UpdatePrice(Guid bookIdentifier, double bookPrice)
        {
            bool operationResult;
            var bookInformation = LookupBook(bookIdentifier);

            if (bookInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.UpdatePrice))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookIdentifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Price, bookPrice);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                bookInformation.Price = bookPrice;
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="bookQuantity"></param>
        /// <returns></returns>
        public bool UpdateStock(Guid bookIdentifier, int bookQuantity)
        {
            bool operationResult;
            var bookInformation = LookupBook(bookIdentifier);

            if (bookInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.UpdateStock))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookIdentifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Stock, bookQuantity);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                bookInformation.Stock = bookQuantity;
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public bool DeleteBook(Guid bookIdentifier)
        {
            bool operationResult;
            var bookInformation = LookupBook(bookIdentifier);

            if (bookInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteBook))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookInformation.Identifier);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _books.Remove(bookIdentifier);
            }

            return operationResult;
        }
    }
}