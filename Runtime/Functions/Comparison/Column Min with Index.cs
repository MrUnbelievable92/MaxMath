using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the index of the minimum component of a ushort2 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort2 x, out ushort min)
        {
            v128 t = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0, -1, -1, -1)));
            min = Sse2.extract_epi16(t, 0);

            return Sse2.extract_epi16(t, 1);
        }

        /// <summary>       Returns the index of the minimum component of a ushort3 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort3 x, out ushort min)
        {
            v128 t = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue)));
            min = Sse2.extract_epi16(t, 0);

            return Sse2.extract_epi16(t, 1);
        }

        /// <summary>       Returns the index of the minimum component of a ushort4 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort4 x, out ushort min)
        {
            v128 t = Sse4_1.minpos_epu16(Sse2.or_si128(x, new v128(0, 0, -1, -1)));
            min = Sse2.extract_epi16(t, 0);

            return Sse2.extract_epi16(t, 1);
        }

        /// <summary>       Returns the index of the minimum component of a ushort8 vector with the minimum component as an out parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort8 x, out ushort min)
        {
            v128 t = Sse4_1.minpos_epu16(x);
            min = Sse2.extract_epi16(t, 0);

            return Sse2.extract_epi16(t, 1);
        }
    }
}