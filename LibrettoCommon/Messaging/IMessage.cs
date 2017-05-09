namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageVisitor"></param>
        void Process(IMessageVisitor messageVisitor);
    }
}