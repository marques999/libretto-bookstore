using System;
using System.Messaging;

using Libretto.Messaging;
using Libretto.Warehouse;

namespace WarehouseTest
{
    /// <summary>
    /// 
    /// </summary>
    internal class WarehouseTest
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly MessageQueue WarehouseQueue = MessagingCommon.InitializeWarehouseQueue();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var orderGuid = Guid.NewGuid();

            WarehouseQueue.Send(new WarehouseOrder
            {
                Quantity = 100,
                Total = 1234.0,
                Title = "QWERTY",
                Identifier = orderGuid,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });

            WarehouseQueue.Send(new MessageUpdate
            {
                Quantity = 200,
                Total = 2468.0,
                Identifier = orderGuid
            });

            WarehouseQueue.Send(new MessageCancel
            {
                Identifier = orderGuid
            });
        }
    }
}