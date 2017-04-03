using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CustomerForm : CustomerBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Password
        {
            get;
            set;
        }
    }
}