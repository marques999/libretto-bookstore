using System;

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
        public event MessageHandler OnSend;

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
            OnSend?.Invoke(remoteMessage);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        public void JoinRoom(UserProfile userProfile)
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