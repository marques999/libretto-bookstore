using System;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum RemoteResponse
    {
        AuthenticationFailed,
        NotFound,
        PermissionDenied,
        Success,
        BadRequest,
        SessionExists,
        ObjectExists,
        OperationFailed,
        RoomFull
    }
}