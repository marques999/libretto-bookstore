using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class CustomResponse
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseCode"></param>
        public CustomResponse(RemoteResponse responseCode) : this(responseCode, null)
        {
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="responseCode"></param>
        /// <param name="responseContents"></param>
        public CustomResponse(RemoteResponse responseCode, object responseContents)
        {
            _response = responseCode;
            _contents = responseContents;
        }

        /// <summary>
        /// 
        /// </summary>
        private RemoteResponse _response;

        /// <summary>
        /// Public getter property for the "_response" private member
        /// </summary>
        public RemoteResponse Response
        {
            get
            {
                return _response;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private object _contents;

        /// <summary>
        /// Public getter property for the "_contents" private member
        /// </summary>
        public object Contents
        {
            get
            {
                return _contents;
            }
        }
    }
}