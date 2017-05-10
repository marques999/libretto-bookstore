using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace Libretto.Database
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
            return _context.Customers.Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customer> List()
        {
            return _context.Customers.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Customer Lookup(Guid customerIdentifier)
        {
            return _context.Customers.FirstOrDefault(customerInformation => customerInformation.Id == customerIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public bool Insert(Customer customerInformation)
        {
            try
            {
                _context.Customers.Add(customerInformation);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public bool Update(Customer customerInformation)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(previousCustomer => previousCustomer.Id == customerInformation.Id);

            if (sqlEntity == null)
            {
                return false;
            }

            try
            {
                sqlEntity.Name = customerInformation.Name;
                sqlEntity.Email = customerInformation.Email;
                sqlEntity.Location = customerInformation.Location;
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public bool Delete(Guid customerIdentifier)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);

            if (sqlEntity == null)
            {
                return false;
            }

            try
            {
                _context.Customers.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}