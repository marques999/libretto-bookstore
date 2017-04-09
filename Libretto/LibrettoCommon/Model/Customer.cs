using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Customer : CustomerBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid Identifier
        {
            get;
            set;
        }
    }
}