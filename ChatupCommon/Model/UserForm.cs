using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class UserForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        /// <param name="userPassword"></param>
        public UserForm(string userName, string fullName, string userPassword)
        {
            _name = fullName;
            _username = userName;
            _password = userPassword;
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
        private string _password;

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
                var otherForm = otherInstance as UserForm;

                if (otherForm != null)
                {
                    return _username.Equals(otherForm._username) && _password.Equals(otherForm._password);
                }
            }

            return false;
        }
    }
}