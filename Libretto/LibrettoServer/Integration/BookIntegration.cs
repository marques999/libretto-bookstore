using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
        public BookIntegration(SqlConnection sqlConnection) : base(sqlConnection)
        {
            Books = ListBooks();
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, Book> Books
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Dictionary<Guid, Book> ListBooks()
        {
            var bookList = new Dictionary<Guid, Book>();

            using (var sqlReader = Query(SqliteCommands.ListBook).ExecuteReader())
            {
                if (sqlReader.HasRows == false)
                {
                    return bookList;
                }

                while (sqlReader.Read())
                {
                    var customerIdentifier = ReadGuid(sqlReader, SqliteColumns.Identifier);

                    bookList.Add(customerIdentifier, new Book
                    {
                        Identifier = customerIdentifier,
                        Title = ReadString(sqlReader, SqliteColumns.Title),
                        Price = ReadFloat(sqlReader, SqliteColumns.Price),
                        Stock = ReadInteger(sqlReader, SqliteColumns.Stock)
                    });
                }
            }

            return bookList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <returns></returns>
        public Book LookupBook(Guid bookIdentifier)
        {
            return Books.TryGetValue(bookIdentifier, out Book bookInformation) ? bookInformation : null;
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

                Books.Add(bookInformation.Identifier, new Book
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
                    Books.Remove(bookInformation.Identifier);
                    Books.Add(bookInformation.Identifier, bookInformation);
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
                    Books.Remove(bookIdentifier);
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