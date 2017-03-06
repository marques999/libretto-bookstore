using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    public delegate void UserHandler(UserInformation userName);

    /// <summary>
    /// 
    /// </summary>
    public interface SessionInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event UserHandler OnLogin;

        /// <summary>
        /// 
        /// </summary>
        event UserHandler OnLogout;

        /// <summary>
        /// 
        /// </summary>
        event UserHandler OnRegister;

        /// <summary>
        /// 
        /// </summary>
        Dictionary<string, UserInformation> Users
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        RemoteResponse Login(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Logout(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        RemoteResponse Register(UserForm registerObject);
    }
}