using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using Libretto.Model;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [XmlRoot("Warehouse")]
    public class WarehouseBooks : SerializableClass
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public Dictionary<Guid, Book> Books
        {
            get;
        } = new Dictionary<Guid, Book>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Book this[Guid key]
        {
            get => Books[key];
            set => Books[key] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [XmlArray("BookList")]
        [XmlArrayItem("Book", typeof(SerializableBook))]
        public SerializableBook[] BooksProxy
        {
            get
            {
                return new List<SerializableBook>(Books.Select(bookInformation => new SerializableBook
                {
                    Key = bookInformation.Key,
                    Value = bookInformation.Value
                })).ToArray();
            }
            set
            {
                foreach (var bookInformation in value)
                {
                    Books.Add(bookInformation.Key, bookInformation.Value);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bookIdentifier"></param>
        /// <param name="stockQuantity"></param>
        /// <returns></returns>
        public bool UpdateStock(Guid bookIdentifier, int stockQuantity)
        {
            var operationResult = Books.TryGetValue(bookIdentifier, out Book bookInformaton);

            if (operationResult)
            {
                bookInformaton.Stock = stockQuantity;
            }

            return operationResult;
        }
    }
}