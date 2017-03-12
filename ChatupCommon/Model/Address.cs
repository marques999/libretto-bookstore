using System;
using System.Net;
using System.Net.Sockets;

namespace ChatupNET.Model
{
    [Serializable]
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverHost"></param>
        /// <param name="serverPort"></param>
        public Address(ushort serverPort)
        {
            host = FindAddress();
            port = serverPort;
        }

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
        /// <returns></returns>
        private IPAddress FindAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }

            return null;
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