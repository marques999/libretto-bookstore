using System;
using System.Collections.Generic;
using System.Drawing;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    public class RoomService : MarshalByRefObject, RoomInterface
    {
        /// <summary>
        /// 
        /// </summary>
        private Room mRoom;

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
        protected Dictionary<string, Color> users = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        protected HashSet<RemoteMessage> messages = new HashSet<RemoteMessage>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        public RoomService(Room roomInstance)
        {
            mRoom = roomInstance;
            InsertUser(roomInstance.Owner);
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return mRoom.Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Owner
        {
            get
            {
                return mRoom.Owner;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Capacity
        {
            get
            {
                return mRoom.Capacity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Color> List()
        {
            return users;
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

            if (users.ContainsKey(messageInstance.Author))
            {
                if (messages.Add(messageInstance))
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

            if (users.ContainsKey(userName))
            {
                if (users.Remove(userName))
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
            if (users.ContainsKey(userName))
            {
                return false;
            }

            var userColor = ColorGenerator.Random();

            if (userColor != null)
            {
                users.Add(userName, userColor);
                OnJoin?.Invoke(new UserProfile(userName, userColor));
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            return mRoom.Equals(otherInstance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return mRoom.GetHashCode();
        }

        /// <summary>
        /// Public getter property for the "_users" private member
        /// </summary>
        public Dictionary<string, Color> Users
        {
            get
            {
                return users;
            }
        }

        /// <summary>
        /// Public getter property for the "_count" private member
        /// </summary>
        public int Count
        {
            get
            {
                return users.Count;
            }
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

            if (mRoom.IsPrivate() && (string.IsNullOrEmpty(userPassword) || !userPassword.Equals(mRoom.Password)))
            {
                return RemoteResponse.AuthenticationFailed;
            }

            if (mRoom.IsFull())
            {
                return RemoteResponse.RoomFull;
            }

            if (InsertUser(userName))
            {
                return RemoteResponse.Success;
            }

            return RemoteResponse.ObjectExists;
        }
    }
}