﻿using System;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    [Serializable]
    public class PrivateChatroom : RoomService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        public PrivateChatroom(string roomName, string roomOwner) : base(roomName, roomOwner)
        {
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
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public override RemoteResponse Join(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
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