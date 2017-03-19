using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserLogin
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPasword"></param>
        /// <param name="userHost"></param>
        public UserLogin(string userName, string userPasword, Address userHost)
        {
            mUsername = userName;
            mPassword = userPasword;
            mHost = userHost;
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
        private string mPassword;

        /// <summary>
        /// Public getter property for the "mPassword" private member
        /// </summary>
        public string Pasword
        {
            get
            {
                return mPassword;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Address mHost;

        /// <summary>
        /// Public getter property for the "mHost" private member
        /// </summary>
        public Address Host
        {
            get
            {
                return mHost;
            }
        }
    }
}