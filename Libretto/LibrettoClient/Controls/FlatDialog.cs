using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Controls
{
    /// <summary>
    /// 
    /// </summary>
    internal class FlatDialog : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FlatDialog()
        {
            ShowIcon = false;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            AutoScaleDimensions = ScaleDimensions;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// 
        /// </summary>
        public sealed override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        /// <summary>
        /// 
        /// </summary>
        private static readonly SizeF ScaleDimensions = new SizeF(6F, 13F);
    }
}