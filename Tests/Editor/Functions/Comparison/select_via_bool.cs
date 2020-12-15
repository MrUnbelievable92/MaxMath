using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class select_via_bool
    {
        [Test]
        public static void byte2_via_bool()
        {
            bool result = true;


            byte2 selected;

            selected = maxmath.select(Byte2.TestData_LHS[0], Byte2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == Byte2.TestData_LHS[0].x;
            result &= selected.y == Byte2.TestData_RHS[0].y;

            selected = maxmath.select(Byte2.TestData_LHS[1], Byte2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == Byte2.TestData_RHS[1].x;
            result &= selected.y == Byte2.TestData_RHS[1].y;

            selected = maxmath.select(Byte2.TestData_LHS[2], Byte2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == Byte2.TestData_LHS[2].x;
            result &= selected.y == Byte2.TestData_LHS[2].y;

            selected = maxmath.select(Byte2.TestData_LHS[3], Byte2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == Byte2.TestData_RHS[3].x;
            result &= selected.y == Byte2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte2_via_bool()
        {
            bool result = true;


            sbyte2 selected;

            selected = maxmath.select(SByte2.TestData_LHS[0], SByte2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == SByte2.TestData_LHS[0].x;
            result &= selected.y == SByte2.TestData_RHS[0].y;

            selected = maxmath.select(SByte2.TestData_LHS[1], SByte2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == SByte2.TestData_RHS[1].x;
            result &= selected.y == SByte2.TestData_RHS[1].y;

            selected = maxmath.select(SByte2.TestData_LHS[2], SByte2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == SByte2.TestData_LHS[2].x;
            result &= selected.y == SByte2.TestData_LHS[2].y;

            selected = maxmath.select(SByte2.TestData_LHS[3], SByte2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == SByte2.TestData_RHS[3].x;
            result &= selected.y == SByte2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void byte3_via_bool()
        {
            bool result = true;


            byte3 selected;

            selected = maxmath.select(Byte3.TestData_LHS[0], Byte3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == Byte3.TestData_LHS[0].x;
            result &= selected.y == Byte3.TestData_RHS[0].y;
            result &= selected.z == Byte3.TestData_RHS[0].z;

            selected = maxmath.select(Byte3.TestData_LHS[1], Byte3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == Byte3.TestData_RHS[1].x;
            result &= selected.y == Byte3.TestData_RHS[1].y;
            result &= selected.z == Byte3.TestData_LHS[1].z;

            selected = maxmath.select(Byte3.TestData_LHS[2], Byte3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == Byte3.TestData_LHS[2].x;
            result &= selected.y == Byte3.TestData_LHS[2].y;
            result &= selected.z == Byte3.TestData_RHS[2].z;

            selected = maxmath.select(Byte3.TestData_LHS[3], Byte3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == Byte3.TestData_RHS[3].x;
            result &= selected.y == Byte3.TestData_LHS[3].y;
            result &= selected.z == Byte3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte3_via_bool()
        {
            bool result = true;


            sbyte3 selected;

            selected = maxmath.select(SByte3.TestData_LHS[0], SByte3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == SByte3.TestData_LHS[0].x;
            result &= selected.y == SByte3.TestData_RHS[0].y;
            result &= selected.z == SByte3.TestData_RHS[0].z;

            selected = maxmath.select(SByte3.TestData_LHS[1], SByte3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == SByte3.TestData_RHS[1].x;
            result &= selected.y == SByte3.TestData_RHS[1].y;
            result &= selected.z == SByte3.TestData_LHS[1].z;

            selected = maxmath.select(SByte3.TestData_LHS[2], SByte3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == SByte3.TestData_LHS[2].x;
            result &= selected.y == SByte3.TestData_LHS[2].y;
            result &= selected.z == SByte3.TestData_RHS[2].z;

            selected = maxmath.select(SByte3.TestData_LHS[3], SByte3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == SByte3.TestData_RHS[3].x;
            result &= selected.y == SByte3.TestData_LHS[3].y;
            result &= selected.z == SByte3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void byte4_via_bool()
        {
            bool result = true;


            byte4 selected;

            selected = maxmath.select(Byte4.TestData_LHS[0], Byte4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == Byte4.TestData_LHS[0].x;
            result &= selected.y == Byte4.TestData_RHS[0].y;
            result &= selected.z == Byte4.TestData_RHS[0].z;
            result &= selected.w == Byte4.TestData_RHS[0].w;

            selected = maxmath.select(Byte4.TestData_LHS[1], Byte4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == Byte4.TestData_RHS[1].x;
            result &= selected.y == Byte4.TestData_RHS[1].y;
            result &= selected.z == Byte4.TestData_RHS[1].z;
            result &= selected.w == Byte4.TestData_LHS[1].w;

            selected = maxmath.select(Byte4.TestData_LHS[2], Byte4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == Byte4.TestData_LHS[2].x;
            result &= selected.y == Byte4.TestData_RHS[2].y;
            result &= selected.z == Byte4.TestData_RHS[2].z;
            result &= selected.w == Byte4.TestData_LHS[2].w;

            selected = maxmath.select(Byte4.TestData_LHS[3], Byte4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == Byte4.TestData_RHS[3].x;
            result &= selected.y == Byte4.TestData_LHS[3].y;
            result &= selected.z == Byte4.TestData_RHS[3].z;
            result &= selected.w == Byte4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte4_via_bool()
        {
            bool result = true;


            sbyte4 selected;

            selected = maxmath.select(SByte4.TestData_LHS[0], SByte4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == SByte4.TestData_LHS[0].x;
            result &= selected.y == SByte4.TestData_RHS[0].y;
            result &= selected.z == SByte4.TestData_RHS[0].z;
            result &= selected.w == SByte4.TestData_RHS[0].w;

            selected = maxmath.select(SByte4.TestData_LHS[1], SByte4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == SByte4.TestData_RHS[1].x;
            result &= selected.y == SByte4.TestData_RHS[1].y;
            result &= selected.z == SByte4.TestData_RHS[1].z;
            result &= selected.w == SByte4.TestData_LHS[1].w;

            selected = maxmath.select(SByte4.TestData_LHS[2], SByte4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == SByte4.TestData_LHS[2].x;
            result &= selected.y == SByte4.TestData_RHS[2].y;
            result &= selected.z == SByte4.TestData_RHS[2].z;
            result &= selected.w == SByte4.TestData_LHS[2].w;

            selected = maxmath.select(SByte4.TestData_LHS[3], SByte4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == SByte4.TestData_RHS[3].x;
            result &= selected.y == SByte4.TestData_LHS[3].y;
            result &= selected.z == SByte4.TestData_RHS[3].z;
            result &= selected.w == SByte4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void byte8_via_bool()
        {
            bool result = true;


            byte8 selected;

            selected = maxmath.select(Byte8.TestData_LHS[0], Byte8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == Byte8.TestData_RHS[0].x0; 
            result &= selected.x1  == Byte8.TestData_RHS[0].x1;
            result &= selected.x2  == Byte8.TestData_LHS[0].x2;
            result &= selected.x3  == Byte8.TestData_RHS[0].x3;
            result &= selected.x4  == Byte8.TestData_RHS[0].x4;
            result &= selected.x5  == Byte8.TestData_RHS[0].x5;
            result &= selected.x6  == Byte8.TestData_LHS[0].x6;
            result &= selected.x7  == Byte8.TestData_RHS[0].x7;

            selected = maxmath.select(Byte8.TestData_LHS[1], Byte8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == Byte8.TestData_RHS[1].x0;
            result &= selected.x1  == Byte8.TestData_RHS[1].x1;
            result &= selected.x2  == Byte8.TestData_LHS[1].x2;
            result &= selected.x3  == Byte8.TestData_LHS[1].x3;
            result &= selected.x4  == Byte8.TestData_LHS[1].x4;
            result &= selected.x5  == Byte8.TestData_RHS[1].x5;
            result &= selected.x6  == Byte8.TestData_RHS[1].x6;
            result &= selected.x7  == Byte8.TestData_RHS[1].x7;

            selected = maxmath.select(Byte8.TestData_LHS[2], Byte8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == Byte8.TestData_RHS[2].x0;
            result &= selected.x1  == Byte8.TestData_LHS[2].x1; 
            result &= selected.x2  == Byte8.TestData_LHS[2].x2;
            result &= selected.x3  == Byte8.TestData_RHS[2].x3;
            result &= selected.x4  == Byte8.TestData_LHS[2].x4;
            result &= selected.x5  == Byte8.TestData_RHS[2].x5;
            result &= selected.x6  == Byte8.TestData_LHS[2].x6;
            result &= selected.x7  == Byte8.TestData_LHS[2].x7;

            selected = maxmath.select(Byte8.TestData_LHS[3], Byte8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == Byte8.TestData_RHS[3].x0;
            result &= selected.x1  == Byte8.TestData_RHS[3].x1;
            result &= selected.x2  == Byte8.TestData_LHS[3].x2;
            result &= selected.x3  == Byte8.TestData_RHS[3].x3;
            result &= selected.x4  == Byte8.TestData_RHS[3].x4;
            result &= selected.x5  == Byte8.TestData_RHS[3].x5;
            result &= selected.x6  == Byte8.TestData_RHS[3].x6;
            result &= selected.x7  == Byte8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte8_via_bool()
        {
            bool result = true;


            sbyte8 selected;

            selected = maxmath.select(SByte8.TestData_LHS[0], SByte8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == SByte8.TestData_RHS[0].x0; 
            result &= selected.x1  == SByte8.TestData_RHS[0].x1;
            result &= selected.x2  == SByte8.TestData_LHS[0].x2;
            result &= selected.x3  == SByte8.TestData_RHS[0].x3;
            result &= selected.x4  == SByte8.TestData_RHS[0].x4;
            result &= selected.x5  == SByte8.TestData_RHS[0].x5;
            result &= selected.x6  == SByte8.TestData_LHS[0].x6;
            result &= selected.x7  == SByte8.TestData_RHS[0].x7;

            selected = maxmath.select(SByte8.TestData_LHS[1], SByte8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == SByte8.TestData_RHS[1].x0;
            result &= selected.x1  == SByte8.TestData_RHS[1].x1;
            result &= selected.x2  == SByte8.TestData_LHS[1].x2;
            result &= selected.x3  == SByte8.TestData_LHS[1].x3;
            result &= selected.x4  == SByte8.TestData_LHS[1].x4;
            result &= selected.x5  == SByte8.TestData_RHS[1].x5;
            result &= selected.x6  == SByte8.TestData_RHS[1].x6;
            result &= selected.x7  == SByte8.TestData_RHS[1].x7;

            selected = maxmath.select(SByte8.TestData_LHS[2], SByte8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == SByte8.TestData_RHS[2].x0;
            result &= selected.x1  == SByte8.TestData_LHS[2].x1; 
            result &= selected.x2  == SByte8.TestData_LHS[2].x2;
            result &= selected.x3  == SByte8.TestData_RHS[2].x3;
            result &= selected.x4  == SByte8.TestData_LHS[2].x4;
            result &= selected.x5  == SByte8.TestData_RHS[2].x5;
            result &= selected.x6  == SByte8.TestData_LHS[2].x6;
            result &= selected.x7  == SByte8.TestData_LHS[2].x7;

            selected = maxmath.select(SByte8.TestData_LHS[3], SByte8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == SByte8.TestData_RHS[3].x0;
            result &= selected.x1  == SByte8.TestData_RHS[3].x1;
            result &= selected.x2  == SByte8.TestData_LHS[3].x2;
            result &= selected.x3  == SByte8.TestData_RHS[3].x3;
            result &= selected.x4  == SByte8.TestData_RHS[3].x4;
            result &= selected.x5  == SByte8.TestData_RHS[3].x5;
            result &= selected.x6  == SByte8.TestData_RHS[3].x6;
            result &= selected.x7  == SByte8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void byte16_via_bool()
        {
            bool result = true;


            byte16 selected;

            selected = maxmath.select(Byte16.TestData_LHS[0], Byte16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == Byte16.TestData_RHS[0].x0; 
            result &= selected.x1  == Byte16.TestData_RHS[0].x1;
            result &= selected.x2  == Byte16.TestData_LHS[0].x2;
            result &= selected.x3  == Byte16.TestData_RHS[0].x3;
            result &= selected.x4  == Byte16.TestData_RHS[0].x4;
            result &= selected.x5  == Byte16.TestData_RHS[0].x5;
            result &= selected.x6  == Byte16.TestData_LHS[0].x6;
            result &= selected.x7  == Byte16.TestData_RHS[0].x7;
            result &= selected.x8  == Byte16.TestData_LHS[0].x8;
            result &= selected.x9  == Byte16.TestData_RHS[0].x9;
            result &= selected.x10 == Byte16.TestData_LHS[0].x10;
            result &= selected.x11 == Byte16.TestData_RHS[0].x11;
            result &= selected.x12 == Byte16.TestData_LHS[0].x12;
            result &= selected.x13 == Byte16.TestData_RHS[0].x13;
            result &= selected.x14 == Byte16.TestData_LHS[0].x14;
            result &= selected.x15 == Byte16.TestData_RHS[0].x15;

            selected = maxmath.select(Byte16.TestData_LHS[1], Byte16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == Byte16.TestData_RHS[1].x0;
            result &= selected.x1  == Byte16.TestData_RHS[1].x1;
            result &= selected.x2  == Byte16.TestData_LHS[1].x2;
            result &= selected.x3  == Byte16.TestData_LHS[1].x3;
            result &= selected.x4  == Byte16.TestData_LHS[1].x4;
            result &= selected.x5  == Byte16.TestData_RHS[1].x5;
            result &= selected.x6  == Byte16.TestData_RHS[1].x6;
            result &= selected.x7  == Byte16.TestData_RHS[1].x7;
            result &= selected.x8  == Byte16.TestData_RHS[1].x8;
            result &= selected.x9  == Byte16.TestData_RHS[1].x9;
            result &= selected.x10 == Byte16.TestData_LHS[1].x10;
            result &= selected.x11 == Byte16.TestData_LHS[1].x11;
            result &= selected.x12 == Byte16.TestData_LHS[1].x12;
            result &= selected.x13 == Byte16.TestData_RHS[1].x13;
            result &= selected.x14 == Byte16.TestData_LHS[1].x14;
            result &= selected.x15 == Byte16.TestData_LHS[1].x15;

            selected = maxmath.select(Byte16.TestData_LHS[2], Byte16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == Byte16.TestData_RHS[2].x0;
            result &= selected.x1  == Byte16.TestData_LHS[2].x1; 
            result &= selected.x2  == Byte16.TestData_LHS[2].x2;
            result &= selected.x3  == Byte16.TestData_RHS[2].x3;
            result &= selected.x4  == Byte16.TestData_LHS[2].x4;
            result &= selected.x5  == Byte16.TestData_RHS[2].x5;
            result &= selected.x6  == Byte16.TestData_LHS[2].x6;
            result &= selected.x7  == Byte16.TestData_LHS[2].x7;
            result &= selected.x8  == Byte16.TestData_RHS[2].x8;
            result &= selected.x9  == Byte16.TestData_RHS[2].x9;
            result &= selected.x10 == Byte16.TestData_LHS[2].x10;
            result &= selected.x11 == Byte16.TestData_RHS[2].x11;
            result &= selected.x12 == Byte16.TestData_RHS[2].x12;
            result &= selected.x13 == Byte16.TestData_RHS[2].x13;
            result &= selected.x14 == Byte16.TestData_RHS[2].x14;
            result &= selected.x15 == Byte16.TestData_LHS[2].x15;

            selected = maxmath.select(Byte16.TestData_LHS[3], Byte16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == Byte16.TestData_RHS[3].x0;
            result &= selected.x1  == Byte16.TestData_RHS[3].x1;
            result &= selected.x2  == Byte16.TestData_LHS[3].x2;
            result &= selected.x3  == Byte16.TestData_RHS[3].x3;
            result &= selected.x4  == Byte16.TestData_RHS[3].x4;
            result &= selected.x5  == Byte16.TestData_RHS[3].x5;
            result &= selected.x6  == Byte16.TestData_RHS[3].x6;
            result &= selected.x7  == Byte16.TestData_RHS[3].x7;
            result &= selected.x8  == Byte16.TestData_LHS[3].x8;
            result &= selected.x9  == Byte16.TestData_RHS[3].x9;
            result &= selected.x10 == Byte16.TestData_RHS[3].x10;
            result &= selected.x11 == Byte16.TestData_RHS[3].x11;
            result &= selected.x12 == Byte16.TestData_LHS[3].x12;
            result &= selected.x13 == Byte16.TestData_RHS[3].x13;
            result &= selected.x14 == Byte16.TestData_LHS[3].x14;
            result &= selected.x15 == Byte16.TestData_LHS[3].x15;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte16_via_bool()
        {
            bool result = true;


            sbyte16 selected;

            selected = maxmath.select(SByte16.TestData_LHS[0], SByte16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == SByte16.TestData_RHS[0].x0; 
            result &= selected.x1  == SByte16.TestData_RHS[0].x1;
            result &= selected.x2  == SByte16.TestData_LHS[0].x2;
            result &= selected.x3  == SByte16.TestData_RHS[0].x3;
            result &= selected.x4  == SByte16.TestData_RHS[0].x4;
            result &= selected.x5  == SByte16.TestData_RHS[0].x5;
            result &= selected.x6  == SByte16.TestData_LHS[0].x6;
            result &= selected.x7  == SByte16.TestData_RHS[0].x7;
            result &= selected.x8  == SByte16.TestData_LHS[0].x8;
            result &= selected.x9  == SByte16.TestData_RHS[0].x9;
            result &= selected.x10 == SByte16.TestData_LHS[0].x10;
            result &= selected.x11 == SByte16.TestData_RHS[0].x11;
            result &= selected.x12 == SByte16.TestData_LHS[0].x12;
            result &= selected.x13 == SByte16.TestData_RHS[0].x13;
            result &= selected.x14 == SByte16.TestData_LHS[0].x14;
            result &= selected.x15 == SByte16.TestData_RHS[0].x15;

            selected = maxmath.select(SByte16.TestData_LHS[1], SByte16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == SByte16.TestData_RHS[1].x0;
            result &= selected.x1  == SByte16.TestData_RHS[1].x1;
            result &= selected.x2  == SByte16.TestData_LHS[1].x2;
            result &= selected.x3  == SByte16.TestData_LHS[1].x3;
            result &= selected.x4  == SByte16.TestData_LHS[1].x4;
            result &= selected.x5  == SByte16.TestData_RHS[1].x5;
            result &= selected.x6  == SByte16.TestData_RHS[1].x6;
            result &= selected.x7  == SByte16.TestData_RHS[1].x7;
            result &= selected.x8  == SByte16.TestData_RHS[1].x8;
            result &= selected.x9  == SByte16.TestData_RHS[1].x9;
            result &= selected.x10 == SByte16.TestData_LHS[1].x10;
            result &= selected.x11 == SByte16.TestData_LHS[1].x11;
            result &= selected.x12 == SByte16.TestData_LHS[1].x12;
            result &= selected.x13 == SByte16.TestData_RHS[1].x13;
            result &= selected.x14 == SByte16.TestData_LHS[1].x14;
            result &= selected.x15 == SByte16.TestData_LHS[1].x15;

            selected = maxmath.select(SByte16.TestData_LHS[2], SByte16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == SByte16.TestData_RHS[2].x0;
            result &= selected.x1  == SByte16.TestData_LHS[2].x1; 
            result &= selected.x2  == SByte16.TestData_LHS[2].x2;
            result &= selected.x3  == SByte16.TestData_RHS[2].x3;
            result &= selected.x4  == SByte16.TestData_LHS[2].x4;
            result &= selected.x5  == SByte16.TestData_RHS[2].x5;
            result &= selected.x6  == SByte16.TestData_LHS[2].x6;
            result &= selected.x7  == SByte16.TestData_LHS[2].x7;
            result &= selected.x8  == SByte16.TestData_RHS[2].x8;
            result &= selected.x9  == SByte16.TestData_RHS[2].x9;
            result &= selected.x10 == SByte16.TestData_LHS[2].x10;
            result &= selected.x11 == SByte16.TestData_RHS[2].x11;
            result &= selected.x12 == SByte16.TestData_RHS[2].x12;
            result &= selected.x13 == SByte16.TestData_RHS[2].x13;
            result &= selected.x14 == SByte16.TestData_RHS[2].x14;
            result &= selected.x15 == SByte16.TestData_LHS[2].x15;

            selected = maxmath.select(SByte16.TestData_LHS[3], SByte16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == SByte16.TestData_RHS[3].x0;
            result &= selected.x1  == SByte16.TestData_RHS[3].x1;
            result &= selected.x2  == SByte16.TestData_LHS[3].x2;
            result &= selected.x3  == SByte16.TestData_RHS[3].x3;
            result &= selected.x4  == SByte16.TestData_RHS[3].x4;
            result &= selected.x5  == SByte16.TestData_RHS[3].x5;
            result &= selected.x6  == SByte16.TestData_RHS[3].x6;
            result &= selected.x7  == SByte16.TestData_RHS[3].x7;
            result &= selected.x8  == SByte16.TestData_LHS[3].x8;
            result &= selected.x9  == SByte16.TestData_RHS[3].x9;
            result &= selected.x10 == SByte16.TestData_RHS[3].x10;
            result &= selected.x11 == SByte16.TestData_RHS[3].x11;
            result &= selected.x12 == SByte16.TestData_LHS[3].x12;
            result &= selected.x13 == SByte16.TestData_RHS[3].x13;
            result &= selected.x14 == SByte16.TestData_LHS[3].x14;
            result &= selected.x15 == SByte16.TestData_LHS[3].x15;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void byte32_via_bool()
        {
            bool result = true;


            byte32 selected;
                                                                                                                                                                                                                    
            selected = maxmath.select(Byte32.TestData_LHS[0], Byte32.TestData_RHS[0], new bool32(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true, false, false, true, false, true, true, false, true, true, false, false, false, true,false, true, false));
            result &= selected.x0  == Byte32.TestData_RHS[0].x0; 
            result &= selected.x1  == Byte32.TestData_RHS[0].x1;
            result &= selected.x2  == Byte32.TestData_LHS[0].x2;
            result &= selected.x3  == Byte32.TestData_RHS[0].x3;
            result &= selected.x4  == Byte32.TestData_RHS[0].x4;
            result &= selected.x5  == Byte32.TestData_RHS[0].x5;
            result &= selected.x6  == Byte32.TestData_LHS[0].x6;
            result &= selected.x7  == Byte32.TestData_RHS[0].x7;
            result &= selected.x8  == Byte32.TestData_LHS[0].x8;
            result &= selected.x9  == Byte32.TestData_RHS[0].x9;
            result &= selected.x10 == Byte32.TestData_LHS[0].x10;
            result &= selected.x11 == Byte32.TestData_RHS[0].x11;
            result &= selected.x12 == Byte32.TestData_LHS[0].x12;
            result &= selected.x13 == Byte32.TestData_RHS[0].x13;
            result &= selected.x14 == Byte32.TestData_LHS[0].x14;
            result &= selected.x15 == Byte32.TestData_RHS[0].x15;
            result &= selected.x16 == Byte32.TestData_LHS[0].x16;
            result &= selected.x17 == Byte32.TestData_LHS[0].x17;
            result &= selected.x18 == Byte32.TestData_RHS[0].x18;
            result &= selected.x19 == Byte32.TestData_LHS[0].x19;
            result &= selected.x20 == Byte32.TestData_RHS[0].x20;
            result &= selected.x21 == Byte32.TestData_RHS[0].x21;
            result &= selected.x22 == Byte32.TestData_LHS[0].x22;
            result &= selected.x23 == Byte32.TestData_RHS[0].x23;
            result &= selected.x24 == Byte32.TestData_RHS[0].x24;
            result &= selected.x25 == Byte32.TestData_LHS[0].x25;
            result &= selected.x26 == Byte32.TestData_LHS[0].x26;
            result &= selected.x27 == Byte32.TestData_LHS[0].x27;
            result &= selected.x28 == Byte32.TestData_RHS[0].x28;
            result &= selected.x29 == Byte32.TestData_LHS[0].x29;
            result &= selected.x30 == Byte32.TestData_RHS[0].x30;
            result &= selected.x31 == Byte32.TestData_LHS[0].x31;

            selected = maxmath.select(Byte32.TestData_LHS[1], Byte32.TestData_RHS[1], new bool32(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false, false, true, false, true, false, false, true, false, false, true, true, true, true, false, true, true));
            result &= selected.x0  == Byte32.TestData_RHS[1].x0;
            result &= selected.x1  == Byte32.TestData_RHS[1].x1;
            result &= selected.x2  == Byte32.TestData_LHS[1].x2;
            result &= selected.x3  == Byte32.TestData_LHS[1].x3;
            result &= selected.x4  == Byte32.TestData_LHS[1].x4;
            result &= selected.x5  == Byte32.TestData_RHS[1].x5;
            result &= selected.x6  == Byte32.TestData_RHS[1].x6;
            result &= selected.x7  == Byte32.TestData_RHS[1].x7;
            result &= selected.x8  == Byte32.TestData_RHS[1].x8;
            result &= selected.x9  == Byte32.TestData_RHS[1].x9;
            result &= selected.x10 == Byte32.TestData_LHS[1].x10;
            result &= selected.x11 == Byte32.TestData_LHS[1].x11;
            result &= selected.x12 == Byte32.TestData_LHS[1].x12;
            result &= selected.x13 == Byte32.TestData_RHS[1].x13;
            result &= selected.x14 == Byte32.TestData_LHS[1].x14;
            result &= selected.x15 == Byte32.TestData_LHS[1].x15;
            result &= selected.x16 == Byte32.TestData_LHS[1].x16;
            result &= selected.x17 == Byte32.TestData_RHS[1].x17;
            result &= selected.x18 == Byte32.TestData_LHS[1].x18;
            result &= selected.x19 == Byte32.TestData_RHS[1].x19;
            result &= selected.x20 == Byte32.TestData_LHS[1].x20;
            result &= selected.x21 == Byte32.TestData_LHS[1].x21;
            result &= selected.x22 == Byte32.TestData_RHS[1].x22;
            result &= selected.x23 == Byte32.TestData_LHS[1].x23;
            result &= selected.x24 == Byte32.TestData_LHS[1].x24;
            result &= selected.x25 == Byte32.TestData_RHS[1].x25;
            result &= selected.x26 == Byte32.TestData_RHS[1].x26;
            result &= selected.x27 == Byte32.TestData_RHS[1].x27;
            result &= selected.x28 == Byte32.TestData_RHS[1].x28;
            result &= selected.x29 == Byte32.TestData_LHS[1].x29;
            result &= selected.x30 == Byte32.TestData_RHS[1].x30;
            result &= selected.x31 == Byte32.TestData_RHS[1].x31;
                                                                                                                                                                                                            
            selected = maxmath.select(Byte32.TestData_LHS[2], Byte32.TestData_RHS[2], new bool32(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false, true ,false, true, true, false, true, false, true, true, true, false, true, true ,false, false, false));
            result &= selected.x0  == Byte32.TestData_RHS[2].x0;
            result &= selected.x1  == Byte32.TestData_LHS[2].x1; 
            result &= selected.x2  == Byte32.TestData_LHS[2].x2;
            result &= selected.x3  == Byte32.TestData_RHS[2].x3;
            result &= selected.x4  == Byte32.TestData_LHS[2].x4;
            result &= selected.x5  == Byte32.TestData_RHS[2].x5;
            result &= selected.x6  == Byte32.TestData_LHS[2].x6;
            result &= selected.x7  == Byte32.TestData_LHS[2].x7;
            result &= selected.x8  == Byte32.TestData_RHS[2].x8;
            result &= selected.x9  == Byte32.TestData_RHS[2].x9;
            result &= selected.x10 == Byte32.TestData_LHS[2].x10;
            result &= selected.x11 == Byte32.TestData_RHS[2].x11;
            result &= selected.x12 == Byte32.TestData_RHS[2].x12;
            result &= selected.x13 == Byte32.TestData_RHS[2].x13;
            result &= selected.x14 == Byte32.TestData_RHS[2].x14;
            result &= selected.x15 == Byte32.TestData_LHS[2].x15;
            result &= selected.x16 == Byte32.TestData_RHS[2].x16; 
            result &= selected.x17 == Byte32.TestData_LHS[2].x17;
            result &= selected.x18 == Byte32.TestData_RHS[2].x18;
            result &= selected.x19 == Byte32.TestData_RHS[2].x19;
            result &= selected.x20 == Byte32.TestData_LHS[2].x20;
            result &= selected.x21 == Byte32.TestData_RHS[2].x21;
            result &= selected.x22 == Byte32.TestData_LHS[2].x22;
            result &= selected.x23 == Byte32.TestData_RHS[2].x23;
            result &= selected.x24 == Byte32.TestData_RHS[2].x24;
            result &= selected.x25 == Byte32.TestData_RHS[2].x25;
            result &= selected.x26 == Byte32.TestData_LHS[2].x26;
            result &= selected.x27 == Byte32.TestData_RHS[2].x27;
            result &= selected.x28 == Byte32.TestData_RHS[2].x28;
            result &= selected.x29 == Byte32.TestData_LHS[2].x29;
            result &= selected.x30 == Byte32.TestData_LHS[2].x30;
            result &= selected.x31 == Byte32.TestData_LHS[2].x31;

            selected = maxmath.select(Byte32.TestData_LHS[3], Byte32.TestData_RHS[3], new bool32(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false, true, false, true, false, true, false, false, true, true, false, false, true, true, true, true, false));
            result &= selected.x0  == Byte32.TestData_RHS[3].x0;
            result &= selected.x1  == Byte32.TestData_RHS[3].x1;
            result &= selected.x2  == Byte32.TestData_LHS[3].x2;
            result &= selected.x3  == Byte32.TestData_RHS[3].x3;
            result &= selected.x4  == Byte32.TestData_RHS[3].x4;
            result &= selected.x5  == Byte32.TestData_RHS[3].x5;
            result &= selected.x6  == Byte32.TestData_RHS[3].x6;
            result &= selected.x7  == Byte32.TestData_RHS[3].x7;
            result &= selected.x8  == Byte32.TestData_LHS[3].x8;
            result &= selected.x9  == Byte32.TestData_RHS[3].x9;
            result &= selected.x10 == Byte32.TestData_RHS[3].x10;
            result &= selected.x11 == Byte32.TestData_RHS[3].x11;
            result &= selected.x12 == Byte32.TestData_LHS[3].x12;
            result &= selected.x13 == Byte32.TestData_RHS[3].x13;
            result &= selected.x14 == Byte32.TestData_LHS[3].x14;
            result &= selected.x15 == Byte32.TestData_LHS[3].x15;
            result &= selected.x16 == Byte32.TestData_RHS[3].x16;
            result &= selected.x17 == Byte32.TestData_LHS[3].x17;
            result &= selected.x18 == Byte32.TestData_RHS[3].x18;
            result &= selected.x19 == Byte32.TestData_LHS[3].x19;
            result &= selected.x20 == Byte32.TestData_RHS[3].x20;
            result &= selected.x21 == Byte32.TestData_LHS[3].x21;
            result &= selected.x22 == Byte32.TestData_LHS[3].x22;
            result &= selected.x23 == Byte32.TestData_RHS[3].x23;
            result &= selected.x24 == Byte32.TestData_RHS[3].x24;
            result &= selected.x25 == Byte32.TestData_LHS[3].x25;
            result &= selected.x26 == Byte32.TestData_LHS[3].x26;
            result &= selected.x27 == Byte32.TestData_RHS[3].x27;
            result &= selected.x28 == Byte32.TestData_RHS[3].x28;
            result &= selected.x29 == Byte32.TestData_RHS[3].x29;
            result &= selected.x30 == Byte32.TestData_RHS[3].x30;
            result &= selected.x31 == Byte32.TestData_LHS[3].x31;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void sbyte32_via_bool()
        {
            bool result = true;


            sbyte32 selected;

            selected = maxmath.select(SByte32.TestData_LHS[0], SByte32.TestData_RHS[0], new bool32(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true, false, false, true, false, true, true, false, true, true, false, false, false, true, false, true, false));
            result &= selected.x0  == SByte32.TestData_RHS[0].x0;
            result &= selected.x1  == SByte32.TestData_RHS[0].x1;
            result &= selected.x2  == SByte32.TestData_LHS[0].x2;
            result &= selected.x3  == SByte32.TestData_RHS[0].x3;
            result &= selected.x4  == SByte32.TestData_RHS[0].x4;
            result &= selected.x5  == SByte32.TestData_RHS[0].x5;
            result &= selected.x6  == SByte32.TestData_LHS[0].x6;
            result &= selected.x7  == SByte32.TestData_RHS[0].x7;
            result &= selected.x8  == SByte32.TestData_LHS[0].x8;
            result &= selected.x9  == SByte32.TestData_RHS[0].x9;
            result &= selected.x10 == SByte32.TestData_LHS[0].x10;
            result &= selected.x11 == SByte32.TestData_RHS[0].x11;
            result &= selected.x12 == SByte32.TestData_LHS[0].x12;
            result &= selected.x13 == SByte32.TestData_RHS[0].x13;
            result &= selected.x14 == SByte32.TestData_LHS[0].x14;
            result &= selected.x15 == SByte32.TestData_RHS[0].x15;
            result &= selected.x16 == SByte32.TestData_LHS[0].x16;
            result &= selected.x17 == SByte32.TestData_LHS[0].x17;
            result &= selected.x18 == SByte32.TestData_RHS[0].x18;
            result &= selected.x19 == SByte32.TestData_LHS[0].x19;
            result &= selected.x20 == SByte32.TestData_RHS[0].x20;
            result &= selected.x21 == SByte32.TestData_RHS[0].x21;
            result &= selected.x22 == SByte32.TestData_LHS[0].x22;
            result &= selected.x23 == SByte32.TestData_RHS[0].x23;
            result &= selected.x24 == SByte32.TestData_RHS[0].x24;
            result &= selected.x25 == SByte32.TestData_LHS[0].x25;
            result &= selected.x26 == SByte32.TestData_LHS[0].x26;
            result &= selected.x27 == SByte32.TestData_LHS[0].x27;
            result &= selected.x28 == SByte32.TestData_RHS[0].x28;
            result &= selected.x29 == SByte32.TestData_LHS[0].x29;
            result &= selected.x30 == SByte32.TestData_RHS[0].x30;
            result &= selected.x31 == SByte32.TestData_LHS[0].x31;
                                                                                                                                                                                                                                                                                                                   
            selected = maxmath.select(SByte32.TestData_LHS[1], SByte32.TestData_RHS[1], new bool32(true, true, false, false, false, true, true, true, true ,true ,false, false, false, true, false, false, false, true, false, true, false, false, true, false, false, true, true, true, true, false, true, true));
            result &= selected.x0  == SByte32.TestData_RHS[1].x0; 
            result &= selected.x1  == SByte32.TestData_RHS[1].x1;
            result &= selected.x2  == SByte32.TestData_LHS[1].x2;
            result &= selected.x3  == SByte32.TestData_LHS[1].x3;
            result &= selected.x4  == SByte32.TestData_LHS[1].x4;
            result &= selected.x5  == SByte32.TestData_RHS[1].x5;
            result &= selected.x6  == SByte32.TestData_RHS[1].x6;
            result &= selected.x7  == SByte32.TestData_RHS[1].x7;
            result &= selected.x8  == SByte32.TestData_RHS[1].x8;
            result &= selected.x9  == SByte32.TestData_RHS[1].x9;
            result &= selected.x10 == SByte32.TestData_LHS[1].x10;
            result &= selected.x11 == SByte32.TestData_LHS[1].x11;
            result &= selected.x12 == SByte32.TestData_LHS[1].x12;
            result &= selected.x13 == SByte32.TestData_RHS[1].x13;
            result &= selected.x14 == SByte32.TestData_LHS[1].x14;
            result &= selected.x15 == SByte32.TestData_LHS[1].x15;
            result &= selected.x16 == SByte32.TestData_LHS[1].x16;
            result &= selected.x17 == SByte32.TestData_RHS[1].x17;
            result &= selected.x18 == SByte32.TestData_LHS[1].x18;
            result &= selected.x19 == SByte32.TestData_RHS[1].x19;
            result &= selected.x20 == SByte32.TestData_LHS[1].x20;
            result &= selected.x21 == SByte32.TestData_LHS[1].x21; 
            result &= selected.x22 == SByte32.TestData_RHS[1].x22;
            result &= selected.x23 == SByte32.TestData_LHS[1].x23;
            result &= selected.x24 == SByte32.TestData_LHS[1].x24;
            result &= selected.x25 == SByte32.TestData_RHS[1].x25;
            result &= selected.x26 == SByte32.TestData_RHS[1].x26;
            result &= selected.x27 == SByte32.TestData_RHS[1].x27;
            result &= selected.x28 == SByte32.TestData_RHS[1].x28;
            result &= selected.x29 == SByte32.TestData_LHS[1].x29;
            result &= selected.x30 == SByte32.TestData_RHS[1].x30;
            result &= selected.x31 == SByte32.TestData_RHS[1].x31;

            selected = maxmath.select(SByte32.TestData_LHS[2], SByte32.TestData_RHS[2], new bool32(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false, true, false, true, true, false, true, false, true, true, true, false, true, true, false, false, false));
            result &= selected.x0  == SByte32.TestData_RHS[2].x0;
            result &= selected.x1  == SByte32.TestData_LHS[2].x1; 
            result &= selected.x2  == SByte32.TestData_LHS[2].x2;
            result &= selected.x3  == SByte32.TestData_RHS[2].x3;
            result &= selected.x4  == SByte32.TestData_LHS[2].x4;
            result &= selected.x5  == SByte32.TestData_RHS[2].x5;
            result &= selected.x6  == SByte32.TestData_LHS[2].x6;
            result &= selected.x7  == SByte32.TestData_LHS[2].x7;
            result &= selected.x8  == SByte32.TestData_RHS[2].x8;
            result &= selected.x9  == SByte32.TestData_RHS[2].x9;
            result &= selected.x10 == SByte32.TestData_LHS[2].x10;
            result &= selected.x11 == SByte32.TestData_RHS[2].x11;
            result &= selected.x12 == SByte32.TestData_RHS[2].x12;
            result &= selected.x13 == SByte32.TestData_RHS[2].x13;
            result &= selected.x14 == SByte32.TestData_RHS[2].x14;
            result &= selected.x15 == SByte32.TestData_LHS[2].x15;
            result &= selected.x16 == SByte32.TestData_RHS[2].x16;
            result &= selected.x17 == SByte32.TestData_LHS[2].x17;
            result &= selected.x18 == SByte32.TestData_RHS[2].x18;
            result &= selected.x19 == SByte32.TestData_RHS[2].x19;
            result &= selected.x20 == SByte32.TestData_LHS[2].x20;
            result &= selected.x21 == SByte32.TestData_RHS[2].x21;
            result &= selected.x22 == SByte32.TestData_LHS[2].x22;
            result &= selected.x23 == SByte32.TestData_RHS[2].x23;
            result &= selected.x24 == SByte32.TestData_RHS[2].x24;
            result &= selected.x25 == SByte32.TestData_RHS[2].x25;
            result &= selected.x26 == SByte32.TestData_LHS[2].x26;
            result &= selected.x27 == SByte32.TestData_RHS[2].x27;
            result &= selected.x28 == SByte32.TestData_RHS[2].x28;
            result &= selected.x29 == SByte32.TestData_LHS[2].x29;
            result &= selected.x30 == SByte32.TestData_LHS[2].x30;
            result &= selected.x31 == SByte32.TestData_LHS[2].x31;
                                                                                                                                                                                    
            selected = maxmath.select(SByte32.TestData_LHS[3], SByte32.TestData_RHS[3], new bool32(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false, true ,false, true, false, true, false, false, true ,true ,false, false, true, true, true, true ,false));
            result &= selected.x0  == SByte32.TestData_RHS[3].x0;
            result &= selected.x1  == SByte32.TestData_RHS[3].x1;
            result &= selected.x2  == SByte32.TestData_LHS[3].x2;
            result &= selected.x3  == SByte32.TestData_RHS[3].x3;
            result &= selected.x4  == SByte32.TestData_RHS[3].x4;
            result &= selected.x5  == SByte32.TestData_RHS[3].x5;
            result &= selected.x6  == SByte32.TestData_RHS[3].x6;
            result &= selected.x7  == SByte32.TestData_RHS[3].x7;
            result &= selected.x8  == SByte32.TestData_LHS[3].x8;
            result &= selected.x9  == SByte32.TestData_RHS[3].x9;
            result &= selected.x10 == SByte32.TestData_RHS[3].x10;
            result &= selected.x11 == SByte32.TestData_RHS[3].x11;
            result &= selected.x12 == SByte32.TestData_LHS[3].x12;
            result &= selected.x13 == SByte32.TestData_RHS[3].x13;
            result &= selected.x14 == SByte32.TestData_LHS[3].x14;
            result &= selected.x15 == SByte32.TestData_LHS[3].x15;
            result &= selected.x16 == SByte32.TestData_RHS[3].x16;
            result &= selected.x17 == SByte32.TestData_LHS[3].x17;
            result &= selected.x18 == SByte32.TestData_RHS[3].x18;
            result &= selected.x19 == SByte32.TestData_LHS[3].x19;
            result &= selected.x20 == SByte32.TestData_RHS[3].x20;
            result &= selected.x21 == SByte32.TestData_LHS[3].x21;
            result &= selected.x22 == SByte32.TestData_LHS[3].x22;
            result &= selected.x23 == SByte32.TestData_RHS[3].x23;
            result &= selected.x24 == SByte32.TestData_RHS[3].x24;
            result &= selected.x25 == SByte32.TestData_LHS[3].x25;
            result &= selected.x26 == SByte32.TestData_LHS[3].x26;
            result &= selected.x27 == SByte32.TestData_RHS[3].x27;
            result &= selected.x28 == SByte32.TestData_RHS[3].x28;
            result &= selected.x29 == SByte32.TestData_RHS[3].x29;
            result &= selected.x30 == SByte32.TestData_RHS[3].x30;
            result &= selected.x31 == SByte32.TestData_LHS[3].x31;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ushort2_via_bool()
        {
            bool result = true;


            ushort2 selected;

            selected = maxmath.select(UShort2.TestData_LHS[0], UShort2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == UShort2.TestData_LHS[0].x;
            result &= selected.y == UShort2.TestData_RHS[0].y;

            selected = maxmath.select(UShort2.TestData_LHS[1], UShort2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == UShort2.TestData_RHS[1].x;
            result &= selected.y == UShort2.TestData_RHS[1].y;

            selected = maxmath.select(UShort2.TestData_LHS[2], UShort2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == UShort2.TestData_LHS[2].x;
            result &= selected.y == UShort2.TestData_LHS[2].y;

            selected = maxmath.select(UShort2.TestData_LHS[3], UShort2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == UShort2.TestData_RHS[3].x;
            result &= selected.y == UShort2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void short2_via_bool()
        {
            bool result = true;


            short2 selected;

            selected = maxmath.select(Short2.TestData_LHS[0], Short2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == Short2.TestData_LHS[0].x;
            result &= selected.y == Short2.TestData_RHS[0].y;

            selected = maxmath.select(Short2.TestData_LHS[1], Short2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == Short2.TestData_RHS[1].x;
            result &= selected.y == Short2.TestData_RHS[1].y;

            selected = maxmath.select(Short2.TestData_LHS[2], Short2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == Short2.TestData_LHS[2].x;
            result &= selected.y == Short2.TestData_LHS[2].y;

            selected = maxmath.select(Short2.TestData_LHS[3], Short2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == Short2.TestData_RHS[3].x;
            result &= selected.y == Short2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ushort3_via_bool()
        {
            bool result = true;


            ushort3 selected;

            selected = maxmath.select(UShort3.TestData_LHS[0], UShort3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == UShort3.TestData_LHS[0].x;
            result &= selected.y == UShort3.TestData_RHS[0].y;
            result &= selected.z == UShort3.TestData_RHS[0].z;

            selected = maxmath.select(UShort3.TestData_LHS[1], UShort3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == UShort3.TestData_RHS[1].x;
            result &= selected.y == UShort3.TestData_RHS[1].y;
            result &= selected.z == UShort3.TestData_LHS[1].z;

            selected = maxmath.select(UShort3.TestData_LHS[2], UShort3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == UShort3.TestData_LHS[2].x;
            result &= selected.y == UShort3.TestData_LHS[2].y;
            result &= selected.z == UShort3.TestData_RHS[2].z;

            selected = maxmath.select(UShort3.TestData_LHS[3], UShort3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == UShort3.TestData_RHS[3].x;
            result &= selected.y == UShort3.TestData_LHS[3].y;
            result &= selected.z == UShort3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void short3_via_bool()
        {
            bool result = true;


            short3 selected;

            selected = maxmath.select(Short3.TestData_LHS[0], Short3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == Short3.TestData_LHS[0].x;
            result &= selected.y == Short3.TestData_RHS[0].y;
            result &= selected.z == Short3.TestData_RHS[0].z;

            selected = maxmath.select(Short3.TestData_LHS[1], Short3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == Short3.TestData_RHS[1].x;
            result &= selected.y == Short3.TestData_RHS[1].y;
            result &= selected.z == Short3.TestData_LHS[1].z;

            selected = maxmath.select(Short3.TestData_LHS[2], Short3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == Short3.TestData_LHS[2].x;
            result &= selected.y == Short3.TestData_LHS[2].y;
            result &= selected.z == Short3.TestData_RHS[2].z;

            selected = maxmath.select(Short3.TestData_LHS[3], Short3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == Short3.TestData_RHS[3].x;
            result &= selected.y == Short3.TestData_LHS[3].y;
            result &= selected.z == Short3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ushort4_via_bool()
        {
            bool result = true;


            ushort4 selected;

            selected = maxmath.select(UShort4.TestData_LHS[0], UShort4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == UShort4.TestData_LHS[0].x;
            result &= selected.y == UShort4.TestData_RHS[0].y;
            result &= selected.z == UShort4.TestData_RHS[0].z;
            result &= selected.w == UShort4.TestData_RHS[0].w;

            selected = maxmath.select(UShort4.TestData_LHS[1], UShort4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == UShort4.TestData_RHS[1].x;
            result &= selected.y == UShort4.TestData_RHS[1].y;
            result &= selected.z == UShort4.TestData_RHS[1].z;
            result &= selected.w == UShort4.TestData_LHS[1].w;

            selected = maxmath.select(UShort4.TestData_LHS[2], UShort4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == UShort4.TestData_LHS[2].x;
            result &= selected.y == UShort4.TestData_RHS[2].y;
            result &= selected.z == UShort4.TestData_RHS[2].z;
            result &= selected.w == UShort4.TestData_LHS[2].w;

            selected = maxmath.select(UShort4.TestData_LHS[3], UShort4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == UShort4.TestData_RHS[3].x;
            result &= selected.y == UShort4.TestData_LHS[3].y;
            result &= selected.z == UShort4.TestData_RHS[3].z;
            result &= selected.w == UShort4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void short4_via_bool()
        {
            bool result = true;


            short4 selected;

            selected = maxmath.select(Short4.TestData_LHS[0], Short4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == Short4.TestData_LHS[0].x;
            result &= selected.y == Short4.TestData_RHS[0].y;
            result &= selected.z == Short4.TestData_RHS[0].z;
            result &= selected.w == Short4.TestData_RHS[0].w;

            selected = maxmath.select(Short4.TestData_LHS[1], Short4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == Short4.TestData_RHS[1].x;
            result &= selected.y == Short4.TestData_RHS[1].y;
            result &= selected.z == Short4.TestData_RHS[1].z;
            result &= selected.w == Short4.TestData_LHS[1].w;

            selected = maxmath.select(Short4.TestData_LHS[2], Short4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == Short4.TestData_LHS[2].x;
            result &= selected.y == Short4.TestData_RHS[2].y;
            result &= selected.z == Short4.TestData_RHS[2].z;
            result &= selected.w == Short4.TestData_LHS[2].w;

            selected = maxmath.select(Short4.TestData_LHS[3], Short4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == Short4.TestData_RHS[3].x;
            result &= selected.y == Short4.TestData_LHS[3].y;
            result &= selected.z == Short4.TestData_RHS[3].z;
            result &= selected.w == Short4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ushort8_via_bool()
        {
            bool result = true;


            ushort8 selected;

            selected = maxmath.select(UShort8.TestData_LHS[0], UShort8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == UShort8.TestData_RHS[0].x0; 
            result &= selected.x1  == UShort8.TestData_RHS[0].x1;
            result &= selected.x2  == UShort8.TestData_LHS[0].x2;
            result &= selected.x3  == UShort8.TestData_RHS[0].x3;
            result &= selected.x4  == UShort8.TestData_RHS[0].x4;
            result &= selected.x5  == UShort8.TestData_RHS[0].x5;
            result &= selected.x6  == UShort8.TestData_LHS[0].x6;
            result &= selected.x7  == UShort8.TestData_RHS[0].x7;

            selected = maxmath.select(UShort8.TestData_LHS[1], UShort8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == UShort8.TestData_RHS[1].x0;
            result &= selected.x1  == UShort8.TestData_RHS[1].x1;
            result &= selected.x2  == UShort8.TestData_LHS[1].x2;
            result &= selected.x3  == UShort8.TestData_LHS[1].x3;
            result &= selected.x4  == UShort8.TestData_LHS[1].x4;
            result &= selected.x5  == UShort8.TestData_RHS[1].x5;
            result &= selected.x6  == UShort8.TestData_RHS[1].x6;
            result &= selected.x7  == UShort8.TestData_RHS[1].x7;

            selected = maxmath.select(UShort8.TestData_LHS[2], UShort8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == UShort8.TestData_RHS[2].x0;
            result &= selected.x1  == UShort8.TestData_LHS[2].x1; 
            result &= selected.x2  == UShort8.TestData_LHS[2].x2;
            result &= selected.x3  == UShort8.TestData_RHS[2].x3;
            result &= selected.x4  == UShort8.TestData_LHS[2].x4;
            result &= selected.x5  == UShort8.TestData_RHS[2].x5;
            result &= selected.x6  == UShort8.TestData_LHS[2].x6;
            result &= selected.x7  == UShort8.TestData_LHS[2].x7;

            selected = maxmath.select(UShort8.TestData_LHS[3], UShort8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == UShort8.TestData_RHS[3].x0;
            result &= selected.x1  == UShort8.TestData_RHS[3].x1;
            result &= selected.x2  == UShort8.TestData_LHS[3].x2;
            result &= selected.x3  == UShort8.TestData_RHS[3].x3;
            result &= selected.x4  == UShort8.TestData_RHS[3].x4;
            result &= selected.x5  == UShort8.TestData_RHS[3].x5;
            result &= selected.x6  == UShort8.TestData_RHS[3].x6;
            result &= selected.x7  == UShort8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void short8_via_bool()
        {
            bool result = true;


            short8 selected;

            selected = maxmath.select(Short8.TestData_LHS[0], Short8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == Short8.TestData_RHS[0].x0; 
            result &= selected.x1  == Short8.TestData_RHS[0].x1;
            result &= selected.x2  == Short8.TestData_LHS[0].x2;
            result &= selected.x3  == Short8.TestData_RHS[0].x3;
            result &= selected.x4  == Short8.TestData_RHS[0].x4;
            result &= selected.x5  == Short8.TestData_RHS[0].x5;
            result &= selected.x6  == Short8.TestData_LHS[0].x6;
            result &= selected.x7  == Short8.TestData_RHS[0].x7;

            selected = maxmath.select(Short8.TestData_LHS[1], Short8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == Short8.TestData_RHS[1].x0;
            result &= selected.x1  == Short8.TestData_RHS[1].x1;
            result &= selected.x2  == Short8.TestData_LHS[1].x2;
            result &= selected.x3  == Short8.TestData_LHS[1].x3;
            result &= selected.x4  == Short8.TestData_LHS[1].x4;
            result &= selected.x5  == Short8.TestData_RHS[1].x5;
            result &= selected.x6  == Short8.TestData_RHS[1].x6;
            result &= selected.x7  == Short8.TestData_RHS[1].x7;

            selected = maxmath.select(Short8.TestData_LHS[2], Short8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == Short8.TestData_RHS[2].x0;
            result &= selected.x1  == Short8.TestData_LHS[2].x1; 
            result &= selected.x2  == Short8.TestData_LHS[2].x2;
            result &= selected.x3  == Short8.TestData_RHS[2].x3;
            result &= selected.x4  == Short8.TestData_LHS[2].x4;
            result &= selected.x5  == Short8.TestData_RHS[2].x5;
            result &= selected.x6  == Short8.TestData_LHS[2].x6;
            result &= selected.x7  == Short8.TestData_LHS[2].x7;

            selected = maxmath.select(Short8.TestData_LHS[3], Short8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == Short8.TestData_RHS[3].x0;
            result &= selected.x1  == Short8.TestData_RHS[3].x1;
            result &= selected.x2  == Short8.TestData_LHS[3].x2;
            result &= selected.x3  == Short8.TestData_RHS[3].x3;
            result &= selected.x4  == Short8.TestData_RHS[3].x4;
            result &= selected.x5  == Short8.TestData_RHS[3].x5;
            result &= selected.x6  == Short8.TestData_RHS[3].x6;
            result &= selected.x7  == Short8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ushort16_via_bool()
        {
            bool result = true;


            ushort16 selected;

            selected = maxmath.select(UShort16.TestData_LHS[0], UShort16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == UShort16.TestData_RHS[0].x0; 
            result &= selected.x1  == UShort16.TestData_RHS[0].x1;
            result &= selected.x2  == UShort16.TestData_LHS[0].x2;
            result &= selected.x3  == UShort16.TestData_RHS[0].x3;
            result &= selected.x4  == UShort16.TestData_RHS[0].x4;
            result &= selected.x5  == UShort16.TestData_RHS[0].x5;
            result &= selected.x6  == UShort16.TestData_LHS[0].x6;
            result &= selected.x7  == UShort16.TestData_RHS[0].x7;
            result &= selected.x8  == UShort16.TestData_LHS[0].x8;
            result &= selected.x9  == UShort16.TestData_RHS[0].x9;
            result &= selected.x10 == UShort16.TestData_LHS[0].x10;
            result &= selected.x11 == UShort16.TestData_RHS[0].x11;
            result &= selected.x12 == UShort16.TestData_LHS[0].x12;
            result &= selected.x13 == UShort16.TestData_RHS[0].x13;
            result &= selected.x14 == UShort16.TestData_LHS[0].x14;
            result &= selected.x15 == UShort16.TestData_RHS[0].x15;

            selected = maxmath.select(UShort16.TestData_LHS[1], UShort16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == UShort16.TestData_RHS[1].x0;
            result &= selected.x1  == UShort16.TestData_RHS[1].x1;
            result &= selected.x2  == UShort16.TestData_LHS[1].x2;
            result &= selected.x3  == UShort16.TestData_LHS[1].x3;
            result &= selected.x4  == UShort16.TestData_LHS[1].x4;
            result &= selected.x5  == UShort16.TestData_RHS[1].x5;
            result &= selected.x6  == UShort16.TestData_RHS[1].x6;
            result &= selected.x7  == UShort16.TestData_RHS[1].x7;
            result &= selected.x8  == UShort16.TestData_RHS[1].x8;
            result &= selected.x9  == UShort16.TestData_RHS[1].x9;
            result &= selected.x10 == UShort16.TestData_LHS[1].x10;
            result &= selected.x11 == UShort16.TestData_LHS[1].x11;
            result &= selected.x12 == UShort16.TestData_LHS[1].x12;
            result &= selected.x13 == UShort16.TestData_RHS[1].x13;
            result &= selected.x14 == UShort16.TestData_LHS[1].x14;
            result &= selected.x15 == UShort16.TestData_LHS[1].x15;

            selected = maxmath.select(UShort16.TestData_LHS[2], UShort16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == UShort16.TestData_RHS[2].x0;
            result &= selected.x1  == UShort16.TestData_LHS[2].x1; 
            result &= selected.x2  == UShort16.TestData_LHS[2].x2;
            result &= selected.x3  == UShort16.TestData_RHS[2].x3;
            result &= selected.x4  == UShort16.TestData_LHS[2].x4;
            result &= selected.x5  == UShort16.TestData_RHS[2].x5;
            result &= selected.x6  == UShort16.TestData_LHS[2].x6;
            result &= selected.x7  == UShort16.TestData_LHS[2].x7;
            result &= selected.x8  == UShort16.TestData_RHS[2].x8;
            result &= selected.x9  == UShort16.TestData_RHS[2].x9;
            result &= selected.x10 == UShort16.TestData_LHS[2].x10;
            result &= selected.x11 == UShort16.TestData_RHS[2].x11;
            result &= selected.x12 == UShort16.TestData_RHS[2].x12;
            result &= selected.x13 == UShort16.TestData_RHS[2].x13;
            result &= selected.x14 == UShort16.TestData_RHS[2].x14;
            result &= selected.x15 == UShort16.TestData_LHS[2].x15;

            selected = maxmath.select(UShort16.TestData_LHS[3], UShort16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == UShort16.TestData_RHS[3].x0;
            result &= selected.x1  == UShort16.TestData_RHS[3].x1;
            result &= selected.x2  == UShort16.TestData_LHS[3].x2;
            result &= selected.x3  == UShort16.TestData_RHS[3].x3;
            result &= selected.x4  == UShort16.TestData_RHS[3].x4;
            result &= selected.x5  == UShort16.TestData_RHS[3].x5;
            result &= selected.x6  == UShort16.TestData_RHS[3].x6;
            result &= selected.x7  == UShort16.TestData_RHS[3].x7;
            result &= selected.x8  == UShort16.TestData_LHS[3].x8;
            result &= selected.x9  == UShort16.TestData_RHS[3].x9;
            result &= selected.x10 == UShort16.TestData_RHS[3].x10;
            result &= selected.x11 == UShort16.TestData_RHS[3].x11;
            result &= selected.x12 == UShort16.TestData_LHS[3].x12;
            result &= selected.x13 == UShort16.TestData_RHS[3].x13;
            result &= selected.x14 == UShort16.TestData_LHS[3].x14;
            result &= selected.x15 == UShort16.TestData_LHS[3].x15;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void short16_via_bool()
        {
            bool result = true;


            short16 selected;

            selected = maxmath.select(Short16.TestData_LHS[0], Short16.TestData_RHS[0], new bool16(true, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true));
            result &= selected.x0  == Short16.TestData_RHS[0].x0; 
            result &= selected.x1  == Short16.TestData_RHS[0].x1;
            result &= selected.x2  == Short16.TestData_LHS[0].x2;
            result &= selected.x3  == Short16.TestData_RHS[0].x3;
            result &= selected.x4  == Short16.TestData_RHS[0].x4;
            result &= selected.x5  == Short16.TestData_RHS[0].x5;
            result &= selected.x6  == Short16.TestData_LHS[0].x6;
            result &= selected.x7  == Short16.TestData_RHS[0].x7;
            result &= selected.x8  == Short16.TestData_LHS[0].x8;
            result &= selected.x9  == Short16.TestData_RHS[0].x9;
            result &= selected.x10 == Short16.TestData_LHS[0].x10;
            result &= selected.x11 == Short16.TestData_RHS[0].x11;
            result &= selected.x12 == Short16.TestData_LHS[0].x12;
            result &= selected.x13 == Short16.TestData_RHS[0].x13;
            result &= selected.x14 == Short16.TestData_LHS[0].x14;
            result &= selected.x15 == Short16.TestData_RHS[0].x15;

            selected = maxmath.select(Short16.TestData_LHS[1], Short16.TestData_RHS[1], new bool16(true, true, false, false, false, true, true, true, true, true, false, false, false, true, false, false));
            result &= selected.x0  == Short16.TestData_RHS[1].x0;
            result &= selected.x1  == Short16.TestData_RHS[1].x1;
            result &= selected.x2  == Short16.TestData_LHS[1].x2;
            result &= selected.x3  == Short16.TestData_LHS[1].x3;
            result &= selected.x4  == Short16.TestData_LHS[1].x4;
            result &= selected.x5  == Short16.TestData_RHS[1].x5;
            result &= selected.x6  == Short16.TestData_RHS[1].x6;
            result &= selected.x7  == Short16.TestData_RHS[1].x7;
            result &= selected.x8  == Short16.TestData_RHS[1].x8;
            result &= selected.x9  == Short16.TestData_RHS[1].x9;
            result &= selected.x10 == Short16.TestData_LHS[1].x10;
            result &= selected.x11 == Short16.TestData_LHS[1].x11;
            result &= selected.x12 == Short16.TestData_LHS[1].x12;
            result &= selected.x13 == Short16.TestData_RHS[1].x13;
            result &= selected.x14 == Short16.TestData_LHS[1].x14;
            result &= selected.x15 == Short16.TestData_LHS[1].x15;

            selected = maxmath.select(Short16.TestData_LHS[2], Short16.TestData_RHS[2], new bool16(true, false, false, true, false, true, false, false, true, true, false, true, true, true, true, false));
            result &= selected.x0  == Short16.TestData_RHS[2].x0;
            result &= selected.x1  == Short16.TestData_LHS[2].x1; 
            result &= selected.x2  == Short16.TestData_LHS[2].x2;
            result &= selected.x3  == Short16.TestData_RHS[2].x3;
            result &= selected.x4  == Short16.TestData_LHS[2].x4;
            result &= selected.x5  == Short16.TestData_RHS[2].x5;
            result &= selected.x6  == Short16.TestData_LHS[2].x6;
            result &= selected.x7  == Short16.TestData_LHS[2].x7;
            result &= selected.x8  == Short16.TestData_RHS[2].x8;
            result &= selected.x9  == Short16.TestData_RHS[2].x9;
            result &= selected.x10 == Short16.TestData_LHS[2].x10;
            result &= selected.x11 == Short16.TestData_RHS[2].x11;
            result &= selected.x12 == Short16.TestData_RHS[2].x12;
            result &= selected.x13 == Short16.TestData_RHS[2].x13;
            result &= selected.x14 == Short16.TestData_RHS[2].x14;
            result &= selected.x15 == Short16.TestData_LHS[2].x15;

            selected = maxmath.select(Short16.TestData_LHS[3], Short16.TestData_RHS[3], new bool16(true, true, false, true, true, true, true, true, false, true, true, true, false, true, false, false));
            result &= selected.x0  == Short16.TestData_RHS[3].x0;
            result &= selected.x1  == Short16.TestData_RHS[3].x1;
            result &= selected.x2  == Short16.TestData_LHS[3].x2;
            result &= selected.x3  == Short16.TestData_RHS[3].x3;
            result &= selected.x4  == Short16.TestData_RHS[3].x4;
            result &= selected.x5  == Short16.TestData_RHS[3].x5;
            result &= selected.x6  == Short16.TestData_RHS[3].x6;
            result &= selected.x7  == Short16.TestData_RHS[3].x7;
            result &= selected.x8  == Short16.TestData_LHS[3].x8;
            result &= selected.x9  == Short16.TestData_RHS[3].x9;
            result &= selected.x10 == Short16.TestData_RHS[3].x10;
            result &= selected.x11 == Short16.TestData_RHS[3].x11;
            result &= selected.x12 == Short16.TestData_LHS[3].x12;
            result &= selected.x13 == Short16.TestData_RHS[3].x13;
            result &= selected.x14 == Short16.TestData_LHS[3].x14;
            result &= selected.x15 == Short16.TestData_LHS[3].x15;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void uint8_via_bool()
        {
            bool result = true;


            uint8 selected;

            selected = maxmath.select(UInt8.TestData_LHS[0], UInt8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == UInt8.TestData_RHS[0].x0; 
            result &= selected.x1  == UInt8.TestData_RHS[0].x1;
            result &= selected.x2  == UInt8.TestData_LHS[0].x2;
            result &= selected.x3  == UInt8.TestData_RHS[0].x3;
            result &= selected.x4  == UInt8.TestData_RHS[0].x4;
            result &= selected.x5  == UInt8.TestData_RHS[0].x5;
            result &= selected.x6  == UInt8.TestData_LHS[0].x6;
            result &= selected.x7  == UInt8.TestData_RHS[0].x7;

            selected = maxmath.select(UInt8.TestData_LHS[1], UInt8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == UInt8.TestData_RHS[1].x0;
            result &= selected.x1  == UInt8.TestData_RHS[1].x1;
            result &= selected.x2  == UInt8.TestData_LHS[1].x2;
            result &= selected.x3  == UInt8.TestData_LHS[1].x3;
            result &= selected.x4  == UInt8.TestData_LHS[1].x4;
            result &= selected.x5  == UInt8.TestData_RHS[1].x5;
            result &= selected.x6  == UInt8.TestData_RHS[1].x6;
            result &= selected.x7  == UInt8.TestData_RHS[1].x7;

            selected = maxmath.select(UInt8.TestData_LHS[2], UInt8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == UInt8.TestData_RHS[2].x0;
            result &= selected.x1  == UInt8.TestData_LHS[2].x1; 
            result &= selected.x2  == UInt8.TestData_LHS[2].x2;
            result &= selected.x3  == UInt8.TestData_RHS[2].x3;
            result &= selected.x4  == UInt8.TestData_LHS[2].x4;
            result &= selected.x5  == UInt8.TestData_RHS[2].x5;
            result &= selected.x6  == UInt8.TestData_LHS[2].x6;
            result &= selected.x7  == UInt8.TestData_LHS[2].x7;

            selected = maxmath.select(UInt8.TestData_LHS[3], UInt8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == UInt8.TestData_RHS[3].x0;
            result &= selected.x1  == UInt8.TestData_RHS[3].x1;
            result &= selected.x2  == UInt8.TestData_LHS[3].x2;
            result &= selected.x3  == UInt8.TestData_RHS[3].x3;
            result &= selected.x4  == UInt8.TestData_RHS[3].x4;
            result &= selected.x5  == UInt8.TestData_RHS[3].x5;
            result &= selected.x6  == UInt8.TestData_RHS[3].x6;
            result &= selected.x7  == UInt8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void int8_via_bool()
        {
            bool result = true;


            int8 selected;

            selected = maxmath.select(Int8.TestData_LHS[0], Int8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0  == Int8.TestData_RHS[0].x0; 
            result &= selected.x1  == Int8.TestData_RHS[0].x1;
            result &= selected.x2  == Int8.TestData_LHS[0].x2;
            result &= selected.x3  == Int8.TestData_RHS[0].x3;
            result &= selected.x4  == Int8.TestData_RHS[0].x4;
            result &= selected.x5  == Int8.TestData_RHS[0].x5;
            result &= selected.x6  == Int8.TestData_LHS[0].x6;
            result &= selected.x7  == Int8.TestData_RHS[0].x7;

            selected = maxmath.select(Int8.TestData_LHS[1], Int8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0  == Int8.TestData_RHS[1].x0;
            result &= selected.x1  == Int8.TestData_RHS[1].x1;
            result &= selected.x2  == Int8.TestData_LHS[1].x2;
            result &= selected.x3  == Int8.TestData_LHS[1].x3;
            result &= selected.x4  == Int8.TestData_LHS[1].x4;
            result &= selected.x5  == Int8.TestData_RHS[1].x5;
            result &= selected.x6  == Int8.TestData_RHS[1].x6;
            result &= selected.x7  == Int8.TestData_RHS[1].x7;

            selected = maxmath.select(Int8.TestData_LHS[2], Int8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0  == Int8.TestData_RHS[2].x0;
            result &= selected.x1  == Int8.TestData_LHS[2].x1; 
            result &= selected.x2  == Int8.TestData_LHS[2].x2;
            result &= selected.x3  == Int8.TestData_RHS[2].x3;
            result &= selected.x4  == Int8.TestData_LHS[2].x4;
            result &= selected.x5  == Int8.TestData_RHS[2].x5;
            result &= selected.x6  == Int8.TestData_LHS[2].x6;
            result &= selected.x7  == Int8.TestData_LHS[2].x7;

            selected = maxmath.select(Int8.TestData_LHS[3], Int8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0  == Int8.TestData_RHS[3].x0;
            result &= selected.x1  == Int8.TestData_RHS[3].x1;
            result &= selected.x2  == Int8.TestData_LHS[3].x2;
            result &= selected.x3  == Int8.TestData_RHS[3].x3;
            result &= selected.x4  == Int8.TestData_RHS[3].x4;
            result &= selected.x5  == Int8.TestData_RHS[3].x5;
            result &= selected.x6  == Int8.TestData_RHS[3].x6;
            result &= selected.x7  == Int8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ulong2_via_bool()
        {
            bool result = true;


            ulong2 selected;

            selected = maxmath.select(ULong2.TestData_LHS[0], ULong2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == ULong2.TestData_LHS[0].x;
            result &= selected.y == ULong2.TestData_RHS[0].y;

            selected = maxmath.select(ULong2.TestData_LHS[1], ULong2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == ULong2.TestData_RHS[1].x;
            result &= selected.y == ULong2.TestData_RHS[1].y;

            selected = maxmath.select(ULong2.TestData_LHS[2], ULong2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == ULong2.TestData_LHS[2].x;
            result &= selected.y == ULong2.TestData_LHS[2].y;

            selected = maxmath.select(ULong2.TestData_LHS[3], ULong2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == ULong2.TestData_RHS[3].x;
            result &= selected.y == ULong2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void long2_via_bool()
        {
            bool result = true;


            long2 selected;

            selected = maxmath.select(Long2.TestData_LHS[0], Long2.TestData_RHS[0], new bool2(false, true));
            result &= selected.x == Long2.TestData_LHS[0].x;
            result &= selected.y == Long2.TestData_RHS[0].y;

            selected = maxmath.select(Long2.TestData_LHS[1], Long2.TestData_RHS[1], new bool2(true, true));
            result &= selected.x == Long2.TestData_RHS[1].x;
            result &= selected.y == Long2.TestData_RHS[1].y;

            selected = maxmath.select(Long2.TestData_LHS[2], Long2.TestData_RHS[2], new bool2(false, false));
            result &= selected.x == Long2.TestData_LHS[2].x;
            result &= selected.y == Long2.TestData_LHS[2].y;

            selected = maxmath.select(Long2.TestData_LHS[3], Long2.TestData_RHS[3], new bool2(true, false));
            result &= selected.x == Long2.TestData_RHS[3].x;
            result &= selected.y == Long2.TestData_LHS[3].y;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ulong3_via_bool()
        {
            bool result = true;


            ulong3 selected;

            selected = maxmath.select(ULong3.TestData_LHS[0], ULong3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == ULong3.TestData_LHS[0].x;
            result &= selected.y == ULong3.TestData_RHS[0].y;
            result &= selected.z == ULong3.TestData_RHS[0].z;

            selected = maxmath.select(ULong3.TestData_LHS[1], ULong3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == ULong3.TestData_RHS[1].x;
            result &= selected.y == ULong3.TestData_RHS[1].y;
            result &= selected.z == ULong3.TestData_LHS[1].z;

            selected = maxmath.select(ULong3.TestData_LHS[2], ULong3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == ULong3.TestData_LHS[2].x;
            result &= selected.y == ULong3.TestData_LHS[2].y;
            result &= selected.z == ULong3.TestData_RHS[2].z;

            selected = maxmath.select(ULong3.TestData_LHS[3], ULong3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == ULong3.TestData_RHS[3].x;
            result &= selected.y == ULong3.TestData_LHS[3].y;
            result &= selected.z == ULong3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void long3_via_bool()
        {
            bool result = true;


            long3 selected;

            selected = maxmath.select(Long3.TestData_LHS[0], Long3.TestData_RHS[0], new bool3(false, true, true));
            result &= selected.x == Long3.TestData_LHS[0].x;
            result &= selected.y == Long3.TestData_RHS[0].y;
            result &= selected.z == Long3.TestData_RHS[0].z;

            selected = maxmath.select(Long3.TestData_LHS[1], Long3.TestData_RHS[1], new bool3(true, true, false));
            result &= selected.x == Long3.TestData_RHS[1].x;
            result &= selected.y == Long3.TestData_RHS[1].y;
            result &= selected.z == Long3.TestData_LHS[1].z;

            selected = maxmath.select(Long3.TestData_LHS[2], Long3.TestData_RHS[2], new bool3(false, false, true));
            result &= selected.x == Long3.TestData_LHS[2].x;
            result &= selected.y == Long3.TestData_LHS[2].y;
            result &= selected.z == Long3.TestData_RHS[2].z;

            selected = maxmath.select(Long3.TestData_LHS[3], Long3.TestData_RHS[3], new bool3(true, false, true));
            result &= selected.x == Long3.TestData_RHS[3].x;
            result &= selected.y == Long3.TestData_LHS[3].y;
            result &= selected.z == Long3.TestData_RHS[3].z;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void ulong4_via_bool()
        {
            bool result = true;


            ulong4 selected;

            selected = maxmath.select(ULong4.TestData_LHS[0], ULong4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == ULong4.TestData_LHS[0].x;
            result &= selected.y == ULong4.TestData_RHS[0].y;
            result &= selected.z == ULong4.TestData_RHS[0].z;
            result &= selected.w == ULong4.TestData_RHS[0].w;

            selected = maxmath.select(ULong4.TestData_LHS[1], ULong4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == ULong4.TestData_RHS[1].x;
            result &= selected.y == ULong4.TestData_RHS[1].y;
            result &= selected.z == ULong4.TestData_RHS[1].z;
            result &= selected.w == ULong4.TestData_LHS[1].w;

            selected = maxmath.select(ULong4.TestData_LHS[2], ULong4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == ULong4.TestData_LHS[2].x;
            result &= selected.y == ULong4.TestData_RHS[2].y;
            result &= selected.z == ULong4.TestData_RHS[2].z;
            result &= selected.w == ULong4.TestData_LHS[2].w;

            selected = maxmath.select(ULong4.TestData_LHS[3], ULong4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == ULong4.TestData_RHS[3].x;
            result &= selected.y == ULong4.TestData_LHS[3].y;
            result &= selected.z == ULong4.TestData_RHS[3].z;
            result &= selected.w == ULong4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }

        [Test]
        public static void long4_via_bool()
        {
            bool result = true;


            long4 selected;

            selected = maxmath.select(Long4.TestData_LHS[0], Long4.TestData_RHS[0], new bool4(false, true, true, true));
            result &= selected.x == Long4.TestData_LHS[0].x;
            result &= selected.y == Long4.TestData_RHS[0].y;
            result &= selected.z == Long4.TestData_RHS[0].z;
            result &= selected.w == Long4.TestData_RHS[0].w;

            selected = maxmath.select(Long4.TestData_LHS[1], Long4.TestData_RHS[1], new bool4(true, true, true, false));
            result &= selected.x == Long4.TestData_RHS[1].x;
            result &= selected.y == Long4.TestData_RHS[1].y;
            result &= selected.z == Long4.TestData_RHS[1].z;
            result &= selected.w == Long4.TestData_LHS[1].w;

            selected = maxmath.select(Long4.TestData_LHS[2], Long4.TestData_RHS[2], new bool4(false, true, true, false));
            result &= selected.x == Long4.TestData_LHS[2].x;
            result &= selected.y == Long4.TestData_RHS[2].y;
            result &= selected.z == Long4.TestData_RHS[2].z;
            result &= selected.w == Long4.TestData_LHS[2].w;

            selected = maxmath.select(Long4.TestData_LHS[3], Long4.TestData_RHS[3], new bool4(true, false, true, true));
            result &= selected.x == Long4.TestData_RHS[3].x;
            result &= selected.y == Long4.TestData_LHS[3].y;
            result &= selected.z == Long4.TestData_RHS[3].z;
            result &= selected.w == Long4.TestData_RHS[3].w;


            Assert.AreEqual(result, true);
        }


        [Test]
        public static void float8_via_bool()
        {
            bool result = true;


            float8 selected;

            selected = maxmath.select(Float8.TestData_LHS[0], Float8.TestData_RHS[0], new bool8(true, true, false, true, true, true, false, true));
            result &= selected.x0 == Float8.TestData_RHS[0].x0; 
            result &= selected.x1 == Float8.TestData_RHS[0].x1;
            result &= selected.x2 == Float8.TestData_LHS[0].x2;
            result &= selected.x3 == Float8.TestData_RHS[0].x3;
            result &= selected.x4 == Float8.TestData_RHS[0].x4;
            result &= selected.x5 == Float8.TestData_RHS[0].x5;
            result &= selected.x6 == Float8.TestData_LHS[0].x6;
            result &= selected.x7 == Float8.TestData_RHS[0].x7;

            selected = maxmath.select(Float8.TestData_LHS[1], Float8.TestData_RHS[1], new bool8(true, true, false, false, false, true, true, true));
            result &= selected.x0 == Float8.TestData_RHS[1].x0;
            result &= selected.x1 == Float8.TestData_RHS[1].x1;
            result &= selected.x2 == Float8.TestData_LHS[1].x2;
            result &= selected.x3 == Float8.TestData_LHS[1].x3;
            result &= selected.x4 == Float8.TestData_LHS[1].x4;
            result &= selected.x5 == Float8.TestData_RHS[1].x5;
            result &= selected.x6 == Float8.TestData_RHS[1].x6;
            result &= selected.x7 == Float8.TestData_RHS[1].x7;

            selected = maxmath.select(Float8.TestData_LHS[2], Float8.TestData_RHS[2], new bool8(true, false, false, true, false, true, false, false));
            result &= selected.x0 == Float8.TestData_RHS[2].x0;
            result &= selected.x1 == Float8.TestData_LHS[2].x1; 
            result &= selected.x2 == Float8.TestData_LHS[2].x2;
            result &= selected.x3 == Float8.TestData_RHS[2].x3;
            result &= selected.x4 == Float8.TestData_LHS[2].x4;
            result &= selected.x5 == Float8.TestData_RHS[2].x5;
            result &= selected.x6 == Float8.TestData_LHS[2].x6;
            result &= selected.x7 == Float8.TestData_LHS[2].x7;

            selected = maxmath.select(Float8.TestData_LHS[3], Float8.TestData_RHS[3], new bool8(true, true, false, true, true, true, true, true));
            result &= selected.x0 == Float8.TestData_RHS[3].x0;
            result &= selected.x1 == Float8.TestData_RHS[3].x1;
            result &= selected.x2 == Float8.TestData_LHS[3].x2;
            result &= selected.x3 == Float8.TestData_RHS[3].x3;
            result &= selected.x4 == Float8.TestData_RHS[3].x4;
            result &= selected.x5 == Float8.TestData_RHS[3].x5;
            result &= selected.x6 == Float8.TestData_RHS[3].x6;
            result &= selected.x7 == Float8.TestData_RHS[3].x7;


            Assert.AreEqual(result, true);
        }
    }
}


