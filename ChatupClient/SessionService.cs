using System;
using System.Collections.Generic;

public class SessionService : MarshalByRefObject, SessionInterface
{
    /// <summary>
    /// 
    /// </summary>
    public event JoinHandler OnJoin;

    /// <summary>
    /// 
    /// </summary>
    public event LeaveHandler OnLeave;

    /// <summary>
    /// 
    /// </summary>
    private HashSet<string> activeUsers = new HashSet<string>();

    /// <summary>
    /// 
    /// </summary>
    public HashSet<string> GetUsers()
    {
        return activeUsers;
    }

    /// <summary>
    /// 
    /// </summary>
    public SessionService()
    {
        OnJoin += Insert;
        OnLeave += Remove;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userInstance"></param>
    /// <returns></returns>
    public bool Logout(SessionToken userInstance)
    {
        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPassword"></param>
    /// <returns></returns>
    public string Login(string userName, string userPassword)
    {
        return "abcdefg";
    }

    public override object InitializeLifetimeService() { return (null); }

    /// <summary>
    /// Add client name to the arraylist. This way we maintain the list of all clients connected.
    /// </summary>
    /// <param name="userName"></param>
    public void Insert(string userName)
    {
        if (string.IsNullOrEmpty(userName) == false)
        {
            lock (activeUsers)
            {
                activeUsers.Add(userName);
            }
        }
    }

    /// <summary>
    /// Remove the disconnected client from the arraylist.
    /// </summary>
    /// <param name="userName"></param>
    public void Remove(string userName)
    {
        if (string.IsNullOrEmpty(userName) == false)
        {
            lock (activeUsers)
            {
                activeUsers.Remove(userName);
            }
        }
    }
}