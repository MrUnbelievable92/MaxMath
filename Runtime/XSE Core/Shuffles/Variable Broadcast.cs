using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi8(v128 a, int imm8, byte elements = 16)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        result = shuffle_epi8(a, set1_epi8((byte)(sizeof(byte) * imm8)));
                        goto RET;
                    }
                }

                result = bsrli_si128(a, imm8);

                if (elements > 2)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Avx2.broadcastb_epi8(result);
                    }
                    else
                    {
                        result = unpacklo_epi8(result, result);
                        result = shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 0, 0));

                        if (elements > 8)
                        {
                            result = unpacklo_epi64(result, result);
                        }
                    }
                }
                else
                {
                    result = unpacklo_epi8(result, result);
                }

            RET:

                constexpr.ASSUME_EQ_EPU8(result, extract_epi8(a, (byte)imm8), elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi16(v128 a, int imm8, byte elements = 8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (BurstArchitecture.IsTableLookupSupported)
                {
                    if (constexpr.IS_CONST(imm8))
                    {
                        result = shuffle_epi16(a, set1_epi16((ushort)imm8));
                        goto RET;
                    }
                }


                if (elements < 8 && constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0: result = shufflelo_epi16(a, Sse.SHUFFLE(0, 0, 0, 0));                                 break;
                        case 1: result = shufflelo_epi16(a, Sse.SHUFFLE(1, 1, 1, 1));                                 break;
                        case 2: result = shufflelo_epi16(a, Sse.SHUFFLE(2, 2, 2, 2));                                 break;
                        case 3: result = shufflelo_epi16(a, Sse.SHUFFLE(3, 3, 3, 3));                                 break;
                        case 4: result = shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(0, 0, 0, 0)); break;
                        case 5: result = shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(1, 1, 1, 1)); break;
                        case 6: result = shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(2, 2, 2, 2)); break;
                        case 7: result = shufflelo_epi16(bsrli_si128(a, 4 * sizeof(short)), Sse.SHUFFLE(3, 3, 3, 3)); break;
                        default: result = a;                                                                          break;
                    }
                }
                else
                {
                    result = bsrli_si128(a, imm8 * sizeof(short));

                    if (Avx2.IsAvx2Supported)
                    {
                        if (elements > 4)
                        {
                            return Avx2.broadcastw_epi16(a);
                        }
                    }

                    result = shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 0, 0));

                    if (elements > 4)
                    {
                        result = unpacklo_epi64(result, result);
                    }
                }

            RET:

                constexpr.ASSUME_EQ_EPU16(result, extract_epi16(a, (byte)imm8), elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi32(v128 a, int imm8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0:  result = shuffle_epi32(a, Sse.SHUFFLE(0, 0, 0, 0)); break;
                        case 1:  result = shuffle_epi32(a, Sse.SHUFFLE(1, 1, 1, 1)); break;
                        case 2:  result = shuffle_epi32(a, Sse.SHUFFLE(2, 2, 2, 2)); break;
                        case 3:  result = shuffle_epi32(a, Sse.SHUFFLE(3, 3, 3, 3)); break;
                        default: result = a;                                         break;
                    }
                }
                else
                {
                    result = shuffle_epi32(bsrli_si128(a, imm8 * sizeof(int)), Sse.SHUFFLE(0, 0, 0, 0));
                }

                constexpr.ASSUME_EQ_EPU32(result, extract_epi32(a, (byte)imm8));
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 broadcasti_epi64(v128 a, int imm8)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;

                if (constexpr.IS_CONST(imm8))
                {
                    switch (imm8)
                    {
                        case 0:  result = shuffle_epi32(a, Sse.SHUFFLE(1, 0, 1, 0)); break;
                        case 1:  result = shuffle_epi32(a, Sse.SHUFFLE(3, 2, 3, 2)); break;
                        default: result = a;                                         break;
                    }
                }
                else
                {
                    result = shuffle_epi32(bsrli_si128(a, imm8 * sizeof(long)), Sse.SHUFFLE(1, 0, 1, 0));
                }

                constexpr.ASSUME_EQ_EPU64(result, extract_epi64(a, (byte)imm8));
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi8(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (imm8 > sizeof(v128) / sizeof(byte) - 1)
                {
                    result = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    result = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                }

                result = Avx2.mm256_shuffle_epi8(result, mm256_set1_epi8((byte)imm8));

                constexpr.ASSUME_EQ_EPU8(result, mm256_extract_epi8(a, (byte)imm8));
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi16(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;

                if (imm8 > sizeof(v128) / sizeof(short) - 1)
                {
                    result = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    result = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                }

                result = mm256_shuffle_epi16(result, mm256_set1_epi16((short)imm8));

                constexpr.ASSUME_EQ_EPU16(result, mm256_extract_epi16(a, (byte)imm8));
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_broadcasti_epi32(v256 a, int imm8)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx2.mm256_permutevar8x32_epi32(a, mm256_set1_epi32(imm8));

                constexpr.ASSUME_EQ_EPU32(result, mm256_extract_epi32(a, (byte)imm8));
                return result;
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

                v256 result = Avx2.mm256_permutevar8x32_epi32(a, mm256_set1_epi64x(SHUFFLE_MASK));

                constexpr.ASSUME_EQ_EPU64(result, mm256_extract_epi64(a, (byte)imm8));
                return result;
            }
            else throw new IllegalInstructionException();
        }
    }
}
