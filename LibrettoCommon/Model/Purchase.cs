using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract, Table("Purchase")]
    public class Purchase : Transaction
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember, NotMapped]
        public override string Description => "Purchased";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="waitingChecked"></param>
        /// <param name="processingChecked"></param>
        /// <param name="dispatchedChecked"></param>
        /// <returns></returns>
        public override bool Filter(bool waitingChecked, bool processingChecked, bool dispatchedChecked)
        {
            return true;
        }
    }
}