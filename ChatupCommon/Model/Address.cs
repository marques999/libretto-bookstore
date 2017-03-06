using System.Net;

namespace ChatupNET.Model
{
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverHost"></param>
        /// <param name="serverPort"></param>
        public Address(IPAddress serverHost, ushort serverPort)
        {
            host = serverHost;
            port = serverPort;
        }

        /// <summary>
        /// 
        /// </summary>
        private IPAddress host;

        /// <summary>
        /// 
        /// </summary>
        public IPAddress Host
        {
            get
            {
                return host;
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