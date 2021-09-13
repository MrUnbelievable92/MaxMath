using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Numerics;
using System.Diagnostics;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [DebuggerTypeProxy(typeof(UInt128.DebuggerProxy))]
    unsafe public struct UInt128 : IComparable, IComparable<UInt128>, IConvertible, IEquatable<UInt128>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public BigInteger value;

            public DebuggerProxy(UInt128 v)
            {
                value = v;
            }
        }


        internal ulong lo;
        internal ulong hi;


        public static UInt128 MinValue => new UInt128(0, 0);
        public static UInt128 MaxValue => new UInt128(ulong.MaxValue, ulong.MaxValue);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal UInt128(ulong lo, ulong hi)
        {
            this.lo = lo;
            this.hi = hi;
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
            bool isNegative = value < 0;
            UInt128 result;

            value = abs(value);

            if (value <= ulong.MaxValue)
            {
                result = new UInt128((ulong)value, 0);
            }
            else
            {
                int shift = max(0, (int)ceil(log2(value)) - 63); 

                result = new UInt128((ulong)(value / maxmath.pow(2f, shift)), 0);
                result <<= shift;
            }

            if (isNegative)
            {
                result = (UInt128)(-(Int128)result);
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator UInt128(double value)
        {
            bool isNegative = value < 0;
            UInt128 result;

            value = abs(value);

            if (value <= ulong.MaxValue)
            {
                result = new UInt128((ulong)value, 0);
            }
            else
            {
                int shift = max(0, (int)ceil(log2(value)) - 63); 

                result = new UInt128((ulong)(value / maxmath.pow(2d, shift)), 0);
                result <<= shift;
            }
            
            if (isNegative)
            {
                result = (UInt128)(-(Int128)result);
            }

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
            return (byte)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort(UInt128 value)
        {
            return (ushort)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint(UInt128 value)
        {
            return (uint)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong(UInt128 value)
        {
            return (ulong)value.lo;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte(UInt128 value)
        {
            return (sbyte)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short(UInt128 value)
        {
            return (short)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int(UInt128 value)
        {
            return (int)value.lo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long(UInt128 value)
        {
            return (long)value.lo;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half(UInt128 value)
        {
            return (half)(float)value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(UInt128 value)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.cvtsi32_si128(asint((float)ulong.MaxValue));

                v128 hiIsZero = Sse4_1.cmpeq_epi64(new v128(value.lo, value.hi), Sse2.setzero_si128());
                hiIsZero = Sse2.bsrli_si128(hiIsZero, 1 * sizeof(ulong));
                MAX_VALUE = Sse.and_ps(MAX_VALUE, hiIsZero);

                return mad((float)value.hi, MAX_VALUE.Float0, (float)value.lo);
            }
            else
            {
                return mad((float)value.hi, 
                           asfloat(asint((float)ulong.MaxValue) & -tosbyte(value.hi == 0)),
                           (float)value.lo);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(UInt128 value)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 MAX_VALUE = Sse2.cvtsi64x_si128(aslong((double)ulong.MaxValue));

                v128 hiIsZero = Sse4_1.cmpeq_epi64(new v128(value.lo, value.hi), Sse2.setzero_si128());
                hiIsZero = Sse2.bsrli_si128(hiIsZero, 1 * sizeof(ulong));
                MAX_VALUE = Sse2.and_pd(MAX_VALUE, hiIsZero);
                
                return mad((double)value.hi, MAX_VALUE.Double0, (double)value.lo);
            }
            else
            {
                return mad((double)value.hi, 
                           asdouble(aslong((double)ulong.MaxValue) & -tosbyte(value.hi == 0)),
                           (double)value.lo);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator decimal(UInt128 value)
        {
            return new decimal((int)value.lo, (int)(value.lo >> 32), (int)value.hi, false, 0);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator BigInteger(UInt128 value)
        {
            return (BigInteger)value.hi << 64 | value.lo;
        }
        #endregion

        #region Operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ~ (UInt128 left)
        {
            return new UInt128(~left.lo, ~left.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ++ (UInt128 value) => value + (uint)1; 
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator -- (UInt128 value) => value - (uint)1;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, UInt128 right)
        {
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo + right.lo;
            ulong hi = left.hi + right.hi;

            bool carry = lo < left.lo;
            hi += tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, ulong right)
        {
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo + right;
            bool carry = lo < left.lo;
            ulong hi = left.hi + tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (ulong left, UInt128 right) => right + left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (UInt128 left, uint right)
        {
            // Compiles to ADD + ADC (add carry)
            ulong lo = left.lo + right;
            bool carry = lo < left.lo;
            ulong hi = left.hi + tobyte(carry);

            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator + (uint left, UInt128 right) => right + left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, UInt128 right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo - right.lo;
            ulong hi = left.hi - right.hi;

            hi -= tobyte(left.lo < right.lo); 
            
            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, ulong right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo - right;
            ulong hi = left.hi;
            
            hi -= tobyte(left.lo < right); 
            
            return new UInt128(lo, hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (ulong left, UInt128 right) => (UInt128)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator - (UInt128 left, uint right)
        {
            // Compiles to SUB + SBB (subtract borrow)
            ulong lo = left.lo - right;
            ulong hi = left.hi;
            
            hi -= tobyte(left.lo < right); 
            
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
                    else if (right == 3)
                    {
                        return right + right + right;
                    }
                    else if (ispow2(left))
                    {
                        return right << tzcnt(left);
                    }
                    else if (ispow2(left - 1))
                    {
                        return right + (right << tzcnt(left));
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
                    else if (ispow2(right - 1))
                    {
                        return left + (left << tzcnt(right));
                    }
                }
            }
                
            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }


            ulong lo = Common.umul128(left.lo, right.lo, out ulong hi);

            if (Constant.IsConstantExpression(left.hi))
            {
                if (Constant.IsConstantExpression(right.hi))
                {
                    if (left.hi == 0)
                    {
                        switch (right.hi)
                        {
                            case 0:                 break;
                            case ulong.MaxValue:    hi -= left.lo; break;
                            default:                hi += left.lo * right.hi; break;                
                        }
                    }
                    else if (left.hi == ulong.MaxValue)
                    {
                        switch (right.hi)
                        {
                            case 0:                 hi -= right.lo; break;
                            case ulong.MaxValue:    hi -= right.lo + left.lo; break;
                            default:                hi =  (hi - right.lo) + (left.lo * right.hi); break;
                        }
                    }
                    else
                    {
                        switch (right.hi)
                        {
                            case 0:                 hi += left.hi * right.lo; break;
                            case ulong.MaxValue:    hi =  (hi - left.lo) + (left.hi * right.lo); break;
                            default:                hi += (left.hi * right.lo) + (left.lo * right.hi); break;
                        }
                    }
                }
                else
                {
                    switch (left.hi)
                    {
                        case 0:                 hi += left.lo * right.hi; break;
                        case ulong.MaxValue:    hi =  (hi - right.lo) + (left.lo * right.hi); break;
                        default:                hi += (left.hi * right.lo) + (left.lo * right.hi); break;
                    }
                }
            }
            else
            {
                hi += (left.hi * right.lo) + (left.lo * right.hi);
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
                    else if (ispow2(right - 1))
                    {
                        return left + (left << tzcnt(right));
                    }
                }
            }

            if (Constant.IsConstantExpression(left == right) && left == right)
            {
                return square(left);
            }


            ulong lo = Common.umul128(left.lo, right, out ulong hi);

            if (Constant.IsConstantExpression(left.hi))
            {
                switch (left.hi)
                {
                    case 0:                 break;
                    case ulong.MaxValue:    hi -= right; break;
                    default:                hi += left.hi * right; break;
                }
            }
            else
            {
                hi += left.hi * right;
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
            //    return Operator.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Operator.divuint128(left, right);
            //}
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, ulong right)
        {
Assert.AreNotEqual(0ul, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    return Operator.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Operator.divuint128(left, right);
            //}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator / (UInt128 left, uint right)
        {
Assert.AreNotEqual(0u, right);

            //if (Constant.IsConstantExpression(right))
            //{
            //    return Operator.Constant.divuint128(left, right);
            //}
            //else 
            //{ 
                  return Operator.divuint128(left, right);
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

            return Operator.remuint128(left, right);
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

            return Operator.remuint128(left, right);
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

            return Operator.remuint128(left, right);
        }


        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator << (UInt128 value, int n)
        {
            n &= 127;

            if (Constant.IsConstantExpression(n))
            {
                return Operator.Constant.shluint128(value, n);
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

                    return new UInt128(value.lo << n, value.hi << n | (value.lo >> (64 - n)));
                }
                else
                {
                    Hint.Assume(n > 63 && n < 128);

                    return new UInt128(0, (value.lo << (n - 64)));
                }
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator >> (UInt128 value, int n)
        {
            n &= 127;

            if (Constant.IsConstantExpression(n))
            {
                return Operator.Constant.shruint128(value, n);
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

                    return new UInt128(value.lo >> n | (value.hi << (64 - n)), value.hi >> n);
                }
                else
                {
                    Hint.Assume(n > 63 && n < 128);

                    return new UInt128((value.hi >> (n - 64)), 0);
                }
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo & right.lo, left.hi & right.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, ulong right)
        {
            return new UInt128(left.lo & right, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (ulong left, UInt128 right) => right & left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (UInt128 left, uint right)
        {
            return new UInt128((uint)left.lo & right, 0);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator & (uint left, UInt128 right) => right & left;
        

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo | right.lo, left.hi | right.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, ulong right)
        {
            return new UInt128(left.lo | right, left.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (ulong left, UInt128 right) => right | left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, uint right)
        {
            return new UInt128(left.lo | right, left.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (uint left, UInt128 right) => right | left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator | (UInt128 left, ushort right) => left | (uint)right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, UInt128 right)
        {
            return new UInt128(left.lo ^ right.lo, left.hi ^ right.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, ulong right)
        {
            return new UInt128(left.lo ^ right, left.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (ulong left, UInt128 right) => right ^ left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (UInt128 left, uint right)
        {
            return new UInt128(left.lo ^ right, left.hi);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 operator ^ (uint left, UInt128 right) => right ^ left;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if ((right.lo | right.hi) == 0)
                {
                    return (left.lo | left.hi) == 0;
                }
                if ((right.lo & right.hi) == ulong.MaxValue)
                {
                    return (left.lo & left.hi) == ulong.MaxValue;
                }
            }
            else if (Constant.IsConstantExpression(left))
            {
                if ((left.lo | left.hi) == 0)
                {
                    return (right.lo | right.hi) == 0;
                }
                if ((left.lo & left.hi) == ulong.MaxValue)
                {
                    return (right.lo & right.hi) == ulong.MaxValue;
                }
            }

            return left.lo == right.lo & left.hi == right.hi;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo | left.hi) == 0;
            }

            return left.lo == right & left.hi == 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (ulong left, UInt128 right) => right == left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (UInt128 left, uint right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo | left.hi) == 0;
            }

            return left.lo == right & left.hi == 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator == (uint left, UInt128 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right))
            {
                if ((right.lo | right.hi) == 0)
                {
                    return (left.lo | left.hi) != 0;
                }
                if ((right.lo & right.hi) == ulong.MaxValue)
                {
                    return (left.lo & left.hi) != ulong.MaxValue;
                }
            }
            else if (Constant.IsConstantExpression(left))
            {
                if ((left.lo | left.hi) == 0)
                {
                    return (right.lo | right.hi) != 0;
                }
                if ((left.lo & left.hi) == ulong.MaxValue)
                {
                    return (right.lo & right.hi) != ulong.MaxValue;
                }
            }

            return left.lo != right.lo | left.hi != right.hi;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, ulong right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo | left.hi) != 0;
            }

            return left.lo != right | left.hi != 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (ulong left, UInt128 right) => right != left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (UInt128 left, uint right)
        {
            if (Constant.IsConstantExpression(right) && right == 0)
            {
                return (left.lo | left.hi) != 0;
            }

            return left.lo != right | left.hi != 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator != (uint left, UInt128 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, UInt128 right)
        {
            if (Constant.IsConstantExpression(right) && right.hi == 0)
            {
                return left < right.lo;
            }
            else if (Constant.IsConstantExpression(left) && left.hi == 0)
            {
                return right > left.lo;
            }

            bool highBitsDiffer = left.hi != right.hi;
            
            return (left.hi < right.hi & highBitsDiffer) | andnot(left.lo < right.lo, highBitsDiffer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, ulong right)
        {
            return left.hi == 0 & left.lo < right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (ulong left, UInt128 right)
        {
            return right.hi != 0 | left < right.lo;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (UInt128 left, uint right)
        {
            return left.hi == 0 & left.lo < right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator < (uint left, UInt128 right)
        {
            return right.hi != 0 | left < right.lo;
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
            if (Constant.IsConstantExpression(right) && right.hi == 0)
            {
                return left <= right.lo;
            }
            else if (Constant.IsConstantExpression(left) && left.hi == 0)
            {
                return right >= left.lo;
            }

            bool highBitsDiffer = left.hi != right.hi;
            
            return (left.hi <= right.hi & highBitsDiffer) | andnot(left.lo <= right.lo, highBitsDiffer);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, ulong right)
        {
            return left.hi == 0 & left.lo <= right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (ulong left, UInt128 right)
        {
            return right.hi != 0 | left <= right.lo;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (UInt128 left, uint right)
        {
            return left.hi == 0 & left.lo <= right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator <= (uint left, UInt128 right)
        {
            return right.hi != 0 | left <= right.lo;
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
            ulong _64 = lo ^ hi;

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
        #endregion
    }
}