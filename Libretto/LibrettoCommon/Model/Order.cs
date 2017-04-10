using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Order : Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public override Status Status
        {
            get;
            set;
        } = Status.WaitingDispatch;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime StatusDate
        {
            get;
            set;
        } = DateTime.Now;
    }
}