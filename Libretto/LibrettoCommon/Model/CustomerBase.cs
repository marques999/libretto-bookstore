using System.Runtime.Serialization;

namespace Libretto.Model
{
    [DataContract]
    public class CustomerBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Location
        {
            get;
            set;
        }
    }
}