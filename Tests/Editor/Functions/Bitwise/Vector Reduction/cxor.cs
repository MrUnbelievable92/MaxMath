using Unity.Mathematics;
using NUnit.Framework;

using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    internal class f_cxor
    {
        [Test]
        public void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte2 test = rng.NextByte2();
                byte actual = 0;

                for (int j = 0; j < 2; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte3 test = rng.NextByte3();
                byte actual = 0;

                for (int j = 0; j < 3; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte4 test = rng.NextByte4();
                byte actual = 0;

                for (int j = 0; j < 4; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte8 test = rng.NextByte8();
                byte actual = 0;

                for (int j = 0; j < 8; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte16 test = rng.NextByte16();
                byte actual = 0;

                for (int j = 0; j < 16; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 10; i++)
            {
                byte32 test = rng.NextByte32();
                byte actual = 0;

                for (int j = 0; j < 32; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }


        [Test]
        public void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort2 test = rng.NextUShort2();
                ushort actual = 0;

                for (int j = 0; j < 2; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort3 test = rng.NextUShort3();
                ushort actual = 0;

                for (int j = 0; j < 3; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort4 test = rng.NextUShort4();
                ushort actual = 0;

                for (int j = 0; j < 4; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort8 test = rng.NextUShort8();
                ushort actual = 0;

                for (int j = 0; j < 8; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 10; i++)
            {
                ushort16 test = rng.NextUShort16();
                ushort actual = 0;

                for (int j = 0; j < 16; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }


        [Test]
        public void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 10; i++)
            {
                uint2 test = rng.NextUInt2();
                uint actual = 0;

                for (int j = 0; j < 2; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 10; i++)
            {
                uint3 test = rng.NextUInt3();
                uint actual = 0;

                for (int j = 0; j < 3; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 10; i++)
            {
                uint4 test = rng.NextUInt4();
                uint actual = 0;

                for (int j = 0; j < 4; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 10; i++)
            {
                uint8 test = rng.NextUInt8();
                uint actual = 0;

                for (int j = 0; j < 8; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }


        [Test]
        public void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 10; i++)
            {
                ulong2 test = rng.NextULong2();
                ulong actual = 0;

                for (int j = 0; j < 2; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 10; i++)
            {
                ulong3 test = rng.NextULong3();
                ulong actual = 0;

                for (int j = 0; j < 3; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }

        [Test]
        public void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 10; i++)
            {
                ulong4 test = rng.NextULong4();
                ulong actual = 0;

                for (int j = 0; j < 4; j++)
                {
                    actual ^= test[j];
                }

                Assert.AreEqual(actual, cxor(test));
            }
        }
    }
}
