using System;

namespace ChatupNET.Rooms
{
    [Serializable]
    public class GroupChatroom : Chatroom
    {
        private int _capacity;
        private string _password;

        /// <summary>
        /// Default constructor for "GroupChatroom" class
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public GroupChatroom(string roomName, string roomPassword, int roomCapacity) : base(roomName)
        {
            _password = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
            _capacity = roomCapacity;
        }

        /// <summary>
        /// Public getter property for the "_capacity" private member
        /// </summary>
        public int Capacity
        {
            get
            {
                return _capacity;
            }
        }

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