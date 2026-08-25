using System;
using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        // perfect divisors, factorization(2^BITS + 1)
        internal const uint PERFECT_DIVISOR_32_0 = 641;
        internal const uint PERFECT_DIVISOR_32_1 = 6700417;

        internal const ulong PERFECT_DIVISOR_64_0 = 274177;
        internal const ulong PERFECT_DIVISOR_64_1 = 67280421310721;

        internal static UInt128 PERFECT_DIVISOR_128_0 => new UInt128(0x00D3_EAFC_3AF1_4601, 0x0000_0000_0000_0000);
        internal static UInt128 PERFECT_DIVISOR_128_1 => new UInt128(0x4077_5B48_CC32_BA01, 0x0000_0000_0000_0135);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(uint x, uint divisor, out uint result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_1, out _, out result);
                constexpr.ASSUME(result == x / divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_0, out _, out result);
                constexpr.ASSUME(result == x / divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(uint2 x, uint divisor, out uint2 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint2)divisor, 2);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_1))
            {
                result = x * PERFECT_DIVISOR_32_0;
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint2)divisor, 2);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(uint3 x, uint divisor, out uint3 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint3)divisor, 3);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint3)divisor, 3);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(uint4 x, uint divisor, out uint4 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint4)divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint4)divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(uint8 x, uint divisor, out uint8 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint8)divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_32_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_32_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU32(result, x, (uint8)divisor);
                return true;
            }

            result = 0;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(ulong x, ulong divisor, out ulong result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_1, out _, out result);
                constexpr.ASSUME(result == x / divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_0, out _, out result);
                constexpr.ASSUME(result == x / divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(ulong2 x, ulong divisor, out ulong2 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong2)divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong2)divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(ulong3 x, ulong divisor, out ulong3 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong3)divisor, 3);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong3)divisor, 3);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(ulong4 x, ulong divisor, out ulong4 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_1, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong3)divisor, 4);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_64_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_64_0, out _, out result);
                constexpr.ASSUME_DIVISION_EPU64(result, x, (ulong3)divisor, 4);
                return true;
            }

            result = 0;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(UInt128 x, UInt128 divisor, out UInt128 result)
        {
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_128_0))
            {
                math.mulwide(x, PERFECT_DIVISOR_128_1, out _, out result);
                UInt128.ASSUME_DIVISION(result, x, divisor);
                return true;
            }
            if (constexpr.IS_TRUE(divisor == PERFECT_DIVISOR_128_1))
            {
                math.mulwide(x, PERFECT_DIVISOR_128_0, out _, out result);
                UInt128.ASSUME_DIVISION(result, x, divisor);
                return true;
            }

            result = 0;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(int x, int divisor, out int result)
        {
            if (DivideIfWellKnown((uint)math.abs(x), (uint)math.abs(divisor), out uint unsignedResult))
            {
                result = math.copysign((int)unsignedResult, x ^ divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(int2 x, int divisor, out int2 result)
        {
            if (DivideIfWellKnown((uint2)math.abs(x), (uint)math.abs(divisor), out uint2 unsignedResult))
            {
                result = math.copysign((int2)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(int3 x, int divisor, out int3 result)
        {
            if (DivideIfWellKnown((uint3)math.abs(x), (uint)math.abs(divisor), out uint3 unsignedResult))
            {
                result = math.copysign((int3)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(int4 x, int divisor, out int4 result)
        {
            if (DivideIfWellKnown((uint4)math.abs(x), (uint)math.abs(divisor), out uint4 unsignedResult))
            {
                result = math.copysign((int4)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(int8 x, int divisor, out int8 result)
        {
            if (DivideIfWellKnown((uint8)math.abs(x), (uint)math.abs(divisor), out uint8 unsignedResult))
            {
                result = math.copysign((int8)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(long x, long divisor, out long result)
        {
            if (DivideIfWellKnown((ulong)math.abs(x), (ulong)math.abs(divisor), out ulong unsignedResult))
            {
                result = math.copysign((long)unsignedResult, x ^ divisor);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(long2 x, long divisor, out long2 result)
        {
            if (DivideIfWellKnown((ulong2)math.abs(x), (ulong)math.abs(divisor), out ulong2 unsignedResult))
            {
                result = math.copysign((long2)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(long3 x, long divisor, out long3 result)
        {
            if (DivideIfWellKnown((ulong3)math.abs(x), (ulong)math.abs(divisor), out ulong3 unsignedResult))
            {
                result = math.copysign((long3)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(long4 x, long divisor, out long4 result)
        {
            if (DivideIfWellKnown((ulong4)math.abs(x), (ulong)math.abs(divisor), out ulong4 unsignedResult))
            {
                result = math.copysign((long4)unsignedResult, x ^ divisor, Promise.NonZero | Promise.ZeroOrGreater);
                return true;
            }

            result = 0;
            return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool DivideIfWellKnown(Int128 x, Int128 divisor, out Int128 result)
        {
            if (DivideIfWellKnown((UInt128)math.abs(x), (UInt128)math.abs(divisor), out UInt128 unsignedResult))
            {
                result = math.copysign((Int128)unsignedResult, x ^ divisor);
                return true;
            }

            result = 0;
            return false;
        }
    }
}
