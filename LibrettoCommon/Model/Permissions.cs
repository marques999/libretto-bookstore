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
        [Description("Clerk")]
        Clerk = 0,
        [EnumMember]
        [Description("Administrator")]
        Administrator = 1,
        [EnumMember]
        [Description("None")]
        None = 2
    }
}