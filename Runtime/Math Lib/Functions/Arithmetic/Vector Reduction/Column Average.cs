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
            public static v128 vavg_epu8(v128 a, bool promiseNoOverflow = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements == 2)
                    {
                        return Sse2.avg_epu8(a, Sse2.bsrli_si128(a, 1 * sizeof(byte)));
                    }
                    else
                    {
                        v128 CEIL_SUMMAND = Sse2.cvtsi32_si128(elements - 1);
                        
                        if (promiseNoOverflow & elements < 8)
                        {
                            return constexpr.div_epu8(Sse2.add_epi8(CEIL_SUMMAND, vsum_epu8(a, true, elements)), elements, elements);
                        }
                        else
                        {
                            if (elements == 4 | elements == 8 | elements == 16)
                            {
                                return constexpr.div_epu16(Sse2.add_epi16(CEIL_SUMMAND, vsum_epu8(a, false, elements)), elements, elements);
                            }
                            else
                            {
                                return constexpr.div_epu8_TAKE_AND_RET_EPU16(Sse2.add_epi16(CEIL_SUMMAND, vsum_epu8(a, false, elements)), elements);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vavg_epu16(v128 a, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements == 2)
                    {
                        return Sse2.avg_epu16(a, Sse2.bsrli_si128(a, 1 * sizeof(ushort)));
                    }
                    else
                    {
                        v128 CEIL_SUMMAND = Sse2.cvtsi32_si128(elements - 1);
                        
                        if (promiseNoOverflow)
                        {
                            return constexpr.div_epu16(Sse2.add_epi16(CEIL_SUMMAND, vsum_epu16(a, true, elements)), elements, elements);
                        }
                        else
                        {
                            return constexpr.div_epu32(Sse2.add_epi32(CEIL_SUMMAND, vsum_epu16(a, false, elements)), elements, elements, true);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vavg_epi8(v128 a, bool promiseNoOverflow = false, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        ;
                    }
                    else if (elements == 2)
                    {
                        return Sse2.cvtsi32_si128(maxmath.avg(a.SByte0, a.SByte1));
                    }
                    
                    v128 offset = Sse2.cvtsi32_si128(elements - 1);
                    v128 csum = vsum_epi8(a, promiseNoOverflow, elements);
                    v128 result;

                    if (promiseNoOverflow)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            offset = Ssse3.sign_epi8(offset, csum);
                        }
                        else
                        {
                            v128 signMaskSum = srai_epi8(csum, 7);
                            offset = Sse2.sub_epi8(Sse2.xor_si128(offset, signMaskSum), signMaskSum);
                        }

                        result = Sse2.add_epi8(csum, offset);
                        result = constexpr.div_epi8(result, (sbyte)elements, elements);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            offset = Ssse3.sign_epi16(offset, csum);
                        }
                        else
                        {
                            v128 signMaskSum = Sse2.srai_epi16(csum, 15);
                            offset = Sse2.sub_epi16(Sse2.xor_si128(offset, signMaskSum), signMaskSum);
                        }

                        result = Sse2.add_epi16(csum, offset);
                        result = constexpr.div_epi16(result, elements, elements);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vavg_epi16(v128 a, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        ;
                    }
                    else if (elements == 2)
                    {
                        return Sse2.cvtsi32_si128(maxmath.avg(a.SShort0, a.SShort1));
                    }
                    
                    v128 offset = Sse2.cvtsi32_si128(elements - 1);
                    v128 csum = vsum_epi16(a, promiseNoOverflow, elements);
                    v128 result;

                    if (promiseNoOverflow)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            offset = Ssse3.sign_epi16(offset, csum);
                        }
                        else
                        {
                            v128 signMaskSum = Sse2.srai_epi16(csum, 15);
                            offset = Sse2.sub_epi16(Sse2.xor_si128(offset, signMaskSum), signMaskSum);
                        }

                        result = Sse2.add_epi16(csum, offset);
                        result = constexpr.div_epi16(result, elements, elements);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            offset = Ssse3.sign_epi32(offset, csum);
                        }
                        else
                        {
                            v128 signMaskSum = Sse2.srai_epi32(csum, 31);
                            offset = Sse2.sub_epi32(Sse2.xor_si128(offset, signMaskSum), signMaskSum);
                        }

                        result = Sse2.add_epi32(csum, offset);
                        result = constexpr.div_epi32(result, elements);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 vavg_epi32(v128 a, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Ssse3.IsSsse3Supported)
                    {
                        ;
                    }
                    else if (elements == 2)
                    {
                        return Sse2.cvtsi64_si128(maxmath.avg(a.SInt0, a.SInt1));
                    }
                    
                    v128 offset = Sse2.cvtsi32_si128(elements - 1);
                    v128 csum = vsum_epi32(a, promiseNoOverflow, elements);
                    v128 result;

                    if (promiseNoOverflow)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            offset = Ssse3.sign_epi32(offset, csum);
                        }
                        else
                        {
                            v128 signMaskSum = Sse2.srai_epi32(csum, 31);
                            offset = Sse2.sub_epi32(Sse2.xor_si128(offset, signMaskSum), signMaskSum);
                        }

                        result = Sse2.add_epi32(csum, offset);
                        result = constexpr.div_epi32(result, elements);
                    }
                    else
                    {
                        v128 signMaskSum = srai_epi64(csum, 63);
                        offset = Sse2.sub_epi64(Sse2.xor_si128(offset, signMaskSum), signMaskSum);

                        result = Sse2.add_epi64(csum, offset);
                        result = constexpr.div_epi64(result, elements);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }
    

    unsafe public static partial class maxmath
    {
        /// <summary>      Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu8(c, true, 2).Byte0;
            }
            else
            {
                return (byte)((1u + csum(c)) / 2u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 3 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu8(c, promiseNoOverflow : noOverflow.Promises(Promise.NoOverflow), 3).Byte0;
            }
            else
            {
                return (byte)((2u + csum(c, noOverflow)) / 3u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="optimizations"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> 3 that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte4 c, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu8(c, promiseNoOverflow: optimizations.Promises(Promise.NoOverflow), 4).Byte0;
            }
            else
            {
                return (byte)((3u + csum(c, optimizations)) / 4u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte8 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu8(c, true /*sad_epu*/, 8).Byte0;
            }
            else
            {
                return (byte)((7u + csum(c)) / 8u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte16"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte16 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu8(c, true /*sad_epu*/, 16).Byte0;
            }
            else
            {
                return (byte)((15u + csum(c)) / 16u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.byte32"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte cavg(byte32 c)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 OFFSET = Sse2.cvtsi32_si128(31);
                v128 total;

                if (Avx2.IsAvx2Supported)
                {
                    v256 csum = Xse.mm256_vsum_epu8(c);
                    total = Sse2.add_epi16(Avx.mm256_castsi256_si128(csum), OFFSET);
                    total = Sse2.add_epi16(total, Avx2.mm256_extracti128_si256(csum, 1));
                }
                else
                {
                    total = Sse2.add_epi16(Xse.vsum_epu8(c.v16_0), Xse.vsum_epu8(c.v16_16));
                    total = Sse2.add_epi16(total, OFFSET);
                }

                return Xse.constexpr.div_epu16(total, 32).Byte0;
            }
            else
            {
                return (byte)((31u + csum(c)) / 32u);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi8(c, noOverflow.Promises(Promise.NoOverflow), 2).SByte0;
            }
            else 
            {
                return avg(c.x, c.y);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi8(c, noOverflow.Promises(Promise.NoOverflow), 3).SByte0;
            }
            else
            {
                int intermediate = csum(c);

                return (sbyte)((intermediate + copysign(2, intermediate)) / 3);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi8(c, noOverflow.Promises(Promise.NoOverflow), 4).SByte0;
            }
            else
            {
                int intermediate = csum(c);

                return (sbyte)((intermediate + copysign(3, intermediate)) / 4);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte8"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi8(c, noOverflow.Promises(Promise.NoOverflow), 8).SByte0;
            }
            else
            {
                int intermediate = csum(c);

                return (sbyte)((intermediate + copysign(7, intermediate)) / 8);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte16"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 15 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 15 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi8(c, noOverflow.Promises(Promise.NoOverflow), 16).SByte0;
            }
            else
            {
                int intermediate = csum(c);

                return (sbyte)((intermediate + copysign(15, intermediate)) / 16);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.sbyte32"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 31 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 31 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte cavg(sbyte32 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 OFFSET128 = Sse2.cvtsi32_si128(31);
                v128 lo;
                v128 hi;
                bool promisedNoOverflow = noOverflow.Promises(Promise.NoOverflow);

                if (Avx2.IsAvx2Supported)
                {
                    v256 csum = Xse.mm256_vsum_epi8(c, promisedNoOverflow);
                    lo = Avx.mm256_castsi256_si128(csum);
                    hi = Avx2.mm256_extracti128_si256(csum, 1);
                }
                else
                {
                    lo = Xse.vsum_epi8(c.v16_0,  promisedNoOverflow);
                    hi = Xse.vsum_epi8(c.v16_16, promisedNoOverflow);
                }


                if (promisedNoOverflow)
                {
                    v128 total = Sse2.add_epi8(lo, hi);
                    
                    v128 signedOffset;
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedOffset = Ssse3.sign_epi8(OFFSET128, total);
                    }
                    else
                    {
                        signedOffset = Xse.movsign_epi8(OFFSET128, total);
                    }
                    
                    v128 result = Sse2.add_epi8(total, signedOffset);
                    result = Xse.constexpr.div_epi8(result, 32);
                    
                    return result.SByte0;
                }
                else
                {
                    v128 total = Sse2.add_epi16(lo, hi);
                    
                    v128 signedOffset;
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedOffset = Ssse3.sign_epi16(OFFSET128, total);
                    }
                    else
                    {
                        signedOffset = Xse.movsign_epi16(OFFSET128, total);
                    }
                    
                    v128 result = Sse2.add_epi16(total, signedOffset);
                    result = Xse.constexpr.div_epi16(result, 32);
                    
                    return result.SByte0;
                }
            }
            else 
            {
                int intermediate = csum(c);

                return (sbyte)((intermediate + copysign(31, intermediate)) / 32);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ushort2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cavg(ushort2 c)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu16(c, false, 2).UShort0;
            }
            else
            {
                return (ushort)((1u + csum(c)) / 2u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ushort3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> 2 that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> 2 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cavg(ushort3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu16(c, noOverflow.Promises(Promise.NoOverflow), 3).UShort0;
            }
            else
            {
                return (ushort)((2u + csum(c, noOverflow)) / 3u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ushort4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="optimizations"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> 3 that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cavg(ushort4 c, Promise optimizations = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu16(c, optimizations.Promises(Promise.NoOverflow), 4).UShort0;
            }
            else
            {
                return (ushort)((3u + csum(c, optimizations)) / 4u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ushort8"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> 7 that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> 7 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cavg(ushort8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epu16(c, noOverflow.Promises(Promise.NoOverflow), 8).UShort0;
            }
            else
            {
                return (ushort)((7u + csum(c, noOverflow)) / 8u);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ushort16"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> 7 that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> 7 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort cavg(ushort16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 OFFSET = Sse2.cvtsi32_si128(15);
                v128 lo;
                v128 hi;
                bool promisedNoOverflow = noOverflow.Promises(Promise.NoOverflow);

                if (Avx2.IsAvx2Supported)
                {
                    v256 csum = Xse.mm256_vsum_epu16(c, promisedNoOverflow);
                    lo = Avx.mm256_castsi256_si128(csum);
                    hi = Avx2.mm256_extracti128_si256(csum, 1);
                }
                else
                {
                    lo = Xse.vsum_epu16(c.v8_0, promisedNoOverflow);
                    hi = Xse.vsum_epu16(c.v8_8, promisedNoOverflow);
                }


                if (promisedNoOverflow)
                {
                    v128 csum = Sse2.add_epi16(Sse2.add_epi16(lo, OFFSET), hi);

                    return Xse.constexpr.div_epu16(csum, 16).UShort0;
                }
                else
                {
                    v128 csum = Sse2.add_epi32(Sse2.add_epi32(lo, OFFSET), hi);

                    return Xse.constexpr.div_epu32(csum, 16, 1, true).UShort0;
                }
            }
            else
            {
                return (ushort)((15u + csum(c)) / 16u);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.short2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cavg(short2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi16(c, noOverflow.Promises(Promise.NoOverflow), 2).SShort0;
            }
            else 
            {
                return avg(c.x, c.y);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.short3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cavg(short3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi16(c, noOverflow.Promises(Promise.NoOverflow), 3).SShort0;
            }
            else 
            {
                int intermediate = csum(c);

                return (short)((intermediate + copysign(2, intermediate)) / 3);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.short4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cavg(short4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi16(c, noOverflow.Promises(Promise.NoOverflow), 4).SShort0;
            }
            else 
            {
                int intermediate = csum(c);

                return (short)((intermediate + copysign(3, intermediate)) / 4);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.short8"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cavg(short8 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi16(c, noOverflow.Promises(Promise.NoOverflow), 8).SShort0;
            }
            else 
            {
                int intermediate = csum(c);

                return (short)((intermediate + copysign(7, intermediate)) / 8);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.short16"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 15 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 15 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short cavg(short16 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 OFFSET128 = Sse2.cvtsi32_si128(15);
                v128 lo;
                v128 hi;
                bool promisedNoOverflow = noOverflow.Promises(Promise.NoOverflow);

                if (Avx2.IsAvx2Supported)
                {
                    v256 csum = Xse.mm256_vsum_epi16(c, promisedNoOverflow);
                    lo = Avx.mm256_castsi256_si128(csum);
                    hi = Avx2.mm256_extracti128_si256(csum, 1);
                }
                else
                {
                    lo = Xse.vsum_epi16(c.v8_0, promisedNoOverflow);
                    hi = Xse.vsum_epi16(c.v8_8, promisedNoOverflow);
                }


                if (promisedNoOverflow)
                {
                    v128 total = Sse2.add_epi16(lo, hi);
                    
                    v128 signedOffset;
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedOffset = Ssse3.sign_epi16(OFFSET128, total);
                    }
                    else
                    {
                        signedOffset = Xse.movsign_epi16(OFFSET128, total);
                    }
                    
                    v128 result = Sse2.add_epi16(total, signedOffset);
                    result = Xse.constexpr.div_epi16(result, 16);
                    
                    return result.SShort0;
                }
                else
                {
                    v128 total = Sse2.add_epi32(lo, hi);
                    
                    v128 signedOffset;
                    if (Ssse3.IsSsse3Supported)
                    {
                        signedOffset = Ssse3.sign_epi32(OFFSET128, total);
                    }
                    else
                    {
                        signedOffset = Xse.movsign_epi32(OFFSET128, total);
                    }
                    
                    v128 result = Sse2.add_epi32(total, signedOffset);
                    result = Xse.constexpr.div_epi32(result, 16);
                    
                    return result.SShort0;
                }
            }
            else 
            {
                int intermediate = csum(c);

                return (short)((intermediate + copysign(15, intermediate)) / 16);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="uint2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 1 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cavg(uint2 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (1u + math.csum(c)) / 2;
            }
            else
            {
                return avg(c.x, c.y);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="uint3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 2 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cavg(uint3 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (2u + math.csum(c)) / 3;
            }
            else
            {
                return (uint)(((2 + (ulong)c.z) + csum((ulong2)c.xy)) / 3);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="uint4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 3 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cavg(uint4 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (3u + math.csum(c)) / 4;
            }
            else
            {
                ulong __csum;

                if (Sse2.IsSse2Supported)
                {
                    v128 c64Lo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(c), out v128 c64Hi);
                    v128 sum = Sse2.add_epi64(c64Lo, c64Hi);
                    __csum = Sse2.add_epi64(sum, Sse2.bsrli_si128(sum, sizeof(long))).ULong0;
                }
                else
                {
                    __csum = csum((ulong2)c.xy + (ulong2)c.zw);
                }

                return (uint)((3 + __csum) / 4);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.uint8"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 7 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint cavg(uint8 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (7u + csum(c)) / 8u;
            }
            else
            {
                ulong __csum;

                if (Avx2.IsAvx2Supported)
                {
                    v256 c64Lo = Xse.mm256_cvt2x2epu32_epi64(c, out v256 c64Hi);

                    __csum = csum((ulong4)Avx2.mm256_add_epi64(c64Lo, c64Hi));
                }
                else if (Sse2.IsSse2Supported)
                {
                    v128 c64LoLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(c.v4_0), out v128 c64LoHi);
                    v128 c64HiLo = Xse.cvt2x2epu32_epi64(RegisterConversion.ToV128(c.v4_4), out v128 c64HiHi);
                    c64LoLo = Sse2.add_epi64(c64LoLo, c64LoHi);
                    c64HiLo = Sse2.add_epi64(c64HiLo, c64HiHi);
                    v128 sum = Sse2.add_epi64(c64LoLo, c64HiLo);

                    __csum = Sse2.add_epi64(sum, Sse2.bsrli_si128(sum, sizeof(long))).ULong0;
                }
                else
                {
                    ulong4 lo = c.v4_0;
                    ulong4 hi = c.v4_4;

                    __csum = csum(lo + hi);
                }

                return (uint)((7 + __csum) / 8);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="int2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cavg(int2 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi32(RegisterConversion.ToV128(c), noOverflow.Promises(Promise.NoOverflow), 2).SInt0;
            }
            else
            {
                return avg(c.x, c.y);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="int3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cavg(int3 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi32(RegisterConversion.ToV128(c), noOverflow.Promises(Promise.NoOverflow), 3).SInt0;
            }
            else
            {
                long intermediate = csum((long3)c); 

                return (int)((intermediate + copysign(2, intermediate)) / 3);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="int4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cavg(int4 c, Promise noOverflow = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.vavg_epi32(RegisterConversion.ToV128(c), noOverflow.Promises(Promise.NoOverflow), 4).SInt0;
            }
            else
            {
                long intermediate = csum((long4)c); 

                return (int)((intermediate + copysign(3, intermediate)) / 4);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in an <see cref="MaxMath.int8"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 7 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int cavg(int8 c, Promise noOverflow = Promise.Nothing)
        {
            const int OFFSET = 7;

            if (noOverflow.Promises(Promise.NoOverflow))
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 OFFSET128 = Sse2.cvtsi32_si128(OFFSET);
                    v128 csum;

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 csum256 = Xse.mm256_vsum_epi32(c, true);
                        csum = Sse2.add_epi32(Avx.mm256_castsi256_si128(csum256), Avx2.mm256_extracti128_si256(csum256, 1));
                    }
                    else
                    {
                        csum = Xse.vsum_epi32(Sse2.add_epi32(RegisterConversion.ToV128(c.v4_0), RegisterConversion.ToV128(c.v4_4)), true, 4);
                    }
                
                v128 signedOffset;
                if (Ssse3.IsSsse3Supported)
                {
                    signedOffset = Ssse3.sign_epi32(OFFSET128, csum);
                }
                else
                {
                    signedOffset = Xse.movsign_epi32(OFFSET128, csum);
                }

                    v128 result = Sse2.add_epi32(csum, signedOffset);
                    result = Xse.constexpr.div_epi32(result, 8);

                    return result.SInt0;
                }
                else 
                {
                    int intermediate = csum(c);

                    return (intermediate + copysign(OFFSET, intermediate)) / 8;
                }
            }
            else
            {
                long intermediate;

                if (Ssse3.IsSsse3Supported)
                {
                    v128 csum;

                    if (Avx2.IsAvx2Supported)
                    {
                        v256 csum256 = Xse.mm256_vsum_epi32(c, false);
                        csum = Sse2.add_epi64(Avx.mm256_castsi256_si128(csum256), Avx2.mm256_extracti128_si256(csum256, 1));
                    }
                    else
                    {
                        v128 c64LoLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(c.v4_0), out v128 c64LoHi);
                        v128 c64HiLo = Xse.cvt2x2epi32_epi64(RegisterConversion.ToV128(c.v4_4), out v128 c64HiHi);
                        c64LoLo = Sse2.add_epi64(c64LoLo, c64LoHi);
                        c64HiLo = Sse2.add_epi64(c64HiLo, c64HiHi);
                        v128 sum = Sse2.add_epi64(c64LoLo, c64HiLo);

                        csum = Sse2.add_epi64(sum, Sse2.bsrli_si128(sum, sizeof(long)));
                    }
                
                    intermediate = Sse2.cvtsi128_si64x(csum);
                }
                else 
                {
                    intermediate = csum((long4)c.v4_0 + c.v4_4);
                }

                return (int)((intermediate + copysign(OFFSET, intermediate)) / 8);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ulong2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 1 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cavg(ulong2 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (1u + csum(c)) / 2;
            }
            else
            {
                return avg(c.x, c.y);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ulong3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 2 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cavg(ulong3 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (2u + csum(c)) / 3;
            }
            else
            {
                UInt128 sum = 2;
                sum += c.x;
                sum += c.y;
                sum += c.z;

                return (sum / 3).lo64;
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.ulong4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if the horizontal sum of <paramref name="c"/> <see langword="+"/> 3 overflows.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong cavg(ulong4 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                return (3u + csum(c)) / 4;
            }
            else
            {
                UInt128 sum = 3;
                sum += c.x;
                sum += c.y;
                sum += c.z;
                sum += c.w;

                return (sum >> 2).lo64;
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.long2"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 1 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cavg(long2 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                long intermediate = csum(c);

                return (intermediate + (long)((ulong)~intermediate >> 63)) >> 1;
            }
            else
            {
                return avg(c.x, c.y, noOverflow);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.long3"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 2 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cavg(long3 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                long intermediate = csum(c);

                return (intermediate + copysign(2, intermediate)) / 3;
            }
            else
            {
                Int128 sum = c.x;
                sum += c.y;
                sum += c.z;
                
                return (long)((sum + copysign(2, sum)) / 3);
            }
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.long4"/>.     </summary>
        /// <remarks>       A <see cref="Promise"/> <paramref name="noOverflow"/> withs its <see cref="Promise.NoOverflow"/> flag set returns undefined results for any column sum of <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 ('+' if the column sum is positive, '-' otherwise) that overflows. It is only recommended to use this overload if each possible summation order of elements in <paramref name="c"/> <see langword="+"/> or <see langword="-"/> 3 is guaranteed not to overflow.     </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long cavg(long4 c, Promise noOverflow = Promise.Nothing)
        {
            if (noOverflow.Promises(Promise.NoOverflow))
            {
                long intermediate = csum(c);

                return (intermediate + copysign(3, intermediate)) / 4;
            }
            else
            {
                Int128 sum = c.x;
                sum += c.y;
                sum += c.z;
                sum += c.w;
                
                return (long)((sum + copysign(3, sum)) / 4);
            }
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cavg(float2 c)
        {
            return 0.5f * math.csum(c);
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="float3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cavg(float3 c)
        {
            return (1f / 3f) * math.csum(c);
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cavg(float4 c)
        {
            return 0.25f * math.csum(c);
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cavg(float8 c)
        {
            return 0.125f * csum(c);
        }


        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cavg(double2 c)
        {
            return 0.5d * math.csum(c);
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="double3"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cavg(double3 c)
        {
            return (1d / 3d) * math.csum(c);
        }

        /// <summary>       Returns the ceiling of the horizontal average value of components in a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cavg(double4 c)
        {
            return 0.25d * math.csum(c);
        }
    }
}