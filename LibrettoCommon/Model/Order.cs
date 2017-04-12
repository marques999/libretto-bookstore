using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using Libretto.Messaging;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Serializable]
    public class Order : Transaction, IMessageSubject
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlIgnore]
        public override Status Status
        {
            get;
            set;
        } = Status.WaitingDispatch;

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlElement("StatusDate")]
        public DateTime StatusDate
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [DataMember, XmlIgnore]
        public override TransactionType Type => TransactionType.Order;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageVisitor"></param>
        public void Process(IMessageVisitor messageVisitor)
        {
            messageVisitor.InsertOrder(this);
        }
    }
}