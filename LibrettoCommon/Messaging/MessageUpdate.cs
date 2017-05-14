using System;
using System.Xml.Serialization;

namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MessageUpdate : IMessage
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
        [XmlElement("Quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Total")]
        public double Total
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