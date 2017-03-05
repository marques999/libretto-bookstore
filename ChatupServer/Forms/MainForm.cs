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
        private ServerStatus serverStatus = ServerStatus.Running;

        private enum ServerStatus
        {
            Stopped = 0,
            Running = 1,
            Restarting = 2,
            Failure = 3
        }

        private static string[] statusMessages =
        {
            "Stopped",
            "Running",
            "Restarting",
            "Failure"
        };

        private static Color[] statusColor =
        {
            Color.Black,
            Color.ForestGreen,
            Color.DarkOrange,
            Color.Red
        };

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
        }

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

        private void buttonStart_Click(object sender, EventArgs e)
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            ChangeStatus(ServerStatus.Restarting);
        }

        private void ChangeStatus(ServerStatus statusValue)
        {
            HandleChange(statusValue);
            labelStatus.ForeColor = statusColor[(int)serverStatus];
            labelStatus.Text = statusMessages[(int)serverStatus];
        }

        private void LoadUsers()
        {
            foreach (var userInformation in ChatupServer.Instance.Users)
            {
                UpsertUser(userInformation.Value, "Offline");
            }
        }

        private void LoadRooms()
        {
            foreach (var roomInfo in ChatupServer.Instance.Rooms)
            {
                var roomInstance = roomInfo.Value;

                if (roomInstance != null)
                {
                    treeView1.Nodes.Add(
                        Convert.ToString(roomInfo.Key),
                        string.Format("{0} (0/{1})", roomInstance.Name, roomInstance.Capacity)
                    );
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs args)
        {
            LoadRooms();
            LoadUsers();
            UpdateAddress(new Address(IPAddress.Loopback, 12480));
        }

        private Address addressObject;

        private void UpdateAddress(Address objectInstance)
        {
            addressObject = objectInstance;
            labelAddress.Text = addressObject.Host.ToString() + ":" + addressObject.Port;
        }

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