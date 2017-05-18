using System;

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
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            var orderGuid = Guid.NewGuid();
            var warehouseQueue = MessagingCommon.InitializeWarehouseQueue();

            Console.Write("Testing WarehouseOrder (<Enter> to continue)...");
            Console.ReadLine();

            warehouseQueue.Send(new WarehouseOrder
            {
                Quantity = 100,
                Total = 1234.0,
                Title = "QWERTY",
                Identifier = orderGuid,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            });

            Console.Write("Testing MessageUpdate (<Enter> to continue)...");
            Console.ReadLine();

            warehouseQueue.Send(new MessageUpdate
            {
                Quantity = 200,
                Total = 2468.0,
                Identifier = orderGuid
            });

            Console.Write("Testing MessageCancel (<Enter> to continue)...");
            Console.ReadLine();

            warehouseQueue.Send(new MessageCancel
            {
                Identifier = orderGuid
            });
        }
    }
}