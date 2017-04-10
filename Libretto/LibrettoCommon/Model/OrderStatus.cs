using System.ComponentModel;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum OrderStatus
    {
        [EnumMember]
        [Description("Waiting")]
        WaitingExpedition,
        [EnumMember]
        [Description("Processing")]
        WaitingDispatch,
        [EnumMember]
        [Description("Dispatched")]
        DispatchComplete
    }
}