using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public delegate void MessageDelegate(string message, string senderName);
    public class MessageCb : MarshalByRefObject
    {        
       
        public event MessageDelegate messageEvent;

        public override object InitializeLifetimeService()
        {
            return null;
        }

        public void Repeater(string message, string senderName)
        {
            if (messageEvent != null)
                messageEvent(message, senderName);
        }
    }
}
