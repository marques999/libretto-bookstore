using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public delegate void AlterDelegate(Account user, Operation opr);

    public enum Operation { New, Delete };

    public class UserEventCb : MarshalByRefObject
    {
        public event AlterDelegate alterEvent;

        public override object InitializeLifetimeService()
        { 
            return null;
        }

        public void Repeater(Account user, Operation opr)
        {
            if (alterEvent != null)
                alterEvent(user, opr);
        }
    }
}
