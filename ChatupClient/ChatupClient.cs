using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Forms;
using ChatupNET.Remoting;
using ChatupNET.Model;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using System.Drawing;

public class ChatupClient
{
    /// <summary>
    /// Default constructor for the "ChatupCient" class
    /// </summary>
    private ChatupClient()
    {
        var clientProvider = new BinaryClientFormatterSinkProvider();
        var serverProvider = new BinaryServerFormatterSinkProvider();

        var props = new Hashtable()
        {
            { "port", 0 }
        };

        RemotingConfiguration.Configure("ChatupClient.exe.config", false);
        serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

        var tcpChannel = new TcpChannel(props, clientProvider, serverProvider);

        ChannelServices.RegisterChannel(tcpChannel, false);
        mChat = new MessageIntermediate();
        mColor = ColorGenerator.Random();
        mLobby = (LobbyInterface)RemoteAccess.New(typeof(LobbyInterface));
        mSession = (SessionInterface)RemoteAccess.New(typeof(SessionInterface));
        mHost = new Address((ushort)new Uri(((ChannelDataStore)tcpChannel.ChannelData).ChannelUris[0]).Port);

        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(MessageService),
            "messaging.rem",
            WellKnownObjectMode.Singleton
        );
    }

    /// <summary>
    /// 
    /// </summary>
    private Color mColor;

    /// <summary>
    /// 
    /// </summary>
    public Color Color
    {
        get
        {
            return mColor;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private Address mHost;

    /// <summary>
    /// 
    /// </summary>
    public Address Host
    {
        get
        {
            return mHost;
        }
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
    /// <param name="lobbyIntermediate"></param>
    public void InitializeLobby(LobbyIntermediate lobbyIntermediate)
    {
        mLobby.OnInsert += lobbyIntermediate.CreateRoom;
        mLobby.OnDelete += lobbyIntermediate.DeleteRoom;
        mLobby.OnUpdate += lobbyIntermediate.UpdateRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lobbyIntermediate"></param>
    public void DestroyLobby(LobbyIntermediate lobbyIntermediate)
    {
        mLobby.OnInsert -= lobbyIntermediate.CreateRoom;
        mLobby.OnDelete -= lobbyIntermediate.DeleteRoom;
        mLobby.OnUpdate -= lobbyIntermediate.UpdateRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="messageHandler"></param>
    public void InitializeMessaging(
        ConnectHandler connectHandler,
        LeaveHandler leaveHandler,
        MessageHandler messageHandler)
    {
        mChat.OnConnect += connectHandler;
        mChat.OnDisconnect += leaveHandler;
        mChat.OnReceive += messageHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="messageHandler"></param>
    public void DestroyMessaging(
        ConnectHandler connectHandler,
        LeaveHandler leaveHandler,
        MessageHandler messageHandler)
    {
        mChat.OnConnect -= connectHandler;
        mChat.OnDisconnect -= leaveHandler;
        mChat.OnReceive -= messageHandler;
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
    private MessageIntermediate mChat;

    /// <summary>
    /// Public getter property for the "mChat" private member
    /// </summary>
    public MessageIntermediate Messaging
    {
        get
        {
            return mChat;
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
    public UserProfile Profile
    {
        get
        {
            return new UserProfile(mUsername, mColor);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userLogin"></param>
    /// <returns></returns>
    public RemoteResponse Login(string userName, string userPassword)
    {
        var userLogin = new UserLogin(userName, userPassword, mHost);
        var operationResult = mSession.Login(userLogin);

        if (operationResult == RemoteResponse.Success)
        {
            mActive = true;
            mUsername = userLogin.Username;
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public RemoteResponse Logout()
    {
        var operationResult = mSession.Logout(mUsername);

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