using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, XmlRoot("Warehouse")]
    public class WarehouseOrders
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlArray("OrderList")]
        [XmlArrayItem("Order", typeof(WarehouseOrder))]
        public List<WarehouseOrder> Orders
        {
            get;
        } = new List<WarehouseOrder>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseOrder"></param>
        public void Insert(WarehouseOrder warehouseOrder)
        {
            Orders.Add(warehouseOrder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public bool Dispatch(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            var transactionInformation = Orders.Find(orderInformation => orderInformation.Identifier == transactionIdentifier);

            if (transactionInformation == null || transactionInformation.Status != WarehouseStatus.Pending)
            {
                return false;
            }

            transactionInformation.Status = WarehouseStatus.Dispatched;
            transactionInformation.DateModified = transactionTimestamp;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public bool Cancel(Guid transactionIdentifier, DateTime transactionTimestamp)
        {
            var transactionInformation = Orders.Find(orderInformation => orderInformation.Identifier == transactionIdentifier);

            if (transactionInformation == null || transactionInformation.Status != WarehouseStatus.Pending)
            {
                return false;
            }

            transactionInformation.Status = WarehouseStatus.Cancelled;
            transactionInformation.DateModified = transactionTimestamp;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        /// <param name="fileName"></param>
        public void Serialize(XmlSerializer xmlSerializer, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}