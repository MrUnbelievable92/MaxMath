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
            public static v128 minmag_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPI8(a, 0, elements) && constexpr.ALL_LE_EPI8(b, 0, elements)) 
                    {
                        return max_epi8(a, b);
                    }
                    if (constexpr.ALL_GE_EPI8(a, 0, elements) && constexpr.ALL_GE_EPI8(b, 0, elements)) 
                    {
                        return min_epi8(a, b);
                    }


                    v128 cmp = Sse2.adds_epi8(a, b);
                    minmax_epi8(a, b, out v128 min, out v128 max, elements);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_epi8(min, max, cmp);
                    }
                    else
                    {
                        return blendv_si128(min, max, Sse2.cmpgt_epi8(Sse2.setzero_si128(), cmp));
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 minmag_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPI16(a, 0, elements) && constexpr.ALL_LE_EPI16(b, 0, elements)) 
                    {
                        return Sse2.max_epi16(a, b);
                    }
                    if (constexpr.ALL_GE_EPI16(a, 0, elements) && constexpr.ALL_GE_EPI16(b, 0, elements)) 
                    {
                        return Sse2.min_epi16(a, b);
                    }


                    v128 cmp = Sse2.adds_epi16(a, b);
                    minmax_epi16(a, b, out v128 min, out v128 max);

                    return blendv_si128(min, max, Sse2.srai_epi16(cmp, 15));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 minmag_epi32(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPI32(a, 0, elements) && constexpr.ALL_LE_EPI32(b, 0, elements)) 
                    {
                        return max_epi32(a, b);
                    }
                    if (constexpr.ALL_GE_EPI32(a, 0, elements) && constexpr.ALL_GE_EPI32(b, 0, elements)) 
                    {
                        return min_epi32(a, b);
                    }


                    minmax_epi32(a, b, out v128 min, out v128 max);

                    v128 cmp;
                    if (promiseNoOverflow)
                    {
                        cmp = Sse2.add_epi32(a, b);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            v128 minAbs = abs_epi32(min, elements);
                            v128 maxAbs = abs_epi32(max, elements);

                            return blendv_si128(max, min, Sse2.cmpgt_epi32(maxAbs, minAbs));
                        }
                        else
                        {
                            if (elements == 2)
                            {
                                cmp = Sse2.add_epi64(cvtepi32_epi64(a), cvtepi32_epi64(b));
                                cmp = Sse2.shuffle_epi32(cmp, Sse.SHUFFLE(0, 0, 3, 1));
                            }
                            else
                            {
                                v128 a64Lo = cvt2x2epi32_epi64(a, out v128 a64Hi);
                                v128 b64Lo = cvt2x2epi32_epi64(b, out v128 b64Hi);
                            
                                v128 cmp64Lo = Sse2.add_epi64(a64Lo, b64Lo);
                                v128 cmp64Hi = Sse2.add_epi64(a64Hi, b64Hi);
                            
                                cmp = Sse.shuffle_ps(cmp64Lo, cmp64Hi, Sse.SHUFFLE(3, 1, 3, 1));
                            }
                        }
                    }

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_ps(min, max, cmp);
                    }
                    else
                    {
                        return blendv_si128(min, max, Sse2.srai_epi32(cmp, 31));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 minmag_epi64(v128 a, v128 b, bool promiseNoOverflow = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_EPI64(a, 0) && constexpr.ALL_LE_EPI64(b, 0)) 
                    {
                        return max_epi64(a, b);
                    }
                    if (constexpr.ALL_GE_EPI64(a, 0) && constexpr.ALL_GE_EPI64(b, 0)) 
                    {
                        return min_epi64(a, b);
                    }


                    v128 cmp = promiseNoOverflow ? Sse2.add_epi64(a, b) : adds_epi64(a, b);
                    minmax_epi64(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_pd(min, max, cmp);
                    }
                    else
                    {
                        return blendv_si128(min, max, srai_epi64(cmp, 63));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 minmag_ps(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_PS(a, 0, elements) && constexpr.ALL_LE_PS(b, 0, elements)) 
                    {
                        return Sse.max_ps(a, b);
                    }
                    if (constexpr.ALL_GE_PS(a, 0, elements) && constexpr.ALL_GE_PS(b, 0, elements)) 
                    {
                        return Sse.min_ps(a, b);
                    }


                    v128 cmp = Sse.add_ps(a, b);
                    minmax_ps(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_ps(min, max, cmp);
                    }
                    else
                    {
                        return blendv_ps(min, max, Sse2.srai_epi32(cmp, 31));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 minmag_pd(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_LE_PD(a, 0) && constexpr.ALL_LE_PD(b, 0)) 
                    {
                        return Sse2.max_pd(a, b);
                    }
                    if (constexpr.ALL_GE_PD(a, 0) && constexpr.ALL_GE_PD(b, 0)) 
                    {
                        return Sse2.min_pd(a, b);
                    }


                    v128 cmp = Sse2.add_pd(a, b);
                    minmax_pd(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        return Sse4_1.blendv_pd(min, max, cmp);
                    }
                    else
                    {
                        return blendv_ps(min, max, srai_epi64(cmp, 63));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI8(a, 0) && constexpr.ALL_LE_EPI8(b, 0)) 
                    {
                        return Avx2.mm256_max_epi8(a, b);
                    }
                    if (constexpr.ALL_GE_EPI8(a, 0) && constexpr.ALL_GE_EPI8(b, 0)) 
                    {
                        return Avx2.mm256_min_epi8(a, b);
                    }


                    v256 cmp = Avx2.mm256_adds_epi8(a, b);
                    mm256_minmax_epi8(a, b, out v256 min, out v256 max);

                    return Avx2.mm256_blendv_epi8(min, max, cmp);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI16(a, 0) && constexpr.ALL_LE_EPI16(b, 0)) 
                    {
                        return Avx2.mm256_max_epi16(a, b);
                    }
                    if (constexpr.ALL_GE_EPI16(a, 0) && constexpr.ALL_GE_EPI16(b, 0)) 
                    {
                        return Avx2.mm256_min_epi16(a, b);
                    }


                    v256 cmp = Avx2.mm256_adds_epi16(a, b);
                    mm256_minmax_epi16(a, b, out v256 min, out v256 max);
                    
                    return Avx2.mm256_blendv_epi8(min, max, Avx2.mm256_srai_epi16(cmp, 15));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_epi32(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI32(a, 0) && constexpr.ALL_LE_EPI32(b, 0)) 
                    {
                        return Avx2.mm256_max_epi32(a, b);
                    }
                    if (constexpr.ALL_GE_EPI32(a, 0) && constexpr.ALL_GE_EPI32(b, 0)) 
                    {
                        return Avx2.mm256_min_epi32(a, b);
                    }


                    mm256_minmax_epi32(a, b, out v256 min, out v256 max);

                    if (promiseNoOverflow)
                    {
                        v256 cmp = Avx2.mm256_add_epi32(a, b);

                        return Avx.mm256_blendv_ps(min, max, cmp);
                    }
                    else
                    {
                        v256 minAbs = mm256_abs_epi32(min);
                        v256 maxAbs = mm256_abs_epi32(max);
                        
                        return mm256_blendv_si256(max, min, Avx2.mm256_cmpgt_epi32(maxAbs, minAbs));
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_epi64(v256 a, v256 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPI64(a, 0, elements) && constexpr.ALL_LE_EPI64(b, 0, elements)) 
                    {
                        return mm256_max_epi64(a, b);
                    }
                    if (constexpr.ALL_GE_EPI64(a, 0, elements) && constexpr.ALL_GE_EPI64(b, 0, elements)) 
                    {
                        return mm256_min_epi64(a, b);
                    }


                    v256 cmp = promiseNoOverflow ? Avx2.mm256_add_epi64(a, b) : mm256_adds_epi64(a, b, elements);
                    mm256_minmax_epi64(a, b, out v256 min, out v256 max, elements);

                    return Avx.mm256_blendv_pd(min, max, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.ALL_LE_PS(a, 0) && constexpr.ALL_LE_PS(b, 0)) 
                    {
                        return Avx.mm256_max_ps(a, b);
                    }
                    if (constexpr.ALL_GE_PS(a, 0) && constexpr.ALL_GE_PS(b, 0)) 
                    {
                        return Avx.mm256_min_ps(a, b);
                    }


                    v256 cmp = Avx.mm256_add_ps(a, b);
                    mm256_minmax_ps(a, b, out v256 min, out v256 max);

                    return Avx.mm256_blendv_ps(min, max, cmp);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_minmag_pd(v256 a, v256 b, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    if (constexpr.ALL_LE_PD(a, 0, elements) && constexpr.ALL_LE_PD(b, 0, elements)) 
                    {
                        return Avx.mm256_max_pd(a, b);
                    }
                    if (constexpr.ALL_GE_PD(a, 0, elements) && constexpr.ALL_GE_PD(b, 0, elements)) 
                    {
                        return Avx.mm256_min_pd(a, b);
                    }


                    v256 cmp = Avx.mm256_add_pd(a, b);
                    mm256_minmax_pd(a, b, out v256 min, out v256 max);

                    return Avx.mm256_blendv_pd(min, max, cmp);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the minimum of two <see cref="Int128"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 minmag(Int128 a, Int128 b)
        {
            return select(a, b, (UInt128)abs(a) > (UInt128)abs(b));
        }


        /// <summary>       Returns the minimum of two <see cref="sbyte"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte minmag(sbyte a, sbyte b)
        {
            return abs(a) > abs(b) ? b : a;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 minmag(sbyte2 a, sbyte2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi8(a, b, 2);
            }
            else
            {
                return new sbyte2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 minmag(sbyte3 a, sbyte3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi8(a, b, 3);
            }
            else
            {
                return new sbyte3(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 minmag(sbyte4 a, sbyte4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi8(a, b, 4);
            }
            else
            {
                return new sbyte4(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z), minmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 minmag(sbyte8 a, sbyte8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi8(a, b, 8);
            }
            else
            {
                return new sbyte8(minmag(a.x0, b.x0), minmag(a.x1, b.x1), minmag(a.x2, b.x2), minmag(a.x3, b.x3), minmag(a.x4, b.x4), minmag(a.x5, b.x5), minmag(a.x6, b.x6), minmag(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 minmag(sbyte16 a, sbyte16 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi8(a, b, 16);
            }
            else
            {
                return new sbyte16(minmag(a.x0, b.x0), minmag(a.x1, b.x1), minmag(a.x2, b.x2), minmag(a.x3, b.x3), minmag(a.x4, b.x4), minmag(a.x5, b.x5), minmag(a.x6, b.x6), minmag(a.x7, b.x7), minmag(a.x8, b.x8), minmag(a.x9, b.x9), minmag(a.x10, b.x10), minmag(a.x11, b.x11), minmag(a.x12, b.x12), minmag(a.x13, b.x13), minmag(a.x14, b.x14), minmag(a.x15, b.x15));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.sbyte32"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 minmag(sbyte32 a, sbyte32 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_minmag_epi8(a, b);
            }
            else
            {
                return new sbyte32(minmag(a.v16_0, b.v16_0), minmag(a.v16_16, b.v16_16));
            }
        }


        /// <summary>       Returns the minimum of two <see cref="short"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short minmag(short a, short b)
        {
            return abs(a) > abs(b) ? b : a;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 minmag(short2 a, short2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi16(a, b, 2);
            }
            else
            {
                return new short2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 minmag(short3 a, short3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi16(a, b, 3);
            }
            else
            {
                return new short3(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 minmag(short4 a, short4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi16(a, b, 4);
            }
            else
            {
                return new short4(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z), minmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 minmag(short8 a, short8 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi16(a, b, 8);
            }
            else
            {
                return new short8(minmag(a.x0, b.x0), minmag(a.x1, b.x1), minmag(a.x2, b.x2), minmag(a.x3, b.x3), minmag(a.x4, b.x4), minmag(a.x5, b.x5), minmag(a.x6, b.x6), minmag(a.x7, b.x7));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.short16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 minmag(short16 a, short16 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_minmag_epi16(a, b);
            }
            else
            {
                return new short16(minmag(a.v8_0, b.v8_0), minmag(a.v8_8, b.v8_8));
            }
        }

        
        /// <summary>       Returns the minimum of two <see cref="int"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int minmag(int a, int b)
        {
            return math.abs(a) > math.abs(b) ? b : a;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="int2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 minmag(int2 a, int2 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.minmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noOverFlow.Promises(Promise.NoOverflow), 2));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new int2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="int3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 minmag(int3 a, int3 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.minmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noOverFlow.Promises(Promise.NoOverflow), 3));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new int3(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="int4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 minmag(int4 a, int4 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.minmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), noOverFlow.Promises(Promise.NoOverflow), 4));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new int4(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z), minmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.int8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 minmag(int8 a, int8 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_minmag_epi32(a, b, noOverFlow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(minmag(a.v4_0, b.v4_0), minmag(a.v4_4, b.v4_4));
            }
        }

        
        /// <summary>       Returns the minimum of two <see cref="long"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long minmag(long a, long b)
        {
            return math.abs(a) > math.abs(b) ? b : a;
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 minmag(long2 a, long2 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 minmag(long3 a, long3 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_minmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new long3(minmag(a.xy, b.xy), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.long4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 minmag(long4 a, long4 b, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_minmag_epi64(a, b, noOverFlow.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new long4(minmag(a.xy, b.xy), minmag(a.zw, b.zw));
            }
        }

        
        /// <summary>       Returns the minimum of two <see cref="float"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float minmag(float a, float b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 1).Float0;
            }
            else
            {
                return math.abs(a) > math.abs(b) ? b : a;
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="float2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 minmag(float2 a, float2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat2(Xse.minmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 2));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new float2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="float3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 minmag(float3 a, float3 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.minmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 3));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new float3(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="float4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 minmag(float4 a, float4 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(Xse.minmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), 4));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new float4(minmag(a.x, b.x), minmag(a.y, b.y), minmag(a.z, b.z), minmag(a.w, b.w));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="MaxMath.float8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 minmag(float8 a, float8 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_minmag_ps(a, b);
            }
            else
            {
                return new float8(minmag(a.v4_0, b.v4_0), minmag(a.v4_4, b.v4_4));
            }
        }

        
        /// <summary>       Returns the minimum of two <see cref="double"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>), the sign of the return value is undefined.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double minmag(double a, double b)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.minmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)).Double0;
            }
            else
            {
                return math.abs(a) > math.abs(b) ? b : a;
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="double2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 minmag(double2 a, double2 b)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToDouble2(Xse.minmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b)));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new double2(minmag(a.x, b.x), minmag(a.y, b.y));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="double3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 minmag(double3 a, double3 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_minmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), 3));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new double3(minmag(a.xy, b.xy), minmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum of two <see cref="double4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return value is undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 minmag(double4 a, double4 b)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_minmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), 4));
            }
            else if (Arm.Neon.IsNeonSupported)
            {
                return math.select(a, b, math.abs(a) > math.abs(b));
            }
            else
            {
                return new double4(minmag(a.xy, b.xy), minmag(a.zw, b.zw));
            }
        }
    }
}