using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epu8(v128 a, v128 b, byte elements = 16)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPU8(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPU8(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPU8(a, 2, (byte)elements))
                            {
                                result = Sse2.adds_epu8(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPU8(a, 3, (byte)elements))
                            {
                                result = Sse2.adds_epu8(b, Sse2.adds_epu8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPU8(a, 4, (byte)elements))
                            {
                                result = Sse2.adds_epu8(Sse2.adds_epu8(b, b), Sse2.adds_epu8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 8, (byte)elements))
                            {
                                result = Sse2.adds_epu8(Sse2.adds_epu8(Sse2.adds_epu8(b, b), Sse2.adds_epu8(b, b)), Sse2.adds_epu8(Sse2.adds_epu8(b, b), Sse2.adds_epu8(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    if (elements <= 8)
                    {
                        v128 product = Sse2.mullo_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b));
                        product = blendv_si128(product, Sse2.set1_epi16(short.MaxValue), Sse2.srai_epi16(product, 15));
                        
                        return Sse2.packus_epi16(product, product);
                    }
                    else
                    {
                        v128 aLo = cvt2x2epu8_epi16(a, out v128 aHi);
                        v128 bLo = cvt2x2epu8_epi16(b, out v128 bHi);

                        v128 product_lo = Sse2.mullo_epi16(aLo, bLo);
                        v128 product_hi = Sse2.mullo_epi16(aHi, bHi);
                        product_lo = blendv_si128(product_lo, Sse2.set1_epi16(short.MaxValue), Sse2.srai_epi16(product_lo, 15));
                        product_hi = blendv_si128(product_hi, Sse2.set1_epi16(short.MaxValue), Sse2.srai_epi16(product_hi, 15));
                        
                        return Sse2.packus_epi16(product_lo, product_hi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epu8(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI8(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 2))
                            {
                                result = Avx2.mm256_adds_epu8(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 3))
                            {
                                result = Avx2.mm256_adds_epu8(b, Avx2.mm256_adds_epu8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 4))
                            {
                                result = Avx2.mm256_adds_epu8(Avx2.mm256_adds_epu8(b, b), Avx2.mm256_adds_epu8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 8))
                            {
                                result = Avx2.mm256_adds_epu8(Avx2.mm256_adds_epu8(Avx2.mm256_adds_epu8(b, b), Avx2.mm256_adds_epu8(b, b)), Avx2.mm256_adds_epu8(Avx2.mm256_adds_epu8(b, b), Avx2.mm256_adds_epu8(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 xShortsLo = mm256_cvt2x2epu8_epi16(a, out v256 xShortsHi);
                    v256 yShortsLo = mm256_cvt2x2epu8_epi16(b, out v256 yShortsHi);

                    v256 product_lo = Avx2.mm256_mullo_epi16(xShortsLo, yShortsLo);
                    v256 product_hi = Avx2.mm256_mullo_epi16(xShortsHi, yShortsHi);
                    product_lo = mm256_blendv_si256(product_lo, Avx.mm256_set1_epi16(short.MaxValue), Avx2.mm256_srai_epi16(product_lo, 15));
                    product_hi = mm256_blendv_si256(product_hi, Avx.mm256_set1_epi16(short.MaxValue), Avx2.mm256_srai_epi16(product_hi, 15));

                    return Avx2.mm256_packus_epi16(product_lo, product_hi);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epu16(v128 a, v128 b, byte elements = 8)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI16(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 2, (byte)elements))
                            {
                                result = Sse2.adds_epu16(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 3, (byte)elements))
                            {
                                result = Sse2.adds_epu16(b, Sse2.adds_epu16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 4, (byte)elements))
                            {
                                result = Sse2.adds_epu16(Sse2.adds_epu16(b, b), Sse2.adds_epu16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 8, (byte)elements))
                            {
                                result = Sse2.adds_epu16(Sse2.adds_epu16(Sse2.adds_epu16(b, b), Sse2.adds_epu16(b, b)), Sse2.adds_epu16(Sse2.adds_epu16(b, b), Sse2.adds_epu16(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    v128 product_hiBits = Sse2.mulhi_epu16(a, b);
                    v128 product_loBits = Sse2.mullo_epi16(a, b);

                    v128 _NOT_OverflowMask = Sse2.cmpeq_epi16(product_hiBits, Sse2.setzero_si128());
                    
                    return ternarylogic_si128(product_loBits, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epu16(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI16(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 2))
                            {
                                result = Avx2.mm256_adds_epu16(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 3))
                            {
                                result = Avx2.mm256_adds_epu16(b, Avx2.mm256_adds_epu16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 4))
                            {
                                result = Avx2.mm256_adds_epu16(Avx2.mm256_adds_epu16(b, b), Avx2.mm256_adds_epu16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 8))
                            {
                                result = Avx2.mm256_adds_epu16(Avx2.mm256_adds_epu16(Avx2.mm256_adds_epu16(b, b), Avx2.mm256_adds_epu16(b, b)), Avx2.mm256_adds_epu16(Avx2.mm256_adds_epu16(b, b), Avx2.mm256_adds_epu16(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 product_hiBits = Avx2.mm256_mulhi_epu16(a, b);
                    v256 product_loBits = Avx2.mm256_mullo_epi16(a, b);

                    v256 _NOT_OverflowMask = Avx2.mm256_cmpeq_epi16(product_hiBits, Avx.mm256_setzero_si256());
                    
                    return mm256_ternarylogic_si256(product_loBits, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epu32(v128 a, v128 b, byte elements = 4)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI32(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 2, (byte)elements))
                            {
                                result = adds_epu32(b, b, (byte)elements);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 3, (byte)elements))
                            {
                                result = adds_epu32(b, adds_epu32(b, b, (byte)elements), (byte)elements);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 4, (byte)elements))
                            {
                                result = adds_epu32(adds_epu32(b, b, (byte)elements), adds_epu32(b, b, (byte)elements), (byte)elements);
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    if (elements <= 2)
                    {
                        v128 product64 = Sse2.mul_epu32(Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 1, 0, 0)),
                                                        Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 1, 0, 0)));

                        v128 _NOT_OverflowMask = Sse2.cmpeq_epi32(Sse2.setzero_si128(), product64);
                        _NOT_OverflowMask = Sse2.shuffle_epi32(_NOT_OverflowMask, Sse.SHUFFLE(0, 0, 3, 1));
                        v128 product32 = Sse2.shuffle_epi32(product64, Sse.SHUFFLE(0, 0, 2, 0));

                        return ternarylogic_si128(product32, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                    }
                    else
                    {
                        v128 even = Sse2.mul_epu32(a, b);
                        v128 odd = Sse2.mul_epu32(Sse2.shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Sse2.shuffle_epi32(b, Sse.SHUFFLE(3, 3, 1, 1)));
                        v128 product32 = Sse2.or_si128(even, Sse2.bslli_si128(odd, sizeof(int)));

                        v128 _NOT_OverflowMask = Sse2.cmpeq_epi32(Sse2.setzero_si128(), product32);

                        return ternarylogic_si128(product32, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epu32(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI32(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 2))
                            {
                                result = mm256_adds_epu32(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 3))
                            {
                                result = mm256_adds_epu32(b, mm256_adds_epu32(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 4))
                            {
                                result = mm256_adds_epu32(mm256_adds_epu32(b, b), mm256_adds_epu32(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 even = Avx2.mm256_mul_epu32(a, b);
                    v256 odd = Avx2.mm256_mul_epu32(Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(3, 3, 1, 1)));
                    v256 product32 = Avx2.mm256_or_si256(even, Avx2.mm256_bslli_epi128(odd, sizeof(int)));
                    
                    v256 _NOT_OverflowMask = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), product32);
                    
                    return mm256_ternarylogic_si256(product32, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epu64(v128 a, v128 b)
            {
                static bool __constCheck(v128 a, v128 b, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI64(a, 0))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 2))
                            {
                                result = adds_epu64(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 3))
                            {
                                result = adds_epu64(b, adds_epu64(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 4))
                            {
                                result = adds_epu64(adds_epu64(b, b), adds_epu64(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    ulong loX = Common.umul128(a.ULong0, b.ULong0, out ulong hiX);
                    ulong loY = Common.umul128(a.ULong1, b.ULong1, out ulong hiY);

                    v128 _NOT_OverflowMask = cmpeq_epi64(Sse2.setzero_si128(), new v128(hiX, hiY));
                    
                    return ternarylogic_si128(new v128(loX, loY), _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epu64(v256 a, v256 b, byte elements = 4)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result, byte elements = 4)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI64(a, 0, elements))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 1, elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 2, elements))
                            {
                                result = mm256_adds_epu64(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 3, elements))
                            {
                                result = mm256_adds_epu64(b, mm256_adds_epu64(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 4, elements))
                            {
                                result = mm256_adds_epu64(mm256_adds_epu64(b, b), mm256_adds_epu64(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result, elements))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result, elements))
                    {
                        return result;
                    }
                    
                    v256 ZERO = Avx.mm256_setzero_si256();
                    
                    v256 hi = Xse.mm256_mulhi_epu64(a, b, out v256 lo);
                    v256 _NOT_OverflowMask = Avx2.mm256_cmpeq_epi64(ZERO, hi);
                    
                    return mm256_ternarylogic_si256(lo, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epi8(v128 a, v128 b, byte elements = 16)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI8(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 2, (byte)elements))
                            {
                                result = Sse2.adds_epi8(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 3, (byte)elements))
                            {
                                result = Sse2.adds_epi8(b, Sse2.adds_epi8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 4, (byte)elements))
                            {
                                result = Sse2.adds_epi8(Sse2.adds_epi8(b, b), Sse2.adds_epi8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 8, (byte)elements))
                            {
                                result = Sse2.adds_epi8(Sse2.adds_epi8(Sse2.adds_epi8(b, b), Sse2.adds_epi8(b, b)), Sse2.adds_epi8(Sse2.adds_epi8(b, b), Sse2.adds_epi8(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    if (elements <= 8)
                    {
                        v128 product = Sse2.mullo_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b));
                        
                        return Sse2.packs_epi16(product, product);
                    }
                    else
                    {
                        v128 aLo = cvt2x2epi8_epi16(a, out v128 aHi);
                        v128 bLo = cvt2x2epi8_epi16(b, out v128 bHi);

                        v128 product_lo = Sse2.mullo_epi16(aLo, bLo);
                        v128 product_hi = Sse2.mullo_epi16(aHi, bHi);
                        
                        return Sse2.packs_epi16(product_lo, product_hi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epi8(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI8(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 2))
                            {
                                result = Avx2.mm256_adds_epi8(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 3))
                            {
                                result = Avx2.mm256_adds_epi8(b, Avx2.mm256_adds_epi8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 4))
                            {
                                result = Avx2.mm256_adds_epi8(Avx2.mm256_adds_epi8(b, b), Avx2.mm256_adds_epi8(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI8(a, 8))
                            {
                                result = Avx2.mm256_adds_epi8(Avx2.mm256_adds_epi8(Avx2.mm256_adds_epi8(b, b), Avx2.mm256_adds_epi8(b, b)), Avx2.mm256_adds_epi8(Avx2.mm256_adds_epi8(b, b), Avx2.mm256_adds_epi8(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 xShortsLo = mm256_cvt2x2epi8_epi16(a, out v256 xShortsHi);
                    v256 yShortsLo = mm256_cvt2x2epi8_epi16(b, out v256 yShortsHi);

                    v256 product_lo = Avx2.mm256_mullo_epi16(xShortsLo, yShortsLo);
                    v256 product_hi = Avx2.mm256_mullo_epi16(xShortsHi, yShortsHi);

                    return Avx2.mm256_packs_epi16(product_lo, product_hi);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epi16(v128 a, v128 b, byte elements = 8)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI16(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 2, (byte)elements))
                            {
                                result = Sse2.adds_epi16(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 3, (byte)elements))
                            {
                                result = Sse2.adds_epi16(b, Sse2.adds_epi16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 4, (byte)elements))
                            {
                                result = Sse2.adds_epi16(Sse2.adds_epi16(b, b), Sse2.adds_epi16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 8, (byte)elements))
                            {
                                result = Sse2.adds_epi16(Sse2.adds_epi16(Sse2.adds_epi16(b, b), Sse2.adds_epi16(b, b)), Sse2.adds_epi16(Sse2.adds_epi16(b, b), Sse2.adds_epi16(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    if (elements <= 4)
                    {
                        v128 x32 = Xse.cvtepi16_epi32(a);
                        v128 y32 = Xse.cvtepi16_epi32(b);

                        v128 product = Xse.mullo_epi32(x32, y32, elements);

                        return Sse2.packs_epi32(product, product);
                    }
                    else
                    {
                        v128 x32_lo = cvt2x2epi16_epi32(a, out v128 x32_hi);
                        v128 y32_lo = cvt2x2epi16_epi32(b, out v128 y32_hi);

                        v128 product_lo = Xse.mullo_epi32(x32_lo, y32_lo, 4);
                        v128 product_hi = Xse.mullo_epi32(x32_hi, y32_hi, 4);

                        return Sse2.packs_epi32(product_lo, product_hi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epi16(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI16(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 2))
                            {
                                result = Avx2.mm256_adds_epi16(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 3))
                            {
                                result = Avx2.mm256_adds_epi16(b, Avx2.mm256_adds_epi16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 4))
                            {
                                result = Avx2.mm256_adds_epi16(Avx2.mm256_adds_epi16(b, b), Avx2.mm256_adds_epi16(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI16(a, 8))
                            {
                                result = Avx2.mm256_adds_epi16(Avx2.mm256_adds_epi16(Avx2.mm256_adds_epi16(b, b), Avx2.mm256_adds_epi16(b, b)), Avx2.mm256_adds_epi16(Avx2.mm256_adds_epi16(b, b), Avx2.mm256_adds_epi16(b, b)));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }

                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 xIntsLo = Xse.mm256_cvt2x2epi16_epi32(a, out v256 xIntsHi);
                    v256 yIntsLo = Xse.mm256_cvt2x2epi16_epi32(b, out v256 yIntsHi);

                    v256 product_lo = Avx2.mm256_mullo_epi32(xIntsLo, yIntsLo);
                    v256 product_hi = Avx2.mm256_mullo_epi32(xIntsHi, yIntsHi);

                    return Avx2.mm256_packs_epi32(product_lo, product_hi);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epi32(v128 a, v128 b, byte elements = 4)
            {
                static bool __constCheck(v128 a, v128 b, int elements, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI32(a, 0, (byte)elements))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 1, (byte)elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 2, (byte)elements))
                            {
                                result = adds_epi32(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 3, (byte)elements))
                            {
                                result = adds_epi32(b, adds_epi32(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 4, (byte)elements))
                            {
                                result = adds_epi32(adds_epi32(b, b), adds_epi32(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }

                static v128 CORE_muls_epi32(v128 i64a, v128 i64b)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 MIN_VALUE = new long2(int.MinValue);
                        v128 MAX_VALUE = new long2(int.MaxValue);

                        v128 product64 = Sse4_1.mul_epi32(i64a, i64b);

                        v128 underflowMask = cmpgt_epi64(MIN_VALUE, product64);
                        v128 overflowMask = cmpgt_epi64(product64, MAX_VALUE);

                        product64 = blendv_si128(product64, MIN_VALUE, underflowMask);
                        product64 = blendv_si128(product64, MAX_VALUE, overflowMask);

                        return Sse2.shuffle_epi32(product64, Sse.SHUFFLE(0, 0, 2, 0));
                    }
                    else throw new IllegalInstructionException();       
                }


                if (Sse4_1.IsSse41Supported)
                {
                    if (__constCheck(a, b, elements, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, elements, out result))
                    {
                        return result;
                    }

                    if (elements <= 2)
                    {
                        v128 ulongsA = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 1, 0, 0));
                        v128 ulongsB = Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 1, 0, 0));

                        return CORE_muls_epi32(ulongsA, ulongsB);
                    }
                    else
                    {
                        v128 ulongsLoA = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 1, 0, 0));
                        v128 ulongsLoB = Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 1, 0, 0));
                        v128 ulongsHiA = Sse2.shuffle_epi32(a, Sse.SHUFFLE(0, 3, 0, 2));
                        v128 ulongsHiB = Sse2.shuffle_epi32(b, Sse.SHUFFLE(0, 3, 0, 2));

                        v128 intsLo = CORE_muls_epi32(ulongsLoA, ulongsLoB);
                        v128 intsHi = CORE_muls_epi32(ulongsHiA, ulongsHiB);

                        return Sse2.unpacklo_epi64(intsLo, intsHi);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epi32(v256 a, v256 b)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI32(a, 0))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 2))
                            {
                                result = mm256_adds_epi32(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 3))
                            {
                                result = mm256_adds_epi32(b, mm256_adds_epi32(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI32(a, 4))
                            {
                                result = mm256_adds_epi32(mm256_adds_epi32(b, b), mm256_adds_epi32(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }

                    v256 even = Avx2.mm256_mul_epi32(a, b);
                    v256 odd = Avx2.mm256_mul_epi32(Avx2.mm256_shuffle_epi32(a, Sse.SHUFFLE(3, 3, 1, 1)), Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(3, 3, 1, 1)));
                    v256 product32 = Avx2.mm256_or_si256(even, Avx2.mm256_bslli_epi128(odd, sizeof(int)));
                    
                    v256 _NOT_OverflowMask = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), product32);
                    
                    return mm256_ternarylogic_si256(product32, _NOT_OverflowMask, _NOT_OverflowMask, TernaryOperation.OxF3);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 muls_epi64(v128 a, v128 b)
            {
                static bool __constCheck(v128 a, v128 b, out v128 result)
                {
                    if (Sse2.IsSse2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI64(a, 0))
                            {
                                result = Sse2.setzero_si128();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 1))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 2))
                            {
                                result = adds_epi64(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 3))
                            {
                                result = adds_epi64(b, adds_epi64(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 4))
                            {
                                result = adds_epi64(adds_epi64(b, b), adds_epi64(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Sse2.IsSse2Supported)
                {
                    if (__constCheck(a, b, out v128 result))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result))
                    {
                        return result;
                    }
                    
                    v128 MAX_VALUE = Sse2.srli_epi64(setall_si128(), 1);
                    
                    ulong loX = Common.umul128(a.ULong0, b.ULong0, out ulong hiX);
                    ulong loY = Common.umul128(a.ULong1, b.ULong1, out ulong hiY);
                    v128 xNegative = srai_epi64(a, 63);
                    v128 yNegative = srai_epi64(b, 63);
                    v128 mask = Sse2.sub_epi64(MAX_VALUE, Sse2.xor_si128(xNegative, yNegative));
                    v128 lo = new v128(loX, loY);
                    v128 hi = new v128(hiX, hiY);
                    
                    return blendv_si128(mask, lo, cmpeq_epi64(hi, srai_epi64(lo, 63)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_muls_epi64(v256 a, v256 b, byte elements = 4)
            {
                static bool __constCheck(v256 a, v256 b, out v256 result, byte elements = 4)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        if (Constant.IsConstantExpression(a))
                        {
                            if (constexpr.ALL_EQ_EPI64(a, 0, elements))
                            {
                                result = Avx.mm256_setzero_si256();
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 1, elements))
                            {
                                result = b;
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 2, elements))
                            {
                                result = mm256_adds_epi64(b, b);
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 3, elements))
                            {
                                result = mm256_adds_epi64(b, mm256_adds_epi64(b, b));
                                return true;
                            }
                            if (constexpr.ALL_EQ_EPI64(a, 4, elements))
                            {
                                result = mm256_adds_epi64(mm256_adds_epi64(b, b), mm256_adds_epi64(b, b));
                                return true;
                            }
                        }

                        result = default;
                        return false;
                    }
                    else throw new IllegalInstructionException();
                }


                if (Avx2.IsAvx2Supported)
                {
                    if (__constCheck(a, b, out v256 result, elements))
                    {
                        return result;
                    }
                    if (__constCheck(b, a, out result, elements))
                    {
                        return result;
                    }
                    
                    v256 MAX_VALUE = Avx2.mm256_srli_epi64(mm256_setall_si256(), 1);
                    
                    v256 hi = mm256_mulhi_epu64(a, b, out v256 lo);
                    
                    v256 xNegative = mm256_srai_epi64(a, 63);
                    v256 yNegative = mm256_srai_epi64(b, 63);
                    v256 mask = Avx2.mm256_sub_epi64(MAX_VALUE, Avx2.mm256_xor_si256(xNegative, yNegative));

                    return mm256_blendv_si256(mask, lo, Avx2.mm256_cmpeq_epi64(hi, mm256_srai_epi64(lo, 63)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="UInt128.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 mulsaturated(UInt128 x, UInt128 y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            UInt128 product = UInt128.Common.umul256(x, y, out UInt128 hi);

            return select(product, UInt128.MaxValue, hi != 0);
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="Int128.MaxValue"/> if overflow occurs or <see cref="Int128.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 mulsaturated(Int128 x, Int128 y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            Int128 lo = UInt128.Common.imul256(x, y, out Int128 hi);
            
            return select(select(lo, Int128.MaxValue, hi != 0), Int128.MinValue, hi < -1);
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte mulsaturated(byte x, byte y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            return (byte)math.min(byte.MaxValue, x * y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 mulsaturated(byte2 x, byte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu8(x, y, 2);
            }
            else
            {
                return new byte2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 mulsaturated(byte3 x, byte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu8(x, y, 3);
            }
            else
            {
                return new byte3(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 mulsaturated(byte4 x, byte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu8(x, y, 4);
            }
            else
            {
                return new byte4(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z), 
                                 mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 mulsaturated(byte8 x, byte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu8(x, y, 8);
            }
            else
            {
                return new byte8(mulsaturated(x.x0, y.x0), 
                                 mulsaturated(x.x1, y.x1), 
                                 mulsaturated(x.x2, y.x2), 
                                 mulsaturated(x.x3, y.x3), 
                                 mulsaturated(x.x4, y.x4), 
                                 mulsaturated(x.x5, y.x5), 
                                 mulsaturated(x.x6, y.x6), 
                                 mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 mulsaturated(byte16 x, byte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu8(x, y, 16);
            }
            else
            {
                return new byte16(mulsaturated(x.x0,  y.x0), 
                                  mulsaturated(x.x1,  y.x1), 
                                  mulsaturated(x.x2,  y.x2), 
                                  mulsaturated(x.x3,  y.x3), 
                                  mulsaturated(x.x4,  y.x4), 
                                  mulsaturated(x.x5,  y.x5), 
                                  mulsaturated(x.x6,  y.x6), 
                                  mulsaturated(x.x7,  y.x7),
                                  mulsaturated(x.x8,  y.x8), 
                                  mulsaturated(x.x9,  y.x9), 
                                  mulsaturated(x.x10, y.x10), 
                                  mulsaturated(x.x11, y.x11), 
                                  mulsaturated(x.x12, y.x12), 
                                  mulsaturated(x.x13, y.x13), 
                                  mulsaturated(x.x14, y.x14), 
                                  mulsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="byte.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 mulsaturated(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epu8(x, y);
            }
            else
            {
                return new byte32(mulsaturated(x.v16_0,  y.v16_0), 
                                  mulsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort mulsaturated(ushort x, ushort y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            return (ushort)math.min(ushort.MaxValue, (uint)x * (uint)y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 mulsaturated(ushort2 x, ushort2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu16(x, y);
            }
            else
            {
                return new ushort2(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 mulsaturated(ushort3 x, ushort3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu16(x, y);
            }
            else
            {
                return new ushort3(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y), 
                                   mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 mulsaturated(ushort4 x, ushort4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu16(x, y);
            }
            else
            {
                return new ushort4(mulsaturated(x.x, y.x), 
                                   mulsaturated(x.y, y.y), 
                                   mulsaturated(x.z, y.z), 
                                   mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 mulsaturated(ushort8 x, ushort8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu16(x, y);
            }
            else
            {
                return new ushort8(mulsaturated(x.x0, y.x0), 
                                   mulsaturated(x.x1, y.x1), 
                                   mulsaturated(x.x2, y.x2), 
                                   mulsaturated(x.x3, y.x3), 
                                   mulsaturated(x.x4, y.x4), 
                                   mulsaturated(x.x5, y.x5), 
                                   mulsaturated(x.x6, y.x6), 
                                   mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ushort.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 mulsaturated(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epu16(x, y);
            }
            else
            {
                return new ushort16(mulsaturated(x.v8_0, y.v8_0), 
                                    mulsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint mulsaturated(uint x, uint y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            return (uint)math.min(uint.MaxValue, (ulong)x * (ulong)y);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 mulsaturated(uint2 x, uint2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt2(Xse.muls_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new uint2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 mulsaturated(uint3 x, uint3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.muls_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new uint3(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 mulsaturated(uint4 x, uint4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt4(Xse.muls_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new uint4(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y), 
                                 mulsaturated(x.z, y.z), 
                                 mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="uint.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 mulsaturated(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epu32(x, y);
            }
            else
            {
                return new uint8(mulsaturated(x.v4_0, y.v4_0), mulsaturated(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong mulsaturated(ulong x, ulong y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            ulong product = Common.umul128(x, y, out ulong hi);

            return product | (ulong)(-(long)tobyte(hi != 0));
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 mulsaturated(ulong2 x, ulong2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epu64(x, y);
            }
            else
            {
                return new ulong2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 mulsaturated(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epu64(x, y, 3);
            }
            else
            {
                return new ulong3(mulsaturated(x.xy, y.xy),
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="ulong.MaxValue"/> if overflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 mulsaturated(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epu64(x, y, 4);
            }
            else
            {
                return new ulong4(mulsaturated(x.xy, y.xy),
                                  mulsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte mulsaturated(sbyte x, sbyte y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            return (sbyte)math.clamp(x * y, sbyte.MinValue, sbyte.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 mulsaturated(sbyte2 x, sbyte2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi8(x, y, 2);
            }
            else
            {
                return new sbyte2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 mulsaturated(sbyte3 x, sbyte3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi8(x, y, 3);
            }
            else
            {
                return new sbyte3(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 mulsaturated(sbyte4 x, sbyte4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi8(x, y, 4);
            }
            else
            {
                return new sbyte4(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z), 
                                  mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 mulsaturated(sbyte8 x, sbyte8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi8(x, y, 8);
            }
            else
            {
                return new sbyte8(mulsaturated(x.x0, y.x0), 
                                  mulsaturated(x.x1, y.x1), 
                                  mulsaturated(x.x2, y.x2), 
                                  mulsaturated(x.x3, y.x3), 
                                  mulsaturated(x.x4, y.x4), 
                                  mulsaturated(x.x5, y.x5), 
                                  mulsaturated(x.x6, y.x6), 
                                  mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 mulsaturated(sbyte16 x, sbyte16 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi8(x, y, 16);
            }
            else
            {
                return new sbyte16(mulsaturated(x.x0,  y.x0), 
                                   mulsaturated(x.x1,  y.x1), 
                                   mulsaturated(x.x2,  y.x2), 
                                   mulsaturated(x.x3,  y.x3), 
                                   mulsaturated(x.x4,  y.x4), 
                                   mulsaturated(x.x5,  y.x5), 
                                   mulsaturated(x.x6,  y.x6), 
                                   mulsaturated(x.x7,  y.x7),
                                   mulsaturated(x.x8,  y.x8), 
                                   mulsaturated(x.x9,  y.x9), 
                                   mulsaturated(x.x10, y.x10), 
                                   mulsaturated(x.x11, y.x11), 
                                   mulsaturated(x.x12, y.x12), 
                                   mulsaturated(x.x13, y.x13), 
                                   mulsaturated(x.x14, y.x14), 
                                   mulsaturated(x.x15, y.x15));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="sbyte.MaxValue"/> if overflow occurs or <see cref="sbyte.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 mulsaturated(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epi8(x, y);
            }
            else
            {
                return new sbyte32(mulsaturated(x.v16_0,  y.v16_0), 
                                   mulsaturated(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short mulsaturated(short x, short y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }
            
            return (short)math.clamp(x * y, short.MinValue, short.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 mulsaturated(short2 x, short2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi16(x, y, 2);
            }
            else
            {
                return new short2(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 mulsaturated(short3 x, short3 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi16(x, y, 3);
            }
            else
            {
                return new short3(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 mulsaturated(short4 x, short4 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi16(x, y, 4);
            }
            else
            {
                return new short4(mulsaturated(x.x, y.x), 
                                  mulsaturated(x.y, y.y), 
                                  mulsaturated(x.z, y.z), 
                                  mulsaturated(x.w, y.w));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 mulsaturated(short8 x, short8 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi16(x, y, 8);
            }
            else
            {
                return new short8(mulsaturated(x.x0, y.x0), 
                                  mulsaturated(x.x1, y.x1), 
                                  mulsaturated(x.x2, y.x2), 
                                  mulsaturated(x.x3, y.x3), 
                                  mulsaturated(x.x4, y.x4), 
                                  mulsaturated(x.x5, y.x5), 
                                  mulsaturated(x.x6, y.x6), 
                                  mulsaturated(x.x7, y.x7));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="short.MaxValue"/> if overflow occurs or <see cref="short.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 mulsaturated(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epi16(x, y);
            }
            else
            {
                return new short16(mulsaturated(x.v8_0, y.v8_0), 
                                   mulsaturated(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int mulsaturated(int x, int y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            return (int)math.clamp((long)x * (long)y, int.MinValue, int.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 mulsaturated(int2 x, int2 y)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return RegisterConversion.ToInt2(Xse.muls_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new int2(mulsaturated(x.x, y.x), 
                                mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 mulsaturated(int3 x, int3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt3(Xse.muls_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new int3(mulsaturated(x.xy, y.xy), 
                                mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 mulsaturated(int4 x, int4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt4(Xse.muls_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new int4(mulsaturated(x.xy, y.xy), 
                                mulsaturated(x.zw, y.zw));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="int.MaxValue"/> if overflow occurs or <see cref="int.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 mulsaturated(int8 x, int8 y)
        {
            return new int8(mulsaturated(x.v4_0, y.v4_0), mulsaturated(x.v4_4, y.v4_4));
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long mulsaturated(long x, long y)
        {
            if (Xse.constexpr.IS_TRUE(x == 2))
            {
                return addsaturated(y, y);
            }
            if (Xse.constexpr.IS_TRUE(y == 2))
            {
                return addsaturated(x, x);
            }

            long lo = Xse.imul128(x, y, out long hi);
            
            return hi < -1 ? long.MinValue : hi != 0 ? long.MaxValue : lo;
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 mulsaturated(long2 x, long2 y)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.muls_epi64(x, y);
            }
            else
            {
                return new long2(mulsaturated(x.x, y.x), 
                                 mulsaturated(x.y, y.y));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 mulsaturated(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epi64(x, y, 3);
            }
            else
            {
                return new long3(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.z, y.z));
            }
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="long.MaxValue"/> if overflow occurs or <see cref="long.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 mulsaturated(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_muls_epi64(x, y, 4);
            }
            else
            {
                return new long4(mulsaturated(x.xy, y.xy), 
                                 mulsaturated(x.zw, y.zw));
            }
        }


        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float mulsaturated(float x, float y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 mulsaturated(float2 x, float2 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 mulsaturated(float3 x, float3 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 mulsaturated(float4 x, float4 y)
        {
            return math.clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="float.MaxValue"/> if overflow occurs or <see cref="float.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 mulsaturated(float8 x, float8 y)
        {
            return clamp(x * y, float.MinValue, float.MaxValue);
        }

        /// <summary>       Multiplies <paramref name="x"/> with <paramref name="y"/> and returns the result, which is clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double mulsaturated(double x, double y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 mulsaturated(double2 x, double2 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 mulsaturated(double3 x, double3 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }

        /// <summary>       Multiplies each component of <paramref name="x"/> with <paramref name="y"/> and returns the results, which are clamped to <see cref="double.MaxValue"/> if overflow occurs or <see cref="double.MinValue"/> if underflow occurs.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 mulsaturated(double4 x, double4 y)
        {
            return math.clamp(x * y, double.MinValue, double.MaxValue);
        }
    }
}