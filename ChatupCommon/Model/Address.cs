using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace ChatupNET.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Address
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="remotePort"></param>
        public Address(ushort remotePort)
        {
            Port = remotePort;
            Host = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ipAddress => ipAddress.AddressFamily == AddressFamily.InterNetwork);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remoteHost"></param>
        /// <param name="remotePort"></param>
        public Address(IPAddress remoteHost, ushort remotePort)
        {
            Host = remoteHost;
            Port = remotePort;
        }

        /// <summary>
        /// Public getter property for the "Host" private member
        /// </summary>
        public IPAddress Host
        {
            get;
        }

        /// <summary>
        /// Public getter property for the "Port" private member
        /// </summary>
        public ushort Port
        {
            get;
        }
    }
}