using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.R_CBRT;

namespace MaxMath
{
    // https://www.mdpi.com/1996-1073/14/4/1058/htm

    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_ps(v128 a, bool promise = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    /*const*/ bool NEED_TO_SAVE_SIGN = !(promise || constexpr.ALL_LT_EPU32(a, 1u << 31, elements));

                    v128 ONE = Sse.set1_ps(1f);
                    v128 ONE_THIRD = Sse.set1_ps(1f / 3f);
                    v128 TWO_THIRDS = Sse.set1_ps(2f / 3f);

                    v128 absX = a;
                    
                    if (NEED_TO_SAVE_SIGN)
                    {
                        v128 SIGN_MASK = Sse2.set1_epi32(1 << 31); 
                        absX = Sse.andnot_ps(SIGN_MASK, a);
                        TWO_THIRDS = ternarylogic_si128(TWO_THIRDS, SIGN_MASK, a, TernaryOperation.OxF8);
                    }

                    v128 y = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(absX, 3, elements, true));
                    v128 c = Sse.mul_ps(Sse.mul_ps(absX, y), Sse.mul_ps(y, y));
                    y = Sse.mul_ps(y, fnmadd_ps(fnmadd_ps(Sse.set1_ps(F32_C2), c, Sse.set1_ps(F32_C1)), c, Sse.set1_ps(F32_C0)));
                    v128 d = Sse.mul_ps(absX, y);
                    c = fnmadd_ps(d, Sse.mul_ps(y, y), ONE);
                    
                    y = Sse.mul_ps(Sse.mul_ps(d, y), fmadd_ps(c, ONE_THIRD, ONE));
                    // additional NR
                    y = fdadd_ps(Sse.mul_ps(ONE_THIRD, a), Sse.mul_ps(y, y), Sse.mul_ps(TWO_THIRDS, y));
                    
                    // FloatPrecision.Low 2nd to last y (!!!save sign somehow!!!)
                    // FloatPrecision.Medium+ last y

                    return y;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_ps(v256 a, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    /*const*/ bool NEED_TO_SAVE_SIGN = !(promise || constexpr.ALL_LT_EPU32(a, 1u << 31));

                    v256 ONE = Avx.mm256_set1_ps(1f);
                    v256 ONE_THIRD = Avx.mm256_set1_ps(1f / 3f);
                    v256 TWO_THIRDS = Avx.mm256_set1_ps(2f / 3f);

                    v256 absX = a;
                    
                    if (NEED_TO_SAVE_SIGN)
                    {
                        v256 SIGN_MASK = Avx.mm256_set1_epi32(1 << 31); 
                        absX = Avx.mm256_andnot_ps(SIGN_MASK, a);
                        TWO_THIRDS = mm256_ternarylogic_si256(TWO_THIRDS, SIGN_MASK, a, TernaryOperation.OxF8);
                    }
                    
                    v256 y;
                    if (Avx2.IsAvx2Supported)
                    {
                        y = Avx2.mm256_sub_epi32(Avx.mm256_set1_epi32((int)F32_DIV), constexpr.mm256_div_epu32(absX, 3, true));
                    }
                    else
                    {
                        v128 yLo = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(Avx.mm256_castps256_ps128(a), 3, 4, true));
                        v128 yHi = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(Avx.mm256_extractf128_ps(a, 1), 3, 4, true));

