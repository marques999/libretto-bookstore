using System;
using System.Collections.Generic;

using ChatupNET.Model;
using ChatupNET.Forms;

namespace ChatupNET.Remoting
{
    class MessageService : MarshalByRefObject, MessageInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public void SetForm(MainForm mainForm)
        {
            mForm = mainForm;
        }

        /// <summary>
        /// 
        /// </summary>
        private HashSet<string> users = new HashSet<string>();

        /// <summary>
        /// 
        /// </summary>
        private MainForm mForm;

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
                ChatupClient.Instance.Messaging.Disconnect(userName);
            }
            else
            {
                return RemoteResponse.OperationFailed;
            }

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

            var userName = messageInstance.Author;

            if (!users.Contains(userName))
            {
                return RemoteResponse.PermissionDenied;
            }

            ChatupClient.Instance.Messaging.Push(messageInstance);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public RemoteResponse Connect(UserProfile userProfile, Address userHost)
        {
            var userName = userProfile.Username;

            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (users.Contains(userName))
            {
                return RemoteResponse.SessionExists;
            }

            users.Add(userName);
            ChatupClient.Instance.Messaging.Connect(userProfile, userHost);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public UserProfile Profile()
        {
            return ChatupClient.Instance.Profile;
        }
    }
}