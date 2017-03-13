using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("ChatServer.exe.config", false);
            Console.WriteLine("Press Return to terminate.");
            Console.ReadLine();
        }
    }
}
