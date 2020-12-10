using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if _this is smaller than _other', 1 if _this is greater than _other or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(int _this, int _other)
        {
            return (-cvt_uint8(_this < _other)) | cvt_uint8(_this != _other);
        }

        /// <summary>       Returns -1 if _this is smaller than _other', 1 if _this is greater than _other or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(uint _this, uint _other)
        {
            ulong cmp = (ulong)_this - (ulong)_other;

            return (int)((((long)cmp) >> 63)   |   cvt_uint8(cmp != 0));
        }


        /// <summary>       Returns -1 if _this is smaller than _other', 1 if _this is greater than _other or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(long _this, long _other)
        {
            return (-cvt_uint8(_this < _other)) | cvt_uint8(_this != _other);
        }

        /// <summary>       Returns -1 if _this is smaller than _other', 1 if _this is greater than _other or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(ulong _this, ulong _other)
        {
            return (-cvt_uint8(_this < _other)) | cvt_uint8(_this != _other);
        }
    }
}