using System;

public class RegisterObject
{
    private TimeZoneInfo _timezone;

    public TimeZoneInfo Timezone
    {
        get
        {
            return _timezone;
        }
    }

    private string _username;

    public string Username
    {
        get
        {
            return _username;
        }
    }

    private string _password;

    public string Password
    {
        get
        {
            return _password;
        }
    }

    public RegisterObject(string userName, string userPassword, TimeZoneInfo userTimezone)
    {
        _username = userName;
        _password = userPassword;
        _timezone = userTimezone;
    }
}