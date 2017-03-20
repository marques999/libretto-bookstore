using System;

using ChatupNET.Remoting;

namespace ChatupNET.Model
{
    [Serializable]
    public class RoomInvitation
    {
        public RoomInvitation(Room roomInformation)
        {
            _roomId = roomInformation.ID;
            _roomName = roomInformation.Name;
            _roomPassword = roomInformation.Password;
            _userName = ChatupClient.Instance.Username;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _userName;

        /// <summary>
        /// Public getter property for the "_userName" private member
        /// </summary>
        public string Username
        {
            get
            {
                return _userName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _roomName;

        /// <summary>
        /// Public getter property for the "_roomName" private member
        /// </summary>
        public string Room
        {
            get
            {
                return _roomName;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _roomPassword;

        /// <summary>
        /// Public getter property for the "_roomPassword" private member
        /// </summary>
        public string Password
        {
            get
            {
                return _roomPassword;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _roomId;

        /// <summary>
        /// Public getter property for the "_roomId" private member
        /// </summary>
        public int ID
        {
            get
            {
                return _roomId;
            }
        }
    }
}