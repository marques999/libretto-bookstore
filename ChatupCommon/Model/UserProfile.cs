using System;
using System.Drawing;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserProfile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public UserProfile(string userName, Color userColor)
        {
            _color = userColor;
            _username = userName;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _username;

        /// <summary>
        /// Public getter property for the "_username" private member
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Color _color;

        /// <summary>
        /// Public getter property for the "_color" private member
        /// </summary>
        public Color Color
        {
            get
            {
                return _color;
            }
        }
    }
}