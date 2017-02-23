using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatup.NET
{
    class RoomService
    {
        /// <summary>
        /// 
        /// </summary>
        event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        event LeaveHandler OnLeave;
    }
}
