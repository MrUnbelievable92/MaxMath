using NUnit.Framework;

namespace MaxMath.Tests
{
    /// Float8 implicitly tested by testing Int8
    unsafe public static class csum
    {
        [Test]
        public static void Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte2.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte2.TestData_LHS[i].x +
                                (uint)Tests.Byte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte3.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte3.TestData_LHS[i].x +
                                (uint)Tests.Byte3.TestData_LHS[i].y +
                                (uint)Tests.Byte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte4.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte4.TestData_LHS[i].x +
                                (uint)Tests.Byte4.TestData_LHS[i].y +
                                (uint)Tests.Byte4.TestData_LHS[i].z +
                                (uint)Tests.Byte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte8.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte8.TestData_LHS[i].x0 +
                                (uint)Tests.Byte8.TestData_LHS[i].x1 +
                                (uint)Tests.Byte8.TestData_LHS[i].x2 +
                                (uint)Tests.Byte8.TestData_LHS[i].x3 +
                                (uint)Tests.Byte8.TestData_LHS[i].x4 +
                                (uint)Tests.Byte8.TestData_LHS[i].x5 +
                                (uint)Tests.Byte8.TestData_LHS[i].x6 +
                                (uint)Tests.Byte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte16.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte16.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte16.TestData_LHS[i].x0 +
                                (uint)Tests.Byte16.TestData_LHS[i].x1 +
                                (uint)Tests.Byte16.TestData_LHS[i].x2 +
                                (uint)Tests.Byte16.TestData_LHS[i].x3 +
                                (uint)Tests.Byte16.TestData_LHS[i].x4 +
                                (uint)Tests.Byte16.TestData_LHS[i].x5 +
                                (uint)Tests.Byte16.TestData_LHS[i].x6 +
                                (uint)Tests.Byte16.TestData_LHS[i].x7 +
                                (uint)Tests.Byte16.TestData_LHS[i].x8 +
                                (uint)Tests.Byte16.TestData_LHS[i].x9 +
                                (uint)Tests.Byte16.TestData_LHS[i].x10 +
                                (uint)Tests.Byte16.TestData_LHS[i].x11 +
                                (uint)Tests.Byte16.TestData_LHS[i].x12 +
                                (uint)Tests.Byte16.TestData_LHS[i].x13 +
                                (uint)Tests.Byte16.TestData_LHS[i].x14 +
                                (uint)Tests.Byte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.Byte32.TestData_LHS[i]);

