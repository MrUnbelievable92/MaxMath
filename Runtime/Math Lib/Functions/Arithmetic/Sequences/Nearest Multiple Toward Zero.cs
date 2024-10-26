using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu8(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu16(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu32(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return floormult_epu64(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI8(a, 0, elements))
                        {
                            return and_si128(a, neg_epi8(b));
                        }
                        else
                        {
                            b = dec_epi8(b);

                            return andnot_si128(b, add_epi8(a, and_si128(b, srai_epi8(a, 7))));
                        }
                    }
                    else
                    {
                        if (Arm.Neon.IsNeonSupported)
                        {
                            return mullo_epi8(b, div_epi8(a, b, elements: elements));
                        }
                        else if (elements > 8)
                        {
                            return mullo_epi8(b, div_epi8(a, b, elements: elements));
                        }
                        else
                        {
                            v128 b16 = cvtepi8_epi16(b);
                            v128 shorts;

                            if (elements > 4)
                            {
                                v128 a16 = cvtepi8_epi16(a);
                                v128 leftLo  = cvt2x2epi16_ps(a16, out v128 leftHi);
                                v128 rightLo = cvt2x2epi16_ps(b16, out v128 rightHi);
                                v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                                v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                                shorts = packs_epi32(intsLo, intsHi);
                            }
                            else
                            {
                                v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi8_ps(a), cvtepi16_ps(b16));
                                shorts = packs_epi32(ints, ints);
                            }

                            return cvtepi16_epi8(mullo_epi16(b16, shorts), elements);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI16(a, 0, elements))
                        {
                            return and_si128(a, neg_epi16(b));
                        }
                        else
                        {
                            b = dec_epi16(b);

                            return andnot_si128(b, add_epi16(a, and_si128(b, srai_epi16(a, 15))));
                        }
                    }
                    else
                    {
                        return mullo_epi16(b, div_epi16(a, b, elements: elements));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI32(a, 0, elements))
                        {
                            return and_si128(a, neg_epi32(b));
                        }
                        else
                        {
                            b = dec_epi32(b);

                            return andnot_si128(b, add_epi32(a, and_si128(b, srai_epi32(a, 31))));
                        }
                    }
                    else
                    {
                        return mullo_epi32(b, div_epi32(a, b, elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI64(a, 0))
                        {
                            return and_si128(a, neg_epi64(b));
                        }
                        else
                        {
                            b = dec_epi64(b);

                            return andnot_si128(b, add_epi64(a, and_si128(b, srai_epi64(a, 63))));
                        }
                    }
                    else
                    {
                        return mullo_epi64(b, div_epi64(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu8(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu16(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu32(a, b, pow2);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_floormult_epu64(a, b, elements, pow2);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI8(a, 0))
                        {
                            return Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                        }
                        else
                        {
                            b = mm256_dec_epi8(b);

                            return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi8(a, Avx2.mm256_and_si256(b, mm256_srai_epi8(a, 7))));
                        }
                    }
                    else
                    {
                        return mm256_mullo_epi8(b, mm256_div_epi8(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI16(a, 0))
                        {
                            return Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                        }
                        else
                        {
                            b = mm256_dec_epi16(b);

                            return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi16(a, Avx2.mm256_and_si256(b, Avx2.mm256_srai_epi16(a, 15))));
                        }
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi16(b, mm256_div_epi16(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI32(a, 0))
                        {
                            return Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                        }
                        else
                        {
                            b = mm256_dec_epi32(b);

                            return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi32(a, Avx2.mm256_and_si256(b, Avx2.mm256_srai_epi32(a, 31))));
                        }
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi32(b, mm256_div_epi32(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        if (nonNegative || constexpr.ALL_GE_EPI64(a, 0, elements))
                        {
                            return Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                        }
                        else
                        {
                            b = mm256_dec_epi64(b);

                            return Avx2.mm256_andnot_si256(b, Avx2.mm256_add_epi64(a, Avx2.mm256_and_si256(b, mm256_srai_epi64(a, 63, elements))));
                        }
                    }
                    else
                    {
                        return mm256_mullo_epi64(b, mm256_div_epi64(a, b, elements: elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_ps(b, trunc_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_trunc_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 truncmult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_pd(b, trunc_pd(div_pd(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_truncmult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_trunc_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 truncmultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 truncmultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    return x & (Int128)(0 - n);
                }
                else
                {
                    n--;

                    return andnot(x + ((Int128)n & (x >> 127)), (Int128)n);
                }
            }
            else
            {
                return (Int128)n * (x / (Int128)n);
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong truncmultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 truncmultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 truncmultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 truncmultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long truncmultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    return x & (long)(0 - n);
                }
                else
                {
                    n--;

                    return andnot(x + ((long)n & (x >> 63)), (long)n);
                }
            }
            else
            {
                return (long)n * (x / (long)n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 truncmultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 truncmultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(truncmultiple(x.xy, n.xy, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 truncmultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(truncmultiple(x.xy, n.xy, promises), truncmultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint truncmultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 truncmultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 truncmultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 truncmultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 truncmultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int truncmultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.ispow2(n)))
            {
                if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
                {
                    return x & (int)(0 - n);
                }
                else
                {
                    n--;

                    return andnot(x + ((int)n & (x >> 31)), (int)n);
                }
            }
            else
            {
                return (int)n * (x / (int)n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 truncmultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.truncmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 truncmultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.truncmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 truncmultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.truncmult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 truncmultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(truncmultiple(x.v4_0, n.v4_0, promises), truncmultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort truncmultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 truncmultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 truncmultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 truncmultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 truncmultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 truncmultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short truncmultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)truncmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 truncmultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 truncmultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 truncmultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 truncmultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(truncmultiple(x.x0, n.x0, promises),
                                  truncmultiple(x.x1, n.x1, promises),
                                  truncmultiple(x.x2, n.x2, promises),
                                  truncmultiple(x.x3, n.x3, promises),
                                  truncmultiple(x.x4, n.x4, promises),
                                  truncmultiple(x.x5, n.x5, promises),
                                  truncmultiple(x.x6, n.x6, promises),
                                  truncmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 truncmultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(truncmultiple(x.v8_0, n.v8_0, promises), truncmultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte truncmultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 truncmultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 truncmultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 truncmultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 truncmultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 truncmultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 truncmultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            return floormultiple(x, n, promises);
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte truncmultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)truncmultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 truncmultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 truncmultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 truncmultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(truncmultiple(x.x, n.x, promises), truncmultiple(x.y, n.y, promises), truncmultiple(x.z, n.z, promises), truncmultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 truncmultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(truncmultiple(x.x0, n.x0, promises),
                                  truncmultiple(x.x1, n.x1, promises),
                                  truncmultiple(x.x2, n.x2, promises),
                                  truncmultiple(x.x3, n.x3, promises),
                                  truncmultiple(x.x4, n.x4, promises),
                                  truncmultiple(x.x5, n.x5, promises),
                                  truncmultiple(x.x6, n.x6, promises),
                                  truncmultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 truncmultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.truncmult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(truncmultiple(x.x0,  n.x0,  promises),
                                   truncmultiple(x.x1,  n.x1,  promises),
                                   truncmultiple(x.x2,  n.x2,  promises),
                                   truncmultiple(x.x3,  n.x3,  promises),
                                   truncmultiple(x.x4,  n.x4,  promises),
                                   truncmultiple(x.x5,  n.x5,  promises),
                                   truncmultiple(x.x6,  n.x6,  promises),
                                   truncmultiple(x.x7,  n.x7,  promises),
                                   truncmultiple(x.x8,  n.x8,  promises),
                                   truncmultiple(x.x9,  n.x9,  promises),
                                   truncmultiple(x.x10, n.x10, promises),
                                   truncmultiple(x.x11, n.x11, promises),
                                   truncmultiple(x.x12, n.x12, promises),
                                   truncmultiple(x.x13, n.x13, promises),
                                   truncmultiple(x.x14, n.x14, promises),
                                   truncmultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 truncmultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_truncmult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(truncmultiple(x.v16_0, n.v16_0, promises), truncmultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float truncmultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * math.trunc(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 truncmultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.truncmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new float2(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 truncmultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.truncmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 3));
            }
            else
            {
                return new float3(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y), truncmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 truncmultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.truncmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 4));
            }
            else
            {
                return new float4(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y), truncmultiple(x.z, m.z), truncmultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 truncmultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_truncmult_ps(x, m);
            }
            else
            {
                return new float8(truncmultiple(x.v4_0, m.v4_0), truncmultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double truncmultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * math.trunc(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 truncmultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);
            
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.truncmult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new double2(truncmultiple(x.x, m.x), truncmultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 truncmultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_truncmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double3(truncmultiple(x.xy, m.xy), truncmultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest multiple toward 0 of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 truncmultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_truncmult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double4(truncmultiple(x.xy, m.xy), truncmultiple(x.zw, m.zw));
            }
        }
    }
}