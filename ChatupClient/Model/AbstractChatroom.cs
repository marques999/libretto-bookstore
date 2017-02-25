using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

public abstract class Chatroom
{
    private Random randomGenerator = new Random();
    private Dictionary<string, Color> _users = new Dictionary<string, Color>();

    public Chatroom(string roomName)
    {
        _name = roomName;
    }
 
    static readonly Color[] Colors = typeof(Color)
        .GetProperties(BindingFlags.Public | BindingFlags.Static)
        .Select(propInfo => propInfo.GetValue(null, null))
        .Cast<Color>()
        .ToArray();

    private string _name;

    public string Name
    {
        get
        {
            return _name;
        }
    }

    public int Count
    {
        get
        {
            return _users.Count;
        }
    }

    public void InsertUser(string userName)
    {
        _users.Add(userName, Colors[randomGenerator.Next(0, Colors.Length)]);
    }

    public void InsertUser(string userName, Color userColor)
    {
        _users.Add(userName, userColor);
    }

    public void RemoveUser(string userName)
    {
        _users.Remove(userName);
    }

    public Color Color(string userName)
    {
        try
        {
            return _users[userName];
        }
        catch (KeyNotFoundException)
        {
            return System.Drawing.Color.Black;
        }
    }

    public Dictionary<string, Color> Users
    {
        get
        {
            return _users;
        }
    }

    public abstract bool IsGroup();

    public abstract string GetCapacity();
}