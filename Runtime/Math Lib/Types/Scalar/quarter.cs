using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using Unity.Burst;
using MaxMath.Intrinsics;

using static Unity.Mathematics.math;
using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       An 8-bit 1.3.4.-3 IEEE 754 floating point number, often called a "mini-float".       </summary>
    [Serializable]
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        // Change the number of exponent bits ("->3<- + (SIGN_BIT ? 0 : 1)")
        // And everything will fall into place correctly
        // is what I'd LIKE to say; q -> f works, f -> q does not

        internal const bool IEEE_754_STANDARD = true;                                                                                     //standard: true
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                                                                         //standard: true
        internal const bool SIGNALING_NAN = false;                                                                                        //standard: false
        internal const int BITS = 8 * sizeof(byte);                                                                                       //standard: 8
        internal const int SET_SIGN_BIT = (SIGN_BIT ? 1 : 0) << (BITS - 1);                                                               //standard: 0b1000_0000
        internal const int EXPONENT_BITS = 3 + (SIGN_BIT ? 0 : 1);                                                                        //standard: 3
        internal const int MANTISSA_BITS = BITS - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);                                                     //standard: 4
        internal const int EXPONENT_BIAS = -((1 << (EXPONENT_BITS - 1)) - 1);                                                             //standard: -3
        internal const int MAX_UNBIASED_EXPONENT = -EXPONENT_BIAS;                                                                        //standard: 3
        internal const int MIN_UNBIASED_EXPONENT = EXPONENT_BIAS + 1;                                                                     //standard: -2
        internal const int SIGNALING_EXPONENT = (MAX_UNBIASED_EXPONENT - EXPONENT_BIAS + (IEEE_754_STANDARD ? 1 : 0)) << MANTISSA_BITS;   //standard: 0b0111_0000

        internal const int F32_SHL_LOSE_SIGN       = F32_BITS - (MANTISSA_BITS + EXPONENT_BITS);
        internal const int F32_SHR_PLACE_MANTISSA  = MANTISSA_BITS + ((1 + F32_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const int F32_MAGIC               = (((1 << F32_EXPONENT_BITS) - 1) - (1 + -EXPONENT_BIAS)) << F32_MANTISSA_BITS;
        internal const uint DEPOSIT_MASK_32 = (1u << (F32_BITS - 1)) | (((1u << (BITS - 1)) - 1) << (F32_BITS - BITS - (F32_EXPONENT_BITS - EXPONENT_BITS)));

        internal const int  F64_SHL_LOSE_SIGN      = F64_BITS - (MANTISSA_BITS + EXPONENT_BITS);
        internal const int  F64_SHR_PLACE_MANTISSA = MANTISSA_BITS + ((1 + F64_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const long F64_MAGIC              = (((1L << F64_EXPONENT_BITS) - 1) - (1 + -EXPONENT_BIAS)) << F64_MANTISSA_BITS;
        internal const ulong DEPOSIT_MASK_64       = (1ul << (F64_BITS - 1)) | (((1ul << (BITS - 1)) - 1) << (F64_BITS - BITS - (F64_EXPONENT_BITS - EXPONENT_BITS)));


        public readonly byte value;


        #region CONSTANTS
        /// <summary>       0.015625 as a <see cref="float"/>.      </summary>
        public static quarter Epsilon => asquarter((byte)1);

        /// <summary>       15.5 as a <see cref="float"/>.      </summary>
        public static quarter MaxValue => asquarter((byte)(SIGNALING_EXPONENT - 1));

        /// <summary>       -15.5 as a <see cref="float"/>.      </summary>
        public static quarter MinValue => -MaxValue;
        public static quarter Zero => asquarter((byte)0);
        public static quarter NaN => asquarter((byte)(SIGNALING_EXPONENT | 1));
        public static quarter PositiveInfinity => asquarter((byte)SIGNALING_EXPONENT);
        public static quarter NegativeInfinity => -PositiveInfinity;
        #endregion

        #region TYPE_CONVERSION
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromHalf(half h, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
        {
            FloatingPointPromise<half> promise = new FloatingPointPromise<half>(h);
            promiseInRange |= promise.NotInf && promise.NotNaN && (promise.MinPossible >= MinValue && promise.MaxPossible <= MaxValue);
            promiseAbs |= promise.ZeroOrGreater;
            
            const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + EXPONENT_BIAS;

            int sign = promiseAbs ? 0 : (asushort(h) >> (F16_BITS - 1)) << (BITS - 1);
            uint exp = (uint)asushort(h) & F16_SIGNALING_EXPONENT;
            uint frac = (uint)asushort(h) & bitmask32((uint)F16_MANTISSA_BITS);
            
            bool denormalF8 = !promiseNotSubnormal && exp <= (uint)EXPONENT_OFFSET << F16_MANTISSA_BITS;
            bool overflow = !promiseInRange && asushort(abs(h)) >= ((bitmask32((uint)MANTISSA_BITS + 1) << (F16_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F16_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask32((uint)F16_EXPONENT_BITS)) << F16_MANTISSA_BITS));
            bool noUnderflow = exp >= (EXPONENT_OFFSET - MANTISSA_BITS) << F16_MANTISSA_BITS;

            exp -= EXPONENT_OFFSET << F16_MANTISSA_BITS;
            byte frac8;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - (int)abs((int)exp >> F16_MANTISSA_BITS);
                frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                frac8 |= (byte)((frac & (uint)-(int)tobyte(noUnderflow)) >> (F16_MANTISSA_BITS - bitIndex));
                
                uint round = ((uint)bitIndex >> 31) | tobyte((asushort(h) & (1 << (F16_MANTISSA_BITS - 1 - bitIndex))) != 0);
                frac8 += (byte)(round & (uint)-(int)tobyte(noUnderflow));

                return asquarter((byte)(sign | frac8));
            }
            else
            {
                if (overflow)
                {
                    return asquarter((byte)(sign | SIGNALING_EXPONENT | tobyte(isnan(h))));
                }
                else
                {
                    frac8 = (byte)(frac >> (F16_MANTISSA_BITS - MANTISSA_BITS));
                    frac8 |= (byte)(exp >> (F16_MANTISSA_BITS - MANTISSA_BITS));

                    byte round = tobyte((asushort(h) & bitmask32((uint)(F16_MANTISSA_BITS - MANTISSA_BITS))) > (1 << (F16_MANTISSA_BITS - MANTISSA_BITS - 1)));
                    frac8 += (byte)(sign | round);

                    return asquarter(frac8);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(half h)
        {
            return FromHalf(h);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter FromFloat(float f, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
        {
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
                    uint f8_sign = asuint(f) >> (F32_BITS - 1);
            
                    f8_sign <<= (BITS - 1);
            
                    result = q ^ f8_sign;
                }
                
            ROUND:
                byte round = tobyte((asuint(f) & bitmask32((uint)(F32_MANTISSA_BITS - MANTISSA_BITS))) > (1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)));
                result += round;
                return asquarter((byte)result);
            }

            int sign = promiseAbs ? 0 : (asint(f) >> (F32_BITS - 1)) << (BITS - 1);
            uint frac = asuint(f) & bitmask32((uint)F32_MANTISSA_BITS);

            bool overflow = !promiseInRange && asuint(abs(f)) >= ((bitmask32((uint)MANTISSA_BITS + 1) << (F32_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F32_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask32((uint)F32_EXPONENT_BITS)) << F32_MANTISSA_BITS));

            exp -= EXPONENT_OFFSET << F32_MANTISSA_BITS;
            byte frac8;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - (int)abs((int)exp >> F32_MANTISSA_BITS);
                frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                frac8 |= (byte)((frac & (uint)-(int)tobyte(noUnderflow)) >> (F32_MANTISSA_BITS - bitIndex));
                
                uint round = ((uint)bitIndex >> 31) | tobyte((asuint(f) & (1 << (F32_MANTISSA_BITS - 1 - bitIndex))) != 0);
                frac8 += (byte)(round & (uint)-(int)tobyte(noUnderflow));

                return asquarter((byte)(sign | frac8));
            }
            else
            {
                if (overflow)
                {
                    return asquarter((byte)(sign | SIGNALING_EXPONENT | tobyte(isnan(f))));
                }
                else
                {
                    frac8 = (byte)(frac >> (F32_MANTISSA_BITS - MANTISSA_BITS));
                    frac8 |= (byte)(exp >> (F32_MANTISSA_BITS - MANTISSA_BITS));

                    byte round = tobyte((asuint(f) & bitmask32((uint)(F32_MANTISSA_BITS - MANTISSA_BITS))) > (1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)));
                    frac8 += (byte)(sign | round);

                    return asquarter(frac8);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(float f)
        {
            return FromFloat(f);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromDouble(double d, bool promiseInRange = false, bool promiseAbs = false, bool promiseNotSubnormal = false)
        {
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
                    ulong f8_sign = asulong(d) >> (F64_BITS - 1);
                    
                    f8_sign <<= (BITS - 1);
                    
                    result = q ^ f8_sign;
                }
                
            ROUND:
                byte round = tobyte((asulong(d) & bitmask64((ulong)(F64_MANTISSA_BITS - MANTISSA_BITS))) > (1ul << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)));
                result += round;
                return asquarter((byte)result);
            }

            long sign = promiseAbs ? 0 : (aslong(d) >> (F64_BITS - 1)) << (BITS - 1);
            ulong frac = asulong(d) & bitmask64((ulong)F64_MANTISSA_BITS);
            
            bool denormalF8 = !promiseNotSubnormal && exp <= (ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS;
            bool overflow = !promiseInRange && asulong(abs(d)) >= ((bitmask64((ulong)MANTISSA_BITS + 1) << (F64_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F64_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask64((ulong)F64_EXPONENT_BITS)) << F64_MANTISSA_BITS));
            
            exp -= EXPONENT_OFFSET << F64_MANTISSA_BITS;
            byte frac8;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - (int)abs((long)exp >> F64_MANTISSA_BITS);
                frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                frac8 |= (byte)((frac & (ulong)-(long)tobyte(noUnderflow)) >> (F64_MANTISSA_BITS - bitIndex));
                
                ulong round = ((ulong)bitIndex >> 63) | tobyte((asulong(d) & (1ul << (F64_MANTISSA_BITS - 1 - bitIndex))) != 0);
                frac8 += (byte)(round & (ulong)-(long)tobyte(noUnderflow));

                return asquarter((byte)(sign | frac8));
            }
            else
            {
                if (overflow)
                {
                    return asquarter((byte)(sign | SIGNALING_EXPONENT | tobyte(isnan(d))));
                }
                else
                {
                    frac8 = (byte)(frac >> (F64_MANTISSA_BITS - MANTISSA_BITS));
                    frac8 |= (byte)(exp >> (F64_MANTISSA_BITS - MANTISSA_BITS));

                    byte round = tobyte((asulong(d) & bitmask64((ulong)(F64_MANTISSA_BITS - MANTISSA_BITS))) > (1ul << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)));
                    frac8 += (byte)(sign | round);

                    return asquarter(frac8);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(double d)
        {
            return FromDouble(d);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(decimal d)
        {
            return (quarter)(double)d;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SkipLocalsInit]
        internal static quarter GetInteger(ulong i, quarter overflowValue, bool promiseInRange = false)
        {
            if (promiseInRange || constexpr.IS_TRUE(i < 16ul))
            {
                quarter* possibleValues = stackalloc quarter[] { (quarter)0f, (quarter)1f, (quarter)2f, (quarter)3f, (quarter)4f, (quarter)5f, (quarter)6f, (quarter)7f, (quarter)8f, (quarter)9f, (quarter)10f, (quarter)11f, (quarter)12f, (quarter)13f, (quarter)14f, (quarter)15f };

                return possibleValues[i];
            }
            else
            {
                quarter* possibleValues = stackalloc quarter[] { (quarter)0f, (quarter)1f, (quarter)2f, (quarter)3f, (quarter)4f, (quarter)5f, (quarter)6f, (quarter)7f, (quarter)8f, (quarter)9f, (quarter)10f, (quarter)11f, (quarter)12f, (quarter)13f, (quarter)14f, (quarter)15f, overflowValue };

                return possibleValues[min(i, 16ul)];
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromByte(byte value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(byte b)
        {
            return FromByte(b, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromUShort(ushort value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ushort us)
        {
            return FromUShort(us, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromUInt(uint value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(uint ui)
        {
            return FromUInt(ui, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromULong(ulong value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ulong ul)
        {
            return FromULong(ul, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromUInt128(UInt128 value, quarter overflowValue)
        {
            return value.hi64 != 0 ? overflowValue : GetInteger(value.lo64, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(UInt128 ull)
        {
            return FromUInt128(ull, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromSByte(sbyte value, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return FromByte((byte)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((byte)abs(value), overflowValue, promiseInRange);

                return asquarter((byte)((value & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(sbyte sb)
        {
            return FromSByte(sb, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromShort(short value, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return FromUShort((ushort)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((ushort)abs(value), overflowValue, promiseInRange);

                return asquarter((byte)(((value >> 8) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(short s)
        {
            return FromShort(s, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromInt(int value, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return FromUInt((uint)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((uint)abs(value), overflowValue, promiseInRange);

                return asquarter((byte)(((value >> 24) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(int i)
        {
            return FromInt(i, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromLong(long value, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return FromULong((uint)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((ulong)abs(value), overflowValue, promiseInRange);

                return asquarter((byte)(((value >> 56) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(long l)
        {
            return FromLong(l, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FromInt128(Int128 value, quarter overflowValue)
        {
            if (constexpr.IS_TRUE(value >= 0))
            {
                return FromUInt128((UInt128)value, overflowValue);
            }
            else
            {
                bool overflowHi64 = value.hi64 + 1 > 1; // any other value than -1 or 0

                return overflowHi64 ? asquarter((byte)(overflowValue.value | (value.hi64 >> 56) & 0b1000_0000))
                                    : FromLong((long)value.lo64, overflowValue);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(Int128 ll)
        {
            return FromInt128(ll, quarter.PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half(quarter q)
        {
            return ToHalf(q, false, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static half ToHalf(quarter q, bool inRange = false, bool abs = false)
        {
            const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + EXPONENT_BIAS;
            FloatingPointPromise<quarter> promise = new FloatingPointPromise<quarter>(q);
            inRange |= promise.NotNaN && promise.NotInf;
            abs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? promise.Positive : promise.ZeroOrGreater;

            uint sign = abs ? 0 : (uint)(q.value >> 7) << 15;
            uint exp = (uint)q.value & SIGNALING_EXPONENT;
            uint frac = (uint)q.value & bitmask32((uint)MANTISSA_BITS);

            if (Hint.Unlikely(exp == 0))
            {
                if (promise.NotSubnormal)
                {
                    exp = 0;
                }
                else
                {
                    byte16 shiftDistBase = new byte16(8, 7, 6, 6, 5, 5, 5, 5,    4, 4, 4, 4, 4, 4, 4, 4) - EXPONENT_BITS;

                    exp = Hint.Likely(promise.NonZero || frac != 0) ? (EXPONENT_OFFSET - (uint)shiftDistBase[(int)frac]) << F16_MANTISSA_BITS: 0u;
                    frac <<= shiftDistBase[(int)frac];
                }
            }
            else
            {
                if (!inRange
                 && Hint.Unlikely(exp == bitmask32((uint)EXPONENT_BITS) << MANTISSA_BITS))
                {
                    return ashalf((ushort)((promise.NotNaN ? 0ul : tobyte(frac != 0)) | sign | F16_SIGNALING_EXPONENT));
                }

                exp += EXPONENT_OFFSET << MANTISSA_BITS;
                exp <<= F16_MANTISSA_BITS - MANTISSA_BITS;
            }

            return ashalf((ushort)(sign | (exp + (frac << (F16_MANTISSA_BITS - MANTISSA_BITS)))));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(quarter q)
        {
            return ToFloat(q, false, false);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float ToFloat(quarter q, bool inRange = false, bool abs = false)
        {
            FloatingPointPromise<quarter> promise = new FloatingPointPromise<quarter>(q);
            inRange |= promise.NotNaN && promise.NotInf;
            abs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? promise.Positive : promise.ZeroOrGreater;
            
            float f;
            uint fusedExponentMantissa;

            if (abs)
            {
                fusedExponentMantissa = (uint)q.value << (F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                f = asfloat(F32_MAGIC) * asfloat(fusedExponentMantissa);
            }
            else
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        uint aligned = bits_depositparallel(q.value, DEPOSIT_MASK_32);
                        f = asfloat(F32_MAGIC) * asfloat(aligned);

                        goto NAN_INF_CHECK;
                    }
                }
                
                fusedExponentMantissa = ((uint)q.value << F32_SHL_LOSE_SIGN) >> F32_SHR_PLACE_MANTISSA;
                f = asfloat((sbyte)q.value < 0 ? F32_MAGIC ^ (1 << (F32_BITS - 1)) : F32_MAGIC) * asfloat(fusedExponentMantissa);
            }
            
        NAN_INF_CHECK:

            if (!inRange)
            {
                if (Hint.Unlikely((q.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT))
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
        public static implicit operator double(quarter q)
        {
            return ToDouble(q, false, false);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double ToDouble(quarter q, bool inRange = false, bool abs = false)
        {
            FloatingPointPromise<quarter> promise = new FloatingPointPromise<quarter>(q);
            inRange |= promise.NotNaN && promise.NotInf;
            abs |= COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO ? promise.Positive : promise.ZeroOrGreater;
            
            double d;
            ulong fusedExponentMantissa;

            if (abs)
            {
                fusedExponentMantissa = (ulong)q.value << (F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                d = asdouble(F64_MAGIC) * asdouble(fusedExponentMantissa);
            }
            else
            {
                if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                {
                    if (Bmi2.IsBmi2Supported)
                    {
                        ulong aligned = bits_depositparallel(q.value, DEPOSIT_MASK_64);
                        d = asdouble(F64_MAGIC) * asdouble(aligned);

                        goto NAN_INF_CHECK;
                    }
                }
                
                fusedExponentMantissa = ((ulong)q.value << F64_SHL_LOSE_SIGN) >> F64_SHR_PLACE_MANTISSA;
                d = asdouble((sbyte)q.value < 0 ? F64_MAGIC ^ (1ul << (F64_BITS - 1)) : F64_MAGIC) * asdouble(fusedExponentMantissa);
            }
            
        NAN_INF_CHECK:
            
            if (!inRange)
            {
                if (Hint.Unlikely((q.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT))
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
        public static implicit operator decimal(quarter q)
        {
            return (decimal)(float)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte(quarter q)
        {
            return (byte)maxmath.BASE_cvtf8i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(quarter q)
        {
            return (ushort)maxmath.BASE_cvtf8i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(quarter q)
        {
            return maxmath.BASE_cvtf8i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(quarter q)
        {
            return maxmath.BASE_cvtf8i32(q, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(quarter q)
        {
            return maxmath.BASE_cvtf8i32(q, signed: false, trunc: true);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(quarter q)
        {
            return (sbyte)maxmath.BASE_cvtf8i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(quarter q)
        {
            return (short)maxmath.BASE_cvtf8i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(quarter q)
        {
            return (int)maxmath.BASE_cvtf8i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(quarter q)
        {
            return (int)maxmath.BASE_cvtf8i32(q, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(quarter q)
        {
            return (int)maxmath.BASE_cvtf8i32(q, signed: true, trunc: true);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half2(quarter q)
        {
            return (half2)(half)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(quarter q)
        {
            return (half3)(half)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(quarter q)
        {
            return (half4)(half)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(quarter q)
        {
            return (half8)(half)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(quarter q)
        {
            return (float2)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(quarter q)
        {
            return (float3)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(quarter q)
        {
            return (float4)(float)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(quarter q)
        {
            return (double2)(double)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(quarter q)
        {
            return (double3)(double)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(quarter q)
        {
            return (double4)(double)q;
        }

        #endregion

        #region ARITHMETIC
        internal bool IsZero => (value & 0b0111_1111) == 0;
        internal bool IsNotZero => (value & 0b0111_1111) != 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEqualTo(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(this.IsZero))
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
        internal bool IsNotEqualTo(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(this.IsZero))
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
                    bool notBothZero = asquarter((byte)(this.value | other.value)).IsNotZero;

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
                    bool notBothZero = asquarter((byte)(this.value | other.value)).IsNotZero;

                    return nan | (value & notBothZero);
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool IsLessThan(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(other.IsZero))
            {
                bool negative = this.value > 0b0111_1111;
                bool notZero = (this.value & 0b0111_1111) != 0;

                if (neitherNaN)
                {
                    return notZero & negative;
                }
                else
                {
                    return !isnan(this) & (notZero & negative);
                }
            }
            if (constexpr.IS_TRUE(this.IsZero))
            {
                bool positive = other.value < 0b1000_0000;
                bool notZero = (other.value & 0b0111_1111) != 0;

                if (neitherNaN)
                {
                    return positive & notZero;
                }
                else
                {
                    return !isnan(other) & (positive & notZero);
                }
            }


            int signA = this.value >> 7;
            int signB = other.value >> 7;

            bool equalSigns = signA == signB;
            bool differentValues = this.value != other.value;

            bool ifEqualSigns = differentValues & (tobool(signA) ^ (other.value > this.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool notBothZero = (byte)((this.value | other.value) << 1) != 0;

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
        internal bool IsLessThanOrEqualTo(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            neitherNaN |= constexpr.IS_TRUE(!isnan(this)) && constexpr.IS_TRUE(!isnan(other));
            neitherZero |= constexpr.IS_TRUE(IsNotZero) && constexpr.IS_TRUE(other.IsNotZero);

            if (constexpr.IS_TRUE(other.IsZero))
            {
                bool intLEzero = 1 > (sbyte)this.value;

                if (neitherNaN)
                {
                    return intLEzero;
                }
                else
                {
                    return !isnan(this) & intLEzero;
                }
            }
            if (constexpr.IS_TRUE(this.IsZero))
            {
                bool uintGEzero = (sbyte)other.value > 0;
                bool negativeZero = other.value == 0b1000_0000;

                if (neitherNaN)
                {
                    return uintGEzero | negativeZero;
                }
                else
                {
                    return !isnan(other) & (uintGEzero | negativeZero);
                }
            }


            int signA = this.value >> 7;
            int signB = other.value >> 7;

            bool equalSigns = signA == signB;
            bool equalValues = this.value == other.value;

            bool ifEqualSigns = equalValues | (tobool(signA) ^ (other.value > this.value));
            bool ifOppositeSigns = tobool(signA);

            if (!neitherZero)
            {
                bool bothZero = (byte)((this.value | other.value) << 1) == 0;

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
        internal bool IsGreaterThan(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            return other.IsLessThan(this, neitherNaN, neitherZero);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool IsGreaterThanOrEqualTo(quarter other, bool neitherNaN = false, bool neitherZero = false)
        {
            return other.IsLessThanOrEqualTo(this, neitherNaN, neitherZero);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter operator + (quarter value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter operator - (quarter value)
        {
            return asquarter((byte)(value.value ^ 0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, quarter right)
        {
            return left.IsEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, quarter right)
        {
            if (constexpr.IS_TRUE(left.IsZero()))
            {
                return right.IsZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsZero();
            }

            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, half right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsZero();
            }
            else if (constexpr.IS_TRUE(right.IsZero()))
            {
                return left.IsZero;
            }

            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float left, quarter right)
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
        public static bool operator == (quarter left, float right)
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
        public static bool operator == (double left, quarter right)
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
        public static bool operator == (quarter left, double right)
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
        public static bool operator != (quarter left, quarter right)
        {
            return left.IsNotEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, quarter right)
        {
            if (constexpr.IS_TRUE(left.IsZero()))
            {
                return right.IsNotZero;
            }
            else if (constexpr.IS_TRUE(right.IsZero))
            {
                return left.IsNotZero();
            }

            return (float)left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, half right)
        {
            if (constexpr.IS_TRUE(left.IsZero))
            {
                return right.IsNotZero();
            }
            else if (constexpr.IS_TRUE(right.IsZero()))
            {
                return left.IsNotZero;
            }

            return (float)left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float left, quarter right)
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
        public static bool operator != (quarter left, float right)
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
        public static bool operator != (double left, quarter right)
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
        public static bool operator != (quarter left, double right)
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
        public static bool operator < (quarter left, quarter right)
        {
            return left.IsLessThan(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (half left, quarter right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (quarter left, half right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (float left, quarter right)
        {
            return left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (quarter left, float right)
        {
            return (float)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (double left, quarter right)
        {
            return left < (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (quarter left, double right)
        {
            return (double)left < right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, half right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (float left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, float right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (double left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, double right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quarter left, quarter right)
        {
            return left.IsLessThanOrEqualTo(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (half left, quarter right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quarter left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (float left, quarter right)
        {
            return left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quarter left, float right)
        {
            return (float)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (double left, quarter right)
        {
            return left <= (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quarter left, double right)
        {
            return (double)left <= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, half right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, float right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, double right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (quarter left, quarter right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (half left, quarter right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (quarter left, half right)
        {
            return (float)left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (float left, quarter right)
        {
            return left + (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (quarter left, float right)
        {
            return (float)left + right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (double left, quarter right)
        {
            return left + (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (quarter left, double right)
        {
            return (double)left + right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (quarter left, quarter right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (half left, quarter right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (quarter left, half right)
        {
            return (float)left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (float left, quarter right)
        {
            return left - (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (quarter left, float right)
        {
            return (float)left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (double left, quarter right)
        {
            return left - (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (quarter left, double right)
        {
            return (double)left - right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (quarter left, quarter right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (half left, quarter right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (quarter left, half right)
        {
            return (float)left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (float left, quarter right)
        {
            return left * (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (quarter left, float right)
        {
            return (float)left * right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (double left, quarter right)
        {
            return left * (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (quarter left, double right)
        {
            return (double)left * right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (quarter left, quarter right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (half left, quarter right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (quarter left, half right)
        {
            return (float)left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (float left, quarter right)
        {
            return left / (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (quarter left, float right)
        {
            return (float)left / right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (double left, quarter right)
        {
            return left / (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (quarter left, double right)
        {
            return (double)left / right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (quarter left, quarter right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (half left, quarter right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (quarter left, half right)
        {
            return (float)left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (float left, quarter right)
        {
            return left % (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (quarter left, float right)
        {
            return (float)left % right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (double left, quarter right)
        {
            return left % (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (quarter left, double right)
        {
            return (double)left % right;
        }
        #endregion

        #region PARSING
        public quarter Parse(string s, IFormatProvider provider)
        {
            return (quarter)float.Parse(s, provider);
        }
        public quarter Parse(string s, NumberStyles style, IFormatProvider provider)
        {
            return (quarter)float.Parse(s, style, provider);
        }
        public quarter Parse(string s, NumberStyles style)
        {
            return (quarter)float.Parse(s, style);
        }
        public quarter Parse(string s)
        {
            return (quarter)float.Parse(s);
        }
        public bool TryParse(string s, out quarter result)
        {
            bool success = float.TryParse(s, out float cvt);

            result = (quarter)cvt;

            return success && cvt <= MaxValue && cvt >= MinValue;
        }
        public bool TryParse(string s, NumberStyles style, IFormatProvider provider, out quarter result)
        {
            bool success = float.TryParse(s, style, provider, out float cvt);

            result = (quarter)cvt;

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
        public int CompareTo(quarter other)
        {
            return compareto((float)this, (float)other);
        }
        public int CompareTo(object obj)
        {
            return CompareTo((quarter)obj);
        }
        #endregion

        #region EQUALS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter other)
        {
            return this == other;
        }
        public override readonly bool Equals(object obj) => obj is quarter converted && this.Equals(converted);
        #endregion

        #region GET_HASH_CODE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            return value;
        }
        #endregion

        #region ICONVERTIBLE
        public TypeCode GetTypeCode()
        {
            return TypeCode.Single;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(this.IsNotZero, provider);
        }
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte((byte)this, provider);
        }
        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar((float)this, provider);
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime((float)this, provider);
        }
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal((decimal)this, provider);
        }
        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble((double)this, provider);
        }
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16((short)this, provider);
        }
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32((int)this, provider);
        }
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64((long)this, provider);
        }
        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte((sbyte)this, provider);
        }
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle((float)this, provider);
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType((float)this, conversionType, provider);
        }
        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16((ushort)this, provider);
        }
        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32((uint)this, provider);
        }
        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64((ulong)this, provider);
        }
        #endregion
    }
}