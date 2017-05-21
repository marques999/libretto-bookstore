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
        void OnDeleteTransaction(Guid transactionIdentifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnUpdateTransaction(Transaction transactionInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterTransaction(Transaction purchaseInformation);
    }
}