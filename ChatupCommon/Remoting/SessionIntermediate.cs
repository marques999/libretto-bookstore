using System;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    ///
    /// </summary>
    public class SessionIntermediate : MarshalByRefObject
    {
        /// <summary>
        ///
        /// </summary>
        public event UserHandler OnLogin;

        /// <summary>
        ///
        /// </summary>
        public event UserHandler OnLogout;

        /// <summary>
        ///
        /// </summary>
        public event UserHandler OnRegister;

        /// <summary>
        ///
        /// </summary>
        /// <param name="userInformation"></param>
        public void Logout(UserInformation userInformation)
        {
            OnLogout?.Invoke(userInformation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userInformation"></param>
        public void Login(UserInformation userInformation)
        {
            OnLogin?.Invoke(userInformation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userInformation"></param>
        public void Register(UserInformation userInformation)
        {
            OnRegister?.Invoke(userInformation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}