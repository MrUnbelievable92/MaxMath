using DevTools;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary> UNSAFE (not clamped to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cvt_uint8(bool a)
        { 
Assert.IsBetween<byte>(*(byte*)&a, 0, 1);

            return *(byte*)&a;
        }

        /// <summary> UNSAFE (not clamping 'a' to [0, 1]) </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool cvt_boolean(int a)
        { 
Assert.IsBetween<byte>((byte)a, 0, 1);

            return *(bool*)&a;
        }
    }
}