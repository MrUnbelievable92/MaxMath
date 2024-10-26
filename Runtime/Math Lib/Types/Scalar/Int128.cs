using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [DebuggerTypeProxy(typeof(Int128.DebuggerProxy))]
    unsafe public readonly struct Int128 : IComparable, IComparable<Int128>, IConvertible, IEquatable<Int128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public BigInteger value;

            public DebuggerProxy(Int128 v)
            {
                value = v;
            }
        }


        internal readonly UInt128 value;

        public readonly ulong lo64 => value.lo64;
        public readonly ulong hi64 => value.hi64;

        internal readonly bool IsZero => this == 0;
        internal readonly bool IsNotZero => this != 0;
        internal readonly bool IsMaxValue => this == MaxValue;
        internal readonly bool IsNotMaxValue => this != MaxValue;

        public static Int128 MinValue => new Int128(0, 1ul << 63);
        public static Int128 MaxValue => new Int128(ulong.MaxValue, long.MaxValue);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(ulong lo, ulong hi)
        {
            value = new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Int128(long lo, long hi)
            : this((ulong)lo, (ulong)hi) { }


        #region Conversion
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
		public static explicit operator Int128(half value)
        {
            return (int)BASE_cvtf16i32(value, signed: true, trunc: true);
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
            return negate((Int128)(UInt128)value, value < 0);
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
		public static explicit operator half(Int128 value)
        {
            return (half)(float)value;
        }

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
		public static Int128 operator << (Int128 left, int n) => (Int128)(left.value << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator >> (Int128 left, int n)
        {
            n &= 127;

            if (constexpr.IS_CONST(n))
            {
                return UInt128.__const.sarint128(left, n);
            }
            else
            {
                if (Hint.Unlikely(n == 0))
                {
                    return left;
                }
                else if (n < 64)
                {
                    constexpr.ASSUME(n > 0 && n < 64);

                    return new Int128(left.lo64 >> n | (left.hi64 << (64 - n)), (ulong)((long)left.hi64 >> n));
                }
                else
                {
                    constexpr.ASSUME(n > 63 && n < 128);

                    return new Int128(((long)left.hi64 >> (n - 64)), (long)left.hi64 >> 63);
                }
            }
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
            if (constexpr.IS_TRUE(right.IsZero))
            {
                return (long)left.hi64 < 0;
            }

            return ((long)left.hi64 < (long)right.hi64) | ((left.hi64 == right.hi64) & (left.lo64 < right.lo64));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, long right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return (long)left.hi64 < 0;
            }
            else if (constexpr.IS_TRUE(isinrange(left, long.MinValue, long.MaxValue)))
            {
                return (long)left.lo64 < (long)right;
            }

            return left < (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (long left, Int128 right)
        {
            if (constexpr.IS_TRUE(isinrange(right, long.MinValue, long.MaxValue)))
            {
                return (long)right.lo64 > left;
            }

            return (Int128)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, int right) => left < (long)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (int left, Int128 right) => (long)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, ulong right)
        {
            if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return left.lo64 < right;
            }

            return left < (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (ulong left, Int128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return right.lo64 > left;
            }

            return (Int128)left < right;
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
            return ((long)left.hi64 < (long)right.hi64) | ((left.hi64 == right.hi64) & (left.lo64 <= right.lo64));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, long right)
        {
            return left <= (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (long left, Int128 right)
        {
            return (Int128)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, int right) => left <= (long)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (int left, Int128 right) => (long)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, ulong right)
        {
            if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return left.lo64 <= right;
            }

            return left <= (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (ulong left, Int128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return left <= right.lo64;
            }

            return (Int128)left <= right;
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
		public override readonly int GetHashCode()
        {
            return value.GetHashCode();
        }


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