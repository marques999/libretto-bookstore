using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserInformation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <param name="userHost"></param>
        public UserInformation(string userName, string fullName, string userHost)
        {
            _username = userName;
            _name = fullName;
            _host = userHost;
        }

        /// <summary>
        /// Public getter property for the "mStatus" private member
        /// </summary>
        public bool Online
        {
            get
            {
                return _host != null;
            }
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
        private string _name;

        /// <summary>
        /// Public getter property for the "_name" private member
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _host;

        /// <summary>
        /// Public getter property for the "_host" private member
        /// </summary>
        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _username.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            if (otherInstance != null)
            {
                var otherInformation = otherInstance as UserInformation;

                if (otherInformation != null)
                {
                    return _username.Equals(otherInformation._username);
                }
            }

            return false;
        }
    }
}