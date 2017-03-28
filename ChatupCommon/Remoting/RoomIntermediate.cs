using System;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    public class RoomIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        public event LeaveHandler OnLeave;

        /// <summary>
        /// 
        /// </summary>
        public event MessageHandler OnMessage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void LeaveRoom(string userName)
        {
            OnLeave?.Invoke(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void SendMessage(RemoteMessage remoteMessage)
        {
            OnMessage?.Invoke(remoteMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        public void JoinRoom(Tuple<string, Color> userProfile)
        {
            OnJoin?.Invoke(userProfile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}