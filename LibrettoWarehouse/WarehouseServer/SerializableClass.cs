using System.IO;
using System.Xml.Serialization;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class SerializableClass
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        /// <param name="fileName"></param>
        public void Serialize(XmlSerializer xmlSerializer, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}