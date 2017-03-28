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
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}