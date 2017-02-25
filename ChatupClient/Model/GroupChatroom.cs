using System;

public class GroupChatroom : Chatroom
{
    private int _capacity;

    public int Capacity
    {
        get
        {
            return _capacity;
        }
    }

    public override string GetCapacity()
    {
        return Capacity < 1 ? "INF" : Convert.ToString(Capacity + 1);
    }

    private string _password;

    public string Password
    {
        get
        {
            return _password;
        }
    }

    public override bool IsGroup()
    {
        return true;
    }

    public GroupChatroom(string roomName, string roomPassword, int roomCapacity) : base(roomName)
    {
        _password = string.IsNullOrEmpty(roomPassword) ? null : roomPassword.Trim();
        _capacity = roomCapacity;
    }
}