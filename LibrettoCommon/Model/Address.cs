using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace Libretto.Model
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
        ///
        /// </summary>
        public IPAddress Host
        {
            get;
        }

        /// <summary>
        ///
        /// </summary>
        public ushort Port
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Host}:{Port:D}";
        }
    }
}