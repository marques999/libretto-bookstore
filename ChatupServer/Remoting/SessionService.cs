using System;
using System.Collections.Generic;

using ChatupNET.Session;
using ChatupNET.Database;
using ChatupNET.Database.Enums;

namespace ChatupNET.Remoting
{
    class SessionService : MarshalByRefObject, SessionInterface
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
        private Dictionary<string, string> userTokens = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public HashSet<string> Users
        {
            get
            {
                return ChatupServer.Instance.QueryUsers();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override object InitializeLifetimeService()
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        private bool ValidateSession(string userName, string userToken)
        {
            return userTokens.ContainsKey(userName) && userTokens[userName].Equals(userToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        /// <returns></returns>
        public bool Logout(SessionToken userInstance)
        {
            var userName = userInstance.Username;

            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            if (ValidateSession(userName, userInstance.Token))
            {
                userTokens.Remove(userName);
                OnLogout(userName);
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public SessionToken Login(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName) || userTokens.ContainsKey(userName))
            {
                return null;
            }

            var userPasword = ChatupServer.Instance.QueryPassword(userName);

            if (!userPasword.Equals(userPassword))
            {
                return null;
            }

            var userToken = "generateToken";

            userTokens.Add(userName, userToken);
            OnLogin(userName);

            return new SessionToken(userName, "-1");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        public bool Register(RegisterObject registerObject)
        {
            if (registerObject == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(registerObject.Username) || string.IsNullOrEmpty(registerObject.Password))
            {
                return false;
            }

            return ChatupServer.Instance.InsertUser(registerObject);
        }
    }
}