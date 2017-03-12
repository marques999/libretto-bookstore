using System;

namespace ChatupNET.Model
{
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