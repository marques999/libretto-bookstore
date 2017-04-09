using System;
using System.Runtime.Serialization;
using Libretto.Enums;

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
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public OrderState State
        {
            get;
            set;
        } = new WaitingExpedition();

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid Customer
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Book Book
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