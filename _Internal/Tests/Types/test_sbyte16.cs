using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
    unsafe public static class SByte16
    {
        internal const int NUM_TESTS = 4;


        internal static sbyte16[] TestData_LHS => new sbyte16[]
        {
            new sbyte16{x0  = -83,
					    x1  = 55,
					    x2  = 99,
					    x3  = 76,
					    x4  = 65,
					    x5  = -1,
					    x6  = -11,
					    x7  = 35,
					    x8  = 75,
					    x9  = 99,
					    x10 = -11,
					    x11 = 54,
					    x12 = 68,
					    x13 = 32,
					    x14 = -54,
					    x15 = -77},
					   
            new sbyte16{x0  = 22,
					    x1  = -12,
					    x2  = 16,
					    x3  = -11,
					    x4  = 99,
					    x5  = 80,
					    x6  = -54,
					    x7  = 39,
					    x8  = 76,
					    x9  = 65,
					    x10 = -1,
					    x11 = -11,
					    x12 = 35,
					    x13 = 75,
					    x14 = 99,
					    x15 = -11},
					         // EQUAL
            new sbyte16{x0  = 87,
					    x1  = sbyte.MaxValue,
					    x2  = 17,
					    x3  = 21,
					    x4  = 0,
					    x5  = 47,
					    x6  = 32,
					    x7  = -56,
					    x8  = 87,
					    x9  = 21,
					    x10 = 47,
					    x11 = -70,
					    x12 = 54,
					    x13 = -22,
					    x14 = 12,
					    x15 = 88},
					   
            new sbyte16{x0  = sbyte.MinValue,
					    x1  = 13,
					    x2  = 111,
					    x3  = 66,
					    x4  = -99,
					    x5  = 39,
					    x6  = -50,
					    x7  = 121,
					    x8  = 3,
					    x9  = 32,
					    x10 = -98,
					    x11 = 6,
					    x12 = 34,
					    x13 = 124,
					    x14 = 15,
					    x15 = 99}
        };

        internal static sbyte16[] TestData_RHS => new sbyte16[]
        {
            new sbyte16{x0  = 12,
					    x1  = 8,
					    x2  = 53,
					    x3  = 98,
					    x4  = 2,
					    x5  = -73,
					    x6  = 97,
					    x7  = 44,
					    x8  = 87,
					    x9  = -19,
					    x10 = -82,
					    x11 = 43,
					    x12 = -11,
					    x13 = 35,
					    x14 = 75,
					    x15 = -99},
					   
            new sbyte16{x0  = 22,
					    x1  = -12,
					    x2  = 16,
					    x3  = -11,
					    x4  = 99,
					    x5  = 80,
					    x6  = -54,
					    x7  = 39,
					    x8  = 76,
					    x9  = 65,
					    x10 = -1,
					    x11 = -11,
					    x12 = 35,
					    x13 = 75,
					    x14 = 99,
                        x15 = -11},
					         // EQUAL
            new sbyte16{x0  = 17,
					    x1  = 87,
					    x2  = 9,
					    x3  = -82,
					    x4  = -39,
					    x5  = 45,
					    x6  = 90,
					    x7  = -62,
					    x8  = -77,
					    x9  = 12,
					    x10 = 47,
					    x11 = -49,
					    x12 = 65,
					    x13 = 7,
					    x14 = -127,
					    x15 = 88},
					   
            new sbyte16{x0  = 2,
					    x1  = 9,
					    x2  = -20,
					    x3  = -92,
					    x4  = 87,
					    x5  = -19,
					    x6  = -82,
					    x7  = 43,
					    x8  = 43,
					    x9  = 2,
					    x10 = -42,
					    x11 = 99,
					    x12 = -58,
					    x13 = 92,
					    x14 = 13,
                        x15 = 21}
        };


        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte_SByte()
        {
            sbyte16 x = new sbyte16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15);

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte()
        {
            sbyte16 x = new sbyte16(TestData_LHS[0].x0);

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x0;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte2_SByte2_SByte2_SByte2_SByte2_SByte2_SByte2_SByte2()
        {
            sbyte16 x = new sbyte16(new sbyte2(TestData_LHS[0].x0, TestData_LHS[0].x1), new sbyte2(TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte2(TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte2(TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte2(TestData_LHS[0].x8, TestData_LHS[0].x9), new sbyte2(TestData_LHS[0].x10, TestData_LHS[0].x11), new sbyte2(TestData_LHS[0].x12, TestData_LHS[0].x13), new sbyte2(TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte4_SByte4_SByte4_SByte4()
        {
            sbyte16 x = new sbyte16(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new sbyte4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte4_SByte3_SByte3_SByte3_SByte3()
        {
            sbyte16 x = new sbyte16(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte3(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new sbyte3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new sbyte3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new sbyte3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte3_SByte4_SByte3_SByte3_SByte3()
        {
            sbyte16 x = new sbyte16(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte4(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new sbyte3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new sbyte3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new sbyte3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte3_SByte3_SByte4_SByte3_SByte3()
        {
            sbyte16 x = new sbyte16(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte4(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new sbyte3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new sbyte3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte3_SByte3_SByte3_SByte4_SByte3()
        {
            sbyte16 x = new sbyte16(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new sbyte4(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new sbyte3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte3_SByte3_SByte3_SByte3_SByte4()
        {
            sbyte16 x = new sbyte16(new sbyte3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new sbyte3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new sbyte3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new sbyte3(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new sbyte4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte8_SByte4_SByte4()
        {
            sbyte16 x = new sbyte16(new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new sbyte4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }
        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte4_SByte8_SByte4()
        {
            sbyte16 x = new sbyte16(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte8(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new sbyte4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte4_SByte4_SByte8()
        {
            sbyte16 x = new sbyte16(new sbyte4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new sbyte4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Constructor_SByte8_SByte8()
        {
            sbyte16 x = new sbyte16(new sbyte8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new sbyte8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

            return x.x0 == TestData_LHS[0].x0 &
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
                   x.x15 == TestData_LHS[0].x15;
        }
        [UnitTest("Types", "sbyte16")]
        public static bool Indexer()
        {
            return TestData_LHS[0][0] == TestData_LHS[0].x0 &
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
                   TestData_LHS[0][15] == TestData_LHS[0].x15;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool Add()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] + TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  + TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  + TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  + TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  + TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  + TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  + TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  + TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  + TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  + TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  + TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 + TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 + TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 + TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 + TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 + TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 + TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Subtract()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] - TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  - TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  - TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  - TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  - TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  - TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  - TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  - TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  - TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  - TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  - TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 - TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 - TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 - TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 - TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 - TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 - TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Multiply()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] * TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  * TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  * TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  * TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  * TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  * TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  * TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  * TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  * TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  * TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  * TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 * TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 * TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 * TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 * TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 * TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 * TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Divide()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] / TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  / TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  / TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  / TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  / TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  / TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  / TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  / TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  / TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  / TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  / TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 / TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 / TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 / TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 / TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 / TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 / TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Remainder()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] % TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  % TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  % TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  % TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  % TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  % TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  % TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  % TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  % TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  % TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  % TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 % TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 % TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 % TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 % TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 % TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 % TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Negate()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = -TestData_LHS[i];

                result &= x.x0 ==  (sbyte)(-TestData_LHS[i].x0) &
                          x.x1 ==  (sbyte)(-TestData_LHS[i].x1) &
                          x.x2 ==  (sbyte)(-TestData_LHS[i].x2) &
                          x.x3 ==  (sbyte)(-TestData_LHS[i].x3) &
                          x.x4 ==  (sbyte)(-TestData_LHS[i].x4) &
                          x.x5 ==  (sbyte)(-TestData_LHS[i].x5) &
                          x.x6 ==  (sbyte)(-TestData_LHS[i].x6) &
                          x.x7 ==  (sbyte)(-TestData_LHS[i].x7) &
                          x.x8 ==  (sbyte)(-TestData_LHS[i].x8) &
                          x.x9 ==  (sbyte)(-TestData_LHS[i].x9) &
                          x.x10 == (sbyte)(-TestData_LHS[i].x10) &
                          x.x11 == (sbyte)(-TestData_LHS[i].x11) &
                          x.x12 == (sbyte)(-TestData_LHS[i].x12) &
                          x.x13 == (sbyte)(-TestData_LHS[i].x13) &
                          x.x14 == (sbyte)(-TestData_LHS[i].x14) &
                          x.x15 == (sbyte)(-TestData_LHS[i].x15); ;
            }

            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool AND()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] & TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  & TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  & TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  & TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  & TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  & TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  & TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  & TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  & TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  & TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  & TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 & TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 & TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 & TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 & TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 & TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 & TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool OR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] | TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  | TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  | TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  | TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  | TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  | TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  | TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  | TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  | TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  | TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  | TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 | TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 | TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 | TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 | TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 | TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 | TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool XOR()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i] ^ TestData_RHS[i];

                result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  ^ TestData_RHS[i].x0)  & 
                          x.x1 ==  (sbyte)(TestData_LHS[i].x1  ^ TestData_RHS[i].x1)  &
                          x.x2 ==  (sbyte)(TestData_LHS[i].x2  ^ TestData_RHS[i].x2)  &
                          x.x3 ==  (sbyte)(TestData_LHS[i].x3  ^ TestData_RHS[i].x3)  &
                          x.x4 ==  (sbyte)(TestData_LHS[i].x4  ^ TestData_RHS[i].x4)  &
                          x.x5 ==  (sbyte)(TestData_LHS[i].x5  ^ TestData_RHS[i].x5)  &
                          x.x6 ==  (sbyte)(TestData_LHS[i].x6  ^ TestData_RHS[i].x6)  &
                          x.x7 ==  (sbyte)(TestData_LHS[i].x7  ^ TestData_RHS[i].x7)  &
                          x.x8 ==  (sbyte)(TestData_LHS[i].x8  ^ TestData_RHS[i].x8)  &
                          x.x9 ==  (sbyte)(TestData_LHS[i].x9  ^ TestData_RHS[i].x9)  &
                          x.x10 == (sbyte)(TestData_LHS[i].x10 ^ TestData_RHS[i].x10) &
                          x.x11 == (sbyte)(TestData_LHS[i].x11 ^ TestData_RHS[i].x11) &
                          x.x12 == (sbyte)(TestData_LHS[i].x12 ^ TestData_RHS[i].x12) &
                          x.x13 == (sbyte)(TestData_LHS[i].x13 ^ TestData_RHS[i].x13) &
                          x.x14 == (sbyte)(TestData_LHS[i].x14 ^ TestData_RHS[i].x14) &
                          x.x15 == (sbyte)(TestData_LHS[i].x15 ^ TestData_RHS[i].x15);
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool NOT()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = ~TestData_LHS[i];

                result &= x.x0 ==  (sbyte)(~TestData_LHS[i].x0)  &
                          x.x1 ==  (sbyte)(~TestData_LHS[i].x1)  &
                          x.x2 ==  (sbyte)(~TestData_LHS[i].x2)  &
                          x.x3 ==  (sbyte)(~TestData_LHS[i].x3)  &
                          x.x4 ==  (sbyte)(~TestData_LHS[i].x4)  &
                          x.x5 ==  (sbyte)(~TestData_LHS[i].x5)  &
                          x.x6 ==  (sbyte)(~TestData_LHS[i].x6)  &
                          x.x7 ==  (sbyte)(~TestData_LHS[i].x7)  &
                          x.x8 ==  (sbyte)(~TestData_LHS[i].x8)  &
                          x.x9 ==  (sbyte)(~TestData_LHS[i].x9)  &
                          x.x10 == (sbyte)(~TestData_LHS[i].x10) &
                          x.x11 == (sbyte)(~TestData_LHS[i].x11) &
                          x.x12 == (sbyte)(~TestData_LHS[i].x12) &
                          x.x13 == (sbyte)(~TestData_LHS[i].x13) &
                          x.x14 == (sbyte)(~TestData_LHS[i].x14) &
                          x.x15 == (sbyte)(~TestData_LHS[i].x15); ;
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte16 x = TestData_LHS[i] << j;

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  << j) & 
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  << j) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  << j) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  << j) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  << j) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  << j) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  << j) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  << j) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  << j) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  << j) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 << j) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 << j) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 << j) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 << j) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 << j) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 << j);
                }
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    sbyte16 x = TestData_LHS[i] >> j;

                    result &= x.x0 ==  (sbyte)(TestData_LHS[i].x0  >> j) & 
                              x.x1 ==  (sbyte)(TestData_LHS[i].x1  >> j) &
                              x.x2 ==  (sbyte)(TestData_LHS[i].x2  >> j) &
                              x.x3 ==  (sbyte)(TestData_LHS[i].x3  >> j) &
                              x.x4 ==  (sbyte)(TestData_LHS[i].x4  >> j) &
                              x.x5 ==  (sbyte)(TestData_LHS[i].x5  >> j) &
                              x.x6 ==  (sbyte)(TestData_LHS[i].x6  >> j) &
                              x.x7 ==  (sbyte)(TestData_LHS[i].x7  >> j) &
                              x.x8 ==  (sbyte)(TestData_LHS[i].x8  >> j) &
                              x.x9 ==  (sbyte)(TestData_LHS[i].x9  >> j) &
                              x.x10 == (sbyte)(TestData_LHS[i].x10 >> j) &
                              x.x11 == (sbyte)(TestData_LHS[i].x11 >> j) &
                              x.x12 == (sbyte)(TestData_LHS[i].x12 >> j) &
                              x.x13 == (sbyte)(TestData_LHS[i].x13 >> j) &
                              x.x14 == (sbyte)(TestData_LHS[i].x14 >> j) &
                              x.x15 == (sbyte)(TestData_LHS[i].x15 >> j);
                }
            }

            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool Equal()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] == TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  == TestData_RHS[i].x0,
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

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool LessThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] < TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  < TestData_RHS[i].x0,
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

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool GreaterThan()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] > TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  > TestData_RHS[i].x0,
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

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool NotEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] != TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  != TestData_RHS[i].x0,
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

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool LessThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] <= TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  <= TestData_RHS[i].x0,
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

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool GreaterThanOrEqual()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                bool4x4 x = TestData_LHS[i] >= TestData_RHS[i];

                result &= x.Equals(new bool4x4(new bool4(TestData_LHS[i].x0  >= TestData_RHS[i].x0,
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

            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool AllEqual()
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

            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool Shuffle()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte8 v8_0 = TestData_LHS[i].v8_0;
                result &= v8_0.x0 == TestData_LHS[i].x0 &
                          v8_0.x1 == TestData_LHS[i].x1 &
                          v8_0.x2 == TestData_LHS[i].x2 &
                          v8_0.x3 == TestData_LHS[i].x3 &
                          v8_0.x4 == TestData_LHS[i].x4 &
                          v8_0.x5 == TestData_LHS[i].x5 &
                          v8_0.x6 == TestData_LHS[i].x6 &
                          v8_0.x7 == TestData_LHS[i].x7;

                sbyte8 v8_1 = TestData_LHS[i].v8_1;
                result &= v8_1.x0 == TestData_LHS[i].x1 &
                          v8_1.x1 == TestData_LHS[i].x2 &
                          v8_1.x2 == TestData_LHS[i].x3 &
                          v8_1.x3 == TestData_LHS[i].x4 &
                          v8_1.x4 == TestData_LHS[i].x5 &
                          v8_1.x5 == TestData_LHS[i].x6 &
                          v8_1.x6 == TestData_LHS[i].x7 &
                          v8_1.x7 == TestData_LHS[i].x8;

                sbyte8 v8_2 = TestData_LHS[i].v8_2;
                result &= v8_2.x0 == TestData_LHS[i].x2 &
                          v8_2.x1 == TestData_LHS[i].x3 &
                          v8_2.x2 == TestData_LHS[i].x4 &
                          v8_2.x3 == TestData_LHS[i].x5 &
                          v8_2.x4 == TestData_LHS[i].x6 &
                          v8_2.x5 == TestData_LHS[i].x7 &
                          v8_2.x6 == TestData_LHS[i].x8 &
                          v8_2.x7 == TestData_LHS[i].x9;

                sbyte8 v8_3 = TestData_LHS[i].v8_3;
                result &= v8_3.x0 == TestData_LHS[i].x3 &
                          v8_3.x1 == TestData_LHS[i].x4 &
                          v8_3.x2 == TestData_LHS[i].x5 &
                          v8_3.x3 == TestData_LHS[i].x6 &
                          v8_3.x4 == TestData_LHS[i].x7 &
                          v8_3.x5 == TestData_LHS[i].x8 &
                          v8_3.x6 == TestData_LHS[i].x9 &
                          v8_3.x7 == TestData_LHS[i].x10;

                sbyte8 v8_4 = TestData_LHS[i].v8_4;
                result &= v8_4.x0 == TestData_LHS[i].x4 &
                          v8_4.x1 == TestData_LHS[i].x5 &
                          v8_4.x2 == TestData_LHS[i].x6 &
                          v8_4.x3 == TestData_LHS[i].x7 &
                          v8_4.x4 == TestData_LHS[i].x8 &
                          v8_4.x5 == TestData_LHS[i].x9 &
                          v8_4.x6 == TestData_LHS[i].x10 &
                          v8_4.x7 == TestData_LHS[i].x11;

                sbyte8 v8_5 = TestData_LHS[i].v8_5;
                result &= v8_5.x0 == TestData_LHS[i].x5 &
                          v8_5.x1 == TestData_LHS[i].x6 &
                          v8_5.x2 == TestData_LHS[i].x7 &
                          v8_5.x3 == TestData_LHS[i].x8 &
                          v8_5.x4 == TestData_LHS[i].x9 &
                          v8_5.x5 == TestData_LHS[i].x10 &
                          v8_5.x6 == TestData_LHS[i].x11 &
                          v8_5.x7 == TestData_LHS[i].x12;

                sbyte8 v8_6 = TestData_LHS[i].v8_6;
                result &= v8_6.x0 == TestData_LHS[i].x6 &
                          v8_6.x1 == TestData_LHS[i].x7 &
                          v8_6.x2 == TestData_LHS[i].x8 &
                          v8_6.x3 == TestData_LHS[i].x9 &
                          v8_6.x4 == TestData_LHS[i].x10 &
                          v8_6.x5 == TestData_LHS[i].x11 &
                          v8_6.x6 == TestData_LHS[i].x12 &
                          v8_6.x7 == TestData_LHS[i].x13;

                sbyte8 v8_7 = TestData_LHS[i].v8_7;
                result &= v8_7.x0 == TestData_LHS[i].x7 &
                          v8_7.x1 == TestData_LHS[i].x8 &
                          v8_7.x2 == TestData_LHS[i].x9 &
                          v8_7.x3 == TestData_LHS[i].x10 &
                          v8_7.x4 == TestData_LHS[i].x11 &
                          v8_7.x5 == TestData_LHS[i].x12 &
                          v8_7.x6 == TestData_LHS[i].x13 &
                          v8_7.x7 == TestData_LHS[i].x14;

                sbyte8 v8_8 = TestData_LHS[i].v8_8;
                result &= v8_8.x0 == TestData_LHS[i].x8 &
                          v8_8.x1 == TestData_LHS[i].x9 &
                          v8_8.x2 == TestData_LHS[i].x10 &
                          v8_8.x3 == TestData_LHS[i].x11 &
                          v8_8.x4 == TestData_LHS[i].x12 &
                          v8_8.x5 == TestData_LHS[i].x13 &
                          v8_8.x6 == TestData_LHS[i].x14 &
                          v8_8.x7 == TestData_LHS[i].x15;


                sbyte4 v4_0 = TestData_LHS[i].v4_0;
                result &= v4_0.x == TestData_LHS[i].x0 &
                          v4_0.y == TestData_LHS[i].x1 &
                          v4_0.z == TestData_LHS[i].x2 &
                          v4_0.w == TestData_LHS[i].x3;

                sbyte4 v4_1 = TestData_LHS[i].v4_1;
                result &= v4_1.x == TestData_LHS[i].x1 &
                          v4_1.y == TestData_LHS[i].x2 &
                          v4_1.z == TestData_LHS[i].x3 &
                          v4_1.w == TestData_LHS[i].x4;

                sbyte4 v4_2 = TestData_LHS[i].v4_2;
                result &= v4_2.x == TestData_LHS[i].x2 &
                          v4_2.y == TestData_LHS[i].x3 &
                          v4_2.z == TestData_LHS[i].x4 &
                          v4_2.w == TestData_LHS[i].x5;

                sbyte4 v4_3 = TestData_LHS[i].v4_3;
                result &= v4_3.x == TestData_LHS[i].x3 &
                          v4_3.y == TestData_LHS[i].x4 &
                          v4_3.z == TestData_LHS[i].x5 &
                          v4_3.w == TestData_LHS[i].x6;

                sbyte4 v4_4 = TestData_LHS[i].v4_4;
                result &= v4_4.x == TestData_LHS[i].x4 &
                          v4_4.y == TestData_LHS[i].x5 &
                          v4_4.z == TestData_LHS[i].x6 &
                          v4_4.w == TestData_LHS[i].x7;

                sbyte4 v4_5 = TestData_LHS[i].v4_5;
                result &= v4_5.x == TestData_LHS[i].x5 &
                          v4_5.y == TestData_LHS[i].x6 &
                          v4_5.z == TestData_LHS[i].x7 &
                          v4_5.w == TestData_LHS[i].x8;

                sbyte4 v4_6 = TestData_LHS[i].v4_6;
                result &= v4_6.x == TestData_LHS[i].x6 &
                          v4_6.y == TestData_LHS[i].x7 &
                          v4_6.z == TestData_LHS[i].x8 &
                          v4_6.w == TestData_LHS[i].x9;

                sbyte4 v4_7 = TestData_LHS[i].v4_7;
                result &= v4_7.x == TestData_LHS[i].x7 &
                          v4_7.y == TestData_LHS[i].x8 &
                          v4_7.z == TestData_LHS[i].x9 &
                          v4_7.w == TestData_LHS[i].x10;

                sbyte4 v4_8 = TestData_LHS[i].v4_8;
                result &= v4_8.x == TestData_LHS[i].x8 &
                          v4_8.y == TestData_LHS[i].x9 &
                          v4_8.z == TestData_LHS[i].x10 &
                          v4_8.w == TestData_LHS[i].x11;

                sbyte4 v4_9 = TestData_LHS[i].v4_9;
                result &= v4_9.x == TestData_LHS[i].x9  &
                          v4_9.y == TestData_LHS[i].x10 &
                          v4_9.z == TestData_LHS[i].x11 &
                          v4_9.w == TestData_LHS[i].x12;

                sbyte4 v4_10 = TestData_LHS[i].v4_10;
                result &= v4_10.x == TestData_LHS[i].x10 &
                          v4_10.y == TestData_LHS[i].x11 &
                          v4_10.z == TestData_LHS[i].x12 &
                          v4_10.w == TestData_LHS[i].x13;

                sbyte4 v4_11 = TestData_LHS[i].v4_11;
                result &= v4_11.x == TestData_LHS[i].x11 &
                          v4_11.y == TestData_LHS[i].x12 &
                          v4_11.z == TestData_LHS[i].x13 &
                          v4_11.w == TestData_LHS[i].x14;

                sbyte4 v4_12 = TestData_LHS[i].v4_12;
                result &= v4_12.x == TestData_LHS[i].x12 &
                          v4_12.y == TestData_LHS[i].x13 &
                          v4_12.z == TestData_LHS[i].x14 &
                          v4_12.w == TestData_LHS[i].x15;


                sbyte3 v3_0 = TestData_LHS[i].v3_0;
                result &= v3_0.x == TestData_LHS[i].x0 &
                          v3_0.y == TestData_LHS[i].x1 &
                          v3_0.z == TestData_LHS[i].x2;

                sbyte3 v3_1 = TestData_LHS[i].v3_1;
                result &= v3_1.x == TestData_LHS[i].x1 &
                          v3_1.y == TestData_LHS[i].x2 &
                          v3_1.z == TestData_LHS[i].x3;

                sbyte3 v3_2 = TestData_LHS[i].v3_2;
                result &= v3_2.x == TestData_LHS[i].x2 &
                          v3_2.y == TestData_LHS[i].x3 &
                          v3_2.z == TestData_LHS[i].x4;

                sbyte3 v3_3 = TestData_LHS[i].v3_3;
                result &= v3_3.x == TestData_LHS[i].x3 &
                          v3_3.y == TestData_LHS[i].x4 &
                          v3_3.z == TestData_LHS[i].x5;

                sbyte3 v3_4 = TestData_LHS[i].v3_4;
                result &= v3_4.x == TestData_LHS[i].x4 &
                          v3_4.y == TestData_LHS[i].x5 &
                          v3_4.z == TestData_LHS[i].x6;

                sbyte3 v3_5 = TestData_LHS[i].v3_5;
                result &= v3_5.x == TestData_LHS[i].x5 &
                          v3_5.y == TestData_LHS[i].x6 &
                          v3_5.z == TestData_LHS[i].x7;

                sbyte3 v3_6 = TestData_LHS[i].v3_6;
                result &= v3_6.x == TestData_LHS[i].x6 &
                          v3_6.y == TestData_LHS[i].x7 &
                          v3_6.z == TestData_LHS[i].x8;

                sbyte3 v3_7 = TestData_LHS[i].v3_7;
                result &= v3_7.x == TestData_LHS[i].x7 &
                          v3_7.y == TestData_LHS[i].x8 &
                          v3_7.z == TestData_LHS[i].x9;

                sbyte3 v3_8 = TestData_LHS[i].v3_8;
                result &= v3_8.x == TestData_LHS[i].x8 &
                          v3_8.y == TestData_LHS[i].x9 &
                          v3_8.z == TestData_LHS[i].x10;

                sbyte3 v3_9 = TestData_LHS[i].v3_9;
                result &= v3_9.x == TestData_LHS[i].x9 &
                          v3_9.y == TestData_LHS[i].x10 &
                          v3_9.z == TestData_LHS[i].x11;

                sbyte3 v3_10 = TestData_LHS[i].v3_10;
                result &= v3_10.x == TestData_LHS[i].x10 &
                          v3_10.y == TestData_LHS[i].x11 &
                          v3_10.z == TestData_LHS[i].x12;

                sbyte3 v3_11 = TestData_LHS[i].v3_11;
                result &= v3_11.x == TestData_LHS[i].x11 &
                          v3_11.y == TestData_LHS[i].x12 &
                          v3_11.z == TestData_LHS[i].x13;

                sbyte3 v3_12 = TestData_LHS[i].v3_12;
                result &= v3_12.x == TestData_LHS[i].x12 &
                          v3_12.y == TestData_LHS[i].x13 &
                          v3_12.z == TestData_LHS[i].x14;

                sbyte3 v3_13 = TestData_LHS[i].v3_13;
                result &= v3_13.x == TestData_LHS[i].x13 &
                          v3_13.y == TestData_LHS[i].x14 &
                          v3_13.z == TestData_LHS[i].x15;


                sbyte2 v2_0 = TestData_LHS[i].v2_0;
                result &= v2_0.x == TestData_LHS[i].x0 &
                          v2_0.y == TestData_LHS[i].x1;

                sbyte2 v2_1 = TestData_LHS[i].v2_1;
                result &= v2_1.x == TestData_LHS[i].x1 &
                          v2_1.y == TestData_LHS[i].x2;

                sbyte2 v2_2 = TestData_LHS[i].v2_2;
                result &= v2_2.x == TestData_LHS[i].x2 &
                          v2_2.y == TestData_LHS[i].x3;

                sbyte2 v2_3 = TestData_LHS[i].v2_3;
                result &= v2_3.x == TestData_LHS[i].x3 &
                          v2_3.y == TestData_LHS[i].x4;

                sbyte2 v2_4 = TestData_LHS[i].v2_4;
                result &= v2_4.x == TestData_LHS[i].x4 &
                          v2_4.y == TestData_LHS[i].x5;

                sbyte2 v2_5 = TestData_LHS[i].v2_5;
                result &= v2_5.x == TestData_LHS[i].x5 &
                          v2_5.y == TestData_LHS[i].x6;

                sbyte2 v2_6 = TestData_LHS[i].v2_6;
                result &= v2_6.x == TestData_LHS[i].x6 &
                          v2_6.y == TestData_LHS[i].x7;

                sbyte2 v2_7 = TestData_LHS[i].v2_7;
                result &= v2_7.x == TestData_LHS[i].x7 &
                          v2_7.y == TestData_LHS[i].x8;

                sbyte2 v2_8 = TestData_LHS[i].v2_8;
                result &= v2_8.x == TestData_LHS[i].x8 &
                          v2_8.y == TestData_LHS[i].x9;

                sbyte2 v2_9 = TestData_LHS[i].v2_9;
                result &= v2_9.x == TestData_LHS[i].x9 &
                          v2_9.y == TestData_LHS[i].x10;

                sbyte2 v2_10 = TestData_LHS[i].v2_10;
                result &= v2_10.x == TestData_LHS[i].x10 &
                          v2_10.y == TestData_LHS[i].x11;

                sbyte2 v2_11 = TestData_LHS[i].v2_11;
                result &= v2_11.x == TestData_LHS[i].x11 &
                          v2_11.y == TestData_LHS[i].x12;

                sbyte2 v2_12 = TestData_LHS[i].v2_12;
                result &= v2_12.x == TestData_LHS[i].x12 &
                          v2_12.y == TestData_LHS[i].x13;

                sbyte2 v2_13 = TestData_LHS[i].v2_13;
                result &= v2_13.x == TestData_LHS[i].x13 &
                          v2_13.y == TestData_LHS[i].x14;

                sbyte2 v2_14 = TestData_LHS[i].v2_14;
                result &= v2_14.x == TestData_LHS[i].x14 &
                          v2_14.y == TestData_LHS[i].x15;
            }


            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool Cast_ToV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                v128 x = TestData_LHS[i];

                result &= x.SByte0 == TestData_LHS[i].x0 &
                          x.SByte1 == TestData_LHS[i].x1 &
                          x.SByte2 == TestData_LHS[i].x2 &
                          x.SByte3 == TestData_LHS[i].x3 &
                          x.SByte4 == TestData_LHS[i].x4 &
                          x.SByte5 == TestData_LHS[i].x5 &
                          x.SByte6 == TestData_LHS[i].x6 &
                          x.SByte7 == TestData_LHS[i].x7 &
                          x.SByte8 == TestData_LHS[i].x8 &
                          x.SByte9 == TestData_LHS[i].x9 &
                          x.SByte10 == TestData_LHS[i].x10 &
                          x.SByte11 == TestData_LHS[i].x11 &
                          x.SByte12 == TestData_LHS[i].x12 &
                          x.SByte13 == TestData_LHS[i].x13 &
                          x.SByte14 == TestData_LHS[i].x14 &
                          x.SByte15 == TestData_LHS[i].x15;
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Cast_FromV128()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                sbyte16 x = TestData_LHS[i];
                v128 c = x;
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

            return result;
        }


        [UnitTest("Types", "sbyte16")]
        public static bool Cast_ToShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                short16 x = TestData_LHS[i];

                result &= x.x0 ==  TestData_LHS[i].x0 &
                          x.x1 ==  TestData_LHS[i].x1 &
                          x.x2 ==  TestData_LHS[i].x2 &
                          x.x3 ==  TestData_LHS[i].x3 &
                          x.x4 ==  TestData_LHS[i].x4 &
                          x.x5 ==  TestData_LHS[i].x5 &
                          x.x6 ==  TestData_LHS[i].x6 &
                          x.x7 ==  TestData_LHS[i].x7 &
                          x.x8 ==  TestData_LHS[i].x8 &
                          x.x9 ==  TestData_LHS[i].x9 &
                          x.x10 == TestData_LHS[i].x10 &
                          x.x11 == TestData_LHS[i].x11 &
                          x.x12 == TestData_LHS[i].x12 &
                          x.x13 == TestData_LHS[i].x13 &
                          x.x14 == TestData_LHS[i].x14 &
                          x.x15 == TestData_LHS[i].x15;
            }

            return result;
        }

        [UnitTest("Types", "sbyte16")]
        public static bool Cast_ToUShort()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                ushort16 x = (ushort16)TestData_LHS[i];

                result &= x.x0 ==  (ushort)TestData_LHS[i].x0 &
                          x.x1 ==  (ushort)TestData_LHS[i].x1 &
                          x.x2 ==  (ushort)TestData_LHS[i].x2 &
                          x.x3 ==  (ushort)TestData_LHS[i].x3 &
                          x.x4 ==  (ushort)TestData_LHS[i].x4 &
                          x.x5 ==  (ushort)TestData_LHS[i].x5 &
                          x.x6 ==  (ushort)TestData_LHS[i].x6 &
                          x.x7 ==  (ushort)TestData_LHS[i].x7 &
                          x.x8 ==  (ushort)TestData_LHS[i].x8 &
                          x.x9 ==  (ushort)TestData_LHS[i].x9 &
                          x.x10 == (ushort)TestData_LHS[i].x10 &
                          x.x11 == (ushort)TestData_LHS[i].x11 &
                          x.x12 == (ushort)TestData_LHS[i].x12 &
                          x.x13 == (ushort)TestData_LHS[i].x13 &
                          x.x14 == (ushort)TestData_LHS[i].x14 &
                          x.x15 == (ushort)TestData_LHS[i].x15;
            }

            return result;
        }
    }
}