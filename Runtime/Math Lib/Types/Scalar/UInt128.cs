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
    [Serializable]  [DebuggerTypeProxy(typeof(UInt128.DebuggerProxy))]
    unsafe public partial struct UInt128 : IComparable, IComparable<UInt128>, IConvertible, IEquatable<UInt128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left == (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (byte)left == right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left != (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (byte)left != right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left < (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (byte)left < right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left > (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (byte)left > right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left <= (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (byte)left <= right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (UInt128 left, sbyte right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left >= (byte)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (sbyte left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (byte)left >= right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (UInt128 left, short right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left == (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (short left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ushort)left == right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (UInt128 left, short right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left != (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (short left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ushort)left != right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (UInt128 left, short right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left < (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (short left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ushort)left < right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (UInt128 left, short right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left > (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (short left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ushort)left > right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (UInt128 left, short right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left <= (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (short left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ushort)left <= right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (UInt128 left, short right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left >= (ushort)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (short left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ushort)left >= right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (UInt128 left, int right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left == (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (int left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (uint)left == right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (UInt128 left, int right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left != (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (int left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (uint)left != right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (UInt128 left, int right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left < (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (int left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (uint)left < right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (UInt128 left, int right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left > (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (int left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (uint)left > right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (UInt128 left, int right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left <= (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (int left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (uint)left <= right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (UInt128 left, int right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left >= (uint)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (int left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (uint)left >= right;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (UInt128 left, long right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left == (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator == (long left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ulong)left == right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (UInt128 left, long right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left != (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator != (long left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ulong)left != right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (UInt128 left, long right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left < (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator < (long left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ulong)left < right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (UInt128 left, long right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left > (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator > (long left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ulong)left > right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (UInt128 left, long right)
        {
            if (right < 0)
            {
                return false;
            }
            else 
            {
                return left <= (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <= (long left, UInt128 right)
        {
            if (left < 0)
            {
                return true;
            }
            else 
            {
                return (ulong)left <= right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (UInt128 left, long right)
        {
            if (right < 0)
            {
                return true;
            }
            else 
            {
                return left >= (ulong)right;
            }
        }
                                                           
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >= (long left, UInt128 right)
        {
            if (left < 0)
            {
                return false;
            }
            else 
            {
                return (ulong)left >= right;
            }
        }


        internal sealed class DebuggerProxy
        {
            public BigInteger value;

            public DebuggerProxy(UInt128 v)
            {
                value = v;
            }
        }


        public ulong lo64;
        public ulong hi64;


        public static UInt128 MinValue => new UInt128(0, 0);
        public static UInt128 MaxValue => new UInt128(ulong.MaxValue, ulong.MaxValue);

        internal bool IsZero => this == 0;
        internal bool IsNotZero => this != 0;
        internal bool IsMaxValue => this == MaxValue;
        internal bool IsNotMaxValue => this != MaxValue;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(long lo64, long hi64) 
            : this((ulong)lo64, (ulong)hi64) { }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UInt128(ulong lo64, ulong hi64)
        {
            this.lo64 = lo64;
            this.hi64 = hi64;
        }


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
            return value.intern;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(byte value)
        {
            return new UInt128(value, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ushort value)
        {
            return new UInt128(value, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(uint value)
        {
            return new UInt128(value, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UInt128(ulong value)
        {
            return new UInt128(value, 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(sbyte value)
        {
            long signExtended = value;
            long hi = signExtended >> 63;

            return new UInt128((ulong)signExtended, (ulong)hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(short value)
        {
            long signExtended = value;
            long hi = signExtended >> 63;

            return new UInt128((ulong)signExtended, (ulong)hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(int value)
        {
            long signExtended = value;
            long hi = signExtended >> 63;

            return new UInt128((ulong)signExtended, (ulong)hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(long value)
        {
            long hi = value >> 63;

            return new UInt128((ulong)value, (ulong)hi);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(half value)
        {
            return (UInt128)(float)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(float value)
        {
            long sign = asint(value) >> 31;
            value = abs(value);
            
            UInt128 result;
            if (value <= ulong.MaxValue)
            {
                result = (ulong)value;
            }
            else
            {
                int shift = (int)max(63f, ceil(log2(value))) - 63; 
                result = (ulong)(value * exp2(-shift, Promise.NoOverflow));
                result <<= shift;
            }

            UInt128 negativeMask = new UInt128(sign, sign);
            result ^= negativeMask;
            result -= negativeMask;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(double value)
        {
            long sign = aslong(value) >> 63;
            value = abs(value);
            
            UInt128 result;
            if (value <= ulong.MaxValue)
            {
                result = (ulong)value;
            }
            else
            {
                int shift = (int)max(63d, ceil(log2(value))) - 63; 
                result = (ulong)(value * exp2(-(long)(uint)shift, Promise.NoOverflow));
                result <<= shift;
            }
            
            UInt128 negativeMask = new UInt128(sign, sign);
            result ^= negativeMask;
            result -= negativeMask;

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(decimal value)
        {
            int[] bits = decimal.GetBits(decimal.Truncate(value));

            UInt128 result = new UInt128((uint)bits[0] | ((ulong)bits[1] << 32), (uint)bits[2]);
            
            if (value < 0)
            {
                result = (UInt128)(-(Int128)result);
            }

            return result;
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
            if (Sse2.IsSse2Supported)
            {
                v128 sse = *(v128*)&value;
                v128 cvt = RegisterConversion.ToV128((float2)(*(ulong2*)&value));
                
                v128 hi0;
                if (Sse4_1.IsSse41Supported)
                {
                    hi0 = Sse4_1.cmpeq_epi64(sse, Sse2.setzero_si128());
                    hi0 = Sse2.shuffle_epi32(hi0, Sse.SHUFFLE(3, 3, 3, 3));
                }
                else
                {
                    v128 cmpeq32 = Sse2.cmpeq_epi32(sse, Sse2.setzero_si128());
                    cmpeq32 = Sse2.and_si128(cmpeq32, Sse2.srli_epi64(cmpeq32, 32));
                    hi0 = Sse2.shuffle_epi32(cmpeq32, Sse.SHUFFLE(2, 2, 2, 2));
                }

                v128 hi = Sse2.andnot_si128(hi0, new v128((float)ulong.MaxValue));
                v128 lo = Xse.blendv_si128(Sse2.bsrli_si128(cvt, sizeof(float)), new v128(1f), hi0);

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
            if (Sse2.IsSse2Supported)
            {
                v128 sse = *(v128*)&value;
                v128 cvt = Xse.cvtepu64_pd(sse);

                v128 hi0 = Xse.cmpeq_epi64(sse, Sse2.setzero_si128());
                hi0 = Sse2.bsrli_si128(hi0, sizeof(double));

                v128 hi = Sse2.andnot_si128(hi0, new v128((double)ulong.MaxValue, (double)ulong.MaxValue));
                v128 lo = Xse.blendv_si128(Sse2.bsrli_si128(cvt, sizeof(double)), new v128(1d), hi0);

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
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo64 + right.lo64;
            ulong hi = left.hi64 + right.hi64;

            bool carry = lo < left.lo64;
            hi += tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, ulong right)
        {
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo64 + right;
            bool carry = lo < left.lo64;
            ulong hi = left.hi64 + tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (ulong left, UInt128 right) => right + left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, uint right)
        {
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo64 + right;
            bool carry = lo < left.lo64;
            ulong hi = left.hi64 + tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (uint left, UInt128 right) => right + left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, UInt128 right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo64 - right.lo64;
            ulong hi = left.hi64 - right.hi64;

            hi -= tobyte(left.lo64 < right.lo64); 
            
            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, ulong right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo64 - right;
            ulong hi = left.hi64;
            
            hi -= tobyte(left.lo64 < right); 
            
            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (ulong left, UInt128 right) => (UInt128)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, uint right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo64 - right;
            ulong hi = left.hi64;
            
            hi -= tobyte(left.lo64 < right); 
            
            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (uint left, UInt128 right) => (UInt128)left - right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(left))
            {
                if (left == 0)
                {
                    return 0;
                }
                else if (left == 1)
                {
                    return right;
                }
                else
                {
                    if (left == 2)
                    {
                        return right + right;
                    }
                    else if (left == 3)
                    {
                        return right + right + right;
                    }
                    else if (ispow2(left))
                    {
                        return right << tzcnt(left);
                    }
                }
            }
            else if (Constant.IsConstantExpression(right))
            {
                if (right == 0)
                {
                    return 0;
                }
                else if (right == 1)
                {
                    return left;
                }
                else
                {
                    if (right == 2)
                    {
                        return left + left;
                    }
                    else if (right == 3)
                    {
                        return left + left + left;
                    }
                    else if (ispow2(right))
                    {
                        return left << tzcnt(right);
                    }
                }
            }
                
            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }


            ulong lo = Unity.Burst.Intrinsics.Common.umul128(left.lo64, right.lo64, out ulong hi);

            if (Constant.IsConstantExpression(left.hi64))
            {
                if (Constant.IsConstantExpression(right.hi64))
                {
                    if (left.hi64 == 0)
                    {
                        switch (right.hi64)
                        {
                            case 0:                 break;
                            case ulong.MaxValue:    hi -= left.lo64; break;
                            default:                hi += left.lo64 * right.hi64; break;                
                        }
                    }
                    else if (left.hi64 == ulong.MaxValue)
                    {
                        switch (right.hi64)
                        {
                            case 0:                 hi -= right.lo64; break;
                            case ulong.MaxValue:    hi -= right.lo64 + left.lo64; break;
                            default:                hi =  (hi - right.lo64) + (left.lo64 * right.hi64); break;
                        }
                    }
                    else
                    {
                        switch (right.hi64)
                        {
                            case 0:                 hi += left.hi64 * right.lo64; break;
                            case ulong.MaxValue:    hi =  (hi - left.lo64) + (left.hi64 * right.lo64); break;
                            default:                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64); break;
                        }
                    }
                }
                else
                {
                    switch (left.hi64)
                    {
                        case 0:                 hi += left.lo64 * right.hi64; break;
                        case ulong.MaxValue:    hi =  (hi - right.lo64) + (left.lo64 * right.hi64); break;
                        default:                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64); break;
                    }
                }
            }
            else
            {
                hi += (left.hi64 * right.lo64) + (left.lo64 * right.hi64);
            }

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (UInt128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if (right == 0)
                {
                    return 0;
                }
                else if (right == 1)
                {
                    return left;
                }
                else
                {
                    if (right == 2)
                    {
                        return left + left;
                    }
                    else if (right == 3)
                    {
                        return left + left + left;
                    }
                    else if (ispow2(right))
                    {
                        return left << tzcnt(right);
                    }
                }
            }

            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }


            ulong lo = Unity.Burst.Intrinsics.Common.umul128(left.lo64, right, out ulong hi);

            if (Constant.IsConstantExpression(left.hi64))
            {
                switch (left.hi64)
                {
                    case 0:                 break;
                    case ulong.MaxValue:    hi -= right; break;
                    default:                hi += left.hi64 * right; break;
                }
            }
            else
            {
                hi += left.hi64 * right;
            }

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator * (ulong left, UInt128 right) => right * left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, UInt128 right)
        {
Assert.AreNotEqual(0u, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    return Common.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Common.divuint128(left, right);
            //}
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, ulong right)
        {
Assert.AreNotEqual(0ul, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    return Common.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Common.divuint128(left, right);
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, uint right)
        {
Assert.AreNotEqual(0u, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    return Common.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Common.divuint128(left, right);
            //}
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, UInt128 right)
        {
Assert.AreNotEqual(0u, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    if (right == 1)
            //    {
            //        return 0;
            //    }
            //    else if (right == UInt128.MaxValue)
            //    {
            //        return select(left, 0, right == UInt128.MaxValue);
            //    }
            //    else if (ispow2(right))
            //    {
            //        return left & (right - 1);
            //    }
            //    else
            //    {
            //        return left - ((left / right) * right); 
            //    }
            //}

            return Common.remuint128(left, right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, ulong right)
        {
Assert.AreNotEqual(0ul, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    if (right == 1)
            //    {
            //        return 0;
            //    }
            //    else if (right == UInt128.MaxValue)
            //    {
            //        return select(left, 0, right == UInt128.MaxValue);
            //    }
            //    else if (ispow2(right))
            //    {
            //        return left & (right - 1);
            //    }
            //    else
            //    {
            //        return left - ((left / right) * right); 
            //    }
            //}

            return Common.remuint128(left, right);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator % (UInt128 left, uint right)
        {
Assert.AreNotEqual(0u, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    if (right == 1)
            //    {
            //        return 0;
            //    }
            //    else if (right == UInt128.MaxValue)
            //    {
            //        return select(left, 0, right == UInt128.MaxValue);
            //    }
            //    else if (ispow2(right))
            //    {
            //        return left & (right - 1);
            //    }
            //    else
            //    {
            //        return left - ((left / right) * right); 
            //    }
            //}

            return Common.remuint128(left, right);
        }


        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator << (UInt128 value, int n)
        {
            n &= 127;

            if (Constant.IsConstantExpression(n))
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
                    Hint.Assume(n > 0 && n < 64);

                    return new UInt128(value.lo64 << n, value.hi64 << n | (value.lo64 >> (64 - n)));
                }
                else
                {
                    Hint.Assume(n > 63 && n < 128);

                    return new UInt128(0, (value.lo64 << (n - 64)));
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator >> (UInt128 value, int n)
        {
            n &= 127;

            if (Constant.IsConstantExpression(n))
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
                    Hint.Assume(n > 0 && n < 64);

                    return new UInt128(value.lo64 >> n | (value.hi64 << (64 - n)), value.hi64 >> n);
                }
                else
                {
                    Hint.Assume(n > 63 && n < 128);

                    return new UInt128((value.hi64 >> (n - 64)), 0);
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
        public static UInt128 operator & (UInt128 left, uint right)
        {
            return new UInt128((uint)left.lo64 & right, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (uint left, UInt128 right) => right & left;
        

        
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
        public static UInt128 operator | (UInt128 left, uint right)
        {
            return new UInt128(left.lo64 | right, left.hi64);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (uint left, UInt128 right) => right | left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, ushort right) => left | (uint)right;

        
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
        public static UInt128 operator ^ (UInt128 left, uint right)
        {
            return new UInt128(left.lo64 ^ right, left.hi64);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (uint left, UInt128 right) => right ^ left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if ((right.lo64 | right.hi64) == 0)
                {
                    return (left.lo64 | left.hi64) == 0;
                }
                if ((right.lo64 & right.hi64) == ulong.MaxValue)
                {
                    return (left.lo64 & left.hi64) == ulong.MaxValue;
                }
            }
            else if (Constant.IsConstantExpression(left))
            {
                if ((left.lo64 | left.hi64) == 0)
                {
                    return (right.lo64 | right.hi64) == 0;
                }
                if ((left.lo64 & left.hi64) == ulong.MaxValue)
                {
                    return (right.lo64 & right.hi64) == ulong.MaxValue;
                }
            }

            return left.lo64 == right.lo64 & left.hi64 == right.hi64;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo64 | left.hi64) == 0;
            }

            return left.lo64 == right & left.hi64 == 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ulong left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, uint right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo64 | left.hi64) == 0;
            }

            return left.lo64 == right & left.hi64 == 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (uint left, UInt128 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if ((right.lo64 | right.hi64) == 0)
                {
                    return (left.lo64 | left.hi64) != 0;
                }
                if ((right.lo64 & right.hi64) == ulong.MaxValue)
                {
                    return (left.lo64 & left.hi64) != ulong.MaxValue;
                }
            }
            else if (Constant.IsConstantExpression(left))
            {
                if ((left.lo64 | left.hi64) == 0)
                {
                    return (right.lo64 | right.hi64) != 0;
                }
                if ((left.lo64 & left.hi64) == ulong.MaxValue)
                {
                    return (right.lo64 & right.hi64) != ulong.MaxValue;
                }
            }

            return left.lo64 != right.lo64 | left.hi64 != right.hi64;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo64 | left.hi64) != 0;
            }

            return left.lo64 != right | left.hi64 != 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ulong left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, uint right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo64 | left.hi64) != 0;
            }

            return left.lo64 != right | left.hi64 != 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (uint left, UInt128 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right) && right.hi64 == 0)
            {
                return left < right.lo64;
            }
            else if (Constant.IsConstantExpression(left) && left.hi64 == 0)
            {
                return right > left.lo64;
            }

            bool highBitsDiffer = left.hi64 != right.hi64;
            
            return (left.hi64 < right.hi64 & highBitsDiffer) | andnot(left.lo64 < right.lo64, highBitsDiffer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, ulong right)
        {
            return left.hi64 == 0 & left.lo64 < right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, UInt128 right)
        {
            return right.hi64 != 0 | left < right.lo64;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, uint right)
        {
            return left.hi64 == 0 & left.lo64 < right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (uint left, UInt128 right)
        {
            return right.hi64 != 0 | left < right.lo64;
        }


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
        public static bool operator <= (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right) && right.hi64 == 0)
            {
                return left <= right.lo64;
            }
            else if (Constant.IsConstantExpression(left) && left.hi64 == 0)
            {
                return right >= left.lo64;
            }

            bool highBitsDiffer = left.hi64 != right.hi64;
            
            return (left.hi64 <= right.hi64 & highBitsDiffer) | andnot(left.lo64 <= right.lo64, highBitsDiffer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, ulong right)
        {
            return left.hi64 == 0 & left.lo64 <= right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ulong left, UInt128 right)
        {
            return right.hi64 != 0 | left <= right.lo64;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, uint right)
        {
            return left.hi64 == 0 & left.lo64 <= right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (uint left, UInt128 right)
        {
            return right.hi64 != 0 | left <= right.lo64;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, UInt128 right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, ulong right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (ulong left, UInt128 right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (UInt128 left, uint right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator >= (uint left, UInt128 right) => right <= left;
        #endregion
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(UInt128 other)
        {
            return compareto(this, other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(ulong other)
        {
            return tobyte(this > other) - tobyte(this < other);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int CompareTo(object obj)
        {
            return CompareTo((UInt128)obj);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(UInt128 other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            return this == (UInt128)obj;
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            ulong _64 = lo64 ^ hi64;

            return (int)_64 ^ (int)(_64 >> 32);
        }


        #region string
        public override string ToString()
        {
            return ((BigInteger)this).ToString();
        }

        public string ToString(string format)
        {
            return ((BigInteger)this).ToString(format);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(null, provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return ((BigInteger)this).ToString(format, provider);
        }

        
        public static UInt128 Parse(string value)
        {
            if (!TryParse(value, out UInt128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static UInt128 Parse(string value, NumberStyles style)
        {
            if (!TryParse(value, style, null, out UInt128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static UInt128 Parse(string value, IFormatProvider provider)
        {
            if (!TryParse(value, NumberStyles.Integer, provider, out UInt128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static UInt128 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            if (!TryParse(value, style, provider, out UInt128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static bool TryParse(string value, out UInt128 result)
        {
            return TryParse(value, NumberStyles.Integer, null, out result);
        }

        public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out UInt128 result)
        {
            result = 0;
            bool success;
            BigInteger bigResult;

            if (value.Substring(0, 2) == "0x")
            {
                value = value.Replace("_", "");
                value = value.Remove(1, 1);

                success = BigInteger.TryParse(value, NumberStyles.HexNumber, provider, out bigResult); 
            }
            else
            {
                success = BigInteger.TryParse(value, style, provider, out bigResult); 
            }

            if (success & bigResult <= MaxValue & bigResult.Sign != -1)
            {
                result = (UInt128)bigResult;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region IConvertible
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return this != 0;
        }

        public byte ToByte(IFormatProvider provider)
        {
            return (byte)this;
        }

        public char ToChar(IFormatProvider provider)
        {
            return (char)(ushort)this;
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return (DateTime)Convert.ChangeType((BigInteger)this, typeof(DateTime));
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return (decimal)this;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return (double)this;
        }

        public short ToInt16(IFormatProvider provider)
        {
            return (short)this;
        }

        public int ToInt32(IFormatProvider provider)
        {
            return (int)this;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return (long)this;
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return (sbyte)this;
        }

        public float ToSingle(IFormatProvider provider)
        {
            return (float)this;
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType((BigInteger)this, conversionType);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return (ushort)this;
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return (uint)this;
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)this;
        }

        public bool Equals(long other)
        {
            return this == other;
        }

        public bool Equals(ulong other)
        {
            return this == other;
        }
        #endregion
    }
}