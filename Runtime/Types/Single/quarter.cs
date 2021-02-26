using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using System.Globalization;

namespace MaxMath
{
    /// <summary>       An 8-bit IEEE 754 floating point number, often called a "mini-float".        </summary>
    [Serializable]  [DebuggerTypeProxy(typeof(quarter.DebuggerProxy))]
    public struct quarter : IEquatable<quarter>, IComparable<quarter>, IComparable, IFormattable, IConvertible
    {
        internal sealed class DebuggerProxy
        {
            public quarter value;

            public DebuggerProxy(quarter v)
            {
                value = v;
            }
        }


        // changing any of these values does currently not work.
        internal const bool IEEE_754_STANDARD = true;                                    //standard: true
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                        //standard: true

        internal const int EXPONENT_BITS = 3 + (SIGN_BIT ? 0 : 1);                       //standard: 3
        internal const int MANTISSA_BITS = 8 - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);       //standard: 4
        internal const int EXPONENT_BIAS = -(255 >> (8 - (EXPONENT_BITS - 1)));          //standard: -3


        public byte value;


        #region CONSTANTS
        /// <summary>       0.015625 as a float value.       </summary>
        public static quarter Epsilon => new quarter { value = 0b0000_0001 };

        /// <summary>       -15.5 as a float value.       </summary>
        public static quarter MinValue => new quarter { value = 0b1110_1111 };

        /// <summary>       15.5 as a float value.       </summary>
        public static quarter MaxValue => new quarter { value = 0b0110_1111 };

        public static quarter Zero => default;
        public static quarter NaN => new quarter { value = 0b0111_1000 };
        public static quarter NegativeInfinity => new quarter { value = 0b1111_0000 };
        public static quarter PositiveInfinity => new quarter { value = 0b0111_0000 };
        #endregion

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static bool IsSubnormal(quarter q)
        //{
        //    return !IsZero(q) & ((q.value & 0b0111_0000u) == 0u);
        //}
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsZero(quarter q)
        {
            return (q.value & 0b0111_1111u) == 0u;
        }
        
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsNegativeInfinity(quarter q)
        //{
        //    return q.value == 0b1111_0000;
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static bool IsPositiveInfinity(quarter q)
        //{
        //    return q.value == 0b0111_0000;
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Truncate(quarter q)
        //{
        //    return math.trunc((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Floor(quarter q)
        //{
        //    return math.floor((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Ceiling(quarter q)
        //{
        //    return math.ceil((float)q);
        //}
        //
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static float Round(quarter q)
        //{
        //    return math.round((float)q);
        //}

