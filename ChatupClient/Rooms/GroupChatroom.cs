using System;

namespace ChatupNET.Rooms
{
    [Serializable]
    public class GroupChatroom : Chatroom
    {
        /// <summary>
        /// Default constructor for "GroupChatroom" class
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public GroupChatroom(string roomName, string roomPassword, int roomCapacity) : base(roomName)
        {
            mCapacity = roomCapacity;
            mPassword = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        private int mCapacity;

        /// <summary>
        /// Public getter property for the "mCapacity" private member
        /// </summary>
        public int Capacity
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
        public override string GetCapacity()
        {
            return Capacity < 1 ? "INF" : Convert.ToString(Capacity + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool IsGroup()
        {
            return true;
        }
    }
}