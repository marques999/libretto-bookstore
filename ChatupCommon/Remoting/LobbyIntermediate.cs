using System;

namespace ChatupNET.Remoting
{
    public class LobbyIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomCreateHandler OnCreate;

        /// <summary>
        /// 
        /// </summary>
        public event RoomUpdateHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        public event RoomDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roomName"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public void CreateRoom(string userName, string roomName, string roomPassword, int roomCapacity)
        {
            OnCreate?.Invoke(userName, roomName, roomPassword, roomCapacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomExit"></param>
        public void UpdateRoom(int roomId, string roomExit)
        {
            OnUpdate?.Invoke(roomId, roomExit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        public void DeleteRoom(int roomId)
        {
            OnDelete?.Invoke(roomId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}