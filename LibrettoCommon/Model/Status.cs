using System.ComponentModel;
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
        WaitingExpedition,
        [EnumMember]
        [Description("Processing")]
        WaitingDispatch,
        [EnumMember]
        [Description("Dispatched")]
        DispatchComplete,
        [EnumMember]
        [Description("Cancelled")]
        OrderCancelled
    }
}