using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlRoot("Warehouse")]
    public class WarehouseOrders : SerializableClass
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlArray("OrderList")]
        [XmlArrayItem("Order", typeof(Order))]
        public List<Order> Orders
        {
            get;
        } = new List<Order>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Order this[int key]
        {
            get => Orders[key];
            set => Orders[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        public void Insert(Order transactionInformation)
        {
            Orders.Add(transactionInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        public int IndexOf(Guid transactionIdentifier)
        {
            return Orders.FindIndex(orderInformation => orderInformation.Identifier == transactionIdentifier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        /// <param name="transactionStatus"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        public bool Update(Guid transactionIdentifier, Status transactionStatus, DateTime transactionTimestamp)
        {
            var transactionInformation = Orders.Find(orderInformation => orderInformation.Identifier == transactionIdentifier);

            if (transactionInformation == null || transactionInformation.Status == transactionStatus)
            {
                return false;
            }

            transactionInformation.Status = transactionStatus;
            transactionInformation.StatusDate = transactionTimestamp;

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        public bool Delete(Guid transactionIdentifier)
        {
            return Orders.RemoveAll(orderInformation => orderInformation.Identifier == transactionIdentifier) > 0;
        }
    }
}