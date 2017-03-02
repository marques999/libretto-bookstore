using System.Collections.Generic;

using ChatupNET.Session;

namespace ChatupNET.Remoting
{
    public delegate void LoginHandler(string userName);
    public delegate void LogoutHandler(string userName);

    public interface SessionInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event LoginHandler OnLogin;

        /// <summary>
        /// 
        /// </summary>
        event LogoutHandler OnLogout;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        HashSet<string> Users
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        SessionToken Login(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInstance"></param>
        /// <returns></returns>
        bool Logout(SessionToken userInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registerObject"></param>
        /// <returns></returns>
        bool Register(RegisterObject registerObject);
    }
}