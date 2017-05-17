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
        /// <param name="customerInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterCustomer(Customer customerInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnRegisterTransaction(Transaction purchaseInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        [OperationContract(IsOneWay = true)]
        void OnUpdateTransaction(Transaction purchaseInformation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIdentifier"></param>
        [OperationContract(IsOneWay = true)]
        void OnDeleteTransaction(Guid transactionIdentifier);
    }
}