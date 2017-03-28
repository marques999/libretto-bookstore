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
            if (string.IsNullOrEmpty(remoteMessage?.Author))
            {
                return RemoteResponse.BadRequest;
            }

            if (_users.ContainsKey(remoteMessage.Author))
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
                if (_users.Remove(userName))
                {
                    OnLeave?.Invoke(userName);
                    ChatupServer.Instance.LeaveRoom(_instance, userName);
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
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool InsertUser(string userName)
        {
            var operationResult = !_users.ContainsKey(userName);

            if (operationResult)
            {
                InsertUser(new Tuple<string, Color>(userName, ColorGenerator.Random()));
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        private void InsertUser(Tuple<string, Color> userProfile)
        {
            _users.Add(userProfile.Item1, userProfile.Item2);
            OnJoin?.Invoke(userProfile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomPassword"></param>
        /// <returns></returns>
        public Tuple<RemoteResponse, MessageQueue> Join(string userName, string roomPassword)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.BadRequest, null);
            }

            if (_instance.IsPrivate() && (string.IsNullOrEmpty(roomPassword) || !roomPassword.Equals(_instance.Password)))
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.AuthenticationFailed, null);
            }

            if (_instance.IsFull())
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.RoomFull, null);
            }

            if (InsertUser(userName))
            {
                ChatupServer.Instance.JoinRoom(_instance, userName);
            }
            else
            {
                return new Tuple<RemoteResponse, MessageQueue>(RemoteResponse.ObjectExists, null);
            }

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