using System;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    public class MessageIntermediate : MarshalByRefObject
    {
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
        public event LeaveHandler OnDisconnect;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void Disconnect(string userName)
        {
            OnDisconnect?.Invoke(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public void Connect(UserProfile userProfile, Address remoteHost)
        {
            OnConnect?.Invoke(userProfile, remoteHost);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        public void Push(RemoteMessage remoteMessage)
        {
            OnReceive?.Invoke(remoteMessage);
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