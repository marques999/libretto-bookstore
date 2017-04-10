using System;
using System.Collections.Generic;

using Libretto.Database;
using Libretto.Model;

namespace Libretto.Integration
{
    /// <summary>
    /// 
    /// </summary>
    internal class OrderIntegration : SqliteDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderIntegration()
        {
            _transactions = ListOrders();
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Guid, Transaction> _transactions;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Transaction> ListOrders()
        {
            var transactionsList = new Dictionary<Guid, Transaction>();

            using (var sqlReader = Query(SqliteCommands.ListOrder).ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    var transactionType = ReadType(sqlReader, SqliteColumns.Type);

                    if (transactionType == TransactionType.Order)
                    {
                        transactionsList.Add(sqlReader.GetGuid(0), new Order
                        {
                            Identifier = ReadGuid(sqlReader, SqliteColumns.Identifier),
                            BookId = ReadGuid(sqlReader, SqliteColumns.BookId),
                            BookName = ReadString(sqlReader, SqliteColumns.BookName),
                            CustomerId = ReadGuid(sqlReader, SqliteColumns.CustomerId),
                            CustomerName = ReadString(sqlReader, SqliteColumns.CustomerName),
                            Quantity = ReadInteger(sqlReader, SqliteColumns.Quantity),
                            Timestamp = ReadTimestamp(sqlReader, SqliteColumns.Timestamp),
                            Total = ReadFloat(sqlReader, SqliteColumns.Total),
                            Status = ReadStatus(sqlReader, SqliteColumns.Status),
                            StatusDate = ReadTimestamp(sqlReader, SqliteColumns.StatusDate)
                        });
                    }
                    else
                    {
                        transactionsList.Add(sqlReader.GetGuid(0), new Purchase
                        {
                            Identifier = ReadGuid(sqlReader, SqliteColumns.Identifier),
                            BookId = ReadGuid(sqlReader, SqliteColumns.BookId),
                            BookName = ReadString(sqlReader, SqliteColumns.BookName),
                            CustomerId = ReadGuid(sqlReader, SqliteColumns.CustomerId),
                            CustomerName = ReadString(sqlReader, SqliteColumns.CustomerName),
                            Quantity = ReadInteger(sqlReader, SqliteColumns.Quantity),
                            Timestamp = ReadTimestamp(sqlReader, SqliteColumns.Timestamp),
                            Total = ReadFloat(sqlReader, SqliteColumns.Total),
                            Status = ReadStatus(sqlReader, SqliteColumns.Status)
                        });
                    }
                }
            }

            return transactionsList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Transaction LookupTransaction(Guid customerIdentifier)
        {
            return _transactions.ContainsKey(customerIdentifier) == false ? null : _transactions[customerIdentifier];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        /// <returns></returns>
        public bool RegisterTransaction(Transaction transactionInformation)
        {
            using (var sqlCommand = Query(SqliteCommands.InsertOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Type, transactionInformation.Type);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Total, transactionInformation.Total);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.BookId, transactionInformation.BookId);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, transactionInformation.Status);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Quantity, transactionInformation.Quantity);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Timestamp, transactionInformation.Timestamp);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.CustomerId, transactionInformation.CustomerId);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, transactionInformation.Identifier);

                var orderInformation = transactionInformation as Order;

                if (orderInformation != null)
                {
                    sqlCommand.Parameters.AddWithValue(SqliteParameters.StatusDate, orderInformation.StatusDate);
                }

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    _transactions.Add(transactionInformation.Identifier, transactionInformation);
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
        /// <param name="transactionGuid"></param>
        /// <param name="transactionTimestamp"></param>
        public bool DispatchOrder(Guid transactionGuid, DateTime transactionTimestamp)
        {
            var orderInformation = LookupTransaction(transactionGuid) as Order;

            if (orderInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DispatchOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, transactionGuid);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, Status.WaitingDispatch);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.StatusDate, transactionTimestamp);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    orderInformation.Status = Status.WaitingDispatch;
                    orderInformation.StatusDate = DateTime.Now;
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
        /// <param name="transactionGuid"></param>
        /// <param name="transactionTimestamp"></param>
        public bool ExecuteOrder(Guid transactionGuid, DateTime transactionTimestamp)
        {
            var transactionInformation = LookupTransaction(transactionGuid) as Order;

            if (transactionInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.ExecuteOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, transactionGuid);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, Status.DispatchComplete);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.ExecutionDate, transactionTimestamp);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    transactionInformation.Status = Status.DispatchComplete;
                    transactionInformation.StatusDate = DateTime.Now;
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
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public bool DeleteTransaction(Guid transactionIdentifier)
        {
            var transactionInformation = LookupTransaction(transactionIdentifier);

            if (transactionInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteTransaction))
            {
                sqlCommand.Parameters.AddWithValue(SqliteColumns.Identifier, transactionInformation.Identifier);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    _transactions.Remove(transactionIdentifier);
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