using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Model;
using ChatupNET.Forms;
using ChatupNET.Remoting;
using ChatupNET.Rooms;

public class ChatupServer
{
    /// <summary>
    /// Default constructor for the "ChatupServer" class
    /// </summary>
    private ChatupServer()
    {
        roomsInitialized = false;
        usersInitialized = false;
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
    }

    /// <summary>
    /// 
    /// </summary>
    /// 
    private static ChatupServer instance;

    /// <summary>
    /// Public getter property for the "instance" private member
    /// </summary>
    public static ChatupServer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChatupServer();
            }

            return instance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private static SessionIntermediate sessionIntermediate = new SessionIntermediate();

    /// <summary>
    /// 
    /// </summary>
    private bool roomsInitialized;

    /// <summary>
    /// 
    /// </summary>
    private bool usersInitialized;

    /// <summary>
    /// 
    /// </summary>
    public SessionIntermediate Session
    {
        get
        {
            return sessionIntermediate;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginHandler"></param>
    /// <param name="logoutHandler"></param>
    /// <param name="registerHandler"></param>
    public void SessionActivator(
        UserHandler loginHandler,
        UserHandler logoutHandler,
        UserHandler registerHandler)
    {
        sessionIntermediate.OnLogin += loginHandler;
        sessionIntermediate.OnLogout += logoutHandler;
        sessionIntermediate.OnRegister += registerHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, GroupChatroom> rooms = new Dictionary<int, GroupChatroom>();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<string, UserInformation> users = new Dictionary<string, UserInformation>();

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal Dictionary<int, GroupChatroom> RefreshRooms()
    {
        if (roomsInitialized)
        {
            return rooms;
        }

        roomsInitialized = true;
        rooms = SqliteDatabase.Instance.QueryRooms();

        return rooms;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    internal Dictionary<string, UserInformation> RefreshUsers()
    {
        if (usersInitialized)
        {
            return users;
        }

        usersInitialized = true;
        users = SqliteDatabase.Instance.QueryUsers();

        return users;
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<int, GroupChatroom> Rooms
    {
        get
        {
            return RefreshRooms();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, UserInformation> Users
    {
        get
        {
            return RefreshUsers();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}