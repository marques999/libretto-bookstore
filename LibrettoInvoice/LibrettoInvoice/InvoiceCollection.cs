using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, XmlRoot("Invoices")]
    internal class InvoiceCollection
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlArray("InvoiceList")]
        [XmlArrayItem("Invoice", typeof(Invoice))]
        public List<Invoice> Invoices
        {
            get;
        } = new List<Invoice>();

        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public int Count => Invoices.Count;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceIndex"></param>
        /// <returns></returns>
        [XmlIgnore]
        public Invoice this[int invoiceIndex] => Invoices[invoiceIndex];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="invoiceInformation"></param>
        public void Insert(Invoice invoiceInformation)
        {
            Invoices.Add(invoiceInformation);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionIndex"></param>
        public void Remove(int transactionIndex)
        {
            if (transactionIndex >= 0 && transactionIndex < Invoices.Count)
            {
                Invoices.RemoveAt(transactionIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlSerializer"></param>
        /// <param name="fileName"></param>
        public void Serialize(XmlSerializer xmlSerializer, string fileName)
        {
            using (var writer = new FileStream(fileName, FileMode.Create))
            {
                xmlSerializer.Serialize(writer, this);
            }
        }
    }
}