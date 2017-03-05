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
        /// <returns></returns>
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
        /// 

        bool Login(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        /// <returns></returns>
        bool Logout(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        bool Register(UserForm registerObject);
    }
}