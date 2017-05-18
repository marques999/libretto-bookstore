using System;
using System.Xml.Serialization;

using Libretto.Messaging;
using Libretto.Model;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WarehouseOrder : IMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Identifier")]
        public Guid Identifier
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// /
        /// </summary>
        [XmlElement("Total")]
        public double Total
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("DateCreated")]
        public DateTime DateCreated
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("DateModified")]
        public DateTime DateModified
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageVisitor"></param>
        public void Process(IMessageVisitor messageVisitor)
        {
            messageVisitor.InsertOrder(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderInformation"></param>
        /// <returns></returns>
        public static WarehouseOrder FromOrder(Order orderInformation)
        {
            return new WarehouseOrder
            {
                Total = orderInformation.Total,
                Identifier = orderInformation.Id,
                Title = orderInformation.BookTitle,
                Quantity = orderInformation.Quantity,
                DateCreated = orderInformation.Timestamp,
                DateModified = orderInformation.StatusTimestamp
            };
        }
    }
}