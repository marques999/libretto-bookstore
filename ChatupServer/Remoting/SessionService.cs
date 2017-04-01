using System;
using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    internal class SessionService : MarshalByRefObject, SessionInterface
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
        public Dictionary<string, UserInformation> Users => ChatupServer.Instance.Users;

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

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userLogin.Password))
            {
                return RemoteResponse.BadRequest;
            }

            var storedPassword = SqliteDatabase.Instance.QueryPassword(userName);

            if (storedPassword != userLogin.Password)
            {
                return RemoteResponse.AuthenticationFailed;
            }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userForm"></param>
        /// <returns></returns>
        public RemoteResponse Register(UserForm userForm)
        {
            if (string.IsNullOrEmpty(userForm?.Username) || string.IsNullOrEmpty(userForm.Password))
            {
                return RemoteResponse.BadRequest;
            }

            var userInformation = new UserInformation(userForm.Username, userForm.Name, null);

            if (Users.ContainsKey(userForm.Username))
            {
                return RemoteResponse.UserExists;
            }

            if (SqliteDatabase.Instance.InsertUser(userForm))
            {
                OnRegister?.Invoke(userInformation);
                Users.Add(userForm.Username, userInformation);
                ChatupServer.Instance.Session.Register(userInformation);
            }
            else
            {
                return RemoteResponse.OperationFailed;
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