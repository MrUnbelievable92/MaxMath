using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epi8(v128 v, bool promise = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        switch (elements)
                        {
                            case 16:
                            {
                                v = add_epi8(v, bsrli_si128(v, 8 * sizeof(byte)));

                                goto case 8;
                            }
                            case 8:
                            {
                                v = add_epi8(v, bsrli_si128(v, 4 * sizeof(byte)));

                                goto case 4;
                            }
                            case 4:
                            {
                                v = add_epi8(v, bsrli_si128(v, 2 * sizeof(byte)));

                                goto case 2;
                            }
                            case 3:
                            {
                                v128 __v = v;
                                v = add_epi8(v, bsrli_si128(__v, 2 * sizeof(byte)));
                                v = add_epi8(v, bsrli_si128(__v, 1 * sizeof(byte)));

                                return v;
                            }
                            case 2:
                            {
                                v = add_epi8(v, bsrli_si128(v, 1 * sizeof(byte)));

                                return v;
                            }

                            default: return v;
                        }
                    }
                    else
                    {
                        v128 result;
                        if (elements == 16)
                        {
                            v128 v16Lo = cvt2x2epi8_epi16(v, out v128 v16Hi);

                            result = vsum_epi16(add_epi16(v16Lo, v16Hi), true, 8);
                        }
                        else
                        {
                            result = vsum_epi16(cvtepi8_epi16(v), true, elements);
                        }

                        constexpr.ASSUME_RANGE_EPI16(result, elements * sbyte.MinValue, elements * sbyte.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epu8(v128 v, bool promise = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result;
                    if (elements == 16)
                    {
                        result = sad_epu8(v, setzero_si128());
                        result = add_epi16(result, bsrli_si128(result, sizeof(ulong)));
                    }
                    else if (elements == 8)
                    {
                        result = sad_epu8(v, setzero_si128());
                    }
                    else
                    {
                        result = promise ? vsum_epi8(v, true, elements) : vsum_epi16(cvtepu8_epi16(v), true, elements);
                    }

                    if (!promise)
                    {
                        constexpr.ASSUME_LE_EPU16(result, elements * 255u, 1);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epi16(v128 v, bool promise = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        switch (elements)
                        {
                            case 8:
                            {
                                v = add_epi16(v, bsrli_si128(v, 4 * sizeof(short)));

                                goto case 4;
                            }
                            case 4:
                            {
                                v = add_epi16(v, bsrli_si128(v, 2 * sizeof(short)));

                                goto case 2;
                            }
                            case 3:
                            {
                                v128 __v = v;
                                v = add_epi16(v, bsrli_si128(__v, 2 * sizeof(short)));
                                v = add_epi16(v, bsrli_si128(__v, 1 * sizeof(short)));

                                return v;
                            }
                            case 2:
                            {
                                v = add_epi16(v, bsrli_si128(v, 1 * sizeof(short)));

                                return v;
                            }

                            default: return v;
                        }
                    }
                    else
                    {
                        v128 result;
                        if (elements == 8)
                        {
                            v128 v16Lo = cvt2x2epi16_epi32(v, out v128 v16Hi);

                            result = vsum_epi32(add_epi32(v16Lo, v16Hi), true, 4);
                        }
                        else
                        {
                            result = vsum_epi32(cvtepi16_epi32(v), true, elements);
                        }

                        constexpr.ASSUME_RANGE_EPI32(result, elements * short.MinValue, elements * short.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epu16(v128 v, bool promise = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        return vsum_epi16(v, true, elements);
                    }
                    else
                    {
                        v128 result;
                        if (elements == 8)
                        {
                            v128 v16Lo = cvt2x2epu16_epi32(v, out v128 v16Hi);

                            result = vsum_epi32(add_epi32(v16Lo, v16Hi), true, 4);
                        }
                        else
                        {
                            result = vsum_epi32(cvtepu16_epi32(v), true, elements);
                        }

                        constexpr.ASSUME_LE_EPU32(result, elements * (uint)ushort.MaxValue);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epi32(v128 v, bool promise = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        switch (elements)
                        {
                            case 4:
                            {
                                v = add_epi32(v, bsrli_si128(v, 2 * sizeof(int)));

                                goto case 2;
                            }
                            case 3:
                            {
                                v128 __v = v;
                                v = add_epi32(v, bsrli_si128(__v, 2 * sizeof(int)));
                                v = add_epi32(v, bsrli_si128(__v, 1 * sizeof(int)));

                                return v;
                            }
                            case 2:
                            {
                                v = add_epi32(v, bsrli_si128(v, 1 * sizeof(int)));

                                return v;
                            }

                            default: return v;
                        }
                    }
                    else
                    {
                        v128 result;
                        if (elements == 2)
                        {
                            result = vsum_epi64(cvtepi32_epi64(v));
                        }
                        else
                        {
                            v128 v16Lo = cvt2x2epi32_epi64(v, out v128 v16Hi);

                            if (elements == 4)
                            {
                                result = vsum_epi64(add_epi64(v16Lo, v16Hi));
                            }
                            else
                            {
                                v128 y = bsrli_si128(v16Lo, sizeof(long));
                                v128 sum = add_epi64(v16Lo, v16Hi);
                                sum = add_epi64(sum, y);

                                result = sum;
                            }
                        }

                        // TODO, uncomment once mono bug is fixed
                        ////constexpr.ASSUME_RANGE_EPI64(result, elements * (long)int.MinValue, elements * (long)int.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epu32(v128 v, bool promise = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (promise)
                    {
                        return vsum_epi32(v, true, elements);
                    }
                    else
                    {
                        v128 result;
                        if (elements == 2)
                        {
                            result = vsum_epi64(cvtepu32_epi64(v));
                        }
                        else
                        {
                            v128 v16Lo = cvt2x2epu32_epi64(v, out v128 v16Hi);

                            if (elements == 4)
                            {
                                result = vsum_epi64(add_epi64(v16Lo, v16Hi));
                            }
                            else
                            {
                                v128 y = bsrli_si128(v16Lo, sizeof(long));
                                v128 sum = add_epi64(v16Lo, v16Hi);
                                sum = add_epi64(sum, y);

                                result = sum;
                            }
                        }

                        constexpr.ASSUME_LE_EPU64(result, elements * (ulong)uint.MaxValue);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vsum_epi64(v128 v)
            {
                if (Architecture.IsSIMDSupported)
                {
                    return add_epi64(v, bsrli_si128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epu8(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v = Avx2.mm256_sad_epu8(v, Avx.mm256_setzero_si256());
                    v = Avx2.mm256_add_epi16(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(ushort)));

                    constexpr.ASSUME_LE_EPU16(v, 32 * byte.MaxValue);
                    return v;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epi8(v256 v, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v = Avx2.mm256_add_epi8(v, Avx2.mm256_bsrli_epi128(v, 8 * sizeof(sbyte)));
                        v = Avx2.mm256_add_epi8(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(sbyte)));
                        v = Avx2.mm256_add_epi8(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(sbyte)));
                        v = Avx2.mm256_add_epi8(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(sbyte)));

                        return v;
                    }
                    else
                    {
                        v256 v16Lo = mm256_cvt2x2epi8_epi16(v, out v256 v16Hi);

                        v256 result = mm256_vsum_epi16(Avx2.mm256_add_epi16(v16Lo, v16Hi), true);
                        constexpr.ASSUME_RANGE_EPI16(result, 32 * sbyte.MinValue, 32 * sbyte.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epi16(v256 v, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v = Avx2.mm256_add_epi16(v, Avx2.mm256_bsrli_epi128(v, 4 * sizeof(short)));
                        v = Avx2.mm256_add_epi16(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(short)));
                        v = Avx2.mm256_add_epi16(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(short)));

                        return v;
                    }
                    else
                    {
                        v256 v16Lo = mm256_cvt2x2epi16_epi32(v, out v256 v16Hi);

                        v256 result = mm256_vsum_epi32(Avx2.mm256_add_epi32(v16Lo, v16Hi), true);
                        constexpr.ASSUME_RANGE_EPI32(result, 16 * short.MinValue, 16 * short.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epu16(v256 v, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        return mm256_vsum_epi16(v, true);
                    }
                    else
                    {
                        v256 v16Lo = mm256_cvt2x2epu16_epi32(v, out v256 v16Hi);

                        v256 result = mm256_vsum_epi32(Avx2.mm256_add_epi32(v16Lo, v16Hi), true);
                        constexpr.ASSUME_LE_EPU32(result, 16 * ushort.MaxValue);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epi32(v256 v, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v = Avx2.mm256_add_epi32(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(int)));
                        v = Avx2.mm256_add_epi32(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(int)));

                        return v;
                    }
                    else
                    {
                        v256 v16Lo = mm256_cvt2x2epi32_epi64(v, out v256 v16Hi);

                        v256 result = mm256_vsum_epi64(Avx2.mm256_add_epi64(v16Lo, v16Hi));
                        constexpr.ASSUME_RANGE_EPI64(result, 8 * (long)int.MinValue, 8 * (long)int.MaxValue, 1);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epu32(v256 v, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promise)
                    {
                        v = Avx2.mm256_add_epi32(v, Avx2.mm256_bsrli_epi128(v, 2 * sizeof(int)));
                        v = Avx2.mm256_add_epi32(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(int)));

                        return v;
                    }
                    else
                    {
                        v256 v16Lo = mm256_cvt2x2epu32_epi64(v, out v256 v16Hi);

                        v256 result = mm256_vsum_epi64(Avx2.mm256_add_epi64(v16Lo, v16Hi));
                        constexpr.ASSUME_LE_EPU64(result, 8 * (ulong)uint.MaxValue);
                        return result;
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_vsum_epi64(v256 v)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_add_epi64(v, Avx2.mm256_bsrli_epi128(v, 1 * sizeof(long)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float csum(float8 c)
        {
            if (Avx.IsAvxSupported)
            {
                v128 result = Xse.add_ps(Avx.mm256_castps256_ps128(c),
                                         Avx.mm256_extractf128_ps(c, 1));

                result = Xse.add_ps(result, Xse.shuffle_epi32(result, Sse.SHUFFLE(0, 1, 2, 3)));

                return Xse.add_ss(result, Xse.shufflelo_epi16(result, Sse.SHUFFLE(0, 0, 3, 2))).Float0;
            }
            else
            {
                return math.csum(c.v4_0 + c.v4_4);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 2ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu8(c, true, 2).Byte0;
                }
                else
                {
                    return Xse.vsum_epu8(c, false, 2).UShort0;
                }
            }
            else
            {
                return (uint)c.x + (uint)c.y;
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 3ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu8(c, true, 3).Byte0;
                }
                else
                {
                    return Xse.vsum_epu8(c, false, 3).UShort0;
                }
            }
            else
            {
                return (uint)(c.x + c.y + c.z);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 4ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu8(c, true, 4).Byte0;
                }
                else
                {
                    return Xse.vsum_epu8(c, false, 4).UShort0;
                }
            }
            else
            {
                return (uint)((c.x + c.y) + (c.z + c.w));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte8"/>.       </summary>
        [return: AssumeRange(0ul, 8ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte8 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vsum_epu8(c, false, 8).UShort0;
            }
            else
            {
                return (uint)(((c.x0 + c.x1) + (c.x2 + c.x3)) + ((c.x4 + c.x5) + (c.x6 + c.x7)));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte16"/>.       </summary>
        [return: AssumeRange(0ul, 16ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte16 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vsum_epu8(c, false, 16).UShort0;
            }
            else
            {
                return (uint)((((c.x0 + c.x1) + (c.x2 + c.x3)) + ((c.x4 + c.x5) + (c.x6 + c.x7))) + (((c.x8 + c.x9) + (c.x10 + c.x11)) + ((c.x12 + c.x13) + (c.x14 + c.x15))));
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.byte32"/>.       </summary>
        [return: AssumeRange(0ul, 32ul * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(byte32 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vsum_epu8(c);

                return Xse.add_epi16(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).UShort0;
            }
            else
            {
                return csum(c.v16_0) + csum(c.v16_16);
            }
        }


        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(2 * sbyte.MinValue, 2 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi8(c, true, 2).SByte0;
                }
                else
                {
                    return Xse.vsum_epi8(c, false, 2).SShort0;
                }
            }
            else
            {
                return c.x + c.y;
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(3 * sbyte.MinValue, 3 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi8(c, true, 3).SByte0;
                }
                else
                {
                    return Xse.vsum_epi8(c, false, 3).SShort0;
                }
            }
            else
            {
                return (c.x + c.y) + c.z;
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(4 * sbyte.MinValue, 4 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi8(c, true, 4).SByte0;
                }
                else
                {
                    return Xse.vsum_epi8(c, false, 4).SShort0;
                }
            }
            else
            {
                return (c.x + c.y) + (c.z + c.w);
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(8 * sbyte.MinValue, 8 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi8(c, true, 8).SByte0;
                }
                else
                {
                    return Xse.vsum_epi8(c, false, 8).SShort0;
                }
            }
            else
            {
                return ((c.x0 + c.x1) + (c.x2 + c.x3)) + ((c.x4 + c.x5) + (c.x6 + c.x7));
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(16 * sbyte.MinValue, 16 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi8(c, true, 16).SByte0;
                }
                else
                {
                    return Xse.vsum_epi8(c, false, 16).SShort0;
                }
            }
            else
            {
                return (((c.x0 + c.x1) + (c.x2 + c.x3)) + ((c.x4 + c.x5) + (c.x6 + c.x7))) + (((c.x8 + c.x9) + (c.x10 + c.x11)) + ((c.x12 + c.x13) + (c.x14 + c.x15)));
            }
        }

        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.sbyte32"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(32 * sbyte.MinValue, 32 * sbyte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(sbyte32 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 half = Xse.mm256_vsum_epi8(c, true);

                    return Xse.add_epi8(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SByte0;
                }
                else
                {
                    v256 half = Xse.mm256_vsum_epi8(c, false);

                    return Xse.add_epi16(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SShort0;
                }
            }
            else
            {
                return csum(c.v16_0) + csum(c.v16_16);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(2 * short.MinValue, 2 * short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(short2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi16(c, true, 2).SShort0;
                }
                else
                {
                    return Xse.vsum_epi16(c, false, 2).SInt0;
                }
            }
            else
            {
                return math.csum((int2)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(3 * short.MinValue, 3 * short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(short3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi16(c, true, 3).SShort0;
                }
                else
                {
                    return Xse.vsum_epi16(c, false, 3).SInt0;
                }
            }
            else
            {
                return math.csum((int3)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(4 * short.MinValue, 4 * short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(short4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi16(c, true, 4).SShort0;
                }
                else
                {
                    return Xse.vsum_epi16(c, false, 4).SInt0;
                }
            }
            else
            {
                return math.csum((int4)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(8 * short.MinValue, 8 * short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(short8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epi16(c, true, 8).SShort0;
                }
                else
                {
                    return Xse.vsum_epi16(c, false, 8).SInt0;
                }
            }
            else
            {
                return math.csum((int4)c.v4_0 + (int4)c.v4_4);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.short16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(16 * short.MinValue, 16 * short.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(short16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 half = Xse.mm256_vsum_epi16(c, true);

                    return Xse.add_epi16(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SShort0;
                }
                else
                {
                    v256 half = Xse.mm256_vsum_epi16(c, false);

                    return Xse.add_epi32(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SInt0;
                }
            }
            else
            {
                return csum(c.v8_0) + csum(c.v8_8);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort2"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 2ul * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu16(c, true, 2).UShort0;
                }
                else
                {
                    return Xse.vsum_epu16(c, false, 2).UInt0;
                }
            }
            else
            {
                return math.csum((uint2)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort3"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 3ul * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu16(c, true, 3).UShort0;
                }
                else
                {
                    return Xse.vsum_epu16(c, false, 3).UInt0;
                }
            }
            else
            {
                return math.csum((uint3)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort4"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 4ul * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu16(c, true, 4).UShort0;
                }
                else
                {
                    return Xse.vsum_epu16(c, false, 4).UInt0;
                }
            }
            else
            {
                return math.csum((uint4)c);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort8"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 8ul * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.vsum_epu16(c, true, 8).UShort0;
                }
                else
                {
                    return Xse.vsum_epu16(c, false, 8).UInt0;
                }
            }
            else
            {
                return math.csum((uint4)c.v4_0 + (uint4)c.v4_4);
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ushort16"/>.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> '<paramref name="noOverflow"/>' withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> is guaranteed not to overflow.       </para>     
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 16ul * ushort.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(ushort16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 half = Xse.mm256_vsum_epu16(c, true);

                    return Xse.add_epi16(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).UShort0;
                }
                else
                {
                    v256 half = Xse.mm256_vsum_epu16(c, false);

                    return Xse.add_epi32(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).UInt0;
                }
            }
            else
            {
                return csum(c.v8_0) + csum(c.v8_8);
            }
        }


        /// <summary>       Returns the horizontal sum of components of an <see cref="MaxMath.int8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int csum(int8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vsum_epi32(c, true);

                return Xse.add_epi32(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SInt0;
            }
            else
            {
                return math.csum(c.v4_0 + c.v4_4);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.uint8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint csum(uint8 c)
        {
            return (uint)csum((int8)c);
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long2 c)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.vsum_epi64(c).SLong0;
            }
            else
            {
                return c.x + c.y;
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long3 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 lo = Avx.mm256_castsi256_si128(c);
                v128 hi = Avx2.mm256_extracti128_si256(c, 1);

                v128 sum = Xse.add_epi64(lo, Xse.bsrli_si128(lo, 1 * sizeof(ulong)));
                sum = Xse.add_epi64(sum, hi);

                return sum.SLong0;
            }
            else
            {
                return csum(c.xy) + c.z;
            }
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.long4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long csum(long4 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 half = Xse.mm256_vsum_epi64(c);

                return Xse.add_epi64(Avx.mm256_castsi256_si128(half), Avx2.mm256_extracti128_si256(half, 1)).SLong0;
            }
            else
            {
                return csum(c.xy) + csum(c.zw);
            }
        }


        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong2"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong2 c)
        {
            return (ulong)csum((long2)c);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong3"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong3 c)
        {
            return (ulong)csum((long3)c);
        }

        /// <summary>       Returns the horizontal sum of components of a <see cref="MaxMath.ulong4"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong csum(ulong4 c)
        {
            return (ulong)csum((long4)c);
        }
    }
}