using System;
using System.Collections.Generic;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    ///
    /// </summary>
    internal class RoomService : MarshalByRefObject, RoomInterface
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        public RoomService(Room roomInformation)
        {
            _instance = roomInformation;
        }

        /// <summary>
        ///
        /// </summary>
        private readonly Room _instance;

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
        /// <returns></returns>
        public Dictionary<string, Color> List() => _users;

        /// <summary>
        ///
        /// </summary>
        private readonly MessageQueue _messages = new MessageQueue();

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<string, Color> _users = new Dictionary<string, Color>();

        /// <summary>
        ///
        /// </summary>
        /// <param name="remoteMessage"></param>
        /// <returns></returns>
        public RemoteResponse Send(RemoteMessage remoteMessage)
        {
            var messageAuthor = remoteMessage?.Author.Username;

            if (string.IsNullOrEmpty(messageAuthor))
            {
                return RemoteResponse.BadRequest;
            }

            if (_users.ContainsKey(messageAuthor))
            {
                _messages.Enqueue(remoteMessage);
                OnSend?.Invoke(remoteMessage);
            }
            else
            {
                return RemoteResponse.PermissionDenied;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public RemoteResponse Leave(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (_users.ContainsKey(userName))
            {
                var userProfile = new UserProfile(userName, _users[userName]);

                if (_users.Remove(userName))
                {
                    _instance.Count--;
                    OnLeave?.Invoke(userName);
                    ChatupServer.Instance.LeaveRoom(_instance, userProfile);
                }
                else
                {
                    return RemoteResponse.OperationFailed;
                }
            }
            else
            {
                return RemoteResponse.NotFound;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        public Tuple<RemoteResponse, MessageQueue> Join(UserProfile userProfile)
        {
            if (string.IsNullOrEmpty(userProfile?.Username))
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.BadRequest, null);
            }

            if (_users.ContainsKey(userProfile.Username))
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.ConversationExists, null);
            }

            _instance.Count++;
            OnJoin?.Invoke(userProfile);
            _users.Add(userProfile.Username, userProfile.Color);
            ChatupServer.Instance.JoinRoom(_instance, userProfile);

            return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.Success, _messages);
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