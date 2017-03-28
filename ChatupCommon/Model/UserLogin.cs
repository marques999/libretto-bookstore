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
        /// Public getter property for the "Host" private member
        /// </summary>
        public Address Host
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
        /// Public getter property for the "Passwowrd" private member
        /// </summary>
        public string Password
        {
            get;
        }
    }
}