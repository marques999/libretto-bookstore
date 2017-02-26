using System;
using System.Collections.Generic;

using ChatupNET.Session;

namespace ChatupNET.Remoting
{
    class SessionService : MarshalByRefObject, SessionInterface
    {
        /// <summary>
        /// 
        /// </summary>
        public event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        public event LeaveHandler OnLeave;

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, string> userTokens = new Dictionary<string, string>();

        /// <summary>
        /// 
        /// </summary>
        public HashSet<string> GetUsers()
        {
            return new HashSet<string>(userTokens.Keys);
        }

        /// <summary>
        /// 
        /// </summary>
        private Dictionary<string, string> userDatabase = new Dictionary<string, string>()
        {
            {
                "marques999", "14191091aB"
            },
            {
                "jabst123", "eyb0sserino"
            },
            {
                "somouco", "dormirebom666"
            }
        };

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
            if (ValidateSession(userInstance.Username, userInstance.Token))
            {
                userTokens.Remove(userInstance.Username);
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
        public string Login(string userName, string userPassword)
        {
            // check if user is not currently associated with a session
            if (userTokens.ContainsKey(userName))
            {
                return null;
            }

            // check if username exists in the user database
            if (userDatabase.ContainsKey(userName) == false)
            {
                return null;
            }

            // check user password against password stored in the database
            if (userDatabase[userName].Equals(userPassword) == false)
            {
                return null;
            }

            // generate session token
            var userToken = "generateToken";

            // 
            userTokens.Add(userName, userToken);
            OnJoin(userName);

            return userToken;
        }
    }
}