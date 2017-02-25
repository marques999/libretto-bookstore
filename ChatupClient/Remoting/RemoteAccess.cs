using System;
using System.Collections;
using System.Runtime.Remoting;

class RemoteAccess
{
    private static IDictionary wellKnownTypes;

    public static object New(Type type)
    {
        if (wellKnownTypes == null)
        {
            InitTypeCache();
        }

        var entry = (WellKnownClientTypeEntry)wellKnownTypes[type];

        if (entry == null)
        {
            throw new RemotingException("Type not found!");
        }

        return Activator.GetObject(type, entry.ObjectUrl);
    }

    public static void InitTypeCache()
    {
        var types = new Hashtable();

        foreach (var entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
        {
            if (entry.ObjectType == null)
            {
                throw new RemotingException("A configured type could not be found!");
            }

            types.Add(entry.ObjectType, entry);
        }

        wellKnownTypes = types;
    }
}