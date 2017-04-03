using System;
using Libretto.Model;

namespace Libretto.Enums
{
    /// <summary>
    /// 
    /// </summary>
    public class WaitingDispatch : OrderState
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispatchTime"></param>
        public WaitingDispatch(DateTime dispatchTime)
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
        public override OrderStateEnum Status => OrderStateEnum.WaitingDispatch;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsDone() => Date > DateTime.Now;
    }
}