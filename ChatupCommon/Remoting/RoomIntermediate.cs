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
        /// <param name="userColor"></param>
        public void JoinRoom(string userName, Color userColor)
        {
            OnJoin?.Invoke(userName, userColor);
        }

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
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}