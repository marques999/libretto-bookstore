using System;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    public class MessageIntermediate
    {
        /// <summary>
        /// 
        /// </summary>
        public event InviteHandler OnInvite;

        /// <summary>
        /// 
        /// </summary>
        public event MessageHandler OnReceive;

        /// <summary>
        /// 
        /// </summary>
        public event ConnectHandler OnConnect;

        /// <summary>
        /// 
        /// </summary>
        public event DisconnectHandler OnDisconnect;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="remoteInvocation"></param>
        public void p2pDisconnect(string userName, bool remoteInvocation)
        {
            OnDisconnect?.Invoke(userName, remoteInvocation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void p2pReceive(RemoteMessage remoteMessage)
        {
            OnReceive?.Invoke(remoteMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInvitation"></param>
        public void p2pInvite(RoomInvitation roomInvitation)
        {
            OnInvite?.Invoke(roomInvitation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        public void p2pConnect(Tuple<string, Color> userProfile, string userHost)
        {
            OnConnect?.Invoke(userProfile, userHost);
        }
    }
}