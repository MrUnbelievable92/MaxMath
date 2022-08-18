using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi8(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = Sse2.adds_epi8(a, b);
                    minmax_epi8(a, b, out v128 min, out v128 max, elements);

                    if (Sse4_1.IsSse41Supported)
                    {
                        minmag = Sse4_1.blendv_epi8(min, max, cmp);
                        maxmag = Sse4_1.blendv_epi8(max, min, cmp);
                    }
                    else
                    {
                        cmp = Sse2.cmpgt_epi8(Sse2.setzero_si128(), cmp);

                        minmag = blendv_si128(min, max, cmp);
                        maxmag = blendv_si128(max, min, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi16(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = Sse2.adds_epi16(a, b);
                    minmax_epi16(a, b, out v128 min, out v128 max);
                    
                    cmp = Sse2.srai_epi16(cmp, 15);
                    
                    minmag = blendv_si128(min, max, cmp);
                    maxmag = blendv_si128(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi32(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
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
                            cmp = Sse2.cmpgt_epi32(maxAbs, minAbs);

                            minmag = blendv_si128(max, min, cmp);
                            maxmag = blendv_si128(min, max, cmp);

                            return;
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
                        minmag = Sse4_1.blendv_ps(min, max, cmp);
                        maxmag = Sse4_1.blendv_ps(max, min, cmp);
                    }
                    else
                    {
                        cmp = Sse2.srai_epi32(cmp, 31);

                        minmag = blendv_si128(min, max, cmp);
                        maxmag = blendv_si128(max, min, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_epi64(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag, bool promiseNoOverflow = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = promiseNoOverflow ? Sse2.add_epi64(a, b) : adds_epi64(a, b);
                    minmax_epi64(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        minmag = Sse4_1.blendv_pd(min, max, cmp);
                        maxmag = Sse4_1.blendv_pd(max, min, cmp);
                    }
                    else
                    {
                        cmp = srai_epi64(cmp, 63);

                        minmag = blendv_si128(min, max, cmp);
                        maxmag = blendv_si128(max, min, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_ps(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = Sse.add_ps(a, b);
                    minmax_ps(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        minmag = Sse4_1.blendv_ps(min, max, cmp);
                        maxmag = Sse4_1.blendv_ps(max, min, cmp);
                    }
                    else
                    {
                        cmp = Sse2.srai_epi32(cmp, 31);

                        minmag = blendv_ps(min, max, cmp);
                        maxmag = blendv_ps(max, min, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void minmaxmag_pd(v128 a, v128 b, [NoAlias] out v128 minmag, [NoAlias] out v128 maxmag)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 cmp = Sse2.add_pd(a, b);
                    minmax_pd(a, b, out v128 min, out v128 max);

                    if (Sse4_1.IsSse41Supported)
                    {
                        minmag = Sse4_1.blendv_pd(min, max, cmp);
                        maxmag = Sse4_1.blendv_pd(max, min, cmp);
                    }
                    else
                    {
                        cmp = srai_epi64(cmp, 63);

                        minmag = blendv_ps(min, max, cmp);
                        maxmag = blendv_ps(max, min, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi8(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_adds_epi8(a, b);
                    mm256_minmax_epi8(a, b, out v256 min, out v256 max);

                    minmag = Avx2.mm256_blendv_epi8(min, max, cmp);
                    maxmag = Avx2.mm256_blendv_epi8(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi16(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_adds_epi16(a, b);
                    mm256_minmax_epi16(a, b, out v256 min, out v256 max);
                    cmp = Avx2.mm256_srai_epi16(cmp, 15);

                    minmag = mm256_blendv_si256(min, max, cmp);
                    maxmag = mm256_blendv_si256(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi32(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    mm256_minmax_epi32(a, b, out v256 min, out v256 max);

                    if (promiseNoOverflow)
                    {
                        v256 cmp = Avx2.mm256_add_epi32(a, b);

                        minmag = Avx.mm256_blendv_ps(min, max, cmp);
                        maxmag = Avx.mm256_blendv_ps(max, min, cmp);
                    }
                    else
                    {
                        v256 minAbs = mm256_abs_epi32(min);
                        v256 maxAbs = mm256_abs_epi32(max);
                        
                        v256 cmp = Avx2.mm256_cmpgt_epi32(maxAbs, minAbs);

                        minmag = mm256_blendv_si256(max, min, cmp);
                        maxmag = mm256_blendv_si256(min, max, cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_epi64(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = promiseNoOverflow ? Avx2.mm256_add_epi64(a, b) : mm256_adds_epi64(a, b, elements);
                    mm256_minmax_epi64(a, b, out v256 min, out v256 max, elements);

                    minmag = Avx.mm256_blendv_pd(min, max, cmp);
                    maxmag = Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_ps(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 cmp = Avx.mm256_add_ps(a, b);
                    mm256_minmax_ps(a, b, out v256 min, out v256 max);

                    minmag = Avx.mm256_blendv_ps(min, max, cmp);
                    maxmag = Avx.mm256_blendv_ps(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void mm256_minmaxmag_pd(v256 a, v256 b, [NoAlias] out v256 minmag, [NoAlias] out v256 maxmag)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 cmp = Avx.mm256_add_pd(a, b);
                    mm256_minmax_pd(a, b, out v256 min, out v256 max);

                    minmag = Avx.mm256_blendv_pd(min, max, cmp);
                    maxmag = Avx.mm256_blendv_pd(max, min, cmp);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte2 a, sbyte2 b, [NoAlias] out sbyte2 minmag, [NoAlias] out sbyte2 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 2);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte3 a, sbyte3 b, [NoAlias] out sbyte3 minmag, [NoAlias] out sbyte3 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 3);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte4 a, sbyte4 b, [NoAlias] out sbyte4 minmag, [NoAlias] out sbyte4 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 4);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte8 a, sbyte8 b, [NoAlias] out sbyte8 minmag, [NoAlias] out sbyte8 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 8);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte16 a, sbyte16 b, [NoAlias] out sbyte16 minmag, [NoAlias] out sbyte16 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi8(a, b, out v128 min, out v128 max, 16);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.sbyte32"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(sbyte32 a, sbyte32 b, [NoAlias] out sbyte32 minmag, [NoAlias] out sbyte32 maxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi8(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v16_0,  b.v16_0,  out sbyte16 minLo, out sbyte16 maxLo);
                minmaxmag(a.v16_16, b.v16_16, out sbyte16 minHi, out sbyte16 maxHi);

                minmag = new sbyte32(minLo, minHi);
                maxmag = new sbyte32(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short2 a, short2 b, [NoAlias] out short2 minmag, [NoAlias] out short2 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short3 a, short3 b, [NoAlias] out short3 minmag, [NoAlias] out short3 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short4 a, short4 b, [NoAlias] out short4 minmag, [NoAlias] out short4 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short8 a, short8 b, [NoAlias] out short8 minmag, [NoAlias] out short8 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi16(a, b, out v128 min, out v128 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.short16"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(short16 a, short16 b, [NoAlias] out short16 minmag, [NoAlias] out short16 maxmag)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi16(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v8_0, b.v8_0, out short8 minLo, out short8 maxLo);
                minmaxmag(a.v8_8, b.v8_8, out short8 minHi, out short8 maxHi);

                minmag = new short16(minLo, minHi);
                maxmag = new short16(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.int2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int2 a, int2 b, [NoAlias] out int2 minmag, [NoAlias] out int2 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 2);

                minmag = RegisterConversion.ToType<int2>(min);
                maxmag = RegisterConversion.ToType<int2>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.int3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int3 a, int3 b, [NoAlias] out int3 minmag, [NoAlias] out int3 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 3);

                minmag = RegisterConversion.ToType<int3>(min);
                maxmag = RegisterConversion.ToType<int3>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.int4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int4 a, int4 b, [NoAlias] out int4 minmag, [NoAlias] out int4 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi32(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow), 4);

                minmag = RegisterConversion.ToType<int4>(min);
                maxmag = RegisterConversion.ToType<int4>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.int8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(int8 a, int8 b, [NoAlias] out int8 minmag, [NoAlias] out int8 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi32(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v4_0, b.v4_0, out int4 minLo, out int4 maxLo);
                minmaxmag(a.v4_4, b.v4_4, out int4 minHi, out int4 maxHi);

                minmag = new int8(minLo, minHi);
                maxmag = new int8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long2 a, long2 b, [NoAlias] out long2 minmag, [NoAlias] out long2 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_epi64(a, b, out v128 min, out v128 max, noOverFlow.Promises(Promise.NoOverflow));

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long3 a, long3 b, [NoAlias] out long3 minmag, [NoAlias] out long3 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi64(a, b, out v256 min, out v256 max, noOverFlow.Promises(Promise.NoOverflow), 3);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.xy, b.xy, out long2 minLo, out long2 maxLo);

                minmag = new long3(minLo, maxmath.minmag(a.z, b.z));
                maxmag = new long3(maxLo, maxmath.maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.long4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any <paramref name="a"/> + <paramref name="b"/> component pair that overflows.    </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(long4 a, long4 b, [NoAlias] out long4 minmag, [NoAlias] out long4 maxmag, Promise noOverFlow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                Xse.mm256_minmaxmag_epi64(a, b, out v256 min, out v256 max, noOverFlow.Promises(Promise.NoOverflow));

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.xy, b.xy, out long2 minLo, out long2 maxLo);
                minmaxmag(a.zw, b.zw, out long2 minHi, out long2 maxHi);

                minmag = new long4(minLo, minHi);
                maxmag = new long4(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.float2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float2 a, float2 b, [NoAlias] out float2 minmag, [NoAlias] out float2 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToType<float2>(min);
                maxmag = RegisterConversion.ToType<float2>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.float3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float3 a, float3 b, [NoAlias] out float3 minmag, [NoAlias] out float3 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToType<float3>(min);
                maxmag = RegisterConversion.ToType<float3>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.float4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float4 a, float4 b, [NoAlias] out float4 minmag, [NoAlias] out float4 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToType<float4>(min);
                maxmag = RegisterConversion.ToType<float4>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.float8"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(float8 a, float8 b, [NoAlias] out float8 minmag, [NoAlias] out float8 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_ps(a, b, out v256 min, out v256 max);

                minmag = min;
                maxmag = max;
            }
            else
            {
                minmaxmag(a.v4_0, b.v4_0, out float4 minLo, out float4 maxLo);
                minmaxmag(a.v4_4, b.v4_4, out float4 minHi, out float4 maxHi);

                minmag = new float8(minLo, minHi);
                maxmag = new float8(maxLo, maxHi);
            }
        }


        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.double2"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double2 a, double2 b, [NoAlias] out double2 minmag, [NoAlias] out double2 maxmag)
        {
            if (Sse2.IsSse2Supported)
            {
                Xse.minmaxmag_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), out v128 min, out v128 max);

                minmag = RegisterConversion.ToType<double2>(min);
                maxmag = RegisterConversion.ToType<double2>(max);
            }
            else
            {
                minmag = maxmath.minmag(a, b);
                maxmag = maxmath.maxmag(a, b);
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.double3"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double3 a, double3 b, [NoAlias] out double3 minmag, [NoAlias] out double3 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 min, out v256 max);

                minmag = RegisterConversion.ToType<double3>(min);
                maxmag = RegisterConversion.ToType<double3>(max);
            }
            else
            {
                minmaxmag(a.xy, b.xy, out double2 minLo, out double2 maxLo);

                minmag = new double3(minLo, maxmath.minmag(a.z, b.z));
                maxmag = new double3(maxLo, maxmath.maxmag(a.z, b.z));
            }
        }

        /// <summary>       Returns the componentwise minimum '<paramref name="minmag"/>' and maximum '<paramref name="maxmag"/>' of two <see cref="MaxMath.double4"/>s with regard to their magnitude. If abs(<paramref name="a"/>) is equal to abs(<paramref name="b"/>) for a component, the sign of the return values are undefined for that component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void minmaxmag(double4 a, double4 b, [NoAlias] out double4 minmag, [NoAlias] out double4 maxmag)
        {
            if (Avx.IsAvxSupported)
            {
                Xse.mm256_minmaxmag_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), out v256 min, out v256 max);

                minmag = RegisterConversion.ToType<double4>(min);
                maxmag = RegisterConversion.ToType<double4>(max);
            }
            else
            {
                minmaxmag(a.xy, b.xy, out double2 minLo, out double2 maxLo);
                minmaxmag(a.zw, b.zw, out double2 minHi, out double2 maxHi);

                minmag = new double4(minLo, minHi);
                maxmag = new double4(maxLo, maxHi);
            }
        }
    }
}