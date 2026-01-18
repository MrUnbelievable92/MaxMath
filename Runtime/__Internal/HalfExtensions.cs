using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    internal static class HalfExtensions
    {
        internal const bool IEEE_754_STANDARD = true;                                                                                  
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                                                                      
        internal const bool SIGNALING_NAN = false;                                                                                     
        internal const int BITS = 8 * sizeof(ushort);                                                                                  
        internal const int SET_SIGN_BIT = (SIGN_BIT ? 1 : 0) << (BITS - 1);                                                            
        internal const int EXPONENT_BITS = 5 + (SIGN_BIT ? 0 : 1);                                                                     
        internal const int MANTISSA_BITS = BITS - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);                                                  
        internal const int EXPONENT_BIAS = -((1 << (EXPONENT_BITS - 1)) - 1);                                                          
        internal const int MAX_UNBIASED_EXPONENT = -EXPONENT_BIAS;                                                                     
        internal const int MIN_UNBIASED_EXPONENT = EXPONENT_BIAS + 1;                                                                  
        internal const int SIGNALING_EXPONENT = (MAX_UNBIASED_EXPONENT - EXPONENT_BIAS + (IEEE_754_STANDARD ? 1 : 0)) << MANTISSA_BITS;

        internal const int F32_SHL_LOSE_SIGN       = F32_BITS - (MANTISSA_BITS + EXPONENT_BITS);
        internal const int F32_SHR_PLACE_MANTISSA  = MANTISSA_BITS + ((1 + F32_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const int F32_MAGIC               = (((1 << F32_EXPONENT_BITS) - 1) - (1 + -EXPONENT_BIAS)) << F32_MANTISSA_BITS;
        internal const uint DEPOSIT_MASK_32 = (1u << (F32_BITS - 1)) | (((1u << (BITS - 1)) - 1) << (F32_BITS - BITS - (F32_EXPONENT_BITS - EXPONENT_BITS)));

        internal const int  F64_SHL_LOSE_SIGN      = F64_BITS - (MANTISSA_BITS + EXPONENT_BITS);
        internal const int  F64_SHR_PLACE_MANTISSA = MANTISSA_BITS + ((1 + F64_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const long F64_MAGIC              = (((1L << F64_EXPONENT_BITS) - 1) - (1 + -EXPONENT_BIAS)) << F64_MANTISSA_BITS;
        internal const ulong DEPOSIT_MASK_64 = (1ul << (F64_BITS - 1)) | (((1ul << (BITS - 1)) - 1) << (F64_BITS - BITS - (F64_EXPONENT_BITS - EXPONENT_BITS)));


        internal static half Epsilon => ashalf((ushort)1);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromByte(byte b, bool nonZero = false)
        {
            int lz = math.lzcnt((uint)b);
            int mantissaShift = lz - 21;

            return ashalf((ushort)(((((!nonZero && b == 0) ? 32 : 45) - lz) << 10) + (b << mantissaShift)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromSByte(sbyte b, bool nonZero = false, bool nonNegative = false)
        {
            if (nonNegative
             || constexpr.IS_TRUE(b >= 0))
            {
                return FromByte((byte)b, nonZero: nonZero);
            }

            half absCast = FromByte((byte)abs(b), nonZero: nonZero);
            uint sign = ((uint)(byte)b >> 7) << 15;

            return ashalf((ushort)(absCast.value ^ sign));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromUShort(ushort b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false)
        {
            return FromUInt(b, overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromShort(short b, bool nonZero = false, bool absBelow2pow11 = false, bool nonNegative = false)
        {
            return FromInt(b, (half)float.PositiveInfinity, inRange: true, nonZero: nonZero, absBelow2pow11: absBelow2pow11, nonNegative: nonNegative);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromUInt(uint b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;

            int lz = math.lzcnt(b); 
            int mantissaShift = lz - 21;

            uint exp = (inRange || b <= (uint)Unity.Mathematics.half.MaxValue) ? (((!nonZero && b == 0) ? 32u : 45u) - (uint)lz) << 10
                                                                               : (uint)(asushort(overflowValue) & bitmask32(EXPONENT_BITS, MANTISSA_BITS));

            uint mantissa = (absBelow2pow11 || b < (1 << 11)) ? (b << mantissaShift) 
                                                              : (inRange || b <= (uint)Unity.Mathematics.half.MaxValue) ? (b >> -mantissaShift)
                                                                                                                        : (uint)(asushort(overflowValue) & bitmask32(MANTISSA_BITS));
            return ashalf((ushort)(exp + mantissa));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromInt(int b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false, bool nonNegative = false)
        {
            if (nonNegative
             || constexpr.IS_TRUE(b >= 0))
            {
                return FromUInt((uint)b, overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            }

            half absCast = FromUInt((uint)math.abs(b), overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            uint sign = ((uint)b >> 31) << 15;

            return ashalf((ushort)(absCast.value ^ sign));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromULong(ulong b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;

            int lz = math.lzcnt(b); 
            int mantissaShift = lz - 53;

            uint exp = (inRange || b <= (ulong)Unity.Mathematics.half.MaxValue) ? (((!nonZero && b == 0) ? 64u : 77u) - (uint)lz) << 10
                                                                                : (uint)(asushort(overflowValue) & bitmask32(EXPONENT_BITS, MANTISSA_BITS));

            uint mantissa = (absBelow2pow11 || b < (1 << 11)) ? (uint)(b << mantissaShift) 
                                                              : (inRange || b <= (ulong)Unity.Mathematics.half.MaxValue) ? (uint)(b >> -mantissaShift)
                                                                                                                      : (uint)(asushort(overflowValue) & bitmask32(MANTISSA_BITS));
            return ashalf((ushort)(exp + mantissa));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromLong(long b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false, bool nonNegative = false)
        {
            if (nonNegative
             || constexpr.IS_TRUE(b >= 0))
            {
                return FromULong((ulong)b, overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            }

            half absCast = FromULong((ulong)math.abs(b), overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            ulong sign = ((ulong)b >> 63) << 15;

            return ashalf((ushort)(absCast.value ^ sign));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromUInt128(UInt128 value, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false)
        {
            bool overflow = !inRange && !absBelow2pow11 && value.hi64 != 0;

            return overflow ? overflowValue : FromULong(value.lo64, overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromInt128(Int128 value, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false, bool nonNegative = false)
        {
            if (nonNegative
             || constexpr.IS_TRUE(value >= 0))
            {
                return FromUInt128((UInt128)value, overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            }
            else
            {
                bool overflowHi64 = value.hi64 + 1 > 1; // any other value than -1 or 0

                return overflowHi64 ? ashalf((ushort)(overflowValue.value | ((value.hi64 >> 63) << 15)))
                                    : FromLong((long)value.lo64, overflowValue, inRange, nonZero, absBelow2pow11, nonNegative);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromFloat(float f, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
        {
            FloatingPointPromise<float> promise = new FloatingPointPromise<float>(f);
            promiseInRange |= promise.NotInf && promise.NotNaN && (promise.MinPossible >= Unity.Mathematics.half.MinValue && promise.MaxPossible <= Unity.Mathematics.half.MaxValue);
            promiseAbs |= promise.ZeroOrGreater;
            
            const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + EXPONENT_BIAS;

            uint exp = asuint(f) & F32_SIGNALING_EXPONENT;
            bool noUnderflow = exp >= (EXPONENT_OFFSET - MANTISSA_BITS) << F32_MANTISSA_BITS;
            bool denormalF8 = !promiseNotSubnormal && exp <= (uint)EXPONENT_OFFSET << F32_MANTISSA_BITS;

            if (promiseInRange && promiseNotSubnormal)
            {
                float inRange = f * (1f / asfloat(F32_MAGIC));
            
                uint result;
                if (promiseAbs)
                {
                    uint q = asuint(inRange) >> (F32_MANTISSA_BITS - MANTISSA_BITS);
            
                    result = q;
                }
                else
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = bits_extractparallel(asuint(inRange), DEPOSIT_MASK_32);
                            goto ROUND;
                        }
                    }

                    uint q = asuint(inRange) >> (F32_MANTISSA_BITS - MANTISSA_BITS);
                    uint f16_sign = asuint(f) >> (F32_BITS - 1);
            
                    f16_sign <<= (BITS - 1);
            
                    result = q ^ f16_sign;
                }
                
            ROUND:
                ushort round = tobyte((asuint(f) & bitmask32((uint)(F32_MANTISSA_BITS - MANTISSA_BITS))) > (1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)));
                result += round;
                return ashalf((ushort)result);
            }

            int sign = promiseAbs ? 0 : (asint(f) >> (F32_BITS - 1)) << (BITS - 1);
            uint frac = asuint(f) & bitmask32((uint)F32_MANTISSA_BITS);

            bool overflow = !promiseInRange && asuint(abs(f)) >= ((bitmask32((uint)MANTISSA_BITS + 1) << (F32_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F32_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask32((uint)F32_EXPONENT_BITS)) << F32_MANTISSA_BITS));

            exp -= EXPONENT_OFFSET << F32_MANTISSA_BITS;
            ushort frac16;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - (int)abs((int)exp >> F32_MANTISSA_BITS);
                frac16 = (ushort)(tobyte(noUnderflow) << bitIndex);
                frac16 |= (ushort)((frac & (uint)-(int)tobyte(noUnderflow)) >> (F32_MANTISSA_BITS - bitIndex));
                
                uint round = ((uint)bitIndex >> 31) | tobyte((asuint(f) & (1 << (F32_MANTISSA_BITS - 1 - bitIndex))) != 0);
                frac16 += (ushort)(round & (uint)-(int)tobyte(noUnderflow));

                return ashalf((ushort)(sign | frac16));
            }
            else
            {
                if (overflow)
                {
                    return ashalf((ushort)(sign | SIGNALING_EXPONENT | tobyte(isnan(f))));
                }
                else
                {
                    frac16 = (ushort)(frac >> (F32_MANTISSA_BITS - MANTISSA_BITS));
                    frac16 |= (ushort)(exp >> (F32_MANTISSA_BITS - MANTISSA_BITS));

                    ushort round = tobyte((asuint(f) & bitmask32((uint)(F32_MANTISSA_BITS - MANTISSA_BITS))) > (1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)));
                    frac16 += (ushort)(sign | round);

                    return ashalf(frac16);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromDouble(double d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
        {
            FloatingPointPromise<double> promise = new FloatingPointPromise<double>(d);
            promiseInRange |= promise.NotInf && promise.NotNaN && (promise.MinPossible >= Unity.Mathematics.half.MinValue && promise.MaxPossible <= Unity.Mathematics.half.MaxValue);
            promiseAbs |= promise.ZeroOrGreater;

            const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + EXPONENT_BIAS;
            
            ulong exp = asulong(d) & F64_SIGNALING_EXPONENT;
            bool noUnderflow = exp >= (ulong)(EXPONENT_OFFSET - MANTISSA_BITS) << F64_MANTISSA_BITS;
            
            if (promiseInRange && promiseNotSubnormal)
            {
                double inRange = d * (1d / asdouble(F64_MAGIC));

                ulong result;
                if (promiseAbs)
                {
                    ulong q = asulong(inRange) >> (F64_MANTISSA_BITS - MANTISSA_BITS);
            
                    result = q;
                }
                else
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = bits_extractparallel(asulong(inRange), DEPOSIT_MASK_64);
                            goto ROUND;
                        }
                    }

                    ulong q = asulong(inRange) >> (F64_MANTISSA_BITS - MANTISSA_BITS);
                    ulong f16_sign = asulong(d) >> (F64_BITS - 1);
                    
                    f16_sign <<= (BITS - 1);
                    
                    result = q ^ f16_sign;
                }
                
            ROUND:
                ushort round = tobyte((asulong(d) & bitmask64((ulong)(F64_MANTISSA_BITS - MANTISSA_BITS))) > (1ul << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)));
                result += round;
                return ashalf((ushort)result);
            }

            long sign = promiseAbs ? 0 : (aslong(d) >> (F64_BITS - 1)) << (BITS - 1);
            ulong frac = asulong(d) & bitmask64((ulong)F64_MANTISSA_BITS);
            
            bool denormalF8 = !promiseNotSubnormal && exp <= (ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS;
            bool overflow = !promiseInRange && asulong(abs(d)) >= ((bitmask64((ulong)MANTISSA_BITS + 1) << (F64_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F64_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask64((ulong)F64_EXPONENT_BITS)) << F64_MANTISSA_BITS));
            
            exp -= EXPONENT_OFFSET << F64_MANTISSA_BITS;
            ushort frac16;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - (int)abs((long)exp >> F64_MANTISSA_BITS);
                frac16 = (ushort)(tobyte(noUnderflow) << bitIndex);
                frac16 |= (ushort)((frac & (ulong)-(long)tobyte(noUnderflow)) >> (F64_MANTISSA_BITS - bitIndex));
                
                ulong round = ((ulong)bitIndex >> 63) | tobyte((asulong(d) & (1ul << (F64_MANTISSA_BITS - 1 - bitIndex))) != 0);
                frac16 += (ushort)(round & (ulong)-(long)tobyte(noUnderflow));

                return ashalf((ushort)(sign | frac16));
            }
            else
            {
                if (overflow)
                {
                    return ashalf((ushort)(sign | SIGNALING_EXPONENT | tobyte(isnan(d))));
                }
                else
                {
                    frac16 = (ushort)(frac >> (F64_MANTISSA_BITS - MANTISSA_BITS));
                    frac16 |= (ushort)(exp >> (F64_MANTISSA_BITS - MANTISSA_BITS));

                    ushort round = tobyte((asulong(d) & bitmask64((ulong)(F64_MANTISSA_BITS - MANTISSA_BITS))) > (1ul << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)));
                    frac16 += (ushort)(sign | round);

                    return ashalf(frac16);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float ToFloat(half h, bool inRange = false, bool abs = false)
        {
            FloatingPointPromise<half> promise = new FloatingPointPromise<half>(h);
            inRange |= promise.NotNaN && promise.NotInf;
            abs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? promise.Positive : promise.ZeroOrGreater;
            
            float f;
            uint fusedExponentMantissa;

            if (abs)
            {
                fusedExponentMantissa = (uint)h.value << (F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                f = asfloat(F32_MAGIC) * asfloat(fusedExponentMantissa);
            }
            else
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        uint aligned = bits_depositparallel(h.value, DEPOSIT_MASK_32);
                        f = asfloat(F32_MAGIC) * asfloat(aligned);

                        goto NAN_INF_CHECK;
                    }
                }
                
                fusedExponentMantissa = ((uint)h.value << F32_SHL_LOSE_SIGN) >> F32_SHR_PLACE_MANTISSA;
                f = asfloat((short)h.value < 0 ? F32_MAGIC ^ (1 << (F32_BITS - 1)) : F32_MAGIC) * asfloat(fusedExponentMantissa);
            }
            
        NAN_INF_CHECK:

            if (!inRange)
            {
                if (Hint.Unlikely((h.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT))
                {
                    if (Sse2.IsSse2Supported)
                    {
                        f = Sse.or_ps(Sse.set_ss(f), Sse2.cvtsi32_si128(F32_SIGNALING_EXPONENT)).Float0;
                    }
                    else
                    {
                        f = asfloat(asuint(f) | F32_SIGNALING_EXPONENT);
                    }
                }
            }
            
            return f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double ToDouble(half h, bool inRange = false, bool abs = false)
        {
            FloatingPointPromise<half> promise = new FloatingPointPromise<half>(h);
            inRange |= promise.NotNaN && promise.NotInf;
            abs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? promise.Positive : promise.ZeroOrGreater;
            
            double d;
            ulong fusedExponentMantissa;

            if (abs)
            {
                fusedExponentMantissa = (ulong)h.value << (F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                d = asdouble(F64_MAGIC) * asdouble(fusedExponentMantissa);
            }
            else
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        ulong aligned = bits_depositparallel(h.value, DEPOSIT_MASK_64);
                        d = asdouble(F64_MAGIC) * asdouble(aligned);

                        goto NAN_INF_CHECK;
                    }
                }
                
                fusedExponentMantissa = ((ulong)h.value << F64_SHL_LOSE_SIGN) >> F64_SHR_PLACE_MANTISSA;
                d = asdouble((short)h.value < 0 ? F64_MAGIC ^ (1ul << (F64_BITS - 1)) : F64_MAGIC) * asdouble(fusedExponentMantissa);
            }
            
        NAN_INF_CHECK:
            
            if (!inRange)
            {
                if (Hint.Unlikely((h.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT))
                {
                    if (Sse2.IsSse2Supported)
                    {
                        d = Sse2.or_pd(Sse2.set_sd(d), Sse2.cvtsi64x_si128(F64_SIGNALING_EXPONENT)).Double0;
                    }
                    else
                    {
                        d = asdouble(asulong(d) | F64_SIGNALING_EXPONENT);
                    }
                }
            }
            
            return d;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZero(this half h)
        {
            return (h.value & 0x7FFFu) == 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotZero(this half h)
        {
            return (h.value & 0x7FFFu) != 0u;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsZero(rhs);
            }
            else if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsZero(lhs);
            }

            bool value = lhs.value == rhs.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool zero = IsZero(lhs) & IsZero(rhs);

                    return zero | value;
                }
            }
            else
            {
                bool nan = !isnan(lhs) & !isnan(rhs);

                if (neitherZero)
                {
                    return nan & value;
                }
                else
                {
                    bool zero = IsZero(lhs) & IsZero(rhs);

                    return nan & (zero | value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                return IsNotZero(rhs);
            }
            else if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                return IsNotZero(lhs);
            }

            bool value = lhs.value != rhs.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool notBothZero = IsNotZero(ashalf((ushort)(lhs.value | rhs.value)));

                    return value & notBothZero;
                }
            }
            else
            {
                bool nan = isnan(lhs) | isnan(rhs);

                if (neitherZero)
                {
                    return nan | value;
                }
                else
                {
                    bool notBothZero = IsNotZero(ashalf((ushort)(lhs.value | rhs.value)));

                    return nan | (value & notBothZero);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThan(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                bool negative = lhs.value > 0x7FFF;
                bool notZero = (lhs.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return notZero & negative;
                }
                else
                {
                    return !isnan(lhs) & (notZero & negative);
                }
            }
            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                bool positive = rhs.value < 0x8000;
                bool notZero = (rhs.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return positive & notZero;
                }
                else
                {
                    return !isnan(rhs) & (positive & notZero);
                }
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool equalSigns = signA == signB;
            bool differentValues = lhs.value != rhs.value;

            bool ifEqualSigns = differentValues & (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool notBothZero = (ushort)((lhs.value | rhs.value) << 1) != 0;

                ifOppositeSigns &= notBothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(lhs) & !isnan(rhs);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThanOrEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(lhs)) && constexpr.IS_TRUE(!isnan(rhs));
            neitherZero |= constexpr.IS_TRUE(IsNotZero(lhs)) && constexpr.IS_TRUE(IsNotZero(rhs));

            if (constexpr.IS_TRUE(IsZero(rhs)))
            {
                bool intLEzero = 1 > (short)lhs.value;

                if (neitherNaN)
                {
                    return intLEzero;
                }
                else
                {
                    return !isnan(lhs) & intLEzero;
                }
            }
            if (constexpr.IS_TRUE(IsZero(lhs)))
            {
                bool uintGEzero = (short)rhs.value > 0;
                bool negativeZero = rhs.value == 0x8000;

                if (neitherNaN)
                {
                    return uintGEzero | negativeZero;
                }
                else
                {
                    return !isnan(rhs) & (uintGEzero | negativeZero);
                }
            }


            int signA = lhs.value >> 15;
            int signB = rhs.value >> 15;

            bool equalSigns = signA == signB;
            bool equalValues = lhs.value == rhs.value;

            bool ifEqualSigns = equalValues | (tobool(signA) ^ (rhs.value > lhs.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool bothZero = (ushort)((lhs.value | rhs.value) << 1) == 0;

                ifOppositeSigns |= bothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(lhs) & !isnan(rhs);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThan(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            return rhs.IsLessThan(lhs, neitherNaN, neitherZero);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThanOrEqualTo(this half lhs, half rhs, bool neitherNaN = false, bool neitherZero = false)
        {
            return rhs.IsLessThanOrEqualTo(lhs, neitherNaN, neitherZero);
        }
    }
}