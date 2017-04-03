using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum OrderStateEnum
    {
        [EnumMember]
        WaitingExpedition,
        [EnumMember]
        WaitingDispatch,
        [EnumMember]
        DispatchComplete
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public abstract class OrderState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DataMember]
        public abstract OrderStateEnum Status
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsDone();
    }
}