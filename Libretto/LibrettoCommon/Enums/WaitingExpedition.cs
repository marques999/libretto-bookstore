using Libretto.Model;

namespace Libretto.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public class WaitingExpedition : OrderState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override OrderStateEnum Status => OrderStateEnum.WaitingExpedition;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDone() => false;
    }
}