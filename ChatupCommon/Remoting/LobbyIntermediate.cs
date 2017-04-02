using System;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    ///
    /// </summary>
    public class LobbyIntermediate : MarshalByRefObject
    {
        /// <summary>
        ///
        /// </summary>
        public event InsertHandler OnInsert;

        /// <summary>
        ///
        /// </summary>
        public event DeleteHandler OnDelete;

        /// <summary>
        ///
        /// </summary>
        public event UpdateHandler OnUpdate;

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
        /// <param name="roomInformation"></param>
        public void CreateRoom(Room roomInformation)
        {
            OnInsert?.Invoke(roomInformation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
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