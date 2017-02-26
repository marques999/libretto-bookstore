using System;

namespace ChatupNET.Messaging
{
    [Serializable]
    public class Message
    {
        /// <summary>
        /// Default constructor the "Message" class
        /// </summary>
        /// <param name="messageAuthor"></param>
        /// <param name="messageContents"></param>
        /// <param name="messageTimestamp"></param>
        public Message(string messageAuthor, string messageContents, DateTime messageTimestamp)
        {
            _author = messageAuthor;
            _contents = messageContents;
            _timestamp = messageTimestamp;
        }

        /// <summary>
        /// 
        /// </summary>
        private string _author;

        /// <summary>
        /// 
        /// </summary>
        private string _contents;

        /// <summary>
        /// 
        /// </summary>
        private DateTime _timestamp;

        /// <summary>
        /// Public gettter property for the "_author" private member
        /// </summary>
        public string Author
        {
            get
            {
                return _author;
            }
        }

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
            return _author.GetHashCode() ^ _timestamp.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                var messageObject = obj as Message;

                if (messageObject != null)
                {
                    return messageObject._author.Equals(_author) && messageObject._timestamp.Equals(_timestamp);
                }
            }

            return false;
        }
    }
}