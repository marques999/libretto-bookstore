using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public enum Response
    {
        [EnumMember]
        DatabaseError = 1,
        [EnumMember]
        Success = 0,
        [EnumMember]
        NotFound = 1,
        [EnumMember]
        BadRequest = 2,
        [EnumMember]
        PermissionDenied = 3,
        [EnumMember]
        InvalidArguments = 4,
        [EnumMember]
        SessionExists = 5,
        [EnumMember]
        EmailFailure = 6
    }
}