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
    internal class CustomerIntegration : SqliteDatabase
    {
        /// <summary>
        ///
        /// </summary>
        public CustomerIntegration(SqlConnection sqlConnection) : base(sqlConnection)
        {
            Customers = ListCustomers();
        }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<Guid, Customer> Customers
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Dictionary<Guid, Customer> ListCustomers()
        {
            var customerList = new Dictionary<Guid, Customer>();

            using (var sqlReader = Query(SqliteCommands.ListCustomer).ExecuteReader())
            {
                if (sqlReader.HasRows == false)
                {
                    return customerList;
                }

                while (sqlReader.Read())
                {
                    var customerIdentifier = ReadGuid(sqlReader, SqliteColumns.Identifier);

                    customerList.Add(customerIdentifier, new Customer
                    {
                        Identifier = customerIdentifier,
                        Name = ReadString(sqlReader, SqliteColumns.Name),
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
            return Customers.TryGetValue(customerIdentifier, out Customer customerInformation) ? customerInformation : null;
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
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Name, customerInformation.Name);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Email, customerInformation.Email);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Location, customerInformation.Location);
                sqlCommand.Parameters.AddWithValue(SqliteParameters.Identifier, customerInformation.Identifier);

                if (sqlCommand.ExecuteNonQuery() <= 0)
                {
                    return false;
                }

                Customers.Add(customerInformation.Identifier, new Customer
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
                    Customers.Remove(customerIdentifier);
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