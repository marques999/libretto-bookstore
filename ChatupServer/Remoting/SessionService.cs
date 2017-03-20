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
        /// <returns></returns>
        public Dictionary<string, UserInformation> List()
        {
            return ChatupServer.Instance.Users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public RemoteResponse Logout(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.BadRequest;
            }

            var userInformation = ChatupServer.Instance.Logout(userName);

            if (userInformation != null)
            {
                OnLogout?.Invoke(userInformation);
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
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public RemoteResponse Login(UserLogin userLogin)
        {
            var userName = userLogin.Username;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userLogin.Pasword))
            {
                return RemoteResponse.BadRequest;
            }

            var storedPassword = SqliteDatabase.Instance.QueryPassword(userName);

            if (storedPassword.Equals(userLogin.Pasword))
            {
                var userInformation = ChatupServer.Instance.Login(userLogin);

                if (userInformation != null)
                {
                    OnLogin?.Invoke(userInformation);
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
        /// <param name="userForm"></param>
        /// <returns></returns>
        public RemoteResponse Register(UserForm userForm)
        {
            if (userForm == null)
            {
                return RemoteResponse.BadRequest;
            }

            if (string.IsNullOrEmpty(userForm.Username) || string.IsNullOrEmpty(userForm.Password))
            {
                return RemoteResponse.BadRequest;
            }

            var userInformation = new UserInformation(userForm.Username, userForm.Name, null);

            if (SqliteDatabase.Instance.InsertUser(userForm))
            {
                OnRegister?.Invoke(userInformation);
                ChatupServer.Instance.Users.Add(userForm.Username, userInformation);
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