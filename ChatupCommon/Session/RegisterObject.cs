using System;

namespace ChatupNET.Session
{
    [Serializable]
    public class RegisterObject
    {
        /// <summary>
        /// Default constructor for 'RegisterObject' class
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <param name="userTimezone"></param>
        public RegisterObject(string userName, string userPassword, TimeZoneInfo userTimezone)
        {
            _username = userName;
            _password = userPassword;
            _timezone = userTimezone;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _username;

        /// <summary>
        /// 
        /// </summary>
        private string _password;

        /// <summary>
        /// 
        /// </summary>
        private TimeZoneInfo _timezone;
        private string v1;
        private string v2;

        /// <summary>
        /// Public getter property for the "_timzeone" private member
        /// </summary>
        public TimeZoneInfo Timezone
        {
            get
            {
                return _timezone;
            }
        }

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
        /// Public getter property for the "_password" private member
        /// </summary>
        public string Password
        {
            get
            {
                return _password;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _username.GetHashCode() * 31 + _password.GetHashCode();
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
                var registerObject = otherInstance as RegisterObject;

                if (registerObject != null)
                {
                    return Username.Equals(registerObject.Username) && Password.Equals(registerObject.Password);
                }
            }

            return false;
        }
    }
}