using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupClient
{
    public delegate void ExitChatroomHandler(int instanceCount);

    public partial class RoomForm : Form
    {
        private Chatroom instance;
        public event ExitChatroomHandler ExitHandler;

        public RoomForm(Chatroom roomObject)
        {
            instance = roomObject;
            InitializeComponent();

            foreach (var userInstance in instance.Users)
            {
                UserJoined(userInstance.Key, userInstance.Value);
            }
        }

        private static int instanceCount = 0;

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

        public void AppendText(string text, Color color)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText(text);
            richTextBox1.SelectionColor = richTextBox1.ForeColor;
        }

        private void UserJoined(string userName, Color userColor)
        {
            listBox1.Items.Add(userName);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, userColor);
            AppendText(" has joined the conversation." + "\n", Color.DimGray);
        }

        private void UserLeft(string userName)
        {
            listBox1.Items.Remove(userName);
            AppendText("(" + DateTime.Now.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName, instance.Color(userName));
            AppendText(" has left the conversation." + "\n", Color.DimGray);
        }

        private void AppendMessage(string userName, string messageContents, DateTime messageTimestamp)
        {
            AppendText("(" + messageTimestamp.ToShortTimeString() + ") ", Color.DimGray);
            AppendText(userName + ": ", instance.Color(userName));
            AppendText(messageContents + "\n", Color.Black);
        }

        private void RoomForm_Load(object sender, EventArgs args)
        {
            instanceCount++;
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
            UpdateTitle();
        }

        private void buttonValidate_Click(object sender, EventArgs args)
        {
            AppendMessage("marques999", textBox2.Text, DateTime.Now);
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs args)
        {
            buttonValidate.Enabled = !string.IsNullOrWhiteSpace(textBox2.Text);
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            instanceCount--;
            ExitHandler?.Invoke(instanceCount);
        }
    }
}