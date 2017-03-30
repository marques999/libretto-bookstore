using System;
using System.Drawing;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserProfile
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userColor"></param>
        public UserProfile(string userName, Color userColor)
        {
            Color = userColor;
            Username = userName;
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
        public Color Color
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => Username.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance) => Username.Equals((otherInstance as UserInformation)?.Username);
    }
}