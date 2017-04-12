using System;
using System.Collections;
using System.Runtime.Remoting;

namespace Libretto
{
    /// <summary>
    ///
    /// </summary>
    internal class RemoteAccess
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="classType"></param>
        /// <returns></returns>
        public static object New(Type classType)
        {
            if (_wellKnownTypes == null)
            {
                InitTypeCache();
            }

            var wellKnownType = (WellKnownClientTypeEntry)_wellKnownTypes[classType];

            if (wellKnownType == null)
            {
                throw new RemotingException("Type not found!");
            }

            return Activator.GetObject(classType, wellKnownType.ObjectUrl);
        }

        /// <summary>
        ///
        /// </summary>
        private static IDictionary _wellKnownTypes;

        /// <summary>
        ///
        /// </summary>
        private static void InitTypeCache()
        {
            var typeTable = new Hashtable();

            foreach (var registeredObject in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
            {
                if (registeredObject.ObjectType == null)
                {
                    throw new RemotingException("A configured type could not be found!");
                }

                typeTable.Add(registeredObject.ObjectType, registeredObject);
            }

            _wellKnownTypes = typeTable;
        }
    }
}