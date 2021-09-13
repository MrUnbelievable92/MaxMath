using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (divisor == 1) 
                {
                    remainder = 0;
                    return dividend;
                }
                else if (divisor == UInt128.MaxValue)
                {
                    bool isMax = dividend == UInt128.MaxValue;
                    remainder = select(divisor, 0, isMax);

                    return maxmath.touint128(isMax);
                }
                else if (ispow2(divisor))
                {
                    remainder = dividend & (divisor - 1);
                    return dividend >> maxmath.tzcnt(divisor);
                }
                //else
                //{
                //    quotient = Operator.Constant.divuint128(dividend, divisor);
                //    remainder = dividend - (quotient * divisor); 
                //    
                //    return quotient;
                //}
            }

            if (Constant.IsConstantExpression(divisor.hi == 0) && divisor.hi == 0)
            {
                if (Constant.IsConstantExpression(divisor.hi <= uint.MaxValue) && divisor.hi <= uint.MaxValue) 
                {
                    return Operator.divremuint128(dividend, (uint)divisor, out remainder);
                }
                else
                {
                    return Operator.divremuint128(dividend, (ulong)divisor, out remainder);
                }
            }
            else
            {
                return Operator.divremuint128(dividend, divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, Int128 divisor, out Int128 remainder)
        {
            bool leftIsNegative;
            bool rightIsNegative;

            UInt128 absDivRem;
            UInt128 absRem;
            
            ulong mustNegate;
            ulong xorLo; 
            ulong xorHi; 
            ulong lo;
            ulong hi;

            if (Constant.IsConstantExpression(divisor > 0) && divisor > 0)
            {
                if (Constant.IsConstantExpression(divisor.intern.hi == 0) && divisor.intern.hi == 0)
                {
                    if (Constant.IsConstantExpression(divisor.intern.hi <= uint.MaxValue) && divisor.intern.hi <= uint.MaxValue) 
                    {
                        leftIsNegative = (long)dividend.intern.hi < 0;

                        absDivRem = Operator.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                           (ulong)divisor,
                                                           out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo ^ mustNegate; 
                        xorHi = absRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        xorLo = absDivRem.lo ^ mustNegate; 
                        xorHi = absDivRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                    else
                    {
                        leftIsNegative = (long)dividend.intern.hi < 0;

                        absDivRem = Operator.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                           (uint)divisor,
                                                           out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo ^ mustNegate; 
                        xorHi = absRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        xorLo = absDivRem.lo ^ mustNegate; 
                        xorHi = absDivRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                }
            }
            else
            {
                if (Constant.IsConstantExpression(isinrange(divisor, long.MinValue, long.MaxValue)) && isinrange(divisor, long.MinValue, long.MaxValue))
                {
                    if (Constant.IsConstantExpression(isinrange(divisor, int.MinValue, int.MaxValue)) && isinrange(divisor, int.MinValue, int.MaxValue)) 
                    {
                        long divisor32 = (long)divisor;

                        leftIsNegative = (long)dividend.intern.hi < 0;
                        rightIsNegative = divisor32 < 0;

                        absDivRem = Operator.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                           (ulong)(rightIsNegative ? -divisor32 : divisor32),
                                                           out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo ^ mustNegate; 
                        xorHi = absRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
                        xorLo = absDivRem.lo ^ mustNegate; 
                        xorHi = absDivRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                    else
                    {
                        int divisor32 = (int)divisor;

                        leftIsNegative = (long)dividend.intern.hi < 0;
                        rightIsNegative = divisor32 < 0;

                        absDivRem = Operator.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                           (uint)(rightIsNegative ? -divisor32 : divisor32),
                                                           out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo ^ mustNegate; 
                        xorHi = absRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
                        xorLo = absDivRem.lo ^ mustNegate; 
                        xorHi = absDivRem.hi ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                }
            }

            leftIsNegative = (long)dividend.intern.hi < 0;
            rightIsNegative = (long)divisor.intern.hi < 0;

            absDivRem = Operator.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                               maxmath.select(divisor, -divisor, rightIsNegative).intern,
                                               out absRem);
            
            mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
            xorLo = absRem.lo ^ mustNegate; 
            xorHi = absRem.hi ^ mustNegate; 
            lo = xorLo - mustNegate;
            hi = xorHi - mustNegate;
            hi -= maxmath.tobyte(xorLo < mustNegate); 
            
            remainder = new Int128(lo, hi);

            mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
            xorLo = absDivRem.lo ^ mustNegate; 
            xorHi = absDivRem.hi ^ mustNegate; 
            lo = xorLo - mustNegate;
            hi = xorHi - mustNegate;
            hi -= maxmath.tobyte(xorLo < mustNegate); 
            
            return new Int128(lo, hi);
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte divrem(byte dividend, byte divisor, out byte remainder)
        {
            byte quotient = (byte)((uint)dividend / (uint)divisor);
            remainder = (byte)((uint)dividend % (uint)divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && math.all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdivrem_byte(dividend, divisor, out remainder);
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && math.all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdivrem_byte(dividend, divisor, out remainder);
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && math.all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdivrem_byte(dividend, divisor, out remainder);
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Avx2.IsAvx2Supported)
            {
                return Operator.vdivrem_byte(dividend, divisor, out remainder);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Operator.vdivrem_byte_SSE_FALLBACK(dividend, divisor, out remainder);
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Sse2.IsSse2Supported)
            {
                byte16 quotients = Operator.vdivrem_byte(dividend, divisor, out v128 remainders);
                remainder = remainders;

                return quotients;
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                bool sameValue = all_eq(divisor); 

                if (!sameValue && all(ispow2(divisor)))
                {
                    remainder = dividend & (divisor - 1);
                    return shrl(dividend, tzcnt(divisor));
                }
                else if (sameValue)
                {
                    remainder = dividend % divisor;

                    return dividend / divisor;
                }
            }
            
            if (Avx2.IsAvx2Supported)
            {
                byte32 quotients = Operator.vdivrem_byte(dividend, divisor, out v256 remainders);
                remainder = remainders;

                return quotients;
            }
            else
            {
                byte32 quotients = new byte32(divrem(dividend.v16_0,  divisor.v16_0,  out byte16 remLo),
                                              divrem(dividend.v16_16, divisor.v16_16, out byte16 remHi));
            
                remainder = new byte32(remLo, remHi);
            
                return quotients;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte divisor, out byte2 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte divisor, out byte3 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte divisor, out byte4 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte divisor, out byte8 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte divisor, out byte16 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte16)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte divisor, out byte32 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte32)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte divrem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            sbyte quotient = (sbyte)(dividend / divisor);
            remainder = (sbyte)(dividend % divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = dividend % divisor;
                    return dividend / divisor;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = dividend % divisor;
                    return dividend / divisor;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = dividend % divisor;
                    return dividend / divisor;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
                }
                else if (Sse2.IsSse2Supported)
                {
                    return Operator.vdivrem_sbyte_SSE_FALLBACK(dividend, divisor, out remainder);
                }
                else
                {
                    remainder = dividend % divisor;
                    return dividend / divisor;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    sbyte16 quotients = Operator.vdivrem_sbyte(dividend, divisor, out v128 remainders);
                    remainder = remainders;
                    
                    return quotients;
                }
                else
                {
                    remainder = dividend % divisor;
                    return dividend / divisor;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Operator.vdivrem_sbyte(dividend, divisor, out remainder);
                }
                else
                {
                    sbyte32 quotients = new sbyte32(divrem(dividend.v16_0,  divisor.v16_0,  out sbyte16 remLo),
                                                    divrem(dividend.v16_16, divisor.v16_16, out sbyte16 remHi));

                    remainder = new sbyte32(remLo, remHi);

                    return quotients;
                }
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte divisor, out sbyte2 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte divisor, out sbyte3 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte divisor, out sbyte4 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte divisor, out sbyte8 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte divisor, out sbyte16 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte16)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte divisor, out sbyte32 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte32)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort divrem(ushort dividend, ushort divisor, out ushort remainder)
        {
            ushort quotient = (ushort)((uint)dividend / (uint)divisor);
            remainder = (ushort)((uint)dividend % (uint)divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort2 divisor, out ushort2 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort2 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort3 divisor, out ushort3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort3 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort4 divisor, out ushort4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort4 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort8 divisor, out ushort8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort8 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 divrem(ushort16 dividend, ushort16 divisor, out ushort16 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                ushort16 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort divisor, out ushort2 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort divisor, out ushort3 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort divisor, out ushort4 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort divisor, out ushort8 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 divrem(ushort16 dividend, ushort divisor, out ushort16 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort16)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short divrem(short dividend, short divisor, out short remainder)
        {
            short quotient = (short)(dividend / divisor);
            remainder = (short)(dividend % divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short2 divisor, out short2 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                short2 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short3 divisor, out short3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                short3 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short4 divisor, out short4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                short4 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short8 divisor, out short8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                short8 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divrem(short16 dividend, short16 divisor, out short16 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                short16 quotient = dividend / divisor;
                remainder = dividend - (quotient * divisor);

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short divisor, out short2 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short divisor, out short3 remainder)
        {
            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short divisor, out short4 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short divisor, out short8 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divrem(short16 dividend, short divisor, out short16 remainder)
        {

            if (Constant.IsConstantExpression(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short16)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int divrem(int dividend, int divisor, out int remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 divrem(int2 dividend, int2 divisor, out int2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divrem(int3 dividend, int3 divisor, out int3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divrem(int4 dividend, int4 divisor, out int4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 divrem(int8 dividend, int8 divisor, out int8 remainder)
        {
            remainder = default(v256);

            return new int8(divrem(dividend.x0, divisor.x0, out remainder.x0),
                            divrem(dividend.x1, divisor.x1, out remainder.x1),
                            divrem(dividend.x2, divisor.x2, out remainder.x2),
                            divrem(dividend.x3, divisor.x3, out remainder.x3),
                            divrem(dividend.x4, divisor.x4, out remainder.x4),
                            divrem(dividend.x5, divisor.x5, out remainder.x5),
                            divrem(dividend.x6, divisor.x6, out remainder.x6),
                            divrem(dividend.x7, divisor.x7, out remainder.x7));
        }



        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint divrem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 divrem(uint2 dividend, uint2 divisor, out uint2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 divrem(uint3 dividend, uint3 divisor, out uint3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 divrem(uint4 dividend, uint4 divisor, out uint4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 divrem(uint8 dividend, uint8 divisor, out uint8 remainder)
        {
            uint8 quotient = new uint8((uint)divrem((long)dividend.x0, (long)divisor.x0, out long x0),
                                       (uint)divrem((long)dividend.x1, (long)divisor.x1, out long x1),
                                       (uint)divrem((long)dividend.x2, (long)divisor.x2, out long x2),
                                       (uint)divrem((long)dividend.x3, (long)divisor.x3, out long x3),
                                       (uint)divrem((long)dividend.x4, (long)divisor.x4, out long x4),
                                       (uint)divrem((long)dividend.x5, (long)divisor.x5, out long x5),
                                       (uint)divrem((long)dividend.x6, (long)divisor.x6, out long x6),
                                       (uint)divrem((long)dividend.x7, (long)divisor.x7, out long x7));

            remainder = new uint8((uint)x0, (uint)x1, (uint)x2, (uint)x3, (uint)x4, (uint)x5, (uint)x6, (uint)x7);

            return quotient;
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long divrem(long dividend, long divisor, out long remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, long2 divisor, out long2 remainder)
        {
            remainder = default(v128);

            return new long2(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y));
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, long3 divisor, out long3 remainder)
        {
            remainder = default(v256);

            return new long3(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z));
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, long4 divisor, out long4 remainder)
        {
            remainder = default(v256);

            return new long4(divrem(dividend.x, divisor.x, out remainder.x),
                             divrem(dividend.y, divisor.y, out remainder.y),
                             divrem(dividend.z, divisor.z, out remainder.z),
                             divrem(dividend.w, divisor.w, out remainder.w));
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong divrem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ulong2 divisor, out ulong2 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ulong3 divisor, out ulong3 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ulong4 divisor, out ulong4 remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }


        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divrem(float dividend, float divisor, out float remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor, true), out float quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divrem(float2 dividend, float2 divisor, out float2 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor, true), out float2 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float2 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divrem(float3 dividend, float3 divisor, out float3 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor, true), out float3 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float3 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divrem(float4 dividend, float4 divisor, out float4 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * math.modf(div(dividend, divisor, true), out float4 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * math.modf(dividend / divisor, out float4 quotient);

                return quotient;
            }
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divrem(float8 dividend, float8 divisor, out float8 remainder, bool fastApproximate = false)
        {
            if (fastApproximate)
            {
                remainder = divisor * modf(div(dividend, divisor, true), out float8 quotient);

                return quotient;
            }
            else
            {
                remainder = divisor * modf(dividend / divisor, out float8 quotient);

                return quotient;
            }
        }


        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double divrem(double dividend, double divisor, out double remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 divrem(double2 dividend, double2 divisor, out double2 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double2 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 divrem(double3 dividend, double3 divisor, out double3 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double3 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 divrem(double4 dividend, double4 divisor, out double4 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double4 quotient);

            return quotient;
        }
    }
}