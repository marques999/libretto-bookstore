namespace Libretto.Messaging
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageSubject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageVisitor"></param>
        void Process(IMessageVisitor messageVisitor);
    }
}