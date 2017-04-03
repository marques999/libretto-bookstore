using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Session
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public Guid Token
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Username
        {
            get;
            set;
        }
    }
}