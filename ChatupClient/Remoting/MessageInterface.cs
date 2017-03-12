using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userColor"></param>
    public delegate void ConnectHandler(UserProfile userProfile, Address remoteHost);

    /// <summary>
    /// 
    /// </summary>
    public interface MessageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        RemoteResponse Send(RemoteMessage messageInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        RemoteResponse Disconnect(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        RemoteResponse Connect(UserProfile userProfile, Address userHost);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        UserProfile Profile();
    }
}