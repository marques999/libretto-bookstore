using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

using ChatupNET.Forms;
using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET
{
    internal class ChatupServer
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        private ChatupServer()
        {
            var tcpChannel = new TcpChannel(new Hashtable()
            {
                { "port", ChatupCommon.DefaultPort }
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider()
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            });

            ChannelServices.RegisterChannel(tcpChannel, false);
            RemotingConfiguration.RegisterActivatedServiceType(typeof(RoomInterface));
            LocalHost = new Address((ushort)new Uri(((ChannelDataStore)tcpChannel.ChannelData).ChannelUris[0]).Port);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(LobbyService),
                ChatupCommon.LobbyEndpoint,
                WellKnownObjectMode.Singleton
            );

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(SessionService),
                ChatupCommon.SessionEndpoint,
                WellKnownObjectMode.Singleton
            );

            if (Rooms.Count <= 0)
            {
                return;
            }

            _lastId = Rooms.Aggregate((l, r) => l.Key > r.Key ? l : r).Key;

            foreach (var roomInformation in Rooms)
            {
                LaunchChatroom(roomInformation.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int _lastId;

        /// <summary>
        /// Public getter property for the "_lastid" private member
        /// </summary>
        public int NextId => ++_lastId;

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
        private readonly Dictionary<string, Address> _connections = new Dictionary<string, Address>();

        /// <summary>
        /// Public getter property for the "_instance" private member
        /// </summary>
        public static ChatupServer Instance => _instance ?? (_instance = new ChatupServer());

        /// <summary>
        /// Public getter property for the "_localHost" private member
        /// </summary>
        public Address LocalHost
        {
            get;
            set;
        }

        /// <summary>
        /// Public getter property for the "Lobby" private member
        /// </summary>
        public LobbyIntermediate Lobby
        {
            get;
        } = new LobbyIntermediate();

        /// <summary>
        /// Public getter property for the "Rooms" private member
        /// </summary>
        public Dictionary<int, Room> Rooms
        {
            get;
        } = SqliteDatabase.Instance.QueryRooms();

        /// <summary>
        /// Public getter property for the "Session" private member
        /// </summary>
        public SessionIntermediate Session
        {
            get;
        } = new SessionIntermediate();

        /// <summary>
        /// Public getter property for the "Users" private member
        /// </summary>
        public Dictionary<string, UserInformation> Users
        {
            get;
        } = SqliteDatabase.Instance.QueryUsers();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginHandler"></param>
        /// <param name="logoutHandler"></param>
        /// <param name="registerHandler"></param>
        public void InitializeSession(UserHandler loginHandler, UserHandler logoutHandler, UserHandler registerHandler)
        {
            Session.OnLogin += loginHandler;
            Session.OnLogout += logoutHandler;
            Session.OnRegister += registerHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginHandler"></param>
        /// <param name="logoutHandler"></param>
        /// <param name="registerHandler"></param>
        public void DestroySession(UserHandler loginHandler, UserHandler logoutHandler, UserHandler registerHandler)
        {
            Session.OnLogin -= loginHandler;
            Session.OnLogout -= logoutHandler;
            Session.OnRegister -= registerHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insertHandler"></param>
        /// <param name="deleteHandler"></param>
        public void InitializeLobby(InsertHandler insertHandler, DeleteHandler deleteHandler)
        {
            Lobby.OnInsert += insertHandler;
            Lobby.OnDelete += deleteHandler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="insertHandler"></param>
        /// <param name="deleteHandler"></param>
        public void DestroyLobby(InsertHandler insertHandler, DeleteHandler deleteHandler)
        {
            Lobby.OnInsert -= insertHandler;
            Lobby.OnDelete -= deleteHandler;
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
        public void JoinRoom(Room roomInformation, Tuple<string, Color> userName)
        {
            OnJoin?.Invoke(roomInformation, userName.Item1, Users[userName.Item1].Name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        public void LeaveRoom(Room roomInformation, string userName)
        {
            OnLeave?.Invoke(roomInformation, userName, Users[userName].Name);
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

            Users[userName].Host = ChatupCommon.FormatAddress(userLogin.Host, ChatupCommon.MessagingEndpoint);
            _connections.Add(userName, userLogin.Host);
            Session.Login(Users[userName]);

            return Users[userName];
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
                Users[userName].Host = null;

                if (_connections.ContainsKey(userName))
                {
                    _connections.Remove(userName);
                }

                Session.Logout(Users[userName]);
            }
            else
            {
                return null;
            }

            return Users[userName];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public string LookupChatroom(int roomId)
        {
            return ChatupCommon.FormatAddress(LocalHost, ChatupCommon.FormatChatroom(roomId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        public void LaunchChatroom(Room roomInformation)
        {
            RemotingServices.Marshal(new RoomService(roomInformation), ChatupCommon.FormatChatroom(roomInformation.Id));
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
                Rooms.Add(roomInformation.Id, roomInformation);
                Lobby.CreateRoom(roomInformation);

                if (SqliteDatabase.Instance.InsertRoom(roomInformation))
                {
                    return true;
                }
            }
            catch (RemotingException)
            {
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}