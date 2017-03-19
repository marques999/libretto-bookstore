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
        private HashSet<string> _users = new HashSet<string>();

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

            if (_users.Contains(userName))
            {
                _users.Remove(userName);
            }

            OnDisconnect?.Invoke(userName, false);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userMessage"></param>
        /// <returns></returns>
        public RemoteResponse Send(RemoteMessage userMessage)
        {
            if (userMessage == null)
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrEmpty(userMessage.Author))
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrWhiteSpace(userMessage.Contents))
            {
                return RemoteResponse.BadRequest;
            }

            OnReceive?.Invoke(userMessage);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
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

            if (!_users.Contains(userName))
            {
                _users.Add(userName);
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