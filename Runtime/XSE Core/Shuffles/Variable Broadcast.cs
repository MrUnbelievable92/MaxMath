using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi8(v128 a, int imm8, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        return shuffle_epi8(a, set1_epi8((byte)(sizeof(byte) * imm8)));
                    }
                }

                a = bsrli_si128(a, imm8);

                if (elements > 2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx2.broadcastb_epi8(a);
                    }
                    else
                    {
                        a = unpacklo_epi8(a, a);
                        a = shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 0, 0));

                        if (elements > 8)
                        {
                            a = unpacklo_epi64(a, a);
                        }

                        return a;
                    }
                }
                else
                {
                    return unpacklo_epi8(a, a);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi16(v128 a, int imm8, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (Architecture.IsTableLookupSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        return shuffle_epi16(a, set1_epi16((ushort)imm8));
                    }
                }


                if (elements < 8 && constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0: return shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 0, 0));
                        case 1: return shufflelo_epi16(a, Sse.SHUFFLE(1, 1, 1, 1));
                        case 2: return shufflelo_epi16(a, Sse.SHUFFLE(2, 2, 2, 2));
                        case 3: return shufflelo_epi16(a, Sse.SHUFFLE(3, 3, 3, 3));
                        case 4: return shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(0, 0, 0, 0));
                        case 5: return shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(1, 1, 1, 1));
                        case 6: return shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(2, 2, 2, 2));
                        case 7: return shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(3, 3, 3, 3));
                        default: return a;
                    }
                }
                else
                {
                    a = bsrli_si128(a, imm8 * sizeof(short));

                    if (Avx2.IsAvx2Supported)
                    {
                        if (elements > 4)
                        {
                            return Avx2.broadcastw_epi16(a);
                        }
                    }

                    a = shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 0, 0));

                    if (elements > 8)
                    {
                        a = unpacklo_epi64(a, a);
                    }

                    return a;
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi32(v128 a, int imm8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0: return shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0));
                        case 1: return shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1));
                        case 2: return shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2));
                        case 3: return shuffle_epi32(a, Sse.SHUFFLE(3, 3, 3, 3));
                        default: return a;
                    }
                }
                else
                {
                    return shuffle_epi32(bsrli_si128(a, imm8 * sizeof(int)), Sse.SHUFFLE(0, 0, 0, 0));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi64(v128 a, int imm8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0: return shuffle_epi32(a, Sse.SHUFFLE(1, 0, 1, 0));
                        case 1: return shuffle_epi32(a, Sse.SHUFFLE(3, 1, 3, 2));
                        default: return a;
                    }
                }
                else
                {
                    return shuffle_epi32(bsrli_si128(a, imm8 * sizeof(long)), Sse.SHUFFLE(1, 0, 1, 0));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi8(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (imm8 > sizeof(v128) / sizeof(byte) - 1)
                {
                    a = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    a = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                }

                return Avx2.mm256_shuffle_epi8(a, mm256_set1_epi8((byte)imm8));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi16(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (imm8 > sizeof(v128) / sizeof(short) - 1)
                {
                    a = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    a = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                }

                return mm256_shuffle_epi16(a, mm256_set1_epi16((short)imm8));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi32(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_permutevar8x32_epi32(a, mm256_set1_epi32(imm8));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi64(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                long SHUFFLE_MASK = 2L * imm8;
                SHUFFLE_MASK |= (1L + SHUFFLE_MASK) << 32;

                return Avx2.mm256_permutevar8x32_epi32(a, mm256_set1_epi64x(SHUFFLE_MASK));
            }
            else throw new IllegalInstructionException();
        }
    }
}
