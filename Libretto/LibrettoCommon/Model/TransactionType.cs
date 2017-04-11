using System.ComponentModel;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum TransactionType
    {
        [EnumMember]
        [Description("Order")]
        Order,
        [EnumMember]
        [Description("Purchase")]
        Purchase
    }
}