using System;
using System.Collections.Generic;

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
        public event TransactionHandler OnRefresh;

        /// <summary>
        /// 
        /// </summary>
        public void Refresh(List<WarehouseOrder> transactionInformation)
        {
            OnRefresh?.Invoke(transactionInformation);
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