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
            mColor = userColor;
            mUsername = userName;
        }

        /// <summary>
        /// 
        /// </summary>
        private string mUsername;

        /// <summary>
        /// Public getter property for the "mUsername" private member
        /// </summary>
        public string Username
        {
            get
            {
                return mUsername;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Color mColor;

        /// <summary>
        /// Public getter property for the "mColor" private member
        /// </summary>
        public Color Color
        {
            get
            {
                return mColor;
            }
        }
    }
}