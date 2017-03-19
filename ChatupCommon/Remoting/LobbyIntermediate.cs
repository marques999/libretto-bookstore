using System;

namespace ChatupNET.Remoting
{
    public class LobbyIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomHandler OnCreate;

        /// <summary>
        /// 
        /// </summary>
        public event RoomHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        public event DeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomInstance"></param>
        public void CreateRoom(Room roomInstance)
        {
            OnCreate?.Invoke(roomInstance);
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
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        public void UpdateRoom(Room roomInformation)
        {
            OnUpdate?.Invoke(roomInformation);
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