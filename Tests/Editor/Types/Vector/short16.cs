using NUnit.Framework;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class t_short16
    {
        internal const int NUM_TESTS = 4;


        internal static short16[] TestData_LHS => new short16[]
        {
            new short16{x0  = -644,
					    x1  = 55,
					    x2  = 99,
					    x3  = 76,
					    x4  = 65,
					    x5  = -1,
					    x6  = -11,
					    x7  = 4955,
					    x8  = 75,
					    x9  = 99,
					    x10 = -11,
					    x11 = 54,
					    x12 = 695,
					    x13 = -9532,
					    x14 = -54,
                        x15 = -77},

            new short16{x0  = 3232,
					    x1  = -132,
					    x2  = 16,
					    x3  = -11,
					    x4  = 99,
					    x5  = 950,
					    x6  = -54,
					    x7  = -4959,
					    x8  = 76,
					    x9  = 65,
					    x10 = -1,
					    x11 = -11,
					    x12 = -4955,
					    x13 = 75,
					    x14 = 99,
					    x15 = -11},

            new short16{x0  = 957,
					    x1  = short.MaxValue,
					    x2  = 17,
					    x3  = 321,
					    x4  = 0,
					    x5  = 47,
					    x6  = -4532,
					    x7  = -56,
					    x8  = 957,
					    x9  = 321,
					    x10 = 47,
					    x11 = -70,
					    x12 = 54,
					    x13 = -3232,
					    x14 = 132,
					    x15 = 9595},

            new short16{x0  = short.MinValue,
					    x1  = 15495,
					    x2  = 111,
					    x3  = 66,
					    x4  = -99,
					    x5  = -4959,
					    x6  = -50,
					    x7  = 1321,
					    x8  = 5495,
					    x9  = -4532,
					    x10 = -995,
					    x11 = 6,
					    x12 = -4954,
					    x13 = 1324,
					    x14 = 15,
					    x15 = 99}
        };

        internal static short16[] TestData_RHS => new short16[]
        {
            new short16{x0  = 132,
					    x1  = 95,
					    x2  = 5495,
					    x3  = 995,
					    x4  = 32,
					    x5  = -5495,
					    x6  = 97,
					    x7  = 44,
					    x8  = 957,
					    x9  = -19,
					    x10 = -9532,
					    x11 = -5495,
					    x12 = -11,
					    x13 = -955,
					    x14 = 75,
					    x15 = -99},

            TestData_LHS[1],

            new short16{x0  = 17,
					    x1  = 957,
					    x2  = 9,
					    x3  = -9532,
					    x4  = -5499,
					    x5  = 45,
					    x6  = 90,
					    x7  = -632,
					    x8  = -77,
					    x9  = 132,
					    x10 = 47,
					    x11 = -49,
					    x12 = 65,
					    x13 = 7,
					    x14 = -1327,
					    x15 = 9595},

            new short16{x0  = 32,
					    x1  = 9,
					    x2  = -320,
					    x3  = -932,
					    x4  = 957,
					    x5  = -19,
					    x6  = -9532,
					    x7  = -5495,
					    x8  = -5495,
					    x9  = 32,
					    x10 = -432,
					    x11 = 99,
					    x12 = -595,
					    x13 = 932,
					    x14 = 15495,
                        x15 = 321}
        };


        [Test]
        public static void Constructor___short___short___short___short___short___short___short___short___short___short___short___short___short___short_Short()
        {
            short16 x = new short16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15);

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor_Short()
        {
            short16 x = new short16(TestData_LHS[0].x0);

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x0 &
                   x.x2 == TestData_LHS[0].x0 &
                   x.x3 == TestData_LHS[0].x0 &
                   x.x4 == TestData_LHS[0].x0 &
                   x.x5 == TestData_LHS[0].x0 &
                   x.x6 == TestData_LHS[0].x0 &
                   x.x7 == TestData_LHS[0].x0 &
                   x.x8 == TestData_LHS[0].x0 &
                   x.x9 == TestData_LHS[0].x0 &
                   x.x10 == TestData_LHS[0].x0 &
                   x.x11 == TestData_LHS[0].x0 &
                   x.x12 == TestData_LHS[0].x0 &
                   x.x13 == TestData_LHS[0].x0 &
                   x.x14 == TestData_LHS[0].x0 &
                   x.x15 == TestData_LHS[0].x0, true);
        }

        [Test]
        public static void Constructor___short2___short2___short2___short2___short2___short2___short2_Short2()
        {
            short16 x = new short16(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7), new short2(TestData_LHS[0].x8, TestData_LHS[0].x9), new short2(TestData_LHS[0].x10, TestData_LHS[0].x11), new short2(TestData_LHS[0].x12, TestData_LHS[0].x13), new short2(TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short4___short4___short4_Short4()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short4___short3___short3___short3_Short3()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short3(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new short3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short3___short4___short3___short3_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short4(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new short3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short3___short3___short4___short3_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short4(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short3___short3___short3___short4_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new short4(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short3___short3___short3___short3_Short4()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new short3(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short8___short4_Short4()
        {
            short16 x = new short16(new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }
        [Test]
        public static void Constructor___short4___short8_Short4()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short8(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short4___short4_Short8()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }

        [Test]
        public static void Constructor___short8_Short8()
        {
            short16 x = new short16(new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            Assert.AreEqual(x.x0 == TestData_LHS[0].x0 &
                   x.x1 == TestData_LHS[0].x1 &
                   x.x2 == TestData_LHS[0].x2 &
                   x.x3 == TestData_LHS[0].x3 &
                   x.x4 == TestData_LHS[0].x4 &
                   x.x5 == TestData_LHS[0].x5 &
                   x.x6 == TestData_LHS[0].x6 &
                   x.x7 == TestData_LHS[0].x7 &
                   x.x8 == TestData_LHS[0].x8 &
                   x.x9 == TestData_LHS[0].x9 &
                   x.x10 == TestData_LHS[0].x10 &
                   x.x11 == TestData_LHS[0].x11 &
                   x.x12 == TestData_LHS[0].x12 &
                   x.x13 == TestData_LHS[0].x13 &
                   x.x14 == TestData_LHS[0].x14 &
                   x.x15 == TestData_LHS[0].x15, true);
        }
        [Test]
        public static void Indexer()
        {
            Assert.AreEqual(TestData_LHS[0][0] == TestData_LHS[0].x0 &
                   TestData_LHS[0][1] == TestData_LHS[0].x1 &
                   TestData_LHS[0][2] == TestData_LHS[0].x2 &
                   TestData_LHS[0][3] == TestData_LHS[0].x3 &
                   TestData_LHS[0][4] == TestData_LHS[0].x4 &
                   TestData_LHS[0][5] == TestData_LHS[0].x5 &
                   TestData_LHS[0][6] == TestData_LHS[0].x6 &
                   TestData_LHS[0][7] == TestData_LHS[0].x7 &
                   TestData_LHS[0][8] == TestData_LHS[0].x8 &
                   TestData_LHS[0][9] == TestData_LHS[0].x9 &
                   TestData_LHS[0][10] == TestData_LHS[0].x10 &
                   TestData_LHS[0][11] == TestData_LHS[0].x11 &
                   TestData_LHS[0][12] == TestData_LHS[0].x12 &
                   TestData_LHS[0][13] == TestData_LHS[0].x13 &
                   TestData_LHS[0][14] == TestData_LHS[0].x14 &
                   TestData_LHS[0][15] == TestData_LHS[0].x15, true);

            for (int i = 0; i < 16; i++)
            {
                short16 x = TestData_LHS[0];

                x[i] = 0;
                Assert.AreEqual(x[i], 0);

                for (int j = 0; j < i; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }

                for (int j = i + 1; j < 16; j++)
                {
                    Assert.AreEqual(x[j], TestData_LHS[0][j]);
                }
            }
        }


        [Test]
        public static void op_Addition()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  + TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  + TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  + TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  + TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  + TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  + TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  + TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  + TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  + TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  + TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 + TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 + TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 + TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 + TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 + TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 + TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Subtraction()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  - TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  - TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  - TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  - TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  - TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  - TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  - TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  - TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  - TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  - TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 - TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 - TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 - TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 - TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 - TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 - TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  * TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  * TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  * TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  * TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  * TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  * TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  * TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  * TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  * TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  * TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 * TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 * TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 * TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 * TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 * TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 * TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Division()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  / TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  / TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  / TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  / TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  / TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  / TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  / TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  / TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  / TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  / TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 / TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 / TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 / TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 / TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 / TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 / TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_Modulus()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  % TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  % TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  % TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  % TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  % TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  % TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  % TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  % TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  % TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  % TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 % TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 % TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 % TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 % TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 % TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 % TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = -TestData_LHS[i];

                result &= x.x0 ==  (short)(-TestData_LHS[i].x0) &
                          x.x1 ==  (short)(-TestData_LHS[i].x1) &
                          x.x2 ==  (short)(-TestData_LHS[i].x2) &
                          x.x3 ==  (short)(-TestData_LHS[i].x3) &
                          x.x4 ==  (short)(-TestData_LHS[i].x4) &
                          x.x5 ==  (short)(-TestData_LHS[i].x5) &
                          x.x6 ==  (short)(-TestData_LHS[i].x6) &
                          x.x7 ==  (short)(-TestData_LHS[i].x7) &
                          x.x8 ==  (short)(-TestData_LHS[i].x8) &
                          x.x9 ==  (short)(-TestData_LHS[i].x9) &
                          x.x10 == (short)(-TestData_LHS[i].x10) &
                          x.x11 == (short)(-TestData_LHS[i].x11) &
                          x.x12 == (short)(-TestData_LHS[i].x12) &
                          x.x13 == (short)(-TestData_LHS[i].x13) &
                          x.x14 == (short)(-TestData_LHS[i].x14) &
                          x.x15 == (short)(-TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void op_BitwiseAnd()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  & TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  & TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  & TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  & TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  & TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  & TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  & TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  & TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  & TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  & TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 & TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 & TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 & TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 & TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 & TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 & TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_BitwiseOr()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  | TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  | TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  | TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  | TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  | TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  | TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  | TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  | TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  | TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  | TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 | TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 | TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 | TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 | TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 | TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 | TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void op_ExclusiveOr()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 ==  (short)(TestData_LHS[i].x0  ^ TestData_RHS[i].x0)  &
                          x.x1 ==  (short)(TestData_LHS[i].x1  ^ TestData_RHS[i].x1)  &
                          x.x2 ==  (short)(TestData_LHS[i].x2  ^ TestData_RHS[i].x2)  &
                          x.x3 ==  (short)(TestData_LHS[i].x3  ^ TestData_RHS[i].x3)  &
                          x.x4 ==  (short)(TestData_LHS[i].x4  ^ TestData_RHS[i].x4)  &
                          x.x5 ==  (short)(TestData_LHS[i].x5  ^ TestData_RHS[i].x5)  &
                          x.x6 ==  (short)(TestData_LHS[i].x6  ^ TestData_RHS[i].x6)  &
                          x.x7 ==  (short)(TestData_LHS[i].x7  ^ TestData_RHS[i].x7)  &
                          x.x8 ==  (short)(TestData_LHS[i].x8  ^ TestData_RHS[i].x8)  &
                          x.x9 ==  (short)(TestData_LHS[i].x9  ^ TestData_RHS[i].x9)  &
                          x.x10 == (short)(TestData_LHS[i].x10 ^ TestData_RHS[i].x10) &
                          x.x11 == (short)(TestData_LHS[i].x11 ^ TestData_RHS[i].x11) &
                          x.x12 == (short)(TestData_LHS[i].x12 ^ TestData_RHS[i].x12) &
                          x.x13 == (short)(TestData_LHS[i].x13 ^ TestData_RHS[i].x13) &
                          x.x14 == (short)(TestData_LHS[i].x14 ^ TestData_RHS[i].x14) &
                          x.x15 == (short)(TestData_LHS[i].x15 ^ TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = ~TestData_LHS[i];

                result &= x.x0 ==  (short)(~TestData_LHS[i].x0)  &
                          x.x1 ==  (short)(~TestData_LHS[i].x1)  &
                          x.x2 ==  (short)(~TestData_LHS[i].x2)  &
                          x.x3 ==  (short)(~TestData_LHS[i].x3)  &
                          x.x4 ==  (short)(~TestData_LHS[i].x4)  &
                          x.x5 ==  (short)(~TestData_LHS[i].x5)  &
                          x.x6 ==  (short)(~TestData_LHS[i].x6)  &
                          x.x7 ==  (short)(~TestData_LHS[i].x7)  &
                          x.x8 ==  (short)(~TestData_LHS[i].x8)  &
                          x.x9 ==  (short)(~TestData_LHS[i].x9)  &
                          x.x10 == (short)(~TestData_LHS[i].x10) &
                          x.x11 == (short)(~TestData_LHS[i].x11) &
                          x.x12 == (short)(~TestData_LHS[i].x12) &
                          x.x13 == (short)(~TestData_LHS[i].x13) &
                          x.x14 == (short)(~TestData_LHS[i].x14) &
                          x.x15 == (short)(~TestData_LHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    short16 x = TestData_LHS[i] << j;

                    result &= x.x0 ==  (short)(TestData_LHS[i].x0  << j) &
                              x.x1 ==  (short)(TestData_LHS[i].x1  << j) &
                              x.x2 ==  (short)(TestData_LHS[i].x2  << j) &
                              x.x3 ==  (short)(TestData_LHS[i].x3  << j) &
                              x.x4 ==  (short)(TestData_LHS[i].x4  << j) &
                              x.x5 ==  (short)(TestData_LHS[i].x5  << j) &
                              x.x6 ==  (short)(TestData_LHS[i].x6  << j) &
                              x.x7 ==  (short)(TestData_LHS[i].x7  << j) &
                              x.x8 ==  (short)(TestData_LHS[i].x8  << j) &
                              x.x9 ==  (short)(TestData_LHS[i].x9  << j) &
                              x.x10 == (short)(TestData_LHS[i].x10 << j) &
                              x.x11 == (short)(TestData_LHS[i].x11 << j) &
                              x.x12 == (short)(TestData_LHS[i].x12 << j) &
                              x.x13 == (short)(TestData_LHS[i].x13 << j) &
                              x.x14 == (short)(TestData_LHS[i].x14 << j) &
                              x.x15 == (short)(TestData_LHS[i].x15 << j);
                }
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    short16 x = TestData_LHS[i] >> j;

                    result &= x.x0 ==  (short)(TestData_LHS[i].x0  >> j) &
                              x.x1 ==  (short)(TestData_LHS[i].x1  >> j) &
                              x.x2 ==  (short)(TestData_LHS[i].x2  >> j) &
                              x.x3 ==  (short)(TestData_LHS[i].x3  >> j) &
                              x.x4 ==  (short)(TestData_LHS[i].x4  >> j) &
                              x.x5 ==  (short)(TestData_LHS[i].x5  >> j) &
                              x.x6 ==  (short)(TestData_LHS[i].x6  >> j) &
                              x.x7 ==  (short)(TestData_LHS[i].x7  >> j) &
                              x.x8 ==  (short)(TestData_LHS[i].x8  >> j) &
                              x.x9 ==  (short)(TestData_LHS[i].x9  >> j) &
                              x.x10 == (short)(TestData_LHS[i].x10 >> j) &
                              x.x11 == (short)(TestData_LHS[i].x11 >> j) &
                              x.x12 == (short)(TestData_LHS[i].x12 >> j) &
                              x.x13 == (short)(TestData_LHS[i].x13 >> j) &
                              x.x14 == (short)(TestData_LHS[i].x14 >> j) &
                              x.x15 == (short)(TestData_LHS[i].x15 >> j);
                }
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  == TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  == TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  == TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  == TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  == TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  == TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  == TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  == TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  == TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  == TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 == TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 == TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 == TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 == TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 == TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 == TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  < TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  < TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  < TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  < TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  < TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  < TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  < TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  < TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  < TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  < TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 < TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 < TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 < TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 < TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 < TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 < TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  > TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  > TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  > TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  > TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  > TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  > TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  > TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  > TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  > TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  > TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 > TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 > TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 > TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 > TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 > TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 > TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  != TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  != TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  != TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  != TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  != TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  != TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  != TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  != TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  != TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  != TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 != TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 != TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 != TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 != TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 != TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 != TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  <= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  <= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  <= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  <= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  <= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  <= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  <= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  <= TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  <= TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  <= TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 <= TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 <= TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 <= TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 <= TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 <= TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 <= TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool16 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool16(new bool4(TestData_LHS[i].x0  >= TestData_RHS[i].x0,
                                                         TestData_LHS[i].x1  >= TestData_RHS[i].x1,
                                                         TestData_LHS[i].x2  >= TestData_RHS[i].x2,
                                                         TestData_LHS[i].x3  >= TestData_RHS[i].x3),
                                               new bool4(TestData_LHS[i].x4  >= TestData_RHS[i].x4,
                                                         TestData_LHS[i].x5  >= TestData_RHS[i].x5,
                                                         TestData_LHS[i].x6  >= TestData_RHS[i].x6,
                                                         TestData_LHS[i].x7  >= TestData_RHS[i].x7),
                                               new bool4(TestData_LHS[i].x8  >= TestData_RHS[i].x8,
                                                         TestData_LHS[i].x9  >= TestData_RHS[i].x9,
                                                         TestData_LHS[i].x10 >= TestData_RHS[i].x10,
                                                         TestData_LHS[i].x11 >= TestData_RHS[i].x11),
                                               new bool4(TestData_LHS[i].x12 >= TestData_RHS[i].x12,
                                                         TestData_LHS[i].x13 >= TestData_RHS[i].x13,
                                                         TestData_LHS[i].x14 >= TestData_RHS[i].x14,
                                                         TestData_LHS[i].x15 >= TestData_RHS[i].x15)));
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void AllEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool x = TestData_LHS[i].Equals(TestData_RHS[i]);

                result &= x == (TestData_LHS[i].x0 == TestData_RHS[i].x0 &
                                TestData_LHS[i].x1 == TestData_RHS[i].x1 &
                                TestData_LHS[i].x2 == TestData_RHS[i].x2 &
                                TestData_LHS[i].x3 == TestData_RHS[i].x3 &
                                TestData_LHS[i].x4 == TestData_RHS[i].x4 &
                                TestData_LHS[i].x5 == TestData_RHS[i].x5 &
                                TestData_LHS[i].x6 == TestData_RHS[i].x6 &
                                TestData_LHS[i].x7 == TestData_RHS[i].x7 &
                                TestData_LHS[i].x8 == TestData_RHS[i].x8 &
                                TestData_LHS[i].x9 == TestData_RHS[i].x9 &
                                TestData_LHS[i].x10 == TestData_RHS[i].x10 &
                                TestData_LHS[i].x11 == TestData_RHS[i].x11 &
                                TestData_LHS[i].x12 == TestData_RHS[i].x12 &
                                TestData_LHS[i].x13 == TestData_RHS[i].x13 &
                                TestData_LHS[i].x14 == TestData_RHS[i].x14 &
                                TestData_LHS[i].x15 == TestData_RHS[i].x15);
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ShuffleGetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short8 v8_0 = TestData_LHS[i].v8_0;
                result &= v8_0.x0 == TestData_LHS[i].x0 &
                          v8_0.x1 == TestData_LHS[i].x1 &
                          v8_0.x2 == TestData_LHS[i].x2 &
                          v8_0.x3 == TestData_LHS[i].x3 &
                          v8_0.x4 == TestData_LHS[i].x4 &
                          v8_0.x5 == TestData_LHS[i].x5 &
                          v8_0.x6 == TestData_LHS[i].x6 &
                          v8_0.x7 == TestData_LHS[i].x7;

                short8 v8_1 = TestData_LHS[i].v8_1;
                result &= v8_1.x0 == TestData_LHS[i].x1 &
                          v8_1.x1 == TestData_LHS[i].x2 &
                          v8_1.x2 == TestData_LHS[i].x3 &
                          v8_1.x3 == TestData_LHS[i].x4 &
                          v8_1.x4 == TestData_LHS[i].x5 &
                          v8_1.x5 == TestData_LHS[i].x6 &
                          v8_1.x6 == TestData_LHS[i].x7 &
                          v8_1.x7 == TestData_LHS[i].x8;

                short8 v8_2 = TestData_LHS[i].v8_2;
                result &= v8_2.x0 == TestData_LHS[i].x2 &
                          v8_2.x1 == TestData_LHS[i].x3 &
                          v8_2.x2 == TestData_LHS[i].x4 &
                          v8_2.x3 == TestData_LHS[i].x5 &
                          v8_2.x4 == TestData_LHS[i].x6 &
                          v8_2.x5 == TestData_LHS[i].x7 &
                          v8_2.x6 == TestData_LHS[i].x8 &
                          v8_2.x7 == TestData_LHS[i].x9;

                short8 v8_3 = TestData_LHS[i].v8_3;
                result &= v8_3.x0 == TestData_LHS[i].x3 &
                          v8_3.x1 == TestData_LHS[i].x4 &
                          v8_3.x2 == TestData_LHS[i].x5 &
                          v8_3.x3 == TestData_LHS[i].x6 &
                          v8_3.x4 == TestData_LHS[i].x7 &
                          v8_3.x5 == TestData_LHS[i].x8 &
                          v8_3.x6 == TestData_LHS[i].x9 &
                          v8_3.x7 == TestData_LHS[i].x10;

                short8 v8_4 = TestData_LHS[i].v8_4;
                result &= v8_4.x0 == TestData_LHS[i].x4 &
                          v8_4.x1 == TestData_LHS[i].x5 &
                          v8_4.x2 == TestData_LHS[i].x6 &
                          v8_4.x3 == TestData_LHS[i].x7 &
                          v8_4.x4 == TestData_LHS[i].x8 &
                          v8_4.x5 == TestData_LHS[i].x9 &
                          v8_4.x6 == TestData_LHS[i].x10 &
                          v8_4.x7 == TestData_LHS[i].x11;

                short8 v8_5 = TestData_LHS[i].v8_5;
                result &= v8_5.x0 == TestData_LHS[i].x5 &
                          v8_5.x1 == TestData_LHS[i].x6 &
                          v8_5.x2 == TestData_LHS[i].x7 &
                          v8_5.x3 == TestData_LHS[i].x8 &
                          v8_5.x4 == TestData_LHS[i].x9 &
                          v8_5.x5 == TestData_LHS[i].x10 &
                          v8_5.x6 == TestData_LHS[i].x11 &
                          v8_5.x7 == TestData_LHS[i].x12;

                short8 v8_6 = TestData_LHS[i].v8_6;
                result &= v8_6.x0 == TestData_LHS[i].x6 &
                          v8_6.x1 == TestData_LHS[i].x7 &
                          v8_6.x2 == TestData_LHS[i].x8 &
                          v8_6.x3 == TestData_LHS[i].x9 &
                          v8_6.x4 == TestData_LHS[i].x10 &
                          v8_6.x5 == TestData_LHS[i].x11 &
                          v8_6.x6 == TestData_LHS[i].x12 &
                          v8_6.x7 == TestData_LHS[i].x13;

                short8 v8_7 = TestData_LHS[i].v8_7;
                result &= v8_7.x0 == TestData_LHS[i].x7 &
                          v8_7.x1 == TestData_LHS[i].x8 &
                          v8_7.x2 == TestData_LHS[i].x9 &
                          v8_7.x3 == TestData_LHS[i].x10 &
                          v8_7.x4 == TestData_LHS[i].x11 &
                          v8_7.x5 == TestData_LHS[i].x12 &
                          v8_7.x6 == TestData_LHS[i].x13 &
                          v8_7.x7 == TestData_LHS[i].x14;

                short8 v8_8 = TestData_LHS[i].v8_8;
                result &= v8_8.x0 == TestData_LHS[i].x8 &
                          v8_8.x1 == TestData_LHS[i].x9 &
                          v8_8.x2 == TestData_LHS[i].x10 &
                          v8_8.x3 == TestData_LHS[i].x11 &
                          v8_8.x4 == TestData_LHS[i].x12 &
                          v8_8.x5 == TestData_LHS[i].x13 &
                          v8_8.x6 == TestData_LHS[i].x14 &
                          v8_8.x7 == TestData_LHS[i].x15;


                short4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                short4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                short4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                short4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                short4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;

                short4 v4_5 = TestData_LHS[i].v4_5;
                result &= v4_5.x == TestData_LHS[i].x5 &
                          v4_5.y == TestData_LHS[i].x6 &
                          v4_5.z == TestData_LHS[i].x7 &
                          v4_5.w == TestData_LHS[i].x8;

                short4 v4_6 = TestData_LHS[i].v4_6;
                result &= v4_6.x == TestData_LHS[i].x6 &
                          v4_6.y == TestData_LHS[i].x7 &
                          v4_6.z == TestData_LHS[i].x8 &
                          v4_6.w == TestData_LHS[i].x9;

                short4 v4_7 = TestData_LHS[i].v4_7;
                result &= v4_7.x == TestData_LHS[i].x7 &
                          v4_7.y == TestData_LHS[i].x8 &
                          v4_7.z == TestData_LHS[i].x9 &
                          v4_7.w == TestData_LHS[i].x10;

                short4 v4_8 = TestData_LHS[i].v4_8;
                result &= v4_8.x == TestData_LHS[i].x8 &
                          v4_8.y == TestData_LHS[i].x9 &
                          v4_8.z == TestData_LHS[i].x10 &
                          v4_8.w == TestData_LHS[i].x11;

                short4 v4_9 = TestData_LHS[i].v4_9;
                result &= v4_9.x == TestData_LHS[i].x9  &
                          v4_9.y == TestData_LHS[i].x10 &
                          v4_9.z == TestData_LHS[i].x11 &
                          v4_9.w == TestData_LHS[i].x12;

                short4 v4_10 = TestData_LHS[i].v4_10;
                result &= v4_10.x == TestData_LHS[i].x10 &
                          v4_10.y == TestData_LHS[i].x11 &
                          v4_10.z == TestData_LHS[i].x12 &
                          v4_10.w == TestData_LHS[i].x13;

                short4 v4_11 = TestData_LHS[i].v4_11;
                result &= v4_11.x == TestData_LHS[i].x11 &
                          v4_11.y == TestData_LHS[i].x12 &
                          v4_11.z == TestData_LHS[i].x13 &
                          v4_11.w == TestData_LHS[i].x14;

                short4 v4_12 = TestData_LHS[i].v4_12;
                result &= v4_12.x == TestData_LHS[i].x12 &
                          v4_12.y == TestData_LHS[i].x13 &
                          v4_12.z == TestData_LHS[i].x14 &
                          v4_12.w == TestData_LHS[i].x15;


                short3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                short3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                short3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                short3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                short3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                short3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;

                short3 v3_6 = TestData_LHS[i].v3_6;
                result &= v3_6.x == TestData_LHS[i].x6 &
                          v3_6.y == TestData_LHS[i].x7 &
                          v3_6.z == TestData_LHS[i].x8;

                short3 v3_7 = TestData_LHS[i].v3_7;
                result &= v3_7.x == TestData_LHS[i].x7 &
                          v3_7.y == TestData_LHS[i].x8 &
                          v3_7.z == TestData_LHS[i].x9;

                short3 v3_8 = TestData_LHS[i].v3_8;
                result &= v3_8.x == TestData_LHS[i].x8 &
                          v3_8.y == TestData_LHS[i].x9 &
                          v3_8.z == TestData_LHS[i].x10;

                short3 v3_9 = TestData_LHS[i].v3_9;
                result &= v3_9.x == TestData_LHS[i].x9 &
                          v3_9.y == TestData_LHS[i].x10 &
                          v3_9.z == TestData_LHS[i].x11;

                short3 v3_10 = TestData_LHS[i].v3_10;
                result &= v3_10.x == TestData_LHS[i].x10 &
                          v3_10.y == TestData_LHS[i].x11 &
                          v3_10.z == TestData_LHS[i].x12;

                short3 v3_11 = TestData_LHS[i].v3_11;
                result &= v3_11.x == TestData_LHS[i].x11 &
                          v3_11.y == TestData_LHS[i].x12 &
                          v3_11.z == TestData_LHS[i].x13;

                short3 v3_12 = TestData_LHS[i].v3_12;
                result &= v3_12.x == TestData_LHS[i].x12 &
                          v3_12.y == TestData_LHS[i].x13 &
                          v3_12.z == TestData_LHS[i].x14;

                short3 v3_13 = TestData_LHS[i].v3_13;
                result &= v3_13.x == TestData_LHS[i].x13 &
                          v3_13.y == TestData_LHS[i].x14 &
                          v3_13.z == TestData_LHS[i].x15;


                short2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                short2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                short2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                short2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                short2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                short2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                short2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;

                short2 v2_7 = TestData_LHS[i].v2_7;
                result &= v2_7.x == TestData_LHS[i].x7 &
                          v2_7.y == TestData_LHS[i].x8;

                short2 v2_8 = TestData_LHS[i].v2_8;
                result &= v2_8.x == TestData_LHS[i].x8 &
                          v2_8.y == TestData_LHS[i].x9;

                short2 v2_9 = TestData_LHS[i].v2_9;
                result &= v2_9.x == TestData_LHS[i].x9 &
                          v2_9.y == TestData_LHS[i].x10;

                short2 v2_10 = TestData_LHS[i].v2_10;
                result &= v2_10.x == TestData_LHS[i].x10 &
                          v2_10.y == TestData_LHS[i].x11;

                short2 v2_11 = TestData_LHS[i].v2_11;
                result &= v2_11.x == TestData_LHS[i].x11 &
                          v2_11.y == TestData_LHS[i].x12;

                short2 v2_12 = TestData_LHS[i].v2_12;
                result &= v2_12.x == TestData_LHS[i].x12 &
                          v2_12.y == TestData_LHS[i].x13;

                short2 v2_13 = TestData_LHS[i].v2_13;
                result &= v2_13.x == TestData_LHS[i].x13 &
                          v2_13.y == TestData_LHS[i].x14;

                short2 v2_14 = TestData_LHS[i].v2_14;
                result &= v2_14.x == TestData_LHS[i].x14 &
                          v2_14.y == TestData_LHS[i].x15;
            }


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void ShuffleSetter()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 v8_0 = TestData_LHS[i];
                v8_0.v8_0 = t_short8.TestData_LHS[i];
                result &= v8_0.x0  == t_short8.TestData_LHS[i].x0;
                result &= v8_0.x1  == t_short8.TestData_LHS[i].x1;
                result &= v8_0.x2  == t_short8.TestData_LHS[i].x2;
                result &= v8_0.x3  == t_short8.TestData_LHS[i].x3;
                result &= v8_0.x4  == t_short8.TestData_LHS[i].x4;
                result &= v8_0.x5  == t_short8.TestData_LHS[i].x5;
                result &= v8_0.x6  == t_short8.TestData_LHS[i].x6;
                result &= v8_0.x7  == t_short8.TestData_LHS[i].x7;
                result &= v8_0.x8  == TestData_LHS[i].x8;
                result &= v8_0.x9  == TestData_LHS[i].x9;
                result &= v8_0.x10 == TestData_LHS[i].x10;
                result &= v8_0.x11 == TestData_LHS[i].x11;
                result &= v8_0.x12 == TestData_LHS[i].x12;
                result &= v8_0.x13 == TestData_LHS[i].x13;
                result &= v8_0.x14 == TestData_LHS[i].x14;
                result &= v8_0.x15 == TestData_LHS[i].x15;

                short16 v8_1 = TestData_LHS[i];
                v8_1.v8_1 = t_short8.TestData_LHS[i];
                result &= v8_1.x0  == TestData_LHS[i].x0;
                result &= v8_1.x1  == t_short8.TestData_LHS[i].x0;
                result &= v8_1.x2  == t_short8.TestData_LHS[i].x1;
                result &= v8_1.x3  == t_short8.TestData_LHS[i].x2;
                result &= v8_1.x4  == t_short8.TestData_LHS[i].x3;
                result &= v8_1.x5  == t_short8.TestData_LHS[i].x4;
                result &= v8_1.x6  == t_short8.TestData_LHS[i].x5;
                result &= v8_1.x7  == t_short8.TestData_LHS[i].x6;
                result &= v8_1.x8  == t_short8.TestData_LHS[i].x7;
                result &= v8_1.x9  == TestData_LHS[i].x9;
                result &= v8_1.x10 == TestData_LHS[i].x10;
                result &= v8_1.x11 == TestData_LHS[i].x11;
                result &= v8_1.x12 == TestData_LHS[i].x12;
                result &= v8_1.x13 == TestData_LHS[i].x13;
                result &= v8_1.x14 == TestData_LHS[i].x14;
                result &= v8_1.x15 == TestData_LHS[i].x15;

                short16 v8_2 = TestData_LHS[i];
                v8_2.v8_2 = t_short8.TestData_LHS[i];
                result &= v8_2.x0  == TestData_LHS[i].x0;
                result &= v8_2.x1  == TestData_LHS[i].x1;
                result &= v8_2.x2  == t_short8.TestData_LHS[i].x0;
                result &= v8_2.x3  == t_short8.TestData_LHS[i].x1;
                result &= v8_2.x4  == t_short8.TestData_LHS[i].x2;
                result &= v8_2.x5  == t_short8.TestData_LHS[i].x3;
                result &= v8_2.x6  == t_short8.TestData_LHS[i].x4;
                result &= v8_2.x7  == t_short8.TestData_LHS[i].x5;
                result &= v8_2.x8  == t_short8.TestData_LHS[i].x6;
                result &= v8_2.x9  == t_short8.TestData_LHS[i].x7;
                result &= v8_2.x10 == TestData_LHS[i].x10;
                result &= v8_2.x11 == TestData_LHS[i].x11;
                result &= v8_2.x12 == TestData_LHS[i].x12;
                result &= v8_2.x13 == TestData_LHS[i].x13;
                result &= v8_2.x14 == TestData_LHS[i].x14;
                result &= v8_2.x15 == TestData_LHS[i].x15;

                short16 v8_3 = TestData_LHS[i];
                v8_3.v8_3 = t_short8.TestData_LHS[i];
                result &= v8_3.x0  == TestData_LHS[i].x0;
                result &= v8_3.x1  == TestData_LHS[i].x1;
                result &= v8_3.x2  == TestData_LHS[i].x2;
                result &= v8_3.x3  == t_short8.TestData_LHS[i].x0;
                result &= v8_3.x4  == t_short8.TestData_LHS[i].x1;
                result &= v8_3.x5  == t_short8.TestData_LHS[i].x2;
                result &= v8_3.x6  == t_short8.TestData_LHS[i].x3;
                result &= v8_3.x7  == t_short8.TestData_LHS[i].x4;
                result &= v8_3.x8  == t_short8.TestData_LHS[i].x5;
                result &= v8_3.x9  == t_short8.TestData_LHS[i].x6;
                result &= v8_3.x10 == t_short8.TestData_LHS[i].x7;
                result &= v8_3.x11 == TestData_LHS[i].x11;
                result &= v8_3.x12 == TestData_LHS[i].x12;
                result &= v8_3.x13 == TestData_LHS[i].x13;
                result &= v8_3.x14 == TestData_LHS[i].x14;
                result &= v8_3.x15 == TestData_LHS[i].x15;

                short16 v8_4 = TestData_LHS[i];
                v8_4.v8_4 = t_short8.TestData_LHS[i];
                result &= v8_4.x0  == TestData_LHS[i].x0;
                result &= v8_4.x1  == TestData_LHS[i].x1;
                result &= v8_4.x2  == TestData_LHS[i].x2;
                result &= v8_4.x3  == TestData_LHS[i].x3;
                result &= v8_4.x4  == t_short8.TestData_LHS[i].x0;
                result &= v8_4.x5  == t_short8.TestData_LHS[i].x1;
                result &= v8_4.x6  == t_short8.TestData_LHS[i].x2;
                result &= v8_4.x7  == t_short8.TestData_LHS[i].x3;
                result &= v8_4.x8  == t_short8.TestData_LHS[i].x4;
                result &= v8_4.x9  == t_short8.TestData_LHS[i].x5;
                result &= v8_4.x10 == t_short8.TestData_LHS[i].x6;
                result &= v8_4.x11 == t_short8.TestData_LHS[i].x7;
                result &= v8_4.x12 == TestData_LHS[i].x12;
                result &= v8_4.x13 == TestData_LHS[i].x13;
                result &= v8_4.x14 == TestData_LHS[i].x14;
                result &= v8_4.x15 == TestData_LHS[i].x15;

                short16 v8_5 = TestData_LHS[i];
                v8_5.v8_5 = t_short8.TestData_LHS[i];
                result &= v8_5.x0  == TestData_LHS[i].x0;
                result &= v8_5.x1  == TestData_LHS[i].x1;
                result &= v8_5.x2  == TestData_LHS[i].x2;
                result &= v8_5.x3  == TestData_LHS[i].x3;
                result &= v8_5.x4  == TestData_LHS[i].x4;
                result &= v8_5.x5  == t_short8.TestData_LHS[i].x0;
                result &= v8_5.x6  == t_short8.TestData_LHS[i].x1;
                result &= v8_5.x7  == t_short8.TestData_LHS[i].x2;
                result &= v8_5.x8  == t_short8.TestData_LHS[i].x3;
                result &= v8_5.x9  == t_short8.TestData_LHS[i].x4;
                result &= v8_5.x10 == t_short8.TestData_LHS[i].x5;
                result &= v8_5.x11 == t_short8.TestData_LHS[i].x6;
                result &= v8_5.x12 == t_short8.TestData_LHS[i].x7;
                result &= v8_5.x13 == TestData_LHS[i].x13;
                result &= v8_5.x14 == TestData_LHS[i].x14;
                result &= v8_5.x15 == TestData_LHS[i].x15;

                short16 v8_6 = TestData_LHS[i];
                v8_6.v8_6 = t_short8.TestData_LHS[i];
                result &= v8_6.x0  == TestData_LHS[i].x0;
                result &= v8_6.x1  == TestData_LHS[i].x1;
                result &= v8_6.x2  == TestData_LHS[i].x2;
                result &= v8_6.x3  == TestData_LHS[i].x3;
                result &= v8_6.x4  == TestData_LHS[i].x4;
                result &= v8_6.x5  == TestData_LHS[i].x5;
                result &= v8_6.x6  == t_short8.TestData_LHS[i].x0;
                result &= v8_6.x7  == t_short8.TestData_LHS[i].x1;
                result &= v8_6.x8  == t_short8.TestData_LHS[i].x2;
                result &= v8_6.x9  == t_short8.TestData_LHS[i].x3;
                result &= v8_6.x10 == t_short8.TestData_LHS[i].x4;
                result &= v8_6.x11 == t_short8.TestData_LHS[i].x5;
                result &= v8_6.x12 == t_short8.TestData_LHS[i].x6;
                result &= v8_6.x13 == t_short8.TestData_LHS[i].x7;
                result &= v8_6.x14 == TestData_LHS[i].x14;
                result &= v8_6.x15 == TestData_LHS[i].x15;

                short16 v8_7 = TestData_LHS[i];
                v8_7.v8_7 = t_short8.TestData_LHS[i];
                result &= v8_7.x0  == TestData_LHS[i].x0;
                result &= v8_7.x1  == TestData_LHS[i].x1;
                result &= v8_7.x2  == TestData_LHS[i].x2;
                result &= v8_7.x3  == TestData_LHS[i].x3;
                result &= v8_7.x4  == TestData_LHS[i].x4;
                result &= v8_7.x5  == TestData_LHS[i].x5;
                result &= v8_7.x6  == TestData_LHS[i].x6;
                result &= v8_7.x7  == t_short8.TestData_LHS[i].x0;
                result &= v8_7.x8  == t_short8.TestData_LHS[i].x1;
                result &= v8_7.x9  == t_short8.TestData_LHS[i].x2;
                result &= v8_7.x10 == t_short8.TestData_LHS[i].x3;
                result &= v8_7.x11 == t_short8.TestData_LHS[i].x4;
                result &= v8_7.x12 == t_short8.TestData_LHS[i].x5;
                result &= v8_7.x13 == t_short8.TestData_LHS[i].x6;
                result &= v8_7.x14 == t_short8.TestData_LHS[i].x7;
                result &= v8_7.x15 == TestData_LHS[i].x15;

                short16 v8_8 = TestData_LHS[i];
                v8_8.v8_8 = t_short8.TestData_LHS[i];
                result &= v8_8.x0  == TestData_LHS[i].x0;
                result &= v8_8.x1  == TestData_LHS[i].x1;
                result &= v8_8.x2  == TestData_LHS[i].x2;
                result &= v8_8.x3  == TestData_LHS[i].x3;
                result &= v8_8.x4  == TestData_LHS[i].x4;
                result &= v8_8.x5  == TestData_LHS[i].x5;
                result &= v8_8.x6  == TestData_LHS[i].x6;
                result &= v8_8.x7  == TestData_LHS[i].x7;
                result &= v8_8.x8  == t_short8.TestData_LHS[i].x0;
                result &= v8_8.x9  == t_short8.TestData_LHS[i].x1;
                result &= v8_8.x10 == t_short8.TestData_LHS[i].x2;
                result &= v8_8.x11 == t_short8.TestData_LHS[i].x3;
                result &= v8_8.x12 == t_short8.TestData_LHS[i].x4;
                result &= v8_8.x13 == t_short8.TestData_LHS[i].x5;
                result &= v8_8.x14 == t_short8.TestData_LHS[i].x6;
                result &= v8_8.x15 == t_short8.TestData_LHS[i].x7;


                short16 v4_0 = TestData_LHS[i];
                v4_0.v4_0 = t_short4.TestData_LHS[i];
                result &= v4_0.x0  == t_short4.TestData_LHS[i].x;
                result &= v4_0.x1  == t_short4.TestData_LHS[i].y;
                result &= v4_0.x2  == t_short4.TestData_LHS[i].z;
                result &= v4_0.x3  == t_short4.TestData_LHS[i].w;
                result &= v4_0.x4  == TestData_LHS[i].x4;
                result &= v4_0.x5  == TestData_LHS[i].x5;
                result &= v4_0.x6  == TestData_LHS[i].x6;
                result &= v4_0.x7  == TestData_LHS[i].x7;
                result &= v4_0.x8  == TestData_LHS[i].x8;
                result &= v4_0.x9  == TestData_LHS[i].x9;
                result &= v4_0.x10 == TestData_LHS[i].x10;
                result &= v4_0.x11 == TestData_LHS[i].x11;
                result &= v4_0.x12 == TestData_LHS[i].x12;
                result &= v4_0.x13 == TestData_LHS[i].x13;
                result &= v4_0.x14 == TestData_LHS[i].x14;
                result &= v4_0.x15 == TestData_LHS[i].x15;

                short16 v4_1 = TestData_LHS[i];
                v4_1.v4_1 = t_short4.TestData_LHS[i];
                result &= v4_1.x0  == TestData_LHS[i].x0;
                result &= v4_1.x1  == t_short4.TestData_LHS[i].x;
                result &= v4_1.x2  == t_short4.TestData_LHS[i].y;
                result &= v4_1.x3  == t_short4.TestData_LHS[i].z;
                result &= v4_1.x4  == t_short4.TestData_LHS[i].w;
                result &= v4_1.x5  == TestData_LHS[i].x5;
                result &= v4_1.x6  == TestData_LHS[i].x6;
                result &= v4_1.x7  == TestData_LHS[i].x7;
                result &= v4_1.x8  == TestData_LHS[i].x8;
                result &= v4_1.x9  == TestData_LHS[i].x9;
                result &= v4_1.x10 == TestData_LHS[i].x10;
                result &= v4_1.x11 == TestData_LHS[i].x11;
                result &= v4_1.x12 == TestData_LHS[i].x12;
                result &= v4_1.x13 == TestData_LHS[i].x13;
                result &= v4_1.x14 == TestData_LHS[i].x14;
                result &= v4_1.x15 == TestData_LHS[i].x15;

                short16 v4_2 = TestData_LHS[i];
                v4_2.v4_2 = t_short4.TestData_LHS[i];
                result &= v4_2.x0  == TestData_LHS[i].x0;
                result &= v4_2.x1  == TestData_LHS[i].x1;
                result &= v4_2.x2  == t_short4.TestData_LHS[i].x;
                result &= v4_2.x3  == t_short4.TestData_LHS[i].y;
                result &= v4_2.x4  == t_short4.TestData_LHS[i].z;
                result &= v4_2.x5  == t_short4.TestData_LHS[i].w;
                result &= v4_2.x6  == TestData_LHS[i].x6;
                result &= v4_2.x7  == TestData_LHS[i].x7;
                result &= v4_2.x8  == TestData_LHS[i].x8;
                result &= v4_2.x9  == TestData_LHS[i].x9;
                result &= v4_2.x10 == TestData_LHS[i].x10;
                result &= v4_2.x11 == TestData_LHS[i].x11;
                result &= v4_2.x12 == TestData_LHS[i].x12;
                result &= v4_2.x13 == TestData_LHS[i].x13;
                result &= v4_2.x14 == TestData_LHS[i].x14;
                result &= v4_2.x15 == TestData_LHS[i].x15;

                short16 v4_3 = TestData_LHS[i];
                v4_3.v4_3 = t_short4.TestData_LHS[i];
                result &= v4_3.x0  == TestData_LHS[i].x0;
                result &= v4_3.x1  == TestData_LHS[i].x1;
                result &= v4_3.x2  == TestData_LHS[i].x2;
                result &= v4_3.x3  == t_short4.TestData_LHS[i].x;
                result &= v4_3.x4  == t_short4.TestData_LHS[i].y;
                result &= v4_3.x5  == t_short4.TestData_LHS[i].z;
                result &= v4_3.x6  == t_short4.TestData_LHS[i].w;
                result &= v4_3.x7  == TestData_LHS[i].x7;
                result &= v4_3.x8  == TestData_LHS[i].x8;
                result &= v4_3.x9  == TestData_LHS[i].x9;
                result &= v4_3.x10 == TestData_LHS[i].x10;
                result &= v4_3.x11 == TestData_LHS[i].x11;
                result &= v4_3.x12 == TestData_LHS[i].x12;
                result &= v4_3.x13 == TestData_LHS[i].x13;
                result &= v4_3.x14 == TestData_LHS[i].x14;
                result &= v4_3.x15 == TestData_LHS[i].x15;

                short16 v4_4 = TestData_LHS[i];
                v4_4.v4_4 = t_short4.TestData_LHS[i];
                result &= v4_4.x0  == TestData_LHS[i].x0;
                result &= v4_4.x1  == TestData_LHS[i].x1;
                result &= v4_4.x2  == TestData_LHS[i].x2;
                result &= v4_4.x3  == TestData_LHS[i].x3;
                result &= v4_4.x4  == t_short4.TestData_LHS[i].x;
                result &= v4_4.x5  == t_short4.TestData_LHS[i].y;
                result &= v4_4.x6  == t_short4.TestData_LHS[i].z;
                result &= v4_4.x7  == t_short4.TestData_LHS[i].w;
                result &= v4_4.x8  == TestData_LHS[i].x8;
                result &= v4_4.x9  == TestData_LHS[i].x9;
                result &= v4_4.x10 == TestData_LHS[i].x10;
                result &= v4_4.x11 == TestData_LHS[i].x11;
                result &= v4_4.x12 == TestData_LHS[i].x12;
                result &= v4_4.x13 == TestData_LHS[i].x13;
                result &= v4_4.x14 == TestData_LHS[i].x14;
                result &= v4_4.x15 == TestData_LHS[i].x15;

                short16 v4_5 = TestData_LHS[i];
                v4_5.v4_5 = t_short4.TestData_LHS[i];
                result &= v4_5.x0  == TestData_LHS[i].x0;
                result &= v4_5.x1  == TestData_LHS[i].x1;
                result &= v4_5.x2  == TestData_LHS[i].x2;
                result &= v4_5.x3  == TestData_LHS[i].x3;
                result &= v4_5.x4  == TestData_LHS[i].x4;
                result &= v4_5.x5  == t_short4.TestData_LHS[i].x;
                result &= v4_5.x6  == t_short4.TestData_LHS[i].y;
                result &= v4_5.x7  == t_short4.TestData_LHS[i].z;
                result &= v4_5.x8  == t_short4.TestData_LHS[i].w;
                result &= v4_5.x9  == TestData_LHS[i].x9;
                result &= v4_5.x10 == TestData_LHS[i].x10;
                result &= v4_5.x11 == TestData_LHS[i].x11;
                result &= v4_5.x12 == TestData_LHS[i].x12;
                result &= v4_5.x13 == TestData_LHS[i].x13;
                result &= v4_5.x14 == TestData_LHS[i].x14;
                result &= v4_5.x15 == TestData_LHS[i].x15;

                short16 v4_6 = TestData_LHS[i];
                v4_6.v4_6 = t_short4.TestData_LHS[i];
                result &= v4_6.x0  == TestData_LHS[i].x0;
                result &= v4_6.x1  == TestData_LHS[i].x1;
                result &= v4_6.x2  == TestData_LHS[i].x2;
                result &= v4_6.x3  == TestData_LHS[i].x3;
                result &= v4_6.x4  == TestData_LHS[i].x4;
                result &= v4_6.x5  == TestData_LHS[i].x5;
                result &= v4_6.x6  == t_short4.TestData_LHS[i].x;
                result &= v4_6.x7  == t_short4.TestData_LHS[i].y;
                result &= v4_6.x8  == t_short4.TestData_LHS[i].z;
                result &= v4_6.x9  == t_short4.TestData_LHS[i].w;
                result &= v4_6.x10 == TestData_LHS[i].x10;
                result &= v4_6.x11 == TestData_LHS[i].x11;
                result &= v4_6.x12 == TestData_LHS[i].x12;
                result &= v4_6.x13 == TestData_LHS[i].x13;
                result &= v4_6.x14 == TestData_LHS[i].x14;
                result &= v4_6.x15 == TestData_LHS[i].x15;

                short16 v4_7 = TestData_LHS[i];
                v4_7.v4_7 = t_short4.TestData_LHS[i];
                result &= v4_7.x0  == TestData_LHS[i].x0;
                result &= v4_7.x1  == TestData_LHS[i].x1;
                result &= v4_7.x2  == TestData_LHS[i].x2;
                result &= v4_7.x3  == TestData_LHS[i].x3;
                result &= v4_7.x4  == TestData_LHS[i].x4;
                result &= v4_7.x5  == TestData_LHS[i].x5;
                result &= v4_7.x6  == TestData_LHS[i].x6;
                result &= v4_7.x7  == t_short4.TestData_LHS[i].x;
                result &= v4_7.x8  == t_short4.TestData_LHS[i].y;
                result &= v4_7.x9  == t_short4.TestData_LHS[i].z;
                result &= v4_7.x10 == t_short4.TestData_LHS[i].w;
                result &= v4_7.x11 == TestData_LHS[i].x11;
                result &= v4_7.x12 == TestData_LHS[i].x12;
                result &= v4_7.x13 == TestData_LHS[i].x13;
                result &= v4_7.x14 == TestData_LHS[i].x14;
                result &= v4_7.x15 == TestData_LHS[i].x15;

                short16 v4_8 = TestData_LHS[i];
                v4_8.v4_8 = t_short4.TestData_LHS[i];
                result &= v4_8.x0  == TestData_LHS[i].x0;
                result &= v4_8.x1  == TestData_LHS[i].x1;
                result &= v4_8.x2  == TestData_LHS[i].x2;
                result &= v4_8.x3  == TestData_LHS[i].x3;
                result &= v4_8.x4  == TestData_LHS[i].x4;
                result &= v4_8.x5  == TestData_LHS[i].x5;
                result &= v4_8.x6  == TestData_LHS[i].x6;
                result &= v4_8.x7  == TestData_LHS[i].x7;
                result &= v4_8.x8  == t_short4.TestData_LHS[i].x;
                result &= v4_8.x9  == t_short4.TestData_LHS[i].y;
                result &= v4_8.x10 == t_short4.TestData_LHS[i].z;
                result &= v4_8.x11 == t_short4.TestData_LHS[i].w;
                result &= v4_8.x12 == TestData_LHS[i].x12;
                result &= v4_8.x13 == TestData_LHS[i].x13;
                result &= v4_8.x14 == TestData_LHS[i].x14;
                result &= v4_8.x15 == TestData_LHS[i].x15;

                short16 v4_9 = TestData_LHS[i];
                v4_9.v4_9 = t_short4.TestData_LHS[i];
                result &= v4_9.x0  == TestData_LHS[i].x0;
                result &= v4_9.x1  == TestData_LHS[i].x1;
                result &= v4_9.x2  == TestData_LHS[i].x2;
                result &= v4_9.x3  == TestData_LHS[i].x3;
                result &= v4_9.x4  == TestData_LHS[i].x4;
                result &= v4_9.x5  == TestData_LHS[i].x5;
                result &= v4_9.x6  == TestData_LHS[i].x6;
                result &= v4_9.x7  == TestData_LHS[i].x7;
                result &= v4_9.x8  == TestData_LHS[i].x8;
                result &= v4_9.x9  == t_short4.TestData_LHS[i].x;
                result &= v4_9.x10 == t_short4.TestData_LHS[i].y;
                result &= v4_9.x11 == t_short4.TestData_LHS[i].z;
                result &= v4_9.x12 == t_short4.TestData_LHS[i].w;
                result &= v4_9.x13 == TestData_LHS[i].x13;
                result &= v4_9.x14 == TestData_LHS[i].x14;
                result &= v4_9.x15 == TestData_LHS[i].x15;

                short16 v4_10 = TestData_LHS[i];
                v4_10.v4_10 = t_short4.TestData_LHS[i];
                result &= v4_10.x0  == TestData_LHS[i].x0;
                result &= v4_10.x1  == TestData_LHS[i].x1;
                result &= v4_10.x2  == TestData_LHS[i].x2;
                result &= v4_10.x3  == TestData_LHS[i].x3;
                result &= v4_10.x4  == TestData_LHS[i].x4;
                result &= v4_10.x5  == TestData_LHS[i].x5;
                result &= v4_10.x6  == TestData_LHS[i].x6;
                result &= v4_10.x7  == TestData_LHS[i].x7;
                result &= v4_10.x8  == TestData_LHS[i].x8;
                result &= v4_10.x9  == TestData_LHS[i].x9;
                result &= v4_10.x10 == t_short4.TestData_LHS[i].x;
                result &= v4_10.x11 == t_short4.TestData_LHS[i].y;
                result &= v4_10.x12 == t_short4.TestData_LHS[i].z;
                result &= v4_10.x13 == t_short4.TestData_LHS[i].w;
                result &= v4_10.x14 == TestData_LHS[i].x14;
                result &= v4_10.x15 == TestData_LHS[i].x15;

                short16 v4_11 = TestData_LHS[i];
                v4_11.v4_11 = t_short4.TestData_LHS[i];
                result &= v4_11.x0  == TestData_LHS[i].x0;
                result &= v4_11.x1  == TestData_LHS[i].x1;
                result &= v4_11.x2  == TestData_LHS[i].x2;
                result &= v4_11.x3  == TestData_LHS[i].x3;
                result &= v4_11.x4  == TestData_LHS[i].x4;
                result &= v4_11.x5  == TestData_LHS[i].x5;
                result &= v4_11.x6  == TestData_LHS[i].x6;
                result &= v4_11.x7  == TestData_LHS[i].x7;
                result &= v4_11.x8  == TestData_LHS[i].x8;
                result &= v4_11.x9  == TestData_LHS[i].x9;
                result &= v4_11.x10 == TestData_LHS[i].x10;
                result &= v4_11.x11 == t_short4.TestData_LHS[i].x;
                result &= v4_11.x12 == t_short4.TestData_LHS[i].y;
                result &= v4_11.x13 == t_short4.TestData_LHS[i].z;
                result &= v4_11.x14 == t_short4.TestData_LHS[i].w;
                result &= v4_11.x15 == TestData_LHS[i].x15;

                short16 v4_12 = TestData_LHS[i];
                v4_12.v4_12 = t_short4.TestData_LHS[i];
                result &= v4_12.x0  == TestData_LHS[i].x0;
                result &= v4_12.x1  == TestData_LHS[i].x1;
                result &= v4_12.x2  == TestData_LHS[i].x2;
                result &= v4_12.x3  == TestData_LHS[i].x3;
                result &= v4_12.x4  == TestData_LHS[i].x4;
                result &= v4_12.x5  == TestData_LHS[i].x5;
                result &= v4_12.x6  == TestData_LHS[i].x6;
                result &= v4_12.x7  == TestData_LHS[i].x7;
                result &= v4_12.x8  == TestData_LHS[i].x8;
                result &= v4_12.x9  == TestData_LHS[i].x9;
                result &= v4_12.x10 == TestData_LHS[i].x10;
                result &= v4_12.x11 == TestData_LHS[i].x11;
                result &= v4_12.x12 == t_short4.TestData_LHS[i].x;
                result &= v4_12.x13 == t_short4.TestData_LHS[i].y;
                result &= v4_12.x14 == t_short4.TestData_LHS[i].z;
                result &= v4_12.x15 == t_short4.TestData_LHS[i].w;


                short16 v3_0 = TestData_LHS[i];
                v3_0.v3_0 = t_short3.TestData_LHS[i];
                result &= v3_0.x0  == t_short3.TestData_LHS[i].x;
                result &= v3_0.x1  == t_short3.TestData_LHS[i].y;
                result &= v3_0.x2  == t_short3.TestData_LHS[i].z;
                result &= v3_0.x3  == TestData_LHS[i].x3;
                result &= v3_0.x4  == TestData_LHS[i].x4;
                result &= v3_0.x5  == TestData_LHS[i].x5;
                result &= v3_0.x6  == TestData_LHS[i].x6;
                result &= v3_0.x7  == TestData_LHS[i].x7;
                result &= v3_0.x8  == TestData_LHS[i].x8;
                result &= v3_0.x9  == TestData_LHS[i].x9;
                result &= v3_0.x10 == TestData_LHS[i].x10;
                result &= v3_0.x11 == TestData_LHS[i].x11;
                result &= v3_0.x12 == TestData_LHS[i].x12;
                result &= v3_0.x13 == TestData_LHS[i].x13;
                result &= v3_0.x14 == TestData_LHS[i].x14;
                result &= v3_0.x15 == TestData_LHS[i].x15;

                short16 v3_1 = TestData_LHS[i];
                v3_1.v3_1 = t_short3.TestData_LHS[i];
                result &= v3_1.x0  == TestData_LHS[i].x0;
                result &= v3_1.x1  == t_short3.TestData_LHS[i].x;
                result &= v3_1.x2  == t_short3.TestData_LHS[i].y;
                result &= v3_1.x3  == t_short3.TestData_LHS[i].z;
                result &= v3_1.x4  == TestData_LHS[i].x4;
                result &= v3_1.x5  == TestData_LHS[i].x5;
                result &= v3_1.x6  == TestData_LHS[i].x6;
                result &= v3_1.x7  == TestData_LHS[i].x7;
                result &= v3_1.x8  == TestData_LHS[i].x8;
                result &= v3_1.x9  == TestData_LHS[i].x9;
                result &= v3_1.x10 == TestData_LHS[i].x10;
                result &= v3_1.x11 == TestData_LHS[i].x11;
                result &= v3_1.x12 == TestData_LHS[i].x12;
                result &= v3_1.x13 == TestData_LHS[i].x13;
                result &= v3_1.x14 == TestData_LHS[i].x14;
                result &= v3_1.x15 == TestData_LHS[i].x15;

                short16 v3_2 = TestData_LHS[i];
                v3_2.v3_2 = t_short3.TestData_LHS[i];
                result &= v3_2.x0  == TestData_LHS[i].x0;
                result &= v3_2.x1  == TestData_LHS[i].x1;
                result &= v3_2.x2  == t_short3.TestData_LHS[i].x;
                result &= v3_2.x3  == t_short3.TestData_LHS[i].y;
                result &= v3_2.x4  == t_short3.TestData_LHS[i].z;
                result &= v3_2.x5  == TestData_LHS[i].x5;
                result &= v3_2.x6  == TestData_LHS[i].x6;
                result &= v3_2.x7  == TestData_LHS[i].x7;
                result &= v3_2.x8  == TestData_LHS[i].x8;
                result &= v3_2.x9  == TestData_LHS[i].x9;
                result &= v3_2.x10 == TestData_LHS[i].x10;
                result &= v3_2.x11 == TestData_LHS[i].x11;
                result &= v3_2.x12 == TestData_LHS[i].x12;
                result &= v3_2.x13 == TestData_LHS[i].x13;
                result &= v3_2.x14 == TestData_LHS[i].x14;
                result &= v3_2.x15 == TestData_LHS[i].x15;

                short16 v3_3 = TestData_LHS[i];
                v3_3.v3_3 = t_short3.TestData_LHS[i];
                result &= v3_3.x0  == TestData_LHS[i].x0;
                result &= v3_3.x1  == TestData_LHS[i].x1;
                result &= v3_3.x2  == TestData_LHS[i].x2;
                result &= v3_3.x3  == t_short3.TestData_LHS[i].x;
                result &= v3_3.x4  == t_short3.TestData_LHS[i].y;
                result &= v3_3.x5  == t_short3.TestData_LHS[i].z;
                result &= v3_3.x6  == TestData_LHS[i].x6;
                result &= v3_3.x7  == TestData_LHS[i].x7;
                result &= v3_3.x8  == TestData_LHS[i].x8;
                result &= v3_3.x9  == TestData_LHS[i].x9;
                result &= v3_3.x10 == TestData_LHS[i].x10;
                result &= v3_3.x11 == TestData_LHS[i].x11;
                result &= v3_3.x12 == TestData_LHS[i].x12;
                result &= v3_3.x13 == TestData_LHS[i].x13;
                result &= v3_3.x14 == TestData_LHS[i].x14;
                result &= v3_3.x15 == TestData_LHS[i].x15;

                short16 v3_4 = TestData_LHS[i];
                v3_4.v3_4 = t_short3.TestData_LHS[i];
                result &= v3_4.x0  == TestData_LHS[i].x0;
                result &= v3_4.x1  == TestData_LHS[i].x1;
                result &= v3_4.x2  == TestData_LHS[i].x2;
                result &= v3_4.x3  == TestData_LHS[i].x3;
                result &= v3_4.x4  == t_short3.TestData_LHS[i].x;
                result &= v3_4.x5  == t_short3.TestData_LHS[i].y;
                result &= v3_4.x6  == t_short3.TestData_LHS[i].z;
                result &= v3_4.x7  == TestData_LHS[i].x7;
                result &= v3_4.x8  == TestData_LHS[i].x8;
                result &= v3_4.x9  == TestData_LHS[i].x9;
                result &= v3_4.x10 == TestData_LHS[i].x10;
                result &= v3_4.x11 == TestData_LHS[i].x11;
                result &= v3_4.x12 == TestData_LHS[i].x12;
                result &= v3_4.x13 == TestData_LHS[i].x13;
                result &= v3_4.x14 == TestData_LHS[i].x14;
                result &= v3_4.x15 == TestData_LHS[i].x15;

                short16 v3_5 = TestData_LHS[i];
                v3_5.v3_5 = t_short3.TestData_LHS[i];
                result &= v3_5.x0  == TestData_LHS[i].x0;
                result &= v3_5.x1  == TestData_LHS[i].x1;
                result &= v3_5.x2  == TestData_LHS[i].x2;
                result &= v3_5.x3  == TestData_LHS[i].x3;
                result &= v3_5.x4  == TestData_LHS[i].x4;
                result &= v3_5.x5  == t_short3.TestData_LHS[i].x;
                result &= v3_5.x6  == t_short3.TestData_LHS[i].y;
                result &= v3_5.x7  == t_short3.TestData_LHS[i].z;
                result &= v3_5.x8  == TestData_LHS[i].x8;
                result &= v3_5.x9  == TestData_LHS[i].x9;
                result &= v3_5.x10 == TestData_LHS[i].x10;
                result &= v3_5.x11 == TestData_LHS[i].x11;
                result &= v3_5.x12 == TestData_LHS[i].x12;
                result &= v3_5.x13 == TestData_LHS[i].x13;
                result &= v3_5.x14 == TestData_LHS[i].x14;
                result &= v3_5.x15 == TestData_LHS[i].x15;

                short16 v3_6 = TestData_LHS[i];
                v3_6.v3_6 = t_short3.TestData_LHS[i];
                result &= v3_6.x0  == TestData_LHS[i].x0;
                result &= v3_6.x1  == TestData_LHS[i].x1;
                result &= v3_6.x2  == TestData_LHS[i].x2;
                result &= v3_6.x3  == TestData_LHS[i].x3;
                result &= v3_6.x4  == TestData_LHS[i].x4;
                result &= v3_6.x5  == TestData_LHS[i].x5;
                result &= v3_6.x6  == t_short3.TestData_LHS[i].x;
                result &= v3_6.x7  == t_short3.TestData_LHS[i].y;
                result &= v3_6.x8  == t_short3.TestData_LHS[i].z;
                result &= v3_6.x9  == TestData_LHS[i].x9;
                result &= v3_6.x10 == TestData_LHS[i].x10;
                result &= v3_6.x11 == TestData_LHS[i].x11;
                result &= v3_6.x12 == TestData_LHS[i].x12;
                result &= v3_6.x13 == TestData_LHS[i].x13;
                result &= v3_6.x14 == TestData_LHS[i].x14;
                result &= v3_6.x15 == TestData_LHS[i].x15;

                short16 v3_7 = TestData_LHS[i];
                v3_7.v3_7 = t_short3.TestData_LHS[i];
                result &= v3_7.x0  == TestData_LHS[i].x0;
                result &= v3_7.x1  == TestData_LHS[i].x1;
                result &= v3_7.x2  == TestData_LHS[i].x2;
                result &= v3_7.x3  == TestData_LHS[i].x3;
                result &= v3_7.x4  == TestData_LHS[i].x4;
                result &= v3_7.x5  == TestData_LHS[i].x5;
                result &= v3_7.x6  == TestData_LHS[i].x6;
                result &= v3_7.x7  == t_short3.TestData_LHS[i].x;
                result &= v3_7.x8  == t_short3.TestData_LHS[i].y;
                result &= v3_7.x9  == t_short3.TestData_LHS[i].z;
                result &= v3_7.x10 == TestData_LHS[i].x10;
                result &= v3_7.x11 == TestData_LHS[i].x11;
                result &= v3_7.x12 == TestData_LHS[i].x12;
                result &= v3_7.x13 == TestData_LHS[i].x13;
                result &= v3_7.x14 == TestData_LHS[i].x14;
                result &= v3_7.x15 == TestData_LHS[i].x15;

                short16 v3_8 = TestData_LHS[i];
                v3_8.v3_8 = t_short3.TestData_LHS[i];
                result &= v3_8.x0  == TestData_LHS[i].x0;
                result &= v3_8.x1  == TestData_LHS[i].x1;
                result &= v3_8.x2  == TestData_LHS[i].x2;
                result &= v3_8.x3  == TestData_LHS[i].x3;
                result &= v3_8.x4  == TestData_LHS[i].x4;
                result &= v3_8.x5  == TestData_LHS[i].x5;
                result &= v3_8.x6  == TestData_LHS[i].x6;
                result &= v3_8.x7  == TestData_LHS[i].x7;
                result &= v3_8.x8  == t_short3.TestData_LHS[i].x;
                result &= v3_8.x9  == t_short3.TestData_LHS[i].y;
                result &= v3_8.x10 == t_short3.TestData_LHS[i].z;
                result &= v3_8.x11 == TestData_LHS[i].x11;
                result &= v3_8.x12 == TestData_LHS[i].x12;
                result &= v3_8.x13 == TestData_LHS[i].x13;
                result &= v3_8.x14 == TestData_LHS[i].x14;
                result &= v3_8.x15 == TestData_LHS[i].x15;

                short16 v3_9 = TestData_LHS[i];
                v3_9.v3_9 = t_short3.TestData_LHS[i];
                result &= v3_9.x0  == TestData_LHS[i].x0;
                result &= v3_9.x1  == TestData_LHS[i].x1;
                result &= v3_9.x2  == TestData_LHS[i].x2;
                result &= v3_9.x3  == TestData_LHS[i].x3;
                result &= v3_9.x4  == TestData_LHS[i].x4;
                result &= v3_9.x5  == TestData_LHS[i].x5;
                result &= v3_9.x6  == TestData_LHS[i].x6;
                result &= v3_9.x7  == TestData_LHS[i].x7;
                result &= v3_9.x8  == TestData_LHS[i].x8;
                result &= v3_9.x9  == t_short3.TestData_LHS[i].x;
                result &= v3_9.x10 == t_short3.TestData_LHS[i].y;
                result &= v3_9.x11 == t_short3.TestData_LHS[i].z;
                result &= v3_9.x12 == TestData_LHS[i].x12;
                result &= v3_9.x13 == TestData_LHS[i].x13;
                result &= v3_9.x14 == TestData_LHS[i].x14;
                result &= v3_9.x15 == TestData_LHS[i].x15;

                short16 v3_10 = TestData_LHS[i];
                v3_10.v3_10 = t_short3.TestData_LHS[i];
                result &= v3_10.x0  == TestData_LHS[i].x0;
                result &= v3_10.x1  == TestData_LHS[i].x1;
                result &= v3_10.x2  == TestData_LHS[i].x2;
                result &= v3_10.x3  == TestData_LHS[i].x3;
                result &= v3_10.x4  == TestData_LHS[i].x4;
                result &= v3_10.x5  == TestData_LHS[i].x5;
                result &= v3_10.x6  == TestData_LHS[i].x6;
                result &= v3_10.x7  == TestData_LHS[i].x7;
                result &= v3_10.x8  == TestData_LHS[i].x8;
                result &= v3_10.x9  == TestData_LHS[i].x9;
                result &= v3_10.x10 == t_short3.TestData_LHS[i].x;
                result &= v3_10.x11 == t_short3.TestData_LHS[i].y;
                result &= v3_10.x12 == t_short3.TestData_LHS[i].z;
                result &= v3_10.x13 == TestData_LHS[i].x13;
                result &= v3_10.x14 == TestData_LHS[i].x14;
                result &= v3_10.x15 == TestData_LHS[i].x15;

                short16 v3_11 = TestData_LHS[i];
                v3_11.v3_11 = t_short3.TestData_LHS[i];
                result &= v3_11.x0  == TestData_LHS[i].x0;
                result &= v3_11.x1  == TestData_LHS[i].x1;
                result &= v3_11.x2  == TestData_LHS[i].x2;
                result &= v3_11.x3  == TestData_LHS[i].x3;
                result &= v3_11.x4  == TestData_LHS[i].x4;
                result &= v3_11.x5  == TestData_LHS[i].x5;
                result &= v3_11.x6  == TestData_LHS[i].x6;
                result &= v3_11.x7  == TestData_LHS[i].x7;
                result &= v3_11.x8  == TestData_LHS[i].x8;
                result &= v3_11.x9  == TestData_LHS[i].x9;
                result &= v3_11.x10 == TestData_LHS[i].x10;
                result &= v3_11.x11 == t_short3.TestData_LHS[i].x;
                result &= v3_11.x12 == t_short3.TestData_LHS[i].y;
                result &= v3_11.x13 == t_short3.TestData_LHS[i].z;
                result &= v3_11.x14 == TestData_LHS[i].x14;
                result &= v3_11.x15 == TestData_LHS[i].x15;

                short16 v3_12 = TestData_LHS[i];
                v3_12.v3_12 = t_short3.TestData_LHS[i];
                result &= v3_12.x0  == TestData_LHS[i].x0;
                result &= v3_12.x1  == TestData_LHS[i].x1;
                result &= v3_12.x2  == TestData_LHS[i].x2;
                result &= v3_12.x3  == TestData_LHS[i].x3;
                result &= v3_12.x4  == TestData_LHS[i].x4;
                result &= v3_12.x5  == TestData_LHS[i].x5;
                result &= v3_12.x6  == TestData_LHS[i].x6;
                result &= v3_12.x7  == TestData_LHS[i].x7;
                result &= v3_12.x8  == TestData_LHS[i].x8;
                result &= v3_12.x9  == TestData_LHS[i].x9;
                result &= v3_12.x10 == TestData_LHS[i].x10;
                result &= v3_12.x11 == TestData_LHS[i].x11;
                result &= v3_12.x12 == t_short3.TestData_LHS[i].x;
                result &= v3_12.x13 == t_short3.TestData_LHS[i].y;
                result &= v3_12.x14 == t_short3.TestData_LHS[i].z;
                result &= v3_12.x15 == TestData_LHS[i].x15;

                short16 v3_13 = TestData_LHS[i];
                v3_13.v3_13 = t_short3.TestData_LHS[i];
                result &= v3_13.x0  == TestData_LHS[i].x0;
                result &= v3_13.x1  == TestData_LHS[i].x1;
                result &= v3_13.x2  == TestData_LHS[i].x2;
                result &= v3_13.x3  == TestData_LHS[i].x3;
                result &= v3_13.x4  == TestData_LHS[i].x4;
                result &= v3_13.x5  == TestData_LHS[i].x5;
                result &= v3_13.x6  == TestData_LHS[i].x6;
                result &= v3_13.x7  == TestData_LHS[i].x7;
                result &= v3_13.x8  == TestData_LHS[i].x8;
                result &= v3_13.x9  == TestData_LHS[i].x9;
                result &= v3_13.x10 == TestData_LHS[i].x10;
                result &= v3_13.x11 == TestData_LHS[i].x11;
                result &= v3_13.x12 == TestData_LHS[i].x12;
                result &= v3_13.x13 == t_short3.TestData_LHS[i].x;
                result &= v3_13.x14 == t_short3.TestData_LHS[i].y;
                result &= v3_13.x15 == t_short3.TestData_LHS[i].z;


                short16 v2_0 = TestData_LHS[i];
                v2_0.v2_0 = t_short2.TestData_LHS[i];
                result &= v2_0.x0  == t_short2.TestData_LHS[i].x;
                result &= v2_0.x1  == t_short2.TestData_LHS[i].y;
                result &= v2_0.x2  == TestData_LHS[i].x2;
                result &= v2_0.x3  == TestData_LHS[i].x3;
                result &= v2_0.x4  == TestData_LHS[i].x4;
                result &= v2_0.x5  == TestData_LHS[i].x5;
                result &= v2_0.x6  == TestData_LHS[i].x6;
                result &= v2_0.x7  == TestData_LHS[i].x7;
                result &= v2_0.x8  == TestData_LHS[i].x8;
                result &= v2_0.x9  == TestData_LHS[i].x9;
                result &= v2_0.x10 == TestData_LHS[i].x10;
                result &= v2_0.x11 == TestData_LHS[i].x11;
                result &= v2_0.x12 == TestData_LHS[i].x12;
                result &= v2_0.x13 == TestData_LHS[i].x13;
                result &= v2_0.x14 == TestData_LHS[i].x14;
                result &= v2_0.x15 == TestData_LHS[i].x15;

                short16 v2_1 = TestData_LHS[i];
                v2_1.v2_1 = t_short2.TestData_LHS[i];
                result &= v2_1.x0  == TestData_LHS[i].x0;
                result &= v2_1.x1  == t_short2.TestData_LHS[i].x;
                result &= v2_1.x2  == t_short2.TestData_LHS[i].y;
                result &= v2_1.x3  == TestData_LHS[i].x3;
                result &= v2_1.x4  == TestData_LHS[i].x4;
                result &= v2_1.x5  == TestData_LHS[i].x5;
                result &= v2_1.x6  == TestData_LHS[i].x6;
                result &= v2_1.x7  == TestData_LHS[i].x7;
                result &= v2_1.x8  == TestData_LHS[i].x8;
                result &= v2_1.x9  == TestData_LHS[i].x9;
                result &= v2_1.x10 == TestData_LHS[i].x10;
                result &= v2_1.x11 == TestData_LHS[i].x11;
                result &= v2_1.x12 == TestData_LHS[i].x12;
                result &= v2_1.x13 == TestData_LHS[i].x13;
                result &= v2_1.x14 == TestData_LHS[i].x14;
                result &= v2_1.x15 == TestData_LHS[i].x15;

                short16 v2_2 = TestData_LHS[i];
                v2_2.v2_2 = t_short2.TestData_LHS[i];
                result &= v2_2.x0  == TestData_LHS[i].x0;
                result &= v2_2.x1  == TestData_LHS[i].x1;
                result &= v2_2.x2  == t_short2.TestData_LHS[i].x;
                result &= v2_2.x3  == t_short2.TestData_LHS[i].y;
                result &= v2_2.x4  == TestData_LHS[i].x4;
                result &= v2_2.x5  == TestData_LHS[i].x5;
                result &= v2_2.x6  == TestData_LHS[i].x6;
                result &= v2_2.x7  == TestData_LHS[i].x7;
                result &= v2_2.x8  == TestData_LHS[i].x8;
                result &= v2_2.x9  == TestData_LHS[i].x9;
                result &= v2_2.x10 == TestData_LHS[i].x10;
                result &= v2_2.x11 == TestData_LHS[i].x11;
                result &= v2_2.x12 == TestData_LHS[i].x12;
                result &= v2_2.x13 == TestData_LHS[i].x13;
                result &= v2_2.x14 == TestData_LHS[i].x14;
                result &= v2_2.x15 == TestData_LHS[i].x15;

                short16 v2_3 = TestData_LHS[i];
                v2_3.v2_3 = t_short2.TestData_LHS[i];
                result &= v2_3.x0  == TestData_LHS[i].x0;
                result &= v2_3.x1  == TestData_LHS[i].x1;
                result &= v2_3.x2  == TestData_LHS[i].x2;
                result &= v2_3.x3  == t_short2.TestData_LHS[i].x;
                result &= v2_3.x4  == t_short2.TestData_LHS[i].y;
                result &= v2_3.x5  == TestData_LHS[i].x5;
                result &= v2_3.x6  == TestData_LHS[i].x6;
                result &= v2_3.x7  == TestData_LHS[i].x7;
                result &= v2_3.x8  == TestData_LHS[i].x8;
                result &= v2_3.x9  == TestData_LHS[i].x9;
                result &= v2_3.x10 == TestData_LHS[i].x10;
                result &= v2_3.x11 == TestData_LHS[i].x11;
                result &= v2_3.x12 == TestData_LHS[i].x12;
                result &= v2_3.x13 == TestData_LHS[i].x13;
                result &= v2_3.x14 == TestData_LHS[i].x14;
                result &= v2_3.x15 == TestData_LHS[i].x15;

                short16 v2_4 = TestData_LHS[i];
                v2_4.v2_4 = t_short2.TestData_LHS[i];
                result &= v2_4.x0  == TestData_LHS[i].x0;
                result &= v2_4.x1  == TestData_LHS[i].x1;
                result &= v2_4.x2  == TestData_LHS[i].x2;
                result &= v2_4.x3  == TestData_LHS[i].x3;
                result &= v2_4.x4  == t_short2.TestData_LHS[i].x;
                result &= v2_4.x5  == t_short2.TestData_LHS[i].y;
                result &= v2_4.x6  == TestData_LHS[i].x6;
                result &= v2_4.x7  == TestData_LHS[i].x7;
                result &= v2_4.x8  == TestData_LHS[i].x8;
                result &= v2_4.x9  == TestData_LHS[i].x9;
                result &= v2_4.x10 == TestData_LHS[i].x10;
                result &= v2_4.x11 == TestData_LHS[i].x11;
                result &= v2_4.x12 == TestData_LHS[i].x12;
                result &= v2_4.x13 == TestData_LHS[i].x13;
                result &= v2_4.x14 == TestData_LHS[i].x14;
                result &= v2_4.x15 == TestData_LHS[i].x15;

                short16 v2_5 = TestData_LHS[i];
                v2_5.v2_5 = t_short2.TestData_LHS[i];
                result &= v2_5.x0  == TestData_LHS[i].x0;
                result &= v2_5.x1  == TestData_LHS[i].x1;
                result &= v2_5.x2  == TestData_LHS[i].x2;
                result &= v2_5.x3  == TestData_LHS[i].x3;
                result &= v2_5.x4  == TestData_LHS[i].x4;
                result &= v2_5.x5  == t_short2.TestData_LHS[i].x;
                result &= v2_5.x6  == t_short2.TestData_LHS[i].y;
                result &= v2_5.x7  == TestData_LHS[i].x7;
                result &= v2_5.x8  == TestData_LHS[i].x8;
                result &= v2_5.x9  == TestData_LHS[i].x9;
                result &= v2_5.x10 == TestData_LHS[i].x10;
                result &= v2_5.x11 == TestData_LHS[i].x11;
                result &= v2_5.x12 == TestData_LHS[i].x12;
                result &= v2_5.x13 == TestData_LHS[i].x13;
                result &= v2_5.x14 == TestData_LHS[i].x14;
                result &= v2_5.x15 == TestData_LHS[i].x15;

                short16 v2_6 = TestData_LHS[i];
                v2_6.v2_6 = t_short2.TestData_LHS[i];
                result &= v2_6.x0  == TestData_LHS[i].x0;
                result &= v2_6.x1  == TestData_LHS[i].x1;
                result &= v2_6.x2  == TestData_LHS[i].x2;
                result &= v2_6.x3  == TestData_LHS[i].x3;
                result &= v2_6.x4  == TestData_LHS[i].x4;
                result &= v2_6.x5  == TestData_LHS[i].x5;
                result &= v2_6.x6  == t_short2.TestData_LHS[i].x;
                result &= v2_6.x7  == t_short2.TestData_LHS[i].y;
                result &= v2_6.x8  == TestData_LHS[i].x8;
                result &= v2_6.x9  == TestData_LHS[i].x9;
                result &= v2_6.x10 == TestData_LHS[i].x10;
                result &= v2_6.x11 == TestData_LHS[i].x11;
                result &= v2_6.x12 == TestData_LHS[i].x12;
                result &= v2_6.x13 == TestData_LHS[i].x13;
                result &= v2_6.x14 == TestData_LHS[i].x14;
                result &= v2_6.x15 == TestData_LHS[i].x15;

                short16 v2_7 = TestData_LHS[i];
                v2_7.v2_7 = t_short2.TestData_LHS[i];
                result &= v2_7.x0  == TestData_LHS[i].x0;
                result &= v2_7.x1  == TestData_LHS[i].x1;
                result &= v2_7.x2  == TestData_LHS[i].x2;
                result &= v2_7.x3  == TestData_LHS[i].x3;
                result &= v2_7.x4  == TestData_LHS[i].x4;
                result &= v2_7.x5  == TestData_LHS[i].x5;
                result &= v2_7.x6  == TestData_LHS[i].x6;
                result &= v2_7.x7  == t_short2.TestData_LHS[i].x;
                result &= v2_7.x8  == t_short2.TestData_LHS[i].y;
                result &= v2_7.x9  == TestData_LHS[i].x9;
                result &= v2_7.x10 == TestData_LHS[i].x10;
                result &= v2_7.x11 == TestData_LHS[i].x11;
                result &= v2_7.x12 == TestData_LHS[i].x12;
                result &= v2_7.x13 == TestData_LHS[i].x13;
                result &= v2_7.x14 == TestData_LHS[i].x14;
                result &= v2_7.x15 == TestData_LHS[i].x15;

                short16 v2_8 = TestData_LHS[i];
                v2_8.v2_8 = t_short2.TestData_LHS[i];
                result &= v2_8.x0  == TestData_LHS[i].x0;
                result &= v2_8.x1  == TestData_LHS[i].x1;
                result &= v2_8.x2  == TestData_LHS[i].x2;
                result &= v2_8.x3  == TestData_LHS[i].x3;
                result &= v2_8.x4  == TestData_LHS[i].x4;
                result &= v2_8.x5  == TestData_LHS[i].x5;
                result &= v2_8.x6  == TestData_LHS[i].x6;
                result &= v2_8.x7  == TestData_LHS[i].x7;
                result &= v2_8.x8  == t_short2.TestData_LHS[i].x;
                result &= v2_8.x9  == t_short2.TestData_LHS[i].y;
                result &= v2_8.x10 == TestData_LHS[i].x10;
                result &= v2_8.x11 == TestData_LHS[i].x11;
                result &= v2_8.x12 == TestData_LHS[i].x12;
                result &= v2_8.x13 == TestData_LHS[i].x13;
                result &= v2_8.x14 == TestData_LHS[i].x14;
                result &= v2_8.x15 == TestData_LHS[i].x15;

                short16 v2_9 = TestData_LHS[i];
                v2_9.v2_9 = t_short2.TestData_LHS[i];
                result &= v2_9.x0  == TestData_LHS[i].x0;
                result &= v2_9.x1  == TestData_LHS[i].x1;
                result &= v2_9.x2  == TestData_LHS[i].x2;
                result &= v2_9.x3  == TestData_LHS[i].x3;
                result &= v2_9.x4  == TestData_LHS[i].x4;
                result &= v2_9.x5  == TestData_LHS[i].x5;
                result &= v2_9.x6  == TestData_LHS[i].x6;
                result &= v2_9.x7  == TestData_LHS[i].x7;
                result &= v2_9.x8  == TestData_LHS[i].x8;
                result &= v2_9.x9  == t_short2.TestData_LHS[i].x;
                result &= v2_9.x10 == t_short2.TestData_LHS[i].y;
                result &= v2_9.x11 == TestData_LHS[i].x11;
                result &= v2_9.x12 == TestData_LHS[i].x12;
                result &= v2_9.x13 == TestData_LHS[i].x13;
                result &= v2_9.x14 == TestData_LHS[i].x14;
                result &= v2_9.x15 == TestData_LHS[i].x15;

                short16 v2_10 = TestData_LHS[i];
                v2_10.v2_10 = t_short2.TestData_LHS[i];
                result &= v2_10.x0  == TestData_LHS[i].x0;
                result &= v2_10.x1  == TestData_LHS[i].x1;
                result &= v2_10.x2  == TestData_LHS[i].x2;
                result &= v2_10.x3  == TestData_LHS[i].x3;
                result &= v2_10.x4  == TestData_LHS[i].x4;
                result &= v2_10.x5  == TestData_LHS[i].x5;
                result &= v2_10.x6  == TestData_LHS[i].x6;
                result &= v2_10.x7  == TestData_LHS[i].x7;
                result &= v2_10.x8  == TestData_LHS[i].x8;
                result &= v2_10.x9  == TestData_LHS[i].x9;
                result &= v2_10.x10 == t_short2.TestData_LHS[i].x;
                result &= v2_10.x11 == t_short2.TestData_LHS[i].y;
                result &= v2_10.x12 == TestData_LHS[i].x12;
                result &= v2_10.x13 == TestData_LHS[i].x13;
                result &= v2_10.x14 == TestData_LHS[i].x14;
                result &= v2_10.x15 == TestData_LHS[i].x15;

                short16 v2_11 = TestData_LHS[i];
                v2_11.v2_11 = t_short2.TestData_LHS[i];
                result &= v2_11.x0  == TestData_LHS[i].x0;
                result &= v2_11.x1  == TestData_LHS[i].x1;
                result &= v2_11.x2  == TestData_LHS[i].x2;
                result &= v2_11.x3  == TestData_LHS[i].x3;
                result &= v2_11.x4  == TestData_LHS[i].x4;
                result &= v2_11.x5  == TestData_LHS[i].x5;
                result &= v2_11.x6  == TestData_LHS[i].x6;
                result &= v2_11.x7  == TestData_LHS[i].x7;
                result &= v2_11.x8  == TestData_LHS[i].x8;
                result &= v2_11.x9  == TestData_LHS[i].x9;
                result &= v2_11.x10 == TestData_LHS[i].x10;
                result &= v2_11.x11 == t_short2.TestData_LHS[i].x;
                result &= v2_11.x12 == t_short2.TestData_LHS[i].y;
                result &= v2_11.x13 == TestData_LHS[i].x13;
                result &= v2_11.x14 == TestData_LHS[i].x14;
                result &= v2_11.x15 == TestData_LHS[i].x15;

                short16 v2_12 = TestData_LHS[i];
                v2_12.v2_12 = t_short2.TestData_LHS[i];
                result &= v2_12.x0  == TestData_LHS[i].x0;
                result &= v2_12.x1  == TestData_LHS[i].x1;
                result &= v2_12.x2  == TestData_LHS[i].x2;
                result &= v2_12.x3  == TestData_LHS[i].x3;
                result &= v2_12.x4  == TestData_LHS[i].x4;
                result &= v2_12.x5  == TestData_LHS[i].x5;
                result &= v2_12.x6  == TestData_LHS[i].x6;
                result &= v2_12.x7  == TestData_LHS[i].x7;
                result &= v2_12.x8  == TestData_LHS[i].x8;
                result &= v2_12.x9  == TestData_LHS[i].x9;
                result &= v2_12.x10 == TestData_LHS[i].x10;
                result &= v2_12.x11 == TestData_LHS[i].x11;
                result &= v2_12.x12 == t_short2.TestData_LHS[i].x;
                result &= v2_12.x13 == t_short2.TestData_LHS[i].y;
                result &= v2_12.x14 == TestData_LHS[i].x14;
                result &= v2_12.x15 == TestData_LHS[i].x15;

                short16 v2_13 = TestData_LHS[i];
                v2_13.v2_13 = t_short2.TestData_LHS[i];
                result &= v2_13.x0  == TestData_LHS[i].x0;
                result &= v2_13.x1  == TestData_LHS[i].x1;
                result &= v2_13.x2  == TestData_LHS[i].x2;
                result &= v2_13.x3  == TestData_LHS[i].x3;
                result &= v2_13.x4  == TestData_LHS[i].x4;
                result &= v2_13.x5  == TestData_LHS[i].x5;
                result &= v2_13.x6  == TestData_LHS[i].x6;
                result &= v2_13.x7  == TestData_LHS[i].x7;
                result &= v2_13.x8  == TestData_LHS[i].x8;
                result &= v2_13.x9  == TestData_LHS[i].x9;
                result &= v2_13.x10 == TestData_LHS[i].x10;
                result &= v2_13.x11 == TestData_LHS[i].x11;
                result &= v2_13.x12 == TestData_LHS[i].x12;
                result &= v2_13.x13 == t_short2.TestData_LHS[i].x;
                result &= v2_13.x14 == t_short2.TestData_LHS[i].y;
                result &= v2_13.x15 == TestData_LHS[i].x15;

                short16 v2_14 = TestData_LHS[i];
                v2_14.v2_14 = t_short2.TestData_LHS[i];
                result &= v2_14.x0  == TestData_LHS[i].x0;
                result &= v2_14.x1  == TestData_LHS[i].x1;
                result &= v2_14.x2  == TestData_LHS[i].x2;
                result &= v2_14.x3  == TestData_LHS[i].x3;
                result &= v2_14.x4  == TestData_LHS[i].x4;
                result &= v2_14.x5  == TestData_LHS[i].x5;
                result &= v2_14.x6  == TestData_LHS[i].x6;
                result &= v2_14.x7  == TestData_LHS[i].x7;
                result &= v2_14.x8  == TestData_LHS[i].x8;
                result &= v2_14.x9  == TestData_LHS[i].x9;
                result &= v2_14.x10 == TestData_LHS[i].x10;
                result &= v2_14.x11 == TestData_LHS[i].x11;
                result &= v2_14.x12 == TestData_LHS[i].x12;
                result &= v2_14.x13 == TestData_LHS[i].x13;
                result &= v2_14.x14 == t_short2.TestData_LHS[i].x;
                result &= v2_14.x15 == t_short2.TestData_LHS[i].y;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v256 x = TestData_LHS[i];

                result &= x.SShort0 == TestData_LHS[i].x0 &
                          x.SShort1 == TestData_LHS[i].x1 &
                          x.SShort2 == TestData_LHS[i].x2 &
                          x.SShort3 == TestData_LHS[i].x3 &
                          x.SShort4 == TestData_LHS[i].x4 &
                          x.SShort5 == TestData_LHS[i].x5 &
                          x.SShort6 == TestData_LHS[i].x6 &
                          x.SShort7 == TestData_LHS[i].x7 &
                          x.SShort8 == TestData_LHS[i].x8 &
                          x.SShort9 == TestData_LHS[i].x9 &
                          x.SShort10 == TestData_LHS[i].x10 &
                          x.SShort11 == TestData_LHS[i].x11 &
                          x.SShort12 == TestData_LHS[i].x12 &
                          x.SShort13 == TestData_LHS[i].x13 &
                          x.SShort14 == TestData_LHS[i].x14 &
                          x.SShort15 == TestData_LHS[i].x15;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i];
                v256 c = x;
                x = c;

                result &= x.x0 == TestData_LHS[i].x0 &
                          x.x1 == TestData_LHS[i].x1 &
                          x.x2 == TestData_LHS[i].x2 &
                          x.x3 == TestData_LHS[i].x3 &
                          x.x4 == TestData_LHS[i].x4 &
                          x.x5 == TestData_LHS[i].x5 &
                          x.x6 == TestData_LHS[i].x6 &
                          x.x7 == TestData_LHS[i].x7 &
                          x.x8 == TestData_LHS[i].x8 &
                          x.x9 == TestData_LHS[i].x9 &
                          x.x10 == TestData_LHS[i].x10 &
                          x.x11 == TestData_LHS[i].x11 &
                          x.x12 == TestData_LHS[i].x12 &
                          x.x13 == TestData_LHS[i].x13 &
                          x.x14 == TestData_LHS[i].x14 &
                          x.x15 == TestData_LHS[i].x15;
            }

            Assert.AreEqual(true, result);
        }


        [Test]
        public static void Cast_ToByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                byte16 x = (byte16)TestData_LHS[i];

                result &= x.x0 ==  (byte)TestData_LHS[i].x0 &
                          x.x1 ==  (byte)TestData_LHS[i].x1 &
                          x.x2 ==  (byte)TestData_LHS[i].x2 &
                          x.x3 ==  (byte)TestData_LHS[i].x3 &
                          x.x4 ==  (byte)TestData_LHS[i].x4 &
                          x.x5 ==  (byte)TestData_LHS[i].x5 &
                          x.x6 ==  (byte)TestData_LHS[i].x6 &
                          x.x7 ==  (byte)TestData_LHS[i].x7 &
                          x.x8 ==  (byte)TestData_LHS[i].x8 &
                          x.x9 ==  (byte)TestData_LHS[i].x9 &
                          x.x10 == (byte)TestData_LHS[i].x10 &
                          x.x11 == (byte)TestData_LHS[i].x11 &
                          x.x12 == (byte)TestData_LHS[i].x12 &
                          x.x13 == (byte)TestData_LHS[i].x13 &
                          x.x14 == (byte)TestData_LHS[i].x14 &
                          x.x15 == (byte)TestData_LHS[i].x15;
            }

            Assert.AreEqual(true, result);
        }

        [Test]
        public static void Cast_ToSByte()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = (sbyte16)TestData_LHS[i];

                result &= x.x0 ==  (sbyte)TestData_LHS[i].x0 &
                          x.x1 ==  (sbyte)TestData_LHS[i].x1 &
                          x.x2 ==  (sbyte)TestData_LHS[i].x2 &
                          x.x3 ==  (sbyte)TestData_LHS[i].x3 &
                          x.x4 ==  (sbyte)TestData_LHS[i].x4 &
                          x.x5 ==  (sbyte)TestData_LHS[i].x5 &
                          x.x6 ==  (sbyte)TestData_LHS[i].x6 &
                          x.x7 ==  (sbyte)TestData_LHS[i].x7 &
                          x.x8 ==  (sbyte)TestData_LHS[i].x8 &
                          x.x9 ==  (sbyte)TestData_LHS[i].x9 &
                          x.x10 == (sbyte)TestData_LHS[i].x10 &
                          x.x11 == (sbyte)TestData_LHS[i].x11 &
                          x.x12 == (sbyte)TestData_LHS[i].x12 &
                          x.x13 == (sbyte)TestData_LHS[i].x13 &
                          x.x14 == (sbyte)TestData_LHS[i].x14 &
                          x.x15 == (sbyte)TestData_LHS[i].x15;
            }

            Assert.AreEqual(true, result);
        }
    }
}