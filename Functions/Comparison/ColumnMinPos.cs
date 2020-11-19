using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte2 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128((ushort2)x, new v128(0, -1, -1, -1))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte2 x, out byte min)
        {
            v128 t = X86.Sse4_1.minpos_epu16((ushort2)x);
            min = X86.Sse4_1.extract_epi8(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte3 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128((ushort3)x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte3 x, out byte min)
        {
            v128 t = X86.Sse4_1.minpos_epu16((ushort3)x);
            min = X86.Sse4_1.extract_epi8(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte4 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128((ushort4)x, new v128(0, 0, -1, -1))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte4 x, out byte min)
        {
            v128 t = X86.Sse4_1.minpos_epu16((ushort4)x);
            min = X86.Sse4_1.extract_epi8(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte8 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16((ushort8)x), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(byte8 x, out byte min)
        {
            v128 t = X86.Sse4_1.minpos_epu16((ushort8)x);
            min = X86.Sse4_1.extract_epi8(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort2 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0, -1, -1, -1))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort2 x, out ushort min)
        {
            v128 t = X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0, -1, -1, -1)));
            min = X86.Sse2.extract_epi16(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort3 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort3 x, out ushort min)
        {
            v128 t = X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0u, 0xFFFF_0000u, uint.MaxValue, uint.MaxValue)));
            min = X86.Sse2.extract_epi16(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort4 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0, 0, -1, -1))), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort4 x, out ushort min)
        {
            v128 t = X86.Sse4_1.minpos_epu16(X86.Sse2.or_si128(x, new v128(0, 0, -1, -1)));
            min = X86.Sse2.extract_epi16(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort8 x)
        {
            return X86.Sse2.extract_epi16(X86.Sse4_1.minpos_epu16(x), 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cminpos(ushort8 x, out ushort min)
        {
            v128 t = X86.Sse4_1.minpos_epu16(x);
            min = X86.Sse2.extract_epi16(t, 0);

            return X86.Sse2.extract_epi16(t, 1);
        }
    }
}