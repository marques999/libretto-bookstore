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
            return _context.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);
        }

        public Customer LookupEmail(string email)
        {
            return _context.Customers.SingleOrDefault(customerInformation => customerInformation.Email == email);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public string Insert(Customer customerInformation)
        {
            try
            {
                _context.Customers.Add(customerInformation);
                _context.SaveChanges();
            }
            catch
            {
                return "ERROR!";
            }

            return "Ok";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerInformation"></param>
        /// <returns></returns>
        public List<Customer> Update(Customer customerInformation)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(previousCustomer => previousCustomer.Id == customerInformation.Id);

            if (sqlEntity == null)
            {
                return null;
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
                return null;
            }

            return _context.Customers.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public List<Customer> Delete(Guid customerIdentifier)
        {
            var sqlEntity = _context.Customers.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                _context.Customers.Remove(sqlEntity);
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Customers.ToList();
        }
    }
}