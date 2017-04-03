using System;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class Customer : CustomerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Identifier
        {
            get;
            set;
        } = new Guid();
    }
}