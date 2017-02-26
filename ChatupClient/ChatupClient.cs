using System.Runtime.Remoting;

public class ChatupClient
{
    /// <summary>
    /// Default constructor for the "ChatupCient" class
    /// </summary>
    private ChatupClient()
    {
        RemotingConfiguration.Configure("ChatupClient.exe.config", false);
    }

    /// <summary>
    /// 
    /// </summary>
    private string _username;

    /// <summary>
    /// 
    /// </summary>
    private static ChatupClient _instance;

    /// <summary>
    /// Public getter for the "instance" private member
    /// </summary>
    public static ChatupClient Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ChatupClient();
            }

            return _instance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsAuthenticated()
    {
        return _username != null;
    }

    /// <summary>
    /// Public getter for the "_username" private member
    /// </summary>
    public string Username
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
        }
    }
}