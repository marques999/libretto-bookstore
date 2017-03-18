using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApp
{
    public partial class ChatRoom : Form
    {
        string Roomname;

        bool Private;

        IUserSingleton userServer;
        IMessageSingleton messageServer;
        IChatroomSingleton chatroomServer;

        AlterEventUserRepeater evRepeater;
        AlterEventRepeater evMsgRepeater;
        AlterEventRepeaterCR evCRRepeater;

        ArrayList users;
        ArrayList messages;

        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void LVRemDelegate(string username);
        delegate void ChCommDelegate(User usr);
        delegate void NewMsgDelegate(Message msg);

        delegate void UserJoinDelegate(Chatroom ch);
        delegate void MessageAddDelegate(Message msg);

        User Me;
        Main mainWindow;

        public ChatRoom(string roomname, bool isPrivate, User usr, Main mw)
        {
            InitializeComponent();

            //
            this.Load += new System.EventHandler(this.ChatRoom_Load);
            this.richTextBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox3_EnterPressed);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChatRoom_Close);
            //

            Roomname = roomname;
            Private = isPrivate;
            Me = usr;
            mainWindow = mw;

            userServer = (IUserSingleton)RemoteNew.New(typeof(IUserSingleton));
            messageServer = (IMessageSingleton)RemoteNew.New(typeof(IMessageSingleton));
            chatroomServer = (IChatroomSingleton)RemoteNew.New(typeof(IChatroomSingleton));

            evRepeater = new AlterEventUserRepeater();
            evMsgRepeater = new AlterEventRepeater();
            evCRRepeater = new AlterEventRepeaterCR();

            evCRRepeater.alterEvent += new AlterCRDelegate(chatroomHandler);
            chatroomServer.alterEvent += new AlterCRDelegate(evCRRepeater.Repeater);

            evMsgRepeater.alterEvent += new AlterDelegate(MessageHandler);
            messageServer.alterEvent += new AlterDelegate(evMsgRepeater.Repeater);
            evRepeater.alterEvent += new AlterDelegateUser(DoAlterations);
            userServer.alterEvent += new AlterDelegateUser(evRepeater.Repeater);
        }


        public void chatroomHandler(CROperation op, Chatroom ch)
        {
            MessageAddDelegate msgAdd;
            UserJoinDelegate userAdd;
            switch (op)
            {
                case CROperation.NewMessage:
                    msgAdd = new MessageAddDelegate(WriteMessage);
                    BeginInvoke(msgAdd, new Message[] { (Message)ch.GetMessages()[ch.GetMessages().Count - 1] });
                    break;
                case CROperation.UserJoined:
                    userAdd = new UserJoinDelegate(refreshUsers);
                    BeginInvoke(userAdd, new Chatroom[] { ch });
                    break;
                case CROperation.UserLeft:
                    userAdd = new UserJoinDelegate(refreshUsers);
                    BeginInvoke(userAdd, new Chatroom[] { ch });
                    break;
                default:
                    break;
            }
        }

        public void MessageHandler(Operation op, Message msg)
        {
            MessageAddDelegate msgAdd;
            switch (op)
            {
                case Operation.New:
                    msgAdd = new MessageAddDelegate(WriteMessage);
                    BeginInvoke(msgAdd, new Message[] { msg });
                    break;
                default:
                    break;
            }
        }

        private void refreshUsers(Chatroom ch)
        {
            listView1.Items.Clear();
            users = ch.GetUsers();
            foreach(User usr in users)
            {
                ListViewItem lvitem = new ListViewItem(new string[] { usr.Username });
                listView1.Items.Add(lvitem);
            }
        }

        private void WriteMessage(Message msg)
        {
            richTextBox1.Text += formatMessage(msg);
        }

        private string formatMessage(Message msg)
        {
            return "(" + msg.Datesent + ") " + msg.Sender + " :" + msg.Content + "\n";
        }

        public void DoAlterations(UserOperation op, User usr)
        {
            LVAddDelegate lvAdd;
            LVRemDelegate lvRem;
            //ChCommDelegate chComm;

            switch (op)
            {
                /*case UserOperation.New:
                    lvAdd = new LVAddDelegate(listView1.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { usr.Username });
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
                case UserOperation.Logout:
                    lvRem = new LVRemDelegate(RemoveAnUser);
                    //ListViewItem lvItemR = new ListViewItem(new string[] { usr.Username });
                    BeginInvoke(lvRem, new string[] { usr.Username });
                    break;*/
            }


        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            messages = chatroomServer.GetMessages(Roomname);
            users = chatroomServer.GetUsers(Roomname);

            this.richTextBox1.Text = "Numero de mensagens: " + messages.Count + "\n";
            this.richTextBox1.Text += "Numero de utilizadores: " + users.Count;
            if (messages != null) {
                foreach (Message msg in messages)
                {
                    richTextBox1.Text += formatMessage(msg);
                }
            }
            
            if(users != null)
            {
                foreach (User usr in users)
                {
                    ListViewItem lvItem = new ListViewItem(new string[] { usr.Username });
                    listView1.Items.Add(lvItem);
                }
            }
        }

        private void ChatRoom_Close(object sender, EventArgs e)
        {
            chatroomServer.RemoveUser(Roomname, Me);
            mainWindow.UpdateActiveChatrooms(Roomname);
            if(users.Count == 1)
            {
                chatroomServer.DeleteChatroom(Roomname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chatroomServer.AddMessage(Roomname, new Message(2, this.richTextBox3.Text, new DateTime().ToString(), Me.Username , Roomname));
            richTextBox3.Text = "";
        }

        private void richTextBox3_EnterPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
