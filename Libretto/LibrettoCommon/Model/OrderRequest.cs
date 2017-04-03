using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class OrderRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderRequest() : this(null, 0)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestedItem"></param>
        /// <param name="requestedQuantity"></param>
        public OrderRequest(Book requestedItem, int requestedQuantity)
        {
            Item = requestedItem;
            Quantity = requestedQuantity + 10;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Book Item
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Quantity
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime Timestamp
        {
            get;
        } = DateTime.Now;
    }
}