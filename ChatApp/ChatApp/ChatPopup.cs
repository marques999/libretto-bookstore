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
    public partial class ChatPopup : Form
    {

        IUserSingleton userServer;
        IMessageSingleton messageServer;
        AlterEventUserRepeater evRepeater;
        AlterEventRepeater evMsgRepeater;
        ArrayList users;
        ArrayList messages;
        delegate ListViewItem LVAddDelegate(ListViewItem lvItem);
        delegate void ChCommDelegate(User usr);

        delegate void MessageAddDelegate(Message msg);

        User me;
        string receiver;

        public ChatPopup(User usr, string Receiver)
        {
            InitializeComponent();

            userServer = (IUserSingleton)RemoteNew.New(typeof(IUserSingleton));
            messageServer = (IMessageSingleton)RemoteNew.New(typeof(IMessageSingleton));
            users = userServer.GetUsers();

            me          = usr;
            receiver    = Receiver;

            this.Text += " " + me.Username + " " + receiver + " private chat";

            evRepeater = new AlterEventUserRepeater();
            evMsgRepeater = new AlterEventRepeater();

            evMsgRepeater.alterEvent += new AlterDelegate(MessageHandler);
            messageServer.alterEvent += new AlterDelegate(evMsgRepeater.Repeater);

        }
        /*
         * 
         * case UserOperation.New:
                    lvAdd = new LVAddDelegate(listView1.Items.Add);
                    ListViewItem lvItem = new ListViewItem(new string[] { usr.Username });
                    BeginInvoke(lvAdd, new object[] { lvItem });
                    break;
        */
        public void MessageHandler(Operation op, Message msg)
        {
            MessageAddDelegate msgAdd;
            switch (op)
            {
                case Operation.New:
                    /*if (true)//msg.Receiver == me.Username && msg.Sender == receiver)
                    {
                        richTextBox1.Text += receiver + ": " + msg.Content;
                        richTextBox1.Text += "\n";
                    }*/
                    msgAdd = new MessageAddDelegate(WriteMessage);
                    BeginInvoke(msgAdd, new Message[] { msg });
                    break;
                default:
                    break;
            }
        }
        
        private void WriteMessage(Message msg)
        {
            if (msg.Sender == receiver && msg.Receiver == me.Username || msg.Sender == me.Username)
            {
                richTextBox1.Text += formatMessage(msg);
            }
                
        }

        private void ChatPopup_Load(object sender, EventArgs e)
        {
            messages = messageServer.GetMessagesFromToMe(receiver, me.Username);
            //messages = messageServer.GetMessages();
            foreach(Message msg in messages)
            {
                richTextBox1.Text += formatMessage(msg);
            }
        }

        private string formatMessage(Message msg)
        {
            return "(" + msg.Datesent + ") " + msg.Sender + ":" + msg.Content + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //send message
            messageServer.AddMessage(new Message(2, richTextBox2.Text, DateTime.Today.ToString(), me.Username, receiver));
            richTextBox2.Text = "";
        }

        private void richTextBox2_EnterPressed(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }            
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
    }
}
