public class SessionToken
{
    public SessionToken(string userName, string userToken)
    {
        mToken = userToken;
        mUsername = userName;
    }

    private string mToken;
    private string mUsername;

    public string Token
    {
        get
        {
            return mToken;
        }
    }

    public string Username
    {
        get
        {
            return mUsername;
        }
    }
}