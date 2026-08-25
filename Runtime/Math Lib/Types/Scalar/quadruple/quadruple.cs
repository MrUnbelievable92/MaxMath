using System;
using System.Runtime.CompilerServices;

using static MaxMath.math;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    /// <summary>       A 128-bit 1.15.112.-16383 IEEE 754 floating point number.       </summary>
    [Serializable]
    unsafe public partial struct quadruple : IComparable, IComparable<quadruple>, IConvertible, IEquatable<quadruple>, IFormattable
    {
        internal const bool IEEE_754_STANDARD = true;                                                                                                    //standard: true
        internal const bool SIGN_BIT = IEEE_754_STANDARD || true;                                                                                        //standard: true
        internal const bool SIGNALING_NAN = false;                                                                                                       //standard: false
        internal const int BITS = 2 * 8 * sizeof(ulong);                                                                                                 //standard: 128
        internal const int SET_SIGN_BIT = (SIGN_BIT ? 1 : 0) << (BITS - 1);                                                                              //standard: 1 << 127
        internal const int EXPONENT_BITS = 15 + (SIGN_BIT ? 0 : 1);                                                                                      //standard: 15
        internal const int MANTISSA_BITS = BITS - EXPONENT_BITS - (SIGN_BIT ? 1 : 0);                                                                    //standard: 112
        internal const int MANTISSA_BITS_HI64 = MANTISSA_BITS - 8 * sizeof(ulong);                                                                       //standard: 48
        internal const int EXPONENT_BIAS = -((1 << (EXPONENT_BITS - 1)) - 1);                                                                            //standard: -16383
        internal const int MAX_UNBIASED_EXPONENT = -EXPONENT_BIAS;                                                                                       //standard: 16383
        internal const int MIN_UNBIASED_EXPONENT = EXPONENT_BIAS + 1;                                                                                    //standard: -16382
        internal static UInt128 SIGNALING_EXPONENT => (UInt128)(MAX_UNBIASED_EXPONENT - EXPONENT_BIAS + (IEEE_754_STANDARD ? 1 : 0)) << MANTISSA_BITS;   //standard: 0x7FFF << 112

        internal const int F8_EXPONENT_OFFSET = -EXPONENT_BIAS + quarter.EXPONENT_BIAS;
        internal const int F16_EXPONENT_OFFSET = -EXPONENT_BIAS + half.EXPONENT_BIAS;
        internal const int F32_EXPONENT_OFFSET = -EXPONENT_BIAS + F32_EXPONENT_BIAS;
        internal const int F64_EXPONENT_OFFSET = -EXPONENT_BIAS + F64_EXPONENT_BIAS;


        public UInt128 value;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal quadruple(ulong lo64, ulong hi64)
        {
            value = new UInt128(lo64, hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(bool x)
        {
            this = x ? 1 : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(byte x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(sbyte x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(ushort x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(short x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(uint f)
        {
            this = f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(int f)
        {
            this = f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(ulong d)
        {
            this = d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(long d)
        {
            this = d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(UInt128 d)
        {
            this = d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(Int128 d)
        {
            this = d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(quarter x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(half x)
        {
            this = x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(float f)
        {
            this = f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(double d)
        {
            this = d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quadruple(quadruple d)
        {
            this = d;
        }


        #region CONSTANTS
        /// <summary>   Approximately 6.47e-4966    </summary>
        public static quadruple Epsilon => new quadruple(1, 0);
        /// <summary>   Approximately 1.19e+4932    </summary>
        public static quadruple MaxValue => new quadruple{ value = SIGNALING_EXPONENT - 1 };
        /// <summary>   Approximately -1.19e+4932    </summary>
        public static quadruple MinValue => -MaxValue;
        public static quadruple Zero => new quadruple(0);
        public static quadruple NaN => new quadruple{ value = SIGNALING_EXPONENT | ((UInt128)1 << (MANTISSA_BITS - 1)) };
        public static quadruple PositiveInfinity => new quadruple{ value = SIGNALING_EXPONENT };
        public static quadruple NegativeInfinity => -PositiveInfinity;
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quadruple(bool q) => q ? 1 : 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool(quadruple q) => andnot(q != 0, isnan(q));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(quadruple q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(quadruple q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(quadruple q) => (bool)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(quadruple q) => (half2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(quadruple q) => (half3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(quadruple q) => (half4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float2(quadruple q) => (float2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float3(quadruple q) => (float3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.float4(quadruple q) => (float4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double2(quadruple q) => (double2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double3(quadruple q) => (double3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.double4(quadruple q) => (double4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(quadruple q) => (uint2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(quadruple q) => (uint3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(quadruple q) => (uint4)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(quadruple q) => (int2)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(quadruple q) => (int3)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(quadruple q) => (int4)q;


        public readonly int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public readonly int CompareTo(quadruple other)
        {
            return compareto(this, other);
        }


        public readonly TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public readonly bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public readonly ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode() => (int)math.hash(this);

        public readonly bool Equals(quadruple other)
        {
            return this == other;
        }

        public override readonly bool Equals(object obj) => obj is quadruple converted && this.Equals(converted);
    }
}
