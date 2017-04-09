using System.Collections.Generic;
using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="userInformation"></param>
    public delegate void UserHandler(UserInformation userInformation);

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
        /// <returns></returns>
        RemoteResponse Logout(string userName);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        RemoteResponse Login(UserLogin userLogin);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userForm"></param>
        /// <returns></returns>
        RemoteResponse Register(UserForm userForm);
    }
}