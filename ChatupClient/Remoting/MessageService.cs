using System;
using System.Collections.Generic;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class MessageService : MarshalByRefObject, MessageInterface
    {
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

            ChatupClient.Instance.Messaging.p2pDisconnect(userName, false);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteMessage"></param>
        /// <returns></returns>
        public RemoteResponse Send(RemoteMessage remoteMessage)
        {
            if (remoteMessage == null)
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrEmpty(remoteMessage.Author))
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrWhiteSpace(remoteMessage.Contents))
            {
                return RemoteResponse.BadRequest;
            }

            ChatupClient.Instance.Messaging.p2pReceive(remoteMessage);

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomPassword"></param>
        /// <returns></returns>
        public RemoteResponse Invite(RoomInvitation roomInvitation)
        {
            if (roomInvitation != null && roomInvitation.ID >= 0)
            {
                ChatupClient.Instance.Messaging.p2pInvite(roomInvitation);
            }
            else
            {
                return RemoteResponse.BadRequest;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        /// <param name="userHost"></param>
        /// <returns></returns>
        public Tuple<RemoteResponse, Tuple<string, Color>> Connect(Tuple<string, Color> userProfile, string userHost)
        {
            var userName = userProfile.Item1;

            if (string.IsNullOrEmpty(userName))
            {
                return new Tuple<RemoteResponse, Tuple<string, Color>>(RemoteResponse.BadRequest, null);
            }

            /*if (users.Contains(userName))
            {
                return new CustomResponse(RemoteResponse.SessionExists, null);
            }*/

            if (!_users.Contains(userName))
            {
                _users.Add(userName);
            }

            ChatupClient.Instance.Messaging.p2pConnect(userProfile, userHost);

            return new Tuple<RemoteResponse, Tuple<string, Color>>(RemoteResponse.Success, ChatupClient.Instance.Profile);
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