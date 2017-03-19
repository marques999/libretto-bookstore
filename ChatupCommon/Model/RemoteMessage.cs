using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class RemoteMessage
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="messageAuthor"></param>
        /// <param name="messageContents"></param>
        public RemoteMessage(string messageAuthor, string messageContents)
        {
            _author = messageAuthor;
            _contents = messageContents;
            _timestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _author;

        /// <summary>
        /// Public getter property for the "_author" private attribute
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _contents;

        /// <summary>
        /// Public getter property for the "_contents" private member
        /// </summary>
        public string Contents
        {
            get
            {
                return _contents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime _timestamp;

        /// <summary>
        /// Public getter property for the "_timestamp" private member
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _timestamp.GetHashCode() * 31 + _author.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            if (otherInstance != null)
            {
                var otherMessage = otherInstance as RemoteMessage;

                if (otherMessage != null)
                {
                    return Timestamp == otherMessage.Timestamp && Author == otherMessage.Author;
                }
            }

            return false;
        }
    }
}