using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 inc_pq(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PQ(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PQ(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PQ(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PQ(a, elements) && constexpr.ALL_NEQ_PQ(a, quarter.PositiveInfinity, elements) && constexpr.ALL_NEQ_PH(a, quarter.NegativeInfinity, elements);
                    
                    v128 ONE = set1_epi8(1);

                    v128 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = blendv_epi8(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = or_si128(srai_epi8(a, 7), ONE);
                            }
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = set1_epi8(1 << 7);

                        v128 negative0 = cmpeq_epi8(a, NEGATIVE_ZERO);
                        summand = ternarylogic_si128(negative0, srai_epi8(a, 7), ONE, TernaryOperation.OxAE);
                        a = andnot_si128(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi8(quarter.SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi8(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return sub_epi8(a, summand);
                    }
                    else
                    {
                        return add_epi8(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 inc_ph(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 8)
            {
                if (Architecture.IsSIMDSupported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PH(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PH(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PH(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PH(a, elements) && constexpr.ALL_NEQ_PH(a, (half)float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PH(a, (half)float.NegativeInfinity, elements);
                    
                    v128 ONE = set1_epi16(1);

                    v128 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            summand = or_si128(srai_epi16(a, 15), ONE);
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = set1_epi16(1 << 15);

                        v128 negative0 = cmpeq_epi16(a, NEGATIVE_ZERO);
                        summand = ternarylogic_si128(negative0, srai_epi16(a, 15), ONE, TernaryOperation.OxAE);
                        a = andnot_si128(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi16(F16_SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi16(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return sub_epi16(a, summand);
                    }
                    else
                    {
                        return add_epi16(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 inc_ps(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (Architecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f, elements);
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f, elements);
                    promiseNegative |= constexpr.ALL_LT_PS(a, 0f, elements);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PS(a, elements) && constexpr.ALL_NEQ_PS(a, float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PS(a, float.NegativeInfinity, elements);
                    
                    v128 ONE = set1_epi32(1);

                    v128 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = blendv_ps(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = or_si128(srai_epi32(a, 31), ONE);
                            }
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = set1_epi32(1 << 31);

                        v128 negative0 = cmpeq_epi32(a, NEGATIVE_ZERO);
                        summand = ternarylogic_si128(negative0, srai_epi32(a, 31), ONE, TernaryOperation.OxAE);
                        a = andnot_si128(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi32(F32_SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi32(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return sub_epi32(a, summand);
                    }
                    else
                    {
                        return add_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_inc_ps(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PS(a, 0f);
                    promisePositive |= constexpr.ALL_GT_PS(a, 0f);
                    promiseNegative |= constexpr.ALL_LT_PS(a, 0f);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PS(a) && constexpr.ALL_NEQ_PS(a, float.PositiveInfinity) && constexpr.ALL_NEQ_PS(a, float.NegativeInfinity);
                    
                    v256 ONE = mm256_set1_epi32(1);

                    v256 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx.mm256_blendv_ps(ONE, mm256_setall_si256(), a);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = mm256_set1_epi32(1 << 31);

                        v256 negative0 = Avx2.mm256_cmpeq_epi32(a, NEGATIVE_ZERO);
                        summand = mm256_ternarylogic_si256(negative0, Avx2.mm256_srai_epi32(a, 31), ONE, TernaryOperation.OxAE);
                        a = Avx2.mm256_andnot_si256(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi32(F32_SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi32(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_sub_epi32(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_add_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 inc_pd(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Architecture.IsSIMDSupported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d);
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d);
                    promiseNegative |= constexpr.ALL_LT_PD(a, 0d);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PD(a) && constexpr.ALL_NEQ_PD(a, double.PositiveInfinity) && constexpr.ALL_NEQ_PD(a, double.NegativeInfinity);
                    
                    v128 ONE = set1_epi64x(1);

                    v128 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = setall_si128();
                        }
                        else
                        {
                            if (Sse4_1.IsSse41Supported)
                            {
                                summand = blendv_pd(ONE, setall_si128(), a);
                            }
                            else
                            {
                                summand = or_si128(srai_epi64(a, 63), ONE);
                            }
                        }
                    }
                    else
                    {
                        v128 NEGATIVE_ZERO = set1_epi64x(1L << 63);

                        v128 negative0 = cmpeq_epi64(a, NEGATIVE_ZERO);
                        summand = ternarylogic_si128(negative0, srai_epi64(a, 63), ONE, TernaryOperation.OxAE);
                        a = andnot_si128(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi64x(F64_SIGNALING_EXPONENT);

                        v128 nanInf;
                        if (Architecture.IsCMP64Supported)
                        {
                            nanInf = cmpeq_epi64(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        }
                        else
                        {
                            nanInf = shuffle_epi32(cmpeq_epi32(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT)), Sse.SHUFFLE(3, 3, 1, 1));
                        }

                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return sub_epi64(a, summand);
                    }
                    else
                    {
                        return add_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_inc_pd(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    promiseNonZero |= constexpr.ALL_NEQ_PD(a, 0d, elements);
                    promisePositive |= constexpr.ALL_GT_PD(a, 0d, elements);
                    promiseNegative |= constexpr.ALL_LT_PD(a, 0d, elements);
                    promiseNotNanInf |= constexpr.ALL_NOTNAN_PD(a, elements) && constexpr.ALL_NEQ_PD(a, double.PositiveInfinity, elements) && constexpr.ALL_NEQ_PD(a, double.NegativeInfinity, elements);
                    
                    v256 ONE = mm256_set1_epi64x(1);

                    v256 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx.mm256_blendv_pd(ONE, mm256_setall_si256(), a);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = mm256_set1_epi64x(1L << 63);

                        v256 negative0 = Avx2.mm256_cmpeq_epi64(a, NEGATIVE_ZERO);
                        summand = mm256_ternarylogic_si256(negative0, mm256_srai_epi64(a, 63, elements), ONE, TernaryOperation.OxAE);
                        a = Avx2.mm256_andnot_si256(negative0, a);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi64(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_sub_epi64(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_add_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the next closest <see cref="UInt128"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 nextgreater(UInt128 x)
        {
            return x + tobyte(x != UInt128.MaxValue);
        }


        /// <summary>       Returns the next closest <see cref="Int128"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 nextgreater(Int128 x)
        {
            return x + tobyte(x != Int128.MaxValue);
        }


        /// <summary>       Returns the next closest <see cref="byte"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte nextgreater(byte x)
        {
            return (byte)(x + tobyte(x != byte.MaxValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.byte2"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 nextgreater(byte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu8(x);
            }
            else
            {
                return new byte2(nextgreater(x.x),
                                 nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte3"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 nextgreater(byte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu8(x);
            }
            else
            {
                return new byte3(nextgreater(x.x),
                                 nextgreater(x.y),
                                 nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte4"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 nextgreater(byte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu8(x);
            }
            else
            {
                return new byte4(nextgreater(x.x),
                                 nextgreater(x.y),
                                 nextgreater(x.z),
                                 nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte8"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 nextgreater(byte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu8(x);
            }
            else
            {
                return new byte8(nextgreater(x.x0),
                                 nextgreater(x.x1),
                                 nextgreater(x.x2),
                                 nextgreater(x.x3),
                                 nextgreater(x.x4),
                                 nextgreater(x.x5),
                                 nextgreater(x.x6),
                                 nextgreater(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte16"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 nextgreater(byte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu8(x);
            }
            else
            {
                return new byte16(nextgreater(x.x0),
                                  nextgreater(x.x1),
                                  nextgreater(x.x2),
                                  nextgreater(x.x3),
                                  nextgreater(x.x4),
                                  nextgreater(x.x5),
                                  nextgreater(x.x6),
                                  nextgreater(x.x7),
                                  nextgreater(x.x8),
                                  nextgreater(x.x9),
                                  nextgreater(x.x10),
                                  nextgreater(x.x11),
                                  nextgreater(x.x12),
                                  nextgreater(x.x13),
                                  nextgreater(x.x14),
                                  nextgreater(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte32"/>, where each component is the next closest <see cref="byte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 nextgreater(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epu8(x);
            }
            else
            {
                return new byte32(nextgreater(x.v16_0),
                                  nextgreater(x.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="sbyte"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte nextgreater(sbyte x)
        {
            return (sbyte)(x + tosbyte(x != sbyte.MaxValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte2"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nextgreater(sbyte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi8(x);
            }
            else
            {
                return new sbyte2(nextgreater(x.x),
                                  nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte3"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nextgreater(sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi8(x);
            }
            else
            {
                return new sbyte3(nextgreater(x.x),
                                  nextgreater(x.y),
                                  nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte4"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nextgreater(sbyte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi8(x);
            }
            else
            {
                return new sbyte4(nextgreater(x.x),
                                  nextgreater(x.y),
                                  nextgreater(x.z),
                                  nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte8"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nextgreater(sbyte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi8(x);
            }
            else
            {
                return new sbyte8(nextgreater(x.x0),
                                  nextgreater(x.x1),
                                  nextgreater(x.x2),
                                  nextgreater(x.x3),
                                  nextgreater(x.x4),
                                  nextgreater(x.x5),
                                  nextgreater(x.x6),
                                  nextgreater(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte16"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nextgreater(sbyte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi8(x);
            }
            else
            {
                return new sbyte16(nextgreater(x.x0),
                                   nextgreater(x.x1),
                                   nextgreater(x.x2),
                                   nextgreater(x.x3),
                                   nextgreater(x.x4),
                                   nextgreater(x.x5),
                                   nextgreater(x.x6),
                                   nextgreater(x.x7),
                                   nextgreater(x.x8),
                                   nextgreater(x.x9),
                                   nextgreater(x.x10),
                                   nextgreater(x.x11),
                                   nextgreater(x.x12),
                                   nextgreater(x.x13),
                                   nextgreater(x.x14),
                                   nextgreater(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte32"/>, where each component is the next closest <see cref="sbyte"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nextgreater(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epi8(x);
            }
            else
            {
                return new sbyte32(nextgreater(x.v16_0),
                                   nextgreater(x.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="ushort"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort nextgreater(ushort x)
        {
            return (ushort)(x + tobyte(x != ushort.MaxValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort2"/>, where each component is the next closest <see cref="ushort"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 nextgreater(ushort2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu16(x);
            }
            else
            {
                return new ushort2(nextgreater(x.x),
                                   nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort3"/>, where each component is the next closest <see cref="ushort"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 nextgreater(ushort3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu16(x);
            }
            else
            {
                return new ushort3(nextgreater(x.x),
                                   nextgreater(x.y),
                                   nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort4"/>, where each component is the next closest <see cref="ushort"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 nextgreater(ushort4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu16(x);
            }
            else
            {
                return new ushort4(nextgreater(x.x),
                                   nextgreater(x.y),
                                   nextgreater(x.z),
                                   nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort8"/>, where each component is the next closest <see cref="ushort"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 nextgreater(ushort8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu16(x);
            }
            else
            {
                return new ushort8(nextgreater(x.x0),
                                   nextgreater(x.x1),
                                   nextgreater(x.x2),
                                   nextgreater(x.x3),
                                   nextgreater(x.x4),
                                   nextgreater(x.x5),
                                   nextgreater(x.x6),
                                   nextgreater(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort16"/>, where each component is the next closest <see cref="ushort"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 nextgreater(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epu16(x);
            }
            else
            {
                return new ushort16(nextgreater(x.v8_0),
                                    nextgreater(x.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="short"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short nextgreater(short x)
        {
            return (short)(x + tobyte(x != short.MaxValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.short2"/>, where each component is the next closest <see cref="short"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nextgreater(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi16(x);
            }
            else
            {
                return new short2(nextgreater(x.x),
                                  nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/>, where each component is the next closest <see cref="short"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nextgreater(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi16(x);
            }
            else
            {
                return new short3(nextgreater(x.x),
                                  nextgreater(x.y),
                                  nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/>, where each component is the next closest <see cref="short"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nextgreater(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi16(x);
            }
            else
            {
                return new short4(nextgreater(x.x),
                                  nextgreater(x.y),
                                  nextgreater(x.z),
                                  nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/>, where each component is the next closest <see cref="short"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nextgreater(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi16(x);
            }
            else
            {
                return new short8(nextgreater(x.x0),
                                  nextgreater(x.x1),
                                  nextgreater(x.x2),
                                  nextgreater(x.x3),
                                  nextgreater(x.x4),
                                  nextgreater(x.x5),
                                  nextgreater(x.x6),
                                  nextgreater(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/>, where each component is the next closest <see cref="short"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nextgreater(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epi16(x);
            }
            else
            {
                return new short16(nextgreater(x.v8_0),
                                   nextgreater(x.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="uint"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint nextgreater(uint x)
        {
            return x + tobyte(x != uint.MaxValue);
        }

        /// <summary>       Returns a <see cref="uint2"/>, where each component is the next closest <see cref="uint"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 nextgreater(uint2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.incs_epu32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new uint2(nextgreater(x.x),
                                 nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="uint3"/>, where each component is the next closest <see cref="uint"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 nextgreater(uint3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.incs_epu32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new uint3(nextgreater(x.x),
                                 nextgreater(x.y),
                                 nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="uint4"/>, where each component is the next closest <see cref="uint"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 nextgreater(uint4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.incs_epu32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new uint4(nextgreater(x.x),
                                 nextgreater(x.y),
                                 nextgreater(x.z),
                                 nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.uint8"/>, where each component is the next closest <see cref="uint"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 nextgreater(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epu32(x);
            }
            else
            {
                return new uint8(nextgreater(x.v4_0),
                                 nextgreater(x.v4_4));
            }
        }


        /// <summary>       Returns the next closest <see cref="int"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int nextgreater(int x)
        {
            return x + tobyte(x != int.MaxValue);
        }

        /// <summary>       Returns a <see cref="int2"/>, where each component is the next closest <see cref="int"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 nextgreater(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.incs_epi32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new int2(nextgreater(x.x),
                                nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="int3"/>, where each component is the next closest <see cref="int"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 nextgreater(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.incs_epi32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new int3(nextgreater(x.x),
                                nextgreater(x.y),
                                nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="int4"/>, where each component is the next closest <see cref="int"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 nextgreater(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.incs_epi32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new int4(nextgreater(x.x),
                                nextgreater(x.y),
                                nextgreater(x.z),
                                nextgreater(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.int8"/>, where each component is the next closest <see cref="int"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 nextgreater(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epi32(x);
            }
            else
            {
                return new int8(nextgreater(x.v4_0),
                                nextgreater(x.v4_4));
            }
        }


        /// <summary>       Returns the next closest <see cref="ulong"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong nextgreater(ulong x)
        {
            return x + tobyte(x != ulong.MaxValue);
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong2"/>, where each component is the next closest <see cref="ulong"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 nextgreater(ulong2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epu64(x);
            }
            else
            {
                return new ulong2(nextgreater(x.x),
                                  nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong3"/>, where each component is the next closest <see cref="ulong"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 nextgreater(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epu64(x, 3);
            }
            else
            {
                return new ulong3(nextgreater(x.xy),
                                  nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong4"/>, where each component is the next closest <see cref="ulong"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 nextgreater(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epu64(x, 4);
            }
            else
            {
                return new ulong4(nextgreater(x.xy),
                                  nextgreater(x.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="long"/> greater than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long nextgreater(long x)
        {
            return x + tobyte(x != long.MaxValue);
        }

        /// <summary>       Returns a <see cref="MaxMath.long2"/>, where each component is the next closest <see cref="long"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 nextgreater(long2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.incs_epi64(x);
            }
            else
            {
                return new long2(nextgreater(x.x),
                                 nextgreater(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/>, where each component is the next closest <see cref="long"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 nextgreater(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epi64(x, 3);
            }
            else
            {
                return new long3(nextgreater(x.xy),
                                 nextgreater(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/>, where each component is the next closest <see cref="long"/> greater than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nextgreater(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_incs_epi64(x, 4);
            }
            else
            {
                return new long4(nextgreater(x.xy),
                                 nextgreater(x.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="quarter"/> greater than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nextgreater(quarter x, Promise promises = Promise.Nothing)
        {
            int __x = assbyte(x);
            int summand;
            
            if (promises.Promises(Promise.NonZero))
            {
                if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                {
                    summand = 1;
                }
                else
                {
                    summand = 1 | (__x >> 31);
                }
            }
            else
            {
                int notNegative0 = -tobyte((uint)__x != 0xFFFF_FF80);
                summand = 1 | ((__x >> 31) & notNegative0);
                __x &= notNegative0;
            }
            
            if (!promises.Promises(Promise.Unsafe0))
            {
                int notNanInf = -tobyte((__x & quarter.SIGNALING_EXPONENT) != quarter.SIGNALING_EXPONENT);
                summand &= notNanInf;
            }
            
            if (promises.Promises(Promise.Negative))
            {
                return asquarter((byte)(__x - summand));
            }
            else
            {
                return asquarter((byte)(__x + summand));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter2"/>, where each component is the next closest <see cref="quarter"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nextgreater(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 2);
            }
            else
            {
                return new quarter2(nextgreater(x.x, promises),
                                    nextgreater(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter3"/>, where each component is the next closest <see cref="quarter"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nextgreater(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 3);
            }
            else
            {
                return new quarter3(nextgreater(x.x, promises),
                                    nextgreater(x.y, promises),
                                    nextgreater(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter4"/>, where each component is the next closest <see cref="quarter"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nextgreater(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 4);
            }
            else
            {
                return new quarter4(nextgreater(x.x, promises),
                                    nextgreater(x.y, promises),
                                    nextgreater(x.z, promises),
                                    nextgreater(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter8"/>, where each component is the next closest <see cref="quarter"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="quarter.PositiveInfinity"/>, <see cref="quarter.NegativeInfinity"/> or <see cref="quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nextgreater(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 8);
            }
            else
            {
                return new quarter8(nextgreater(x.x0, promises),
                                    nextgreater(x.x1, promises),
                                    nextgreater(x.x2, promises),
                                    nextgreater(x.x3, promises),
                                    nextgreater(x.x4, promises),
                                    nextgreater(x.x5, promises),
                                    nextgreater(x.x6, promises),
                                    nextgreater(x.x7, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="half"/> greater than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nextgreater(half x, Promise promises = Promise.Nothing)
        {
            int __x = asshort(x);
            int summand;
            
            if (promises.Promises(Promise.NonZero))
            {
                if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                {
                    summand = 1;
                }
                else
                {
                    summand = 1 | (__x >> 31);
                }
            }
            else
            {
                int notNegative0 = -tobyte((uint)__x != 0xFFFF_8000);
                summand = 1 | ((__x >> 31) & notNegative0);
                __x &= notNegative0;
            }
            
            if (!promises.Promises(Promise.Unsafe0))
            {
                int notNanInf = -tobyte((__x & F16_SIGNALING_EXPONENT) != F16_SIGNALING_EXPONENT);
                summand &= notNanInf;
            }
            
            if (promises.Promises(Promise.Negative))
            {
                return ashalf((ushort)(__x - summand));
            }
            else
            {
                return ashalf((ushort)(__x + summand));
            }
        }

        /// <summary>       Returns a <see cref="half2"/>, where each component is the next closest <see cref="half"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nextgreater(half2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.inc_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 2));
            }
            else
            {
                return new half2(nextgreater(x.x, promises),
                                 nextgreater(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="half3"/>, where each component is the next closest <see cref="half"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nextgreater(half3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.inc_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 3));
            }
            else
            {
                return new half3(nextgreater(x.x, promises),
                                 nextgreater(x.y, promises),
                                 nextgreater(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="half4"/>, where each component is the next closest <see cref="half"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nextgreater(half4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.inc_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 4));
            }
            else
            {
                return new half4(nextgreater(x.x, promises),
                                 nextgreater(x.y, promises),
                                 nextgreater(x.z, promises),
                                 nextgreater(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.half8"/>, where each component is the next closest <see cref="half"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nextgreater(half8 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_ph(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 8);
            }
            else
            {
                return new half8(nextgreater(x.x0, promises),
                                 nextgreater(x.x1, promises),
                                 nextgreater(x.x2, promises),
                                 nextgreater(x.x3, promises),
                                 nextgreater(x.x4, promises),
                                 nextgreater(x.x5, promises),
                                 nextgreater(x.x6, promises),
                                 nextgreater(x.x7, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="float"/> greater than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nextgreater(float x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_ps(RegisterConversion.ToV128(x),
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 1).Float0;
            }
            else
            {
                int __x = math.asint(x);
                int summand;

                if (promises.Promises(Promise.NonZero))
                {
                    if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 31);
                    }
                }
                else
                {
                    int notNegative0 = -tobyte(__x != 1 << 31);
                    summand = 1 | ((__x >> 31) & notNegative0);
                    __x &= notNegative0;
                }

                if (!promises.Promises(Promise.Unsafe0))
                {
                    int notNanInf = -tobyte((__x & F32_SIGNALING_EXPONENT) != F32_SIGNALING_EXPONENT);
                    summand &= notNanInf;
                }

                if (promises.Promises(Promise.Negative))
                {
                    return math.asfloat(__x - summand);
                }
                else
                {
                    return math.asfloat(__x + summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="float2"/>, where each component is the next closest <see cref="float"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nextgreater(float2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.inc_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 2));
            }
            else
            {
                return new float2(nextgreater(x.x, promises),
                                  nextgreater(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="float3"/>, where each component is the next closest <see cref="float"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 nextgreater(float3 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.inc_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 3));
            }
            else
            {
                return new float3(nextgreater(x.x, promises),
                                  nextgreater(x.y, promises),
                                  nextgreater(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="float4"/>, where each component is the next closest <see cref="float"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 nextgreater(float4 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.inc_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 4));
            }
            else
            {
                return new float4(nextgreater(x.x, promises),
                                  nextgreater(x.y, promises),
                                  nextgreater(x.z, promises),
                                  nextgreater(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float8"/>, where each component is the next closest <see cref="float"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 nextgreater(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_ps(x,
                                        promiseNonZero: promises.Promises(Promise.NonZero),
                                        promiseNegative: promises.Promises(Promise.Negative),
                                        promisePositive: promises.Promises(Promise.Positive),
                                        promiseNotNanInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new float8(nextgreater(x.v4_0, promises),
                                  nextgreater(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="double"/> greater than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double nextgreater(double x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.inc_pd(RegisterConversion.ToV128(x),
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0)).Double0;
            }
            else
            {
                long __x = math.aslong(x);
                long summand;

                if (promises.Promises(Promise.NonZero))
                {
                    if (promises.Promises(Promise.Positive) | promises.Promises(Promise.Negative))
                    {
                        summand = 1;
                    }
                    else
                    {
                        summand = 1 | (__x >> 63);
                    }
                }
                else
                {
                    long notNegative0 = -(long)tobyte(__x != 1L << 63);
                    summand = 1 | ((__x >> 63) & notNegative0);
                    __x &= notNegative0;
                }

                if (!promises.Promises(Promise.Unsafe0))
                {
                    long notNanInf = -(long)tobyte((__x & F64_SIGNALING_EXPONENT) != F64_SIGNALING_EXPONENT);
                    summand &= notNanInf;
                }

                if (promises.Promises(Promise.Negative))
                {
                    return math.asdouble(__x - summand);
                }
                else
                {
                    return math.asdouble(__x + summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="double2"/>, where each component is the next closest <see cref="double"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nextgreater(double2 x, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.inc_pd(RegisterConversion.ToV128(x),
                                                               promiseNonZero: promises.Promises(Promise.NonZero),
                                                               promiseNegative: promises.Promises(Promise.Negative),
                                                               promisePositive: promises.Promises(Promise.Positive),
                                                               promiseNotNanInf: promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new double2(nextgreater(x.x, promises),
                                   nextgreater(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="double3"/>, where each component is the next closest <see cref="double"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 nextgreater(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_inc_pd(RegisterConversion.ToV256(x),
                                                                     promiseNonZero: promises.Promises(Promise.NonZero),
                                                                     promiseNegative: promises.Promises(Promise.Negative),
                                                                     promisePositive: promises.Promises(Promise.Positive),
                                                                     promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                                     elements: 3));
            }
            else
            {
                return new double3(nextgreater(x.xy, promises),
                                   nextgreater(x.z,  promises));
            }
        }

        /// <summary>       Returns a <see cref="double4"/>, where each component is the next closest <see cref="double"/> greater than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 nextgreater(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_inc_pd(RegisterConversion.ToV256(x),
                                                                     promiseNonZero: promises.Promises(Promise.NonZero),
                                                                     promiseNegative: promises.Promises(Promise.Negative),
                                                                     promisePositive: promises.Promises(Promise.Positive),
                                                                     promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                                     elements: 4));
            }
            else
            {
                return new double4(nextgreater(x.xy, promises),
                                   nextgreater(x.zw, promises));
            }
        }
    }
}
