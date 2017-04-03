using System;
using Libretto.Model;

namespace Libretto.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public class DispatchCompleted : OrderState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchTime"></param>
        public DispatchCompleted(DateTime dispatchTime)
        {
            Date = dispatchTime;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override OrderStateEnum Status => OrderStateEnum.DispatchComplete;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDone() => Date > DateTime.Now;
    }
}