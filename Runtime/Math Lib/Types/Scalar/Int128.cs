using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using DevTools;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class Int128DebuggerProxy
    {
        public BigInteger value;

        public Int128DebuggerProxy(Int128 v)
        {
            value = v;
        }
    }

    [DebuggerTypeProxy(typeof(UInt128DebuggerProxy))]
#endif
    [Serializable]
    unsafe public readonly partial struct Int128 : IComparable, IComparable<Int128>, IConvertible, IEquatable<Int128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        internal readonly UInt128 value;

        public readonly ulong lo64 => value.lo64;
        public readonly ulong hi64 => value.hi64;

        internal readonly bool IsZero => this == 0;
        internal readonly bool IsNotZero => this != 0;
        internal readonly bool IsMaxValue => this == MaxValue;
        internal readonly bool IsNotMaxValue => this != MaxValue;

        /// <summary>       -170.141.183.460.469.231.731.687.303.715.884.105.728     </summary>
        public static Int128 MinValue => new Int128(0, 1ul << 63);
        /// <summary>       170.141.183.460.469.231.731.687.303.715.884.105.727     </summary>
        public static Int128 MaxValue => new Int128(ulong.MaxValue, long.MaxValue);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(ulong lo, ulong hi)
        {
            value = new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(long lo, long hi)
            : this((ulong)lo, (ulong)hi) { }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(bool x)
        {
            this = new Int128(x ? 1 : 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(byte x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(sbyte x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(ushort x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(short x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(uint f)
        {
            this = (Int128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(int f)
        {
            this = (Int128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(ulong d)
        {
            this = (Int128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(long d)
        {
            this = (Int128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(UInt128 d)
        {
            this = (Int128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(Int128 d)
        {
            this = (Int128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(quarter x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(half x)
        {
            this = (Int128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(float f)
        {
            this = (Int128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(double d)
        {
            this = (Int128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(quadruple d)
        {
            this = (Int128)d;
        }


        #region Conversion
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(bool q) => q ? (Int128)1 : (Int128)0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool(Int128 q) => q.IsNotZero;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(Int128 q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(Int128 q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(Int128 q) => (bool)q;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(Guid value)
        {
            return *(Int128*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(string value)
        {
            return Parse(value);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(UInt128 value)
        {
            return new Int128(value.lo64, value.hi64);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(byte value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(ushort value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(uint value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(ulong value) => (Int128)(UInt128)value;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(sbyte value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(short value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(int value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(long value) => (Int128)(UInt128)value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(BigInteger value)
        {
            return value.Sign == -1 ? -(Int128)(UInt128)BigInteger.Abs(value) : (Int128)(UInt128)value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(float value)
        {
            return (Int128)BASE_cvtf32i128(value, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(double value)
        {
            return (Int128)BASE_cvtf64i128(value, signed: true, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(decimal value)
        {
            return negateif((Int128)(UInt128)value, value < 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Int128(Unity.Mathematics.half value)
        {
            return (Int128)(half)value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Guid(Int128 value)
        {
            return *(Guid*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte(Int128 value) => (byte)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator ushort(Int128 value) => (ushort)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint(Int128 value) => (uint)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator ulong(Int128 value) => (ulong)value.value;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator sbyte(Int128 value) => (sbyte)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator short(Int128 value) => (short)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int(Int128 value) => (int)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator long(Int128 value) => (long)value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float(Int128 value)
        {
            if (value < 0)
            {
                return -((float)(UInt128)(-value));
            }
            else
            {
                return (float)(UInt128)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator double(Int128 value)
        {
            if (value < 0)
            {
                return -((double)(UInt128)(-value));
            }
            else
            {
                return (double)(UInt128)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator decimal(Int128 value)
        {
            if (value < 0)
            {
                return -((decimal)(UInt128)(-value));
            }
            else
            {
                return (decimal)(UInt128)value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator BigInteger(Int128 value)
        {
            if (value < 0)
            {
                return -((BigInteger)(UInt128)(-value));
            }
            else
            {
                return (BigInteger)(UInt128)value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half(Int128 value)
        {
            return (half)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(Int128 value)
        {
            return (half2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(Int128 value)
        {
            return (half3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(Int128 value)
        {
            return (half4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(Int128 value)
        {
            return (float2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(Int128 value)
        {
            return (float3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(Int128 value)
        {
            return (float4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(Int128 value)
        {
            return (double2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(Int128 value)
        {
            return (double3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(Int128 value)
        {
            return (double4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(Int128 value)
        {
            return (uint2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(Int128 value)
        {
            return (uint3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(Int128 value)
        {
            return (uint4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(Int128 value)
        {
            return (int2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(Int128 value)
        {
            return (int3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(Int128 value)
        {
            return (int4)value;
        }
        #endregion

        #region Operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 value)
        {
            // neg lo
            // sbb 0, hi

            ulong newLo = (ulong)-(long)value.value.lo64;
            ulong newHi = (ulong)-(long)value.value.hi64;

            return new Int128(newLo, newHi - tobyte(value.value.lo64 != 0));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ~ (Int128 value) => (Int128)~value.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ++ (Int128 value)
        {
            return (Int128)(value.value + 1u);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator -- (Int128 value)
        {
            return (Int128)(value.value - 1u);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, Int128 right) => (Int128)(left.value + right.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, long right) => left + (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (long left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, int right) => left + (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (int left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, ulong right) => (Int128)((UInt128)left + right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (ulong left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, uint right) => (Int128)((UInt128)left + right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (uint left, Int128 right) => right + left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, Int128 right) => (Int128)(left.value - right.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, long right) => left - (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (long left, Int128 right) => (Int128)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, int right) => left - (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (int left, Int128 right) => (Int128)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, ulong right) => (Int128)((UInt128)left - right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (ulong left, Int128 right) => (Int128)(left - (UInt128)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, uint right) => (Int128)((UInt128)left - right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (uint left, Int128 right) => (Int128)(left - (UInt128)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, Int128 right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (Int128)UInt128.__const.imul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return (Int128)UInt128.__const.imul(left, right);
            }

            return UInt128.imul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, long right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (Int128)UInt128.__const.imul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return (Int128)UInt128.__const.imul(left, right);
            }

            return UInt128.imul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (long left, Int128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, int right) => left * (long)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (int left, Int128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, ulong right)
        {
            if (constexpr.IS_CONST(left))
            {
                return (Int128)UInt128.__const.umul((UInt128)right, (UInt128)left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return (Int128)UInt128.__const.umul((UInt128)left, (UInt128)right);
            }

            return UInt128.imul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (ulong left, Int128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, uint right) => left * (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (uint left, Int128 right) => right * left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, Int128 right)
        {
Assert.AreNotEqual(right, (Int128)0);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.idiv(left, right);
            }
            else
            {
                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, (long)right.hi64, (UInt128)abs(left) / (UInt128)abs(right), default(UInt128));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, long right)
        {
Assert.AreNotEqual(right, 0);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.idiv(left, right);
            }
            else
            {
                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, right, (UInt128)abs(left) / (ulong)abs(right), default(UInt128));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.idiv(left, right);
            }
            else
            {
                return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out _, (long)left.hi64, 0, (UInt128)abs(left) / right, default(UInt128));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, Int128 right)
        {
Assert.AreNotEqual(right, 0);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.irem(left, right);
            }
            else
            {
                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, (long)right.hi64, default(UInt128), (UInt128)abs(left) % (UInt128)abs(right));

                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, long right)
        {
Assert.AreNotEqual(right, 0);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.irem(left, right);
            }
            else
            {
                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, right, default(UInt128), (UInt128)abs(left) % (ulong)abs(right));

                return result;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return UInt128.__const.irem(left, right);
            }
            else
            {
                Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 result, (long)left.hi64, 0, default(UInt128), (UInt128)abs(left) % right);

                return result;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (float lhs, Int128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (float lhs, Int128 rhs) => lhs - (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (float lhs, Int128 rhs) => lhs * (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (float lhs, Int128 rhs) => lhs / (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (float lhs, Int128 rhs) => lhs % (float)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (Int128 lhs, float rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (Int128 lhs, float rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (Int128 lhs, float rhs) => (float)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (Int128 lhs, float rhs) => (float)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (Int128 lhs, float rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (double lhs, Int128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (double lhs, Int128 rhs) => lhs - (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (double lhs, Int128 rhs) => lhs * (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (double lhs, Int128 rhs) => lhs / (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (double lhs, Int128 rhs) => lhs % (double)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (Int128 lhs, double rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (Int128 lhs, double rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (Int128 lhs, double rhs) => (double)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (Int128 lhs, double rhs) => (double)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (Int128 lhs, double rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs - (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs * (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs / (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs - (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs * (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs / (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs - (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs * (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs / (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs % (double4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator << (Int128 left, int n) => (Int128)(left.value << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator >> (Int128 value, int n)
        {
            Int128 result;

            n &= 127;

            if (constexpr.IS_CONST(n))
            {
                result = UInt128.__const.sarint128(value, n);
            }
            if (constexpr.IS_TRUE(value >= 0))
            {
                result = (Int128)((UInt128)value >> n);
            }
            else
            {
                int n2 = n & 63;
                bool upper = n >= 64;

                long carry      = ((long)value.hi64 << 1) << (63 - n2);
                long loCombined = (long)((ulong)value.lo64 >> n2) | carry;

                long hiShiftedArith  = (long)value.hi64 >> n2;
                long signExt         = (long)value.hi64 >> 63;

                long outHi = upper ? signExt        : hiShiftedArith;
                long outLo = upper ? hiShiftedArith : loCombined;

                result =  new Int128(outLo, outHi);
            }
            
            if (constexpr.IS_TRUE(value.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            constexpr.ASSUME(value < 0 == result < 0);
            constexpr.ASSUME(value >= 0 == result >= 0);
            if (constexpr.IS_TRUE(value >= 0))
            {
                constexpr.ASSUME(result == (Int128)((UInt128)value >> n));
            }
            constexpr.ASSUME(l1cnt(result) >= l1cnt(value));
            constexpr.ASSUME(value >= 0 ? result <= value : result >= value);

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, Int128 right) => (Int128)(left.value & right.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, long right) => left & (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (long left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, int right) => left & (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (int left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, ulong right) => new Int128(left.lo64 & right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (ulong left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, uint right) => new Int128((uint)left.lo64 & right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (uint left, Int128 right) => right & left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, Int128 right) => (Int128)(left.value | right.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, long right) => left | (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (long left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, int right) => left | (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (int left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, ulong right) => new Int128(left.lo64 | right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (ulong left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, uint right) => new Int128(left.lo64 | right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (uint left, Int128 right) => right | left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, Int128 right) => (Int128)(left.value ^ right.value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, long right) => left ^ (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (long left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, int right) => left ^ (Int128)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (int left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, ulong right) => new Int128(left.lo64 ^ right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (ulong left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, uint right) => new Int128(left.lo64 ^ right, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (uint left, Int128 right) => right ^ left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, Int128 right) => left.value == right.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, long right)
        {
            return left.lo64 == (ulong)right & left.hi64 == (ulong)(right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (long left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, int right)
        {
            return left.lo64 == (ulong)right & left.hi64 == (ulong)((long)right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (int left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, ulong right)
        {
            return left.lo64 == right & left.hi64 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (ulong left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, uint right)
        {
            return left.lo64 == right & left.hi64 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (uint left, Int128 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, Int128 right) => left.value != right.value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, long right)
        {
            return left.lo64 != (ulong)right | left.hi64 != (ulong)(right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (long left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, int right)
        {
            return left.lo64 != (ulong)right | left.hi64 != (ulong)((long)right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (int left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, ulong right)
        {
            return left.lo64 != right | left.hi64 != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (ulong left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, uint right)
        {
            return left.lo64 != right | left.hi64 != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (uint left, Int128 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, Int128 right)
        {
            bool result = cmplt(left, right);

            constexpr.ASSUME(!result || !(left == right));
            constexpr.ASSUME(!result || (left != right));
            constexpr.ASSUME(result == !(left >= right));
            constexpr.ASSUME(result == (left <= right && left != right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, long right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !(left == right));
            constexpr.ASSUME(!result || (left != right));
            constexpr.ASSUME(result == !(left >= right));
            constexpr.ASSUME(result == (left <= right && left != right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (long left, Int128 right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !(left == right));
            constexpr.ASSUME(!result || (left != right));
            constexpr.ASSUME(result == !(left >= right));
            constexpr.ASSUME(result == (left <= right && left != right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, int right) => left < (long)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (int left, Int128 right) => (long)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, ulong right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !(left == right));
            constexpr.ASSUME(!result || (left != right));
            constexpr.ASSUME(result == !(left >= right));
            constexpr.ASSUME(result == (left <= right && left != right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (ulong left, Int128 right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !(left == right));
            constexpr.ASSUME(!result || (left != right));
            constexpr.ASSUME(result == !(left >= right));
            constexpr.ASSUME(result == (left <= right && left != right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, uint right) => left < (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (uint left, Int128 right) => (ulong)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (Int128 left, Int128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (Int128 left, long right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (long left, Int128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (Int128 left, int right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (int left, Int128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (Int128 left, ulong right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (ulong left, Int128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (Int128 left, uint right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator > (uint left, Int128 right) => right < left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, Int128 right)
        {
            bool result = ((long)left.hi64 < (long)right.hi64) | ((left.hi64 == right.hi64) & (left.lo64 <= right.lo64));

            constexpr.ASSUME(result == (cmplt(left, right) || left == right));
            constexpr.ASSUME(result == !cmplt(right, left));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, long right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return ((long)left.hi64 < 0) | (left.hi64 == 0 & left.lo64 == 0);
            }
            else if ((left.hi64 == 0 && left.lo64 < (1ul << 63)) ||
                     (left.hi64 == ulong.MaxValue && left.lo64 >= (1ul << 63)))
            {
                return (long)left.lo64 <= right;
            }

            return left <= (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (long left, Int128 right)
        {
            if (constexpr.IS_TRUE(left == 0))
            {
                return (long)right.hi64 >= 0;
            }
            else if ((right.hi64 == 0 && right.lo64 < (1ul << 63)) ||
                     (right.hi64 == ulong.MaxValue && right.lo64 >= (1ul << 63)))
            {
                return left <= (long)right.lo64;
            }

            return (Int128)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, int right) => left <= (long)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (int left, Int128 right) => (long)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, ulong right)
        {
            bool result;

            if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                result = left.lo64 <= right;
            }
            else
            {
                result = left <= (Int128)right;
            }
            
            constexpr.ASSUME(result == (cmplt(left, right) || left == right));
            constexpr.ASSUME(result == !cmplt(right, left));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (ulong left, Int128 right)
        {
            bool result;

            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                result = left <= right.lo64;
            }
            else
            {
                result = (Int128)left <= right;
            }
            
            constexpr.ASSUME(result == (cmplt(left, right) || left == right));
            constexpr.ASSUME(result == !cmplt(right, left));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, uint right) => left <= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (uint left, Int128 right) => (ulong)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (Int128 left, Int128 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (Int128 left, long right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (long left, Int128 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (Int128 left, int right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (int left, Int128 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (Int128 left, ulong right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (ulong left, Int128 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (Int128 left, uint right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >= (uint left, Int128 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float lhs, Int128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float lhs, Int128 rhs) => lhs != (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (float lhs, Int128 rhs) => lhs < (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (float lhs, Int128 rhs) => lhs > (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (float lhs, Int128 rhs) => lhs <= (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float lhs, Int128 rhs) => lhs >= (float)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (Int128 lhs, float rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (Int128 lhs, float rhs) => (float)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (Int128 lhs, float rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (Int128 lhs, float rhs) => (float)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (Int128 lhs, float rhs) => (float)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (Int128 lhs, float rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (double lhs, Int128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (double lhs, Int128 rhs) => lhs != (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (double lhs, Int128 rhs) => lhs < (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (double lhs, Int128 rhs) => lhs > (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (double lhs, Int128 rhs) => lhs <= (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double lhs, Int128 rhs) => lhs >= (double)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (Int128 lhs, double rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (Int128 lhs, double rhs) => (double)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (Int128 lhs, double rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (Int128 lhs, double rhs) => (double)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (Int128 lhs, double rhs) => (double)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (Int128 lhs, double rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs != (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs < (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs > (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs <= (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.float2 lhs, Int128 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Int128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs != (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs < (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs > (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs <= (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.float3 lhs, Int128 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Int128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs != (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs < (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs > (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs <= (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.float4 lhs, Int128 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Int128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs != (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs < (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs > (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs <= (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.double2 lhs, Int128 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Int128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs != (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs < (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs > (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs <= (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.double3 lhs, Int128 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Int128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs != (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs < (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs > (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs <= (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.double4 lhs, Int128 rhs) => lhs >= (double4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Int128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs >= rhs;
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly int CompareTo(Int128 other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly int CompareTo(long other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly int CompareTo(ulong other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly int CompareTo(object obj)
        {
            return CompareTo((Int128)obj);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(Int128 other)
        {
            return this == other;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly bool Equals(object obj)
        {
            return obj is Int128 converted && this.Equals(converted);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode() => (int)math.hash(this);


        #region string
        internal const byte MAX_DECIMAL_DIGITS = 39 + 1;

        public override readonly string ToString()
        {
            if (IsZero)
            {
                return "0";
            }

            char* DECIMAL_DIGITS = stackalloc char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char* result = stackalloc char[MAX_DECIMAL_DIGITS];
            char* currentDigit = result + (MAX_DECIMAL_DIGITS - 1);
            UInt128 cpy = (UInt128)abs(this);

            while (cpy >= 10u)
            {
                cpy = UInt128.__const.divrem10(cpy, out ulong rem);

                *currentDigit-- = DECIMAL_DIGITS[rem];
            }
            if (cpy.IsNotZero)
            {
                *currentDigit-- = DECIMAL_DIGITS[cpy.lo64];
            }
            if ((long)hi64 < 0)
            {
                *currentDigit-- = '-';
            }

            int length = MAX_DECIMAL_DIGITS - (int)(((ulong)++currentDigit - (ulong)result) / sizeof(char));

            return new string(currentDigit, 0, length);
        }

        public readonly string ToString(string format)
        {
            return ((BigInteger)this).ToString(format);
        }

		public readonly string ToString(IFormatProvider provider)
        {
            return ToString(null, provider);
        }

		public readonly string ToString(string format, IFormatProvider provider)
        {
            return ((BigInteger)this).ToString(format, provider);
        }


        public static Int128 Parse(string value)
        {
            return Parse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        public static Int128 Parse(string value, NumberStyles style)
        {
            return Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        public static Int128 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            BigInteger result = BigInteger.Parse(value, style, provider);

            if (result < MinValue || result > MaxValue)
            {
                throw new OverflowException();
            }

            return (Int128)result;
        }

        public static Int128 Parse(ReadOnlySpan<char> value)
        {
            return Parse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        public static Int128 Parse(ReadOnlySpan<char> value, NumberStyles style)
        {
            return Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        public static Int128 Parse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider)
        {
            return (Int128)BigInteger.Parse(value, style, provider);
        }

        public static bool TryParse(string value, out Int128 result)
        {
            return TryParse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(string value, NumberStyles style, out Int128 result)
        {
            return TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out Int128 result)
        {
            if (!BigInteger.TryParse(value, style, provider, out BigInteger bigResult))
            {
                result = 0;
                return false;
            }

            if (bigResult < MinValue || bigResult > MaxValue)
            {
                result = 0;
                return false;
            }

            result = (Int128)bigResult;
            return true;
        }

        public static bool TryParse(ReadOnlySpan<char> value, out Int128 result)
        {
            return TryParse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> value, NumberStyles style, out Int128 result)
        {
            return TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider, out Int128 result)
        {
            if (!BigInteger.TryParse(value, style, provider, out BigInteger bigResult))
            {
                result = 0;
                return false;
            }

            if (bigResult < MinValue || bigResult > MaxValue)
            {
                result = 0;
                return false;
            }

            result = (Int128)bigResult;
            return true;
        }
        #endregion

        #region IConvertible
		public readonly TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

		public readonly bool ToBoolean(IFormatProvider provider)
        {
            return this != 0;
        }

		public readonly byte ToByte(IFormatProvider provider)
        {
            return (byte)this;
        }

		public readonly char ToChar(IFormatProvider provider)
        {
            return (char)(ushort)this;
        }

		public readonly DateTime ToDateTime(IFormatProvider provider)
        {
            return (DateTime)Convert.ChangeType((BigInteger)this, typeof(DateTime));
        }

		public readonly decimal ToDecimal(IFormatProvider provider)
        {
            return (decimal)this;
        }

		public readonly double ToDouble(IFormatProvider provider)
        {
            return (double)this;
        }

		public readonly short ToInt16(IFormatProvider provider)
        {
            return (short)this;
        }

		public readonly int ToInt32(IFormatProvider provider)
        {
            return (int)this;
        }

		public readonly long ToInt64(IFormatProvider provider)
        {
            return (long)this;
        }

		public readonly sbyte ToSByte(IFormatProvider provider)
        {
            return (sbyte)this;
        }

		public readonly float ToSingle(IFormatProvider provider)
        {
            return (float)this;
        }

		public readonly object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType((BigInteger)this, conversionType);
        }

		public readonly ushort ToUInt16(IFormatProvider provider)
        {
            return (ushort)this;
        }

		public readonly uint ToUInt32(IFormatProvider provider)
        {
            return (uint)this;
        }

		public readonly ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)this;
        }

        public readonly bool Equals(long other)
        {
            return this == other;
        }

        public readonly bool Equals(ulong other)
        {
            return this == other;
        }
        #endregion
    }
}