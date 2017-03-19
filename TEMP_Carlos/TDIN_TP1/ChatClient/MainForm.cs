using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Common;
using System.Runtime.Remoting;
using System.Threading;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        private IChat chatServer;
        private Guid id;
        private Form parent;

        private string myUsername;

        private UserEventCb userEvents;

        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void LVDelDelegate(Account acc);

        private bool userClosing;
        
        public MainForm(IChat chatServer, Guid id, string username, Form parent)
        {
            this.chatServer = chatServer;
            this.id = id;
            this.parent = parent;
            this.myUsername = username;

            userClosing = true;

            userEvents = new UserEventCb();
            userEvents.alterEvent += new AlterDelegate(updateActiveUsers);
            chatServer.alterEvent += new AlterDelegate(userEvents.Repeater);

            InitializeComponent();

            List<Account> users = chatServer.getActiveUsers();

            foreach(Account acc in users)
            {
                ListViewItem listViewItem = new ListViewItem(new string[] { acc.getUsername(), acc.getAdress() });
                usersListView.Items.Add(listViewItem);
            }
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            chatServer.logout(id);
            if(userClosing)
            {
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            userClosing = false;
            this.Close();
            parent.Show();
        }

        public void deleteItem(Account acc)
        {
            for(int i = 0; i < usersListView.Items.Count; i++)
            {
                if (usersListView.Items[i].Text.Equals(acc.getUsername()))
                {
                    usersListView.Items[i].Remove();
                    break;
                }
            }                
        }

        public void updateActiveUsers(Account acc, Operation opr)
        {
            LVAddDelegate lvAdd;
            LVDelDelegate chComm;
            switch (opr)
            {
                case Operation.New:
                {
                    lvAdd = new LVAddDelegate(usersListView.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { acc.getUsername(), acc.getAdress() });
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                }                    
                case Operation.Delete:
                {
                    chComm = new LVDelDelegate(deleteItem);
                    BeginInvoke(chComm, new object[] { acc });
                    break;
                }
                    
            }
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count > 0)
            {
                var item = usersListView.SelectedItems[0];
                             
                new Thread(() =>
                {         
                    ClientChatWindow chatwin = new ClientChatWindow(item.SubItems[0].Text, myUsername, item.SubItems[1].Text);
                    Application.Run(chatwin);
                }).Start();

                
            }
        }
    }
}
