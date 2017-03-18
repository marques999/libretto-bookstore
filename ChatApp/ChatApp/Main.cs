using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class Main : Form
    {

        IUserSingleton userServer;
        IMessageSingleton messageServer;
        IChatroomSingleton chatroomServer;
        AlterEventUserRepeater evRepeater;
        AlterEventRepeater evMsgRepeater;
        AlterEventRepeaterCR evCRRepeater;

        ArrayList chatrooms;
        ArrayList users;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void LVRemDelegate(string username);

        delegate void LVRemDelegateChatroom(Chatroom ch);
        delegate void ChCommDelegate(User usr);
        delegate void NewMsgDelegate(Message msg);

        delegate ListViewItem NewCHDelegate(ListViewItem ch);

        User me;
        ArrayList popupChats;
        ArrayList popupChatRooms;

        public Main(User usr)
        {
            InitializeComponent();

            // Non generated initialization
            this.listView1.SelectedIndexChanged += (sender, e) => this.listView1_SelectedIndexChanged(sender, e, this.listView1.FocusedItem);
            this.listView2.SelectedIndexChanged += (sender, e) => this.listView2_SelectedIndexChanged(sender, e, this.listView2.FocusedItem);

            //

            me = usr;

            userServer = (IUserSingleton)RemoteNew.New(typeof(IUserSingleton));
            messageServer = (IMessageSingleton)RemoteNew.New(typeof(IMessageSingleton));
            chatroomServer = (IChatroomSingleton)RemoteNew.New(typeof(IChatroomSingleton));
            users = userServer.GetLoggedUsers();
            chatrooms = chatroomServer.GetChatrooms();
            popupChats = new ArrayList();
            popupChatRooms = new ArrayList();

            evRepeater = new AlterEventUserRepeater();
            evMsgRepeater = new AlterEventRepeater();
            evCRRepeater = new AlterEventRepeaterCR();

            evCRRepeater.alterEvent += new AlterCRDelegate(ChatroomHandler);
            chatroomServer.alterEvent += new AlterCRDelegate(evCRRepeater.Repeater);
            evMsgRepeater.alterEvent += new AlterDelegate(MessageHandler);
            messageServer.alterEvent += new AlterDelegate(evMsgRepeater.Repeater);
            evRepeater.alterEvent += new AlterDelegateUser(DoAlterations);
            userServer.alterEvent += new AlterDelegateUser(evRepeater.Repeater);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void MessageHandler(Operation op, Message msg)
        {
            NewMsgDelegate newMsg;
            switch (op)
            {
                case Operation.New:
                    newMsg = new NewMsgDelegate(NewMessageReceived);
                    BeginInvoke(newMsg, new Message[] { msg });                    
                    break;
                default:
                    break;
            }
        }

        public User GetMe()
        {
            return me;
        }

        public void ChatroomHandler(CROperation op, Chatroom ch)
        {
            NewCHDelegate newCh;
            LVRemDelegateChatroom remCh;
            switch (op)
            {
                case CROperation.New:
                    newCh = new NewCHDelegate(listView2.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { ch.Name });
                    BeginInvoke(newCh, new object[] { lvItem });
                    break;
                case CROperation.Delete:
                    remCh = new LVRemDelegateChatroom(RemoveChatRoom);
                    BeginInvoke(remCh, new Chatroom[] { ch });
                    break;
                default:
                    break;
            }
        }
        public void DoAlterations(UserOperation op, User usr)
        {
            LVAddDelegate lvAdd;
            LVRemDelegate lvRem;
            //ChCommDelegate chComm;

            switch (op)
            {
                case UserOperation.New:
                    lvAdd = new LVAddDelegate(listView1.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { usr.Username });
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                case UserOperation.Logout:
                    lvRem = new LVRemDelegate(RemoveAnUser);
                    //ListViewItem lvItemR = new ListViewItem(new string[] { usr.Username });
                    BeginInvoke(lvRem, new string[] { usr.Username });
                    break;
            }

            
        }
        private void RemoveChatRoom(Chatroom ch)
        {
            int index = 0;
            
            foreach(ListViewItem i in listView2.Items)
            {
                this.richTextBox1.Text += ch.Name + " " + i.SubItems[0].Text + " " + index + "\n";
                if (i.SubItems[0].Text.Equals(ch.Name))
                {
                    listView1.Items[index].Remove();
                }
                index++;
            }
        }
        private void RemoveAnUser(string username)
        {
            int index = 0;
            foreach(ListViewItem i in listView1.Items)
            {
                richTextBox1.Text += i.SubItems[0].Text + " -- " + username + "\n";
                if (i.SubItems[0].Text.Equals(username))
                {
                    listView1.Items[index].Remove();
                }
                index++;
            }
        }

        private void NewMessageReceived(Message msg)
        {
            if (msg.Receiver == me.Username)
            {
                foreach (string sender in popupChats)
                {
                    if (msg.Sender == sender)
                        return;
                }
                popupChats.Add(msg.Sender);
                var popup = new ChatPopup(me, msg.Sender);
                popup.Show();
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            foreach (User usr in users)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { usr.Username });
                listView1.Items.Add(lvItem);
            }
            foreach(Chatroom ch in chatrooms)
            {
                ListViewItem lvItem = new ListViewItem(new string[] { ch.Name });
                listView2.Items.Add(lvItem);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveAnUser("CHAN");
        }

        private void MainWindow_Close(object sender, FormClosedEventArgs e)
        {
            userServer.LogoutUser(me);
            Application.Exit();
        }

        private void printToBox()
        {
            foreach(string name in popupChats)
            {
                richTextBox1.Text += name + "\n";
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e, ListViewItem something)
        {
            if(something == null)
            {
                this.richTextBox1.Text = "ITEM IS NULL...";
            }
            else
            {
                this.richTextBox1.Text = something.Text;
                popupChats.Add(something.Text);
                var popup = new ChatPopup(me, something.Text);
                popup.Show();

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var modalBox = new ModalBox(this);
            modalBox.Show();
        }

        public void createChatRoom(string chname, bool isPrivate)
        {
            chatroomServer.AddChatroom(new Chatroom(chname, isPrivate));
            chatroomServer.AddUser(chname, me);
            var popup = new ChatRoom(chname, false, me, this);
            popupChatRooms.Add(chname);
            popup.Show();
        }

        public void UpdateActiveChatrooms(string chName)
        {
            int index = 0;
            foreach(string chatroomname in popupChatRooms)
            {
                if(chatroomname.Equals(chName))
                {
                    popupChatRooms.RemoveAt(index);
                    return;
                }
                index++;
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e, ListViewItem chName)
        {
            if(chName == null)
            {
                this.richTextBox1.Text = "ITEM IS NULL...";
            }
            else
            {
                this.richTextBox1.Text = chName.Text;
                foreach(string chatroomname in popupChatRooms)
                {
                    if(chatroomname == chName.Text)
                    {
                        return;
                    }
                }
                popupChatRooms.Add(chName.Text);
                chatroomServer.AddUser(chName.Text, me);
                var popup = new ChatRoom(chName.Text, false, me, this);
                popup.Show(); ;
            }
        }
    }
}
