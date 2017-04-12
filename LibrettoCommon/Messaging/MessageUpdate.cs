using System;
using System.Xml.Serialization;

using Libretto.Model;

namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MessageUpdate : IMessageSubject
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
        [XmlElement("Status")]
        public Status Status
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Timestamp")]
        public DateTime Timestamp
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageVisitor"></param>
        public void Process(IMessageVisitor messageVisitor)
        {
            messageVisitor.UpdateOrder(this);
        }
    }
}