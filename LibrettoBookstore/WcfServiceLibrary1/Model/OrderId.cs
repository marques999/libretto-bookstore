using System.Runtime.Serialization;

namespace LibrettoWCF.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class OrderId
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