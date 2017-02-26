using ChatupNET.Session;

namespace ChatupNET.Remoting
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