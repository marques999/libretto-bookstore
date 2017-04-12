using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public abstract class Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("Identifier")]
        public Guid Identifier
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("Status")]
        public abstract Status Status
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlIgnore]
        public abstract TransactionType Type
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("BookId")]
        public Guid BookId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("BookName")]
        public string BookName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [XmlElement("CustomerId")]
        public Guid CustomerId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [XmlElement("CustomerName")]
        public string CustomerName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [XmlElement("Timestamp")]
        public DateTime Timestamp
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [XmlElement("Quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// /
        /// </summary>
        [DataMember]
        [XmlElement("Total")]
        public double Total
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public string Description => Status.GetDescription();
    }
}