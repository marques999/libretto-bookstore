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
            mAuthor = messageAuthor;
            mContents = messageContents;
            mTimestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        private string mAuthor;

        /// <summary>
        /// Public getter property for the "mAuthor" private attribute
        /// </summary>
        public string Author
        {
            get
            {
                return mAuthor;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mContents;

        /// <summary>
        /// Public getter property for the "mContents" private member
        /// </summary>
        public string Contents
        {
            get
            {
                return mContents;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private DateTime mTimestamp;

        /// <summary>
        /// Public getter property for the "mTimestamp" private member
        /// </summary>
        public DateTime Timestamp
        {
            get
            {
                return mTimestamp;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return mTimestamp.GetHashCode() * 31 + mAuthor.GetHashCode();
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