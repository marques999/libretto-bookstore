using System;

using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    [Serializable]
    public class GroupChatroom : Chatroom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public GroupChatroom(string roomName, string roomOwner, string roomPassword, int roomCapacity) : base(roomName, roomOwner)
        {
            _capacity = roomCapacity;
            _password = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
            InsertUser(roomOwner);
        }

        /// <summary>
        /// 
        /// </summary>
        private int _capacity;

        /// <summary>
        /// Public getter property for the "_capacity" private member
        /// </summary>
        public override int Capacity
        {
            get
            {
                return _capacity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _password;

        /// <summary>
        /// Public getter property for the "_password" private member
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsGroup()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsPrivate()
        {
            return _password != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override bool Join(string userName)
        {
            return !IsPrivate() && !IsFull() && InsertUser(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public override bool Join(string userName, string userPassword)
        {
            if (IsPrivate() && !userPassword.Equals(_password))
            {
                return false;
            }

            return !IsFull() && InsertUser(userName);
        }
    }
}