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
            public static v128 movsign_epi8(v128 a, v128 s, bool promise = false, byte elements = 16)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI8(s, 0, elements)))
                    {
                        s = sub_epi8(s, cmpeq_epi8(s, setzero_si128()));
                    }
                    else if (constexpr.ALL_EQ_EPI8(a, 1, elements) || constexpr.ALL_EQ_EPI8(a, -1, elements))
                    {
                        return or_si128(srai_epi8(s, 7), set1_epi8(1));
                    }

                    return sign_epi8(abs_epi8(a, elements), s);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI8(a, 1, elements) || constexpr.ALL_EQ_EPI8(a, -1, elements))
                    {
                        return or_si128(srai_epi8(s, 7), set1_epi8(1));
                    }

                    v128 res = xor_si128(a, s);
                    res = srai_epi8(res, 7);

                    return sub_epi8(xor_si128(a, res), res);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi8(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI8(s, 0)))
                    {
                        s = Avx2.mm256_sub_epi8(s, Avx2.mm256_cmpeq_epi8(s, Avx.mm256_setzero_si256()));
                    }
                    else if (constexpr.ALL_EQ_EPI8(a, 1) || constexpr.ALL_EQ_EPI8(a, -1))
                    {
                        return Avx2.mm256_or_si256(mm256_srai_epi8(s, 7), mm256_set1_epi8(1));
                    }

                    return Avx2.mm256_sign_epi8(mm256_abs_epi8(a), s);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi16(v128 a, v128 s, bool promise = false, byte elements = 8)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI16(s, 0, elements)))
                    {
                        s = sub_epi16(s, cmpeq_epi16(s, setzero_si128()));
                    }
                    else if (constexpr.ALL_EQ_EPI16(a, 1, elements) || constexpr.ALL_EQ_EPI16(a, -1, elements))
                    {
                        return or_si128(srai_epi16(s, 15), set1_epi16(1));
                    }

                    return sign_epi16(abs_epi16(a, elements), s);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI16(a, 1, elements) || constexpr.ALL_EQ_EPI16(a, -1, elements))
                    {
                        return or_si128(srai_epi16(s, 15), set1_epi16(1));
                    }

                    v128 res = xor_si128(a, s);
                    res = srai_epi16(res, 15);

                    return sub_epi16(xor_si128(a, res), res);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi16(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI16(s, 0)))
                    {
                        s = Avx2.mm256_sub_epi16(s, Avx2.mm256_cmpeq_epi16(s, Avx.mm256_setzero_si256()));
                    }
                    else if (constexpr.ALL_EQ_EPI16(a, 1) || constexpr.ALL_EQ_EPI16(a, -1))
                    {
                        return Avx2.mm256_or_si256(mm256_srai_epi16(s, 15), mm256_set1_epi16(1));
                    }

                    return Avx2.mm256_sign_epi16(mm256_abs_epi16(a), s);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi32(v128 a, v128 s, bool promise = false, byte elements = 4)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI32(s, 0, elements)))
                    {
                        s = sub_epi32(s, cmpeq_epi32(s, setzero_si128()));
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, 1, elements) || constexpr.ALL_EQ_EPI32(a, -1, elements))
                    {
                        return or_si128(srai_epi32(s, 31), set1_epi32(1));
                    }

                    return sign_epi32(abs_epi32(a, elements), s);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 1, elements) || constexpr.ALL_EQ_EPI32(a, -1, elements))
                    {
                        return or_si128(srai_epi32(s, 31), set1_epi32(1));
                    }

                    v128 res = xor_si128(a, s);
                    res = srai_epi32(res, 31);

                    return sub_epi32(xor_si128(a, res), res);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi32(v256 a, v256 s, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!(promise || constexpr.ALL_NEQ_EPI32(s, 0)))
                    {
                        s = Avx2.mm256_sub_epi32(s, Avx2.mm256_cmpeq_epi32(s, Avx.mm256_setzero_si256()));
                    }
                    else if (constexpr.ALL_EQ_EPI32(a, 1) || constexpr.ALL_EQ_EPI32(a, -1))
                    {
                        return Avx2.mm256_or_si256(mm256_srai_epi32(s, 31), mm256_set1_epi32(1));
                    }

                    return Avx2.mm256_sign_epi32(mm256_abs_epi32(a), s);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_epi64(v128 a, v128 s)
            {
                if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 1) || constexpr.ALL_EQ_EPI64(a, -1))
                    {
                        return or_si128(set1_epi64x(1), srai_epi64(s, 63));
                    }
                    else
                    {
                        v128 res = xor_si128(a, s);
                        res = srai_epi64(res, 63);

                        return sub_epi64(xor_si128(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_epi64(v256 a, v256 s, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 1, elements) || constexpr.ALL_EQ_EPI64(a, -1, elements))
                    {
                        return Avx2.mm256_or_si256(mm256_set1_epi64x(1), mm256_srai_epi64(s, 63, elements));
                    }
                    else
                    {
                        v256 res = Avx2.mm256_xor_si256(a, s);
                        res = mm256_srai_epi64(res, 63, elements);

                        return Avx2.mm256_sub_epi64(Avx2.mm256_xor_si256(a, res), res);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pq(v128 a, v128 s, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 MASK = set1_epi8(1 << 7);

                    if (!promise)
                    {
                        v128 isZero = cmpeq_epi8(and_si128(s, set1_epi8(0x7F)), setzero_si128());

                        s = andnot_si128(isZero, srai_epi8(s, 7));
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ph(v128 a, v128 s, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 MASK = set1_epi16(1 << 15);

                    if (!promise)
                    {
                        v128 isZero = cmpeq_epi16(and_si128(s, set1_epi16(0x7FFF)), setzero_si128());

                        s = andnot_si128(isZero, srai_epi16(s, 15));
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_ps(v128 a, v128 s, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 MASK = new v128(1 << 31);

                    if (!promise)
                    {
                        s = cmplt_ps(s, setzero_ps());
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_ps(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1 << 31);

                    if (!promise)
                    {
                        s = mm256_cmplt_ps(s, Avx.mm256_setzero_ps());
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 movsign_pd(v128 a, v128 s, bool promise = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 MASK = new v128(1L << 63);

                    if (!promise)
                    {
                        s = cmplt_pd(s, setzero_ps());
                    }

                    return ternarylogic_si128(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_movsign_pd(v256 a, v256 s, bool promise = false)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 MASK = new v256(1L << 63);

                    if (!promise)
                    {
                        s = mm256_cmplt_pd(s, Avx.mm256_setzero_pd());
                    }

                    return mm256_ternarylogic_si256(a, s, MASK, TernaryOperation.OxD8);
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 copysign(Int128 x, Int128 y)
        {
            ulong temp = (ulong)((long)(x.hi64 ^ y.hi64) >> 63);
            ulong lo = x.lo64 ^ temp;
            ulong hi = x.hi64 ^ temp;
            ulong loResult = lo - temp;
            ulong hiResult = hi - temp;
            hiResult -= tobyte(lo < temp);

            return new Int128(loResult, hiResult);
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte copysign(sbyte x, sbyte y)
        {
            return (sbyte)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 copysign(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                sbyte2 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 copysign(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                sbyte3 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 copysign(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                sbyte4 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 copysign(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                sbyte8 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 copysign(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi8(x, y, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                sbyte16 temp = (x ^ y) >> 7;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 copysign(sbyte32 x, sbyte32 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi8(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new sbyte32(copysign(x.v16_0, y.v16_0, nonZero), copysign(x.v16_16, y.v16_16, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short copysign(short x, short y)
        {
            return (short)copysign((int)x, (int)y);
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 copysign(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                short2 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 copysign(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                short3 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 copysign(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                short4 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 copysign(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi16(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                short8 temp = (x ^ y) >> 15;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 copysign(short16 x, short16 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi16(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new short16(copysign(x.v8_0, y.v8_0, nonZero), copysign(x.v8_8, y.v8_8, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int copysign(int x, int y)
        {
            if (constexpr.IS_TRUE(x == 1 || x == -1))
            {
                return (y >> 31) | 1;
            }

            int temp = (x ^ y) >> 31;

            return (x ^ temp) - temp;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 copysign(int2 x, int2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 2));
            }
            else
            {
                int2 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 copysign(int3 x, int3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 3));
            }
            else
            {
                int3 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 copysign(int4 x, int4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.movsign_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 4));
            }
            else
            {
                int4 temp = (x ^ y) >> 31;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="y"/> component that is equal to 0.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 copysign(int8 x, int8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi32(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new int8(copysign(x.v4_0, y.v4_0, nonZero), copysign(x.v4_4, y.v4_4, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long copysign(long x, long y)
        {
            if (constexpr.IS_TRUE(x == 1 || x == -1))
            {
                return (y >> 63) | 1;
            }

            long temp = (x ^ y) >> 63;

            return (x ^ temp) - temp;
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 copysign(long2 x, long2 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_epi64(x, y);
            }
            else
            {
                long2 temp = (x ^ y) >> 63;

                return (x ^ temp) - temp;
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 copysign(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 3);
            }
            else
            {
                return new long3(copysign(x.xy, y.xy), copysign(x.z, y.z));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 copysign(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_movsign_epi64(x, y, 4);
            }
            else
            {
                return new long4(copysign(x.xy, y.xy), copysign(x.zw, y.zw));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter copysign(quarter x, quarter y, Promise nonZero = Promise.Nothing)
        {
            const byte SIGN_MASK = 1 << 7;
            const byte VALUE_MASK = unchecked((byte)(~SIGN_MASK));
            
            byte _x = asbyte(x);
            byte _y = asbyte(y);
            
            uint xAbs = (uint)_x & (uint)VALUE_MASK;
            uint ySign;
            
            if (nonZero.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK & (uint)_y;
            }
            else
            {
                ySign = _y & (touint(y != 0) << 7);
            }
            
            return asquarter((byte)(xAbs | ySign));
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 copysign(quarter2 x, quarter2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 copysign(quarter3 x, quarter3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter3(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 copysign(quarter4 x, quarter4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter4(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero), copysign(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 copysign(quarter8 x, quarter8 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_pq(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new quarter8(copysign(x.x0, y.x0, nonZero), copysign(x.x1, y.x1, nonZero), copysign(x.x2, y.x2, nonZero), copysign(x.x3, y.x3, nonZero), copysign(x.x4, y.x4, nonZero), copysign(x.x5, y.x5, nonZero), copysign(x.x6, y.x6, nonZero), copysign(x.x7, y.x7, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half copysign(half x, half y, Promise nonZero = Promise.Nothing)
        {
            const ushort SIGN_MASK = 1 << 15;
            const ushort VALUE_MASK = unchecked((ushort)(~SIGN_MASK));
            
            ushort _x = asushort(x);
            ushort _y = asushort(y);
            
            uint xAbs = (uint)_x & (uint)VALUE_MASK;
            uint ySign;
            
            if (nonZero.Promises(Promise.NonZero))
            {
                ySign = SIGN_MASK & (uint)_y;
            }
            else
            {
                ySign = _y & (touint(y != 0) << 15);
            }
            
            return ashalf((ushort)(xAbs | ySign));
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 copysign(half2 x, half2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 copysign(half3 x, half3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half3(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 copysign(half4 x, half4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.movsign_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new half4(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero), copysign(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 copysign(half8 x, half8 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_ph(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new half8(copysign(x.x0, y.x0, nonZero), copysign(x.x1, y.x1, nonZero), copysign(x.x2, y.x2, nonZero), copysign(x.x3, y.x3, nonZero), copysign(x.x4, y.x4, nonZero), copysign(x.x5, y.x5, nonZero), copysign(x.x6, y.x6, nonZero), copysign(x.x7, y.x7, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float copysign(float x, float y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).Float0;
            }
            else
            {
                const uint SIGN_MASK = 1u << 31;
                const uint VALUE_MASK = ~SIGN_MASK;

                uint _x = math.asuint(x);
                uint _y = math.asuint(y);

                uint xAbs = _x & VALUE_MASK;
                uint ySign;

                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = SIGN_MASK & _y;
                }
                else
                {
                    ySign = _y & (touint(y != 0) << 31);
                }

                return math.asfloat(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>      
        ///     <para>       A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 copysign(float2 x, float2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new float2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 copysign(float3 x, float3 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new float3(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is  negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 copysign(float4 x, float4 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.movsign_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new float4(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero), copysign(x.z, y.z, nonZero), copysign(x.w, y.w, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 copysign(float8 x, float8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_movsign_ps(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                return new float8(copysign(x.v4_0, y.v4_0, nonZero),
                                  copysign(x.v4_4, y.v4_4, nonZero));
            }
        }


        /// <summary>       Transfers the sign of <paramref name="y"/> onto <paramref name="x"/> and returns the result. If <paramref name="y"/> is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned and if <paramref name="y"/> is greater than or equal to zero, abs(<paramref name="x"/>) is returned.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>), if <paramref name="y"/> is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double copysign(double x, double y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.movsign_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)).Double0;
            }
            else
            {
                const ulong MASK = 1ul << 63;

                ulong _x = math.asulong(x);
                ulong _y = math.asulong(y);

                ulong xAbs = andnot(_x, MASK);
                ulong ySign;

                if (nonZero.Promises(Promise.NonZero))
                {
                    ySign = MASK & _y;
                }
                else
                {
                    ySign = _y & (toulong(y != 0) << 63);
                }

                return math.asdouble(xAbs | ySign);
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 copysign(double2 x, double2 y, Promise nonZero = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.movsign_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new double2(copysign(x.x, y.x, nonZero), copysign(x.y, y.y, nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 copysign(double3 x, double3 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_movsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new double3(copysign(x.xy, y.xy, nonZero),
                                   copysign(x.z,  y.z,  nonZero));
            }
        }

        /// <summary>       Transfers the sign of each <paramref name="y"/> component onto the corresponding <paramref name="x"/> component and returns the result. If a <paramref name="y"/> component is negative, <see langword="-"/>abs(<paramref name="x"/>) is returned for the corresponding component and if a <paramref name="y"/> component is greater than or equal to zero, abs(<paramref name="x"/>) is returned for the corresponding component.
        /// <remarks>       
        ///     <para>      A <see cref="Promise"/> "<paramref name="nonZero"/>" with its <see cref="Promise.NonZero"/> flag set will incorrectly return <see langword="-"/>abs(<paramref name="x"/>) for a component, if the corresponding <paramref name="y"/> component is negative zero, exactly.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 copysign(double4 x, double4 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_movsign_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y), nonZero.Promises(Promise.NonZero)));
            }
            else
            {
                return new double4(copysign(x.xy, y.xy, nonZero),
                                   copysign(x.zw, y.zw, nonZero));
            }
        }
    }
}