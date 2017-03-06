using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    class SessionService : MarshalByRefObject, SessionInterface
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
        private Dictionary<string, UserInformation> Users
        {
            get
            {
                return ChatupServer.Instance.Users;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, UserInformation> List()
        {
            return ChatupServer.Instance.Users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        /// <returns></returns>
        public RemoteResponse Logout(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            if (ChatupServer.Instance.Logout(userName))
            {
                OnLogout?.Invoke(Users[userName]);
            }
            else
            {
                return RemoteResponse.PermissionDenied;
            }

            return RemoteResponse.Success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public RemoteResponse Login(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPassword))
            {
                return RemoteResponse.BadRequest;
            }

            var storedPassword = SqliteDatabase.Instance.QueryPassword(userName);

            if (storedPassword.Equals(userPassword))
            {
                if (ChatupServer.Instance.Login(userName, userPassword))
                {
                    OnLogin?.Invoke(Users[userName]);
                }
                else
                {
                    return RemoteResponse.SessionExists;
                }

                return RemoteResponse.Success;
            }
            else
            {
                return RemoteResponse.AuthenticationFailed;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        public RemoteResponse Register(UserForm registerObject)
        {
            if (registerObject == null)
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrEmpty(registerObject.Username) || string.IsNullOrEmpty(registerObject.Password))
            {
                return RemoteResponse.BadRequest;
            }

            var userInformation = new UserInformation(registerObject.Username, registerObject.Name);

            if (SqliteDatabase.Instance.InsertUser(registerObject))
            {
                OnRegister?.Invoke(userInformation);
                Users.Add(registerObject.Username, userInformation);
                ChatupServer.Instance.Session.Register(userInformation);
            }
            else
            {
                return RemoteResponse.ObjectExists;
            }

            return RemoteResponse.Success;
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