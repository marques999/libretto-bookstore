using System;

using Libretto.Enums;

namespace Libretto.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Order
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Identifier
        {
            get;
            set;
        } = new Guid();

        /// <summary>
        /// 
        /// </summary>
        public OrderState State
        {
            get;
            set;
        } = new WaitingExpedition();

        /// <summary>
        /// 
        /// </summary>
        public Guid Customer
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public Book Book
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// /
        /// </summary>
        public double Total
        {
            get;
            set;
        }
    }
}