using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Controls
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class FlatBadge : Label
    {
        /// <summary>
        /// 
        /// </summary>
        public FlatBadge()
        {
            AutoSize = true;
            Font = LabelFont;
            Dock = DockStyle.Fill;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly Font LabelFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
    }
}