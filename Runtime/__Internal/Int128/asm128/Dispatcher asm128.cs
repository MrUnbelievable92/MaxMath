#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
#define WINDOWS
#endif

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe internal static class asm128
    {
    #if WINDOWS
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#1")*/)] extern private static ulong a(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* quotientHiPLUSrem);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#2")*/)] extern private static ulong b(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* quotientHiPLUSrem);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#3")*/)] extern private static ulong c(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* paddingPLUSrem);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#4")*/)] extern private static ulong d(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, ulong* remLo);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#5")*/)] extern private static ulong e(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* quotientHi);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#6")*/)] extern private static ulong f(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* quotientHi);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#7")*/)] extern private static ulong g(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#8")*/)] extern private static ulong h(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#9")*/)] extern private static ulong i(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* hiRem);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#10"*/)] extern private static ulong j(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, void* hiRem);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#11"*/)] extern private static ulong k(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, ulong* hi);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#12"*/)] extern private static ulong l(ulong dividendLo64, ulong dividendHi64, ulong divisorLo64, ulong divisorHi64, ulong* hi);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#13"*/)] extern private static ulong m(ulong lo64, ulong hi64, ulong divisor, void* hi_and_rem);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#14"*/)] extern private static ulong n(ulong lo64, ulong hi64, ulong divisor, void* rem_and_hi);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#15"*/)] extern private static ulong p(ulong lo64, ulong hi64, ulong divisor, ulong* hiRes);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#16"*/)] extern private static ulong q(ulong lo64, ulong hi64, ulong divisor, ulong* hiRes);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#17"*/)] extern private static ulong s(ulong lo64, ulong hi64, ulong divisor);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#18"*/)] extern private static ulong t(ulong lo64, ulong hi64, ulong divisor);

		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#19"*/)] extern private static ulong v(ulong dividend0, ulong dividend1, ulong* results, ulong dividend2, ulong dividend3);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#20"*/)] extern private static ulong w(ulong dividend0, ulong dividend1, ulong* results, ulong dividend2);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#21"*/)] extern private static ulong x(ulong dividend0, ulong dividend1, ulong* results);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#22"*/)] extern private static ulong y(ulong dividend, ulong* hi);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#23"*/)] extern private static ulong z([NoAlias] ulong* INhidividendsOUTresults, [NoAlias] ulong* divisors);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#24"*/)] extern private static ulong A(ulong* INhidividendsOUTresults, ulong divisor1, ulong divisor2, ulong divisor0);
		[DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#25"*/)] extern private static ulong B(ulong* INhidividendsOUTresults, ulong divisor0, ulong divisor1);

        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#26"*/)] extern private static ulong D(ulong dividendLo64, ulong dividendHi64, ulong divisor, ulong* remPtr);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#27"*/)] extern private static long  E(ulong dividendLo64, ulong dividendHi64, long divisor, long* remPtr);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#28"*/)] extern private static ulong F(ulong dividendLo64, ulong dividendHi64, ulong divisor);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#29"*/)] extern private static long  G(ulong dividendLo64, ulong dividendHi64, long divisor);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#30"*/)] extern private static ulong H(ulong dividendLo64, ulong dividendHi64, ulong divisor);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#31"*/)] extern private static long  I(ulong dividendLo64, ulong dividendHi64, long divisor);
     #endif


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CHECK_DIVISOR(UInt128 divisor)
        {
#if DEBUG
if (divisor.IsZero) throw new DivideByZeroException();
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 fallback__udivrem128x128(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            if (divisor > dividend)
            {
                remainder = dividend;

                return 0;
            }
	        else
            {
                return fallback__udivrem128x128_rLEl(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 fallback__udivrem128x128_rLEl(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            if (divisor.hi64 == 0)
            {
                UInt128 quotient = fallback__udivrem128x64(dividend, divisor.lo64, out ulong remainder64);

                remainder = remainder64;
                return quotient;
            }
            else
            {
                return fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong fallback__udivrem128x128_rGTu64max(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            if (divisor > dividend)
            {
                remainder = dividend;

                return 0;
            }
	        else
            {
                return fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong fallback__udivrem128x128_rGTu64max_rLEl(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            remainder = dividend;

            int shift = lzcnt(divisor.hi64);

            ulong scaledHi = (divisor << shift).hi64;
            ulong roundBit = tobyte(dividend.hi64 >= scaledHi);
            dividend = new UInt128(dividend.lo64, dividend.hi64 < scaledHi ? dividend.hi64 : dividend.hi64 - scaledHi);
            ulong scaledLo = (new UInt128(fallback__usf__udivrem128x64(dividend, scaledHi, out _), roundBit) << shift).hi64;
            scaledHi = scaledLo * divisor.hi64;
            dividend = UInt128.umul128(divisor.lo64, scaledLo);

            remainder -= dividend;
            ulong quotient = scaledLo - tobyte(remainder.hi64 < scaledHi);
            divisor = select(0, divisor, remainder.hi64 < scaledHi);
            remainder = new UInt128(remainder.lo64, remainder.hi64 - scaledHi);
            remainder += divisor;

            return quotient;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 fallback__udivrem128x64(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            if (dividend.hi64 >= divisor)
            {
                return fallback__udivrem128x64_rLEhi(dividend, divisor, out remainder);
            }
            else
            {
                return fallback__usf__udivrem128x64(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 fallback__udivrem128x64_rLEhi(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            ulong quotientHi = divrem(dividend.hi64, divisor, out ulong dividendHi);
            dividend = new UInt128(dividend.lo64, dividendHi);

            return new UInt128(fallback__usf__udivrem128x64(dividend, divisor, out remainder), quotientHi);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong fallback__usf__udivrem128x64(UInt128 dividend, ulong divisor, out ulong remainder)
        {
Assert.IsSmaller(dividend.hi64, divisor);

            int shift = lzcnt(divisor);
            dividend <<= shift;
            divisor <<= shift;

            ulong qHi = divrem(dividend.hi64, divisor >> 32, out ulong remdiv);
            remdiv = (remdiv << 32) | (dividend.lo64 >> 32);
            remainder = remdiv - (qHi * (uint)divisor);
            bool b1 = remainder > remdiv;
            bool b2 = b1 & ((ulong)-(long)remainder > divisor);
            qHi -= tobyte(b2);
            qHi -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            ulong qLo = divrem(remainder, divisor >> 32, out remdiv);
            remdiv = (remdiv << 32) | (uint)dividend.lo64;
            remainder = remdiv - (qLo * (uint)divisor);
            b1 = remainder > remdiv;
            b2 = b1 & ((ulong)-(long)remainder > divisor);
            qLo -= tobyte(b2);
            qLo -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            remainder >>= shift;
            return (qHi << 32) | (uint)qLo;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long fallback__usf__idivrem128x64(Int128 dividend, long divisor, out long remainder)
        {
            UInt128 absDividend = (UInt128)abs(dividend);
            ulong absDivisor = (ulong)abs(divisor);

            ulong absQuotient = fallback__usf__udivrem128x64(absDividend, absDivisor, out ulong absRemainder);
            ulong quotient = Xse.SIGNED_FROM_UNSIGNED_DIV_I128(out Int128 remainder128, (long)dividend.hi64, divisor >> 63, absQuotient, absRemainder).lo64;

            remainder = (long)remainder128.lo64;
            return (long)quotient;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 fallback__spc__udivmax128x64_inc(ulong divisor)
        {
            ulong quotientHi = divrem(ulong.MaxValue, divisor, out ulong dividendHi);
            UInt128 dividend = new UInt128(ulong.MaxValue, dividendHi);

            return 1 + new UInt128(fallback__usf__udivrem128x64(dividend, divisor, out _), quotientHi);
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udivrem128x128(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                UInt128 quotient = __udivrem128x64(dividend, divisor.lo64, out ulong remainder64);

                remainder = remainder64;
                return quotient;
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                if (constexpr.IS_TRUE(divisor <= dividend))
                {
                    return __udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
                }
                else
                {
                    return __udivrem128x128_rGTu64max(dividend, divisor, out remainder);
                }
            }
            else if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __udivrem128x128_rLEl(dividend, divisor, out remainder);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x128(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* quotientHiPLUSrem = stackalloc ulong[3];
                ulong lo = a(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, quotientHiPLUSrem);

                remainder = new UInt128(quotientHiPLUSrem[1], quotientHiPLUSrem[2]);
                return new UInt128(lo, quotientHiPLUSrem[0]);
            }
        #endif

            return fallback__udivrem128x128(dividend, divisor, out remainder);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udivrem128x128_rLEl(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                UInt128 quotient = __udivrem128x64(dividend, divisor.lo64, out ulong remainder64);

                remainder = remainder64;
                return quotient;
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                return __udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x128_rLEl(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* quotientHiPLUSrem = stackalloc ulong[3];
                ulong lo = b(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, quotientHiPLUSrem);

                remainder = new UInt128(quotientHiPLUSrem[1], quotientHiPLUSrem[2]);
                return new UInt128(lo, quotientHiPLUSrem[0]);
            }
        #endif

            return fallback__udivrem128x128_rLEl(dividend, divisor, out remainder);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __udivrem128x128_rGTu64max(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                UInt128 quotient = __udivrem128x64(dividend, divisor.lo64, out ulong remainder64);

                remainder = remainder64;
                return quotient.lo64;
            }
            if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__udivrem128x128_rGTu64max(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* rem = stackalloc ulong[3];
                ulong q = c(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, rem);

                remainder = new UInt128(rem[1], rem[2]); // intentional
                return q;
            }
        #endif

            return fallback__udivrem128x128_rGTu64max(dividend, divisor, out remainder);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __udivrem128x128_rGTu64max_rLEl(UInt128 dividend, UInt128 divisor, out UInt128 remainder)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                UInt128 quotient = __udivrem128x64(dividend, divisor.lo64, out ulong remainder64);

                remainder = remainder64;
                return quotient.lo64;
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* res = stackalloc ulong[3];
                ulong q = d(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, res);

                remainder = new UInt128(res[1], res[2]); // intentional
                return q;
            }
        #endif

            return fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out remainder);
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udiv128x128(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __udiv128x64(dividend, divisor.lo64);
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                if (constexpr.IS_TRUE(divisor <= dividend))
                {
                    return __udiv128x128_rGTu64max_rLEl(dividend, divisor);
                }
                else
                {
                    return __udiv128x128_rGTu64max(dividend, divisor);
                }
            }
            else if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __udiv128x128_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x128(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = e(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            return fallback__udivrem128x128(dividend, divisor, out _);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udiv128x128_rLEl(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __udiv128x64(dividend, divisor.lo64);
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                return __udiv128x128_rGTu64max_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x128_rLEl(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = f(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            return fallback__udivrem128x128_rLEl(dividend, divisor, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __udiv128x128_rGTu64max(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __udiv128x64(dividend, divisor.lo64).lo64;
            }
            if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __udiv128x128_rGTu64max_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__udivrem128x128_rGTu64max(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return g(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64);
            }
        #endif

            return fallback__udivrem128x128_rGTu64max(dividend, divisor, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __udiv128x128_rGTu64max_rLEl(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __udiv128x64(dividend, divisor.lo64).lo64;
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return h(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64);
            }
        #endif

            return fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out _);
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __urem128x128(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __urem128x64(dividend, divisor.lo64);
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                if (constexpr.IS_TRUE(divisor <= dividend))
                {
                    return __urem128x128_rGTu64max_rLEl(dividend, divisor);
                }
                else
                {
                    return __urem128x128_rGTu64max(dividend, divisor);
                }
            }
            else if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __urem128x128_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x128(dividend, divisor, out UInt128 constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = i(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            fallback__udivrem128x128(dividend, divisor, out UInt128 remainder);

            return remainder;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __urem128x128_rLEl(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __urem128x64(dividend, divisor.lo64);
            }
            if (constexpr.IS_TRUE(divisor.hi64 != 0))
            {
                return __urem128x128_rGTu64max_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x128_rLEl(dividend, divisor, out UInt128 constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = j(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            fallback__udivrem128x128_rLEl(dividend, divisor, out UInt128 remainder);

            return remainder;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __urem128x128_rGTu64max(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __urem128x64(dividend, divisor.lo64);
            }
            if (constexpr.IS_TRUE(divisor <= dividend))
            {
                return __urem128x128_rGTu64max_rLEl(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x128_rGTu64max(dividend, divisor, out UInt128 constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = k(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            fallback__udivrem128x128_rGTu64max(dividend, divisor, out UInt128 remainder);

            return remainder;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __urem128x128_rGTu64max_rLEl(UInt128 dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor.hi64 == 0))
            {
                return __urem128x64(dividend, divisor.lo64);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out UInt128 constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = l(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            fallback__udivrem128x128_rGTu64max_rLEl(dividend, divisor, out UInt128 remainder);

            return remainder;
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udivrem128x64(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor <= dividend.hi64))
            {
                return __udivrem128x64_rLEhi(dividend, divisor, out remainder);
            }
            else if (constexpr.IS_TRUE(divisor > dividend.hi64))
            {
                return __usf__udivrem128x64(dividend, divisor, out remainder);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x64(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* hi_and_rem = stackalloc ulong[2];
                ulong lo = m(dividend.lo64, dividend.hi64, divisor, hi_and_rem);

                remainder = hi_and_rem[1];
                return new UInt128(lo, hi_and_rem[0]);
            }
        #endif

            return fallback__udivrem128x64(dividend, divisor, out remainder);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udivrem128x64_rLEhi(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x64_rLEhi(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* rem_and_hi = stackalloc ulong[2];
                ulong lo = n(dividend.lo64, dividend.hi64, divisor, rem_and_hi);

                remainder = rem_and_hi[0];
                return new UInt128(lo, rem_and_hi[1]);
            }
        #endif

            return fallback__udivrem128x64_rLEhi(dividend, divisor, out remainder);
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udiv128x64(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor <= dividend.hi64))
            {
                return __udiv128x64_rLEhi(dividend, divisor);
            }
            else if (constexpr.IS_TRUE(divisor > dividend.hi64))
            {
                return __usf__udiv128x64(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x64(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = p(dividend.lo64, dividend.hi64, divisor, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            return fallback__udivrem128x64(dividend, divisor, out _);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __udiv128x64_rLEhi(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__udivrem128x64_rLEhi(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = q(dividend.lo64, dividend.hi64, divisor, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            return fallback__udivrem128x64_rLEhi(dividend, divisor, out _);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __urem128x64(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

            if (constexpr.IS_TRUE(divisor <= dividend.hi64))
            {
                return __urem128x64_rLEhi(dividend, divisor);
            }
            else if (constexpr.IS_TRUE(divisor > dividend.hi64))
            {
                return __usf__urem128x64(dividend, divisor);
            }

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x64(dividend, divisor, out ulong constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return s(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            fallback__udivrem128x64(dividend, divisor, out ulong remainder);

            return remainder;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __urem128x64_rLEhi(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__udivrem128x64_rLEhi(dividend, divisor, out ulong constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return t(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            fallback__udivrem128x64_rLEhi(dividend, divisor, out ulong remainder);

            return remainder;
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void __spc__4xudivmax128x64_inc(ulong divisor0, [NoAlias] out UInt128 result0, ulong divisor1, [NoAlias] out UInt128 result1, ulong divisor2, [NoAlias] out UInt128 result2, ulong divisor3, [NoAlias] out UInt128 result3)
        {
            CHECK_DIVISOR(divisor0);
            CHECK_DIVISOR(divisor1);
            CHECK_DIVISOR(divisor2);
            CHECK_DIVISOR(divisor3);

        #if WINDOWS
            if (constexpr.IS_CONST(divisor0)
             && constexpr.IS_CONST(divisor1)
             && constexpr.IS_CONST(divisor2)
             && constexpr.IS_CONST(divisor3))
            {
                UInt128 constResult0 = fallback__spc__udivmax128x64_inc(divisor0);
                UInt128 constResult1 = fallback__spc__udivmax128x64_inc(divisor1);
                UInt128 constResult2 = fallback__spc__udivmax128x64_inc(divisor2);
                UInt128 constResult3 = fallback__spc__udivmax128x64_inc(divisor3);

                if (constexpr.IS_CONST(constResult0)
                 && constexpr.IS_CONST(constResult1)
                 && constexpr.IS_CONST(constResult2)
                 && constexpr.IS_CONST(constResult3))
                {
                    result0 = constResult0;
                    result1 = constResult1;
                    result2 = constResult2;
                    result3 = constResult3;

                    return;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* results = stackalloc ulong[7];
                ulong result3_lo = v(divisor0, divisor1, results, divisor2, divisor3);

                result0 = new UInt128(results[0], results[1]);
                result1 = new UInt128(results[2], results[3]);
                result2 = new UInt128(results[4], results[5]);
                result3 = new UInt128(result3_lo, results[6]);

                return;
            }
        #endif

            result0 = fallback__spc__udivmax128x64_inc(divisor0);
            result1 = fallback__spc__udivmax128x64_inc(divisor1);
            result2 = fallback__spc__udivmax128x64_inc(divisor2);
            result3 = fallback__spc__udivmax128x64_inc(divisor3);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void __spc__3xudivmax128x64_inc(ulong divisor0, [NoAlias] out UInt128 result0, ulong divisor1, [NoAlias] out UInt128 result1, ulong divisor2, [NoAlias] out UInt128 result2)
        {
            CHECK_DIVISOR(divisor0);
            CHECK_DIVISOR(divisor1);
            CHECK_DIVISOR(divisor2);

        #if WINDOWS
            if (constexpr.IS_CONST(divisor0)
             && constexpr.IS_CONST(divisor1)
             && constexpr.IS_CONST(divisor2))
            {
                UInt128 constResult0 = fallback__spc__udivmax128x64_inc(divisor0);
                UInt128 constResult1 = fallback__spc__udivmax128x64_inc(divisor1);
                UInt128 constResult2 = fallback__spc__udivmax128x64_inc(divisor2);

                if (constexpr.IS_CONST(constResult0)
                 && constexpr.IS_CONST(constResult1)
                 && constexpr.IS_CONST(constResult2))
                {
                    result0 = constResult0;
                    result1 = constResult1;
                    result2 = constResult2;

                    return;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* results = stackalloc ulong[5];
                ulong result2_lo = w(divisor0, divisor1, results, divisor2);

                result0 = new UInt128(results[0], results[1]);
                result1 = new UInt128(results[2], results[3]);
                result2 = new UInt128(result2_lo, results[4]);

                return;
            }
        #endif

            result0 = fallback__spc__udivmax128x64_inc(divisor0);
            result1 = fallback__spc__udivmax128x64_inc(divisor1);
            result2 = fallback__spc__udivmax128x64_inc(divisor2);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static void __spc__2xudivmax128x64_inc(ulong divisor0, [NoAlias] out UInt128 result0, ulong divisor1, [NoAlias] out UInt128 result1)
        {
            CHECK_DIVISOR(divisor0);
            CHECK_DIVISOR(divisor1);

        #if WINDOWS
            if (constexpr.IS_CONST(divisor0)
             && constexpr.IS_CONST(divisor1))
            {
                UInt128 constResult0 = fallback__spc__udivmax128x64_inc(divisor0);
                UInt128 constResult1 = fallback__spc__udivmax128x64_inc(divisor1);

                if (constexpr.IS_CONST(constResult0)
                 && constexpr.IS_CONST(constResult1))
                {
                    result0 = constResult0;
                    result1 = constResult1;

                    return;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* results = stackalloc ulong[3];
                ulong result1_lo = x(divisor0, divisor1, results);

                result0 = new UInt128(results[0], results[1]);
                result1 = new UInt128(result1_lo, results[2]);

                return;
            }
        #endif

            result0 = fallback__spc__udivmax128x64_inc(divisor0);
            result1 = fallback__spc__udivmax128x64_inc(divisor1);
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static UInt128 __spc__udivmax128x64_inc(ulong divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(divisor))
            {
                UInt128 constResult = fallback__spc__udivmax128x64_inc(divisor);

                if (constexpr.IS_CONST(constResult))
                {
                    return constResult;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong hi;
                ulong lo = y(divisor, &hi);

                return new UInt128(lo, hi);
            }
        #endif

            return fallback__spc__udivmax128x64_inc(divisor);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ulong4 __spc__4xudiv128hiXloRlo(ulong4 hiDividends, ulong4 divisors)
        {
            CHECK_DIVISOR(divisors.x);
            CHECK_DIVISOR(divisors.y);
            CHECK_DIVISOR(divisors.z);
            CHECK_DIVISOR(divisors.w);

        #if WINDOWS
            if (constexpr.IS_CONST(hiDividends) && constexpr.IS_CONST(divisors))
            {
                ulong4 constResults = new ulong4(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.z), divisors.z, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.w), divisors.w, out _));

                if (constexpr.IS_CONST(constResults))
                {
                    return constResults;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                z((ulong*)&hiDividends, (ulong*)&divisors);

                return hiDividends;
            }
        #endif

            return new ulong4(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.z), divisors.z, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.w), divisors.w, out _));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ulong3 __spc__3xudiv128hiXloRlo(ulong3 hiDividends, ulong3 divisors)
        {
            CHECK_DIVISOR(divisors.x);
            CHECK_DIVISOR(divisors.y);
            CHECK_DIVISOR(divisors.z);

        #if WINDOWS
            if (constexpr.IS_CONST(hiDividends) && constexpr.IS_CONST(divisors))
            {
                ulong3 constResults = new ulong3(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.z), divisors.z, out _));

                if (constexpr.IS_CONST(constResults))
                {
                    return constResults;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                A((ulong*)&hiDividends, divisors.y, divisors.z, divisors.x);

                return hiDividends;
            }
        #endif

            return new ulong3(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.z), divisors.z, out _));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ulong2 __spc__2xudiv128hiXloRlo(ulong2 hiDividends, ulong2 divisors)
        {
            CHECK_DIVISOR(divisors.x);
            CHECK_DIVISOR(divisors.y);

        #if WINDOWS
            if (constexpr.IS_CONST(hiDividends) && constexpr.IS_CONST(divisors))
            {
                ulong2 constResults = new ulong2(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                                                 fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _));

                if (constexpr.IS_CONST(constResults))
                {
                    return constResults;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                B((ulong*)&hiDividends, divisors.x, divisors.y);

                return hiDividends;
            }
        #endif

            return new ulong2(fallback__usf__udivrem128x64(new UInt128(0, hiDividends.x), divisors.x, out _),
                              fallback__usf__udivrem128x64(new UInt128(0, hiDividends.y), divisors.y, out _));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ulong __spc__udiv128hiXloRlo(ulong hiDividend, ulong divisor)
        {
            return __usf__udiv128x64(new UInt128(0, hiDividend), divisor);
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __usf__udivrem128x64(UInt128 dividend, ulong divisor, out ulong remainder)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__usf__udivrem128x64(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong rem;
                ulong q = D(dividend.lo64, dividend.hi64, divisor, &rem);
                remainder = rem;
                return q;
            }
        #endif

            return fallback__usf__udivrem128x64(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __usf__udiv128x64(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                ulong constQuotient = fallback__usf__udivrem128x64(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return F(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            return fallback__usf__udivrem128x64(dividend, divisor, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __usf__urem128x64(UInt128 dividend, ulong divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__usf__udivrem128x64(dividend, divisor, out ulong constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return H(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            fallback__usf__udivrem128x64(dividend, divisor, out ulong remainder);

            return remainder;
        }


        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __usf__idivrem128x64(Int128 dividend, long divisor, out long remainder)
        {
            CHECK_DIVISOR((UInt128)divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                long constQuotient = fallback__usf__idivrem128x64(dividend, divisor, out remainder);

                if (constexpr.IS_CONST(constQuotient) && constexpr.IS_CONST(remainder))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                long rem;
                long q = E(dividend.lo64, dividend.hi64, divisor, &rem);
                remainder = rem;
                return q;
            }
        #endif

            return fallback__usf__idivrem128x64(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __usf__idiv128x64(Int128 dividend, long divisor)
        {
            CHECK_DIVISOR((UInt128)divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                long constQuotient = fallback__usf__idivrem128x64(dividend, divisor, out _);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return G(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            return fallback__usf__idivrem128x64(dividend, divisor, out _);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long __usf__irem128x64(Int128 dividend, long divisor)
        {
            CHECK_DIVISOR((UInt128)divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                fallback__usf__idivrem128x64(dividend, divisor, out long constRemainder);

                if (constexpr.IS_CONST(constRemainder))
                {
                    return constRemainder;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                return I(dividend.lo64, dividend.hi64, divisor);
            }
        #endif

            fallback__usf__idivrem128x64(dividend, divisor, out long remainder);

            return remainder;
        }
    }
}
