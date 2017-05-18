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
        /// <param name="orderQuantity"></param>
        /// <param name="orderTotal"></param>
        /// <returns></returns>
        public WarehouseOrder Update(Guid transactionIdentifier, int orderQuantity, double orderTotal)
        {
            var transactionInformation = Orders.Find(orderInformation => orderInformation.Identifier == transactionIdentifier);

            if (transactionInformation == null)
            {
                return null;
            }

            transactionInformation.Total = orderTotal;
            transactionInformation.Quantity = orderQuantity;
            transactionInformation.DateModified = DateTime.Now;

            return transactionInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public bool Delete(Guid transactionIdentifier)
        {
            return Orders.RemoveAll(orderInformation => orderInformation.Identifier == transactionIdentifier) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        /// <param name="fileName"></param>
        public void Serialize(XmlSerializer xmlSerializer, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}