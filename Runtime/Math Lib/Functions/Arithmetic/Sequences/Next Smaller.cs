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
            public static v128 dec_pq(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                        v128 SUMMAND_IF_ZERO = set1_epi8(0b1000_0010);

                        v128 isZero = cmpeq_epi8(andnot_si128(NEGATIVE_ZERO, a), setzero_si128());
                        summand = ternarylogic_si128(isZero, srai_epi8(a, 7), ONE, TernaryOperation.OxAE);
                        a = ternarylogic_si128(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi8(quarter.SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi8(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return add_epi8(a, summand);
                    }
                    else
                    {
                        return sub_epi8(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dec_pq(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PQ(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PQ(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PQ(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PQ(a, elements) && constexpr.ALL_NEQ_PQ(a, quarter.PositiveInfinity, elements) && constexpr.ALL_NEQ_PH(a, quarter.NegativeInfinity, elements);

                    v256 ONE = mm256_set1_epi8(1);

                    v256 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx2.mm256_blendv_epi8(ONE, mm256_setall_si256(), a);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = mm256_set1_epi8(1 << 7);
                        v256 SUMMAND_IF_ZERO = mm256_set1_epi8(0b1000_0010);

                        v256 isZero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_andnot_si256(NEGATIVE_ZERO, a), Avx.mm256_setzero_si256());
                        summand = mm256_ternarylogic_si256(isZero, mm256_srai_epi8(a, 7), ONE, TernaryOperation.OxAE);
                        a = mm256_ternarylogic_si256(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi8(quarter.SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi8(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_add_epi8(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_sub_epi8(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dec_ph(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                        v128 SUMMAND_IF_ZERO = set1_epi16(0x8002);

                        v128 isZero = cmpeq_epi16(andnot_si128(NEGATIVE_ZERO, a), setzero_si128());
                        summand = ternarylogic_si128(isZero, srai_epi16(a, 15), ONE, TernaryOperation.OxAE);
                        a = ternarylogic_si128(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi16(F16_SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi16(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return add_epi16(a, summand);
                    }
                    else
                    {
                        return sub_epi16(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dec_ph(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    //promiseNonZero |= constexpr.ALL_NEQ_PH(a, 0f, elements);
                    //promisePositive |= constexpr.ALL_GT_PH(a, 0f, elements);
                    //promiseNegative |= constexpr.ALL_LT_PH(a, 0f, elements);
                    //promiseNotNanInf |= constexpr.ALL_NOTNAN_PH(a, elements) && constexpr.ALL_NEQ_PH(a, (half)float.PositiveInfinity, elements) && constexpr.ALL_NEQ_PH(a, (half)float.NegativeInfinity, elements);

                    v256 ONE = mm256_set1_epi16(1);

                    v256 summand;
                    if (promiseNonZero)
                    {
                        if (promisePositive | promiseNegative)
                        {
                            summand = mm256_setall_si256();
                        }
                        else
                        {
                            summand = Avx2.mm256_or_si256(Avx2.mm256_srai_epi16(a, 15), ONE);
                        }
                    }
                    else
                    {
                        v256 NEGATIVE_ZERO = mm256_set1_epi16(1 << 15);
                        v256 SUMMAND_IF_ZERO = mm256_set1_epi16(0x8002);

                        v256 isZero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_andnot_si256(NEGATIVE_ZERO, a), Avx.mm256_setzero_si256());
                        summand = mm256_ternarylogic_si256(isZero, Avx2.mm256_srai_epi16(a, 15), ONE, TernaryOperation.OxAE);
                        a = mm256_ternarylogic_si256(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi16(F16_SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi16(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_add_epi16(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_sub_epi16(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dec_ps(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                        v128 SUMMAND_IF_ZERO = set1_epi32(0x8000_0002);

                        v128 isZero = cmpeq_epi32(andnot_si128(NEGATIVE_ZERO, a), setzero_si128());
                        summand = ternarylogic_si128(isZero, srai_epi32(a, 31), ONE, TernaryOperation.OxAE);
                        a = ternarylogic_si128(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi32(F32_SIGNALING_EXPONENT);

                        v128 nanInf = cmpeq_epi32(SIGNALING_EXPONENT, and_si128(a, SIGNALING_EXPONENT));
                        summand = andnot_si128(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return add_epi32(a, summand);
                    }
                    else
                    {
                        return sub_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dec_ps(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
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
                        v256 SUMMAND_IF_ZERO = mm256_set1_epi32(0x8000_0002);

                        v256 isZero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_andnot_si256(NEGATIVE_ZERO, a), Avx.mm256_setzero_si256());
                        summand = mm256_ternarylogic_si256(isZero, Avx2.mm256_srai_epi32(a, 31), ONE, TernaryOperation.OxAE);
                        a = mm256_ternarylogic_si256(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi32(F32_SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi32(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_add_epi32(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_sub_epi32(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 dec_pd(v128 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
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
                        v128 NEGATIVE_ZERO = set1_epi64x(1ul << 64);
                        v128 SUMMAND_IF_ZERO = set1_epi64x(0x8000_0000_0000_0002);

                        v128 isZero = cmpeq_epi64(andnot_si128(NEGATIVE_ZERO, a), setzero_si128());
                        summand = ternarylogic_si128(isZero, srai_epi64(a, 63), ONE, TernaryOperation.OxAE);
                        a = ternarylogic_si128(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v128 SIGNALING_EXPONENT = set1_epi64x(F64_SIGNALING_EXPONENT);

                        v128 nanInf;
                        if (BurstArchitecture.IsCMP64Supported)
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
                        return add_epi64(a, summand);
                    }
                    else
                    {
                        return sub_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_dec_pd(v256 a, bool promiseNonZero = false, bool promisePositive = false, bool promiseNegative = false, bool promiseNotNanInf = false, byte elements = 4)
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
                        v256 NEGATIVE_ZERO = mm256_set1_epi64x(1ul << 63);
                        v256 SUMMAND_IF_ZERO = mm256_set1_epi64x(0x8000_0000_0000_0002);

                        v256 isZero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_andnot_si256(NEGATIVE_ZERO, a), Avx.mm256_setzero_si256());
                        summand = mm256_ternarylogic_si256(isZero, mm256_srai_epi64(a, 63, elements), ONE, TernaryOperation.OxAE);
                        a = mm256_ternarylogic_si256(a, SUMMAND_IF_ZERO, isZero, TernaryOperation.OxF8);
                    }

                    if (!promiseNotNanInf)
                    {
                        v256 SIGNALING_EXPONENT = mm256_set1_epi64x(F64_SIGNALING_EXPONENT);

                        v256 nanInf = Avx2.mm256_cmpeq_epi64(SIGNALING_EXPONENT, Avx2.mm256_and_si256(a, SIGNALING_EXPONENT));
                        summand = Avx2.mm256_andnot_si256(nanInf, summand);
                    }

                    if (promisePositive)
                    {
                        return Avx2.mm256_add_epi64(a, summand);
                    }
                    else
                    {
                        return Avx2.mm256_sub_epi64(a, summand);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the next closest <see cref="UInt128"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 nextsmaller(UInt128 x)
        {
            return x - tobyte(x != UInt128.MinValue);
        }


        /// <summary>       Returns the next closest <see cref="Int128"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 nextsmaller(Int128 x)
        {
            return x - tobyte(x != Int128.MinValue);
        }


        /// <summary>       Returns the next closest <see cref="byte"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte nextsmaller(byte x)
        {
            return (byte)(x - tobyte(x != byte.MinValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.byte2"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 nextsmaller(byte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu8(x);
            }
            else
            {
                return new byte2(nextsmaller(x.x),
                                 nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte3"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 nextsmaller(byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu8(x);
            }
            else
            {
                return new byte3(nextsmaller(x.x),
                                 nextsmaller(x.y),
                                 nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte4"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 nextsmaller(byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu8(x);
            }
            else
            {
                return new byte4(nextsmaller(x.x),
                                 nextsmaller(x.y),
                                 nextsmaller(x.z),
                                 nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte8"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 nextsmaller(byte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu8(x);
            }
            else
            {
                return new byte8(nextsmaller(x.x0),
                                 nextsmaller(x.x1),
                                 nextsmaller(x.x2),
                                 nextsmaller(x.x3),
                                 nextsmaller(x.x4),
                                 nextsmaller(x.x5),
                                 nextsmaller(x.x6),
                                 nextsmaller(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte16"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 nextsmaller(byte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu8(x);
            }
            else
            {
                return new byte16(nextsmaller(x.x0),
                                  nextsmaller(x.x1),
                                  nextsmaller(x.x2),
                                  nextsmaller(x.x3),
                                  nextsmaller(x.x4),
                                  nextsmaller(x.x5),
                                  nextsmaller(x.x6),
                                  nextsmaller(x.x7),
                                  nextsmaller(x.x8),
                                  nextsmaller(x.x9),
                                  nextsmaller(x.x10),
                                  nextsmaller(x.x11),
                                  nextsmaller(x.x12),
                                  nextsmaller(x.x13),
                                  nextsmaller(x.x14),
                                  nextsmaller(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.byte32"/>, where each component is the next closest <see cref="byte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 nextsmaller(byte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epu8(x);
            }
            else
            {
                return new byte32(nextsmaller(x.v16_0),
                                  nextsmaller(x.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="sbyte"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte nextsmaller(sbyte x)
        {
            return (sbyte)(x - tobyte(x != sbyte.MinValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte2"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 nextsmaller(sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi8(x);
            }
            else
            {
                return new sbyte2(nextsmaller(x.x),
                                  nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte3"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 nextsmaller(sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi8(x);
            }
            else
            {
                return new sbyte3(nextsmaller(x.x),
                                  nextsmaller(x.y),
                                  nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte4"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 nextsmaller(sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi8(x);
            }
            else
            {
                return new sbyte4(nextsmaller(x.x),
                                  nextsmaller(x.y),
                                  nextsmaller(x.z),
                                  nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte8"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 nextsmaller(sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi8(x);
            }
            else
            {
                return new sbyte8(nextsmaller(x.x0),
                                  nextsmaller(x.x1),
                                  nextsmaller(x.x2),
                                  nextsmaller(x.x3),
                                  nextsmaller(x.x4),
                                  nextsmaller(x.x5),
                                  nextsmaller(x.x6),
                                  nextsmaller(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte16"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 nextsmaller(sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi8(x);
            }
            else
            {
                return new sbyte16(nextsmaller(x.x0),
                                   nextsmaller(x.x1),
                                   nextsmaller(x.x2),
                                   nextsmaller(x.x3),
                                   nextsmaller(x.x4),
                                   nextsmaller(x.x5),
                                   nextsmaller(x.x6),
                                   nextsmaller(x.x7),
                                   nextsmaller(x.x8),
                                   nextsmaller(x.x9),
                                   nextsmaller(x.x10),
                                   nextsmaller(x.x11),
                                   nextsmaller(x.x12),
                                   nextsmaller(x.x13),
                                   nextsmaller(x.x14),
                                   nextsmaller(x.x15));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.sbyte32"/>, where each component is the next closest <see cref="sbyte"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 nextsmaller(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epi8(x);
            }
            else
            {
                return new sbyte32(nextsmaller(x.v16_0),
                                   nextsmaller(x.v16_16));
            }
        }


        /// <summary>       Returns the next closest <see cref="ushort"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort nextsmaller(ushort x)
        {
            return (ushort)(x - tobyte(x != ushort.MinValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort2"/>, where each component is the next closest <see cref="ushort"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 nextsmaller(ushort2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu16(x);
            }
            else
            {
                return new ushort2(nextsmaller(x.x),
                                   nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort3"/>, where each component is the next closest <see cref="ushort"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 nextsmaller(ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu16(x);
            }
            else
            {
                return new ushort3(nextsmaller(x.x),
                                   nextsmaller(x.y),
                                   nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort4"/>, where each component is the next closest <see cref="ushort"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 nextsmaller(ushort4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu16(x);
            }
            else
            {
                return new ushort4(nextsmaller(x.x),
                                   nextsmaller(x.y),
                                   nextsmaller(x.z),
                                   nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort8"/>, where each component is the next closest <see cref="ushort"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 nextsmaller(ushort8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu16(x);
            }
            else
            {
                return new ushort8(nextsmaller(x.x0),
                                   nextsmaller(x.x1),
                                   nextsmaller(x.x2),
                                   nextsmaller(x.x3),
                                   nextsmaller(x.x4),
                                   nextsmaller(x.x5),
                                   nextsmaller(x.x6),
                                   nextsmaller(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ushort16"/>, where each component is the next closest <see cref="ushort"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 nextsmaller(ushort16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epu16(x);
            }
            else
            {
                return new ushort16(nextsmaller(x.v8_0),
                                    nextsmaller(x.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="short"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short nextsmaller(short x)
        {
            return (short)(x - tobyte(x != short.MinValue));
        }

        /// <summary>       Returns a <see cref="MaxMath.short2"/>, where each component is the next closest <see cref="short"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 nextsmaller(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi16(x);
            }
            else
            {
                return new short2(nextsmaller(x.x),
                                  nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/>, where each component is the next closest <see cref="short"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 nextsmaller(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi16(x);
            }
            else
            {
                return new short3(nextsmaller(x.x),
                                  nextsmaller(x.y),
                                  nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/>, where each component is the next closest <see cref="short"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 nextsmaller(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi16(x);
            }
            else
            {
                return new short4(nextsmaller(x.x),
                                  nextsmaller(x.y),
                                  nextsmaller(x.z),
                                  nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/>, where each component is the next closest <see cref="short"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 nextsmaller(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi16(x);
            }
            else
            {
                return new short8(nextsmaller(x.x0),
                                  nextsmaller(x.x1),
                                  nextsmaller(x.x2),
                                  nextsmaller(x.x3),
                                  nextsmaller(x.x4),
                                  nextsmaller(x.x5),
                                  nextsmaller(x.x6),
                                  nextsmaller(x.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/>, where each component is the next closest <see cref="short"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 nextsmaller(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epi16(x);
            }
            else
            {
                return new short16(nextsmaller(x.v8_0),
                                   nextsmaller(x.v8_8));
            }
        }


        /// <summary>       Returns the next closest <see cref="uint"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint nextsmaller(uint x)
        {
            return x - tobyte(x != uint.MinValue);
        }

        /// <summary>       Returns a <see cref="uint2"/>, where each component is the next closest <see cref="uint"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 nextsmaller(uint2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.decs_epu32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new uint2(nextsmaller(x.x),
                                 nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="uint3"/>, where each component is the next closest <see cref="uint"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 nextsmaller(uint3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.decs_epu32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new uint3(nextsmaller(x.x),
                                 nextsmaller(x.y),
                                 nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="uint4"/>, where each component is the next closest <see cref="uint"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 nextsmaller(uint4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.decs_epu32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new uint4(nextsmaller(x.x),
                                 nextsmaller(x.y),
                                 nextsmaller(x.z),
                                 nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.uint8"/>, where each component is the next closest <see cref="uint"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 nextsmaller(uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epu32(x);
            }
            else
            {
                return new uint8(nextsmaller(x.v4_0),
                                 nextsmaller(x.v4_4));
            }
        }


        /// <summary>       Returns the next closest <see cref="int"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int nextsmaller(int x)
        {
            return x - tobyte(x != int.MinValue);
        }

        /// <summary>       Returns a <see cref="int2"/>, where each component is the next closest <see cref="int"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 nextsmaller(int2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.decs_epi32(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new int2(nextsmaller(x.x),
                                nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="int3"/>, where each component is the next closest <see cref="int"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 nextsmaller(int3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.decs_epi32(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new int3(nextsmaller(x.x),
                                nextsmaller(x.y),
                                nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="int4"/>, where each component is the next closest <see cref="int"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 nextsmaller(int4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.decs_epi32(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new int4(nextsmaller(x.x),
                                nextsmaller(x.y),
                                nextsmaller(x.z),
                                nextsmaller(x.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.int8"/>, where each component is the next closest <see cref="int"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 nextsmaller(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epi32(x);
            }
            else
            {
                return new int8(nextsmaller(x.v4_0),
                                nextsmaller(x.v4_4));
            }
        }


        /// <summary>       Returns the next closest <see cref="ulong"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong nextsmaller(ulong x)
        {
            return x - tobyte(x != ulong.MinValue);
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong2"/>, where each component is the next closest <see cref="ulong"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 nextsmaller(ulong2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epu64(x);
            }
            else
            {
                return new ulong2(nextsmaller(x.x),
                                  nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong3"/>, where each component is the next closest <see cref="ulong"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 nextsmaller(ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epu64(x, 3);
            }
            else
            {
                return new ulong3(nextsmaller(x.xy),
                                  nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.ulong4"/>, where each component is the next closest <see cref="ulong"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 nextsmaller(ulong4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epu64(x, 4);
            }
            else
            {
                return new ulong4(nextsmaller(x.xy),
                                  nextsmaller(x.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="long"/> smaller than <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long nextsmaller(long x)
        {
            return x - tobyte(x != long.MinValue);
        }

        /// <summary>       Returns a <see cref="MaxMath.long2"/>, where each component is the next closest <see cref="long"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 nextsmaller(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.decs_epi64(x);
            }
            else
            {
                return new long2(nextsmaller(x.x),
                                 nextsmaller(x.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/>, where each component is the next closest <see cref="long"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 nextsmaller(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epi64(x, 3);
            }
            else
            {
                return new long3(nextsmaller(x.xy),
                                 nextsmaller(x.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/>, where each component is the next closest <see cref="long"/> smaller than the corresponding component in <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 nextsmaller(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_decs_epi64(x, 4);
            }
            else
            {
                return new long4(nextsmaller(x.xy),
                                 nextsmaller(x.zw));
            }
        }


        /// <summary>       Returns the next closest <see cref="MaxMath.quarter"/> smaller than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter nextsmaller(quarter x, Promise promises = Promise.Nothing)
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
                int isNotZero = -tobyte((__x != unchecked((int)0xFFFF_FF80)) & (__x != 0));
                summand = 1 | ((__x >> 31) & isNotZero);
                __x |= (int)andnot(0b1000_0010, (uint)isNotZero);
            }

            if (!promises.Promises(Promise.Unsafe0))
            {
                int notNanInf = -tobyte((__x & quarter.SIGNALING_EXPONENT) != quarter.SIGNALING_EXPONENT);
                summand &= notNanInf;
            }

            if (promises.Promises(Promise.Negative))
            {
                return asquarter((byte)(__x + summand));
            }
            else
            {
                return asquarter((byte)(__x - summand));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter2"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 nextsmaller(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 2);
            }
            else
            {
                return new quarter2(nextsmaller(x.x, promises),
                                    nextsmaller(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter3"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 nextsmaller(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 3);
            }
            else
            {
                return new quarter3(nextsmaller(x.x, promises),
                                    nextsmaller(x.y, promises),
                                    nextsmaller(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter4"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 nextsmaller(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 4);
            }
            else
            {
                return new quarter4(nextsmaller(x.x, promises),
                                    nextsmaller(x.y, promises),
                                    nextsmaller(x.z, promises),
                                    nextsmaller(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter8"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 nextsmaller(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 8);
            }
            else
            {
                return new quarter8(nextsmaller(x.x0, promises),
                                    nextsmaller(x.x1, promises),
                                    nextsmaller(x.x2, promises),
                                    nextsmaller(x.x3, promises),
                                    nextsmaller(x.x4, promises),
                                    nextsmaller(x.x5, promises),
                                    nextsmaller(x.x6, promises),
                                    nextsmaller(x.x7, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter16"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 nextsmaller(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pq(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new quarter16(nextsmaller(x.x0, promises),
                                     nextsmaller(x.x1, promises),
                                     nextsmaller(x.x2, promises),
                                     nextsmaller(x.x3, promises),
                                     nextsmaller(x.x4, promises),
                                     nextsmaller(x.x5, promises),
                                     nextsmaller(x.x6, promises),
                                     nextsmaller(x.x7, promises),
                                     nextsmaller(x.x8, promises),
                                     nextsmaller(x.x9, promises),
                                     nextsmaller(x.x10, promises),
                                     nextsmaller(x.x11, promises),
                                     nextsmaller(x.x12, promises),
                                     nextsmaller(x.x13, promises),
                                     nextsmaller(x.x14, promises),
                                     nextsmaller(x.x15, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.quarter32"/>, where each component is the next closest <see cref="MaxMath.quarter"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="MaxMath.quarter.PositiveInfinity"/>, <see cref="MaxMath.quarter.NegativeInfinity"/> or <see cref="MaxMath.quarter.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 nextsmaller(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_pq(x,
                                        promiseNonZero: promises.Promises(Promise.NonZero),
                                        promiseNegative: promises.Promises(Promise.Negative),
                                        promisePositive: promises.Promises(Promise.Positive),
                                        promiseNotNanInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new quarter32(nextsmaller(x.v16_0, promises), nextsmaller(x.v16_16, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="half"/> smaller than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half nextsmaller(half x, Promise promises = Promise.Nothing)
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
                int isNotZero = -tobyte((__x != unchecked((int)0xFFFF_8000)) & (__x != 0));
                summand = 1 | ((__x >> 31) & isNotZero);
                __x |= (int)andnot(0x8002u, (uint)isNotZero);
            }

            if (!promises.Promises(Promise.Unsafe0))
            {
                int notNanInf = -tobyte((__x & F16_SIGNALING_EXPONENT) != F16_SIGNALING_EXPONENT);
                summand &= notNanInf;
            }

            if (promises.Promises(Promise.Negative))
            {
                return ashalf((ushort)(__x + summand));
            }
            else
            {
                return ashalf((ushort)(__x - summand));
            }
        }

        /// <summary>       Returns a <see cref="half2"/>, where each component is the next closest <see cref="half"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 nextsmaller(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.dec_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 2));
            }
            else
            {
                return new half2(nextsmaller(x.x, promises),
                                 nextsmaller(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="half3"/>, where each component is the next closest <see cref="half"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 nextsmaller(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.dec_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 3));
            }
            else
            {
                return new half3(nextsmaller(x.x, promises),
                                 nextsmaller(x.y, promises),
                                 nextsmaller(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="half4"/>, where each component is the next closest <see cref="half"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 nextsmaller(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.dec_ph(RegisterConversion.ToV128(x),
                                                             promiseNonZero: promises.Promises(Promise.NonZero),
                                                             promiseNegative: promises.Promises(Promise.Negative),
                                                             promisePositive: promises.Promises(Promise.Positive),
                                                             promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                             elements: 4));
            }
            else
            {
                return new half4(nextsmaller(x.x, promises),
                                 nextsmaller(x.y, promises),
                                 nextsmaller(x.z, promises),
                                 nextsmaller(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.half8"/>, where each component is the next closest <see cref="half"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 nextsmaller(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_ph(x,
                                  promiseNonZero: promises.Promises(Promise.NonZero),
                                  promiseNegative: promises.Promises(Promise.Negative),
                                  promisePositive: promises.Promises(Promise.Positive),
                                  promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                  elements: 8);
            }
            else
            {
                return new half8(nextsmaller(x.x0, promises),
                                 nextsmaller(x.x1, promises),
                                 nextsmaller(x.x2, promises),
                                 nextsmaller(x.x3, promises),
                                 nextsmaller(x.x4, promises),
                                 nextsmaller(x.x5, promises),
                                 nextsmaller(x.x6, promises),
                                 nextsmaller(x.x7, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.half16"/>, where each component is the next closest <see cref="half"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either half.PositiveInfinity, half.NegativeInfinity or half.NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 nextsmaller(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_ph(x,
                                        promiseNonZero: promises.Promises(Promise.NonZero),
                                        promiseNegative: promises.Promises(Promise.Negative),
                                        promisePositive: promises.Promises(Promise.Positive),
                                        promiseNotNanInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new half16(nextsmaller(x.v8_0, promises), nextsmaller(x.v8_8, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="float"/> smaller than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float nextsmaller(float x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_ps(RegisterConversion.ToV128(x),
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
                    int isNotZero = -tobyte((__x != 1 << 31) & (__x != 0));
                    summand = 1 | ((__x >> 31) & isNotZero);
                    __x |= (int)andnot(0x8000_0002u, (uint)isNotZero);
                }

                if (!promises.Promises(Promise.Unsafe0))
                {
                    int notNanInf = -tobyte((__x & F32_SIGNALING_EXPONENT) != F32_SIGNALING_EXPONENT);
                    summand &= notNanInf;
                }

                if (promises.Promises(Promise.Negative))
                {
                    return math.asfloat(__x + summand);
                }
                else
                {
                    return math.asfloat(__x - summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="float2"/>, where each component is the next closest <see cref="float"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 nextsmaller(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.dec_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 2));
            }
            else
            {
                return new float2(nextsmaller(x.x, promises),
                                  nextsmaller(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="float3"/>, where each component is the next closest <see cref="float"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 nextsmaller(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.dec_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 3));
            }
            else
            {
                return new float3(nextsmaller(x.x, promises),
                                  nextsmaller(x.y, promises),
                                  nextsmaller(x.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="float4"/>, where each component is the next closest <see cref="float"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 nextsmaller(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.dec_ps(RegisterConversion.ToV128(x),
                                                              promiseNonZero: promises.Promises(Promise.NonZero),
                                                              promiseNegative: promises.Promises(Promise.Negative),
                                                              promisePositive: promises.Promises(Promise.Positive),
                                                              promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                              elements: 4));
            }
            else
            {
                return new float4(nextsmaller(x.x, promises),
                                  nextsmaller(x.y, promises),
                                  nextsmaller(x.z, promises),
                                  nextsmaller(x.w, promises));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.float8"/>, where each component is the next closest <see cref="float"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="float.PositiveInfinity"/>, <see cref="float.NegativeInfinity"/> or <see cref="float.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 nextsmaller(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_ps(x,
                                        promiseNonZero: promises.Promises(Promise.NonZero),
                                        promiseNegative: promises.Promises(Promise.Negative),
                                        promisePositive: promises.Promises(Promise.Positive),
                                        promiseNotNanInf: promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new float8(nextsmaller(x.v4_0, promises),
                                  nextsmaller(x.v4_4, promises));
            }
        }


        /// <summary>       Returns the next closest <see cref="double"/> smaller than <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double nextsmaller(double x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_pd(RegisterConversion.ToV128(x),
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
                    long isNotZero = -tobyte((__x != 1L << 63) & (__x != 0));
                    summand = 1 | ((__x >> 63) & isNotZero);
                    __x |= (long)andnot(0x8000_0000_0000_0002, (ulong)isNotZero);
                }

                if (!promises.Promises(Promise.Unsafe0))
                {
                    long notNanInf = -(long)tobyte((__x & F64_SIGNALING_EXPONENT) != F64_SIGNALING_EXPONENT);
                    summand &= notNanInf;
                }

                if (promises.Promises(Promise.Negative))
                {
                    return math.asdouble(__x + summand);
                }
                else
                {
                    return math.asdouble(__x - summand);
                }
            }
        }

        /// <summary>       Returns a <see cref="double2"/>, where each component is the next closest <see cref="double"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 nextsmaller(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.dec_pd(RegisterConversion.ToV128(x),
                                                               promiseNonZero: promises.Promises(Promise.NonZero),
                                                               promiseNegative: promises.Promises(Promise.Negative),
                                                               promisePositive: promises.Promises(Promise.Positive),
                                                               promiseNotNanInf: promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new double2(nextsmaller(x.x, promises),
                                   nextsmaller(x.y, promises));
            }
        }

        /// <summary>       Returns a <see cref="double3"/>, where each component is the next closest <see cref="double"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 nextsmaller(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_dec_pd(RegisterConversion.ToV256(x),
                                                                     promiseNonZero: promises.Promises(Promise.NonZero),
                                                                     promiseNegative: promises.Promises(Promise.Negative),
                                                                     promisePositive: promises.Promises(Promise.Positive),
                                                                     promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                                     elements: 3));
            }
            else
            {
                return new double3(nextsmaller(x.xy, promises),
                                   nextsmaller(x.z,  promises));
            }
        }

        /// <summary>       Returns a <see cref="double4"/>, where each component is the next closest <see cref="double"/> smaller than the corresponding component in <paramref name="x"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.NonZero"/> flag set returns incorrect results for any <paramref name="x"/> that is negative 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Positive"/> flag set returns incorrect results for any <paramref name="x"/> that is negative or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Negative"/> flag set returns incorrect results for any <paramref name="x"/> that is positive or 0.       </para>
        /// <para>      A <see cref="Promise"/> "<paramref name="promises"/>" with its <see cref="Promise.Unsafe0"/> flag set returns incorrect results for any <paramref name="x"/> that is either <see cref="double.PositiveInfinity"/>, <see cref="double.NegativeInfinity"/> or <see cref="double.NaN"/>.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 nextsmaller(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_dec_pd(RegisterConversion.ToV256(x),
                                                                     promiseNonZero: promises.Promises(Promise.NonZero),
                                                                     promiseNegative: promises.Promises(Promise.Negative),
                                                                     promisePositive: promises.Promises(Promise.Positive),
                                                                     promiseNotNanInf: promises.Promises(Promise.Unsafe0),
                                                                     elements: 4));
            }
            else
            {
                return new double4(nextsmaller(x.xy, promises),
                                   nextsmaller(x.zw, promises));
            }
        }
    }
}
