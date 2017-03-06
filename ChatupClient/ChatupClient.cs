using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Forms;
using ChatupNET.Remoting;
using ChatupNET.Model;

public class ChatupClient
{
    /// <summary>
    /// Default constructor for the "ChatupCient" class
    /// </summary>
    private ChatupClient()
    {
        RemotingConfiguration.Configure("ChatupClient.exe.config", false);
        mSession = (SessionInterface)RemoteAccess.New(typeof(SessionInterface));
        mLobby = (LobbyInterface)RemoteAccess.New(typeof(LobbyInterface));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void IntializeSession(SessionIntermediate sessionIntermediate)
    {
        mSession.OnLogin += sessionIntermediate.Login;
        mSession.OnLogout += sessionIntermediate.Logout;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void DestroySession(SessionIntermediate sessionIntermediate)
    {
        mSession.OnLogin -= sessionIntermediate.Login;
        mSession.OnLogout -= sessionIntermediate.Logout;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void InitializeLobby(LobbyIntermediate lobbyIntermediate)
    {
        mLobby.OnInsert += lobbyIntermediate.CreateRoom;
        mLobby.OnDelete += lobbyIntermediate.DeleteRoom;
        mLobby.OnUpdate += lobbyIntermediate.UpdateRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void DestroyLobby(LobbyIntermediate lobbyIntermediate)
    {
        mLobby.OnInsert -= lobbyIntermediate.CreateRoom;
        mLobby.OnDelete -= lobbyIntermediate.DeleteRoom;
        mLobby.OnUpdate -= lobbyIntermediate.UpdateRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="chatroomIntermediate"></param>
    public void InitializeRoom(int roomId, RoomIntermediate chatroomIntermediate)
    {
        var chatroomInstance = Room(roomId);

        if (chatroomInstance != null)
        {
            chatroomInstance.OnJoin += chatroomIntermediate.JoinRoom;
            chatroomInstance.OnLeave += chatroomIntermediate.LeaveRoom;
            chatroomInstance.OnSend += chatroomIntermediate.SendMessage;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="chatroomIntermediate"></param>
    public void DestroyRoom(int roomId, RoomIntermediate chatroomIntermediate)
    {
        var chatroomInstance = Room(roomId);

        if (chatroomInstance != null)
        {
            chatroomInstance.OnJoin -= chatroomIntermediate.JoinRoom;
            chatroomInstance.OnLeave -= chatroomIntermediate.LeaveRoom;
            chatroomInstance.OnSend -= chatroomIntermediate.SendMessage;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private SessionInterface mSession;

    /// <summary>
    /// Public getter property for the "mSession" private member
    /// </summary>
    public SessionInterface Session
    {
        get
        {
            return mSession;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, RoomInterface> mRooms = new Dictionary<int, RoomInterface>();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <returns></returns>
    public RoomInterface Room(int roomId)
    {
        if (mRooms.ContainsKey(roomId))
        {
            return mRooms[roomId];
        }

        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    private LobbyInterface mLobby;

    /// <summary>
    /// Public getter property for the "mLobby" private member
    /// </summary>
    public LobbyInterface Lobby
    {
        get
        {
            return mLobby;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private static ChatupClient mInstance;

    /// <summary>
    /// Public getter property for the "mInstance" private member
    /// </summary>
    public static ChatupClient Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = new ChatupClient();
            }

            return mInstance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private string mUsername;

    /// <summary>
    /// Public getter property for the "username" private member
    /// </summary>
    public string Username
    {
        get
        {
            return mUsername;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private bool mActive;

    /// <summary>
    /// Public getter property for the "active" private member
    /// </summary>
    public bool Active
    {
        get
        {
            return mActive && mUsername != null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userPassword"></param>
    /// <returns></returns>
    public RemoteResponse Login(string userName, string userPassword)
    {
        RemoteResponse operationResult = mSession.Login(userName, userPassword);

        if (operationResult == RemoteResponse.Success)
        {
            mActive = true;
            mUsername = userName;
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public RemoteResponse Logout()
    {
        RemoteResponse operationResult = mSession.Logout(mUsername);

        if (operationResult == RemoteResponse.Success)
        {
            mActive = false;
            mUsername = null;
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new LoginForm());
    }
}