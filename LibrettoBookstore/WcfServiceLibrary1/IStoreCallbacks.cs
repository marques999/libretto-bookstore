using System;
using System.ServiceModel;

using Libretto.Model;

namespace LibrettoWCF
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IStoreCallbacks
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        [OperationContract(IsOneWay = true)]
        void OnCancelOrder(Guid transactionIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        [OperationContract(IsOneWay = true)]
        void OnDispatchOrder(Guid transactionIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterTransaction(Transaction purchaseInformation);
    }
}