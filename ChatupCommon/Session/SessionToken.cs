using System;

namespace ChatupNET.Session
{
    [Serializable]
    public class SessionToken
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userToken"></param>
        public SessionToken(string userName, string userToken)
        {
            _token = userToken;
            _username = userName;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _token;

        /// <summary>
        /// 
        /// </summary>
        private string _username;

        /// <summary>
        /// Public getter property for the "_token" private member
        /// </summary>
        public string Token
        {
            get
            {
                return _token;
            }
        }

        /// <summary>
        /// Public getter property for the "_username" private member
        /// </summary>
        public string Username
        {
            get
            {
                return _username;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _token.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj != null && obj is SessionToken && (_token.Equals(((SessionToken)obj)._token));
        }
    }
}