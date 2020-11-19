using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class Short16
    {
        internal const int NUM_TESTS = 4;


        internal static short16[] TestData_LHS => new short16[]
        {
            new short16(-644, 55, 99, 76, 65, -1, -11, 4955, 75, 99, -11, 54, 695, -9532, -54, -77),
            new short16(3232, -132, 16, -11, 99, 950, -54, -4959, 76, 65, -1, -11, -4955, 75, 99, -11),      // EQUAL
            new short16(957, short.MaxValue, 17, 321, 0, 47, -4532, -56, 957, 321, 47, -70, 54, -3232, 132, 9595),
            new short16(short.MinValue, 15495, 111, 66, -99, -4959, -50, 1321, 5495, -4532, -995, 6, -4954, 1324, 15, 99)
        };

        internal static short16[] TestData_RHS => new short16[]
        {
            new short16(132, 95, 5495, 995, 32, -5495, 97, 44, 957, -19, -9532, -5495, -11, -955, 75, -99),
            new short16(3232, -132, 16, -11, 99, 950, -54, -4959, 76, 65, -1, -11, -4955, 75, 99, -11),      // EQUAL
            new short16(17, 957, 9, -9532, -5499, 45, 90, -632, -77, 132, 47, -49, 65, 7, -1327, 9595),
            new short16(32, 9, -320, -932, 957, -19, -9532, -5495, -5495, 32, -432, 99, -595, 932, 15495, 321)
        };

        internal static int[] TestData_int32 => new int[]
        {
            15,
            9,
            2,
            0
        };


        [UnitTest("Types", "short16")]
        public static bool Constructor_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short_Short()
        {
            short16 x = new short16(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15);

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short()
        {
            short16 x = new short16(TestData_LHS[0].x0);

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short2_Short2_Short2_Short2_Short2_Short2_Short2_Short2()
        {
            short16 x = new short16(new short2(TestData_LHS[0].x0, TestData_LHS[0].x1), new short2(TestData_LHS[0].x2, TestData_LHS[0].x3), new short2(TestData_LHS[0].x4, TestData_LHS[0].x5), new short2(TestData_LHS[0].x6, TestData_LHS[0].x7), new short2(TestData_LHS[0].x8, TestData_LHS[0].x9), new short2(TestData_LHS[0].x10, TestData_LHS[0].x11), new short2(TestData_LHS[0].x12, TestData_LHS[0].x13), new short2(TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short4_Short4_Short4_Short4()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short4_Short3_Short3_Short3_Short3()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short3(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new short3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short3_Short4_Short3_Short3_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short4(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6), new short3(TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short3_Short3_Short4_Short3_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short4(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9), new short3(TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short3_Short3_Short3_Short4_Short3()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new short4(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12), new short3(TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short3_Short3_Short3_Short3_Short4()
        {
            short16 x = new short16(new short3(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2), new short3(TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5), new short3(TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8), new short3(TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short8_Short4_Short4()
        {
            short16 x = new short16(new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short4(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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
        [UnitTest("Types", "short16")]
        public static bool Constructor_Short4_Short8_Short4()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short8(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7, TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11), new short4(TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short4_Short4_Short8()
        {
            short16 x = new short16(new short4(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3), new short4(TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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

        [UnitTest("Types", "short16")]
        public static bool Constructor_Short8_Short8()
        {
            short16 x = new short16(new short8(TestData_LHS[0].x0, TestData_LHS[0].x1, TestData_LHS[0].x2, TestData_LHS[0].x3, TestData_LHS[0].x4, TestData_LHS[0].x5, TestData_LHS[0].x6, TestData_LHS[0].x7), new short8(TestData_LHS[0].x8, TestData_LHS[0].x9, TestData_LHS[0].x10, TestData_LHS[0].x11, TestData_LHS[0].x12, TestData_LHS[0].x13, TestData_LHS[0].x14, TestData_LHS[0].x15));

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
        [UnitTest("Types", "short16")]
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


        [UnitTest("Types", "short16")]
        public static bool Add()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Subtract()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Multiply()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Divide()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Remainder()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Negate()
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
                          x.x15 == (short)(-TestData_LHS[i].x15); ;
            }

            return result;
        }


        [UnitTest("Types", "short16")]
        public static bool AND()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool OR()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool XOR()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool NOT()
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
                          x.x15 == (short)(~TestData_LHS[i].x15); ;
            }

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool ShiftLeft()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    short16 x = TestData_LHS[i] << TestData_int32[j];

                    result &= x.x0 ==  (short)(TestData_LHS[i].x0  << TestData_int32[j]) & 
                              x.x1 ==  (short)(TestData_LHS[i].x1  << TestData_int32[j]) &
                              x.x2 ==  (short)(TestData_LHS[i].x2  << TestData_int32[j]) &
                              x.x3 ==  (short)(TestData_LHS[i].x3  << TestData_int32[j]) &
                              x.x4 ==  (short)(TestData_LHS[i].x4  << TestData_int32[j]) &
                              x.x5 ==  (short)(TestData_LHS[i].x5  << TestData_int32[j]) &
                              x.x6 ==  (short)(TestData_LHS[i].x6  << TestData_int32[j]) &
                              x.x7 ==  (short)(TestData_LHS[i].x7  << TestData_int32[j]) &
                              x.x8 ==  (short)(TestData_LHS[i].x8  << TestData_int32[j]) &
                              x.x9 ==  (short)(TestData_LHS[i].x9  << TestData_int32[j]) &
                              x.x10 == (short)(TestData_LHS[i].x10 << TestData_int32[j]) &
                              x.x11 == (short)(TestData_LHS[i].x11 << TestData_int32[j]) &
                              x.x12 == (short)(TestData_LHS[i].x12 << TestData_int32[j]) &
                              x.x13 == (short)(TestData_LHS[i].x13 << TestData_int32[j]) &
                              x.x14 == (short)(TestData_LHS[i].x14 << TestData_int32[j]) &
                              x.x15 == (short)(TestData_LHS[i].x15 << TestData_int32[j]);
                }
            }

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool ShiftRight()
        {
            bool result = true;

            for (int i = 0; i < NUM_TESTS; i++)
            {
                for (int j = 0; j < NUM_TESTS; j++)
                {
                    short16 x = TestData_LHS[i] >> TestData_int32[j];

                    result &= x.x0 ==  (short)(TestData_LHS[i].x0  >> TestData_int32[j]) & 
                              x.x1 ==  (short)(TestData_LHS[i].x1  >> TestData_int32[j]) &
                              x.x2 ==  (short)(TestData_LHS[i].x2  >> TestData_int32[j]) &
                              x.x3 ==  (short)(TestData_LHS[i].x3  >> TestData_int32[j]) &
                              x.x4 ==  (short)(TestData_LHS[i].x4  >> TestData_int32[j]) &
                              x.x5 ==  (short)(TestData_LHS[i].x5  >> TestData_int32[j]) &
                              x.x6 ==  (short)(TestData_LHS[i].x6  >> TestData_int32[j]) &
                              x.x7 ==  (short)(TestData_LHS[i].x7  >> TestData_int32[j]) &
                              x.x8 ==  (short)(TestData_LHS[i].x8  >> TestData_int32[j]) &
                              x.x9 ==  (short)(TestData_LHS[i].x9  >> TestData_int32[j]) &
                              x.x10 == (short)(TestData_LHS[i].x10 >> TestData_int32[j]) &
                              x.x11 == (short)(TestData_LHS[i].x11 >> TestData_int32[j]) &
                              x.x12 == (short)(TestData_LHS[i].x12 >> TestData_int32[j]) &
                              x.x13 == (short)(TestData_LHS[i].x13 >> TestData_int32[j]) &
                              x.x14 == (short)(TestData_LHS[i].x14 >> TestData_int32[j]) &
                              x.x15 == (short)(TestData_LHS[i].x15 >> TestData_int32[j]);
                }
            }

            return result;
        }


        [UnitTest("Types", "short16")]
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

        [UnitTest("Types", "short16")]
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

        [UnitTest("Types", "short16")]
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

        [UnitTest("Types", "short16")]
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

        [UnitTest("Types", "short16")]
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

        [UnitTest("Types", "short16")]
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


        [UnitTest("Types", "short16")]
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


        [UnitTest("Types", "short16")]
        public static bool Shuffle()
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


            return result;
        }


        [UnitTest("Types", "short16")]
        public static bool Cast_ToV128()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Cast_FromV128()
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

            return result;
        }


        [UnitTest("Types", "short16")]
        public static bool Cast_ToByte()
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

            return result;
        }

        [UnitTest("Types", "short16")]
        public static bool Cast_ToSByte()
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

            return result;
        }
    }
#endif
}