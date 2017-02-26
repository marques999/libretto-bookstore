using System.Runtime.Remoting;

public class ChatupServer
{
    /// <summary>
    /// Default constructor for the "ChatupServer" class
    /// </summary>
    private ChatupServer()
    {
        RemotingConfiguration.Configure("ChatupServer.exe.config", false);
    }

    /// <summary>
    /// 
    /// </summary>
    private static ChatupServer _instance;

    /// <summary>
    /// Public getter property for the "_instance" private member
    /// </summary>
    public static ChatupServer Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ChatupServer();
            }

            return _instance;
        }
    }
}