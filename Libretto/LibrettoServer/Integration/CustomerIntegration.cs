using System;
using System.Collections.Generic;

using Libretto.Database;
using Libretto.Model;
using Libretto.Tools;

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
                while (sqlReader.Read())
                {
                    customerList.Add(sqlReader.GetGuid(0), new Customer
                    {
                        Identifier = ReadGuid(sqlReader, SqliteColumns.Identifier),
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
        /// <param name="customerIdentifier"></param>
        /// <param name="customerForm"></param>
        /// <returns></returns>
        public bool InsertCustomer(Guid customerIdentifier, CustomerForm customerForm)
        {
            bool operationResult;

            using (var myCommand = Query(SqliteCommands.InsertCustomer))
            {
                myCommand.Parameters.AddWithValue(SqliteParameters.Identifier, customerIdentifier);
                myCommand.Parameters.AddWithValue(SqliteParameters.Username, customerForm.Name);
                myCommand.Parameters.AddWithValue(SqliteParameters.Email, customerForm.Email);
                myCommand.Parameters.AddWithValue(SqliteParameters.Location, customerForm.Location);
                myCommand.Parameters.AddWithValue(SqliteParameters.Password, PasswordUtilities.Hash(customerForm.Password));
                operationResult = myCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _customers.Add(customerIdentifier, new Customer
                {
                    Identifier = customerIdentifier,
                    Name = customerForm.Name,
                    Email = customerForm.Email,
                    Location = customerForm.Location
                });
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public bool DeleteCustomer(Guid customerIdentifier)
        {
            bool operationResult;
            var customerInformation = LookupCustomer(customerIdentifier);

            if (customerInformation == null)
            {
                return false;
            }

            using (var sqlCommand = Query(SqliteCommands.DeleteCustomer))
            {
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, customerInformation.Identifier);
                operationResult = sqlCommand.ExecuteNonQuery() > 0;
            }

            if (operationResult)
            {
                _customers.Remove(customerIdentifier);
            }

            return operationResult;
        }
    }
}