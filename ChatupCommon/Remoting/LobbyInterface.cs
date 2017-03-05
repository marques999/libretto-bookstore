namespace ChatupNET.Remoting
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    public delegate void RoomDeleteHandler(int roomId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="roomExit"></param>
    public delegate void RoomUpdateHandler(int roomId, string roomExit);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <param name="roomName"></param>
    /// <param name="roomPassword"></param>
    /// <param name="roomCapacity"></param>
    public delegate void RoomCreateHandler(string userName, string roomName, string roomPassword, int roomCapacity);

    /// <summary>
    /// 
    /// </summary>
    public interface LobbyInterface
    {
        /// <summary>
        /// 
        /// </summary>
        event RoomCreateHandler OnCreate;

        /// <summary>
        /// 
        /// </summary>
        event RoomUpdateHandler OnUpdate;

        /// <summary>
        /// 
        /// </summary>
        event RoomDeleteHandler OnDelete;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageInstance"></param>
        bool New(string userName, string roomName, string roomPassword, int roomCapacity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        bool Delete(string userName, int roomId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        bool Join(string userName, int roomId);
    }
}