using System.Collections.Generic;

using ChatupNET.Model;

namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public delegate void DeleteHandler(int roomId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomInformation"></param>
    public delegate void RoomHandler(Room roomInformation);

    /// <summary>
    /// 
    /// </summary>
    public interface LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event RoomHandler OnInsert;

        /// <summary>
        /// 
        /// </summary>
        event RoomHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        event DeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        Dictionary<int, Room> List();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        string LookupUser(string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        string LookupRoom(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        RemoteResponse IsPrivate(int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        RemoteResponse Delete(int roomId, string userName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomInstance"></param>
        /// <returns></returns>
        CustomResponse Insert(Room roomInformation);
    }
}