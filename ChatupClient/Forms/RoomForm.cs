using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using ChatupNET.Remoting;
using ChatupNET.Model;

namespace ChatupNET.Forms
{
    public delegate void ExitChatroomHandler(Room instance);

    public partial class RoomForm : Form
    {
        private Room instance;
        private Dictionary<string, Color> users;
        private RoomIntermediate chatroomIntermediate;

        public RoomForm(Room roomObject)
        {
            InitializeComponent();
            instance = roomObject;
            users = new Dictionary<string, Color>();
            chatroomIntermediate = new RoomIntermediate();
            chatroomIntermediate.OnJoin += UserJoined;
            chatroomIntermediate.OnLeave += UserLeft;
            chatroomIntermediate.OnMessage += AppendMessage;
        }

        public event ExitChatroomHandler ExitHandler;

        protected override void OnClosing(CancelEventArgs args)
        {
            base.OnClosing(args);
            chatroomIntermediate.OnJoin -= UserJoined;
            chatroomIntermediate.OnLeave -= UserLeft;
            chatroomIntermediate.OnMessage -= AppendMessage;
        }

        private void UpdateTitle()
        {
            if (instance.IsGroup())
            {
                Text = string.Format("{0} [{1}/{2}]", instance.Name, instance.Count, instance.GetCapacity());
            }
            else
            {
                Text = string.Format("{0} [PRIVATE]", instance.Name);
            }
        }

        public void AppendText(string textContents, Color textColor)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = textColor;
            richTextBox1.AppendText(textContents);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        private void UserJoined(string userName, Color userColor)
        {
            listBox1.Items.Add(userName);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, userColor);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
            users.Add(userName, userColor);
        }

        private void UserLeft(string userName)
        {
            listBox1.Items.Remove(userName);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, users[userName]);
            AppendText(" has left the conversation." + "\n", Color.DimGray);
            users.Remove(userName);
        }

        private void AppendMessage(RemoteMessage messageInstance)
        {
            AppendText("(" + messageInstance.Timestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(messageInstance.Author + ": ", users[messageInstance.Author]);
            AppendText(messageInstance.Contents + "\n", Color.Black);
        }

        private void RoomForm_Load(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
            UpdateTitle();
        }

        private void buttonValidate_Click(object sender, EventArgs args)
        {
            AppendMessage(new RemoteMessage("marques999", textBox2.Text));
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs args)
        {
            ExitHandler?.Invoke(instance);
        }
    }
}