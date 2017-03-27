using System;
using System.Collections.Generic;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class RoomService : MarshalByRefObject, RoomInterface
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
        private Room _instance;

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
        protected MessageQueue _messages = new MessageQueue(100);

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, Color> _users = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Color> List()
        {
            return _users;
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

            if (_users.ContainsKey(messageInstance.Author))
            {
                _messages.Enqueue(messageInstance);
                OnSend?.Invoke(messageInstance);
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
            bool operationResult = !_users.ContainsKey(userName);

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