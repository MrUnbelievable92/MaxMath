using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(UInt128 dividend, UInt128 divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<UInt128> Divider = new Divider<UInt128>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(Int128 dividend, Int128 divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<Int128> Divider = new Divider<Int128>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(byte dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                if (ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(byte2 dividend, byte2 divisor)
        {
VectorAssert.AreNotEqual<byte2, byte>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<byte2> Divider = new Divider<byte2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(byte2 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(byte3 dividend, byte3 divisor)
        {
VectorAssert.AreNotEqual<byte3, byte>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<byte3> Divider = new Divider<byte3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(byte3 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(byte4 dividend, byte4 divisor)
        {
VectorAssert.AreNotEqual<byte4, byte>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<byte4> Divider = new Divider<byte4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(byte4 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(byte8 dividend, byte8 divisor)
        {
VectorAssert.AreNotEqual<byte8, byte>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<byte8> Divider = new Divider<byte8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(byte8 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(byte16 dividend, byte16 divisor)
        {
VectorAssert.AreNotEqual<byte16, byte>(divisor, 0, 16);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<byte16> Divider = new Divider<byte16>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(byte16 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(byte32 dividend, byte32 divisor)
        {
VectorAssert.AreNotEqual<byte32, byte>(divisor, 0, 32);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<byte32> Divider = new Divider<byte32>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(byte32 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }

                Divider<byte> Divider = new Divider<byte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(ushort dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ushort2 dividend, ushort2 divisor)
        {
VectorAssert.AreNotEqual<ushort2, ushort>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ushort2> Divider = new Divider<ushort2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ushort2 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ushort3 dividend, ushort3 divisor)
        {
VectorAssert.AreNotEqual<ushort3, ushort>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ushort3> Divider = new Divider<ushort3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ushort3 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ushort4 dividend, ushort4 divisor)
        {
VectorAssert.AreNotEqual<ushort4, ushort>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ushort4> Divider = new Divider<ushort4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ushort4 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(ushort8 dividend, ushort8 divisor)
        {
VectorAssert.AreNotEqual<ushort8, ushort>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<ushort8> Divider = new Divider<ushort8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(ushort8 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(ushort16 dividend, ushort16 divisor)
        {
VectorAssert.AreNotEqual<ushort16, ushort>(divisor, 0, 16);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<ushort16> Divider = new Divider<ushort16>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(ushort16 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }

                Divider<ushort> Divider = new Divider<ushort>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(uint dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<uint> Divider = new Divider<uint>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(uint2 dividend, uint2 divisor)
        {
VectorAssert.AreNotEqual<uint2, uint>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<uint2> Divider = new Divider<uint2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(uint2 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<uint> Divider = new Divider<uint>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(uint3 dividend, uint3 divisor)
        {
VectorAssert.AreNotEqual<uint3, uint>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<uint3> Divider = new Divider<uint3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(uint3 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<uint> Divider = new Divider<uint>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(uint4 dividend, uint4 divisor)
        {
VectorAssert.AreNotEqual<uint4, uint>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<uint4> Divider = new Divider<uint4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(uint4 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<uint> Divider = new Divider<uint>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(uint8 dividend, uint8 divisor)
        {
VectorAssert.AreNotEqual<uint8, uint>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<uint8> Divider = new Divider<uint8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(uint8 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<uint> Divider = new Divider<uint>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(ulong dividend, ulong divisor)
        {
Assert.AreNotEqual(0ul, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<ulong> Divider = new Divider<ulong>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ulong2 dividend, ulong2 divisor)
        {
VectorAssert.AreNotEqual<ulong2, ulong>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ulong2> Divider = new Divider<ulong2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ulong2 dividend, ulong divisor)
        {
Assert.AreNotEqual(0ul, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<ulong> Divider = new Divider<ulong>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ulong3 dividend, ulong3 divisor)
        {
VectorAssert.AreNotEqual<ulong3, ulong>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ulong3> Divider = new Divider<ulong3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ulong3 dividend, ulong divisor)
        {
Assert.AreNotEqual(0ul, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<ulong> Divider = new Divider<ulong>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ulong4 dividend, ulong4 divisor)
        {
VectorAssert.AreNotEqual<ulong4, ulong>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<ulong4> Divider = new Divider<ulong4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ulong4 dividend, ulong divisor)
        {
Assert.AreNotEqual(0ul, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1)
                {
                    return true;
                }
                else if (maxmath.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }

                Divider<ulong> Divider = new Divider<ulong>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(sbyte dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(sbyte2 dividend, sbyte2 divisor)
        {
VectorAssert.AreNotEqual<sbyte2, sbyte>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<sbyte2> Divider = new Divider<sbyte2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(sbyte2 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(sbyte3 dividend, sbyte3 divisor)
        {
VectorAssert.AreNotEqual<sbyte3, sbyte>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<sbyte3> Divider = new Divider<sbyte3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(sbyte3 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(sbyte4 dividend, sbyte4 divisor)
        {
VectorAssert.AreNotEqual<sbyte4, sbyte>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<sbyte4> Divider = new Divider<sbyte4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(sbyte4 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(sbyte8 dividend, sbyte8 divisor)
        {
VectorAssert.AreNotEqual<sbyte8, sbyte>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<sbyte8> Divider = new Divider<sbyte8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(sbyte8 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(sbyte16 dividend, sbyte16 divisor)
        {
VectorAssert.AreNotEqual<sbyte16, sbyte>(divisor, 0, 16);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<sbyte16> Divider = new Divider<sbyte16>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(sbyte16 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(sbyte32 dividend, sbyte32 divisor)
        {
VectorAssert.AreNotEqual<sbyte32, sbyte>(divisor, 0, 32);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<sbyte32> Divider = new Divider<sbyte32>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(sbyte32 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<sbyte> Divider = new Divider<sbyte>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(short dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(short2 dividend, short2 divisor)
        {
VectorAssert.AreNotEqual<short2, short>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<short2> Divider = new Divider<short2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(short2 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(short3 dividend, short3 divisor)
        {
VectorAssert.AreNotEqual<short3, short>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<short3> Divider = new Divider<short3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(short3 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(short4 dividend, short4 divisor)
        {
VectorAssert.AreNotEqual<short4, short>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<short4> Divider = new Divider<short4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(short4 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(short8 dividend, short8 divisor)
        {
VectorAssert.AreNotEqual<short8, short>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<short8> Divider = new Divider<short8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(short8 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(short16 dividend, short16 divisor)
        {
VectorAssert.AreNotEqual<short16, short>(divisor, 0, 16);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<short16> Divider = new Divider<short16>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(short16 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<short> Divider = new Divider<short>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(int dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<int> Divider = new Divider<int>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(int2 dividend, int2 divisor)
        {
VectorAssert.AreNotEqual<int2, int>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<int2> Divider = new Divider<int2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(int2 dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<int> Divider = new Divider<int>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(int3 dividend, int3 divisor)
        {
VectorAssert.AreNotEqual<int3, int>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<int3> Divider = new Divider<int3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(int3 dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<int> Divider = new Divider<int>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(int4 dividend, int4 divisor)
        {
VectorAssert.AreNotEqual<int4, int>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<int4> Divider = new Divider<int4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(int4 dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<int> Divider = new Divider<int>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return mod(dividend, divisor) == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(int8 dividend, int8 divisor)
        {
VectorAssert.AreNotEqual<int8, int>(divisor, 0, 8);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x0);
                }
                else
                {
                    Divider<int8> Divider = new Divider<int8>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(int8 dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<int> Divider = new Divider<int>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }


        /// <summary>       Returns <see langword="true"/> if the <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(long dividend, long divisor)
        {
Assert.AreNotEqual(0L, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<long> Divider = new Divider<long>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(long2 dividend, long2 divisor)
        {
VectorAssert.AreNotEqual<long2, long>(divisor, 0, 2);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<long2> Divider = new Divider<long2>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(long2 dividend, long divisor)
        {
Assert.AreNotEqual(0L, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<long> Divider = new Divider<long>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(long3 dividend, long3 divisor)
        {
VectorAssert.AreNotEqual<long3, long>(divisor, 0, 3);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<long3> Divider = new Divider<long3>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(long3 dividend, long divisor)
        {
Assert.AreNotEqual(0L, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<long> Divider = new Divider<long>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the corresponding <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(long4 dividend, long4 divisor)
        {
VectorAssert.AreNotEqual<long4, long>(divisor, 0, 4);

            if (constexpr.IS_CONST(divisor))
            {
                if (all_eq(divisor))
                {
                    return isdivisible(dividend, divisor.x);
                }
                else
                {
                    Divider<long4> Divider = new Divider<long4>(divisor);

                    if (constexpr.IS_CONST(Divider))
                    {
                        return Divider.EvenlyDivides(dividend);
                    }
                }
            }

            return dividend % divisor == 0;
        }

        /// <summary>       Returns <see langword="true"/> for each component if the respective <paramref name="dividend"/> is evenly divisible by the <paramref name="divisor"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(long4 dividend, long divisor)
        {
Assert.AreNotEqual(0L, divisor);

            if (constexpr.IS_CONST(divisor))
            {
                if (divisor == 1 || divisor == -1)
                {
                    return true;
                }
                if (divisor == 2 || divisor == -2)
                {
                    return (dividend & 1) == 0;
                }

                Divider<long> Divider = new Divider<long>(divisor);

                if (constexpr.IS_CONST(Divider))
                {
                    return Divider.EvenlyDivides(dividend);
                }
            }

            return dividend % divisor == 0;
        }
    }
}