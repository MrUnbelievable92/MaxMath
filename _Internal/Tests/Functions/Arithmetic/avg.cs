using DevTools;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath.Tests
{
#if UNITY_EDITOR
    unsafe public static class avg
    {
        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Byte2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte2.NUM_TESTS; i++)
            {
                short2 x = maxmath.avg(Tests.Byte2.TestData_LHS[i], Tests.Byte2.TestData_RHS[i]);

                result &= x.x == (((Tests.Byte2.TestData_LHS[i].x + Tests.Byte2.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Byte2.TestData_LHS[i].x + Tests.Byte2.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Byte2.TestData_LHS[i].y + Tests.Byte2.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Byte2.TestData_LHS[i].y + Tests.Byte2.TestData_RHS[i].y) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Byte3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte3.NUM_TESTS; i++)
            {
                short3 x = maxmath.avg(Tests.Byte3.TestData_LHS[i], Tests.Byte3.TestData_RHS[i]);

                result &= x.x == (((Tests.Byte3.TestData_LHS[i].x + Tests.Byte3.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Byte3.TestData_LHS[i].x + Tests.Byte3.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Byte3.TestData_LHS[i].y + Tests.Byte3.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Byte3.TestData_LHS[i].y + Tests.Byte3.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.Byte3.TestData_LHS[i].z + Tests.Byte3.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.Byte3.TestData_LHS[i].z + Tests.Byte3.TestData_RHS[i].z) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Byte4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte4.NUM_TESTS; i++)
            {
                short4 x = maxmath.avg(Tests.Byte4.TestData_LHS[i], Tests.Byte4.TestData_RHS[i]);

                result &= x.x == (((Tests.Byte4.TestData_LHS[i].x + Tests.Byte4.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Byte4.TestData_LHS[i].x + Tests.Byte4.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Byte4.TestData_LHS[i].y + Tests.Byte4.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Byte4.TestData_LHS[i].y + Tests.Byte4.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.Byte4.TestData_LHS[i].z + Tests.Byte4.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.Byte4.TestData_LHS[i].z + Tests.Byte4.TestData_RHS[i].z) / 2;
                result &= x.w == (((Tests.Byte4.TestData_LHS[i].w + Tests.Byte4.TestData_RHS[i].w) > 0 ? 1 : -1) + Tests.Byte4.TestData_LHS[i].w + Tests.Byte4.TestData_RHS[i].w) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Byte8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Byte8.NUM_TESTS; i++)
            {
                short8 x = maxmath.avg(Tests.Byte8.TestData_LHS[i], Tests.Byte8.TestData_RHS[i]);

                result &= x.x0 == (((Tests.Byte8.TestData_LHS[i].x0 + Tests.Byte8.TestData_RHS[i].x0) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x0 + Tests.Byte8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (((Tests.Byte8.TestData_LHS[i].x1 + Tests.Byte8.TestData_RHS[i].x1) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x1 + Tests.Byte8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (((Tests.Byte8.TestData_LHS[i].x2 + Tests.Byte8.TestData_RHS[i].x2) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x2 + Tests.Byte8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (((Tests.Byte8.TestData_LHS[i].x3 + Tests.Byte8.TestData_RHS[i].x3) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x3 + Tests.Byte8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (((Tests.Byte8.TestData_LHS[i].x4 + Tests.Byte8.TestData_RHS[i].x4) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x4 + Tests.Byte8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (((Tests.Byte8.TestData_LHS[i].x5 + Tests.Byte8.TestData_RHS[i].x5) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x5 + Tests.Byte8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (((Tests.Byte8.TestData_LHS[i].x6 + Tests.Byte8.TestData_RHS[i].x6) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x6 + Tests.Byte8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (((Tests.Byte8.TestData_LHS[i].x7 + Tests.Byte8.TestData_RHS[i].x7) > 0 ? 1 : -1) + Tests.Byte8.TestData_LHS[i].x7 + Tests.Byte8.TestData_RHS[i].x7) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool SByte16()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte16.NUM_TESTS; i++)
            {
                sbyte16 x = maxmath.avg(Tests.SByte16.TestData_LHS[i], Tests.SByte16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.SByte16.TestData_LHS[i].x0  + Tests.SByte16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x0  + Tests.SByte16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.SByte16.TestData_LHS[i].x1  + Tests.SByte16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x1  + Tests.SByte16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.SByte16.TestData_LHS[i].x2  + Tests.SByte16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x2  + Tests.SByte16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.SByte16.TestData_LHS[i].x3  + Tests.SByte16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x3  + Tests.SByte16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.SByte16.TestData_LHS[i].x4  + Tests.SByte16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x4  + Tests.SByte16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.SByte16.TestData_LHS[i].x5  + Tests.SByte16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x5  + Tests.SByte16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.SByte16.TestData_LHS[i].x6  + Tests.SByte16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x6  + Tests.SByte16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.SByte16.TestData_LHS[i].x7  + Tests.SByte16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x7  + Tests.SByte16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.SByte16.TestData_LHS[i].x8  + Tests.SByte16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x8  + Tests.SByte16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.SByte16.TestData_LHS[i].x9  + Tests.SByte16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x9  + Tests.SByte16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.SByte16.TestData_LHS[i].x10 + Tests.SByte16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x10 + Tests.SByte16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.SByte16.TestData_LHS[i].x11 + Tests.SByte16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x11 + Tests.SByte16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.SByte16.TestData_LHS[i].x12 + Tests.SByte16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x12 + Tests.SByte16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.SByte16.TestData_LHS[i].x13 + Tests.SByte16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x13 + Tests.SByte16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.SByte16.TestData_LHS[i].x14 + Tests.SByte16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x14 + Tests.SByte16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.SByte16.TestData_LHS[i].x15 + Tests.SByte16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.SByte16.TestData_LHS[i].x15 + Tests.SByte16.TestData_RHS[i].x15) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool SByte32()
        {
            bool result = true;

            for (int i = 0; i < Tests.SByte32.NUM_TESTS; i++)
            {
                sbyte32 x = maxmath.avg(Tests.SByte32.TestData_LHS[i], Tests.SByte32.TestData_RHS[i]);

                result &= x.x0  == (((Tests.SByte32.TestData_LHS[i].x0  + Tests.SByte32.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x0  + Tests.SByte32.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.SByte32.TestData_LHS[i].x1  + Tests.SByte32.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x1  + Tests.SByte32.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.SByte32.TestData_LHS[i].x2  + Tests.SByte32.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x2  + Tests.SByte32.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.SByte32.TestData_LHS[i].x3  + Tests.SByte32.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x3  + Tests.SByte32.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.SByte32.TestData_LHS[i].x4  + Tests.SByte32.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x4  + Tests.SByte32.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.SByte32.TestData_LHS[i].x5  + Tests.SByte32.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x5  + Tests.SByte32.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.SByte32.TestData_LHS[i].x6  + Tests.SByte32.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x6  + Tests.SByte32.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.SByte32.TestData_LHS[i].x7  + Tests.SByte32.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x7  + Tests.SByte32.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.SByte32.TestData_LHS[i].x8  + Tests.SByte32.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x8  + Tests.SByte32.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.SByte32.TestData_LHS[i].x9  + Tests.SByte32.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x9  + Tests.SByte32.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.SByte32.TestData_LHS[i].x10 + Tests.SByte32.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x10 + Tests.SByte32.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.SByte32.TestData_LHS[i].x11 + Tests.SByte32.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x11 + Tests.SByte32.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.SByte32.TestData_LHS[i].x12 + Tests.SByte32.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x12 + Tests.SByte32.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.SByte32.TestData_LHS[i].x13 + Tests.SByte32.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x13 + Tests.SByte32.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.SByte32.TestData_LHS[i].x14 + Tests.SByte32.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x14 + Tests.SByte32.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.SByte32.TestData_LHS[i].x15 + Tests.SByte32.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x15 + Tests.SByte32.TestData_RHS[i].x15) / 2;
                result &= x.x16 == (((Tests.SByte32.TestData_LHS[i].x16 + Tests.SByte32.TestData_RHS[i].x16) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x16 + Tests.SByte32.TestData_RHS[i].x16) / 2;
                result &= x.x17 == (((Tests.SByte32.TestData_LHS[i].x17 + Tests.SByte32.TestData_RHS[i].x17) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x17 + Tests.SByte32.TestData_RHS[i].x17) / 2;
                result &= x.x18 == (((Tests.SByte32.TestData_LHS[i].x18 + Tests.SByte32.TestData_RHS[i].x18) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x18 + Tests.SByte32.TestData_RHS[i].x18) / 2;
                result &= x.x19 == (((Tests.SByte32.TestData_LHS[i].x19 + Tests.SByte32.TestData_RHS[i].x19) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x19 + Tests.SByte32.TestData_RHS[i].x19) / 2;
                result &= x.x20 == (((Tests.SByte32.TestData_LHS[i].x20 + Tests.SByte32.TestData_RHS[i].x20) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x20 + Tests.SByte32.TestData_RHS[i].x20) / 2;
                result &= x.x21 == (((Tests.SByte32.TestData_LHS[i].x21 + Tests.SByte32.TestData_RHS[i].x21) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x21 + Tests.SByte32.TestData_RHS[i].x21) / 2;
                result &= x.x22 == (((Tests.SByte32.TestData_LHS[i].x22 + Tests.SByte32.TestData_RHS[i].x22) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x22 + Tests.SByte32.TestData_RHS[i].x22) / 2;
                result &= x.x23 == (((Tests.SByte32.TestData_LHS[i].x23 + Tests.SByte32.TestData_RHS[i].x23) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x23 + Tests.SByte32.TestData_RHS[i].x23) / 2;
                result &= x.x24 == (((Tests.SByte32.TestData_LHS[i].x24 + Tests.SByte32.TestData_RHS[i].x24) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x24 + Tests.SByte32.TestData_RHS[i].x24) / 2;
                result &= x.x25 == (((Tests.SByte32.TestData_LHS[i].x25 + Tests.SByte32.TestData_RHS[i].x25) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x25 + Tests.SByte32.TestData_RHS[i].x25) / 2;
                result &= x.x26 == (((Tests.SByte32.TestData_LHS[i].x26 + Tests.SByte32.TestData_RHS[i].x26) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x26 + Tests.SByte32.TestData_RHS[i].x26) / 2;
                result &= x.x27 == (((Tests.SByte32.TestData_LHS[i].x27 + Tests.SByte32.TestData_RHS[i].x27) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x27 + Tests.SByte32.TestData_RHS[i].x27) / 2;
                result &= x.x28 == (((Tests.SByte32.TestData_LHS[i].x28 + Tests.SByte32.TestData_RHS[i].x28) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x28 + Tests.SByte32.TestData_RHS[i].x28) / 2;
                result &= x.x29 == (((Tests.SByte32.TestData_LHS[i].x29 + Tests.SByte32.TestData_RHS[i].x29) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x29 + Tests.SByte32.TestData_RHS[i].x29) / 2;
                result &= x.x30 == (((Tests.SByte32.TestData_LHS[i].x30 + Tests.SByte32.TestData_RHS[i].x30) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x30 + Tests.SByte32.TestData_RHS[i].x30) / 2;
                result &= x.x31 == (((Tests.SByte32.TestData_LHS[i].x31 + Tests.SByte32.TestData_RHS[i].x31) > 0 ? 1 : -1) + Tests.SByte32.TestData_LHS[i].x31 + Tests.SByte32.TestData_RHS[i].x31) / 2;
            }

            return result;
        }


        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Short2()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short2.NUM_TESTS; i++)
            {
                short2 x = maxmath.avg(Tests.Short2.TestData_LHS[i], Tests.Short2.TestData_RHS[i]);

                result &= x.x == (((Tests.Short2.TestData_LHS[i].x + Tests.Short2.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Short2.TestData_LHS[i].x + Tests.Short2.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Short2.TestData_LHS[i].y + Tests.Short2.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Short2.TestData_LHS[i].y + Tests.Short2.TestData_RHS[i].y) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Short3()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short3.NUM_TESTS; i++)
            {
                short3 x = maxmath.avg(Tests.Short3.TestData_LHS[i], Tests.Short3.TestData_RHS[i]);

                result &= x.x == (((Tests.Short3.TestData_LHS[i].x + Tests.Short3.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Short3.TestData_LHS[i].x + Tests.Short3.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Short3.TestData_LHS[i].y + Tests.Short3.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Short3.TestData_LHS[i].y + Tests.Short3.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.Short3.TestData_LHS[i].z + Tests.Short3.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.Short3.TestData_LHS[i].z + Tests.Short3.TestData_RHS[i].z) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Short4()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short4.NUM_TESTS; i++)
            {
                short4 x = maxmath.avg(Tests.Short4.TestData_LHS[i], Tests.Short4.TestData_RHS[i]);

                result &= x.x == (((Tests.Short4.TestData_LHS[i].x + Tests.Short4.TestData_RHS[i].x) > 0 ? 1 : -1) + Tests.Short4.TestData_LHS[i].x + Tests.Short4.TestData_RHS[i].x) / 2;
                result &= x.y == (((Tests.Short4.TestData_LHS[i].y + Tests.Short4.TestData_RHS[i].y) > 0 ? 1 : -1) + Tests.Short4.TestData_LHS[i].y + Tests.Short4.TestData_RHS[i].y) / 2;
                result &= x.z == (((Tests.Short4.TestData_LHS[i].z + Tests.Short4.TestData_RHS[i].z) > 0 ? 1 : -1) + Tests.Short4.TestData_LHS[i].z + Tests.Short4.TestData_RHS[i].z) / 2;
                result &= x.w == (((Tests.Short4.TestData_LHS[i].w + Tests.Short4.TestData_RHS[i].w) > 0 ? 1 : -1) + Tests.Short4.TestData_LHS[i].w + Tests.Short4.TestData_RHS[i].w) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Short8()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short8.NUM_TESTS; i++)
            {
                short8 x = maxmath.avg(Tests.Short8.TestData_LHS[i], Tests.Short8.TestData_RHS[i]);

                result &= x.x0 == (((Tests.Short8.TestData_LHS[i].x0 + Tests.Short8.TestData_RHS[i].x0) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x0 + Tests.Short8.TestData_RHS[i].x0) / 2;
                result &= x.x1 == (((Tests.Short8.TestData_LHS[i].x1 + Tests.Short8.TestData_RHS[i].x1) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x1 + Tests.Short8.TestData_RHS[i].x1) / 2;
                result &= x.x2 == (((Tests.Short8.TestData_LHS[i].x2 + Tests.Short8.TestData_RHS[i].x2) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x2 + Tests.Short8.TestData_RHS[i].x2) / 2;
                result &= x.x3 == (((Tests.Short8.TestData_LHS[i].x3 + Tests.Short8.TestData_RHS[i].x3) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x3 + Tests.Short8.TestData_RHS[i].x3) / 2;
                result &= x.x4 == (((Tests.Short8.TestData_LHS[i].x4 + Tests.Short8.TestData_RHS[i].x4) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x4 + Tests.Short8.TestData_RHS[i].x4) / 2;
                result &= x.x5 == (((Tests.Short8.TestData_LHS[i].x5 + Tests.Short8.TestData_RHS[i].x5) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x5 + Tests.Short8.TestData_RHS[i].x5) / 2;
                result &= x.x6 == (((Tests.Short8.TestData_LHS[i].x6 + Tests.Short8.TestData_RHS[i].x6) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x6 + Tests.Short8.TestData_RHS[i].x6) / 2;
                result &= x.x7 == (((Tests.Short8.TestData_LHS[i].x7 + Tests.Short8.TestData_RHS[i].x7) > 0 ? 1 : -1) + Tests.Short8.TestData_LHS[i].x7 + Tests.Short8.TestData_RHS[i].x7) / 2;
            }

            return result;
        }

        [UnitTest("Functions", "Arithmetic", "Average")]
        public static bool Short16()
        {
            bool result = true;

            for (int i = 0; i < Tests.Short16.NUM_TESTS; i++)
            {
                short16 x = maxmath.avg(Tests.Short16.TestData_LHS[i], Tests.Short16.TestData_RHS[i]);

                result &= x.x0  == (((Tests.Short16.TestData_LHS[i].x0  + Tests.Short16.TestData_RHS[i].x0)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x0  + Tests.Short16.TestData_RHS[i].x0)  / 2;
                result &= x.x1  == (((Tests.Short16.TestData_LHS[i].x1  + Tests.Short16.TestData_RHS[i].x1)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x1  + Tests.Short16.TestData_RHS[i].x1)  / 2;
                result &= x.x2  == (((Tests.Short16.TestData_LHS[i].x2  + Tests.Short16.TestData_RHS[i].x2)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x2  + Tests.Short16.TestData_RHS[i].x2)  / 2;
                result &= x.x3  == (((Tests.Short16.TestData_LHS[i].x3  + Tests.Short16.TestData_RHS[i].x3)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x3  + Tests.Short16.TestData_RHS[i].x3)  / 2;
                result &= x.x4  == (((Tests.Short16.TestData_LHS[i].x4  + Tests.Short16.TestData_RHS[i].x4)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x4  + Tests.Short16.TestData_RHS[i].x4)  / 2;
                result &= x.x5  == (((Tests.Short16.TestData_LHS[i].x5  + Tests.Short16.TestData_RHS[i].x5)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x5  + Tests.Short16.TestData_RHS[i].x5)  / 2;
                result &= x.x6  == (((Tests.Short16.TestData_LHS[i].x6  + Tests.Short16.TestData_RHS[i].x6)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x6  + Tests.Short16.TestData_RHS[i].x6)  / 2;
                result &= x.x7  == (((Tests.Short16.TestData_LHS[i].x7  + Tests.Short16.TestData_RHS[i].x7)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x7  + Tests.Short16.TestData_RHS[i].x7)  / 2;
                result &= x.x8  == (((Tests.Short16.TestData_LHS[i].x8  + Tests.Short16.TestData_RHS[i].x8)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x8  + Tests.Short16.TestData_RHS[i].x8)  / 2;
                result &= x.x9  == (((Tests.Short16.TestData_LHS[i].x9  + Tests.Short16.TestData_RHS[i].x9)  > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x9  + Tests.Short16.TestData_RHS[i].x9)  / 2;
                result &= x.x10 == (((Tests.Short16.TestData_LHS[i].x10 + Tests.Short16.TestData_RHS[i].x10) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x10 + Tests.Short16.TestData_RHS[i].x10) / 2;
                result &= x.x11 == (((Tests.Short16.TestData_LHS[i].x11 + Tests.Short16.TestData_RHS[i].x11) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x11 + Tests.Short16.TestData_RHS[i].x11) / 2;
                result &= x.x12 == (((Tests.Short16.TestData_LHS[i].x12 + Tests.Short16.TestData_RHS[i].x12) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x12 + Tests.Short16.TestData_RHS[i].x12) / 2;
                result &= x.x13 == (((Tests.Short16.TestData_LHS[i].x13 + Tests.Short16.TestData_RHS[i].x13) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x13 + Tests.Short16.TestData_RHS[i].x13) / 2;
                result &= x.x14 == (((Tests.Short16.TestData_LHS[i].x14 + Tests.Short16.TestData_RHS[i].x14) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x14 + Tests.Short16.TestData_RHS[i].x14) / 2;
                result &= x.x15 == (((Tests.Short16.TestData_LHS[i].x15 + Tests.Short16.TestData_RHS[i].x15) > 0 ? 1 : -1) + Tests.Short16.TestData_LHS[i].x15 + Tests.Short16.TestData_RHS[i].x15) / 2;
            }

            return result;
        }
    }
#endif
}