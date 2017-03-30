using System;
using System.Collections;
using System.Drawing;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

using ChatupNET.Forms;
using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET
{
    /// <summary>
    /// 
    /// </summary>
    internal class ChatupClient
    {
        /// <summary>
        /// 
        /// </summary>
        private ChatupClient()
        {
            var tcpChannel = new TcpChannel(new Hashtable()
            {
                { "port", 0 }
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider()
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            });

            ChannelServices.RegisterChannel(tcpChannel, false);
            LocalHost = new Address((ushort)new Uri(((ChannelDataStore)tcpChannel.ChannelData).ChannelUris[0]).Port);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(MessageInterface), ChatupCommon.MessagingEndpoint, WellKnownObjectMode.Singleton);
        }

        /// <summary>
        /// 
        /// </summary>
        private static ChatupClient _instance;

        /// <summary>
        /// 
        /// </summary>
        private readonly Random _randomGenerator = new Random();

        /// <summary>
        /// Public getter property for the "_instance" private member
        /// </summary>
        public static ChatupClient Instance => _instance ?? (_instance = new ChatupClient());

        /// <summary>
        /// Public getter property for the "LocalAddress" private member
        /// </summary>
        public string LocalAddress => ChatupCommon.FormatAddress(LocalHost, ChatupCommon.MessagingEndpoint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionIntermediate"></param>
        public void InitializeSession(SessionIntermediate sessionIntermediate)
        {
            Session.OnLogin += sessionIntermediate.Login;
            Session.OnLogout += sessionIntermediate.Logout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionIntermediate"></param>
        public void DestroySession(SessionIntermediate sessionIntermediate)
        {
            Session.OnLogin -= sessionIntermediate.Login;
            Session.OnLogout -= sessionIntermediate.Logout;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lobbyIntermediate"></param>
        public void InitializeLobby(LobbyIntermediate lobbyIntermediate)
        {
            Lobby.OnInsert += lobbyIntermediate.CreateRoom;
            Lobby.OnDelete += lobbyIntermediate.DeleteRoom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lobbyIntermediate"></param>
        public void DestroyLobby(LobbyIntermediate lobbyIntermediate)
        {
            Lobby.OnInsert -= lobbyIntermediate.CreateRoom;
            Lobby.OnDelete -= lobbyIntermediate.DeleteRoom;
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
            Messaging.OnInvite += inviteHandler;
            Messaging.OnConnect += joinHandler;
            Messaging.OnDisconnect += leaveHandler;
            Messaging.OnReceive += messageHandler;
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
            Messaging.OnInvite -= inviteHandler;
            Messaging.OnConnect -= joinHandler;
            Messaging.OnDisconnect -= leaveHandler;
            Messaging.OnReceive -= messageHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Username => Profile.Item1;

        /// <summary>
        /// Public getter property for the "LocalHost" private member
        /// </summary>
        public Address LocalHost
        {
            get;
        }

        /// <summary>
        /// Private getter property for the "RemoteHost" private member
        /// </summary>
        private Address RemoteHost
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Tuple<string, Color> Profile
        {
            get;
            private set;
        } = new Tuple<string, Color>(null, Color.White);

        /// <summary>
        /// Public getter property for the "Lobby" private member
        /// </summary>
        public LobbyInterface Lobby
        {
            get;
            private set;
        }

        /// <summary>
        /// Public getter property for the "Session" private member
        /// </summary>
        public SessionInterface Session
        {
            get;
            private set;
        }

        /// <summary>
        /// Public getter property for the "Messaging" private member
        /// </summary>
        public MessageIntermediate Messaging
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public void InitializeRemoting(Address remoteHost)
        {
            RemoteHost = remoteHost;
            Messaging = new MessageIntermediate();

            RemotingConfiguration.RegisterWellKnownClientType(
                typeof(LobbyInterface),
                ChatupCommon.FormatAddress(RemoteHost, ChatupCommon.LobbyEndpoint)
            );

            RemotingConfiguration.RegisterWellKnownClientType(
                typeof(SessionInterface),
                ChatupCommon.FormatAddress(RemoteHost, ChatupCommon.SessionEndpoint)
            );

            RemotingConfiguration.RegisterActivatedServiceType(typeof(RoomInterface));
            Lobby = (LobbyInterface)RemoteAccess.New(typeof(LobbyInterface));
            Session = (SessionInterface)RemoteAccess.New(typeof(SessionInterface));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        /// <returns></returns>
        public RemoteResponse Login(string userName, string userPassword)
        {
            var userLogin = new UserLogin(userName, userPassword, LocalHost);
            var operationResult = Session.Login(userLogin);

            if (operationResult == RemoteResponse.Success)
            {
                Profile = new Tuple<string, Color>(userLogin.Username, Color.FromArgb(_randomGenerator.Next(32, 224), _randomGenerator.Next(32, 224), _randomGenerator.Next(32, 224)));
            }

            return operationResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public RemoteResponse Logout()
        {
            var operationResult = Session.Logout(Profile.Item1);

            if (operationResult == RemoteResponse.Success)
            {
                Profile = null;
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
}