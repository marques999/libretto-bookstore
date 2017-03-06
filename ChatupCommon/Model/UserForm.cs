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
            mUsername = userName;
            mPassword = userPassword;
            mFullName = fullName;
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
        private string mFullName;

        /// <summary>
        /// Public getter property for the "mName" private member
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
        private string mPassword;

        /// <summary>
        /// Public getter property for the "mPassword" private member
        /// </summary>
        public string Password
        {
            get
            {
                return mPassword;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return mUsername.GetHashCode() * 31 + mPassword.GetHashCode();
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
                    return Username.Equals(otherForm.Username) && Password.Equals(otherForm.Password);
                }
            }

            return false;
        }
    }
}