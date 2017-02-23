using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

public class Server
{
    private static Server instance;

    private Server()
    {
        RemotingConfiguration.Configure("Server.exe.config", false);
    }

    public static Server getInstance()
    {
        if (instance == null)
        {
            instance = new Server();
        }

        return instance;
    }
}