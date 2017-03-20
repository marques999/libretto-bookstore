using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Forms;
using ChatupNET.Model;
using ChatupNET.Remoting;

class ChatupServer
{
    /// <summary>
    /// Default constructor
    /// </summary>
    private ChatupServer()
    {
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
        RemotingConfiguration.RegisterActivatedServiceType(typeof(RoomInterface));

        if (_rooms.Count > 0)
        {
            lastId = _rooms.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;

            foreach (var roomInformation in _rooms)
            {
                LaunchChatroom(roomInformation.Value);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private int lastId = 0;

    /// <summary>
    /// 
    /// </summary>
    private event RoomHandler OnJoin;

    /// <summary>
    /// 
    /// </summary>
    private event RoomHandler OnLeave;

    /// <summary>
    /// 
    /// </summary>
    private static ChatupServer _instance;

    /// <summary>
    /// 
    /// </summary>
    private LobbyIntermediate _lobbyInterface = new LobbyIntermediate();

    /// <summary>
    /// 
    /// </summary>
    private SessionIntermediate _sessionInterface = new SessionIntermediate();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, Room> _rooms = SqliteDatabase.Instance.QueryRooms();

    /// <summary>
    ///
    /// </summary>
    private Dictionary<string, Address> _connections = new Dictionary<string, Address>();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<string, UserInformation> _users = SqliteDatabase.Instance.QueryUsers();

    /// <summary>
    /// Public getter property for the "_instance" private member
    /// </summary>
    public static ChatupServer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ChatupServer();
            }

            return _instance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public LobbyIntermediate Lobby
    {
        get
        {
            return _lobbyInterface;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public SessionIntermediate Session
    {
        get
        {
            return _sessionInterface;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<int, Room> Rooms
    {
        get
        {
            return _rooms;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<string, UserInformation> Users
    {
        get
        {
            return _users;
        }
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
    /// <param name="loginHandler"></param>
    /// <param name="logoutHandler"></param>
    /// <param name="registerHandler"></param>
    public void InitializeSession(UserHandler loginHandler, UserHandler logoutHandler, UserHandler registerHandler)
    {
        _sessionInterface.OnLogin += loginHandler;
        _sessionInterface.OnLogout += logoutHandler;
        _sessionInterface.OnRegister += registerHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="loginHandler"></param>
    /// <param name="logoutHandler"></param>
    /// <param name="registerHandler"></param>
    public void DestroySession(UserHandler loginHandler, UserHandler logoutHandler, UserHandler registerHandler)
    {
        _sessionInterface.OnLogin -= loginHandler;
        _sessionInterface.OnLogout -= logoutHandler;
        _sessionInterface.OnRegister -= registerHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="insertHandler"></param>
    /// <param name="deleteHandler"></param>
    public void InitializeLobby(InsertHandler insertHandler, DeleteHandler deleteHandler)
    {
        _lobbyInterface.OnInsert += insertHandler;
        _lobbyInterface.OnDelete += deleteHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="insertHandler"></param>
    /// <param name="deleteHandler"></param>
    public void DestroyLobby(InsertHandler insertHandler, DeleteHandler deleteHandler)
    {
        _lobbyInterface.OnInsert -= insertHandler;
        _lobbyInterface.OnDelete -= deleteHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    public void InitializeRoom(RoomHandler joinHandler, RoomHandler leaveHandler)
    {
        OnJoin += joinHandler;
        OnLeave += leaveHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    public void DestroyRoom(RoomHandler joinHandler, RoomHandler leaveHandler)
    {
        OnJoin -= joinHandler;
        OnLeave -= leaveHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    /// <param name="userName"></param>
    public void JoinRoom(Room roomInformation, string userName)
    {
        OnJoin?.Invoke(roomInformation, userName, _users[userName].Name);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    /// <param name="userName"></param>
    public void LeaveRoom(Room roomInformation, string userName)
    {
        OnLeave?.Invoke(roomInformation, userName, _users[userName].Name);
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

        _users[userName].Host = FormatHost(userLogin.Host);
        _connections.Add(userName, userLogin.Host);
        _sessionInterface.Login(_users[userName]);

        return _users[userName];
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
            _users[userName].Host = null;

            if (_connections.ContainsKey(userName))
            {
                _connections.Remove(userName);
            }

            _sessionInterface.Logout(Users[userName]);
        }
        else
        {
            return null;
        }

        return _users[userName];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    public void LaunchChatroom(Room roomInformation)
    {
        RemotingServices.Marshal(new RoomService(roomInformation), FormatUri(roomInformation.ID));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomInformation"></param>
    /// <returns></returns>
    public bool RegisterChatrooom(Room roomInformation)
    {
        try
        {
            LaunchChatroom(roomInformation);
            _rooms.Add(roomInformation.ID, roomInformation);
            _lobbyInterface.CreateRoom(roomInformation);
            SqliteDatabase.Instance.InsertRoom(roomInformation);
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
    /// <returns></returns>
    private string FormatUri(int roomId)
    {
        return string.Format("chatroom_{0:D}.rem", roomId);
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
    /// <param name="connectionInformation"></param>
    /// <returns></returns>
    private string FormatHost(Address connectionInformation)
    {
        return string.Format("tcp://{0}:{1:D}/messaging.rem", connectionInformation.Host, connectionInformation.Port);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    public string LookupHost(string userName)
    {
        if (_connections.ContainsKey(userName))
        {
            var connectionInformation = _connections[userName];

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
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}