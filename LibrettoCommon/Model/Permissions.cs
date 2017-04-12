using System.ComponentModel;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Permissions
    {
        [EnumMember]
        [Description("None")]
        None,
        [EnumMember]
        [Description("Clerk")]
        Clerk,
        [EnumMember]
        [Description("Customer")]
        Customer,
        [EnumMember]
        [Description("Administrator")]
        Administrator
    }
}