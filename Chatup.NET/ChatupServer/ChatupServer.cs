using System;
using System.Collections;
using System.Collections.Generic;
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
    /// <summary>
    ///
    /// </summary>
    internal class ChatupServer
    {
        /// <summary>
        ///
        /// </summary>
        private ChatupServer()
        {
            var tcpChannel = new TcpChannel(new Hashtable()
            {
                {"port", ChatupCommon.DefaultPort}
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
        ///
        /// </summary>
        public int NextId => ++_lastId;

        /// <summary>
        ///
        /// </summary>
        public int Active => _connections.Count;

        /// <summary>
        ///
        /// </summary>
        private UpdateHandler _updateHandler;

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
        public static ChatupServer Instance => _instance ?? (_instance = new ChatupServer());

        /// <summary>
        ///
        /// </summary>
        private readonly Dictionary<string, Address> _connections = new Dictionary<string, Address>();

        /// <summary>
        ///
        /// </summary>
        public Address LocalHost
        {
            get;
            set;
        }

        /// <summary>
        ///
        /// </summary>
        public LobbyIntermediate Lobby
        {
            get;
        } = new LobbyIntermediate();

        /// <summary>
        ///
        /// </summary>
        public Dictionary<int, Room> Rooms
        {
            get;
        } = SqliteDatabase.Instance.QueryRooms();

        /// <summary>
        ///
        /// </summary>
        public SessionIntermediate Session
        {
            get;
        } = new SessionIntermediate();

        /// <summary>
        ///
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
        public void InitializeChatrooms(RoomHandler joinHandler, RoomHandler leaveHandler)
        {
            OnJoin += joinHandler;
            OnLeave += leaveHandler;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="joinHandler"></param>
        /// <param name="leaveHandler"></param>
        public void DestroyChatrooms(RoomHandler joinHandler, RoomHandler leaveHandler)
        {
            OnJoin -= joinHandler;
            OnLeave -= leaveHandler;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userProfile"></param>
        public void JoinRoom(Room roomInformation, UserProfile userProfile)
        {
            NotifyUpdates(roomInformation);
            OnJoin?.Invoke(roomInformation, userProfile, Users[userProfile.Username].Name);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        public void LeaveRoom(Room roomInformation, UserProfile userName)
        {
            NotifyUpdates(roomInformation);
            OnLeave?.Invoke(roomInformation, userName, Users[userName.Username].Name);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public UserInformation Login(UserLogin userLogin)
        {
            var userName = userLogin.Username;

            if (Users.ContainsKey(userName) && Users[userName].Online)
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
            if (Users.ContainsKey(userName) && Users[userName].Online)
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
        /// <param name="updateHandler"></param>
        public void InitializeUpdates(UpdateHandler updateHandler)
        {
            _updateHandler = updateHandler;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        public void NotifyUpdates(Room roomInformation)
        {
            _updateHandler?.Invoke(roomInformation.Id, roomInformation.Count, roomInformation.Capacity);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        private static bool LaunchChatroom(Room roomInformation)
        {
            try
            {
                RemotingServices.Marshal(new RoomService(roomInformation), ChatupCommon.FormatChatroom(roomInformation.Id));
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
        /// <param name="roomInformation"></param>
        /// <returns></returns>
        public bool RegisterChatrooom(Room roomInformation)
        {
            if (LaunchChatroom(roomInformation))
            {
                Rooms.Add(roomInformation.Id, roomInformation);
                Lobby.CreateRoom(roomInformation);
            }
            else
            {
                return false;
            }

            return SqliteDatabase.Instance.InsertRoom(roomInformation);
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