using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Table("Order")]
    public class Order : Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Status Status
        {
            get;
            set;
        } = Status.WaitingDispatch;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime StatusTimestamp
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public override string Description => Status.GetDescription();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitingChecked"></param>
        /// <param name="processingChecked"></param>
        /// <param name="dispatchedChecked"></param>
        /// <returns></returns>
        public override bool Filter(bool waitingChecked, bool processingChecked, bool dispatchedChecked)
        {
            return Status == Status.WaitingExpedition && waitingChecked || Status == Status.WaitingDispatch && processingChecked || Status == Status.DispatchComplete && dispatchedChecked;
        }
    }
}