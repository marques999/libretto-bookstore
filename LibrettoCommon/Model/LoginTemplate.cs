﻿using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LoginTemplate
    {
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
        public string Password
        {
            get;
            set;
        }
    }
}