using Libretto.Warehouse;

namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageVisitor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageCancel"></param>
        void CancelOrder(MessageCancel messageCancel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageUpdate"></param>
        void UpdateOrder(MessageUpdate messageUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInsert"></param>
        void InsertOrder(WarehouseOrder messageInsert);
    }
}