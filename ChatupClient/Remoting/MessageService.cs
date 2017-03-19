using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class MessageService : MarshalByRefObject, MessageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageService()
        {
            OnReceive += ChatupClient.Instance.Push;
            OnConnect += ChatupClient.Instance.Connect;
            OnDisconnect += ChatupClient.Instance.Disconnect;
        }

        /// <summary>
        /// 
        /// </summary>
        private HashSet<string> users = new HashSet<string>();

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
        /// <returns></returns>
        public RemoteResponse Disconnect(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (users.Contains(userName))
            {
                users.Remove(userName);
            }

            OnDisconnect?.Invoke(userName, false);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        /// <returns></returns>
        public RemoteResponse Send(RemoteMessage messageInstance)
        {
            if (messageInstance == null)
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrEmpty(messageInstance.Author))
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrWhiteSpace(messageInstance.Contents))
            {
                return RemoteResponse.BadRequest;
            }

            OnReceive?.Invoke(messageInstance);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public CustomResponse Connect(UserProfile userProfile, string userHost)
        {
            var userName = userProfile.Username;

            if (string.IsNullOrEmpty(userName))
            {
                return new CustomResponse(RemoteResponse.BadRequest, null);
            }

            /*if (users.Contains(userName))
            {
                return new CustomResponse(RemoteResponse.SessionExists, null);
            }*/

            if (!users.Contains(userName))
            {
                users.Add(userName);
            }

            OnConnect?.Invoke(userProfile, userHost);

            return new CustomResponse(RemoteResponse.Success, ChatupClient.Instance.Profile);
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