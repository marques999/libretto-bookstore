using System;
using System.Runtime.Remoting;
using System.Threading;

using Libretto.Forms;
using Libretto.Remoting;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal class InvoiceClient : MarshalByRefObject
    {
        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            RemotingConfiguration.RegisterWellKnownClientType(
                typeof(InvoiceInterface),
                "tcp://localhost:12480/invoice.rem"
            );

            var invoiceProxy = (InvoiceInterface)RemoteAccess.New(typeof(InvoiceInterface));

            invoiceProxy.OnReceive += invoiceInformation =>
            {
                new InvoiceForm(invoiceInformation).Show();
            };

            Console.ReadLine();
        }
    }
}