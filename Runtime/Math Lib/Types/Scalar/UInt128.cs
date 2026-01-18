using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [DebuggerTypeProxy(typeof(UInt128.DebuggerProxy))]
    unsafe public readonly partial struct UInt128 : IComparable, IComparable<UInt128>, IConvertible, IEquatable<UInt128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public BigInteger value;

            public DebuggerProxy(UInt128 v)
            {
                value = v;
            }
        }


        public readonly ulong lo64;
        public readonly ulong hi64;


        public static UInt128 MinValue => new UInt128(0, 0);
        public static UInt128 MaxValue => new UInt128(ulong.MaxValue, ulong.MaxValue);

        internal readonly bool IsZero => (lo64 | hi64) == 0;
        internal readonly bool IsNotZero => (lo64 | hi64) != 0;
        internal readonly bool IsMaxValue => (lo64 & hi64) == ulong.MaxValue;
        internal readonly bool IsNotMaxValue => (lo64 & hi64) != ulong.MaxValue;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(ulong lo64, ulong hi64)
        {
            this.lo64 = lo64;
            this.hi64 = hi64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(long lo64, long hi64)
            : this((ulong)lo64, (ulong)hi64) { }


        #region Conversions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator UInt128(Guid value)
        {
            return *(UInt128*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(string value)
        {
            return Parse(value);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(Int128 value)
        {
            return value.value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(byte value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.Assume(r <= value);
            //constexpr.Assume((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ushort value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.Assume(r <= value);
            //constexpr.Assume((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(uint value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.Assume(r <= value);
            //constexpr.Assume((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ulong value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.Assume(r <= value);
            //constexpr.Assume((Int128)r >= (Int128)0);
            return r;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(sbyte value)
        {
            long signExtended = value;
            if (constexpr.IS_TRUE(value == 0 || value == -1))
            {
                return new UInt128(signExtended, signExtended);
            }
            long hi = signExtended >> 63;
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.Assume(constexpr.IS_TRUE(value >= 0)
            //                 ? r <= value && (Int128)r >= (Int128)0
            //                 : isinrange((Int128)r, nabs((long)value), abs((long)value)));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(short value)
        {
            long signExtended = value;
            if (constexpr.IS_TRUE(value == 0 || value == -1))
            {
                return new UInt128(signExtended, signExtended);
            }
            long hi = signExtended >> 63;
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.Assume(constexpr.IS_TRUE(value >= 0)
            //                 ? r <= value && (Int128)r >= (Int128)0
            //                 : isinrange((Int128)r, nabs((long)value), abs((long)value)));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(int value)
        {
            long signExtended = value;
            if (constexpr.IS_TRUE(value == 0 || value == -1))
            {
                return new UInt128(signExtended, signExtended);
            }
            long hi = signExtended >> 63;
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.Assume(constexpr.IS_TRUE(value >= 0)
            //                 ? r <= value && (Int128)r >= (Int128)0
            //                 : isinrange((Int128)r, nabs((long)value), abs((long)value)));
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(long value)
        {
            if (constexpr.IS_TRUE(value == 0 || value == -1))
            {
                return new UInt128(value, value);
            }
            long hi = value >> 63;
            UInt128 r = new UInt128((ulong)value, (ulong)hi);

            //constexpr.Assume(constexpr.IS_TRUE(value >= 0)
            //                 ? r <= value && (Int128)r >= (Int128)0
            //                 : isinrange((Int128)r, nabs((Int128)r), abs((Int128)r)));
            return r;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(half value)
        {
            return BASE_cvtf16i32(value, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(float value)
        {
            return BASE_cvtf32i128(value, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(double value)
        {
            return BASE_cvtf64i128(value, signed: false, trunc: true);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(decimal value)
        {
            int[] bits = decimal.GetBits(decimal.Truncate(value));

            return new UInt128((uint)bits[0] | ((ulong)bits[1] << 32), (uint)bits[2]);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(BigInteger value)
        {
            bool isNegative = value.Sign == -1;

            if (isNegative)
            {
                value = -value;
            }

            UInt128 result = new UInt128((ulong)(value & ulong.MaxValue), (ulong)((value >> 64) & ulong.MaxValue));

            if (isNegative)
            {
                result = (UInt128)(-(Int128)result);
            }

            return result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Guid(UInt128 value)
        {
            return *(Guid*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte(UInt128 value)
        {
            return (byte)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(UInt128 value)
        {
            return (ushort)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(UInt128 value)
        {
            return (uint)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(UInt128 value)
        {
            return (ulong)value.lo64;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(UInt128 value)
        {
            return (sbyte)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(UInt128 value)
        {
            return (short)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(UInt128 value)
        {
            return (int)value.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(UInt128 value)
        {
            return (long)value.lo64;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(UInt128 value)
        {
            return (half)(float)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(UInt128 value)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 sse = *(v128*)&value;
                v128 cvt = RegisterConversion.ToV128((float2)(*(ulong2*)&value));

                v128 hi0;
                if (Sse4_1.IsSse41Supported)
                {
                    hi0 = Xse.cmpeq_epi64(sse, Xse.setzero_si128());
                    hi0 = Xse.shuffle_epi32(hi0, Sse.SHUFFLE(3, 3, 3, 3));
                }
                else
                {
                    v128 cmpeq32 = Xse.cmpeq_epi32(sse, Xse.setzero_si128());
                    cmpeq32 = Xse.and_si128(cmpeq32, Xse.srli_epi64(cmpeq32, 32));
                    hi0 = Xse.shuffle_epi32(cmpeq32, Sse.SHUFFLE(2, 2, 2, 2));
                }

                v128 hi = Xse.andnot_si128(hi0, new v128((float)ulong.MaxValue));
                v128 lo = Xse.blendv_si128(Xse.bsrli_si128(cvt, sizeof(float)), new v128(1f), hi0);

                return Xse.fmadd_ps(lo, hi, cvt).Float0;
            }
            else
            {
                float2 cvt = *(ulong2*)&value;
                bool hi0 = value.hi64 != 0;
                float __mul = asfloat(asuint((float)ulong.MaxValue) & (uint)-toint(hi0));

                return mad(hi0 ? cvt.y : 1f, __mul, cvt.x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(UInt128 value)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 sse = *(v128*)&value;
                v128 cvt = Xse.cvtepu64_pd(sse);

                v128 hi0 = Xse.cmpeq_epi64(sse, Xse.setzero_si128());
                hi0 = Xse.bsrli_si128(hi0, sizeof(double));

                v128 hi = Xse.andnot_si128(hi0, Xse.set1_pd(ulong.MaxValue));
                v128 lo = Xse.blendv_si128(Xse.bsrli_si128(cvt, sizeof(double)), new v128(1d), hi0);

                return Xse.fmadd_pd(lo, hi, cvt).Double0;
            }
            else
            {
                double2 cvt = *(ulong2*)&value;
                bool hi0 = value.hi64 != 0;
                double __mul = asdouble(asulong((double)ulong.MaxValue) & (ulong)-tolong(hi0));

                return mad(hi0 ? cvt.y : 1d, __mul, cvt.x);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(UInt128 value)
        {
            return new decimal((int)value.lo64, (int)(value.lo64 >> 32), (int)value.hi64, false, 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator BigInteger(UInt128 value)
        {
            return (BigInteger)value.hi64 << 64 | value.lo64;
        }
        #endregion

        #region Operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ~ (UInt128 left)
        {
            return new UInt128(~left.lo64, ~left.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ++ (UInt128 value) => value + (uint)1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator -- (UInt128 value) => value - (uint)1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, UInt128 right)
        {
            ulong lo = left.lo64 + right.lo64;
            ulong hi = left.hi64 + right.hi64;

            bool carry = lo < left.lo64;
            hi += tobyte(carry);

            return new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, ulong right)
        {
            ulong lo = left.lo64 + right;
            bool carry = lo < left.lo64;
            ulong hi = left.hi64 + tobyte(carry);

            return new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (ulong left, UInt128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, uint right) => left + (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (uint left, UInt128 right) => (ulong)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, ushort right) => left + (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (ushort left, UInt128 right) => (ulong)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, byte right) => left + (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (byte left, UInt128 right) => (ulong)left + right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, UInt128 right)
        {
            ulong lo = left.lo64 - right.lo64;
            ulong hi = left.hi64 - right.hi64;

            hi -= tobyte(left.lo64 < right.lo64);

            return new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, ulong right)
        {
            ulong lo = left.lo64 - right;
            ulong hi = left.hi64;

            hi -= tobyte(left.lo64 < right);

            return new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (ulong left, UInt128 right) => (UInt128)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, uint right) => left - (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (uint left, UInt128 right) => (ulong)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, ushort right) => left - (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (ushort left, UInt128 right) => (ulong)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, byte right) => left - (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (byte left, UInt128 right) => (ulong)left - right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, UInt128 right)
        {
            if (constexpr.IS_CONST(left))
            {
                return __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return __const.umul(left, right);
            }

            return UInt128.umul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, ulong right)
        {
            if (constexpr.IS_CONST(left))
            {
                return __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return __const.umul(left, right);
            }

            return UInt128.umul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (ulong left, UInt128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, uint right)
        {
            if (constexpr.IS_CONST(left))
            {
                return __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                return __const.umul(left, right);
            }

            return UInt128.umul(left, right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (uint left, UInt128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, ushort right) => left * (uint)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (ushort left, UInt128 right) => (uint)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, byte right) => left * (uint)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (byte left, UInt128 right) => (uint)left * right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, UInt128 right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return __const.udiv(left, right);
            }
            else
            {
                return asm128.__udiv128x128(left, right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return __const.udiv(left, right);
            }
            else
            {
                return asm128.__udiv128x64(left, right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, uint right) => left / (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (uint left, UInt128 right) => (ulong)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, ushort right) => left / (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (ushort left, UInt128 right) => (ulong)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, byte right) => left / (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (byte left, UInt128 right) => (ulong)left / right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, UInt128 right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return __const.urem(left, right);
            }
            else
            {
                return asm128.__urem128x128(left, right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);

            if (constexpr.IS_CONST(right))
            {
                return __const.urem(left, right);
            }
            else
            {
                return asm128.__urem128x64(left, right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, uint right) => left % (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (uint left, UInt128 right) => (ulong)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, ushort right) => left % (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (ushort left, UInt128 right) => (ulong)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, byte right) => left % (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (byte left, UInt128 right) => (ulong)left % right;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator << (UInt128 value, int n)
        {
            n &= 127;

            if (constexpr.IS_TRUE(value.lo64 == 0))
            {
                return new UInt128(0, (n < 64) ? (value.hi64 << n) : 0);
            }
            if (constexpr.IS_CONST(n))
            {
                return __const.shluint128(value, n);
            }
            else
            {
                if (Hint.Unlikely(n == 0))
                {
                    return value;
                }
                else if (n < 64)
                {
                    constexpr.ASSUME(n > 0 && n < 64);

                    return new UInt128(value.lo64 << n, (value.hi64 << n) | (value.lo64 >> (64 - n)));
                }
                else
                {
                    constexpr.ASSUME(n > 63 && n < 128);

                    return new UInt128(0, value.lo64 << (n - 64));
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator >> (UInt128 value, int n)
        {
            n &= 127;

            if (constexpr.IS_TRUE(value.hi64 == 0))
            {
                return new UInt128((n < 64) ? (value.lo64 >> n) : 0, 0);
            }
            if (constexpr.IS_CONST(n))
            {
                return __const.shruint128(value, n);
            }
            else
            {
                if (Hint.Unlikely(n == 0))
                {
                    return value;
                }
                else if (n < 64)
                {
                    constexpr.ASSUME(n > 0 && n < 64);

                    return new UInt128((value.lo64 >> n) | (value.hi64 << (64 - n)), value.hi64 >> n);
                }
                else
                {
                    constexpr.ASSUME(n > 63 && n < 128);

                    return new UInt128(value.hi64 >> (n - 64), 0);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo64 & right.lo64, left.hi64 & right.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, ulong right)
        {
            return new UInt128(left.lo64 & right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (ulong left, UInt128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, uint right) => left & (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (uint left, UInt128 right) => (ulong)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, ushort right) => left & (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (ushort left, UInt128 right) => (ulong)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, byte right) => left & (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (byte left, UInt128 right) => (ulong)left & right;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo64 | right.lo64, left.hi64 | right.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, ulong right)
        {
            return new UInt128(left.lo64 | right, left.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (ulong left, UInt128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, uint right) => left | (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (uint left, UInt128 right) => (ulong)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, ushort right) => left | (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (ushort left, UInt128 right) => (ulong)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, byte right) => left | (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (byte left, UInt128 right) => (ulong)left | right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo64 ^ right.lo64, left.hi64 ^ right.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, ulong right)
        {
            return new UInt128(left.lo64 ^ right, left.hi64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (ulong left, UInt128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, uint right) => left ^ (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (uint left, UInt128 right) => (ulong)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, ushort right) => left ^ (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (ushort left, UInt128 right) => (ulong)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, byte right) => left ^ (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (byte left, UInt128 right) => (ulong)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                if (right.IsZero)
                {
                    return left.IsZero;
                }
                if (right.IsMaxValue)
                {
                    return left.IsMaxValue;
                }
            }
            else if (constexpr.IS_CONST(left))
            {
                if (left.IsZero)
                {
                    return right.IsZero;
                }
                if (left.IsMaxValue)
                {
                    return right.IsMaxValue;
                }
            }

            return ((left.lo64 ^ right.lo64) | (left.hi64 ^ right.hi64)) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return left.IsZero;
            }

            return ((left.lo64 ^ right) | left.hi64) == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ulong left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, uint right) => left == (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (uint left, UInt128 right) => (ulong)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, ushort right) => left == (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ushort left, UInt128 right) => (ulong)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, byte right) => left == (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (byte left, UInt128 right) => (ulong)left == right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, UInt128 right)
        {
            if (constexpr.IS_CONST(right))
            {
                if (right.IsZero)
                {
                    return left.IsNotZero;
                }
                if (right.IsMaxValue)
                {
                    return left.IsNotMaxValue;
                }
            }
            else if (constexpr.IS_CONST(left))
            {
                if (left.IsZero)
                {
                    return right.IsNotZero;
                }
                if (left.IsMaxValue)
                {
                    return right.IsNotMaxValue;
                }
            }

            return ((left.lo64 ^ right.lo64) | (left.hi64 ^ right.hi64)) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(right == 0))
            {
                return left.IsNotZero;
            }

            return ((left.lo64 ^ right) | left.hi64) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ulong left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, uint right) => left != (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (uint left, UInt128 right) => (ulong)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, ushort right) => left != (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ushort left, UInt128 right) => (ulong)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, byte right) => left != (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (byte left, UInt128 right) => (ulong)left != right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return left < right.lo64;
            }
            else if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return right > left.lo64;
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (UInt128)(-(Int128)right)).IsZero;
            }

            return (left.hi64 < right.hi64) | ((left.hi64 == right.hi64) & left.lo64 < right.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & new UInt128((-(Int128)right).lo64, ulong.MaxValue)).IsZero;
            }

            return left.hi64 == 0 & left.lo64 < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, UInt128 right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (-(Int128)right).lo64) == 0;
            }

            return right.hi64 != 0 | left < right.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, uint right) => left < (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (uint left, UInt128 right) => (ulong)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, ushort right) => left < (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ushort left, UInt128 right) => (ulong)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, byte right) => left < (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (byte left, UInt128 right) => (ulong)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, ulong right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (ulong left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, uint right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (uint left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, ushort right) => left > (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (ushort left, UInt128 right) => (ulong)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, byte right) => left > (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (byte left, UInt128 right) => (ulong)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, UInt128 right)
        {
            if (constexpr.IS_TRUE(right.hi64 == 0))
            {
                return left >= right.lo64;
            }
            else if (constexpr.IS_TRUE(left.hi64 == 0))
            {
                return right <= left.lo64;
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (UInt128)(-(Int128)right)).IsNotZero;
            }

            return (right.hi64 < left.hi64) | ((right.hi64 == left.hi64) & right.lo64 <= left.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, ulong right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (UInt128)(-(Int128)right)).IsNotZero;
            }

            return left.hi64 != 0 | left.lo64 >= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, UInt128 right)
        {
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                return (left & (-(Int128)right).lo64) != 0;
            }

            return right.hi64 == 0 & left >= right.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, uint right) => left >= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (uint left, UInt128 right) => (ulong)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, ushort right) => left >= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ushort left, UInt128 right) => (ulong)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, byte right) => left >= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (byte left, UInt128 right) => (ulong)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, ulong right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ulong left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, uint right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (uint left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, ushort right) => left <= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ushort left, UInt128 right) => (ulong)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, byte right) => left <= (ulong)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (byte left, UInt128 right) => (ulong)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, sbyte right)
        {
            return (right >= 0) & (left == (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (sbyte left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, sbyte right)
        {
            return (right < 0) | (left != (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (sbyte left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, sbyte right)
        {
            return (right >= 0) & (left < (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (sbyte left, UInt128 right) => right > left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, sbyte right)
        {
            return (right < 0) | (left > (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (sbyte left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, sbyte right)
        {
            return (right >= 0) & (left <= (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (sbyte left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, sbyte right)
        {
            return (right < 0) | (left >= (byte)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (sbyte left, UInt128 right) => right <= left;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, short right)
        {
            return (right >= 0) & (left == (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (short left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, short right)
        {
            return (right < 0) | (left != (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (short left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, short right)
        {
            return (right >= 0) & (left < (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (short left, UInt128 right) => right > left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, short right)
        {
            return (right < 0) | (left > (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (short left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, short right)
        {
            return (right >= 0) & (left <= (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (short left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, short right)
        {
            return (right < 0) | (left >= (ushort)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (short left, UInt128 right) => right <= left;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, int right)
        {
            return (right >= 0) & (left == (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (int left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, int right)
        {
            return (right < 0) | (left != (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (int left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, int right)
        {
            return (right >= 0) & (left < (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (int left, UInt128 right) => right > left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, int right)
        {
            return (right < 0) | (left > (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (int left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, int right)
        {
            return (right >= 0) & (left <= (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (int left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, int right)
        {
            return (right < 0) | (left >= (uint)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (int left, UInt128 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, long right)
        {
            return (right >= 0) & (left == (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (long left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, long right)
        {
            return (right < 0) | (left != (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (long left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, long right)
        {
            return (right >= 0) & (left < (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (long left, UInt128 right) => right > left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 left, long right)
        {
            return (right < 0) | (left > (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (long left, UInt128 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, long right)
        {
            return (right >= 0) & (left <= (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (long left, UInt128 right) => right >= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, long right)
        {
            return (right < 0) | (left >= (ulong)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (long left, UInt128 right) => right <= left;
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int CompareTo(UInt128 other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int CompareTo(ulong other)
        {
            return tobyte(this > other) - tobyte(this < other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly int CompareTo(object obj)
        {
            return CompareTo((UInt128)obj);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(UInt128 other)
        {
            return this == other;
        }

        public override readonly bool Equals(object obj)
        {
            return obj is UInt128 converted && this.Equals(converted);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            ulong _64 = lo64 ^ hi64;

            return (int)_64 ^ (int)(_64 >> 32);
        }


        #region string
        internal const byte MAX_DECIMAL_DIGITS = 39;

        public override readonly string ToString()
        {
            if (IsZero)
            {
                return "0";
            }

            char* DECIMAL_DIGITS = stackalloc char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char* result = stackalloc char[MAX_DECIMAL_DIGITS];
            char* currentDigit = result + (MAX_DECIMAL_DIGITS - 1);
            UInt128 cpy = this;

            while (cpy >= 10u)
            {
                cpy = __const.divrem10(cpy, out ulong rem);

                *currentDigit-- = DECIMAL_DIGITS[rem];
            }
            if (cpy.IsNotZero)
            {
                *currentDigit-- = DECIMAL_DIGITS[cpy.lo64];
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


        public static UInt128 Parse(string value)
        {
            return Parse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        public static UInt128 Parse(string value, NumberStyles style)
        {
            return Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        public static UInt128 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            BigInteger result = BigInteger.Parse(value, style, provider);

            if (result < MinValue || result > MaxValue)
            {
                throw new OverflowException();
            }

            return (UInt128)result;
        }

        public static UInt128 Parse(ReadOnlySpan<char> value)
        {
            return Parse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo);
        }

        public static UInt128 Parse(ReadOnlySpan<char> value, NumberStyles style)
        {
            return Parse(value, style, NumberFormatInfo.CurrentInfo);
        }

        public static UInt128 Parse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider)
        {
            return (UInt128)BigInteger.Parse(value, style, provider);
        }

        public static bool TryParse(string value, out UInt128 result)
        {
            return TryParse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(string value, NumberStyles style, out UInt128 result)
        {
            return TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out UInt128 result)
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

            result = (UInt128)bigResult;
            return true;
        }

        public static bool TryParse(ReadOnlySpan<char> value, out UInt128 result)
        {
            return TryParse(value, NumberStyles.Integer, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> value, NumberStyles style, out UInt128 result)
        {
            return TryParse(value, style, NumberFormatInfo.CurrentInfo, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> value, NumberStyles style, IFormatProvider provider, out UInt128 result)
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

            result = (UInt128)bigResult;
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