using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epu8(v128 a, v128 b, bool promiseNoOverflow = false, bool promiseSpecialRange = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (elements == 3)
                    {
                        if (BurstArchitecture.IsInsertExtractSupported)
                        {
                            if (constexpr.IS_CONST(a))
                            {
                                a = insert_epi8(a, 0, 3);
                            }
                            else
                            {
                                b = insert_epi8(b, 0, 3);
                            }
                        }
                        else
                        {
                            v128 MASK = cvtsi32_si128(0x00FF_FFFF);

                            if (constexpr.IS_CONST(a))
                            {
                                a = and_si128(a, MASK);
                            }
                            else
                            {
                                b = and_si128(b, MASK);
                            }
                        }
                    }

                    v128 result;
                    if (Ssse3.IsSsse3Supported)
                    {
                        if (promiseSpecialRange || (constexpr.ALL_LE_EPU8(a, 127, elements) && constexpr.ALL_LE_EPU8(b, 127, elements)))
                        {
                            result = vsum_epu16(maddubs_epi16(a, b), promiseNoOverflow, (byte)((elements + 1) >> 1));

                            if (promiseNoOverflow)
                            {
                                if (elements < 4)
                                {
                                    constexpr.ASSUME_LE_EPU16(result, elements * (uint)sbyte.MaxValue * (uint)sbyte.MaxValue, 1);
                                }
                            }
                            else
                            {
                                constexpr.ASSUME_LE_EPU32(result, elements * (uint)sbyte.MaxValue * (uint)sbyte.MaxValue, 1);
                            }
                            return result;
                        }
                    }

                    if (elements == 16)
                    {
                        v128 aLo = cvt2x2epu8_epi16(a, out v128 aHi);
                        v128 bLo = cvt2x2epu8_epi16(b, out v128 bHi);

                        aLo = madd_epi16(aLo, bLo);
                        aHi = madd_epi16(aHi, bHi);

                        result = vsum_epu32(add_epi32(aLo, aHi), true, 4);
                    }
                    else
                    {
                        result = vsum_epu32(madd_epi16(cvtepu8_epi16(a), cvtepu8_epi16(b)), true, (byte)((elements + 1) >> 1));
                    }

                    constexpr.ASSUME_LE_EPU32(result, elements * (uint)byte.MaxValue * (uint)byte.MaxValue);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epu16(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue, elements) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue, elements))
                    {
                        return dp_epi16(a, b, promiseNoOverflow, elements);
                    }
                    else
                    {
                        if (promiseNoOverflow)
                        {
                            return vsum_epu16(mullo_epi16(a, b), promiseNoOverflow, elements);
                        }
                        else
                        {
                            if (elements == 8)
                            {
                                v128 aLo = cvt2x2epu16_epi32(a, out v128 aHi);
                                v128 bLo = cvt2x2epu16_epi32(b, out v128 bHi);

                                aLo = mullo_epi32(aLo, bLo);
                                aHi = mullo_epi32(aHi, bHi);

                                return vsum_epu32(add_epi32(aLo, aHi), true, 4);
                            }
                            else
                            {
                                return vsum_epu32(mullo_epi32(cvtepu16_epi32(a), cvtepu16_epi32(b)), true, elements);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epu32(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (promiseNoOverflow)
                    {
                        return vsum_epu32(mullo_epi32(a, b, elements), true);
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            return vsum_epi64(mul_epu32(cvtepu32_epi64(a), cvtepu32_epi64(b)));
                        }
                        else
                        {
                            v128 aLo = cvt2x2epu32_epi64(a, out v128 aHi);
                            v128 bLo = cvt2x2epu32_epi64(b, out v128 bHi);

                            aLo = mul_epu32(aLo, aHi);
                            bLo = mul_epu32(bLo, bHi);

                            if (elements == 4)
                            {
                                return vsum_epi64(add_epi64(aLo, bLo));
                            }
                            else
                            {
                                return add_epi64(add_epi64(aLo, bsrli_si128(aLo, 1 * sizeof(ulong))), bLo);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epu64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return vsum_epi64(mullo_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epu8(v256 a, v256 b, bool promiseNoOverflow = false, bool promiseSpecialRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    if (promiseSpecialRange || (constexpr.ALL_LE_EPU8(a, 127) && constexpr.ALL_LE_EPU8(b, 127)))
                    {
                        result = mm256_vsum_epu16(Avx2.mm256_maddubs_epi16(a, b), promiseNoOverflow);
                        if (!promiseNoOverflow)
                        {
                            constexpr.ASSUME_LE_EPU32(result, 32 * (uint)sbyte.MaxValue * (uint)sbyte.MaxValue, 1);
                        }
                        return result;
                    }

                    v256 aLo = mm256_cvt2x2epu8_epi16(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epu8_epi16(b, out v256 bHi);

                    aLo = Avx2.mm256_madd_epi16(aLo, bLo);
                    aHi = Avx2.mm256_madd_epi16(aHi, bHi);

                    result = mm256_vsum_epu32(Avx2.mm256_add_epi32(aLo, aHi), true);
                    constexpr.ASSUME_LE_EPU32(result, 32 * (uint)byte.MaxValue * (uint)byte.MaxValue);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epu16(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LE_EPU16(a, (ushort)short.MaxValue) && constexpr.ALL_LE_EPU16(b, (ushort)short.MaxValue))
                    {
                        return mm256_dp_epi16(a, b, promiseNoOverflow);
                    }
                    else
                    {
                        if (promiseNoOverflow)
                        {
                            return mm256_vsum_epu16(Avx2.mm256_mullo_epi16(a, b), promiseNoOverflow);
                        }
                        else
                        {
                            v256 aLo = mm256_cvt2x2epu16_epi32(a, out v256 aHi);
                            v256 bLo = mm256_cvt2x2epu16_epi32(b, out v256 bHi);

                            aLo = Avx2.mm256_mullo_epi32(aLo, bLo);
                            aHi = Avx2.mm256_mullo_epi32(aHi, bHi);

                            return mm256_vsum_epu32(Avx2.mm256_add_epi32(aLo, aHi), true);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epu32(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseNoOverflow)
                    {
                        return mm256_vsum_epu32(Avx2.mm256_mullo_epi32(a, b), true);
                    }
                    else
                    {
                        v256 aLo = mm256_cvt2x2epu32_epi64(a, out v256 aHi);
                        v256 bLo = mm256_cvt2x2epu32_epi64(b, out v256 bHi);

                        aLo = Avx2.mm256_mul_epu32(aLo, aHi);
                        bLo = Avx2.mm256_mul_epu32(bLo, bHi);

                        return mm256_vsum_epi64(Avx2.mm256_add_epi64(aLo, bLo));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_vsum_epi64(mm256_mullo_epi64(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epi8(v128 a, v128 b, bool promiseNoOverflow = false, bool promiseSpecialRange = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (elements == 3)
                    {
                        if (BurstArchitecture.IsInsertExtractSupported)
                        {
                            if (constexpr.IS_CONST(a))
                            {
                                a = insert_epi8(a, 0, 3);
                            }
                            else
                            {
                                b = insert_epi8(b, 0, 3);
                            }
                        }
                        else
                        {
                            v128 MASK = cvtsi32_si128(0x00FF_FFFF);

                            if (constexpr.IS_CONST(a))
                            {
                                a = and_si128(a, MASK);
                            }
                            else
                            {
                                b = and_si128(b, MASK);
                            }
                        }
                    }

                    v128 result;
                    if (Ssse3.IsSsse3Supported)
                    {
                        // both unsigned and <= 127 test on left vector
                        if (promiseSpecialRange || (constexpr.ALL_LE_EPU8(a, 127, elements) && constexpr.ALL_NEQ_EPI8(b, -128, elements)))
                        {
                            result = vsum_epi16(maddubs_epi16(a, b), promiseNoOverflow, (byte)((elements + 1) >> 1));
                            if (promiseNoOverflow)
                            {
                                if (elements <= 4)
                                {
                                    constexpr.ASSUME_RANGE_EPI16(result, elements * -(sbyte.MaxValue * sbyte.MaxValue), elements * sbyte.MaxValue * sbyte.MaxValue, 1);
                                }
                            }
                            else
                            {
                                constexpr.ASSUME_RANGE_EPI32(result, elements * -(sbyte.MaxValue * sbyte.MaxValue), elements * sbyte.MaxValue * sbyte.MaxValue, 1);
                            }
                            return result;
                        }
                        if (constexpr.ALL_LE_EPU8(b, 127, elements) && constexpr.ALL_NEQ_EPI8(a, -128, elements))
                        {
                            result = vsum_epi16(maddubs_epi16(b, a), promiseNoOverflow, (byte)((elements + 1) >> 1));
                            if (promiseNoOverflow)
                            {
                                if (elements <= 4)
                                {
                                    constexpr.ASSUME_RANGE_EPI16(result, elements * -(sbyte.MaxValue * sbyte.MaxValue), elements * sbyte.MaxValue * sbyte.MaxValue, 1);
                                }
                            }
                            else
                            {
                                constexpr.ASSUME_RANGE_EPI32(result, elements * -(sbyte.MaxValue * sbyte.MaxValue), elements * sbyte.MaxValue * sbyte.MaxValue, 1);
                            }
                            return result;
                        }
                    }

                    if (elements == 16)
                    {
                        v128 aLo = cvt2x2epi8_epi16(a, out v128 aHi);
                        v128 bLo = cvt2x2epi8_epi16(b, out v128 bHi);

                        aLo = madd_epi16(aLo, bLo);
                        aHi = madd_epi16(aHi, bHi);

                        result = vsum_epi32(add_epi32(aLo, aHi), true, 4);
                    }
                    else
                    {
                        result = vsum_epi32(madd_epi16(cvtepi8_epi16(a), cvtepi8_epi16(b)), true, (byte)((elements + 1) >> 1));
                    }

                    constexpr.ASSUME_RANGE_EPI32(result, elements * sbyte.MinValue * sbyte.MaxValue, elements * unchecked((byte)sbyte.MinValue) * unchecked((byte)sbyte.MinValue));
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epi16(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (elements == 3)
                    {
                        if (constexpr.IS_CONST(a))
                        {
                            a = insert_epi16(a, 0, 3);
                        }
                        else
                        {
                            b = insert_epi16(b, 0, 3);
                        }
                    }

                    v128 result = vsum_epi32(madd_epi16(a, b), promiseNoOverflow, (byte)((elements + 1) >> 1));
                    if (elements == 2)
                    {
                        constexpr.ASSUME_RANGE_EPI32(result, 2 * -32768 * 32767, int.MaxValue);
                    }
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epi32(v128 a, v128 b, bool promiseNoOverflow = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (promiseNoOverflow)
                    {
                        return vsum_epi32(mullo_epi32(a, b, elements), true);
                    }
                    else
                    {
                        if (elements == 2)
                        {
                            return vsum_epi64(mul_epi32(cvtepu32_epi64(a), cvtepu32_epi64(b)));
                        }
                        else
                        {
                            v128 aLo = cvt2x2epi32_epi64(a, out v128 aHi);
                            v128 bLo = cvt2x2epi32_epi64(b, out v128 bHi);

                            aLo = mul_epi32(aLo, aHi);
                            bLo = mul_epi32(bLo, bHi);

                            if (elements == 4)
                            {
                                return vsum_epi64(add_epi64(aLo, bLo));
                            }
                            else
                            {
                                return add_epi64(add_epi64(aLo, bsrli_si128(aLo, 1 * sizeof(long))), bLo);
                            }
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dp_epi64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return vsum_epi64(mullo_epi64(a, b));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epi8(v256 a, v256 b, bool promiseNoOverflow = false, bool promiseSpecialRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;
                    // both unsigned and <= 127 test on left vector
                    if (promiseSpecialRange || (constexpr.ALL_LE_EPU8(a, 127) && constexpr.ALL_NEQ_EPI8(b, -128)))
                    {
                        result = mm256_vsum_epi16(Avx2.mm256_maddubs_epi16(a, b), promiseNoOverflow);
                        if (!promiseNoOverflow)
                        {
                            constexpr.ASSUME_RANGE_EPI32(result, 32 * -(sbyte.MaxValue * sbyte.MaxValue), 32 * sbyte.MaxValue * sbyte.MaxValue);
                        }
                        return result;
                    }
                    if (constexpr.ALL_LE_EPU8(b, 127) && constexpr.ALL_NEQ_EPI8(a, -128))
                    {
                        result = mm256_vsum_epi16(Avx2.mm256_maddubs_epi16(b, a), promiseNoOverflow);
                        if (!promiseNoOverflow)
                        {
                            constexpr.ASSUME_RANGE_EPI32(result, 32 * -(sbyte.MaxValue * sbyte.MaxValue), 32 * sbyte.MaxValue * sbyte.MaxValue);
                        }
                        return result;
                    }

                    v256 aLo = mm256_cvt2x2epi8_epi16(a, out v256 aHi);
                    v256 bLo = mm256_cvt2x2epi8_epi16(b, out v256 bHi);

                    aLo = Avx2.mm256_madd_epi16(aLo, bLo);
                    aHi = Avx2.mm256_madd_epi16(aHi, bHi);

                    result = mm256_vsum_epi32(Avx2.mm256_add_epi32(aLo, aHi), true);
                    constexpr.ASSUME_RANGE_EPI32(result, 32 * sbyte.MinValue * sbyte.MaxValue, 32 * unchecked((byte)sbyte.MinValue) * unchecked((byte)sbyte.MinValue));
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epi16(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_vsum_epi32(Avx2.mm256_madd_epi16(a, b), promiseNoOverflow);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epi32(v256 a, v256 b, bool promiseNoOverflow = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseNoOverflow)
                    {
                        return mm256_vsum_epi32(Avx2.mm256_mullo_epi32(a, b), true);
                    }
                    else
                    {
                        v256 aLo = mm256_cvt2x2epi32_epi64(a, out v256 aHi);
                        v256 bLo = mm256_cvt2x2epi32_epi64(b, out v256 bHi);

                        aLo = Avx2.mm256_mul_epi32(aLo, aHi);
                        bLo = Avx2.mm256_mul_epi32(bLo, bHi);

                        return mm256_vsum_epi64(Avx2.mm256_add_epi64(aLo, bLo));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dp_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return mm256_vsum_epi64(mm256_mullo_epi64(a, b, elements));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the dot product of two <see cref="MaxMath.float8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dot(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                x = Avx.mm256_dp_ps(x, y, 255);

                return Xse.add_ss(Avx.mm256_castps256_ps128(x), Avx.mm256_extractf128_ps(x, 1)).Float0;
            }
            else
            {
                return math.dot(x.v4_0, y.v4_0) + math.dot(x.v4_4, y.v4_4);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte2"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 2ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte2 a, byte2 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epu8(a, b, noOverflow, specialRange, 2);

                return (noOverflow & specialRange) ? result.UShort0 : result.UInt0;
            }
            else
            {
                return ((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte3"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 3ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte3 a, byte3 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epu8(a, b, noOverflow, specialRange, 3);

                return noOverflow ? result.UShort0 : result.UInt0;
            }
            else
            {
                return ((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y) + ((uint)a.z * (uint)b.z);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte4"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 4ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte4 a, byte4 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epu8(a, b, noOverflow, specialRange, 4);

                return noOverflow ? result.UShort0 : result.UInt0;
            }
            else
            {
                return ((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y) + ((uint)a.z * (uint)b.z) + ((uint)a.w * (uint)b.w);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte8"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 8ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte8 a, byte8 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epu8(a, b, noOverflow, specialRange, 8);

                return noOverflow ? result.UShort0 : result.UInt0;
            }
            else
            {
                return ((uint)a.x0 * (uint)b.x0) + ((uint)a.x1 * (uint)b.x1) + ((uint)a.x2 * (uint)b.x2) + ((uint)a.x3 * (uint)b.x3) + ((uint)a.x4 * (uint)b.x4) + ((uint)a.x5 * (uint)b.x5) + ((uint)a.x6 * (uint)b.x6) + ((uint)a.x7 * (uint)b.x7);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte16"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 16ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte16 a, byte16 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epu8(a, b, noOverflow, specialRange, 16);

                return noOverflow ? result.UShort0 : result.UInt0;
            }
            else
            {
                return ((uint)a.x0 * (uint)b.x0) + ((uint)a.x1 * (uint)b.x1) + ((uint)a.x2 * (uint)b.x2) + ((uint)a.x3 * (uint)b.x3) + ((uint)a.x4 * (uint)b.x4) + ((uint)a.x5 * (uint)b.x5) + ((uint)a.x6 * (uint)b.x6) + ((uint)a.x7 * (uint)b.x7) + ((uint)a.x8 * (uint)b.x8) + ((uint)a.x9 * (uint)b.x9) + ((uint)a.x10 * (uint)b.x10) + ((uint)a.x11 * (uint)b.x11) + ((uint)a.x12 * (uint)b.x12) + ((uint)a.x13 * (uint)b.x13) + ((uint)a.x14 * (uint)b.x14) + ((uint)a.x15 * (uint)b.x15);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.byte32"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. This overload is safe if each element is less than 128.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 32ul * 255ul * 255ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(byte32 a, byte32 b, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v256 result = Xse.mm256_dp_epu8(a, b, noOverflow, specialRange);

                if (noOverflow)
                {
                    return Xse.add_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UShort0;
                }
                else
                {
                    return Xse.add_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).UInt0;
                }
            }
            else
            {
                return dot(a.v16_0, b.v16_0, promises) + dot(a.v16_16, b.v16_16, promises);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte2"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-2 * 128 * 127, 2 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte2 a, sbyte2 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epi8(a, b, noOverflow, specialRange, 2);

                return noOverflow ? result.SShort0 : result.SInt0;
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte3"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-3 * 128 * 127, 3 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte3 a, sbyte3 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epi8(a, b, noOverflow, specialRange, 3);

                return noOverflow ? result.SShort0 : result.SInt0;
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte4"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-4 * 128 * 127, 4 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte4 a, sbyte4 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epi8(a, b, noOverflow, specialRange, 4);

                return noOverflow ? result.SShort0 : result.SInt0;
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y) + (a.z * b.z) + (a.w * b.w);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte8"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-8 * 128 * 127, 8 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte8 a, sbyte8 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epi8(a, b, noOverflow, specialRange, 8);

                return noOverflow ? result.SShort0 : result.SInt0;
            }
            else
            {
                return (a.x0 * b.x0) + (a.x1 * b.x1) + (a.x2 * b.x2) + (a.x3 * b.x3) + (a.x4 * b.x4) + (a.x5 * b.x5) + (a.x6 * b.x6) + (a.x7 * b.x7);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte16"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-16 * 128 * 127, 16 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte16 a, sbyte16 b, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v128 result = Xse.dp_epi8(a, b, noOverflow, specialRange, 16);

                return noOverflow ? result.SShort0 : result.SInt0;
            }
            else
            {
                return (a.x0 * b.x0) + (a.x1 * b.x1) + (a.x2 * b.x2) + (a.x3 * b.x3) + (a.x4 * b.x4) + (a.x5 * b.x5) + (a.x6 * b.x6) + (a.x7 * b.x7) + (a.x8 * b.x8) + (a.x9 * b.x9) + (a.x10 * b.x10) + (a.x11 * b.x11) + (a.x12 * b.x12) + (a.x13 * b.x13) + (a.x14 * b.x14) + (a.x15 * b.x15);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.sbyte32"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.     </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components combined with the first summation of adjacent products, i.e. (<paramref name="a"/>.x * <paramref name="b"/>.x) + (<paramref name="a"/>.y * <paramref name="b"/>.y) for each pair of 2 adjacent elements in both vectors, results in a signed 16 bit overflow. Additionally, each element in <paramref name="a"/> must be greater than or equal to 0. This overload is safe if each element in <paramref name="a"/> lies within the interval [0, 127] and each elements in <paramref name="b"/> lies within the interval [-127, 127].      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-32 * 128 * 127, 32 * 128 * 128)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(sbyte32 a, sbyte32 b, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                bool noOverflow = promises.Promises(Promise.NoOverflow);
                bool specialRange = promises.Promises(Promise.Unsafe0);
                v256 result = Xse.mm256_dp_epi8(a, b, noOverflow, specialRange);

                if (noOverflow)
                {
                    return Xse.add_epi16(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SShort0;
                }
                else
                {
                    return Xse.add_epi32(Avx.mm256_castsi256_si128(result), Avx2.mm256_extracti128_si256(result, 1)).SInt0;
                }
            }
            else
            {
                return dot(a.v16_0, b.v16_0, promises) + dot(a.v16_16, b.v16_16, promises);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.short2"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(2 * -32768 * 32767, int.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short2 a, short2 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epi16(a, b, true, 2).SShort0;
                }
                else
                {
                    return Xse.dp_epi16(a, b, false, 2).SInt0;
                }
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short3"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short3 a, short3 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epi16(a, b, true, 3).SShort0;
                }
                else
                {
                    return Xse.dp_epi16(a, b, false, 3).SInt0;
                }
            }
            else
            {
                return (a.x * b.x) + (a.y * b.y) + (a.z * b.z);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short4"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short4 a, short4 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epi16(a, b, true, 4).SShort0;
                }
                else
                {
                    return Xse.dp_epi16(a, b, false, 4).SInt0;
                }
            }
            else
            {
                return ((a.x * b.x) + (a.y * b.y)) + ((a.z * b.z) + (a.w * b.w));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short8"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short8 a, short8 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epi16(a, b, true, 8).SShort0;
                }
                else
                {
                    return Xse.dp_epi16(a, b, false, 8).SInt0;
                }
            }
            else
            {
                return (((a.x0 * b.x0) + (a.x1 * b.x1)) + ((a.x2 * b.x2) + (a.x3 * b.x3))) + (((a.x4 * b.x4) + (a.x5 * b.x5)) + ((a.x6 * b.x6) + (a.x7 * b.x7)));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.short16"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(short16 a, short16 b, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 halfs = Xse.mm256_dp_epi16(a, b, true);
                    v128 epi16 = Xse.add_epi16(Avx.mm256_castsi256_si128(halfs), Avx2.mm256_extracti128_si256(halfs, 1));

                    return epi16.SShort0;
                }
                else
                {
                    v256 halfs = Xse.mm256_dp_epi16(a, b, false);
                    v128 epi32 = Xse.add_epi32(Avx.mm256_castsi256_si128(halfs), Avx2.mm256_extracti128_si256(halfs, 1));

                    return epi32.SInt0;
                }
            }
            else
            {
                return dot(a.v8_0, b.v8_0, noOverflow) + dot(a.v8_8, b.v8_8, noOverflow);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort2"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort2 a, ushort2 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epu16(a, b, true, 2).UShort0;
                }
                else
                {
                    return Xse.dp_epu16(a, b, false, 2).UInt0;
                }
            }
            else
            {
                return (((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort3"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort3 a, ushort3 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epu16(a, b, true, 3).UShort0;
                }
                else
                {
                    return Xse.dp_epu16(a, b, false, 3).UInt0;
                }
            }
            else
            {
                return (((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y)) + ((uint)a.z * (uint)b.z);
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort4"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort4 a, ushort4 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epu16(a, b, true, 4).UShort0;
                }
                else
                {
                    return Xse.dp_epu16(a, b, false, 4).UInt0;
                }
            }
            else
            {
                return (((uint)a.x * (uint)b.x) + ((uint)a.y * (uint)b.y)) + (((uint)a.z * (uint)b.z) + ((uint)a.w * (uint)b.w));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort8"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort8 a, ushort8 b, Promise noOverflow = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    return Xse.dp_epu16(a, b, true, 8).UShort0;
                }
                else
                {
                    return Xse.dp_epu16(a, b, false, 8).UInt0;
                }
            }
            else
            {
                return ((((uint)a.x0 * (uint)b.x0) + ((uint)a.x1 * (uint)b.x1)) + (((uint)a.x2 * (uint)b.x2) + ((uint)a.x3 * (uint)b.x3))) + ((((uint)a.x4 * (uint)b.x4) + ((uint)a.x5 * (uint)b.x5)) + (((uint)a.x6 * (uint)b.x6) + ((uint)a.x7 * (uint)b.x7)));
            }
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ushort16"/>s.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="noOverflow"/>' with its <see cref="Promise.NoOverflow"/> flag set returns undefined results if any multiplication of corresponding <paramref name="x"/> and <paramref name="y"/> components or any possible summation of all resulting products produces a 16-bit overflow.      </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(ushort16 a, ushort16 b, Promise noOverflow = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (noOverflow.Promises(Promise.NoOverflow))
                {
                    v256 halfs = Xse.mm256_dp_epu16(a, b, true);
                    v128 epi16 = Xse.add_epi16(Avx.mm256_castsi256_si128(halfs), Avx2.mm256_extracti128_si256(halfs, 1));

                    return epi16.UShort0;
                }
                else
                {
                    v256 halfs = Xse.mm256_dp_epu16(a, b, false);
                    v128 epi32 = Xse.add_epi32(Avx.mm256_castsi256_si128(halfs), Avx2.mm256_extracti128_si256(halfs, 1));

                    return epi32.UInt0;
                }
            }
            else
            {
                return dot(a.v8_0, b.v8_0, noOverflow) + dot(a.v8_8, b.v8_8, noOverflow);
            }
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.int8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int dot(int8 x, int8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.uint8"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint dot(uint8 x, uint8 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.long2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long2 x, long2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.long3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long3 x, long3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.long4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long dot(long4 x, long4 y)
        {
            return csum(x * y);
        }


        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong2"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong2 x, ulong2 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong3"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong3 x, ulong3 y)
        {
            return csum(x * y);
        }

        /// <summary>       Returns the dot product of two <see cref="MaxMath.ulong4"/>s.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong dot(ulong4 x, ulong4 y)
        {
            return csum(x * y);
        }
    }
}