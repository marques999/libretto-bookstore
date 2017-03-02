using System.Net;

namespace ChatupNET.Remoting
{
    public class AddressObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverAddress"></param>
        /// <param name="serverPort"></param>
        public AddressObject(IPAddress serverAddress, ushort serverPort)
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
        public IPAddress Address
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