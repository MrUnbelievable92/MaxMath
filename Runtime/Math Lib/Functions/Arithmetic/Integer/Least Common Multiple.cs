using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using Unity.Burst;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu8(v128 a, v128 b, bool promiseNonZero = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                    v128 left = constexpr.IS_CONST(a) ? b : a;
                    v128 right = gcd_epu8(a, b, promiseNonZero, elements);
                    v128 mul = constexpr.IS_CONST(a) ? a : b;

                    return divmullo_epu8(left, right, mul, out _, noOverflow: true, elements: elements);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu8x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                    v128 left0 = constexpr.IS_CONST(a0) ? b0 : a0;
                    v128 left1 = constexpr.IS_CONST(a1) ? b1 : a1;
                    gcd_epu8x2(a0, a1, b0, b1, out v128 right0, out v128 right1, promiseNonZero);
                    v128 mul0 = constexpr.IS_CONST(a0) ? a0 : b0;
                    v128 mul1 = constexpr.IS_CONST(a1) ? a1 : b1;

                    r0 = divmullo_epu8(left0, right0, mul0, out _, noOverflow: true, elements: 16);
                    r1 = divmullo_epu8(left1, right1, mul1, out _, noOverflow: true, elements: 16);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu8(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    // counter-intuitive but this is free (ILP during gcd); whereas multiplication at the very end could be up to 4 cycles faster this way
                    v256 left = constexpr.IS_CONST(a) ? b : a;
                    v256 right = mm256_gcd_epu8(a, b, promiseNonZero);
                    v256 mul = constexpr.IS_CONST(a) ? a : b;

                    return mm256_divmullo_epu8(left, right, mul, out _, noOverflow: true);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu16(v128 a, v128 b, bool promiseNonZero = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return mullo_epi16(div_epu16(b, gcd_epu16(a, b, promiseNonZero, elements), elements), a);
                    }
                    else
                    {
                        return mullo_epi16(div_epu16(a, gcd_epu16(a, b, promiseNonZero, elements), elements), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu16x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu16x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi16(div_epu16(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi16(div_epu16(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi16(div_epu16(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi16(div_epu16(a1, gcd1), b1);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu16(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return Avx2.mm256_mullo_epi16(mm256_div_epu16(b, mm256_gcd_epu16(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi16(mm256_div_epu16(a, mm256_gcd_epu16(a, b, promiseNonZero)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu32(v128 a, v128 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return mullo_epi32(div_epu32(b, gcd_epu32(a, b, promiseNonZero, elements), elements), a, elements);
                    }
                    else
                    {
                        return mullo_epi32(div_epu32(a, gcd_epu32(a, b, promiseNonZero, elements), elements), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu32x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu32x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi32(div_epu32(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi32(div_epu32(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi32(div_epu32(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi32(div_epu32(a1, gcd1), b1);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu32(v256 a, v256 b, bool promiseNonZero = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return Avx2.mm256_mullo_epi32(mm256_div_epu32(b, mm256_gcd_epu32(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        return Avx2.mm256_mullo_epi32(mm256_div_epu32(a, mm256_gcd_epu32(a, b, promiseNonZero)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 lcm_epu64(v128 a, v128 b, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return mullo_epi64(div_epu64(b, gcd_epu64(a, b, promiseNonZero)), a);
                    }
                    else
                    {
                        return mullo_epi64(div_epu64(a, gcd_epu64(a, b, promiseNonZero)), b);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void lcm_epu64x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1, bool promiseNonZero = false)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    gcd_epu64x2(a0, a1, b0, b1, out v128 gcd0, out v128 gcd1, promiseNonZero);

                    if (constexpr.IS_CONST(a0))
                    {
                        r0 = mullo_epi64(div_epu64(b0, gcd0), a0);

                    }
                    else
                    {
                        r0 = mullo_epi64(div_epu64(a0, gcd0), b0);
                    }

                    if (constexpr.IS_CONST(a1))
                    {
                        r1 = mullo_epi64(div_epu64(b1, gcd1), a1);
                    }
                    else
                    {
                        r1 = mullo_epi64(div_epu64(a1, gcd1), b1);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_lcm_epu64(v256 a, v256 b, bool promiseNonZero = false, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.IS_CONST(a))
                    {
                        return mm256_mullo_epi64(mm256_div_epu64(b, mm256_gcd_epu64(a, b, promiseNonZero, elements), elements: elements), a, elements);
                    }
                    else
                    {
                        return mm256_mullo_epi64(mm256_div_epu64(a, mm256_gcd_epu64(a, b, promiseNonZero, elements), elements: elements), b, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the least common multiple of two <see cref="UInt128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(UInt128 x, UInt128 y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x))
            {
                return (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                return (x / gcd(x, y, nonZero)) * y;
            }
        }

        /// <summary>       Returns the least common multiple of two <see cref="Int128"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 lcm(Int128 x, Int128 y, Promise nonZero = Promise.Nothing)
        {
            UInt128 absX = (UInt128)abs(x);
            UInt128 absY = (UInt128)abs(y);

            if (constexpr.IS_CONST(absX))
            {
                return (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY, nonZero)) * absY;
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="byte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, (ulong)byte.MaxValue * byte.MaxValue)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(byte x, byte y, Promise nonZero = Promise.Nothing)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(byte2 x, byte2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(byte3 x, byte3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(byte4 x, byte4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(byte8 x, byte8 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(byte16 x, byte16 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(x, y, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.byte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(byte32 x, byte32 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu8x2(x.v16_0, x.v16_16, y.v16_0, y.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="sbyte"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, ((ulong)sbyte.MaxValue + 1ul) * ((ulong)sbyte.MaxValue + 1ul))]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(sbyte x, sbyte y, Promise nonZero = Promise.Nothing)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 lcm(sbyte2 x, sbyte2 y, Promise nonZero = Promise.Nothing)
        {
            byte2 absX = (byte2)abs(x);
            byte2 absY = (byte2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 lcm(sbyte3 x, sbyte3 y, Promise nonZero = Promise.Nothing)
        {
            byte3 absX = (byte3)abs(x);
            byte3 absY = (byte3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 lcm(sbyte4 x, sbyte4 y, Promise nonZero = Promise.Nothing)
        {
            byte4 absX = (byte4)abs(x);
            byte4 absY = (byte4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 lcm(sbyte8 x, sbyte8 y, Promise nonZero = Promise.Nothing)
        {
            byte8 absX = (byte8)abs(x);
            byte8 absY = (byte8)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 lcm(sbyte16 x, sbyte16 y, Promise nonZero = Promise.Nothing)
        {
            byte16 absX = (byte16)abs(x);
            byte16 absY = (byte16)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero), 16);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.sbyte32"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 lcm(sbyte32 x, sbyte32 y, Promise nonZero = Promise.Nothing)
        {
            byte32 absX = (byte32)abs(x);
            byte32 absY = (byte32)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu8(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu8x2(absX.v16_0, absX.v16_16, absY.v16_0, absY.v16_16, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new byte32(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="ushort"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(ushort x, ushort y, Promise nonZero = Promise.Nothing)
        {
            return lcm((uint)x, (uint)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(ushort2 x, ushort2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(ushort3 x, ushort3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(ushort4 x, ushort4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(ushort8 x, ushort8 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(x, y, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ushort16"/>s.r.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(ushort16 x, ushort16 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu16x2(x.v8_0, x.v8_8, y.v8_0, y.v8_8, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ushort16(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="short"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(short x, short y, Promise nonZero = Promise.Nothing)
        {
            return lcm((int)x, (int)y);
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 lcm(short2 x, short2 y, Promise nonZero = Promise.Nothing)
        {
            ushort2 absX = (ushort2)abs(x);
            ushort2 absY = (ushort2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 2);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 lcm(short3 x, short3 y, Promise nonZero = Promise.Nothing)
        {
            ushort3 absX = (ushort3)abs(x);
            ushort3 absY = (ushort3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 lcm(short4 x, short4 y, Promise nonZero = Promise.Nothing)
        {
            ushort4 absX = (ushort4)abs(x);
            ushort4 absY = (ushort4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 lcm(short8 x, short8 y, Promise nonZero = Promise.Nothing)
        {
            ushort8 absX = (ushort8)abs(x);
            ushort8 absY = (ushort8)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero), 8);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.short16"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 lcm(short16 x, short16 y, Promise nonZero = Promise.Nothing)
        {
            ushort16 absX = (ushort16)abs(x);
            ushort16 absY = (ushort16)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu16(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu16x2(absX.v8_0, absX.v8_8, absY.v8_0, absY.v8_8, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ushort16(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="int"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(int x, int y, Promise nonZero = Promise.Nothing)
        {
            uint absX = constexpr.IS_TRUE(x >= 0) ? (uint)x : (uint)math.abs(x);
            uint absY = constexpr.IS_TRUE(x >= 0) ? (uint)y : (uint)math.abs(y);

            if (constexpr.IS_CONST(absX))
            {
                return (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY, nonZero)) * absY;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(int2 x, int2 y, Promise nonZero = Promise.Nothing)
        {
            uint2 absX = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint2)x : (uint2)abs(x);
            uint2 absY = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint2)y : (uint2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), nonZero.Promises(Promise.NonZero), 2));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(int3 x, int3 y, Promise nonZero = Promise.Nothing)
        {
            uint3 absX = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint3)x : (uint3)abs(x);
            uint3 absY = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint3)y : (uint3)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), nonZero.Promises(Promise.NonZero), 3));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="int4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(int4 x, int4 y, Promise nonZero = Promise.Nothing)
        {
            uint4 absX = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint4)x : (uint4)abs(x);
            uint4 absY = constexpr.IS_TRUE(math.all(x >= 0)) ? (uint4)y : (uint4)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.lcm_epu32(RegisterConversion.ToV128(absX), RegisterConversion.ToV128(absY), nonZero.Promises(Promise.NonZero), 4));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.int8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(int8 x, int8 y, Promise nonZero = Promise.Nothing)
        {
            uint8 absX = constexpr.IS_TRUE(all(x >= 0)) ? (uint8)x : (uint8)abs(x);
            uint8 absY = constexpr.IS_TRUE(all(x >= 0)) ? (uint8)y : (uint8)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu32x2(RegisterConversion.ToV128(absX.v4_0), RegisterConversion.ToV128(absX.v4_4), RegisterConversion.ToV128(absY.v4_0), RegisterConversion.ToV128(absY.v4_4), out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="uint"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint lcm(uint x, uint y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x))
            {
                return (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                return (x / gcd(x, y, nonZero)) * y;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 lcm(uint2 x, uint2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt2(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 2));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 lcm(uint3 x, uint3 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 3));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="uint4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 lcm(uint4 x, uint4 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt4(Xse.lcm_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), nonZero.Promises(Promise.NonZero), 4));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.uint8"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 lcm(uint8 x, uint8 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu32(x, y, nonZero.Promises(Promise.NonZero));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu32x2(RegisterConversion.ToV128(x.v4_0), RegisterConversion.ToV128(x.v4_4), RegisterConversion.ToV128(y.v4_0), RegisterConversion.ToV128(y.v4_4), out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new uint8(RegisterConversion.ToUInt4(lo), RegisterConversion.ToUInt4(hi));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="long"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(long x, long y, Promise nonZero = Promise.Nothing)
        {
            ulong absX = constexpr.IS_TRUE(x >= 0) ? (ulong)x : (ulong)math.abs(x);
            ulong absY = constexpr.IS_TRUE(x >= 0) ? (ulong)y : (ulong)math.abs(y);

            if (constexpr.IS_CONST(x))
            {
                return (absY / gcd(absX, absY, nonZero)) * absX;
            }
            else
            {
                return (absX / gcd(absX, absY, nonZero)) * absY;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(long2 x, long2 y, Promise nonZero = Promise.Nothing)
        {
            ulong2 absX = (ulong2)abs(x);
            ulong2 absY = (ulong2)abs(y);

            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(long3 x, long3 y, Promise nonZero = Promise.Nothing)
        {
            ulong3 absX = (ulong3)abs(x);
            ulong3 absY = (ulong3)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(absX.xy, absX.zz, absY.xy, absY.zz, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.long4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(long4 x, long4 y, Promise nonZero = Promise.Nothing)
        {
            ulong4 absX = (ulong4)abs(x);
            ulong4 absY = (ulong4)abs(y);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(absX, absY, nonZero.Promises(Promise.NonZero), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(absX.xy, absX.zw, absY.xy, absY.zw, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong4(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (absY / gcd(absX, absY, nonZero)) * absX;
                }
                else
                {
                    return (absX / gcd(absX, absY, nonZero)) * absY;
                }
            }
        }


        /// <summary>       Returns the least common multiple of two <see cref="ulong"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong lcm(ulong x, ulong y, Promise nonZero = Promise.Nothing)
        {
            if (constexpr.IS_CONST(x))
            {
                return (y / gcd(x, y, nonZero)) * x;
            }
            else
            {
                return (x / gcd(x, y, nonZero)) * y;
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong2"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 lcm(ulong2 x, ulong2 y, Promise nonZero = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.lcm_epu64(x, y, nonZero.Promises(Promise.NonZero));
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong3"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 lcm(ulong3 x, ulong3 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, nonZero.Promises(Promise.NonZero), 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(x.xy, x.zz, y.xy, y.zz, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong3(lo, hi.ULong0);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }

        /// <summary>       Returns the componentwise least common multiple of the corresponding values of two <see cref="MaxMath.ulong4"/>s.
        /// <remarks>
        /// <para>          Calling this function with a <see cref="Promise"/> '<paramref name="nonZero"/>' with its <see cref="Promise.NonZero"/> flag set will be stuck in an infinite loop for any <paramref name="x"/> or <paramref name="y"/> equal to 0.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 lcm(ulong4 x, ulong4 y, Promise nonZero = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_lcm_epu64(x, y, nonZero.Promises(Promise.NonZero), 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Xse.lcm_epu64x2(x.xy, x.zw, y.xy, y.zw, out v128 lo, out v128 hi, nonZero.Promises(Promise.NonZero));

                return new ulong4(lo, hi);
            }
            else
            {
                if (constexpr.IS_CONST(x))
                {
                    return (y / gcd(x, y, nonZero)) * x;
                }
                else
                {
                    return (x / gcd(x, y, nonZero)) * y;
                }
            }
        }
    }
}