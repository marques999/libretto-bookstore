using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userProfile"></param>
    /// <param name="remoteHost"></param>
    public delegate void ConnectHandler(UserProfile userProfile, string remoteHost);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userAction"></param>
    public delegate void DisconnectHandler(string userName, bool userAction);

    /// <summary>
    /// 
    /// </summary>
    public interface MessageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event MessageHandler OnReceive;

        /// <summary>
        /// 
        /// </summary>
        event ConnectHandler OnConnect;

        /// <summary>
        /// 
        /// </summary>
        event DisconnectHandler OnDisconnect;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Disconnect(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns></returns>
        RemoteResponse Send(RemoteMessage userMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        /// <returns></returns>
        CustomResponse Connect(UserProfile userProfile, string userHost);
    }
}