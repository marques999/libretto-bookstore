using System.Drawing;

using ChatupNET.Model;
using System.Collections.Generic;

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
    /// <param name="userProfile"></param>
    public delegate void JoinHandler(UserProfile userProfile);

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
        /// <returns></returns>
        Dictionary<string, Color> List();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        RemoteResponse Send(RemoteMessage messageInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        RemoteResponse Leave(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        CustomResponse Join(string userName, string userPassword);
    }
}