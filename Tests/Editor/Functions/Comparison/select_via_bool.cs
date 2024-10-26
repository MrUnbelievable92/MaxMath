using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_select_via_bool
    {
        [Test]
        public static void _byte2_via_bool()
        {
            bool result = true;


            byte2 selected;

            selected = maxmath.select(t_byte2.TestData_LHS[0], t_byte2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_byte2.TestData_LHS[0].x;
            result &= selected.y == t_byte2.TestData_RHS[0].y;

            selected = maxmath.select(t_byte2.TestData_LHS[1], t_byte2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_byte2.TestData_RHS[1].x;
            result &= selected.y == t_byte2.TestData_RHS[1].y;

            selected = maxmath.select(t_byte2.TestData_LHS[2], t_byte2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_byte2.TestData_LHS[2].x;
            result &= selected.y == t_byte2.TestData_LHS[2].y;

            selected = maxmath.select(t_byte2.TestData_LHS[3], t_byte2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_byte2.TestData_RHS[3].x;
            result &= selected.y == t_byte2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte2_via_bool()
        {
            bool result = true;


            sbyte2 selected;

            selected = maxmath.select(t_sbyte2.TestData_LHS[0], t_sbyte2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_sbyte2.TestData_LHS[0].x;
            result &= selected.y == t_sbyte2.TestData_RHS[0].y;

            selected = maxmath.select(t_sbyte2.TestData_LHS[1], t_sbyte2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_sbyte2.TestData_RHS[1].x;
            result &= selected.y == t_sbyte2.TestData_RHS[1].y;

            selected = maxmath.select(t_sbyte2.TestData_LHS[2], t_sbyte2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_sbyte2.TestData_LHS[2].x;
            result &= selected.y == t_sbyte2.TestData_LHS[2].y;

            selected = maxmath.select(t_sbyte2.TestData_LHS[3], t_sbyte2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_sbyte2.TestData_RHS[3].x;
            result &= selected.y == t_sbyte2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _byte3_via_bool()
        {
            bool result = true;


            byte3 selected;

            selected = maxmath.select(t_byte3.TestData_LHS[0], t_byte3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_byte3.TestData_LHS[0].x;
            result &= selected.y == t_byte3.TestData_RHS[0].y;
            result &= selected.z == t_byte3.TestData_RHS[0].z;

            selected = maxmath.select(t_byte3.TestData_LHS[1], t_byte3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_byte3.TestData_RHS[1].x;
            result &= selected.y == t_byte3.TestData_RHS[1].y;
            result &= selected.z == t_byte3.TestData_LHS[1].z;

            selected = maxmath.select(t_byte3.TestData_LHS[2], t_byte3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_byte3.TestData_LHS[2].x;
            result &= selected.y == t_byte3.TestData_LHS[2].y;
            result &= selected.z == t_byte3.TestData_RHS[2].z;

            selected = maxmath.select(t_byte3.TestData_LHS[3], t_byte3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_byte3.TestData_RHS[3].x;
            result &= selected.y == t_byte3.TestData_LHS[3].y;
            result &= selected.z == t_byte3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte3_via_bool()
        {
            bool result = true;


            sbyte3 selected;

            selected = maxmath.select(t_sbyte3.TestData_LHS[0], t_sbyte3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_sbyte3.TestData_LHS[0].x;
            result &= selected.y == t_sbyte3.TestData_RHS[0].y;
            result &= selected.z == t_sbyte3.TestData_RHS[0].z;

            selected = maxmath.select(t_sbyte3.TestData_LHS[1], t_sbyte3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_sbyte3.TestData_RHS[1].x;
            result &= selected.y == t_sbyte3.TestData_RHS[1].y;
            result &= selected.z == t_sbyte3.TestData_LHS[1].z;

            selected = maxmath.select(t_sbyte3.TestData_LHS[2], t_sbyte3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_sbyte3.TestData_LHS[2].x;
            result &= selected.y == t_sbyte3.TestData_LHS[2].y;
            result &= selected.z == t_sbyte3.TestData_RHS[2].z;

            selected = maxmath.select(t_sbyte3.TestData_LHS[3], t_sbyte3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_sbyte3.TestData_RHS[3].x;
            result &= selected.y == t_sbyte3.TestData_LHS[3].y;
            result &= selected.z == t_sbyte3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _byte4_via_bool()
        {
            bool result = true;


            byte4 selected;

            selected = maxmath.select(t_byte4.TestData_LHS[0], t_byte4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_byte4.TestData_LHS[0].x;
            result &= selected.y == t_byte4.TestData_RHS[0].y;
            result &= selected.z == t_byte4.TestData_RHS[0].z;
            result &= selected.w == t_byte4.TestData_RHS[0].w;

            selected = maxmath.select(t_byte4.TestData_LHS[1], t_byte4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_byte4.TestData_RHS[1].x;
            result &= selected.y == t_byte4.TestData_RHS[1].y;
            result &= selected.z == t_byte4.TestData_RHS[1].z;
            result &= selected.w == t_byte4.TestData_LHS[1].w;

            selected = maxmath.select(t_byte4.TestData_LHS[2], t_byte4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_byte4.TestData_LHS[2].x;
            result &= selected.y == t_byte4.TestData_RHS[2].y;
            result &= selected.z == t_byte4.TestData_RHS[2].z;
            result &= selected.w == t_byte4.TestData_LHS[2].w;

            selected = maxmath.select(t_byte4.TestData_LHS[3], t_byte4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_byte4.TestData_RHS[3].x;
            result &= selected.y == t_byte4.TestData_LHS[3].y;
            result &= selected.z == t_byte4.TestData_RHS[3].z;
            result &= selected.w == t_byte4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte4_via_bool()
        {
            bool result = true;


            sbyte4 selected;

            selected = maxmath.select(t_sbyte4.TestData_LHS[0], t_sbyte4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_sbyte4.TestData_LHS[0].x;
            result &= selected.y == t_sbyte4.TestData_RHS[0].y;
            result &= selected.z == t_sbyte4.TestData_RHS[0].z;
            result &= selected.w == t_sbyte4.TestData_RHS[0].w;

            selected = maxmath.select(t_sbyte4.TestData_LHS[1], t_sbyte4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_sbyte4.TestData_RHS[1].x;
            result &= selected.y == t_sbyte4.TestData_RHS[1].y;
            result &= selected.z == t_sbyte4.TestData_RHS[1].z;
            result &= selected.w == t_sbyte4.TestData_LHS[1].w;

            selected = maxmath.select(t_sbyte4.TestData_LHS[2], t_sbyte4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_sbyte4.TestData_LHS[2].x;
            result &= selected.y == t_sbyte4.TestData_RHS[2].y;
            result &= selected.z == t_sbyte4.TestData_RHS[2].z;
            result &= selected.w == t_sbyte4.TestData_LHS[2].w;

            selected = maxmath.select(t_sbyte4.TestData_LHS[3], t_sbyte4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_sbyte4.TestData_RHS[3].x;
            result &= selected.y == t_sbyte4.TestData_LHS[3].y;
            result &= selected.z == t_sbyte4.TestData_RHS[3].z;
            result &= selected.w == t_sbyte4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _byte8_via_bool()
        {
            bool result = true;


            byte8 selected;

            selected = maxmath.select(t_byte8.TestData_LHS[0], t_byte8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_byte8.TestData_RHS[0].x0;
            result &= selected.x1  == t_byte8.TestData_RHS[0].x1;
            result &= selected.x2  == t_byte8.TestData_LHS[0].x2;
            result &= selected.x3  == t_byte8.TestData_RHS[0].x3;
            result &= selected.x4  == t_byte8.TestData_RHS[0].x4;
            result &= selected.x5  == t_byte8.TestData_RHS[0].x5;
            result &= selected.x6  == t_byte8.TestData_LHS[0].x6;
            result &= selected.x7  == t_byte8.TestData_RHS[0].x7;

            selected = maxmath.select(t_byte8.TestData_LHS[1], t_byte8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_byte8.TestData_RHS[1].x0;
            result &= selected.x1  == t_byte8.TestData_RHS[1].x1;
            result &= selected.x2  == t_byte8.TestData_LHS[1].x2;
            result &= selected.x3  == t_byte8.TestData_LHS[1].x3;
            result &= selected.x4  == t_byte8.TestData_LHS[1].x4;
            result &= selected.x5  == t_byte8.TestData_RHS[1].x5;
            result &= selected.x6  == t_byte8.TestData_RHS[1].x6;
            result &= selected.x7  == t_byte8.TestData_RHS[1].x7;

            selected = maxmath.select(t_byte8.TestData_LHS[2], t_byte8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_byte8.TestData_RHS[2].x0;
            result &= selected.x1  == t_byte8.TestData_LHS[2].x1;
            result &= selected.x2  == t_byte8.TestData_LHS[2].x2;
            result &= selected.x3  == t_byte8.TestData_RHS[2].x3;
            result &= selected.x4  == t_byte8.TestData_LHS[2].x4;
            result &= selected.x5  == t_byte8.TestData_RHS[2].x5;
            result &= selected.x6  == t_byte8.TestData_LHS[2].x6;
            result &= selected.x7  == t_byte8.TestData_LHS[2].x7;

            selected = maxmath.select(t_byte8.TestData_LHS[3], t_byte8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_byte8.TestData_RHS[3].x0;
            result &= selected.x1  == t_byte8.TestData_RHS[3].x1;
            result &= selected.x2  == t_byte8.TestData_LHS[3].x2;
            result &= selected.x3  == t_byte8.TestData_RHS[3].x3;
            result &= selected.x4  == t_byte8.TestData_RHS[3].x4;
            result &= selected.x5  == t_byte8.TestData_RHS[3].x5;
            result &= selected.x6  == t_byte8.TestData_RHS[3].x6;
            result &= selected.x7  == t_byte8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte8_via_bool()
        {
            bool result = true;


            sbyte8 selected;

            selected = maxmath.select(t_sbyte8.TestData_LHS[0], t_sbyte8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_sbyte8.TestData_RHS[0].x0;
            result &= selected.x1  == t_sbyte8.TestData_RHS[0].x1;
            result &= selected.x2  == t_sbyte8.TestData_LHS[0].x2;
            result &= selected.x3  == t_sbyte8.TestData_RHS[0].x3;
            result &= selected.x4  == t_sbyte8.TestData_RHS[0].x4;
            result &= selected.x5  == t_sbyte8.TestData_RHS[0].x5;
            result &= selected.x6  == t_sbyte8.TestData_LHS[0].x6;
            result &= selected.x7  == t_sbyte8.TestData_RHS[0].x7;

            selected = maxmath.select(t_sbyte8.TestData_LHS[1], t_sbyte8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_sbyte8.TestData_RHS[1].x0;
            result &= selected.x1  == t_sbyte8.TestData_RHS[1].x1;
            result &= selected.x2  == t_sbyte8.TestData_LHS[1].x2;
            result &= selected.x3  == t_sbyte8.TestData_LHS[1].x3;
            result &= selected.x4  == t_sbyte8.TestData_LHS[1].x4;
            result &= selected.x5  == t_sbyte8.TestData_RHS[1].x5;
            result &= selected.x6  == t_sbyte8.TestData_RHS[1].x6;
            result &= selected.x7  == t_sbyte8.TestData_RHS[1].x7;

            selected = maxmath.select(t_sbyte8.TestData_LHS[2], t_sbyte8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_sbyte8.TestData_RHS[2].x0;
            result &= selected.x1  == t_sbyte8.TestData_LHS[2].x1;
            result &= selected.x2  == t_sbyte8.TestData_LHS[2].x2;
            result &= selected.x3  == t_sbyte8.TestData_RHS[2].x3;
            result &= selected.x4  == t_sbyte8.TestData_LHS[2].x4;
            result &= selected.x5  == t_sbyte8.TestData_RHS[2].x5;
            result &= selected.x6  == t_sbyte8.TestData_LHS[2].x6;
            result &= selected.x7  == t_sbyte8.TestData_LHS[2].x7;

            selected = maxmath.select(t_sbyte8.TestData_LHS[3], t_sbyte8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_sbyte8.TestData_RHS[3].x0;
            result &= selected.x1  == t_sbyte8.TestData_RHS[3].x1;
            result &= selected.x2  == t_sbyte8.TestData_LHS[3].x2;
            result &= selected.x3  == t_sbyte8.TestData_RHS[3].x3;
            result &= selected.x4  == t_sbyte8.TestData_RHS[3].x4;
            result &= selected.x5  == t_sbyte8.TestData_RHS[3].x5;
            result &= selected.x6  == t_sbyte8.TestData_RHS[3].x6;
            result &= selected.x7  == t_sbyte8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _byte16_via_bool()
        {
            bool result = true;


            byte16 selected;

            selected = maxmath.select(t_byte16.TestData_LHS[0], t_byte16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == t_byte16.TestData_RHS[0].x0;
            result &= selected.x1  == t_byte16.TestData_RHS[0].x1;
            result &= selected.x2  == t_byte16.TestData_LHS[0].x2;
            result &= selected.x3  == t_byte16.TestData_RHS[0].x3;
            result &= selected.x4  == t_byte16.TestData_RHS[0].x4;
            result &= selected.x5  == t_byte16.TestData_RHS[0].x5;
            result &= selected.x6  == t_byte16.TestData_LHS[0].x6;
            result &= selected.x7  == t_byte16.TestData_RHS[0].x7;
            result &= selected.x8  == t_byte16.TestData_LHS[0].x8;
            result &= selected.x9  == t_byte16.TestData_RHS[0].x9;
            result &= selected.x10 == t_byte16.TestData_LHS[0].x10;
            result &= selected.x11 == t_byte16.TestData_RHS[0].x11;
            result &= selected.x12 == t_byte16.TestData_LHS[0].x12;
            result &= selected.x13 == t_byte16.TestData_RHS[0].x13;
            result &= selected.x14 == t_byte16.TestData_LHS[0].x14;
            result &= selected.x15 == t_byte16.TestData_RHS[0].x15;

            selected = maxmath.select(t_byte16.TestData_LHS[1], t_byte16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == t_byte16.TestData_RHS[1].x0;
            result &= selected.x1  == t_byte16.TestData_RHS[1].x1;
            result &= selected.x2  == t_byte16.TestData_LHS[1].x2;
            result &= selected.x3  == t_byte16.TestData_LHS[1].x3;
            result &= selected.x4  == t_byte16.TestData_LHS[1].x4;
            result &= selected.x5  == t_byte16.TestData_RHS[1].x5;
            result &= selected.x6  == t_byte16.TestData_RHS[1].x6;
            result &= selected.x7  == t_byte16.TestData_RHS[1].x7;
            result &= selected.x8  == t_byte16.TestData_RHS[1].x8;
            result &= selected.x9  == t_byte16.TestData_RHS[1].x9;
            result &= selected.x10 == t_byte16.TestData_LHS[1].x10;
            result &= selected.x11 == t_byte16.TestData_LHS[1].x11;
            result &= selected.x12 == t_byte16.TestData_LHS[1].x12;
            result &= selected.x13 == t_byte16.TestData_RHS[1].x13;
            result &= selected.x14 == t_byte16.TestData_LHS[1].x14;
            result &= selected.x15 == t_byte16.TestData_LHS[1].x15;

            selected = maxmath.select(t_byte16.TestData_LHS[2], t_byte16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == t_byte16.TestData_RHS[2].x0;
            result &= selected.x1  == t_byte16.TestData_LHS[2].x1;
            result &= selected.x2  == t_byte16.TestData_LHS[2].x2;
            result &= selected.x3  == t_byte16.TestData_RHS[2].x3;
            result &= selected.x4  == t_byte16.TestData_LHS[2].x4;
            result &= selected.x5  == t_byte16.TestData_RHS[2].x5;
            result &= selected.x6  == t_byte16.TestData_LHS[2].x6;
            result &= selected.x7  == t_byte16.TestData_LHS[2].x7;
            result &= selected.x8  == t_byte16.TestData_RHS[2].x8;
            result &= selected.x9  == t_byte16.TestData_RHS[2].x9;
            result &= selected.x10 == t_byte16.TestData_LHS[2].x10;
            result &= selected.x11 == t_byte16.TestData_RHS[2].x11;
            result &= selected.x12 == t_byte16.TestData_RHS[2].x12;
            result &= selected.x13 == t_byte16.TestData_RHS[2].x13;
            result &= selected.x14 == t_byte16.TestData_RHS[2].x14;
            result &= selected.x15 == t_byte16.TestData_LHS[2].x15;

            selected = maxmath.select(t_byte16.TestData_LHS[3], t_byte16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == t_byte16.TestData_RHS[3].x0;
            result &= selected.x1  == t_byte16.TestData_RHS[3].x1;
            result &= selected.x2  == t_byte16.TestData_LHS[3].x2;
            result &= selected.x3  == t_byte16.TestData_RHS[3].x3;
            result &= selected.x4  == t_byte16.TestData_RHS[3].x4;
            result &= selected.x5  == t_byte16.TestData_RHS[3].x5;
            result &= selected.x6  == t_byte16.TestData_RHS[3].x6;
            result &= selected.x7  == t_byte16.TestData_RHS[3].x7;
            result &= selected.x8  == t_byte16.TestData_LHS[3].x8;
            result &= selected.x9  == t_byte16.TestData_RHS[3].x9;
            result &= selected.x10 == t_byte16.TestData_RHS[3].x10;
            result &= selected.x11 == t_byte16.TestData_RHS[3].x11;
            result &= selected.x12 == t_byte16.TestData_LHS[3].x12;
            result &= selected.x13 == t_byte16.TestData_RHS[3].x13;
            result &= selected.x14 == t_byte16.TestData_LHS[3].x14;
            result &= selected.x15 == t_byte16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte16_via_bool()
        {
            bool result = true;


            sbyte16 selected;

            selected = maxmath.select(t_sbyte16.TestData_LHS[0], t_sbyte16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == t_sbyte16.TestData_RHS[0].x0;
            result &= selected.x1  == t_sbyte16.TestData_RHS[0].x1;
            result &= selected.x2  == t_sbyte16.TestData_LHS[0].x2;
            result &= selected.x3  == t_sbyte16.TestData_RHS[0].x3;
            result &= selected.x4  == t_sbyte16.TestData_RHS[0].x4;
            result &= selected.x5  == t_sbyte16.TestData_RHS[0].x5;
            result &= selected.x6  == t_sbyte16.TestData_LHS[0].x6;
            result &= selected.x7  == t_sbyte16.TestData_RHS[0].x7;
            result &= selected.x8  == t_sbyte16.TestData_LHS[0].x8;
            result &= selected.x9  == t_sbyte16.TestData_RHS[0].x9;
            result &= selected.x10 == t_sbyte16.TestData_LHS[0].x10;
            result &= selected.x11 == t_sbyte16.TestData_RHS[0].x11;
            result &= selected.x12 == t_sbyte16.TestData_LHS[0].x12;
            result &= selected.x13 == t_sbyte16.TestData_RHS[0].x13;
            result &= selected.x14 == t_sbyte16.TestData_LHS[0].x14;
            result &= selected.x15 == t_sbyte16.TestData_RHS[0].x15;

            selected = maxmath.select(t_sbyte16.TestData_LHS[1], t_sbyte16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == t_sbyte16.TestData_RHS[1].x0;
            result &= selected.x1  == t_sbyte16.TestData_RHS[1].x1;
            result &= selected.x2  == t_sbyte16.TestData_LHS[1].x2;
            result &= selected.x3  == t_sbyte16.TestData_LHS[1].x3;
            result &= selected.x4  == t_sbyte16.TestData_LHS[1].x4;
            result &= selected.x5  == t_sbyte16.TestData_RHS[1].x5;
            result &= selected.x6  == t_sbyte16.TestData_RHS[1].x6;
            result &= selected.x7  == t_sbyte16.TestData_RHS[1].x7;
            result &= selected.x8  == t_sbyte16.TestData_RHS[1].x8;
            result &= selected.x9  == t_sbyte16.TestData_RHS[1].x9;
            result &= selected.x10 == t_sbyte16.TestData_LHS[1].x10;
            result &= selected.x11 == t_sbyte16.TestData_LHS[1].x11;
            result &= selected.x12 == t_sbyte16.TestData_LHS[1].x12;
            result &= selected.x13 == t_sbyte16.TestData_RHS[1].x13;
            result &= selected.x14 == t_sbyte16.TestData_LHS[1].x14;
            result &= selected.x15 == t_sbyte16.TestData_LHS[1].x15;

            selected = maxmath.select(t_sbyte16.TestData_LHS[2], t_sbyte16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == t_sbyte16.TestData_RHS[2].x0;
            result &= selected.x1  == t_sbyte16.TestData_LHS[2].x1;
            result &= selected.x2  == t_sbyte16.TestData_LHS[2].x2;
            result &= selected.x3  == t_sbyte16.TestData_RHS[2].x3;
            result &= selected.x4  == t_sbyte16.TestData_LHS[2].x4;
            result &= selected.x5  == t_sbyte16.TestData_RHS[2].x5;
            result &= selected.x6  == t_sbyte16.TestData_LHS[2].x6;
            result &= selected.x7  == t_sbyte16.TestData_LHS[2].x7;
            result &= selected.x8  == t_sbyte16.TestData_RHS[2].x8;
            result &= selected.x9  == t_sbyte16.TestData_RHS[2].x9;
            result &= selected.x10 == t_sbyte16.TestData_LHS[2].x10;
            result &= selected.x11 == t_sbyte16.TestData_RHS[2].x11;
            result &= selected.x12 == t_sbyte16.TestData_RHS[2].x12;
            result &= selected.x13 == t_sbyte16.TestData_RHS[2].x13;
            result &= selected.x14 == t_sbyte16.TestData_RHS[2].x14;
            result &= selected.x15 == t_sbyte16.TestData_LHS[2].x15;

            selected = maxmath.select(t_sbyte16.TestData_LHS[3], t_sbyte16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == t_sbyte16.TestData_RHS[3].x0;
            result &= selected.x1  == t_sbyte16.TestData_RHS[3].x1;
            result &= selected.x2  == t_sbyte16.TestData_LHS[3].x2;
            result &= selected.x3  == t_sbyte16.TestData_RHS[3].x3;
            result &= selected.x4  == t_sbyte16.TestData_RHS[3].x4;
            result &= selected.x5  == t_sbyte16.TestData_RHS[3].x5;
            result &= selected.x6  == t_sbyte16.TestData_RHS[3].x6;
            result &= selected.x7  == t_sbyte16.TestData_RHS[3].x7;
            result &= selected.x8  == t_sbyte16.TestData_LHS[3].x8;
            result &= selected.x9  == t_sbyte16.TestData_RHS[3].x9;
            result &= selected.x10 == t_sbyte16.TestData_RHS[3].x10;
            result &= selected.x11 == t_sbyte16.TestData_RHS[3].x11;
            result &= selected.x12 == t_sbyte16.TestData_LHS[3].x12;
            result &= selected.x13 == t_sbyte16.TestData_RHS[3].x13;
            result &= selected.x14 == t_sbyte16.TestData_LHS[3].x14;
            result &= selected.x15 == t_sbyte16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _byte32_via_bool()
        {
            bool result = true;


            byte32 selected;

            selected = maxmath.select(t_byte32.TestData_LHS[0], t_byte32.TestData_RHS[0], new bool32(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true, false, false, true, false, true, true, false, true, true, false, false, false, true,false, true, false));
            result &= selected.x0  == t_byte32.TestData_RHS[0].x0;
            result &= selected.x1  == t_byte32.TestData_RHS[0].x1;
            result &= selected.x2  == t_byte32.TestData_LHS[0].x2;
            result &= selected.x3  == t_byte32.TestData_RHS[0].x3;
            result &= selected.x4  == t_byte32.TestData_RHS[0].x4;
            result &= selected.x5  == t_byte32.TestData_RHS[0].x5;
            result &= selected.x6  == t_byte32.TestData_LHS[0].x6;
            result &= selected.x7  == t_byte32.TestData_RHS[0].x7;
            result &= selected.x8  == t_byte32.TestData_LHS[0].x8;
            result &= selected.x9  == t_byte32.TestData_RHS[0].x9;
            result &= selected.x10 == t_byte32.TestData_LHS[0].x10;
            result &= selected.x11 == t_byte32.TestData_RHS[0].x11;
            result &= selected.x12 == t_byte32.TestData_LHS[0].x12;
            result &= selected.x13 == t_byte32.TestData_RHS[0].x13;
            result &= selected.x14 == t_byte32.TestData_LHS[0].x14;
            result &= selected.x15 == t_byte32.TestData_RHS[0].x15;
            result &= selected.x16 == t_byte32.TestData_LHS[0].x16;
            result &= selected.x17 == t_byte32.TestData_LHS[0].x17;
            result &= selected.x18 == t_byte32.TestData_RHS[0].x18;
            result &= selected.x19 == t_byte32.TestData_LHS[0].x19;
            result &= selected.x20 == t_byte32.TestData_RHS[0].x20;
            result &= selected.x21 == t_byte32.TestData_RHS[0].x21;
            result &= selected.x22 == t_byte32.TestData_LHS[0].x22;
            result &= selected.x23 == t_byte32.TestData_RHS[0].x23;
            result &= selected.x24 == t_byte32.TestData_RHS[0].x24;
            result &= selected.x25 == t_byte32.TestData_LHS[0].x25;
            result &= selected.x26 == t_byte32.TestData_LHS[0].x26;
            result &= selected.x27 == t_byte32.TestData_LHS[0].x27;
            result &= selected.x28 == t_byte32.TestData_RHS[0].x28;
            result &= selected.x29 == t_byte32.TestData_LHS[0].x29;
            result &= selected.x30 == t_byte32.TestData_RHS[0].x30;
            result &= selected.x31 == t_byte32.TestData_LHS[0].x31;

            selected = maxmath.select(t_byte32.TestData_LHS[1], t_byte32.TestData_RHS[1], new bool32(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false, false, true, false, true, false, false, true, false, false, true, true, true, true, false, true, true));
            result &= selected.x0  == t_byte32.TestData_RHS[1].x0;
            result &= selected.x1  == t_byte32.TestData_RHS[1].x1;
            result &= selected.x2  == t_byte32.TestData_LHS[1].x2;
            result &= selected.x3  == t_byte32.TestData_LHS[1].x3;
            result &= selected.x4  == t_byte32.TestData_LHS[1].x4;
            result &= selected.x5  == t_byte32.TestData_RHS[1].x5;
            result &= selected.x6  == t_byte32.TestData_RHS[1].x6;
            result &= selected.x7  == t_byte32.TestData_RHS[1].x7;
            result &= selected.x8  == t_byte32.TestData_RHS[1].x8;
            result &= selected.x9  == t_byte32.TestData_RHS[1].x9;
            result &= selected.x10 == t_byte32.TestData_LHS[1].x10;
            result &= selected.x11 == t_byte32.TestData_LHS[1].x11;
            result &= selected.x12 == t_byte32.TestData_LHS[1].x12;
            result &= selected.x13 == t_byte32.TestData_RHS[1].x13;
            result &= selected.x14 == t_byte32.TestData_LHS[1].x14;
            result &= selected.x15 == t_byte32.TestData_LHS[1].x15;
            result &= selected.x16 == t_byte32.TestData_LHS[1].x16;
            result &= selected.x17 == t_byte32.TestData_RHS[1].x17;
            result &= selected.x18 == t_byte32.TestData_LHS[1].x18;
            result &= selected.x19 == t_byte32.TestData_RHS[1].x19;
            result &= selected.x20 == t_byte32.TestData_LHS[1].x20;
            result &= selected.x21 == t_byte32.TestData_LHS[1].x21;
            result &= selected.x22 == t_byte32.TestData_RHS[1].x22;
            result &= selected.x23 == t_byte32.TestData_LHS[1].x23;
            result &= selected.x24 == t_byte32.TestData_LHS[1].x24;
            result &= selected.x25 == t_byte32.TestData_RHS[1].x25;
            result &= selected.x26 == t_byte32.TestData_RHS[1].x26;
            result &= selected.x27 == t_byte32.TestData_RHS[1].x27;
            result &= selected.x28 == t_byte32.TestData_RHS[1].x28;
            result &= selected.x29 == t_byte32.TestData_LHS[1].x29;
            result &= selected.x30 == t_byte32.TestData_RHS[1].x30;
            result &= selected.x31 == t_byte32.TestData_RHS[1].x31;

            selected = maxmath.select(t_byte32.TestData_LHS[2], t_byte32.TestData_RHS[2], new bool32(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false, true ,false, true, true, false, true, false, true, true, true, false, true, true ,false, false, false));
            result &= selected.x0  == t_byte32.TestData_RHS[2].x0;
            result &= selected.x1  == t_byte32.TestData_LHS[2].x1;
            result &= selected.x2  == t_byte32.TestData_LHS[2].x2;
            result &= selected.x3  == t_byte32.TestData_RHS[2].x3;
            result &= selected.x4  == t_byte32.TestData_LHS[2].x4;
            result &= selected.x5  == t_byte32.TestData_RHS[2].x5;
            result &= selected.x6  == t_byte32.TestData_LHS[2].x6;
            result &= selected.x7  == t_byte32.TestData_LHS[2].x7;
            result &= selected.x8  == t_byte32.TestData_RHS[2].x8;
            result &= selected.x9  == t_byte32.TestData_RHS[2].x9;
            result &= selected.x10 == t_byte32.TestData_LHS[2].x10;
            result &= selected.x11 == t_byte32.TestData_RHS[2].x11;
            result &= selected.x12 == t_byte32.TestData_RHS[2].x12;
            result &= selected.x13 == t_byte32.TestData_RHS[2].x13;
            result &= selected.x14 == t_byte32.TestData_RHS[2].x14;
            result &= selected.x15 == t_byte32.TestData_LHS[2].x15;
            result &= selected.x16 == t_byte32.TestData_RHS[2].x16;
            result &= selected.x17 == t_byte32.TestData_LHS[2].x17;
            result &= selected.x18 == t_byte32.TestData_RHS[2].x18;
            result &= selected.x19 == t_byte32.TestData_RHS[2].x19;
            result &= selected.x20 == t_byte32.TestData_LHS[2].x20;
            result &= selected.x21 == t_byte32.TestData_RHS[2].x21;
            result &= selected.x22 == t_byte32.TestData_LHS[2].x22;
            result &= selected.x23 == t_byte32.TestData_RHS[2].x23;
            result &= selected.x24 == t_byte32.TestData_RHS[2].x24;
            result &= selected.x25 == t_byte32.TestData_RHS[2].x25;
            result &= selected.x26 == t_byte32.TestData_LHS[2].x26;
            result &= selected.x27 == t_byte32.TestData_RHS[2].x27;
            result &= selected.x28 == t_byte32.TestData_RHS[2].x28;
            result &= selected.x29 == t_byte32.TestData_LHS[2].x29;
            result &= selected.x30 == t_byte32.TestData_LHS[2].x30;
            result &= selected.x31 == t_byte32.TestData_LHS[2].x31;

            selected = maxmath.select(t_byte32.TestData_LHS[3], t_byte32.TestData_RHS[3], new bool32(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false, true, false, true, false, true, false, false, true, true, false, false, true, true, true, true, false));
            result &= selected.x0  == t_byte32.TestData_RHS[3].x0;
            result &= selected.x1  == t_byte32.TestData_RHS[3].x1;
            result &= selected.x2  == t_byte32.TestData_LHS[3].x2;
            result &= selected.x3  == t_byte32.TestData_RHS[3].x3;
            result &= selected.x4  == t_byte32.TestData_RHS[3].x4;
            result &= selected.x5  == t_byte32.TestData_RHS[3].x5;
            result &= selected.x6  == t_byte32.TestData_RHS[3].x6;
            result &= selected.x7  == t_byte32.TestData_RHS[3].x7;
            result &= selected.x8  == t_byte32.TestData_LHS[3].x8;
            result &= selected.x9  == t_byte32.TestData_RHS[3].x9;
            result &= selected.x10 == t_byte32.TestData_RHS[3].x10;
            result &= selected.x11 == t_byte32.TestData_RHS[3].x11;
            result &= selected.x12 == t_byte32.TestData_LHS[3].x12;
            result &= selected.x13 == t_byte32.TestData_RHS[3].x13;
            result &= selected.x14 == t_byte32.TestData_LHS[3].x14;
            result &= selected.x15 == t_byte32.TestData_LHS[3].x15;
            result &= selected.x16 == t_byte32.TestData_RHS[3].x16;
            result &= selected.x17 == t_byte32.TestData_LHS[3].x17;
            result &= selected.x18 == t_byte32.TestData_RHS[3].x18;
            result &= selected.x19 == t_byte32.TestData_LHS[3].x19;
            result &= selected.x20 == t_byte32.TestData_RHS[3].x20;
            result &= selected.x21 == t_byte32.TestData_LHS[3].x21;
            result &= selected.x22 == t_byte32.TestData_LHS[3].x22;
            result &= selected.x23 == t_byte32.TestData_RHS[3].x23;
            result &= selected.x24 == t_byte32.TestData_RHS[3].x24;
            result &= selected.x25 == t_byte32.TestData_LHS[3].x25;
            result &= selected.x26 == t_byte32.TestData_LHS[3].x26;
            result &= selected.x27 == t_byte32.TestData_RHS[3].x27;
            result &= selected.x28 == t_byte32.TestData_RHS[3].x28;
            result &= selected.x29 == t_byte32.TestData_RHS[3].x29;
            result &= selected.x30 == t_byte32.TestData_RHS[3].x30;
            result &= selected.x31 == t_byte32.TestData_LHS[3].x31;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _sbyte32_via_bool()
        {
            bool result = true;


            sbyte32 selected;

            selected = maxmath.select(t_sbyte32.TestData_LHS[0], t_sbyte32.TestData_RHS[0], new bool32(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true, false, false, true, false, true, true, false, true, true, false, false, false, true, false, true, false));
            result &= selected.x0  == t_sbyte32.TestData_RHS[0].x0;
            result &= selected.x1  == t_sbyte32.TestData_RHS[0].x1;
            result &= selected.x2  == t_sbyte32.TestData_LHS[0].x2;
            result &= selected.x3  == t_sbyte32.TestData_RHS[0].x3;
            result &= selected.x4  == t_sbyte32.TestData_RHS[0].x4;
            result &= selected.x5  == t_sbyte32.TestData_RHS[0].x5;
            result &= selected.x6  == t_sbyte32.TestData_LHS[0].x6;
            result &= selected.x7  == t_sbyte32.TestData_RHS[0].x7;
            result &= selected.x8  == t_sbyte32.TestData_LHS[0].x8;
            result &= selected.x9  == t_sbyte32.TestData_RHS[0].x9;
            result &= selected.x10 == t_sbyte32.TestData_LHS[0].x10;
            result &= selected.x11 == t_sbyte32.TestData_RHS[0].x11;
            result &= selected.x12 == t_sbyte32.TestData_LHS[0].x12;
            result &= selected.x13 == t_sbyte32.TestData_RHS[0].x13;
            result &= selected.x14 == t_sbyte32.TestData_LHS[0].x14;
            result &= selected.x15 == t_sbyte32.TestData_RHS[0].x15;
            result &= selected.x16 == t_sbyte32.TestData_LHS[0].x16;
            result &= selected.x17 == t_sbyte32.TestData_LHS[0].x17;
            result &= selected.x18 == t_sbyte32.TestData_RHS[0].x18;
            result &= selected.x19 == t_sbyte32.TestData_LHS[0].x19;
            result &= selected.x20 == t_sbyte32.TestData_RHS[0].x20;
            result &= selected.x21 == t_sbyte32.TestData_RHS[0].x21;
            result &= selected.x22 == t_sbyte32.TestData_LHS[0].x22;
            result &= selected.x23 == t_sbyte32.TestData_RHS[0].x23;
            result &= selected.x24 == t_sbyte32.TestData_RHS[0].x24;
            result &= selected.x25 == t_sbyte32.TestData_LHS[0].x25;
            result &= selected.x26 == t_sbyte32.TestData_LHS[0].x26;
            result &= selected.x27 == t_sbyte32.TestData_LHS[0].x27;
            result &= selected.x28 == t_sbyte32.TestData_RHS[0].x28;
            result &= selected.x29 == t_sbyte32.TestData_LHS[0].x29;
            result &= selected.x30 == t_sbyte32.TestData_RHS[0].x30;
            result &= selected.x31 == t_sbyte32.TestData_LHS[0].x31;

            selected = maxmath.select(t_sbyte32.TestData_LHS[1], t_sbyte32.TestData_RHS[1], new bool32(true, true, false, false, false, true, true, true, true ,true ,false, false, false, true, false, false, false, true, false, true, false, false, true, false, false, true, true, true, true, false, true, true));
            result &= selected.x0  == t_sbyte32.TestData_RHS[1].x0;
            result &= selected.x1  == t_sbyte32.TestData_RHS[1].x1;
            result &= selected.x2  == t_sbyte32.TestData_LHS[1].x2;
            result &= selected.x3  == t_sbyte32.TestData_LHS[1].x3;
            result &= selected.x4  == t_sbyte32.TestData_LHS[1].x4;
            result &= selected.x5  == t_sbyte32.TestData_RHS[1].x5;
            result &= selected.x6  == t_sbyte32.TestData_RHS[1].x6;
            result &= selected.x7  == t_sbyte32.TestData_RHS[1].x7;
            result &= selected.x8  == t_sbyte32.TestData_RHS[1].x8;
            result &= selected.x9  == t_sbyte32.TestData_RHS[1].x9;
            result &= selected.x10 == t_sbyte32.TestData_LHS[1].x10;
            result &= selected.x11 == t_sbyte32.TestData_LHS[1].x11;
            result &= selected.x12 == t_sbyte32.TestData_LHS[1].x12;
            result &= selected.x13 == t_sbyte32.TestData_RHS[1].x13;
            result &= selected.x14 == t_sbyte32.TestData_LHS[1].x14;
            result &= selected.x15 == t_sbyte32.TestData_LHS[1].x15;
            result &= selected.x16 == t_sbyte32.TestData_LHS[1].x16;
            result &= selected.x17 == t_sbyte32.TestData_RHS[1].x17;
            result &= selected.x18 == t_sbyte32.TestData_LHS[1].x18;
            result &= selected.x19 == t_sbyte32.TestData_RHS[1].x19;
            result &= selected.x20 == t_sbyte32.TestData_LHS[1].x20;
            result &= selected.x21 == t_sbyte32.TestData_LHS[1].x21;
            result &= selected.x22 == t_sbyte32.TestData_RHS[1].x22;
            result &= selected.x23 == t_sbyte32.TestData_LHS[1].x23;
            result &= selected.x24 == t_sbyte32.TestData_LHS[1].x24;
            result &= selected.x25 == t_sbyte32.TestData_RHS[1].x25;
            result &= selected.x26 == t_sbyte32.TestData_RHS[1].x26;
            result &= selected.x27 == t_sbyte32.TestData_RHS[1].x27;
            result &= selected.x28 == t_sbyte32.TestData_RHS[1].x28;
            result &= selected.x29 == t_sbyte32.TestData_LHS[1].x29;
            result &= selected.x30 == t_sbyte32.TestData_RHS[1].x30;
            result &= selected.x31 == t_sbyte32.TestData_RHS[1].x31;

            selected = maxmath.select(t_sbyte32.TestData_LHS[2], t_sbyte32.TestData_RHS[2], new bool32(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false, true, false, true, true, false, true, false, true, true, true, false, true, true, false, false, false));
            result &= selected.x0  == t_sbyte32.TestData_RHS[2].x0;
            result &= selected.x1  == t_sbyte32.TestData_LHS[2].x1;
            result &= selected.x2  == t_sbyte32.TestData_LHS[2].x2;
            result &= selected.x3  == t_sbyte32.TestData_RHS[2].x3;
            result &= selected.x4  == t_sbyte32.TestData_LHS[2].x4;
            result &= selected.x5  == t_sbyte32.TestData_RHS[2].x5;
            result &= selected.x6  == t_sbyte32.TestData_LHS[2].x6;
            result &= selected.x7  == t_sbyte32.TestData_LHS[2].x7;
            result &= selected.x8  == t_sbyte32.TestData_RHS[2].x8;
            result &= selected.x9  == t_sbyte32.TestData_RHS[2].x9;
            result &= selected.x10 == t_sbyte32.TestData_LHS[2].x10;
            result &= selected.x11 == t_sbyte32.TestData_RHS[2].x11;
            result &= selected.x12 == t_sbyte32.TestData_RHS[2].x12;
            result &= selected.x13 == t_sbyte32.TestData_RHS[2].x13;
            result &= selected.x14 == t_sbyte32.TestData_RHS[2].x14;
            result &= selected.x15 == t_sbyte32.TestData_LHS[2].x15;
            result &= selected.x16 == t_sbyte32.TestData_RHS[2].x16;
            result &= selected.x17 == t_sbyte32.TestData_LHS[2].x17;
            result &= selected.x18 == t_sbyte32.TestData_RHS[2].x18;
            result &= selected.x19 == t_sbyte32.TestData_RHS[2].x19;
            result &= selected.x20 == t_sbyte32.TestData_LHS[2].x20;
            result &= selected.x21 == t_sbyte32.TestData_RHS[2].x21;
            result &= selected.x22 == t_sbyte32.TestData_LHS[2].x22;
            result &= selected.x23 == t_sbyte32.TestData_RHS[2].x23;
            result &= selected.x24 == t_sbyte32.TestData_RHS[2].x24;
            result &= selected.x25 == t_sbyte32.TestData_RHS[2].x25;
            result &= selected.x26 == t_sbyte32.TestData_LHS[2].x26;
            result &= selected.x27 == t_sbyte32.TestData_RHS[2].x27;
            result &= selected.x28 == t_sbyte32.TestData_RHS[2].x28;
            result &= selected.x29 == t_sbyte32.TestData_LHS[2].x29;
            result &= selected.x30 == t_sbyte32.TestData_LHS[2].x30;
            result &= selected.x31 == t_sbyte32.TestData_LHS[2].x31;

            selected = maxmath.select(t_sbyte32.TestData_LHS[3], t_sbyte32.TestData_RHS[3], new bool32(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false, true ,false, true, false, true, false, false, true ,true ,false, false, true, true, true, true ,false));
            result &= selected.x0  == t_sbyte32.TestData_RHS[3].x0;
            result &= selected.x1  == t_sbyte32.TestData_RHS[3].x1;
            result &= selected.x2  == t_sbyte32.TestData_LHS[3].x2;
            result &= selected.x3  == t_sbyte32.TestData_RHS[3].x3;
            result &= selected.x4  == t_sbyte32.TestData_RHS[3].x4;
            result &= selected.x5  == t_sbyte32.TestData_RHS[3].x5;
            result &= selected.x6  == t_sbyte32.TestData_RHS[3].x6;
            result &= selected.x7  == t_sbyte32.TestData_RHS[3].x7;
            result &= selected.x8  == t_sbyte32.TestData_LHS[3].x8;
            result &= selected.x9  == t_sbyte32.TestData_RHS[3].x9;
            result &= selected.x10 == t_sbyte32.TestData_RHS[3].x10;
            result &= selected.x11 == t_sbyte32.TestData_RHS[3].x11;
            result &= selected.x12 == t_sbyte32.TestData_LHS[3].x12;
            result &= selected.x13 == t_sbyte32.TestData_RHS[3].x13;
            result &= selected.x14 == t_sbyte32.TestData_LHS[3].x14;
            result &= selected.x15 == t_sbyte32.TestData_LHS[3].x15;
            result &= selected.x16 == t_sbyte32.TestData_RHS[3].x16;
            result &= selected.x17 == t_sbyte32.TestData_LHS[3].x17;
            result &= selected.x18 == t_sbyte32.TestData_RHS[3].x18;
            result &= selected.x19 == t_sbyte32.TestData_LHS[3].x19;
            result &= selected.x20 == t_sbyte32.TestData_RHS[3].x20;
            result &= selected.x21 == t_sbyte32.TestData_LHS[3].x21;
            result &= selected.x22 == t_sbyte32.TestData_LHS[3].x22;
            result &= selected.x23 == t_sbyte32.TestData_RHS[3].x23;
            result &= selected.x24 == t_sbyte32.TestData_RHS[3].x24;
            result &= selected.x25 == t_sbyte32.TestData_LHS[3].x25;
            result &= selected.x26 == t_sbyte32.TestData_LHS[3].x26;
            result &= selected.x27 == t_sbyte32.TestData_RHS[3].x27;
            result &= selected.x28 == t_sbyte32.TestData_RHS[3].x28;
            result &= selected.x29 == t_sbyte32.TestData_RHS[3].x29;
            result &= selected.x30 == t_sbyte32.TestData_RHS[3].x30;
            result &= selected.x31 == t_sbyte32.TestData_LHS[3].x31;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort2_via_bool()
        {
            bool result = true;


            ushort2 selected;

            selected = maxmath.select(t_ushort2.TestData_LHS[0], t_ushort2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_ushort2.TestData_LHS[0].x;
            result &= selected.y == t_ushort2.TestData_RHS[0].y;

            selected = maxmath.select(t_ushort2.TestData_LHS[1], t_ushort2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_ushort2.TestData_RHS[1].x;
            result &= selected.y == t_ushort2.TestData_RHS[1].y;

            selected = maxmath.select(t_ushort2.TestData_LHS[2], t_ushort2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_ushort2.TestData_LHS[2].x;
            result &= selected.y == t_ushort2.TestData_LHS[2].y;

            selected = maxmath.select(t_ushort2.TestData_LHS[3], t_ushort2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_ushort2.TestData_RHS[3].x;
            result &= selected.y == t_ushort2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short2_via_bool()
        {
            bool result = true;


            short2 selected;

            selected = maxmath.select(t_short2.TestData_LHS[0], t_short2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_short2.TestData_LHS[0].x;
            result &= selected.y == t_short2.TestData_RHS[0].y;

            selected = maxmath.select(t_short2.TestData_LHS[1], t_short2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_short2.TestData_RHS[1].x;
            result &= selected.y == t_short2.TestData_RHS[1].y;

            selected = maxmath.select(t_short2.TestData_LHS[2], t_short2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_short2.TestData_LHS[2].x;
            result &= selected.y == t_short2.TestData_LHS[2].y;

            selected = maxmath.select(t_short2.TestData_LHS[3], t_short2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_short2.TestData_RHS[3].x;
            result &= selected.y == t_short2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort3_via_bool()
        {
            bool result = true;


            ushort3 selected;

            selected = maxmath.select(t_ushort3.TestData_LHS[0], t_ushort3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_ushort3.TestData_LHS[0].x;
            result &= selected.y == t_ushort3.TestData_RHS[0].y;
            result &= selected.z == t_ushort3.TestData_RHS[0].z;

            selected = maxmath.select(t_ushort3.TestData_LHS[1], t_ushort3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_ushort3.TestData_RHS[1].x;
            result &= selected.y == t_ushort3.TestData_RHS[1].y;
            result &= selected.z == t_ushort3.TestData_LHS[1].z;

            selected = maxmath.select(t_ushort3.TestData_LHS[2], t_ushort3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_ushort3.TestData_LHS[2].x;
            result &= selected.y == t_ushort3.TestData_LHS[2].y;
            result &= selected.z == t_ushort3.TestData_RHS[2].z;

            selected = maxmath.select(t_ushort3.TestData_LHS[3], t_ushort3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_ushort3.TestData_RHS[3].x;
            result &= selected.y == t_ushort3.TestData_LHS[3].y;
            result &= selected.z == t_ushort3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short3_via_bool()
        {
            bool result = true;


            short3 selected;

            selected = maxmath.select(t_short3.TestData_LHS[0], t_short3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_short3.TestData_LHS[0].x;
            result &= selected.y == t_short3.TestData_RHS[0].y;
            result &= selected.z == t_short3.TestData_RHS[0].z;

            selected = maxmath.select(t_short3.TestData_LHS[1], t_short3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_short3.TestData_RHS[1].x;
            result &= selected.y == t_short3.TestData_RHS[1].y;
            result &= selected.z == t_short3.TestData_LHS[1].z;

            selected = maxmath.select(t_short3.TestData_LHS[2], t_short3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_short3.TestData_LHS[2].x;
            result &= selected.y == t_short3.TestData_LHS[2].y;
            result &= selected.z == t_short3.TestData_RHS[2].z;

            selected = maxmath.select(t_short3.TestData_LHS[3], t_short3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_short3.TestData_RHS[3].x;
            result &= selected.y == t_short3.TestData_LHS[3].y;
            result &= selected.z == t_short3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort4_via_bool()
        {
            bool result = true;


            ushort4 selected;

            selected = maxmath.select(t_ushort4.TestData_LHS[0], t_ushort4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_ushort4.TestData_LHS[0].x;
            result &= selected.y == t_ushort4.TestData_RHS[0].y;
            result &= selected.z == t_ushort4.TestData_RHS[0].z;
            result &= selected.w == t_ushort4.TestData_RHS[0].w;

            selected = maxmath.select(t_ushort4.TestData_LHS[1], t_ushort4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_ushort4.TestData_RHS[1].x;
            result &= selected.y == t_ushort4.TestData_RHS[1].y;
            result &= selected.z == t_ushort4.TestData_RHS[1].z;
            result &= selected.w == t_ushort4.TestData_LHS[1].w;

            selected = maxmath.select(t_ushort4.TestData_LHS[2], t_ushort4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_ushort4.TestData_LHS[2].x;
            result &= selected.y == t_ushort4.TestData_RHS[2].y;
            result &= selected.z == t_ushort4.TestData_RHS[2].z;
            result &= selected.w == t_ushort4.TestData_LHS[2].w;

            selected = maxmath.select(t_ushort4.TestData_LHS[3], t_ushort4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_ushort4.TestData_RHS[3].x;
            result &= selected.y == t_ushort4.TestData_LHS[3].y;
            result &= selected.z == t_ushort4.TestData_RHS[3].z;
            result &= selected.w == t_ushort4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short4_via_bool()
        {
            bool result = true;


            short4 selected;

            selected = maxmath.select(t_short4.TestData_LHS[0], t_short4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_short4.TestData_LHS[0].x;
            result &= selected.y == t_short4.TestData_RHS[0].y;
            result &= selected.z == t_short4.TestData_RHS[0].z;
            result &= selected.w == t_short4.TestData_RHS[0].w;

            selected = maxmath.select(t_short4.TestData_LHS[1], t_short4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_short4.TestData_RHS[1].x;
            result &= selected.y == t_short4.TestData_RHS[1].y;
            result &= selected.z == t_short4.TestData_RHS[1].z;
            result &= selected.w == t_short4.TestData_LHS[1].w;

            selected = maxmath.select(t_short4.TestData_LHS[2], t_short4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_short4.TestData_LHS[2].x;
            result &= selected.y == t_short4.TestData_RHS[2].y;
            result &= selected.z == t_short4.TestData_RHS[2].z;
            result &= selected.w == t_short4.TestData_LHS[2].w;

            selected = maxmath.select(t_short4.TestData_LHS[3], t_short4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_short4.TestData_RHS[3].x;
            result &= selected.y == t_short4.TestData_LHS[3].y;
            result &= selected.z == t_short4.TestData_RHS[3].z;
            result &= selected.w == t_short4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort8_via_bool()
        {
            bool result = true;


            ushort8 selected;

            selected = maxmath.select(t_ushort8.TestData_LHS[0], t_ushort8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_ushort8.TestData_RHS[0].x0;
            result &= selected.x1  == t_ushort8.TestData_RHS[0].x1;
            result &= selected.x2  == t_ushort8.TestData_LHS[0].x2;
            result &= selected.x3  == t_ushort8.TestData_RHS[0].x3;
            result &= selected.x4  == t_ushort8.TestData_RHS[0].x4;
            result &= selected.x5  == t_ushort8.TestData_RHS[0].x5;
            result &= selected.x6  == t_ushort8.TestData_LHS[0].x6;
            result &= selected.x7  == t_ushort8.TestData_RHS[0].x7;

            selected = maxmath.select(t_ushort8.TestData_LHS[1], t_ushort8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_ushort8.TestData_RHS[1].x0;
            result &= selected.x1  == t_ushort8.TestData_RHS[1].x1;
            result &= selected.x2  == t_ushort8.TestData_LHS[1].x2;
            result &= selected.x3  == t_ushort8.TestData_LHS[1].x3;
            result &= selected.x4  == t_ushort8.TestData_LHS[1].x4;
            result &= selected.x5  == t_ushort8.TestData_RHS[1].x5;
            result &= selected.x6  == t_ushort8.TestData_RHS[1].x6;
            result &= selected.x7  == t_ushort8.TestData_RHS[1].x7;

            selected = maxmath.select(t_ushort8.TestData_LHS[2], t_ushort8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_ushort8.TestData_RHS[2].x0;
            result &= selected.x1  == t_ushort8.TestData_LHS[2].x1;
            result &= selected.x2  == t_ushort8.TestData_LHS[2].x2;
            result &= selected.x3  == t_ushort8.TestData_RHS[2].x3;
            result &= selected.x4  == t_ushort8.TestData_LHS[2].x4;
            result &= selected.x5  == t_ushort8.TestData_RHS[2].x5;
            result &= selected.x6  == t_ushort8.TestData_LHS[2].x6;
            result &= selected.x7  == t_ushort8.TestData_LHS[2].x7;

            selected = maxmath.select(t_ushort8.TestData_LHS[3], t_ushort8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_ushort8.TestData_RHS[3].x0;
            result &= selected.x1  == t_ushort8.TestData_RHS[3].x1;
            result &= selected.x2  == t_ushort8.TestData_LHS[3].x2;
            result &= selected.x3  == t_ushort8.TestData_RHS[3].x3;
            result &= selected.x4  == t_ushort8.TestData_RHS[3].x4;
            result &= selected.x5  == t_ushort8.TestData_RHS[3].x5;
            result &= selected.x6  == t_ushort8.TestData_RHS[3].x6;
            result &= selected.x7  == t_ushort8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short8_via_bool()
        {
            bool result = true;


            short8 selected;

            selected = maxmath.select(t_short8.TestData_LHS[0], t_short8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_short8.TestData_RHS[0].x0;
            result &= selected.x1  == t_short8.TestData_RHS[0].x1;
            result &= selected.x2  == t_short8.TestData_LHS[0].x2;
            result &= selected.x3  == t_short8.TestData_RHS[0].x3;
            result &= selected.x4  == t_short8.TestData_RHS[0].x4;
            result &= selected.x5  == t_short8.TestData_RHS[0].x5;
            result &= selected.x6  == t_short8.TestData_LHS[0].x6;
            result &= selected.x7  == t_short8.TestData_RHS[0].x7;

            selected = maxmath.select(t_short8.TestData_LHS[1], t_short8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_short8.TestData_RHS[1].x0;
            result &= selected.x1  == t_short8.TestData_RHS[1].x1;
            result &= selected.x2  == t_short8.TestData_LHS[1].x2;
            result &= selected.x3  == t_short8.TestData_LHS[1].x3;
            result &= selected.x4  == t_short8.TestData_LHS[1].x4;
            result &= selected.x5  == t_short8.TestData_RHS[1].x5;
            result &= selected.x6  == t_short8.TestData_RHS[1].x6;
            result &= selected.x7  == t_short8.TestData_RHS[1].x7;

            selected = maxmath.select(t_short8.TestData_LHS[2], t_short8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_short8.TestData_RHS[2].x0;
            result &= selected.x1  == t_short8.TestData_LHS[2].x1;
            result &= selected.x2  == t_short8.TestData_LHS[2].x2;
            result &= selected.x3  == t_short8.TestData_RHS[2].x3;
            result &= selected.x4  == t_short8.TestData_LHS[2].x4;
            result &= selected.x5  == t_short8.TestData_RHS[2].x5;
            result &= selected.x6  == t_short8.TestData_LHS[2].x6;
            result &= selected.x7  == t_short8.TestData_LHS[2].x7;

            selected = maxmath.select(t_short8.TestData_LHS[3], t_short8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_short8.TestData_RHS[3].x0;
            result &= selected.x1  == t_short8.TestData_RHS[3].x1;
            result &= selected.x2  == t_short8.TestData_LHS[3].x2;
            result &= selected.x3  == t_short8.TestData_RHS[3].x3;
            result &= selected.x4  == t_short8.TestData_RHS[3].x4;
            result &= selected.x5  == t_short8.TestData_RHS[3].x5;
            result &= selected.x6  == t_short8.TestData_RHS[3].x6;
            result &= selected.x7  == t_short8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ushort16_via_bool()
        {
            bool result = true;


            ushort16 selected;

            selected = maxmath.select(t_ushort16.TestData_LHS[0], t_ushort16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == t_ushort16.TestData_RHS[0].x0;
            result &= selected.x1  == t_ushort16.TestData_RHS[0].x1;
            result &= selected.x2  == t_ushort16.TestData_LHS[0].x2;
            result &= selected.x3  == t_ushort16.TestData_RHS[0].x3;
            result &= selected.x4  == t_ushort16.TestData_RHS[0].x4;
            result &= selected.x5  == t_ushort16.TestData_RHS[0].x5;
            result &= selected.x6  == t_ushort16.TestData_LHS[0].x6;
            result &= selected.x7  == t_ushort16.TestData_RHS[0].x7;
            result &= selected.x8  == t_ushort16.TestData_LHS[0].x8;
            result &= selected.x9  == t_ushort16.TestData_RHS[0].x9;
            result &= selected.x10 == t_ushort16.TestData_LHS[0].x10;
            result &= selected.x11 == t_ushort16.TestData_RHS[0].x11;
            result &= selected.x12 == t_ushort16.TestData_LHS[0].x12;
            result &= selected.x13 == t_ushort16.TestData_RHS[0].x13;
            result &= selected.x14 == t_ushort16.TestData_LHS[0].x14;
            result &= selected.x15 == t_ushort16.TestData_RHS[0].x15;

            selected = maxmath.select(t_ushort16.TestData_LHS[1], t_ushort16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == t_ushort16.TestData_RHS[1].x0;
            result &= selected.x1  == t_ushort16.TestData_RHS[1].x1;
            result &= selected.x2  == t_ushort16.TestData_LHS[1].x2;
            result &= selected.x3  == t_ushort16.TestData_LHS[1].x3;
            result &= selected.x4  == t_ushort16.TestData_LHS[1].x4;
            result &= selected.x5  == t_ushort16.TestData_RHS[1].x5;
            result &= selected.x6  == t_ushort16.TestData_RHS[1].x6;
            result &= selected.x7  == t_ushort16.TestData_RHS[1].x7;
            result &= selected.x8  == t_ushort16.TestData_RHS[1].x8;
            result &= selected.x9  == t_ushort16.TestData_RHS[1].x9;
            result &= selected.x10 == t_ushort16.TestData_LHS[1].x10;
            result &= selected.x11 == t_ushort16.TestData_LHS[1].x11;
            result &= selected.x12 == t_ushort16.TestData_LHS[1].x12;
            result &= selected.x13 == t_ushort16.TestData_RHS[1].x13;
            result &= selected.x14 == t_ushort16.TestData_LHS[1].x14;
            result &= selected.x15 == t_ushort16.TestData_LHS[1].x15;

            selected = maxmath.select(t_ushort16.TestData_LHS[2], t_ushort16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == t_ushort16.TestData_RHS[2].x0;
            result &= selected.x1  == t_ushort16.TestData_LHS[2].x1;
            result &= selected.x2  == t_ushort16.TestData_LHS[2].x2;
            result &= selected.x3  == t_ushort16.TestData_RHS[2].x3;
            result &= selected.x4  == t_ushort16.TestData_LHS[2].x4;
            result &= selected.x5  == t_ushort16.TestData_RHS[2].x5;
            result &= selected.x6  == t_ushort16.TestData_LHS[2].x6;
            result &= selected.x7  == t_ushort16.TestData_LHS[2].x7;
            result &= selected.x8  == t_ushort16.TestData_RHS[2].x8;
            result &= selected.x9  == t_ushort16.TestData_RHS[2].x9;
            result &= selected.x10 == t_ushort16.TestData_LHS[2].x10;
            result &= selected.x11 == t_ushort16.TestData_RHS[2].x11;
            result &= selected.x12 == t_ushort16.TestData_RHS[2].x12;
            result &= selected.x13 == t_ushort16.TestData_RHS[2].x13;
            result &= selected.x14 == t_ushort16.TestData_RHS[2].x14;
            result &= selected.x15 == t_ushort16.TestData_LHS[2].x15;

            selected = maxmath.select(t_ushort16.TestData_LHS[3], t_ushort16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == t_ushort16.TestData_RHS[3].x0;
            result &= selected.x1  == t_ushort16.TestData_RHS[3].x1;
            result &= selected.x2  == t_ushort16.TestData_LHS[3].x2;
            result &= selected.x3  == t_ushort16.TestData_RHS[3].x3;
            result &= selected.x4  == t_ushort16.TestData_RHS[3].x4;
            result &= selected.x5  == t_ushort16.TestData_RHS[3].x5;
            result &= selected.x6  == t_ushort16.TestData_RHS[3].x6;
            result &= selected.x7  == t_ushort16.TestData_RHS[3].x7;
            result &= selected.x8  == t_ushort16.TestData_LHS[3].x8;
            result &= selected.x9  == t_ushort16.TestData_RHS[3].x9;
            result &= selected.x10 == t_ushort16.TestData_RHS[3].x10;
            result &= selected.x11 == t_ushort16.TestData_RHS[3].x11;
            result &= selected.x12 == t_ushort16.TestData_LHS[3].x12;
            result &= selected.x13 == t_ushort16.TestData_RHS[3].x13;
            result &= selected.x14 == t_ushort16.TestData_LHS[3].x14;
            result &= selected.x15 == t_ushort16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _short16_via_bool()
        {
            bool result = true;


            short16 selected;

            selected = maxmath.select(t_short16.TestData_LHS[0], t_short16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == t_short16.TestData_RHS[0].x0;
            result &= selected.x1  == t_short16.TestData_RHS[0].x1;
            result &= selected.x2  == t_short16.TestData_LHS[0].x2;
            result &= selected.x3  == t_short16.TestData_RHS[0].x3;
            result &= selected.x4  == t_short16.TestData_RHS[0].x4;
            result &= selected.x5  == t_short16.TestData_RHS[0].x5;
            result &= selected.x6  == t_short16.TestData_LHS[0].x6;
            result &= selected.x7  == t_short16.TestData_RHS[0].x7;
            result &= selected.x8  == t_short16.TestData_LHS[0].x8;
            result &= selected.x9  == t_short16.TestData_RHS[0].x9;
            result &= selected.x10 == t_short16.TestData_LHS[0].x10;
            result &= selected.x11 == t_short16.TestData_RHS[0].x11;
            result &= selected.x12 == t_short16.TestData_LHS[0].x12;
            result &= selected.x13 == t_short16.TestData_RHS[0].x13;
            result &= selected.x14 == t_short16.TestData_LHS[0].x14;
            result &= selected.x15 == t_short16.TestData_RHS[0].x15;

            selected = maxmath.select(t_short16.TestData_LHS[1], t_short16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == t_short16.TestData_RHS[1].x0;
            result &= selected.x1  == t_short16.TestData_RHS[1].x1;
            result &= selected.x2  == t_short16.TestData_LHS[1].x2;
            result &= selected.x3  == t_short16.TestData_LHS[1].x3;
            result &= selected.x4  == t_short16.TestData_LHS[1].x4;
            result &= selected.x5  == t_short16.TestData_RHS[1].x5;
            result &= selected.x6  == t_short16.TestData_RHS[1].x6;
            result &= selected.x7  == t_short16.TestData_RHS[1].x7;
            result &= selected.x8  == t_short16.TestData_RHS[1].x8;
            result &= selected.x9  == t_short16.TestData_RHS[1].x9;
            result &= selected.x10 == t_short16.TestData_LHS[1].x10;
            result &= selected.x11 == t_short16.TestData_LHS[1].x11;
            result &= selected.x12 == t_short16.TestData_LHS[1].x12;
            result &= selected.x13 == t_short16.TestData_RHS[1].x13;
            result &= selected.x14 == t_short16.TestData_LHS[1].x14;
            result &= selected.x15 == t_short16.TestData_LHS[1].x15;

            selected = maxmath.select(t_short16.TestData_LHS[2], t_short16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == t_short16.TestData_RHS[2].x0;
            result &= selected.x1  == t_short16.TestData_LHS[2].x1;
            result &= selected.x2  == t_short16.TestData_LHS[2].x2;
            result &= selected.x3  == t_short16.TestData_RHS[2].x3;
            result &= selected.x4  == t_short16.TestData_LHS[2].x4;
            result &= selected.x5  == t_short16.TestData_RHS[2].x5;
            result &= selected.x6  == t_short16.TestData_LHS[2].x6;
            result &= selected.x7  == t_short16.TestData_LHS[2].x7;
            result &= selected.x8  == t_short16.TestData_RHS[2].x8;
            result &= selected.x9  == t_short16.TestData_RHS[2].x9;
            result &= selected.x10 == t_short16.TestData_LHS[2].x10;
            result &= selected.x11 == t_short16.TestData_RHS[2].x11;
            result &= selected.x12 == t_short16.TestData_RHS[2].x12;
            result &= selected.x13 == t_short16.TestData_RHS[2].x13;
            result &= selected.x14 == t_short16.TestData_RHS[2].x14;
            result &= selected.x15 == t_short16.TestData_LHS[2].x15;

            selected = maxmath.select(t_short16.TestData_LHS[3], t_short16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == t_short16.TestData_RHS[3].x0;
            result &= selected.x1  == t_short16.TestData_RHS[3].x1;
            result &= selected.x2  == t_short16.TestData_LHS[3].x2;
            result &= selected.x3  == t_short16.TestData_RHS[3].x3;
            result &= selected.x4  == t_short16.TestData_RHS[3].x4;
            result &= selected.x5  == t_short16.TestData_RHS[3].x5;
            result &= selected.x6  == t_short16.TestData_RHS[3].x6;
            result &= selected.x7  == t_short16.TestData_RHS[3].x7;
            result &= selected.x8  == t_short16.TestData_LHS[3].x8;
            result &= selected.x9  == t_short16.TestData_RHS[3].x9;
            result &= selected.x10 == t_short16.TestData_RHS[3].x10;
            result &= selected.x11 == t_short16.TestData_RHS[3].x11;
            result &= selected.x12 == t_short16.TestData_LHS[3].x12;
            result &= selected.x13 == t_short16.TestData_RHS[3].x13;
            result &= selected.x14 == t_short16.TestData_LHS[3].x14;
            result &= selected.x15 == t_short16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _uint8_via_bool()
        {
            bool result = true;


            uint8 selected;

            selected = maxmath.select(t_uint8.TestData_LHS[0], t_uint8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_uint8.TestData_RHS[0].x0;
            result &= selected.x1  == t_uint8.TestData_RHS[0].x1;
            result &= selected.x2  == t_uint8.TestData_LHS[0].x2;
            result &= selected.x3  == t_uint8.TestData_RHS[0].x3;
            result &= selected.x4  == t_uint8.TestData_RHS[0].x4;
            result &= selected.x5  == t_uint8.TestData_RHS[0].x5;
            result &= selected.x6  == t_uint8.TestData_LHS[0].x6;
            result &= selected.x7  == t_uint8.TestData_RHS[0].x7;

            selected = maxmath.select(t_uint8.TestData_LHS[1], t_uint8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_uint8.TestData_RHS[1].x0;
            result &= selected.x1  == t_uint8.TestData_RHS[1].x1;
            result &= selected.x2  == t_uint8.TestData_LHS[1].x2;
            result &= selected.x3  == t_uint8.TestData_LHS[1].x3;
            result &= selected.x4  == t_uint8.TestData_LHS[1].x4;
            result &= selected.x5  == t_uint8.TestData_RHS[1].x5;
            result &= selected.x6  == t_uint8.TestData_RHS[1].x6;
            result &= selected.x7  == t_uint8.TestData_RHS[1].x7;

            selected = maxmath.select(t_uint8.TestData_LHS[2], t_uint8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_uint8.TestData_RHS[2].x0;
            result &= selected.x1  == t_uint8.TestData_LHS[2].x1;
            result &= selected.x2  == t_uint8.TestData_LHS[2].x2;
            result &= selected.x3  == t_uint8.TestData_RHS[2].x3;
            result &= selected.x4  == t_uint8.TestData_LHS[2].x4;
            result &= selected.x5  == t_uint8.TestData_RHS[2].x5;
            result &= selected.x6  == t_uint8.TestData_LHS[2].x6;
            result &= selected.x7  == t_uint8.TestData_LHS[2].x7;

            selected = maxmath.select(t_uint8.TestData_LHS[3], t_uint8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_uint8.TestData_RHS[3].x0;
            result &= selected.x1  == t_uint8.TestData_RHS[3].x1;
            result &= selected.x2  == t_uint8.TestData_LHS[3].x2;
            result &= selected.x3  == t_uint8.TestData_RHS[3].x3;
            result &= selected.x4  == t_uint8.TestData_RHS[3].x4;
            result &= selected.x5  == t_uint8.TestData_RHS[3].x5;
            result &= selected.x6  == t_uint8.TestData_RHS[3].x6;
            result &= selected.x7  == t_uint8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _int8_via_bool()
        {
            bool result = true;


            int8 selected;

            selected = maxmath.select(t_int8.TestData_LHS[0], t_int8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == t_int8.TestData_RHS[0].x0;
            result &= selected.x1  == t_int8.TestData_RHS[0].x1;
            result &= selected.x2  == t_int8.TestData_LHS[0].x2;
            result &= selected.x3  == t_int8.TestData_RHS[0].x3;
            result &= selected.x4  == t_int8.TestData_RHS[0].x4;
            result &= selected.x5  == t_int8.TestData_RHS[0].x5;
            result &= selected.x6  == t_int8.TestData_LHS[0].x6;
            result &= selected.x7  == t_int8.TestData_RHS[0].x7;

            selected = maxmath.select(t_int8.TestData_LHS[1], t_int8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == t_int8.TestData_RHS[1].x0;
            result &= selected.x1  == t_int8.TestData_RHS[1].x1;
            result &= selected.x2  == t_int8.TestData_LHS[1].x2;
            result &= selected.x3  == t_int8.TestData_LHS[1].x3;
            result &= selected.x4  == t_int8.TestData_LHS[1].x4;
            result &= selected.x5  == t_int8.TestData_RHS[1].x5;
            result &= selected.x6  == t_int8.TestData_RHS[1].x6;
            result &= selected.x7  == t_int8.TestData_RHS[1].x7;

            selected = maxmath.select(t_int8.TestData_LHS[2], t_int8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == t_int8.TestData_RHS[2].x0;
            result &= selected.x1  == t_int8.TestData_LHS[2].x1;
            result &= selected.x2  == t_int8.TestData_LHS[2].x2;
            result &= selected.x3  == t_int8.TestData_RHS[2].x3;
            result &= selected.x4  == t_int8.TestData_LHS[2].x4;
            result &= selected.x5  == t_int8.TestData_RHS[2].x5;
            result &= selected.x6  == t_int8.TestData_LHS[2].x6;
            result &= selected.x7  == t_int8.TestData_LHS[2].x7;

            selected = maxmath.select(t_int8.TestData_LHS[3], t_int8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == t_int8.TestData_RHS[3].x0;
            result &= selected.x1  == t_int8.TestData_RHS[3].x1;
            result &= selected.x2  == t_int8.TestData_LHS[3].x2;
            result &= selected.x3  == t_int8.TestData_RHS[3].x3;
            result &= selected.x4  == t_int8.TestData_RHS[3].x4;
            result &= selected.x5  == t_int8.TestData_RHS[3].x5;
            result &= selected.x6  == t_int8.TestData_RHS[3].x6;
            result &= selected.x7  == t_int8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong2_via_bool()
        {
            bool result = true;


            ulong2 selected;

            selected = maxmath.select(t_ulong2.TestData_LHS[0], t_ulong2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_ulong2.TestData_LHS[0].x;
            result &= selected.y == t_ulong2.TestData_RHS[0].y;

            selected = maxmath.select(t_ulong2.TestData_LHS[1], t_ulong2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_ulong2.TestData_RHS[1].x;
            result &= selected.y == t_ulong2.TestData_RHS[1].y;

            selected = maxmath.select(t_ulong2.TestData_LHS[2], t_ulong2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_ulong2.TestData_LHS[2].x;
            result &= selected.y == t_ulong2.TestData_LHS[2].y;

            selected = maxmath.select(t_ulong2.TestData_LHS[3], t_ulong2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_ulong2.TestData_RHS[3].x;
            result &= selected.y == t_ulong2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long2_via_bool()
        {
            bool result = true;


            long2 selected;

            selected = maxmath.select(t_long2.TestData_LHS[0], t_long2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == t_long2.TestData_LHS[0].x;
            result &= selected.y == t_long2.TestData_RHS[0].y;

            selected = maxmath.select(t_long2.TestData_LHS[1], t_long2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == t_long2.TestData_RHS[1].x;
            result &= selected.y == t_long2.TestData_RHS[1].y;

            selected = maxmath.select(t_long2.TestData_LHS[2], t_long2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == t_long2.TestData_LHS[2].x;
            result &= selected.y == t_long2.TestData_LHS[2].y;

            selected = maxmath.select(t_long2.TestData_LHS[3], t_long2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == t_long2.TestData_RHS[3].x;
            result &= selected.y == t_long2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong3_via_bool()
        {
            bool result = true;


            ulong3 selected;

            selected = maxmath.select(t_ulong3.TestData_LHS[0], t_ulong3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_ulong3.TestData_LHS[0].x;
            result &= selected.y == t_ulong3.TestData_RHS[0].y;
            result &= selected.z == t_ulong3.TestData_RHS[0].z;

            selected = maxmath.select(t_ulong3.TestData_LHS[1], t_ulong3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_ulong3.TestData_RHS[1].x;
            result &= selected.y == t_ulong3.TestData_RHS[1].y;
            result &= selected.z == t_ulong3.TestData_LHS[1].z;

            selected = maxmath.select(t_ulong3.TestData_LHS[2], t_ulong3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_ulong3.TestData_LHS[2].x;
            result &= selected.y == t_ulong3.TestData_LHS[2].y;
            result &= selected.z == t_ulong3.TestData_RHS[2].z;

            selected = maxmath.select(t_ulong3.TestData_LHS[3], t_ulong3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_ulong3.TestData_RHS[3].x;
            result &= selected.y == t_ulong3.TestData_LHS[3].y;
            result &= selected.z == t_ulong3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long3_via_bool()
        {
            bool result = true;


            long3 selected;

            selected = maxmath.select(t_long3.TestData_LHS[0], t_long3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == t_long3.TestData_LHS[0].x;
            result &= selected.y == t_long3.TestData_RHS[0].y;
            result &= selected.z == t_long3.TestData_RHS[0].z;

            selected = maxmath.select(t_long3.TestData_LHS[1], t_long3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == t_long3.TestData_RHS[1].x;
            result &= selected.y == t_long3.TestData_RHS[1].y;
            result &= selected.z == t_long3.TestData_LHS[1].z;

            selected = maxmath.select(t_long3.TestData_LHS[2], t_long3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == t_long3.TestData_LHS[2].x;
            result &= selected.y == t_long3.TestData_LHS[2].y;
            result &= selected.z == t_long3.TestData_RHS[2].z;

            selected = maxmath.select(t_long3.TestData_LHS[3], t_long3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == t_long3.TestData_RHS[3].x;
            result &= selected.y == t_long3.TestData_LHS[3].y;
            result &= selected.z == t_long3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _ulong4_via_bool()
        {
            bool result = true;


            ulong4 selected;

            selected = maxmath.select(t_ulong4.TestData_LHS[0], t_ulong4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_ulong4.TestData_LHS[0].x;
            result &= selected.y == t_ulong4.TestData_RHS[0].y;
            result &= selected.z == t_ulong4.TestData_RHS[0].z;
            result &= selected.w == t_ulong4.TestData_RHS[0].w;

            selected = maxmath.select(t_ulong4.TestData_LHS[1], t_ulong4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_ulong4.TestData_RHS[1].x;
            result &= selected.y == t_ulong4.TestData_RHS[1].y;
            result &= selected.z == t_ulong4.TestData_RHS[1].z;
            result &= selected.w == t_ulong4.TestData_LHS[1].w;

            selected = maxmath.select(t_ulong4.TestData_LHS[2], t_ulong4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_ulong4.TestData_LHS[2].x;
            result &= selected.y == t_ulong4.TestData_RHS[2].y;
            result &= selected.z == t_ulong4.TestData_RHS[2].z;
            result &= selected.w == t_ulong4.TestData_LHS[2].w;

            selected = maxmath.select(t_ulong4.TestData_LHS[3], t_ulong4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_ulong4.TestData_RHS[3].x;
            result &= selected.y == t_ulong4.TestData_LHS[3].y;
            result &= selected.z == t_ulong4.TestData_RHS[3].z;
            result &= selected.w == t_ulong4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void _long4_via_bool()
        {
            bool result = true;


            long4 selected;

            selected = maxmath.select(t_long4.TestData_LHS[0], t_long4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == t_long4.TestData_LHS[0].x;
            result &= selected.y == t_long4.TestData_RHS[0].y;
            result &= selected.z == t_long4.TestData_RHS[0].z;
            result &= selected.w == t_long4.TestData_RHS[0].w;

            selected = maxmath.select(t_long4.TestData_LHS[1], t_long4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == t_long4.TestData_RHS[1].x;
            result &= selected.y == t_long4.TestData_RHS[1].y;
            result &= selected.z == t_long4.TestData_RHS[1].z;
            result &= selected.w == t_long4.TestData_LHS[1].w;

            selected = maxmath.select(t_long4.TestData_LHS[2], t_long4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == t_long4.TestData_LHS[2].x;
            result &= selected.y == t_long4.TestData_RHS[2].y;
            result &= selected.z == t_long4.TestData_RHS[2].z;
            result &= selected.w == t_long4.TestData_LHS[2].w;

            selected = maxmath.select(t_long4.TestData_LHS[3], t_long4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == t_long4.TestData_RHS[3].x;
            result &= selected.y == t_long4.TestData_LHS[3].y;
            result &= selected.z == t_long4.TestData_RHS[3].z;
            result &= selected.w == t_long4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void _float8_via_bool()
        {
            bool result = true;


            float8 selected;

            selected = maxmath.select(t_float8.TestData_LHS[0], t_float8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0 == t_float8.TestData_RHS[0].x0;
            result &= selected.x1 == t_float8.TestData_RHS[0].x1;
            result &= selected.x2 == t_float8.TestData_LHS[0].x2;
            result &= selected.x3 == t_float8.TestData_RHS[0].x3;
            result &= selected.x4 == t_float8.TestData_RHS[0].x4;
            result &= selected.x5 == t_float8.TestData_RHS[0].x5;
            result &= selected.x6 == t_float8.TestData_LHS[0].x6;
            result &= selected.x7 == t_float8.TestData_RHS[0].x7;

            selected = maxmath.select(t_float8.TestData_LHS[1], t_float8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0 == t_float8.TestData_RHS[1].x0;
            result &= selected.x1 == t_float8.TestData_RHS[1].x1;
            result &= selected.x2 == t_float8.TestData_LHS[1].x2;
            result &= selected.x3 == t_float8.TestData_LHS[1].x3;
            result &= selected.x4 == t_float8.TestData_LHS[1].x4;
            result &= selected.x5 == t_float8.TestData_RHS[1].x5;
            result &= selected.x6 == t_float8.TestData_RHS[1].x6;
            result &= selected.x7 == t_float8.TestData_RHS[1].x7;

            selected = maxmath.select(t_float8.TestData_LHS[2], t_float8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0 == t_float8.TestData_RHS[2].x0;
            result &= selected.x1 == t_float8.TestData_LHS[2].x1;
            result &= selected.x2 == t_float8.TestData_LHS[2].x2;
            result &= selected.x3 == t_float8.TestData_RHS[2].x3;
            result &= selected.x4 == t_float8.TestData_LHS[2].x4;
            result &= selected.x5 == t_float8.TestData_RHS[2].x5;
            result &= selected.x6 == t_float8.TestData_LHS[2].x6;
            result &= selected.x7 == t_float8.TestData_LHS[2].x7;

            selected = maxmath.select(t_float8.TestData_LHS[3], t_float8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0 == t_float8.TestData_RHS[3].x0;
            result &= selected.x1 == t_float8.TestData_RHS[3].x1;
            result &= selected.x2 == t_float8.TestData_LHS[3].x2;
            result &= selected.x3 == t_float8.TestData_RHS[3].x3;
            result &= selected.x4 == t_float8.TestData_RHS[3].x4;
            result &= selected.x5 == t_float8.TestData_RHS[3].x5;
            result &= selected.x6 == t_float8.TestData_RHS[3].x6;
            result &= selected.x7 == t_float8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }
    }
}