using System;

namespace ChatupNET.Remoting
{
    public class Room
    {
        public Room(string roomName, string roomOwner, string roomPassword, int roomCapacity)
        {
            mCount = 1;
            mName = roomName;
            mOwner = roomOwner;
            mCapacity = roomCapacity;
            mPassword = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
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
        private int mCount;

        /// <summary>
        /// Public getter property for the "_count" private member
        /// </summary>
        public int Count
        {
            get
            {
                return mCount;
            }
            set
            {
                mCount = value;
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
        private int mCapacity;

        /// <summary>
        /// Public getter property for the "_capacity" private member
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
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            if (otherInstance != null)
            {
                var otherChatroom = otherInstance as Room;

                if (otherChatroom != null)
                {
                    return otherChatroom.mName.Equals(mName);
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
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        public string GetCapacity()
        {
            return Capacity < 1 ? "INF" : Convert.ToString(Capacity + 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsPrivate()
        {
            return mPassword != null;
        }

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
        /// <returns></returns>
        public bool IsGroup()
        {
            return true;
        }
    }
}