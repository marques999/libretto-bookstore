using System;
using System.ComponentModel;

namespace Libretto.Warehouse
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public enum WarehouseStatus
    {
        [Description("Pending")]
        Pending,
        [Description("Dispatched")]
        Dispatched,
        [Description("Cancelled")]
        Cancelled
    }
}