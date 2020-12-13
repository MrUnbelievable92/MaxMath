using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if 'this' is smaller than 'other', 1 if 'this' is greater than 'other' or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(int _this, int _other)
        {
            return (-touint8(_this < _other)) | touint8(_this != _other);
        }

        /// <summary>       Returns -1 if 'this' is smaller than 'other', 1 if 'this' is greater than 'other' or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(uint _this, uint _other)
        {
            ulong cmp = (ulong)_this - (ulong)_other;

            return (int)((((long)cmp) >> 63)   |   touint8(cmp != 0));
        }


        /// <summary>       Returns -1 if 'this' is smaller than 'other', 1 if 'this' is greater than 'other' or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(long _this, long _other)
        {
            return (-touint8(_this < _other)) | touint8(_this != _other);
        }

        /// <summary>       Returns -1 if 'this' is smaller than 'other', 1 if 'this' is greater than 'other' or 0 if both are equal.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]   [return: AssumeRange(-1, 1)]
        public static int compareto(ulong _this, ulong _other)
        {
            return (-touint8(_this < _other)) | touint8(_this != _other);
        }
    }
}