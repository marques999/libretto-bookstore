using System;

namespace ChatupNET.Remoting
{
    public class SessionIntermediate : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        public event LoginHandler OnLogin;

        /// <summary>
        /// 
        /// </summary>
        public event LogoutHandler OnLogout;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void Login(string userName)
        {
            OnLogin(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        public void Logout(string userName)
        {
            OnLogout(userName);
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