using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class select_via_int
    {
        [Test]
        public static void byte2_via_int()
        {
            bool result = true;


            byte2 selected;

            selected = maxmath.select(__byte2.TestData_LHS[0], __byte2.TestData_RHS[0], 0b10);
            result &= selected.x == __byte2.TestData_LHS[0].x;
            result &= selected.y == __byte2.TestData_RHS[0].y;

            selected = maxmath.select(__byte2.TestData_LHS[1], __byte2.TestData_RHS[1], 0b11);
            result &= selected.x == __byte2.TestData_RHS[1].x;
            result &= selected.y == __byte2.TestData_RHS[1].y;

            selected = maxmath.select(__byte2.TestData_LHS[2], __byte2.TestData_RHS[2], 0b00);
            result &= selected.x == __byte2.TestData_LHS[2].x;
            result &= selected.y == __byte2.TestData_LHS[2].y;

            selected = maxmath.select(__byte2.TestData_LHS[3], __byte2.TestData_RHS[3], 0b01);
            result &= selected.x == __byte2.TestData_RHS[3].x;
            result &= selected.y == __byte2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte2_via_int()
        {
            bool result = true;


            sbyte2 selected;

            selected = maxmath.select(__sbyte2.TestData_LHS[0], __sbyte2.TestData_RHS[0], 0b10);
            result &= selected.x == __sbyte2.TestData_LHS[0].x;
            result &= selected.y == __sbyte2.TestData_RHS[0].y;

            selected = maxmath.select(__sbyte2.TestData_LHS[1], __sbyte2.TestData_RHS[1], 0b11);
            result &= selected.x == __sbyte2.TestData_RHS[1].x;
            result &= selected.y == __sbyte2.TestData_RHS[1].y;

            selected = maxmath.select(__sbyte2.TestData_LHS[2], __sbyte2.TestData_RHS[2], 0b00);
            result &= selected.x == __sbyte2.TestData_LHS[2].x;
            result &= selected.y == __sbyte2.TestData_LHS[2].y;

            selected = maxmath.select(__sbyte2.TestData_LHS[3], __sbyte2.TestData_RHS[3], 0b01);
            result &= selected.x == __sbyte2.TestData_RHS[3].x;
            result &= selected.y == __sbyte2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void byte3_via_int()
        {
            bool result = true;


            byte3 selected;

            selected = maxmath.select(__byte3.TestData_LHS[0], __byte3.TestData_RHS[0], 0b110);
            result &= selected.x == __byte3.TestData_LHS[0].x;
            result &= selected.y == __byte3.TestData_RHS[0].y;
            result &= selected.z == __byte3.TestData_RHS[0].z;

            selected = maxmath.select(__byte3.TestData_LHS[1], __byte3.TestData_RHS[1], 0b011);
            result &= selected.x == __byte3.TestData_RHS[1].x;
            result &= selected.y == __byte3.TestData_RHS[1].y;
            result &= selected.z == __byte3.TestData_LHS[1].z;

            selected = maxmath.select(__byte3.TestData_LHS[2], __byte3.TestData_RHS[2], 0b100);
            result &= selected.x == __byte3.TestData_LHS[2].x;
            result &= selected.y == __byte3.TestData_LHS[2].y;
            result &= selected.z == __byte3.TestData_RHS[2].z;

            selected = maxmath.select(__byte3.TestData_LHS[3], __byte3.TestData_RHS[3], 0b101);
            result &= selected.x == __byte3.TestData_RHS[3].x;
            result &= selected.y == __byte3.TestData_LHS[3].y;
            result &= selected.z == __byte3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte3_via_int()
        {
            bool result = true;


            sbyte3 selected;

            selected = maxmath.select(__sbyte3.TestData_LHS[0], __sbyte3.TestData_RHS[0], 0b110);
            result &= selected.x == __sbyte3.TestData_LHS[0].x;
            result &= selected.y == __sbyte3.TestData_RHS[0].y;
            result &= selected.z == __sbyte3.TestData_RHS[0].z;

            selected = maxmath.select(__sbyte3.TestData_LHS[1], __sbyte3.TestData_RHS[1], 0b011);
            result &= selected.x == __sbyte3.TestData_RHS[1].x;
            result &= selected.y == __sbyte3.TestData_RHS[1].y;
            result &= selected.z == __sbyte3.TestData_LHS[1].z;

            selected = maxmath.select(__sbyte3.TestData_LHS[2], __sbyte3.TestData_RHS[2], 0b100);
            result &= selected.x == __sbyte3.TestData_LHS[2].x;
            result &= selected.y == __sbyte3.TestData_LHS[2].y;
            result &= selected.z == __sbyte3.TestData_RHS[2].z;

            selected = maxmath.select(__sbyte3.TestData_LHS[3], __sbyte3.TestData_RHS[3], 0b101);
            result &= selected.x == __sbyte3.TestData_RHS[3].x;
            result &= selected.y == __sbyte3.TestData_LHS[3].y;
            result &= selected.z == __sbyte3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void byte4_via_int()
        {
            bool result = true;


            byte4 selected;

            selected = maxmath.select(__byte4.TestData_LHS[0], __byte4.TestData_RHS[0], 0b1110);
            result &= selected.x == __byte4.TestData_LHS[0].x;
            result &= selected.y == __byte4.TestData_RHS[0].y;
            result &= selected.z == __byte4.TestData_RHS[0].z;
            result &= selected.w == __byte4.TestData_RHS[0].w;

            selected = maxmath.select(__byte4.TestData_LHS[1], __byte4.TestData_RHS[1], 0b0111);
            result &= selected.x == __byte4.TestData_RHS[1].x;
            result &= selected.y == __byte4.TestData_RHS[1].y;
            result &= selected.z == __byte4.TestData_RHS[1].z;
            result &= selected.w == __byte4.TestData_LHS[1].w;

            selected = maxmath.select(__byte4.TestData_LHS[2], __byte4.TestData_RHS[2], 0b0110);
            result &= selected.x == __byte4.TestData_LHS[2].x;
            result &= selected.y == __byte4.TestData_RHS[2].y;
            result &= selected.z == __byte4.TestData_RHS[2].z;
            result &= selected.w == __byte4.TestData_LHS[2].w;

            selected = maxmath.select(__byte4.TestData_LHS[3], __byte4.TestData_RHS[3], 0b1101);
            result &= selected.x == __byte4.TestData_RHS[3].x;
            result &= selected.y == __byte4.TestData_LHS[3].y;
            result &= selected.z == __byte4.TestData_RHS[3].z;
            result &= selected.w == __byte4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte4_via_int()
        {
            bool result = true;


            sbyte4 selected;

            selected = maxmath.select(__sbyte4.TestData_LHS[0], __sbyte4.TestData_RHS[0], 0b1110);
            result &= selected.x == __sbyte4.TestData_LHS[0].x;
            result &= selected.y == __sbyte4.TestData_RHS[0].y;
            result &= selected.z == __sbyte4.TestData_RHS[0].z;
            result &= selected.w == __sbyte4.TestData_RHS[0].w;

            selected = maxmath.select(__sbyte4.TestData_LHS[1], __sbyte4.TestData_RHS[1], 0b0111);
            result &= selected.x == __sbyte4.TestData_RHS[1].x;
            result &= selected.y == __sbyte4.TestData_RHS[1].y;
            result &= selected.z == __sbyte4.TestData_RHS[1].z;
            result &= selected.w == __sbyte4.TestData_LHS[1].w;

            selected = maxmath.select(__sbyte4.TestData_LHS[2], __sbyte4.TestData_RHS[2], 0b0110);
            result &= selected.x == __sbyte4.TestData_LHS[2].x;
            result &= selected.y == __sbyte4.TestData_RHS[2].y;
            result &= selected.z == __sbyte4.TestData_RHS[2].z;
            result &= selected.w == __sbyte4.TestData_LHS[2].w;

            selected = maxmath.select(__sbyte4.TestData_LHS[3], __sbyte4.TestData_RHS[3], 0b1101);
            result &= selected.x == __sbyte4.TestData_RHS[3].x;
            result &= selected.y == __sbyte4.TestData_LHS[3].y;
            result &= selected.z == __sbyte4.TestData_RHS[3].z;
            result &= selected.w == __sbyte4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void byte8_via_int()
        {
            bool result = true;


            byte8 selected;

            selected = maxmath.select(__byte8.TestData_LHS[0], __byte8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0  == __byte8.TestData_RHS[0].x0; 
            result &= selected.x1  == __byte8.TestData_RHS[0].x1;
            result &= selected.x2  == __byte8.TestData_LHS[0].x2;
            result &= selected.x3  == __byte8.TestData_RHS[0].x3;
            result &= selected.x4  == __byte8.TestData_RHS[0].x4;
            result &= selected.x5  == __byte8.TestData_RHS[0].x5;
            result &= selected.x6  == __byte8.TestData_LHS[0].x6;
            result &= selected.x7  == __byte8.TestData_RHS[0].x7;

            selected = maxmath.select(__byte8.TestData_LHS[1], __byte8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0  == __byte8.TestData_RHS[1].x0;
            result &= selected.x1  == __byte8.TestData_RHS[1].x1;
            result &= selected.x2  == __byte8.TestData_LHS[1].x2;
            result &= selected.x3  == __byte8.TestData_LHS[1].x3;
            result &= selected.x4  == __byte8.TestData_LHS[1].x4;
            result &= selected.x5  == __byte8.TestData_RHS[1].x5;
            result &= selected.x6  == __byte8.TestData_RHS[1].x6;
            result &= selected.x7  == __byte8.TestData_RHS[1].x7;

            selected = maxmath.select(__byte8.TestData_LHS[2], __byte8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __byte8.TestData_RHS[2].x0;
            result &= selected.x1  == __byte8.TestData_LHS[2].x1; 
            result &= selected.x2  == __byte8.TestData_LHS[2].x2;
            result &= selected.x3  == __byte8.TestData_RHS[2].x3;
            result &= selected.x4  == __byte8.TestData_LHS[2].x4;
            result &= selected.x5  == __byte8.TestData_RHS[2].x5;
            result &= selected.x6  == __byte8.TestData_LHS[2].x6;
            result &= selected.x7  == __byte8.TestData_LHS[2].x7;

            selected = maxmath.select(__byte8.TestData_LHS[3], __byte8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __byte8.TestData_RHS[3].x0;
            result &= selected.x1  == __byte8.TestData_RHS[3].x1;
            result &= selected.x2  == __byte8.TestData_LHS[3].x2;
            result &= selected.x3  == __byte8.TestData_RHS[3].x3;
            result &= selected.x4  == __byte8.TestData_RHS[3].x4;
            result &= selected.x5  == __byte8.TestData_RHS[3].x5;
            result &= selected.x6  == __byte8.TestData_RHS[3].x6;
            result &= selected.x7  == __byte8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte8_via_int()
        {
            bool result = true;


            sbyte8 selected;

            selected = maxmath.select(__sbyte8.TestData_LHS[0], __sbyte8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0  == __sbyte8.TestData_RHS[0].x0; 
            result &= selected.x1  == __sbyte8.TestData_RHS[0].x1;
            result &= selected.x2  == __sbyte8.TestData_LHS[0].x2;
            result &= selected.x3  == __sbyte8.TestData_RHS[0].x3;
            result &= selected.x4  == __sbyte8.TestData_RHS[0].x4;
            result &= selected.x5  == __sbyte8.TestData_RHS[0].x5;
            result &= selected.x6  == __sbyte8.TestData_LHS[0].x6;
            result &= selected.x7  == __sbyte8.TestData_RHS[0].x7;

            selected = maxmath.select(__sbyte8.TestData_LHS[1], __sbyte8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0  == __sbyte8.TestData_RHS[1].x0;
            result &= selected.x1  == __sbyte8.TestData_RHS[1].x1;
            result &= selected.x2  == __sbyte8.TestData_LHS[1].x2;
            result &= selected.x3  == __sbyte8.TestData_LHS[1].x3;
            result &= selected.x4  == __sbyte8.TestData_LHS[1].x4;
            result &= selected.x5  == __sbyte8.TestData_RHS[1].x5;
            result &= selected.x6  == __sbyte8.TestData_RHS[1].x6;
            result &= selected.x7  == __sbyte8.TestData_RHS[1].x7;

            selected = maxmath.select(__sbyte8.TestData_LHS[2], __sbyte8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __sbyte8.TestData_RHS[2].x0;
            result &= selected.x1  == __sbyte8.TestData_LHS[2].x1; 
            result &= selected.x2  == __sbyte8.TestData_LHS[2].x2;
            result &= selected.x3  == __sbyte8.TestData_RHS[2].x3;
            result &= selected.x4  == __sbyte8.TestData_LHS[2].x4;
            result &= selected.x5  == __sbyte8.TestData_RHS[2].x5;
            result &= selected.x6  == __sbyte8.TestData_LHS[2].x6;
            result &= selected.x7  == __sbyte8.TestData_LHS[2].x7;

            selected = maxmath.select(__sbyte8.TestData_LHS[3], __sbyte8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __sbyte8.TestData_RHS[3].x0;
            result &= selected.x1  == __sbyte8.TestData_RHS[3].x1;
            result &= selected.x2  == __sbyte8.TestData_LHS[3].x2;
            result &= selected.x3  == __sbyte8.TestData_RHS[3].x3;
            result &= selected.x4  == __sbyte8.TestData_RHS[3].x4;
            result &= selected.x5  == __sbyte8.TestData_RHS[3].x5;
            result &= selected.x6  == __sbyte8.TestData_RHS[3].x6;
            result &= selected.x7  == __sbyte8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void byte16_via_int()
        {
            bool result = true;


            byte16 selected;

            selected = maxmath.select(__byte16.TestData_LHS[0], __byte16.TestData_RHS[0], unchecked((int)0b1010_1010_1011_1011u));
            result &= selected.x0  == __byte16.TestData_RHS[0].x0; 
            result &= selected.x1  == __byte16.TestData_RHS[0].x1;
            result &= selected.x2  == __byte16.TestData_LHS[0].x2;
            result &= selected.x3  == __byte16.TestData_RHS[0].x3;
            result &= selected.x4  == __byte16.TestData_RHS[0].x4;
            result &= selected.x5  == __byte16.TestData_RHS[0].x5;
            result &= selected.x6  == __byte16.TestData_LHS[0].x6;
            result &= selected.x7  == __byte16.TestData_RHS[0].x7;
            result &= selected.x8  == __byte16.TestData_LHS[0].x8;
            result &= selected.x9  == __byte16.TestData_RHS[0].x9;
            result &= selected.x10 == __byte16.TestData_LHS[0].x10;
            result &= selected.x11 == __byte16.TestData_RHS[0].x11;
            result &= selected.x12 == __byte16.TestData_LHS[0].x12;
            result &= selected.x13 == __byte16.TestData_RHS[0].x13;
            result &= selected.x14 == __byte16.TestData_LHS[0].x14;
            result &= selected.x15 == __byte16.TestData_RHS[0].x15;

            selected = maxmath.select(__byte16.TestData_LHS[1], __byte16.TestData_RHS[1], unchecked((int)0b0010_0011_1110_0011u));
            result &= selected.x0  == __byte16.TestData_RHS[1].x0;
            result &= selected.x1  == __byte16.TestData_RHS[1].x1;
            result &= selected.x2  == __byte16.TestData_LHS[1].x2;
            result &= selected.x3  == __byte16.TestData_LHS[1].x3;
            result &= selected.x4  == __byte16.TestData_LHS[1].x4;
            result &= selected.x5  == __byte16.TestData_RHS[1].x5;
            result &= selected.x6  == __byte16.TestData_RHS[1].x6;
            result &= selected.x7  == __byte16.TestData_RHS[1].x7;
            result &= selected.x8  == __byte16.TestData_RHS[1].x8;
            result &= selected.x9  == __byte16.TestData_RHS[1].x9;
            result &= selected.x10 == __byte16.TestData_LHS[1].x10;
            result &= selected.x11 == __byte16.TestData_LHS[1].x11;
            result &= selected.x12 == __byte16.TestData_LHS[1].x12;
            result &= selected.x13 == __byte16.TestData_RHS[1].x13;
            result &= selected.x14 == __byte16.TestData_LHS[1].x14;
            result &= selected.x15 == __byte16.TestData_LHS[1].x15;

            selected = maxmath.select(__byte16.TestData_LHS[2], __byte16.TestData_RHS[2], 0b0111_1011_0010_1001);
            result &= selected.x0  == __byte16.TestData_RHS[2].x0;
            result &= selected.x1  == __byte16.TestData_LHS[2].x1; 
            result &= selected.x2  == __byte16.TestData_LHS[2].x2;
            result &= selected.x3  == __byte16.TestData_RHS[2].x3;
            result &= selected.x4  == __byte16.TestData_LHS[2].x4;
            result &= selected.x5  == __byte16.TestData_RHS[2].x5;
            result &= selected.x6  == __byte16.TestData_LHS[2].x6;
            result &= selected.x7  == __byte16.TestData_LHS[2].x7;
            result &= selected.x8  == __byte16.TestData_RHS[2].x8;
            result &= selected.x9  == __byte16.TestData_RHS[2].x9;
            result &= selected.x10 == __byte16.TestData_LHS[2].x10;
            result &= selected.x11 == __byte16.TestData_RHS[2].x11;
            result &= selected.x12 == __byte16.TestData_RHS[2].x12;
            result &= selected.x13 == __byte16.TestData_RHS[2].x13;
            result &= selected.x14 == __byte16.TestData_RHS[2].x14;
            result &= selected.x15 == __byte16.TestData_LHS[2].x15;

            selected = maxmath.select(__byte16.TestData_LHS[3], __byte16.TestData_RHS[3], 0b0010_1110_1111_1011);
            result &= selected.x0  == __byte16.TestData_RHS[3].x0;
            result &= selected.x1  == __byte16.TestData_RHS[3].x1;
            result &= selected.x2  == __byte16.TestData_LHS[3].x2;
            result &= selected.x3  == __byte16.TestData_RHS[3].x3;
            result &= selected.x4  == __byte16.TestData_RHS[3].x4;
            result &= selected.x5  == __byte16.TestData_RHS[3].x5;
            result &= selected.x6  == __byte16.TestData_RHS[3].x6;
            result &= selected.x7  == __byte16.TestData_RHS[3].x7;
            result &= selected.x8  == __byte16.TestData_LHS[3].x8;
            result &= selected.x9  == __byte16.TestData_RHS[3].x9;
            result &= selected.x10 == __byte16.TestData_RHS[3].x10;
            result &= selected.x11 == __byte16.TestData_RHS[3].x11;
            result &= selected.x12 == __byte16.TestData_LHS[3].x12;
            result &= selected.x13 == __byte16.TestData_RHS[3].x13;
            result &= selected.x14 == __byte16.TestData_LHS[3].x14;
            result &= selected.x15 == __byte16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte16_via_int()
        {
            bool result = true;


            sbyte16 selected;

            selected = maxmath.select(__sbyte16.TestData_LHS[0], __sbyte16.TestData_RHS[0], unchecked((int)0b1010_1010_1011_1011u));
            result &= selected.x0  == __sbyte16.TestData_RHS[0].x0; 
            result &= selected.x1  == __sbyte16.TestData_RHS[0].x1;
            result &= selected.x2  == __sbyte16.TestData_LHS[0].x2;
            result &= selected.x3  == __sbyte16.TestData_RHS[0].x3;
            result &= selected.x4  == __sbyte16.TestData_RHS[0].x4;
            result &= selected.x5  == __sbyte16.TestData_RHS[0].x5;
            result &= selected.x6  == __sbyte16.TestData_LHS[0].x6;
            result &= selected.x7  == __sbyte16.TestData_RHS[0].x7;
            result &= selected.x8  == __sbyte16.TestData_LHS[0].x8;
            result &= selected.x9  == __sbyte16.TestData_RHS[0].x9;
            result &= selected.x10 == __sbyte16.TestData_LHS[0].x10;
            result &= selected.x11 == __sbyte16.TestData_RHS[0].x11;
            result &= selected.x12 == __sbyte16.TestData_LHS[0].x12;
            result &= selected.x13 == __sbyte16.TestData_RHS[0].x13;
            result &= selected.x14 == __sbyte16.TestData_LHS[0].x14;
            result &= selected.x15 == __sbyte16.TestData_RHS[0].x15;

            selected = maxmath.select(__sbyte16.TestData_LHS[1], __sbyte16.TestData_RHS[1], unchecked((int)0b0010_0011_1110_0011u));
            result &= selected.x0  == __sbyte16.TestData_RHS[1].x0;
            result &= selected.x1  == __sbyte16.TestData_RHS[1].x1;
            result &= selected.x2  == __sbyte16.TestData_LHS[1].x2;
            result &= selected.x3  == __sbyte16.TestData_LHS[1].x3;
            result &= selected.x4  == __sbyte16.TestData_LHS[1].x4;
            result &= selected.x5  == __sbyte16.TestData_RHS[1].x5;
            result &= selected.x6  == __sbyte16.TestData_RHS[1].x6;
            result &= selected.x7  == __sbyte16.TestData_RHS[1].x7;
            result &= selected.x8  == __sbyte16.TestData_RHS[1].x8;
            result &= selected.x9  == __sbyte16.TestData_RHS[1].x9;
            result &= selected.x10 == __sbyte16.TestData_LHS[1].x10;
            result &= selected.x11 == __sbyte16.TestData_LHS[1].x11;
            result &= selected.x12 == __sbyte16.TestData_LHS[1].x12;
            result &= selected.x13 == __sbyte16.TestData_RHS[1].x13;
            result &= selected.x14 == __sbyte16.TestData_LHS[1].x14;
            result &= selected.x15 == __sbyte16.TestData_LHS[1].x15;

            selected = maxmath.select(__sbyte16.TestData_LHS[2], __sbyte16.TestData_RHS[2], 0b0111_1011_0010_1001);
            result &= selected.x0  == __sbyte16.TestData_RHS[2].x0;
            result &= selected.x1  == __sbyte16.TestData_LHS[2].x1; 
            result &= selected.x2  == __sbyte16.TestData_LHS[2].x2;
            result &= selected.x3  == __sbyte16.TestData_RHS[2].x3;
            result &= selected.x4  == __sbyte16.TestData_LHS[2].x4;
            result &= selected.x5  == __sbyte16.TestData_RHS[2].x5;
            result &= selected.x6  == __sbyte16.TestData_LHS[2].x6;
            result &= selected.x7  == __sbyte16.TestData_LHS[2].x7;
            result &= selected.x8  == __sbyte16.TestData_RHS[2].x8;
            result &= selected.x9  == __sbyte16.TestData_RHS[2].x9;
            result &= selected.x10 == __sbyte16.TestData_LHS[2].x10;
            result &= selected.x11 == __sbyte16.TestData_RHS[2].x11;
            result &= selected.x12 == __sbyte16.TestData_RHS[2].x12;
            result &= selected.x13 == __sbyte16.TestData_RHS[2].x13;
            result &= selected.x14 == __sbyte16.TestData_RHS[2].x14;
            result &= selected.x15 == __sbyte16.TestData_LHS[2].x15;

            selected = maxmath.select(__sbyte16.TestData_LHS[3], __sbyte16.TestData_RHS[3], 0b0010_1110_1111_1011);
            result &= selected.x0  == __sbyte16.TestData_RHS[3].x0;
            result &= selected.x1  == __sbyte16.TestData_RHS[3].x1;
            result &= selected.x2  == __sbyte16.TestData_LHS[3].x2;
            result &= selected.x3  == __sbyte16.TestData_RHS[3].x3;
            result &= selected.x4  == __sbyte16.TestData_RHS[3].x4;
            result &= selected.x5  == __sbyte16.TestData_RHS[3].x5;
            result &= selected.x6  == __sbyte16.TestData_RHS[3].x6;
            result &= selected.x7  == __sbyte16.TestData_RHS[3].x7;
            result &= selected.x8  == __sbyte16.TestData_LHS[3].x8;
            result &= selected.x9  == __sbyte16.TestData_RHS[3].x9;
            result &= selected.x10 == __sbyte16.TestData_RHS[3].x10;
            result &= selected.x11 == __sbyte16.TestData_RHS[3].x11;
            result &= selected.x12 == __sbyte16.TestData_LHS[3].x12;
            result &= selected.x13 == __sbyte16.TestData_RHS[3].x13;
            result &= selected.x14 == __sbyte16.TestData_LHS[3].x14;
            result &= selected.x15 == __sbyte16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void byte32_via_int()
        {
            bool result = true;


            byte32 selected;

            selected = maxmath.select(__byte32.TestData_LHS[0], __byte32.TestData_RHS[0], unchecked((int)0b0101_0001_1011_0100_1010_1010_1011_1011u));
            result &= selected.x0  == __byte32.TestData_RHS[0].x0; 
            result &= selected.x1  == __byte32.TestData_RHS[0].x1;
            result &= selected.x2  == __byte32.TestData_LHS[0].x2;
            result &= selected.x3  == __byte32.TestData_RHS[0].x3;
            result &= selected.x4  == __byte32.TestData_RHS[0].x4;
            result &= selected.x5  == __byte32.TestData_RHS[0].x5;
            result &= selected.x6  == __byte32.TestData_LHS[0].x6;
            result &= selected.x7  == __byte32.TestData_RHS[0].x7;
            result &= selected.x8  == __byte32.TestData_LHS[0].x8;
            result &= selected.x9  == __byte32.TestData_RHS[0].x9;
            result &= selected.x10 == __byte32.TestData_LHS[0].x10;
            result &= selected.x11 == __byte32.TestData_RHS[0].x11;
            result &= selected.x12 == __byte32.TestData_LHS[0].x12;
            result &= selected.x13 == __byte32.TestData_RHS[0].x13;
            result &= selected.x14 == __byte32.TestData_LHS[0].x14;
            result &= selected.x15 == __byte32.TestData_RHS[0].x15;
            result &= selected.x16 == __byte32.TestData_LHS[0].x16;
            result &= selected.x17 == __byte32.TestData_LHS[0].x17;
            result &= selected.x18 == __byte32.TestData_RHS[0].x18;
            result &= selected.x19 == __byte32.TestData_LHS[0].x19;
            result &= selected.x20 == __byte32.TestData_RHS[0].x20;
            result &= selected.x21 == __byte32.TestData_RHS[0].x21;
            result &= selected.x22 == __byte32.TestData_LHS[0].x22;
            result &= selected.x23 == __byte32.TestData_RHS[0].x23;
            result &= selected.x24 == __byte32.TestData_RHS[0].x24;
            result &= selected.x25 == __byte32.TestData_LHS[0].x25;
            result &= selected.x26 == __byte32.TestData_LHS[0].x26;
            result &= selected.x27 == __byte32.TestData_LHS[0].x27;
            result &= selected.x28 == __byte32.TestData_RHS[0].x28;
            result &= selected.x29 == __byte32.TestData_LHS[0].x29;
            result &= selected.x30 == __byte32.TestData_RHS[0].x30;
            result &= selected.x31 == __byte32.TestData_LHS[0].x31;

            selected = maxmath.select(__byte32.TestData_LHS[1], __byte32.TestData_RHS[1], unchecked((int)0b1101_1110_0100_1010_0010_0011_1110_0011u));
            result &= selected.x0  == __byte32.TestData_RHS[1].x0;
            result &= selected.x1  == __byte32.TestData_RHS[1].x1;
            result &= selected.x2  == __byte32.TestData_LHS[1].x2;
            result &= selected.x3  == __byte32.TestData_LHS[1].x3;
            result &= selected.x4  == __byte32.TestData_LHS[1].x4;
            result &= selected.x5  == __byte32.TestData_RHS[1].x5;
            result &= selected.x6  == __byte32.TestData_RHS[1].x6;
            result &= selected.x7  == __byte32.TestData_RHS[1].x7;
            result &= selected.x8  == __byte32.TestData_RHS[1].x8;
            result &= selected.x9  == __byte32.TestData_RHS[1].x9;
            result &= selected.x10 == __byte32.TestData_LHS[1].x10;
            result &= selected.x11 == __byte32.TestData_LHS[1].x11;
            result &= selected.x12 == __byte32.TestData_LHS[1].x12;
            result &= selected.x13 == __byte32.TestData_RHS[1].x13;
            result &= selected.x14 == __byte32.TestData_LHS[1].x14;
            result &= selected.x15 == __byte32.TestData_LHS[1].x15;
            result &= selected.x16 == __byte32.TestData_LHS[1].x16;
            result &= selected.x17 == __byte32.TestData_RHS[1].x17;
            result &= selected.x18 == __byte32.TestData_LHS[1].x18;
            result &= selected.x19 == __byte32.TestData_RHS[1].x19;
            result &= selected.x20 == __byte32.TestData_LHS[1].x20;
            result &= selected.x21 == __byte32.TestData_LHS[1].x21;
            result &= selected.x22 == __byte32.TestData_RHS[1].x22;
            result &= selected.x23 == __byte32.TestData_LHS[1].x23;
            result &= selected.x24 == __byte32.TestData_LHS[1].x24;
            result &= selected.x25 == __byte32.TestData_RHS[1].x25;
            result &= selected.x26 == __byte32.TestData_RHS[1].x26;
            result &= selected.x27 == __byte32.TestData_RHS[1].x27;
            result &= selected.x28 == __byte32.TestData_RHS[1].x28;
            result &= selected.x29 == __byte32.TestData_LHS[1].x29;
            result &= selected.x30 == __byte32.TestData_RHS[1].x30;
            result &= selected.x31 == __byte32.TestData_RHS[1].x31;

            selected = maxmath.select(__byte32.TestData_LHS[2], __byte32.TestData_RHS[2], 0b0001_1011_1010_1101_0111_1011_0010_1001);
            result &= selected.x0  == __byte32.TestData_RHS[2].x0;
            result &= selected.x1  == __byte32.TestData_LHS[2].x1; 
            result &= selected.x2  == __byte32.TestData_LHS[2].x2;
            result &= selected.x3  == __byte32.TestData_RHS[2].x3;
            result &= selected.x4  == __byte32.TestData_LHS[2].x4;
            result &= selected.x5  == __byte32.TestData_RHS[2].x5;
            result &= selected.x6  == __byte32.TestData_LHS[2].x6;
            result &= selected.x7  == __byte32.TestData_LHS[2].x7;
            result &= selected.x8  == __byte32.TestData_RHS[2].x8;
            result &= selected.x9  == __byte32.TestData_RHS[2].x9;
            result &= selected.x10 == __byte32.TestData_LHS[2].x10;
            result &= selected.x11 == __byte32.TestData_RHS[2].x11;
            result &= selected.x12 == __byte32.TestData_RHS[2].x12;
            result &= selected.x13 == __byte32.TestData_RHS[2].x13;
            result &= selected.x14 == __byte32.TestData_RHS[2].x14;
            result &= selected.x15 == __byte32.TestData_LHS[2].x15;
            result &= selected.x16 == __byte32.TestData_RHS[2].x16; 
            result &= selected.x17 == __byte32.TestData_LHS[2].x17;
            result &= selected.x18 == __byte32.TestData_RHS[2].x18;
            result &= selected.x19 == __byte32.TestData_RHS[2].x19;
            result &= selected.x20 == __byte32.TestData_LHS[2].x20;
            result &= selected.x21 == __byte32.TestData_RHS[2].x21;
            result &= selected.x22 == __byte32.TestData_LHS[2].x22;
            result &= selected.x23 == __byte32.TestData_RHS[2].x23;
            result &= selected.x24 == __byte32.TestData_RHS[2].x24;
            result &= selected.x25 == __byte32.TestData_RHS[2].x25;
            result &= selected.x26 == __byte32.TestData_LHS[2].x26;
            result &= selected.x27 == __byte32.TestData_RHS[2].x27;
            result &= selected.x28 == __byte32.TestData_RHS[2].x28;
            result &= selected.x29 == __byte32.TestData_LHS[2].x29;
            result &= selected.x30 == __byte32.TestData_LHS[2].x30;
            result &= selected.x31 == __byte32.TestData_LHS[2].x31;

            selected = maxmath.select(__byte32.TestData_LHS[3], __byte32.TestData_RHS[3], 0b0111_1001_1001_0101_0010_1110_1111_1011);
            result &= selected.x0  == __byte32.TestData_RHS[3].x0;
            result &= selected.x1  == __byte32.TestData_RHS[3].x1;
            result &= selected.x2  == __byte32.TestData_LHS[3].x2;
            result &= selected.x3  == __byte32.TestData_RHS[3].x3;
            result &= selected.x4  == __byte32.TestData_RHS[3].x4;
            result &= selected.x5  == __byte32.TestData_RHS[3].x5;
            result &= selected.x6  == __byte32.TestData_RHS[3].x6;
            result &= selected.x7  == __byte32.TestData_RHS[3].x7;
            result &= selected.x8  == __byte32.TestData_LHS[3].x8;
            result &= selected.x9  == __byte32.TestData_RHS[3].x9;
            result &= selected.x10 == __byte32.TestData_RHS[3].x10;
            result &= selected.x11 == __byte32.TestData_RHS[3].x11;
            result &= selected.x12 == __byte32.TestData_LHS[3].x12;
            result &= selected.x13 == __byte32.TestData_RHS[3].x13;
            result &= selected.x14 == __byte32.TestData_LHS[3].x14;
            result &= selected.x15 == __byte32.TestData_LHS[3].x15;
            result &= selected.x16 == __byte32.TestData_RHS[3].x16;
            result &= selected.x17 == __byte32.TestData_LHS[3].x17;
            result &= selected.x18 == __byte32.TestData_RHS[3].x18;
            result &= selected.x19 == __byte32.TestData_LHS[3].x19;
            result &= selected.x20 == __byte32.TestData_RHS[3].x20;
            result &= selected.x21 == __byte32.TestData_LHS[3].x21;
            result &= selected.x22 == __byte32.TestData_LHS[3].x22;
            result &= selected.x23 == __byte32.TestData_RHS[3].x23;
            result &= selected.x24 == __byte32.TestData_RHS[3].x24;
            result &= selected.x25 == __byte32.TestData_LHS[3].x25;
            result &= selected.x26 == __byte32.TestData_LHS[3].x26;
            result &= selected.x27 == __byte32.TestData_RHS[3].x27;
            result &= selected.x28 == __byte32.TestData_RHS[3].x28;
            result &= selected.x29 == __byte32.TestData_RHS[3].x29;
            result &= selected.x30 == __byte32.TestData_RHS[3].x30;
            result &= selected.x31 == __byte32.TestData_LHS[3].x31;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void sbyte32_via_int()
        {
            bool result = true;


            sbyte32 selected;

            selected = maxmath.select(__sbyte32.TestData_LHS[0], __sbyte32.TestData_RHS[0], unchecked((int)0b0101_0001_1011_0100_1010_1010_1011_1011u));
            result &= selected.x0  == __sbyte32.TestData_RHS[0].x0;
            result &= selected.x1  == __sbyte32.TestData_RHS[0].x1;
            result &= selected.x2  == __sbyte32.TestData_LHS[0].x2;
            result &= selected.x3  == __sbyte32.TestData_RHS[0].x3;
            result &= selected.x4  == __sbyte32.TestData_RHS[0].x4;
            result &= selected.x5  == __sbyte32.TestData_RHS[0].x5;
            result &= selected.x6  == __sbyte32.TestData_LHS[0].x6;
            result &= selected.x7  == __sbyte32.TestData_RHS[0].x7;
            result &= selected.x8  == __sbyte32.TestData_LHS[0].x8;
            result &= selected.x9  == __sbyte32.TestData_RHS[0].x9;
            result &= selected.x10 == __sbyte32.TestData_LHS[0].x10;
            result &= selected.x11 == __sbyte32.TestData_RHS[0].x11;
            result &= selected.x12 == __sbyte32.TestData_LHS[0].x12;
            result &= selected.x13 == __sbyte32.TestData_RHS[0].x13;
            result &= selected.x14 == __sbyte32.TestData_LHS[0].x14;
            result &= selected.x15 == __sbyte32.TestData_RHS[0].x15;
            result &= selected.x16 == __sbyte32.TestData_LHS[0].x16;
            result &= selected.x17 == __sbyte32.TestData_LHS[0].x17;
            result &= selected.x18 == __sbyte32.TestData_RHS[0].x18;
            result &= selected.x19 == __sbyte32.TestData_LHS[0].x19;
            result &= selected.x20 == __sbyte32.TestData_RHS[0].x20;
            result &= selected.x21 == __sbyte32.TestData_RHS[0].x21;
            result &= selected.x22 == __sbyte32.TestData_LHS[0].x22;
            result &= selected.x23 == __sbyte32.TestData_RHS[0].x23;
            result &= selected.x24 == __sbyte32.TestData_RHS[0].x24;
            result &= selected.x25 == __sbyte32.TestData_LHS[0].x25;
            result &= selected.x26 == __sbyte32.TestData_LHS[0].x26;
            result &= selected.x27 == __sbyte32.TestData_LHS[0].x27;
            result &= selected.x28 == __sbyte32.TestData_RHS[0].x28;
            result &= selected.x29 == __sbyte32.TestData_LHS[0].x29;
            result &= selected.x30 == __sbyte32.TestData_RHS[0].x30;
            result &= selected.x31 == __sbyte32.TestData_LHS[0].x31;

            selected = maxmath.select(__sbyte32.TestData_LHS[1], __sbyte32.TestData_RHS[1], unchecked((int)0b1101_1110_0100_1010_0010_0011_1110_0011u));
            result &= selected.x0  == __sbyte32.TestData_RHS[1].x0; 
            result &= selected.x1  == __sbyte32.TestData_RHS[1].x1;
            result &= selected.x2  == __sbyte32.TestData_LHS[1].x2;
            result &= selected.x3  == __sbyte32.TestData_LHS[1].x3;
            result &= selected.x4  == __sbyte32.TestData_LHS[1].x4;
            result &= selected.x5  == __sbyte32.TestData_RHS[1].x5;
            result &= selected.x6  == __sbyte32.TestData_RHS[1].x6;
            result &= selected.x7  == __sbyte32.TestData_RHS[1].x7;
            result &= selected.x8  == __sbyte32.TestData_RHS[1].x8;
            result &= selected.x9  == __sbyte32.TestData_RHS[1].x9;
            result &= selected.x10 == __sbyte32.TestData_LHS[1].x10;
            result &= selected.x11 == __sbyte32.TestData_LHS[1].x11;
            result &= selected.x12 == __sbyte32.TestData_LHS[1].x12;
            result &= selected.x13 == __sbyte32.TestData_RHS[1].x13;
            result &= selected.x14 == __sbyte32.TestData_LHS[1].x14;
            result &= selected.x15 == __sbyte32.TestData_LHS[1].x15;
            result &= selected.x16 == __sbyte32.TestData_LHS[1].x16;
            result &= selected.x17 == __sbyte32.TestData_RHS[1].x17;
            result &= selected.x18 == __sbyte32.TestData_LHS[1].x18;
            result &= selected.x19 == __sbyte32.TestData_RHS[1].x19;
            result &= selected.x20 == __sbyte32.TestData_LHS[1].x20;
            result &= selected.x21 == __sbyte32.TestData_LHS[1].x21; 
            result &= selected.x22 == __sbyte32.TestData_RHS[1].x22;
            result &= selected.x23 == __sbyte32.TestData_LHS[1].x23;
            result &= selected.x24 == __sbyte32.TestData_LHS[1].x24;
            result &= selected.x25 == __sbyte32.TestData_RHS[1].x25;
            result &= selected.x26 == __sbyte32.TestData_RHS[1].x26;
            result &= selected.x27 == __sbyte32.TestData_RHS[1].x27;
            result &= selected.x28 == __sbyte32.TestData_RHS[1].x28;
            result &= selected.x29 == __sbyte32.TestData_LHS[1].x29;
            result &= selected.x30 == __sbyte32.TestData_RHS[1].x30;
            result &= selected.x31 == __sbyte32.TestData_RHS[1].x31;

            selected = maxmath.select(__sbyte32.TestData_LHS[2], __sbyte32.TestData_RHS[2], 0b0001_1011_1010_1101_0111_1011_0010_1001);
            result &= selected.x0  == __sbyte32.TestData_RHS[2].x0;
            result &= selected.x1  == __sbyte32.TestData_LHS[2].x1; 
            result &= selected.x2  == __sbyte32.TestData_LHS[2].x2;
            result &= selected.x3  == __sbyte32.TestData_RHS[2].x3;
            result &= selected.x4  == __sbyte32.TestData_LHS[2].x4;
            result &= selected.x5  == __sbyte32.TestData_RHS[2].x5;
            result &= selected.x6  == __sbyte32.TestData_LHS[2].x6;
            result &= selected.x7  == __sbyte32.TestData_LHS[2].x7;
            result &= selected.x8  == __sbyte32.TestData_RHS[2].x8;
            result &= selected.x9  == __sbyte32.TestData_RHS[2].x9;
            result &= selected.x10 == __sbyte32.TestData_LHS[2].x10;
            result &= selected.x11 == __sbyte32.TestData_RHS[2].x11;
            result &= selected.x12 == __sbyte32.TestData_RHS[2].x12;
            result &= selected.x13 == __sbyte32.TestData_RHS[2].x13;
            result &= selected.x14 == __sbyte32.TestData_RHS[2].x14;
            result &= selected.x15 == __sbyte32.TestData_LHS[2].x15;
            result &= selected.x16 == __sbyte32.TestData_RHS[2].x16;
            result &= selected.x17 == __sbyte32.TestData_LHS[2].x17;
            result &= selected.x18 == __sbyte32.TestData_RHS[2].x18;
            result &= selected.x19 == __sbyte32.TestData_RHS[2].x19;
            result &= selected.x20 == __sbyte32.TestData_LHS[2].x20;
            result &= selected.x21 == __sbyte32.TestData_RHS[2].x21;
            result &= selected.x22 == __sbyte32.TestData_LHS[2].x22;
            result &= selected.x23 == __sbyte32.TestData_RHS[2].x23;
            result &= selected.x24 == __sbyte32.TestData_RHS[2].x24;
            result &= selected.x25 == __sbyte32.TestData_RHS[2].x25;
            result &= selected.x26 == __sbyte32.TestData_LHS[2].x26;
            result &= selected.x27 == __sbyte32.TestData_RHS[2].x27;
            result &= selected.x28 == __sbyte32.TestData_RHS[2].x28;
            result &= selected.x29 == __sbyte32.TestData_LHS[2].x29;
            result &= selected.x30 == __sbyte32.TestData_LHS[2].x30;
            result &= selected.x31 == __sbyte32.TestData_LHS[2].x31;

            selected = maxmath.select(__sbyte32.TestData_LHS[3], __sbyte32.TestData_RHS[3], 0b0111_1001_1001_0101_0010_1110_1111_1011);
            result &= selected.x0  == __sbyte32.TestData_RHS[3].x0;
            result &= selected.x1  == __sbyte32.TestData_RHS[3].x1;
            result &= selected.x2  == __sbyte32.TestData_LHS[3].x2;
            result &= selected.x3  == __sbyte32.TestData_RHS[3].x3;
            result &= selected.x4  == __sbyte32.TestData_RHS[3].x4;
            result &= selected.x5  == __sbyte32.TestData_RHS[3].x5;
            result &= selected.x6  == __sbyte32.TestData_RHS[3].x6;
            result &= selected.x7  == __sbyte32.TestData_RHS[3].x7;
            result &= selected.x8  == __sbyte32.TestData_LHS[3].x8;
            result &= selected.x9  == __sbyte32.TestData_RHS[3].x9;
            result &= selected.x10 == __sbyte32.TestData_RHS[3].x10;
            result &= selected.x11 == __sbyte32.TestData_RHS[3].x11;
            result &= selected.x12 == __sbyte32.TestData_LHS[3].x12;
            result &= selected.x13 == __sbyte32.TestData_RHS[3].x13;
            result &= selected.x14 == __sbyte32.TestData_LHS[3].x14;
            result &= selected.x15 == __sbyte32.TestData_LHS[3].x15;
            result &= selected.x16 == __sbyte32.TestData_RHS[3].x16;
            result &= selected.x17 == __sbyte32.TestData_LHS[3].x17;
            result &= selected.x18 == __sbyte32.TestData_RHS[3].x18;
            result &= selected.x19 == __sbyte32.TestData_LHS[3].x19;
            result &= selected.x20 == __sbyte32.TestData_RHS[3].x20;
            result &= selected.x21 == __sbyte32.TestData_LHS[3].x21;
            result &= selected.x22 == __sbyte32.TestData_LHS[3].x22;
            result &= selected.x23 == __sbyte32.TestData_RHS[3].x23;
            result &= selected.x24 == __sbyte32.TestData_RHS[3].x24;
            result &= selected.x25 == __sbyte32.TestData_LHS[3].x25;
            result &= selected.x26 == __sbyte32.TestData_LHS[3].x26;
            result &= selected.x27 == __sbyte32.TestData_RHS[3].x27;
            result &= selected.x28 == __sbyte32.TestData_RHS[3].x28;
            result &= selected.x29 == __sbyte32.TestData_RHS[3].x29;
            result &= selected.x30 == __sbyte32.TestData_RHS[3].x30;
            result &= selected.x31 == __sbyte32.TestData_LHS[3].x31;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort2_via_int()
        {
            bool result = true;


            ushort2 selected;

            selected = maxmath.select(__ushort2.TestData_LHS[0], __ushort2.TestData_RHS[0], 0b10);
            result &= selected.x == __ushort2.TestData_LHS[0].x;
            result &= selected.y == __ushort2.TestData_RHS[0].y;

            selected = maxmath.select(__ushort2.TestData_LHS[1], __ushort2.TestData_RHS[1], 0b11);
            result &= selected.x == __ushort2.TestData_RHS[1].x;
            result &= selected.y == __ushort2.TestData_RHS[1].y;

            selected = maxmath.select(__ushort2.TestData_LHS[2], __ushort2.TestData_RHS[2], 0b00);
            result &= selected.x == __ushort2.TestData_LHS[2].x;
            result &= selected.y == __ushort2.TestData_LHS[2].y;

            selected = maxmath.select(__ushort2.TestData_LHS[3], __ushort2.TestData_RHS[3], 0b01);
            result &= selected.x == __ushort2.TestData_RHS[3].x;
            result &= selected.y == __ushort2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short2_via_int()
        {
            bool result = true;


            short2 selected;

            selected = maxmath.select(__short2.TestData_LHS[0], __short2.TestData_RHS[0], 0b10);
            result &= selected.x == __short2.TestData_LHS[0].x;
            result &= selected.y == __short2.TestData_RHS[0].y;

            selected = maxmath.select(__short2.TestData_LHS[1], __short2.TestData_RHS[1], 0b11);
            result &= selected.x == __short2.TestData_RHS[1].x;
            result &= selected.y == __short2.TestData_RHS[1].y;

            selected = maxmath.select(__short2.TestData_LHS[2], __short2.TestData_RHS[2], 0b00);
            result &= selected.x == __short2.TestData_LHS[2].x;
            result &= selected.y == __short2.TestData_LHS[2].y;

            selected = maxmath.select(__short2.TestData_LHS[3], __short2.TestData_RHS[3], 0b01);
            result &= selected.x == __short2.TestData_RHS[3].x;
            result &= selected.y == __short2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort3_via_int()
        {
            bool result = true;


            ushort3 selected;

            selected = maxmath.select(__ushort3.TestData_LHS[0], __ushort3.TestData_RHS[0], 0b110);
            result &= selected.x == __ushort3.TestData_LHS[0].x;
            result &= selected.y == __ushort3.TestData_RHS[0].y;
            result &= selected.z == __ushort3.TestData_RHS[0].z;

            selected = maxmath.select(__ushort3.TestData_LHS[1], __ushort3.TestData_RHS[1], 0b011);
            result &= selected.x == __ushort3.TestData_RHS[1].x;
            result &= selected.y == __ushort3.TestData_RHS[1].y;
            result &= selected.z == __ushort3.TestData_LHS[1].z;

            selected = maxmath.select(__ushort3.TestData_LHS[2], __ushort3.TestData_RHS[2], 0b100);
            result &= selected.x == __ushort3.TestData_LHS[2].x;
            result &= selected.y == __ushort3.TestData_LHS[2].y;
            result &= selected.z == __ushort3.TestData_RHS[2].z;

            selected = maxmath.select(__ushort3.TestData_LHS[3], __ushort3.TestData_RHS[3], 0b101);
            result &= selected.x == __ushort3.TestData_RHS[3].x;
            result &= selected.y == __ushort3.TestData_LHS[3].y;
            result &= selected.z == __ushort3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short3_via_int()
        {
            bool result = true;


            short3 selected;

            selected = maxmath.select(__short3.TestData_LHS[0], __short3.TestData_RHS[0], 0b110);
            result &= selected.x == __short3.TestData_LHS[0].x;
            result &= selected.y == __short3.TestData_RHS[0].y;
            result &= selected.z == __short3.TestData_RHS[0].z;

            selected = maxmath.select(__short3.TestData_LHS[1], __short3.TestData_RHS[1], 0b011);
            result &= selected.x == __short3.TestData_RHS[1].x;
            result &= selected.y == __short3.TestData_RHS[1].y;
            result &= selected.z == __short3.TestData_LHS[1].z;

            selected = maxmath.select(__short3.TestData_LHS[2], __short3.TestData_RHS[2], 0b100);
            result &= selected.x == __short3.TestData_LHS[2].x;
            result &= selected.y == __short3.TestData_LHS[2].y;
            result &= selected.z == __short3.TestData_RHS[2].z;

            selected = maxmath.select(__short3.TestData_LHS[3], __short3.TestData_RHS[3], 0b101);
            result &= selected.x == __short3.TestData_RHS[3].x;
            result &= selected.y == __short3.TestData_LHS[3].y;
            result &= selected.z == __short3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort4_via_int()
        {
            bool result = true;


            ushort4 selected;

            selected = maxmath.select(__ushort4.TestData_LHS[0], __ushort4.TestData_RHS[0], 0b1110);
            result &= selected.x == __ushort4.TestData_LHS[0].x;
            result &= selected.y == __ushort4.TestData_RHS[0].y;
            result &= selected.z == __ushort4.TestData_RHS[0].z;
            result &= selected.w == __ushort4.TestData_RHS[0].w;

            selected = maxmath.select(__ushort4.TestData_LHS[1], __ushort4.TestData_RHS[1], 0b0111);
            result &= selected.x == __ushort4.TestData_RHS[1].x;
            result &= selected.y == __ushort4.TestData_RHS[1].y;
            result &= selected.z == __ushort4.TestData_RHS[1].z;
            result &= selected.w == __ushort4.TestData_LHS[1].w;

            selected = maxmath.select(__ushort4.TestData_LHS[2], __ushort4.TestData_RHS[2], 0b0110);
            result &= selected.x == __ushort4.TestData_LHS[2].x;
            result &= selected.y == __ushort4.TestData_RHS[2].y;
            result &= selected.z == __ushort4.TestData_RHS[2].z;
            result &= selected.w == __ushort4.TestData_LHS[2].w;

            selected = maxmath.select(__ushort4.TestData_LHS[3], __ushort4.TestData_RHS[3], 0b1101);
            result &= selected.x == __ushort4.TestData_RHS[3].x;
            result &= selected.y == __ushort4.TestData_LHS[3].y;
            result &= selected.z == __ushort4.TestData_RHS[3].z;
            result &= selected.w == __ushort4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short4_via_int()
        {
            bool result = true;


            short4 selected;

            selected = maxmath.select(__short4.TestData_LHS[0], __short4.TestData_RHS[0], 0b1110);
            result &= selected.x == __short4.TestData_LHS[0].x;
            result &= selected.y == __short4.TestData_RHS[0].y;
            result &= selected.z == __short4.TestData_RHS[0].z;
            result &= selected.w == __short4.TestData_RHS[0].w;

            selected = maxmath.select(__short4.TestData_LHS[1], __short4.TestData_RHS[1], 0b0111);
            result &= selected.x == __short4.TestData_RHS[1].x;
            result &= selected.y == __short4.TestData_RHS[1].y;
            result &= selected.z == __short4.TestData_RHS[1].z;
            result &= selected.w == __short4.TestData_LHS[1].w;

            selected = maxmath.select(__short4.TestData_LHS[2], __short4.TestData_RHS[2], 0b0110);
            result &= selected.x == __short4.TestData_LHS[2].x;
            result &= selected.y == __short4.TestData_RHS[2].y;
            result &= selected.z == __short4.TestData_RHS[2].z;
            result &= selected.w == __short4.TestData_LHS[2].w;

            selected = maxmath.select(__short4.TestData_LHS[3], __short4.TestData_RHS[3], 0b1101);
            result &= selected.x == __short4.TestData_RHS[3].x;
            result &= selected.y == __short4.TestData_LHS[3].y;
            result &= selected.z == __short4.TestData_RHS[3].z;
            result &= selected.w == __short4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort8_via_int()
        {
            bool result = true;


            ushort8 selected;

            selected = maxmath.select(__ushort8.TestData_LHS[0], __ushort8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0  == __ushort8.TestData_RHS[0].x0; 
            result &= selected.x1  == __ushort8.TestData_RHS[0].x1;
            result &= selected.x2  == __ushort8.TestData_LHS[0].x2;
            result &= selected.x3  == __ushort8.TestData_RHS[0].x3;
            result &= selected.x4  == __ushort8.TestData_RHS[0].x4;
            result &= selected.x5  == __ushort8.TestData_RHS[0].x5;
            result &= selected.x6  == __ushort8.TestData_LHS[0].x6;
            result &= selected.x7  == __ushort8.TestData_RHS[0].x7;

            selected = maxmath.select(__ushort8.TestData_LHS[1], __ushort8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0  == __ushort8.TestData_RHS[1].x0;
            result &= selected.x1  == __ushort8.TestData_RHS[1].x1;
            result &= selected.x2  == __ushort8.TestData_LHS[1].x2;
            result &= selected.x3  == __ushort8.TestData_LHS[1].x3;
            result &= selected.x4  == __ushort8.TestData_LHS[1].x4;
            result &= selected.x5  == __ushort8.TestData_RHS[1].x5;
            result &= selected.x6  == __ushort8.TestData_RHS[1].x6;
            result &= selected.x7  == __ushort8.TestData_RHS[1].x7;

            selected = maxmath.select(__ushort8.TestData_LHS[2], __ushort8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __ushort8.TestData_RHS[2].x0;
            result &= selected.x1  == __ushort8.TestData_LHS[2].x1; 
            result &= selected.x2  == __ushort8.TestData_LHS[2].x2;
            result &= selected.x3  == __ushort8.TestData_RHS[2].x3;
            result &= selected.x4  == __ushort8.TestData_LHS[2].x4;
            result &= selected.x5  == __ushort8.TestData_RHS[2].x5;
            result &= selected.x6  == __ushort8.TestData_LHS[2].x6;
            result &= selected.x7  == __ushort8.TestData_LHS[2].x7;

            selected = maxmath.select(__ushort8.TestData_LHS[3], __ushort8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __ushort8.TestData_RHS[3].x0;
            result &= selected.x1  == __ushort8.TestData_RHS[3].x1;
            result &= selected.x2  == __ushort8.TestData_LHS[3].x2;
            result &= selected.x3  == __ushort8.TestData_RHS[3].x3;
            result &= selected.x4  == __ushort8.TestData_RHS[3].x4;
            result &= selected.x5  == __ushort8.TestData_RHS[3].x5;
            result &= selected.x6  == __ushort8.TestData_RHS[3].x6;
            result &= selected.x7  == __ushort8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short8_via_int()
        {
            bool result = true;


            short8 selected;

            selected = maxmath.select(__short8.TestData_LHS[0], __short8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0  == __short8.TestData_RHS[0].x0; 
            result &= selected.x1  == __short8.TestData_RHS[0].x1;
            result &= selected.x2  == __short8.TestData_LHS[0].x2;
            result &= selected.x3  == __short8.TestData_RHS[0].x3;
            result &= selected.x4  == __short8.TestData_RHS[0].x4;
            result &= selected.x5  == __short8.TestData_RHS[0].x5;
            result &= selected.x6  == __short8.TestData_LHS[0].x6;
            result &= selected.x7  == __short8.TestData_RHS[0].x7;

            selected = maxmath.select(__short8.TestData_LHS[1], __short8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0  == __short8.TestData_RHS[1].x0;
            result &= selected.x1  == __short8.TestData_RHS[1].x1;
            result &= selected.x2  == __short8.TestData_LHS[1].x2;
            result &= selected.x3  == __short8.TestData_LHS[1].x3;
            result &= selected.x4  == __short8.TestData_LHS[1].x4;
            result &= selected.x5  == __short8.TestData_RHS[1].x5;
            result &= selected.x6  == __short8.TestData_RHS[1].x6;
            result &= selected.x7  == __short8.TestData_RHS[1].x7;

            selected = maxmath.select(__short8.TestData_LHS[2], __short8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __short8.TestData_RHS[2].x0;
            result &= selected.x1  == __short8.TestData_LHS[2].x1; 
            result &= selected.x2  == __short8.TestData_LHS[2].x2;
            result &= selected.x3  == __short8.TestData_RHS[2].x3;
            result &= selected.x4  == __short8.TestData_LHS[2].x4;
            result &= selected.x5  == __short8.TestData_RHS[2].x5;
            result &= selected.x6  == __short8.TestData_LHS[2].x6;
            result &= selected.x7  == __short8.TestData_LHS[2].x7;

            selected = maxmath.select(__short8.TestData_LHS[3], __short8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __short8.TestData_RHS[3].x0;
            result &= selected.x1  == __short8.TestData_RHS[3].x1;
            result &= selected.x2  == __short8.TestData_LHS[3].x2;
            result &= selected.x3  == __short8.TestData_RHS[3].x3;
            result &= selected.x4  == __short8.TestData_RHS[3].x4;
            result &= selected.x5  == __short8.TestData_RHS[3].x5;
            result &= selected.x6  == __short8.TestData_RHS[3].x6;
            result &= selected.x7  == __short8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ushort16_via_int()
        {
            bool result = true;


            ushort16 selected;

            selected = maxmath.select(__ushort16.TestData_LHS[0], __ushort16.TestData_RHS[0], unchecked((int)0b1010_1010_1011_1011u));
            result &= selected.x0  == __ushort16.TestData_RHS[0].x0; 
            result &= selected.x1  == __ushort16.TestData_RHS[0].x1;
            result &= selected.x2  == __ushort16.TestData_LHS[0].x2;
            result &= selected.x3  == __ushort16.TestData_RHS[0].x3;
            result &= selected.x4  == __ushort16.TestData_RHS[0].x4;
            result &= selected.x5  == __ushort16.TestData_RHS[0].x5;
            result &= selected.x6  == __ushort16.TestData_LHS[0].x6;
            result &= selected.x7  == __ushort16.TestData_RHS[0].x7;
            result &= selected.x8  == __ushort16.TestData_LHS[0].x8;
            result &= selected.x9  == __ushort16.TestData_RHS[0].x9;
            result &= selected.x10 == __ushort16.TestData_LHS[0].x10;
            result &= selected.x11 == __ushort16.TestData_RHS[0].x11;
            result &= selected.x12 == __ushort16.TestData_LHS[0].x12;
            result &= selected.x13 == __ushort16.TestData_RHS[0].x13;
            result &= selected.x14 == __ushort16.TestData_LHS[0].x14;
            result &= selected.x15 == __ushort16.TestData_RHS[0].x15;

            selected = maxmath.select(__ushort16.TestData_LHS[1], __ushort16.TestData_RHS[1], unchecked((int)0b0010_0011_1110_0011u));
            result &= selected.x0  == __ushort16.TestData_RHS[1].x0;
            result &= selected.x1  == __ushort16.TestData_RHS[1].x1;
            result &= selected.x2  == __ushort16.TestData_LHS[1].x2;
            result &= selected.x3  == __ushort16.TestData_LHS[1].x3;
            result &= selected.x4  == __ushort16.TestData_LHS[1].x4;
            result &= selected.x5  == __ushort16.TestData_RHS[1].x5;
            result &= selected.x6  == __ushort16.TestData_RHS[1].x6;
            result &= selected.x7  == __ushort16.TestData_RHS[1].x7;
            result &= selected.x8  == __ushort16.TestData_RHS[1].x8;
            result &= selected.x9  == __ushort16.TestData_RHS[1].x9;
            result &= selected.x10 == __ushort16.TestData_LHS[1].x10;
            result &= selected.x11 == __ushort16.TestData_LHS[1].x11;
            result &= selected.x12 == __ushort16.TestData_LHS[1].x12;
            result &= selected.x13 == __ushort16.TestData_RHS[1].x13;
            result &= selected.x14 == __ushort16.TestData_LHS[1].x14;
            result &= selected.x15 == __ushort16.TestData_LHS[1].x15;

            selected = maxmath.select(__ushort16.TestData_LHS[2], __ushort16.TestData_RHS[2], 0b0111_1011_0010_1001);
            result &= selected.x0  == __ushort16.TestData_RHS[2].x0;
            result &= selected.x1  == __ushort16.TestData_LHS[2].x1; 
            result &= selected.x2  == __ushort16.TestData_LHS[2].x2;
            result &= selected.x3  == __ushort16.TestData_RHS[2].x3;
            result &= selected.x4  == __ushort16.TestData_LHS[2].x4;
            result &= selected.x5  == __ushort16.TestData_RHS[2].x5;
            result &= selected.x6  == __ushort16.TestData_LHS[2].x6;
            result &= selected.x7  == __ushort16.TestData_LHS[2].x7;
            result &= selected.x8  == __ushort16.TestData_RHS[2].x8;
            result &= selected.x9  == __ushort16.TestData_RHS[2].x9;
            result &= selected.x10 == __ushort16.TestData_LHS[2].x10;
            result &= selected.x11 == __ushort16.TestData_RHS[2].x11;
            result &= selected.x12 == __ushort16.TestData_RHS[2].x12;
            result &= selected.x13 == __ushort16.TestData_RHS[2].x13;
            result &= selected.x14 == __ushort16.TestData_RHS[2].x14;
            result &= selected.x15 == __ushort16.TestData_LHS[2].x15;

            selected = maxmath.select(__ushort16.TestData_LHS[3], __ushort16.TestData_RHS[3], 0b0010_1110_1111_1011);
            result &= selected.x0  == __ushort16.TestData_RHS[3].x0;
            result &= selected.x1  == __ushort16.TestData_RHS[3].x1;
            result &= selected.x2  == __ushort16.TestData_LHS[3].x2;
            result &= selected.x3  == __ushort16.TestData_RHS[3].x3;
            result &= selected.x4  == __ushort16.TestData_RHS[3].x4;
            result &= selected.x5  == __ushort16.TestData_RHS[3].x5;
            result &= selected.x6  == __ushort16.TestData_RHS[3].x6;
            result &= selected.x7  == __ushort16.TestData_RHS[3].x7;
            result &= selected.x8  == __ushort16.TestData_LHS[3].x8;
            result &= selected.x9  == __ushort16.TestData_RHS[3].x9;
            result &= selected.x10 == __ushort16.TestData_RHS[3].x10;
            result &= selected.x11 == __ushort16.TestData_RHS[3].x11;
            result &= selected.x12 == __ushort16.TestData_LHS[3].x12;
            result &= selected.x13 == __ushort16.TestData_RHS[3].x13;
            result &= selected.x14 == __ushort16.TestData_LHS[3].x14;
            result &= selected.x15 == __ushort16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void short16_via_int()
        {
            bool result = true;


            short16 selected;

            selected = maxmath.select(__short16.TestData_LHS[0], __short16.TestData_RHS[0], unchecked((int)0b1010_1010_1011_1011u));
            result &= selected.x0  == __short16.TestData_RHS[0].x0; 
            result &= selected.x1  == __short16.TestData_RHS[0].x1;
            result &= selected.x2  == __short16.TestData_LHS[0].x2;
            result &= selected.x3  == __short16.TestData_RHS[0].x3;
            result &= selected.x4  == __short16.TestData_RHS[0].x4;
            result &= selected.x5  == __short16.TestData_RHS[0].x5;
            result &= selected.x6  == __short16.TestData_LHS[0].x6;
            result &= selected.x7  == __short16.TestData_RHS[0].x7;
            result &= selected.x8  == __short16.TestData_LHS[0].x8;
            result &= selected.x9  == __short16.TestData_RHS[0].x9;
            result &= selected.x10 == __short16.TestData_LHS[0].x10;
            result &= selected.x11 == __short16.TestData_RHS[0].x11;
            result &= selected.x12 == __short16.TestData_LHS[0].x12;
            result &= selected.x13 == __short16.TestData_RHS[0].x13;
            result &= selected.x14 == __short16.TestData_LHS[0].x14;
            result &= selected.x15 == __short16.TestData_RHS[0].x15;

            selected = maxmath.select(__short16.TestData_LHS[1], __short16.TestData_RHS[1], unchecked((int)0b0010_0011_1110_0011u));
            result &= selected.x0  == __short16.TestData_RHS[1].x0;
            result &= selected.x1  == __short16.TestData_RHS[1].x1;
            result &= selected.x2  == __short16.TestData_LHS[1].x2;
            result &= selected.x3  == __short16.TestData_LHS[1].x3;
            result &= selected.x4  == __short16.TestData_LHS[1].x4;
            result &= selected.x5  == __short16.TestData_RHS[1].x5;
            result &= selected.x6  == __short16.TestData_RHS[1].x6;
            result &= selected.x7  == __short16.TestData_RHS[1].x7;
            result &= selected.x8  == __short16.TestData_RHS[1].x8;
            result &= selected.x9  == __short16.TestData_RHS[1].x9;
            result &= selected.x10 == __short16.TestData_LHS[1].x10;
            result &= selected.x11 == __short16.TestData_LHS[1].x11;
            result &= selected.x12 == __short16.TestData_LHS[1].x12;
            result &= selected.x13 == __short16.TestData_RHS[1].x13;
            result &= selected.x14 == __short16.TestData_LHS[1].x14;
            result &= selected.x15 == __short16.TestData_LHS[1].x15;

            selected = maxmath.select(__short16.TestData_LHS[2], __short16.TestData_RHS[2], 0b0111_1011_0010_1001);
            result &= selected.x0  == __short16.TestData_RHS[2].x0;
            result &= selected.x1  == __short16.TestData_LHS[2].x1; 
            result &= selected.x2  == __short16.TestData_LHS[2].x2;
            result &= selected.x3  == __short16.TestData_RHS[2].x3;
            result &= selected.x4  == __short16.TestData_LHS[2].x4;
            result &= selected.x5  == __short16.TestData_RHS[2].x5;
            result &= selected.x6  == __short16.TestData_LHS[2].x6;
            result &= selected.x7  == __short16.TestData_LHS[2].x7;
            result &= selected.x8  == __short16.TestData_RHS[2].x8;
            result &= selected.x9  == __short16.TestData_RHS[2].x9;
            result &= selected.x10 == __short16.TestData_LHS[2].x10;
            result &= selected.x11 == __short16.TestData_RHS[2].x11;
            result &= selected.x12 == __short16.TestData_RHS[2].x12;
            result &= selected.x13 == __short16.TestData_RHS[2].x13;
            result &= selected.x14 == __short16.TestData_RHS[2].x14;
            result &= selected.x15 == __short16.TestData_LHS[2].x15;

            selected = maxmath.select(__short16.TestData_LHS[3], __short16.TestData_RHS[3], 0b0010_1110_1111_1011);
            result &= selected.x0  == __short16.TestData_RHS[3].x0;
            result &= selected.x1  == __short16.TestData_RHS[3].x1;
            result &= selected.x2  == __short16.TestData_LHS[3].x2;
            result &= selected.x3  == __short16.TestData_RHS[3].x3;
            result &= selected.x4  == __short16.TestData_RHS[3].x4;
            result &= selected.x5  == __short16.TestData_RHS[3].x5;
            result &= selected.x6  == __short16.TestData_RHS[3].x6;
            result &= selected.x7  == __short16.TestData_RHS[3].x7;
            result &= selected.x8  == __short16.TestData_LHS[3].x8;
            result &= selected.x9  == __short16.TestData_RHS[3].x9;
            result &= selected.x10 == __short16.TestData_RHS[3].x10;
            result &= selected.x11 == __short16.TestData_RHS[3].x11;
            result &= selected.x12 == __short16.TestData_LHS[3].x12;
            result &= selected.x13 == __short16.TestData_RHS[3].x13;
            result &= selected.x14 == __short16.TestData_LHS[3].x14;
            result &= selected.x15 == __short16.TestData_LHS[3].x15;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void uint2_via_int()
        {
            bool result = true;


            uint2 selected;

            selected = maxmath.select(__uint2.TestData_LHS[0], __uint2.TestData_RHS[0], 0b10);
            result &= selected.x == __uint2.TestData_LHS[0].x;
            result &= selected.y == __uint2.TestData_RHS[0].y;

            selected = maxmath.select(__uint2.TestData_LHS[1], __uint2.TestData_RHS[1], 0b11);
            result &= selected.x == __uint2.TestData_RHS[1].x;
            result &= selected.y == __uint2.TestData_RHS[1].y;

            selected = maxmath.select(__uint2.TestData_LHS[2], __uint2.TestData_RHS[2], 0b00);
            result &= selected.x == __uint2.TestData_LHS[2].x;
            result &= selected.y == __uint2.TestData_LHS[2].y;

            selected = maxmath.select(__uint2.TestData_LHS[3], __uint2.TestData_RHS[3], 0b01);
            result &= selected.x == __uint2.TestData_RHS[3].x;
            result &= selected.y == __uint2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int2_via_int()
        {
            bool result = true;


            int2 selected;

            selected = maxmath.select(__int2.TestData_LHS[0], __int2.TestData_RHS[0], 0b10);
            result &= selected.x == __int2.TestData_LHS[0].x;
            result &= selected.y == __int2.TestData_RHS[0].y;

            selected = maxmath.select(__int2.TestData_LHS[1], __int2.TestData_RHS[1], 0b11);
            result &= selected.x == __int2.TestData_RHS[1].x;
            result &= selected.y == __int2.TestData_RHS[1].y;

            selected = maxmath.select(__int2.TestData_LHS[2], __int2.TestData_RHS[2], 0b00);
            result &= selected.x == __int2.TestData_LHS[2].x;
            result &= selected.y == __int2.TestData_LHS[2].y;

            selected = maxmath.select(__int2.TestData_LHS[3], __int2.TestData_RHS[3], 0b01);
            result &= selected.x == __int2.TestData_RHS[3].x;
            result &= selected.y == __int2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void uint3_via_int()
        {
            bool result = true;


            uint3 selected;

            selected = maxmath.select(__uint3.TestData_LHS[0], __uint3.TestData_RHS[0], 0b110);
            result &= selected.x == __uint3.TestData_LHS[0].x;
            result &= selected.y == __uint3.TestData_RHS[0].y;
            result &= selected.z == __uint3.TestData_RHS[0].z;

            selected = maxmath.select(__uint3.TestData_LHS[1], __uint3.TestData_RHS[1], 0b011);
            result &= selected.x == __uint3.TestData_RHS[1].x;
            result &= selected.y == __uint3.TestData_RHS[1].y;
            result &= selected.z == __uint3.TestData_LHS[1].z;

            selected = maxmath.select(__uint3.TestData_LHS[2], __uint3.TestData_RHS[2], 0b100);
            result &= selected.x == __uint3.TestData_LHS[2].x;
            result &= selected.y == __uint3.TestData_LHS[2].y;
            result &= selected.z == __uint3.TestData_RHS[2].z;

            selected = maxmath.select(__uint3.TestData_LHS[3], __uint3.TestData_RHS[3], 0b101);
            result &= selected.x == __uint3.TestData_RHS[3].x;
            result &= selected.y == __uint3.TestData_LHS[3].y;
            result &= selected.z == __uint3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int3_via_int()
        {
            bool result = true;


            int3 selected;

            selected = maxmath.select(__int3.TestData_LHS[0], __int3.TestData_RHS[0], 0b110);
            result &= selected.x == __int3.TestData_LHS[0].x;
            result &= selected.y == __int3.TestData_RHS[0].y;
            result &= selected.z == __int3.TestData_RHS[0].z;

            selected = maxmath.select(__int3.TestData_LHS[1], __int3.TestData_RHS[1], 0b011);
            result &= selected.x == __int3.TestData_RHS[1].x;
            result &= selected.y == __int3.TestData_RHS[1].y;
            result &= selected.z == __int3.TestData_LHS[1].z;

            selected = maxmath.select(__int3.TestData_LHS[2], __int3.TestData_RHS[2], 0b100);
            result &= selected.x == __int3.TestData_LHS[2].x;
            result &= selected.y == __int3.TestData_LHS[2].y;
            result &= selected.z == __int3.TestData_RHS[2].z;

            selected = maxmath.select(__int3.TestData_LHS[3], __int3.TestData_RHS[3], 0b101);
            result &= selected.x == __int3.TestData_RHS[3].x;
            result &= selected.y == __int3.TestData_LHS[3].y;
            result &= selected.z == __int3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void uint4_via_int()
        {
            bool result = true;


            uint4 selected;

            selected = maxmath.select(__uint4.TestData_LHS[0], __uint4.TestData_RHS[0], 0b1110);
            result &= selected.x == __uint4.TestData_LHS[0].x;
            result &= selected.y == __uint4.TestData_RHS[0].y;
            result &= selected.z == __uint4.TestData_RHS[0].z;
            result &= selected.w == __uint4.TestData_RHS[0].w;

            selected = maxmath.select(__uint4.TestData_LHS[1], __uint4.TestData_RHS[1], 0b0111);
            result &= selected.x == __uint4.TestData_RHS[1].x;
            result &= selected.y == __uint4.TestData_RHS[1].y;
            result &= selected.z == __uint4.TestData_RHS[1].z;
            result &= selected.w == __uint4.TestData_LHS[1].w;

            selected = maxmath.select(__uint4.TestData_LHS[2], __uint4.TestData_RHS[2], 0b0110);
            result &= selected.x == __uint4.TestData_LHS[2].x;
            result &= selected.y == __uint4.TestData_RHS[2].y;
            result &= selected.z == __uint4.TestData_RHS[2].z;
            result &= selected.w == __uint4.TestData_LHS[2].w;

            selected = maxmath.select(__uint4.TestData_LHS[3], __uint4.TestData_RHS[3], 0b1101);
            result &= selected.x == __uint4.TestData_RHS[3].x;
            result &= selected.y == __uint4.TestData_LHS[3].y;
            result &= selected.z == __uint4.TestData_RHS[3].z;
            result &= selected.w == __uint4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int4_via_int()
        {
            bool result = true;


            int4 selected;

            selected = maxmath.select(__int4.TestData_LHS[0], __int4.TestData_RHS[0], 0b1110);
            result &= selected.x == __int4.TestData_LHS[0].x;
            result &= selected.y == __int4.TestData_RHS[0].y;
            result &= selected.z == __int4.TestData_RHS[0].z;
            result &= selected.w == __int4.TestData_RHS[0].w;

            selected = maxmath.select(__int4.TestData_LHS[1], __int4.TestData_RHS[1], 0b0111);
            result &= selected.x == __int4.TestData_RHS[1].x;
            result &= selected.y == __int4.TestData_RHS[1].y;
            result &= selected.z == __int4.TestData_RHS[1].z;
            result &= selected.w == __int4.TestData_LHS[1].w;

            selected = maxmath.select(__int4.TestData_LHS[2], __int4.TestData_RHS[2], 0b0110);
            result &= selected.x == __int4.TestData_LHS[2].x;
            result &= selected.y == __int4.TestData_RHS[2].y;
            result &= selected.z == __int4.TestData_RHS[2].z;
            result &= selected.w == __int4.TestData_LHS[2].w;

            selected = maxmath.select(__int4.TestData_LHS[3], __int4.TestData_RHS[3], 0b1101);
            result &= selected.x == __int4.TestData_RHS[3].x;
            result &= selected.y == __int4.TestData_LHS[3].y;
            result &= selected.z == __int4.TestData_RHS[3].z;
            result &= selected.w == __int4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void uint8_via_int()
        {
            bool result = true;


            uint8 selected;

            selected = maxmath.select(__uint8.TestData_LHS[0], __uint8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0  == __uint8.TestData_RHS[0].x0; 
            result &= selected.x1  == __uint8.TestData_RHS[0].x1;
            result &= selected.x2  == __uint8.TestData_LHS[0].x2;
            result &= selected.x3  == __uint8.TestData_RHS[0].x3;
            result &= selected.x4  == __uint8.TestData_RHS[0].x4;
            result &= selected.x5  == __uint8.TestData_RHS[0].x5;
            result &= selected.x6  == __uint8.TestData_LHS[0].x6;
            result &= selected.x7  == __uint8.TestData_RHS[0].x7;

            selected = maxmath.select(__uint8.TestData_LHS[1], __uint8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0  == __uint8.TestData_RHS[1].x0;
            result &= selected.x1  == __uint8.TestData_RHS[1].x1;
            result &= selected.x2  == __uint8.TestData_LHS[1].x2;
            result &= selected.x3  == __uint8.TestData_LHS[1].x3;
            result &= selected.x4  == __uint8.TestData_LHS[1].x4;
            result &= selected.x5  == __uint8.TestData_RHS[1].x5;
            result &= selected.x6  == __uint8.TestData_RHS[1].x6;
            result &= selected.x7  == __uint8.TestData_RHS[1].x7;

            selected = maxmath.select(__uint8.TestData_LHS[2], __uint8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __uint8.TestData_RHS[2].x0;
            result &= selected.x1  == __uint8.TestData_LHS[2].x1; 
            result &= selected.x2  == __uint8.TestData_LHS[2].x2;
            result &= selected.x3  == __uint8.TestData_RHS[2].x3;
            result &= selected.x4  == __uint8.TestData_LHS[2].x4;
            result &= selected.x5  == __uint8.TestData_RHS[2].x5;
            result &= selected.x6  == __uint8.TestData_LHS[2].x6;
            result &= selected.x7  == __uint8.TestData_LHS[2].x7;

            selected = maxmath.select(__uint8.TestData_LHS[3], __uint8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __uint8.TestData_RHS[3].x0;
            result &= selected.x1  == __uint8.TestData_RHS[3].x1;
            result &= selected.x2  == __uint8.TestData_LHS[3].x2;
            result &= selected.x3  == __uint8.TestData_RHS[3].x3;
            result &= selected.x4  == __uint8.TestData_RHS[3].x4;
            result &= selected.x5  == __uint8.TestData_RHS[3].x5;
            result &= selected.x6  == __uint8.TestData_RHS[3].x6;
            result &= selected.x7  == __uint8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void int8_via_int()
        {
            bool result = true;


            int8 selected;

            selected = maxmath.select(__int8.TestData_LHS[0], __int8.TestData_RHS[0], 0b1011_1011);
            result &= selected.x0  == __int8.TestData_RHS[0].x0; 
            result &= selected.x1  == __int8.TestData_RHS[0].x1;
            result &= selected.x2  == __int8.TestData_LHS[0].x2;
            result &= selected.x3  == __int8.TestData_RHS[0].x3;
            result &= selected.x4  == __int8.TestData_RHS[0].x4;
            result &= selected.x5  == __int8.TestData_RHS[0].x5;
            result &= selected.x6  == __int8.TestData_LHS[0].x6;
            result &= selected.x7  == __int8.TestData_RHS[0].x7;

            selected = maxmath.select(__int8.TestData_LHS[1], __int8.TestData_RHS[1], 0b1110_0011);
            result &= selected.x0  == __int8.TestData_RHS[1].x0;
            result &= selected.x1  == __int8.TestData_RHS[1].x1;
            result &= selected.x2  == __int8.TestData_LHS[1].x2;
            result &= selected.x3  == __int8.TestData_LHS[1].x3;
            result &= selected.x4  == __int8.TestData_LHS[1].x4;
            result &= selected.x5  == __int8.TestData_RHS[1].x5;
            result &= selected.x6  == __int8.TestData_RHS[1].x6;
            result &= selected.x7  == __int8.TestData_RHS[1].x7;

            selected = maxmath.select(__int8.TestData_LHS[2], __int8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0  == __int8.TestData_RHS[2].x0;
            result &= selected.x1  == __int8.TestData_LHS[2].x1; 
            result &= selected.x2  == __int8.TestData_LHS[2].x2;
            result &= selected.x3  == __int8.TestData_RHS[2].x3;
            result &= selected.x4  == __int8.TestData_LHS[2].x4;
            result &= selected.x5  == __int8.TestData_RHS[2].x5;
            result &= selected.x6  == __int8.TestData_LHS[2].x6;
            result &= selected.x7  == __int8.TestData_LHS[2].x7;

            selected = maxmath.select(__int8.TestData_LHS[3], __int8.TestData_RHS[3], 0b1111_1011);
            result &= selected.x0  == __int8.TestData_RHS[3].x0;
            result &= selected.x1  == __int8.TestData_RHS[3].x1;
            result &= selected.x2  == __int8.TestData_LHS[3].x2;
            result &= selected.x3  == __int8.TestData_RHS[3].x3;
            result &= selected.x4  == __int8.TestData_RHS[3].x4;
            result &= selected.x5  == __int8.TestData_RHS[3].x5;
            result &= selected.x6  == __int8.TestData_RHS[3].x6;
            result &= selected.x7  == __int8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ulong2_via_int()
        {
            bool result = true;


            ulong2 selected;

            selected = maxmath.select(__ulong2.TestData_LHS[0], __ulong2.TestData_RHS[0], 0b10);
            result &= selected.x == __ulong2.TestData_LHS[0].x;
            result &= selected.y == __ulong2.TestData_RHS[0].y;

            selected = maxmath.select(__ulong2.TestData_LHS[1], __ulong2.TestData_RHS[1], 0b11);
            result &= selected.x == __ulong2.TestData_RHS[1].x;
            result &= selected.y == __ulong2.TestData_RHS[1].y;

            selected = maxmath.select(__ulong2.TestData_LHS[2], __ulong2.TestData_RHS[2], 0b00);
            result &= selected.x == __ulong2.TestData_LHS[2].x;
            result &= selected.y == __ulong2.TestData_LHS[2].y;

            selected = maxmath.select(__ulong2.TestData_LHS[3], __ulong2.TestData_RHS[3], 0b01);
            result &= selected.x == __ulong2.TestData_RHS[3].x;
            result &= selected.y == __ulong2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void long2_via_int()
        {
            bool result = true;


            long2 selected;

            selected = maxmath.select(__long2.TestData_LHS[0], __long2.TestData_RHS[0], 0b10);
            result &= selected.x == __long2.TestData_LHS[0].x;
            result &= selected.y == __long2.TestData_RHS[0].y;

            selected = maxmath.select(__long2.TestData_LHS[1], __long2.TestData_RHS[1], 0b11);
            result &= selected.x == __long2.TestData_RHS[1].x;
            result &= selected.y == __long2.TestData_RHS[1].y;

            selected = maxmath.select(__long2.TestData_LHS[2], __long2.TestData_RHS[2], 0b00);
            result &= selected.x == __long2.TestData_LHS[2].x;
            result &= selected.y == __long2.TestData_LHS[2].y;

            selected = maxmath.select(__long2.TestData_LHS[3], __long2.TestData_RHS[3], 0b01);
            result &= selected.x == __long2.TestData_RHS[3].x;
            result &= selected.y == __long2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ulong3_via_int()
        {
            bool result = true;


            ulong3 selected;

            selected = maxmath.select(__ulong3.TestData_LHS[0], __ulong3.TestData_RHS[0], 0b110);
            result &= selected.x == __ulong3.TestData_LHS[0].x;
            result &= selected.y == __ulong3.TestData_RHS[0].y;
            result &= selected.z == __ulong3.TestData_RHS[0].z;

            selected = maxmath.select(__ulong3.TestData_LHS[1], __ulong3.TestData_RHS[1], 0b011);
            result &= selected.x == __ulong3.TestData_RHS[1].x;
            result &= selected.y == __ulong3.TestData_RHS[1].y;
            result &= selected.z == __ulong3.TestData_LHS[1].z;

            selected = maxmath.select(__ulong3.TestData_LHS[2], __ulong3.TestData_RHS[2], 0b100);
            result &= selected.x == __ulong3.TestData_LHS[2].x;
            result &= selected.y == __ulong3.TestData_LHS[2].y;
            result &= selected.z == __ulong3.TestData_RHS[2].z;

            selected = maxmath.select(__ulong3.TestData_LHS[3], __ulong3.TestData_RHS[3], 0b101);
            result &= selected.x == __ulong3.TestData_RHS[3].x;
            result &= selected.y == __ulong3.TestData_LHS[3].y;
            result &= selected.z == __ulong3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void long3_via_int()
        {
            bool result = true;


            long3 selected;

            selected = maxmath.select(__long3.TestData_LHS[0], __long3.TestData_RHS[0], 0b110);
            result &= selected.x == __long3.TestData_LHS[0].x;
            result &= selected.y == __long3.TestData_RHS[0].y;
            result &= selected.z == __long3.TestData_RHS[0].z;

            selected = maxmath.select(__long3.TestData_LHS[1], __long3.TestData_RHS[1], 0b011);
            result &= selected.x == __long3.TestData_RHS[1].x;
            result &= selected.y == __long3.TestData_RHS[1].y;
            result &= selected.z == __long3.TestData_LHS[1].z;

            selected = maxmath.select(__long3.TestData_LHS[2], __long3.TestData_RHS[2], 0b100);
            result &= selected.x == __long3.TestData_LHS[2].x;
            result &= selected.y == __long3.TestData_LHS[2].y;
            result &= selected.z == __long3.TestData_RHS[2].z;

            selected = maxmath.select(__long3.TestData_LHS[3], __long3.TestData_RHS[3], 0b101);
            result &= selected.x == __long3.TestData_RHS[3].x;
            result &= selected.y == __long3.TestData_LHS[3].y;
            result &= selected.z == __long3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void ulong4_via_int()
        {
            bool result = true;


            ulong4 selected;

            selected = maxmath.select(__ulong4.TestData_LHS[0], __ulong4.TestData_RHS[0], 0b1110);
            result &= selected.x == __ulong4.TestData_LHS[0].x;
            result &= selected.y == __ulong4.TestData_RHS[0].y;
            result &= selected.z == __ulong4.TestData_RHS[0].z;
            result &= selected.w == __ulong4.TestData_RHS[0].w;

            selected = maxmath.select(__ulong4.TestData_LHS[1], __ulong4.TestData_RHS[1], 0b0111);
            result &= selected.x == __ulong4.TestData_RHS[1].x;
            result &= selected.y == __ulong4.TestData_RHS[1].y;
            result &= selected.z == __ulong4.TestData_RHS[1].z;
            result &= selected.w == __ulong4.TestData_LHS[1].w;

            selected = maxmath.select(__ulong4.TestData_LHS[2], __ulong4.TestData_RHS[2], 0b0110);
            result &= selected.x == __ulong4.TestData_LHS[2].x;
            result &= selected.y == __ulong4.TestData_RHS[2].y;
            result &= selected.z == __ulong4.TestData_RHS[2].z;
            result &= selected.w == __ulong4.TestData_LHS[2].w;

            selected = maxmath.select(__ulong4.TestData_LHS[3], __ulong4.TestData_RHS[3], 0b1101);
            result &= selected.x == __ulong4.TestData_RHS[3].x;
            result &= selected.y == __ulong4.TestData_LHS[3].y;
            result &= selected.z == __ulong4.TestData_RHS[3].z;
            result &= selected.w == __ulong4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void long4_via_int()
        {
            bool result = true;


            long4 selected;

            selected = maxmath.select(__long4.TestData_LHS[0], __long4.TestData_RHS[0], 0b1110);
            result &= selected.x == __long4.TestData_LHS[0].x;
            result &= selected.y == __long4.TestData_RHS[0].y;
            result &= selected.z == __long4.TestData_RHS[0].z;
            result &= selected.w == __long4.TestData_RHS[0].w;

            selected = maxmath.select(__long4.TestData_LHS[1], __long4.TestData_RHS[1], 0b0111);
            result &= selected.x == __long4.TestData_RHS[1].x;
            result &= selected.y == __long4.TestData_RHS[1].y;
            result &= selected.z == __long4.TestData_RHS[1].z;
            result &= selected.w == __long4.TestData_LHS[1].w;

            selected = maxmath.select(__long4.TestData_LHS[2], __long4.TestData_RHS[2], 0b0110);
            result &= selected.x == __long4.TestData_LHS[2].x;
            result &= selected.y == __long4.TestData_RHS[2].y;
            result &= selected.z == __long4.TestData_RHS[2].z;
            result &= selected.w == __long4.TestData_LHS[2].w;

            selected = maxmath.select(__long4.TestData_LHS[3], __long4.TestData_RHS[3], 0b1101);
            result &= selected.x == __long4.TestData_RHS[3].x;
            result &= selected.y == __long4.TestData_LHS[3].y;
            result &= selected.z == __long4.TestData_RHS[3].z;
            result &= selected.w == __long4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void float2_via_int()
        {
            bool result = true;


            float2 selected;

            selected = maxmath.select(__float2.TestData_LHS[0], __float2.TestData_RHS[0], 0b10);
            result &= selected.x == __float2.TestData_LHS[0].x;
            result &= selected.y == __float2.TestData_RHS[0].y;

            selected = maxmath.select(__float2.TestData_LHS[1], __float2.TestData_RHS[1], 0b11);
            result &= selected.x == __float2.TestData_RHS[1].x;
            result &= selected.y == __float2.TestData_RHS[1].y;

            selected = maxmath.select(__float2.TestData_LHS[2], __float2.TestData_RHS[2], 0b00);
            result &= selected.x == __float2.TestData_LHS[2].x;
            result &= selected.y == __float2.TestData_LHS[2].y;

            selected = maxmath.select(__float2.TestData_LHS[3], __float2.TestData_RHS[3], 0b01);
            result &= selected.x == __float2.TestData_RHS[3].x;
            result &= selected.y == __float2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void double2_via_int()
        {
            bool result = true;


            double2 selected;

            selected = maxmath.select(__double2.TestData_LHS[0], __double2.TestData_RHS[0], 0b10);
            result &= selected.x == __double2.TestData_LHS[0].x;
            result &= selected.y == __double2.TestData_RHS[0].y;

            selected = maxmath.select(__double2.TestData_LHS[1], __double2.TestData_RHS[1], 0b11);
            result &= selected.x == __double2.TestData_RHS[1].x;
            result &= selected.y == __double2.TestData_RHS[1].y;

            selected = maxmath.select(__double2.TestData_LHS[2], __double2.TestData_RHS[2], 0b00);
            result &= selected.x == __double2.TestData_LHS[2].x;
            result &= selected.y == __double2.TestData_LHS[2].y;

            selected = maxmath.select(__double2.TestData_LHS[3], __double2.TestData_RHS[3], 0b01);
            result &= selected.x == __double2.TestData_RHS[3].x;
            result &= selected.y == __double2.TestData_LHS[3].y;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void float3_via_int()
        {
            bool result = true;


            float3 selected;

            selected = maxmath.select(__float3.TestData_LHS[0], __float3.TestData_RHS[0], 0b110);
            result &= selected.x == __float3.TestData_LHS[0].x;
            result &= selected.y == __float3.TestData_RHS[0].y;
            result &= selected.z == __float3.TestData_RHS[0].z;

            selected = maxmath.select(__float3.TestData_LHS[1], __float3.TestData_RHS[1], 0b011);
            result &= selected.x == __float3.TestData_RHS[1].x;
            result &= selected.y == __float3.TestData_RHS[1].y;
            result &= selected.z == __float3.TestData_LHS[1].z;

            selected = maxmath.select(__float3.TestData_LHS[2], __float3.TestData_RHS[2], 0b100);
            result &= selected.x == __float3.TestData_LHS[2].x;
            result &= selected.y == __float3.TestData_LHS[2].y;
            result &= selected.z == __float3.TestData_RHS[2].z;

            selected = maxmath.select(__float3.TestData_LHS[3], __float3.TestData_RHS[3], 0b101);
            result &= selected.x == __float3.TestData_RHS[3].x;
            result &= selected.y == __float3.TestData_LHS[3].y;
            result &= selected.z == __float3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void double3_via_int()
        {
            bool result = true;


            double3 selected;

            selected = maxmath.select(__double3.TestData_LHS[0], __double3.TestData_RHS[0], 0b110);
            result &= selected.x == __double3.TestData_LHS[0].x;
            result &= selected.y == __double3.TestData_RHS[0].y;
            result &= selected.z == __double3.TestData_RHS[0].z;

            selected = maxmath.select(__double3.TestData_LHS[1], __double3.TestData_RHS[1], 0b011);
            result &= selected.x == __double3.TestData_RHS[1].x;
            result &= selected.y == __double3.TestData_RHS[1].y;
            result &= selected.z == __double3.TestData_LHS[1].z;

            selected = maxmath.select(__double3.TestData_LHS[2], __double3.TestData_RHS[2], 0b100);
            result &= selected.x == __double3.TestData_LHS[2].x;
            result &= selected.y == __double3.TestData_LHS[2].y;
            result &= selected.z == __double3.TestData_RHS[2].z;

            selected = maxmath.select(__double3.TestData_LHS[3], __double3.TestData_RHS[3], 0b101);
            result &= selected.x == __double3.TestData_RHS[3].x;
            result &= selected.y == __double3.TestData_LHS[3].y;
            result &= selected.z == __double3.TestData_RHS[3].z;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void float4_via_int()
        {
            bool result = true;


            float4 selected;

            selected = maxmath.select(__float4.TestData_LHS[0], __float4.TestData_RHS[0], 0b1110);
            result &= selected.x == __float4.TestData_LHS[0].x;
            result &= selected.y == __float4.TestData_RHS[0].y;
            result &= selected.z == __float4.TestData_RHS[0].z;
            result &= selected.w == __float4.TestData_RHS[0].w;

            selected = maxmath.select(__float4.TestData_LHS[1], __float4.TestData_RHS[1], 0b0111);
            result &= selected.x == __float4.TestData_RHS[1].x;
            result &= selected.y == __float4.TestData_RHS[1].y;
            result &= selected.z == __float4.TestData_RHS[1].z;
            result &= selected.w == __float4.TestData_LHS[1].w;

            selected = maxmath.select(__float4.TestData_LHS[2], __float4.TestData_RHS[2], 0b0110);
            result &= selected.x == __float4.TestData_LHS[2].x;
            result &= selected.y == __float4.TestData_RHS[2].y;
            result &= selected.z == __float4.TestData_RHS[2].z;
            result &= selected.w == __float4.TestData_LHS[2].w;

            selected = maxmath.select(__float4.TestData_LHS[3], __float4.TestData_RHS[3], 0b1101);
            result &= selected.x == __float4.TestData_RHS[3].x;
            result &= selected.y == __float4.TestData_LHS[3].y;
            result &= selected.z == __float4.TestData_RHS[3].z;
            result &= selected.w == __float4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }

        [Test]
        public static void double4_via_int()
        {
            bool result = true;


            double4 selected;

            selected = maxmath.select(__double4.TestData_LHS[0], __double4.TestData_RHS[0], 0b1110);
            result &= selected.x == __double4.TestData_LHS[0].x;
            result &= selected.y == __double4.TestData_RHS[0].y;
            result &= selected.z == __double4.TestData_RHS[0].z;
            result &= selected.w == __double4.TestData_RHS[0].w;

            selected = maxmath.select(__double4.TestData_LHS[1], __double4.TestData_RHS[1], 0b0111);
            result &= selected.x == __double4.TestData_RHS[1].x;
            result &= selected.y == __double4.TestData_RHS[1].y;
            result &= selected.z == __double4.TestData_RHS[1].z;
            result &= selected.w == __double4.TestData_LHS[1].w;

            selected = maxmath.select(__double4.TestData_LHS[2], __double4.TestData_RHS[2], 0b0110);
            result &= selected.x == __double4.TestData_LHS[2].x;
            result &= selected.y == __double4.TestData_RHS[2].y;
            result &= selected.z == __double4.TestData_RHS[2].z;
            result &= selected.w == __double4.TestData_LHS[2].w;

            selected = maxmath.select(__double4.TestData_LHS[3], __double4.TestData_RHS[3], 0b1101);
            result &= selected.x == __double4.TestData_RHS[3].x;
            result &= selected.y == __double4.TestData_LHS[3].y;
            result &= selected.z == __double4.TestData_RHS[3].z;
            result &= selected.w == __double4.TestData_RHS[3].w;


            Assert.AreEqual(true, result);
        }


        [Test]
        public static void float8_via_int()
        {
            bool result = true;


            float8 selected;

            selected = maxmath.select(__float8.TestData_LHS[0], __float8.TestData_RHS[0], unchecked((int)0b1011_1011u));
            result &= selected.x0 == __float8.TestData_RHS[0].x0; 
            result &= selected.x1 == __float8.TestData_RHS[0].x1;
            result &= selected.x2 == __float8.TestData_LHS[0].x2;
            result &= selected.x3 == __float8.TestData_RHS[0].x3;
            result &= selected.x4 == __float8.TestData_RHS[0].x4;
            result &= selected.x5 == __float8.TestData_RHS[0].x5;
            result &= selected.x6 == __float8.TestData_LHS[0].x6;
            result &= selected.x7 == __float8.TestData_RHS[0].x7;

            selected = maxmath.select(__float8.TestData_LHS[1], __float8.TestData_RHS[1], unchecked((int)0b1110_0011u));
            result &= selected.x0 == __float8.TestData_RHS[1].x0;
            result &= selected.x1 == __float8.TestData_RHS[1].x1;
            result &= selected.x2 == __float8.TestData_LHS[1].x2;
            result &= selected.x3 == __float8.TestData_LHS[1].x3;
            result &= selected.x4 == __float8.TestData_LHS[1].x4;
            result &= selected.x5 == __float8.TestData_RHS[1].x5;
            result &= selected.x6 == __float8.TestData_RHS[1].x6;
            result &= selected.x7 == __float8.TestData_RHS[1].x7;

            selected = maxmath.select(__float8.TestData_LHS[2], __float8.TestData_RHS[2], 0b0010_1001);
            result &= selected.x0 == __float8.TestData_RHS[2].x0;
            result &= selected.x1 == __float8.TestData_LHS[2].x1;
            result &= selected.x2 == __float8.TestData_LHS[2].x2;
            result &= selected.x3 == __float8.TestData_RHS[2].x3;
            result &= selected.x4 == __float8.TestData_LHS[2].x4;
            result &= selected.x5 == __float8.TestData_RHS[2].x5;
            result &= selected.x6 == __float8.TestData_LHS[2].x6;
            result &= selected.x7 == __float8.TestData_LHS[2].x7;

            selected = maxmath.select(__float8.TestData_LHS[3], __float8.TestData_RHS[3], 0b1111_1101);
            result &= selected.x0 == __float8.TestData_RHS[3].x0;
            result &= selected.x1 == __float8.TestData_LHS[3].x1;
            result &= selected.x2 == __float8.TestData_RHS[3].x2;
            result &= selected.x3 == __float8.TestData_RHS[3].x3;
            result &= selected.x4 == __float8.TestData_RHS[3].x4;
            result &= selected.x5 == __float8.TestData_RHS[3].x5;
            result &= selected.x6 == __float8.TestData_RHS[3].x6;
            result &= selected.x7 == __float8.TestData_RHS[3].x7;


            Assert.AreEqual(true, result);
        }
    }
}


