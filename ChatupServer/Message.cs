using System;

[Serializable]
public class Message
{
    public Message(string messageAuthor, string messageContents, DateTime messageTimestamp)
    {
        mAuthor = messageAuthor;
        mContents = messageContents;
        mTimestamp = messageTimestamp;
    }

    private string mAuthor;

    public string Author
    {
        get
        {
            return mAuthor;
        }
    }

    private string mContents;

    public string Contents
    {
        get
        {
            return mContents;
        }
    }

    private DateTime mTimestamp;

    public DateTime Timestamp
    {
        get
        {
            return mTimestamp;
        }
    }
}