using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

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
            if (Sse2.IsSse2Supported)
            {
                hi = Sse2.srai_epi16(Sse2.unpackhi_epi8(a, a), 8);

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepi8_epi16(a);
                }
                else
                {
                    return Sse2.srai_epi16(Sse2.unpacklo_epi8(a, a), 8);
                }
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_epi32(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.srai_epi16(a, 15);
                hi = Sse2.unpackhi_epi16(a, negativeMask);

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepi16_epi32(a);
                }
                else
                {
                    return Sse2.unpacklo_epi16(a, negativeMask);
                }
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_epi64(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 negativeMask = Sse2.srai_epi32(a, 31);
                hi = Sse2.unpackhi_epi32(a, negativeMask);

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepi32_epi64(a);
                }
                else
                {
                    return Sse2.unpacklo_epi32(a, negativeMask);
                }
            }
            else throw new IllegalInstructionException();
        }
        
        
        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu8_epi16(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = Sse2.unpackhi_epi8(a, Sse2.setzero_si128());

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepu8_epi16(a);
                }
                else
                {
                    return Sse2.unpacklo_epi8(a, Sse2.setzero_si128());
                }
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu16_epi32(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = Sse2.unpackhi_epi16(a, Sse2.setzero_si128());

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepu16_epi32(a);
                }
                else
                {
                    return Sse2.unpacklo_epi16(a, Sse2.setzero_si128());
                }
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu32_epi64(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi = Sse2.unpackhi_epi32(a, Sse2.setzero_si128());

                if (Sse4_1.IsSse41Supported)
                {
                    return Sse4_1.cvtepu32_epi64(a);
                }
                else
                {
                    return Sse2.unpacklo_epi32(a, Sse2.setzero_si128());
                }
            }
            else throw new IllegalInstructionException();
        }
        
        
        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu16_ps(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 EXP_MASK = Sse2.set1_epi16(0x4B00);
                v128 MAGIC = Sse.set1_ps(LIMIT_PRECISE_I16_F32);

                hi   = Sse.sub_ps(Sse2.unpackhi_epi16(a, EXP_MASK), MAGIC);
                return Sse.sub_ps(Sse2.unpacklo_epi16(a, EXP_MASK), MAGIC);
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_ps(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 lo = cvt2x2epi16_epi32(a, out hi);

                hi   = Sse2.cvtepi32_ps(hi);
                return Sse2.cvtepi32_ps(lo);
            }
            else throw new IllegalInstructionException();
        }
        

        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epu32_pd(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LE_EPU32(a, int.MaxValue, 4))
                {
                    hi   = Sse2.cvtepi32_pd(Sse2.bsrli_si128(a, 2 * sizeof(int)));
                    return Sse2.cvtepi32_pd(a);
                }
                else
                {
                    v128 EXP_MASK = Sse2.set1_epi32(0x4330_0000);
                    v128 MAGIC = Sse2.set1_pd(LIMIT_PRECISE_I32_F64);

                    hi   = Sse2.sub_pd(Sse2.unpackhi_epi32(a, EXP_MASK), MAGIC);
                    return Sse2.sub_pd(Sse2.unpacklo_epi32(a, EXP_MASK), MAGIC);
                }
            }
            else throw new IllegalInstructionException();
        }
        
        /// <summary>       <para>  LO: | 0 1 |  </para>      <para>  HI: | 2 3 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_pd(v128 a, out v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                hi   = Sse2.cvtepi32_pd(Sse2.bsrli_si128(a, 2 * sizeof(int)));
                return Sse2.cvtepi32_pd(a);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi16_epi8(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MASK = Sse2.set1_epi16(0x00FF);

                lo = Sse2.and_si128(lo, MASK);
                hi = Sse2.and_si128(hi, MASK);

                return Sse2.packus_epi16(lo, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi32_epi16(v128 lo, v128 hi)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MASK = Sse2.set1_epi32(0x0000_FFFF);

                lo = Sse2.and_si128(lo, MASK);
                hi = Sse2.and_si128(hi, MASK);

                return Sse4_1.packus_epi32(lo, hi);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.unpacklo_epi64(cvtepi32_epi16(lo), cvtepi32_epi16(hi)); 
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvt2x2ps_epu16(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = Sse.set1_ps(LIMIT_PRECISE_I16_F32);

                return cvt2x2epi32_epi16(Sse.add_ps(lo, MAGIC), Sse.add_ps(hi, MAGIC));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 cvt2x2epi64_epi32(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse.shuffle_ps(lo, hi, Sse.SHUFFLE(2, 0, 2, 0)); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtt2x2pd_epi32(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                return cvt2x2epi64_epi32(usfcvttpd_epi64(lo), usfcvttpd_epi64(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvt2x2pd_epu32(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 MAGIC = Sse2.set1_pd(LIMIT_PRECISE_I32_F64);

                return cvt2x2epi64_epi32(Sse2.add_pd(lo, MAGIC), Sse2.add_pd(hi, MAGIC));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 usfcvtt2x2pd_epu32(v128 lo, v128 hi)
        {
            if (Sse2.IsSse2Supported)
            {
                lo = RegisterConversion.ToV128(Unity.Mathematics.math.trunc(RegisterConversion.ToType<Unity.Mathematics.double2>(lo)));
                hi = RegisterConversion.ToV128(Unity.Mathematics.math.trunc(RegisterConversion.ToType<Unity.Mathematics.double2>(hi)));

                return usfcvt2x2pd_epu32(lo, hi);
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
                     
                hi   = Avx2.mm256_srai_epi16(hi, 8);
                return Avx2.mm256_srai_epi16(lo, 8);
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

                hi   = Avx2.mm256_unpackhi_epi16(a, negativeMask);
                return Avx2.mm256_unpacklo_epi16(a, negativeMask);
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

                hi   = Avx2.mm256_unpackhi_epi32(a, negativeMask);
                return Avx2.mm256_unpacklo_epi32(a, negativeMask);
            }
            else throw new IllegalInstructionException();
        }
        
        
        /// <summary>       <para>  LO: | 0 1 2 3 4 5 6 7 | 16 17 18 19 20 21 22 23 |  </para>      <para>  HI: | 8 9 10 11 12 13 14 15 | 24 25 26 27 28 29 30 31 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu8_epi16(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi   = Avx2.mm256_unpackhi_epi8(a, Avx.mm256_setzero_si256());
                return Avx2.mm256_unpacklo_epi8(a, Avx.mm256_setzero_si256());
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu16_epi32(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi   = Avx2.mm256_unpackhi_epi16(a, Avx.mm256_setzero_si256());
                return Avx2.mm256_unpacklo_epi16(a, Avx.mm256_setzero_si256());
            }
            else throw new IllegalInstructionException();
        }

        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu32_epi64(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi   = Avx2.mm256_unpackhi_epi32(a, Avx.mm256_setzero_si256());
                return Avx2.mm256_unpacklo_epi32(a, Avx.mm256_setzero_si256());
            }
            else throw new IllegalInstructionException();
        }
        

        /// <summary>       <para>  LO: | 0 1 2 3 | 8 9 10 11 |  </para>      <para>  HI: | 4 5 6 7 | 12 13 14 15 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu16_ps(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 EXP_MASK = Avx.mm256_set1_epi16(0x4B00);
                v256 MAGIC = Avx.mm256_set1_ps(LIMIT_PRECISE_I16_F32);

                hi   = Avx.mm256_sub_ps(Avx2.mm256_unpackhi_epi16(a, EXP_MASK), MAGIC);
                return Avx.mm256_sub_ps(Avx2.mm256_unpacklo_epi16(a, EXP_MASK), MAGIC);
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

                hi   = Avx.mm256_cvtepi32_ps(hi);
                return Avx.mm256_cvtepi32_ps(lo);
            }
            else throw new IllegalInstructionException();
        }
        

        /// <summary>       <para>  LO: | 0 1 | 4 5 |  </para>      <para>  HI: | 2 3 | 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epu32_pd(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 EXP_MASK = Avx.mm256_set1_epi32(0x4330_0000);
                v256 MAGIC = Avx.mm256_set1_pd(LIMIT_PRECISE_I32_F64);

                hi   = Avx.mm256_sub_pd(Avx2.mm256_unpackhi_epi32(a, EXP_MASK), MAGIC);
                return Avx.mm256_sub_pd(Avx2.mm256_unpacklo_epi32(a, EXP_MASK), MAGIC);
            }
            else throw new IllegalInstructionException();
        }
        

        /// <summary>       <para>  LO: | 0 1 2 3 |  </para>      <para>  HI: | 4 5 6 7 |  </para>       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi32_pd(v256 a, out v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                hi   = Avx.mm256_cvtepi32_pd(Avx2.mm256_extracti128_si256(a, 1));
                return Avx.mm256_cvtepi32_pd(Avx.mm256_castsi256_si128(a));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi16_epi8(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = Avx.mm256_set1_epi16(0x00FF);

                lo = Avx2.mm256_and_si256(lo, MASK);
                hi = Avx2.mm256_and_si256(hi, MASK);
                
                return Avx2.mm256_packus_epi16(lo, hi); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi32_epi16(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MASK = Avx.mm256_set1_epi32(0x0000_FFFF);

                lo = Avx2.mm256_and_si256(lo, MASK);
                hi = Avx2.mm256_and_si256(hi, MASK);
                
                return Avx2.mm256_packus_epi32(lo, hi); 
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_cvt2x2epi64_epi32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx.mm256_shuffle_ps(lo, hi, Sse.SHUFFLE(2, 0, 2, 0)); 
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2ps_epu16(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = Avx.mm256_set1_ps(LIMIT_PRECISE_I16_F32);

                return mm256_cvt2x2epi32_epi16(Avx.mm256_add_ps(lo, MAGIC), Avx.mm256_add_ps(hi, MAGIC));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2pd_epu32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAGIC = Avx.mm256_set1_pd(LIMIT_PRECISE_I32_F64);

                return mm256_cvt2x2epi64_epi32(Avx.mm256_add_pd(lo, MAGIC), Avx.mm256_add_pd(hi, MAGIC));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtt2x2pd_epu32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                lo = Avx.mm256_round_pd(lo, (int)RoundingMode.FROUND_TRUNC_NOEXC);
                hi = Avx.mm256_round_pd(hi, (int)RoundingMode.FROUND_TRUNC_NOEXC);


                return mm256_usfcvt2x2pd_epu32(lo, hi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvt2x2pd_epi32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvt2x2epi64_epi32(mm256_usfcvtpd_epi64(lo), mm256_usfcvtpd_epi64(hi));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_usfcvtt2x2pd_epi32(v256 lo, v256 hi)
        {
            if (Avx2.IsAvx2Supported)
            {
                return mm256_cvt2x2epi64_epi32(mm256_usfcvttpd_epi64(lo), mm256_usfcvttpd_epi64(hi));
            }
            else throw new IllegalInstructionException();
        }
    }
}