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
                return mUsers;
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
        private bool ValidateSession(string userName)
        {
            return mUsers.ContainsKey(userName) && mUsers[userName].Status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        /// <returns></returns>
        public bool Logout(string userName)
        {
            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.RefreshUsers();
            }

            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            if (!ValidateSession(userName))
            {
                return false;
            }

            OnLogout?.Invoke(mUsers[userName]);
            mUsers[userName].Status = false;
            ChatupServer.Instance.Session.Logout(mUsers[userName]);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public bool Login(string userName, string userPassword)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return false;
            }

            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.RefreshUsers();
            }

            if (ValidateSession(userName))
            {
                return false;
            }

            var userPasword = SqliteDatabase.Instance.QueryPassword(userName);

            if (!userPasword.Equals(userPassword))
            {
                return false;
            }

            var userInformation = mUsers[userName];

            OnLogin?.Invoke(userInformation);
            mUsers[userName].Status = true;
            ChatupServer.Instance.Session.Login(userInformation);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        public bool Register(UserForm registerObject)
        {
            if (registerObject == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(registerObject.Username) || string.IsNullOrEmpty(registerObject.Password))
            {
                return false;
            }

            if (mUsers == null)
            {
                mUsers = ChatupServer.Instance.Users;
            }

            var userInformation = new UserInformation(registerObject.Username, registerObject.Name);
            bool operationResult = SqliteDatabase.Instance.InsertUser(registerObject);

            if (operationResult)
            {
                OnRegister?.Invoke(userInformation);
                ChatupServer.Instance.Session.Register(userInformation);
            }

            return operationResult;
        }
    }
}