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
            _name = roomName;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _name;

        /// <summary>
        /// 
        /// </summary>
        private Random randomGenerator = new Random();

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, Color> _users = new Dictionary<string, Color>();

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
                return _name;
            }
        }

        /// <summary>
        /// Public getter property for the "_count" private member
        /// </summary>
        public int Count
        {
            get
            {
                return _users.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void InsertUser(string userName)
        {
            _users.Add(userName, Colors[randomGenerator.Next(0, Colors.Length)]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public void InsertUser(string userName, Color userColor)
        {
            _users.Add(userName, userColor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void RemoveUser(string userName)
        {
            _users.Remove(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Color Color(string userName)
        {
            if (_users.ContainsKey(userName))
            {
                return _users[userName];
            }

            return System.Drawing.Color.Black;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
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
                    return chatroomInstance._name.Equals(_name);
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
                return _users;
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