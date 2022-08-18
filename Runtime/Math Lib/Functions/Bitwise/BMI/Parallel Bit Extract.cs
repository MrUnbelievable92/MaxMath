using System.Runtime.CompilerServices;
using Unity.Mathematics;
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
            public static v128 pext_epi8(v128 a, v128 mask, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result = Sse2.setzero_si128();
                    v128 i = Sse2.set1_epi8(1);

                    while (notalltrue_epi128<byte>(Sse2.cmpeq_epi8(mask, Sse2.setzero_si128()), elements))
                    {
                        v128 bitZero = Sse2.cmpeq_epi8(Sse2.and_si128(a, blsi_epi8(mask)), Sse2.setzero_si128());
                        result = ternarylogic_si128(bitZero, i, result, TernaryOperation.OxAE);

                        mask = blsr_epi8(mask);
                        i = Sse2.add_epi8(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi16(v128 a, v128 mask, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result = Sse2.setzero_si128();
                    v128 i = Sse2.set1_epi16(1);

                    while (notalltrue_epi128<short>(Sse2.cmpeq_epi16(mask, Sse2.setzero_si128()), elements))
                    {
                        v128 bitZero = Sse2.cmpeq_epi16(Sse2.and_si128(a, blsi_epi16(mask)), Sse2.setzero_si128());
                        result = ternarylogic_si128(bitZero, i, result, TernaryOperation.OxAE);

                        mask = blsr_epi16(mask);
                        i = Sse2.add_epi16(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi32(v128 a, v128 mask, byte elements = 4)
            {
                if (Bmi2.IsBmi2Supported && elements == 2)
                {
                    return new v128(Bmi2.pext_u32(a.UInt0, mask.UInt0), Bmi2.pext_u32(a.UInt1, mask.UInt1), 0, 0);
                }
                if (Sse2.IsSse2Supported)
                {
                    v128 result = Sse2.setzero_si128();
                    v128 i = Sse2.set1_epi32(1);

                    while (notalltrue_epi128<int>(Sse2.cmpeq_epi32(mask, Sse2.setzero_si128()), elements))
                    {
                        v128 bitZero = Sse2.cmpeq_epi32(Sse2.and_si128(a, blsi_epi32(mask)), Sse2.setzero_si128());
                        result = ternarylogic_si128(bitZero, i, result, TernaryOperation.OxAE);

                        mask = blsr_epi32(mask);
                        i = Sse2.add_epi32(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pext_epi64(v128 a, v128 mask)
            {
                if (Bmi2.IsBmi2Supported)
                {
                    return new v128(Bmi2.pext_u64(a.ULong0, mask.ULong0), Bmi2.pext_u64(a.ULong1, mask.ULong1));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 result = Sse2.setzero_si128();
                    v128 i = Sse2.set1_epi64x(1);

                    while (notalltrue_epi128<long>(cmpeq_epi64(mask, Sse2.setzero_si128()), 2))
                    {
                        v128 bitZero = cmpeq_epi64(Sse2.and_si128(a, blsi_epi64(mask)), Sse2.setzero_si128());
                        result = ternarylogic_si128(bitZero, i, result, TernaryOperation.OxAE);

                        mask = blsr_epi64(mask);
                        i = Sse2.add_epi64(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi8(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx.mm256_setzero_si256();
                    v256 i = Avx.mm256_set1_epi8(1);

                    while (mm256_notalltrue_epi256<byte>(Avx2.mm256_cmpeq_epi8(mask, Avx.mm256_setzero_si256()), 32))
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, mm256_blsi_epi8(mask)), Avx.mm256_setzero_si256());
                        result = mm256_ternarylogic_si256(bitZero, i, result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi8(mask);
                        i = Avx2.mm256_add_epi8(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi16(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx.mm256_setzero_si256();
                    v256 i = Avx.mm256_set1_epi16(1);

                    while (mm256_notalltrue_epi256<short>(Avx2.mm256_cmpeq_epi16(mask, Avx.mm256_setzero_si256()), 16))
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, mm256_blsi_epi16(mask)), Avx.mm256_setzero_si256());
                        result = mm256_ternarylogic_si256(bitZero, i, result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi16(mask);
                        i = Avx2.mm256_add_epi16(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi32(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx.mm256_setzero_si256();
                    v256 i = Avx.mm256_set1_epi32(1);

                    while (mm256_notalltrue_epi256<int>(Avx2.mm256_cmpeq_epi32(mask, Avx.mm256_setzero_si256()), 8))
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, mm256_blsi_epi32(mask)), Avx.mm256_setzero_si256());
                        result = mm256_ternarylogic_si256(bitZero, i, result, TernaryOperation.OxAE);

                        mask = mm256_blsr_epi32(mask);
                        i = Avx2.mm256_add_epi32(i, i);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pext_epi64(v256 a, v256 mask)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx.mm256_setzero_si256();
                    v256 i = Avx.mm256_set1_epi64x(1);

                    while (mm256_notalltrue_epi256<long>(Avx2.mm256_cmpeq_epi64(mask, Avx.mm256_setzero_si256()), 4))
                    {
                        v256 bitZero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, mm256_blsi_epi64(mask)), Avx.mm256_setzero_si256());
                        result = mm256_ternarylogic_si256(bitZero, i, result, TernaryOperation.OxAE);

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
        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 bits_extractparallel(Int128 x, Int128 mask)
        {
            return (Int128)bits_extractparallel((UInt128)x, (UInt128)mask);
        }

        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 bits_extractparallel(UInt128 x, UInt128 mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                ulong lo = Bmi2.pext_u64(x.lo64, mask.lo64);
                ulong hi = Bmi2.pext_u64(x.hi64, mask.hi64);
                int maskloCount = math.countbits(mask.lo64);

                return lo | ((UInt128)hi << maskloCount);
            }
            else
            {
                UInt128 result = 0;

                for (UInt128 i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    {
                        result |= i;
                    }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte bits_extractparallel(byte x, byte mask)
        {
            return (byte)bits_extractparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 bits_extractparallel(byte2 x, byte2 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi8(x, mask, 2);
            }
            else
            {
                return new byte2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 bits_extractparallel(byte3 x, byte3 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi8(x, mask, 3);
            }
            else
            {
                return new byte3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 bits_extractparallel(byte4 x, byte4 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi8(x, mask, 4);
            }
            else
            {
                return new byte4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 bits_extractparallel(byte8 x, byte8 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi8(x, mask, 8);
            }
            else
            {
                return new byte8(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 bits_extractparallel(byte16 x, byte16 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi8(x, mask, 16);
            }
            else
            {
                return new byte16(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7), bits_extractparallel(x.x8, mask.x8), bits_extractparallel(x.x9, mask.x9), bits_extractparallel(x.x10, mask.x10), bits_extractparallel(x.x11, mask.x11), bits_extractparallel(x.x12, mask.x12), bits_extractparallel(x.x13, mask.x13), bits_extractparallel(x.x14, mask.x14), bits_extractparallel(x.x15, mask.x15));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 bits_extractparallel(byte32 x, byte32 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi8(x, mask);
            }
            else
            {
                return new byte32(bits_extractparallel(x.v16_0, mask.v16_0), bits_extractparallel(x.v16_16, mask.v16_16));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte bits_extractparallel(sbyte x, sbyte mask)
        {
            return (sbyte)bits_extractparallel((byte)x, (byte)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 bits_extractparallel(sbyte2 x, sbyte2 mask)
        {
            return (sbyte2)bits_extractparallel((byte2)x, (byte2)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 bits_extractparallel(sbyte3 x, sbyte3 mask)
        {
            return (sbyte3)bits_extractparallel((byte3)x, (byte3)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 bits_extractparallel(sbyte4 x, sbyte4 mask)
        {
            return (sbyte4)bits_extractparallel((byte4)x, (byte4)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 bits_extractparallel(sbyte8 x, sbyte8 mask)
        {
            return (sbyte8)bits_extractparallel((byte8)x, (byte8)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 bits_extractparallel(sbyte16 x, sbyte16 mask)
        {
            return (sbyte16)bits_extractparallel((byte16)x, (byte16)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 bits_extractparallel(sbyte32 x, sbyte32 mask)
        {
            return (sbyte32)bits_extractparallel((byte32)x, (byte32)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort bits_extractparallel(ushort x, ushort mask)
        {
            return (ushort)bits_extractparallel((uint)x, (uint)mask);
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 bits_extractparallel(ushort2 x, ushort2 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi16(x, mask, 2);
            }
            else
            {
                return new ushort2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 bits_extractparallel(ushort3 x, ushort3 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi16(x, mask, 3);
            }
            else
            {
                return new ushort3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 bits_extractparallel(ushort4 x, ushort4 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi16(x, mask, 4);
            }
            else
            {
                return new ushort4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 bits_extractparallel(ushort8 x, ushort8 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi16(x, mask, 8);
            }
            else
            {
                return new ushort8(bits_extractparallel(x.x0, mask.x0), bits_extractparallel(x.x1, mask.x1), bits_extractparallel(x.x2, mask.x2), bits_extractparallel(x.x3, mask.x3), bits_extractparallel(x.x4, mask.x4), bits_extractparallel(x.x5, mask.x5), bits_extractparallel(x.x6, mask.x6), bits_extractparallel(x.x7, mask.x7));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 bits_extractparallel(ushort16 x, ushort16 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi16(x, mask);
            }
            else
            {
                return new ushort16(bits_extractparallel(x.v8_0, mask.v8_0), bits_extractparallel(x.v8_8, mask.v8_8));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short bits_extractparallel(short x, short mask)
        {
            return (short)bits_extractparallel((ushort)x, (ushort)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 bits_extractparallel(short2 x, short2 mask)
        {
            return (short2)bits_extractparallel((ushort2)x, (ushort2)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 bits_extractparallel(short3 x, short3 mask)
        {
            return (short3)bits_extractparallel((ushort3)x, (ushort3)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 bits_extractparallel(short4 x, short4 mask)
        {
            return (short4)bits_extractparallel((ushort4)x, (ushort4)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 bits_extractparallel(short8 x, short8 mask)
        {
            return (short8)bits_extractparallel((ushort8)x, (ushort8)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 bits_extractparallel(short16 x, short16 mask)
        {
            return (short16)bits_extractparallel((ushort16)x, (ushort16)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint bits_extractparallel(uint x, uint mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u32(x, mask);
            }
            else
            {
                uint result = 0;

                for (uint i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    {
                        result |= i;
                    }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 bits_extractparallel(uint2 x, uint2 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint2>(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 2));
            }
            else
            {
                return new uint2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 bits_extractparallel(uint3 x, uint3 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint3>(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 3));
            }
            else
            {
                return new uint3(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 bits_extractparallel(uint4 x, uint4 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<uint4>(Xse.pext_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(mask), 4));
            }
            else
            {
                return new uint4(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y), bits_extractparallel(x.z, mask.z), bits_extractparallel(x.w, mask.w));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 bits_extractparallel(uint8 x, uint8 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi32(x, mask);
            }
            else
            {
                return new uint8(bits_extractparallel(x.v4_0, mask.v4_0), bits_extractparallel(x.v4_4, mask.v4_4));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int bits_extractparallel(int x, int mask)
        {
            return (int)bits_extractparallel((uint)x, (uint)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 bits_extractparallel(int2 x, int2 mask)
        {
            return (int2)bits_extractparallel((uint2)x, (uint2)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 bits_extractparallel(int3 x, int3 mask)
        {
            return (int3)bits_extractparallel((uint3)x, (uint3)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 bits_extractparallel(int4 x, int4 mask)
        {
            return (int4)bits_extractparallel((uint4)x, (uint4)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 bits_extractparallel(int8 x, int8 mask)
        {
            return (int8)bits_extractparallel((uint8)x, (uint8)mask);
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong bits_extractparallel(ulong x, ulong mask)
        {
            if (Bmi2.IsBmi2Supported)
            {
                return Bmi2.pext_u64(x, mask);
            }
            else
            {
                ulong result = 0;

                for (ulong i = 1; mask != 0; i += i)
                {
                    if ((x & bits_extractlowest(mask)) != 0)
                    { 
                        result |= i;
                    }

                    mask = bits_resetlowest(mask);
                }

                return result;
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 bits_extractparallel(ulong2 x, ulong2 mask)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pext_epi64(x, mask);
            }
            else
            {
                return new ulong2(bits_extractparallel(x.x, mask.x), bits_extractparallel(x.y, mask.y));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 bits_extractparallel(ulong3 x, ulong3 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi64(x, mask);
            }
            else
            {
                return new ulong3(bits_extractparallel(x.xy, mask.xy), bits_extractparallel(x.z, mask.z));
            }
        }

        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 bits_extractparallel(ulong4 x, ulong4 mask)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pext_epi64(x, mask);
            }
            else
            {
                return new ulong4(bits_extractparallel(x.xy, mask.xy), bits_extractparallel(x.zw, mask.zw));
            }
        }


        /// <summary>       For each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long bits_extractparallel(long x, long mask)
        {
            return (long)bits_extractparallel((ulong)x, (ulong)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 bits_extractparallel(long2 x, long2 mask)
        {
            return (long2)bits_extractparallel((ulong2)x, (ulong2)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 bits_extractparallel(long3 x, long3 mask)
        {
            return (long3)bits_extractparallel((ulong3)x, (ulong3)mask);
        }
        
        /// <summary>       For each component pair, for each 1-bit in <paramref name="mask"/>, the corresponding bit in <paramref name="x"/> is extracted. Then, a contiguous string of the extracted bits is placed in the low bits of the result, with each remaining bit set to 0.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 bits_extractparallel(long4 x, long4 mask)
        {
            return (long4)bits_extractparallel((ulong4)x, (ulong4)mask);
        }
    }
}