using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;


namespace MaxMath
{
    [Serializable]  
    [DebuggerTypeProxy(typeof(Int128.DebuggerProxy))]
    unsafe public struct Int128 : IComparable, IComparable<Int128>, IConvertible, IEquatable<Int128>, IEquatable<ulong>, IEquatable<long>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public BigInteger value;

            public DebuggerProxy(Int128 v)
            {
                value = v;
            }
        }


        internal UInt128 intern;

        public ulong lo64 => intern.lo64;
        public ulong hi64 => intern.hi64;
        
        internal bool IsZero => this == 0;
        internal bool IsNotZero => this != 0;
        internal bool IsMaxValue => this == MaxValue;
        internal bool IsNotMaxValue => this != MaxValue;

        public static Int128 MinValue => new Int128(0, 1ul << 63);
        public static Int128 MaxValue => new Int128(ulong.MaxValue, (ulong)long.MaxValue);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Int128(ulong lo, ulong hi)
        {
            intern = new UInt128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Int128(long lo, long hi)
            : this ((ulong)lo, (ulong)hi) { }

        
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
		public static implicit operator Int128(byte value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(ushort value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(uint value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(ulong value)
        {
            return (Int128)(UInt128)value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(sbyte value)
        {
            return (Int128)(UInt128)value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(short value)
        {
            return (Int128)(UInt128)value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(int value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Int128(long value)
        {
            return (Int128)(UInt128)value;
        }












































        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(half value)
        {
            return (Int128)(UInt128)value;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(float value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(double value)
        {
            return (Int128)(UInt128)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(decimal value)
        {
            return (Int128)(UInt128)value;
        }











































        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator Int128(BigInteger value)
        {            
            return value.Sign == -1 ? -(Int128)(UInt128)BigInteger.Abs(value) : (Int128)(UInt128)value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Guid(Int128 value)
        {
            return *(Guid*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator byte(Int128 value)
        {
            return (byte)value.intern.lo64;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator ushort(Int128 value)
        {
            return (ushort)value.intern.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint(Int128 value)
        {
            return (uint)value.intern.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator ulong(Int128 value)
        {
            return value.intern.lo64;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator sbyte(Int128 value)
        {
            return (sbyte)value.intern.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator short(Int128 value)
        {
            return (short)value.intern.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int(Int128 value)
        {
            return (int)value.intern.lo64;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator long(Int128 value)
        {
            return (long)value.intern.lo64;
        }
        
        





































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
            return (Int128)0 - value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ~ (Int128 value)
        {
            return (Int128)~value.intern;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ++ (Int128 value)
        {
            return (Int128)(value.intern + 1u);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator -- (Int128 value)
        {
            return (Int128)(value.intern - 1u);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, Int128 right)
        {
            return (Int128)(left.intern + right.intern);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, long right)
        {
            return left + (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (long left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, int right)
        {
            return left + (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (int left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, ulong right)
        {
            return (Int128)((UInt128)left + right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (ulong left, Int128 right) => right + left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (Int128 left, uint right)
        {
            return (Int128)((UInt128)left + right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator + (uint left, Int128 right) => right + left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, Int128 right)
        {
            return (Int128)(left.intern - right.intern);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, long right)
        {
            return left - (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (long left, Int128 right)
        {
            return (Int128)left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, int right)
        {
            return left - (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (int left, Int128 right)
        {
            return (Int128)left - right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, ulong right)
        {
            return (Int128)((UInt128)left - right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (ulong left, Int128 right)
        {
            return (Int128)(left - (UInt128)right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (Int128 left, uint right)
        {
            return (Int128)((UInt128)left - right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator - (uint left, Int128 right)
        {
            return (Int128)(left - (UInt128)right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, Int128 right)
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
                    else if (ispow2(left))
                    {
                        return right << tzcnt(left);
                    }
                }
            }

            if (Constant.IsConstantExpression(left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)) && (left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)))
            {
                if (Constant.IsConstantExpression(right.intern.hi64 == (ulong)((long)right.intern.lo64 >> 63)) && (right.intern.hi64 == (ulong)((long)right.intern.lo64 >> 63)))
                {
                    long _lo = Xse.imul128((long)left.intern.lo64, (long)right.intern.lo64, out long _hi);

                    return new Int128(_lo, _hi);
                }

                return (long)left * right;
            }
            
            if (Constant.IsConstantExpression(left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)) && (left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)))
            {
                return left * (long)right;
            }
            
            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }
            

            ulong lo = Common.umul128(left.intern.lo64, right.intern.lo64, out ulong hi);
            hi += (right.intern.hi64 * left.intern.lo64) + (left.intern.hi64 * right.intern.lo64);

            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator * (Int128 left, long right)
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
                        return (Int128)right + right;
                    }
                    else if (left == 3)
                    {
                        return (Int128)right + right + right;
                    }
                    else if (ispow2(left))
                    {
                        return (Int128)right << tzcnt(left);
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

            if (Constant.IsConstantExpression(left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)) && (left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)))
            {   
                long _lo = Xse.imul128((long)left.intern.lo64, right, out long _hi);

                return new Int128(_lo, _hi);
            }
            
            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }


            ulong lo = Common.umul128(left.intern.lo64, (ulong)right, out ulong hi);
            hi += (ulong)-(long)(left.intern.lo64 & (ulong)(right >> 63));
            hi += left.intern.hi64 * (ulong)right;

            return new Int128(lo, hi);
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
                        return (Int128)right + right;
                    }
                    else if (left == 3)
                    {
                        return (Int128)right + right + right;
                    }
                    else if (ispow2(left))
                    {
                        return (Int128)right << tzcnt(left);
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

            if (Constant.IsConstantExpression(left.intern.hi64) && (left.intern.hi64 == 0))
            {   
                ulong _lo = Common.umul128(left.intern.lo64, right, out ulong _hi);

                return new Int128(_lo, _hi);
            }

            if (Constant.IsConstantExpression(left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)) && (left.intern.hi64 == (ulong)((long)left.intern.lo64 >> 63)))
            {   
                long _lo = Xse.imul128((long)left.intern.lo64, (long)right, out long _hi);

                return new Int128(_lo, _hi);
            }
            
            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }
            

            ulong lo = Common.umul128(right, left.intern.lo64, out ulong hi);
            hi += left.intern.hi64 * right;

            return new Int128(lo, hi);
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
Assert.IsFalse(left == MinValue && right == -1);

            if (Constant.IsConstantExpression(right))
            {
Assert.AreNotEqual(right, (Int128)0);

                if (right == 1)
                {
                    return left;
                }
                else if (right == -1)
                {
                    return -left;
                }
                else if (ispow2(abs(right)))
                {

                }
            }

            bool leftIsNegative = (long)left.intern.hi64 < 0;
            bool rightIsNegative = (long)right.intern.hi64 < 0;

            UInt128 absDiv = select(left, -left, leftIsNegative).intern / select(right, -right, rightIsNegative).intern;
            
            ulong mustNegate = (ulong)-(tolong(leftIsNegative) ^ tolong(rightIsNegative));
            ulong xorLo = absDiv.lo64 ^ mustNegate; 
            ulong xorHi = absDiv.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, long right)
        {
Assert.IsFalse(left == MinValue && right == -1);

            if (Constant.IsConstantExpression(right))
            {
Assert.AreNotEqual(right, 0);

                if (right == 1)
                {
                    return left;
                }
                else if (right == -1)
                {
                    return -left;
                }
                else if (ispow2(abs(right)))
                {

                }
            }

            bool leftIsNegative = (long)left.intern.hi64 < 0;
            bool rightIsNegative = right < 0;

            UInt128 absDiv = select(left, -left, leftIsNegative).intern / (ulong)select(right, -right, rightIsNegative);
            
            ulong mustNegate = (ulong)-(tolong(leftIsNegative) ^ tolong(rightIsNegative));
            ulong xorLo = absDiv.lo64 ^ mustNegate; 
            ulong xorHi = absDiv.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, int right)
        {
Assert.IsFalse(left == MinValue && right == -1);

            if (Constant.IsConstantExpression(right))
            {
Assert.AreNotEqual(right, 0);

                if (right == 1)
                {
                    return left;
                }
                else if (right == -1)
                {
                    return -left;
                }
                else if (ispow2(abs(right)))
                {

                }
            }

            bool leftIsNegative = (long)left.intern.hi64 < 0;
            bool rightIsNegative = right < 0;

            UInt128 absDiv = select(left, -left, leftIsNegative).intern / (uint)select(right, -right, rightIsNegative);
            
            ulong mustNegate = (ulong)-(tolong(leftIsNegative) ^ tolong(rightIsNegative));
            ulong xorLo = absDiv.lo64 ^ mustNegate; 
            ulong xorHi = absDiv.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right))
            {
Assert.AreNotEqual(right, 0ul);

                if (right == 1)
                {
                    return left;
                }
                else if (ispow2(right))
                {

                }
            }

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absDiv = select(left, -left, leftIsNegative).intern / right;
            
            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absDiv.lo64 ^ mustNegate; 
            ulong xorHi = absDiv.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator / (Int128 left, uint right)
        {
            if (Constant.IsConstantExpression(right))
            {
Assert.AreNotEqual(right, 0ul);

                if (right == 1)
                {
                    return left;
                }
                else if (ispow2(right))
                {

                }
            }

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absDiv = select(left, -left, leftIsNegative).intern / right;
            
            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absDiv.lo64 ^ mustNegate; 
            ulong xorHi = absDiv.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, Int128 right)
        {
Assert.AreNotEqual(right, 0ul);

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absRem = select(left, -left, leftIsNegative).intern % abs(right).intern;

            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absRem.lo64 ^ mustNegate; 
            ulong xorHi = absRem.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, long right)
        {
Assert.AreNotEqual(right, 0);

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absRem = select(left, -left, leftIsNegative).intern % (ulong)abs(right);

            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absRem.lo64 ^ mustNegate; 
            ulong xorHi = absRem.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, int right)
        {
Assert.AreNotEqual(right, 0);

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absRem = select(left, -left, leftIsNegative).intern % (uint)abs(right);

            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absRem.lo64 ^ mustNegate; 
            ulong xorHi = absRem.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, ulong right)
        {
Assert.AreNotEqual(right, 0ul);

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absRem = select(left, -left, leftIsNegative).intern % right;

            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absRem.lo64 ^ mustNegate; 
            ulong xorHi = absRem.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator % (Int128 left, uint right)
        {
Assert.AreNotEqual(right, 0u);

            bool leftIsNegative = (long)left.intern.hi64 < 0;

            UInt128 absRem = select(left, -left, leftIsNegative).intern % right;

            ulong mustNegate = (ulong)-tolong(leftIsNegative);
            ulong xorLo = absRem.lo64 ^ mustNegate; 
            ulong xorHi = absRem.hi64 ^ mustNegate; 
            ulong lo = xorLo - mustNegate;
            ulong hi = xorHi - mustNegate;
            hi -= tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator << (Int128 left, int n)
        {
            return (Int128)(left.intern << n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator >> (Int128 left, int n)
        {
            n &= 127;

            if (Constant.IsConstantExpression(n))
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
                    Hint.Assume(n > 0 && n < 64);

                    return new Int128(left.intern.lo64 >> n | (left.intern.hi64 << (64 - n)), (ulong)((long)left.intern.hi64 >> n));
                }
                else
                {
                    Hint.Assume(n > 63 && n < 128);

                    return new Int128(((long)left.intern.hi64 >> (n - 64)), (long)left.intern.hi64 >> 63);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, Int128 right)
        {
            return (Int128)(left.intern & right.intern);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, long right)
        {
            return left & (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (long left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, int right)
        {
            return left & (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (int left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, ulong right)
        {
            return new Int128(left.intern.lo64 & right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (ulong left, Int128 right) => right & left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (Int128 left, uint right)
        {
            return new Int128((uint)left.intern.lo64 & right, 0ul);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator & (uint left, Int128 right) => right & left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, Int128 right)
        {
            return (Int128)(left.intern | right.intern);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, long right)
        {
            return left | (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (long left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, int right)
        {
            return left | (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (int left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, ulong right)
        {
            return new Int128(left.intern.lo64 | right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (ulong left, Int128 right) => right | left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (Int128 left, uint right)
        {
            return new Int128(left.intern.lo64 | right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator | (uint left, Int128 right) => right | left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, Int128 right)
        {
            return (Int128)(left.intern ^ right.intern);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, long right)
        {
            return left ^ (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (long left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, int right)
        {
            return left ^ (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (int left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, ulong right)
        {
            return new Int128(left.intern.lo64 ^ right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (ulong left, Int128 right) => right ^ left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (Int128 left, uint right)
        {
            return new Int128(left.intern.lo64 ^ right, 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Int128 operator ^ (uint left, Int128 right) => right ^ left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, Int128 right)
        {
            return left.intern == right.intern;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, long right)
        {
            return left.intern.lo64 == (ulong)right & left.intern.hi64 == (ulong)(right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (long left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, int right)
        {
            return left.intern.lo64 == (ulong)right & left.intern.hi64 == (ulong)((long)right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (int left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, ulong right)
        {
            return left.intern.lo64 == right & left.intern.hi64 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (ulong left, Int128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (Int128 left, uint right)
        {
            return left.intern.lo64 == right & left.intern.hi64 == 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator == (uint left, Int128 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, Int128 right)
        {
            return left.intern != right.intern;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, long right)
        {
            return left.intern.lo64 != (ulong)right | left.intern.hi64 != (ulong)(right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (long left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, int right)
        {
            return left.intern.lo64 != (ulong)right | left.intern.hi64 != (ulong)((long)right >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (int left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, ulong right)
        {
            return left.intern.lo64 != right | left.intern.hi64 != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (ulong left, Int128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (Int128 left, uint right)
        {
            return left.intern.lo64 != right | left.intern.hi64 != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator != (uint left, Int128 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, Int128 right)
        {
            if (Constant.IsConstantExpression(right) && ((right.intern.lo64 | right.intern.hi64) == 0))
            {
                return (long)left.intern.hi64 < 0;
            }
            else if (Constant.IsConstantExpression(left) && ((left.intern.lo64 | left.intern.hi64) == 0))
            {
                return ((long)right.intern.hi64 > 0) | (((long)right.intern.hi64 == 0) & right.intern.lo64 != 0); 
            }

            return ((long)left.intern.hi64 < (long)right.intern.hi64) | ((left.intern.hi64 == right.intern.hi64) & left.intern.lo64 < right.intern.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (Int128 left, long right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (long)left.intern.hi64 < 0;
            }
            else if (Constant.IsConstantExpression(left) && isinrange(left, long.MinValue, long.MaxValue))
            {
                return (long)left.intern.lo64 < (long)right;
            }
            
            return left < (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (long left, Int128 right)
        {
            if (Constant.IsConstantExpression(right) && isinrange(right, long.MinValue, long.MaxValue))
            {
                return (long)right.intern.lo64 > left;
            }
            else if (Constant.IsConstantExpression(left) && left == 0)
            {
                return ((long)right.intern.hi64 > 0) | (((long)right.intern.hi64 == 0) & right.intern.lo64 != 0); 
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
            if (Constant.IsConstantExpression(left) && (left.intern.hi64 == 0))
            {
                return left.intern.lo64 < right;
            }

            return ((long)left.intern.hi64 < 0) | ((left.intern.hi64 == 0) & (left.intern.lo64 < right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator < (ulong left, Int128 right)
        {
            if (Constant.IsConstantExpression(right) && (right.intern.hi64 == 0))
            {
                return right.intern.lo64 > left;
            }
            
            return ((long)right.intern.hi64 > 0) | ((right.intern.hi64 == 0) & (right.intern.lo64 > left));
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
            if (Constant.IsConstantExpression(right))
            {
                if ((right.intern.lo64 | right.intern.hi64) == 0)
                {
                    return (long)left.intern.hi64 < 0 | ((left.intern.lo64 | left.intern.hi64) == 0);
                }
            }
            else if (Constant.IsConstantExpression(left))
            {
                if ((left.intern.lo64 | left.intern.hi64) == 0)
                {
                    return (long)right.intern.hi64 > 0 | ((right.intern.lo64 | right.intern.hi64) == 0);
                }
            }
            
            return ((long)left.intern.hi64 < (long)right.intern.hi64) | ((left.intern.hi64 == right.intern.hi64) & left.intern.lo64 <= right.intern.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (Int128 left, long right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if (right == 0)
                {
                    return (long)left.intern.hi64 < 0 | ((left.intern.lo64 | left.intern.hi64) == 0);
                }
            }

            return left <= (Int128)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (long left, Int128 right)
        {
            if (Constant.IsConstantExpression(left))
            {
                if (left == 0)
                {
                    return (long)right.intern.hi64 >= 0 & ((right.intern.lo64 | right.intern.hi64) != 0);
                }
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
            if (Constant.IsConstantExpression(left) && (left.intern.hi64 == 0))
            {
                return left.intern.lo64 <= right;
            }

            return ((long)left.intern.hi64 < 0) | ((left.intern.hi64 == 0) & (left.intern.lo64 <= right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <= (ulong left, Int128 right)
        {
            if (Constant.IsConstantExpression(right) && (right.intern.hi64 == 0))
            {
                return left <= right.intern.lo64;
            }

            return ((long)right.intern.hi64 > 0) | ((right.intern.hi64 == 0) & (left <= right.intern.lo64));
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
		public int CompareTo(Int128 other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(long other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(ulong other)
        {
            return compareto(this, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int CompareTo(object obj)
        {
            return CompareTo((Int128)obj);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(Int128 other)
        {
            return this == other;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override bool Equals(object obj)
        {
            return this == (Int128)obj;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
        {
            return intern.GetHashCode();
        }

        
        #region string
        internal const byte MAX_DECIMAL_DIGITS = 39;

        public override string ToString()
        {
            if (IsZero)
            {
                return "0";
            }

            char* DECIMAL_DIGITS = stackalloc char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            char* result = stackalloc char[MAX_DECIMAL_DIGITS + 1];
            char* currentDigit = result + (MAX_DECIMAL_DIGITS + 1 - 1);
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

            int length = (MAX_DECIMAL_DIGITS + 1) - (int)(((ulong)++currentDigit - (ulong)result) / sizeof(char));

            return new string(currentDigit, 0, length);
        }

        public string ToString(string format)
        {
            if (format == "X" || format == "x")
            {
                string hex = DevTools.Dump.Hex(this, false);

                return (format == "x") ? hex.ToLower() : hex;
            }

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

        
		public static Int128 Parse(string value)
        {
            if (!TryParse(value, out Int128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static Int128 Parse(string value, NumberStyles style)
        {
            if (!TryParse(value, style, null, out Int128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static Int128 Parse(string value, IFormatProvider provider)
        {
            if (!TryParse(value, NumberStyles.Integer, provider, out Int128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

        public static Int128 Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            if (!TryParse(value, style, provider, out Int128 result))
            {
                throw new FormatException();
            }
            else
            {
                return result;
            }
        }

		public static bool TryParse(string value, out Int128 result)
        {
            return TryParse(value, NumberStyles.Integer, null, out result);
        }

		public static bool TryParse(string value, NumberStyles style, IFormatProvider provider, out Int128 result)
        {
            result = 0;
            bool success;
            BigInteger bigResult;

            if (value.Substring(0, 2) == "0x")
            {
                value = value.Replace("_", "");

                if (value.Length == 34)
                {
                    success = BigInteger.TryParse(value.Substring(2, value.Length - 2), NumberStyles.HexNumber, provider, out bigResult); 
                }
                else
                {
                    value = value.Remove(1, 1);
                    success = BigInteger.TryParse(value, NumberStyles.HexNumber, provider, out bigResult); 
                }
            }
            else
            {
                success = BigInteger.TryParse(value, style, provider, out bigResult); 
            }

            if (success & bigResult <= MaxValue & bigResult >= MinValue)
            {
                result = (Int128)bigResult;
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