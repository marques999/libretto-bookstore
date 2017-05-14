using System;
using System.Collections.Generic;
using System.Linq;

using Libretto.Model;

namespace LibrettoWCF.Database
{
    /// <summary>
    /// 
    /// </summary>
    internal class ClerkIntegration
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly LibrettoDatabase _context;

        /// <summary>
        ///
        /// </summary>
        public ClerkIntegration(LibrettoDatabase sqlContext)
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
        public List<Clerk> List()
        {
            return _context.Clerks.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public Clerk Lookup(Guid customerIdentifier)
        {
            return _context.Clerks.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerEmail"></param>
        /// <returns></returns>
        public Clerk LookupByEmail(string customerEmail)
        {
            try
            {
                return _context.Clerks.SingleOrDefault(customerInformation => customerInformation.Email == customerEmail);
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
        public string Insert(Clerk customerInformation)
        {
            try
            {
                _context.Clerks.Add(customerInformation);
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
        public List<Clerk> Update(Clerk customerInformation)
        {
            var sqlEntity = _context.Clerks.SingleOrDefault(previousCustomer => previousCustomer.Id == customerInformation.Id);

            if (sqlEntity == null)
            {
                return null;
            }

            try
            {
                sqlEntity.Name = customerInformation.Name;
                sqlEntity.Email = customerInformation.Email;
                _context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return _context.Clerks.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerIdentifier"></param>
        /// <returns></returns>
        public List<Clerk> Delete(Guid customerIdentifier)
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

            return _context.Clerks.ToList();
        }
    }
}