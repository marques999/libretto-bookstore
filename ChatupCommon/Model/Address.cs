using System.Net;

namespace ChatupNET.Model
{
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverAddress"></param>
        /// <param name="serverPort"></param>
        public Address(IPAddress serverAddress, ushort serverPort)
        {
            address = serverAddress;
            port = serverPort;
        }

        /// <summary>
        /// 
        /// </summary>
        private IPAddress address;

        /// <summary>
        /// 
        /// </summary>
        public IPAddress Host
        {
            get
            {
                return address;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ushort port;

        /// <summary>
        /// 
        /// </summary>
        public ushort Port
        {
            get
            {
                return port;
            }
        }
    }
}