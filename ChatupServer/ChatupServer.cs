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
    private int lastId = 0;

    /// <summary>
    /// 
    /// </summary>
    private static ChatupServer instance;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, Room> rooms = SqliteDatabase.Instance.QueryRooms();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<string, UserInformation> users = SqliteDatabase.Instance.QueryUsers();

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
        RoomHandler createHandler,
        DeleteHandler deleteHandler,
        RoomHandler updateHandler)
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
        RoomHandler createHandler,
        DeleteHandler deleteHandler,
        RoomHandler updateHandler)
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
        return Users.ContainsKey(userName) && Users[userName].Online;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userLogin"></param>
    /// <returns></returns>
    public UserInformation Login(UserLogin userLogin)
    {
        var userName = userLogin.Username;

        if (ValidateSession(userName))
        {
            return null;
        }

        users[userName].Host = FormatHost(userLogin.Host);
        connections.Add(userName, userLogin.Host);
        sessionIntermediate.Login(users[userName]);

        return users[userName];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public UserInformation Logout(string userName)
    {
        if (ValidateSession(userName))
        {
            users[userName].Host = null;

            if (connections.ContainsKey(userName))
            {
                connections.Remove(userName);
            }

            sessionIntermediate.Logout(Users[userName]);
        }
        else
        {
            return null;
        }

        return users[userName];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    /// <returns></returns>
    public bool RegisterChatrooom(Room roomInformation)
    {
        try
        {
            RemotingServices.Marshal(new RoomService(roomInformation), FormatUri(roomInformation.ID));
            rooms.Add(roomInformation.ID, roomInformation);
            lobbyIntermediate.CreateRoom(roomInformation);
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
    public string LookupHost(string userName)
    {
        if (connections.ContainsKey(userName))
        {
            var connectionInformation = connections[userName];

            if (connectionInformation != null)
            {
                FormatHost(connectionInformation);
            }
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    private string FormatHost(Address connectionInformation)
    {
        return string.Format("tcp://{0}:{1:D}/messaging.rem", connectionInformation.Host, connectionInformation.Port);
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