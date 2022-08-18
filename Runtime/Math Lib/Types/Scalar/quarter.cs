using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       An 8-bit 1.3.4.-3 IEEE 754 floating point number, often called a "mini-float".       </summary>
    [Serializable] 
    [DebuggerTypeProxy(typeof(quarter.DebuggerProxy))]
    unsafe public readonly partial struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal sealed class DebuggerProxy
        {
            public quarter value;

            public DebuggerProxy(quarter v)
            {
                value = v;
            }
        }


        internal quarter(byte value)
        {
            this.value = value;
        }

        
        // Change the number of exponent bits ("->3<- + (SIGN_BIT ? 0 : 1)")
        // And everything will fall into place correctly
        // is what I'd LIKE to say; q -> f works, f -> q does not 
        internal const bool IEEE_754_STANDARD = true;                                                                            //standard: true
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                                                                //standard: true
        internal const int BITS = 8 * sizeof(byte);                                                                              //standard: 8
        internal const int SET_SIGN_BIT = (SIGN_BIT ? 1 : 0) << (BITS - 1);                                                      //standard: 0b1000_0000
        internal const int EXPONENT_BITS = 3 + (SIGN_BIT ? 0 : 1);                                                               //standard: 3
        internal const int MANTISSA_BITS = BITS - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);                                            //standard: 4
        internal const int EXPONENT_BIAS = -(((1 << BITS) - 1) >> (BITS - (EXPONENT_BITS - 1)));                                 //standard: -3
        internal const int MAX_EXPONENT = EXPONENT_BIAS + ((1 << EXPONENT_BITS) - 1) - (IEEE_754_STANDARD ? 1 : 0);              //standard: 3
        internal const int SIGNALING_EXPONENT = (MAX_EXPONENT - EXPONENT_BIAS + (IEEE_754_STANDARD ? 1 : 0)) << MANTISSA_BITS;   //standard: 0b0111_0000                     
        
        internal const int F32_SHL_LOSE_SIGN       = (F32_BITS - (MANTISSA_BITS + EXPONENT_BITS));
        internal const int F32_SHR_PLACE_MANTISSA  = MANTISSA_BITS + ((1 + F32_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const int F32_MAGIC               = (((1 << F32_EXPONENT_BITS) - 1) - (1 + EXPONENT_BITS)) << F32_MANTISSA_BITS;

        internal const int  F64_SHL_LOSE_SIGN      = (F64_BITS - (MANTISSA_BITS + EXPONENT_BITS));
        internal const int  F64_SHR_PLACE_MANTISSA = MANTISSA_BITS + ((1 + F64_EXPONENT_BITS) - (MANTISSA_BITS + EXPONENT_BITS));
        internal const long F64_MAGIC              = (((1L << F64_EXPONENT_BITS) - 1) - (1 + EXPONENT_BITS)) << F64_MANTISSA_BITS;


        public readonly byte value;


        #region CONSTANTS
        /// <summary>       0.015625 as a <see cref="float"/>.      </summary>
        public static quarter Epsilon => new quarter(1);

        /// <summary>       -15.5 as a <see cref="float"/>.      </summary>
        public static quarter MinValue => new quarter(SET_SIGN_BIT | (SIGNALING_EXPONENT - 1));

        /// <summary>       15.5 as a <see cref="float"/>.      </summary>
        public static quarter MaxValue => new quarter(SIGNALING_EXPONENT - 1);

        public static quarter Zero => new quarter(0);
        public static quarter NaN => new quarter(SIGNALING_EXPONENT | 1);
        public static quarter NegativeInfinity => new quarter(SET_SIGN_BIT | SIGNALING_EXPONENT);
        public static quarter PositiveInfinity => new quarter(SIGNALING_EXPONENT);
        #endregion
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsZero(quarter q)
        {
            return (q.value & ~SET_SIGN_BIT) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsNotZero(quarter q)
        {
            return (q.value & ~SET_SIGN_BIT) != 0;
        }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static bool IsSubnormal(quarter q)
        //{
        //    return (q.value & (SIGNALING_EXPONENT | SIGN_BIT_MASK)) == 0u;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsNegativeInfinity(quarter q)
        //{
        //    return q.value == NegativeInfinity.value;
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsPositiveInfinity(quarter q)
        //{
        //    return q.value == PositiveInfinity.value;
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Truncate(quarter q)
        //{
        //    return trunc((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Floor(quarter q)
        //{
        //    return floor((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Ceiling(quarter q)
        //{
        //    return ceil((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Round(quarter q)
        //{
        //    return round((float)q);
        //}

        #region TYPE_CONVERISON
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(half h)
        {
            return (quarter)(float)h;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(float f)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtss_sq(RegisterConversion.ToV128(f)).Byte0);
            }
            else
            {
                quarter q = FloatToQuarterInRangeAbs(f);
                
                uint f32_exponent = asuint(f) & F32_SIGNALING_EXPONENT;
                bool overflow = f32_exponent > ((-F32_EXPONENT_BIAS + MAX_EXPONENT) << F32_MANTISSA_BITS); 
                bool notNaNInf = f32_exponent != F32_SIGNALING_EXPONENT; 
                uint f8_sign = asuint(f) >> (F32_BITS - 1);
                f8_sign ^= tobyte(!notNaNInf);
                f8_sign <<= (BITS - 1);
                if (overflow & notNaNInf)
                {
                    q = PositiveInfinity;
                }

                return new quarter((byte)(q.value ^ f8_sign));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FloatToQuarterInRange(float f)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtss_sq(RegisterConversion.ToV128(f), promiseInRange: true).Byte0);
            }
            else
            {
                quarter q = FloatToQuarterInRangeAbs(f);
                uint f8_sign = (asuint(f) >> (F32_BITS - 1)) << (BITS - 1);

                return new quarter((byte)(q.value ^ f8_sign));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter FloatToQuarterInRangeAbs(float f)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtss_sq(RegisterConversion.ToV128(f), promiseAbsoluteAndInRange: true).Byte0);
            }
            else
            {
                float inRange = f * (1f / asfloat(F32_MAGIC));
                uint q = asuint(inRange) >> (F32_MANTISSA_BITS - (1 + EXPONENT_BITS));
                q |= ((1 << (F32_MANTISSA_BITS - MANTISSA_BITS - 1)) & asuint(inRange)) >> (F32_MANTISSA_BITS - MANTISSA_BITS - 1);

                return new quarter((byte)q);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(double d)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtsd_sq(RegisterConversion.ToV128(d)).Byte0);
            }
            else
            {
                quarter q = DoubleToQuarterInRangeAbs(d);
                
                long f64_exponent = aslong(d) & F64_SIGNALING_EXPONENT;
                bool overflow = f64_exponent > ((long)(-F64_EXPONENT_BIAS + MAX_EXPONENT) << F64_MANTISSA_BITS); 
                bool notNaNInf = f64_exponent != F64_SIGNALING_EXPONENT; 
                ulong f8_sign = asulong(d) >> (F64_BITS - 1);
                f8_sign ^= tobyte(!notNaNInf);
                f8_sign <<= (BITS - 1);
                if (overflow & notNaNInf)
                {
                    q = PositiveInfinity;
                }

                return new quarter((byte)(q.value ^ f8_sign));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter DoubleToQuarterInRange(double d)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtsd_sq(RegisterConversion.ToV128(d), promiseInRange: true).Byte0);
            }
            else
            {
                quarter q = DoubleToQuarterInRangeAbs(d);
                ulong f8_sign = (asulong(d) >> (F64_BITS - 1)) << (BITS - 1);

                return new quarter((byte)(q.value ^ f8_sign));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter DoubleToQuarterInRangeAbs(double d)
        {
            if (Sse2.IsSse2Supported)
            {
                return new quarter(Vectorized.cvtsd_sq(RegisterConversion.ToV128(d), promiseAbsoluteAndInRange: true).Byte0);
            }
            else
            {
                double inRange = d * (1d / asdouble(F64_MAGIC));
                ulong q = asulong(inRange) >> (F64_MANTISSA_BITS - (1 + EXPONENT_BITS));
                q |= ((1L << (F64_MANTISSA_BITS - MANTISSA_BITS - 1)) & asulong(inRange)) >> (F64_MANTISSA_BITS - MANTISSA_BITS - 1);

                return new quarter((byte)q);
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
            if (promiseInRange || Xse.constexpr.IS_TRUE(i < 16ul))
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
            if (promiseAbs || Xse.constexpr.IS_TRUE(value >= 0))
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
            if (promiseAbs || Xse.constexpr.IS_TRUE(value >= 0))
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
            if (promiseAbs || Xse.constexpr.IS_TRUE(value >= 0))
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
            if (promiseAbs || Xse.constexpr.IS_TRUE(value >= 0))
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
            if (Xse.constexpr.IS_TRUE(value >= 0))
            {
                return ULongToQuarter((uint)value, overflowValue);
            }
            else
            {
                bool overflowHi64 = value.hi64 + 1 > 1; // any other value than -1 or 0
                
                return overflowHi64 ? new quarter((byte)(overflowValue.value | (value.hi64 >> 56) & SET_SIGN_BIT)) 
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
            return (half)(float)q; // No hardware implemented half multiplication, could do it by adding exponents and multiplying significands with carry but... no
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(quarter q)
        {
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_ss(Sse2.cvtsi32_si128(q.value)).Float0;
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
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_ss(Sse2.cvtsi32_si128(q.value), true, false).Float0;
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
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_ss(Sse2.cvtsi32_si128(q.value), true, true).Float0;
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
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_sd(Sse2.cvtsi32_si128(q.value), false, false).Double0;
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
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_sd(Sse2.cvtsi32_si128(q.value), true, false).Double0;
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
            if (Sse2.IsSse2Supported)
            {
                return Vectorized.cvtsq_sd(Sse2.cvtsi32_si128(q.value), true, true).Double0;
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
            return (byte)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(quarter q)
        {
            return (ushort)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(quarter q)
        {
            return (uint)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(quarter q)
        {
            return (ulong)(float)q;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(quarter q)
        {
            return (UInt128)(float)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(quarter q)
        {
            return (sbyte)(float)q;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(quarter q)
        {
            return (short)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(quarter q)
        {
            return (int)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(quarter q)
        {
            return (int)(float)q;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(quarter q)
        {
            return (int)(float)q;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter operator + (quarter value)
        {
            return value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter operator - (quarter value)
        {
            return new quarter((byte)(value.value ^ SET_SIGN_BIT));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return IsZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return IsZero(left);
            }

            bool nan   = !isnan(left) & !isnan(right);
            bool zero  = IsZero(left) & IsZero(right);
            bool value = left.value == right.value;

            return nan & (zero | value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left.IsZero()))
            {
                return IsZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left.IsZero();
            }

            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, half right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right.IsZero();
            }
            else if (Xse.constexpr.IS_TRUE(right.IsZero()))
            {
                return IsZero(left);
            }

            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return IsZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left == 0f;
            }

            return left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, float right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right == 0f;
            }
            else if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return IsZero(left);
            }

            return (float)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (double left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0d))
            {
                return IsZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left == 0d;
            }

            return left == (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, double right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right == 0d;
            }
            else if (Xse.constexpr.IS_TRUE(right == 0d))
            {
                return IsZero(left);
            }

            return (double)left == right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return IsNotZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return IsNotZero(left);
            }

            bool nan   = isnan(left) | isnan(right);
            bool zero  = !IsZero(left) | !IsZero(right);
            bool value = left.value != right.value;

            return nan | (zero & value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left.IsNotZero()))
            {
                return IsNotZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left.IsNotZero();
            }

            return (float)left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, half right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right.IsNotZero();
            }
            else if (Xse.constexpr.IS_TRUE(right.IsNotZero()))
            {
                return IsNotZero(left);
            }

            return (float)left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left != 0f))
            {
                return IsNotZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left != 0f;
            }

            return left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, float right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right != 0f;
            }
            else if (Xse.constexpr.IS_TRUE(right != 0f))
            {
                return IsNotZero(left);
            }

            return (float)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (double left, quarter right)
        {
            if (Xse.constexpr.IS_TRUE(left != 0d))
            {
                return IsNotZero(right);
            }
            else if (Xse.constexpr.IS_TRUE(IsZero(right)))
            {
                return left != 0d;
            }

            return left != (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, double right)
        {
            if (Xse.constexpr.IS_TRUE(IsZero(left)))
            {
                return right != 0d;
            }
            else if (Xse.constexpr.IS_TRUE(right != 0d))
            {
                return IsNotZero(left);
            }

            return (double)left != right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (quarter left, quarter right)
        {
            return (float)left < (float)right;
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
        public static bool operator > (quarter left, quarter right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (half left, quarter right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, half right)
        {
            return (float)left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (float left, quarter right)
        {
            return left > (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, float right)
        {
            return (float)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (double left, quarter right)
        {
            return left > (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (quarter left, double right)
        {
            return (double)left > right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (quarter left, quarter right)
        {
            return (float)left <= (float)right;
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
        public static bool operator >= (quarter left, quarter right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, quarter right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, half right)
        {
            return (float)left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float left, quarter right)
        {
            return left >= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, float right)
        {
            return (float)left >= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double left, quarter right)
        {
            return left >= (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, double right)
        {
            return (double)left >= right;
        }


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
            return Convert.ToBoolean(IsNotZero(this), provider);
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