        #region TYPE_CONVERISON
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(half h)
        {
            byte f8_sign      = (byte)(((uint)h.value >> 15) << 7);
            uint f16_exponent = ((uint)h.value << 1) >> 11;
            

            if (f16_exponent < 8) // underflow => preserve +/- 0
            {
                return new quarter { value = f8_sign };
            }
            else if (f16_exponent > 18) // overflow => +/- infinity or preserve NaN
            {
                return new quarter { value = (byte)(f8_sign | PositiveInfinity.value | maxmath.touint8(maxmath.isnan(h))) };
            }
            else
            {
                uint f16_mantissa = h.value & 0x03FFu;

                int cmp = 13 - (int)f16_exponent;
                int cmpIsZeroOrNegativeMask = (cmp - 1) >> 31;
                
                int denormalExponent = maxmath.andnot(0b0001_0000 >> cmp, cmpIsZeroOrNegativeMask);        // special case 9: sets it to quarter.Epsilon
                denormalExponent += maxmath.touint8((f16_exponent == 9) & (f16_mantissa >= 0x0200));       // case 9: 2^(-6) * (1 + mantissa): return +/- quarter.Epsilon = 2^(-2) * 2^(-4); if the mantissa is >= 0.5 return 2^(-2) * 2^(-3) 
                int mantissaIfSmallerEpsilon = maxmath.touint8((f16_mantissa == 8) & (f16_mantissa != 0)); // case 8: 2^(-7) * 1.(mantissa > 0) means the value is closer to quarter.epsilon than 0

                int normalExponent = (cmpIsZeroOrNegativeMask & ((int)f16_exponent - (15 + EXPONENT_BIAS))) << MANTISSA_BITS;

                int mantissaShift = 6 + maxmath.andnot(cmp, cmpIsZeroOrNegativeMask);
                

                return new quarter { value = (byte)((f8_sign | normalExponent) | (denormalExponent | mantissaIfSmallerEpsilon) | (int)(f16_mantissa >> mantissaShift)) };
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(float f)
        {
            byte f8_sign      = (byte)((math.asuint(f) >> 31) << 7);
            uint f32_exponent = (math.asuint(f) << 1) >> 24;
            

            if (f32_exponent < 120) // underflow => preserve +/- 0
            {
                return new quarter { value = f8_sign };
            }
            else if (f32_exponent > 130) // overflow => +/- infinity or preserve NaN
            {
                return new quarter { value = (byte)(f8_sign | PositiveInfinity.value | maxmath.touint8(math.isnan(f))) };
            }
            else
            {
                uint f32_mantissa = math.asuint(f) & 0x007F_FFFFu;

                int cmp = 125 - (int)f32_exponent;
                int cmpIsZeroOrNegativeMask = (cmp - 1) >> 31;
                
                int denormalExponent = maxmath.andnot(0b0001_0000 >> cmp, cmpIsZeroOrNegativeMask);          // special case 121: sets it to quarter.Epsilon
                denormalExponent += maxmath.touint8((f32_exponent == 121) & (f32_mantissa >= 0x0040_0000));  // case 121: 2^(-6) * (1 + mantissa): return +/- quarter.Epsilon = 2^(-2) * 2^(-4); if the mantissa is >= 0.5 return 2^(-2) * 2^(-3) 
                int mantissaIfSmallerEpsilon = maxmath.touint8((f32_exponent == 120) & (f32_mantissa != 0)); // case 120: 2^(-7) * 1.(mantissa > 0) means the value is closer to quarter.epsilon than 0

                int normalExponent = (cmpIsZeroOrNegativeMask & ((int)f32_exponent - (127 + EXPONENT_BIAS))) << MANTISSA_BITS;

                int mantissaShift = 19 + maxmath.andnot(cmp, cmpIsZeroOrNegativeMask);
                

                return new quarter { value = (byte)((f8_sign | normalExponent) | (denormalExponent | mantissaIfSmallerEpsilon) | (int)(f32_mantissa >> mantissaShift)) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(double d)
        {
            byte f8_sign      = (byte)((math.asulong(d) >> 63) << 7);
            uint f64_exponent = (uint)((math.asulong(d) << 1) >> 53);
            

            if (f64_exponent < 1016) // underflow => preserve +/- 0
            {
                return new quarter { value = f8_sign };
            }
            else if (f64_exponent > 1026) // overflow => +/- infinity or preserve NaN
            {
                return new quarter { value = (byte)(f8_sign | PositiveInfinity.value | maxmath.touint8(math.isnan(d))) };
            }
            else
            {
                ulong f64_mantissa = (math.asulong(d) << 12) >> 12;

                int cmp = 1021 - (int)f64_exponent;
                int cmpIsZeroOrNegativeMask = (cmp - 1) >> 31;
                
                int denormalExponent = maxmath.andnot(0b0001_0000 >> cmp, cmpIsZeroOrNegativeMask);                      // special case 1017: sets it to quarter.Epsilon
                denormalExponent += maxmath.touint8((f64_exponent == 1017) & (f64_mantissa >= 0x0008_0000_0000_0000ul)); // case 1017: 2^(-6) * (1 + mantissa): return +/- quarter.Epsilon = 2^(-2) * 2^(-4); if the mantissa is >= 0.5 return 2^(-2) * 2^(-3) 
                int mantissaIfSmallerEpsilon = maxmath.touint8((f64_mantissa == 1016) & (f64_mantissa != 0));            // case 1016: 2^(-7) * 1.(mantissa > 0) means the value is closer to quarter.epsilon than 0

                int normalExponent = (cmpIsZeroOrNegativeMask & ((int)f64_exponent - (1023 + EXPONENT_BIAS))) << MANTISSA_BITS;

                int mantissaShift = 48 + maxmath.andnot(cmp, cmpIsZeroOrNegativeMask);
                

                return new quarter { value = (byte)((f8_sign | normalExponent) | (denormalExponent | mantissaIfSmallerEpsilon) | (int)(f64_mantissa >> mantissaShift)) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(decimal d)
        {
            return (quarter)(float)d;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(byte b)
        {
            if (b > 15)
            {
                return PositiveInfinity;
            }
            else
            {
                float f = b;

                uint f32 = math.asuint(f) - ((127 + EXPONENT_BIAS) << 23);
                uint notZeroMask = (uint)-maxmath.touint8(b != 0);

                return new quarter { value = (byte)(notZeroMask & (f32 >> 19)) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ushort us)
        {
            if (us > 15)
            {
                return PositiveInfinity;
            }
            else
            {
                float f = us;

                uint f32 = math.asuint(f) - ((127 + EXPONENT_BIAS) << 23);
                uint notZeroMask = (uint)-maxmath.touint8(us != 0);

                return new quarter { value = (byte)(notZeroMask & (f32 >> 19)) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(uint ui)
        {
            if (ui > 15)
            {
                return PositiveInfinity;
            }
            else
            {
                float f = ui;

                uint f32 = math.asuint(f) - ((127 + EXPONENT_BIAS) << 23);
                uint notZeroMask = (uint)-maxmath.touint8(ui != 0);

                return new quarter { value = (byte)(notZeroMask & (f32 >> 19)) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(ulong ul)
        {
            if (ul > 15)
            {
                return PositiveInfinity;
            }
            else
            {
                float f = ul;

                uint f32 = math.asuint(f) - ((127 + EXPONENT_BIAS) << 23);
                uint notZeroMask = (uint)-maxmath.touint8(ul != 0);

                return new quarter { value = (byte)(notZeroMask & (f32 >> 19)) };
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(sbyte sb)
        {
            int sign = sb & 0b1000_0000;
            int abs = math.abs(sb);

            if (abs > 15)
            {
                return new quarter { value = (byte)(sign | PositiveInfinity.value) };
            }
            else
            {
                float f = abs;

                int f32 = math.asint(f) - ((127 + EXPONENT_BIAS) << 23);
                int notZeroMask = -maxmath.touint8(abs != 0);

                return new quarter { value = (byte)(sign | (notZeroMask & (f32 >> 19))) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(short s)
        {
            int sign = (int)((uint)(int)s >> 31) << 7;
            int abs = math.abs(s);

            if (abs > 15)
            {
                return new quarter { value = (byte)(sign | PositiveInfinity.value) };
            }
            else
            {
                float f = abs;

                int f32 = math.asint(f) - ((127 + EXPONENT_BIAS) << 23);
                int notZeroMask = -maxmath.touint8(abs != 0);

                return new quarter { value = (byte)(sign | (notZeroMask & (f32 >> 19))) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(int i)
        {
            int sign = (int)((uint)i >> 31) << 7;
            int abs = math.abs(i);

            if (abs > 15)
            {
                return new quarter { value = (byte)(sign | PositiveInfinity.value) };
            }
            else
            {
                float f = abs;

                int f32 = math.asint(f) - ((127 + EXPONENT_BIAS) << 23);
                int notZeroMask = -maxmath.touint8(abs != 0);

                return new quarter { value = (byte)(sign | (notZeroMask & (f32 >> 19))) };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter(long l)
        {
            int sign = (int)((ulong)l >> 63) << 7;
            long abs = math.abs(l);

            if (abs > 15)
            {
                return new quarter { value = (byte)(sign | PositiveInfinity.value) };
            }
            else
            {
                float f = abs;

                int f32 = math.asint(f) - ((127 + EXPONENT_BIAS) << 23);
                int notZeroMask = -maxmath.touint8(abs != 0);

                return new quarter { value = (byte)(sign | (notZeroMask & (f32 >> 19))) };
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half(quarter q)
        {
            return (half)(float)q; // No hardware implemented half multiplication, could do it by adding exponents and multiplying significands with carray but... no
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(quarter q)
        {
            int sign = (int)(((uint)q.value >> 7) << 31);
            int fusedExponentMantissa = (int)(((uint)q.value << (32 - (MANTISSA_BITS + EXPONENT_BITS))) >> 6);


            if ((q.value & 0b0111_0000) == 0b0111_0000) // NaN/Infinity
            {
                return math.asfloat(sign | (255 << 23) | fusedExponentMantissa);
            }
            else // normal and subnormal
            {
                float magic = math.asfloat((255 - 1 + EXPONENT_BIAS) << 23);

                return magic * math.asfloat(sign | fusedExponentMantissa);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(quarter q)
        {
            long sign = (long)(((ulong)q >> 7) << 63);
            long fusedExponentMantissa = (long)(((ulong)q.value << (64 - (MANTISSA_BITS + EXPONENT_BITS))) >> 9);


            if ((q.value & 0b0111_0000) == 0b0111_0000) // NaN/Infinity
            {
                return math.asdouble(sign | (2047L << 52) | fusedExponentMantissa);
            }
            else // normal and subnormal
            {
                double magic = math.asdouble((2047L - 1 + EXPONENT_BIAS) << 52);

                return magic * math.asdouble(sign | fusedExponentMantissa);
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
            return (uint)(float)q;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(quarter q)
        {
            return (sbyte)(float)q;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(quarter q)
        {
            return (short)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(quarter q)
        {
            return (int)(float)q;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(quarter q)
        {
            return (int)(float)q;
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
            value.value ^= 0b1000_0000;

            return value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, quarter right)
        {
            bool nan   = !maxmath.isnan(left) & !maxmath.isnan(right);
            bool zero  = IsZero(left) & IsZero(right);
            bool value = left.value == right.value;

            return nan & (zero | value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (half left, quarter right)
        {
            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, half right)
        {
            return (float)left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float left, quarter right)
        {
            return left == (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, float right)
        {
            return (float)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (double left, quarter right)
        {
            return left == (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (quarter left, double right)
        {
            return (double)left == right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, quarter right)
        {
            bool nan   = maxmath.isnan(left) | maxmath.isnan(right);
            bool zero  = !IsZero(left) | !IsZero(right);
            bool value = left.value != right.value;

            return nan | (zero & value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (half left, quarter right)
        {
            return (float)left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, half right)
        {
            return (float)left != (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float left, quarter right)
        {
            return left < (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, float right)
        {
            return (float)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (double left, quarter right)
        {
            return left < (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (quarter left, double right)
        {
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
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (half left, quarter right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, half right)
        {
            return (float)left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float left, quarter right)
        {
            return left <= (float)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, float right)
        {
            return (float)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double left, quarter right)
        {
            return left <= (double)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (quarter left, double right)
        {
            return (double)left <= right;
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

        #region COMPARE_TO
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(quarter other)
        {
            return maxmath.compareto((float)this, (float)other);
        }
        public int CompareTo(object obj)
        {
            return CompareTo((quarter)obj);
        }
        #endregion

        #region EQUALS
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public  bool Equals(quarter other)
        {
            return this == other;
        }
        public override  bool Equals(object obj)
        {
            return Equals((quarter)obj);
        }
        #endregion

        #region GET_HASH_CODE
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override  int GetHashCode()
        {
            return value;
        }
        #endregion

        #region TO_STRING
        public override  string ToString()
        {
            return ((float)this).ToString();
        }
        public  string ToString(IFormatProvider provider)
        {
            return ((float)this).ToString(provider);
        }
        public  string ToString(string format)
        {
            return ((float)this).ToString(format);
        }
        public  string ToString(string format, IFormatProvider provider)
        {
            return ((float)this).ToString(format, provider);
        }
        #endregion

        #region ICONVERTIBLE
        public TypeCode GetTypeCode()
        {
            return TypeCode.Single;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(!IsZero(this), provider);
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