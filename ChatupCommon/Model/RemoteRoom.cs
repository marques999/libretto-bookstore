using System;

namespace ChatupNET.Model
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class Room
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomName"></param>
        /// <param name="roomOwner"></param>
        /// <param name="roomPassword"></param>
        /// <param name="roomCapacity"></param>
        public Room(int roomId, string roomName, string roomOwner, string roomPassword, int roomCapacity)
        {
            Count = 0;
            Id = roomId;
            Name = roomName;
            Owner = roomOwner;
            Capacity = roomCapacity;
            Password = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
        }

        /// <summary>
        ///
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string Owner
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        public string Password
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public int Capacity
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool IsPrivate() => Password != null;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool IsFull() => Count >= Capacity;

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Id;

        /// <summary>
        ///
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance) => Id == (otherInstance as Room)?.Id;
    }
}