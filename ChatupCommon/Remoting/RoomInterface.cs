using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    public delegate void LeaveHandler(string userName);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userColor"></param>
    public delegate void JoinHandler(string userName, Color userColor);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageInstance"></param>
    public delegate void MessageHandler(RemoteMessage messageInstance);

    /// <summary>
    /// 
    /// </summary>
    public interface RoomInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        event LeaveHandler OnLeave;

        /// <summary>
        /// 
        /// </summary>
        event MessageHandler OnSend;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        RemoteResponse Insert(RemoteMessage messageInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        RemoteResponse Join(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        RemoteResponse Leave(string userName);
    }
}