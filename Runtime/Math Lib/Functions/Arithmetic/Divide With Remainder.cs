using System;
using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
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
                //    quotient = Xse.Constant.divuint128(dividend, divisor);
                //    remainder = dividend - (quotient * divisor); 
                //    
                //    return quotient;
                //}
            }

            if (Xse.constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                if (Xse.constexpr.IS_TRUE(divisor.hi64 <= uint.MaxValue))
                {
                    return UInt128.Common.divremuint128(dividend, (uint)divisor, out remainder);
                }
                else
                {
                    return UInt128.Common.divremuint128(dividend, (ulong)divisor, out remainder);
                }
            }
            else
            {
                return UInt128.Common.divremuint128(dividend, divisor, out remainder);
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

            if (Xse.constexpr.IS_TRUE(divisor > 0))
            {
                if (Xse.constexpr.IS_TRUE(divisor.hi64 == 0))
                {
                    if (Xse.constexpr.IS_TRUE(divisor.hi64 <= uint.MaxValue)) 
                    {
                        leftIsNegative = (long)dividend.hi64 < 0;

                        absDivRem = UInt128.Common.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                                     (ulong)divisor,
                                                                     out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo64 ^ mustNegate; 
                        xorHi = absRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        xorLo = absDivRem.lo64 ^ mustNegate; 
                        xorHi = absDivRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                    else
                    {
                        leftIsNegative = (long)dividend.hi64 < 0;

                        absDivRem = UInt128.Common.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                                     (uint)divisor,
                                                                     out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo64 ^ mustNegate; 
                        xorHi = absRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        xorLo = absDivRem.lo64 ^ mustNegate; 
                        xorHi = absDivRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                }
            }
            else
            {
                if (Xse.constexpr.IS_TRUE(isinrange(divisor, long.MinValue, long.MaxValue)))
                {
                    if (Xse.constexpr.IS_TRUE(isinrange(divisor, int.MinValue, int.MaxValue)))
                    {
                        long divisor32 = (long)divisor;

                        leftIsNegative = (long)dividend.hi64 < 0;
                        rightIsNegative = divisor32 < 0;

                        absDivRem = UInt128.Common.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                                     (ulong)(rightIsNegative ? -divisor32 : divisor32),
                                                                     out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo64 ^ mustNegate; 
                        xorHi = absRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
                        xorLo = absDivRem.lo64 ^ mustNegate; 
                        xorHi = absDivRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                    else
                    {
                        int divisor32 = (int)divisor;

                        leftIsNegative = (long)dividend.hi64 < 0;
                        rightIsNegative = divisor32 < 0;

                        absDivRem = UInt128.Common.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                                     (uint)(rightIsNegative ? -divisor32 : divisor32),
                                                                     out absRem);
                        
                        mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
                        xorLo = absRem.lo64 ^ mustNegate; 
                        xorHi = absRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        remainder = new Int128(lo, hi);

                        mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
                        xorLo = absDivRem.lo64 ^ mustNegate; 
                        xorHi = absDivRem.hi64 ^ mustNegate; 
                        lo = xorLo - mustNegate;
                        hi = xorHi - mustNegate;
                        hi -= maxmath.tobyte(xorLo < mustNegate); 
                        
                        return new Int128(lo, hi);
                    }
                }
            }

            leftIsNegative = (long)dividend.hi64 < 0;
            rightIsNegative = (long)divisor.hi64 < 0;

            absDivRem = UInt128.Common.divremuint128(maxmath.select(dividend, -dividend, leftIsNegative).intern,
                                                         maxmath.select(divisor, -divisor, rightIsNegative).intern,
                                                         out absRem);
            
            mustNegate = (ulong)-maxmath.tolong(leftIsNegative);
            xorLo = absRem.lo64 ^ mustNegate; 
            xorHi = absRem.hi64 ^ mustNegate; 
            lo = xorLo - mustNegate;
            hi = xorHi - mustNegate;
            hi -= maxmath.tobyte(xorLo < mustNegate); 
            
            remainder = new Int128(lo, hi);

            mustNegate ^= (ulong)-maxmath.tolong(rightIsNegative);
            xorLo = absDivRem.lo64 ^ mustNegate; 
            xorHi = absDivRem.hi64 ^ mustNegate; 
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
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders);
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
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders);
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
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders);
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
            
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders);
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
                byte16 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders);
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
                byte32 quotients = Xse.mm256_divrem_epu8(dividend, divisor, out v256 remainders);
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
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 quotients = Xse.divrem_epi8(dividend, divisor, out v128 rem, 2);
                    remainder = rem;

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
        public static sbyte3 divrem(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 quotients = Xse.divrem_epi8(dividend, divisor, out v128 rem, 3);
                    remainder = rem;

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
        public static sbyte4 divrem(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 quotients = Xse.divrem_epi8(dividend, divisor, out v128 rem, 4);
                    remainder = rem;

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
        public static sbyte8 divrem(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor.x0;

                return dividend / divisor.x0;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 quotients = Xse.divrem_epi8(dividend, divisor, out v128 rem, 8);
                    remainder = rem;

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
        public static sbyte16 divrem(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            if (Constant.IsConstantExpression(divisor) && all_eq(divisor))
            {
                remainder = dividend % divisor.x0;

                return dividend / divisor.x0;
            }
            else
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 quotients = Xse.divrem_epi8(dividend, divisor, out v128 rem, 16);
                    remainder = rem;

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
                    v256 quotient = Xse.mm256_divrem_epi8(dividend, divisor, out v256 _remainder);

                    remainder = _remainder;
                    return quotient;
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
                v128 quotients = Xse.divrem_epu16(dividend, divisor, out v128 rem, 2);
                remainder = rem;

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
        public static ushort3 divrem(ushort3 dividend, ushort3 divisor, out ushort3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epu16(dividend, divisor, out v128 rem, 3);
                remainder = rem;

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
        public static ushort4 divrem(ushort4 dividend, ushort4 divisor, out ushort4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epu16(dividend, divisor, out v128 rem, 4);
                remainder = rem;

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
        public static ushort8 divrem(ushort8 dividend, ushort8 divisor, out ushort8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epu16(dividend, divisor, out v128 rem, 8);
                remainder = rem;

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
        public static ushort16 divrem(ushort16 dividend, ushort16 divisor, out ushort16 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotients = Xse.mm256_divrem_epu16(dividend, divisor, out v256 rem);
                remainder = rem;

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
                v128 quotients = Xse.divrem_epi16(dividend, divisor, out v128 rem, 2);
                remainder = rem;

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
        public static short3 divrem(short3 dividend, short3 divisor, out short3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epi16(dividend, divisor, out v128 rem, 3);
                remainder = rem;

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
        public static short4 divrem(short4 dividend, short4 divisor, out short4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epi16(dividend, divisor, out v128 rem, 4);
                remainder = rem;

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
        public static short8 divrem(short8 dividend, short8 divisor, out short8 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 quotients = Xse.divrem_epi16(dividend, divisor, out v128 rem, 8);
                remainder = rem;

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
        public static short16 divrem(short16 dividend, short16 divisor, out short16 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotients = Xse.mm256_divrem_epi16(dividend, divisor, out v256 rem);
                remainder = rem;

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
            if (Sse2.IsSse2Supported)
            {
                int2 ret = RegisterConversion.ToInt2(Xse.divrem_epi32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 2));
                remainder = RegisterConversion.ToInt2(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divrem(int3 dividend, int3 divisor, out int3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                int3 ret = RegisterConversion.ToInt3(Xse.divrem_epi32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 3));
                remainder = RegisterConversion.ToInt3(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divrem(int4 dividend, int4 divisor, out int4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                int4 ret = RegisterConversion.ToInt4(Xse.divrem_epi32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 4));
                remainder = RegisterConversion.ToInt4(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 divrem(int8 dividend, int8 divisor, out int8 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                int8 ret = Xse.mm256_divrem_epi32(dividend, divisor, out v256 rem);
                remainder = rem;

                return ret;
            }
            else
            {
                int8 ret = new int8(divrem(dividend.v4_0, divisor.v4_0, out int4 remLo), divrem(dividend.v4_4, divisor.v4_4, out int4 remHi));
                remainder = new int8(remLo, remHi);

                return ret;
            }
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
            if (Sse2.IsSse2Supported)
            {
                uint2 ret = RegisterConversion.ToUInt2(Xse.divrem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 2));
                remainder = RegisterConversion.ToUInt2(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 divrem(uint3 dividend, uint3 divisor, out uint3 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                uint3 ret = RegisterConversion.ToUInt3(Xse.divrem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 3));
                remainder = RegisterConversion.ToUInt3(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 divrem(uint4 dividend, uint4 divisor, out uint4 remainder)
        {
            if (Sse2.IsSse2Supported)
            {
                uint4 ret = RegisterConversion.ToUInt4(Xse.divrem_epu32(RegisterConversion.ToV128(dividend), RegisterConversion.ToV128(divisor), out v128 rem, 4));
                remainder = RegisterConversion.ToUInt4(rem);

                return ret;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 divrem(uint8 dividend, uint8 divisor, out uint8 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                uint8 ret = Xse.mm256_divrem_epu32(dividend, divisor, out v256 rem);
                remainder = rem;

                return ret;
            }
            else
            {
                uint8 ret = new uint8(divrem(dividend.v4_0, divisor.v4_0, out uint4 remLo), divrem(dividend.v4_4, divisor.v4_4, out uint4 remHi));
                remainder = new uint8(remLo, remHi);

                return ret;
            }
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
            if (Sse2.IsSse2Supported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, divisor, out v128 rem);
                remainder = rem;

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
        public static long3 divrem(long3 dividend, long3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, divisor, out v256 rem, 3);
                remainder = rem;

                return quotient;
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, long4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, divisor, out v256 rem, 4);
                remainder = rem;

                return quotient;
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
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
            if (Sse2.IsSse2Supported)
            {
                v128 quotient = Xse.divrem_epu64(dividend, divisor, out v128 rem);
                remainder = rem;

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
        public static ulong3 divrem(ulong3 dividend, ulong3 divisor, out ulong3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, divisor, out v256 rem, 3);
                remainder = rem;

                return quotient;
            }
            else
            {
                ulong3 quotient = new ulong3(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.z, divisor.z, out ulong zRem));
                remainder = new ulong3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ulong4 divisor, out ulong4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, divisor, out v256 rem, 4);
                remainder = rem;

                return quotient;
            }
            else
            {
                ulong4 quotient = new ulong4(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.zw, divisor.zw, out ulong2 zwRem));
                remainder = new ulong4(xyRem, zwRem);

                return quotient;
            }
        }


        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divrem(float dividend, float divisor, out float remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float quotient);
            
            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divrem(float2 dividend, float2 divisor, out float2 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float2 quotient);
            
            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divrem(float3 dividend, float3 divisor, out float3 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float3 quotient);
            
            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divrem(float4 dividend, float4 divisor, out float4 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float4 quotient);
            
            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out" /> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divrem(float8 dividend, float8 divisor, out float8 remainder, bool fastApproximate = false)
        {
            remainder = divisor * modf(div(dividend, divisor, fastApproximate), out float8 quotient);
            
            return quotient;
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