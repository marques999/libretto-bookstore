using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [KnownType(typeof(Order))]
    [KnownType(typeof(Purchase))]
    public abstract class Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public Guid Id
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public Guid BookId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public string BookTitle
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public Guid CustomerId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
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
        [NotMapped]
        public abstract string Description
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitingChecked"></param>
        /// <param name="processingChecked"></param>
        /// <param name="dispatchedChecked"></param>
        /// <returns></returns>
        public abstract bool Filter(bool waitingChecked, bool processingChecked, bool dispatchedChecked);
    }
}