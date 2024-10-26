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
            public static v128 floormult_epu8(v128 a, v128 b, byte elements = 16, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        return and_si128(a, neg_epi8(b));
                    }
                    else
                    {
                        if (Arm.Neon.IsNeonSupported)
                        {
                            return mullo_epi8(b, div_epu8(a, b, elements));
                        }
                        else if (elements > 8)
                        {
                            return mullo_epi8(b, div_epu8(a, b, elements));
                        }
                        else
                        {
                            v128 b16 = cvtepu8_epi16(b);
                            v128 shorts;

                            if (elements > 4)
                            {
                                v128 a16 = cvtepu8_epi16(a);
                                v128 leftLo  = cvt2x2epu16_ps(a16, out v128 leftHi);
                                v128 rightLo = cvt2x2epu16_ps(b16, out v128 rightHi);
                                v128 intsLo = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftLo, rightLo);
                                v128 intsHi = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(leftHi, rightHi);

                                shorts = packs_epi32(intsLo, intsHi);
                            }
                            else
                            {
                                v128 ints = DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepu8_ps(a), cvtepu16_ps(b16));
                                shorts = packs_epi32(ints, ints);
                            }

                            return cvtepi16_epi8(mullo_epi16(b16, shorts), elements);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu16(v128 a, v128 b, byte elements = 8, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        return and_si128(a, neg_epi16(b));
                    }
                    else
                    {
                        return mullo_epi16(b, div_epu16(a, b, elements));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu32(v128 a, v128 b, byte elements = 4, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        return and_si128(a, neg_epi32(b));
                    }
                    else
                    {
                        return mullo_epi32(b, div_epu32(a, b, elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epu64(v128 a, v128 b, bool pow2 = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        return and_si128(a, neg_epi64(b));
                    }
                    else
                    {
                        return mullo_epi64(b, div_epu64(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi8(v128 a, v128 b, byte elements = 16, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b, elements))
                    {
                        return and_si128(a, neg_epi8(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI8(a, 0, elements)))
                        {
                            a = sub_epi8(a, and_si128(dec_epi8(b), srai_epi8(a, 7)));
                        }

                        
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
            public static v128 floormult_epi16(v128 a, v128 b, byte elements = 8, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b, elements))
                    {
                        return and_si128(a, neg_epi16(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI16(a, 0, elements)))
                        {
                            a = sub_epi16(a, and_si128(dec_epi16(b), srai_epi16(a, 15)));
                        }

                        return mullo_epi16(b, div_epi16(a, b, elements: elements));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi32(v128 a, v128 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b, elements))
                    {
                        return and_si128(a, neg_epi32(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI32(a, 0, elements)))
                        {
                            a = sub_epi32(a, and_si128(dec_epi32(b), srai_epi32(a, 31)));
                        }

                        return mullo_epi32(b, div_epi32(a, b, elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_epi64(v128 a, v128 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b))
                    {
                        return and_si128(a, neg_epi64(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI64(a, 0)))
                        {
                            a = sub_epi64(a, and_si128(dec_epi64(b), srai_epi64(a, 63)));
                        }

                        return mullo_epi64(b, div_epi64(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu8(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                    }
                    else
                    {
                        return mm256_mullo_epi8(b, mm256_div_epu8(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu16(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi16(b, mm256_div_epu16(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu32(v256 a, v256 b, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi32(b, mm256_div_epu32(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epu64(v256 a, v256 b, byte elements = 4, bool pow2 = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                    }
                    else
                    {
                        return mm256_mullo_epi64(b, mm256_div_epu64(a, b, elements: elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi8(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU8(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi8(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI8(a, 0)))
                        {
                            a = Avx2.mm256_sub_epi8(a, Avx2.mm256_and_si256(mm256_dec_epi8(b), mm256_srai_epi8(a, 7)));
                        }

                        return mm256_mullo_epi8(b, mm256_div_epi8(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi16(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU16(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi16(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI16(a, 0)))
                        {
                            a = Avx2.mm256_sub_epi16(a, Avx2.mm256_and_si256(mm256_dec_epi16(b), mm256_srai_epi16(a, 15)));
                        }

                        return Avx2.mm256_mullo_epi16(b, mm256_div_epi16(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi32(v256 a, v256 b, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU32(b))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi32(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI32(a, 0)))
                        {
                            a = Avx2.mm256_sub_epi32(a, Avx2.mm256_and_si256(mm256_dec_epi32(b), mm256_srai_epi32(a, 31)));
                        }

                        return Avx2.mm256_mullo_epi32(b, mm256_div_epi32(a, b));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_epi64(v256 a, v256 b, byte elements = 4, bool pow2 = false, bool nonNegative = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (pow2 || constexpr.ALL_POW2_EPU64(b, elements))
                    {
                        return Avx2.mm256_and_si256(a, mm256_neg_epi64(b));
                    }
                    else
                    {
                        if (!(nonNegative || constexpr.ALL_GE_EPI64(a, 0, elements)))
                        {
                            a = Avx2.mm256_sub_epi64(a, Avx2.mm256_and_si256(mm256_dec_epi64(b), mm256_srai_epi64(a, 63, elements)));
                        }

                        return mm256_mullo_epi64(b, mm256_div_epi64(a, b, elements: elements), elements);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_ps(v128 a, v128 b, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_ps(b, floor_ps(div_ps(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_ps(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_ps(b, mm256_floor_ps(Avx.mm256_div_ps(a, b)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 floormult_pd(v128 a, v128 b, byte elements = 2)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return mul_pd(b, floor_pd(div_pd(a, b), elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_floormult_pd(v256 a, v256 b)
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_mul_pd(b, mm256_floor_pd(Avx.mm256_div_pd(a, b)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 floormultiple(UInt128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                return x & (0ul - n);
            }
            else
            {
                return n * (x / n);
            }
        }

        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 floormultiple(Int128 x, UInt128 n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                return x & -((Int128)n);
            }
            else
            {
                if (!(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)))
                {
                    x -= ((Int128)n - 1) & new Int128((long)x.hi64 >> 63, (long)x.hi64 >> 63);
                }

                return (Int128)n * (x / (Int128)n);
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong floormultiple(ulong x, ulong n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                return x & (0ul - n);
            }
            else
            {
                return n * (x / n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 floormultiple(ulong2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu64(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 floormultiple(ulong3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu64(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong3(floormultiple(x.xy, n.xy, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 floormultiple(ulong4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu64(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ulong4(floormultiple(x.xy, n.xy, promises), floormultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long floormultiple(long x, ulong n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(ispow2(n)))
            {
                return x & (long)(0 - n);
            }
            else
            {
                if (!(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)))
                {
                    x -= ((long)n - 1) & (x >> 63);
                }

                return (long)n * (x / (long)n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 floormultiple(long2 x, ulong2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi64(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 floormultiple(long3 x, ulong3 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi64(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long3(floormultiple(x.xy, n.xy, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 floormultiple(long4 x, ulong4 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi64(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new long4(floormultiple(x.xy, n.xy, promises), floormultiple(x.zw, n.zw, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint floormultiple(uint x, uint n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.ispow2(n)))
            {
                return x & (0u - n);
            }
            else
            {
                return n * (x / n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 floormultiple(uint2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.floormult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 floormultiple(uint3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.floormult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 floormultiple(uint4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.floormult_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new uint4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 floormultiple(uint8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu32(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new uint8(floormultiple(x.v4_0, n.v4_0, promises), floormultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floormultiple(int x, uint n, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(math.ispow2(n)))
            {
                return x & (int)(0 - n);
            }
            else
            {
                if (!(promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0)))
                {
                    x -= ((int)n - 1) & (x >> 31);
                }

                return (int)n * (x / (int)n);
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floormultiple(int2 x, uint2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.floormult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floormultiple(int3 x, uint3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.floormult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floormultiple(int4 x, uint4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.floormult_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater)));
            }
            else
            {
                return new int4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 floormultiple(int8 x, uint8 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi32(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new int8(floormultiple(x.v4_0, n.v4_0, promises), floormultiple(x.v4_4, n.v4_4, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort floormultiple(ushort x, ushort n, Promise promises = Promise.Nothing)
        {
            return (ushort)floormultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 floormultiple(ushort2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 floormultiple(ushort3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 floormultiple(ushort4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 floormultiple(ushort8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu16(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort8(floormultiple(x.x0, n.x0, promises),
                                   floormultiple(x.x1, n.x1, promises),
                                   floormultiple(x.x2, n.x2, promises),
                                   floormultiple(x.x3, n.x3, promises),
                                   floormultiple(x.x4, n.x4, promises),
                                   floormultiple(x.x5, n.x5, promises),
                                   floormultiple(x.x6, n.x6, promises),
                                   floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 floormultiple(ushort16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu16(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(floormultiple(x.v8_0, n.v8_0, promises), floormultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short floormultiple(short x, ushort n, Promise promises = Promise.Nothing)
        {
            return (short)floormultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 floormultiple(short2 x, ushort2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 floormultiple(short3 x, ushort3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 floormultiple(short4 x, ushort4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 floormultiple(short8 x, ushort8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi16(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short8(floormultiple(x.x0, n.x0, promises),
                                  floormultiple(x.x1, n.x1, promises),
                                  floormultiple(x.x2, n.x2, promises),
                                  floormultiple(x.x3, n.x3, promises),
                                  floormultiple(x.x4, n.x4, promises),
                                  floormultiple(x.x5, n.x5, promises),
                                  floormultiple(x.x6, n.x6, promises),
                                  floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 floormultiple(short16 x, ushort16 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi16(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new short16(floormultiple(x.v8_0, n.v8_0, promises), floormultiple(x.v8_8, n.v8_8, promises));
            }
        }


        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte floormultiple(byte x, byte n, Promise promises = Promise.Nothing)
        {
            return (byte)floormultiple((uint)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 floormultiple(byte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 2, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 floormultiple(byte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 3, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 floormultiple(byte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 4, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 floormultiple(byte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 8, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte8(floormultiple(x.x0, n.x0, promises),
                                 floormultiple(x.x1, n.x1, promises),
                                 floormultiple(x.x2, n.x2, promises),
                                 floormultiple(x.x3, n.x3, promises),
                                 floormultiple(x.x4, n.x4, promises),
                                 floormultiple(x.x5, n.x5, promises),
                                 floormultiple(x.x6, n.x6, promises),
                                 floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 floormultiple(byte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epu8(x, n, 16, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte16(floormultiple(x.x0,  n.x0,  promises),
                                  floormultiple(x.x1,  n.x1,  promises),
                                  floormultiple(x.x2,  n.x2,  promises),
                                  floormultiple(x.x3,  n.x3,  promises),
                                  floormultiple(x.x4,  n.x4,  promises),
                                  floormultiple(x.x5,  n.x5,  promises),
                                  floormultiple(x.x6,  n.x6,  promises),
                                  floormultiple(x.x7,  n.x7,  promises),
                                  floormultiple(x.x8,  n.x8,  promises),
                                  floormultiple(x.x9,  n.x9,  promises),
                                  floormultiple(x.x10, n.x10, promises),
                                  floormultiple(x.x11, n.x11, promises),
                                  floormultiple(x.x12, n.x12, promises),
                                  floormultiple(x.x13, n.x13, promises),
                                  floormultiple(x.x14, n.x14, promises),
                                  floormultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 floormultiple(byte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epu8(x, n, promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(floormultiple(x.v16_0, n.v16_0, promises), floormultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte floormultiple(sbyte x, byte n, Promise promises = Promise.Nothing)
        {
            return (sbyte)floormultiple((int)x, n, promises);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 floormultiple(sbyte2 x, byte2 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 2, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte2(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 floormultiple(sbyte3 x, byte3 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 3, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte3(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 floormultiple(sbyte4 x, byte4 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 4, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte4(floormultiple(x.x, n.x, promises), floormultiple(x.y, n.y, promises), floormultiple(x.z, n.z, promises), floormultiple(x.w, n.w, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 floormultiple(sbyte8 x, byte8 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 8, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte8(floormultiple(x.x0, n.x0, promises),
                                  floormultiple(x.x1, n.x1, promises),
                                  floormultiple(x.x2, n.x2, promises),
                                  floormultiple(x.x3, n.x3, promises),
                                  floormultiple(x.x4, n.x4, promises),
                                  floormultiple(x.x5, n.x5, promises),
                                  floormultiple(x.x6, n.x6, promises),
                                  floormultiple(x.x7, n.x7, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 floormultiple(sbyte16 x, byte16 n, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.floormult_epi8(x, n, 16, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte16(floormultiple(x.x0,  n.x0,  promises),
                                   floormultiple(x.x1,  n.x1,  promises),
                                   floormultiple(x.x2,  n.x2,  promises),
                                   floormultiple(x.x3,  n.x3,  promises),
                                   floormultiple(x.x4,  n.x4,  promises),
                                   floormultiple(x.x5,  n.x5,  promises),
                                   floormultiple(x.x6,  n.x6,  promises),
                                   floormultiple(x.x7,  n.x7,  promises),
                                   floormultiple(x.x8,  n.x8,  promises),
                                   floormultiple(x.x9,  n.x9,  promises),
                                   floormultiple(x.x10, n.x10, promises),
                                   floormultiple(x.x11, n.x11, promises),
                                   floormultiple(x.x12, n.x12, promises),
                                   floormultiple(x.x13, n.x13, promises),
                                   floormultiple(x.x14, n.x14, promises),
                                   floormultiple(x.x15, n.x15, promises));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="n"/> where <paramref name="n"/> &gt; 0.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any <paramref name="n"/> is not a power of 2.        </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results if any <paramref name="x"/> is negative.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 floormultiple(sbyte32 x, byte32 n, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_floormult_epi8(x, n, promises.Promises(Promise.Unsafe0), promises.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(floormultiple(x.v16_0, n.v16_0, promises), floormultiple(x.v16_16, n.v16_16, promises));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float floormultiple(float x, float m)
        {
Assert.IsGreater(m, 0f);

            return m * math.floor(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 floormultiple(float2 x, float2 m)
        {
VectorAssert.IsGreater<float2, float>(m, 0f, 2);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.floormult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new float2(floormultiple(x.x, m.x), floormultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 floormultiple(float3 x, float3 m)
        {
VectorAssert.IsGreater<float3, float>(m, 0f, 3);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.floormult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 3));
            }
            else
            {
                return new float3(floormultiple(x.x, m.x), floormultiple(x.y, m.y), floormultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 floormultiple(float4 x, float4 m)
        {
VectorAssert.IsGreater<float4, float>(m, 0f, 4);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.floormult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 4));
            }
            else
            {
                return new float4(floormultiple(x.x, m.x), floormultiple(x.y, m.y), floormultiple(x.z, m.z), floormultiple(x.w, m.w));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 floormultiple(float8 x, float8 m)
        {
VectorAssert.IsGreater<float8, float>(m, 0f, 8);

            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_floormult_ps(x, m);
            }
            else
            {
                return new float8(floormultiple(x.v4_0, m.v4_0), floormultiple(x.v4_4, m.v4_4));
            }
        }


        /// <summary>       Returns <paramref name="x"/> rounded to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double floormultiple(double x, double m)
        {
Assert.IsGreater(m, 0d);

            return m * math.floor(x / m);
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 floormultiple(double2 x, double2 m)
        {
VectorAssert.IsGreater<double2, double>(m, 0d, 2);

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.floormult_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(m), 2));
            }
            else
            {
                return new double2(floormultiple(x.x, m.x), floormultiple(x.y, m.y));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 floormultiple(double3 x, double3 m)
        {
VectorAssert.IsGreater<double3, double>(m, 0d, 3);

            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_floormult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double3(floormultiple(x.xy, m.xy), floormultiple(x.z, m.z));
            }
        }

        /// <summary>       Returns the componentwise result of rounding <paramref name="x"/> to the nearest smaller multiple of <paramref name="m"/> &gt; 0.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 floormultiple(double4 x, double4 m)
        {
VectorAssert.IsGreater<double4, double>(m, 0d, 4);
            
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_floormult_ps(RegisterConversion.ToV256(x), RegisterConversion.ToV256(m)));
            }
            else
            {
                return new double4(floormultiple(x.xy, m.xy), floormultiple(x.zw, m.zw));
            }
        }
    }
}