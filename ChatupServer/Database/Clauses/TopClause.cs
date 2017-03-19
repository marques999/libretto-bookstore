using ChatupNET.Database.Enums;

namespace ChatupNET.Database
{
    struct TopClause
    {
        /// <summary>
        /// 
        /// </summary>
        public TopUnit Unit;

        /// <summary>
        /// 
        /// </summary>
        public int Quantity;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nr"></param>
        /// <param name="aUnit"></param>
        public TopClause(int nr, TopUnit aUnit)
        {
            Quantity = nr;
            Unit = aUnit;
        }
    }
}