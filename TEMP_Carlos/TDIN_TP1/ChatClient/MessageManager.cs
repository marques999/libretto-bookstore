using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    class MessageManager : MarshalByRefObject, IMessage
    {
        private ChatWindow chatWin;
        private string myUsername;

        public event MessageDelegate messageEvent;

        delegate void PrivateChatDelegate(string caller);
        
        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void setUsername(string username)
        {
            myUsername = username;
        }

        public bool RequestPrivateChat(string caller)
        {
            string callingDetails = caller + " wants to chat with you!";
            DialogResult result = MessageBox.Show(callingDetails, "Private Chat Request.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                chatWin = new HostChatWindow(caller, myUsername, NotifyClients);
                new Thread(() => {                    
                    chatWin.FormClosed += (s, t) => {
                        Console.WriteLine("FIM DO CHAT!");
                    };
                    Application.Run(chatWin);
                }).Start();
                return true;
            }

            return false;
        }

        private void NotifyClients(string msg, string sender)
        {
            if (messageEvent != null)
            {
                Delegate[] invkList = messageEvent.GetInvocationList();
                Console.WriteLine(invkList.Count());
                foreach (MessageDelegate handler in invkList)
                {
                    new Thread(() => {
                        try
                        {
                            handler(msg, sender);
                            Console.WriteLine("Invoking event handler");
                        }
                        catch (Exception)
                        {
                            messageEvent -= handler;
                            Console.WriteLine("Exception: Removed an event handler");
                        }
                    }).Start();
                }
            }
        }

        public void SendMessage(string message, string caller)
        {
            chatWin.AddMessage(message, caller);
        }
    }
}
