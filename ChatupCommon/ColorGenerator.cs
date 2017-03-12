using System;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace ChatupNET
{
    public class ColorGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        private static Random mRandom = new Random();

        /// <summary>
        /// 
        /// </summary>
        private static readonly Color[] mColors = typeof(Color)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(propInfo => propInfo.GetValue(null, null))
            .Cast<Color>()
            .ToArray();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Color Random()
        {
            return mColors[mRandom.Next(0, mColors.Length)];
        }
    }
}