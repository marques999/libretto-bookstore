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
    private static ChatupClient instance;

    /// <summary>
    /// Public getter property for the "instance" private member
    /// </summary>
    public static ChatupClient Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ChatupClient();
            }

            return instance;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private string username;

    /// <summary>
    /// Public getter property for the "username" private member
    /// </summary>
    public string Username
    {
        get
        {
            return username;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private bool active;

    /// <summary>
    /// Public getter property for the "active" private member
    /// </summary>
    public bool Active
    {
        get
        {
            return active && username != null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    public void Login(string userName)
    {
        active = true;
        username = userName;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Logout()
    {
        active = false;
        username = null;
    }
}