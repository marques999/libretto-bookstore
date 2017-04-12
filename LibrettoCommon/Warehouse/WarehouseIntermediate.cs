using System;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public class WarehouseIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event RefreshHandler OnRefreshBooks;

        /// <summary>
        /// 
        /// </summary>
        public event RefreshHandler OnRefreshOrders;

        /// <summary>
        /// 
        /// </summary>
        public void RefreshBooks()
        {
            OnRefreshBooks?.Invoke();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RefreshOrders()
        {
            OnRefreshOrders?.Invoke();
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