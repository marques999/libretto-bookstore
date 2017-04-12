using System;
using System.Xml.Serialization;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class SerializableBook
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Key")]
        public Guid Key
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Value")]
        public Book Value
        {
            get;
            set;
        }
    }
}