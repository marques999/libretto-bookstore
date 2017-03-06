using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using ChatupNET.Model;
using ChatupNET.Remoting;

namespace ChatupNET.Forms
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private ServerStatus serverStatus = ServerStatus.Running;

        /// <summary>
        /// 
        /// </summary>
        private enum ServerStatus
        {
            Stopped = 0,
            Running = 1,
            Restarting = 2,
            Failure = 3
        }

        /// <summary>
        /// 
        /// </summary>
        private static string[] statusMessages =
        {
            "Stopped",
            "Running",
            "Restarting",
            "Failure"
        };

        /// <summary>
        /// 
        /// </summary>
        private static Color[] statusColor =
        {
            Color.Black,
            Color.ForestGreen,
            Color.DarkOrange,
            Color.Red
        };

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            ChatupServer.Instance.SessionActivator
            (
                delegate (UserInformation userInformation)
                {
                    UpsertUser(userInformation, "Active");
                },
                delegate (UserInformation userInformation)
                {
                    UpsertUser(userInformation, "Offline");
                },
                delegate (UserInformation userInformation)
                {
                    UpsertUser(userInformation, "Offline");
                }
            );

            ChatupServer.Instance.LobbyActivator
            (
                delegate (int roomId, Room roomInformation)
                {
                    BeginInvoke(new RoomInsertHandler(InsertRoom), new object[]
                    {
                        roomId, roomInformation
                    });
                },
                delegate (int roomId)
                {
                    BeginInvoke(new RoomDeleteHandler(DeleteRoom), new object[]
                    {
                        roomId
                    });
                },
                delegate (int roomId, int roomCount, int roomCapacity)
                {
                    BeginInvoke(new RoomUpdateHandler(UpdateRoom), new object[]
                    {
                        roomId, roomCount, roomCapacity
                    });
                }
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomInformation"></param>
        private void InsertRoom(int roomId, Room roomInformation)
        {
            treeView1.Nodes.Add(
                Convert.ToString(roomId),
                FormatCapacity(roomInformation)
            );
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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="roomExit"></param>
        private void UpdateRoom(int roomId, int roomCount, int roomCapacity)
        {
            var _roomId = Convert.ToString(roomId);

            if (!treeView1.Nodes.ContainsKey(_roomId))
            {
                return;
            }

            var listItems = treeView1.Nodes.Find(_roomId, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="userStatus"></param>
        private void UpsertUser(UserInformation userInformation, string userStatus)
        {
            if (listView1.Items.ContainsKey(userInformation.Username))
            {
                listView1.Items.RemoveByKey(userInformation.Username);
            }

            var lvi = new ListViewItem(new string[]
            {
                userInformation.Username, userStatus
            });

            lvi.Name = userInformation.Username;
            listView1.Items.Insert(0, lvi);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextStatus"></param>
        private void HandleChange(ServerStatus nextStatus)
        {
            if (serverStatus == nextStatus)
            {
                return;
            }

            switch (serverStatus)
            {
                case ServerStatus.Restarting:
                    buttonStart.Enabled = true;
                    buttonRestart.Enabled = true;
                    buttonExit.Enabled = true;
                    break;
            }

            switch (nextStatus)
            {
                case ServerStatus.Stopped:
                    buttonStart.Text = "Start";
                    buttonRestart.Enabled = false;
                    break;
                case ServerStatus.Running:
                    buttonStart.Text = "Stop";
                    buttonRestart.Enabled = true;
                    break;
                case ServerStatus.Restarting:
                    buttonStart.Text = "Restarting...";
                    buttonStart.Enabled = false;
                    buttonRestart.Enabled = false;
                    buttonExit.Enabled = false;
                    break;
            }

            serverStatus = nextStatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonStart_Click(object sender, EventArgs args)
        {
            if (serverStatus == ServerStatus.Stopped)
            {
                ChangeStatus(ServerStatus.Running);
            }
            else if (serverStatus == ServerStatus.Running)
            {
                ChangeStatus(ServerStatus.Stopped);
            }
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
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonRestart_Click(object sender, EventArgs args)
        {
            ChangeStatus(ServerStatus.Restarting);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusValue"></param>
        private void ChangeStatus(ServerStatus statusValue)
        {
            HandleChange(statusValue);
            labelStatus.ForeColor = statusColor[(int)serverStatus];
            labelStatus.Text = statusMessages[(int)serverStatus];
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadUsers()
        {
            foreach (var userInformation in ChatupServer.Instance.Users)
            {
                UpsertUser(userInformation.Value, "Offline");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadRooms()
        {
            foreach (var roomInfo in ChatupServer.Instance.Rooms)
            {
                var roomInstance = roomInfo.Value;

                if (roomInstance != null)
                {

                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        private string FormatCapacity(Room roomInstance)
        {
            return FormatCapacity(roomInstance.Count, roomInstance.Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomCount"></param>
        /// <param name="roomCapacity"></param>
        /// <returns></returns>
        private string FormatCapacity(int roomCount, int roomCapacity)
        {
            return string.Format("{0} / {1}", roomCount, roomCapacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainForm_Load(object sender, EventArgs args)
        {
            LoadRooms();
            LoadUsers();
            UpdateAddress(new Address(IPAddress.Loopback, 12480));
        }

        /// <summary>
        /// 
        /// </summary>
        private Address addressObject;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectInstance"></param>
        private void UpdateAddress(Address objectInstance)
        {
            addressObject = objectInstance;
            labelAddress.Text = addressObject.Host.ToString() + ":" + addressObject.Port;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void buttonAddress_click(object sender, EventArgs args)
        {
            var addressForm = new AddressForm(addressObject);

            if (addressForm.ShowDialog() == DialogResult.OK)
            {
                UpdateAddress(addressForm.ModalData);
            }
        }
    }
}