using System;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInvitation"></param>
    public delegate void InviteHandler(RoomInvitation roomInvitation);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userAction"></param>
    public delegate void DisconnectHandler(string userName, bool userAction);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userProfile"></param>
    /// <param name="userHost"></param>
    public delegate void ConnectHandler(Tuple<string, Color> userProfile, string userHost);

    /// <summary>
    /// 
    /// </summary>
    public interface MessageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Disconnect(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        /// <returns></returns>
        RemoteResponse Send(RemoteMessage remoteMessage);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInvitation"></param>
        /// <returns></returns>
        RemoteResponse Invite(RoomInvitation roomInvitation);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        /// <returns></returns>
        Tuple<RemoteResponse, Tuple<string, Color>> Connect(Tuple<string, Color> userProfile, string userHost);
    }
}