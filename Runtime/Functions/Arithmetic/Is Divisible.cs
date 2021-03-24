using DevTools;
using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(byte dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            return isdivisible((ushort)dividend, (ushort)divisor);
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(byte2 dividend, byte2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort2 compile = (new ushort2(ushort.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(byte2 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort2 compile = (new ushort2(ushort.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(byte3 dividend, byte3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort3 compile = (new ushort3(ushort.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(byte3 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort3 compile = (new ushort3(ushort.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(byte4 dividend, byte4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort4 compile = (new ushort4(ushort.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(byte4 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort4 compile = (new ushort4(ushort.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(byte8 dividend, byte8 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort8 compile = (new ushort8(ushort.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(byte8 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort8 compile = (new ushort8(ushort.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(byte16 dividend, byte16 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort16 compile = (new ushort16(ushort.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(byte16 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort16 compile = (new ushort16(ushort.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(byte32 dividend, byte32 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);
Assert.AreNotEqual(0, divisor.x16);
Assert.AreNotEqual(0, divisor.x17);
Assert.AreNotEqual(0, divisor.x18);
Assert.AreNotEqual(0, divisor.x19);
Assert.AreNotEqual(0, divisor.x20);
Assert.AreNotEqual(0, divisor.x21);
Assert.AreNotEqual(0, divisor.x22);
Assert.AreNotEqual(0, divisor.x23);
Assert.AreNotEqual(0, divisor.x24);
Assert.AreNotEqual(0, divisor.x25);
Assert.AreNotEqual(0, divisor.x26);
Assert.AreNotEqual(0, divisor.x27);
Assert.AreNotEqual(0, divisor.x28);
Assert.AreNotEqual(0, divisor.x29);
Assert.AreNotEqual(0, divisor.x30);
Assert.AreNotEqual(0, divisor.x31);

            if (Constant.IsConstantExpression(divisor))
            {
                ushort16 compile_lo = (new ushort16(ushort.MaxValue) / divisor.v16_0) + 1;
                ushort16 compile_hi = (new ushort16(ushort.MaxValue) / divisor.v16_16) + 1;

                return new bool32(dividend.v16_0  * compile_lo <= compile_lo - 1,
                                  dividend.v16_16 * compile_lo <= compile_lo - 1);
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(byte32 dividend, byte divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (byte)(divisor - 1)) == 0;
                }
                else
                {
                    ushort16 compile = (new ushort16(ushort.MaxValue) / divisor) + 1;

                    return new bool32(dividend.v16_0  * compile <= compile - 1,
                                      dividend.v16_16 * compile <= compile - 1);
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(ushort dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    uint compile = (uint.MaxValue / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ushort2 dividend, ushort2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            if (Constant.IsConstantExpression(divisor))
            {
                uint2 compile = (new uint2(uint.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ushort2 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }
                else
                {
                    uint2 compile = (new uint2(uint.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ushort3 dividend, ushort3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            if (Constant.IsConstantExpression(divisor))
            {
                uint3 compile = (new uint3(uint.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ushort3 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }
                else
                {
                    uint3 compile = (new uint3(uint.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ushort4 dividend, ushort4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            if (Constant.IsConstantExpression(divisor))
            {
                uint4 compile = (new uint4(uint.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ushort4 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }
                else
                {
                    uint4 compile = (new uint4(uint.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(ushort8 dividend, ushort8 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);

            if (Constant.IsConstantExpression(divisor))
            {
                uint8 compile = (new uint8(uint.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(ushort8 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }
                else
                {
                    uint8 compile = (new uint8(uint.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(ushort16 dividend, ushort16 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);

            if (Constant.IsConstantExpression(divisor))
            {
                uint8 compile_lo = (new uint8(uint.MaxValue) / divisor.v8_0) + 1;
                uint8 compile_hi = (new uint8(uint.MaxValue) / divisor.v8_8) + 1;

                return new bool16(dividend.v8_0 * compile_lo <= compile_lo - 1,
                                  dividend.v8_8 * compile_lo <= compile_lo - 1);
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(ushort16 dividend, ushort divisor)
        {
Assert.AreNotEqual(0, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2((uint)divisor))
                {
                    return (dividend & (ushort)(divisor - 1)) == 0;
                }
                else
                {
                    uint8 compile = (new uint8(uint.MaxValue) / divisor) + 1;

                    return new bool16(dividend.v8_0 * compile <= compile - 1,
                                      dividend.v8_8 * compile <= compile - 1);
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(uint dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    ulong compile = (ulong.MaxValue / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(uint2 dividend, uint2 divisor)
        {
Assert.AreNotEqual(0u, divisor.x);
Assert.AreNotEqual(0u, divisor.y);

            if (Constant.IsConstantExpression(divisor))
            {
                ulong2 compile = (new ulong2(ulong.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(uint2 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    ulong2 compile = (new ulong2(ulong.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(uint3 dividend, uint3 divisor)
        {
Assert.AreNotEqual(0u, divisor.x);
Assert.AreNotEqual(0u, divisor.y);
Assert.AreNotEqual(0u, divisor.z);

            if (Constant.IsConstantExpression(divisor))
            {
                ulong3 compile = (new ulong3(ulong.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(uint3 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    ulong3 compile = (new ulong3(ulong.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(uint4 dividend, uint4 divisor)
        {
Assert.AreNotEqual(0u, divisor.x);
Assert.AreNotEqual(0u, divisor.y);
Assert.AreNotEqual(0u, divisor.z);
Assert.AreNotEqual(0u, divisor.w);

            if (Constant.IsConstantExpression(divisor))
            {
                ulong4 compile = (new ulong4(ulong.MaxValue) / divisor) + 1;

                return dividend * compile <= compile - 1;
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(uint4 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    ulong4 compile = (new ulong4(ulong.MaxValue) / divisor) + 1;

                    return dividend * compile <= compile - 1;
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(uint8 dividend, uint8 divisor)
        {
Assert.AreNotEqual(0u, divisor.x0);
Assert.AreNotEqual(0u, divisor.x1);
Assert.AreNotEqual(0u, divisor.x2);
Assert.AreNotEqual(0u, divisor.x3);
Assert.AreNotEqual(0u, divisor.x4);
Assert.AreNotEqual(0u, divisor.x5);
Assert.AreNotEqual(0u, divisor.x6);
Assert.AreNotEqual(0u, divisor.x7);

            if (Constant.IsConstantExpression(divisor))
            {
                ulong4 compile_lo = (new ulong4(ulong.MaxValue) / divisor.v4_0) + 1;
                ulong4 compile_hi = (new ulong4(ulong.MaxValue) / divisor.v4_4) + 1;

                return new bool8(dividend.v4_0 * compile_lo <= compile_lo - 1,
                                 dividend.v4_4 * compile_lo <= compile_lo - 1);
            }
            else
            {
                return dividend % divisor == 0;
            }
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(uint8 dividend, uint divisor)
        {
Assert.AreNotEqual(0u, divisor);

            if (Constant.IsConstantExpression(divisor))
            {
                if (math.ispow2(divisor))
                {
                    return (dividend & (divisor - 1)) == 0;
                }
                else
                {
                    ulong4 compile = (new ulong4(ulong.MaxValue) / divisor) + 1;

                    return new bool8(dividend.v4_0 * compile <= compile - 1,
                                     dividend.v4_4 * compile <= compile - 1);
                }
            }
            else
            {
                return dividend % divisor == 0;
            }
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(ulong dividend, ulong divisor)
        {
Assert.AreNotEqual(0ul, divisor);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(ulong2 dividend, ulong2 divisor)
        {
Assert.AreNotEqual(0ul, divisor.x);
Assert.AreNotEqual(0ul, divisor.y);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(ulong3 dividend, ulong3 divisor)
        {
Assert.AreNotEqual(0ul, divisor.x);
Assert.AreNotEqual(0ul, divisor.y);
Assert.AreNotEqual(0ul, divisor.z);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(ulong4 dividend, ulong4 divisor)
        {
Assert.AreNotEqual(0ul, divisor.x);
Assert.AreNotEqual(0ul, divisor.y);
Assert.AreNotEqual(0ul, divisor.z);
Assert.AreNotEqual(0ul, divisor.w);

            return dividend % divisor == 0;
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(sbyte dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            return isdivisible((short)dividend, (short)divisor);
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(sbyte2 dividend, sbyte2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(sbyte3 dividend, sbyte3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(sbyte4 dividend, sbyte4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(sbyte8 dividend, sbyte8 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(sbyte16 dividend, sbyte16 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(sbyte32 dividend, sbyte32 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);
Assert.AreNotEqual(0, divisor.x16);
Assert.AreNotEqual(0, divisor.x17);
Assert.AreNotEqual(0, divisor.x18);
Assert.AreNotEqual(0, divisor.x19);
Assert.AreNotEqual(0, divisor.x20);
Assert.AreNotEqual(0, divisor.x21);
Assert.AreNotEqual(0, divisor.x22);
Assert.AreNotEqual(0, divisor.x23);
Assert.AreNotEqual(0, divisor.x24);
Assert.AreNotEqual(0, divisor.x25);
Assert.AreNotEqual(0, divisor.x26);
Assert.AreNotEqual(0, divisor.x27);
Assert.AreNotEqual(0, divisor.x28);
Assert.AreNotEqual(0, divisor.x29);
Assert.AreNotEqual(0, divisor.x30);
Assert.AreNotEqual(0, divisor.x31);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isdivisible(sbyte32 dividend, sbyte divisor)
        {
Assert.AreNotEqual(0, divisor);

            return dividend % divisor == 0;
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(short dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            return isdivisible((int)dividend, (int)divisor);
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(short2 dividend, short2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(short3 dividend, short3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(short4 dividend, short4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(short8 dividend, short8 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(short16 dividend, short16 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);
Assert.AreNotEqual(0, divisor.x8);
Assert.AreNotEqual(0, divisor.x9);
Assert.AreNotEqual(0, divisor.x10);
Assert.AreNotEqual(0, divisor.x11);
Assert.AreNotEqual(0, divisor.x12);
Assert.AreNotEqual(0, divisor.x13);
Assert.AreNotEqual(0, divisor.x14);
Assert.AreNotEqual(0, divisor.x15);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isdivisible(short16 dividend, short divisor)
        {
Assert.AreNotEqual(0, divisor);

            return dividend % divisor == 0;
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(int dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(int2 dividend, int2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(int3 dividend, int3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(int4 dividend, int4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(int8 dividend, int8 divisor)
        {
Assert.AreNotEqual(0, divisor.x0);
Assert.AreNotEqual(0, divisor.x1);
Assert.AreNotEqual(0, divisor.x2);
Assert.AreNotEqual(0, divisor.x3);
Assert.AreNotEqual(0, divisor.x4);
Assert.AreNotEqual(0, divisor.x5);
Assert.AreNotEqual(0, divisor.x6);
Assert.AreNotEqual(0, divisor.x7);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isdivisible(int8 dividend, int divisor)
        {
Assert.AreNotEqual(0, divisor);

            return dividend % divisor == 0;
        }


        /// <summary>       Returns true if the dividend is evenly divisible by the divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isdivisible(long dividend, long divisor)
        {
Assert.AreNotEqual(0, divisor);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isdivisible(long2 dividend, long2 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isdivisible(long3 dividend, long3 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);

            return dividend % divisor == 0;
        }

        /// <summary>       Returns true for each component if the respective dividend is evenly divisible by the corresponding divisor.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isdivisible(long4 dividend, long4 divisor)
        {
Assert.AreNotEqual(0, divisor.x);
Assert.AreNotEqual(0, divisor.y);
Assert.AreNotEqual(0, divisor.z);
Assert.AreNotEqual(0, divisor.w);

            return dividend % divisor == 0;
        }
    }
}