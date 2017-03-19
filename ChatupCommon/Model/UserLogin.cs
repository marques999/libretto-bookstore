using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserLogin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPasword"></param>
        /// <param name="userHost"></param>
        public UserLogin(string userName, string userPasword, Address userHost)
        {
            _host = userHost;
            _username = userName;
            _password = userPasword;
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
        private string _password;

        /// <summary>
        /// Public getter property for the "_password" private member
        /// </summary>
        public string Pasword
        {
            get
            {
                return _password;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Address _host;

        /// <summary>
        /// Public getter property for the "_host" private member
        /// </summary>
        public Address Host
        {
            get
            {
                return _host;
            }
        }
    }
}