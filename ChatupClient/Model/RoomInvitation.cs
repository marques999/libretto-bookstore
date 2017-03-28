using System;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class RoomInvitation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        public RoomInvitation(Room roomInformation)
        {
            Id = roomInformation.Id;
            Room = roomInformation.Name;
            Password = roomInformation.Password;
            Username = ChatupClient.Instance.Username;
        }

        /// <summary>
        /// Public getter property for the "Id" private member
        /// </summary>
        public int Id
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Room" private member
        /// </summary>
        public string Room
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Username" private member
        /// </summary>
        public string Username
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Password" private member
        /// </summary>
        public string Password
        {
            get;
        }
    }
}