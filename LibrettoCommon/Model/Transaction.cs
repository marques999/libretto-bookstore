using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public abstract class Transaction
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
        public abstract Status Status
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public abstract TransactionType Type
        {
            get;
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
        public string BookTitle
        {
            get;
            set;
        }

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

        /// <summary>
        /// 
        /// </summary>
        public string Description => Status.GetDescription();
    }
}