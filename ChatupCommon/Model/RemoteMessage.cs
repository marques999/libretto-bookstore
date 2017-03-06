using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class RemoteMessage
    {
        public RemoteMessage(int messageId, string messageAuthor, string messageContents)
        {
            mId = messageId;
            mAuthor = messageAuthor;
            mContents = messageContents;
            mTimestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        private int mId;

        /// <summary>
        /// Public getter property for the "_id" private attribute
        /// </summary>
        public int ID
        {
            get
            {
                return mId;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string mAuthor;

        /// <summary>
        /// Public getter property for the "_source" private attribute
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
        /// Public getter property for the "_contents" private member
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
        /// Public getter property for the "_timestamp" private member
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
            return mTimestamp.GetHashCode() * 31 + ID.GetHashCode();
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
                var messageObject = otherInstance as RemoteMessage;

                if (messageObject != null)
                {
                    return ID == messageObject.ID;
                }
            }

            return false;
        }
    }
}