using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_divsaturated
    {
        [Test]
        public static void _sbyte2()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte2 left = rng.NextSByte2();
            sbyte2 right = rng.NextSByte2();

            for (int i = 0; i < 2; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 2; i += 2)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte2 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte3 left = rng.NextSByte3();
            sbyte3 right = rng.NextSByte3();

            for (int i = 0; i < 3; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte3 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte4 left = rng.NextSByte4();
            sbyte4 right = rng.NextSByte4();

            for (int i = 0; i < 4; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 4; i += 2)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte4 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte16 left = rng.NextSByte16();
            sbyte16 right = rng.NextSByte16();

            for (int i = 0; i < 16; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 16; i += 2)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte16 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte16 left = rng.NextSByte16();
            sbyte16 right = rng.NextSByte16();

            for (int i = 0; i < 16; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 16; i += 2)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte16 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            byte seed = (byte)System.Environment.TickCount;
            seed = seed == 0 ? (byte)1 : seed;
            Random8 rng = new Random8(seed);

            sbyte32 left = rng.NextSByte32();
            sbyte32 right = rng.NextSByte32();

            for (int i = 0; i < 32; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 32; i += 22)
            {
                left[i] = sbyte.MinValue;
                right[i] = -1;
            }

            sbyte32 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 32; i++)
            {
                if (i % 22 == 0)
                {
                    Assert.AreEqual(quotients[i], sbyte.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }


        [Test]
        public static void _short2()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            short2 left = rng.NextShort2();
            short2 right = rng.NextShort2();

            for (int i = 0; i < 2; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 2; i += 2)
            {
                left[i] = short.MinValue;
                right[i] = -1;
            }

            short2 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], short.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            short3 left = rng.NextShort3();
            short3 right = rng.NextShort3();

            for (int i = 0; i < 3; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                left[i] = short.MinValue;
                right[i] = -1;
            }

            short3 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], short.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            short4 left = rng.NextShort4();
            short4 right = rng.NextShort4();

            for (int i = 0; i < 4; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 4; i += 2)
            {
                left[i] = short.MinValue;
                right[i] = -1;
            }

            short4 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], short.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            short8 left = rng.NextShort8();
            short8 right = rng.NextShort8();

            for (int i = 0; i < 8; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 8; i += 2)
            {
                left[i] = short.MinValue;
                right[i] = -1;
            }

            short8 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], short.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _short16()
        {
            ushort seed = (ushort)System.Environment.TickCount;
            seed = seed == 0 ? (ushort)1 : seed;
            Random16 rng = new Random16(seed);

            short16 left = rng.NextShort16();
            short16 right = rng.NextShort16();

            for (int i = 0; i < 16; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 16; i += 2)
            {
                left[i] = short.MinValue;
                right[i] = -1;
            }

            short16 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 16; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], short.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }


        [Test]
        public static void _int2()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            int2 left = rng.NextInt2();
            int2 right = rng.NextInt2();

            for (int i = 0; i < 2; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 2; i += 2)
            {
                left[i] = int.MinValue;
                right[i] = -1;
            }

            int2 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], int.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _int3()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            int3 left = rng.NextInt3();
            int3 right = rng.NextInt3();

            for (int i = 0; i < 3; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                left[i] = int.MinValue;
                right[i] = -1;
            }

            int3 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], int.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _int4()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            int4 left = rng.NextInt4();
            int4 right = rng.NextInt4();

            for (int i = 0; i < 4; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 4; i += 2)
            {
                left[i] = int.MinValue;
                right[i] = -1;
            }

            int4 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], int.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _int8()
        {
            uint seed = (uint)System.Environment.TickCount;
            seed = seed == 0 ? (uint)1 : seed;
            Random32 rng = new Random32(seed);

            int8 left = rng.NextInt8();
            int8 right = rng.NextInt8();

            for (int i = 0; i < 8; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 8; i += 2)
            {
                left[i] = int.MinValue;
                right[i] = -1;
            }

            int8 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], int.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }


        [Test]
        public static void _long2()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            long2 left = rng.NextLong2();
            long2 right = rng.NextLong2();

            for (int i = 0; i < 2; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 2; i += 2)
            {
                left[i] = long.MinValue;
                right[i] = -1;
            }

            long2 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 2; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], long.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _long3()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            long3 left = rng.NextLong3();
            long3 right = rng.NextLong3();

            for (int i = 0; i < 3; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 3; i += 2)
            {
                left[i] = long.MinValue;
                right[i] = -1;
            }

            long3 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], long.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }

        [Test]
        public static void _long4()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random64 rng = new Random64(seed);

            long4 left = rng.NextLong4();
            long4 right = rng.NextLong4();

            for (int i = 0; i < 4; i++)
            {
                if (right[i] == 0)
                {
                    right[i] = 100;
                }
            }

            for (int i = 0; i < 4; i += 2)
            {
                left[i] = long.MinValue;
                right[i] = -1;
            }

            long4 quotients = maxmath.divsaturated(left, right);

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    Assert.AreEqual(quotients[i], long.MaxValue);
                }
                else
                {
                    Assert.AreEqual(quotients[i], left[i] / right[i]);
                }
            }
        }


        [Test]
        public static void _Int128()
        {
            ulong seed = (ulong)System.Environment.TickCount;
            seed = seed == 0 ? (ulong)1 : seed;
            Random128 rng = new Random128(seed);

            Int128 left = rng.NextInt128();
            Int128 right = rng.NextInt128();

            if (right == 0)
            {
                right = 100;
            }

            Int128 quotient = maxmath.divsaturated(left, right);
            Assert.AreEqual(quotient, left / right);

            left = Int128.MinValue;
            right = -1;
            quotient = maxmath.divsaturated(left, right);
            Assert.AreEqual(quotient, Int128.MaxValue);
        }
    }
}