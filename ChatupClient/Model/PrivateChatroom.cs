class PrivateChatroom : Chatroom
{
    public override string GetCapacity()
    {
        return "2";
    }

    public override bool IsGroup()
    {
        return false;
    }

    public PrivateChatroom(string roomName) : base(roomName)
    {
    }
}