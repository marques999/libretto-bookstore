using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class FlatHeader : Label
    {
        /// <summary>
        /// 
        /// </summary>
        public FlatHeader()
        {
            AutoSize = true;
            Font = HeaderFont;
            Dock = DockStyle.Fill;
            Margin = HeaderMargin;
            ForeColor = Color.Silver;
            BackColor = SystemColors.ControlDarkDark;
            TextAlign = ContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly Padding HeaderMargin = new Padding(2);

        /// <summary>
        /// 
        /// </summary>
        private static readonly Font HeaderFont = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
    }
}