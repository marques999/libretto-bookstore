using System.Runtime.Serialization;

namespace Libretto.Model
{
    [DataContract]
    public class BookInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public double Price
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Stock
        {
            get;
            set;
        }
    }
}