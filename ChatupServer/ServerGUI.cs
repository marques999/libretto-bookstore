using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatup.NET
{
    public partial class ServerGUI : Form
    {
        private int serverStatus = 0;

        private string[] statusMessages =
        {
            "Stopped",
            "Running",
            "Restarting",
            "Failure"
        };

        public ServerGUI()
        {
            InitializeComponent();
        }

        private Server serverInstance;

        private void UserJoined(string userName)
        {
            MessageBox.Show("UserJoined");
            ListViewItem lvi = new ListViewItem();

            if (listView1.Items.ContainsKey(userName))
            {
                listView1.Items.RemoveByKey(userName);
            }

            lvi.Text = userName;
            lvi.SubItems.Add("Online");
            listView1.Items.Add(lvi);
        }

        private void UserLeft(string userName)
        {
            ListViewItem lvi = new ListViewItem();

            if (listView1.Items.ContainsKey(userName))
            {
                ListViewItem[] existingItem = listView1.Items.Find(userName, false);

                if (existingItem.Length > 0)
                {
                    lvi = existingItem[0];
                    lvi.SubItems.RemoveAt(0);
                    lvi.SubItems.Add("Offline");
                }
            }
            else
            {
                lvi.Text = userName;
                lvi.SubItems.Add("Offline");
                listView1.Items.Add(lvi);
            }
        }

        private SessionService remoteSession;

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serverStatus == 0)
            {
                serverStatus = 1;
                buttonStop.Text = "Stop";
                serverInstance = Server.getInstance();
               // remoteSession = (SessionService)Activator.GetObject(typeof(SessionService), "tcp://127.0.0.1:12480/SessionService");
                //remoteSession.OnJoin += UserJoined;

            }
            else if (serverStatus == 1)
            {
                serverStatus = 0;
                buttonStop.Text = "Start";
            }

            button2.Enabled = !button2.Enabled;
            labelStatus.Text = statusMessages[serverStatus];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serverStatus = 2;
            labelStatus.Text = statusMessages[serverStatus];
        }
    }
}