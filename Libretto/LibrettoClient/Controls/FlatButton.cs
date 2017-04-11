using System.Drawing;
using System.Windows.Forms;

namespace Libretto.Controls
{
    /// <summary>
    /// 
    /// </summary>
    internal sealed class FlatButton : Button
    {
        /// <summary>
        /// 
        /// </summary>
        public FlatButton()
        {
            AutoSize = true;
            FlatStyle = FlatStyle.Flat;
            UseVisualStyleBackColor = false;
            BackColor = SystemColors.Control;
            FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        }
    }
}