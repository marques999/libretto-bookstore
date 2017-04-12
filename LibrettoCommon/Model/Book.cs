using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class Book
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
        [DataMember, XmlElement("Title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("Price")]
        public double Price
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("Stock")]
        public int Stock
        {
            get;
            set;
        }
    }
}