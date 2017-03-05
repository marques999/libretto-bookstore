using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace ChatupNET.Rooms
{
    [Serializable]
    public abstract class Chatroom
    {
        /// <summary>
        /// Default constructor for the "Chatroom" class
        /// </summary>
        /// <param name="roomName"></param>
        public Chatroom(string roomName)
        {
            mName = roomName;
        }

        /// <summary>
        /// 
        /// </summary>
        private string mName;

        /// <summary>
        /// 
        /// </summary>
        private Random mRnadom = new Random();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> mUsers = new Dictionary<string, Color>();

        /// <summary>
        /// 
        /// </summary>
        static readonly Color[] Colors = typeof(Color)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.GetValue(null, null))
            .Cast<Color>()
            .ToArray();

        /// <summary>
        /// Public getter property for the "_name" private member
        /// </summary>
        public string Name
        {
            get
            {
                return mName;
            }
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
        /// <param name="userName"></param>
        public void InsertUser(string userName)
        {
            mUsers.Add(userName, Colors[mRnadom.Next(0, Colors.Length)]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public void InsertUser(string userName, Color userColor)
        {
            mUsers.Add(userName, userColor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void RemoveUser(string userName)
        {
            mUsers.Remove(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Color Color(string userName)
        {
            if (mUsers.ContainsKey(userName))
            {
                return mUsers[userName];
            }

            return System.Drawing.Color.Black;
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
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                var chatroomInstance = obj as Chatroom;

                if (chatroomInstance != null)
                {
                    return chatroomInstance.mName.Equals(mName);
                }
            }

            return false;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract bool IsGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract string GetCapacity();
    }
}