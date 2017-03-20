using System;

namespace ChatupNET.Remoting
{
    public class LobbyIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event RoomHandler OnInsert;

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
        /// <param name="roomInstance"></param>
        public void CreateRoom(Room roomInformation)
        {
            OnInsert?.Invoke(roomInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        public void UpdateRoom(Room roomInformation)
        {
            OnUpdate?.Invoke(roomInformation);
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