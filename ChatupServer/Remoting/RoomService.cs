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
            InsertUser(roomInformation.Owner);
        }

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
        private Room _instance;

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, Color> _users = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        protected HashSet<RemoteMessage> _messages = new HashSet<RemoteMessage>();

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
        public RemoteResponse Insert(RemoteMessage messageInstance)
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
                if (_messages.Add(messageInstance))
                {
                    OnSend?.Invoke(messageInstance);
                }
                else
                {
                    return RemoteResponse.ObjectExists;
                }
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
                InsertUser(new UserProfile(userName, ColorGenerator.Random()));
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userProfile"></param>
        private void InsertUser(UserProfile userProfile)
        {
            _users.Add(userProfile.Username, userProfile.Color);
            OnJoin?.Invoke(userProfile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public RemoteResponse Join(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (_instance.IsPrivate() && (string.IsNullOrEmpty(userPassword) || !userPassword.Equals(_instance.Password)))
            {
                return RemoteResponse.AuthenticationFailed;
            }

            if (_instance.IsFull())
            {
                return RemoteResponse.RoomFull;
            }

            if (InsertUser(userName))
            {
                ChatupServer.Instance.Lobby.UpdateRoom(_instance);
            }
            else
            {
                return RemoteResponse.ObjectExists;
            }

            return RemoteResponse.Success;
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