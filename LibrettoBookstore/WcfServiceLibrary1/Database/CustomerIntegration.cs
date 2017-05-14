using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

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
        public int Count()
        {
            try
            {
                return _context.Customers.Count();
            }
            catch
            {
                return 0;
            }
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
                return _context.Customers.SingleOrDefault(customerInformation => customerInformation.Email == customerEmail);
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
                _context.Customers.Add(customerInformation);
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
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public Response Update(Customer customerInformation)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(previousCustomer => previousCustomer.Id == customerInformation.Id);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            sqlEntity.Name = customerInformation.Name;
            sqlEntity.Email = customerInformation.Email;
            sqlEntity.Location = customerInformation.Location;

            try
            {
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
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Response Delete(Guid customerIdentifier)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            try
            {
                _context.Customers.Remove(sqlEntity);
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