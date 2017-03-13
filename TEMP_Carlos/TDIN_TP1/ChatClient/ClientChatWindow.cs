using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatClient
{
    class ClientChatWindow : ChatWindow
    {
        private IMessage chatHost;

        private MessageCb userEvents;

        public ClientChatWindow(string host, string myUsername, string hostAddr) : base(myUsername)
        {
            chatHost = (IMessage)RemotingServices.Connect(typeof(IMessage), hostAddr);
            printChatEvent("Inviting " + host + " to join the room....");
            new Thread(() => {
                if (chatHost.RequestPrivateChat(myUsername))
                {
                    userEvents = new MessageCb();
                    userEvents.messageEvent += new MessageDelegate(AddMessage);
                    chatHost.messageEvent += new MessageDelegate(userEvents.Repeater);
                    
                    BeginInvoke(new LogEvent(printChatEvent), new object[] { host + " as join the room." });                    
                }
                else
                {
                    BeginInvoke(new LogEvent(printChatEvent), new object[] { host + " refused your invitation." });
                }
            }).Start();
        }

        protected override void button1_Click(object sender, EventArgs e)
        {
            chatHost.SendMessage(chatTextBox.Text, myUsername);
        }
    }
}
