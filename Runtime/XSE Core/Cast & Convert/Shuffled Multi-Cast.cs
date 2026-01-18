using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi8_epi16(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                hi = srai_epi16(unpackhi_epi8(a, a), 8);
                v128 lo = cvtepi8_epi16(a);

                constexpr.ASSUME(lo.SShort0 == a.SByte0);
                constexpr.ASSUME(lo.SShort1 == a.SByte1);
                constexpr.ASSUME(lo.SShort2 == a.SByte2);
                constexpr.ASSUME(lo.SShort3 == a.SByte3);
                constexpr.ASSUME(lo.SShort4 == a.SByte4);
                constexpr.ASSUME(lo.SShort5 == a.SByte5);
                constexpr.ASSUME(lo.SShort6 == a.SByte6);
                constexpr.ASSUME(lo.SShort7 == a.SByte7);
                constexpr.ASSUME(hi.SShort0 == a.SByte8);
                constexpr.ASSUME(hi.SShort1 == a.SByte9);
                constexpr.ASSUME(hi.SShort2 == a.SByte10);
                constexpr.ASSUME(hi.SShort3 == a.SByte11);
                constexpr.ASSUME(hi.SShort4 == a.SByte12);
                constexpr.ASSUME(hi.SShort5 == a.SByte13);
                constexpr.ASSUME(hi.SShort6 == a.SByte14);
                constexpr.ASSUME(hi.SShort7 == a.SByte15);
                constexpr.ASSUME_RANGE_EPI16(lo, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI16(hi, sbyte.MinValue, sbyte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_epi32(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 negativeMask = srai_epi16(a, 15);
                hi = unpackhi_epi16(a, negativeMask);

                v128 lo = cvtepi16_epi32(a);

                constexpr.ASSUME(lo.SInt0 == a.SShort0);
                constexpr.ASSUME(lo.SInt1 == a.SShort1);
                constexpr.ASSUME(lo.SInt2 == a.SShort2);
                constexpr.ASSUME(lo.SInt3 == a.SShort3);
                constexpr.ASSUME(hi.SInt0 == a.SShort4);
                constexpr.ASSUME(hi.SInt1 == a.SShort5);
                constexpr.ASSUME(hi.SInt2 == a.SShort6);
                constexpr.ASSUME(hi.SInt3 == a.SShort7);
                constexpr.ASSUME_RANGE_EPI32(lo, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(hi, short.MinValue, short.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_epi64(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 negativeMask = srai_epi32(a, 31);
                hi = unpackhi_epi32(a, negativeMask);

                v128 lo = cvtepi32_epi64(a);

                constexpr.ASSUME(lo.SLong0 == a.SInt0);
                constexpr.ASSUME(lo.SLong1 == a.SInt1);
                constexpr.ASSUME(hi.SLong0 == a.SInt2);
                constexpr.ASSUME(hi.SLong1 == a.SInt3);
                constexpr.ASSUME_RANGE_EPI64(lo, int.MinValue, int.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(hi, int.MinValue, int.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu8_epi16(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                hi = unpackhi_epi8(a, setzero_si128());

                v128 lo = cvtepu8_epi16(a);

                constexpr.ASSUME(lo.UShort0 == a.Byte0);
                constexpr.ASSUME(lo.UShort1 == a.Byte1);
                constexpr.ASSUME(lo.UShort2 == a.Byte2);
                constexpr.ASSUME(lo.UShort3 == a.Byte3);
                constexpr.ASSUME(lo.UShort4 == a.Byte4);
                constexpr.ASSUME(lo.UShort5 == a.Byte5);
                constexpr.ASSUME(lo.UShort6 == a.Byte6);
                constexpr.ASSUME(lo.UShort7 == a.Byte7);
                constexpr.ASSUME(hi.UShort0 == a.Byte8);
                constexpr.ASSUME(hi.UShort1 == a.Byte9);
                constexpr.ASSUME(hi.UShort2 == a.Byte10);
                constexpr.ASSUME(hi.UShort3 == a.Byte11);
                constexpr.ASSUME(hi.UShort4 == a.Byte12);
                constexpr.ASSUME(hi.UShort5 == a.Byte13);
                constexpr.ASSUME(hi.UShort6 == a.Byte14);
                constexpr.ASSUME(hi.UShort7 == a.Byte15);
                constexpr.ASSUME_LE_EPU16(lo, byte.MaxValue);
                constexpr.ASSUME_LE_EPU16(hi, byte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu16_epi32(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                hi = unpackhi_epi16(a, setzero_si128());

                v128 lo = cvtepu16_epi32(a);

                constexpr.ASSUME(lo.UInt0 == a.UShort0);
                constexpr.ASSUME(lo.UInt1 == a.UShort1);
                constexpr.ASSUME(lo.UInt2 == a.UShort2);
                constexpr.ASSUME(lo.UInt3 == a.UShort3);
                constexpr.ASSUME(hi.UInt0 == a.UShort4);
                constexpr.ASSUME(hi.UInt1 == a.UShort5);
                constexpr.ASSUME(hi.UInt2 == a.UShort6);
                constexpr.ASSUME(hi.UInt3 == a.UShort7);
                constexpr.ASSUME_LE_EPU32(lo, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU32(hi, ushort.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu32_epi64(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                hi = unpackhi_epi32(a, setzero_si128());

                v128 lo = cvtepu32_epi64(a);

                constexpr.ASSUME(lo.ULong0 == a.UInt0);
                constexpr.ASSUME(lo.ULong1 == a.UInt1);
                constexpr.ASSUME(hi.ULong0 == a.UInt2);
                constexpr.ASSUME(hi.ULong1 == a.UInt3);
                constexpr.ASSUME_LE_EPU64(lo, uint.MaxValue);
                constexpr.ASSUME_LE_EPU64(hi, uint.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu16_ps(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 EXP_MASK = set1_epi16(0x4B00);
                v128 MAGIC = set1_ps(LIMIT_PRECISE_U32_F32);

                hi      = sub_ps(unpackhi_epi16(a, EXP_MASK), MAGIC);
                v128 lo = sub_ps(unpacklo_epi16(a, EXP_MASK), MAGIC);

                constexpr.ASSUME(lo.Float0 == a.UShort0);
                constexpr.ASSUME(lo.Float1 == a.UShort1);
                constexpr.ASSUME(lo.Float2 == a.UShort2);
                constexpr.ASSUME(lo.Float3 == a.UShort3);
                constexpr.ASSUME(hi.Float0 == a.UShort4);
                constexpr.ASSUME(hi.Float1 == a.UShort5);
                constexpr.ASSUME(hi.Float2 == a.UShort6);
                constexpr.ASSUME(hi.Float3 == a.UShort7);
                constexpr.ASSUME_RANGE_PS(lo, 0f, ushort.MaxValue);
                constexpr.ASSUME_RANGE_PS(hi, 0f, ushort.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_ps(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo = cvt2x2epi16_epi32(a, out hi);

                hi = cvtepi32_ps(hi);
                lo = cvtepi32_ps(lo);

                constexpr.ASSUME(lo.Float0 == a.SShort0);
                constexpr.ASSUME(lo.Float1 == a.SShort1);
                constexpr.ASSUME(lo.Float2 == a.SShort2);
                constexpr.ASSUME(lo.Float3 == a.SShort3);
                constexpr.ASSUME(hi.Float0 == a.SShort4);
                constexpr.ASSUME(hi.Float1 == a.SShort5);
                constexpr.ASSUME(hi.Float2 == a.SShort6);
                constexpr.ASSUME(hi.Float3 == a.SShort7);
                constexpr.ASSUME_RANGE_PS(lo, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_PS(hi, short.MinValue, short.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu32_pd(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 EXP_MASK = set1_epi32(0x4330_0000);
                v128 MAGIC = set1_pd(LIMIT_PRECISE_U64_F64);

                v128 lo;
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, 4))
                {
                    lo = cvtepi32_pd(a);
                }
                else
                {
                    lo = sub_pd(unpacklo_epi32(a, EXP_MASK), MAGIC);
                }

                hi = sub_pd(unpackhi_epi32(a, EXP_MASK), MAGIC);

                constexpr.ASSUME(lo.Double0 == a.UInt0);
                constexpr.ASSUME(lo.Double1 == a.UInt1);
                constexpr.ASSUME(hi.Double0 == a.UInt2);
                constexpr.ASSUME(hi.Double1 == a.UInt3);
                constexpr.ASSUME_RANGE_PD(lo, 0d, uint.MaxValue);
                constexpr.ASSUME_RANGE_PD(hi, 0d, uint.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_pd(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                hi      = cvtepi32_pd(bsrli_si128(a, 2 * sizeof(int)));
                v128 lo = cvtepi32_pd(a);

                constexpr.ASSUME(lo.Double0 == a.SInt0);
                constexpr.ASSUME(lo.Double1 == a.SInt1);
                constexpr.ASSUME(hi.Double0 == a.SInt2);
                constexpr.ASSUME(hi.Double1 == a.SInt3);
                constexpr.ASSUME_RANGE_PD(lo, int.MinValue, int.MaxValue);
                constexpr.ASSUME_RANGE_PD(hi, int.MinValue, int.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_epi8(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_LE_EPU16(lo, byte.MaxValue) && constexpr.ALL_LE_EPU16(hi, byte.MaxValue))
                {
                    result = packus_epi16(lo, hi);
                }
                else
                {
                    v128 MASK = set1_epi16(0x00FF);
                    result = packus_epi16(and_si128(lo, MASK), and_si128(hi, MASK));
                }

                constexpr.ASSUME(result.SByte0  == (sbyte)lo.SShort0);
                constexpr.ASSUME(result.SByte1  == (sbyte)lo.SShort1);
                constexpr.ASSUME(result.SByte2  == (sbyte)lo.SShort2);
                constexpr.ASSUME(result.SByte3  == (sbyte)lo.SShort3);
                constexpr.ASSUME(result.SByte4  == (sbyte)lo.SShort4);
                constexpr.ASSUME(result.SByte5  == (sbyte)lo.SShort5);
                constexpr.ASSUME(result.SByte6  == (sbyte)lo.SShort6);
                constexpr.ASSUME(result.SByte7  == (sbyte)lo.SShort7);
                constexpr.ASSUME(result.SByte8  == (sbyte)hi.SShort0);
                constexpr.ASSUME(result.SByte9  == (sbyte)hi.SShort1);
                constexpr.ASSUME(result.SByte10 == (sbyte)hi.SShort2);
                constexpr.ASSUME(result.SByte11 == (sbyte)hi.SShort3);
                constexpr.ASSUME(result.SByte12 == (sbyte)hi.SShort4);
                constexpr.ASSUME(result.SByte13 == (sbyte)hi.SShort5);
                constexpr.ASSUME(result.SByte14 == (sbyte)hi.SShort6);
                constexpr.ASSUME(result.SByte15 == (sbyte)hi.SShort7);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_epi8(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    result = unpacklo_epi32(cvtepi32_epi8(lo, 4), cvtepi32_epi8(hi, 4));
                }
                else
                {
                    lo = and_si128(lo, set1_epi32(byte.MaxValue));
                    hi = and_si128(hi, set1_epi32(byte.MaxValue));

                    result = packs_epi32(lo, hi);
                    result = packus_epi16(result, result);
                }

                constexpr.ASSUME(result.Byte0 == (byte)lo.SInt0);
                constexpr.ASSUME(result.Byte1 == (byte)lo.SInt1);
                constexpr.ASSUME(result.Byte2 == (byte)lo.SInt2);
                constexpr.ASSUME(result.Byte3 == (byte)lo.SInt3);
                constexpr.ASSUME(result.Byte4 == (byte)hi.SInt0);
                constexpr.ASSUME(result.Byte5 == (byte)hi.SInt1);
                constexpr.ASSUME(result.Byte6 == (byte)hi.SInt2);
                constexpr.ASSUME(result.Byte7 == (byte)hi.SInt3);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_epi16(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result;
                if (constexpr.ALL_LE_EPU32(lo, (uint)short.MaxValue) && constexpr.ALL_LE_EPU32(hi, (uint)short.MaxValue))
                {
                    result = packs_epi32(lo, hi);
                }
                else if (Sse4_1.IsSse41Supported)
                {
                    if (constexpr.ALL_LE_EPU32(lo, ushort.MaxValue) && constexpr.ALL_LE_EPU32(hi, ushort.MaxValue))
                    {
                        result = packus_epi32(lo, hi);
                    }
                    else
                    {
                        v128 MASK = set1_epi32(0x0000_FFFF);
                        result = packus_epi32(and_si128(lo, MASK), and_si128(hi, MASK));
                    }
                }
                else
                {
                    result = unpacklo_epi64(cvtepi32_epi16(lo), cvtepi32_epi16(hi));
                }

                constexpr.ASSUME(result.SShort0 == (short)lo.SInt0);
                constexpr.ASSUME(result.SShort1 == (short)lo.SInt1);
                constexpr.ASSUME(result.SShort2 == (short)lo.SInt2);
                constexpr.ASSUME(result.SShort3 == (short)lo.SInt3);
                constexpr.ASSUME(result.SShort4 == (short)hi.SInt0);
                constexpr.ASSUME(result.SShort5 == (short)hi.SInt1);
                constexpr.ASSUME(result.SShort6 == (short)hi.SInt2);
                constexpr.ASSUME(result.SShort7 == (short)hi.SInt3);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtt2x2ps_epu16(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return cvt2x2epi32_epi16(cvttps_epi32(lo), cvttps_epi32(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvt2x2ps_epu16(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MAGIC = set1_ps(LIMIT_PRECISE_U32_F32);
                v128 result = cvt2x2epi32_epi16(add_ps(lo, MAGIC), add_ps(hi, MAGIC));

                constexpr.ASSUME(result.UShort0 == (ushort)lo.Float0);
                constexpr.ASSUME(result.UShort1 == (ushort)lo.Float1);
                constexpr.ASSUME(result.UShort2 == (ushort)lo.Float2);
                constexpr.ASSUME(result.UShort3 == (ushort)lo.Float3);
                constexpr.ASSUME(result.UShort4 == (ushort)hi.Float0);
                constexpr.ASSUME(result.UShort5 == (ushort)hi.Float1);
                constexpr.ASSUME(result.UShort6 == (ushort)hi.Float2);
                constexpr.ASSUME(result.UShort7 == (ushort)hi.Float3);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi64_epi32(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = shuffle_ps(lo, hi, Sse.SHUFFLE(2, 0, 2, 0));

                constexpr.ASSUME(result.SInt0 == (int)lo.SLong0);
                constexpr.ASSUME(result.SInt1 == (int)lo.SLong1);
                constexpr.ASSUME(result.SInt2 == (int)hi.SLong0);
                constexpr.ASSUME(result.SInt3 == (int)hi.SLong1);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtt2x2pd_epi32(v128 lo, v128 hi, bool nonZero = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi64(cvttpd_epi32(lo), cvttpd_epi32(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvt2x2pd_epu32(v128 lo, v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 MAGIC = set1_pd(LIMIT_PRECISE_U64_F64);
                v128 result = cvt2x2epi64_epi32(add_pd(lo, MAGIC), add_pd(hi, MAGIC));

                constexpr.ASSUME(result.UInt0 == (uint)lo.Double0);
                constexpr.ASSUME(result.UInt1 == (uint)lo.Double1);
                constexpr.ASSUME(result.UInt2 == (uint)hi.Double0);
                constexpr.ASSUME(result.UInt3 == (uint)hi.Double1);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvtt2x2pd_epu32(v128 lo, v128 hi, bool nonZero = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = cvt2x2epi64_epi32(cvttpd_epu64(lo, nonZero: nonZero), cvttpd_epu64(hi, nonZero: nonZero));

                constexpr.ASSUME(result.UInt0 == (uint)lo.Double0);
                constexpr.ASSUME(result.UInt1 == (uint)lo.Double1);
                constexpr.ASSUME(result.UInt2 == (uint)hi.Double0);
                constexpr.ASSUME(result.UInt3 == (uint)hi.Double1);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 | 16 17 18 19 20 21 22 23 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 | 24 25 26 27 28 29 30 31 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi8_epi16(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                     hi = Avx2.mm256_unpackhi_epi8(a, a);
                v256 lo = Avx2.mm256_unpacklo_epi8(a, a);

                hi = Avx2.mm256_srai_epi16(hi, 8);
                lo = Avx2.mm256_srai_epi16(lo, 8);

                constexpr.ASSUME(lo.SShort0  == a.SByte0);
                constexpr.ASSUME(lo.SShort1  == a.SByte1);
                constexpr.ASSUME(lo.SShort2  == a.SByte2);
                constexpr.ASSUME(lo.SShort3  == a.SByte3);
                constexpr.ASSUME(lo.SShort4  == a.SByte4);
                constexpr.ASSUME(lo.SShort5  == a.SByte5);
                constexpr.ASSUME(lo.SShort6  == a.SByte6);
                constexpr.ASSUME(lo.SShort7  == a.SByte7);
                constexpr.ASSUME(lo.SShort8  == a.SByte16);
                constexpr.ASSUME(lo.SShort9  == a.SByte17);
                constexpr.ASSUME(lo.SShort10 == a.SByte18);
                constexpr.ASSUME(lo.SShort11 == a.SByte19);
                constexpr.ASSUME(lo.SShort12 == a.SByte20);
                constexpr.ASSUME(lo.SShort13 == a.SByte21);
                constexpr.ASSUME(lo.SShort14 == a.SByte22);
                constexpr.ASSUME(lo.SShort15 == a.SByte23);
                constexpr.ASSUME(hi.SShort0  == a.SByte8);
                constexpr.ASSUME(hi.SShort1  == a.SByte9);
                constexpr.ASSUME(hi.SShort2  == a.SByte10);
                constexpr.ASSUME(hi.SShort3  == a.SByte11);
                constexpr.ASSUME(hi.SShort4  == a.SByte12);
                constexpr.ASSUME(hi.SShort5  == a.SByte13);
                constexpr.ASSUME(hi.SShort6  == a.SByte14);
                constexpr.ASSUME(hi.SShort7  == a.SByte15);
                constexpr.ASSUME(hi.SShort8  == a.SByte24);
                constexpr.ASSUME(hi.SShort9  == a.SByte25);
                constexpr.ASSUME(hi.SShort10 == a.SByte26);
                constexpr.ASSUME(hi.SShort11 == a.SByte27);
                constexpr.ASSUME(hi.SShort12 == a.SByte28);
                constexpr.ASSUME(hi.SShort13 == a.SByte29);
                constexpr.ASSUME(hi.SShort14 == a.SByte30);
                constexpr.ASSUME(hi.SShort15 == a.SByte31);
                constexpr.ASSUME_RANGE_EPI16(lo, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI16(hi, sbyte.MinValue, sbyte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi16_epi32(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 negativeMask = Avx2.mm256_srai_epi16(a, 15);

                hi      = Avx2.mm256_unpackhi_epi16(a, negativeMask);
                v256 lo = Avx2.mm256_unpacklo_epi16(a, negativeMask);

                constexpr.ASSUME(lo.SInt0 == a.SShort0);
                constexpr.ASSUME(lo.SInt1 == a.SShort1);
                constexpr.ASSUME(lo.SInt2 == a.SShort2);
                constexpr.ASSUME(lo.SInt3 == a.SShort3);
                constexpr.ASSUME(lo.SInt4 == a.SShort8);
                constexpr.ASSUME(lo.SInt5 == a.SShort9);
                constexpr.ASSUME(lo.SInt6 == a.SShort10);
                constexpr.ASSUME(lo.SInt7 == a.SShort11);
                constexpr.ASSUME(hi.SInt0 == a.SShort4);
                constexpr.ASSUME(hi.SInt1 == a.SShort5);
                constexpr.ASSUME(hi.SInt2 == a.SShort6);
                constexpr.ASSUME(hi.SInt3 == a.SShort7);
                constexpr.ASSUME(hi.SInt4 == a.SShort12);
                constexpr.ASSUME(hi.SInt5 == a.SShort13);
                constexpr.ASSUME(hi.SInt6 == a.SShort14);
                constexpr.ASSUME(hi.SInt7 == a.SShort15);
                constexpr.ASSUME_RANGE_EPI32(lo, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(hi, short.MinValue, short.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi32_epi64(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 negativeMask = Avx2.mm256_srai_epi32(a, 31);

                hi      = Avx2.mm256_unpackhi_epi32(a, negativeMask);
                v256 lo = Avx2.mm256_unpacklo_epi32(a, negativeMask);

                constexpr.ASSUME(lo.SLong0 == a.SInt0);
                constexpr.ASSUME(lo.SLong1 == a.SInt1);
                constexpr.ASSUME(lo.SLong2 == a.SInt4);
                constexpr.ASSUME(lo.SLong3 == a.SInt5);
                constexpr.ASSUME(hi.SLong0 == a.SInt2);
                constexpr.ASSUME(hi.SLong1 == a.SInt3);
                constexpr.ASSUME(hi.SLong2 == a.SInt6);
                constexpr.ASSUME(hi.SLong3 == a.SInt7);
                constexpr.ASSUME_RANGE_EPI64(lo, int.MinValue, int.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(hi, int.MinValue, int.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 | 16 17 18 19 20 21 22 23 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 | 24 25 26 27 28 29 30 31 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu8_epi16(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi      = Avx2.mm256_unpackhi_epi8(a, Avx.mm256_setzero_si256());
                v256 lo = Avx2.mm256_unpacklo_epi8(a, Avx.mm256_setzero_si256());

                constexpr.ASSUME(lo.UShort0  == a.Byte0);
                constexpr.ASSUME(lo.UShort1  == a.Byte1);
                constexpr.ASSUME(lo.UShort2  == a.Byte2);
                constexpr.ASSUME(lo.UShort3  == a.Byte3);
                constexpr.ASSUME(lo.UShort4  == a.Byte4);
                constexpr.ASSUME(lo.UShort5  == a.Byte5);
                constexpr.ASSUME(lo.UShort6  == a.Byte6);
                constexpr.ASSUME(lo.UShort7  == a.Byte7);
                constexpr.ASSUME(lo.UShort8  == a.Byte16);
                constexpr.ASSUME(lo.UShort9  == a.Byte17);
                constexpr.ASSUME(lo.UShort10 == a.Byte18);
                constexpr.ASSUME(lo.UShort11 == a.Byte19);
                constexpr.ASSUME(lo.UShort12 == a.Byte20);
                constexpr.ASSUME(lo.UShort13 == a.Byte21);
                constexpr.ASSUME(lo.UShort14 == a.Byte22);
                constexpr.ASSUME(lo.UShort15 == a.Byte23);
                constexpr.ASSUME(hi.UShort0  == a.Byte8);
                constexpr.ASSUME(hi.UShort1  == a.Byte9);
                constexpr.ASSUME(hi.UShort2  == a.Byte10);
                constexpr.ASSUME(hi.UShort3  == a.Byte11);
                constexpr.ASSUME(hi.UShort4  == a.Byte12);
                constexpr.ASSUME(hi.UShort5  == a.Byte13);
                constexpr.ASSUME(hi.UShort6  == a.Byte14);
                constexpr.ASSUME(hi.UShort7  == a.Byte15);
                constexpr.ASSUME(hi.UShort8  == a.Byte24);
                constexpr.ASSUME(hi.UShort9  == a.Byte25);
                constexpr.ASSUME(hi.UShort10 == a.Byte26);
                constexpr.ASSUME(hi.UShort11 == a.Byte27);
                constexpr.ASSUME(hi.UShort12 == a.Byte28);
                constexpr.ASSUME(hi.UShort13 == a.Byte29);
                constexpr.ASSUME(hi.UShort14 == a.Byte30);
                constexpr.ASSUME(hi.UShort15 == a.Byte31);
                constexpr.ASSUME_LE_EPU16(lo, byte.MaxValue);
                constexpr.ASSUME_LE_EPU16(hi, byte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu16_epi32(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi      = Avx2.mm256_unpackhi_epi16(a, Avx.mm256_setzero_si256());
                v256 lo = Avx2.mm256_unpacklo_epi16(a, Avx.mm256_setzero_si256());

                constexpr.ASSUME(lo.UInt0 == a.UShort0);
                constexpr.ASSUME(lo.UInt1 == a.UShort1);
                constexpr.ASSUME(lo.UInt2 == a.UShort2);
                constexpr.ASSUME(lo.UInt3 == a.UShort3);
                constexpr.ASSUME(lo.UInt4 == a.UShort8);
                constexpr.ASSUME(lo.UInt5 == a.UShort9);
                constexpr.ASSUME(lo.UInt6 == a.UShort10);
                constexpr.ASSUME(lo.UInt7 == a.UShort11);
                constexpr.ASSUME(hi.UInt0 == a.UShort4);
                constexpr.ASSUME(hi.UInt1 == a.UShort5);
                constexpr.ASSUME(hi.UInt2 == a.UShort6);
                constexpr.ASSUME(hi.UInt3 == a.UShort7);
                constexpr.ASSUME(hi.UInt4 == a.UShort12);
                constexpr.ASSUME(hi.UInt5 == a.UShort13);
                constexpr.ASSUME(hi.UInt6 == a.UShort14);
                constexpr.ASSUME(hi.UInt7 == a.UShort15);
                constexpr.ASSUME_LE_EPU32(lo, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU32(hi, ushort.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu32_epi64(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi      = Avx2.mm256_unpackhi_epi32(a, Avx.mm256_setzero_si256());
                v256 lo = Avx2.mm256_unpacklo_epi32(a, Avx.mm256_setzero_si256());

                constexpr.ASSUME(lo.ULong0 == a.UInt0);
                constexpr.ASSUME(lo.ULong1 == a.UInt1);
                constexpr.ASSUME(lo.ULong2 == a.UInt4);
                constexpr.ASSUME(lo.ULong3 == a.UInt5);
                constexpr.ASSUME(hi.ULong0 == a.UInt2);
                constexpr.ASSUME(hi.ULong1 == a.UInt3);
                constexpr.ASSUME(hi.ULong2 == a.UInt6);
                constexpr.ASSUME(hi.ULong3 == a.UInt7);
                constexpr.ASSUME_LE_EPU64(lo, uint.MaxValue);
                constexpr.ASSUME_LE_EPU64(hi, uint.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu16_ps(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 EXP_MASK = mm256_set1_epi16(0x4B00);
                v256 MAGIC = mm256_set1_ps(LIMIT_PRECISE_U32_F32);

                hi      = Avx.mm256_sub_ps(Avx2.mm256_unpackhi_epi16(a, EXP_MASK), MAGIC);
                v256 lo = Avx.mm256_sub_ps(Avx2.mm256_unpacklo_epi16(a, EXP_MASK), MAGIC);

                constexpr.ASSUME(lo.Float0 == a.UShort0);
                constexpr.ASSUME(lo.Float1 == a.UShort1);
                constexpr.ASSUME(lo.Float2 == a.UShort2);
                constexpr.ASSUME(lo.Float3 == a.UShort3);
                constexpr.ASSUME(lo.Float4 == a.UShort8);
                constexpr.ASSUME(lo.Float5 == a.UShort9);
                constexpr.ASSUME(lo.Float6 == a.UShort10);
                constexpr.ASSUME(lo.Float7 == a.UShort11);
                constexpr.ASSUME(hi.Float0 == a.UShort4);
                constexpr.ASSUME(hi.Float1 == a.UShort5);
                constexpr.ASSUME(hi.Float2 == a.UShort6);
                constexpr.ASSUME(hi.Float3 == a.UShort7);
                constexpr.ASSUME(hi.Float4 == a.UShort12);
                constexpr.ASSUME(hi.Float5 == a.UShort13);
                constexpr.ASSUME(hi.Float6 == a.UShort14);
                constexpr.ASSUME(hi.Float7 == a.UShort15);
                constexpr.ASSUME_RANGE_PS(lo, 0f, ushort.MaxValue);
                constexpr.ASSUME_RANGE_PS(hi, 0f, ushort.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi16_ps(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = mm256_cvt2x2epi16_epi32(a, out hi);

                hi = Avx.mm256_cvtepi32_ps(hi);
                lo = Avx.mm256_cvtepi32_ps(lo);

                constexpr.ASSUME(lo.Float0 == a.SShort0);
                constexpr.ASSUME(lo.Float1 == a.SShort1);
                constexpr.ASSUME(lo.Float2 == a.SShort2);
                constexpr.ASSUME(lo.Float3 == a.SShort3);
                constexpr.ASSUME(lo.Float4 == a.SShort8);
                constexpr.ASSUME(lo.Float5 == a.SShort9);
                constexpr.ASSUME(lo.Float6 == a.SShort10);
                constexpr.ASSUME(lo.Float7 == a.SShort11);
                constexpr.ASSUME(hi.Float0 == a.SShort4);
                constexpr.ASSUME(hi.Float1 == a.SShort5);
                constexpr.ASSUME(hi.Float2 == a.SShort6);
                constexpr.ASSUME(hi.Float3 == a.SShort7);
                constexpr.ASSUME(hi.Float4 == a.SShort12);
                constexpr.ASSUME(hi.Float5 == a.SShort13);
                constexpr.ASSUME(hi.Float6 == a.SShort14);
                constexpr.ASSUME(hi.Float7 == a.SShort15);
                constexpr.ASSUME_RANGE_PS(lo, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_PS(hi, short.MinValue, short.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu32_pd(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 EXP_MASK = mm256_set1_epi32(0x4330_0000);
                v256 MAGIC = mm256_set1_pd(LIMIT_PRECISE_U64_F64);

                hi      = Avx.mm256_sub_pd(Avx2.mm256_unpackhi_epi32(a, EXP_MASK), MAGIC);
                v256 lo = Avx.mm256_sub_pd(Avx2.mm256_unpacklo_epi32(a, EXP_MASK), MAGIC);

                constexpr.ASSUME(lo.Double0 == a.UInt0);
                constexpr.ASSUME(lo.Double1 == a.UInt1);
                constexpr.ASSUME(lo.Double2 == a.UInt4);
                constexpr.ASSUME(lo.Double3 == a.UInt5);
                constexpr.ASSUME(hi.Double0 == a.UInt2);
                constexpr.ASSUME(hi.Double1 == a.UInt3);
                constexpr.ASSUME(hi.Double2 == a.UInt6);
                constexpr.ASSUME(hi.Double3 == a.UInt7);
                constexpr.ASSUME_RANGE_PD(lo, 0d, uint.MaxValue);
                constexpr.ASSUME_RANGE_PD(hi, 0d, uint.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi32_pd(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = mm256_cvt2x2epi32_epi64(a, out hi);
                lo = mm256_usfcvtepi64_pd(lo);
                hi = mm256_usfcvtepi64_pd(hi);

                constexpr.ASSUME(lo.Double0 == a.SInt0);
                constexpr.ASSUME(lo.Double1 == a.SInt1);
                constexpr.ASSUME(lo.Double2 == a.SInt4);
                constexpr.ASSUME(lo.Double3 == a.SInt5);
                constexpr.ASSUME(hi.Double0 == a.SInt2);
                constexpr.ASSUME(hi.Double1 == a.SInt3);
                constexpr.ASSUME(hi.Double2 == a.SInt6);
                constexpr.ASSUME(hi.Double3 == a.SInt7);
                constexpr.ASSUME_RANGE_PD(lo, int.MinValue, int.MaxValue);
                constexpr.ASSUME_RANGE_PD(hi, int.MinValue, int.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi16_epi8(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_LE_EPU16(lo, byte.MaxValue) && constexpr.ALL_LE_EPU16(hi, byte.MaxValue))
                {
                    result = Avx2.mm256_packus_epi16(lo, hi);
                }
                else
                {
                    v256 MASK = mm256_set1_epi16(0x00FF);
                    result = Avx2.mm256_packus_epi16(Avx2.mm256_and_si256(lo, MASK), Avx2.mm256_and_si256(hi, MASK));
                }

                constexpr.ASSUME(result.Byte0  == (byte)lo.UShort0);
                constexpr.ASSUME(result.Byte1  == (byte)lo.UShort1);
                constexpr.ASSUME(result.Byte2  == (byte)lo.UShort2);
                constexpr.ASSUME(result.Byte3  == (byte)lo.UShort3);
                constexpr.ASSUME(result.Byte4  == (byte)lo.UShort4);
                constexpr.ASSUME(result.Byte5  == (byte)lo.UShort5);
                constexpr.ASSUME(result.Byte6  == (byte)lo.UShort6);
                constexpr.ASSUME(result.Byte7  == (byte)lo.UShort7);
                constexpr.ASSUME(result.Byte8  == (byte)hi.UShort0);
                constexpr.ASSUME(result.Byte9  == (byte)hi.UShort1);
                constexpr.ASSUME(result.Byte10 == (byte)hi.UShort2);
                constexpr.ASSUME(result.Byte11 == (byte)hi.UShort3);
                constexpr.ASSUME(result.Byte12 == (byte)hi.UShort4);
                constexpr.ASSUME(result.Byte13 == (byte)hi.UShort5);
                constexpr.ASSUME(result.Byte14 == (byte)hi.UShort6);
                constexpr.ASSUME(result.Byte15 == (byte)hi.UShort7);
                constexpr.ASSUME(result.Byte16 == (byte)lo.UShort8);
                constexpr.ASSUME(result.Byte17 == (byte)lo.UShort9);
                constexpr.ASSUME(result.Byte18 == (byte)lo.UShort10);
                constexpr.ASSUME(result.Byte19 == (byte)lo.UShort11);
                constexpr.ASSUME(result.Byte20 == (byte)lo.UShort12);
                constexpr.ASSUME(result.Byte21 == (byte)lo.UShort13);
                constexpr.ASSUME(result.Byte22 == (byte)lo.UShort14);
                constexpr.ASSUME(result.Byte23 == (byte)lo.UShort15);
                constexpr.ASSUME(result.Byte24 == (byte)hi.UShort8);
                constexpr.ASSUME(result.Byte25 == (byte)hi.UShort9);
                constexpr.ASSUME(result.Byte26 == (byte)hi.UShort10);
                constexpr.ASSUME(result.Byte27 == (byte)hi.UShort11);
                constexpr.ASSUME(result.Byte28 == (byte)hi.UShort12);
                constexpr.ASSUME(result.Byte29 == (byte)hi.UShort13);
                constexpr.ASSUME(result.Byte30 == (byte)hi.UShort14);
                constexpr.ASSUME(result.Byte31 == (byte)hi.UShort15);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi32_epi16(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result;
                if (constexpr.ALL_LE_EPU32(lo, ushort.MaxValue) && constexpr.ALL_LE_EPU32(hi, ushort.MaxValue))
                {
                    result = Avx2.mm256_packus_epi32(lo, hi);
                }
                else
                {
                    v256 MASK = mm256_set1_epi32(0x0000_FFFF);
                    result = Avx2.mm256_packus_epi32(Avx2.mm256_and_si256(lo, MASK), Avx2.mm256_and_si256(hi, MASK));
                }

                constexpr.ASSUME(result.UShort0  == (ushort)lo.UInt0);
                constexpr.ASSUME(result.UShort1  == (ushort)lo.UInt1);
                constexpr.ASSUME(result.UShort2  == (ushort)lo.UInt2);
                constexpr.ASSUME(result.UShort3  == (ushort)lo.UInt3);
                constexpr.ASSUME(result.UShort4  == (ushort)hi.UInt0);
                constexpr.ASSUME(result.UShort5  == (ushort)hi.UInt1);
                constexpr.ASSUME(result.UShort6  == (ushort)hi.UInt2);
                constexpr.ASSUME(result.UShort7  == (ushort)hi.UInt3);
                constexpr.ASSUME(result.UShort8  == (ushort)lo.UInt4);
                constexpr.ASSUME(result.UShort9  == (ushort)lo.UInt5);
                constexpr.ASSUME(result.UShort10 == (ushort)lo.UInt6);
                constexpr.ASSUME(result.UShort11 == (ushort)lo.UInt7);
                constexpr.ASSUME(result.UShort12 == (ushort)hi.UInt4);
                constexpr.ASSUME(result.UShort13 == (ushort)hi.UInt5);
                constexpr.ASSUME(result.UShort14 == (ushort)hi.UInt6);
                constexpr.ASSUME(result.UShort15 == (ushort)hi.UInt7);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi64_epi32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(2, 0, 2, 0));

                constexpr.ASSUME(result.UInt0 == (uint)lo.ULong0);
                constexpr.ASSUME(result.UInt1 == (uint)lo.ULong1);
                constexpr.ASSUME(result.UInt2 == (uint)hi.ULong0);
                constexpr.ASSUME(result.UInt3 == (uint)hi.ULong1);
                constexpr.ASSUME(result.UInt4 == (uint)lo.ULong2);
                constexpr.ASSUME(result.UInt5 == (uint)lo.ULong3);
                constexpr.ASSUME(result.UInt6 == (uint)hi.ULong2);
                constexpr.ASSUME(result.UInt7 == (uint)hi.ULong3);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtt2x2ps_epu16(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvt2x2epi32_epi16(Avx.mm256_cvttps_epi32(lo), Avx.mm256_cvttps_epi32(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2ps_epu16(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = mm256_set1_ps(LIMIT_PRECISE_U32_F32);
                v256 result = mm256_cvt2x2epi32_epi16(Avx.mm256_add_ps(lo, MAGIC), Avx.mm256_add_ps(hi, MAGIC));

                constexpr.ASSUME(result.UShort0  == (ushort)lo.Float0);
                constexpr.ASSUME(result.UShort1  == (ushort)lo.Float1);
                constexpr.ASSUME(result.UShort2  == (ushort)lo.Float2);
                constexpr.ASSUME(result.UShort3  == (ushort)lo.Float3);
                constexpr.ASSUME(result.UShort4  == (ushort)hi.Float0);
                constexpr.ASSUME(result.UShort5  == (ushort)hi.Float1);
                constexpr.ASSUME(result.UShort6  == (ushort)hi.Float2);
                constexpr.ASSUME(result.UShort7  == (ushort)hi.Float3);
                constexpr.ASSUME(result.UShort8  == (ushort)lo.Float4);
                constexpr.ASSUME(result.UShort9  == (ushort)lo.Float5);
                constexpr.ASSUME(result.UShort10 == (ushort)lo.Float6);
                constexpr.ASSUME(result.UShort11 == (ushort)lo.Float7);
                constexpr.ASSUME(result.UShort12 == (ushort)hi.Float4);
                constexpr.ASSUME(result.UShort13 == (ushort)hi.Float5);
                constexpr.ASSUME(result.UShort14 == (ushort)hi.Float6);
                constexpr.ASSUME(result.UShort15 == (ushort)hi.Float7);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2pd_epu32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = mm256_set1_pd(LIMIT_PRECISE_U64_F64);
                v256 result = mm256_cvt2x2epi64_epi32(Avx.mm256_add_pd(lo, MAGIC), Avx.mm256_add_pd(hi, MAGIC));

                constexpr.ASSUME(result.UInt0 == (uint)lo.Double0);
                constexpr.ASSUME(result.UInt1 == (uint)lo.Double1);
                constexpr.ASSUME(result.UInt2 == (uint)hi.Double0);
                constexpr.ASSUME(result.UInt3 == (uint)hi.Double1);
                constexpr.ASSUME(result.UInt4 == (uint)lo.Double2);
                constexpr.ASSUME(result.UInt5 == (uint)lo.Double3);
                constexpr.ASSUME(result.UInt6 == (uint)hi.Double2);
                constexpr.ASSUME(result.UInt7 == (uint)hi.Double3);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtt2x2pd_epu32(v256 lo, v256 hi, bool positive = false, bool nonZero = false)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = mm256_cvt2x2epi64_epi32(mm256_cvttpd_epu64(lo, elements: 4, nonZero: nonZero), mm256_cvttpd_epu64(hi, elements: 4, nonZero: nonZero));

                constexpr.ASSUME(result.UInt0 == (uint)lo.Double0);
                constexpr.ASSUME(result.UInt1 == (uint)lo.Double1);
                constexpr.ASSUME(result.UInt2 == (uint)hi.Double0);
                constexpr.ASSUME(result.UInt3 == (uint)hi.Double1);
                constexpr.ASSUME(result.UInt4 == (uint)lo.Double2);
                constexpr.ASSUME(result.UInt5 == (uint)lo.Double3);
                constexpr.ASSUME(result.UInt6 == (uint)hi.Double2);
                constexpr.ASSUME(result.UInt7 == (uint)hi.Double3);

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2pd_epi32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = mm256_cvt2x2epi64_epi32(mm256_usfcvtpd_epi64(lo), mm256_usfcvtpd_epi64(hi));

                constexpr.ASSUME(result.SInt0 == (int)lo.Double0);
                constexpr.ASSUME(result.SInt1 == (int)lo.Double1);
                constexpr.ASSUME(result.SInt2 == (int)hi.Double0);
                constexpr.ASSUME(result.SInt3 == (int)hi.Double1);
                constexpr.ASSUME(result.SInt4 == (int)lo.Double2);
                constexpr.ASSUME(result.SInt5 == (int)lo.Double3);
                constexpr.ASSUME(result.SInt6 == (int)hi.Double2);
                constexpr.ASSUME(result.SInt7 == (int)hi.Double3);

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvtt2x2pd_epi32(v256 lo, v256 hi, bool positive = false, bool nonZero = false, bool adjustSign = true)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 result = mm256_cvt2x2epi64_epi32(mm256_cvttpd_epi64(lo, elements: 4, positive: positive, nonZero: nonZero, adjustSign: adjustSign), mm256_cvttpd_epi64(hi, elements: 4, positive: positive, nonZero: nonZero, adjustSign: adjustSign));

                constexpr.ASSUME(result.SInt0 == (int)(adjustSign ? lo.Double0 : math.abs(lo.Double0)));
                constexpr.ASSUME(result.SInt1 == (int)(adjustSign ? lo.Double1 : math.abs(lo.Double1)));
                constexpr.ASSUME(result.SInt2 == (int)(adjustSign ? hi.Double0 : math.abs(hi.Double0)));
                constexpr.ASSUME(result.SInt3 == (int)(adjustSign ? hi.Double1 : math.abs(hi.Double1)));
                constexpr.ASSUME(result.SInt4 == (int)(adjustSign ? lo.Double2 : math.abs(lo.Double2)));
                constexpr.ASSUME(result.SInt5 == (int)(adjustSign ? lo.Double3 : math.abs(lo.Double3)));
                constexpr.ASSUME(result.SInt6 == (int)(adjustSign ? hi.Double2 : math.abs(hi.Double2)));
                constexpr.ASSUME(result.SInt7 == (int)(adjustSign ? hi.Double3 : math.abs(hi.Double3)));

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu8_epi32(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    hi = shuffle_epi8(a, new v128(4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1));
                    lo = cvtepu8_epi32(a);
                }
                else
                {
                    lo = cvt2x2epu16_epi32(cvtepu8_epi16(a), out hi);
                }

                constexpr.ASSUME(lo.UInt0 == a.Byte0);
                constexpr.ASSUME(lo.UInt1 == a.Byte1);
                constexpr.ASSUME(lo.UInt2 == a.Byte2);
                constexpr.ASSUME(lo.UInt3 == a.Byte3);
                constexpr.ASSUME(hi.UInt0 == a.Byte4);
                constexpr.ASSUME(hi.UInt1 == a.Byte5);
                constexpr.ASSUME(hi.UInt2 == a.Byte6);
                constexpr.ASSUME(hi.UInt3 == a.Byte7);
                constexpr.ASSUME_LE_EPU32(lo, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(hi, byte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt4x4epu8_epi32(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    r0 = cvtepu8_epi32(a);
                    r1 = shuffle_epi8(a, new v128( 4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1));
                    r2 = shuffle_epi8(a, new v128( 8, -1, -1, -1,    9, -1, -1, -1,   10, -1, -1, -1,   11, -1, -1, -1));
                    r3 = shuffle_epi8(a, new v128(12, -1, -1, -1,   13, -1, -1, -1,   14, -1, -1, -1,   15, -1, -1, -1));
                }
                else
                {
                    v128 lo16 = cvt2x2epu8_epi16(a, out v128 hi16);
                    r0 = cvt2x2epu16_epi32(lo16, out r1);
                    r2 = cvt2x2epu16_epi32(hi16, out r3);
                }

                constexpr.ASSUME(r0.UInt0 == a.Byte0);
                constexpr.ASSUME(r0.UInt1 == a.Byte1);
                constexpr.ASSUME(r0.UInt2 == a.Byte2);
                constexpr.ASSUME(r0.UInt3 == a.Byte3);
                constexpr.ASSUME(r1.UInt0 == a.Byte4);
                constexpr.ASSUME(r1.UInt1 == a.Byte5);
                constexpr.ASSUME(r1.UInt2 == a.Byte6);
                constexpr.ASSUME(r1.UInt3 == a.Byte7);
                constexpr.ASSUME(r2.UInt0 == a.Byte8);
                constexpr.ASSUME(r2.UInt1 == a.Byte9);
                constexpr.ASSUME(r2.UInt2 == a.Byte10);
                constexpr.ASSUME(r2.UInt3 == a.Byte11);
                constexpr.ASSUME(r3.UInt0 == a.Byte12);
                constexpr.ASSUME(r3.UInt1 == a.Byte13);
                constexpr.ASSUME(r3.UInt2 == a.Byte14);
                constexpr.ASSUME(r3.UInt3 == a.Byte15);
                constexpr.ASSUME_LE_EPU32(r0, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r1, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r2, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r3, byte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi8_epi32(v128 a, out v128 hi)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 lo;
                if (Sse4_1.IsSse41Supported)
                {
                    hi = cvtepi8_epi32(bsrli_si128(a, 4 * sizeof(byte)));
                    lo = cvtepi8_epi32(a);
                }
                else
                {
                    lo = cvt2x2epi16_epi32(cvtepi8_epi16(a), out hi);
                }

                constexpr.ASSUME(lo.SInt0 == a.SByte0);
                constexpr.ASSUME(lo.SInt1 == a.SByte1);
                constexpr.ASSUME(lo.SInt2 == a.SByte2);
                constexpr.ASSUME(lo.SInt3 == a.SByte3);
                constexpr.ASSUME(hi.SInt0 == a.SByte4);
                constexpr.ASSUME(hi.SInt1 == a.SByte5);
                constexpr.ASSUME(hi.SInt2 == a.SByte6);
                constexpr.ASSUME(hi.SInt3 == a.SByte7);
                constexpr.ASSUME_RANGE_EPI32(lo, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(hi, sbyte.MinValue, sbyte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt4x4epi8_epi32(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    r0 = cvtepi8_epi32(a);
                    r1 = cvtepi8_epi32(srli_epi64(a,   4 * 8 * sizeof(byte)));
                    r2 = cvtepi8_epi32(bsrli_si128(a,  8 * sizeof(byte)));
                    r3 = cvtepi8_epi32(bsrli_si128(a, 12 * sizeof(byte)));
                }
                else
                {
                    v128 lo16 = cvt2x2epi8_epi16(a, out v128 hi16);
                    r0 = cvt2x2epi16_epi32(lo16, out r1);
                    r2 = cvt2x2epi16_epi32(hi16, out r3);
                }

                constexpr.ASSUME(r0.SInt0 == a.SByte0);
                constexpr.ASSUME(r0.SInt1 == a.SByte1);
                constexpr.ASSUME(r0.SInt2 == a.SByte2);
                constexpr.ASSUME(r0.SInt3 == a.SByte3);
                constexpr.ASSUME(r1.SInt0 == a.SByte4);
                constexpr.ASSUME(r1.SInt1 == a.SByte5);
                constexpr.ASSUME(r1.SInt2 == a.SByte6);
                constexpr.ASSUME(r1.SInt3 == a.SByte7);
                constexpr.ASSUME(r2.SInt0 == a.SByte8);
                constexpr.ASSUME(r2.SInt1 == a.SByte9);
                constexpr.ASSUME(r2.SInt2 == a.SByte10);
                constexpr.ASSUME(r2.SInt3 == a.SByte11);
                constexpr.ASSUME(r3.SInt0 == a.SByte12);
                constexpr.ASSUME(r3.SInt1 == a.SByte13);
                constexpr.ASSUME(r3.SInt2 == a.SByte14);
                constexpr.ASSUME(r3.SInt3 == a.SByte15);
                constexpr.ASSUME_RANGE_EPI32(r0, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r1, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r2, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r3, sbyte.MinValue, sbyte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt8x8epu8_epi64(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3, [NoAlias] out v128 r4, [NoAlias] out v128 r5, [NoAlias] out v128 r6, [NoAlias] out v128 r7)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    r0 = cvtepu8_epi64(a);
                    r1 = shuffle_epi8(a, new v128( 2, -1, -1, -1, -1, -1, -1, -1,   3, -1, -1, -1, -1, -1, -1, -1));
                    r2 = shuffle_epi8(a, new v128( 4, -1, -1, -1, -1, -1, -1, -1,   5, -1, -1, -1, -1, -1, -1, -1));
                    r3 = shuffle_epi8(a, new v128( 6, -1, -1, -1, -1, -1, -1, -1,   7, -1, -1, -1, -1, -1, -1, -1));
                    r4 = shuffle_epi8(a, new v128( 8, -1, -1, -1, -1, -1, -1, -1,   9, -1, -1, -1, -1, -1, -1, -1));
                    r5 = shuffle_epi8(a, new v128(10, -1, -1, -1, -1, -1, -1, -1,  11, -1, -1, -1, -1, -1, -1, -1));
                    r6 = shuffle_epi8(a, new v128(12, -1, -1, -1, -1, -1, -1, -1,  13, -1, -1, -1, -1, -1, -1, -1));
                    r7 = shuffle_epi8(a, new v128(14, -1, -1, -1, -1, -1, -1, -1,  15, -1, -1, -1, -1, -1, -1, -1));
                }
                else
                {
                    cvt4x4epu8_epi32(a, out v128 r32_0, out v128 r32_1, out v128 r32_2, out v128 r32_3);
                    r0 = cvt2x2epu32_epi64(r32_0, out r1);
                    r2 = cvt2x2epu32_epi64(r32_0, out r3);
                    r4 = cvt2x2epu32_epi64(r32_0, out r5);
                    r6 = cvt2x2epu32_epi64(r32_0, out r7);
                }

                constexpr.ASSUME(r0.ULong0 == a.Byte0);
                constexpr.ASSUME(r0.ULong1 == a.Byte1);
                constexpr.ASSUME(r1.ULong0 == a.Byte2);
                constexpr.ASSUME(r1.ULong1 == a.Byte3);
                constexpr.ASSUME(r2.ULong0 == a.Byte4);
                constexpr.ASSUME(r2.ULong1 == a.Byte5);
                constexpr.ASSUME(r3.ULong0 == a.Byte6);
                constexpr.ASSUME(r3.ULong1 == a.Byte7);
                constexpr.ASSUME(r4.ULong0 == a.Byte8);
                constexpr.ASSUME(r4.ULong1 == a.Byte9);
                constexpr.ASSUME(r5.ULong0 == a.Byte10);
                constexpr.ASSUME(r5.ULong1 == a.Byte11);
                constexpr.ASSUME(r6.ULong0 == a.Byte12);
                constexpr.ASSUME(r6.ULong1 == a.Byte13);
                constexpr.ASSUME(r7.ULong0 == a.Byte14);
                constexpr.ASSUME(r7.ULong1 == a.Byte15);
                constexpr.ASSUME_LE_EPU64(r0, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r1, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r2, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r3, byte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt8x8epi8_epi64(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3, [NoAlias] out v128 r4, [NoAlias] out v128 r5, [NoAlias] out v128 r6, [NoAlias] out v128 r7)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    r0 = cvtepi8_epi64(a);

                    if (Arm.Neon.IsNeonSupported)
                    {
                        r1 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1,  2,  -1, -1, -1, -1, -1, -1, -1,  3)), 56);
                        r2 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1,  4,  -1, -1, -1, -1, -1, -1, -1,  5)), 56);
                        r3 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1,  6,  -1, -1, -1, -1, -1, -1, -1,  7)), 56);
                        r4 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1,  8,  -1, -1, -1, -1, -1, -1, -1,  9)), 56);
                        r5 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1, 10,  -1, -1, -1, -1, -1, -1, -1, 11)), 56);
                        r6 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1, 12,  -1, -1, -1, -1, -1, -1, -1, 13)), 56);
                        r7 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, -1, 14,  -1, -1, -1, -1, -1, -1, -1, 15)), 56);
                    }
                    else
                    {
                        v128 a16lo = cvt2x2epi8_epi16(a, out v128 a16hi);

                        r1 = shuffle_epi8(a16lo, new v128( 4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7));
                        r2 = shuffle_epi8(a16lo, new v128( 8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11));
                        r3 = shuffle_epi8(a16lo, new v128(12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15));
                        r4 = shuffle_epi8(a16hi, new v128( 0,  1,  1,  1,  1,  1,  1,  1,   2,  3,  3,  3,  3,  3,  3,  3));
                        r5 = shuffle_epi8(a16hi, new v128( 4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7));
                        r6 = shuffle_epi8(a16hi, new v128( 8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11));
                        r7 = shuffle_epi8(a16hi, new v128(12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15));
                    }
                }
                else
                {
                    cvt4x4epi8_epi32(a, out v128 r32_0, out v128 r32_1, out v128 r32_2, out v128 r32_3);
                    r0 = cvt2x2epi32_epi64(r32_0, out r1);
                    r2 = cvt2x2epi32_epi64(r32_1, out r3);
                    r4 = cvt2x2epi32_epi64(r32_2, out r5);
                    r6 = cvt2x2epi32_epi64(r32_3, out r7);
                }

                constexpr.ASSUME(r0.SLong0 == a.SByte0);
                constexpr.ASSUME(r0.SLong1 == a.SByte1);
                constexpr.ASSUME(r1.SLong0 == a.SByte2);
                constexpr.ASSUME(r1.SLong1 == a.SByte3);
                constexpr.ASSUME(r2.SLong0 == a.SByte4);
                constexpr.ASSUME(r2.SLong1 == a.SByte5);
                constexpr.ASSUME(r3.SLong0 == a.SByte6);
                constexpr.ASSUME(r3.SLong1 == a.SByte7);
                constexpr.ASSUME(r4.SLong0 == a.SByte8);
                constexpr.ASSUME(r4.SLong1 == a.SByte9);
                constexpr.ASSUME(r5.SLong0 == a.SByte10);
                constexpr.ASSUME(r5.SLong1 == a.SByte11);
                constexpr.ASSUME(r6.SLong0 == a.SByte12);
                constexpr.ASSUME(r6.SLong1 == a.SByte13);
                constexpr.ASSUME(r7.SLong0 == a.SByte14);
                constexpr.ASSUME(r7.SLong1 == a.SByte15);
                constexpr.ASSUME_RANGE_EPI64(r0, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r1, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r2, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r3, sbyte.MinValue, sbyte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt4x4epu16_epi64(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    r0 = cvtepu16_epi64(a);
                    r1 = shuffle_epi8(a, new v128( 4,  5, -1, -1, -1, -1, -1, -1,   6,  7, -1, -1, -1, -1, -1, -1));
                    r2 = shuffle_epi8(a, new v128( 8,  9, -1, -1, -1, -1, -1, -1,  10, 11, -1, -1, -1, -1, -1, -1));
                    r3 = shuffle_epi8(a, new v128(12, 23, -1, -1, -1, -1, -1, -1,  14, 15, -1, -1, -1, -1, -1, -1));
                }
                else
                {
                    v128 lo32 = cvt2x2epu16_epi32(a, out v128 hi32);
                    r0 = cvt2x2epu32_epi64(lo32, out r1);
                    r2 = cvt2x2epu32_epi64(hi32, out r3);
                }

                constexpr.ASSUME(r0.ULong0 == a.UShort0);
                constexpr.ASSUME(r0.ULong1 == a.UShort1);
                constexpr.ASSUME(r1.ULong0 == a.UShort2);
                constexpr.ASSUME(r1.ULong1 == a.UShort3);
                constexpr.ASSUME(r2.ULong0 == a.UShort4);
                constexpr.ASSUME(r2.ULong1 == a.UShort5);
                constexpr.ASSUME(r3.ULong0 == a.UShort6);
                constexpr.ASSUME(r3.ULong1 == a.UShort7);
                constexpr.ASSUME_LE_EPU64(r0, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r1, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r2, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r3, ushort.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void cvt4x4epi16_epi64(v128 a, [NoAlias] out v128 r0, [NoAlias] out v128 r1, [NoAlias] out v128 r2, [NoAlias] out v128 r3)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    r0 = cvtepi16_epi64(a);

                    if (Arm.Neon.IsNeonSupported)
                    {
                        r1 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1,  4,  5,  -1, -1, -1, -1, -1, -1,  6,  7)), 48);
                        r2 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1,  8,  9,  -1, -1, -1, -1, -1, -1, 10, 11)), 48);
                        r3 = srai_epi64(shuffle_epi8(a, new v128(-1, -1, -1, -1, -1, -1, 12, 13,  -1, -1, -1, -1, -1, -1, 14, 15)), 48);
                    }
                    else
                    {
                        v128 a32lo = cvt2x2epi16_epi32(a, out v128 a32hi);

                        r1 = shuffle_epi8(a32lo, new v128( 8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15));
                        r2 = shuffle_epi8(a32hi, new v128( 0,  1,  2,  3,  3,  3,  3,  3,   4,  5,  6,  7,  7,  7,  7,  7));
                        r3 = shuffle_epi8(a32hi, new v128( 8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15));
                    }
                }
                else
                {
                    v128 a32lo = cvt2x2epi16_epi32(a, out v128 a32hi);
                    r0 = cvt2x2epi32_epi64(a32lo, out r1);
                    r2 = cvt2x2epi32_epi64(a32hi, out r3);
                }

                constexpr.ASSUME(r0.SLong0 == a.SShort0);
                constexpr.ASSUME(r0.SLong1 == a.SShort1);
                constexpr.ASSUME(r1.SLong0 == a.SShort2);
                constexpr.ASSUME(r1.SLong1 == a.SShort3);
                constexpr.ASSUME(r2.SLong0 == a.SShort4);
                constexpr.ASSUME(r2.SLong1 == a.SShort5);
                constexpr.ASSUME(r3.SLong0 == a.SShort6);
                constexpr.ASSUME(r3.SLong1 == a.SShort7);
                constexpr.ASSUME_RANGE_EPI64(r0, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r1, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r2, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r3, short.MinValue, short.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu8_epi32(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi      = Avx2.mm256_shuffle_epi8(a, new v256(4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1,
                                                              4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1));
                v256 lo = Avx2.mm256_shuffle_epi8(a, new v256(0, -1, -1, -1,    1, -1, -1, -1,    2, -1, -1, -1,    3, -1, -1, -1,
                                                              0, -1, -1, -1,    1, -1, -1, -1,    2, -1, -1, -1,    3, -1, -1, -1));

                constexpr.ASSUME(lo.UInt0 == a.Byte0);
                constexpr.ASSUME(lo.UInt1 == a.Byte1);
                constexpr.ASSUME(lo.UInt2 == a.Byte2);
                constexpr.ASSUME(lo.UInt3 == a.Byte3);
                constexpr.ASSUME(lo.UInt4 == a.Byte16);
                constexpr.ASSUME(lo.UInt5 == a.Byte17);
                constexpr.ASSUME(lo.UInt6 == a.Byte18);
                constexpr.ASSUME(lo.UInt7 == a.Byte19);
                constexpr.ASSUME(hi.UInt0 == a.Byte4);
                constexpr.ASSUME(hi.UInt1 == a.Byte5);
                constexpr.ASSUME(hi.UInt2 == a.Byte6);
                constexpr.ASSUME(hi.UInt3 == a.Byte7);
                constexpr.ASSUME(hi.UInt4 == a.Byte20);
                constexpr.ASSUME(hi.UInt5 == a.Byte21);
                constexpr.ASSUME(hi.UInt6 == a.Byte22);
                constexpr.ASSUME(hi.UInt7 == a.Byte23);
                constexpr.ASSUME_LE_EPU32(lo, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(hi, byte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epu8_epi32(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                r0 = Avx2.mm256_shuffle_epi8(a, new v256( 0, -1, -1, -1,    1, -1, -1, -1,    2, -1, -1, -1,    3, -1, -1, -1,
                                                          0, -1, -1, -1,    1, -1, -1, -1,    2, -1, -1, -1,    3, -1, -1, -1));
                r1 = Avx2.mm256_shuffle_epi8(a, new v256( 4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1,
                                                          4, -1, -1, -1,    5, -1, -1, -1,    6, -1, -1, -1,    7, -1, -1, -1));
                r2 = Avx2.mm256_shuffle_epi8(a, new v256( 8, -1, -1, -1,    9, -1, -1, -1,   10, -1, -1, -1,   11, -1, -1, -1,
                                                          8, -1, -1, -1,    9, -1, -1, -1,   10, -1, -1, -1,   11, -1, -1, -1));
                r3 = Avx2.mm256_shuffle_epi8(a, new v256(12, -1, -1, -1,   13, -1, -1, -1,   14, -1, -1, -1,   15, -1, -1, -1,
                                                         12, -1, -1, -1,   13, -1, -1, -1,   14, -1, -1, -1,   15, -1, -1, -1));

                constexpr.ASSUME(r0.UInt0 == a.Byte0);
                constexpr.ASSUME(r0.UInt1 == a.Byte1);
                constexpr.ASSUME(r0.UInt2 == a.Byte2);
                constexpr.ASSUME(r0.UInt3 == a.Byte3);
                constexpr.ASSUME(r0.UInt4 == a.Byte16);
                constexpr.ASSUME(r0.UInt5 == a.Byte17);
                constexpr.ASSUME(r0.UInt6 == a.Byte18);
                constexpr.ASSUME(r0.UInt7 == a.Byte19);
                constexpr.ASSUME(r1.UInt0 == a.Byte4);
                constexpr.ASSUME(r1.UInt1 == a.Byte5);
                constexpr.ASSUME(r1.UInt2 == a.Byte6);
                constexpr.ASSUME(r1.UInt3 == a.Byte7);
                constexpr.ASSUME(r1.UInt4 == a.Byte20);
                constexpr.ASSUME(r1.UInt5 == a.Byte21);
                constexpr.ASSUME(r1.UInt6 == a.Byte22);
                constexpr.ASSUME(r1.UInt7 == a.Byte23);
                constexpr.ASSUME(r2.UInt0 == a.Byte8);
                constexpr.ASSUME(r2.UInt1 == a.Byte9);
                constexpr.ASSUME(r2.UInt2 == a.Byte10);
                constexpr.ASSUME(r2.UInt3 == a.Byte11);
                constexpr.ASSUME(r2.UInt4 == a.Byte24);
                constexpr.ASSUME(r2.UInt5 == a.Byte25);
                constexpr.ASSUME(r2.UInt6 == a.Byte26);
                constexpr.ASSUME(r2.UInt7 == a.Byte27);
                constexpr.ASSUME(r3.UInt0 == a.Byte12);
                constexpr.ASSUME(r3.UInt1 == a.Byte13);
                constexpr.ASSUME(r3.UInt2 == a.Byte14);
                constexpr.ASSUME(r3.UInt3 == a.Byte15);
                constexpr.ASSUME(r3.UInt4 == a.Byte28);
                constexpr.ASSUME(r3.UInt5 == a.Byte29);
                constexpr.ASSUME(r3.UInt6 == a.Byte30);
                constexpr.ASSUME(r3.UInt7 == a.Byte31);
                constexpr.ASSUME_LE_EPU32(r0, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r1, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r2, byte.MaxValue);
                constexpr.ASSUME_LE_EPU32(r3, byte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi8_epi32(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi      = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1, 4,    -1, -1, -1, 5,    -1, -1, -1, 6,    -1, -1, -1, 7,
                                                                                    -1, -1, -1, 4,    -1, -1, -1, 5,    -1, -1, -1, 6,    -1, -1, -1, 7)),
                                                24);
                v256 lo = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1, 0,    -1, -1, -1, 1,    -1, -1, -1, 2,    -1, -1, -1, 3,
                                                                                    -1, -1, -1, 0,    -1, -1, -1, 1,    -1, -1, -1, 2,    -1, -1, -1, 3)),
                                                24);

                constexpr.ASSUME(lo.SInt0 == a.SByte0);
                constexpr.ASSUME(lo.SInt1 == a.SByte1);
                constexpr.ASSUME(lo.SInt2 == a.SByte2);
                constexpr.ASSUME(lo.SInt3 == a.SByte3);
                constexpr.ASSUME(lo.SInt4 == a.SByte16);
                constexpr.ASSUME(lo.SInt5 == a.SByte17);
                constexpr.ASSUME(lo.SInt6 == a.SByte18);
                constexpr.ASSUME(lo.SInt7 == a.SByte19);
                constexpr.ASSUME(hi.SInt0 == a.SByte4);
                constexpr.ASSUME(hi.SInt1 == a.SByte5);
                constexpr.ASSUME(hi.SInt2 == a.SByte6);
                constexpr.ASSUME(hi.SInt3 == a.SByte7);
                constexpr.ASSUME(hi.SInt4 == a.SByte20);
                constexpr.ASSUME(hi.SInt5 == a.SByte21);
                constexpr.ASSUME(hi.SInt6 == a.SByte22);
                constexpr.ASSUME(hi.SInt7 == a.SByte23);
                constexpr.ASSUME_RANGE_EPI32(lo, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(hi, sbyte.MinValue, sbyte.MaxValue);

                return lo;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epi8_epi32(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                r0 = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1,  0,    -1, -1, -1,  1,    -1, -1, -1,  2,    -1, -1, -1,  3,
                                                                               -1, -1, -1,  0,    -1, -1, -1,  1,    -1, -1, -1,  2,    -1, -1, -1,  3)),
                                                                   24);
                r1 = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1,  4,    -1, -1, -1,  5,    -1, -1, -1,  6,    -1, -1, -1,  7,
                                                                               -1, -1, -1,  4,    -1, -1, -1,  5,    -1, -1, -1,  6,    -1, -1, -1,  7)),
                                                                   24);
                r2 = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1,  8,    -1, -1, -1,  9,    -1, -1, -1, 10,    -1, -1, -1, 11,
                                                                               -1, -1, -1,  8,    -1, -1, -1,  9,    -1, -1, -1, 10,    -1, -1, -1, 11)),
                                                                   24);
                r3 = Avx2.mm256_srai_epi32(Avx2.mm256_shuffle_epi8(a, new v256(-1, -1, -1, 12,    -1, -1, -1, 13,    -1, -1, -1, 14,    -1, -1, -1, 15,
                                                                               -1, -1, -1, 12,    -1, -1, -1, 13,    -1, -1, -1, 14,    -1, -1, -1, 15)),
                                                                   24);

                constexpr.ASSUME(r0.SInt0 == a.SByte0);
                constexpr.ASSUME(r0.SInt1 == a.SByte1);
                constexpr.ASSUME(r0.SInt2 == a.SByte2);
                constexpr.ASSUME(r0.SInt3 == a.SByte3);
                constexpr.ASSUME(r0.SInt4 == a.SByte16);
                constexpr.ASSUME(r0.SInt5 == a.SByte17);
                constexpr.ASSUME(r0.SInt6 == a.SByte18);
                constexpr.ASSUME(r0.SInt7 == a.SByte19);
                constexpr.ASSUME(r1.SInt0 == a.SByte4);
                constexpr.ASSUME(r1.SInt1 == a.SByte5);
                constexpr.ASSUME(r1.SInt2 == a.SByte6);
                constexpr.ASSUME(r1.SInt3 == a.SByte7);
                constexpr.ASSUME(r1.SInt4 == a.SByte20);
                constexpr.ASSUME(r1.SInt5 == a.SByte21);
                constexpr.ASSUME(r1.SInt6 == a.SByte22);
                constexpr.ASSUME(r1.SInt7 == a.SByte23);
                constexpr.ASSUME(r2.SInt0 == a.SByte8);
                constexpr.ASSUME(r2.SInt1 == a.SByte9);
                constexpr.ASSUME(r2.SInt2 == a.SByte10);
                constexpr.ASSUME(r2.SInt3 == a.SByte11);
                constexpr.ASSUME(r2.SInt4 == a.SByte24);
                constexpr.ASSUME(r2.SInt5 == a.SByte25);
                constexpr.ASSUME(r2.SInt6 == a.SByte26);
                constexpr.ASSUME(r2.SInt7 == a.SByte27);
                constexpr.ASSUME(r3.SInt0 == a.SByte12);
                constexpr.ASSUME(r3.SInt1 == a.SByte13);
                constexpr.ASSUME(r3.SInt2 == a.SByte14);
                constexpr.ASSUME(r3.SInt3 == a.SByte15);
                constexpr.ASSUME(r3.SInt4 == a.SByte28);
                constexpr.ASSUME(r3.SInt5 == a.SByte29);
                constexpr.ASSUME(r3.SInt6 == a.SByte30);
                constexpr.ASSUME(r3.SInt7 == a.SByte31);
                constexpr.ASSUME_RANGE_EPI32(r0, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r1, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r2, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI32(r3, sbyte.MinValue, sbyte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epi8_ps(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                mm256_cvt4x4epi8_epi32(a, out r0, out r1, out r2, out r3);
                r0 = Avx.mm256_cvtepi32_ps(r0);
                r1 = Avx.mm256_cvtepi32_ps(r1);
                r2 = Avx.mm256_cvtepi32_ps(r2);
                r3 = Avx.mm256_cvtepi32_ps(r3);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epu8_ps(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 aLo = mm256_cvt2x2epu8_epi16(a, out v256 aHi);
                r0 = mm256_cvt2x2epu16_ps(aLo, out r1);
                r2 = mm256_cvt2x2epu16_ps(aHi, out r3);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt8x8epu8_epi64(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3, [NoAlias] out v256 r4, [NoAlias] out v256 r5, [NoAlias] out v256 r6, [NoAlias] out v256 r7)
        {
            if (Avx2.IsAvx2Supported)
            {
                r0 = Avx2.mm256_shuffle_epi8(a, new v256( 0, -1, -1, -1, -1, -1, -1, -1,   1, -1, -1, -1, -1, -1, -1, -1,
                                                          0, -1, -1, -1, -1, -1, -1, -1,   1, -1, -1, -1, -1, -1, -1, -1));
                r1 = Avx2.mm256_shuffle_epi8(a, new v256( 2, -1, -1, -1, -1, -1, -1, -1,   3, -1, -1, -1, -1, -1, -1, -1,
                                                          2, -1, -1, -1, -1, -1, -1, -1,   3, -1, -1, -1, -1, -1, -1, -1));
                r2 = Avx2.mm256_shuffle_epi8(a, new v256( 4, -1, -1, -1, -1, -1, -1, -1,   5, -1, -1, -1, -1, -1, -1, -1,
                                                          4, -1, -1, -1, -1, -1, -1, -1,   5, -1, -1, -1, -1, -1, -1, -1));
                r3 = Avx2.mm256_shuffle_epi8(a, new v256( 6, -1, -1, -1, -1, -1, -1, -1,   7, -1, -1, -1, -1, -1, -1, -1,
                                                          6, -1, -1, -1, -1, -1, -1, -1,   7, -1, -1, -1, -1, -1, -1, -1));
                r4 = Avx2.mm256_shuffle_epi8(a, new v256( 8, -1, -1, -1, -1, -1, -1, -1,   9, -1, -1, -1, -1, -1, -1, -1,
                                                          8, -1, -1, -1, -1, -1, -1, -1,   9, -1, -1, -1, -1, -1, -1, -1));
                r5 = Avx2.mm256_shuffle_epi8(a, new v256(10, -1, -1, -1, -1, -1, -1, -1,  11, -1, -1, -1, -1, -1, -1, -1,
                                                         10, -1, -1, -1, -1, -1, -1, -1,  11, -1, -1, -1, -1, -1, -1, -1));
                r6 = Avx2.mm256_shuffle_epi8(a, new v256(12, -1, -1, -1, -1, -1, -1, -1,  13, -1, -1, -1, -1, -1, -1, -1,
                                                         12, -1, -1, -1, -1, -1, -1, -1,  13, -1, -1, -1, -1, -1, -1, -1));
                r7 = Avx2.mm256_shuffle_epi8(a, new v256(14, -1, -1, -1, -1, -1, -1, -1,  15, -1, -1, -1, -1, -1, -1, -1,
                                                         14, -1, -1, -1, -1, -1, -1, -1,  15, -1, -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(r0.ULong0 == a.Byte0);
                constexpr.ASSUME(r0.ULong1 == a.Byte1);
                constexpr.ASSUME(r0.ULong2 == a.Byte16);
                constexpr.ASSUME(r0.ULong3 == a.Byte17);
                constexpr.ASSUME(r1.ULong0 == a.Byte2);
                constexpr.ASSUME(r1.ULong1 == a.Byte3);
                constexpr.ASSUME(r1.ULong2 == a.Byte18);
                constexpr.ASSUME(r1.ULong3 == a.Byte19);
                constexpr.ASSUME(r2.ULong0 == a.Byte4);
                constexpr.ASSUME(r2.ULong1 == a.Byte5);
                constexpr.ASSUME(r2.ULong2 == a.Byte20);
                constexpr.ASSUME(r2.ULong3 == a.Byte21);
                constexpr.ASSUME(r3.ULong0 == a.Byte6);
                constexpr.ASSUME(r3.ULong1 == a.Byte7);
                constexpr.ASSUME(r3.ULong2 == a.Byte22);
                constexpr.ASSUME(r3.ULong3 == a.Byte23);
                constexpr.ASSUME(r4.ULong0 == a.Byte8);
                constexpr.ASSUME(r4.ULong1 == a.Byte9);
                constexpr.ASSUME(r4.ULong2 == a.Byte24);
                constexpr.ASSUME(r4.ULong3 == a.Byte25);
                constexpr.ASSUME(r5.ULong0 == a.Byte10);
                constexpr.ASSUME(r5.ULong1 == a.Byte11);
                constexpr.ASSUME(r5.ULong2 == a.Byte26);
                constexpr.ASSUME(r5.ULong3 == a.Byte27);
                constexpr.ASSUME(r6.ULong0 == a.Byte12);
                constexpr.ASSUME(r6.ULong1 == a.Byte13);
                constexpr.ASSUME(r6.ULong2 == a.Byte28);
                constexpr.ASSUME(r6.ULong3 == a.Byte29);
                constexpr.ASSUME(r7.ULong0 == a.Byte14);
                constexpr.ASSUME(r7.ULong1 == a.Byte15);
                constexpr.ASSUME(r7.ULong2 == a.Byte30);
                constexpr.ASSUME(r7.ULong3 == a.Byte31);
                constexpr.ASSUME_LE_EPU64(r0, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r1, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r2, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r3, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r4, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r5, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r6, byte.MaxValue);
                constexpr.ASSUME_LE_EPU64(r7, byte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt8x8epi8_epi64(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3, [NoAlias] out v256 r4, [NoAlias] out v256 r5, [NoAlias] out v256 r6, [NoAlias] out v256 r7)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 a16lo = mm256_cvt2x2epi8_epi16(a, out v256 a16hi);

                r0 = Avx2.mm256_shuffle_epi8(a16lo, new v256( 0,  1,  1,  1,  1,  1,  1,  1,   2,  3,  3,  3,  3,  3,  3,  3,
                                                              0,  1,  1,  1,  1,  1,  1,  1,   2,  3,  3,  3,  3,  3,  3,  3));
                r1 = Avx2.mm256_shuffle_epi8(a16lo, new v256( 4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7,
                                                              4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7));
                r2 = Avx2.mm256_shuffle_epi8(a16lo, new v256( 8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11,
                                                              8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11));
                r3 = Avx2.mm256_shuffle_epi8(a16lo, new v256(12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15,
                                                             12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15));
                r4 = Avx2.mm256_shuffle_epi8(a16hi, new v256( 0,  1,  1,  1,  1,  1,  1,  1,   2,  3,  3,  3,  3,  3,  3,  3,
                                                              0,  1,  1,  1,  1,  1,  1,  1,   2,  3,  3,  3,  3,  3,  3,  3));
                r5 = Avx2.mm256_shuffle_epi8(a16hi, new v256( 4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7,
                                                              4,  5,  5,  5,  5,  5,  5,  5,   6,  7,  7,  7,  7,  7,  7,  7));
                r6 = Avx2.mm256_shuffle_epi8(a16hi, new v256( 8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11,
                                                              8,  9,  9,  9,  9,  9,  9,  9,  10, 11, 11, 11, 11, 11, 11, 11));
                r7 = Avx2.mm256_shuffle_epi8(a16hi, new v256(12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15,
                                                             12, 13, 13, 13, 13, 13, 13, 13,  14, 15, 15, 15, 15, 15, 15, 15));

                constexpr.ASSUME(r0.SLong0 == a.SByte0);
                constexpr.ASSUME(r0.SLong1 == a.SByte1);
                constexpr.ASSUME(r0.SLong2 == a.SByte16);
                constexpr.ASSUME(r0.SLong3 == a.SByte17);
                constexpr.ASSUME(r1.SLong0 == a.SByte2);
                constexpr.ASSUME(r1.SLong1 == a.SByte3);
                constexpr.ASSUME(r1.SLong2 == a.SByte18);
                constexpr.ASSUME(r1.SLong3 == a.SByte19);
                constexpr.ASSUME(r2.SLong0 == a.SByte4);
                constexpr.ASSUME(r2.SLong1 == a.SByte5);
                constexpr.ASSUME(r2.SLong2 == a.SByte20);
                constexpr.ASSUME(r2.SLong3 == a.SByte21);
                constexpr.ASSUME(r3.SLong0 == a.SByte6);
                constexpr.ASSUME(r3.SLong1 == a.SByte7);
                constexpr.ASSUME(r3.SLong2 == a.SByte22);
                constexpr.ASSUME(r3.SLong3 == a.SByte23);
                constexpr.ASSUME(r4.SLong0 == a.SByte8);
                constexpr.ASSUME(r4.SLong1 == a.SByte9);
                constexpr.ASSUME(r4.SLong2 == a.SByte24);
                constexpr.ASSUME(r4.SLong3 == a.SByte25);
                constexpr.ASSUME(r5.SLong0 == a.SByte10);
                constexpr.ASSUME(r5.SLong1 == a.SByte11);
                constexpr.ASSUME(r5.SLong2 == a.SByte26);
                constexpr.ASSUME(r5.SLong3 == a.SByte27);
                constexpr.ASSUME(r6.SLong0 == a.SByte12);
                constexpr.ASSUME(r6.SLong1 == a.SByte13);
                constexpr.ASSUME(r6.SLong2 == a.SByte28);
                constexpr.ASSUME(r6.SLong3 == a.SByte29);
                constexpr.ASSUME(r7.SLong0 == a.SByte14);
                constexpr.ASSUME(r7.SLong1 == a.SByte15);
                constexpr.ASSUME(r7.SLong2 == a.SByte30);
                constexpr.ASSUME(r7.SLong3 == a.SByte31);
                constexpr.ASSUME_RANGE_EPI64(r0, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r1, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r2, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r3, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r4, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r5, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r6, sbyte.MinValue, sbyte.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r7, sbyte.MinValue, sbyte.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epu16_epi64(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                r0 = Avx2.mm256_shuffle_epi8(a, new v256( 0,  1, -1, -1, -1, -1, -1, -1,   2,  3, -1, -1, -1, -1, -1, -1,
                                                          0,  1, -1, -1, -1, -1, -1, -1,   2,  3, -1, -1, -1, -1, -1, -1));
                r1 = Avx2.mm256_shuffle_epi8(a, new v256( 4,  5, -1, -1, -1, -1, -1, -1,   6,  7, -1, -1, -1, -1, -1, -1,
                                                          4,  5, -1, -1, -1, -1, -1, -1,   6,  7, -1, -1, -1, -1, -1, -1));
                r2 = Avx2.mm256_shuffle_epi8(a, new v256( 8,  9, -1, -1, -1, -1, -1, -1,  10, 11, -1, -1, -1, -1, -1, -1,
                                                          8,  9, -1, -1, -1, -1, -1, -1,  10, 11, -1, -1, -1, -1, -1, -1));
                r3 = Avx2.mm256_shuffle_epi8(a, new v256(12, 23, -1, -1, -1, -1, -1, -1,  14, 15, -1, -1, -1, -1, -1, -1,
                                                         12, 23, -1, -1, -1, -1, -1, -1,  14, 15, -1, -1, -1, -1, -1, -1));

                constexpr.ASSUME(r0.ULong0 == a.UShort0);
                constexpr.ASSUME(r0.ULong1 == a.UShort1);
                constexpr.ASSUME(r0.ULong2 == a.UShort8);
                constexpr.ASSUME(r0.ULong3 == a.UShort9);
                constexpr.ASSUME(r1.ULong0 == a.UShort2);
                constexpr.ASSUME(r1.ULong1 == a.UShort3);
                constexpr.ASSUME(r1.ULong2 == a.UShort10);
                constexpr.ASSUME(r1.ULong3 == a.UShort11);
                constexpr.ASSUME(r2.ULong0 == a.UShort4);
                constexpr.ASSUME(r2.ULong1 == a.UShort5);
                constexpr.ASSUME(r2.ULong2 == a.UShort12);
                constexpr.ASSUME(r2.ULong3 == a.UShort13);
                constexpr.ASSUME(r3.ULong0 == a.UShort6);
                constexpr.ASSUME(r3.ULong1 == a.UShort7);
                constexpr.ASSUME(r3.ULong2 == a.UShort14);
                constexpr.ASSUME(r3.ULong3 == a.UShort15);
                constexpr.ASSUME_LE_EPU64(r0, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r1, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r2, ushort.MaxValue);
                constexpr.ASSUME_LE_EPU64(r3, ushort.MaxValue);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void mm256_cvt4x4epi16_epi64(v256 a, [NoAlias] out v256 r0, [NoAlias] out v256 r1, [NoAlias] out v256 r2, [NoAlias] out v256 r3)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 a32lo = mm256_cvt2x2epi16_epi32(a, out v256 a32hi);

                r0 = Avx2.mm256_shuffle_epi8(a32lo, new v256( 0,  1,  2,  3,  3,  3,  3,  3,   4,  5,  6,  7,  7,  7,  7,  7,
                                                              0,  1,  2,  3,  3,  3,  3,  3,   4,  5,  6,  7,  7,  7,  7,  7));
                r1 = Avx2.mm256_shuffle_epi8(a32lo, new v256( 8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15,
                                                              8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15));
                r2 = Avx2.mm256_shuffle_epi8(a32hi, new v256( 0,  1,  2,  3,  3,  3,  3,  3,   4,  5,  6,  7,  7,  7,  7,  7,
                                                              0,  1,  2,  3,  3,  3,  3,  3,   4,  5,  6,  7,  7,  7,  7,  7));
                r3 = Avx2.mm256_shuffle_epi8(a32hi, new v256( 8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15,
                                                              8,  9, 10, 11, 11, 11, 11, 11,  12, 13, 14, 15, 15, 15, 15, 15));

                constexpr.ASSUME(r0.SLong0 == a.SShort0);
                constexpr.ASSUME(r0.SLong1 == a.SShort1);
                constexpr.ASSUME(r0.SLong2 == a.SShort8);
                constexpr.ASSUME(r0.SLong3 == a.SShort9);
                constexpr.ASSUME(r1.SLong0 == a.SShort2);
                constexpr.ASSUME(r1.SLong1 == a.SShort3);
                constexpr.ASSUME(r1.SLong2 == a.SShort10);
                constexpr.ASSUME(r1.SLong3 == a.SShort11);
                constexpr.ASSUME(r2.SLong0 == a.SShort4);
                constexpr.ASSUME(r2.SLong1 == a.SShort5);
                constexpr.ASSUME(r2.SLong2 == a.SShort12);
                constexpr.ASSUME(r2.SLong3 == a.SShort13);
                constexpr.ASSUME(r3.SLong0 == a.SShort6);
                constexpr.ASSUME(r3.SLong1 == a.SShort7);
                constexpr.ASSUME(r3.SLong2 == a.SShort14);
                constexpr.ASSUME(r3.SLong3 == a.SShort15);
                constexpr.ASSUME_RANGE_EPI64(r0, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r1, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r2, short.MinValue, short.MaxValue);
                constexpr.ASSUME_RANGE_EPI64(r3, short.MinValue, short.MaxValue);
            }
            else throw new IllegalInstructionException();
        }
    }
}