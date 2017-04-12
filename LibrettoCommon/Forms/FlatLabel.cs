using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FlatLabel : Label
    {
        /// <summary>
        /// 
        /// </summary>
        public FlatLabel()
        {
            AutoSize = true;
            Margin = LabelMargin;
            Dock = DockStyle.Fill;
            BackColor = Color.Silver;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly Padding LabelMargin = new Padding(0);
    }
}