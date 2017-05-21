using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

using LibrettoWCF.Tools;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class CustomerIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public CustomerIntegration(LibrettoDatabase sqlContext)
        {
            _context = sqlContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> List()
        {
            try
            {
                return _context.Customers.ToList();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer Lookup(Guid customerIdentifier)
        {
            try
            {
                return _context.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public Customer LookupByEmail(string customerEmail)
        {
            try
            {
                return string.IsNullOrEmpty(customerEmail) ? null : _context.Customers.SingleOrDefault(customerInformation => customerInformation.Email == customerEmail);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response Insert(Customer customerInformation)
        {
            try
            {
                if (customerInformation == null)
                {
                    return Response.InvalidArguments;
                }

                if (string.IsNullOrEmpty(customerInformation.Password) == false)
                {
                    customerInformation.Password = PasswordUtilities.Hash(customerInformation.Password);
                }

                _context.Customers.Add(customerInformation);
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