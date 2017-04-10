using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Book : BookInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid Identifier
        {
            get;
            set;
        } = Guid.NewGuid();
    }
}