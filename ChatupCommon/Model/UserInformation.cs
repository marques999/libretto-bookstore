using System;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
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
            Host = userHost;
            Name = fullName;
            Username = userName;
        }

        /// <summary>
        /// Public getter property for the "_host" private member
        /// </summary>
        public string Host
        {
            get;
            set;
        }

        /// <summary>
        /// Public getter property for the "Name" private member
        /// </summary>
        public string Name
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
        /// Public getter property for the "_host" private member
        /// </summary>
        public bool Online => Host != null;

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
        public override bool Equals(object otherInstance) => Username == (otherInstance as UserInformation)?.Username;
    }
}