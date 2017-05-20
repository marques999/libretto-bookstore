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
        void CancelOrder(Guid orderIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        [OperationContract(IsOneWay = true)]
        void InsertOrder(WarehouseOrder warehouseOrder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderIdentifier"></param>
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        [OperationContract(IsOneWay = true)]
        void UpdateOrder(Guid orderIdentifier, int orderQuantity, double orderTotal);
    }
}