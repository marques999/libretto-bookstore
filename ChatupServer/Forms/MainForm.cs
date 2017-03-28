using System;
using System.ComponentModel;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class MainForm : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _console = new ConsoleInterface(richTextBox1);
            ChatupServer.Instance.InitializeSession(OnLogin, OnLogout, OnRegister);
            ChatupServer.Instance.InitializeLobby(OnInsert, OnDelete);
            ChatupServer.Instance.InitializeRoom(OnJoin, OnLeave);
        }

        /// <summary>
        /// 
        /// </summary>
        private enum UserAction
        {
            Login, Logout, Register
        }

        /// <summary>
        /// 
        /// </summary>
        private int _activeCount;

        /// <summary>
        /// 
        /// </summary>
        private readonly ConsoleInterface _console;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private delegate void UpsertHandler(UserInformation userInformation, UserAction userAction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogin(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpsertHandler(UpsertUser), userInformation, UserAction.Login);
            }
            else
            {
                UpsertUser(userInformation, UserAction.Login);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnLogout(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpsertHandler(UpsertUser), userInformation, UserAction.Logout);
            }
            else
            {
                UpsertUser(userInformation, UserAction.Logout);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        private void OnRegister(UserInformation userInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpsertHandler(UpsertUser), userInformation, UserAction.Register);
            }
            else
            {
                UpsertUser(userInformation, UserAction.Register);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void OnInsert(Room roomInformation)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new InsertHandler(InsertRoom), roomInformation);
            }
            else
            {
                InsertRoom(roomInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void OnDelete(int roomId)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new DeleteHandler(DeleteRoom), roomId);
            }
            else
            {
                DeleteRoom(roomId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void OnJoin(Room roomInformation, string userName, string fullName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(JoinRoom), roomInformation, userName, fullName);
            }
            else
            {
                JoinRoom(roomInformation, userName, fullName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void OnLeave(Room roomInformation, string userName, string fullName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(LeaveRoom), roomInformation, userName, fullName);
            }
            else
            {
                LeaveRoom(roomInformation, userName, fullName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void JoinRoom(Room roomInformation, string userName, string fullName)
        {
            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.Id));

            if (nodeIndex < 0)
            {
                return;
            }

            _console.Timestamp();
            _console.Print(fullName, ConsoleInterface.Blue);
            _console.Print(" (" + userName + ") ", ConsoleInterface.Yellow);
            _console.Print("has joined chatroom ");
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.Id + ")\n", ConsoleInterface.Yellow);

            var nodeItem = treeView1.Nodes[nodeIndex];

            if (InsertSubnode(nodeItem, userName))
            {
                nodeItem.Text = ChatupCommon.FormatRoom(roomInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void LeaveRoom(Room roomInformation, string userName, string fullName)
        {
            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.Id));

            if (nodeIndex < 0)
            {
                return;
            }

            _console.Timestamp();
            _console.Print(fullName, ConsoleInterface.Blue);
            _console.Print(" (" + userName + ") ", ConsoleInterface.Yellow);
            _console.Print("has left chatroom ");
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.Id + ")\n", ConsoleInterface.Yellow);

            var nodeItem = treeView1.Nodes[nodeIndex];

            if (RemoveSubnode(nodeItem, userName))
            {
                nodeItem.Text = ChatupCommon.FormatRoom(roomInformation);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private static bool InsertSubnode(TreeNode nodeItem, string userName)
        {
            if (nodeItem == null || nodeItem.Nodes.ContainsKey(userName))
            {
                return false;
            }

            nodeItem.Nodes.Add(userName, userName);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private static bool RemoveSubnode(TreeNode nodeItem, string userName)
        {
            if (nodeItem == null || !nodeItem.Nodes.ContainsKey(userName))
            {
                return false;
            }

            nodeItem.Nodes.RemoveByKey(userName);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            var userName = roomInformation.Owner;

            if (ChatupServer.Instance.Users.ContainsKey(userName) == false)
            {
                return;
            }

            var convertedId = Convert.ToString(roomInformation.Id);
            var userInformation = ChatupServer.Instance.Users[userName];

            if (userInformation == null || treeView1.Nodes.ContainsKey(convertedId))
            {
                return;
            }

            _console.Timestamp();
            _console.Print(userInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (" + userName + ") ", ConsoleInterface.Yellow);
            _console.Print("has created chatroom ");
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.Id + ")\n", ConsoleInterface.Yellow);
            treeView1.Nodes.Add(convertedId, ChatupCommon.FormatRoom(roomInformation));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void DeleteRoom(int roomId)
        {
            if (ChatupServer.Instance.Rooms.ContainsKey(roomId) == false)
            {
                return;
            }

            var convertedId = Convert.ToString(roomId);
            var roomInformation = ChatupServer.Instance.Rooms[roomId];

            if (roomInformation == null || treeView1.Nodes.ContainsKey(convertedId) == false)
            {
                return;
            }

            treeView1.Nodes.RemoveByKey(convertedId);
            _console.Timestamp();
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomId + ") ", ConsoleInterface.Yellow);
            _console.Print("was deleted by owner request.\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private void LogUser(UserInformation userInformation, UserAction userAction)
        {
            _console.Timestamp();
            _console.Print(userInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (" + userInformation.Username + ") ", ConsoleInterface.Yellow);

            if (userAction == UserAction.Login)
            {
                _console.Print("has connected.\n");
            }
            else if (userAction == UserAction.Logout)
            {
                _console.Print("has terminated session.\n");
            }
            else
            {
                _console.Print("account registered.\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userAction"></param>
        private void UpsertUser(UserInformation userInformation, UserAction userAction)
        {
            if (listView1.Items.ContainsKey(userInformation.Username))
            {
                listView1.Items.RemoveByKey(userInformation.Username);
            }

            if (userAction == UserAction.Login)
            {
                _activeCount++;
            }
            else if (userAction == UserAction.Logout)
            {
                _activeCount--;
            }

            listView1.Items.Insert(0, new ListViewItem(new[]
            {
                userInformation.Username,
                userAction == UserAction.Login ? userInformation.Host : "Offline"
            })
            {
                Name = userInformation.Username
            });

            LogUser(userInformation, userAction);
            UpdateStats(_activeCount, listView1.Items.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateStats(int activeUsers, int numberUsers)
        {
            groupBox2.Text = $@"Peers ({activeUsers:D} active, {numberUsers - activeUsers:D} inactive)";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            ChatupServer.Instance.DestroyLobby(OnInsert, OnDelete);
            ChatupServer.Instance.DestroySession(OnLogin, OnLogout, OnRegister);
            ChatupServer.Instance.DestroyRoom(OnJoin, OnLeave);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            var userList = ChatupServer.Instance.Users;

            if (userList.Count > 0)
            {
                foreach (var userInformation in userList)
                {
                    UpsertUser(userInformation.Value, UserAction.Register);
                }
            }

            var roomList = ChatupServer.Instance.Rooms;

            if (roomList.Count > 0)
            {
                foreach (var roomInfo in roomList)
                {
                    InsertRoom(roomInfo.Value);
                }
            }

            UpdateStats(_activeCount, listView1.Items.Count);
            _console.Timestamp();
            _console.Print("ChatupServer ", ConsoleInterface.Yellow);
            _console.Print("running at ");
            _console.Print(ChatupServer.Instance.LocalHost.Host + ":" + ChatupServer.Instance.LocalHost.Port, ConsoleInterface.Blue);
            _console.Print("...\n");
        }
    }
}