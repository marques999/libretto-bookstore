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
    public delegate void JoinHandler(UserProfile userProfile);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="remoteMessage"></param>
    public delegate void MessageHandler(RemoteMessage remoteMessage);

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
        /// <param name="remoteMessage"></param>
        /// <returns></returns>
        RemoteResponse Send(RemoteMessage remoteMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="roomPassword"></param>
        /// <returns></returns>
        Tuple<RemoteResponse, MessageQueue> Join(UserProfile userProfile, string roomPassword);
    }
}