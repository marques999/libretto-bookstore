using System;
using System.Collections.Generic;

using ChatupNET.Session;
using ChatupNET.Remoting;

public class SessionService : MarshalByRefObject, SessionInterface
{
    /// <summary>
    /// 
    /// </summary>
    public event LoginHandler OnLogin;

    /// <summary>
    /// 
    /// </summary>
    public event LogoutHandler OnLogout;

    /// <summary>
    /// 
    /// </summary>
    public SessionService()
    {
        OnLogin += Insert;
        OnLogout += Remove;
    }

    /// <summary>
    /// 
    /// </summary>
    private HashSet<string> users = new HashSet<string>();

    /// <summary>
    /// 
    /// </summary>
    public HashSet<string> Users
    {
        get
        {
            return users;
        }
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
    public SessionToken Login(string userName, string userPassword)
    {
        return new SessionToken(userName, "abcdefg");
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
    /// Add client name to the arraylist. This way we maintain the list of all clients connected.
    /// </summary>
    /// <param name="userName"></param>
    public void Insert(string userName)
    {
        if (string.IsNullOrEmpty(userName) == false)
        {
            lock (users)
            {
                users.Add(userName);
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
            lock (users)
            {
                users.Remove(userName);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="registerObject"></param>
    /// <returns></returns>
    public bool Register(RegisterObject registerObject)
    {
        return false;
    }
}