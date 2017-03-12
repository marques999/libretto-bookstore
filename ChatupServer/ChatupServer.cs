using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Model;
using ChatupNET.Forms;
using ChatupNET.Remoting;

public class ChatupServer
{
    /// <summary>
    /// Default constructor
    /// </summary>
    private ChatupServer()
    {
        lastId = 0;
        users = SqliteDatabase.Instance.QueryUsers();
        rooms = SqliteDatabase.Instance.QueryRooms();
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
        RemotingConfiguration.RegisterActivatedServiceType(typeof(RoomInterface));

        if (rooms.Count > 0)
        {
            lastId = rooms.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private int lastId;

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
    private Dictionary<string, Address> connections = new Dictionary<string, Address>();

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
    public void InitializeSession(
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
    /// <param name="loginHandler"></param>
    /// <param name="logoutHandler"></param>
    /// <param name="registerHandler"></param>
    public void DestroySession(
        UserHandler loginHandler,
        UserHandler logoutHandler,
        UserHandler registerHandler)
    {
        sessionIntermediate.OnLogin -= loginHandler;
        sessionIntermediate.OnLogout -= logoutHandler;
        sessionIntermediate.OnRegister -= registerHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createHandler"></param>
    /// <param name="deleteHandler"></param>
    /// <param name="updateHandler"></param>
    public void InitializeLobby(
        RoomInsertHandler createHandler,
        RoomDeleteHandler deleteHandler,
        RoomUpdateHandler updateHandler)
    {
        lobbyIntermediate.OnCreate += createHandler;
        lobbyIntermediate.OnDelete += deleteHandler;
        lobbyIntermediate.OnUpdate += updateHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createHandler"></param>
    /// <param name="deleteHandler"></param>
    /// <param name="updateHandler"></param>
    public void DestroyLobby(
        RoomInsertHandler createHandler,
        RoomDeleteHandler deleteHandler,
        RoomUpdateHandler updateHandler)
    {
        lobbyIntermediate.OnCreate -= createHandler;
        lobbyIntermediate.OnDelete -= deleteHandler;
        lobbyIntermediate.OnUpdate -= updateHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    private bool ValidateSession(string userName)
    {
        return Users.ContainsKey(userName) && Users[userName].Status;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns></returns>
    public bool Login(UserLogin userLogin)
    {
        var userName = userLogin.Username;
        bool operationResult = !ValidateSession(userName);

        if (operationResult)
        {
            users[userName].Status = true;
            connections.Add(userName, userLogin.Host);
            sessionIntermediate.Login(users[userName]);
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public bool Logout(string userName)
    {
        bool operationResult = ValidateSession(userName);

        if (operationResult)
        {
            users[userName].Status = false;

            if (connections.ContainsKey(userName))
            {
                connections.Remove(userName);
            }

            sessionIntermediate.Logout(Users[userName]);
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    /// <returns></returns>
    public bool RegisterChatrooom(int roomId, Room roomInformation)
    {
        try
        {
            RemotingServices.Marshal(new RoomService(roomInformation), FormatUri(roomId));
            rooms.Add(roomId, roomInformation);
            lobbyIntermediate.CreateRoom(roomId, roomInformation);
        }
        catch (RemotingException)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public void DestroyChatroom(int roomId)
    {
        lobbyIntermediate.DeleteRoom(roomId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    private string FormatUri(int roomId)
    {
        return string.Format("chatroom-{0:D}.rem", roomId);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public Address LookupHost(string userName)
    {
        if (connections.ContainsKey(userName))
        {
            return connections[userName];
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public string LookupChatroom(int roomId)
    {
        return "tcp://localhost:12480/" + FormatUri(roomId);
    }

    /// <summary>
    /// 
    /// </summary>
    public int NextID
    {
        get
        {
            return ++lastId;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<int, Room> Rooms
    {
        get
        {
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