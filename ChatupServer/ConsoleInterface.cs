using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChatupNET
{
    /// <summary>
    /// 
    /// </summary>
    internal class ConsoleInterface
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="richTextBox"></param>
        public ConsoleInterface(RichTextBox richTextBox)
        {
            _richText = richTextBox;
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly RichTextBox _richText;

        /// <summary>
        /// 
        /// </summary>
        private static readonly Color Green = Color.FromArgb(166, 226, 46);

        /// <summary>
        /// 
        /// </summary>
        public static readonly Color Blue = Color.FromArgb(102, 217, 239);

        /// <summary>
        /// 
        /// </summary>
        public static readonly Color Yellow = Color.FromArgb(244, 191, 117);

        /// <summary>
        /// 
        /// </summary>
        public static readonly Color Default = Color.FromArgb(248, 248, 242);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageContent"></param>
        public void Print(string messageContent) => Print(messageContent, Default);

        /// <summary>
        /// 
        /// </summary>
        public void Timestamp() => Print(DateTime.Now.ToString("[HH:mm:ss] "), Green);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageContent"></param>
        /// <param name="messageColor"></param>
        public void Print(string messageContent, Color messageColor)
        {
            _richText.SelectionStart = _richText.TextLength;
            _richText.SelectionLength = 0;
            _richText.SelectionColor = messageColor;
            _richText.AppendText(messageContent);
            _richText.SelectionColor = _richText.ForeColor;
            _richText.ScrollToCaret();
        }
    }
}