                result &= x == ((uint)Tests.Byte32.TestData_LHS[i].x0 +
                                (uint)Tests.Byte32.TestData_LHS[i].x1 +
                                (uint)Tests.Byte32.TestData_LHS[i].x2 +
                                (uint)Tests.Byte32.TestData_LHS[i].x3 +
                                (uint)Tests.Byte32.TestData_LHS[i].x4 +
                                (uint)Tests.Byte32.TestData_LHS[i].x5 +
                                (uint)Tests.Byte32.TestData_LHS[i].x6 +
                                (uint)Tests.Byte32.TestData_LHS[i].x7 +
                                (uint)Tests.Byte32.TestData_LHS[i].x8 +
                                (uint)Tests.Byte32.TestData_LHS[i].x9 +
                                (uint)Tests.Byte32.TestData_LHS[i].x10 +
                                (uint)Tests.Byte32.TestData_LHS[i].x11 +
                                (uint)Tests.Byte32.TestData_LHS[i].x12 +
                                (uint)Tests.Byte32.TestData_LHS[i].x13 +
                                (uint)Tests.Byte32.TestData_LHS[i].x14 +
                                (uint)Tests.Byte32.TestData_LHS[i].x15 +
                                (uint)Tests.Byte32.TestData_LHS[i].x16 +
                                (uint)Tests.Byte32.TestData_LHS[i].x17 +
                                (uint)Tests.Byte32.TestData_LHS[i].x18 +
                                (uint)Tests.Byte32.TestData_LHS[i].x19 +
                                (uint)Tests.Byte32.TestData_LHS[i].x20 +
                                (uint)Tests.Byte32.TestData_LHS[i].x21 +
                                (uint)Tests.Byte32.TestData_LHS[i].x22 +
                                (uint)Tests.Byte32.TestData_LHS[i].x23 +
                                (uint)Tests.Byte32.TestData_LHS[i].x24 +
                                (uint)Tests.Byte32.TestData_LHS[i].x25 +
                                (uint)Tests.Byte32.TestData_LHS[i].x26 +
                                (uint)Tests.Byte32.TestData_LHS[i].x27 +
                                (uint)Tests.Byte32.TestData_LHS[i].x28 +
                                (uint)Tests.Byte32.TestData_LHS[i].x29 +
                                (uint)Tests.Byte32.TestData_LHS[i].x30 +
                                (uint)Tests.Byte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte2.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte2.TestData_LHS[i].x +
                                (int)Tests.SByte2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte3.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte3.TestData_LHS[i].x +
                                (int)Tests.SByte3.TestData_LHS[i].y +
                                (int)Tests.SByte3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte4.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte4.TestData_LHS[i].x +
                                (int)Tests.SByte4.TestData_LHS[i].y +
                                (int)Tests.SByte4.TestData_LHS[i].z +
                                (int)Tests.SByte4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte8.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte8.TestData_LHS[i].x0 +
                                (int)Tests.SByte8.TestData_LHS[i].x1 +
                                (int)Tests.SByte8.TestData_LHS[i].x2 +
                                (int)Tests.SByte8.TestData_LHS[i].x3 +
                                (int)Tests.SByte8.TestData_LHS[i].x4 +
                                (int)Tests.SByte8.TestData_LHS[i].x5 +
                                (int)Tests.SByte8.TestData_LHS[i].x6 +
                                (int)Tests.SByte8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte16.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte16.TestData_LHS[i].x0 +
                                (int)Tests.SByte16.TestData_LHS[i].x1 +
                                (int)Tests.SByte16.TestData_LHS[i].x2 +
                                (int)Tests.SByte16.TestData_LHS[i].x3 +
                                (int)Tests.SByte16.TestData_LHS[i].x4 +
                                (int)Tests.SByte16.TestData_LHS[i].x5 +
                                (int)Tests.SByte16.TestData_LHS[i].x6 +
                                (int)Tests.SByte16.TestData_LHS[i].x7 +
                                (int)Tests.SByte16.TestData_LHS[i].x8 +
                                (int)Tests.SByte16.TestData_LHS[i].x9 +
                                (int)Tests.SByte16.TestData_LHS[i].x10 +
                                (int)Tests.SByte16.TestData_LHS[i].x11 +
                                (int)Tests.SByte16.TestData_LHS[i].x12 +
                                (int)Tests.SByte16.TestData_LHS[i].x13 +
                                (int)Tests.SByte16.TestData_LHS[i].x14 +
                                (int)Tests.SByte16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.SByte32.TestData_LHS[i]);

