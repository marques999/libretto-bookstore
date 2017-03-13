using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public delegate void SendMessageDel(string caller, string message);
    public delegate void LogEvent(string text);
    public abstract partial class ChatWindow : Form
    {
        protected string myUsername;
                
        public ChatWindow(string myUsername) {
            this.myUsername = myUsername;
            InitializeComponent();
        }

        public void AddMessage(string message, string sender)
        {
            BeginInvoke(new LogEvent(printChatEvent), new object[] { sender + ": " + message });
        }

        protected abstract void button1_Click(object sender, EventArgs e);
        
        protected void printChatEvent(string text)
        {
            if(!chatLogTextBox.Text.Equals(""))
            {
                chatLogTextBox.AppendText(Environment.NewLine);
            }
            chatLogTextBox.AppendText("[" + DateTime.Now.ToString("hh:mm:ss") + "] " + text);
        }        
    }
}
