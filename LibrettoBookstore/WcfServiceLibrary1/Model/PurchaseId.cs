using System.Runtime.Serialization;

namespace LibrettoWCF.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class PurchaseId
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Id
        {
            get;
            set;
        }
    }
}