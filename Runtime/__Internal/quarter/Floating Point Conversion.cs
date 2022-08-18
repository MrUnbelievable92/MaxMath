using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal static partial class Vectorized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtsq_ss(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 F8_NAN_INF = Sse2.cvtsi32_si128(SIGNALING_EXPONENT);
                    v128 F32_INF = RegisterConversion.ToV128(float.PositiveInfinity);
                    v128 MAGIC = Sse2.cvtsi32_si128(F32_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || Xse.constexpr.IS_TRUE(q.Byte0 <= MaxValue.value))
                    {
                        exponentMantissa = Sse2.slli_epi32(q, F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                        return Sse.mul_ss(MAGIC, exponentMantissa);
                    }

                    exponentMantissa = Sse2.srli_epi32(Sse2.slli_epi32(q, F32_SHL_LOSE_SIGN), F32_SHR_PLACE_MANTISSA);
                    v128 sign = Sse2.slli_epi32(Sse2.srli_epi32(q, BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return Sse.mul_ss(MAGIC, Sse2.or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = Sse2.cmpeq_epi32(Sse2.and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f32 = Xse.ternarylogic_si128(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return Sse.mul_ss(Sse2.or_si128(sign, f32), Xse.blendv_si128(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 F8_NAN_INF = Sse2.set1_epi32(SIGNALING_EXPONENT);
                    v128 F32_INF = Sse.set1_ps(float.PositiveInfinity);
                    v128 MAGIC = Sse2.set1_epi32(F32_MAGIC);
                    v128 exponentMantissa;

                    if (promiseAbsoluteAndInRange || Xse.constexpr.ALL_LE_EPU8(q, MaxValue.value, elements))
                    {
                        exponentMantissa = Sse2.slli_epi32(Xse.cvtepu8_epi32(q), F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                        return Sse.mul_ps(MAGIC, exponentMantissa);
                    }
                    
                    q = Xse.cvtepu8_epi32(q);
                    exponentMantissa = Sse2.srli_epi32(Sse2.slli_epi32(q, F32_SHL_LOSE_SIGN), F32_SHR_PLACE_MANTISSA);
                    v128 sign = Sse2.slli_epi32(Sse2.srli_epi32(q, BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return Sse.mul_ps(MAGIC, Sse2.or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = Sse2.cmpeq_epi32(Sse2.and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f32 = Xse.ternarylogic_si128(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return Sse.mul_ps(Sse2.or_si128(sign, f32), Xse.blendv_si128(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_ps(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_NAN_INF = Avx.mm256_set1_epi32(SIGNALING_EXPONENT);
                    v256 F32_INF = Avx.mm256_set1_ps(float.PositiveInfinity);
                    v256 MAGIC = Avx.mm256_set1_epi32(F32_MAGIC);
                    v256 exponentMantissa;

                    if (promiseAbsoluteAndInRange || Xse.constexpr.ALL_LE_EPU8(q, MaxValue.value, 8))
                    {
                        exponentMantissa = Avx2.mm256_slli_epi32(Avx2.mm256_cvtepu8_epi32(q), F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                        return Avx.mm256_mul_ps(MAGIC, exponentMantissa);
                    }
                    
                    v256 __q = Avx2.mm256_cvtepu8_epi32(q);
                    exponentMantissa = Avx2.mm256_srli_epi32(Avx2.mm256_slli_epi32(__q, F32_SHL_LOSE_SIGN), F32_SHR_PLACE_MANTISSA);
                    v256 sign = Avx2.mm256_slli_epi32(Avx2.mm256_srli_epi32(__q, BITS - 1), F32_BITS - 1);

                    if (promiseInRange)
                    {
                        return Avx.mm256_mul_ps(MAGIC, Avx2.mm256_or_si256(sign, exponentMantissa));
                    }
                    
                    v256 isNanInf = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(__q, F8_NAN_INF), F8_NAN_INF);
                    v256 f32 = Xse.mm256_ternarylogic_si256(exponentMantissa, F32_INF, isNanInf, TernaryOperation.OxF8);

                    return Avx.mm256_mul_ps(Avx2.mm256_or_si256(sign, f32), Xse.mm256_blendv_si256(MAGIC, f32, isNanInf));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtsq_sd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 F8_NAN_INF = Sse2.cvtsi64x_si128(SIGNALING_EXPONENT);
                    v128 F64_INF = RegisterConversion.ToV128(double.PositiveInfinity);
                    v128 MAGIC = Sse2.cvtsi64x_si128(F64_MAGIC);
                    v128 exponentMantissa;
                    
                    if (promiseAbsoluteAndInRange || Xse.constexpr.IS_TRUE(q.Byte0 <= MaxValue.value))
                    {
                        exponentMantissa = Sse2.slli_epi64(q, F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                        return Sse2.mul_sd(MAGIC, exponentMantissa);
                    }

                    exponentMantissa = Sse2.srli_epi64(Sse2.slli_epi64(q, F64_SHL_LOSE_SIGN), F64_SHR_PLACE_MANTISSA);
                    v128 sign = Sse2.slli_epi64(Sse2.srli_epi64(q, BITS - 1), F64_BITS - 1);
                    
                    if (promiseInRange)
                    {
                        return Sse2.mul_sd(MAGIC, Sse2.or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = Xse.cmpeq_epi64(Sse2.and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f64 = Xse.ternarylogic_si128(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return Sse2.mul_sd(Sse2.or_si128(sign, f64), Xse.blendv_pd(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 F8_NAN_INF = Sse2.set1_epi64x(SIGNALING_EXPONENT);
                    v128 F64_INF = Sse2.set1_pd(double.PositiveInfinity);
                    v128 MAGIC = Sse2.set1_epi64x(F64_MAGIC);
                    v128 exponentMantissa;
                    
                    if (promiseAbsoluteAndInRange || Xse.constexpr.ALL_LE_EPU8(q, MaxValue.value, 2))
                    {
                        exponentMantissa = Sse2.slli_epi64(Xse.cvtepu8_epi64(q), F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                        return Sse2.mul_pd(MAGIC, exponentMantissa);
                    }
                    
                    q = Xse.cvtepu8_epi64(q);
                    exponentMantissa = Sse2.srli_epi64(Sse2.slli_epi64(q, F64_SHL_LOSE_SIGN), F64_SHR_PLACE_MANTISSA);
                    v128 sign = Sse2.slli_epi64(Sse2.srli_epi64(q, BITS - 1), F64_BITS - 1);
                    
                    if (promiseInRange)
                    {
                        return Sse2.mul_pd(MAGIC, Sse2.or_si128(sign, exponentMantissa));
                    }

                    v128 isNanInf = Xse.cmpeq_epi64(Sse2.and_si128(q, F8_NAN_INF), F8_NAN_INF);
                    v128 f64 = Xse.ternarylogic_si128(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return Sse2.mul_pd(Sse2.or_si128(sign, f64), Xse.blendv_pd(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cvtpq_pd(v128 q, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 F8_NAN_INF = Avx.mm256_set1_epi64x(SIGNALING_EXPONENT);
                    v256 F64_INF = Avx.mm256_set1_pd(double.PositiveInfinity);
                    v256 MAGIC = Avx.mm256_set1_epi64x(F64_MAGIC);
                    v256 exponentMantissa;
                    
                    if (promiseAbsoluteAndInRange || Xse.constexpr.ALL_LE_EPU8(q, MaxValue.value, elements))
                    {
                        exponentMantissa = Avx2.mm256_slli_epi64(Avx2.mm256_cvtepu8_epi64(q), F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                        return Avx.mm256_mul_pd(MAGIC, exponentMantissa);
                    }
                    
                    v256 __q = Avx2.mm256_cvtepu8_epi64(q);
                    exponentMantissa = Avx2.mm256_srli_epi64(Avx2.mm256_slli_epi64(__q, F64_SHL_LOSE_SIGN), F64_SHR_PLACE_MANTISSA);
                    v256 sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(__q, BITS - 1), F64_BITS - 1);
                    
                    if (promiseInRange)
                    {
                        return Avx.mm256_mul_pd(MAGIC, Avx2.mm256_or_si256(sign, exponentMantissa));
                    }

                    v256 isNanInf = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(__q, F8_NAN_INF), F8_NAN_INF);
                    v256 f64 = Xse.mm256_ternarylogic_si256(exponentMantissa, F64_INF, isNanInf, TernaryOperation.OxF8);

                    return Avx.mm256_mul_pd(Avx2.mm256_or_si256(sign, f64), Avx.mm256_blendv_pd(MAGIC, f64, isNanInf));
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtph_pq(v128 h, bool promiseInRange = false, bool promiseAbsolute = false, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (elements == 8)
                    {
                        float8 f = RegisterConversion.ToType<half8>(h);

                        if (Avx2.IsAvx2Supported)
                        {
                            return mm256_cvtps_pq(f, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange);
                        }
                        else
                        {
                            return new quarter8(cvtps_pq(RegisterConversion.ToV128(f.v4_0), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, elements: 4), cvtps_pq(RegisterConversion.ToV128(f.v4_4), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, elements: 4));
                        }
                    }
                    else if (elements == 4)
                    {
                        float4 f = RegisterConversion.ToType<half4>(h);

                        return cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, elements: 4);
                    }
                    else if (elements == 3)
                    {
                        float3 f = RegisterConversion.ToType<half3>(h);

                        return cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, elements: 3);
                    }
                    else
                    {
                        float2 f = RegisterConversion.ToType<half2>(h);

                        return cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsolute & promiseInRange, elements: 2);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtss_sq(v128 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NAN_INF_MASK = Sse2.cvtsi32_si128(F32_SIGNALING_EXPONENT);
                    v128 MAX_EXPONENT_MASK = Sse2.cvtsi32_si128((-F32_EXPONENT_BIAS + MAX_EXPONENT) << F32_MANTISSA_BITS);
                    v128 MAGIC = RegisterConversion.ToV128(1f / asfloat(F32_MAGIC));

                    v128 inRange = Sse.mul_ss(s, MAGIC);
                    inRange = Sse2.srli_epi32(inRange, (F32_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v128 round = Sse2.srli_epi32(Sse2.and_si128(Sse2.set1_epi32(1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F32_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Sse2.or_si128(inRange, round);

                    if (promiseAbsoluteAndInRange || Xse.constexpr.IS_TRUE(s.Float0 >= 0f & s.Float0 <= MaxValue))
                    {
                        return inRange;
                    }
                    
                    v128 f8_sign = Sse2.srli_epi32(s, F32_BITS - 1);

                    if (promiseInRange || Xse.constexpr.IS_TRUE(s.Float0 >= MinValue & s.Float0 <= MaxValue))
                    {
                        f8_sign = Sse2.slli_epi32(f8_sign, (BITS - 1));

                        return Sse2.xor_si128(inRange, f8_sign);
                    }

                    v128 f32_exponent = Sse2.and_si128(s, NAN_INF_MASK);
                    v128 overflow = Sse2.cmpgt_epi32(f32_exponent, MAX_EXPONENT_MASK);
                    v128 nanInf = Sse2.cmpeq_epi32(f32_exponent, NAN_INF_MASK);
                    v128 setInf = Sse2.andnot_si128(nanInf, overflow);
                    v128 result = Xse.blendv_si128(inRange, Sse2.cvtsi32_si128(PositiveInfinity.value), setInf);

                    f8_sign = Sse2.xor_si128(f8_sign, nanInf);
                    f8_sign = Sse2.slli_epi32(f8_sign, (BITS - 1));
                    
                    return Sse2.xor_si128(f8_sign, result); 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtps_pq(v128 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    return Xse.cvtepi32_epi8(BASE__cvtps_pq(s, promiseInRange, promiseAbsoluteAndInRange, elements));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtps_pq(v256 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NAN_INF_MASK = Avx.mm256_set1_epi32(F32_SIGNALING_EXPONENT);
                    v256 MAX_EXPONENT_MASK = Avx.mm256_set1_epi32((-F32_EXPONENT_BIAS + MAX_EXPONENT) << F32_MANTISSA_BITS);
                    v256 MAGIC = Avx.mm256_set1_ps(1f / asfloat(F32_MAGIC));

                    v256 inRange = Avx.mm256_mul_ps(s, MAGIC);
                    inRange = Avx2.mm256_srli_epi32(inRange, (F32_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v256 round = Avx2.mm256_srli_epi32(Avx2.mm256_and_si256(Avx.mm256_set1_epi32(1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F32_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Avx2.mm256_or_si256(inRange, round);

                    if (promiseAbsoluteAndInRange || (Xse.constexpr.ALL_GE_EPI32(s, 0) && Xse.constexpr.ALL_LE_PS(s, MaxValue)))
                    {
                        return Xse.mm256_cvtepi32_epi8(inRange);
                    }
                    
                    v256 f8_sign = Avx2.mm256_srli_epi32(s, F32_BITS - 1);

                    if (promiseInRange || (Xse.constexpr.ALL_GE_PS(s, MinValue) && Xse.constexpr.ALL_LE_PS(s, MaxValue)))
                    {
                        f8_sign = Avx2.mm256_slli_epi32(f8_sign, (BITS - 1));

                        return Xse.mm256_cvtepi32_epi8(Avx2.mm256_xor_si256(inRange, f8_sign));
                    }

                    v256 f32_exponent = Avx2.mm256_and_si256(s, NAN_INF_MASK);
                    v256 overflow = Avx2.mm256_cmpgt_epi32(f32_exponent, MAX_EXPONENT_MASK);
                    v256 nanInf = Avx2.mm256_cmpeq_epi32(f32_exponent, NAN_INF_MASK);
                    v256 setInf = Avx2.mm256_andnot_si256(nanInf, overflow);
                    v256 result = Xse.mm256_blendv_si256(inRange, Avx.mm256_set1_epi32(PositiveInfinity.value), setInf);

                    f8_sign = Avx2.mm256_xor_si256(f8_sign, nanInf);
                    f8_sign = Avx2.mm256_slli_epi32(f8_sign, (BITS - 1));

                    return Xse.mm256_cvtepi32_epi8(Avx2.mm256_xor_si256(f8_sign, result)); 
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtsd_sq(v128 d, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NAN_INF_MASK = Sse2.cvtsi64x_si128(F64_SIGNALING_EXPONENT);
                    v128 MAX_EXPONENT_MASK = Sse2.cvtsi64x_si128((long)(-F64_EXPONENT_BIAS + MAX_EXPONENT) << F64_MANTISSA_BITS);

                    v128 inRange = Sse2.mul_sd(d, RegisterConversion.ToV128(1d / asdouble(F64_MAGIC)));
                    inRange = Sse2.srli_epi64(inRange, (F64_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v128 round = Sse2.srli_epi64(Sse2.and_si128(Sse2.set1_epi64x(1L << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F64_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Sse2.or_si128(inRange, round);
                    
                    if (promiseAbsoluteAndInRange || Xse.constexpr.IS_TRUE(d.Double0 >= 0d & d.Double0 <= MaxValue))
                    {
                        return inRange;
                    }
                    
                    v128 f8_sign;

                    if (promiseInRange || Xse.constexpr.IS_TRUE(d.Double0 >= MinValue & d.Double0 <= MaxValue))
                    {
                        f8_sign = Sse2.slli_epi64(Sse2.srli_epi64(d, F64_BITS - 1), (BITS - 1));

                        return Sse2.xor_si128(inRange, f8_sign);
                    }

                    v128 f64_exponent = Sse2.and_si128(d, NAN_INF_MASK);
                    v128 overflow = Sse2.cmpgt_epi32(f64_exponent, MAX_EXPONENT_MASK);
                    v128 nanInf = Sse2.cmpeq_epi32(f64_exponent, NAN_INF_MASK);
                    v128 setInf = Sse2.andnot_si128(nanInf, overflow);

                    if (Sse4_1.IsSse41Supported)
                    {
                        ;
                    }
                    else
                    {
                        setInf = Sse2.shuffle_epi32(setInf, Sse.SHUFFLE(3, 3, 1, 1));
                    }

                    v128 result = Xse.blendv_pd(inRange, Sse2.cvtsi32_si128(PositiveInfinity.value), setInf);

                    f8_sign = Sse2.xor_si128(d, nanInf);
                    f8_sign = Sse2.srli_epi64(f8_sign, F64_BITS - 1);
                    f8_sign = Sse2.slli_epi64(f8_sign, (BITS - 1));
                    
                    return Sse2.xor_si128(f8_sign, result); 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cvtpd_pq(v128 d, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NAN_INF_MASK = Sse2.set1_epi64x(F64_SIGNALING_EXPONENT);
                    v128 MAX_EXPONENT_MASK = Sse2.set1_epi64x((long)(-F64_EXPONENT_BIAS + MAX_EXPONENT) << F64_MANTISSA_BITS);

                    v128 inRange = Sse2.mul_pd(d, Sse2.set1_pd(1d / asdouble(F64_MAGIC)));
                    inRange = Sse2.srli_epi64(inRange, (F64_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v128 round = Sse2.srli_epi64(Sse2.and_si128(Sse2.set1_epi64x(1L << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F64_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Sse2.or_si128(inRange, round);
                    
                    if (promiseAbsoluteAndInRange || (Xse.constexpr.ALL_GE_PD(d, 0d) && Xse.constexpr.ALL_LE_PD(d, MaxValue)))
                    {
                        return Xse.cvtepi64_epi8(inRange);
                    }
                    
                    v128 f8_sign;

                    if (promiseInRange || (Xse.constexpr.ALL_GE_PD(d, 0d) && Xse.constexpr.ALL_LE_PD(d, MaxValue)))
                    {
                        f8_sign = Sse2.slli_epi64(Sse2.srli_epi64(d, F64_BITS - 1), (BITS - 1));

                        return Xse.cvtepi64_epi8(Sse2.xor_si128(inRange, f8_sign));
                    }

                    v128 f64_exponent = Sse2.and_si128(d, NAN_INF_MASK);
                    v128 overflow = Sse2.cmpgt_epi32(f64_exponent, MAX_EXPONENT_MASK);
                    v128 nanInf = Sse2.cmpeq_epi32(f64_exponent, NAN_INF_MASK);
                    v128 setInf = Sse2.andnot_si128(nanInf, overflow);

                    if (Sse4_1.IsSse41Supported)
                    {
                        ;
                    }
                    else
                    {
                        setInf = Sse2.shuffle_epi32(setInf, Sse.SHUFFLE(3, 3, 1, 1));
                    }

                    v128 result = Xse.blendv_pd(inRange, Sse2.set1_epi64x(PositiveInfinity.value), setInf);

                    f8_sign = Sse2.xor_si128(d, nanInf);
                    f8_sign = Sse2.srli_epi64(f8_sign, F64_BITS - 1);
                    f8_sign = Sse2.slli_epi64(f8_sign, (BITS - 1));

                    return Xse.cvtepi64_epi8(Sse2.xor_si128(f8_sign, result)); 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 mm256_cvtpd_pq(v256 d, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 3)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 NAN_INF_MASK = Avx.mm256_set1_epi64x(F64_SIGNALING_EXPONENT);
                    v256 MAX_EXPONENT_MASK = Avx.mm256_set1_epi64x((long)(-F64_EXPONENT_BIAS + MAX_EXPONENT) << F64_MANTISSA_BITS);

                    v256 inRange = Avx.mm256_mul_pd(d, Avx.mm256_set1_pd(1d / asdouble(F64_MAGIC)));
                    inRange = Avx2.mm256_srli_epi64(inRange, (F64_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v256 round = Avx2.mm256_srli_epi64(Avx2.mm256_and_si256(Avx.mm256_set1_epi64x(1L << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F64_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Avx2.mm256_or_si256(inRange, round);
                    
                    if (promiseAbsoluteAndInRange || (Xse.constexpr.ALL_GE_PD(d, 0d, elements) && Xse.constexpr.ALL_LE_PD(d, MaxValue, elements)))
                    {
                        return Xse.mm256_cvtepi64_epi8(inRange);
                    }
                    
                    v256 f8_sign;

                    if (promiseInRange || (Xse.constexpr.ALL_GE_PD(d, 0d, elements) && Xse.constexpr.ALL_LE_PD(d, MaxValue, elements)))
                    {
                        f8_sign = Avx2.mm256_slli_epi64(Avx2.mm256_srli_epi64(d, F64_BITS - 1), (BITS - 1));

                        return Xse.mm256_cvtepi64_epi8(Avx2.mm256_xor_si256(inRange, f8_sign));
                    }

                    v256 f64_exponent = Avx2.mm256_and_si256(d, NAN_INF_MASK);
                    v256 overflow = Avx2.mm256_cmpgt_epi32(f64_exponent, MAX_EXPONENT_MASK);
                    v256 nanInf = Avx2.mm256_cmpeq_epi32(f64_exponent, NAN_INF_MASK);
                    v256 setInf = Avx2.mm256_andnot_si256(nanInf, overflow);

                    v256 result = Avx.mm256_blendv_pd(inRange, Avx.mm256_set1_epi64x(PositiveInfinity.value), setInf);

                    f8_sign = Avx2.mm256_xor_si256(d, nanInf);
                    f8_sign = Avx2.mm256_srli_epi64(f8_sign, F64_BITS - 1);
                    f8_sign = Avx2.mm256_slli_epi64(f8_sign, (BITS - 1));

                    return Xse.mm256_cvtepi64_epi8(Avx2.mm256_xor_si256(f8_sign, result)); 
                }
                else throw new IllegalInstructionException();
            }

            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 BASE_OVERFLOWCTRL__cvtps_pq(v128 s, quarter overflowValue, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 NAN_INF_MASK = Sse2.set1_epi32(F32_SIGNALING_EXPONENT);
                    v128 MAX_EXPONENT_MASK = Sse2.set1_epi32((-F32_EXPONENT_BIAS + MAX_EXPONENT) << F32_MANTISSA_BITS);
                    v128 MAGIC = Sse.set1_ps(1f / asfloat(F32_MAGIC));

                    v128 inRange = Sse.mul_ps(s, MAGIC);
                    inRange = Sse2.srli_epi32(inRange, (F32_MANTISSA_BITS - (1 + EXPONENT_BITS)));
                    v128 round = Sse2.srli_epi32(Sse2.and_si128(Sse2.set1_epi32(1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)), inRange), F32_MANTISSA_BITS - MANTISSA_BITS - 1);
                    inRange = Sse2.or_si128(inRange, round);

                    if (promiseAbsoluteAndInRange || (Xse.constexpr.ALL_GE_EPI32(s, 0, elements) && Xse.constexpr.ALL_LE_PS(s, MaxValue, elements)))
                    {
                        return inRange;
                    }
                    
                    v128 f8_sign = Sse2.srli_epi32(s, F32_BITS - 1);

                    if (promiseInRange || (Xse.constexpr.ALL_GE_PS(s, MinValue, elements) && Xse.constexpr.ALL_LE_PS(s, MaxValue, elements)))
                    {
                        f8_sign = Sse2.slli_epi32(f8_sign, (BITS - 1));

                        return Sse2.xor_si128(inRange, f8_sign);
                    }

                    v128 f32_exponent = Sse2.and_si128(s, NAN_INF_MASK);
                    v128 overflow = Sse2.cmpgt_epi32(f32_exponent, MAX_EXPONENT_MASK);
                    v128 nanInf = Sse2.cmpeq_epi32(f32_exponent, NAN_INF_MASK);
                    v128 setInf = Sse2.andnot_si128(nanInf, overflow);
                    v128 result = Xse.blendv_si128(inRange, Sse2.set1_epi32(overflowValue.value), setInf);

                    f8_sign = Sse2.xor_si128(f8_sign, nanInf);
                    f8_sign = Sse2.slli_epi32(f8_sign, (BITS - 1));

                    return Sse2.xor_si128(f8_sign, result); 
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 BASE__cvtps_pq(v128 s, bool promiseInRange = false, bool promiseAbsoluteAndInRange = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    return BASE_OVERFLOWCTRL__cvtps_pq(s, promiseInRange: promiseInRange, promiseAbsoluteAndInRange: promiseAbsoluteAndInRange, overflowValue: quarter.PositiveInfinity, elements: elements); 
                }
                else throw new IllegalInstructionException();
            }
        }
    }
}
