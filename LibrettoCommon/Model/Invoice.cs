using System;
using System.Xml.Serialization;

namespace Libretto.Model
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
        [XmlElement("Identifier")]
        public Guid Identifier
        {
            get;
            set;
        } = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Title")]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Customer")]
        public string Customer
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Timestamp")]
        public DateTime Timestamp
        {
            get;
            set;
        } = DateTime.Now;

        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Quantity")]
        public int Quantity
        {
            get;
            set;
        }

        /// <summary>
        /// /
        /// </summary>
        [XmlElement("Total")]
        public double Total
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseInformation"></param>
        /// <returns></returns>
        public static Invoice FromPurchase(Purchase purchaseInformation)
        {
            return new Invoice
            {
                Total = purchaseInformation.Total,
                Identifier = purchaseInformation.Id,
                Title = purchaseInformation.BookTitle,
                Quantity = purchaseInformation.Quantity,
                Timestamp = purchaseInformation.Timestamp,
                Customer = purchaseInformation.CustomerName
            };
        }
    }
}