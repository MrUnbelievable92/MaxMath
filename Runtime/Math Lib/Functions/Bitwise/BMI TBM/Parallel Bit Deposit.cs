using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP_pdep_epi8(v128 a, v128 i, [NoAlias] ref v128 result, [NoAlias] ref v128 mask)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 bitZero = cmpeq_epi8(and_si128(a, i), setzero_si128());
                    result = ternarylogic_si128(bitZero, blsi_epi8(mask), result, TernaryOperation.OxAE);
                    mask = blsr_epi8(mask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi8(v128 a, v128 mask, byte elements = 16)
            {
                static bool ContinueLoop(v128 mask, byte elements = 16)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return notalltrue_epi128<byte>(cmpeq_epi8(mask, setzero_si128()), elements);
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 result = ZERO;
                    v128 i = set1_epi8(1);

                    if (Sse4_1.IsSse41Supported)
                    {
                        mask = zeromissing_epi8(mask, elements);
                    }
                        
                    while (ContinueLoop(mask, elements))
                    {
                        LOOP_pdep_epi8(a, i, ref result, ref mask);
                        i = add_epi8(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi8x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return notalltrue_epi128<byte>(cmpeq_epi8(mask, setzero_si128()));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    r0 = setzero_si128();
                    r1 = setzero_si128();
                    v128 i = set1_epi8(1);

                    while (ContinueLoop(mask0, mask1))
                    {
                        LOOP_pdep_epi8(a0, i, ref r0, ref mask0);
                        LOOP_pdep_epi8(a1, i, ref r1, ref mask1);
                        i = add_epi8(i, i);
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP_pdep_epi16(v128 a, v128 i, [NoAlias] ref v128 result, [NoAlias] ref v128 mask)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 bitZero = cmpeq_epi16(and_si128(a, i), setzero_si128());
                    result = ternarylogic_si128(bitZero, blsi_epi16(mask), result, TernaryOperation.OxAE);
                    mask = blsr_epi16(mask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi16(v128 a, v128 mask, byte elements = 8)
            {
                static bool ContinueLoop(v128 mask, byte elements = 8)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return notalltrue_epi128<short>(cmpeq_epi16(mask, setzero_si128()), elements);
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 result = ZERO;
                    v128 i = set1_epi16(1);

                    if (Sse4_1.IsSse41Supported)
                    {
                        mask = zeromissing_epi16(mask, elements);
                    }
                    
                    while (ContinueLoop(mask, elements))
                    {
                        LOOP_pdep_epi16(a, i, ref result, ref mask);
                        i = add_epi16(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi16x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return notalltrue_epi128<short>(cmpeq_epi16(mask, setzero_si128()));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    r0 = setzero_si128();
                    r1 = setzero_si128();
                    v128 i = set1_epi16(1);

                    while (ContinueLoop(mask0, mask1))
                    {
                        LOOP_pdep_epi16(a0, i, ref r0, ref mask0);
                        LOOP_pdep_epi16(a1, i, ref r1, ref mask1);
                        i = add_epi16(i, i);
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP_pdep_epi32(v128 a, v128 i, [NoAlias] ref v128 result, [NoAlias] ref v128 mask)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 bitZero = cmpeq_epi32(and_si128(a, i), setzero_si128());
                    result = ternarylogic_si128(bitZero, blsi_epi32(mask), result, TernaryOperation.OxAE);
                    mask = blsr_epi32(mask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi32(v128 a, v128 mask, byte elements = 4)
            {
                static bool ContinueLoop(v128 mask, byte elements = 4)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return notalltrue_epi128<int>(cmpeq_epi32(mask, setzero_si128()), elements);
                    }
                    else throw new IllegalInstructionException();
                }


                if (Bmi2.IsBmi2Supported)
                {
                    if (elements == 2)
                    {
                        return new v128(Bmi2.pdep_u32(a.UInt0, mask.UInt0), Bmi2.pdep_u32(a.UInt1, mask.UInt1), 0, 0);
                    }
                }
                if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 result = ZERO;
                    v128 i = set1_epi32(1);

                    if (Sse4_1.IsSse41Supported)
                    {
                        mask = zeromissing_epi32(mask, elements);
                    }
                    
                    while (ContinueLoop(mask, elements))
                    {
                        LOOP_pdep_epi32(a, i, ref result, ref mask);
                        i = add_epi32(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi32x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return notalltrue_epi128<int>(cmpeq_epi32(mask, setzero_si128()));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    r0 = setzero_si128();
                    r1 = setzero_si128();
                    v128 i = set1_epi32(1);

                    while (ContinueLoop(mask0, mask1))
                    {
                        LOOP_pdep_epi32(a0, i, ref r0, ref mask0);
                        LOOP_pdep_epi32(a1, i, ref r1, ref mask1);
                        i = add_epi32(i, i);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void LOOP_pdep_epi64(v128 a, v128 i, [NoAlias] ref v128 result, [NoAlias] ref v128 mask)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 bitZero = cmpeq_epi64(and_si128(a, i), setzero_si128());
                    result = ternarylogic_si128(bitZero, blsi_epi64(mask), result, TernaryOperation.OxAE);
                    mask = blsr_epi64(mask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pdep_epi64(v128 a, v128 mask)
            {
                static bool ContinueLoop(v128 mask)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        return notalltrue_epi128<long>(cmpeq_epi64(mask, setzero_si128()));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Bmi2.IsBmi2Supported)
                {
                    return new v128(Bmi2.pdep_u64(a.ULong0, mask.ULong0), Bmi2.pdep_u64(a.ULong1, mask.ULong1));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();

                    v128 result = ZERO;
                    v128 i = set1_epi64x(1);

                    while (ContinueLoop(mask))
                    {
                        LOOP_pdep_epi64(a, i, ref result, ref mask);
                        i = add_epi64(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void pdep_epi64x2(v128 a0, v128 a1, v128 mask0, v128 mask1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 mask0, v128 mask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return testz_si128(mask, mask) == 0;
                    }
                    else if (Architecture.IsSIMDSupported)
                    {
                        v128 mask = or_si128(mask0, mask1);

                        return notalltrue_epi128<long>(cmpeq_epi64(mask, setzero_si128()));
                    }
                    else throw new IllegalInstructionException();
                }


                if (Architecture.IsSIMDSupported)
                {
                    r0 = setzero_si128();
                    r1 = setzero_si128();
                    v128 i = set1_epi64x(1);

                    while (ContinueLoop(mask0, mask1))
                    {
                        LOOP_pdep_epi64(a0, i, ref r0, ref mask0);
                        LOOP_pdep_epi64(a1, i, ref r1, ref mask1);
                        i = add_epi64(i, i);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi8(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;
                    v256 i = mm256_set1_epi8(1);

                    while (Avx.mm256_testz_si256(mask, mask) == 0)
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, i), ZERO);
                        result = mm256_ternarylogic_si256(bitZero, mm256_blsi_epi8(mask), result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi8(mask);
                        i = Avx2.mm256_add_epi8(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi16(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;
                    v256 i = mm256_set1_epi16(1);

                    while (Avx.mm256_testz_si256(mask, mask) == 0)
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, i), ZERO);
                        result = mm256_ternarylogic_si256(bitZero, mm256_blsi_epi16(mask), result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi16(mask);
                        i = Avx2.mm256_add_epi16(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi32(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;
                    v256 i = mm256_set1_epi32(1);

                    while (Avx.mm256_testz_si256(mask, mask) == 0)
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, i), ZERO);
                        result = mm256_ternarylogic_si256(bitZero, mm256_blsi_epi32(mask), result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi32(mask);
                        i = Avx2.mm256_add_epi32(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pdep_epi64(v256 a, v256 mask, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 ZERO = Avx.mm256_setzero_si256();

                    v256 result = ZERO;
                    v256 i = mm256_set1_epi64x(1);

                    mask = mm256_zeromissing_epi64(mask, elements);

                    while (Avx.mm256_testz_si256(mask, mask) == 0)
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, i), ZERO);
                        result = mm256_ternarylogic_si256(bitZero, mm256_blsi_epi64(mask), result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi64(mask);
                        i = Avx2.mm256_add_epi64(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_depositparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_depositparallel((UInt128)x, (UInt128)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_depositparallel(UInt128 x, UInt128 mask)
        {
            UInt128 result = 0;

            for (UInt128 i = 1; mask != 0; i += i)
            {
                if ((x & i) != 0)
                {
                    result |= bits_extractlowest(mask);
                }

                mask = bits_resetlowest(mask);
            }

            return result;
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_depositparallel(byte x, byte mask)
        {
            return (byte)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_depositparallel(byte2 x, byte2 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 2);
            }
            else
            {
                return new byte2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_depositparallel(byte3 x, byte3 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 3);
            }
            else
            {
                return new byte3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_depositparallel(byte4 x, byte4 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 4);
            }
            else
            {
                return new byte4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_depositparallel(byte8 x, byte8 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 8);
            }
            else
            {
                return new byte8(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_depositparallel(byte16 x, byte16 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi8(x, mask, 16);
            }
            else
            {
                return new byte16(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7), bits_depositparallel(x.x8, mask.x8), bits_depositparallel(x.x9, mask.x9), bits_depositparallel(x.x10, mask.x10), bits_depositparallel(x.x11, mask.x11), bits_depositparallel(x.x12, mask.x12), bits_depositparallel(x.x13, mask.x13), bits_depositparallel(x.x14, mask.x14), bits_depositparallel(x.x15, mask.x15));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_depositparallel(byte32 x, byte32 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi8(x, mask);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.pdep_epi8x2(x.v16_0, x.v16_16, mask.v16_0, mask.v16_16, out v128 lo, out v128 hi);

                return new byte32(lo, hi);
            }
            else
            {
                return new byte32(bits_depositparallel(x.v16_0, mask.v16_0), bits_depositparallel(x.v16_16, mask.v16_16));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_depositparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_depositparallel((byte)x, (byte)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_depositparallel(sbyte2 x, sbyte2 mask)
        {
            return (sbyte2)bits_depositparallel((byte2)x, (byte2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_depositparallel(sbyte3 x, sbyte3 mask)
        {
            return (sbyte3)bits_depositparallel((byte3)x, (byte3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_depositparallel(sbyte4 x, sbyte4 mask)
        {
            return (sbyte4)bits_depositparallel((byte4)x, (byte4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_depositparallel(sbyte8 x, sbyte8 mask)
        {
            return (sbyte8)bits_depositparallel((byte8)x, (byte8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_depositparallel(sbyte16 x, sbyte16 mask)
        {
            return (sbyte16)bits_depositparallel((byte16)x, (byte16)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_depositparallel(sbyte32 x, sbyte32 mask)
        {
            return (sbyte32)bits_depositparallel((byte32)x, (byte32)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_depositparallel(ushort x, ushort mask)
        {
            return (ushort)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_depositparallel(ushort2 x, ushort2 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 2);
            }
            else
            {
                return new ushort2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_depositparallel(ushort3 x, ushort3 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 3);
            }
            else
            {
                return new ushort3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_depositparallel(ushort4 x, ushort4 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 4);
            }
            else
            {
                return new ushort4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_depositparallel(ushort8 x, ushort8 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi16(x, mask, 8);
            }
            else
            {
                return new ushort8(bits_depositparallel(x.x0, mask.x0), bits_depositparallel(x.x1, mask.x1), bits_depositparallel(x.x2, mask.x2), bits_depositparallel(x.x3, mask.x3), bits_depositparallel(x.x4, mask.x4), bits_depositparallel(x.x5, mask.x5), bits_depositparallel(x.x6, mask.x6), bits_depositparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_depositparallel(ushort16 x, ushort16 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi16(x, mask);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.pdep_epi16x2(x.v8_0, x.v8_8, mask.v8_0, mask.v8_8, out v128 lo, out v128 hi);

                return new ushort16(lo, hi);
            }
            else
            {
                return new ushort16(bits_depositparallel(x.v8_0, mask.v8_0), bits_depositparallel(x.v8_8, mask.v8_8));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_depositparallel(short x, short mask)
        {
            return (short)bits_depositparallel((ushort)x, (ushort)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_depositparallel(short2 x, short2 mask)
        {
            return (short2)bits_depositparallel((ushort2)x, (ushort2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_depositparallel(short3 x, short3 mask)
        {
            return (short3)bits_depositparallel((ushort3)x, (ushort3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_depositparallel(short4 x, short4 mask)
        {
            return (short4)bits_depositparallel((ushort4)x, (ushort4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_depositparallel(short8 x, short8 mask)
        {
            return (short8)bits_depositparallel((ushort8)x, (ushort8)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_depositparallel(short16 x, short16 mask)
        {
            return (short16)bits_depositparallel((ushort16)x, (ushort16)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_depositparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_depositparallel(uint2 x, uint2 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 2));
            }
            else
            {
                return new uint2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_depositparallel(uint3 x, uint3 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 3));
            }
            else
            {
                return new uint3(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_depositparallel(uint4 x, uint4 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.pdep_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 4));
            }
            else
            {
                return new uint4(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y), bits_depositparallel(x.z, mask.z), bits_depositparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_depositparallel(uint8 x, uint8 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi32(x, mask);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.pdep_epi32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(mask.v4_0), RegisterConversion.ToV128(mask.v4_4), out v128 lo, out v128 hi);

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                return new uint8(bits_depositparallel(x.v4_0, mask.v4_0), bits_depositparallel(x.v4_4, mask.v4_4));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_depositparallel(int x, int mask)
        {
            return (int)bits_depositparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_depositparallel(int2 x, int2 mask)
        {
            return (int2)bits_depositparallel((uint2)x, (uint2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_depositparallel(int3 x, int3 mask)
        {
            return (int3)bits_depositparallel((uint3)x, (uint3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_depositparallel(int4 x, int4 mask)
        {
            return (int4)bits_depositparallel((uint4)x, (uint4)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_depositparallel(int8 x, int8 mask)
        {
            return (int8)bits_depositparallel((uint8)x, (uint8)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_depositparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pdep_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & i) != 0)
                    {
                        result |= bits_extractlowest(mask);
                    }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_depositparallel(ulong2 x, ulong2 mask)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.pdep_epi64(x, mask);
            }
            else
            {
                return new ulong2(bits_depositparallel(x.x, mask.x), bits_depositparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_depositparallel(ulong3 x, ulong3 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi64(x, mask, 3);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.pdep_epi64x2(x.xy, x.zz, mask.xy, mask.zz, out v128 lo, out v128 hi);

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                return new ulong3(bits_depositparallel(x.xy, mask.xy), bits_depositparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_depositparallel(ulong4 x, ulong4 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pdep_epi64(x, mask, 4);
            }
            else if (Architecture.IsSIMDSupported)
            {
                Xse.pdep_epi64x2(x.xy, x.zw, mask.xy, mask.zw, out v128 lo, out v128 hi);

                return new ulong4(lo, hi);
            }
            else
            {
                return new ulong4(bits_depositparallel(x.xy, mask.xy), bits_depositparallel(x.zw, mask.zw));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_depositparallel(long x, long mask)
        {
            return (long)bits_depositparallel((ulong)x, (ulong)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_depositparallel(long2 x, long2 mask)
        {
            return (long2)bits_depositparallel((ulong2)x, (ulong2)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_depositparallel(long3 x, long3 mask)
        {
            return (long3)bits_depositparallel((ulong3)x, (ulong3)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, an equal amount of contiguous low bits in <paramref name="x"/> is extracted. Then, each of the extracted bits is placed at the corresponding bit position of each 1-bit in <paramref name="mask"/> in LSB order, with each remaining bit set to 0.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_depositparallel(long4 x, long4 mask)
        {
            return (long4)bits_depositparallel((ulong4)x, (ulong4)mask);
        }
    }
}