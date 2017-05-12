using System.Runtime.Serialization;

namespace LibrettoWCF.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class LoginForm
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Password
        {
            get;
            set;
        }
    }
}