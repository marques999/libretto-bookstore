using ChatupNET.Messaging;
using System;
using System.Drawing;

namespace ChatupNET.Remoting
{
    public class ChatroomIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        public void Join(string userName, Color userColor)
        {
            OnJoin(userName, userColor);
        }

        /// <summary>
        /// 
        /// </summary>
        public event LeaveHandler OnLeave;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        public void Leave(string userName)
        {
            OnLeave(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        public event MessageHandler OnSend;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        public void Send(Message messageInstance)
        {
            OnSend(messageInstance);
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