using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Model;
using ChatupNET.Forms;
using ChatupNET.Remoting;

public class ChatupServer
{
    /// <summary>
    /// Default constructor for the "ChatupServer" class
    /// </summary>
    private ChatupServer()
    {
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
    }

    /// <summary>
    /// 
    /// </summary>
    private static ChatupServer instance;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, Room> rooms;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<string, UserInformation> users;

    /// <summary>
    /// 
    /// </summary>
    private LobbyIntermediate lobbyIntermediate = new LobbyIntermediate();

    /// <summary>
    /// 
    /// </summary>
    private SessionIntermediate sessionIntermediate = new SessionIntermediate();

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
    public LobbyIntermediate Lobby
    {
        get
        {
            return lobbyIntermediate;
        }
    }

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
        UserHandler registerHandler
    )
    {
        sessionIntermediate.OnLogin += loginHandler;
        sessionIntermediate.OnLogout += logoutHandler;
        sessionIntermediate.OnRegister += registerHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createHandler"></param>
    /// <param name="deleteHandler"></param>
    /// <param name="updateHandler"></param>
    public void LobbyActivator(
        RoomInsertHandler createHandler,
        RoomDeleteHandler deleteHandler,
        RoomUpdateHandler updateHandler
    )
    {
        lobbyIntermediate.OnCreate += createHandler;
        lobbyIntermediate.OnDelete += deleteHandler;
        lobbyIntermediate.OnUpdate += updateHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<int, Room> Rooms
    {
        get
        {
            if (rooms == null)
            {
                rooms = SqliteDatabase.Instance.QueryRooms();
            }

            return rooms;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, UserInformation> Users
    {
        get
        {
            if (users == null)
            {
                users = SqliteDatabase.Instance.QueryUsers();
            }

            return users;
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