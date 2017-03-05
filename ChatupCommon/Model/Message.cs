using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class Message
    {
        public Message(int messageId, string user1, string user2, string messageContents)
        {
            _id = messageId;
            _source = user1;
            _destination = user2;
            _contents = messageContents;
            _timestamp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        private int _id;

        /// <summary>
        /// Public getter property for the "_id" private attribute
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private string _source;

        /// <summary>
        /// Public getter property for the "_source" private attribute
        /// </summary>
        public string Source
        {
            get
            {
                return _source;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _destination;

        /// <summary>
        /// Public getter property for the "_destination" private attribute
        /// </summary>
        public string Destination
        {
            get
            {
                return _destination;
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
            return _timestamp.GetHashCode() * 31 + ID.GetHashCode();
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
                var messageObject = otherInstance as Message;

                if (messageObject != null)
                {
                    return ID == messageObject.ID;
                }
            }

            return false;
        }
    }
}