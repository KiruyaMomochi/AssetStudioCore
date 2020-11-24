using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetStudio
{
    internal static class Utils
    {
        // Converts an array of bytes into a half.
        public static Half ToHalf(byte[] value, int startIndex) => Int16BitsToHalf(System.BitConverter.ToInt16(value, startIndex));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe Half Int16BitsToHalf(short value)
        {
            return *(Half*)&value;
        }
    }
}
