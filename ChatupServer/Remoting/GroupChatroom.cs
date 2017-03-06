using System;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    [Serializable]
    public class GroupChatroom : RoomService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        public GroupChatroom(Room roomInstance) : base(roomInstance.Name, roomInstance.Owner)
        {
            mCapacity = roomInstance.Capacity;

            if (roomInstance.IsPrivate())
            {
                mPassword = roomInstance.Password;
            }
            else
            {
                mPassword = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int mCapacity;

        /// <summary>
        /// Public getter property for the "mCapacity" private member
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
        /// Public getter property for the "mPassword" private member
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
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public override RemoteResponse Join(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (IsPrivate() && (string.IsNullOrEmpty(userPassword) || !userPassword.Equals(mPassword)))
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