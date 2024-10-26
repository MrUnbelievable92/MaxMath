using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       An 8-bit 1.3.4.-3 IEEE 754 floating point number, often called a "mini-float".       </summary>
    [Serializable]
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal quarter(byte value)
        {
            this.value = value;
        }


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
        internal const int F32_MAGIC               = (((1 << F32_EXPONENT_BITS) - 1) - (1 + EXPONENT_BITS)) << F32_MANTISSA_BITS;

        internal const int  F64_SHL_LOSE_SIGN      = F64_BITS - (MANTISSA_BITS + EXPONENT_BITS);
        internal const int  F64_SHR_PLACE_MANTISSA = MANTISSA_BITS + ((1 + F64_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const long F64_MAGIC              = (((1L << F64_EXPONENT_BITS) - 1) - (1 + EXPONENT_BITS)) << F64_MANTISSA_BITS;


        public readonly byte value;


        #region CONSTANTS
        /// <summary>       0.015625 as a <see cref="float"/>.      </summary>
        public static quarter Epsilon => new quarter(1);

        /// <summary>       15.5 as a <see cref="float"/>.      </summary>
        public static quarter MaxValue => new quarter(SIGNALING_EXPONENT - 1);

        /// <summary>       -15.5 as a <see cref="float"/>.      </summary>
        public static quarter MinValue => -MaxValue;
        public static quarter Zero => new quarter(0);
        public static quarter NaN => new quarter(SIGNALING_EXPONENT | 1);
        public static quarter PositiveInfinity => new quarter(SIGNALING_EXPONENT);
        public static quarter NegativeInfinity => -PositiveInfinity;
        #endregion

        #region TYPE_CONVERSION
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(half h)
        {
            const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + EXPONENT_BIAS;

            int sign = (h.value >> 15) << (BITS - 1);
            uint exp = (uint)h.value & F16_SIGNALING_EXPONENT;
            uint frac = (uint)h.value & bitmask32((uint)F16_MANTISSA_BITS);
            
            bool denormalF8 = exp <= EXPONENT_OFFSET << F16_MANTISSA_BITS;
            bool overflow = abs(h).value >= ((bitmask32(MANTISSA_BITS + 1) << (F16_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F16_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask32(F16_EXPONENT_BITS)) << F16_MANTISSA_BITS));
            bool noUnderflow = exp >= (MIN_UNBIASED_EXPONENT - MANTISSA_BITS - 1 - F16_EXPONENT_BIAS) << F16_MANTISSA_BITS;

            exp -= EXPONENT_OFFSET << F16_MANTISSA_BITS;
            byte frac8;
            if (Hint.Unlikely(denormalF8))
            {
                int bitIndex = MANTISSA_BITS - 1 - abs((int)exp >> F16_MANTISSA_BITS);
                frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                frac8 |= (byte)((frac & (uint)-tobyte(noUnderflow)) >> (F16_MANTISSA_BITS - bitIndex));
                
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

                    byte round = tobyte((frac & bitmask32((uint)(F16_MANTISSA_BITS - MANTISSA_BITS))) != 0);
                    frac8 += round;
            
                    return asquarter((byte)(sign | (byte)(exp >> (F16_MANTISSA_BITS - MANTISSA_BITS)) | frac8));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(float f)
        {
            if (Architecture.IsSIMDSupported)
            {
                return new quarter(Xse.cvtps_pq(RegisterConversion.ToV128(f)).Byte0);
            }
            else
            {
                const int EXPONENT_OFFSET = -F32_EXPONENT_BIAS + EXPONENT_BIAS;

                int sign = (asint(f) >> 31) << (BITS - 1);
                uint exp = asuint(f) & F32_SIGNALING_EXPONENT;
                uint frac = asuint(f) & bitmask32((uint)F32_MANTISSA_BITS);
                
                bool denormalF8 = exp <= (uint)EXPONENT_OFFSET << F32_MANTISSA_BITS;
                bool overflow = asuint(abs(f)) >= ((bitmask32((uint)MANTISSA_BITS + 1) << (F32_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F32_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask32((uint)F32_EXPONENT_BITS)) << F32_MANTISSA_BITS));
                bool noUnderflow = exp >= (uint)(MIN_UNBIASED_EXPONENT - MANTISSA_BITS - 1 - F32_EXPONENT_BIAS) << F32_MANTISSA_BITS;

                exp -= EXPONENT_OFFSET << F32_MANTISSA_BITS;
                byte frac8;
                if (Hint.Unlikely(denormalF8))
                {
                    int bitIndex = MANTISSA_BITS - 1 - abs((int)exp >> F32_MANTISSA_BITS);
                    frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                    frac8 |= (byte)((frac & (uint)-tobyte(noUnderflow)) >> (F32_MANTISSA_BITS - bitIndex));
                    
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

                        byte round = tobyte((frac & bitmask32((uint)(F32_MANTISSA_BITS - MANTISSA_BITS))) != 0);
                        frac8 += round;
                
                        return asquarter((byte)(sign | (byte)(exp >> (F32_MANTISSA_BITS - MANTISSA_BITS)) | frac8));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(double d)
        {
            if (Architecture.IsSIMDSupported)
            {
                return new quarter(Xse.cvtpd_pq(RegisterConversion.ToV128(d)).Byte0);
            }
            else
            {
                const long EXPONENT_OFFSET = -F64_EXPONENT_BIAS + EXPONENT_BIAS;

                long sign = (aslong(d) >> 63) << (BITS - 1);
                ulong exp = asulong(d) & F64_SIGNALING_EXPONENT;
                ulong frac = asulong(d) & bitmask64((ulong)F64_MANTISSA_BITS);
                
                bool denormalF8 = exp <= (ulong)EXPONENT_OFFSET << F64_MANTISSA_BITS;
                bool overflow = asulong(abs(d)) >= ((bitmask64((ulong)MANTISSA_BITS + 1) << (F64_MANTISSA_BITS - (MANTISSA_BITS + 1))) | (((-F64_EXPONENT_BIAS + MAX_UNBIASED_EXPONENT) & bitmask64((ulong)F64_EXPONENT_BITS)) << F64_MANTISSA_BITS));
                bool noUnderflow = exp >= (ulong)(MIN_UNBIASED_EXPONENT - MANTISSA_BITS - 1 - F64_EXPONENT_BIAS) << F64_MANTISSA_BITS;

                exp -= EXPONENT_OFFSET << F64_MANTISSA_BITS;
                byte frac8;
                if (Hint.Unlikely(denormalF8))
                {
                    int bitIndex = MANTISSA_BITS - 1 - (int)abs((long)exp >> F64_MANTISSA_BITS);
                    frac8 = (byte)(tobyte(noUnderflow) << bitIndex);
                    frac8 |= (byte)((frac & (ulong)-tobyte(noUnderflow)) >> (F64_MANTISSA_BITS - bitIndex));
                    
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

                        byte round = tobyte((frac & bitmask64((ulong)(F64_MANTISSA_BITS - MANTISSA_BITS))) != 0);
                        frac8 += round;
                
                        return asquarter((byte)(sign | (byte)(exp >> (F64_MANTISSA_BITS - MANTISSA_BITS)) | frac8));
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(decimal d)
        {
            return (quarter)(float)d;
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
        internal static quarter ByteToQuarter(byte value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(byte b)
        {
            return ByteToQuarter(b, PositiveInfinity);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter UShortToQuarter(ushort value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ushort us)
        {
            return UShortToQuarter(us, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter UIntToQuarter(uint value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(uint ui)
        {
            return UIntToQuarter(ui, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter ULongToQuarter(ulong value, quarter overflowValue)
        {
            return GetInteger(value, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ulong ul)
        {
            return ULongToQuarter(ul, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter UInt128ToQuarter(UInt128 value, quarter overflowValue)
        {
            return value.hi64 != 0 ? overflowValue : GetInteger(value.lo64, overflowValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(UInt128 ull)
        {
            return UInt128ToQuarter(ull, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter SByteToQuarter(sbyte value, quarter overflowValue, bool promiseInRange = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return ByteToQuarter((byte)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((byte)abs(value), overflowValue, promiseInRange);

                return new quarter((byte)((value & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(sbyte sb)
        {
            return SByteToQuarter(sb, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter ShortToQuarter(short value, quarter overflowValue, bool promiseNoOverflow = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return UShortToQuarter((ushort)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((ushort)abs(value), overflowValue, promiseNoOverflow);

                return new quarter((byte)(((value >> 8) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(short s)
        {
            return ShortToQuarter(s, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter IntToQuarter(int value, quarter overflowValue, bool promiseNoOverflow = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return UIntToQuarter((uint)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((uint)abs(value), overflowValue, promiseNoOverflow);

                return new quarter((byte)(((value >> 24) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(int i)
        {
            return IntToQuarter(i, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter LongToQuarter(long value, quarter overflowValue, bool promiseNoOverflow = false, bool promiseAbs = false)
        {
            if (promiseAbs || constexpr.IS_TRUE(value >= 0))
            {
                return ULongToQuarter((uint)value, overflowValue);
            }
            else
            {
                quarter absQ = GetInteger((ulong)abs(value), overflowValue, promiseNoOverflow);

                return new quarter((byte)(((value >> 56) & 0b1000_0000) | absQ.value));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(long l)
        {
            return LongToQuarter(l, PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter Int128ToQuarter(Int128 value, quarter overflowValue)
        {
            if (constexpr.IS_TRUE(value >= 0))
            {
                return ULongToQuarter((uint)value, overflowValue);
            }
            else
            {
                bool overflowHi64 = value.hi64 + 1 > 1; // any other value than -1 or 0

                return overflowHi64 ? new quarter((byte)(overflowValue.value | (value.hi64 >> 56) & 0b1000_0000))
                                    : LongToQuarter((long)value.lo64, overflowValue);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(Int128 ll)
        {
            return Int128ToQuarter(ll, quarter.PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half(quarter q)
        {
            const int EXPONENT_OFFSET = -F16_EXPONENT_BIAS + EXPONENT_BIAS;
            FloatingPointPromise<quarter> promise = new FloatingPointPromise<quarter>(q);

            uint sign = (uint)(q.value >> 7) << 15;
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
                if (!(promise.NotNaN 
                   && promise.NotInf)
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
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_ss(Xse.cvtsi32_si128(q.value)).Float0;
            }
            else
            {
                uint fusedExponentMantissa = ((uint)q.value << F32_SHL_LOSE_SIGN) >> F32_SHR_PLACE_MANTISSA;
                uint sign = ((uint)q.value >> (BITS - 1)) << (F32_BITS - 1);

                bool nanInf = (q.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT;
                uint ifNanInf = asuint(float.PositiveInfinity) & (uint)(-tobyte(nanInf));
                uint f64 = fusedExponentMantissa | ifNanInf;

                return asfloat(sign | f64) * asfloat(nanInf ? f64 : F32_MAGIC);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float QuarterToFloatInRange(quarter q)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_ss(Xse.cvtsi32_si128(q.value), true, false).Float0;
            }
            else
            {
                uint fusedExponentMantissa = ((uint)q.value << F32_SHL_LOSE_SIGN) >> F32_SHR_PLACE_MANTISSA;
                uint sign = ((uint)q.value >> (BITS - 1)) << (F32_BITS - 1);

                return asfloat(F32_MAGIC) * asfloat(sign | fusedExponentMantissa);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float QuarterToFloatInRangeAbs(quarter q)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_ss(Xse.cvtsi32_si128(q.value), true, true).Float0;
            }
            else
            {
                uint fusedExponentMantissa = (uint)q.value << (F32_SHL_LOSE_SIGN - F32_SHR_PLACE_MANTISSA);

                return asfloat(F32_MAGIC) * asfloat(fusedExponentMantissa);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(quarter q)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_sd(Xse.cvtsi32_si128(q.value), false, false).Double0;
            }
            else
            {
                ulong fusedExponentMantissa = ((ulong)q.value << F64_SHL_LOSE_SIGN) >> F64_SHR_PLACE_MANTISSA;
                ulong sign = ((ulong)q.value >> (BITS - 1)) << (F64_BITS - 1);

                bool nanInf = (q.value & SIGNALING_EXPONENT) == SIGNALING_EXPONENT;
                ulong ifNanInf = asulong(double.PositiveInfinity) & (ulong)(-tobyte(nanInf));
                ulong f64 = fusedExponentMantissa | ifNanInf;

                return asdouble(sign | f64) * asdouble(nanInf ? f64 : F64_MAGIC);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double QuarterToDoubleInRange(quarter q)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_sd(Xse.cvtsi32_si128(q.value), true, false).Double0;
            }
            else
            {
                ulong fusedExponentMantissa = ((ulong)q.value << F64_SHL_LOSE_SIGN) >> F64_SHR_PLACE_MANTISSA;
                ulong sign = ((ulong)q.value >> (BITS - 1)) << (F64_BITS - 1);

                return asdouble(F64_MAGIC) * asdouble(sign | fusedExponentMantissa);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double QuarterToDoubleInRangeAbs(quarter q)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.cvtsq_sd(Xse.cvtsi32_si128(q.value), true, true).Double0;
            }
            else
            {
                ulong fusedExponentMantissa = (ulong)q.value << (F64_SHL_LOSE_SIGN - F64_SHR_PLACE_MANTISSA);

                return asdouble(F64_MAGIC) * asdouble(fusedExponentMantissa);
            }
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
                    bool notBothZero = new quarter((byte)(this.value | other.value)).IsNotZero;

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
                    bool notBothZero = new quarter((byte)(this.value | other.value)).IsNotZero;

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
            return new quarter((byte)(value.value ^ 0b1000_0000));
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