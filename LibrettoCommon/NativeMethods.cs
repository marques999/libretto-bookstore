using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Libretto
{
    /// <summary>
    ///
    /// </summary>
    public class NativeMethods
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="pwfi"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// <summary>
        ///
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="formInstance"></param>
        /// <returns></returns>
        public static bool FlashWindowEx(Form formInstance)
        {
            var fInfo = new FLASHWINFO
            {
                dwTimeout = 0,
                dwFlags = 0x0F,
                uCount = uint.MaxValue,
                hwnd = formInstance.Handle,
            };

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));

            return FlashWindowEx(ref fInfo);
        }
    }
}