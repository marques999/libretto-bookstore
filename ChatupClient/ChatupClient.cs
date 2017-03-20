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
        _p2pInterface = new MessageIntermediate();
        _lobbyInterface = (LobbyInterface)RemoteAccess.New(typeof(LobbyInterface));
        _sessionInterface = (SessionInterface)RemoteAccess.New(typeof(SessionInterface));
        RemotingConfiguration.RegisterActivatedServiceType(typeof(RoomInterface));
        _userAddress = new Address((ushort)new Uri(((ChannelDataStore)tcpChannel.ChannelData).ChannelUris[0]).Port);

        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(MessageService),
            "messaging.rem",
            WellKnownObjectMode.Singleton
        );
    }

    /// <summary>
    /// 
    /// </summary>
    private Color _userColor;

    /// <summary>
    /// 
    /// </summary>
    private Address _userAddress;

    /// <summary>
    /// 
    /// </summary>
    private string _userName;

    /// <summary>
    /// 
    /// </summary>
    private static ChatupClient _instance;

    /// <summary>
    /// 
    /// </summary>
    private LobbyInterface _lobbyInterface;

    /// <summary>
    /// 
    /// </summary>
    private SessionInterface _sessionInterface;

    /// <summary>
    /// a
    /// </summary>
    private MessageIntermediate _p2pInterface;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<int, RoomInterface> _rooms = new Dictionary<int, RoomInterface>();

    /// <summary>
    /// 
    /// </summary>
    public Color Color
    {
        get
        {
            return _userColor;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Address Host
    {
        get
        {
            return _userAddress;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string LocalAddress
    {
        get
        {
            return string.Format("tcp://{0}:{1:D}/messaging.rem", _userAddress.Host, _userAddress.Port);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void InitializeSession(SessionIntermediate sessionIntermediate)
    {
        _sessionInterface.OnLogin += sessionIntermediate.Login;
        _sessionInterface.OnLogout += sessionIntermediate.Logout;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sessionIntermediate"></param>
    public void DestroySession(SessionIntermediate sessionIntermediate)
    {
        _sessionInterface.OnLogin -= sessionIntermediate.Login;
        _sessionInterface.OnLogout -= sessionIntermediate.Logout;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lobbyIntermediate"></param>
    public void InitializeLobby(LobbyIntermediate lobbyIntermediate)
    {
        _lobbyInterface.OnInsert += lobbyIntermediate.CreateRoom;
        _lobbyInterface.OnDelete += lobbyIntermediate.DeleteRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lobbyIntermediate"></param>
    public void DestroyLobby(LobbyIntermediate lobbyIntermediate)
    {
        _lobbyInterface.OnInsert -= lobbyIntermediate.CreateRoom;
        _lobbyInterface.OnDelete -= lobbyIntermediate.DeleteRoom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="inviteHandler"></param>
    /// <param name="messageHandler"></param>
    public void InitializeMessaging(ConnectHandler joinHandler, DisconnectHandler leaveHandler, InviteHandler inviteHandler, MessageHandler messageHandler)
    {
        _p2pInterface.OnInvite += inviteHandler;
        _p2pInterface.OnConnect += joinHandler;
        _p2pInterface.OnDisconnect += leaveHandler;
        _p2pInterface.OnReceive += messageHandler;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="joinHandler"></param>
    /// <param name="leaveHandler"></param>
    /// <param name="inviteHandler"></param>
    /// <param name="messageHandler"></param>
    public void DestroyMessaging(ConnectHandler joinHandler, DisconnectHandler leaveHandler, InviteHandler inviteHandler, MessageHandler messageHandler)
    {
        _p2pInterface.OnInvite -= inviteHandler;
        _p2pInterface.OnConnect -= joinHandler;
        _p2pInterface.OnDisconnect -= leaveHandler;
        _p2pInterface.OnReceive -= messageHandler;
    }

    /// <summary>
    /// Public getter property for the "mSession" private member
    /// </summary>
    public SessionInterface Session
    {
        get
        {
            return _sessionInterface;
        }
    }

    /// <summary>
    /// Public getter property for the "mLobby" private member
    /// </summary>
    public LobbyInterface Lobby
    {
        get
        {
            return _lobbyInterface;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public MessageIntermediate Messaging
    {
        get
        {
            return _p2pInterface;
        }
    }

    /// <summary>
    /// Public getter property for the "mInstance" private member
    /// </summary>
    public static ChatupClient Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ChatupClient();
            }

            return _instance;
        }
    }

    /// <summary>
    /// Public getter property for the "username" private member
    /// </summary>
    public string Username
    {
        get
        {
            return _userName;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Tuple<string, Color> Profile
    {
        get
        {
            return new Tuple<string, Color>(_userName, _userColor);
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
        var userLogin = new UserLogin(userName, userPassword, _userAddress);
        var operationResult = _sessionInterface.Login(userLogin);

        if (operationResult == RemoteResponse.Success)
        {
            _userName = userLogin.Username;
            _userColor = ColorGenerator.Random();
        }

        return operationResult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public RemoteResponse Logout()
    {
        var operationResult = _sessionInterface.Logout(_userName);

        if (operationResult == RemoteResponse.Success)
        {
            _userName = null;
            _userColor = Color.Black;
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