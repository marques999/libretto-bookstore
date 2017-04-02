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
        ///
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public string Username
        {
            get;
        }

        /// <summary>
        ///
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
                return Username == otherForm.Username && Password == otherForm.Password;
            }

            return false;
        }
    }
}