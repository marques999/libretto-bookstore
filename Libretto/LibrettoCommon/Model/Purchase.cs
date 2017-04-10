using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Purchase : Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public override Status Status
        {
            get;
            set;
        } = Status.StorePurchased;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public override TransactionType Type => TransactionType.Purchase;
    }
}