                        y = new v256(yLo, yHi);
                    }

                    v256 c = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absX, y), Avx.mm256_mul_ps(y, y));
                    y = Avx.mm256_mul_ps(y, mm256_fnmadd_ps(mm256_fnmadd_ps(Avx.mm256_set1_ps(F32_C2), c, Avx.mm256_set1_ps(F32_C1)), c, Avx.mm256_set1_ps(F32_C0)));
                    v256 d = Avx.mm256_mul_ps(absX, y);
                    c = mm256_fnmadd_ps(d, Avx.mm256_mul_ps(y, y), ONE);
                   
                    y = Avx.mm256_mul_ps(Avx.mm256_mul_ps(d, y), mm256_fmadd_ps(c, ONE_THIRD, ONE));
                    // additional NR
                    y = mm256_fdadd_ps(Avx.mm256_mul_ps(ONE_THIRD, a), Avx.mm256_mul_ps(y, y), Avx.mm256_mul_ps(TWO_THIRDS, y));

                    // FloatPrecision.Low 2nd to last y (!!!save sign somehow!!!)
                    // FloatPrecision.Medium+ last y

                    return y;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 absHi = Sse2.and_pd(a, Sse2.set1_epi64x(0x7FFF_FFFF_0000_0000));

                    v128 r = Sse2.mul_pd(a, Sse2.set1_pd(1e+54));
                    r = Sse2.srli_epi64(Sse2.slli_epi64(r, 1), 33);
                    v128 newHiMask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x0010_0000), absHi);
                    v128 retAMask = Sse2.or_si128(Sse2.cmpgt_epi32(absHi, Sse2.set1_epi32(0x7FEF_FFFF)), 
                                                  Sse2.cmpeq_epi32(absHi, Sse2.setzero_si128()));
                    if (Sse4_1.IsSse41Supported)
                    {
                        ;
                    }
                    else
                    {
                        retAMask = Sse2.shuffle_epi32(retAMask, Sse.SHUFFLE(3, 3, 1, 1));
                        newHiMask = Sse2.shuffle_epi32(newHiMask, Sse.SHUFFLE(3, 3, 1, 1));
                    }
                    absHi = blendv_pd(Sse2.srli_epi64(absHi, 32), r, newHiMask);
                    v128 summand = blendv_pd(Sse2.set1_epi32((int)F64_DIV2), Sse2.set1_epi32((int)F64_DIV1), newHiMask);

                    //inlined __const.div_epu32 (more efficient shuffles)
                    v128 RCP3 = Sse2.set1_epi64x(2_863_311_531);
					absHi = Sse2.mul_epu32(RCP3, absHi);
					absHi = Sse2.srli_epi64(absHi, 33);
					absHi = Sse2.add_epi64(absHi, summand);

                    v128 t = Sse2.and_si128(a, Sse2.set1_epi64x(1L << 63));
                    t = Sse2.or_si128(t, Sse2.slli_epi64(absHi, 32));

                    r = Sse2.mul_pd(Sse2.mul_pd(t, Sse2.mul_pd(t, t)), Sse2.div_pd(Sse2.set1_pd(1d), a));
                    t = Sse2.mul_pd(t, fmadd_pd(Sse2.mul_pd(Sse2.mul_pd(r, r), r), fmadd_pd(Sse2.set1_pd(F64_C4), r, Sse2.set1_pd(F64_C3)), fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_C2), r, Sse2.set1_pd(F64_C1)), r, Sse2.set1_pd(F64_C0))));
                    t = Sse2.and_si128(Sse2.add_epi64(t, Sse2.set1_epi64x(0x8000_0000)), Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_C000_0000ul)));
                        
                    r = Sse2.div_pd(a, Sse2.mul_pd(t, t));                
                    t = fmadd_pd(Sse2.div_pd(Sse2.sub_pd(r, t), Sse2.add_pd(Sse2.add_pd(t, t), r)), t, t);  

                    return blendv_pd(t, a, retAMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 absHi = Avx.mm256_and_pd(a, Avx.mm256_set1_epi64x(0x7FFF_FFFF_0000_0000));

                    v256 r = Avx.mm256_mul_pd(a, Avx.mm256_set1_pd(1e+54));
                    r = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(r, 1), 33);
                    v256 newHiMask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x0010_0000), absHi);
                    v256 retAMask = Avx2.mm256_or_si256(Avx2.mm256_cmpgt_epi32(absHi, Avx.mm256_set1_epi32(0x7FEF_FFFF)), 
                                                        Avx2.mm256_cmpeq_epi32(absHi, Avx.mm256_setzero_si256()));
                    absHi = Avx.mm256_blendv_pd(Avx2.mm256_srli_epi64(absHi, 32), r, newHiMask);
                    v256 summand = Avx.mm256_blendv_pd(Avx.mm256_set1_epi32((int)F64_DIV2), Avx.mm256_set1_epi32((int)F64_DIV1), newHiMask);
                    
                    //inlined __const.div_epu32 (more efficient shuffles)
                    v256 RCP3 = Avx.mm256_set1_epi64x(2_863_311_531);
					absHi = Avx2.mm256_mul_epu32(RCP3, absHi);
					absHi = Avx2.mm256_srli_epi64(absHi, 33);
					absHi = Avx2.mm256_add_epi64(absHi, summand);

                    v256 t = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi64x(1L << 63));
                    t = Avx2.mm256_or_si256(t, Avx2.mm256_slli_epi64(absHi, 32));

                    r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(t, Avx.mm256_mul_pd(t, t)), Avx.mm256_div_pd(Avx.mm256_set1_pd(1d), a));
                    t = Avx.mm256_mul_pd(t, mm256_fmadd_pd(Avx.mm256_mul_pd(Avx.mm256_mul_pd(r, r), r), mm256_fmadd_pd(Avx.mm256_set1_pd(F64_C4), r, Avx.mm256_set1_pd(F64_C3)), mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_C2), r, Avx.mm256_set1_pd(F64_C1)), r, Avx.mm256_set1_pd(F64_C0))));
                    t = Avx2.mm256_and_si256(Avx2.mm256_add_epi64(t, Avx.mm256_set1_epi64x(0x8000_0000)), Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_C000_0000ul)));
                        
                    r = Avx.mm256_div_pd(a, Avx.mm256_mul_pd(t, t));                
                    t = mm256_fmadd_pd(Avx.mm256_div_pd(Avx.mm256_sub_pd(r, t), Avx.mm256_add_pd(Avx.mm256_add_pd(t, t), r)), t, t);  

                    return Avx.mm256_blendv_pd(t, a, retAMask);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rcbrt_ps(v128 a, bool promise = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    /*const*/ bool NEED_TO_SAVE_SIGN = !(promise || constexpr.ALL_LT_EPU32(a, 1u << 31, elements));
                    
                    v128 absX = a;
                    v128 ONE_THIRD = Sse.set1_ps(1f / 3f);
                    v128 SIGN_MASK = Sse2.set1_epi32(1 << 31); 

                    if (NEED_TO_SAVE_SIGN)
                    {
                        absX = Sse.andnot_ps(SIGN_MASK, a);
                        ONE_THIRD = ternarylogic_si128(ONE_THIRD, SIGN_MASK, a, TernaryOperation.OxF8);
                    }
        
                    v128 y = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(absX, 3, elements, true));
                    v128 c = Sse.mul_ps(Sse.mul_ps(absX, y), Sse.mul_ps(y, y));
                    y = Sse.mul_ps(y, fnmadd_ps(c, fnmadd_ps(Sse.set1_ps(F32_C2), c, Sse.set1_ps(F32_C1)), Sse.set1_ps(F32_C0)));
                    c = fnmadd_ps(Sse.mul_ps(Sse.mul_ps(ONE_THIRD, absX), y), Sse.mul_ps(y, y), ONE_THIRD);
                   
                    if (NEED_TO_SAVE_SIGN)
                    {
                        return fmadd_ps(c, y, ternarylogic_si128(y, SIGN_MASK, a, TernaryOperation.OxF8));
                    }
                    else 
                    {
                        return fmadd_ps(c, y, y);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rcbrt_ps(v256 a, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    /*const*/ bool NEED_TO_SAVE_SIGN = !(promise || constexpr.ALL_LT_EPU32(a, 1u << 31));
            
                    v256 absX = a;
                    v256 ONE_THIRD = Avx.mm256_set1_ps(1f / 3f);
                    v256 SIGN_MASK = Avx.mm256_set1_epi32(1 << 31); 

                    if (NEED_TO_SAVE_SIGN)
                    {   
                        absX = Avx.mm256_andnot_ps(SIGN_MASK, a);
                        ONE_THIRD = mm256_ternarylogic_si256(ONE_THIRD, SIGN_MASK, a, TernaryOperation.OxF8);
                    }
        
                    v256 y;
                    if (Avx2.IsAvx2Supported)
                    {
                        y = Avx2.mm256_sub_epi32(Avx.mm256_set1_epi32((int)F32_DIV), constexpr.mm256_div_epu32(absX, 3, true));
                    }
                    else
                    {
                        v128 yLo = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(Avx.mm256_castps256_ps128(a), 3, 4, true));
                        v128 yHi = Sse2.sub_epi32(Sse2.set1_epi32((int)F32_DIV), constexpr.div_epu32(Avx.mm256_extractf128_ps(a, 1), 3, 4, true));

                        y = new v256(yLo, yHi);
                    }
                    v256 c = Avx.mm256_mul_ps(Avx.mm256_mul_ps(absX, y), Avx.mm256_mul_ps(y, y));
                    y = Avx.mm256_mul_ps(y, mm256_fnmadd_ps(c, mm256_fnmadd_ps(Avx.mm256_set1_ps(F32_C2), c, Avx.mm256_set1_ps(F32_C1)), Avx.mm256_set1_ps(F32_C0)));
                    c = mm256_fnmadd_ps(Avx.mm256_mul_ps(Avx.mm256_mul_ps(ONE_THIRD, absX), y), Avx.mm256_mul_ps(y, y), ONE_THIRD);
                   
                    if (NEED_TO_SAVE_SIGN)
                    {
                        return mm256_fmadd_ps(c, y, mm256_ternarylogic_si256(y, SIGN_MASK, a, TernaryOperation.OxF8));
                    }
                    else 
                    {
                        return mm256_fmadd_ps(c, y, y);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rcbrt_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 absHi = Sse2.and_pd(a, Sse2.set1_epi64x(0x7FFF_FFFF_0000_0000));

                    v128 r = Sse2.mul_pd(a, Sse2.set1_pd(1e+54));
                    r = Sse2.srli_epi64(Sse2.slli_epi64(r, 1), 33);
                    v128 newHiMask = Sse2.cmpgt_epi32(Sse2.set1_epi32(0x0010_0000), absHi);
                    v128 retAMask = Sse2.or_si128(Sse2.cmpgt_epi32(absHi, Sse2.set1_epi32(0x7FEF_FFFF)), 
                                                  Sse2.cmpeq_epi32(absHi, Sse2.setzero_si128()));
                    if (Sse4_1.IsSse41Supported)
                    {
                        ;
                    }
                    else
                    {
                        retAMask = Sse2.shuffle_epi32(retAMask, Sse.SHUFFLE(3, 3, 1, 1));
                        newHiMask = Sse2.shuffle_epi32(newHiMask, Sse.SHUFFLE(3, 3, 1, 1));
                    }
                    absHi = blendv_pd(Sse2.srli_epi64(absHi, 32), r, newHiMask);
                    v128 summand = blendv_pd(Sse2.set1_epi32((int)F64_DIV2), Sse2.set1_epi32((int)F64_DIV1), newHiMask);
                    
                    //inlined __const.div_epu32 (more efficient shuffles)
                    v128 RCP3 = Sse2.set1_epi64x(2_863_311_531);
					absHi = Sse2.mul_epu32(RCP3, absHi);
					absHi = Sse2.srli_epi64(absHi, 33);
					absHi = Sse2.add_epi64(absHi, summand);

                    v128 t = Sse2.and_si128(a, Sse2.set1_epi64x(1L << 63));
                    t = Sse2.or_si128(t, Sse2.slli_epi64(absHi, 32));

                    r = Sse2.mul_pd(Sse2.mul_pd(t, Sse2.mul_pd(t, t)), Sse2.div_pd(Sse2.set1_pd(1d), a));
                    t = Sse2.mul_pd(t, fmadd_pd(Sse2.mul_pd(Sse2.mul_pd(r, r), r), fmadd_pd(Sse2.set1_pd(F64_C4), r, Sse2.set1_pd(F64_C3)), fmadd_pd(fmadd_pd(Sse2.set1_pd(F64_C2), r, Sse2.set1_pd(F64_C1)), r, Sse2.set1_pd(F64_C0))));
                    t = Sse2.and_si128(Sse2.add_epi64(t, Sse2.set1_epi64x(0x8000_0000)), Sse2.set1_epi64x(unchecked((long)0xFFFF_FFFF_C000_0000ul)));
                        
                    v128 tsq = Sse2.mul_pd(t, t);
                    r = Sse2.div_pd(a, tsq);
                    t = Sse2.div_pd(Sse2.add_pd(Sse2.add_pd(t, t), r), 
                                    Sse2.add_pd(fmsub_pd(r, t, tsq), fmadd_pd(t, r, Sse2.add_pd(tsq, tsq)))); 

                    return blendv_pd(t, a, retAMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rcbrt_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 absHi = Avx.mm256_and_pd(a, Avx.mm256_set1_epi64x(0x7FFF_FFFF_0000_0000));

                    v256 r = Avx.mm256_mul_pd(a, Avx.mm256_set1_pd(1e+54));
                    r = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(r, 1), 33);
                    v256 newHiMask = Avx2.mm256_cmpgt_epi32(Avx.mm256_set1_epi32(0x0010_0000), absHi);
                    v256 retAMask = Avx2.mm256_or_si256(Avx2.mm256_cmpgt_epi32(absHi, Avx.mm256_set1_epi32(0x7FEF_FFFF)), 
                                                        Avx2.mm256_cmpeq_epi32(absHi, Avx.mm256_setzero_si256()));
                    absHi = Avx.mm256_blendv_pd(Avx2.mm256_srli_epi64(absHi, 32), r, newHiMask);
                    v256 summand = Avx.mm256_blendv_pd(Avx.mm256_set1_epi32((int)F64_DIV2), Avx.mm256_set1_epi32((int)F64_DIV1), newHiMask);
                    
                    //inlined __const.div_epu32 (more efficient shuffles)
                    v256 RCP3 = Avx.mm256_set1_epi64x(2_863_311_531);
					absHi = Avx2.mm256_mul_epu32(RCP3, absHi);
					absHi = Avx2.mm256_srli_epi64(absHi, 33);
					absHi = Avx2.mm256_add_epi64(absHi, summand);

                    v256 t = Avx2.mm256_and_si256(a, Avx.mm256_set1_epi64x(1L << 63));
                    t = Avx2.mm256_or_si256(t, Avx2.mm256_slli_epi64(absHi, 32));

                    r = Avx.mm256_mul_pd(Avx.mm256_mul_pd(t, Avx.mm256_mul_pd(t, t)), Avx.mm256_div_pd(Avx.mm256_set1_pd(1d), a));
                    t = Avx.mm256_mul_pd(t, mm256_fmadd_pd(Avx.mm256_mul_pd(Avx.mm256_mul_pd(r, r), r), mm256_fmadd_pd(Avx.mm256_set1_pd(F64_C4), r, Avx.mm256_set1_pd(F64_C3)), mm256_fmadd_pd(mm256_fmadd_pd(Avx.mm256_set1_pd(F64_C2), r, Avx.mm256_set1_pd(F64_C1)), r, Avx.mm256_set1_pd(F64_C0))));
                    t = Avx2.mm256_and_si256(Avx2.mm256_add_epi64(t, Avx.mm256_set1_epi64x(0x8000_0000)), Avx.mm256_set1_epi64x(unchecked((long)0xFFFF_FFFF_C000_0000ul)));
                        
                    v256 tsq = Avx.mm256_mul_pd(t, t);
                    r = Avx.mm256_div_pd(a, tsq);
                    t = Avx.mm256_div_pd(Avx.mm256_add_pd(Avx.mm256_add_pd(t, t), r), 
                                         Avx.mm256_add_pd(mm256_fmsub_pd(r, t, tsq), mm256_fmadd_pd(t, r, Avx.mm256_add_pd(tsq, tsq)))); 

                    return Avx.mm256_blendv_pd(t, a, retAMask);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the cube root of a <see cref="float"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cbrt(float x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 1).Float0;
            }
            else
            {
                /*const*/ bool NEED_TO_SAVE_SIGN = !(positive.Promises(Promise.Positive) || Xse.constexpr.IS_TRUE(x >= 0f));
                
                float TWO_THIRDS = 2f / 3f;
                float absX = x;

                if (NEED_TO_SAVE_SIGN)
                {
                    uint SIGN_MASK = 0x8000_0000; 
                    uint sign = math.asuint(x) & SIGN_MASK;
                    absX = math.asfloat(andnot(math.asuint(x), SIGN_MASK));
                    TWO_THIRDS = math.asfloat(sign | math.asuint(TWO_THIRDS));
                }
        
                float y = math.asfloat(F32_DIV - math.asuint(absX) / 3);
                float c = (absX * y) * (y * y);
                y *= F32_C0 - c * (F32_C1 - F32_C2 * c);
                float d = absX * y * y;
                c = 1f - d * y;

                y = d * (1f + (1f / 3f) * c);
                // additional NR
                y = (TWO_THIRDS * y) + (((1f / 3f) * x) / (y * y));
                
                // FloatPrecision.Low 2nd to last y (!!!save sign somehow!!!)
                // FloatPrecision.Medium+ last y

                return y;
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float2"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cbrt(float2 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(Xse.cbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 2));
            }
            else
            {
                return new float2(cbrt(x.x, positive), cbrt(x.y, positive));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float3"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cbrt(float3 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.cbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 3));
            }
            else
            {
                return new float3(cbrt(x.x, positive), cbrt(x.y, positive), cbrt(x.z, positive));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="float4"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cbrt(float4 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(Xse.cbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 4));
            }
            else
            {
                return new float4(cbrt(x.x, positive), cbrt(x.y, positive), cbrt(x.z, positive), cbrt(x.w, positive));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="MaxMath.float8"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cbrt(float8 x, Promise positive = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cbrt_ps(x, positive.Promises(Promise.Positive));
            }
            else
            {
                return new float8(cbrt(x.v4_0, positive), cbrt(x.v4_4, positive));
            }
        }


        /// <summary>       Returns the cube root of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cbrt(double x)
        {
            uint hi = (uint)(((*(ulong*)&x) << 1) >> 33);
            double r = x;
            
            if (hi > 0x7FEF_FFFF | hi == 0)
            {
                return x;
            }
            else 
            {
                if (hi < 0x00100000) 
                {
                    r = x * 1e+54;
                    hi = (uint)(((*(ulong*)&r) << 1) >> 33);
                    hi = hi / 3 + F64_DIV1;
                } 
                else
                {
                    hi = hi / 3 + F64_DIV2;
                }
            
                ulong u = *(ulong*)&x & 1ul << 63;
                u |= (ulong)hi << 32;
                double t = *(double*)&u;
                
                r = (t * t * t) * (1d / x);
                t *= math.mad(r * r * r, math.mad(F64_C4, r, F64_C3), math.mad(math.mad(F64_C2, r, F64_C1), r, F64_C0));
                u = (*(ulong*)&t + 0x8000_0000) & 0xFFFF_FFFF_C000_0000ul;
                t = *(double*)&u;
                
                r = x / (t * t);                
                t = math.mad((r - t) / (t + t + r), t, t);  

                return t;
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cbrt(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.cbrt_pd(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new double2(cbrt(x.x), cbrt(x.y));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cbrt(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_cbrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double3(cbrt(x.xy), cbrt(x.z));
            }
        }

        /// <summary>       Returns the componentwise cube root of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cbrt(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_cbrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double4(cbrt(x.xy), cbrt(x.zw));
            }
        }


        /// <summary>       Returns the reciprocal cube root of a <see cref="float"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float rcbrt(float x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rcbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 1).Float0;
            }
            else
            {
                /*const*/ bool NEED_TO_SAVE_SIGN = !(positive.Promises(Promise.Positive) || Xse.constexpr.IS_TRUE(x >= 0f));
                
                float ONE = 1f;
                float absX = x;

                if (NEED_TO_SAVE_SIGN)
                {
                    uint SIGN_MASK = 0x8000_0000; 
                    uint sign = math.asuint(x) & SIGN_MASK;
                    absX = math.asfloat(andnot(math.asuint(x), SIGN_MASK));
                    ONE = math.asfloat(sign | math.asuint(ONE));
                }
        
                // this function is faster yet less precise AND WRONG (sign)
        
                //float y = math.asfloat(0x548C_39CB - math.asint(absX) / 3);
                //y *= 1.5015480449f - 0.534850249f * (absX * y) * (y * y);
                //y *= if (NEED_TO_SAVE_SIGN) math.asfloat(sign | math.asuint(1.333333985f)) - 0.33333333f * (x * y) * (y * y);
        
                float y = math.asfloat(F32_DIV - math.asuint(absX) / 3);
                float c = (absX * y) * (y * y);
                y *= F32_C0 - c * (F32_C1 - F32_C2 * c);
                c = ONE - (x * y) * (y * y);
                y *= ONE + (1f / 3f) * c;
        
                return y;
            }
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float2"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 rcbrt(float2 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(Xse.rcbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 2));
            }
            else
            {
                return new float2(rcbrt(x.x, positive), rcbrt(x.y, positive));
            }
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float3"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rcbrt(float3 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.rcbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 3));
            }
            else
            {
                return new float3(rcbrt(x.x, positive), rcbrt(x.y, positive), rcbrt(x.z, positive));
            }
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="float4"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rcbrt(float4 x, Promise positive = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(Xse.rcbrt_ps(RegisterConversion.ToV128(x), positive.Promises(Promise.Positive), 4));
            }
            else
            {
                return new float4(rcbrt(x.x, positive), rcbrt(x.y, positive), rcbrt(x.z, positive), rcbrt(x.w, positive));
            }
        }
        
        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="MaxMath.float8"/>.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="positive"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for negative input values, including negative 0.        </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcbrt(float8 x, Promise positive = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_rcbrt_ps(x, positive.Promises(Promise.Positive));
            }
            else
            {
                return new float8(rcbrt(x.v4_0, positive), rcbrt(x.v4_4, positive));
            }
        }

        
        /// <summary>       Returns the reciprocal cube root of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double rcbrt(double x)
        {
            uint hi = (uint)(((*(ulong*)&x) << 1) >> 33);
            double r = x;
            
            if (hi > 0x7FEF_FFFF | hi == 0)
            {
                return x;
            }
            else 
            {
                if (hi < 0x00100000) 
                {
                    r = x * 1e+54;
                    hi = (uint)(((*(ulong*)&r) << 1) >> 33);
                    hi = hi / 3 + F64_DIV1;
                } 
                else
                {
                    hi = hi / 3 + F64_DIV2;
                }
            
                ulong u = *(ulong*)&r & 1ul << 63;
                u |= (ulong)hi << 32;
                double t = *(double*)&u;
                
                r = (t * t * t) * (1d / x);
                t *= math.mad(r * r * r, math.mad(F64_C4, r, F64_C3), math.mad(math.mad(F64_C2, r, F64_C1), r, F64_C0));
                u = (*(ulong*)&t + 0x8000_0000) & 0xFFFF_FFFF_C000_0000ul;
                t = *(double*)&u;
                
                double tsq = t * t; 
                r = x / tsq;                
                t = (t + t + r) / (math.mad(r, t, -tsq) + math.mad(t, r, tsq + tsq));

                return t;
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 rcbrt(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.rcbrt_pd(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new double2(rcbrt(x.x), rcbrt(x.y));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 rcbrt(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_rcbrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double3(rcbrt(x.xy), rcbrt(x.z));
            }
        }

        /// <summary>       Returns the componentwise reciprocal cube root of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 rcbrt(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_rcbrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double4(rcbrt(x.xy), rcbrt(x.zw));
            }
        }
    }
}