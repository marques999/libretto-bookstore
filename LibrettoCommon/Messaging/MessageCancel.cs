﻿using System;
using System.Xml.Serialization;

namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class MessageCancel : IMessage
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
        /// <param name="messageVisitor"></param>
        public void Process(IMessageVisitor messageVisitor)
        {
            messageVisitor.CancelOrder(this);
        }
    }
}