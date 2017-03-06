using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Model;
using ChatupNET.Forms;
using ChatupNET.Remoting;

using System.Linq;

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
    private Dictionary<int, GroupChatroom> objects = new Dictionary<int, GroupChatroom>();

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
    /// <param name="userName"></param>
    /// <param name="userPassword"></param>
    /// <returns></returns>
    public bool Login(string userName, string userPassword)
    {
        bool operationResult = ValidateSession(userName);

        if (operationResult)
        {
            users[userName].Status = true;
            sessionIntermediate.Login(users[userName]);
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userToken"></param>
    /// <returns></returns>
    private bool ValidateSession(string userName)
    {
        return Users.ContainsKey(userName) && Users[userName].Status;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    public bool Logout(string userName)
    {
        bool operationResult = ValidateSession(userName);

        if (operationResult)
        {
            users[userName].Status = false;
            sessionIntermediate.Logout(Users[userName]);
        }

        return operationResult;
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
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    public bool RegisterChatrooom(int roomId, Room roomInformation)
    {
        var chatroomInstance = new GroupChatroom(roomInformation);

        try
        {
            RemotingServices.Marshal(chatroomInstance, FormatUri(roomId));
            rooms.Add(roomId, roomInformation);
            objects.Add(roomId, chatroomInstance);
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
        if (objects.ContainsKey(roomId))
        {
            var roomInstance = objects[roomId];

            if (roomInstance != null)
            {
                RemotingServices.Disconnect(roomInstance);
                lobbyIntermediate.DeleteRoom(roomId);
            }
        }
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
    /// <param name="roomId"></param>
    /// <returns></returns>
    public string FindChatroom(int roomId)
    {
        if (objects.ContainsKey(roomId))
        {
            return FormatUri(roomId);
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    private int lastId;

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
            if (rooms == null)
            {
                rooms = SqliteDatabase.Instance.QueryRooms();

                if (rooms.Count > 0)
                {
                    lastId = rooms.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;
                }
                else
                {
                    lastId = 0;
                }
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