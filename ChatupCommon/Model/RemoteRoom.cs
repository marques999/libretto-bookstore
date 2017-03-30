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
        /// Public getter property for the "Id" private member
        /// </summary>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Public getter property for the "Name" private member
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Owner" private member
        /// </summary>
        public string Owner
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Count" private member
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Public getter property for the "Password" private member
        /// </summary>
        public string Password
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Capacity" private member
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