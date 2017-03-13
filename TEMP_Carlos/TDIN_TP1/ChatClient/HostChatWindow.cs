using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{    
    class HostChatWindow : ChatWindow
    {
        public delegate void NotifyClients(string m, string c);

        private NotifyClients msgSender;

        public HostChatWindow(string caller, string myUsername, NotifyClients msgSender) : base(myUsername)
        {
            this.msgSender += msgSender;
        }
        

        protected override void button1_Click(object sender, EventArgs e)
        {
            msgSender(chatTextBox.Text, myUsername);
        }
    }
}
