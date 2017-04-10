using System;
using System.Collections.Generic;

using Libretto.Database;
using Libretto.Model;

namespace Libretto.Integration
{
    /// <summary>
    /// 
    /// </summary>
    internal class CustomerIntegration : SqliteDatabase
    {
        /// <summary>
        ///
        /// </summary>
        public CustomerIntegration()
        {
            _customers = ListCustomers();
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<Guid, Customer> _customers;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<Guid, Customer> ListCustomers()
        {
            var customerList = new Dictionary<Guid, Customer>();

            using (var sqlReader = Query(SqliteCommands.ListCustomer).ExecuteReader())
            {
                var customerIdentifier = ReadGuid(sqlReader, SqliteColumns.Identifier);

                while (sqlReader.Read())
                {
                    customerList.Add(customerIdentifier, new Customer
                    {
                        Identifier = customerIdentifier,
                        Name = ReadString(sqlReader, SqliteColumns.Username),
                        Email = ReadString(sqlReader, SqliteColumns.Email),
                        Location = ReadString(sqlReader, SqliteColumns.Location)
                    });
                }
            }

            return customerList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer LookupCustomer(Guid customerIdentifier)
        {
            return _customers.ContainsKey(customerIdentifier) == false ? null : _customers[customerIdentifier];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public bool InsertCustomer(Customer customerInformation)
        {
            using (var sqlCommand = Query(SqliteCommands.InsertCustomer))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, customerInformation.Identifier);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Name, customerInformation.Name);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Email, customerInformation.Email);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Location, customerInformation.Location);

                if (sqlCommand.ExecuteNonQuery() <= 0)
                {
                    return false;
                }

                _customers.Add(customerInformation.Identifier, new Customer
                {
                    Identifier = customerInformation.Identifier,
                    Name = customerInformation.Name,
                    Email = customerInformation.Email,
                    Location = customerInformation.Location
                });
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public bool DeleteCustomer(Guid customerIdentifier)
        {
            var customerInformation = LookupCustomer(customerIdentifier);

            if (customerInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteCustomer))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, customerInformation.Identifier);

                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    _customers.Remove(customerIdentifier);
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