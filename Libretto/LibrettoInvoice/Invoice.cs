using System;

namespace LibrettoInvoice
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class Invoice
    {
        /// <summary>
        /// 
        /// </summary>
        public long ProductId
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Price
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Coupon
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public char Type
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastUpdate
        {
            get;
            set;
        }
    }
}