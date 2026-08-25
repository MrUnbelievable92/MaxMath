using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using Unity.Burst.Intrinsics;
using DevTools;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class UInt128DebuggerProxy
    {
        public BigInteger value;

        public UInt128DebuggerProxy(UInt128 v)
        {
            value = v;
        }
    }

    [DebuggerTypeProxy(typeof(UInt128DebuggerProxy))]
#endif
    [Serializable]
    unsafe public readonly partial struct UInt128 : IComparable, IComparable<UInt128>, IConvertible, IEquatable<UInt128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        public readonly ulong lo64;
        public readonly ulong hi64;


        /// <summary>   0   </summary>
        public static UInt128 MinValue => new UInt128(0, 0);
        /// <summary>   340.282.366.920.938.463.463.374.607.431.768.211.455    </summary>
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
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(bool x)
        {
            this = new UInt128(x ? 1 : 0, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(byte x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(sbyte x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(ushort x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(short x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(uint f)
        {
            this = (UInt128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(int f)
        {
            this = (UInt128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(ulong d)
        {
            this = (UInt128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(long d)
        {
            this = (UInt128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(UInt128 d)
        {
            this = (UInt128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(Int128 d)
        {
            this = (UInt128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(quarter x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(half x)
        {
            this = (UInt128)x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(float f)
        {
            this = (UInt128)f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(double d)
        {
            this = (UInt128)d;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(quadruple d)
        {
            this = (UInt128)d;
        }


        #region Conversions
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(bool q) => q ? (UInt128)1 : (UInt128)0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool(UInt128 q) => q.IsNotZero;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(UInt128 q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(UInt128 q) => (bool)q;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(UInt128 q) => (bool)q;


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
            //constexpr.ASSUME(r <= value);
            //constexpr.ASSUME((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ushort value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.ASSUME(r <= value);
            //constexpr.ASSUME((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(uint value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.ASSUME(r <= value);
            //constexpr.ASSUME((Int128)r >= (Int128)0);
            return r;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ulong value)
        {
            UInt128 r = new UInt128(value, 0);
            //constexpr.ASSUME(r <= value);
            //constexpr.ASSUME((Int128)r >= (Int128)0);
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
            constexpr.ASSUME(hi == 0 || hi == -1);
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.ASSUME(constexpr.IS_TRUE(value >= 0)
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
            constexpr.ASSUME(hi == 0 || hi == -1);
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.ASSUME(constexpr.IS_TRUE(value >= 0)
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
            constexpr.ASSUME(hi == 0 || hi == -1);
            UInt128 r = new UInt128((ulong)signExtended, (ulong)hi);

            //constexpr.ASSUME(constexpr.IS_TRUE(value >= 0)
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
            constexpr.ASSUME(hi == 0 || hi == -1);
            UInt128 r = new UInt128((ulong)value, (ulong)hi);

            //constexpr.ASSUME(constexpr.IS_TRUE(value >= 0)
            //                 ? r <= value && (Int128)r >= (Int128)0
            //                 : isinrange((Int128)r, nabs((Int128)r), abs((Int128)r)));
            return r;
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
        public static explicit operator UInt128(Unity.Mathematics.half value)
        {
            return (UInt128)(half)value;
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
        public static implicit operator float(UInt128 value)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 sse = *(v128*)&value;
                v128 cvt = (float2)(*(ulong2*)&value);

                v128 hi0;
                if (BurstArchitecture.IsCMP64Supported)
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half(UInt128 value)
        {
            return (half)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(UInt128 value)
        {
            return (half2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(UInt128 value)
        {
            return (half3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(UInt128 value)
        {
            return (half4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(UInt128 value)
        {
            return (float2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(UInt128 value)
        {
            return (float3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(UInt128 value)
        {
            return (float4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(UInt128 value)
        {
            return (double2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(UInt128 value)
        {
            return (double3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(UInt128 value)
        {
            return (double4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(UInt128 value)
        {
            return (uint2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(UInt128 value)
        {
            return (uint3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(UInt128 value)
        {
            return (uint4)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(UInt128 value)
        {
            return (int2)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(UInt128 value)
        {
            return (int3)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(UInt128 value)
        {
            return (int4)value;
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
            UInt128 result;

            if (constexpr.IS_CONST(left))
            {
                result = __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                result = __const.umul(left, right);
            }
            else
            {
                result = UInt128.umul(left, right);
            }

            if (constexpr.IS_TRUE(left.IsZero || right.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == 1))
            {
                constexpr.ASSUME(result == right);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                constexpr.ASSUME(result == left);
            }

            constexpr.ASSUME((result.lo64 & 1ul) == ((left.lo64 & right.lo64) & 1ul));
            constexpr.ASSUME(((result.lo64 & 1ul) == 0) ==  (((left.lo64 & 1ul) == 0) || ((right.lo64 & 1ul) == 0)));

            constexpr.ASSUME(tzcnt(result) >= tzcnt(left));
            constexpr.ASSUME(tzcnt(result) >= tzcnt(right));
            constexpr.ASSUME(tzcnt(result) == min(128, tzcnt(left) + tzcnt(right)));

            if (constexpr.IS_TRUE(ispow2(left)))
            {
                constexpr.ASSUME(result == right << tzcnt(left));
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                constexpr.ASSUME(result == left << tzcnt(right));
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, ulong right)
        {
            UInt128 result;

            if (constexpr.IS_CONST(left))
            {
                result = __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                result = __const.umul(left, right);
            }
            else
            {
                result = UInt128.umul(left, right);
            }
            
            if (constexpr.IS_TRUE(left.IsZero || right == 0))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == 1))
            {
                constexpr.ASSUME(result == right);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                constexpr.ASSUME(result == left);
            }

            constexpr.ASSUME((result.lo64 & 1ul) == ((left.lo64 & right) & 1ul));
            constexpr.ASSUME(((result.lo64 & 1ul) == 0) ==  (((left.lo64 & 1ul) == 0) || ((right & 1ul) == 0)));
            
            constexpr.ASSUME(tzcnt(result) >= tzcnt(left));
            constexpr.ASSUME(tzcnt(result) >= tzcnt((UInt128)right));
            constexpr.ASSUME(tzcnt(result) == min(128, tzcnt(left) + tzcnt((UInt128)right)));

            if (constexpr.IS_TRUE(ispow2(left)))
            {
                constexpr.ASSUME(result == (UInt128)right << tzcnt(left));
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                constexpr.ASSUME(result == left << tzcnt(right));
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (ulong left, UInt128 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, uint right)
        {
            UInt128 result;

            if (constexpr.IS_CONST(left))
            {
                result = __const.umul(right, left);
            }
            else if (constexpr.IS_CONST(right))
            {
                result = __const.umul(left, right);
            }
            else
            {
                result = UInt128.umul(left, right);
            }
            
            if (constexpr.IS_TRUE(left.IsZero || right == 0))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(left == 1))
            {
                constexpr.ASSUME(result == right);
            }
            if (constexpr.IS_TRUE(right == 1))
            {
                constexpr.ASSUME(result == left);
            }

            constexpr.ASSUME((result.lo64 & 1ul) == ((left.lo64 & right) & 1ul));
            constexpr.ASSUME(((result.lo64 & 1ul) == 0) ==  (((left.lo64 & 1ul) == 0) || ((right & 1ul) == 0)));
            
            constexpr.ASSUME(tzcnt(result) >= tzcnt(left));
            constexpr.ASSUME(tzcnt(result) >= tzcnt((UInt128)right));
            constexpr.ASSUME(tzcnt(result) == min(128, tzcnt(left) + tzcnt((UInt128)right)));

            if (constexpr.IS_TRUE(ispow2(left)))
            {
                constexpr.ASSUME(result == (UInt128)right << tzcnt(left));
            }
            if (constexpr.IS_TRUE(ispow2(right)))
            {
                constexpr.ASSUME(result == left << tzcnt(right));
            }

            return result;
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

            UInt128 result;

            if (constexpr.IS_CONST(right))
            {
                result = __const.udiv(left, right);
            }
            else
            {
                result = asm128.__udiv128x128(left, right);
            }

            ASSUME_DIVISION(result, left, right);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);

            UInt128 result;

            if (constexpr.IS_CONST(right))
            {
                result = __const.udiv(left, right);
            }
            else
            {
                result = asm128.__udiv128x64(left, right);
            }

            ASSUME_DIVISION(result, left, right);

            return result;
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

            UInt128 result;

            if (constexpr.IS_CONST(right))
            {
                result = __const.urem(left, right);
            }
            else
            {
                result = asm128.__urem128x128(left, right);
            }
            
            ASSUME_REMAINDER(result, left, right);

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, ulong right)
        {
Assert.AreNotEqual(right, 0u);
            
            ulong result;

            if (constexpr.IS_CONST(right))
            {
                result = __const.urem(left, right);
            }
            else
            {
                result = asm128.__urem128x64(left, right);
            }
            
            ASSUME_REMAINDER(result, left, right);

            return result;
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
        public static float operator + (float lhs, UInt128 rhs) => lhs + (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (float lhs, UInt128 rhs) => lhs - (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (float lhs, UInt128 rhs) => lhs * (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (float lhs, UInt128 rhs) => lhs / (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (float lhs, UInt128 rhs) => lhs % (float)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator + (UInt128 lhs, float rhs) => (float)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator - (UInt128 lhs, float rhs) => (float)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator * (UInt128 lhs, float rhs) => (float)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator / (UInt128 lhs, float rhs) => (float)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float operator % (UInt128 lhs, float rhs) => (float)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (double lhs, UInt128 rhs) => lhs + (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (double lhs, UInt128 rhs) => lhs - (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (double lhs, UInt128 rhs) => lhs * (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (double lhs, UInt128 rhs) => lhs / (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (double lhs, UInt128 rhs) => lhs % (double)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator + (UInt128 lhs, double rhs) => (double)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator - (UInt128 lhs, double rhs) => (double)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator * (UInt128 lhs, double rhs) => (double)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator / (UInt128 lhs, double rhs) => (double)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double operator % (UInt128 lhs, double rhs) => (double)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs + (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs - (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs * (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs / (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs % (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs + (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs - (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs * (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs / (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs % (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs + (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs - (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs * (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs / (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs % (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs + (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs - (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs * (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs / (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs % (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs + (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs - (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs * (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs / (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs % (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs + (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs - (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs * (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs / (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs % (double4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs + rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs - rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs * rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs / rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs % rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator << (UInt128 value, int n)
        {
            UInt128 result = shl(value, n);
            
            if (constexpr.IS_TRUE(value.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            //constexpr.ASSUME(result == UInt128.umul(value, shl(1, n)));
            constexpr.ASSUME((result & (shl(1, n) - 1)).IsZero);
            //constexpr.ASSUME(tzcnt(result) >= tzcnt(value));
            //constexpr.ASSUME(tzcnt(result) == min(128, tzcnt(value) + n));
            constexpr.ASSUME(countbits(result) <= countbits(value));
            if (constexpr.IS_TRUE(ispow2(value)))
            {
                constexpr.ASSUME(ispow2(result) || result.IsZero);
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator >> (UInt128 value, int n)
        {
            UInt128 result;
            
            if (!constexpr.IS_TRUE(n <= 127 && n >= 0))
            {
                n &= 127;
            }

            if (constexpr.IS_TRUE(value.hi64 == 0))
            {
                result = new UInt128((n < 64) ? (value.lo64 >> n) : 0, 0);
            }
            else if (constexpr.IS_CONST(n))
            {
                result = __const.shruint128(value, n);
            }
            else
            {
                int n2 = n;
                if (!constexpr.IS_TRUE(n <= 63 && n >= 0))
                {
                    n2 &= 63;
                }

                bool upper = n >= 64;

                ulong hiShifted = value.hi64 >> n2;

                ulong carry      = (value.hi64 << 1) << (63 - n2);
                ulong loCombined = (value.lo64 >> n2) | carry;

                ulong outHi = upper ? 0           : hiShifted;
                ulong outLo = upper ? hiShifted   : loCombined;

                result = new UInt128(outLo, outHi);
            }

            //constexpr.ASSUME(result == value / ((UInt128)1 << n)));
            if (constexpr.IS_TRUE(value.IsZero))
            {
                constexpr.ASSUME(result.IsZero);
            }
            if (constexpr.IS_TRUE(n != 0))
            {
                constexpr.ASSUME((result & ~(((UInt128)1 << (128 - n)) - 1)).IsZero);
            }
            constexpr.ASSUME(lzcnt(result) >= lzcnt(value));
            constexpr.ASSUME(countbits(result) <= countbits(value));
            if (constexpr.IS_TRUE(ispow2(value)))
            {
                constexpr.ASSUME(ispow2(result) || result.IsZero);
            }
            constexpr.ASSUME((result << n) <= value);
            constexpr.ASSUME(value == (result << n) + (value & (((UInt128)1 << n) - 1)));

            return result;
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
            bool result = cmpeq(left, right);
            
            constexpr.ASSUME(result == !cmpneq(left, right));
            constexpr.ASSUME(result == (!cmplt(left, right) && !cmplt(right, left)));
            constexpr.ASSUME(result == (cmpge(left, right) && cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, ulong right)
        {
            bool result = cmpeq(left, right);
            
            constexpr.ASSUME(result == !cmpneq(left, right));
            constexpr.ASSUME(result == (!cmplt(left, right) && !cmplt(right, left)));
            constexpr.ASSUME(result == (cmpge(left, right) && cmpge(right, left)));

            return result;
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
            bool result = cmpneq(left, right);

            constexpr.ASSUME(result == !cmpeq(left, right));
            constexpr.ASSUME(result == (cmplt(left, right) || cmplt(right, left)));
            constexpr.ASSUME(result == (!cmpge(left, right) || !cmpge(right, left)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, ulong right)
        {
            bool result = cmpneq(left, right);
            
            constexpr.ASSUME(result == !cmpeq(left, right));
            constexpr.ASSUME(result == (cmplt(left, right) || cmplt(right, left)));
            constexpr.ASSUME(result == (!cmpge(left, right) || !cmpge(right, left)));

            return result;
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
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, ulong right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, UInt128 right)
        {
            bool result = cmplt(left, right);
            
            constexpr.ASSUME(!result || !cmpeq(left, right));
            constexpr.ASSUME(!result || cmpneq(left, right));
            constexpr.ASSUME(result == !cmpge(left, right));
            constexpr.ASSUME(result == (cmpge(right, left) && cmpneq(left, right)));

            return result;
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
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, ulong right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, UInt128 right)
        {
            bool result = cmpge(left, right);

            constexpr.ASSUME(result == (cmplt(right, left) || cmpeq(left, right)));
            constexpr.ASSUME(result == !cmplt(left, right));

            return result;
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (float lhs, UInt128 rhs) => lhs == (float)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (float lhs, UInt128 rhs) => lhs != (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (float lhs, UInt128 rhs) => lhs < (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (float lhs, UInt128 rhs) => lhs > (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (float lhs, UInt128 rhs) => lhs <= (float)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (float lhs, UInt128 rhs) => lhs >= (float)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 lhs, float rhs) => (float)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 lhs, float rhs) => (float)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 lhs, float rhs) => (float)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 lhs, float rhs) => (float)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 lhs, float rhs) => (float)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 lhs, float rhs) => (float)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (double lhs, UInt128 rhs) => lhs == (double)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (double lhs, UInt128 rhs) => lhs != (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (double lhs, UInt128 rhs) => lhs < (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (double lhs, UInt128 rhs) => lhs > (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (double lhs, UInt128 rhs) => lhs <= (double)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (double lhs, UInt128 rhs) => lhs >= (double)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 lhs, double rhs) => (double)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 lhs, double rhs) => (double)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 lhs, double rhs) => (double)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator > (UInt128 lhs, double rhs) => (double)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 lhs, double rhs) => (double)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 lhs, double rhs) => (double)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs == (float2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs != (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs < (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs > (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs <= (float2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.float2 lhs, UInt128 rhs) => lhs >= (float2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (UInt128 lhs, Unity.Mathematics.float2 rhs) => (float2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs == (float3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs != (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs < (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs > (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs <= (float3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.float3 lhs, UInt128 rhs) => lhs >= (float3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (UInt128 lhs, Unity.Mathematics.float3 rhs) => (float3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs == (float4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs != (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs < (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs > (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs <= (float4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.float4 lhs, UInt128 rhs) => lhs >= (float4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (UInt128 lhs, Unity.Mathematics.float4 rhs) => (float4)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs == (double2)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs != (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs < (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs > (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs <= (double2)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (Unity.Mathematics.double2 lhs, UInt128 rhs) => lhs >= (double2)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator == (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator != (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator < (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator > (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator <= (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 operator >= (UInt128 lhs, Unity.Mathematics.double2 rhs) => (double2)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs == (double3)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs != (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs < (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs > (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs <= (double3)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (Unity.Mathematics.double3 lhs, UInt128 rhs) => lhs >= (double3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (UInt128 lhs, Unity.Mathematics.double3 rhs) => (double3)lhs >= rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs == (double4)rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs != (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs < (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs > (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs <= (double4)rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (Unity.Mathematics.double4 lhs, UInt128 rhs) => lhs >= (double4)rhs;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs == rhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs != rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs < rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs > rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs <= rhs;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (UInt128 lhs, Unity.Mathematics.double4 rhs) => (double4)lhs >= rhs;
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
		public override readonly int GetHashCode() => (int)math.hash(this);


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