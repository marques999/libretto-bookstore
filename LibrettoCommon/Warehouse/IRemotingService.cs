using System;
using Libretto.Model;

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
        /// <param name="transactionIdentifier"></param>
        /// <returns></returns>
        Response DispatchOrder(Guid transactionIdentifier);
    }
}