#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
#define WINDOWS
#endif

//#define TESTING

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst;
using DevTools;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static MaxMath.math;

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

        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#32"*/)] extern private static ulong J(ulong dividend0, ulong dividend64, ulong dividend128, ulong dividend192, ulong divisorlo, ulong divisorhi, ulong* quotient);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#33"*/)] extern private static ulong K(ulong dividend0, ulong dividend64, ulong divisorlo, ulong divisorhi, ulong* quoPtr);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#33"*/)] extern private static ulong L(ulong dividend0, ulong dividend64, ulong divisorlo, ulong divisorhi, long count, ulong* remHiPtr);
        [DllImport("asm128", CallingConvention = CallingConvention.Cdecl/*, EntryPoint = "#34"*/)] extern private static ulong M(ulong divisorlo, ulong divisorhi, ulong* quoPtr);
     #endif


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CHECK_DIVISOR(UInt128 divisor)
        {
#if DEBUG
if (divisor.IsZero) throw new DivideByZeroException();
#endif
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CHECK_DIVISOR(__UInt256__ divisor)
        {
#if DEBUG
if (divisor.IsZero) throw new DivideByZeroException();
#endif
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool usf__sdivrem128x64_fits64(Int128 dividend, long divisor)
        {
            if (divisor > 0)
            {
                long h = divisor >> 1;
                return ((long)dividend.hi64 >= -h) & ((long)dividend.hi64 < h);
            }
            else
            {
                ulong u  = (ulong)(-divisor);
                ulong h  = u >> 1;
                ulong hc = (u + 1) >> 1;
                return ((long)dividend.hi64 > -(long)hc) & ((long)dividend.hi64 < (long)h);
            }
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

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static __UInt256__ fallback__udivrem256x128_rLEhi(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder)
        {
            UInt128 quotientHi = __udivrem128x128(dividend.hi128, divisor, out UInt128 dividendHi);
            dividend = new __UInt256__(dividend.lo128, dividendHi);

            return new __UInt256__(__usf__udivrem256x128(dividend, divisor, out remainder), quotientHi);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 /*fallback*/__usf__udivrem256x128(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder, bool preShift = false, int shift = -1, bool alignedDivisorHiLessThanAlignedDividendHi128Hi64 = false)
        {
Assert.IsSmaller(dividend.hi128, divisor);

            if (!preShift)
            {
                shift = lzcnt(divisor);
                dividend <<= shift;
                divisor <<= shift;
            }

            UInt128 qHi = alignedDivisorHiLessThanAlignedDividendHi128Hi64 ? __usf__udivrem128x64(dividend.hi128, divisor.hi64, out ulong remdiv)
                                                                           : __udivrem128x64(dividend.hi128, divisor.hi64, out remdiv);
            UInt128 remdiv128 = new UInt128(dividend.lo128.hi64, remdiv);
            remainder = remdiv128 - (qHi * divisor.lo64);
            bool b1 = remainder > remdiv128;
            bool b2 = b1 & ((UInt128)(-(Int128)remainder) > divisor);
            qHi -= tobyte(b2);
            qHi -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            UInt128 qLo = __udivrem128x64(remainder, divisor.hi64, out remdiv);
            remdiv128 = new UInt128(dividend.lo128.lo64, remdiv);
            remainder = remdiv128 - (qLo * divisor.lo64);
            b1 = remainder > remdiv128;
            b2 = b1 & ((UInt128)(-(Int128)remainder) > divisor);
            qLo -= tobyte(b2);
            qLo -= tobyte(b1);
            remainder += b1 ? divisor : 0;
            remainder += b2 ? divisor : 0;

            remainder >>= shift;
            return new UInt128(qLo.lo64, qHi.lo64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 /*fallback*/__udivrem256x256_rGTu128max_rLEl(__UInt256__ dividend, __UInt256__ divisor, out __UInt256__ remainder)
        {
            remainder = dividend;

            int shift = lzcnt(divisor.hi128);

            UInt128 scaledHi = (divisor << shift).hi128;
            UInt128 roundBit = tobyte(dividend.hi128 >= scaledHi);
            dividend = new __UInt256__(dividend.lo128, dividend.hi128 < scaledHi ? dividend.hi128 : dividend.hi128 - scaledHi);
            UInt128 scaledLo = (new __UInt256__(__usf__udivrem256x128(dividend, scaledHi, out _), roundBit) << shift).hi128;
            scaledHi = scaledLo * divisor.hi128;
            dividend = __UInt256__.umul256(divisor.lo128, scaledLo);

            remainder -= dividend;
            UInt128 quotient = scaledLo - tobyte(remainder.hi128 < scaledHi);
            divisor = remainder.hi128 < scaledHi ? divisor : 0;
            remainder = new __UInt256__(remainder.lo128, remainder.hi128 - scaledHi);
            remainder += divisor;

            return quotient;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 fallback__usf__udiv256x128(__UInt256__ dividend, UInt128 divisor, bool preShift = false, int shift = -1)
        {
            CHECK_DIVISOR(divisor);

            return __usf__udivrem256x128(dividend, divisor, out _, preShift: preShift, shift: shift);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 /*fallback*/__usf__urem256x128(__UInt256__ dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

            __usf__udivrem256x128(dividend, divisor, out UInt128 rem);

            return rem;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ /*fallback*/__udivrem256x128(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder)
        {
            CHECK_DIVISOR(divisor);
            
            if (dividend.hi128 >= divisor)
            {
                return fallback__udivrem256x128_rLEhi(dividend, divisor, out remainder);
            }
            else
            {
                return __usf__udivrem256x128(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ /*fallback*/__udivrem256x256(__UInt256__ dividend, __UInt256__ divisor, out __UInt256__ remainder)
        {
            CHECK_DIVISOR(divisor);

            if (divisor > dividend)
            {
                remainder = dividend;

                return 0;
            }
	        else
            {
                return udivrem256x256_rLEl(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static __UInt256__ udivrem256x256_rLEl(__UInt256__ dividend, __UInt256__ divisor, out __UInt256__ remainder)
        {
            CHECK_DIVISOR(divisor);

            if (divisor.hi128.IsZero)
            {
                __UInt256__ quotient = __udivrem256x128(dividend, divisor.lo128, out UInt128 remainder128);

                remainder = remainder128;
                return quotient;
            }
            else
            {
                return __udivrem256x256_rGTu128max_rLEl(dividend, divisor, out remainder);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static UInt128 __udivrem256x256_rGTu128max(__UInt256__ dividend, __UInt256__ divisor, out __UInt256__ remainder)
        {
            CHECK_DIVISOR(divisor);

            if (divisor > dividend)
            {
                remainder = dividend;

                return 0;
            }
	        else
            {
                return __udivrem256x256_rGTu128max_rLEl(dividend, divisor, out remainder);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ fallback__udiv256x128(__UInt256__ dividend, UInt128 divisor)
        {
            if (divisor > dividend)
            {
                return __UInt256__.MinValue;
            }
	        else
            {
                return fallback__udivrem256x128_rLEhi(dividend, divisor, out UInt128 _);
            }
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

            if (!BurstArchitecture.IsX86Win64Supported)
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static __UInt256__ __udivrem256x128_rLEhi(__UInt256__ dividend, UInt128 divisor, out UInt128 remainder)
        {
            return fallback__udivrem256x128_rLEhi(dividend, divisor, out remainder);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __usf__udiv256x128(__UInt256__ dividend, UInt128 divisor)
        {
            CHECK_DIVISOR(divisor);

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                UInt128 constQuotient = fallback__usf__udiv256x128(dividend, divisor);

                if (constexpr.IS_CONST(constQuotient))
                {
                    return constQuotient;
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* hi = stackalloc ulong[1];
                ulong lo = J(dividend.lo128.lo64, dividend.lo128.hi64, dividend.hi128.lo64, dividend.hi128.hi64, divisor.lo64, divisor.hi64, hi);

                return new UInt128(lo, *hi);
            }
        #endif


            return fallback__usf__udiv256x128(dividend, divisor);
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __usf__div128to256x128shl127x15(UInt128 dividend, UInt128 divisor, out UInt128 quotient)
        {
            __UInt256__ dividend256;
            UInt128 remainder;

        #if WINDOWS
            if (constexpr.IS_CONST(dividend) && constexpr.IS_CONST(divisor))
            {
                dividend256 = dividend;
                dividend256 <<= 112 + 15;

                quotient = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);

                if (constexpr.IS_CONST(quotient))
                {
                    remainder <<= 1;
                    return remainder > divisor ? (1ul << 63) | 1ul
                         : remainder == divisor ? (1ul << 63)
                         : 0ul; 
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* quoPtr = stackalloc ulong[2];

                ulong sigZExtra = K(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, quoPtr);

                quotient = new UInt128(quoPtr[0], quoPtr[1]);

            #if TESTING
                dividend256 = dividend;
                dividend256 <<= 112 + 15;
                
                UInt128 quotient2 = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);
                remainder <<= 1;
                ulong sigZExtra2 = remainder > divisor ? (1ul << 63) | 1ul
                                 : remainder == divisor ? (1ul << 63)
                                 : 0ul; 

                Assert.AreEqual(quotient, quotient2);
                Assert.AreEqual(sigZExtra, sigZExtra2);
            #endif

                return sigZExtra;
            }
        #endif
            
            dividend256 = dividend;
            dividend256 <<= 112 + 15;
            
            quotient = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);
            remainder <<= 1;
            return remainder > divisor ? (1ul << 63) | 1ul
                 : remainder == divisor ? (1ul << 63)
                 : 0ul; 
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 __usf__loop_rem128to256x128shl127x15(UInt128 dividend, UInt128 divisor, long count)
        {
			const int CHUNK = 112;
			const int SHIFT = 15;
            UInt128 shiftedDivisor;
            __UInt256__ finalNumerator;

        #if WINDOWS
            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* remHi = stackalloc ulong[1];
                ulong remLo = L(dividend.lo64, dividend.hi64, divisor.lo64, divisor.hi64, count, remHi);

                UInt128 rem = new UInt128(remLo, *remHi);

            #if TESTING
			    shiftedDivisor = divisor << SHIFT;
			    
			    while (count > CHUNK)
			    {
			        __UInt256__ numerator = (__UInt256__)dividend << (CHUNK + SHIFT);
			        __usf__udivrem256x128(numerator, shiftedDivisor, out dividend, preShift: true, shift: SHIFT);
			        count -= CHUNK;
			    }
			    
			    finalNumerator = (__UInt256__)dividend << ((int)count + SHIFT);
			    __usf__udivrem256x128(finalNumerator, shiftedDivisor, out dividend, preShift: true, shift: SHIFT);

                Assert.AreEqual(dividend, rem);
            #endif

                return rem;
            }
        #endif

			shiftedDivisor = divisor << SHIFT;
			
			while (count > CHUNK)
			{
			    __UInt256__ numerator = (__UInt256__)dividend << (CHUNK + SHIFT);
			    __usf__udivrem256x128(numerator, shiftedDivisor, out dividend, preShift: true, shift: SHIFT);
			    count -= CHUNK;
			}
			
			finalNumerator = (__UInt256__)dividend << ((int)count + SHIFT);
			__usf__udivrem256x128(finalNumerator, shiftedDivisor, out dividend, preShift: true, shift: SHIFT);

            return dividend;
        }

        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static ulong __rcpdivf128(UInt128 divisor, out UInt128 quotient)
        {
            __UInt256__ dividend256;
            UInt128 remainder;
            UInt128 sigA;
            UInt128 rem;

        #if WINDOWS
            if (constexpr.IS_CONST(divisor))
            {
                sigA = new UInt128(0, 1ul << quadruple.MANTISSA_BITS_HI64);
                rem = divisor != 0 ? sigA << 1 : sigA;

                dividend256 = rem;
                dividend256 <<= 112 + 15;

                quotient = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);

                if (constexpr.IS_CONST(quotient))
                {
                    remainder <<= 1;
                    return remainder > divisor ? (1ul << 63) | 1ul
                         : remainder == divisor ? (1ul << 63)
                         : 0ul; 
                }
            }

            if (BurstArchitecture.IsX86Win64Supported)
            {
                ulong* quo = stackalloc ulong[2];
                ulong sigZExtra = M(divisor.lo64, divisor.hi64, quo);

                quotient = new UInt128(quo[0], quo[1]);

            #if TESTING
                sigA = new UInt128(0, 1ul << quadruple.MANTISSA_BITS_HI64);
                rem = divisor != 0 ? sigA << 1 : sigA;

                dividend256 = rem;
                dividend256 <<= 112 + 15;
                
                UInt128 quotient2 = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);
                
                remainder <<= 1;
                ulong sigZExtra2 = remainder > divisor ? (1ul << 63) | 1ul
                                             : remainder == divisor ? (1ul << 63)
                                             : 0ul; 

                Assert.AreEqual(quotient, quotient2);
                Assert.AreEqual(sigZExtra, sigZExtra2);
            #endif
                return sigZExtra;
            }
        #endif
            
            sigA = new UInt128(0, 1ul << quadruple.MANTISSA_BITS_HI64);
            rem = divisor != 0 ? sigA << 1 : sigA;

            dividend256 = rem;
            dividend256 <<= 112 + 15;
            
            quotient = __usf__udivrem256x128(dividend256, divisor << 15, out remainder, preShift: true, shift: 15);
            
            remainder <<= 1;
            return remainder > divisor ? (1ul << 63) | 1ul
                 : remainder == divisor ? (1ul << 63)
                 : 0ul; 
        }
    }
}
