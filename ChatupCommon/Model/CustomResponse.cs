using System;

namespace ChatupNET.Model
{
    [Serializable]
    public class CustomResponse
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="remoteResponse"></param>
        /// <param name="responseContents"></param>
        public CustomResponse(RemoteResponse remoteResponse, object responseContents)
        {
            mResponse = remoteResponse;
            mContents = responseContents;
        }

        /// <summary>
        /// 
        /// </summary>
        private RemoteResponse mResponse;

        /// <summary>
        /// Public getter property for the "mResponse" private member
        /// </summary>
        public RemoteResponse Response
        {
            get
            {
                return mResponse;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private object mContents;

        /// <summary>
        /// Public getter property for the "mContents" private member
        /// </summary>
        public object Contents
        {
            get
            {
                return mContents;
            }
        }
    }
}