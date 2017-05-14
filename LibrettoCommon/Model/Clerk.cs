using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Table("Clerk")]
    public class Clerk
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public Guid Id
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember, Required]
        public string Password
        {
            get;
            set;
        }
    }
}