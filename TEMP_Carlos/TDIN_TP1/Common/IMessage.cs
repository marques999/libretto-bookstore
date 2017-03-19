using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IMessage
    {
        event MessageDelegate messageEvent;

        void SendMessage(string message, string senderName);

        bool RequestPrivateChat(string senderName);
    }
}
