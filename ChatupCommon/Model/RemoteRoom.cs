using System;

namespace ChatupNET.Remoting
{
    [Serializable]
    public class Room
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomName"></param>
        /// <param name="roomOwner"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public Room(int roomId, string roomName, string roomOwner, string roomPassword, int roomCapacity)
        {
            _count = 0;
            _id = roomId;
            _name = roomName;
            _owner = roomOwner;
            _capacity = roomCapacity;
            _password = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        private int _id;

        /// <summary>
        /// Public getter property for the "_id" private member
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _name;

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
        /// 
        /// </summary>
        private string _owner;

        /// <summary>
        /// Public getter property for the "_owner" private member
        /// </summary>
        public string Owner
        {
            get
            {
                return _owner;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _count;

        /// <summary>
        /// Public getter property for the "_count" private member
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
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
        private int _capacity;

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
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            if (otherInstance != null)
            {
                var otherChatroom = otherInstance as Room;

                if (otherChatroom != null)
                {
                    return ID == otherChatroom.ID;
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
            return ID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPrivate()
        {
            return _password != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsFull()
        {
            return Count >= Capacity;
        }
    }
}