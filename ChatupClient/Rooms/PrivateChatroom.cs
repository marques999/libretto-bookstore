using System;

namespace ChatupNET.Rooms
{
    [Serializable]
    public class PrivateChatroom : Chatroom
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomName"></param>
        public PrivateChatroom(string roomName) : base(roomName)
        {
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
        public override string GetCapacity()
        {
            return "2";
        }
    }
}