using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable, Table("Book")]
    public class Book
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required, XmlElement("Identifier")]
        public Guid Id
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required, XmlElement("Title")]
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