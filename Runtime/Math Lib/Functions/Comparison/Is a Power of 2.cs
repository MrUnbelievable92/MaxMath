using System.Runtime.CompilerServices;
using Unity.Burst;
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
            public static v128 pow2_epu8(v128 a, bool nonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI8(a, 0, elements);

                    v128 result = cmpeq_epi8(blsr_epi8(a), setzero_si128());

                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi8(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu16(v128 a, bool nonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI16(a, 0, elements);

                    v128 result = cmpeq_epi16(blsr_epi16(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi16(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu32(v128 a, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI32(a, 0, elements);

                    v128 result = cmpeq_epi32(blsr_epi32(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi32(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epu64(v128 a, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI64(a, 0);

                    v128 result = cmpeq_epi64(blsr_epi64(a), setzero_si128());
                    
                    if (!nonZero)
                    {
                        result = andnot_si128(cmpeq_epi64(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu8(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI8(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi8(mm256_blsr_epi8(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu16(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI16(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi16(mm256_blsr_epi16(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu32(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI32(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_blsr_epi32(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epu64(v256 a, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    nonZero |= constexpr.ALL_NEQ_EPI64(a, 0, elements);

                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_blsr_epi64(a), Avx.mm256_setzero_si256());
                    
                    if (!nonZero)
                    {
                        result = Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi8(v128 a, bool positive = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI8(a, 0, elements);

                    v128 result = cmpeq_epi8(blsr_epi8(a), setzero_si128());

                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi8(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi16(v128 a, bool positive = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI16(a, 0, elements);

                    v128 result = cmpeq_epi16(blsr_epi16(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi16(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi32(v128 a, bool positive = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI32(a, 0, elements);

                    v128 result = cmpeq_epi32(blsr_epi32(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi32(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_epi64(v128 a, bool positive = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    positive |= constexpr.ALL_GT_EPI64(a, 0);

                    v128 result = cmpeq_epi64(blsr_epi64(a), setzero_si128());
                    
                    if (!positive)
                    {
                        result = and_si128(cmpgt_epi64(a, setzero_si128()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi8(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI8(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi8(mm256_blsr_epi8(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi8(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi16(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI16(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi16(mm256_blsr_epi16(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi16(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi32(v256 a, bool positive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI32(a, 0);

                    v256 result = Avx2.mm256_cmpeq_epi32(mm256_blsr_epi32(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi32(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_epi64(v256 a, bool positive = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    positive |= constexpr.ALL_GT_EPI64(a, 0, elements);

                    v256 result = Avx2.mm256_cmpeq_epi64(mm256_blsr_epi64(a), Avx.mm256_setzero_si256());
                    
                    if (!positive)
                    {
                        result = Avx2.mm256_and_si256(Avx2.mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()), result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_pq(v128 a, bool normal = false, bool nonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 sign = srai_epi8(a, 7);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return andnot_si128(sign, pow2mag_pq(a, normal: normal, nonZero: nonZero, elements: elements));
                    }
                    else
                    {
                        v128 MANTISSA_MASK = bitmask_epi8(set1_epi8(quarter.MANTISSA_BITS));
                        v128 EXPONENT_MASK = bitmask_epi8(set1_epi8(quarter.EXPONENT_BITS), set1_epi8(quarter.MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v128 not_normalExponent = cmpeq_epi8(and_si128(a, EXPONENT_MASK), setzero_si128());
                            return ternarylogic_si128(sign, not_normalExponent, cmpeq_epi8(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v128 normalExponent = cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                            return ternarylogic_si128(sign, normalExponent, cmpeq_epi8(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_ph(v128 a, bool normal = false, bool nonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 sign = srai_epi16(a, 15);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return andnot_si128(sign, pow2mag_pq(a, normal: normal, nonZero: nonZero, elements: elements));
                    }
                    else
                    {
                        v128 MANTISSA_MASK = bitmask_epi16(set1_epi16(half.MANTISSA_BITS));
                        v128 EXPONENT_MASK = bitmask_epi16(set1_epi16(half.EXPONENT_BITS), set1_epi16(half.MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v128 not_normalExponent = cmpeq_epi16(and_si128(a, EXPONENT_MASK), setzero_si128());
                            return ternarylogic_si128(sign, not_normalExponent, cmpeq_epi16(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v128 normalExponent = cmpgt_epi16(set1_epi16(half.SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                            return ternarylogic_si128(sign, normalExponent, cmpeq_epi16(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_ps(v128 a, bool normal = false, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 sign = srai_epi32(a, 31);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return andnot_si128(sign, pow2mag_pq(a, normal: normal, nonZero: nonZero, elements: elements));
                    }
                    else
                    {
                        v128 MANTISSA_MASK = bitmask_epi32(set1_epi32(F32_MANTISSA_BITS));
                        v128 EXPONENT_MASK = bitmask_epi32(set1_epi32(F32_EXPONENT_BITS), set1_epi32(F32_MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v128 not_normalExponent = cmpeq_epi32(and_si128(a, EXPONENT_MASK), setzero_si128());
                            return ternarylogic_si128(sign, not_normalExponent, cmpeq_epi32(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v128 normalExponent = cmpgt_epi32(set1_epi32(F32_SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                            return ternarylogic_si128(sign, normalExponent, cmpeq_epi32(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2_pd(v128 a, bool normal = false, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 sign = srai_epi64(a, 63);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return andnot_si128(sign, pow2mag_pq(a, normal: normal, nonZero: nonZero));
                    }
                    else
                    {
                        v128 MANTISSA_MASK = bitmask_epi64(set1_epi64x(F64_MANTISSA_BITS));
                        v128 EXPONENT_MASK = bitmask_epi64(set1_epi64x(F64_EXPONENT_BITS), set1_epi64x(F64_MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v128 not_normalExponent = cmpeq_epi64(and_si128(a, EXPONENT_MASK), setzero_si128());
                            return ternarylogic_si128(sign, not_normalExponent, cmpeq_epi64(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v128 normalExponent = cmpgt_epi64(set1_epi64x(F64_SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                            return ternarylogic_si128(sign, normalExponent, cmpeq_epi64(and_si128(a, MANTISSA_MASK), setzero_si128()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_pq(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sign = mm256_srai_epi8(a, 7);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx2.mm256_andnot_si256(sign, mm256_pow2mag_pq(a, normal: normal, nonZero: nonZero));
                    }
                    else
                    {
                        v256 MANTISSA_MASK = mm256_bitmask_epi8(mm256_set1_epi8(quarter.MANTISSA_BITS));
                        v256 EXPONENT_MASK = mm256_bitmask_epi8(mm256_set1_epi8(quarter.EXPONENT_BITS), mm256_set1_epi8(quarter.MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v256 not_normalExponent = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                            return mm256_ternarylogic_si256(sign, not_normalExponent, Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v256 normalExponent = Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                            return mm256_ternarylogic_si256(sign, normalExponent, Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_ph(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sign = mm256_srai_epi16(a, 15);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx2.mm256_andnot_si256(sign, mm256_pow2mag_pq(a, normal: normal, nonZero: nonZero));
                    }
                    else
                    {
                        v256 MANTISSA_MASK = mm256_bitmask_epi16(mm256_set1_epi16(half.MANTISSA_BITS));
                        v256 EXPONENT_MASK = mm256_bitmask_epi16(mm256_set1_epi16(half.EXPONENT_BITS), mm256_set1_epi16(half.MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v256 not_normalExponent = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                            return mm256_ternarylogic_si256(sign, not_normalExponent, Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v256 normalExponent = Avx2.mm256_cmpgt_epi16(mm256_set1_epi16(half.SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                            return mm256_ternarylogic_si256(sign, normalExponent, Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_ps(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sign = mm256_srai_epi32(a, 31);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx2.mm256_andnot_si256(sign, mm256_pow2mag_pq(a, normal: normal, nonZero: nonZero));
                    }
                    else
                    {
                        v256 MANTISSA_MASK = mm256_bitmask_epi32(mm256_set1_epi32(F32_MANTISSA_BITS));
                        v256 EXPONENT_MASK = mm256_bitmask_epi32(mm256_set1_epi32(F32_EXPONENT_BITS), mm256_set1_epi32(F32_MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v256 not_normalExponent = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                            return mm256_ternarylogic_si256(sign, not_normalExponent, Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v256 normalExponent = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(F32_SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                            return mm256_ternarylogic_si256(sign, normalExponent, Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2_pd(v256 a, bool normal = false, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 sign = mm256_srai_epi64(a, 63);

                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx2.mm256_andnot_si256(sign, mm256_pow2mag_pq(a, normal: normal, nonZero: nonZero));
                    }
                    else
                    {
                        v256 MANTISSA_MASK = mm256_bitmask_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS));
                        v256 EXPONENT_MASK = mm256_bitmask_epi64(mm256_set1_epi64x(F64_EXPONENT_BITS), mm256_set1_epi64x(F64_MANTISSA_BITS));
                        
                        if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                        {
                            v256 not_normalExponent = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                            return mm256_ternarylogic_si256(sign, not_normalExponent, Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO2);
                        }
                        else
                        {
                            v256 normalExponent = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(F64_SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                            return mm256_ternarylogic_si256(sign, normalExponent, Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256()), TernaryOperation.OxO8);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_epi8(v128 a, bool nonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return pow2_epu8(abs_epi8(a, elements: elements), nonZero: nonZero, elements: elements);
                    }
                    else
                    {
                        v128 neg = or_si128(a, dec_epi8(a));
                        v128 pos = and_si128(a, dec_epi8(a));

                        v128 cmp = srai_epi8(a, 7);
                        if (!nonZero)
                        {
                            cmp = xor_si128(cmp, cmpeq_epi8(a, setzero_si128()));
                        }

                        return cmpeq_epi8(blendv_epi8(pos, neg, a), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_epi16(v128 a, bool nonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return pow2_epu16(abs_epi16(a, elements: elements), nonZero: nonZero, elements: elements);
                    }
                    else
                    {
                        v128 neg = or_si128(a, dec_epi16(a));
                        v128 pos = and_si128(a, dec_epi16(a));

                        v128 cmp = srai_epi16(a, 15);
                        if (!nonZero)
                        {
                            cmp = xor_si128(cmp, cmpeq_epi16(a, setzero_si128()));
                        }

                        return cmpeq_epi16(blendv_si128(pos, neg, srai_epi16(a, 15)), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_epi32(v128 a, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return pow2_epu32(abs_epi32(a, elements: elements), nonZero: nonZero, elements: elements);
                    }
                    else
                    {
                        v128 neg = or_si128(a, dec_epi32(a));
                        v128 pos = and_si128(a, dec_epi32(a));

                        v128 cmp = srai_epi32(a, 31);
                        if (!nonZero)
                        {
                            cmp = xor_si128(cmp, cmpeq_epi32(a, setzero_si128()));
                        }

                        return cmpeq_epi32(blendv_ps(pos, neg, a), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_epi64(v128 a, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 neg = or_si128(a, dec_epi64(a));
                    v128 pos = and_si128(a, dec_epi64(a));
                    
                    v128 cmp = srai_epi64(a, 63);
                    if (!nonZero)
                    {
                        cmp = xor_si128(cmp, cmpeq_epi64(a, setzero_si128()));
                    }
                    
                    return cmpeq_epi64(blendv_pd(pos, neg, a), cmp);
                }
                else throw new IllegalInstructionException();
            }
            
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_epi8(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return mm256_pow2_epu8(mm256_abs_epi8(a), nonZero: nonZero);
                    }
                    else
                    {
                        v256 neg = Avx2.mm256_or_si256(a, mm256_dec_epi8(a));
                        v256 pos = Avx2.mm256_and_si256(a, mm256_dec_epi8(a));

                        v256 cmp = mm256_srai_epi8(a, 7);
                        if (!nonZero)
                        {
                            cmp = Avx2.mm256_xor_si256(cmp, Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()));
                        }

                        return Avx2.mm256_cmpeq_epi8(Avx2.mm256_blendv_epi8(pos, neg, a), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_epi16(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return mm256_pow2_epu16(mm256_abs_epi16(a), nonZero: nonZero);
                    }
                    else
                    {
                        v256 neg = Avx2.mm256_or_si256(a, mm256_dec_epi16(a));
                        v256 pos = Avx2.mm256_and_si256(a, mm256_dec_epi16(a));

                        v256 cmp = mm256_srai_epi16(a, 15);
                        if (!nonZero)
                        {
                            cmp = Avx2.mm256_xor_si256(cmp, Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()));
                        }

                        return Avx2.mm256_cmpeq_epi16(mm256_blendv_si256(pos, neg, mm256_srai_epi16(a, 15)), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_epi32(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                    {
                        return mm256_pow2_epu32(mm256_abs_epi32(a), nonZero: nonZero);
                    }
                    else
                    {
                        v256 neg = Avx2.mm256_or_si256(a, mm256_dec_epi32(a));
                        v256 pos = Avx2.mm256_and_si256(a, mm256_dec_epi32(a));

                        v256 cmp = mm256_srai_epi32(a, 31);
                        if (!nonZero)
                        {
                            cmp = Avx2.mm256_xor_si256(cmp, Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()));
                        }

                        return Avx2.mm256_cmpeq_epi32(Avx.mm256_blendv_ps(pos, neg, a), cmp);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_epi64(v256 a, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 neg = Avx2.mm256_or_si256(a, mm256_dec_epi64(a));
                    v256 pos = Avx2.mm256_and_si256(a, mm256_dec_epi64(a));
                    
                    v256 cmp = mm256_srai_epi64(a, 63);
                    if (!nonZero)
                    {
                        cmp = Avx2.mm256_xor_si256(cmp, Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()));
                    }
                    
                    return Avx2.mm256_cmpeq_epi64(Avx.mm256_blendv_pd(pos, neg, a), cmp);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_pq(v128 a, bool normal = false, bool nonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MANTISSA_MASK = bitmask_epi8(set1_epi8(quarter.MANTISSA_BITS));
                    v128 EXPONENT_MASK = bitmask_epi8(set1_epi8(quarter.EXPONENT_BITS), set1_epi8(quarter.MANTISSA_BITS));
                    
                    v128 result;
                    v128 not_normalExponent = cmpeq_epi8(and_si128(a, EXPONENT_MASK), setzero_si128());
                    v128 mantissa0 = cmpeq_epi8(and_si128(a, MANTISSA_MASK), setzero_si128());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = andnot_si128(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v128 notNaNinf = cmpgt_epi8(set1_epi8(quarter.SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                        result = ternarylogic_si128(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v128 oneMantissaBit = pow2_epu8(and_si128(a, MANTISSA_MASK), nonZero: nonZero, elements: elements); 
                        v128 expZero = cmpeq_epi8(and_si128(a, EXPONENT_MASK), setzero_si128());

                        result = ternarylogic_si128(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_ph(v128 a, bool normal = false, bool nonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MANTISSA_MASK = bitmask_epi16(set1_epi16(half.MANTISSA_BITS));
                    v128 EXPONENT_MASK = bitmask_epi16(set1_epi16(half.EXPONENT_BITS), set1_epi16(half.MANTISSA_BITS));
                    
                    v128 result;
                    v128 not_normalExponent = cmpeq_epi16(and_si128(a, EXPONENT_MASK), setzero_si128());
                    v128 mantissa0 = cmpeq_epi16(and_si128(a, MANTISSA_MASK), setzero_si128());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = andnot_si128(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v128 notNaNinf = cmpgt_epi16(set1_epi16(half.SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                        result = ternarylogic_si128(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v128 oneMantissaBit = pow2_epu16(and_si128(a, MANTISSA_MASK), nonZero: nonZero, elements: elements); 
                        v128 expZero = cmpeq_epi16(and_si128(a, EXPONENT_MASK), setzero_si128());

                        result = ternarylogic_si128(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_ps(v128 a, bool normal = false, bool nonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MANTISSA_MASK = bitmask_epi32(set1_epi32(F32_MANTISSA_BITS));
                    v128 EXPONENT_MASK = bitmask_epi32(set1_epi32(F32_EXPONENT_BITS), set1_epi32(F32_MANTISSA_BITS));
                    
                    v128 result;
                    v128 not_normalExponent = cmpeq_epi32(and_si128(a, EXPONENT_MASK), setzero_si128());
                    v128 mantissa0 = cmpeq_epi32(and_si128(a, MANTISSA_MASK), setzero_si128());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = andnot_si128(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v128 notNaNinf = cmpgt_epi32(set1_epi32(F32_SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                        result = ternarylogic_si128(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v128 oneMantissaBit = pow2_epu32(and_si128(a, MANTISSA_MASK), nonZero: nonZero, elements: elements); 
                        v128 expZero = cmpeq_epi32(and_si128(a, EXPONENT_MASK), setzero_si128());

                        result = ternarylogic_si128(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow2mag_pd(v128 a, bool normal = false, bool nonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 MANTISSA_MASK = bitmask_epi64(set1_epi64x(F64_MANTISSA_BITS));
                    v128 EXPONENT_MASK = bitmask_epi64(set1_epi64x(F64_EXPONENT_BITS), set1_epi64x(F64_MANTISSA_BITS));
                    
                    v128 result;
                    v128 not_normalExponent = cmpeq_epi64(and_si128(a, EXPONENT_MASK), setzero_si128());
                    v128 mantissa0 = cmpeq_epi64(and_si128(a, MANTISSA_MASK), setzero_si128());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = andnot_si128(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v128 notNaNinf = cmpgt_epi64(set1_epi64x(F64_SIGNALING_EXPONENT), and_si128(a, EXPONENT_MASK));
                        result = ternarylogic_si128(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }
                    
                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v128 oneMantissaBit = pow2_epu64(and_si128(a, MANTISSA_MASK), nonZero: nonZero); 
                        v128 expZero = cmpeq_epi64(and_si128(a, EXPONENT_MASK), setzero_si128());
                    
                        result = ternarylogic_si128(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_pq(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MANTISSA_MASK = mm256_bitmask_epi8(mm256_set1_epi8(quarter.MANTISSA_BITS));
                    v256 EXPONENT_MASK = mm256_bitmask_epi8(mm256_set1_epi8(quarter.EXPONENT_BITS), mm256_set1_epi8(quarter.MANTISSA_BITS));
                    
                    v256 result;
                    v256 not_normalExponent = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                    v256 mantissa0 = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = Avx2.mm256_andnot_si256(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v256 notNaNinf = Avx2.mm256_cmpgt_epi8(mm256_set1_epi8(quarter.SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                        result = mm256_ternarylogic_si256(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v256 oneMantissaBit = mm256_pow2_epu8(Avx2.mm256_and_si256(a, MANTISSA_MASK), nonZero: nonZero); 
                        v256 expZero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());

                        result = mm256_ternarylogic_si256(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_ph(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MANTISSA_MASK = mm256_bitmask_epi16(mm256_set1_epi16(half.MANTISSA_BITS));
                    v256 EXPONENT_MASK = mm256_bitmask_epi16(mm256_set1_epi16(half.EXPONENT_BITS), mm256_set1_epi16(half.MANTISSA_BITS));
                    
                    v256 result;
                    v256 not_normalExponent = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                    v256 mantissa0 = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = Avx2.mm256_andnot_si256(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v256 notNaNinf = Avx2.mm256_cmpgt_epi16(mm256_set1_epi16(half.SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                        result = mm256_ternarylogic_si256(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v256 oneMantissaBit = mm256_pow2_epu16(Avx2.mm256_and_si256(a, MANTISSA_MASK), nonZero: nonZero); 
                        v256 expZero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());

                        result = mm256_ternarylogic_si256(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_ps(v256 a, bool normal = false, bool nonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MANTISSA_MASK = mm256_bitmask_epi32(mm256_set1_epi32(F32_MANTISSA_BITS));
                    v256 EXPONENT_MASK = mm256_bitmask_epi32(mm256_set1_epi32(F32_EXPONENT_BITS), mm256_set1_epi32(F32_MANTISSA_BITS));
                    
                    v256 result;
                    v256 not_normalExponent = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                    v256 mantissa0 = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = Avx2.mm256_andnot_si256(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v256 notNaNinf = Avx2.mm256_cmpgt_epi32(mm256_set1_epi32(F32_SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                        result = mm256_ternarylogic_si256(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v256 oneMantissaBit = mm256_pow2_epu32(Avx2.mm256_and_si256(a, MANTISSA_MASK), nonZero: nonZero); 
                        v256 expZero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());

                        result = mm256_ternarylogic_si256(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow2mag_pd(v256 a, bool normal = false, bool nonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 MANTISSA_MASK = mm256_bitmask_epi64(mm256_set1_epi64x(F64_MANTISSA_BITS));
                    v256 EXPONENT_MASK = mm256_bitmask_epi64(mm256_set1_epi64x(F64_EXPONENT_BITS), mm256_set1_epi64x(F64_MANTISSA_BITS));
                    
                    v256 result;
                    v256 not_normalExponent = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());
                    v256 mantissa0 = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, MANTISSA_MASK), Avx.mm256_setzero_si256());
                    if (COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        result = Avx2.mm256_andnot_si256(not_normalExponent, mantissa0);
                    }
                    else
                    {
                        v256 notNaNinf = Avx2.mm256_cmpgt_epi64(mm256_set1_epi64x(F64_SIGNALING_EXPONENT), Avx2.mm256_and_si256(a, EXPONENT_MASK));
                        result = mm256_ternarylogic_si256(not_normalExponent, notNaNinf, mantissa0, TernaryOperation.OxO8);
                    }

                    if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        v256 oneMantissaBit = mm256_pow2_epu64(Avx2.mm256_and_si256(a, MANTISSA_MASK), nonZero: nonZero, elements: elements); 
                        v256 expZero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_and_si256(a, EXPONENT_MASK), Avx.mm256_setzero_si256());

                        result = mm256_ternarylogic_si256(result, oneMantissaBit, expZero, TernaryOperation.OxF8);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class math
    {
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(UInt128 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsPopcntSupported)
            {
                return countbits(x) == 1;
            }
            else
            {
                return (promises.Promises(Promise.NonZero) || x.IsNotZero) & (bits_resetlowest(x) == 0);
            }
        }
        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(Int128 x, Promise promises = Promise.Nothing)
        {
            return  (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(byte x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2(byte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask8x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2(byte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask8x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2(byte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask8x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2(byte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask8x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2(byte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu8(x, promises.Promises(Promise.NonZero), 16);
            }
            else
            {
                return new mask8x16(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises), ispow2(x.x8, promises), ispow2(x.x9, promises), ispow2(x.x10, promises), ispow2(x.x11, promises), ispow2(x.x12, promises), ispow2(x.x13, promises), ispow2(x.x14, promises), ispow2(x.x15, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2(byte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu8(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask8x32(ispow2(x.v16_0, promises), ispow2(x.v16_16, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(sbyte x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2(sbyte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask8x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2(sbyte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask8x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2(sbyte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask8x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2(sbyte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 8);
            }
            else
            {
                return new mask8x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2(sbyte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi8(x, promises.Promises(Promise.Positive), 16);
            }
            else
            {
                return new mask8x16(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises), ispow2(x.x8, promises), ispow2(x.x9, promises), ispow2(x.x10, promises), ispow2(x.x11, promises), ispow2(x.x12, promises), ispow2(x.x13, promises), ispow2(x.x14, promises), ispow2(x.x15, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2(sbyte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi8(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask8x32(ispow2(x.v16_0, promises), ispow2(x.v16_16, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ushort x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 ispow2(ushort2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask16x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2(ushort3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask16x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2(ushort4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask16x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2(ushort8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu16(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask16x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2(ushort16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu16(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask16x16(ispow2(x.v8_0, promises), ispow2(x.v8_8, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(short x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(short2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask16x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2(short3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask16x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2(short4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask16x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2(short8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi16(x, promises.Promises(Promise.Positive), 8);
            }
            else
            {
                return new mask16x8(ispow2(x.x0, promises), ispow2(x.x1, promises), ispow2(x.x2, promises), ispow2(x.x3, promises), ispow2(x.x4, promises), ispow2(x.x5, promises), ispow2(x.x6, promises), ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi16(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask16x16(ispow2(x.v8_0, promises), ispow2(x.v8_8, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(uint x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(uint2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask32x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2(uint3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask32x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2(uint4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu32(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask32x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2(uint8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu32(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask32x8(ispow2(x.v4_0, promises), ispow2(x.v4_4, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(int x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2(int2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 2);
            }
            else
            {
                return new mask32x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2(int3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask32x3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2(int4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi32(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask32x4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi32(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask32x8(ispow2(x.v4_0, promises), ispow2(x.v4_4, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(ulong x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.NonZero) || (x != 0)) & (bits_resetlowest(x) == 0);
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2(ulong2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epu64(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask64x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2(ulong3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu64(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask64x3(ispow2(x.xy, promises), ispow2(x.z, promises));
            }
        }

        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns <see langword="true"/> for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2(ulong4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epu64(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask64x4(ispow2(x.xy, promises), ispow2(x.zw, promises));
            }
        }


        /// <summary>       Checks if the input is a power of two. If <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/>.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results if <paramref name="x"/> is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(long x, Promise promises = Promise.Nothing)
        {
            return (promises.Promises(Promise.Positive) || (x > 0)) & (bits_resetlowest(x) == 0);
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2(long2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_epi64(x, promises.Promises(Promise.Positive));
            }
            else
            {
                return new mask64x2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi64(x, promises.Promises(Promise.Positive), 3);
            }
            else
            {
                return new mask64x3(ispow2(x.xy, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two. If a component of <paramref name="x"/> is less than or equal to zero, then this function returns <see langword="false"/> in that component.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Positive"/> flag set returns undefined results for any <paramref name="x"/> component that is less than or equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_epi64(x, promises.Promises(Promise.Positive), 4);
            }
            else
            {
                return new mask64x4(ispow2(x.xy, promises), ispow2(x.zw, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(quarter x, Promise promises = Promise.Nothing)
        {
            byte sign = (byte)(asbyte(x) >> 7);

            return tobool(andnot(tobyte(ispow2mag(x, promises)), sign));
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new bool8(ispow2(x.x0, promises), 
                                 ispow2(x.x1, promises), 
                                 ispow2(x.x2, promises), 
                                 ispow2(x.x3, promises), 
                                 ispow2(x.x4, promises), 
                                 ispow2(x.x5, promises), 
                                 ispow2(x.x6, promises), 
                                 ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 16);
            }
            else
            {
                return new bool16(ispow2(x.x0,  promises), 
                                  ispow2(x.x1,  promises), 
                                  ispow2(x.x2,  promises), 
                                  ispow2(x.x3,  promises), 
                                  ispow2(x.x4,  promises), 
                                  ispow2(x.x5,  promises), 
                                  ispow2(x.x6,  promises), 
                                  ispow2(x.x7,  promises), 
                                  ispow2(x.x8,  promises), 
                                  ispow2(x.x9,  promises), 
                                  ispow2(x.x10, promises), 
                                  ispow2(x.x11, promises), 
                                  ispow2(x.x12, promises), 
                                  ispow2(x.x13, promises), 
                                  ispow2(x.x14, promises), 
                                  ispow2(x.x15, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool32(ispow2(x.v16_0, promises), ispow2(x.v16_16, promises));
            }
        }
        

        /// <summary>       Checks if the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(half x, Promise promises = Promise.Nothing)
        {
            byte sign = (byte)(asushort(x) >> 15);

            return tobool(andnot(tobyte(ispow2mag(x, promises)), sign));
        }

        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 ispow2(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new bool8(ispow2(x.x0, promises), 
                                 ispow2(x.x1, promises), 
                                 ispow2(x.x2, promises), 
                                 ispow2(x.x3, promises), 
                                 ispow2(x.x4, promises), 
                                 ispow2(x.x5, promises), 
                                 ispow2(x.x6, promises), 
                                 ispow2(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool16(ispow2(x.v8_0, promises), ispow2(x.v8_8, promises));
            }
        }
        
        
        /// <summary>       Checks if the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(float x, Promise promises = Promise.Nothing)
        {
            byte sign = (byte)(asuint(x) >> 31);

            return tobool(andnot(tobyte(ispow2mag(x, promises)), sign));
        }

        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 ispow2(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2(x.x, promises), ispow2(x.y, promises), ispow2(x.z, promises), ispow2(x.w, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool8(ispow2(x.v4_0, promises), ispow2(x.v4_4, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(double x, Promise promises = Promise.Nothing)
        {
            byte sign = (byte)(asulong(x) >> 63);

            return tobool(andnot(tobyte(ispow2mag(x, promises)), sign));
        }

        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool2(ispow2(x.x, promises), ispow2(x.y, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2(x.xy, promises), ispow2(x.z, promises));
            }
        }
        
        /// <summary>       Checks if each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2(x.xy, promises), ispow2(x.zw, promises));
            }
        }

        
        /// <summary>       Checks if the input is a power of two, i.e. whether <paramref name="x"/> ∈ { 2ᵏ | k ∈ ℤ } = { …, 2⁻², 2⁻¹, 2⁰, 2¹, 2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2(quadruple x, Promise promises = Promise.Nothing)
        {
            byte sign = (byte)(asuint128(x) >> 127);

            return tobool(andnot(tobyte(ispow2mag(x, promises)), sign));
        }

        
        /// <summary>       Checks if the absolute value of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(Int128 x, Promise promises = Promise.Nothing)
        {
            bool nonZero = promises.Promises(Promise.NonZero) || (x != 0);
            
            bool pos = bits_resetlowest(x) == 0;
            bool neg = tzfill(x) == -1;
            
            return nonZero & (x < 0 ? neg : pos);
        }

        
        /// <summary>       Checks if the absolute value of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(sbyte x, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return ispow2((byte)abs(x), promises);
            }
            else
            {
                bool nonZero = promises.Promises(Promise.NonZero) || (x != 0);
                
                bool pos = bits_resetlowest(x) == 0;
                bool neg = tzfill(x) == -1;

                return nonZero & (x < 0 ? neg : pos);
            }
        }

        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2mag(sbyte2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi8(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask8x2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2mag(sbyte3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi8(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask8x3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2mag(sbyte4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi8(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask8x4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2mag(sbyte8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi8(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask8x8(ispow2mag(x.x0, promises), ispow2mag(x.x1, promises), ispow2mag(x.x2, promises), ispow2mag(x.x3, promises), ispow2mag(x.x4, promises), ispow2mag(x.x5, promises), ispow2mag(x.x6, promises), ispow2mag(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2mag(sbyte16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi8(x, promises.Promises(Promise.NonZero), 16);
            }
            else
            {
                return new mask8x16(ispow2mag(x.x0, promises), ispow2mag(x.x1, promises), ispow2mag(x.x2, promises), ispow2mag(x.x3, promises), ispow2mag(x.x4, promises), ispow2mag(x.x5, promises), ispow2mag(x.x6, promises), ispow2mag(x.x7, promises), ispow2mag(x.x8, promises), ispow2mag(x.x9, promises), ispow2mag(x.x10, promises), ispow2mag(x.x11, promises), ispow2mag(x.x12, promises), ispow2mag(x.x13, promises), ispow2mag(x.x14, promises), ispow2mag(x.x15, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2mag(sbyte32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_epi8(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask8x32(ispow2mag(x.v16_0, promises), ispow2mag(x.v16_16, promises));
            }
        }


        /// <summary>       Checks if the absolute value of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(short x, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return ispow2((ushort)abs(x), promises);
            }
            else
            {
                bool nonZero = promises.Promises(Promise.NonZero) || (x != 0);
                
                bool pos = bits_resetlowest(x) == 0;
                bool neg = tzfill(x) == -1;

                return nonZero & (x < 0 ? neg : pos);
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2mag(short2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi16(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask16x2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2mag(short3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi16(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask16x3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2mag(short4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi16(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask16x4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2mag(short8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi16(x, promises.Promises(Promise.NonZero), 8);
            }
            else
            {
                return new mask16x8(ispow2mag(x.x0, promises), ispow2mag(x.x1, promises), ispow2mag(x.x2, promises), ispow2mag(x.x3, promises), ispow2mag(x.x4, promises), ispow2mag(x.x5, promises), ispow2mag(x.x6, promises), ispow2mag(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2mag(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_epi16(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask16x16(ispow2mag(x.v8_0, promises), ispow2mag(x.v8_8, promises));
            }
        }

        
        /// <summary>       Checks if the absolute value of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(int x, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return ispow2((uint)abs(x), promises);
            }
            else
            {
                bool nonZero = promises.Promises(Promise.NonZero) || (x != 0);
                
                bool pos = bits_resetlowest(x) == 0;
                bool neg = tzfill(x) == -1;

                return nonZero & (x < 0 ? neg : pos);
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 ispow2mag(int2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi32(x, promises.Promises(Promise.NonZero), 2);
            }
            else
            {
                return new mask32x2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2mag(int3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi32(x, promises.Promises(Promise.NonZero), 3);
            }
            else
            {
                return new mask32x3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2mag(int4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi32(x, promises.Promises(Promise.NonZero), 4);
            }
            else
            {
                return new mask32x4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }

        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2mag(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_epi32(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask32x8(ispow2mag(x.v4_0, promises), ispow2mag(x.v4_4, promises));
            }
        }


        /// <summary>       Checks if the absolute value of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results if <paramref name="x"/> is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(long x, Promise promises = Promise.Nothing)
        {
            if (Bmi1.IsBmi1Supported)
            {
                return ispow2((ulong)abs(x), promises);
            }
            else
            {
                bool nonZero = promises.Promises(Promise.NonZero) || (x != 0);
                
                bool pos = bits_resetlowest(x) == 0;
                bool neg = tzfill(x) == -1;

                return nonZero & (x < 0 ? neg : pos);
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2mag(long2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_epi64(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask64x2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2mag(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_epi64(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask64x3(ispow2mag(x.xy, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set returns undefined results for any <paramref name="x"/> component that is equal to zero.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2mag(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_epi64(x, promises.Promises(Promise.NonZero));
            }
            else
            {
                return new mask64x4(ispow2mag(x.xy, promises), ispow2mag(x.zw, promises));
            }
        }

        
        /// <summary>       Checks if the absolute value of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(quarter x, Promise promises = Promise.Nothing)
        {
            byte MANTISSA_MASK = bitmask8(numBits: (uint)quarter.MANTISSA_BITS);
            byte EXPONENT_MASK = bitmask8(numBits: (uint)quarter.EXPONENT_BITS, index: quarter.MANTISSA_BITS);

            byte bits = asbyte(x);
            
            bool normalExponent = (bits & EXPONENT_MASK) != 0;
            normalExponent &= COMPILATION_OPTIONS.FLOAT_NO_INF 
                            ? true 
                            : (bits & EXPONENT_MASK) < quarter.SIGNALING_EXPONENT;

            bool normalPow2 = (bits & MANTISSA_MASK) == 0
                            & normalExponent;
            
            bool result = normalPow2;

            if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                bool subnormalPow2 = ispow2(bits & MANTISSA_MASK)
                                   & (bits & EXPONENT_MASK) == 0;

                result |= subnormalPow2;
            }

            return result;
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x2 ispow2mag(quarter2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 ispow2mag(quarter3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 ispow2mag(quarter4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x8 ispow2mag(quarter8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new bool8(ispow2mag(x.x0, promises), 
                                 ispow2mag(x.x1, promises), 
                                 ispow2mag(x.x2, promises), 
                                 ispow2mag(x.x3, promises), 
                                 ispow2mag(x.x4, promises), 
                                 ispow2mag(x.x5, promises), 
                                 ispow2mag(x.x6, promises), 
                                 ispow2mag(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x16 ispow2mag(quarter16 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 16);
            }
            else
            {
                return new bool16(ispow2mag(x.x0,  promises), 
                                  ispow2mag(x.x1,  promises), 
                                  ispow2mag(x.x2,  promises), 
                                  ispow2mag(x.x3,  promises), 
                                  ispow2mag(x.x4,  promises), 
                                  ispow2mag(x.x5,  promises), 
                                  ispow2mag(x.x6,  promises), 
                                  ispow2mag(x.x7,  promises), 
                                  ispow2mag(x.x8,  promises), 
                                  ispow2mag(x.x9,  promises), 
                                  ispow2mag(x.x10, promises), 
                                  ispow2mag(x.x11, promises), 
                                  ispow2mag(x.x12, promises), 
                                  ispow2mag(x.x13, promises), 
                                  ispow2mag(x.x14, promises), 
                                  ispow2mag(x.x15, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x32 ispow2mag(quarter32 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_pq(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool32(ispow2mag(x.v16_0, promises), ispow2mag(x.v16_16, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x2 ispow2mag(half2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 ispow2mag(half3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x4 ispow2mag(half4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x8 ispow2mag(half8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 8);
            }
            else
            {
                return new bool8(ispow2mag(x.x0, promises), 
                                 ispow2mag(x.x1, promises), 
                                 ispow2mag(x.x2, promises), 
                                 ispow2mag(x.x3, promises), 
                                 ispow2mag(x.x4, promises), 
                                 ispow2mag(x.x5, promises), 
                                 ispow2mag(x.x6, promises), 
                                 ispow2mag(x.x7, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x16 ispow2mag(half16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_ph(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool16(ispow2mag(x.v8_0, promises), ispow2mag(x.v8_8, promises));
            }
        }
        

        /// <summary>       Checks if the absolute value of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(half x, Promise promises = Promise.Nothing)
        {
            ushort MANTISSA_MASK = bitmask16(numBits: (uint)half.MANTISSA_BITS);
            ushort EXPONENT_MASK = bitmask16(numBits: (uint)half.EXPONENT_BITS, index: half.MANTISSA_BITS);

            ushort bits = asushort(x);
            
            bool normalExponent = (bits & EXPONENT_MASK) != 0;
            normalExponent &= COMPILATION_OPTIONS.FLOAT_NO_INF 
                            ? true 
                            : (bits & EXPONENT_MASK) < half.SIGNALING_EXPONENT;

            bool normalPow2 = (bits & MANTISSA_MASK) == 0
                            & normalExponent;
            
            bool result = normalPow2;

            if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                bool subnormalPow2 = ispow2(bits & MANTISSA_MASK, promises)
                                   & (bits & EXPONENT_MASK) == 0;

                result |= subnormalPow2;
            }

            return result;
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x2 ispow2mag(float2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 2);
            }
            else
            {
                return new bool2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x3 ispow2mag(float3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x4 ispow2mag(float4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2mag(x.x, promises), ispow2mag(x.y, promises), ispow2mag(x.z, promises), ispow2mag(x.w, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 ispow2mag(float8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_ps(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool8(ispow2mag(x.v4_0, promises), ispow2mag(x.v4_4, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(float x, Promise promises = Promise.Nothing)
        {
            uint MANTISSA_MASK = bitmask32(numBits: (uint)F32_MANTISSA_BITS);
            uint EXPONENT_MASK = bitmask32(numBits: (uint)F32_EXPONENT_BITS, index: F32_MANTISSA_BITS);

            uint bits = asuint(x);
            
            bool normalExponent = (bits & EXPONENT_MASK) != 0;
            normalExponent &= COMPILATION_OPTIONS.FLOAT_NO_INF 
                            ? true 
                            : (bits & EXPONENT_MASK) < F32_SIGNALING_EXPONENT;

            bool normalPow2 = (bits & MANTISSA_MASK) == 0
                            & normalExponent;
            
            bool result = normalPow2;

            if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                bool subnormalPow2 = ispow2(bits & MANTISSA_MASK, promises)
                                   & (bits & EXPONENT_MASK) == 0;

                result |= subnormalPow2;
            }

            return result;
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 ispow2mag(double2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.pow2mag_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero));
            }
            else
            {
                return new bool2(ispow2mag(x.x, promises), ispow2mag(x.y, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 ispow2mag(double3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 3);
            }
            else
            {
                return new bool3(ispow2mag(x.xy, promises), ispow2mag(x.z, promises));
            }
        }
        
        /// <summary>       Checks if the absolute value of each component of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 ispow2mag(double4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow2mag_pd(x, normal: promises.Promises(Promise.Unsafe0), nonZero: promises.Promises(Promise.NonZero), elements: 4);
            }
            else
            {
                return new bool4(ispow2mag(x.xy, promises), ispow2mag(x.zw, promises));
            }
        }

        
        /// <summary>       Checks if the absolute value of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(double x, Promise promises = Promise.Nothing)
        {
            ulong MANTISSA_MASK = bitmask64(numBits: (ulong)F64_MANTISSA_BITS);
            ulong EXPONENT_MASK = bitmask64(numBits: (ulong)F64_EXPONENT_BITS, index: F64_MANTISSA_BITS);

            ulong bits = asulong(x);

            bool normalExponent = (bits & EXPONENT_MASK) != 0;
            normalExponent &= COMPILATION_OPTIONS.FLOAT_NO_INF 
                            ? true 
                            : (bits & EXPONENT_MASK) < F64_SIGNALING_EXPONENT;

            bool normalPow2 = (bits & MANTISSA_MASK) == 0
                            & normalExponent;
            
            bool result = normalPow2;

            if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                bool subnormalPow2 = ispow2(bits & MANTISSA_MASK, promises)
                                   & (bits & EXPONENT_MASK) == 0;

                result |= subnormalPow2;
            }

            return result;
        }
        
        /// <summary>       Checks if the absolute value of the input is a power of two, i.e. whether <paramref name="x"/> ∈ { ±2ᵏ | k ∈ ℤ } = { …, ±2⁻², ±2⁻¹, ±2⁰, ±2¹, ±2², … }.
        /// <remarks>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.NonZero"/> flag set incorrectly returns <see langword="true"/> if <paramref name="x"/> is 0.       </para>
        /// <para>      A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set incorrectly returns <see langword="false"/> if <paramref name="x"/> is subnormal and a power of 2.       </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ispow2mag(quadruple x, Promise promises = Promise.Nothing)
        {
            UInt128 MANTISSA_MASK = bitmask128(numBits: (ulong)quadruple.MANTISSA_BITS);
            UInt128 EXPONENT_MASK = bitmask128(numBits: (ulong)quadruple.EXPONENT_BITS, index: quadruple.MANTISSA_BITS);

            UInt128 bits = asuint128(x);
            
            bool normalExponent = (bits & EXPONENT_MASK) != 0;
            normalExponent &= COMPILATION_OPTIONS.FLOAT_NO_INF 
                            ? true 
                            : (bits & EXPONENT_MASK) < quadruple.SIGNALING_EXPONENT;

            bool normalPow2 = (bits & MANTISSA_MASK) == 0
                            & normalExponent;
            
            bool result = normalPow2;

            if (!COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                bool subnormalPow2 = ispow2(bits & MANTISSA_MASK, promises)
                                   & (bits & EXPONENT_MASK) == 0;

                result |= subnormalPow2;
            }

            return result;
        }
    }
}