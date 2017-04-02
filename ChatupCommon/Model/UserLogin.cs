using System;

namespace ChatupNET.Model
{
    /// <summary>
    ///
    /// </summary>
    [Serializable]
    public class UserLogin
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="userHost"></param>
        public UserLogin(string userName, string userPassword, Address userHost)
        {
            Host = userHost;
            Username = userName;
            Password = userPassword;
        }

        /// <summary>
        ///
        /// </summary>
        public Address Host
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