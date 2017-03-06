using System;

using ChatupNET.Remoting;
using ChatupNET.Model;

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
            mCapacity = roomCapacity;
            mPassword = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
            InsertUser(roomOwner);
        }

        /// <summary>
        /// 
        /// </summary>
        private int mCapacity;

        /// <summary>
        /// Public getter property for the "_capacity" private member
        /// </summary>
        public override int Capacity
        {
            get
            {
                return mCapacity;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mPassword;

        /// <summary>
        /// Public getter property for the "_password" private member
        /// </summary>
        public string Password
        {
            get
            {
                return mPassword;
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
            return mPassword != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override RemoteResponse Join(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (IsPrivate())
            {
                return RemoteResponse.AuthenticationFailed;
            }

            if (IsFull())
            {
                return RemoteResponse.RoomFull;
            }

            if (InsertUser(userName))
            {
                return RemoteResponse.Success;
            }

            return RemoteResponse.ObjectExists;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public override RemoteResponse Join(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPassword))
            {
                return RemoteResponse.BadRequest;
            }

            if (IsPrivate() && !userPassword.Equals(mPassword))
            {
                return RemoteResponse.AuthenticationFailed;
            }

            if (IsFull())
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