using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum TransactionType
    {
        [EnumMember] Order,
        [EnumMember] Purchase
    }
}