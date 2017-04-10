using System;
using System.Collections.Generic;
using System.Data;

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
            _orders = ListOrders();
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Guid, Order> _orders;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Order> ListOrders()
        {
            var ordersList = new Dictionary<Guid, Order>();

            using (var sqlReader = Query(SqliteCommands.ListOrder).ExecuteReader())
            {
                while (sqlReader.Read())
                {
                    ordersList.Add(sqlReader.GetGuid(0), new Order
                    {
                        Identifier = ReadGuid(sqlReader, SqliteColumns.Identifier),
                        CustomerId = ReadGuid(sqlReader, SqliteColumns.Customer),
                        Quantity = ReadInteger(sqlReader, SqliteColumns.Quantity),
                        Timestamp = ReadTimestamp(sqlReader, SqliteColumns.Timestamp),
                        Total = ReadFloat(sqlReader, SqliteColumns.Total),
                        Status = ReadOrderState(sqlReader)
                    });
                }
            }

            return ordersList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Order LookupOrder(Guid customerIdentifier)
        {
            return _orders.ContainsKey(customerIdentifier) == false ? null : _orders[customerIdentifier];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlReader"></param>
        /// <returns></returns>
        private static OrderState ReadOrderState(IDataRecord sqlReader)
        {
            switch (ReadInteger(sqlReader, SqliteColumns.Status))
            {
                case 0:
                    return new WaitingExpedition();
                case 1:
                    return new DispatchCompleted(sqlReader.GetDateTime(5));
                default:
                    return new DispatchCompleted(sqlReader.GetDateTime(6));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public bool InsertOrder(Guid orderIdentifier, Order orderInformation)
        {
            bool operationResult;

            using (var sqlCommand = Query(SqliteCommands.InsertOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, orderIdentifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Customer, orderInformation.CustomerId);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Quantity, orderInformation.Quantity);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Timestamp, orderInformation.Timestamp);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Total, orderInformation.Total);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, Status.WaitingExpedition);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _orders.Add(orderIdentifier, orderInformation);
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <param name="orderTimestamp"></param>
        public bool DispatchOrder(Guid orderGuid, DateTime orderTimestamp)
        {
            bool operationResult;
            var orderInformation = LookupOrder(orderGuid);

            if (orderInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DispatchOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, orderGuid);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, Status.WaitingDispatch);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.DispatchDate, orderTimestamp);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                orderInformation.Status = new WaitingDispatch(orderTimestamp);
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderGuid"></param>
        /// <param name="orderTimestamp"></param>
        public bool ExecuteOrder(Guid orderGuid, DateTime orderTimestamp)
        {
            bool operationResult;
            var orderInformation = LookupOrder(orderGuid);

            if (orderInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.ExecuteOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, orderGuid);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Status, Status.DispatchComplete);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.ExecutionDate, orderTimestamp);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                orderInformation.Status = new DispatchCompleted(orderTimestamp);
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public bool DeleteOrder(Guid orderIdentifier)
        {
            bool operationResult;
            var orderInformation = LookupOrder(orderIdentifier);

            if (orderInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteOrder))
            {
                sqlCommand.Parameters.AddWithValue(SqliteColumns.Identifier, orderInformation.Identifier);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _orders.Remove(orderIdentifier);
            }

            return operationResult;
        }
    }
}