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
        public UserInformation(string userName, string fullName)
        {
            mUsername = userName;
            mFullName = fullName;
            mStatus = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <param name="userStatus"></param>
        public UserInformation(string userName, string fullName, bool userStatus)
        {
            mUsername = userName;
            mFullName = fullName;
            mStatus = userStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool mStatus;

        /// <summary>
        /// 
        /// </summary>
        public bool Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                mStatus = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mUsername;

        /// <summary>
        /// 
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
        private string mFullName;

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                return mFullName;
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