                result &= x == ((int)Tests.SByte32.TestData_LHS[i].x0 +
                                (int)Tests.SByte32.TestData_LHS[i].x1 +
                                (int)Tests.SByte32.TestData_LHS[i].x2 +
                                (int)Tests.SByte32.TestData_LHS[i].x3 +
                                (int)Tests.SByte32.TestData_LHS[i].x4 +
                                (int)Tests.SByte32.TestData_LHS[i].x5 +
                                (int)Tests.SByte32.TestData_LHS[i].x6 +
                                (int)Tests.SByte32.TestData_LHS[i].x7 +
                                (int)Tests.SByte32.TestData_LHS[i].x8 +
                                (int)Tests.SByte32.TestData_LHS[i].x9 +
                                (int)Tests.SByte32.TestData_LHS[i].x10 +
                                (int)Tests.SByte32.TestData_LHS[i].x11 +
                                (int)Tests.SByte32.TestData_LHS[i].x12 +
                                (int)Tests.SByte32.TestData_LHS[i].x13 +
                                (int)Tests.SByte32.TestData_LHS[i].x14 +
                                (int)Tests.SByte32.TestData_LHS[i].x15 +
                                (int)Tests.SByte32.TestData_LHS[i].x16 +
                                (int)Tests.SByte32.TestData_LHS[i].x17 +
                                (int)Tests.SByte32.TestData_LHS[i].x18 +
                                (int)Tests.SByte32.TestData_LHS[i].x19 +
                                (int)Tests.SByte32.TestData_LHS[i].x20 +
                                (int)Tests.SByte32.TestData_LHS[i].x21 +
                                (int)Tests.SByte32.TestData_LHS[i].x22 +
                                (int)Tests.SByte32.TestData_LHS[i].x23 +
                                (int)Tests.SByte32.TestData_LHS[i].x24 +
                                (int)Tests.SByte32.TestData_LHS[i].x25 +
                                (int)Tests.SByte32.TestData_LHS[i].x26 +
                                (int)Tests.SByte32.TestData_LHS[i].x27 +
                                (int)Tests.SByte32.TestData_LHS[i].x28 +
                                (int)Tests.SByte32.TestData_LHS[i].x29 +
                                (int)Tests.SByte32.TestData_LHS[i].x30 +
                                (int)Tests.SByte32.TestData_LHS[i].x31);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort2.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UShort2.TestData_LHS[i]);

                result &= x == ((uint)Tests.UShort2.TestData_LHS[i].x +
                                (uint)Tests.UShort2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort3.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UShort3.TestData_LHS[i]);

                result &= x == ((uint)Tests.UShort3.TestData_LHS[i].x +
                                (uint)Tests.UShort3.TestData_LHS[i].y +
                                (uint)Tests.UShort3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UShort4.TestData_LHS[i]);

                result &= x == ((uint)Tests.UShort4.TestData_LHS[i].x +
                                (uint)Tests.UShort4.TestData_LHS[i].y +
                                (uint)Tests.UShort4.TestData_LHS[i].z +
                                (uint)Tests.UShort4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UShort8.TestData_LHS[i]);

                result &= x == ((uint)Tests.UShort8.TestData_LHS[i].x0 +
                                (uint)Tests.UShort8.TestData_LHS[i].x1 +
                                (uint)Tests.UShort8.TestData_LHS[i].x2 +
                                (uint)Tests.UShort8.TestData_LHS[i].x3 +
                                (uint)Tests.UShort8.TestData_LHS[i].x4 +
                                (uint)Tests.UShort8.TestData_LHS[i].x5 +
                                (uint)Tests.UShort8.TestData_LHS[i].x6 +
                                (uint)Tests.UShort8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UShort16.TestData_LHS[i]);

                result &= x == ((uint)Tests.UShort16.TestData_LHS[i].x0 +
                                (uint)Tests.UShort16.TestData_LHS[i].x1 +
                                (uint)Tests.UShort16.TestData_LHS[i].x2 +
                                (uint)Tests.UShort16.TestData_LHS[i].x3 +
                                (uint)Tests.UShort16.TestData_LHS[i].x4 +
                                (uint)Tests.UShort16.TestData_LHS[i].x5 +
                                (uint)Tests.UShort16.TestData_LHS[i].x6 +
                                (uint)Tests.UShort16.TestData_LHS[i].x7 +
                                (uint)Tests.UShort16.TestData_LHS[i].x8 +
                                (uint)Tests.UShort16.TestData_LHS[i].x9 +
                                (uint)Tests.UShort16.TestData_LHS[i].x10 +
                                (uint)Tests.UShort16.TestData_LHS[i].x11 +
                                (uint)Tests.UShort16.TestData_LHS[i].x12 +
                                (uint)Tests.UShort16.TestData_LHS[i].x13 +
                                (uint)Tests.UShort16.TestData_LHS[i].x14 +
                                (uint)Tests.UShort16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Short2.TestData_LHS[i]);

                result &= x == ((int)Tests.Short2.TestData_LHS[i].x +
                                (int)Tests.Short2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Short3.TestData_LHS[i]);

                result &= x == ((int)Tests.Short3.TestData_LHS[i].x +
                                (int)Tests.Short3.TestData_LHS[i].y +
                                (int)Tests.Short3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Short4.TestData_LHS[i]);

                result &= x == ((int)Tests.Short4.TestData_LHS[i].x +
                                (int)Tests.Short4.TestData_LHS[i].y +
                                (int)Tests.Short4.TestData_LHS[i].z +
                                (int)Tests.Short4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Short8.TestData_LHS[i]);

                result &= x == ((int)Tests.Short8.TestData_LHS[i].x0 +
                                (int)Tests.Short8.TestData_LHS[i].x1 +
                                (int)Tests.Short8.TestData_LHS[i].x2 +
                                (int)Tests.Short8.TestData_LHS[i].x3 +
                                (int)Tests.Short8.TestData_LHS[i].x4 +
                                (int)Tests.Short8.TestData_LHS[i].x5 +
                                (int)Tests.Short8.TestData_LHS[i].x6 +
                                (int)Tests.Short8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Short16.TestData_LHS[i]);

                result &= x == ((int)Tests.Short16.TestData_LHS[i].x0 +
                                (int)Tests.Short16.TestData_LHS[i].x1 +
                                (int)Tests.Short16.TestData_LHS[i].x2 +
                                (int)Tests.Short16.TestData_LHS[i].x3 +
                                (int)Tests.Short16.TestData_LHS[i].x4 +
                                (int)Tests.Short16.TestData_LHS[i].x5 +
                                (int)Tests.Short16.TestData_LHS[i].x6 +
                                (int)Tests.Short16.TestData_LHS[i].x7 +
                                (int)Tests.Short16.TestData_LHS[i].x8 +
                                (int)Tests.Short16.TestData_LHS[i].x9 +
                                (int)Tests.Short16.TestData_LHS[i].x10 +
                                (int)Tests.Short16.TestData_LHS[i].x11 +
                                (int)Tests.Short16.TestData_LHS[i].x12 +
                                (int)Tests.Short16.TestData_LHS[i].x13 +
                                (int)Tests.Short16.TestData_LHS[i].x14 +
                                (int)Tests.Short16.TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                int x = maxmath.csum(Tests.Int8.TestData_LHS[i]);

                result &= x == (Tests.Int8.TestData_LHS[i].x0 +
                                Tests.Int8.TestData_LHS[i].x1 +
                                Tests.Int8.TestData_LHS[i].x2 +
                                Tests.Int8.TestData_LHS[i].x3 +
                                Tests.Int8.TestData_LHS[i].x4 +
                                Tests.Int8.TestData_LHS[i].x5 +
                                Tests.Int8.TestData_LHS[i].x6 +
                                Tests.Int8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UInt8.NUM_TESTS; i++)
            {
                uint x = maxmath.csum(Tests.UInt8.TestData_LHS[i]);

                result &= x == (Tests.UInt8.TestData_LHS[i].x0 +
                                Tests.UInt8.TestData_LHS[i].x1 +
                                Tests.UInt8.TestData_LHS[i].x2 +
                                Tests.UInt8.TestData_LHS[i].x3 +
                                Tests.UInt8.TestData_LHS[i].x4 +
                                Tests.UInt8.TestData_LHS[i].x5 +
                                Tests.UInt8.TestData_LHS[i].x6 +
                                Tests.UInt8.TestData_LHS[i].x7);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long x = maxmath.csum(Tests.Long2.TestData_LHS[i]);

                result &= x == (Tests.Long2.TestData_LHS[i].x +
                                Tests.Long2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long x = maxmath.csum(Tests.Long3.TestData_LHS[i]);

                result &= x == (Tests.Long3.TestData_LHS[i].x +
                                Tests.Long3.TestData_LHS[i].y +
                                Tests.Long3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long x = maxmath.csum(Tests.Long4.TestData_LHS[i]);

                result &= x == (Tests.Long4.TestData_LHS[i].x +
                                Tests.Long4.TestData_LHS[i].y +
                                Tests.Long4.TestData_LHS[i].z +
                                Tests.Long4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.csum(Tests.ULong2.TestData_LHS[i]);

                result &= x == (Tests.ULong2.TestData_LHS[i].x +
                                Tests.ULong2.TestData_LHS[i].y);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong3()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong3.NUM_TESTS; i++)
            {
                ulong x = maxmath.csum(Tests.ULong3.TestData_LHS[i]);

                result &= x == (Tests.ULong3.TestData_LHS[i].x +
                                Tests.ULong3.TestData_LHS[i].y +
                                Tests.ULong3.TestData_LHS[i].z);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ULong4()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.csum(Tests.ULong4.TestData_LHS[i]);

                result &= x == (Tests.ULong4.TestData_LHS[i].x +
                                Tests.ULong4.TestData_LHS[i].y +
                                Tests.ULong4.TestData_LHS[i].z +
                                Tests.ULong4.TestData_LHS[i].w);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                float x = maxmath.csum(Tests.Float8.TestData_LHS[i]);

                result &= maxmath.approx(x, (Tests.Float8.TestData_LHS[i].x0 +
                                             Tests.Float8.TestData_LHS[i].x1 +
                                             Tests.Float8.TestData_LHS[i].x2 +
                                             Tests.Float8.TestData_LHS[i].x3 +
                                             Tests.Float8.TestData_LHS[i].x4 +
                                             Tests.Float8.TestData_LHS[i].x5 +
                                             Tests.Float8.TestData_LHS[i].x6 +
                                             Tests.Float8.TestData_LHS[i].x7), 0.01f);
            }

            Assert.AreEqual(true, result);
        }
    }
}