using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       A 16-bit 1.5.10.-15 IEEE 754 floating point number.       </summary>
    [Serializable]
    unsafe public struct half : IEquatable<half>, IComparable<half>, IComparable, IFormattable, IConvertible
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
        
        
        [Obsolete("Zero is already defined. This property will be removed in a subsequent release.")]
        public static half zero => new half();
        
        [Obsolete("MaxValue is already a MaxMath.half. This property will be removed in a subsequent release.")]
        public static half MaxValueAsHalf => new half(MaxValue);

        [Obsolete("MinValue is already a MaxMath.half. This property will be removed in a subsequent release.")]
        public static half MinValueAsHalf => new half(MinValue);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(bool x)
        {
            this = x ? (half)1f : (half)0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(byte x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(sbyte x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(ushort x)
        {
            this = (half)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(short x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(uint f)
        {
            this = (half)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(int f)
        {
            this = (half)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(ulong d)
        {
            this = (half)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(long d)
        {
            this = (half)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(UInt128 d)
        {
            this = (half)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(Int128 d)
        {
            this = (half)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(quarter x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(half x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(float f)
        {
            this = (half)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(double d)
        {
            this = (half)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public half(quadruple d)
        {
            this = (half)d;
        }


        public ushort value;
        

        /// <summary>       65504.0 as a <see cref="float"/>.      </summary>
        public static half Epsilon => ashalf((ushort)1);

        /// <summary>       65504.0 as a <see cref="float"/>.      </summary>
        public static half MaxValue => ashalf((ushort)(SIGNALING_EXPONENT - 1));

        /// <summary>       -65504.0 as a <see cref="float"/>.      </summary>
        public static half MinValue => -MaxValue;
        public static half Zero => ashalf((ushort)0);
        public static half NaN => ashalf((ushort)(SIGNALING_EXPONENT | 1));
        public static half PositiveInfinity => ashalf((ushort)SIGNALING_EXPONENT);
        public static half NegativeInfinity => -PositiveInfinity;

        
        internal readonly bool IsZero => (value & 0x7FFFu) == 0;
        internal readonly bool IsNotZero => (value & 0x7FFFu) != 0;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(bool q) => q ? (half)1 : (half)0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool(half q) => andnot(q != 0, isnan(q));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(half q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(half q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(half q) => (bool)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromByte(byte b, bool nonZero = false)
        {
            int lz = lzcnt((uint)b);
            int mantissaShift = lz - 21;

            return ashalf((ushort)(((((!nonZero && b == 0) ? 32 : 45) - lz) << MANTISSA_BITS) + (b << mantissaShift)));
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

            int lz = lzcnt(b); 
            int mantissaShift = lz - 21;

            uint exp = (inRange || b <= (uint)MaxValue) ? (((!nonZero && b == 0) ? 32u : 45u) - (uint)lz) << MANTISSA_BITS
                                                        : (uint)(asushort(overflowValue) & bitmask32(EXPONENT_BITS, MANTISSA_BITS));
            uint mantissa = (absBelow2pow11 || b < (1 << 11)) ? (b << mantissaShift) 
                                                              : (inRange || b <= (uint)MaxValue) ? (b >> -mantissaShift) + tobyte((b & bitmask32(-mantissaShift)) > 1 << ~mantissaShift)
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

            half absCast = FromUInt((uint)abs(b), overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
            uint sign = ((uint)b >> 31) << 15;

            return ashalf((ushort)(absCast.value ^ sign));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half FromULong(ulong b, half overflowValue, bool inRange = false, bool nonZero = false, bool absBelow2pow11 = false)
        {
            inRange |= absBelow2pow11;

            int lz = lzcnt(b); 
            int mantissaShift = lz - 53;

            uint exp = (inRange || b <= (ulong)MaxValue) ? (((!nonZero && b == 0) ? 64u : 77u) - (uint)lz) << MANTISSA_BITS
                                                         : (uint)(asushort(overflowValue) & bitmask32(EXPONENT_BITS, MANTISSA_BITS));

            uint mantissa = (absBelow2pow11 || b < (1 << 11)) ? (uint)(b << mantissaShift) 
                                                              : (inRange || b <= (ulong)MaxValue) ? (uint)(b >> -mantissaShift) + tobyte((b & bitmask64((ulong)-mantissaShift)) > 1ul << ~mantissaShift)
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

            half absCast = FromULong((ulong)abs(b), overflowValue, inRange: inRange, nonZero: nonZero, absBelow2pow11: absBelow2pow11);
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
            if (BurstArchitecture.IsF16Supported)
            {
                return new half { value = Xse.cvtps_ph(Xse.set_ss(f)).UShort0 }; 
            }

            FloatingPointPromise<float> promise = new FloatingPointPromise<float>(f);
            promiseInRange |= promise.NotInf && promise.NotNaN && (promise.MinPossible >= MinValue && promise.MaxPossible <= MaxValue);
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
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return (half)(float)d;
                }
            }

            FloatingPointPromise<double> promise = new FloatingPointPromise<double>(d);
            promiseInRange |= promise.NotInf && promise.NotNaN && (promise.MinPossible >= MinValue && promise.MaxPossible <= MaxValue);
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
            if (BurstArchitecture.IsF16Supported)
            {
                return Xse.cvtph_ps(Xse.cvtsi32_si128(h.value)).Float0;
            }

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
            if (BurstArchitecture.IsF16Supported)
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    return (float)h;
                }
            }

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
        public static implicit operator half(Unity.Mathematics.half h)
        {
            return new half { value = h.value };
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half(half h)
        {
            return new Unity.Mathematics.half { value = h.value };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(float f)
        {
            return FromFloat(f);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(double d)
        {
            return FromDouble(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(decimal d)
        {
            return (half)(double)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half(byte b)
        {
            return FromByte(b);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(ushort us)
        {
            return FromUShort(us, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(uint ui)
        {
            return FromUInt(ui, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(ulong ul)
        {
            return FromULong(ul, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(UInt128 ull)
        {
            return FromUInt128(ull, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator half(sbyte sb)
        {
            return FromSByte(sb);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half(short s)
        {
            return FromShort(s);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(int i)
        {
            return FromInt(i, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(long l)
        {
            return FromLong(l, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(Int128 ll)
        {
            return FromInt128(ll, MaxMath.half.PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(half q)
        {
            return ToFloat(q, false, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(half q)
        {
            return ToDouble(q, false, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator decimal(half q)
        {
            return (decimal)(float)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte(half q)
        {
            return (byte)math.BASE_cvtf16i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(half q)
        {
            return (ushort)math.BASE_cvtf16i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(half q)
        {
            return math.BASE_cvtf16i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(half q)
        {
            return math.BASE_cvtf16i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(half q)
        {
            return math.BASE_cvtf16i32(q, signed: false, trunc: true);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(half q)
        {
            return (sbyte)math.BASE_cvtf16i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(half q)
        {
            return (short)math.BASE_cvtf16i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(half q)
        {
            return (int)math.BASE_cvtf16i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(half q)
        {
            return (int)math.BASE_cvtf16i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(half q)
        {
            return (int)math.BASE_cvtf16i32(q, signed: true, trunc: true);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half2(half q) => (half2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(half q) => (half3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(half q) => (half4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(half q) => (float2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(half q) => (float3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(half q) => (float4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(half q) => (double2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(half q) => (double3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(half q) => (double4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(half q) => (uint2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(half q) => (uint3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(half q) => (uint4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(half q) => (int2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(half q) => (int3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(half q) => (int4)q;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsEqualTo(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(IsZero))
            {
                return other.IsZero;
            }
            else if (constexpr.IS_TRUE(other.IsZero))
            {
                return IsZero;
            }

            bool value = this.value == other.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool zero = IsZero & other.IsZero;

                    return zero | value;
                }
            }
            else
            {
                bool nan = !isnan(this) & !isnan(other);

                if (neitherZero)
                {
                    return nan & value;
                }
                else
                {
                    bool zero = IsZero & other.IsZero;

                    return nan & (zero | value);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsNotEqualTo(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(IsZero))
            {
                return other.IsNotZero;
            }
            else if (constexpr.IS_TRUE(other.IsZero))
            {
                return IsNotZero;
            }

            bool value = this.value != other.value;

            if (neitherNaN)
            {
                if (neitherZero)
                {
                    return value;
                }
                else
                {
                    bool notBothZero = ashalf((ushort)(this.value | other.value)).IsNotZero;

                    return value & notBothZero;
                }
            }
            else
            {
                bool nan = isnan(this) | isnan(other);

                if (neitherZero)
                {
                    return nan | value;
                }
                else
                {
                    bool notBothZero = ashalf((ushort)(this.value | other.value)).IsNotZero;

                    return nan | (value & notBothZero);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsLessThan(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(other.IsZero))
            {
                bool negative = this.value > 0x7FFF;
                bool notZero = (this.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return notZero & negative;
                }
                else
                {
                    return !isnan(this) & (notZero & negative);
                }
            }
            if (constexpr.IS_TRUE(IsZero))
            {
                bool positive = other.value < 0x8000;
                bool notZero = (other.value & 0x7FFF) != 0;

                if (neitherNaN)
                {
                    return positive & notZero;
                }
                else
                {
                    return !isnan(other) & (positive & notZero);
                }
            }


            int signA = this.value >> 15;
            int signB = other.value >> 15;

            bool equalSigns = signA == signB;
            bool differentValues = this.value != other.value;

            bool ifEqualSigns = differentValues & (tobool(signA) ^ (other.value > this.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool notBothZero = (ushort)((this.value | other.value) << 1) != 0;

                ifOppositeSigns &= notBothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(this) & !isnan(other);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsLessThanOrEqualTo(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(other.IsZero))
            {
                bool intLEzero = 1 > (short)this.value;

                if (neitherNaN)
                {
                    return intLEzero;
                }
                else
                {
                    return !isnan(this) & intLEzero;
                }
            }
            if (constexpr.IS_TRUE(IsZero))
            {
                bool uintGEzero = (short)other.value > 0;
                bool negativeZero = other.value == 0x8000;

                if (neitherNaN)
                {
                    return uintGEzero | negativeZero;
                }
                else
                {
                    return !isnan(other) & (uintGEzero | negativeZero);
                }
            }


            int signA = this.value >> 15;
            int signB = other.value >> 15;

            bool equalSigns = signA == signB;
            bool equalValues = this.value == other.value;

            bool ifEqualSigns = equalValues | (tobool(signA) ^ (other.value > this.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool bothZero = (ushort)((this.value | other.value) << 1) == 0;

                ifOppositeSigns |= bothZero;
            }

            if (neitherNaN)
            {
                return equalSigns ? ifEqualSigns : ifOppositeSigns;
            }
            else
            {
                bool notNaN = !isnan(this) & !isnan(other);

                return notNaN & (equalSigns ? ifEqualSigns : ifOppositeSigns);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsGreaterThan(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            return other.IsLessThan(this, neitherNaN, neitherZero);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly bool IsGreaterThanOrEqualTo(half other, bool neitherNaN = false, bool neitherZero = false)
        {
            return other.IsLessThanOrEqualTo(this, neitherNaN, neitherZero);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half operator + (half value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half operator - (half value)
        {
            return ashalf((ushort)(value.value ^ 0x8000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (float left, half right)
        {
            return left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, float right)
        {
            return (float)left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (double left, half right)
        {
            return left + (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (half left, double right)
        {
            return (double)left + right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (float left, half right)
        {
            return left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, float right)
        {
            return (float)left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (double left, half right)
        {
            return left - (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (half left, double right)
        {
            return (double)left - right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (float left, half right)
        {
            return left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, float right)
        {
            return (float)left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (double left, half right)
        {
            return left * (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (half left, double right)
        {
            return (double)left * right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (float left, half right)
        {
            return left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, float right)
        {
            return (float)left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (double left, half right)
        {
            return left / (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (half left, double right)
        {
            return (double)left / right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (float left, half right)
        {
            return left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, float right)
        {
            return (float)left % right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (double left, half right)
        {
            return left % (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (half left, double right)
        {
            return (double)left % right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (byte left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, byte right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (ushort left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, ushort right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (uint left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, uint right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (ulong left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, ulong right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (UInt128 left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, UInt128 right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (sbyte left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, sbyte right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (short left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, short right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (int left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, int right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (long left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, long right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (Int128 left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, Int128 right)
        {
            return (float)left + (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (byte left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, byte right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (ushort left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, ushort right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (uint left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, uint right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (ulong left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, ulong right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (UInt128 left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, UInt128 right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (sbyte left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, sbyte right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (short left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, short right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (int left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, int right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (long left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, long right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (Int128 left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, Int128 right)
        {
            return (float)left - (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (byte left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, byte right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (ushort left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, ushort right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (uint left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, uint right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (ulong left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, ulong right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (UInt128 left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, UInt128 right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (sbyte left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, sbyte right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (short left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, short right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (int left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, int right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (long left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, long right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (Int128 left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, Int128 right)
        {
            return (float)left * (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (byte left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, byte right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (ushort left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, ushort right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (uint left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, uint right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (ulong left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, ulong right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (UInt128 left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, UInt128 right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (sbyte left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, sbyte right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (short left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, short right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (int left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, int right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (long left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, long right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (Int128 left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, Int128 right)
        {
            return (float)left / (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (byte left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, byte right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (ushort left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, ushort right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (uint left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, uint right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (ulong left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, ulong right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (UInt128 left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, UInt128 right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (sbyte left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, sbyte right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (short left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, short right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (int left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, int right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (long left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, long right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (Int128 left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, Int128 right)
        {
            return (float)left % (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half lhs, Unity.Mathematics.half rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half lhs, Unity.Mathematics.half rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half lhs, Unity.Mathematics.half rhs) => (float)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half lhs, Unity.Mathematics.half rhs) => (float)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half lhs, Unity.Mathematics.half rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (Unity.Mathematics.half lhs, half rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (Unity.Mathematics.half lhs, half rhs) => lhs - (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (Unity.Mathematics.half lhs, half rhs) => lhs * (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (Unity.Mathematics.half lhs, half rhs) => lhs / (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (Unity.Mathematics.half lhs, half rhs) => lhs % (float)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half lhs, Unity.Mathematics.half2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half lhs, Unity.Mathematics.half2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half lhs, Unity.Mathematics.half2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half lhs, Unity.Mathematics.half2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half lhs, Unity.Mathematics.half2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.half2 lhs, half rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.half2 lhs, half rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.half2 lhs, half rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.half2 lhs, half rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.half2 lhs, half rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half lhs, Unity.Mathematics.half3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half lhs, Unity.Mathematics.half3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half lhs, Unity.Mathematics.half3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half lhs, Unity.Mathematics.half3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half lhs, Unity.Mathematics.half3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.half3 lhs, half rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.half3 lhs, half rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.half3 lhs, half rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.half3 lhs, half rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.half3 lhs, half rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half lhs, Unity.Mathematics.half4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half lhs, Unity.Mathematics.half4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half lhs, Unity.Mathematics.half4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half lhs, Unity.Mathematics.half4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half lhs, Unity.Mathematics.half4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.half4 lhs, half rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.half4 lhs, half rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.half4 lhs, half rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.half4 lhs, half rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.half4 lhs, half rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, half rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, half rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, half rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, half rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, half rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, half rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, half rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, half rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, half rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, half rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 lhs, half rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 lhs, half rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 lhs, half rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 lhs, half rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 lhs, half rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, half rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, half rhs) => lhs - (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, half rhs) => lhs * (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, half rhs) => lhs / (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, half rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, half rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, half rhs) => lhs - (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, half rhs) => lhs * (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, half rhs) => lhs / (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, half rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 lhs, half rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 lhs, half rhs) => lhs - (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 lhs, half rhs) => lhs * (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 lhs, half rhs) => lhs / (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 lhs, half rhs) => lhs % (double4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.int2 lhs, half rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.int2 lhs, half rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.int2 lhs, half rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.int2 lhs, half rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.int2 lhs, half rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half lhs, Unity.Mathematics.int2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half lhs, Unity.Mathematics.int2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half lhs, Unity.Mathematics.int2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half lhs, Unity.Mathematics.int2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half lhs, Unity.Mathematics.int2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.int3 lhs, half rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.int3 lhs, half rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.int3 lhs, half rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.int3 lhs, half rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.int3 lhs, half rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half lhs, Unity.Mathematics.int3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half lhs, Unity.Mathematics.int3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half lhs, Unity.Mathematics.int3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half lhs, Unity.Mathematics.int3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half lhs, Unity.Mathematics.int3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.int4 lhs, half rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.int4 lhs, half rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.int4 lhs, half rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.int4 lhs, half rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.int4 lhs, half rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half lhs, Unity.Mathematics.int4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half lhs, Unity.Mathematics.int4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half lhs, Unity.Mathematics.int4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half lhs, Unity.Mathematics.int4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half lhs, Unity.Mathematics.int4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.uint2 lhs, half rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.uint2 lhs, half rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.uint2 lhs, half rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.uint2 lhs, half rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.uint2 lhs, half rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (half lhs, Unity.Mathematics.uint2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (half lhs, Unity.Mathematics.uint2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (half lhs, Unity.Mathematics.uint2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (half lhs, Unity.Mathematics.uint2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (half lhs, Unity.Mathematics.uint2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.uint3 lhs, half rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.uint3 lhs, half rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.uint3 lhs, half rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.uint3 lhs, half rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.uint3 lhs, half rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (half lhs, Unity.Mathematics.uint3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (half lhs, Unity.Mathematics.uint3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (half lhs, Unity.Mathematics.uint3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (half lhs, Unity.Mathematics.uint3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (half lhs, Unity.Mathematics.uint3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.uint4 lhs, half rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.uint4 lhs, half rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.uint4 lhs, half rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.uint4 lhs, half rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.uint4 lhs, half rhs) => lhs % (float4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (half lhs, Unity.Mathematics.uint4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (half lhs, Unity.Mathematics.uint4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (half lhs, Unity.Mathematics.uint4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (half lhs, Unity.Mathematics.uint4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (half lhs, Unity.Mathematics.uint4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, half right)
        {
            return left.IsEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float left, half right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right.IsZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left == 0f;
            }

            return left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, float right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right == 0f;
            }
            else if (constexpr.IS_TRUE(right == 0f))
            {
                return left.IsZero;
            }

            return (float)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (double left, half right)
        {
            if (constexpr.IS_TRUE(left == 0d))
            {
                return right.IsZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left == 0d;
            }

            return left == (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, double right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right == 0d;
            }
            else if (constexpr.IS_TRUE(right == 0d))
            {
                return left.IsZero;
            }

            return (double)left == right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, half right)
        {
            return left.IsNotEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float left, half right)
        {
            if (constexpr.IS_TRUE(left == 0f))
            {
                return right.IsNotZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left != 0f;
            }

            return left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, float right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right != 0f;
            }
            else if (constexpr.IS_TRUE(right == 0f))
            {
                return left.IsNotZero;
            }

            return (float)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (double left, half right)
        {
            if (constexpr.IS_TRUE(left == 0d))
            {
                return right.IsNotZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left != 0d;
            }

            return left != (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, double right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right != 0d;
            }
            else if (constexpr.IS_TRUE(right == 0d))
            {
                return left.IsNotZero;
            }

            return (double)left != right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, half right)
        {
            return left.IsLessThan(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (float left, half right)
        {
            return left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, float right)
        {
            return (float)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (double left, half right)
        {
            return left < (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, double right)
        {
            return (double)left < right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (float left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (double left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, double right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, half right)
        {
            return left.IsLessThanOrEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (float left, half right)
        {
            return left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, float right)
        {
            return (float)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (double left, half right)
        {
            return left <= (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, double right)
        {
            return (double)left <= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, double right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (byte left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, byte right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ushort left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, ushort right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (uint left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, uint right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ulong left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, ulong right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (sbyte left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, sbyte right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (short left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, short right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (int left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, int right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (long left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, long right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (Int128 left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return andnot((half)left == (half)right, isinf(right));
            }
            else
            {
                return (float)left == (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, Int128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                return andnot((half)left == (half)right, isinf(left));
            }
            else
            {
                return (float)left == (float)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (byte left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, byte right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ushort left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, ushort right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (uint left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, uint right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ulong left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, ulong right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (sbyte left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, sbyte right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (short left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, short right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (int left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, int right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (long left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, long right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (Int128 left, half right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (half)left != (half)right | isinf(right);
            }
            else
            {
                return (float)left != (float)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, Int128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                return (half)left != (half)right | isinf(left);
            }
            else
            {
                return (float)left != (float)right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (byte left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, byte right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ushort left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, ushort right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (uint left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, uint right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, ulong right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, UInt128 right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (sbyte left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, sbyte right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (short left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, short right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (int left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, int right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (long left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, long right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (Int128 left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, Int128 right)
        {
            return (float)left < (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (byte left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, byte right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (ushort left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, ushort right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (uint left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, uint right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (ulong left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, ulong right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, UInt128 right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (sbyte left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, sbyte right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (short left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, short right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (int left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, int right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (long left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, long right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (Int128 left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, Int128 right)
        {
            return (float)left > (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (byte left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, byte right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ushort left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, ushort right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (uint left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, uint right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ulong left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, ulong right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, UInt128 right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (sbyte left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, sbyte right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (short left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, short right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (int left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, int right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (long left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, long right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (Int128 left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, Int128 right)
        {
            return (float)left <= (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (byte left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, byte right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ushort left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, ushort right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (uint left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, uint right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, ulong right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, UInt128 right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (sbyte left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, sbyte right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (short left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, short right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (int left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, int right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (long left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, long right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (Int128 left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, Int128 right)
        {
            return (float)left >= (float)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (Unity.Mathematics.half lhs, half rhs) => (half)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (Unity.Mathematics.half lhs, half rhs) => (half)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (Unity.Mathematics.half lhs, half rhs) => (half)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (Unity.Mathematics.half lhs, half rhs) => (half)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (Unity.Mathematics.half lhs, half rhs) => (half)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (Unity.Mathematics.half lhs, half rhs) => (half)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half lhs, Unity.Mathematics.half rhs) => lhs == (half)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half lhs, Unity.Mathematics.half rhs) => lhs != (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half lhs, Unity.Mathematics.half rhs) => lhs < (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half lhs, Unity.Mathematics.half rhs) => lhs > (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half lhs, Unity.Mathematics.half rhs) => lhs <= (half)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half lhs, Unity.Mathematics.half rhs) => lhs >= (half)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.half2 lhs, half rhs) => (half2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half lhs, Unity.Mathematics.half2 rhs) => lhs == (half2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half lhs, Unity.Mathematics.half2 rhs) => lhs != (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half lhs, Unity.Mathematics.half2 rhs) => lhs < (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half lhs, Unity.Mathematics.half2 rhs) => lhs > (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half lhs, Unity.Mathematics.half2 rhs) => lhs <= (half2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half lhs, Unity.Mathematics.half2 rhs) => lhs >= (half2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.half3 lhs, half rhs) => (half3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (half lhs, Unity.Mathematics.half3 rhs) => lhs == (half3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (half lhs, Unity.Mathematics.half3 rhs) => lhs != (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (half lhs, Unity.Mathematics.half3 rhs) => lhs < (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (half lhs, Unity.Mathematics.half3 rhs) => lhs > (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (half lhs, Unity.Mathematics.half3 rhs) => lhs <= (half3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (half lhs, Unity.Mathematics.half3 rhs) => lhs >= (half3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.half4 lhs, half rhs) => (half4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (half lhs, Unity.Mathematics.half4 rhs) => lhs == (half4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (half lhs, Unity.Mathematics.half4 rhs) => lhs != (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (half lhs, Unity.Mathematics.half4 rhs) => lhs < (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (half lhs, Unity.Mathematics.half4 rhs) => lhs > (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (half lhs, Unity.Mathematics.half4 rhs) => lhs <= (half4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (half lhs, Unity.Mathematics.half4 rhs) => lhs >= (half4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.float2 lhs, half rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.float2 lhs, half rhs) => lhs != (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.float2 lhs, half rhs) => lhs < (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.float2 lhs, half rhs) => lhs > (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.float2 lhs, half rhs) => lhs <= (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.float2 lhs, half rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half lhs, Unity.Mathematics.float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.float3 lhs, half rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.float3 lhs, half rhs) => lhs != (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.float3 lhs, half rhs) => lhs < (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.float3 lhs, half rhs) => lhs > (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.float3 lhs, half rhs) => lhs <= (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.float3 lhs, half rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (half lhs, Unity.Mathematics.float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.float4 lhs, half rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.float4 lhs, half rhs) => lhs != (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.float4 lhs, half rhs) => lhs < (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.float4 lhs, half rhs) => lhs > (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.float4 lhs, half rhs) => lhs <= (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.float4 lhs, half rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (half lhs, Unity.Mathematics.float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.double2 lhs, half rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.double2 lhs, half rhs) => lhs != (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.double2 lhs, half rhs) => lhs < (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.double2 lhs, half rhs) => lhs > (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.double2 lhs, half rhs) => lhs <= (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.double2 lhs, half rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (half lhs, Unity.Mathematics.double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.double3 lhs, half rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.double3 lhs, half rhs) => lhs != (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.double3 lhs, half rhs) => lhs < (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.double3 lhs, half rhs) => lhs > (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.double3 lhs, half rhs) => lhs <= (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.double3 lhs, half rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (half lhs, Unity.Mathematics.double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.double4 lhs, half rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.double4 lhs, half rhs) => lhs != (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.double4 lhs, half rhs) => lhs < (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.double4 lhs, half rhs) => lhs > (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.double4 lhs, half rhs) => lhs <= (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.double4 lhs, half rhs) => lhs >= (double4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (half lhs, Unity.Mathematics.double4 rhs) => (double4)lhs >= rhs;


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator == (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator != (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator < (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator > (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator <= (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator >= (Unity.Mathematics.int2 lhs, half rhs) => (float2)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator == (half lhs, Unity.Mathematics.int2 rhs) => lhs == (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator != (half lhs, Unity.Mathematics.int2 rhs) => lhs != (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator < (half lhs, Unity.Mathematics.int2 rhs) => lhs < (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator > (half lhs, Unity.Mathematics.int2 rhs) => lhs > (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator <= (half lhs, Unity.Mathematics.int2 rhs) => lhs <= (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator >= (half lhs, Unity.Mathematics.int2 rhs) => lhs >= (float2)rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator == (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator != (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator < (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator > (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator <= (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator >= (Unity.Mathematics.int3 lhs, half rhs) => (float3)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator == (half lhs, Unity.Mathematics.int3 rhs) => lhs == (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator != (half lhs, Unity.Mathematics.int3 rhs) => lhs != (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator < (half lhs, Unity.Mathematics.int3 rhs) => lhs < (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator > (half lhs, Unity.Mathematics.int3 rhs) => lhs > (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator <= (half lhs, Unity.Mathematics.int3 rhs) => lhs <= (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator >= (half lhs, Unity.Mathematics.int3 rhs) => lhs >= (float3)rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator == (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator != (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator < (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator > (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator <= (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator >= (Unity.Mathematics.int4 lhs, half rhs) => (float4)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator == (half lhs, Unity.Mathematics.int4 rhs) => lhs == (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator != (half lhs, Unity.Mathematics.int4 rhs) => lhs != (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator < (half lhs, Unity.Mathematics.int4 rhs) => lhs < (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator > (half lhs, Unity.Mathematics.int4 rhs) => lhs > (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator <= (half lhs, Unity.Mathematics.int4 rhs) => lhs <= (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator >= (half lhs, Unity.Mathematics.int4 rhs) => lhs >= (float4)rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator == (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator != (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator < (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator > (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator <= (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator >= (Unity.Mathematics.uint2 lhs, half rhs) => (float2)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator == (half lhs, Unity.Mathematics.uint2 rhs) => lhs == (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator != (half lhs, Unity.Mathematics.uint2 rhs) => lhs != (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator < (half lhs, Unity.Mathematics.uint2 rhs) => lhs < (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator > (half lhs, Unity.Mathematics.uint2 rhs) => lhs > (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator <= (half lhs, Unity.Mathematics.uint2 rhs) => lhs <= (float2)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool2 operator >= (half lhs, Unity.Mathematics.uint2 rhs) => lhs >= (float2)rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator == (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator != (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator < (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator > (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator <= (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator >= (Unity.Mathematics.uint3 lhs, half rhs) => (float3)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator == (half lhs, Unity.Mathematics.uint3 rhs) => lhs == (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator != (half lhs, Unity.Mathematics.uint3 rhs) => lhs != (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator < (half lhs, Unity.Mathematics.uint3 rhs) => lhs < (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator > (half lhs, Unity.Mathematics.uint3 rhs) => lhs > (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator <= (half lhs, Unity.Mathematics.uint3 rhs) => lhs <= (float3)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool3 operator >= (half lhs, Unity.Mathematics.uint3 rhs) => lhs >= (float3)rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator == (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs == rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator != (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs != rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator < (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs < rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator > (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs > rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator <= (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs <= rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator >= (Unity.Mathematics.uint4 lhs, half rhs) => (float4)lhs >= rhs;
        //
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator == (half lhs, Unity.Mathematics.uint4 rhs) => lhs == (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator != (half lhs, Unity.Mathematics.uint4 rhs) => lhs != (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator < (half lhs, Unity.Mathematics.uint4 rhs) => lhs < (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator > (half lhs, Unity.Mathematics.uint4 rhs) => lhs > (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator <= (half lhs, Unity.Mathematics.uint4 rhs) => lhs <= (float4)rhs;
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool4 operator >= (half lhs, Unity.Mathematics.uint4 rhs) => lhs >= (float4)rhs;

        #region PARSING
        public static half Parse(string s, IFormatProvider provider)
        {
            return (half)float.Parse(s, provider);
        }
        public static half Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            return (half)float.Parse(s, style, provider);
        }
        public static half Parse(string s, NumberStyles style)
        {
            return (half)float.Parse(s, style);
        }
        public static half Parse(string s)
        {
            return (half)float.Parse(s);
        }
        public static bool TryParse(string s, out half result)
        {
            bool success = float.TryParse(s, out float cvt);

            result = (half)cvt;

            return success && cvt <= MaxValue && cvt >= MinValue;
        }
        public static bool TryParse(string s, NumberStyles style, IFormatProvider provider, out half result)
        {
            bool success = float.TryParse(s, style, provider, out float cvt);

            result = (half)cvt;

            return success && cvt <= MaxValue && cvt >= MinValue;
        }
        #endregion

        #region TO_STRING
        public override readonly string ToString()
        {
            return ((float)this).ToString();
        }
        public readonly string ToString(IFormatProvider provider)
        {
            return ((float)this).ToString(provider);
        }
        public readonly string ToString(string format)
        {
            return ((float)this).ToString(format);
        }
        public readonly string ToString(string format, IFormatProvider provider)
        {
            return ((float)this).ToString(format, provider);
        }
        #endregion

        #region COMPARE_TO
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int CompareTo(half other)
        {
            return compareto((float)this, (float)other);
        }
        public readonly int CompareTo(object obj)
        {
            return CompareTo((half)obj);
        }
        #endregion

        #region EQUALS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(half other)
        {
            return this == other;
        }
        public override readonly bool Equals(object obj) => obj is half converted && this.Equals(converted);
        #endregion

        #region GET_HASH_CODE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            return value;
        }
        #endregion

        #region ICONVERTIBLE
        public readonly TypeCode GetTypeCode()
        {
            return TypeCode.Single;
        }
        public readonly bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this.IsNotZero, provider);
        }
        public readonly byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte((byte)this, provider);
        }
        public readonly char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar((float)this, provider);
        }
        public readonly DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime((float)this, provider);
        }
        public readonly decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal((decimal)this, provider);
        }
        public readonly double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble((double)this, provider);
        }
        public readonly short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16((short)this, provider);
        }
        public readonly int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32((int)this, provider);
        }
        public readonly long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64((long)this, provider);
        }
        public readonly sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte((sbyte)this, provider);
        }
        public readonly float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle((float)this, provider);
        }
        public readonly object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType((float)this, conversionType, provider);
        }
        public readonly ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16((ushort)this, provider);
        }
        public readonly uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32((uint)this, provider);
        }
        public readonly ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64((ulong)this, provider);
        }
        #endregion
    }
}
