using Unity.Mathematics;
using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_cprod
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2 test = rng.NextByte2();

                uint cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3 test = rng.NextByte3();

                uint cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4 test = rng.NextByte4();

                uint cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte8 test = rng.NextByte8();

                uint cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte16 test = rng.NextByte16();

                uint cmp = 1;
                for (int j = 0; j < 16; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte32 test = rng.NextByte32();

                uint cmp = 1;
                for (int j = 0; j < 32; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte2 test = rng.NextSByte2();

                int cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte3 test = rng.NextSByte3();

                int cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte4 test = rng.NextSByte4();

                int cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte8 test = rng.NextSByte8();

                int cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte16 test = rng.NextSByte16();

                int cmp = 1;
                for (int j = 0; j < 16; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                sbyte32 test = rng.NextSByte32();

                int cmp = 1;
                for (int j = 0; j < 32; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2 test = rng.NextUShort2();

                uint cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 test = rng.NextUShort3();

                uint cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4 test = rng.NextUShort4();

                uint cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort8 test = rng.NextUShort8();

                uint cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort16 test = rng.NextUShort16();

                uint cmp = 1;
                for (int j = 0; j < 16; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short2 test = rng.NextShort2();

                int cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short3 test = rng.NextShort3();

                int cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short4 test = rng.NextShort4();

                int cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short8 test = rng.NextShort8();

                int cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                short16 test = rng.NextShort16();

                int cmp = 1;
                for (int j = 0; j < 16; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2 test = rng.NextUInt2();

                uint cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3 test = rng.NextUInt3();

                uint cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4 test = rng.NextUInt4();

                uint cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint8 test = rng.NextUInt8();

                uint cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int2 test = rng.NextInt2();

                int cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int3 test = rng.NextInt3();

                int cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int4 test = rng.NextInt4();

                int cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                int8 test = rng.NextInt8();

                int cmp = 1;
                for (int j = 0; j < 8; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2 test = rng.NextULong2();

                ulong cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3 test = rng.NextULong3();

                ulong cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4 test = rng.NextULong4();

                ulong cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long2 test = rng.NextLong2();

                long cmp = 1;
                for (int j = 0; j < 2; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long3 test = rng.NextLong3();

                long cmp = 1;
                for (int j = 0; j < 3; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                long4 test = rng.NextLong4();

                long cmp = 1;
                for (int j = 0; j < 4; j++)
                {
                    cmp *= test[j];
                }

                Assert.AreEqual(cmp, maxmath.cprod(test));
            }
        }
    }
}