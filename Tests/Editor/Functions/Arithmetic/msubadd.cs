using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_msubadd
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            byte2 a = rng.NextByte2();
            byte2 b = rng.NextByte2();
            byte2 c = rng.NextByte2();
            byte2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (byte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (byte)(a.y * b.y + c.y));
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            byte3 a = rng.NextByte3();
            byte3 b = rng.NextByte3();
            byte3 c = rng.NextByte3();
            byte3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (byte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (byte)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (byte)(a.z * b.z - c.z));
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            byte4 a = rng.NextByte4();
            byte4 b = rng.NextByte4();
            byte4 c = rng.NextByte4();
            byte4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (byte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (byte)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (byte)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (byte)(a.w * b.w + c.w));
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            byte8 a = rng.NextByte8();
            byte8 b = rng.NextByte8();
            byte8 c = rng.NextByte8();
            byte8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (byte)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (byte)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (byte)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (byte)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (byte)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (byte)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (byte)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (byte)(a.x7 * b.x7 + c.x7));
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            byte16 a = rng.NextByte16();
            byte16 b = rng.NextByte16();
            byte16 c = rng.NextByte16();
            byte16 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (byte)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (byte)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (byte)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (byte)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (byte)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (byte)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (byte)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (byte)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (byte)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (byte)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (byte)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (byte)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (byte)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (byte)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (byte)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (byte)(a.x15 * b.x15 + c.x15));
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            byte32 a = rng.NextByte32();
            byte32 b = rng.NextByte32();
            byte32 c = rng.NextByte32();
            byte32 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (byte)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (byte)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (byte)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (byte)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (byte)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (byte)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (byte)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (byte)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (byte)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (byte)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (byte)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (byte)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (byte)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (byte)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (byte)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (byte)(a.x15 * b.x15 + c.x15));
            Assert.AreEqual(op.x16, (byte)(a.x16 * b.x16 - c.x16));
            Assert.AreEqual(op.x17, (byte)(a.x17 * b.x17 + c.x17));
            Assert.AreEqual(op.x18, (byte)(a.x18 * b.x18 - c.x18));
            Assert.AreEqual(op.x19, (byte)(a.x19 * b.x19 + c.x19));
            Assert.AreEqual(op.x20, (byte)(a.x20 * b.x20 - c.x20));
            Assert.AreEqual(op.x21, (byte)(a.x21 * b.x21 + c.x21));
            Assert.AreEqual(op.x22, (byte)(a.x22 * b.x22 - c.x22));
            Assert.AreEqual(op.x23, (byte)(a.x23 * b.x23 + c.x23));
            Assert.AreEqual(op.x24, (byte)(a.x24 * b.x24 - c.x24));
            Assert.AreEqual(op.x25, (byte)(a.x25 * b.x25 + c.x25));
            Assert.AreEqual(op.x26, (byte)(a.x26 * b.x26 - c.x26));
            Assert.AreEqual(op.x27, (byte)(a.x27 * b.x27 + c.x27));
            Assert.AreEqual(op.x28, (byte)(a.x28 * b.x28 - c.x28));
            Assert.AreEqual(op.x29, (byte)(a.x29 * b.x29 + c.x29));
            Assert.AreEqual(op.x30, (byte)(a.x30 * b.x30 - c.x30));
            Assert.AreEqual(op.x31, (byte)(a.x31 * b.x31 + c.x31));
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            sbyte2 a = rng.NextSByte2();
            sbyte2 b = rng.NextSByte2();
            sbyte2 c = rng.NextSByte2();
            sbyte2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (sbyte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (sbyte)(a.y * b.y + c.y));
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            sbyte3 a = rng.NextSByte3();
            sbyte3 b = rng.NextSByte3();
            sbyte3 c = rng.NextSByte3();
            sbyte3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (sbyte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (sbyte)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (sbyte)(a.z * b.z - c.z));
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            sbyte4 a = rng.NextSByte4();
            sbyte4 b = rng.NextSByte4();
            sbyte4 c = rng.NextSByte4();
            sbyte4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (sbyte)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (sbyte)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (sbyte)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (sbyte)(a.w * b.w + c.w));
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            sbyte8 a = rng.NextSByte8();
            sbyte8 b = rng.NextSByte8();
            sbyte8 c = rng.NextSByte8();
            sbyte8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (sbyte)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (sbyte)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (sbyte)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (sbyte)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (sbyte)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (sbyte)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (sbyte)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (sbyte)(a.x7 * b.x7 + c.x7));
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            sbyte16 a = rng.NextSByte16();
            sbyte16 b = rng.NextSByte16();
            sbyte16 c = rng.NextSByte16();
            sbyte16 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (sbyte)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (sbyte)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (sbyte)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (sbyte)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (sbyte)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (sbyte)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (sbyte)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (sbyte)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (sbyte)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (sbyte)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (sbyte)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (sbyte)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (sbyte)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (sbyte)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (sbyte)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (sbyte)(a.x15 * b.x15 + c.x15));
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 rng = Random8.New;

            sbyte32 a = rng.NextSByte32();
            sbyte32 b = rng.NextSByte32();
            sbyte32 c = rng.NextSByte32();
            sbyte32 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (sbyte)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (sbyte)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (sbyte)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (sbyte)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (sbyte)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (sbyte)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (sbyte)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (sbyte)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (sbyte)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (sbyte)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (sbyte)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (sbyte)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (sbyte)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (sbyte)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (sbyte)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (sbyte)(a.x15 * b.x15 + c.x15));
            Assert.AreEqual(op.x16, (sbyte)(a.x16 * b.x16 - c.x16));
            Assert.AreEqual(op.x17, (sbyte)(a.x17 * b.x17 + c.x17));
            Assert.AreEqual(op.x18, (sbyte)(a.x18 * b.x18 - c.x18));
            Assert.AreEqual(op.x19, (sbyte)(a.x19 * b.x19 + c.x19));
            Assert.AreEqual(op.x20, (sbyte)(a.x20 * b.x20 - c.x20));
            Assert.AreEqual(op.x21, (sbyte)(a.x21 * b.x21 + c.x21));
            Assert.AreEqual(op.x22, (sbyte)(a.x22 * b.x22 - c.x22));
            Assert.AreEqual(op.x23, (sbyte)(a.x23 * b.x23 + c.x23));
            Assert.AreEqual(op.x24, (sbyte)(a.x24 * b.x24 - c.x24));
            Assert.AreEqual(op.x25, (sbyte)(a.x25 * b.x25 + c.x25));
            Assert.AreEqual(op.x26, (sbyte)(a.x26 * b.x26 - c.x26));
            Assert.AreEqual(op.x27, (sbyte)(a.x27 * b.x27 + c.x27));
            Assert.AreEqual(op.x28, (sbyte)(a.x28 * b.x28 - c.x28));
            Assert.AreEqual(op.x29, (sbyte)(a.x29 * b.x29 + c.x29));
            Assert.AreEqual(op.x30, (sbyte)(a.x30 * b.x30 - c.x30));
            Assert.AreEqual(op.x31, (sbyte)(a.x31 * b.x31 + c.x31));
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            ushort2 a = rng.NextUShort2();
            ushort2 b = rng.NextUShort2();
            ushort2 c = rng.NextUShort2();
            ushort2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ushort)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ushort)(a.y * b.y + c.y));
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            ushort3 a = rng.NextUShort3();
            ushort3 b = rng.NextUShort3();
            ushort3 c = rng.NextUShort3();
            ushort3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ushort)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ushort)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (ushort)(a.z * b.z - c.z));
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            ushort4 a = rng.NextUShort4();
            ushort4 b = rng.NextUShort4();
            ushort4 c = rng.NextUShort4();
            ushort4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ushort)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ushort)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (ushort)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (ushort)(a.w * b.w + c.w));
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            ushort8 a = rng.NextUShort8();
            ushort8 b = rng.NextUShort8();
            ushort8 c = rng.NextUShort8();
            ushort8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (ushort)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (ushort)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (ushort)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (ushort)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (ushort)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (ushort)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (ushort)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (ushort)(a.x7 * b.x7 + c.x7));
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            ushort16 a = rng.NextUShort16();
            ushort16 b = rng.NextUShort16();
            ushort16 c = rng.NextUShort16();
            ushort16 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (ushort)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (ushort)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (ushort)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (ushort)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (ushort)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (ushort)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (ushort)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (ushort)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (ushort)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (ushort)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (ushort)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (ushort)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (ushort)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (ushort)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (ushort)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (ushort)(a.x15 * b.x15 + c.x15));
        }


        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            short2 a = rng.NextShort2();
            short2 b = rng.NextShort2();
            short2 c = rng.NextShort2();
            short2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (short)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (short)(a.y * b.y + c.y));
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            short3 a = rng.NextShort3();
            short3 b = rng.NextShort3();
            short3 c = rng.NextShort3();
            short3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (short)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (short)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (short)(a.z * b.z - c.z));
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            short4 a = rng.NextShort4();
            short4 b = rng.NextShort4();
            short4 c = rng.NextShort4();
            short4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (short)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (short)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (short)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (short)(a.w * b.w + c.w));
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            short8 a = rng.NextShort8();
            short8 b = rng.NextShort8();
            short8 c = rng.NextShort8();
            short8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (short)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (short)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (short)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (short)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (short)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (short)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (short)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (short)(a.x7 * b.x7 + c.x7));
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            short16 a = rng.NextShort16();
            short16 b = rng.NextShort16();
            short16 c = rng.NextShort16();
            short16 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0,  (short)(a.x0  * b.x0  - c.x0));
            Assert.AreEqual(op.x1,  (short)(a.x1  * b.x1  + c.x1));
            Assert.AreEqual(op.x2,  (short)(a.x2  * b.x2  - c.x2));
            Assert.AreEqual(op.x3,  (short)(a.x3  * b.x3  + c.x3));
            Assert.AreEqual(op.x4,  (short)(a.x4  * b.x4  - c.x4));
            Assert.AreEqual(op.x5,  (short)(a.x5  * b.x5  + c.x5));
            Assert.AreEqual(op.x6,  (short)(a.x6  * b.x6  - c.x6));
            Assert.AreEqual(op.x7,  (short)(a.x7  * b.x7  + c.x7));
            Assert.AreEqual(op.x8,  (short)(a.x8  * b.x8  - c.x8));
            Assert.AreEqual(op.x9,  (short)(a.x9  * b.x9  + c.x9));
            Assert.AreEqual(op.x10, (short)(a.x10 * b.x10 - c.x10));
            Assert.AreEqual(op.x11, (short)(a.x11 * b.x11 + c.x11));
            Assert.AreEqual(op.x12, (short)(a.x12 * b.x12 - c.x12));
            Assert.AreEqual(op.x13, (short)(a.x13 * b.x13 + c.x13));
            Assert.AreEqual(op.x14, (short)(a.x14 * b.x14 - c.x14));
            Assert.AreEqual(op.x15, (short)(a.x15 * b.x15 + c.x15));
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            uint2 a = rng.NextUInt2();
            uint2 b = rng.NextUInt2();
            uint2 c = rng.NextUInt2();
            uint2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (uint)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (uint)(a.y * b.y + c.y));
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            uint3 a = rng.NextUInt3();
            uint3 b = rng.NextUInt3();
            uint3 c = rng.NextUInt3();
            uint3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (uint)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (uint)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (uint)(a.z * b.z - c.z));
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            uint4 a = rng.NextUInt4();
            uint4 b = rng.NextUInt4();
            uint4 c = rng.NextUInt4();
            uint4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (uint)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (uint)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (uint)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (uint)(a.w * b.w + c.w));
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            uint8 a = rng.NextUInt8();
            uint8 b = rng.NextUInt8();
            uint8 c = rng.NextUInt8();
            uint8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (uint)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (uint)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (uint)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (uint)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (uint)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (uint)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (uint)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (uint)(a.x7 * b.x7 + c.x7));
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            int2 a = rng.NextInt2();
            int2 b = rng.NextInt2();
            int2 c = rng.NextInt2();
            int2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (int)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (int)(a.y * b.y + c.y));
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            int3 a = rng.NextInt3();
            int3 b = rng.NextInt3();
            int3 c = rng.NextInt3();
            int3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (int)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (int)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (int)(a.z * b.z - c.z));
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            int4 a = rng.NextInt4();
            int4 b = rng.NextInt4();
            int4 c = rng.NextInt4();
            int4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (int)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (int)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (int)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (int)(a.w * b.w + c.w));
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            int8 a = rng.NextInt8();
            int8 b = rng.NextInt8();
            int8 c = rng.NextInt8();
            int8 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x0, (int)(a.x0 * b.x0 - c.x0));
            Assert.AreEqual(op.x1, (int)(a.x1 * b.x1 + c.x1));
            Assert.AreEqual(op.x2, (int)(a.x2 * b.x2 - c.x2));
            Assert.AreEqual(op.x3, (int)(a.x3 * b.x3 + c.x3));
            Assert.AreEqual(op.x4, (int)(a.x4 * b.x4 - c.x4));
            Assert.AreEqual(op.x5, (int)(a.x5 * b.x5 + c.x5));
            Assert.AreEqual(op.x6, (int)(a.x6 * b.x6 - c.x6));
            Assert.AreEqual(op.x7, (int)(a.x7 * b.x7 + c.x7));
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            ulong2 a = rng.NextULong2();
            ulong2 b = rng.NextULong2();
            ulong2 c = rng.NextULong2();
            ulong2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ulong)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ulong)(a.y * b.y + c.y));
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            ulong3 a = rng.NextULong3();
            ulong3 b = rng.NextULong3();
            ulong3 c = rng.NextULong3();
            ulong3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ulong)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ulong)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (ulong)(a.z * b.z - c.z));
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            ulong4 a = rng.NextULong4();
            ulong4 b = rng.NextULong4();
            ulong4 c = rng.NextULong4();
            ulong4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (ulong)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (ulong)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (ulong)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (ulong)(a.w * b.w + c.w));
        }


        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            long2 a = rng.NextLong2();
            long2 b = rng.NextLong2();
            long2 c = rng.NextLong2();
            long2 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (long)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (long)(a.y * b.y + c.y));
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            long3 a = rng.NextLong3();
            long3 b = rng.NextLong3();
            long3 c = rng.NextLong3();
            long3 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (long)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (long)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (long)(a.z * b.z - c.z));
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            long4 a = rng.NextLong4();
            long4 b = rng.NextLong4();
            long4 c = rng.NextLong4();
            long4 op = maxmath.msubadd(a, b, c);

            Assert.AreEqual(op.x, (long)(a.x * b.x - c.x));
            Assert.AreEqual(op.y, (long)(a.y * b.y + c.y));
            Assert.AreEqual(op.z, (long)(a.z * b.z - c.z));
            Assert.AreEqual(op.w, (long)(a.w * b.w + c.w));
        }
    }
}