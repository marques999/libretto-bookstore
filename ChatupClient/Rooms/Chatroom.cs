using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    public abstract class Chatroom : MarshalByRefObject, RoomInterface
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

        public Chatroom(string roomName, string roomOwner)
        {
            mName = roomName;
            mOwner = roomOwner;
        }

        /// <summary>
        /// 
        /// </summary>
        private string mName;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return mName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mOwner;

        /// <summary>
        /// 
        /// </summary>
        public string Owner
        {
            get
            {
                return mOwner;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static readonly Color[] Colors = typeof(Color)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.GetValue(null, null))
            .Cast<Color>()
            .ToArray();

        /// <summary>
        /// 
        /// </summary>
        protected Random mRandom = new Random();

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, Color> mUsers = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        protected HashSet<RemoteMessage> messages = new HashSet<RemoteMessage>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        /// <returns></returns>
        public RemoteResponse Insert(RemoteMessage messageInstance)
        {
            if (mUsers.ContainsKey(messageInstance.Author))
            {
                if (messages.Add(messageInstance))
                {
                    OnSend?.Invoke(messageInstance);
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
            if (mUsers.ContainsKey(userName))
            {
                if (mUsers.Remove(userName))
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
        protected bool Exists(string userName)
        {
            return mUsers.ContainsKey(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool InsertUser(string userName)
        {
            if (mUsers.ContainsKey(userName))
            {
                return false;
            }

            var userColor = Colors[mRandom.Next(0, Colors.Length)];

            mUsers.Add(userName, userColor);
            OnJoin?.Invoke(userName, userColor);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            if (otherInstance != null)
            {
                var chatroomInstance = otherInstance as Chatroom;

                if (chatroomInstance != null)
                {
                    return chatroomInstance.mName.Equals(mName);
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return mName.GetHashCode();
        }

        /// <summary>
        /// Public getter property for the "_users" private member
        /// </summary>
        public Dictionary<string, Color> Users
        {
            get
            {
                return mUsers;
            }
        }

        /// <summary>
        /// Public getter property for the "_name" private member
        /// </summary>
        public abstract int Capacity
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "_count" private member
        /// </summary>
        public int Count
        {
            get
            {
                return mUsers.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsPrivate();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return Count < Capacity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public abstract RemoteResponse Join(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public abstract RemoteResponse Join(string userName);
    }
}