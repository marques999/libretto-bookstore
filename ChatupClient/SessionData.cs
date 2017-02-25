public class SessionData
{
    private static SessionData instance;

    private SessionData()
    {
    }

    public static SessionData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SessionData();
            }

            return instance;
        }
    }

    private string _username;

    public bool IsAuthenticated()
    {
        return _username != null;
    }

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