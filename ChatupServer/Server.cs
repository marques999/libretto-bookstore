using System.Runtime.Remoting;

public class Server
{
    private static Server instance;

    private Server()
    {
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
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