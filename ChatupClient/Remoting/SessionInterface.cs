using System.Collections.Generic;

public delegate void JoinHandler(string userName);
public delegate void LeaveHandler(string userName);

public interface SessionInterface
{
    /// <summary>
    /// 
    /// </summary>
    event JoinHandler OnJoin;

    /// <summary>
    /// 
    /// </summary>
    event LeaveHandler OnLeave;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    HashSet<string> GetUsers();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPassword"></param>
    /// <returns></returns>
    string Login(string userName, string userPassword);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userInstance"></param>
    /// <returns></returns>
    bool Logout(SessionToken userInstance);
}