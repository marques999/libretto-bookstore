using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private enum UserAction
        {
            Login,
            Logout,
            Register
        }

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
        private string mHost;

        /// <summary>
        /// 
        /// </summary>
        private int activeUsers = 0;

        /// <summary>
        /// 
        /// </summary>
        private ConsoleInterface _console;

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
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Login
                });
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
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Logout
                });
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
                BeginInvoke(new UpsertHandler(UpsertUser), new object[]
                {
                    userInformation, UserAction.Register
                });
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
                BeginInvoke(new InsertHandler(InsertRoom), new object[]
                {
                    roomInformation
                });
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
                BeginInvoke(new DeleteHandler(DeleteRoom), new object[]
                {
                    roomId
                });
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
                BeginInvoke(new RoomHandler(JoinRoom), new object[]
                {
                    roomInformation, userName, fullName
                });
            }
            else
            {
                JoinRoom(roomInformation, userName, fullName);
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="roomInformation"></param>
        /// <param name="userName"></param>
        /// <param name="fullName"></param>
        private void OnLeave(Room roomInformation, string userName, string fullName)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new RoomHandler(LeaveRoom), new object[]
                {
                    roomInformation, userName, fullName
                });
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
            _console.Timestamp();
            _console.Print(fullName, ConsoleInterface.Blue);
            _console.Print(" (" + userName + ") ", ConsoleInterface.Yellow);
            _console.Print("has joined chatroom ", ConsoleInterface.Default);
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.ID + ")\n", ConsoleInterface.Yellow);

            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.ID));

            if (nodeIndex >= 0)
            {
                var nodeItem = treeView1.Nodes[nodeIndex];

                if (nodeItem != null)
                {
                    InsertNode(nodeItem, userName);
                    nodeItem.Text = FormatRoom(roomInformation);
                }
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
            _console.Timestamp();
            _console.Print(fullName, ConsoleInterface.Blue);
            _console.Print(" (" + userName + ") ", ConsoleInterface.Yellow);
            _console.Print("has left chatroom ", ConsoleInterface.Default);
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.ID + ")\n", ConsoleInterface.Yellow);

            int nodeIndex = treeView1.Nodes.IndexOfKey(Convert.ToString(roomInformation.ID));

            if (nodeIndex >= 0)
            {
                var nodeItem = treeView1.Nodes[nodeIndex];

                if (nodeItem != null)
                {
                    RemoveNode(nodeItem, userName);
                    nodeItem.Text = FormatRoom(roomInformation);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private void InsertNode(TreeNode nodeItem, string userName)
        {
            if (nodeItem != null && nodeItem.Nodes != null)
            {
                if (!nodeItem.Nodes.ContainsKey(userName))
                {
                    nodeItem.Nodes.Add(userName, userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeItem"></param>
        /// <param name="userName"></param>
        private void RemoveNode(TreeNode nodeItem, string userName)
        {
            if (nodeItem != null && nodeItem.Nodes != null)
            {
                if (nodeItem.Nodes.ContainsKey(userName))
                {
                    nodeItem.Nodes.RemoveByKey(userName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInformation"></param>
        private void InsertRoom(Room roomInformation)
        {
            treeView1.Nodes.Add(
                Convert.ToString(roomInformation.ID),
                FormatRoom(roomInformation)
            );

            _console.Timestamp();
            _console.Print(ChatupServer.Instance.Users[roomInformation.Owner].Name, ConsoleInterface.Blue);
            _console.Print(" (" + roomInformation.Owner + ") ", ConsoleInterface.Yellow);
            _console.Print("has created chatroom ", ConsoleInterface.Default);
            _console.Print(roomInformation.Name, ConsoleInterface.Blue);
            _console.Print(" (id=" + roomInformation.ID + ")\n", ConsoleInterface.Yellow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        private void DeleteRoom(int roomId)
        {
            var _roomId = Convert.ToString(roomId);

            if (treeView1.Nodes.ContainsKey(_roomId))
            {
                treeView1.Nodes.RemoveByKey(_roomId);
            }

            if (ChatupServer.Instance.Rooms.ContainsKey(roomId))
            {
                var roomInformation = ChatupServer.Instance.Rooms[roomId];

                if (roomInformation != null)
                {
                    _console.Timestamp();
                    _console.Print(ChatupServer.Instance.Rooms[roomId].Name, ConsoleInterface.Blue);
                    _console.Print(" (id=" + roomId + ") ", ConsoleInterface.Yellow);
                    _console.Print("was deleted by owner request.\n", ConsoleInterface.Default);
                }
            }
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
                _console.Print("has connected.\n", ConsoleInterface.Default);
            }
            else if (userAction == UserAction.Logout)
            {
                _console.Print("has terminated session.\n", ConsoleInterface.Default);
            }
            else
            {
                _console.Print("account registered.\n", ConsoleInterface.Default);
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
                activeUsers++;
            }
            else if (userAction == UserAction.Logout)
            {
                activeUsers--;
            }

            var lvi = new ListViewItem(new string[]
            {
                userInformation.Username,
                userAction == UserAction.Login ? userInformation.Host : "Offline"
            });

            lvi.Name = userInformation.Username;
            listView1.Items.Insert(0, lvi);
            LogUser(userInformation, userAction);
            UpdateStats();
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateStats()
        {
            groupBox2.Text = string.Format("Peers ({0} active, {1} inactive)", activeUsers, listView1.Items.Count - activeUsers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonExit_Click(object sender, EventArgs args)
        {
            Application.Exit();
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
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        private string FormatRoom(Room roomInstance)
        {
            return string.Format("{0} ({1:D}/{2:D})", roomInstance.Name, roomInstance.Count, roomInstance.Capacity);
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

            UpdateStats();
            UpdateAddress(new Address(IPAddress.Loopback, 12480));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        private void UpdateAddress(Address objectInstance)
        {
            mHost = objectInstance.Host.ToString() + ":" + objectInstance.Port;
            _console.Timestamp();
            _console.Print("ChatupServer ", ConsoleInterface.Yellow);
            _console.Print("running at ", ConsoleInterface.Default);
            _console.Print(mHost, ConsoleInterface.Blue);
            _console.Print("...\n", ConsoleInterface.Default);
        }
    }
}