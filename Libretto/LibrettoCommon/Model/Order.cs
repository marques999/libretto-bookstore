using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid Identifier
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public OrderStatus Status
        {
            get;
            set;
        } = OrderStatus.WaitingDispatch;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid CustomerId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid BookId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string BookName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime Timestamp
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// /
        /// </summary>
        [DataMember]
        public double Total
        {
            get;
            set;
        }
    }
}