using System;
using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, byte divisor, out UInt128 remainder)
        {
            UInt128 q = divrem(dividend, divisor, out ulong r);
            remainder = r;
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, ushort divisor, out UInt128 remainder)
        {
            UInt128 q = divrem(dividend, divisor, out ulong r);
            remainder = r;
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, uint divisor, out UInt128 remainder)
        {
            UInt128 q = divrem(dividend, divisor, out ulong r);
            remainder = r;
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, ulong divisor, out UInt128 remainder)
        {
            UInt128 q = divrem(dividend, divisor, out ulong r);
            remainder = r;
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
Assert.AreNotEqual(0u, divisor);

                remainder = UInt128.__const.urem(dividend, divisor);
                return UInt128.__const.udiv(dividend, divisor);
            }

            return asm128.__udivrem128x64(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 divrem(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
Assert.AreNotEqual(0u, divisor);

                remainder = UInt128.__const.urem(dividend, divisor);
                return UInt128.__const.udiv(dividend, divisor);
            }

            return asm128.__udivrem128x128(dividend, divisor, out remainder);
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, byte divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, ushort divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, uint divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, ulong divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (Int128)divisor, out remainder);
            return q;
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, sbyte divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, short divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, int divisor, out Int128 remainder)
        {
            Int128 q = divrem(dividend, (long)divisor, out remainder);
            return q;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, long divisor, out Int128 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
Assert.AreNotEqual(0u, divisor);

                remainder = UInt128.__const.irem(dividend, divisor);
                return UInt128.__const.idiv(dividend, divisor);
            }

            ulong absDivisor = constexpr.IS_TRUE(divisor >= 0) ? (ulong)divisor : (ulong)math.abs(divisor);
            UInt128 absQuotient = asm128.__udivrem128x64((UInt128)abs(dividend), absDivisor, out ulong absRem64);
            Int128 quotient = Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 remainder128, (long)dividend.hi64, divisor >> 63, absQuotient, absRem64);

            remainder = remainder128;
            return quotient;
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 divrem(Int128 dividend, Int128 divisor, out Int128 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
Assert.AreNotEqual(0u, divisor);

                remainder = UInt128.__const.irem(dividend, divisor);
                return UInt128.__const.idiv(dividend, divisor);
            }

            if (constexpr.IS_TRUE(isinrange(divisor, long.MinValue, long.MaxValue)))
            {
                return divrem(dividend, (long)divisor.lo64, out remainder);
            }

            UInt128 absQuotient = asm128.__udivrem128x128((UInt128)abs(dividend), (UInt128)abs(divisor), out UInt128 absRem);

            return Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out remainder, (long)dividend.hi64, (long)divisor.hi64, absQuotient, absRem);
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte divrem(byte dividend, byte divisor, out byte remainder)
        {
            byte quotient = (byte)((uint)dividend / (uint)divisor);
            remainder = (byte)((uint)dividend % (uint)divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte2 divisor, out byte2 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders, 2);
                remainder = remainders;

                return quotients;
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte3 divisor, out byte3 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders, 3);
                remainder = remainders;

                return quotients;
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte4 divisor, out byte4 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders, 4);
                remainder = remainders;

                return quotients;
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte8 divisor, out byte8 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotients = Xse.divrem_epu8(dividend, divisor, out v128 remainders, 8);
                remainder = remainders;

                return quotients;
            }
            else
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte16 divisor, out byte16 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte32 divisor, out byte32 remainder)
        {
            if (constexpr.IS_CONST(divisor))
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 divrem(byte2 dividend, byte divisor, out byte2 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 divrem(byte3 dividend, byte divisor, out byte3 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 divrem(byte4 dividend, byte divisor, out byte4 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 divrem(byte8 dividend, byte divisor, out byte8 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 divrem(byte16 dividend, byte divisor, out byte16 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte16)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 divrem(byte32 dividend, byte divisor, out byte32 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (byte32)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte divrem(sbyte dividend, sbyte divisor, out sbyte remainder)
        {
            sbyte quotient = (sbyte)(dividend / divisor);
            remainder = (sbyte)(dividend % divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte2 divisor, out sbyte2 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
            {
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte3 divisor, out sbyte3 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
            {
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte4 divisor, out sbyte4 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
            {
                remainder = dividend % divisor.x;

                return dividend / divisor.x;
            }
            else
            {
                if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte8 divisor, out sbyte8 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
            {
                remainder = dividend % divisor.x0;

                return dividend / divisor.x0;
            }
            else
            {
                if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte16 divisor, out sbyte16 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
            {
                remainder = dividend % divisor.x0;

                return dividend / divisor.x0;
            }
            else
            {
                if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte32 divisor, out sbyte32 remainder)
        {
            if (constexpr.IS_TRUE(all_eq(divisor)))
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 divrem(sbyte2 dividend, sbyte divisor, out sbyte2 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 divrem(sbyte3 dividend, sbyte divisor, out sbyte3 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 divrem(sbyte4 dividend, sbyte divisor, out sbyte4 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 divrem(sbyte8 dividend, sbyte divisor, out sbyte8 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 divrem(sbyte16 dividend, sbyte divisor, out sbyte16 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte16)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 divrem(sbyte32 dividend, sbyte divisor, out sbyte32 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (sbyte32)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort divrem(ushort dividend, ushort divisor, out ushort remainder)
        {
            ushort quotient = (ushort)((uint)dividend / (uint)divisor);
            remainder = (ushort)((uint)dividend % (uint)divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort2 divisor, out ushort2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort3 divisor, out ushort3 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort4 divisor, out ushort4 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort8 divisor, out ushort8 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 divrem(ushort2 dividend, ushort divisor, out ushort2 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 divrem(ushort3 dividend, ushort divisor, out ushort3 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 divrem(ushort4 dividend, ushort divisor, out ushort4 remainder)
        {

            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 divrem(ushort8 dividend, ushort divisor, out ushort8 remainder)
        {

            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 divrem(ushort16 dividend, ushort divisor, out ushort16 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (ushort16)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short divrem(short dividend, short divisor, out short remainder)
        {
            short quotient = (short)(dividend / divisor);
            remainder = (short)(dividend % divisor);

            return quotient;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short2 divisor, out short2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short3 divisor, out short3 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short4 divisor, out short4 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short8 divisor, out short8 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 divrem(short2 dividend, short divisor, out short2 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short2)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 divrem(short3 dividend, short divisor, out short3 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short3)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 divrem(short4 dividend, short divisor, out short4 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short4)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 divrem(short8 dividend, short divisor, out short8 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short8)divisor, out remainder);
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 divrem(short16 dividend, short divisor, out short16 remainder)
        {
            if (constexpr.IS_CONST(divisor))
            {
                remainder = dividend % divisor;
                return dividend / divisor;
            }
            else
            {
                return divrem(dividend, (short16)divisor, out remainder);
            }
        }


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int divrem(int dividend, int divisor, out int remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 divrem(int2 dividend, int2 divisor, out int2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 divrem(int3 dividend, int3 divisor, out int3 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 divrem(int4 dividend, int4 divisor, out int4 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
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



        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint divrem(uint dividend, uint divisor, out uint remainder)
        {
            remainder = dividend % divisor;

            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 divrem(uint2 dividend, uint2 divisor, out uint2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 divrem(uint3 dividend, uint3 divisor, out uint3 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 divrem(uint4 dividend, uint4 divisor, out uint4 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
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

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
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


        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long divrem(long dividend, long divisor, out long remainder)
        {
            return Math.DivRem(dividend, divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, byte divisor, out long2 remainder)
        {
            return divrem(dividend, (byte2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, byte2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepu8_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, byte divisor, out long3 remainder)
        {
            return divrem(dividend, (byte3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, byte3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu8_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu8_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, byte divisor, out long4 remainder)
        {
            return divrem(dividend, (byte4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, byte4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu8_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu8_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepu8_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false, bNonNegative: true);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, ushort divisor, out long2 remainder)
        {
            return divrem(dividend, (ushort2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, ushort2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepu16_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, ushort divisor, out long3 remainder)
        {
            return divrem(dividend, (ushort3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, ushort3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu16_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu16_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, ushort divisor, out long4 remainder)
        {
            return divrem(dividend, (ushort4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, ushort4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu16_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu16_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepu16_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false, bNonNegative: true);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, uint divisor, out long2 remainder)
        {
            return divrem(dividend, (uint2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, uint2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, uint divisor, out long3 remainder)
        {
            return divrem(dividend, (uint3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, uint3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, uint divisor, out long4 remainder)
        {
            return divrem(dividend, (uint4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, uint4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true, bNonNegative: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepu32_epi64(RegisterConversion.ToV128(divisor.zw)), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false, bNonNegative: true);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, sbyte divisor, out long2 remainder)
        {
            return divrem(dividend, (sbyte2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, sbyte2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepi8_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, sbyte divisor, out long3 remainder)
        {
            return divrem(dividend, (sbyte3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, sbyte3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepi8_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi8_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, sbyte divisor, out long4 remainder)
        {
            return divrem(dividend, (sbyte4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, sbyte4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepi8_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi8_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepi8_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, short divisor, out long2 remainder)
        {
            return divrem(dividend, (short2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, short2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepi16_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, short divisor, out long3 remainder)
        {
            return divrem(dividend, (short3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, short3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepi16_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi16_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, short divisor, out long4 remainder)
        {
            return divrem(dividend, (short4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, short4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Xse.mm256_cvtepi16_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi16_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepi16_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, int divisor, out long2 remainder)
        {
            return divrem(dividend, (int2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, int2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epi64(dividend, Xse.cvtepi32_pd(RegisterConversion.ToV128(divisor)), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, int divisor, out long3 remainder)
        {
            return divrem(dividend, (int3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, int3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(divisor)), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, int divisor, out long4 remainder)
        {
            return divrem(dividend, (int4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, int4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(divisor)),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, Xse.cvtepi32_epi64(RegisterConversion.ToV128(divisor.zw)), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 divrem(long2 dividend, long2 divisor, out long2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient;
                v128 rem;
                if (Avx2.IsAvx2Supported)
                {
                    quotient = Xse.divrem_epi64(dividend, divisor, out rem, useFPU: true);
                }
                else
                {
                    quotient = Xse.divrem_epi64(dividend, divisor, out rem, useFPU: false);
                }
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 divrem(long3 dividend, long3 divisor, out long3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, divisor, out v256 rem, elements: 3);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, divisor.xy, out v128 remLo, useFPU: true);
                long quotientHi = divrem(dividend.z, divisor.z, out long remHi);

                remainder = new long3(remLo, remHi);
                return new long3(quotientLo, quotientHi);
            }
            else
            {
                long3 quotient = new long3(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.z, divisor.z, out long zRem));
                remainder = new long3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 divrem(long4 dividend, long4 divisor, out long4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epi64(dividend, divisor, out v256 rem, elements: 4);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                long2 quotientLo = Xse.divrem_epi64(dividend.xy, divisor.xy, out v128 remLo, useFPU: true);
                long2 quotientHi = Xse.divrem_epi64(dividend.zw, divisor.zw, out v128 remHi, useFPU: false);

                remainder = new long4(remLo, remHi);
                return new long4(quotientLo, quotientHi);
            }
            else
            {
                long4 quotient = new long4(divrem(dividend.xy, divisor.xy, out long2 xyRem), divrem(dividend.zw, divisor.zw, out long2 zwRem));
                remainder = new long4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong divrem(ulong dividend, ulong divisor, out ulong remainder)
        {
            remainder = dividend % divisor;
            return dividend / divisor;
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, byte divisor, out ulong2 remainder)
        {
            return divrem(dividend, (byte2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, byte2 divisor, out ulong2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epu64(dividend, Xse.cvtepu8_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, byte divisor, out ulong3 remainder)
        {
            return divrem(dividend, (byte3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, byte3 divisor, out ulong3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu8_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu8_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong quotientHi = divrem(dividend.z, divisor.z, out ulong remHi);

                remainder = new ulong3(remLo, remHi);
                return new ulong3(quotientLo, quotientHi);
            }
            else
            {
                ulong3 quotient = new ulong3(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.z, divisor.z, out ulong zRem));
                remainder = new ulong3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, byte divisor, out ulong4 remainder)
        {
            return divrem(dividend, (byte4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, byte4 divisor, out ulong4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu8_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu8_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong2 quotientHi = Xse.divrem_epu64(dividend.zw, Xse.cvtepu8_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new ulong4(remLo, remHi);
                return new ulong4(quotientLo, quotientHi);
            }
            else
            {
                ulong4 quotient = new ulong4(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.zw, divisor.zw, out ulong2 zwRem));
                remainder = new ulong4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ushort divisor, out ulong2 remainder)
        {
            return divrem(dividend, (ushort2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ushort2 divisor, out ulong2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epu64(dividend, Xse.cvtepu16_pd(divisor), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ushort divisor, out ulong3 remainder)
        {
            return divrem(dividend, (ushort3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ushort3 divisor, out ulong3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu16_pd(divisor), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu16_pd(divisor), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong quotientHi = divrem(dividend.z, divisor.z, out ulong remHi);

                remainder = new ulong3(remLo, remHi);
                return new ulong3(quotientLo, quotientHi);
            }
            else
            {
                ulong3 quotient = new ulong3(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.z, divisor.z, out ulong zRem));
                remainder = new ulong3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ushort divisor, out ulong4 remainder)
        {
            return divrem(dividend, (ushort4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ushort4 divisor, out ulong4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu16_pd(divisor), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu16_pd(divisor),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong2 quotientHi = Xse.divrem_epu64(dividend.zw, Xse.cvtepu16_epi64(divisor.zw), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new ulong4(remLo, remHi);
                return new ulong4(quotientLo, quotientHi);
            }
            else
            {
                ulong4 quotient = new ulong4(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.zw, divisor.zw, out ulong2 zwRem));
                remainder = new ulong4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, uint divisor, out ulong2 remainder)
        {
            return divrem(dividend, (uint2)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, uint2 divisor, out ulong2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient = Xse.divrem_epu64(dividend, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v128 rem, useFPU: true, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, uint divisor, out ulong3 remainder)
        {
            return divrem(dividend, (uint3)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, uint3 divisor, out ulong3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 3, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong quotientHi = divrem(dividend.z, divisor.z, out ulong remHi);

                remainder = new ulong3(remLo, remHi);
                return new ulong3(quotientLo, quotientHi);
            }
            else
            {
                ulong3 quotient = new ulong3(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.z, divisor.z, out ulong zRem));
                remainder = new ulong3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, uint divisor, out ulong4 remainder)
        {
            return divrem(dividend, (uint4)divisor, out remainder);
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, uint4 divisor, out ulong4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(divisor)), out v256 rem, elements: 4, bLEu32max: true, bIsDbl: true);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(divisor)),       out v128 remLo, useFPU: true, bLEu32max: true, bIsDbl: true);
                ulong2 quotientHi = Xse.divrem_epu64(dividend.zw, Xse.cvtepu32_epi64(RegisterConversion.ToV128(divisor.zw)), out v128 remHi, useFPU: false, bLEu32max: true, bIsDbl: false);

                remainder = new ulong4(remLo, remHi);
                return new ulong4(quotientLo, quotientHi);
            }
            else
            {
                ulong4 quotient = new ulong4(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.zw, divisor.zw, out ulong2 zwRem));
                remainder = new ulong4(xyRem, zwRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 divrem(ulong2 dividend, ulong2 divisor, out ulong2 remainder)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 quotient;
                v128 rem;
                if (Avx2.IsAvx2Supported)
                {
                    quotient = Xse.divrem_epu64(dividend, divisor, out rem, useFPU: true);
                }
                else
                {
                    quotient = Xse.divrem_epu64(dividend, divisor, out rem, useFPU: false);
                }
                remainder = rem;

                return quotient;
            }
            else
            {
                remainder = dividend % divisor;

                return dividend / divisor;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 divrem(ulong3 dividend, ulong3 divisor, out ulong3 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, divisor, out v256 rem, elements: 3);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, divisor.xy, out v128 remLo, useFPU: true);
                ulong quotientHi = divrem(dividend.z, divisor.z, out ulong remHi);

                remainder = new ulong3(remLo, remHi);
                return new ulong3(quotientLo, quotientHi);
            }
            else
            {
                ulong3 quotient = new ulong3(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.z, divisor.z, out ulong zRem));
                remainder = new ulong3(xyRem, zRem);

                return quotient;
            }
        }

        /// <summary>       Returns the quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 divrem(ulong4 dividend, ulong4 divisor, out ulong4 remainder)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = Xse.mm256_divrem_epu64(dividend, divisor, out v256 rem, elements: 4);
                remainder = rem;

                return quotient;
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                ulong2 quotientLo = Xse.divrem_epu64(dividend.xy, divisor.xy, out v128 remLo, useFPU: true);
                ulong2 quotientHi = Xse.divrem_epu64(dividend.zw, divisor.zw, out v128 remHi, useFPU: false);

                remainder = new ulong4(remLo, remHi);
                return new ulong4(quotientLo, quotientHi);
            }
            else
            {
                ulong4 quotient = new ulong4(divrem(dividend.xy, divisor.xy, out ulong2 xyRem), divrem(dividend.zw, divisor.zw, out ulong2 zwRem));
                remainder = new ulong4(xyRem, zwRem);

                return quotient;
            }
        }


        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float divrem(float dividend, float divisor, out float remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 divrem(float2 dividend, float2 divisor, out float2 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float2 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 divrem(float3 dividend, float3 divisor, out float3 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float3 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 divrem(float4 dividend, float4 divisor, out float4 remainder, bool fastApproximate = false)
        {
            remainder = divisor * math.modf(div(dividend, divisor, fastApproximate), out float4 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 divrem(float8 dividend, float8 divisor, out float8 remainder, bool fastApproximate = false)
        {
            remainder = divisor * modf(div(dividend, divisor, fastApproximate), out float8 quotient);

            return quotient;
        }


        /// <summary>       Returns the truncated quotient of the <paramref name="dividend"/> divided by the <paramref name="divisor"/> with the <paramref name="remainder"/> as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double divrem(double dividend, double divisor, out double remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 divrem(double2 dividend, double2 divisor, out double2 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double2 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 divrem(double3 dividend, double3 divisor, out double3 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double3 quotient);

            return quotient;
        }

        /// <summary>       Returns the truncated quotients of the componentwise division of the <paramref name="dividend"/> by the <paramref name="divisor"/> with the <paramref name="remainder"/>s as an <see langword="out"/> parameter.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 divrem(double4 dividend, double4 divisor, out double4 remainder)
        {
            remainder = divisor * math.modf(dividend / divisor, out double4 quotient);

            return quotient;
        }
    }
}