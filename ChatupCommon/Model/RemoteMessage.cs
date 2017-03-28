using System;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RemoteMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageAuthor"></param>
        /// <param name="messageContents"></param>
        public RemoteMessage(string messageAuthor, string messageContents)
        {
            Author = messageAuthor;
            Contents = messageContents;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Author
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Contents" private member
        /// </summary>
        public string Contents
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Timestamp" private member
        /// </summary>
        public DateTime Timestamp
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Timestamp.GetHashCode() * 31 + Author.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="otherInstance"></param>
        /// <returns></returns>
        public override bool Equals(object otherInstance)
        {
            var otherMessage = otherInstance as RemoteMessage;

            if (otherMessage != null)
            {
                return Timestamp == otherMessage.Timestamp && Author == otherMessage.Author;
            }

            return false;
        }
    }
}