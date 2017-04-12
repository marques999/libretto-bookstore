using System;
using System.Runtime.Remoting;
using System.Windows.Forms;

using Libretto.Warehouse;

namespace Libretto
{
    /// <summary>
    /// 
    /// </summary>
    internal static class WarehouseClient
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="warehouseIntermediate"></param>
        public static void InitializeWarehouse(WarehouseIntermediate warehouseIntermediate)
        {
            Warehouse.OnRefreshBooks += warehouseIntermediate.RefreshBooks;
            Warehouse.OnRefreshOrders += warehouseIntermediate.RefreshOrders;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="warehouseIntermediate"></param>
        public static void DestroyWarehouse(WarehouseIntermediate warehouseIntermediate)
        {
            Warehouse.OnRefreshBooks -= warehouseIntermediate.RefreshBooks;
            Warehouse.OnRefreshOrders -= warehouseIntermediate.RefreshOrders;
        }

        /// <summary>
        /// 
        /// </summary>
        public static WarehouseInterface Warehouse
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RemotingConfiguration.RegisterActivatedServiceType(typeof(WarehouseIntermediate));
            RemotingConfiguration.RegisterActivatedServiceType(typeof(WarehouseInterface));
            Warehouse = (WarehouseInterface)RemotingServices.Connect(typeof(WarehouseInterface), WarehouseCommon.RemotingAddress);
            Application.Run(new WarehouseForm());
        }
    }
}