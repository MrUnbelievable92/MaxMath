using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
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
            public static v128 cmpnorm_pq(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi8(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi8(cmp, set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_ph(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi16(F16_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi16(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi16(cmp, set1_epi16(F16_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_ps(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi32(F32_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi32(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi32(cmp, set1_epi32(F32_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi64x(F64_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi64(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi64(cmp, set1_epi64x(F64_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi8(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi8(cmp, mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi16(F16_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi16(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi16(cmp, mm256_set1_epi16(F16_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi32(F32_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi32(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi32(cmp, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else if (Avx.IsAvxSupported)
                {
                    return mm256_cmprange_ps(mm256_abs_ps(a), mm256_set1_ps(math.FLT_MIN_NORMAL), mm256_set1_ps(float.MaxValue));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi64(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi64(cmp, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else if (Avx.IsAvxSupported)
                {
                    return mm256_cmprange_pd(mm256_abs_pd(a), mm256_set1_pd(math.DBL_MIN_NORMAL), mm256_set1_pd(double.MaxValue));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_pq(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi8(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi8(add_epi8(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi8(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_ph(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi16(F16_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi16(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi16(add_epi16(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi16(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_ps(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi32(F32_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi32(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi32(add_epi32(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi32(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi64x(F64_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi64(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi64(add_epi64(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi64(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi8(MaxMath.quarter.SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi8(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_add_epi8(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi16(F16_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi16(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_add_epi16(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi32(F32_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi32(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_add_epi32(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else if (Avx.IsAvxSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    return Avx.mm256_and_ps(mm256_cmpneq_ps(a, Avx.mm256_setzero_ps()),
                                            mm256_cmpgt_ps(mm256_set1_ps(math.FLT_MIN_NORMAL), mm256_abs_ps(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi64(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_add_epi64(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else if (Avx.IsAvxSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    return Avx.mm256_and_pd(mm256_cmpneq_pd(a, Avx.mm256_setzero_pd()),
                                            mm256_cmpgt_pd(mm256_set1_pd(math.DBL_MIN_NORMAL), mm256_abs_pd(a)));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpint_pq(v128 a, bool notNaNinf = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 EXPONENT_MASK = set1_epi8(math.bitmask8((uint)quarter.EXPONENT_BITS));
                    v128 FRACTION_MASK = set1_epi8(math.bitmask8((uint)quarter.MANTISSA_BITS));

                    v128 exponentShifted = srli_epi8(a, quarter.MANTISSA_BITS, elements: elements);
                    v128 exponent = and_si128(exponentShifted, EXPONENT_MASK);
                    v128 unbiasedExponent = sub_epi8(exponent, set1_epi8((byte)math.abs(quarter.EXPONENT_BIAS)));
                    v128 fractionalMask = bitmask_epi8(sub_epi8(set1_epi8((byte)quarter.MANTISSA_BITS), unbiasedExponent), elements: elements, promiseLT8: true);

                    v128 unbiasedExponentNegative = cmpgt_epi8(setzero_si128(), unbiasedExponent);
                    v128 unbiasedExponentGEMantissaBits = cmpgt_epi8(unbiasedExponent, set1_epi8((byte)(quarter.MANTISSA_BITS - 1)));

                    v128 result0 = cmpeq_epi8(ternarylogic_si128(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), setzero_si128());
                    v128 result1 = ternarylogic_si128(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v128 result2 = cmpeq_epi8(ternarylogic_si128(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), setzero_si128());
                    v128 result3 = ternarylogic_si128(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v128 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = ternarylogic_si128(result1, result3, cmpeq_epi8(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = or_si128(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpint_ph(v128 a, bool notNaNinf = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 EXPONENT_MASK = set1_epi16(math.bitmask16((uint)half.EXPONENT_BITS));
                    v128 FRACTION_MASK = set1_epi16(math.bitmask16((uint)half.MANTISSA_BITS));

                    v128 exponentShifted = srli_epi16(a, half.MANTISSA_BITS);
                    v128 exponent = and_si128(exponentShifted, EXPONENT_MASK);
                    v128 unbiasedExponent = sub_epi16(exponent, set1_epi16((ushort)math.abs(half.EXPONENT_BIAS)));
                    v128 fractionalMask = bitmask_epi16(sub_epi16(set1_epi16((ushort)half.MANTISSA_BITS), unbiasedExponent), elements: elements, promiseLT16: true);

                    v128 unbiasedExponentNegative = cmpgt_epi16(setzero_si128(), unbiasedExponent);
                    v128 unbiasedExponentGEMantissaBits = cmpgt_epi16(unbiasedExponent, set1_epi16((ushort)(half.MANTISSA_BITS - 1)));

                    v128 result0 = cmpeq_epi16(ternarylogic_si128(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), setzero_si128());
                    v128 result1 = ternarylogic_si128(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v128 result2 = cmpeq_epi16(ternarylogic_si128(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), setzero_si128());
                    v128 result3 = ternarylogic_si128(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v128 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = ternarylogic_si128(result1, result3, cmpeq_epi16(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = or_si128(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpint_ps(v128 a, bool notNaNinf = false, byte elements = 4)
            {
                static v128 HardwareSupported(v128 a, bool notNaNinf)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 result = cmpeq_epi32(trunc_ps(a), a);
                        
                        if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                            && COMPILATION_OPTIONS.FLOAT_NO_INF)
                           || notNaNinf))
                        {
                            v128 mask = set1_epi32(math.bitmask32((uint)F32_EXPONENT_BITS, (uint)F32_MANTISSA_BITS));

                            result = andnot_si128(cmpeq_epi32(and_si128(a, mask), mask), result);
                        }

                        return result;
                    }
                    else throw new IllegalInstructionException();
                }

                if (Sse4_1.IsSse41Supported)
                {
                    return HardwareSupported(a, notNaNinf);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return HardwareSupported(a, notNaNinf);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 EXPONENT_MASK = set1_epi32(math.bitmask32((uint)F32_EXPONENT_BITS));
                    v128 FRACTION_MASK = set1_epi32(math.bitmask32((uint)F32_MANTISSA_BITS));

                    v128 exponentShifted = srli_epi32(a, F32_MANTISSA_BITS);
                    v128 exponent = and_si128(exponentShifted, EXPONENT_MASK);
                    v128 unbiasedExponent = sub_epi32(exponent, set1_epi32((uint)math.abs(F32_EXPONENT_BIAS)));
                    v128 fractionalMask = bitmask_epi32(sub_epi32(set1_epi32((uint)F32_MANTISSA_BITS), unbiasedExponent), elements: elements, promiseLT32: true);

                    v128 unbiasedExponentNegative = cmpgt_epi32(setzero_si128(), unbiasedExponent);
                    v128 unbiasedExponentGEMantissaBits = cmpgt_epi32(unbiasedExponent, set1_epi32((uint)(F32_MANTISSA_BITS - 1)));

                    v128 result0 = cmpeq_epi32(ternarylogic_si128(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), setzero_si128());
                    v128 result1 = ternarylogic_si128(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v128 result2 = cmpeq_epi32(ternarylogic_si128(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), setzero_si128());
                    v128 result3 = ternarylogic_si128(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v128 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = ternarylogic_si128(result1, result3, cmpeq_epi32(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = or_si128(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpint_pd(v128 a, bool notNaNinf = false)
            {
                static v128 HardwareSupported(v128 a, bool notNaNinf)
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 result = cmpeq_epi64(trunc_pd(a), a);
                        
                        if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                            && COMPILATION_OPTIONS.FLOAT_NO_INF)
                           || notNaNinf))
                        {
                            v128 mask = set1_epi64x(math.bitmask64((ulong)F64_EXPONENT_BITS, (ulong)F64_MANTISSA_BITS));

                            result = andnot_si128(cmpeq_epi64(and_si128(a, mask), mask), result);
                        }

                        return result;
                    }
                    else throw new IllegalInstructionException();
                }

                if (Sse4_1.IsSse41Supported)
                {
                    return HardwareSupported(a, notNaNinf);
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return HardwareSupported(a, notNaNinf);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 EXPONENT_MASK = set1_epi64x(math.bitmask64((ulong)F64_EXPONENT_BITS));
                    v128 FRACTION_MASK = set1_epi64x(math.bitmask64((ulong)F64_MANTISSA_BITS));

                    v128 exponentShifted = srli_epi64(a, F64_MANTISSA_BITS);
                    v128 exponent = and_si128(exponentShifted, EXPONENT_MASK);
                    v128 unbiasedExponent = sub_epi64(exponent, set1_epi64x((ulong)math.abs(F64_EXPONENT_BIAS)));
                    v128 fractionalMask = bitmask_epi64(sub_epi64(set1_epi64x((ulong)F64_MANTISSA_BITS), unbiasedExponent), promiseLT64: true);

                    v128 unbiasedExponentNegative = cmpgt_epi64(setzero_si128(), unbiasedExponent);
                    v128 unbiasedExponentGEMantissaBits = cmpgt_epi64(unbiasedExponent, set1_epi64x((ulong)(F64_MANTISSA_BITS - 1)));

                    v128 result0 = cmpeq_epi64(ternarylogic_si128(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), setzero_si128());
                    v128 result1 = ternarylogic_si128(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v128 result2 = cmpeq_epi64(ternarylogic_si128(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), setzero_si128());
                    v128 result3 = ternarylogic_si128(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v128 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = ternarylogic_si128(result1, result3, cmpeq_epi64(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = or_si128(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpint_pq(v256 a, bool notNaNinf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 EXPONENT_MASK = mm256_set1_epi8(math.bitmask8((uint)quarter.EXPONENT_BITS));
                    v256 FRACTION_MASK = mm256_set1_epi8(math.bitmask8((uint)quarter.MANTISSA_BITS));

                    v256 exponentShifted = mm256_srli_epi8(a, quarter.MANTISSA_BITS);
                    v256 exponent = Avx2.mm256_and_si256(exponentShifted, EXPONENT_MASK);
                    v256 unbiasedExponent = Avx2.mm256_sub_epi8(exponent, mm256_set1_epi8((byte)math.abs(quarter.EXPONENT_BIAS)));
                    v256 fractionalMask = mm256_bitmask_epi8(Avx2.mm256_sub_epi8(mm256_set1_epi8((byte)quarter.MANTISSA_BITS), unbiasedExponent));

                    v256 unbiasedExponentNegative = Avx2.mm256_cmpgt_epi8(Avx.mm256_setzero_si256(), unbiasedExponent);
                    v256 unbiasedExponentGEMantissaBits = Avx2.mm256_cmpgt_epi8(unbiasedExponent, mm256_set1_epi8((byte)(quarter.MANTISSA_BITS - 1)));

                    v256 result0 = Avx2.mm256_cmpeq_epi8(mm256_ternarylogic_si256(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), Avx.mm256_setzero_si256());
                    v256 result1 = mm256_ternarylogic_si256(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v256 result2 = Avx2.mm256_cmpeq_epi8(mm256_ternarylogic_si256(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), Avx.mm256_setzero_si256());
                    v256 result3 = mm256_ternarylogic_si256(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v256 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = mm256_ternarylogic_si256(result1, result3, Avx2.mm256_cmpeq_epi8(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = Avx2.mm256_or_si256(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpint_ph(v256 a, bool notNaNinf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 EXPONENT_MASK = mm256_set1_epi16(math.bitmask16((uint)half.EXPONENT_BITS));
                    v256 FRACTION_MASK = mm256_set1_epi16(math.bitmask16((uint)half.MANTISSA_BITS));

                    v256 exponentShifted = mm256_srli_epi16(a, half.MANTISSA_BITS);
                    v256 exponent = Avx2.mm256_and_si256(exponentShifted, EXPONENT_MASK);
                    v256 unbiasedExponent = Avx2.mm256_sub_epi16(exponent, mm256_set1_epi16((ushort)math.abs(half.EXPONENT_BIAS)));
                    v256 fractionalMask = mm256_bitmask_epi16(Avx2.mm256_sub_epi16(mm256_set1_epi16((ushort)half.MANTISSA_BITS), unbiasedExponent), promiseLT16: true);

                    v256 unbiasedExponentNegative = Avx2.mm256_cmpgt_epi16(Avx.mm256_setzero_si256(), unbiasedExponent);
                    v256 unbiasedExponentGEMantissaBits = Avx2.mm256_cmpgt_epi16(unbiasedExponent, mm256_set1_epi16((ushort)(half.MANTISSA_BITS - 1)));

                    v256 result0 = Avx2.mm256_cmpeq_epi16(mm256_ternarylogic_si256(exponent, a, FRACTION_MASK, TernaryOperation.OxF8), Avx.mm256_setzero_si256());
                    v256 result1 = mm256_ternarylogic_si256(unbiasedExponentGEMantissaBits, unbiasedExponentNegative, result0, TernaryOperation.OxF8);
                    v256 result2 = Avx2.mm256_cmpeq_epi16(mm256_ternarylogic_si256(fractionalMask, a, FRACTION_MASK, TernaryOperation.Ox8O), Avx.mm256_setzero_si256());
                    v256 result3 = mm256_ternarylogic_si256(unbiasedExponentNegative, unbiasedExponentGEMantissaBits, result2, TernaryOperation.OxO2);
                    
                    v256 result;

                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        result = mm256_ternarylogic_si256(result1, result3, Avx2.mm256_cmpeq_epi16(exponent, EXPONENT_MASK), TernaryOperation.Ox54);
                    }
                    else
                    {
                        result = Avx2.mm256_or_si256(result1, result3);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpint_ps(v256 a, bool notNaNinf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_trunc_ps(a), a);
                    
                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        v256 mask = mm256_set1_epi32(math.bitmask32((uint)F32_EXPONENT_BITS, (uint)F32_MANTISSA_BITS));
                    
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, mask), mask), result);
                    }
                    
                    return result;
                }
                else if (Avx.IsAvxSupported)
                {
                    v256 result = mm256_cmpeq_ps(mm256_trunc_ps(a), a);
                    
                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        v256 mask = mm256_set1_epi32(math.bitmask32((uint)F32_EXPONENT_BITS, (uint)F32_MANTISSA_BITS));
                    
                        // mm256_cmpeq_ps(mm256_trunc_ps(a), a) -> false if a is NaN
                        result = Avx.mm256_andnot_ps(mm256_cmpeq_ps(Avx.mm256_and_ps(a, mask), mask), result);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpint_pd(v256 a, bool notNaNinf = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_trunc_pd(a), a);
                    
                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        v256 mask = mm256_set1_epi64x(math.bitmask64((ulong)F64_EXPONENT_BITS, (ulong)F64_MANTISSA_BITS));
                    
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, mask), mask), result);
                    }
                    
                    return result;
                }
                else if (Avx.IsAvxSupported)
                {
                    v256 result = mm256_cmpeq_pd(mm256_trunc_pd(a), a);
                    
                    if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                        && COMPILATION_OPTIONS.FLOAT_NO_INF)
                       || notNaNinf))
                    {
                        v256 mask = mm256_set1_epi64x(math.bitmask64((ulong)F64_EXPONENT_BITS, (ulong)F64_MANTISSA_BITS));
                    
                        // mm256_cmpeq_pd(mm256_trunc_pd(a), a) -> false if a is NaN
                        result = Avx.mm256_andnot_pd(mm256_cmpeq_pd(Avx.mm256_and_pd(a, mask), mask), result);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class math
    {
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(quarter q)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && (q.value & 0b0111_1111) == 0b0111_0000;
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(quarter q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || (q.value & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="quarter"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(quarter q)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (q.value & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="quarter2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isinf(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="quarter2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isfinite(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="quarter2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isnan(quarter2 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="quarter3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isinf(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="quarter3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isfinite(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="quarter3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isnan(quarter3 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="quarter4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isinf(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="quarter4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isfinite(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="quarter4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isnan(quarter4 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="quarter8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isinf(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="quarter8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isfinite(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="quarter8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isnan(quarter8 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="quarter16"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isinf(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="quarter16"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isfinite(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="quarter16"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isnan(quarter16 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        ///<summary>        Returns a <see cref="bool32"/> indicating for each component of a <see cref="quarter32"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isinf(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asbyte(q) & 0b0111_1111) == 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool32"/> indicating for each component of a <see cref="quarter32"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isfinite(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asbyte(q) & 0b0111_1111) < 0b0111_0000;
        }

        ///<summary>        Returns a <see cref="bool32"/> indicating for each component of a <see cref="quarter32"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isnan(quarter32 q)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asbyte(q) & 0b0111_1111) > 0b0111_0000;
        }


        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="half"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(half h)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && (h.value & 0x7FFF) == 0x7C00;
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="half"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(half h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || (h.value & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="half"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(half h)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (h.value & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="half2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isinf(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="half2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isfinite(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="half2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isnan(half2 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="half3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isinf(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="half3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isfinite(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="half3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isnan(half3 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="half4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isinf(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="half4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isfinite(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="half4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isnan(half4 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="half8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isinf(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="half8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isfinite(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="half8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isnan(half8 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="half16"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isinf(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asushort(h) & 0x7FFF) == 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="half16"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isfinite(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : (asushort(h) & 0x7FFF) < 0x7C00;
        }

        ///<summary>        Returns a <see cref="bool16"/> indicating for each component of a <see cref="half16"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isnan(half16 h)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asushort(h) & 0x7FFF) > 0x7C00;
        }


        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="float"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(float f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF && Unity.Mathematics.math.isinf(f);
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="float"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(float f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF || Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="float"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(float f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN && Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isinf(float2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isfinite(float2 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isnan(float2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isinf(float3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isfinite(float3 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isnan(float3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isinf(float4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isfinite(float4 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isnan(float4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="float8"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isinf(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? false : (asint(f) << 1) == (asint(float.PositiveInfinity) << 1);
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="float8"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isfinite(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF ? true : abs(f) < float.PositiveInfinity;
        }

        ///<summary>        Returns a <see cref="bool8"/> indicating for each component of a <see cref="float8"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isnan(float8 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_NAN ? false : (asint(f) & bitmask32(31)) > 0x7F80_0000;
        }

        
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="double"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(double f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF && Unity.Mathematics.math.isinf(f);
        }

        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="double"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(double f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF || Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="double"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(double f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN && Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isinf(double2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isfinite(double2 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isnan(double2 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isinf(double3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isfinite(double3 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isnan(double3 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }


        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isinf(double4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF & Unity.Mathematics.math.isinf(f);
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> whether it is a finite floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isfinite(double4 f)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF | Unity.Mathematics.math.isfinite(f);
        }

        ///<summary>        Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isnan(double4 f)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN & Unity.Mathematics.math.isnan(f);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool isinf(quadruple.ConstChecked x)
        {
            return !x.Promise.NotInf && isinf(x.Value);
        }
        
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quadruple"/> whether it is an infinite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isinf(quadruple x)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_INF
                && abs(x).value == quadruple.SIGNALING_EXPONENT;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool isfinite(quadruple.ConstChecked x)
        {
            return x.Promise.NotInf || isfinite(x.Value);
        }
        
        /// <summary>        Returns a <see cref="bool"/> indicating for a <see cref="quadruple"/> whether it is a finite floating point value.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isfinite(quadruple x)
        {
            return COMPILATION_OPTIONS.FLOAT_NO_INF
                || abs(x).value < quadruple.SIGNALING_EXPONENT;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool isnan(quadruple.ConstChecked x)
        {
            return !x.Promise.NotNaN && isnan(x.Value);
        }
        
        ///<summary>        Returns a <see cref="bool"/> indicating for a <see cref="quadruple"/> whether it is a NaN (not a number) floating point value.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnan(quadruple x)
        {
            return !COMPILATION_OPTIONS.FLOAT_NO_NAN
                && (abs(x).value > quadruple.SIGNALING_EXPONENT);
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="quarter"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(quarter x)
        {
            int cmp = asbyte(x) & MaxMath.quarter.SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != MaxMath.quarter.SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="half"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(half x)
        {
            int cmp = asushort(x) & F16_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F16_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="float"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(float x)
        {
            int cmp = asint(x) & F32_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F32_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="double"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(double x)
        {
            long cmp = aslong(x) & F64_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F64_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="quarter"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(quarter x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = asbyte(x) & MaxMath.quarter.SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = asbyte(x) << 25 != 0;
            }
            else
            {
                nonZero = asbyte(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="half"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(half x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = asushort(x) & F16_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = asushort(x) << 17 != 0;
            }
            else
            {
                nonZero = asushort(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="float"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(float x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = asint(x) & F32_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = asint(x) << 1 != 0;
            }
            else
            {
                nonZero = asint(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="double"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(double x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            long cmp = aslong(x) & F64_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = aslong(x) << 1 != 0;
            }
            else
            {
                nonZero = aslong(x) != 0;
            }

            return nonZero & zeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isnormal(quarter2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isnormal(quarter3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isnormal(quarter4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isnormal(quarter8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x8(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isnormal(quarter16 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x16(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7), isnormal(x.x8), isnormal(x.x9), isnormal(x.x10), isnormal(x.x11), isnormal(x.x12), isnormal(x.x13), isnormal(x.x14), isnormal(x.x15));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isnormal(quarter32 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x32(isnormal(x.v16_0), isnormal(x.v16_16));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isnormal(half2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isnormal(half3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isnormal(half4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isnormal(half8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x8(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isnormal(half16 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x16(isnormal(x.v8_0), isnormal(x.v8_8));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isnormal(float2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isnormal(float3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isnormal(float4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isnormal(float8 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x8(isnormal(x.v4_0), isnormal(x.v4_4));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isnormal(double2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isnormal(double3 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x3(isnormal(x.xy), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isnormal(double4 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x4(isnormal(x.xy), isnormal(x.zw));
        	}
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="quadruple"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(quadruple x)
        {
            ulong cmp = x.value.hi64 & quadruple.SIGNALING_EXPONENT.hi64;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != quadruple.SIGNALING_EXPONENT.hi64;
            }

            return notNanInf & nonZeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 issubnormal(quarter2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 issubnormal(quarter3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 issubnormal(quarter4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 issubnormal(quarter8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x8(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 issubnormal(quarter16 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x16(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7), issubnormal(x.x8), issubnormal(x.x9), issubnormal(x.x10), issubnormal(x.x11), issubnormal(x.x12), issubnormal(x.x13), issubnormal(x.x14), issubnormal(x.x15));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 issubnormal(quarter32 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpsubnorm_pq(x);
        	}
        	else
        	{
        		return new mask8x32(issubnormal(x.v16_0), issubnormal(x.v16_16));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 issubnormal(half2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 issubnormal(half3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 issubnormal(half4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 issubnormal(half8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x8(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 issubnormal(half16 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpsubnorm_ph(x);
        	}
        	else
        	{
        		return new mask16x16(issubnormal(x.v8_0), issubnormal(x.v8_8));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 issubnormal(float2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 issubnormal(float3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 issubnormal(float4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 issubnormal(float8 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpsubnorm_ps(x);
        	}
        	else
        	{
        		return new mask32x8(issubnormal(x.v4_0), issubnormal(x.v4_4));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 issubnormal(double2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return Xse.cmpsubnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 issubnormal(double3 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpsubnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x3(issubnormal(x.xy), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 issubnormal(double4 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return Xse.mm256_cmpsubnorm_pd(x);
        	}
        	else
        	{
        		return new mask64x4(issubnormal(x.xy), issubnormal(x.zw));
        	}
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="quadruple"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(quadruple x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            ulong cmp = x.value.hi64 & quadruple.SIGNALING_EXPONENT.hi64;
            bool zeroExponent = cmp == 0;

            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = (x.value.lo64 | (x.value.hi64 << 1)) != 0;
            }
            else
            {
                nonZero = x.value.IsNotZero;
            }

            return nonZero & zeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="quarter"/> <paramref name="x"/> is a finite integer value with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isint(quarter x, Promise notNaNinf = Promise.Nothing)
        {
            uint EXPONENT_MASK = bitmask32((uint)quarter.EXPONENT_BITS);
            uint FRACTION_MASK = bitmask32((uint)quarter.MANTISSA_BITS);

            uint bits = asbyte(x);

            uint exponent = (bits >> quarter.MANTISSA_BITS) & EXPONENT_MASK;
            uint unbiasedExponent = exponent - (uint)abs(quarter.EXPONENT_BIAS);
            uint fractionalMask = bitmask8(quarter.MANTISSA_BITS - unbiasedExponent);
            uint fraction = bits & FRACTION_MASK;

            bool unbiasedExponentNegative = (int)unbiasedExponent < 0;
            bool unbiasedExponentGEMantissaBits = (int)unbiasedExponent >= quarter.MANTISSA_BITS;
            bool result = (unbiasedExponentNegative & ((fraction | exponent) == 0))
                        | unbiasedExponentGEMantissaBits
                        | (!unbiasedExponentNegative & !unbiasedExponentGEMantissaBits & ((fraction & fractionalMask) == 0));

            if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                && COMPILATION_OPTIONS.FLOAT_NO_INF)
               || notNaNinf.Promises(Promise.Unsafe0)))
            {
                result &= exponent != EXPONENT_MASK;
            }

            return result;
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter2"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 isint(quarter2 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 2);
            }
            else
            {
                return new bool2(isint(x.x, notNaNinf), isint(x.y, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter3"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 isint(quarter3 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new bool3(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter4"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 isint(quarter4 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new bool4(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf), isint(x.w, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter8"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 isint(quarter8 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 8);
            }
            else
            {
                return new bool8(isint(x.x0, notNaNinf), 
                                 isint(x.x1, notNaNinf), 
                                 isint(x.x2, notNaNinf), 
                                 isint(x.x3, notNaNinf), 
                                 isint(x.x4, notNaNinf), 
                                 isint(x.x5, notNaNinf), 
                                 isint(x.x6, notNaNinf), 
                                 isint(x.x7, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter16"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 isint(quarter16 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 16);
            }
            else
            {
                return new bool16(isint(x.x0,  notNaNinf), 
                                  isint(x.x1,  notNaNinf), 
                                  isint(x.x2,  notNaNinf), 
                                  isint(x.x3,  notNaNinf), 
                                  isint(x.x4,  notNaNinf), 
                                  isint(x.x5,  notNaNinf), 
                                  isint(x.x6,  notNaNinf), 
                                  isint(x.x7,  notNaNinf), 
                                  isint(x.x8,  notNaNinf), 
                                  isint(x.x9,  notNaNinf), 
                                  isint(x.x10, notNaNinf), 
                                  isint(x.x11, notNaNinf), 
                                  isint(x.x12, notNaNinf), 
                                  isint(x.x13, notNaNinf), 
                                  isint(x.x14, notNaNinf), 
                                  isint(x.x15, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="quarter32"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 isint(quarter32 x, Promise notNaNinf = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpint_pq(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool32(isint(x.v16_0, notNaNinf), isint(x.v16_16, notNaNinf));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="half"/> <paramref name="x"/> is a finite integer value with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isint(half x, Promise notNaNinf = Promise.Nothing)
        {
            uint EXPONENT_MASK = bitmask32((uint)half.EXPONENT_BITS);
            uint FRACTION_MASK = bitmask32((uint)half.MANTISSA_BITS);

            uint bits = asushort(x);

            uint exponent = (bits >> half.MANTISSA_BITS) & EXPONENT_MASK;
            uint unbiasedExponent = exponent - (uint)abs(half.EXPONENT_BIAS);
            uint fractionalMask = bitmask16(half.MANTISSA_BITS - unbiasedExponent);
            uint fraction = bits & FRACTION_MASK;

            bool unbiasedExponentNegative = (int)unbiasedExponent < 0;
            bool unbiasedExponentGEMantissaBits = (int)unbiasedExponent >= half.MANTISSA_BITS;
            bool result = (unbiasedExponentNegative & ((fraction | exponent) == 0))
                        | unbiasedExponentGEMantissaBits
                        | (!unbiasedExponentNegative & !unbiasedExponentGEMantissaBits & ((fraction & fractionalMask) == 0));
            
            if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                && COMPILATION_OPTIONS.FLOAT_NO_INF)
               || notNaNinf.Promises(Promise.Unsafe0)))
            {
                result &= exponent != EXPONENT_MASK;
            }

            return result;
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="half2"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 isint(half2 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ph(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 2);
            }
            else
            {
                return new bool2(isint(x.x, notNaNinf), isint(x.y, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="half3"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 isint(half3 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ph(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new bool3(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="half4"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 isint(half4 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ph(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new bool4(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf), isint(x.w, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="half16"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 isint(half8 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ph(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 16);
            }
            else
            {
                return new bool8(isint(x.x0, notNaNinf), 
                                 isint(x.x1, notNaNinf), 
                                 isint(x.x2, notNaNinf), 
                                 isint(x.x3, notNaNinf), 
                                 isint(x.x4, notNaNinf), 
                                 isint(x.x5, notNaNinf), 
                                 isint(x.x6, notNaNinf), 
                                 isint(x.x7, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="half16"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 isint(half16 x, Promise notNaNinf = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpint_ph(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool16(isint(x.v8_0, notNaNinf), isint(x.v8_8, notNaNinf));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="float"/> <paramref name="x"/> is a finite integer value with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isint(float x, Promise notNaNinf = Promise.Nothing)
        {
            static bool HardwareSupported(float x, Promise notNaNinf)
            {
                bool result = trunc(x) == x;
                
                if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                    && COMPILATION_OPTIONS.FLOAT_NO_INF)
                   || notNaNinf.Promises(Promise.Unsafe0)))
                {
                    uint mask = bitmask32((uint)F32_EXPONENT_BITS, (uint)F32_MANTISSA_BITS);

                    result &= !((asuint(x) & mask) == mask);
                }

                return result;
            }

            if (Sse4_1.IsSse41Supported)
            {
                return HardwareSupported(x, notNaNinf);
            }
            if (Arm.Neon.IsNeonSupported)
            {
                return HardwareSupported(x, notNaNinf);
            }

            uint EXPONENT_MASK = bitmask32((uint)F32_EXPONENT_BITS);
            uint FRACTION_MASK = bitmask32((uint)F32_MANTISSA_BITS);

            uint bits = asuint(x);

            uint exponent = (bits >> F32_MANTISSA_BITS) & EXPONENT_MASK;
            uint unbiasedExponent = exponent - (uint)abs(F32_EXPONENT_BIAS);
            uint fractionalMask = bitmask32(F32_MANTISSA_BITS - unbiasedExponent);
            uint fraction = bits & FRACTION_MASK;

            bool unbiasedExponentNegative = (int)unbiasedExponent < 0;
            bool unbiasedExponentGEMantissaBits = (int)unbiasedExponent >= F32_MANTISSA_BITS;
            bool result = (unbiasedExponentNegative & ((fraction | exponent) == 0))
                        | unbiasedExponentGEMantissaBits
                        | (!unbiasedExponentNegative & !unbiasedExponentGEMantissaBits & ((fraction & fractionalMask) == 0));
            
            if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                && COMPILATION_OPTIONS.FLOAT_NO_INF)
               || notNaNinf.Promises(Promise.Unsafe0)))
            {
                result &= exponent != EXPONENT_MASK;
            }

            return result;
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="float2"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 isint(float2 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ps(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 2);
            }
            else
            {
                return new bool2(isint(x.x, notNaNinf), isint(x.y, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="float3"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 isint(float3 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ps(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 3);
            }
            else
            {
                return new bool3(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="float4"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 isint(float4 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_ps(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0), elements: 4);
            }
            else
            {
                return new bool4(isint(x.x, notNaNinf), isint(x.y, notNaNinf), isint(x.z, notNaNinf), isint(x.w, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="float32"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 isint(float8 x, Promise notNaNinf = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpint_ps(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool8(isint(x.v4_0, notNaNinf), isint(x.v4_4, notNaNinf));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="double"/> <paramref name="x"/> is a finite integer value with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isint(double x, Promise notNaNinf = Promise.Nothing)
        {
            static bool HardwareSupported(double x, Promise notNaNinf)
            {
                bool result = trunc(x) == x;
                
                if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                    && COMPILATION_OPTIONS.FLOAT_NO_INF)
                   || notNaNinf.Promises(Promise.Unsafe0)))
                {
                    ulong mask = bitmask64((ulong)F64_EXPONENT_BITS, (ulong)F64_MANTISSA_BITS);

                    result &= !((asulong(x) & mask) == mask);
                }

                return result;
            }

            if (Sse4_1.IsSse41Supported)
            {
                return HardwareSupported(x, notNaNinf);
            }
            if (Arm.Neon.IsNeonSupported)
            {
                return HardwareSupported(x, notNaNinf);
            }

            ulong EXPONENT_MASK = bitmask64((ulong)F64_EXPONENT_BITS);
            ulong FRACTION_MASK = bitmask64((ulong)F64_MANTISSA_BITS);

            ulong bits = asulong(x);

            ulong exponent = (bits >> F64_MANTISSA_BITS) & EXPONENT_MASK;
            ulong unbiasedExponent = exponent - (ulong)abs(F64_EXPONENT_BIAS);
            ulong fractionalMask = bitmask64(F64_MANTISSA_BITS - unbiasedExponent);
            ulong fraction = bits & FRACTION_MASK;

            bool unbiasedExponentNegative = (long)unbiasedExponent < 0;
            bool unbiasedExponentGEMantissaBits = (long)unbiasedExponent >= F64_MANTISSA_BITS;
            bool result = (unbiasedExponentNegative & ((fraction | exponent) == 0))
                        | unbiasedExponentGEMantissaBits
                        | (!unbiasedExponentNegative & !unbiasedExponentGEMantissaBits & ((fraction & fractionalMask) == 0));
            
            if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                && COMPILATION_OPTIONS.FLOAT_NO_INF)
               || notNaNinf.Promises(Promise.Unsafe0)))
            {
                result &= exponent != EXPONENT_MASK;
            }

            return result;
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="double2"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 isint(double2 x, Promise notNaNinf = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpint_pd(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool2(isint(x.x, notNaNinf), isint(x.y, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="double3"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 isint(double3 x, Promise notNaNinf = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpint_pd(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool3(isint(x.xy, notNaNinf), isint(x.z, notNaNinf));
            }
        }

        /// <summary>       Returns <see langword="true"/> if the components in the <see cref="double4"/> <paramref name="x"/> are finite integer values with the fractional part being equal to 0. 
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 isint(double4 x, Promise notNaNinf = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_cmpint_pd(x, notNaNinf: notNaNinf.Promises(Promise.Unsafe0));
            }
            else
            {
                return new bool4(isint(x.xy, notNaNinf), isint(x.zw, notNaNinf));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="quadruple"/> <paramref name="x"/> is a finite integer value with the fractional part being equal to 0.      
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="notNaNinf"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for infinite values or NaN.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isint(quadruple x, Promise notNaNinf = Promise.Nothing)
        {
            ulong EXPONENT_MASK = bitmask64((ulong)quadruple.EXPONENT_BITS);
            UInt128 FRACTION_MASK = bitmask128((ulong)quadruple.MANTISSA_BITS);

            UInt128 bits = asuint128(x);

            ulong exponent = (ulong)(bits >> quadruple.MANTISSA_BITS) & EXPONENT_MASK;
            ulong unbiasedExponent = exponent - (ulong)abs(quadruple.EXPONENT_BIAS);
            UInt128 fractionalMask = bitmask128(quadruple.MANTISSA_BITS - unbiasedExponent);
            UInt128 fraction = bits & FRACTION_MASK;

            bool unbiasedExponentNegative = (long)unbiasedExponent < 0;
            bool unbiasedExponentGEMantissaBits = (long)unbiasedExponent >= quadruple.MANTISSA_BITS;
            bool result = (unbiasedExponentNegative & ((fraction | exponent) == 0))
                        | unbiasedExponentGEMantissaBits
                        | (!unbiasedExponentNegative & !unbiasedExponentGEMantissaBits & ((fraction & fractionalMask) == 0));
            
            if (!((COMPILATION_OPTIONS.FLOAT_NO_NAN 
                && COMPILATION_OPTIONS.FLOAT_NO_INF)
               || notNaNinf.Promises(Promise.Unsafe0)))
            {
                result &= exponent != EXPONENT_MASK;
            }

            return result;
        }
    }
}
