using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_byte(v128 v, int n)
        {
            byte16 mask = (byte)(0b1111_1111 >> n);

            return shl_short(v & mask, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 v, int n)
        {
            byte32 mask = (byte)(0b1111_1111 >> n);

            return shl_short(v & mask, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 v, int n)
        {
            byte16 mask = (byte)(0b1111_1111 << n);

            return shrl_short(v & mask, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 v, int n)
        {
            byte32 mask = (byte)(0b1111_1111 << n);

            return shrl_short(v & mask, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 v, int n)
        {
            v256 lo = shra_short(shl_short(v, 8), n + 8);
            v256 hi = shra_short(v, n);

            return Avx2.mm256_blendv_epi8(hi, lo, new v256(0x00FF_00FF));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_short(v128 v, int n)
        {
            return Sse2.sll_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_short(v256 v, int n)
        {
            return Avx2.mm256_sll_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_short(v128 v, int n)
        {
            return Sse2.srl_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_short(v256 v, int n)
        {
            return Avx2.mm256_srl_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_short(v128 v, int n)
        {
            return Sse2.sra_epi16(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_short(v256 v, int n)
        {
            return Avx2.mm256_sra_epi16(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_int(v128 v, int n)
        {
            return Sse2.sra_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_int(v256 v, int n)
        {
            return Avx2.mm256_sra_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_int(v128 v, int n)
        {
            return Sse2.srl_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_int(v256 v, int n)
        {
            
            return Avx2.mm256_srl_epi32(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_int(v256 v, int n)
        {
            return Avx2.mm256_sll_epi32(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_long(v128 v, int n)
        {
            return Sse2.sll_epi64(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_long(v256 v, int n)
        {
            return Avx2.mm256_sll_epi64(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_long(v128 v, int n)
        {
            return Sse2.srl_epi64(v, new v128(n, 0, 0, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_long(v256 v, int n)
        {
            return Avx2.mm256_srl_epi64(v, new v128(n, 0, 0, 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 shra_long(long2 v, int n)
        {
            v128 shiftLo;
            v128 shiftHi;

            if (n <= 32)
            {
                shiftHi = shra_int(v, n);
                shiftLo = shrl_long(v, n);
            }
            else
            {
                shiftHi = Sse2.srai_epi32(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = Sse2.srli_epi64(shiftLo, 32);
            }

            return Sse4_1.blend_epi16(shiftLo, shiftHi, Sse.SHUFFLE(3, 0, 3, 0));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_long(v256 v, int n)
        {
            v256 shiftLo;
            v256 shiftHi;
           
            if (n <= 32)
            {
                shiftHi = shra_int(v, n);
                shiftLo = shrl_long(v, n);
            }
            else
            {
                shiftHi = Avx2.mm256_srai_epi32(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = Avx2.mm256_srli_epi64(shiftLo, 32);
            }

            return Avx2.mm256_blend_epi16(shiftLo, shiftHi, Sse.SHUFFLE(3, 0, 3, 0));
        }
    }
}