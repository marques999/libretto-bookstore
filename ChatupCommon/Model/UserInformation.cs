using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserInformation
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userhost"></param>
        /// <param name="userStatus"></param>
        public UserInformation(string userName, string fullName, string userHost)
        {
            mUsername = userName;
            mFullname = fullName;
            mHost = userHost;
        }

        /// <summary>
        /// Public getter property for the "mStatus" private member
        /// </summary>
        public bool Online
        {
            get
            {
                return mHost != null;
            }
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

        private string mFullname;

        public string Name
        {
            get
            {
                return mFullname;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mHost;

        /// <summary>
        /// Public getter property for the "mFullname" private member
        /// </summary>
        public string Host
        {
            get
            {
                return mHost;
            }
            set
            {
                mHost = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return mUsername.GetHashCode();
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
                    return Username.Equals(otherInformation.Username);
                }
            }

            return false;
        }
    }
}