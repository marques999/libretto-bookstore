﻿using System;

namespace ChatupNET.Remoting
{
    [Serializable]
    public class Room
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="roomName"></param>
        /// <param name="roomOwner"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public Room(string roomName, string roomOwner, string roomPassword, int roomCapacity)
        {
            mCount = 0;
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
        /// Public getter property for the "mName" private member
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
        /// Public getter property for the "mOwner" private member
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
        /// Public getter property for the "mCount" private member
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
    }
}