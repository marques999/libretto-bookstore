using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Libretto.Model;
using Libretto.Remoting;

namespace InvoiceTest
{
    /// <summary>
    /// 
    /// </summary>
    internal class InvoiceServer : MarshalByRefObject, InvoiceInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main()
        {
            var testInvoice = new InvoiceServer();
            Console.ReadLine();
        }

        public InvoiceServer()
        {
            var tcpChannel = new TcpChannel(new Hashtable()
            {
                {"port", 12480}
            }, new BinaryClientFormatterSinkProvider(), new BinaryServerFormatterSinkProvider
            {
                TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            });

            ChannelServices.RegisterChannel(tcpChannel, false);
            RemotingConfiguration.RegisterActivatedServiceType(typeof(InvoiceServer));
            RemotingServices.Marshal(this, "invoice.rem");

            OnReceive?.Invoke(new Invoice
            {
                Description = "ABC",
                Coupon = false,
                LastUpdate = DateTime.Now,
                Price = 2.49,
                Quantity = 5,
                Type = 'x'
            });
        }

        public event ReceiveHandler OnReceive;
    }
}