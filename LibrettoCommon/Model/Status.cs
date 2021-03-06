﻿using System.ComponentModel;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Status
    {
        [EnumMember]
        [Description("Waiting")]
        Waiting,
        [EnumMember]
        [Description("Pending")]
        Pending,
        [EnumMember]
        [Description("Dispatched")]
        Dispatched,
        [EnumMember]
        [Description("Cancelled")]
        Cancelled
    }
}