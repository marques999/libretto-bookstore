using System;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
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
            Name = fullName;
            Username = userName;
            Password = userPassword;
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
        /// Public getter property for the "Password" private member
        /// </summary>
        public string Password
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Username.GetHashCode() * 31 + Password.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            var otherForm = otherInstance as UserForm;

            if (otherForm != null)
            {
                return Username.Equals(otherForm.Username) && Password.Equals(otherForm.Password);
            }

            return false;
        }
    }
}