using System;

namespace ChatupNET.Remoting
{
    class LobbyService : MarshalByRefObject, LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomCreateHandler OnCreate;

        /// <summary>
        /// 
        /// </summary>
        public event RoomDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        public event RoomUpdateHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool Delete(string userName, int roomId)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public bool Join(string userName, int roomId)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomName"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        /// <returns></returns>
        public bool New(string userName, string roomName, string roomPassword, int roomCapacity)
        {
            return true;
        }
    }
}