using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfServiceLibrary1
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract]
    public interface IStoreService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [OperationContract]
        string GetData(int value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class CompositeType
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public bool BoolValue
        {
            get;
            set;
        } = true;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string StringValue
        {
            get;
            set;
        } = "Hello ";
    }
}