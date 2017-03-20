using System;
using System.Collections.Generic;
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
    /// <param name="userProfile"></param>
    public delegate void JoinHandler(Tuple<string, Color> userProfile);

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
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Leave(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        /// <returns></returns>
        RemoteResponse Send(RemoteMessage messageInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        Tuple<RemoteResponse, MessageQueue> Join(string userName, string userPassword);
    }
}