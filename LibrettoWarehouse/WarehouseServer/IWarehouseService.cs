using System;
using System.ServiceModel;

using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IWarehouseService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        [OperationContract(IsOneWay = true)]
        void DeleteOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        [OperationContract(IsOneWay = true)]
        void InsertOrder(WarehouseOrder warehouseOrder);
    }
}