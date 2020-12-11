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
Assert.IsDefinedBitShift<byte>(n);

            byte16 mask = (byte)(0b1111_1111 << n);

            return mask & shl_short(v, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 v, int n)
        {
Assert.IsDefinedBitShift<byte>(n);

            byte32 mask = (byte)(0b1111_1111 << n);

            return mask & shl_short(v, n);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 v, int n)
        {
Assert.IsDefinedBitShift<byte>(n);

            byte16 mask = (byte)(0b1111_1111 >> n);

            return mask & shrl_short(v, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 v, int n)
        {
Assert.IsDefinedBitShift<byte>(n);

            byte32 mask = (byte)(0b1111_1111 >> n);

            return mask & shrl_short(v, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 v, int n)
        {
Assert.IsDefinedBitShift<sbyte>(n);

            byte32 mask = (byte)(0b1111_1111_0000_0000 >> n);

            byte32 maskedShift = maxmath.andn(shra_short(v, n), mask);
            byte32 signMask = Avx2.mm256_blendv_epi8(default(v256),     mask,   Avx2.mm256_cmpgt_epi8(default(v256), v));

            return maskedShift | signMask;
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
                shiftHi = shra_int(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = shra_long(shiftLo, 32);
            }

            return Sse4_1.blend_epi16(shiftLo, shiftHi, 0b1100_1100);
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
                shiftHi = shra_int(v, 31);
                shiftLo = shra_int(v, n - 32);
                shiftLo = shra_long(shiftLo, 32);
            }

            return Avx2.mm256_blend_epi16(shiftLo, shiftHi, 0b1100_1100);
        }
    }
}