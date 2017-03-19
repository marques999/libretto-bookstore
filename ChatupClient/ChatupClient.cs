using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

using ChatupNET;
using ChatupNET.Forms;
using ChatupNET.Remoting;
using ChatupNET.Model;

class ChatupClient
{
    /// <summary>
    /// Default constructor for the "ChatupCient" class
    /// </summary>
    private ChatupClient()
    {
        var serverProvider = new BinaryServerFormatterSinkProvider();

        RemotingConfiguration.Configure("ChatupClient.exe.config", false);
        serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

        var tcpChannel = new TcpChannel(new Hashtable()
        {
            { "port", 0 }
        }, new BinaryClientFormatterSinkProvider(), serverProvider);

        ChannelServices.RegisterChannel(tcpChannel, false);
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
    private Address mHost;

    /// <summary>
    /// 
    /// </summary>
    private string mUsername;

    /// <summary>
    /// 
    /// </summary>
    private static ChatupClient mInstance;

    /// <summary>
    /// 
    /// </summary>
    public event MessageHandler OnReceive;

    /// <summary>
    /// 
    /// </summary>
    public event ConnectHandler OnConnect;

    /// <summary>
    /// 
    /// </summary>
    public event DisconnectHandler OnDisconnect;

    /// <summary>
    /// 
    /// </summary>
    private Color mColor = ColorGenerator.Random();

    /// <summary>
    /// 
    /// </summary>
    private LobbyInterface mLobby;

    /// <summary>
    /// 
    /// </summary>
    private SessionInterface mSession;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, RoomInterface> mRooms = new Dictionary<int, RoomInterface>();

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
    public string LocalAddress
    {
        get
        {
            return string.Format("tcp://{0}:{1:D}/messaging.rem", mHost.Host, mHost.Port);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void InitializeSession(SessionIntermediate sessionIntermediate)
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
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="messageHandler"></param>
    public void InitializeMessaging(ConnectHandler joinHandler, DisconnectHandler leaveHandler, MessageHandler messageHandler)
    {
        OnConnect += joinHandler;
        OnDisconnect += leaveHandler;
        OnReceive += messageHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="messageHandler"></param>
    public void DestroyMessaging(ConnectHandler joinHandler, DisconnectHandler leaveHandler, MessageHandler messageHandler)
    {
        OnConnect -= joinHandler;
        OnDisconnect -= leaveHandler;
        OnReceive -= messageHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userProfile"></param>
    /// <param name="remoteHost"></param>
    public void Connect(UserProfile userProfile, string remoteHost)
    {
        OnConnect?.Invoke(userProfile, remoteHost);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="userAction"></param>
    public void Disconnect(string userName, bool userAction)
    {
        OnDisconnect?.Invoke(userName, userAction);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="remoteMessage"></param>
    public void Push(RemoteMessage remoteMessage)
    {
        OnReceive?.Invoke(remoteMessage);
    }

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
    /// <param name="userPassword"></param>
    /// <returns></returns>
    public RemoteResponse Login(string userName, string userPassword)
    {
        var userLogin = new UserLogin(userName, userPassword, mHost);
        var operationResult = mSession.Login(userLogin);

        if (operationResult == RemoteResponse.Success)
        {
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