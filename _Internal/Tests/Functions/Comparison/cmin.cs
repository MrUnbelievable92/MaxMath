using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class cmin
    {
        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte2.TestData_LHS[i].x,
                                        (int)Tests.Byte2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte3.TestData_LHS[i].x,
                               math.min((int)Tests.Byte3.TestData_LHS[i].y,
                                        (int)Tests.Byte3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte4.TestData_LHS[i].x,
                               math.min((int)Tests.Byte4.TestData_LHS[i].y,
                               math.min((int)Tests.Byte4.TestData_LHS[i].z,
                                        (int)Tests.Byte4.TestData_LHS[i].w)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte8.TestData_LHS[i].x0,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x1,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x2,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x3,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x4,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x5,
                               math.min((int)Tests.Byte8.TestData_LHS[i].x6,
                                        (int)Tests.Byte8.TestData_LHS[i].x7)))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte16.TestData_LHS[i].x0,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x1,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x2,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x3,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x4,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x5,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x6,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x7,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x8,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x9,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x10,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x11,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x12,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x13,
                               math.min((int)Tests.Byte16.TestData_LHS[i].x14,
                                        (int)Tests.Byte16.TestData_LHS[i].x15)))))))))))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Byte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Byte32.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Byte32.TestData_LHS[i].x0,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x1,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x2,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x3,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x4,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x5,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x6,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x7,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x8,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x9,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x10,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x11,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x12,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x13,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x14,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x15,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x16,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x17,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x18,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x19,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x20,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x21,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x22,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x23,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x24,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x25,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x26,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x27,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x28,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x29,
                               math.min((int)Tests.Byte32.TestData_LHS[i].x30,
                                        (int)Tests.Byte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte2.TestData_LHS[i].x,
                                        (int)Tests.SByte2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte3.TestData_LHS[i].x,
                               math.min((int)Tests.SByte3.TestData_LHS[i].y,
                                        (int)Tests.SByte3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte4.TestData_LHS[i].x,
                               math.min((int)Tests.SByte4.TestData_LHS[i].y,
                               math.min((int)Tests.SByte4.TestData_LHS[i].z,
                                        (int)Tests.SByte4.TestData_LHS[i].w)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte8.TestData_LHS[i].x0,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x1,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x2,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x3,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x4,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x5,
                               math.min((int)Tests.SByte8.TestData_LHS[i].x6,
                                        (int)Tests.SByte8.TestData_LHS[i].x7)))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte16.TestData_LHS[i].x0,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x1,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x2,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x3,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x4,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x5,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x6,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x7,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x8,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x9,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x10,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x11,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x12,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x13,
                               math.min((int)Tests.SByte16.TestData_LHS[i].x14,
                                        (int)Tests.SByte16.TestData_LHS[i].x15)))))))))))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.SByte32.TestData_LHS[i]);

                result &= x == math.min((int)Tests.SByte32.TestData_LHS[i].x0,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x1,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x2,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x3,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x4,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x5,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x6,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x7,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x8,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x9,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x10,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x11,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x12,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x13,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x14,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x15,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x16,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x17,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x18,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x19,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x20,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x21,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x22,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x23,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x24,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x25,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x26,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x27,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x28,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x29,
                               math.min((int)Tests.SByte32.TestData_LHS[i].x30,
                                        (int)Tests.SByte32.TestData_LHS[i].x31)))))))))))))))))))))))))))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Short2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Short2.TestData_LHS[i].x,
                                        (int)Tests.Short2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Short3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Short3.TestData_LHS[i].x,
                               math.min((int)Tests.Short3.TestData_LHS[i].y,
                                        (int)Tests.Short3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Short4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Short4.TestData_LHS[i].x,
                               math.min((int)Tests.Short4.TestData_LHS[i].y,
                               math.min((int)Tests.Short4.TestData_LHS[i].z,
                                        (int)Tests.Short4.TestData_LHS[i].w)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Short8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Short8.TestData_LHS[i].x0,
                               math.min((int)Tests.Short8.TestData_LHS[i].x1,
                               math.min((int)Tests.Short8.TestData_LHS[i].x2,
                               math.min((int)Tests.Short8.TestData_LHS[i].x3,
                               math.min((int)Tests.Short8.TestData_LHS[i].x4,
                               math.min((int)Tests.Short8.TestData_LHS[i].x5,
                               math.min((int)Tests.Short8.TestData_LHS[i].x6,
                                        (int)Tests.Short8.TestData_LHS[i].x7)))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Short16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Short16.TestData_LHS[i].x0,
                               math.min((int)Tests.Short16.TestData_LHS[i].x1,
                               math.min((int)Tests.Short16.TestData_LHS[i].x2,
                               math.min((int)Tests.Short16.TestData_LHS[i].x3,
                               math.min((int)Tests.Short16.TestData_LHS[i].x4,
                               math.min((int)Tests.Short16.TestData_LHS[i].x5,
                               math.min((int)Tests.Short16.TestData_LHS[i].x6,
                               math.min((int)Tests.Short16.TestData_LHS[i].x7,
                               math.min((int)Tests.Short16.TestData_LHS[i].x8,
                               math.min((int)Tests.Short16.TestData_LHS[i].x9,
                               math.min((int)Tests.Short16.TestData_LHS[i].x10,
                               math.min((int)Tests.Short16.TestData_LHS[i].x11,
                               math.min((int)Tests.Short16.TestData_LHS[i].x12,
                               math.min((int)Tests.Short16.TestData_LHS[i].x13,
                               math.min((int)Tests.Short16.TestData_LHS[i].x14,
                                        (int)Tests.Short16.TestData_LHS[i].x15)))))))))))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UShort2()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort2.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.UShort2.TestData_LHS[i]);

                result &= x == math.min((int)Tests.UShort2.TestData_LHS[i].x,
                                        (int)Tests.UShort2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UShort3()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort3.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.UShort3.TestData_LHS[i]);

                result &= x == math.min((int)Tests.UShort3.TestData_LHS[i].x,
                               math.min((int)Tests.UShort3.TestData_LHS[i].y,
                                        (int)Tests.UShort3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UShort4()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort4.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.UShort4.TestData_LHS[i]);

                result &= x == math.min((int)Tests.UShort4.TestData_LHS[i].x,
                               math.min((int)Tests.UShort4.TestData_LHS[i].y,
                               math.min((int)Tests.UShort4.TestData_LHS[i].z,
                                        (int)Tests.UShort4.TestData_LHS[i].w)));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UShort8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.UShort8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.UShort8.TestData_LHS[i].x0,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x1,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x2,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x3,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x4,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x5,
                               math.min((int)Tests.UShort8.TestData_LHS[i].x6,
                                        (int)Tests.UShort8.TestData_LHS[i].x7)))))));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UShort16()
        {
            bool result = true;

            for (int i = 0; i < Tests.UShort16.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.UShort16.TestData_LHS[i]);

                result &= x == math.min((int)Tests.UShort16.TestData_LHS[i].x0,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x1,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x2,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x3,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x4,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x5,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x6,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x7,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x8,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x9,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x10,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x11,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x12,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x13,
                               math.min((int)Tests.UShort16.TestData_LHS[i].x14,
                                        (int)Tests.UShort16.TestData_LHS[i].x15)))))))))))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Int8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Int8.NUM_TESTS; i++)
            {
                int x = maxmath.cmin(Tests.Int8.TestData_LHS[i]);

                result &= x == math.min((int)Tests.Int8.TestData_LHS[i].x0,
                               math.min((int)Tests.Int8.TestData_LHS[i].x1,
                               math.min((int)Tests.Int8.TestData_LHS[i].x2,
                               math.min((int)Tests.Int8.TestData_LHS[i].x3,
                               math.min((int)Tests.Int8.TestData_LHS[i].x4,
                               math.min((int)Tests.Int8.TestData_LHS[i].x5,
                               math.min((int)Tests.Int8.TestData_LHS[i].x6,
                                        (int)Tests.Int8.TestData_LHS[i].x7)))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool UInt8()
        {
            bool result = true;

            for (int i = 0; i < Tests.UInt8.NUM_TESTS; i++)
            {
                uint x = maxmath.cmin(Tests.UInt8.TestData_LHS[i]);

                result &= x == math.min(Tests.UInt8.TestData_LHS[i].x0,
                               math.min(Tests.UInt8.TestData_LHS[i].x1,
                               math.min(Tests.UInt8.TestData_LHS[i].x2,
                               math.min(Tests.UInt8.TestData_LHS[i].x3,
                               math.min(Tests.UInt8.TestData_LHS[i].x4,
                               math.min(Tests.UInt8.TestData_LHS[i].x5,
                               math.min(Tests.UInt8.TestData_LHS[i].x6,
                                        Tests.UInt8.TestData_LHS[i].x7)))))));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Long2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long2.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.Long2.TestData_LHS[i]);

                result &= x == math.min(Tests.Long2.TestData_LHS[i].x,
                                        Tests.Long2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Long3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long3.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.Long3.TestData_LHS[i]);

                result &= x == math.min(Tests.Long3.TestData_LHS[i].x,
                               math.min(Tests.Long3.TestData_LHS[i].y,
                                        Tests.Long3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Long4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Long4.NUM_TESTS; i++)
            {
                long x = maxmath.cmin(Tests.Long4.TestData_LHS[i]);

                result &= x == math.min(Tests.Long4.TestData_LHS[i].x,
                               math.min(Tests.Long4.TestData_LHS[i].y,
                               math.min(Tests.Long4.TestData_LHS[i].z,
                                        Tests.Long4.TestData_LHS[i].w)));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool ULong2()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong2.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.ULong2.TestData_LHS[i]);

                result &= x == math.min(Tests.ULong2.TestData_LHS[i].x,
                                        Tests.ULong2.TestData_LHS[i].y);
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool ULong3()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong3.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.ULong3.TestData_LHS[i]);

                result &= x == math.min(Tests.ULong3.TestData_LHS[i].x,
                               math.min(Tests.ULong3.TestData_LHS[i].y,
                                        Tests.ULong3.TestData_LHS[i].z));
            }

            return result;
        }

        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool ULong4()
        {
            bool result = true;

            for (int i = 0; i < Tests.ULong4.NUM_TESTS; i++)
            {
                ulong x = maxmath.cmin(Tests.ULong4.TestData_LHS[i]);

                result &= x == math.min(Tests.ULong4.TestData_LHS[i].x,
                               math.min(Tests.ULong4.TestData_LHS[i].y,
                               math.min(Tests.ULong4.TestData_LHS[i].z,
                                        Tests.ULong4.TestData_LHS[i].w)));
            }

            return result;
        }


        [UnitTest("Functions", "Comparison", "ColumnMin")]
        public static bool Float8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Float8.NUM_TESTS; i++)
            {
                float x = maxmath.cmin(Tests.Float8.TestData_LHS[i]);

                result &= x == math.min(Tests.Float8.TestData_LHS[i].x0,
                               math.min(Tests.Float8.TestData_LHS[i].x1,
                               math.min(Tests.Float8.TestData_LHS[i].x2,
                               math.min(Tests.Float8.TestData_LHS[i].x3,
                               math.min(Tests.Float8.TestData_LHS[i].x4,
                               math.min(Tests.Float8.TestData_LHS[i].x5,
                               math.min(Tests.Float8.TestData_LHS[i].x6,
                                        Tests.Float8.TestData_LHS[i].x7)))))));
            }

            return result;
        }
    }
#endif
}