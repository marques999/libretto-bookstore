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
        public Dictionary<string, UserInformation> mUsers;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, UserInformation> Users
        {
            get
            {
                if (mUsers == null)
                {
                    mUsers = ChatupServer.Instance.Users;
                }

                return mUsers;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userToken"></param>
        /// <returns></returns>
        private bool ValidateSession(string userName)
        {
            return mUsers.ContainsKey(userName) && mUsers[userName].Status;
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
                return RemoteResponse.MissingParameters;
            }

            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.Users;
            }

            if (!ValidateSession(userName))
            {
                return RemoteResponse.InsufficientPermissions;
            }

            OnLogout?.Invoke(mUsers[userName]);
            mUsers[userName].Status = false;
            ChatupServer.Instance.Session.Logout(mUsers[userName]);

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
            if (string.IsNullOrEmpty(userName))
            {
                return RemoteResponse.MissingParameters;
            }

            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.Users;
            }

            if (ValidateSession(userName))
            {
                return RemoteResponse.SessionExists;
            }

            var userPasword = SqliteDatabase.Instance.QueryPassword(userName);

            if (!userPasword.Equals(userPassword))
            {
                return RemoteResponse.AuthenticationFailed;
            }

            var userInformation = mUsers[userName];

            OnLogin?.Invoke(userInformation);
            mUsers[userName].Status = true;
            ChatupServer.Instance.Session.Login(userInformation);

            return RemoteResponse.Success;
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
                return RemoteResponse.MissingParameters;
            }

            if (string.IsNullOrEmpty(registerObject.Username) || string.IsNullOrEmpty(registerObject.Password))
            {
                return RemoteResponse.MissingParameters;
            }

            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.Users;
            }

            var userInformation = new UserInformation(registerObject.Username, registerObject.Name);

            if (SqliteDatabase.Instance.InsertUser(registerObject))
            {
                OnRegister?.Invoke(userInformation);
                mUsers.Add(registerObject.Username, userInformation);
                ChatupServer.Instance.Session.Register(userInformation);
            }
            else
            {
                return RemoteResponse.EntityExists;
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