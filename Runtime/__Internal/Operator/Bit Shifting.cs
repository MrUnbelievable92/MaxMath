using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe internal static partial class Operator
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_byte(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.set1_epi8((sbyte)(0b1111_1111 >> n));

                return shl_short(Sse2.and_si128(x, mask), n);
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_byte(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi8((byte)(0b1111_1111 >> n));

                return shl_short(Avx2.mm256_and_si256(x, mask), n);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_byte(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 mask = Sse2.set1_epi8((sbyte)(0b1111_1111 << n));

                return shrl_short(Sse2.and_si128(x, mask), n);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_byte(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 mask = Avx.mm256_set1_epi8((byte)(0b1111_1111 << n));

                return shrl_short(Avx2.mm256_and_si256(x, mask), n);
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_byte(v128 x, int n)
        {
            v128 even = shra_short(shl_short(x, 8), n + 8);
            v128 odd = shra_short(x, n);

            return Mask.BlendV(even, odd, new v128(0xFF00_FF00));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_byte(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 even = shra_short(shl_short(x, 8), n + 8);
                v256 odd = shra_short(x, n);

                return Avx2.mm256_blendv_epi8(even, odd, new v256(0xFF00_FF00));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_short(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sll_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_short(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_short(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_short(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_short(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sra_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_short(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi16(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shra_int(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sra_epi32(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_int(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sra_epi32(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_int(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi32(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_int(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi32(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_int(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi32(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shl_long(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sll_epi64(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shl_long(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sll_epi64(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 shrl_long(v128 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.srl_epi64(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shrl_long(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_srl_epi64(x, new v128(n, 0, 0, 0));
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long2 shra_long(long2 x, int n)
        {
            v128 shiftLo;
            v128 shiftHi;

            if (n <= 32)
            {
                shiftHi = shra_int(x, n);
                shiftLo = shrl_long(x, n);
            }
            else
            {
                shiftHi = shra_int(x, 31);
                shiftLo = shra_int(x, n - 32);
                shiftLo = shrl_long(shiftLo, 32);
            }


            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.blend_epi16(shiftLo, shiftHi, 0b1100_1100);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Mask.BlendEpi16_SSE2(shiftLo, shiftHi, 0b1100_1100);
            }
            else throw new CPUFeatureCheckException();
            
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 shra_long(v256 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shiftLo;
                v256 shiftHi;

                if (n <= 32)
                {
                    shiftHi = shra_int(x, n);
                    shiftLo = shrl_long(x, n);
                }
                else
                {
                    shiftHi = shra_int(x, 31);
                    shiftLo = shra_int(x, n - 32);
                    shiftLo = shrl_long(shiftLo, 32);
                }

                return Avx2.mm256_blend_epi32(shiftLo, shiftHi, 0b1010_1010);
            }
            else throw new CPUFeatureCheckException();
        }
    }
}