using System;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRemotingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentfiier"></param>
        /// <param name="transactionTimestamp"></param>
        /// <returns></returns>
        bool DispatchOrder(Guid transactionIdentfiier, DateTime transactionTimestamp);
    }
}