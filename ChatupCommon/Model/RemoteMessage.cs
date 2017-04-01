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
        public RemoteMessage(UserProfile messageAuthor, string messageContents)
        {
            Author = messageAuthor;
            Timestamp = DateTime.Now;
            Contents = messageContents;
        }

        /// <summary>
        ///
        /// </summary>
        public string Contents
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public UserProfile Author
        {
            get;
        }

        /// <summary>
        ///
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