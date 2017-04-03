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
        ///
        /// </summary>
        public int Id
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string Room
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string Username
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string Password
        {
            get;
        }
    }
}