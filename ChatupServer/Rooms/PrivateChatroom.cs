using System;

using ChatupNET.Remoting;

namespace ChatupNET.Rooms
{
    [Serializable]
    public class PrivateChatroom : Chatroom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        public PrivateChatroom(string roomName, string roomOwner) : base(roomName, roomOwner)
        {
            InsertUser(roomOwner);
        }

        /// <summary>
        /// 
        /// </summary>
        public override int Capacity
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsGroup()
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsPrivate()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override bool Join(string userName)
        {
            return !IsFull() && InsertUser(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public override bool Join(string userName, string userPassword)
        {
            return !IsFull() && InsertUser(userName);
        }
    }
}