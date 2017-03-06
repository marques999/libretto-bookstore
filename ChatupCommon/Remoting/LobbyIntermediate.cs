using System;

namespace ChatupNET.Remoting
{
    public class LobbyIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomInsertHandler OnCreate;

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
        /// <param name="roomInstance"></param>
        public void CreateRoom(int roomId, Room roomInstance)
        {
            OnCreate?.Invoke(roomId, roomInstance);
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
        /// <param name="roomId"></param>
        /// <param name="roomExit"></param>
        public void UpdateRoom(int roomId, int roomCount, int roomCapacity)
        {
            OnUpdate?.Invoke(roomId, roomCount, roomCapacity);
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