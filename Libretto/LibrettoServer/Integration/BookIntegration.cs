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
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public bool InsertBook(Book bookInformation)
        {
            using (var sqlCommand = Query(SqliteCommands.InsertBook))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookInformation.Identifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Title, bookInformation.Title);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Price, bookInformation.Price);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Stock, bookInformation.Stock);

                if (sqlCommand.ExecuteNonQuery() <= 0)
                {
                    return false;
                }

                _books.Add(bookInformation.Identifier, new Book
                {
                    Identifier = bookInformation.Identifier,
                    Title = bookInformation.Title,
                    Price = bookInformation.Price,
                    Stock = bookInformation.Stock
                });
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookInformation"></param>
        /// <returns></returns>
        public bool UpdateBook(Book bookInformation)
        {
            using (var sqlCommand = Query(SqliteCommands.UpdatePrice))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookInformation.Identifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Title, bookInformation.Title);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Price, bookInformation.Price);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Stock, bookInformation.Stock);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    _books.Remove(bookInformation.Identifier);
                    _books.Add(bookInformation.Identifier, bookInformation);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public bool DeleteBook(Guid bookIdentifier)
        {
            var bookInformation = LookupBook(bookIdentifier);

            if (bookInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteBook))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, bookInformation.Identifier);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    _books.Remove(bookIdentifier);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}