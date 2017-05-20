using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

using Libretto.Model;
using Libretto.Properties;
using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseRemoting : MarshalByRefObject, IWarehouseRemoting
    {
        /// <summary>
        /// 
        /// </summary>
        public event WarehouseDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        public event WarehouseUpsertHandler OnUpsert;

        /// <summary>
        /// 
        /// </summary>
        private readonly IBookstoreRemoting _bookstore;

        /// <summary>
        /// 
        /// </summary>
        public WarehouseRemoting()
        {
            WarehouseLogger.LogMessage(Resources.RemotingEstablish, nameof(IBookstoreRemoting), WarehouseCommon.BookstoreAddress);
            _bookstore = (IBookstoreRemoting)RemotingServices.Connect(typeof(IBookstoreRemoting), WarehouseCommon.BookstoreAddress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        public void InvokeDelete(Guid orderIdentifier)
        {
            OnDelete?.Invoke(orderIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void InvokeUpsert(WarehouseOrder warehouseOrder)
        {
            OnUpsert?.Invoke(warehouseOrder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<WarehouseOrder> ListOrders()
        {
            return WarehouseServer.ListOrders();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <returns></returns>
        public bool DispatchOrder(Guid orderIdentifier)
        {
            try
            {
                WarehouseLogger.LogMessage(Resources.RemotingDispatchOrder, orderIdentifier);

                if (_bookstore.DispatchOrder(orderIdentifier) != Response.Success)
                {
                    return false;
                }

                WarehouseServer.DeleteOrder(orderIdentifier);

                return true;
            }
            catch (Exception ex)
            {
                WarehouseLogger.LogException(ex);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}