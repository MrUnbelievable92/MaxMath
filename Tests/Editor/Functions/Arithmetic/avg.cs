using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class avg
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < Tests.__byte2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte2.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__byte2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void byte3()
        {
            for (int i = 0; i < Tests.__byte3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte3.TestData_LHS[i]),
                                (2 + maxmath.csum(Tests.__byte3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void byte4()
        {
            for (int i = 0; i < Tests.__byte4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte4.TestData_LHS[i]),
                                (3u + maxmath.csum(Tests.__byte4.TestData_LHS[i])) / 4u);
            }
        }

        [Test]
        public static void byte8()
        {
            for (int i = 0; i < Tests.__byte8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte8.TestData_LHS[i]),
                                (7 + maxmath.csum(Tests.__byte8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0; i < Tests.__byte16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte16.TestData_LHS[i]),
                                (15 + maxmath.csum(Tests.__byte16.TestData_LHS[i])) / 16);
            }
        }

        [Test]
        public static void byte32()
        {
            for (int i = 0; i < Tests.__byte32.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__byte32.TestData_LHS[i]),
                                (31 + maxmath.csum(Tests.__byte32.TestData_LHS[i])) / 32);
            }
        }


        [Test]
        public static void ushort2()
        {
            for (int i = 0; i < Tests.__ushort2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ushort2.TestData_LHS[i]),
                                (1 + maxmath.csum(Tests.__ushort2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void ushort3()
        {
            for (int i = 0; i < Tests.__ushort3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ushort3.TestData_LHS[i]),
                                (2 + maxmath.csum(Tests.__ushort3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void ushort4()
        {
            for (int i = 0; i < Tests.__ushort4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ushort4.TestData_LHS[i]),
                                (3 + maxmath.csum(Tests.__ushort4.TestData_LHS[i])) / 4);
            }
        }

        [Test]
        public static void ushort8()
        {
            for (int i = 0; i < Tests.__ushort8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ushort8.TestData_LHS[i]),
                                (7 + maxmath.csum(Tests.__ushort8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void ushort16()
        {
            for (int i = 0; i < Tests.__ushort16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ushort16.TestData_LHS[i]),
                                (15 + maxmath.csum(Tests.__ushort16.TestData_LHS[i])) / 16);
            }
        }


        [Test]
        public static void uint2()
        {
            for (int i = 0; i < Tests.__uint2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__uint2.TestData_LHS[i]),
                                (1 + maxmath.csum((ulong2)Tests.__uint2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void uint3()
        {
            for (int i = 0; i < Tests.__uint3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__uint3.TestData_LHS[i]),
                                (2 + maxmath.csum((ulong3)Tests.__uint3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void uint4()
        {
            for (int i = 0; i < Tests.__uint4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__uint4.TestData_LHS[i]),
                                (3 + maxmath.csum((ulong4)Tests.__uint4.TestData_LHS[i])) / 4);
            }
        }

        [Test]
        public static void uint8()
        {
            for (int i = 0; i < Tests.__uint8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__uint8.TestData_LHS[i]),
                                (7 + maxmath.csum((ulong4)Tests.__uint8.TestData_LHS[i].v4_0 + (ulong4)Tests.__uint8.TestData_LHS[i].v4_4)) / 8);
            }
        }


        [Test]
        public static void ulong2()
        {
            for (int i = 0; i < Tests.__ulong2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ulong2.TestData_LHS[i]),
                                (1 + (UInt128)Tests.__ulong2.TestData_LHS[i].x + Tests.__ulong2.TestData_LHS[i].y) / 2);
            }
        }

        [Test]
        public static void ulong3()
        {
            for (int i = 0; i < Tests.__ulong3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ulong3.TestData_LHS[i]),
                                (2 + (UInt128)Tests.__ulong3.TestData_LHS[i].x + Tests.__ulong3.TestData_LHS[i].y + Tests.__ulong3.TestData_LHS[i].z) / 3);
            }
        }

        [Test]
        public static void ulong4()
        {
            for (int i = 0; i < Tests.__ulong4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__ulong4.TestData_LHS[i]),
                                (3 + (UInt128)Tests.__ulong4.TestData_LHS[i].x + Tests.__ulong4.TestData_LHS[i].y + Tests.__ulong4.TestData_LHS[i].z + Tests.__ulong4.TestData_LHS[i].w) / 4);
            }
        }


        [Test]
        public static void byte2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte2.NUM_TESTS; i++)
            {
                byte2 x = maxmath.avg(Tests.__byte2.TestData_LHS[i], Tests.__byte2.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__byte2.TestData_LHS[i].x + Tests.__byte2.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__byte2.TestData_LHS[i].y + Tests.__byte2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte3.NUM_TESTS; i++)
            {
                byte3 x = maxmath.avg(Tests.__byte3.TestData_LHS[i], Tests.__byte3.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__byte3.TestData_LHS[i].x + Tests.__byte3.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__byte3.TestData_LHS[i].y + Tests.__byte3.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + Tests.__byte3.TestData_LHS[i].z + Tests.__byte3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte4.NUM_TESTS; i++)
            {
                byte4 x = maxmath.avg(Tests.__byte4.TestData_LHS[i], Tests.__byte4.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__byte4.TestData_LHS[i].x + Tests.__byte4.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__byte4.TestData_LHS[i].y + Tests.__byte4.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + Tests.__byte4.TestData_LHS[i].z + Tests.__byte4.TestData_RHS[i].z) / 2;
                result &= x.w == (1 + Tests.__byte4.TestData_LHS[i].w + Tests.__byte4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte8.NUM_TESTS; i++)
            {
                byte8 x = maxmath.avg(Tests.__byte8.TestData_LHS[i], Tests.__byte8.TestData_RHS[i]);

                result &= x.x0 == (1 + Tests.__byte8.TestData_LHS[i].x0 + Tests.__byte8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (1 + Tests.__byte8.TestData_LHS[i].x1 + Tests.__byte8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (1 + Tests.__byte8.TestData_LHS[i].x2 + Tests.__byte8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (1 + Tests.__byte8.TestData_LHS[i].x3 + Tests.__byte8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (1 + Tests.__byte8.TestData_LHS[i].x4 + Tests.__byte8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (1 + Tests.__byte8.TestData_LHS[i].x5 + Tests.__byte8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (1 + Tests.__byte8.TestData_LHS[i].x6 + Tests.__byte8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (1 + Tests.__byte8.TestData_LHS[i].x7 + Tests.__byte8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte16.NUM_TESTS; i++)
            {
                byte16 x = maxmath.avg(Tests.__byte16.TestData_LHS[i], Tests.__byte16.TestData_RHS[i]);

                result &= x.x0  == (1 + Tests.__byte16.TestData_LHS[i].x0  + Tests.__byte16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (1 + Tests.__byte16.TestData_LHS[i].x1  + Tests.__byte16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (1 + Tests.__byte16.TestData_LHS[i].x2  + Tests.__byte16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (1 + Tests.__byte16.TestData_LHS[i].x3  + Tests.__byte16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (1 + Tests.__byte16.TestData_LHS[i].x4  + Tests.__byte16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (1 + Tests.__byte16.TestData_LHS[i].x5  + Tests.__byte16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (1 + Tests.__byte16.TestData_LHS[i].x6  + Tests.__byte16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (1 + Tests.__byte16.TestData_LHS[i].x7  + Tests.__byte16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (1 + Tests.__byte16.TestData_LHS[i].x8  + Tests.__byte16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (1 + Tests.__byte16.TestData_LHS[i].x9  + Tests.__byte16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (1 + Tests.__byte16.TestData_LHS[i].x10 + Tests.__byte16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (1 + Tests.__byte16.TestData_LHS[i].x11 + Tests.__byte16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (1 + Tests.__byte16.TestData_LHS[i].x12 + Tests.__byte16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (1 + Tests.__byte16.TestData_LHS[i].x13 + Tests.__byte16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (1 + Tests.__byte16.TestData_LHS[i].x14 + Tests.__byte16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (1 + Tests.__byte16.TestData_LHS[i].x15 + Tests.__byte16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void byte32x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__byte32.NUM_TESTS; i++)
            {
                byte32 x = maxmath.avg(Tests.__byte32.TestData_LHS[i], Tests.__byte32.TestData_RHS[i]);

                result &= x.x0  == (1 + Tests.__byte32.TestData_LHS[i].x0  + Tests.__byte32.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (1 + Tests.__byte32.TestData_LHS[i].x1  + Tests.__byte32.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (1 + Tests.__byte32.TestData_LHS[i].x2  + Tests.__byte32.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (1 + Tests.__byte32.TestData_LHS[i].x3  + Tests.__byte32.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (1 + Tests.__byte32.TestData_LHS[i].x4  + Tests.__byte32.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (1 + Tests.__byte32.TestData_LHS[i].x5  + Tests.__byte32.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (1 + Tests.__byte32.TestData_LHS[i].x6  + Tests.__byte32.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (1 + Tests.__byte32.TestData_LHS[i].x7  + Tests.__byte32.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (1 + Tests.__byte32.TestData_LHS[i].x8  + Tests.__byte32.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (1 + Tests.__byte32.TestData_LHS[i].x9  + Tests.__byte32.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (1 + Tests.__byte32.TestData_LHS[i].x10 + Tests.__byte32.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (1 + Tests.__byte32.TestData_LHS[i].x11 + Tests.__byte32.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (1 + Tests.__byte32.TestData_LHS[i].x12 + Tests.__byte32.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (1 + Tests.__byte32.TestData_LHS[i].x13 + Tests.__byte32.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (1 + Tests.__byte32.TestData_LHS[i].x14 + Tests.__byte32.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (1 + Tests.__byte32.TestData_LHS[i].x15 + Tests.__byte32.TestData_RHS[i].x15) / 2;
                result &= x.x16 == (1 + Tests.__byte32.TestData_LHS[i].x16 + Tests.__byte32.TestData_RHS[i].x16) / 2;
                result &= x.x17 == (1 + Tests.__byte32.TestData_LHS[i].x17 + Tests.__byte32.TestData_RHS[i].x17) / 2;
                result &= x.x18 == (1 + Tests.__byte32.TestData_LHS[i].x18 + Tests.__byte32.TestData_RHS[i].x18) / 2;
                result &= x.x19 == (1 + Tests.__byte32.TestData_LHS[i].x19 + Tests.__byte32.TestData_RHS[i].x19) / 2;
                result &= x.x20 == (1 + Tests.__byte32.TestData_LHS[i].x20 + Tests.__byte32.TestData_RHS[i].x20) / 2;
                result &= x.x21 == (1 + Tests.__byte32.TestData_LHS[i].x21 + Tests.__byte32.TestData_RHS[i].x21) / 2;
                result &= x.x22 == (1 + Tests.__byte32.TestData_LHS[i].x22 + Tests.__byte32.TestData_RHS[i].x22) / 2;
                result &= x.x23 == (1 + Tests.__byte32.TestData_LHS[i].x23 + Tests.__byte32.TestData_RHS[i].x23) / 2;
                result &= x.x24 == (1 + Tests.__byte32.TestData_LHS[i].x24 + Tests.__byte32.TestData_RHS[i].x24) / 2;
                result &= x.x25 == (1 + Tests.__byte32.TestData_LHS[i].x25 + Tests.__byte32.TestData_RHS[i].x25) / 2;
                result &= x.x26 == (1 + Tests.__byte32.TestData_LHS[i].x26 + Tests.__byte32.TestData_RHS[i].x26) / 2;
                result &= x.x27 == (1 + Tests.__byte32.TestData_LHS[i].x27 + Tests.__byte32.TestData_RHS[i].x27) / 2;
                result &= x.x28 == (1 + Tests.__byte32.TestData_LHS[i].x28 + Tests.__byte32.TestData_RHS[i].x28) / 2;
                result &= x.x29 == (1 + Tests.__byte32.TestData_LHS[i].x29 + Tests.__byte32.TestData_RHS[i].x29) / 2;
                result &= x.x30 == (1 + Tests.__byte32.TestData_LHS[i].x30 + Tests.__byte32.TestData_RHS[i].x30) / 2;
                result &= x.x31 == (1 + Tests.__byte32.TestData_LHS[i].x31 + Tests.__byte32.TestData_RHS[i].x31) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort2.NUM_TESTS; i++)
            {
                ushort2 x = maxmath.avg(Tests.__ushort2.TestData_LHS[i], Tests.__ushort2.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__ushort2.TestData_LHS[i].x + Tests.__ushort2.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__ushort2.TestData_LHS[i].y + Tests.__ushort2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ushort3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort3.NUM_TESTS; i++)
            {
                ushort3 x = maxmath.avg(Tests.__ushort3.TestData_LHS[i], Tests.__ushort3.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__ushort3.TestData_LHS[i].x + Tests.__ushort3.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__ushort3.TestData_LHS[i].y + Tests.__ushort3.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + Tests.__ushort3.TestData_LHS[i].z + Tests.__ushort3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ushort4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort4.NUM_TESTS; i++)
            {
                ushort4 x = maxmath.avg(Tests.__ushort4.TestData_LHS[i], Tests.__ushort4.TestData_RHS[i]);

                result &= x.x == (1 + Tests.__ushort4.TestData_LHS[i].x + Tests.__ushort4.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + Tests.__ushort4.TestData_LHS[i].y + Tests.__ushort4.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + Tests.__ushort4.TestData_LHS[i].z + Tests.__ushort4.TestData_RHS[i].z) / 2;
                result &= x.w == (1 + Tests.__ushort4.TestData_LHS[i].w + Tests.__ushort4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ushort8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort8.NUM_TESTS; i++)
            {
                ushort8 x = maxmath.avg(Tests.__ushort8.TestData_LHS[i], Tests.__ushort8.TestData_RHS[i]);

                result &= x.x0 == (1 + Tests.__ushort8.TestData_LHS[i].x0 + Tests.__ushort8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (1 + Tests.__ushort8.TestData_LHS[i].x1 + Tests.__ushort8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (1 + Tests.__ushort8.TestData_LHS[i].x2 + Tests.__ushort8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (1 + Tests.__ushort8.TestData_LHS[i].x3 + Tests.__ushort8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (1 + Tests.__ushort8.TestData_LHS[i].x4 + Tests.__ushort8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (1 + Tests.__ushort8.TestData_LHS[i].x5 + Tests.__ushort8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (1 + Tests.__ushort8.TestData_LHS[i].x6 + Tests.__ushort8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (1 + Tests.__ushort8.TestData_LHS[i].x7 + Tests.__ushort8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ushort16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ushort16.NUM_TESTS; i++)
            {
                ushort16 x = maxmath.avg(Tests.__ushort16.TestData_LHS[i], Tests.__ushort16.TestData_RHS[i]);

                result &= x.x0  == (1 + Tests.__ushort16.TestData_LHS[i].x0  + Tests.__ushort16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (1 + Tests.__ushort16.TestData_LHS[i].x1  + Tests.__ushort16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (1 + Tests.__ushort16.TestData_LHS[i].x2  + Tests.__ushort16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (1 + Tests.__ushort16.TestData_LHS[i].x3  + Tests.__ushort16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (1 + Tests.__ushort16.TestData_LHS[i].x4  + Tests.__ushort16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (1 + Tests.__ushort16.TestData_LHS[i].x5  + Tests.__ushort16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (1 + Tests.__ushort16.TestData_LHS[i].x6  + Tests.__ushort16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (1 + Tests.__ushort16.TestData_LHS[i].x7  + Tests.__ushort16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (1 + Tests.__ushort16.TestData_LHS[i].x8  + Tests.__ushort16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (1 + Tests.__ushort16.TestData_LHS[i].x9  + Tests.__ushort16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (1 + Tests.__ushort16.TestData_LHS[i].x10 + Tests.__ushort16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (1 + Tests.__ushort16.TestData_LHS[i].x11 + Tests.__ushort16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (1 + Tests.__ushort16.TestData_LHS[i].x12 + Tests.__ushort16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (1 + Tests.__ushort16.TestData_LHS[i].x13 + Tests.__ushort16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (1 + Tests.__ushort16.TestData_LHS[i].x14 + Tests.__ushort16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (1 + Tests.__ushort16.TestData_LHS[i].x15 + Tests.__ushort16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }

        
        [Test]
        public static void uint2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint2.NUM_TESTS; i++)
            {
                uint2 x = maxmath.avg(Tests.__uint2.TestData_LHS[i], Tests.__uint2.TestData_RHS[i]);

                result &= x.x == (1 + (ulong)Tests.__uint2.TestData_LHS[i].x + (ulong)Tests.__uint2.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (ulong)Tests.__uint2.TestData_LHS[i].y + (ulong)Tests.__uint2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void uint3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint3.NUM_TESTS; i++)
            {
                uint3 x = maxmath.avg(Tests.__uint3.TestData_LHS[i], Tests.__uint3.TestData_RHS[i]);

                result &= x.x == (1 + (ulong)Tests.__uint3.TestData_LHS[i].x + (ulong)Tests.__uint3.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (ulong)Tests.__uint3.TestData_LHS[i].y + (ulong)Tests.__uint3.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + (ulong)Tests.__uint3.TestData_LHS[i].z + (ulong)Tests.__uint3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void uint4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint4.NUM_TESTS; i++)
            {
                uint4 x = maxmath.avg(Tests.__uint4.TestData_LHS[i], Tests.__uint4.TestData_RHS[i]);

                result &= x.x == (1 + (ulong)Tests.__uint4.TestData_LHS[i].x + (ulong)Tests.__uint4.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (ulong)Tests.__uint4.TestData_LHS[i].y + (ulong)Tests.__uint4.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + (ulong)Tests.__uint4.TestData_LHS[i].z + (ulong)Tests.__uint4.TestData_RHS[i].z) / 2;
                result &= x.w == (1 + (ulong)Tests.__uint4.TestData_LHS[i].w + (ulong)Tests.__uint4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void uint8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__uint8.NUM_TESTS; i++)
            {
                uint8 x = maxmath.avg(Tests.__uint8.TestData_LHS[i], Tests.__uint8.TestData_RHS[i]);

                result &= x.x0 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x0 + (ulong)Tests.__uint8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x1 + (ulong)Tests.__uint8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x2 + (ulong)Tests.__uint8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x3 + (ulong)Tests.__uint8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x4 + (ulong)Tests.__uint8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x5 + (ulong)Tests.__uint8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x6 + (ulong)Tests.__uint8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (1 + (ulong)Tests.__uint8.TestData_LHS[i].x7 + (ulong)Tests.__uint8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ulong2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong2.NUM_TESTS; i++)
            {
                ulong2 x = maxmath.avg(Tests.__ulong2.TestData_LHS[i], Tests.__ulong2.TestData_RHS[i]);

                result &= x.x == (1 + (UInt128)Tests.__ulong2.TestData_LHS[i].x + (UInt128)Tests.__ulong2.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (UInt128)Tests.__ulong2.TestData_LHS[i].y + (UInt128)Tests.__ulong2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ulong3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong3.NUM_TESTS; i++)
            {
                ulong3 x = maxmath.avg(Tests.__ulong3.TestData_LHS[i], Tests.__ulong3.TestData_RHS[i]);

                result &= x.x == (1 + (UInt128)Tests.__ulong3.TestData_LHS[i].x + (UInt128)Tests.__ulong3.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (UInt128)Tests.__ulong3.TestData_LHS[i].y + (UInt128)Tests.__ulong3.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + (UInt128)Tests.__ulong3.TestData_LHS[i].z + (UInt128)Tests.__ulong3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ulong4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__ulong4.NUM_TESTS; i++)
            {
                ulong4 x = maxmath.avg(Tests.__ulong4.TestData_LHS[i], Tests.__ulong4.TestData_RHS[i]);

                result &= x.x == (1 + (UInt128)Tests.__ulong4.TestData_LHS[i].x + (UInt128)Tests.__ulong4.TestData_RHS[i].x) / 2;
                result &= x.y == (1 + (UInt128)Tests.__ulong4.TestData_LHS[i].y + (UInt128)Tests.__ulong4.TestData_RHS[i].y) / 2;
                result &= x.z == (1 + (UInt128)Tests.__ulong4.TestData_LHS[i].z + (UInt128)Tests.__ulong4.TestData_RHS[i].z) / 2;
                result &= x.w == (1 + (UInt128)Tests.__ulong4.TestData_LHS[i].w + (UInt128)Tests.__ulong4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void sbyte2()
        {
            for (int i = 0; i < Tests.__sbyte2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte2.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte2.TestData_LHS[i]) > 0 ? 1 : -1) + maxmath.csum(Tests.__sbyte2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void sbyte3()
        {
            for (int i = 0; i < Tests.__sbyte3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte3.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte3.TestData_LHS[i]) > 0 ? 2 : -2) + maxmath.csum(Tests.__sbyte3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void sbyte4()
        {
            for (int i = 0; i < Tests.__sbyte4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte4.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte4.TestData_LHS[i]) > 0 ? 3 : -3) + maxmath.csum(Tests.__sbyte4.TestData_LHS[i])) / 4);
            }
        }

        [Test]
        public static void sbyte8()
        {
            for (int i = 0; i < Tests.__sbyte8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte8.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte8.TestData_LHS[i]) > 0 ? 7 : -7) + maxmath.csum(Tests.__sbyte8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void sbyte16()
        {
            for (int i = 0; i < Tests.__sbyte16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte16.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte16.TestData_LHS[i]) > 0 ? 15 : -15) + maxmath.csum(Tests.__sbyte16.TestData_LHS[i])) / 16);
            }
        }

        [Test]
        public static void sbyte32()
        {
            for (int i = 0; i < Tests.__sbyte32.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__sbyte32.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__sbyte32.TestData_LHS[i]) > 0 ? 31 : -31) + maxmath.csum(Tests.__sbyte32.TestData_LHS[i])) / 32);
            }
        }


        [Test]
        public static void short2()
        {
            for (int i = 0; i < Tests.__short2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__short2.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__short2.TestData_LHS[i]) > 0 ? 1 : -1) + maxmath.csum(Tests.__short2.TestData_LHS[i])) / 2);
            }
        }

        [Test]
        public static void short3()
        {
            for (int i = 0; i < Tests.__short3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__short3.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__short3.TestData_LHS[i]) > 0 ? 2 : -2) + maxmath.csum(Tests.__short3.TestData_LHS[i])) / 3);
            }
        }

        [Test]
        public static void short4()
        {
            for (int i = 0; i < Tests.__short4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__short4.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__short4.TestData_LHS[i]) > 0 ? 3 : -3) + maxmath.csum(Tests.__short4.TestData_LHS[i])) / 4);
            }
        }

        [Test]
        public static void short8()
        {
            for (int i = 0; i < Tests.__short8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__short8.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__short8.TestData_LHS[i]) > 0 ? 7 : -7) + maxmath.csum(Tests.__short8.TestData_LHS[i])) / 8);
            }
        }

        [Test]
        public static void short16()
        {
            for (int i = 0; i < Tests.__short16.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__short16.TestData_LHS[i]),
                                ((maxmath.csum(Tests.__short16.TestData_LHS[i]) > 0 ? 15 : -15) + maxmath.csum(Tests.__short16.TestData_LHS[i])) / 16);
            }
        }


        [Test]
        public static void int2()
        {
            for (int i = 0; i < Tests.__int2.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__int2.TestData_LHS[i]),
                                (int)(((maxmath.csum((long2)Tests.__int2.TestData_LHS[i]) > 0 ? 1 : -1) + maxmath.csum((long2)Tests.__int2.TestData_LHS[i])) / 2));
            }
        }

        [Test]
        public static void int3()
        {
            for (int i = 0; i < Tests.__int3.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__int3.TestData_LHS[i]),
                                (int)(((maxmath.csum((long3)Tests.__int3.TestData_LHS[i]) > 0 ? 2 : -2) + maxmath.csum((long3)Tests.__int3.TestData_LHS[i])) / 3));
            }
        }

        [Test]
        public static void int4()
        {
            for (int i = 0; i < Tests.__int4.TestData_LHS.Length; i++)
            {
                Assert.AreEqual((int)maxmath.cavg(Tests.__int4.TestData_LHS[i]),
                                (int)(((maxmath.csum((long4)Tests.__int4.TestData_LHS[i]) > 0 ? 3 : -3) + maxmath.csum((long4)Tests.__int4.TestData_LHS[i])) / 4));
            }
        }

        [Test]
        public static void int8()
        {
            for (int i = 0; i < Tests.__int8.TestData_LHS.Length; i++)
            {
                Assert.AreEqual(maxmath.cavg(Tests.__int8.TestData_LHS[i]),
                                ((maxmath.csum((long4)Tests.__int8.TestData_LHS[i].v4_0 + (long4)Tests.__int8.TestData_LHS[i].v4_4) > 0 ? 7 : -7) + maxmath.csum((long4)Tests.__int8.TestData_LHS[i].v4_0 + (long4)Tests.__int8.TestData_LHS[i].v4_4)) / 8);
            }
        }


        [Test]
        public static void long2()
        {
            for (int i = 0; i < Tests.__long2.TestData_LHS.Length; i++)
            {
                Int128 csum = Tests.__long2.TestData_LHS[i].x;
                csum += Tests.__long2.TestData_LHS[i].y;

                Assert.AreEqual(maxmath.cavg(Tests.__long2.TestData_LHS[i]),
                                ((csum > 0 ? 1 : -1) + csum) / 2);
            }
        }

        [Test]
        public static void long3()
        {
            for (int i = 0; i < Tests.__long3.TestData_LHS.Length; i++)
            {
                Int128 csum = Tests.__long3.TestData_LHS[i].x;
                csum += Tests.__long3.TestData_LHS[i].y;
                csum += Tests.__long3.TestData_LHS[i].z;

                Assert.AreEqual(maxmath.cavg(Tests.__long3.TestData_LHS[i]),
                                ((csum > 0 ? 2 : -2) + csum) / 3);
            }
        }

        [Test]
        public static void long4()
        {
            for (int i = 0; i < Tests.__long4.TestData_LHS.Length; i++)
            {
                Int128 csum = Tests.__long4.TestData_LHS[i].x;
                csum += Tests.__long4.TestData_LHS[i].y;
                csum += Tests.__long4.TestData_LHS[i].z;
                csum += Tests.__long4.TestData_LHS[i].w;

                Assert.AreEqual(maxmath.cavg(Tests.__long4.TestData_LHS[i]),
                                ((csum > 0 ? 3 : -3) + csum) / 4);
            }
        }


        [Test]
        public static void sbyte2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte2.NUM_TESTS; i++)
            {
                sbyte2 x = maxmath.avg(Tests.__sbyte2.TestData_LHS[i], Tests.__sbyte2.TestData_RHS[i]);

                result &= x.x  == (((Tests.__sbyte2.TestData_LHS[i].x  + Tests.__sbyte2.TestData_RHS[i].x)  > 0 ? 1 : -1) + Tests.__sbyte2.TestData_LHS[i].x  + Tests.__sbyte2.TestData_RHS[i].x)  / 2;
                result &= x.y  == (((Tests.__sbyte2.TestData_LHS[i].y  + Tests.__sbyte2.TestData_RHS[i].y)  > 0 ? 1 : -1) + Tests.__sbyte2.TestData_LHS[i].y  + Tests.__sbyte2.TestData_RHS[i].y)  / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte3.NUM_TESTS; i++)
            {
                sbyte3 x = maxmath.avg(Tests.__sbyte3.TestData_LHS[i], Tests.__sbyte3.TestData_RHS[i]);

                result &= x.x  == (((Tests.__sbyte3.TestData_LHS[i].x  + Tests.__sbyte3.TestData_RHS[i].x)  > 0 ? 1 : -1) + Tests.__sbyte3.TestData_LHS[i].x  + Tests.__sbyte3.TestData_RHS[i].x)  / 2;
                result &= x.y  == (((Tests.__sbyte3.TestData_LHS[i].y  + Tests.__sbyte3.TestData_RHS[i].y)  > 0 ? 1 : -1) + Tests.__sbyte3.TestData_LHS[i].y  + Tests.__sbyte3.TestData_RHS[i].y)  / 2;
                result &= x.z  == (((Tests.__sbyte3.TestData_LHS[i].z  + Tests.__sbyte3.TestData_RHS[i].z)  > 0 ? 1 : -1) + Tests.__sbyte3.TestData_LHS[i].z  + Tests.__sbyte3.TestData_RHS[i].z)  / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte4.NUM_TESTS; i++)
            {
                sbyte4 x = maxmath.avg(Tests.__sbyte4.TestData_LHS[i], Tests.__sbyte4.TestData_RHS[i]);

                result &= x.x  == (((Tests.__sbyte4.TestData_LHS[i].x  + Tests.__sbyte4.TestData_RHS[i].x)  > 0 ? 1 : -1) + Tests.__sbyte4.TestData_LHS[i].x  + Tests.__sbyte4.TestData_RHS[i].x)  / 2;
                result &= x.y  == (((Tests.__sbyte4.TestData_LHS[i].y  + Tests.__sbyte4.TestData_RHS[i].y)  > 0 ? 1 : -1) + Tests.__sbyte4.TestData_LHS[i].y  + Tests.__sbyte4.TestData_RHS[i].y)  / 2;
                result &= x.z  == (((Tests.__sbyte4.TestData_LHS[i].z  + Tests.__sbyte4.TestData_RHS[i].z)  > 0 ? 1 : -1) + Tests.__sbyte4.TestData_LHS[i].z  + Tests.__sbyte4.TestData_RHS[i].z)  / 2;
                result &= x.w  == (((Tests.__sbyte4.TestData_LHS[i].w  + Tests.__sbyte4.TestData_RHS[i].w)  > 0 ? 1 : -1) + Tests.__sbyte4.TestData_LHS[i].w  + Tests.__sbyte4.TestData_RHS[i].w)  / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte8.NUM_TESTS; i++)
            {
                sbyte8 x = maxmath.avg(Tests.__sbyte8.TestData_LHS[i], Tests.__sbyte8.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__sbyte8.TestData_LHS[i].x0  + Tests.__sbyte8.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x0  + Tests.__sbyte8.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__sbyte8.TestData_LHS[i].x1  + Tests.__sbyte8.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x1  + Tests.__sbyte8.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__sbyte8.TestData_LHS[i].x2  + Tests.__sbyte8.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x2  + Tests.__sbyte8.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__sbyte8.TestData_LHS[i].x3  + Tests.__sbyte8.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x3  + Tests.__sbyte8.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__sbyte8.TestData_LHS[i].x4  + Tests.__sbyte8.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x4  + Tests.__sbyte8.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__sbyte8.TestData_LHS[i].x5  + Tests.__sbyte8.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x5  + Tests.__sbyte8.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__sbyte8.TestData_LHS[i].x6  + Tests.__sbyte8.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x6  + Tests.__sbyte8.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__sbyte8.TestData_LHS[i].x7  + Tests.__sbyte8.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__sbyte8.TestData_LHS[i].x7  + Tests.__sbyte8.TestData_RHS[i].x7)  / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte16.NUM_TESTS; i++)
            {
                sbyte16 x = maxmath.avg(Tests.__sbyte16.TestData_LHS[i], Tests.__sbyte16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__sbyte16.TestData_LHS[i].x0  + Tests.__sbyte16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x0  + Tests.__sbyte16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__sbyte16.TestData_LHS[i].x1  + Tests.__sbyte16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x1  + Tests.__sbyte16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__sbyte16.TestData_LHS[i].x2  + Tests.__sbyte16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x2  + Tests.__sbyte16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__sbyte16.TestData_LHS[i].x3  + Tests.__sbyte16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x3  + Tests.__sbyte16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__sbyte16.TestData_LHS[i].x4  + Tests.__sbyte16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x4  + Tests.__sbyte16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__sbyte16.TestData_LHS[i].x5  + Tests.__sbyte16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x5  + Tests.__sbyte16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__sbyte16.TestData_LHS[i].x6  + Tests.__sbyte16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x6  + Tests.__sbyte16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__sbyte16.TestData_LHS[i].x7  + Tests.__sbyte16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x7  + Tests.__sbyte16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__sbyte16.TestData_LHS[i].x8  + Tests.__sbyte16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x8  + Tests.__sbyte16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__sbyte16.TestData_LHS[i].x9  + Tests.__sbyte16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x9  + Tests.__sbyte16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__sbyte16.TestData_LHS[i].x10 + Tests.__sbyte16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x10 + Tests.__sbyte16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__sbyte16.TestData_LHS[i].x11 + Tests.__sbyte16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x11 + Tests.__sbyte16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__sbyte16.TestData_LHS[i].x12 + Tests.__sbyte16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x12 + Tests.__sbyte16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__sbyte16.TestData_LHS[i].x13 + Tests.__sbyte16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x13 + Tests.__sbyte16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__sbyte16.TestData_LHS[i].x14 + Tests.__sbyte16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x14 + Tests.__sbyte16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__sbyte16.TestData_LHS[i].x15 + Tests.__sbyte16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__sbyte16.TestData_LHS[i].x15 + Tests.__sbyte16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte32x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__sbyte32.NUM_TESTS; i++)
            {
                sbyte32 x = maxmath.avg(Tests.__sbyte32.TestData_LHS[i], Tests.__sbyte32.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__sbyte32.TestData_LHS[i].x0  + Tests.__sbyte32.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x0  + Tests.__sbyte32.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__sbyte32.TestData_LHS[i].x1  + Tests.__sbyte32.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x1  + Tests.__sbyte32.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__sbyte32.TestData_LHS[i].x2  + Tests.__sbyte32.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x2  + Tests.__sbyte32.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__sbyte32.TestData_LHS[i].x3  + Tests.__sbyte32.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x3  + Tests.__sbyte32.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__sbyte32.TestData_LHS[i].x4  + Tests.__sbyte32.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x4  + Tests.__sbyte32.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__sbyte32.TestData_LHS[i].x5  + Tests.__sbyte32.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x5  + Tests.__sbyte32.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__sbyte32.TestData_LHS[i].x6  + Tests.__sbyte32.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x6  + Tests.__sbyte32.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__sbyte32.TestData_LHS[i].x7  + Tests.__sbyte32.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x7  + Tests.__sbyte32.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__sbyte32.TestData_LHS[i].x8  + Tests.__sbyte32.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x8  + Tests.__sbyte32.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__sbyte32.TestData_LHS[i].x9  + Tests.__sbyte32.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x9  + Tests.__sbyte32.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__sbyte32.TestData_LHS[i].x10 + Tests.__sbyte32.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x10 + Tests.__sbyte32.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__sbyte32.TestData_LHS[i].x11 + Tests.__sbyte32.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x11 + Tests.__sbyte32.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__sbyte32.TestData_LHS[i].x12 + Tests.__sbyte32.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x12 + Tests.__sbyte32.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__sbyte32.TestData_LHS[i].x13 + Tests.__sbyte32.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x13 + Tests.__sbyte32.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__sbyte32.TestData_LHS[i].x14 + Tests.__sbyte32.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x14 + Tests.__sbyte32.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__sbyte32.TestData_LHS[i].x15 + Tests.__sbyte32.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x15 + Tests.__sbyte32.TestData_RHS[i].x15) / 2;
                result &= x.x16 == (((Tests.__sbyte32.TestData_LHS[i].x16 + Tests.__sbyte32.TestData_RHS[i].x16) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x16 + Tests.__sbyte32.TestData_RHS[i].x16) / 2;
                result &= x.x17 == (((Tests.__sbyte32.TestData_LHS[i].x17 + Tests.__sbyte32.TestData_RHS[i].x17) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x17 + Tests.__sbyte32.TestData_RHS[i].x17) / 2;
                result &= x.x18 == (((Tests.__sbyte32.TestData_LHS[i].x18 + Tests.__sbyte32.TestData_RHS[i].x18) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x18 + Tests.__sbyte32.TestData_RHS[i].x18) / 2;
                result &= x.x19 == (((Tests.__sbyte32.TestData_LHS[i].x19 + Tests.__sbyte32.TestData_RHS[i].x19) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x19 + Tests.__sbyte32.TestData_RHS[i].x19) / 2;
                result &= x.x20 == (((Tests.__sbyte32.TestData_LHS[i].x20 + Tests.__sbyte32.TestData_RHS[i].x20) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x20 + Tests.__sbyte32.TestData_RHS[i].x20) / 2;
                result &= x.x21 == (((Tests.__sbyte32.TestData_LHS[i].x21 + Tests.__sbyte32.TestData_RHS[i].x21) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x21 + Tests.__sbyte32.TestData_RHS[i].x21) / 2;
                result &= x.x22 == (((Tests.__sbyte32.TestData_LHS[i].x22 + Tests.__sbyte32.TestData_RHS[i].x22) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x22 + Tests.__sbyte32.TestData_RHS[i].x22) / 2;
                result &= x.x23 == (((Tests.__sbyte32.TestData_LHS[i].x23 + Tests.__sbyte32.TestData_RHS[i].x23) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x23 + Tests.__sbyte32.TestData_RHS[i].x23) / 2;
                result &= x.x24 == (((Tests.__sbyte32.TestData_LHS[i].x24 + Tests.__sbyte32.TestData_RHS[i].x24) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x24 + Tests.__sbyte32.TestData_RHS[i].x24) / 2;
                result &= x.x25 == (((Tests.__sbyte32.TestData_LHS[i].x25 + Tests.__sbyte32.TestData_RHS[i].x25) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x25 + Tests.__sbyte32.TestData_RHS[i].x25) / 2;
                result &= x.x26 == (((Tests.__sbyte32.TestData_LHS[i].x26 + Tests.__sbyte32.TestData_RHS[i].x26) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x26 + Tests.__sbyte32.TestData_RHS[i].x26) / 2;
                result &= x.x27 == (((Tests.__sbyte32.TestData_LHS[i].x27 + Tests.__sbyte32.TestData_RHS[i].x27) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x27 + Tests.__sbyte32.TestData_RHS[i].x27) / 2;
                result &= x.x28 == (((Tests.__sbyte32.TestData_LHS[i].x28 + Tests.__sbyte32.TestData_RHS[i].x28) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x28 + Tests.__sbyte32.TestData_RHS[i].x28) / 2;
                result &= x.x29 == (((Tests.__sbyte32.TestData_LHS[i].x29 + Tests.__sbyte32.TestData_RHS[i].x29) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x29 + Tests.__sbyte32.TestData_RHS[i].x29) / 2;
                result &= x.x30 == (((Tests.__sbyte32.TestData_LHS[i].x30 + Tests.__sbyte32.TestData_RHS[i].x30) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x30 + Tests.__sbyte32.TestData_RHS[i].x30) / 2;
                result &= x.x31 == (((Tests.__sbyte32.TestData_LHS[i].x31 + Tests.__sbyte32.TestData_RHS[i].x31) > 0 ? 1 : -1) + Tests.__sbyte32.TestData_LHS[i].x31 + Tests.__sbyte32.TestData_RHS[i].x31) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void short2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short2.NUM_TESTS; i++)
            {
                short2 x = maxmath.avg(Tests.__short2.TestData_LHS[i], Tests.__short2.TestData_RHS[i]);

                result &= x.x == (((Tests.__short2.TestData_LHS[i].x + Tests.__short2.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short2.TestData_LHS[i].x + Tests.__short2.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short2.TestData_LHS[i].y + Tests.__short2.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short2.TestData_LHS[i].y + Tests.__short2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short3.NUM_TESTS; i++)
            {
                short3 x = maxmath.avg(Tests.__short3.TestData_LHS[i], Tests.__short3.TestData_RHS[i]);

                result &= x.x == (((Tests.__short3.TestData_LHS[i].x + Tests.__short3.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].x + Tests.__short3.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short3.TestData_LHS[i].y + Tests.__short3.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].y + Tests.__short3.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__short3.TestData_LHS[i].z + Tests.__short3.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__short3.TestData_LHS[i].z + Tests.__short3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short4.NUM_TESTS; i++)
            {
                short4 x = maxmath.avg(Tests.__short4.TestData_LHS[i], Tests.__short4.TestData_RHS[i]);

                result &= x.x == (((Tests.__short4.TestData_LHS[i].x + Tests.__short4.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].x + Tests.__short4.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.__short4.TestData_LHS[i].y + Tests.__short4.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].y + Tests.__short4.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.__short4.TestData_LHS[i].z + Tests.__short4.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].z + Tests.__short4.TestData_RHS[i].z) / 2;
                result &= x.w == (((Tests.__short4.TestData_LHS[i].w + Tests.__short4.TestData_RHS[i].w) > 0 ? 1 : -1) + Tests.__short4.TestData_LHS[i].w + Tests.__short4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short8.NUM_TESTS; i++)
            {
                short8 x = maxmath.avg(Tests.__short8.TestData_LHS[i], Tests.__short8.TestData_RHS[i]);

                result &= x.x0 == (((Tests.__short8.TestData_LHS[i].x0 + Tests.__short8.TestData_RHS[i].x0) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x0 + Tests.__short8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (((Tests.__short8.TestData_LHS[i].x1 + Tests.__short8.TestData_RHS[i].x1) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x1 + Tests.__short8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (((Tests.__short8.TestData_LHS[i].x2 + Tests.__short8.TestData_RHS[i].x2) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x2 + Tests.__short8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (((Tests.__short8.TestData_LHS[i].x3 + Tests.__short8.TestData_RHS[i].x3) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x3 + Tests.__short8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (((Tests.__short8.TestData_LHS[i].x4 + Tests.__short8.TestData_RHS[i].x4) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x4 + Tests.__short8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (((Tests.__short8.TestData_LHS[i].x5 + Tests.__short8.TestData_RHS[i].x5) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x5 + Tests.__short8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (((Tests.__short8.TestData_LHS[i].x6 + Tests.__short8.TestData_RHS[i].x6) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x6 + Tests.__short8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (((Tests.__short8.TestData_LHS[i].x7 + Tests.__short8.TestData_RHS[i].x7) > 0 ? 1 : -1) + Tests.__short8.TestData_LHS[i].x7 + Tests.__short8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short16x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__short16.NUM_TESTS; i++)
            {
                short16 x = maxmath.avg(Tests.__short16.TestData_LHS[i], Tests.__short16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.__short16.TestData_LHS[i].x0  + Tests.__short16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x0  + Tests.__short16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.__short16.TestData_LHS[i].x1  + Tests.__short16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x1  + Tests.__short16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.__short16.TestData_LHS[i].x2  + Tests.__short16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x2  + Tests.__short16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.__short16.TestData_LHS[i].x3  + Tests.__short16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x3  + Tests.__short16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.__short16.TestData_LHS[i].x4  + Tests.__short16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x4  + Tests.__short16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.__short16.TestData_LHS[i].x5  + Tests.__short16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x5  + Tests.__short16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.__short16.TestData_LHS[i].x6  + Tests.__short16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x6  + Tests.__short16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.__short16.TestData_LHS[i].x7  + Tests.__short16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x7  + Tests.__short16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.__short16.TestData_LHS[i].x8  + Tests.__short16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x8  + Tests.__short16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.__short16.TestData_LHS[i].x9  + Tests.__short16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x9  + Tests.__short16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.__short16.TestData_LHS[i].x10 + Tests.__short16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x10 + Tests.__short16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.__short16.TestData_LHS[i].x11 + Tests.__short16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x11 + Tests.__short16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.__short16.TestData_LHS[i].x12 + Tests.__short16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x12 + Tests.__short16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.__short16.TestData_LHS[i].x13 + Tests.__short16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x13 + Tests.__short16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.__short16.TestData_LHS[i].x14 + Tests.__short16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x14 + Tests.__short16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.__short16.TestData_LHS[i].x15 + Tests.__short16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.__short16.TestData_LHS[i].x15 + Tests.__short16.TestData_RHS[i].x15) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void int2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int2.NUM_TESTS; i++)
            {
                int2 x = maxmath.avg(Tests.__int2.TestData_LHS[i], Tests.__int2.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__int2.TestData_LHS[i].x, Tests.__int2.TestData_RHS[i].x) > 0 ? 1 : -1) + (long)Tests.__int2.TestData_LHS[i].x + (long)Tests.__int2.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__int2.TestData_LHS[i].y, Tests.__int2.TestData_RHS[i].y) > 0 ? 1 : -1) + (long)Tests.__int2.TestData_LHS[i].y + (long)Tests.__int2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int3.NUM_TESTS; i++)
            {
                int3 x = maxmath.avg(Tests.__int3.TestData_LHS[i], Tests.__int3.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__int3.TestData_LHS[i].x, Tests.__int3.TestData_RHS[i].x) > 0 ? 1 : -1) + (long)Tests.__int3.TestData_LHS[i].x + (long)Tests.__int3.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__int3.TestData_LHS[i].y, Tests.__int3.TestData_RHS[i].y) > 0 ? 1 : -1) + (long)Tests.__int3.TestData_LHS[i].y + (long)Tests.__int3.TestData_RHS[i].y) / 2;
                result &= x.z == ((maxmath.addsaturated(Tests.__int3.TestData_LHS[i].z, Tests.__int3.TestData_RHS[i].z) > 0 ? 1 : -1) + (long)Tests.__int3.TestData_LHS[i].z + (long)Tests.__int3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int4.NUM_TESTS; i++)
            {
                int4 x = maxmath.avg(Tests.__int4.TestData_LHS[i], Tests.__int4.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__int4.TestData_LHS[i].x, Tests.__int4.TestData_RHS[i].x) > 0 ? 1 : -1) + (long)Tests.__int4.TestData_LHS[i].x + (long)Tests.__int4.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__int4.TestData_LHS[i].y, Tests.__int4.TestData_RHS[i].y) > 0 ? 1 : -1) + (long)Tests.__int4.TestData_LHS[i].y + (long)Tests.__int4.TestData_RHS[i].y) / 2;
                result &= x.z == ((maxmath.addsaturated(Tests.__int4.TestData_LHS[i].z, Tests.__int4.TestData_RHS[i].z) > 0 ? 1 : -1) + (long)Tests.__int4.TestData_LHS[i].z + (long)Tests.__int4.TestData_RHS[i].z) / 2;
                result &= x.w == ((maxmath.addsaturated(Tests.__int4.TestData_LHS[i].w, Tests.__int4.TestData_RHS[i].w) > 0 ? 1 : -1) + (long)Tests.__int4.TestData_LHS[i].w + (long)Tests.__int4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int8x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__int8.NUM_TESTS; i++)
            {
                int8 x = maxmath.avg(Tests.__int8.TestData_LHS[i], Tests.__int8.TestData_RHS[i]);

                result &= x.x0 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x0, Tests.__int8.TestData_RHS[i].x0) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x0 + (long)Tests.__int8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x1, Tests.__int8.TestData_RHS[i].x1) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x1 + (long)Tests.__int8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x2, Tests.__int8.TestData_RHS[i].x2) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x2 + (long)Tests.__int8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x3, Tests.__int8.TestData_RHS[i].x3) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x3 + (long)Tests.__int8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x4, Tests.__int8.TestData_RHS[i].x4) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x4 + (long)Tests.__int8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x5, Tests.__int8.TestData_RHS[i].x5) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x5 + (long)Tests.__int8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x6, Tests.__int8.TestData_RHS[i].x6) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x6 + (long)Tests.__int8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == ((maxmath.addsaturated(Tests.__int8.TestData_LHS[i].x7, Tests.__int8.TestData_RHS[i].x7) > 0 ? 1 : -1) + (long)Tests.__int8.TestData_LHS[i].x7 + (long)Tests.__int8.TestData_RHS[i].x7) / 2;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void long2x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long2.NUM_TESTS; i++)
            {
                long2 x = maxmath.avg(Tests.__long2.TestData_LHS[i], Tests.__long2.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__long2.TestData_LHS[i].x, Tests.__long2.TestData_RHS[i].x) > 0 ? 1 : -1) + (Int128)Tests.__long2.TestData_LHS[i].x + (Int128)Tests.__long2.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__long2.TestData_LHS[i].y, Tests.__long2.TestData_RHS[i].y) > 0 ? 1 : -1) + (Int128)Tests.__long2.TestData_LHS[i].y + (Int128)Tests.__long2.TestData_RHS[i].y) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void long3x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long3.NUM_TESTS; i++)
            {
                long3 x = maxmath.avg(Tests.__long3.TestData_LHS[i], Tests.__long3.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__long3.TestData_LHS[i].x, Tests.__long3.TestData_RHS[i].x) > 0 ? 1 : -1) + (Int128)Tests.__long3.TestData_LHS[i].x + (Int128)Tests.__long3.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__long3.TestData_LHS[i].y, Tests.__long3.TestData_RHS[i].y) > 0 ? 1 : -1) + (Int128)Tests.__long3.TestData_LHS[i].y + (Int128)Tests.__long3.TestData_RHS[i].y) / 2;
                result &= x.z == ((maxmath.addsaturated(Tests.__long3.TestData_LHS[i].z, Tests.__long3.TestData_RHS[i].z) > 0 ? 1 : -1) + (Int128)Tests.__long3.TestData_LHS[i].z + (Int128)Tests.__long3.TestData_RHS[i].z) / 2;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void long4x2()
        {
            bool result = true;

            for (int i = 0; i < Tests.__long4.NUM_TESTS; i++)
            {
                long4 x = maxmath.avg(Tests.__long4.TestData_LHS[i], Tests.__long4.TestData_RHS[i]);

                result &= x.x == ((maxmath.addsaturated(Tests.__long4.TestData_LHS[i].x, Tests.__long4.TestData_RHS[i].x) > 0 ? 1 : -1) + (Int128)Tests.__long4.TestData_LHS[i].x + (Int128)Tests.__long4.TestData_RHS[i].x) / 2;
                result &= x.y == ((maxmath.addsaturated(Tests.__long4.TestData_LHS[i].y, Tests.__long4.TestData_RHS[i].y) > 0 ? 1 : -1) + (Int128)Tests.__long4.TestData_LHS[i].y + (Int128)Tests.__long4.TestData_RHS[i].y) / 2;
                result &= x.z == ((maxmath.addsaturated(Tests.__long4.TestData_LHS[i].z, Tests.__long4.TestData_RHS[i].z) > 0 ? 1 : -1) + (Int128)Tests.__long4.TestData_LHS[i].z + (Int128)Tests.__long4.TestData_RHS[i].z) / 2;
                result &= x.w == ((maxmath.addsaturated(Tests.__long4.TestData_LHS[i].w, Tests.__long4.TestData_RHS[i].w) > 0 ? 1 : -1) + (Int128)Tests.__long4.TestData_LHS[i].w + (Int128)Tests.__long4.TestData_RHS[i].w) / 2;
            }

            Assert.AreEqual(true, result);
        }
    }
}