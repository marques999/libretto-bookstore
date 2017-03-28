using ChatupNET.Model;

namespace ChatupNET
{
    public class ChatupCommon
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly int QueueLimit = 100;
        public static readonly ushort DefaultPort = 12480;

        /// <summary>
        /// 
        /// </summary>
        public static readonly string LobbyEndpoint = "lobby.rem";
        public static readonly string MessagingEndpoint = "messaging.rem";
        public static readonly string SessionEndpoint = "session.rem";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public static string FormatChatroom(int roomId)
        {
            return $"chatroom_{roomId:D}.rem";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAddress"></param>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public static string FormatAddress(Address userAddress, string endPoint)
        {
            return $"tcp://{userAddress.Host}:{userAddress.Port:D}/{endPoint}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        public static string FormatRoom(Room roomInstance)
        {
            return $"{roomInstance.Name} ({roomInstance.Count:D}/{roomInstance.Capacity:D})";
        }
    }
}