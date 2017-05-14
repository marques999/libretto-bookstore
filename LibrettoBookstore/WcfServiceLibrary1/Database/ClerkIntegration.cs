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
            try
            {
                return _context.Customers.Count();
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Clerk> List()
        {
            try
            {
                return _context.Clerks.ToList();
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
        public Clerk Lookup(Guid customerIdentifier)
        {
            try
            {
                return _context.Clerks.SingleOrDefault(customerInformation => customerInformation.Id == customerIdentifier);
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
        public Response Insert(Clerk customerInformation)
        {
            try
            {
                customerInformation.Permissions = Permissions.Clerk;
                _context.Clerks.Add(customerInformation);
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
        public Response Update(Clerk customerInformation)
        {
            var sqlEntity = _context.Clerks.SingleOrDefault(previousCustomer => previousCustomer.Id == customerInformation.Id);

            if (sqlEntity == null)
            {
                return Response.NotFound;
            }

            sqlEntity.Name = customerInformation.Name;
            sqlEntity.Email = customerInformation.Email;

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