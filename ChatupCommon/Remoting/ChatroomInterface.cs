using System.Drawing;

using ChatupNET.Messaging;

namespace ChatupNET.Remoting
{
    public delegate void MessageHandler(Message messageInstance);
    public delegate void LeaveHandler(string userName);
    public delegate void JoinHandler(string userName, Color userColor);

    public interface ChatroomInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event JoinHandler OnJoin;

        /// <summary>
        /// 
        /// </summary>
        event LeaveHandler OnLeave;

        /// <summary>
        /// 
        /// </summary>
        event MessageHandler OnSend;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        bool Insert(Message messageInstance);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        bool Join(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        bool Join(string userName, string userPassword);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        bool Leave(string userName);
    }
}