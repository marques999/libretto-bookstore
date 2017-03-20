using System;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
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
        /// <param name="messageInstance"></param>
        public void SendMessage(RemoteMessage messageInstance)
        {
            OnMessage?.Invoke(messageInstance);
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