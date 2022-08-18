using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class addsub
    {
        [Test]
        public static void byte2()
        {
            Random8 rng = Random8.New;

            byte2 left  = rng.NextByte2();
            byte2 right = rng.NextByte2();
            byte2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (byte)(left.x + right.x));
            Assert.AreEqual(op.y, (byte)(left.y - right.y));
        }

        [Test]
        public static void byte3()
        {
            Random8 rng = Random8.New;

            byte3 left  = rng.NextByte3();
            byte3 right = rng.NextByte3();
            byte3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (byte)(left.x + right.x));
            Assert.AreEqual(op.y, (byte)(left.y - right.y));
            Assert.AreEqual(op.z, (byte)(left.z + right.z));
        }

        [Test]
        public static void byte4()
        {
            Random8 rng = Random8.New;

            byte4 left  = rng.NextByte4();
            byte4 right = rng.NextByte4();
            byte4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (byte)(left.x + right.x));
            Assert.AreEqual(op.y, (byte)(left.y - right.y));
            Assert.AreEqual(op.z, (byte)(left.z + right.z));
            Assert.AreEqual(op.w, (byte)(left.w - right.w));
        }

        [Test]
        public static void byte8()
        {
            Random8 rng = Random8.New;

            byte8 left  = rng.NextByte8();
            byte8 right = rng.NextByte8();
            byte8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (byte)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (byte)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (byte)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (byte)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (byte)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (byte)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (byte)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (byte)(left.x7 - right.x7));
        }

        [Test]
        public static void byte16()
        {
            Random8 rng = Random8.New;

            byte16 left  = rng.NextByte16();
            byte16 right = rng.NextByte16();
            byte16 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (byte)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (byte)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (byte)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (byte)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (byte)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (byte)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (byte)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (byte)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (byte)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (byte)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (byte)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (byte)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (byte)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (byte)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (byte)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (byte)(left.x15 - right.x15));
        }

        [Test]
        public static void byte32()
        {
            Random8 rng = Random8.New;

            byte32 left  = rng.NextByte32();
            byte32 right = rng.NextByte32();
            byte32 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (byte)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (byte)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (byte)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (byte)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (byte)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (byte)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (byte)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (byte)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (byte)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (byte)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (byte)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (byte)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (byte)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (byte)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (byte)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (byte)(left.x15 - right.x15));
            Assert.AreEqual(op.x16, (byte)(left.x16 + right.x16));
            Assert.AreEqual(op.x17, (byte)(left.x17 - right.x17));
            Assert.AreEqual(op.x18, (byte)(left.x18 + right.x18));
            Assert.AreEqual(op.x19, (byte)(left.x19 - right.x19));
            Assert.AreEqual(op.x20, (byte)(left.x20 + right.x20));
            Assert.AreEqual(op.x21, (byte)(left.x21 - right.x21));
            Assert.AreEqual(op.x22, (byte)(left.x22 + right.x22));
            Assert.AreEqual(op.x23, (byte)(left.x23 - right.x23));
            Assert.AreEqual(op.x24, (byte)(left.x24 + right.x24));
            Assert.AreEqual(op.x25, (byte)(left.x25 - right.x25));
            Assert.AreEqual(op.x26, (byte)(left.x26 + right.x26));
            Assert.AreEqual(op.x27, (byte)(left.x27 - right.x27));
            Assert.AreEqual(op.x28, (byte)(left.x28 + right.x28));
            Assert.AreEqual(op.x29, (byte)(left.x29 - right.x29));
            Assert.AreEqual(op.x30, (byte)(left.x30 + right.x30));
            Assert.AreEqual(op.x31, (byte)(left.x31 - right.x31));
        }

        
        [Test]
        public static void sbyte2()
        {
            Random8 rng = Random8.New;

            sbyte2 left  = rng.NextSByte2();
            sbyte2 right = rng.NextSByte2();
            sbyte2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (sbyte)(left.x + right.x));
            Assert.AreEqual(op.y, (sbyte)(left.y - right.y));
        }

        [Test]
        public static void sbyte3()
        {
            Random8 rng = Random8.New;

            sbyte3 left  = rng.NextSByte3();
            sbyte3 right = rng.NextSByte3();
            sbyte3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (sbyte)(left.x + right.x));
            Assert.AreEqual(op.y, (sbyte)(left.y - right.y));
            Assert.AreEqual(op.z, (sbyte)(left.z + right.z));
        }

        [Test]
        public static void sbyte4()
        {
            Random8 rng = Random8.New;

            sbyte4 left  = rng.NextSByte4();
            sbyte4 right = rng.NextSByte4();
            sbyte4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (sbyte)(left.x + right.x));
            Assert.AreEqual(op.y, (sbyte)(left.y - right.y));
            Assert.AreEqual(op.z, (sbyte)(left.z + right.z));
            Assert.AreEqual(op.w, (sbyte)(left.w - right.w));
        }

        [Test]
        public static void sbyte8()
        {
            Random8 rng = Random8.New;

            sbyte8 left  = rng.NextSByte8();
            sbyte8 right = rng.NextSByte8();
            sbyte8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (sbyte)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (sbyte)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (sbyte)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (sbyte)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (sbyte)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (sbyte)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (sbyte)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (sbyte)(left.x7 - right.x7));
        }

        [Test]
        public static void sbyte16()
        {
            Random8 rng = Random8.New;

            sbyte16 left  = rng.NextSByte16();
            sbyte16 right = rng.NextSByte16();
            sbyte16 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (sbyte)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (sbyte)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (sbyte)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (sbyte)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (sbyte)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (sbyte)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (sbyte)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (sbyte)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (sbyte)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (sbyte)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (sbyte)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (sbyte)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (sbyte)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (sbyte)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (sbyte)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (sbyte)(left.x15 - right.x15));
        }

        [Test]
        public static void sbyte32()
        {
            Random8 rng = Random8.New;

            sbyte32 left  = rng.NextSByte32();
            sbyte32 right = rng.NextSByte32();
            sbyte32 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (sbyte)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (sbyte)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (sbyte)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (sbyte)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (sbyte)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (sbyte)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (sbyte)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (sbyte)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (sbyte)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (sbyte)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (sbyte)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (sbyte)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (sbyte)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (sbyte)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (sbyte)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (sbyte)(left.x15 - right.x15));
            Assert.AreEqual(op.x16, (sbyte)(left.x16 + right.x16));
            Assert.AreEqual(op.x17, (sbyte)(left.x17 - right.x17));
            Assert.AreEqual(op.x18, (sbyte)(left.x18 + right.x18));
            Assert.AreEqual(op.x19, (sbyte)(left.x19 - right.x19));
            Assert.AreEqual(op.x20, (sbyte)(left.x20 + right.x20));
            Assert.AreEqual(op.x21, (sbyte)(left.x21 - right.x21));
            Assert.AreEqual(op.x22, (sbyte)(left.x22 + right.x22));
            Assert.AreEqual(op.x23, (sbyte)(left.x23 - right.x23));
            Assert.AreEqual(op.x24, (sbyte)(left.x24 + right.x24));
            Assert.AreEqual(op.x25, (sbyte)(left.x25 - right.x25));
            Assert.AreEqual(op.x26, (sbyte)(left.x26 + right.x26));
            Assert.AreEqual(op.x27, (sbyte)(left.x27 - right.x27));
            Assert.AreEqual(op.x28, (sbyte)(left.x28 + right.x28));
            Assert.AreEqual(op.x29, (sbyte)(left.x29 - right.x29));
            Assert.AreEqual(op.x30, (sbyte)(left.x30 + right.x30));
            Assert.AreEqual(op.x31, (sbyte)(left.x31 - right.x31));
        }


        [Test]
        public static void ushort2()
        {
            Random16 rng = Random16.New;

            ushort2 left  = rng.NextUShort2();
            ushort2 right = rng.NextUShort2();
            ushort2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ushort)(left.x + right.x));
            Assert.AreEqual(op.y, (ushort)(left.y - right.y));
        }

        [Test]
        public static void ushort3()
        {
            Random16 rng = Random16.New;

            ushort3 left  = rng.NextUShort3();
            ushort3 right = rng.NextUShort3();
            ushort3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ushort)(left.x + right.x));
            Assert.AreEqual(op.y, (ushort)(left.y - right.y));
            Assert.AreEqual(op.z, (ushort)(left.z + right.z));
        }

        [Test]
        public static void ushort4()
        {
            Random16 rng = Random16.New;

            ushort4 left  = rng.NextUShort4();
            ushort4 right = rng.NextUShort4();
            ushort4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ushort)(left.x + right.x));
            Assert.AreEqual(op.y, (ushort)(left.y - right.y));
            Assert.AreEqual(op.z, (ushort)(left.z + right.z));
            Assert.AreEqual(op.w, (ushort)(left.w - right.w));
        }

        [Test]
        public static void ushort8()
        {
            Random16 rng = Random16.New;

            ushort8 left  = rng.NextUShort8();
            ushort8 right = rng.NextUShort8();
            ushort8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (ushort)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (ushort)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (ushort)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (ushort)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (ushort)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (ushort)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (ushort)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (ushort)(left.x7 - right.x7));
        }

        [Test]
        public static void ushort16()
        {
            Random16 rng = Random16.New;

            ushort16 left  = rng.NextUShort16();
            ushort16 right = rng.NextUShort16();
            ushort16 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (ushort)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (ushort)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (ushort)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (ushort)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (ushort)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (ushort)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (ushort)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (ushort)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (ushort)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (ushort)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (ushort)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (ushort)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (ushort)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (ushort)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (ushort)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (ushort)(left.x15 - right.x15));
        }


        [Test]
        public static void short2()
        {
            Random16 rng = Random16.New;

            short2 left  = rng.NextShort2();
            short2 right = rng.NextShort2();
            short2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (short)(left.x + right.x));
            Assert.AreEqual(op.y, (short)(left.y - right.y));
        }

        [Test]
        public static void short3()
        {
            Random16 rng = Random16.New;

            short3 left  = rng.NextShort3();
            short3 right = rng.NextShort3();
            short3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (short)(left.x + right.x));
            Assert.AreEqual(op.y, (short)(left.y - right.y));
            Assert.AreEqual(op.z, (short)(left.z + right.z));
        }

        [Test]
        public static void short4()
        {
            Random16 rng = Random16.New;

            short4 left  = rng.NextShort4();
            short4 right = rng.NextShort4();
            short4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (short)(left.x + right.x));
            Assert.AreEqual(op.y, (short)(left.y - right.y));
            Assert.AreEqual(op.z, (short)(left.z + right.z));
            Assert.AreEqual(op.w, (short)(left.w - right.w));
        }

        [Test]
        public static void short8()
        {
            Random16 rng = Random16.New;

            short8 left  = rng.NextShort8();
            short8 right = rng.NextShort8();
            short8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (short)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (short)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (short)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (short)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (short)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (short)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (short)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (short)(left.x7 - right.x7));
        }

        [Test]
        public static void short16()
        {
            Random16 rng = Random16.New;

            short16 left  = rng.NextShort16();
            short16 right = rng.NextShort16();
            short16 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0,  (short)(left.x0  + right.x0));
            Assert.AreEqual(op.x1,  (short)(left.x1  - right.x1));
            Assert.AreEqual(op.x2,  (short)(left.x2  + right.x2));
            Assert.AreEqual(op.x3,  (short)(left.x3  - right.x3));
            Assert.AreEqual(op.x4,  (short)(left.x4  + right.x4));
            Assert.AreEqual(op.x5,  (short)(left.x5  - right.x5));
            Assert.AreEqual(op.x6,  (short)(left.x6  + right.x6));
            Assert.AreEqual(op.x7,  (short)(left.x7  - right.x7));
            Assert.AreEqual(op.x8,  (short)(left.x8  + right.x8));
            Assert.AreEqual(op.x9,  (short)(left.x9  - right.x9));
            Assert.AreEqual(op.x10, (short)(left.x10 + right.x10));
            Assert.AreEqual(op.x11, (short)(left.x11 - right.x11));
            Assert.AreEqual(op.x12, (short)(left.x12 + right.x12));
            Assert.AreEqual(op.x13, (short)(left.x13 - right.x13));
            Assert.AreEqual(op.x14, (short)(left.x14 + right.x14));
            Assert.AreEqual(op.x15, (short)(left.x15 - right.x15));
        }


        [Test]
        public static void uint2()
        {
            Random32 rng = Random32.New;

            uint2 left  = rng.NextUInt2();
            uint2 right = rng.NextUInt2();
            uint2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (uint)(left.x + right.x));
            Assert.AreEqual(op.y, (uint)(left.y - right.y));
        }

        [Test]
        public static void uint3()
        {
            Random32 rng = Random32.New;

            uint3 left  = rng.NextUInt3();
            uint3 right = rng.NextUInt3();
            uint3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (uint)(left.x + right.x));
            Assert.AreEqual(op.y, (uint)(left.y - right.y));
            Assert.AreEqual(op.z, (uint)(left.z + right.z));
        }

        [Test]
        public static void uint4()
        {
            Random32 rng = Random32.New;

            uint4 left  = rng.NextUInt4();
            uint4 right = rng.NextUInt4();
            uint4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (uint)(left.x + right.x));
            Assert.AreEqual(op.y, (uint)(left.y - right.y));
            Assert.AreEqual(op.z, (uint)(left.z + right.z));
            Assert.AreEqual(op.w, (uint)(left.w - right.w));
        }

        [Test]
        public static void uint8()
        {
            Random32 rng = Random32.New;

            uint8 left  = rng.NextUInt8();
            uint8 right = rng.NextUInt8();
            uint8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (uint)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (uint)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (uint)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (uint)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (uint)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (uint)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (uint)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (uint)(left.x7 - right.x7));
        }


        [Test]
        public static void int2()
        {
            Random32 rng = Random32.New;

            int2 left  = rng.NextInt2();
            int2 right = rng.NextInt2();
            int2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (int)(left.x + right.x));
            Assert.AreEqual(op.y, (int)(left.y - right.y));
        }

        [Test]
        public static void int3()
        {
            Random32 rng = Random32.New;

            int3 left  = rng.NextInt3();
            int3 right = rng.NextInt3();
            int3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (int)(left.x + right.x));
            Assert.AreEqual(op.y, (int)(left.y - right.y));
            Assert.AreEqual(op.z, (int)(left.z + right.z));
        }

        [Test]
        public static void int4()
        {
            Random32 rng = Random32.New;

            int4 left  = rng.NextInt4();
            int4 right = rng.NextInt4();
            int4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (int)(left.x + right.x));
            Assert.AreEqual(op.y, (int)(left.y - right.y));
            Assert.AreEqual(op.z, (int)(left.z + right.z));
            Assert.AreEqual(op.w, (int)(left.w - right.w));
        }

        [Test]
        public static void int8()
        {
            Random32 rng = Random32.New;

            int8 left  = rng.NextInt8();
            int8 right = rng.NextInt8();
            int8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (int)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (int)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (int)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (int)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (int)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (int)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (int)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (int)(left.x7 - right.x7));
        }


        [Test]
        public static void ulong2()
        {
            Random64 rng = Random64.New;

            ulong2 left  = rng.NextULong2();
            ulong2 right = rng.NextULong2();
            ulong2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ulong)(left.x + right.x));
            Assert.AreEqual(op.y, (ulong)(left.y - right.y));
        }

        [Test]
        public static void ulong3()
        {
            Random64 rng = Random64.New;

            ulong3 left  = rng.NextULong3();
            ulong3 right = rng.NextULong3();
            ulong3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ulong)(left.x + right.x));
            Assert.AreEqual(op.y, (ulong)(left.y - right.y));
            Assert.AreEqual(op.z, (ulong)(left.z + right.z));
        }

        [Test]
        public static void ulong4()
        {
            Random64 rng = Random64.New;

            ulong4 left  = rng.NextULong4();
            ulong4 right = rng.NextULong4();
            ulong4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (ulong)(left.x + right.x));
            Assert.AreEqual(op.y, (ulong)(left.y - right.y));
            Assert.AreEqual(op.z, (ulong)(left.z + right.z));
            Assert.AreEqual(op.w, (ulong)(left.w - right.w));
        }


        [Test]
        public static void long2()
        {
            Random64 rng = Random64.New;

            long2 left  = rng.NextLong2();
            long2 right = rng.NextLong2();
            long2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (long)(left.x + right.x));
            Assert.AreEqual(op.y, (long)(left.y - right.y));
        }

        [Test]
        public static void long3()
        {
            Random64 rng = Random64.New;

            long3 left  = rng.NextLong3();
            long3 right = rng.NextLong3();
            long3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (long)(left.x + right.x));
            Assert.AreEqual(op.y, (long)(left.y - right.y));
            Assert.AreEqual(op.z, (long)(left.z + right.z));
        }

        [Test]
        public static void long4()
        {
            Random64 rng = Random64.New;

            long4 left  = rng.NextLong4();
            long4 right = rng.NextLong4();
            long4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (long)(left.x + right.x));
            Assert.AreEqual(op.y, (long)(left.y - right.y));
            Assert.AreEqual(op.z, (long)(left.z + right.z));
            Assert.AreEqual(op.w, (long)(left.w - right.w));
        }


        [Test]
        public static void float2()
        {
            Random32 rng = Random32.New;

            float2 left  = rng.NextFloat2();
            float2 right = rng.NextFloat2();
            float2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (float)(left.x + right.x));
            Assert.AreEqual(op.y, (float)(left.y - right.y));
        }

        [Test]
        public static void float3()
        {
            Random32 rng = Random32.New;

            float3 left  = rng.NextFloat3();
            float3 right = rng.NextFloat3();
            float3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (float)(left.x + right.x));
            Assert.AreEqual(op.y, (float)(left.y - right.y));
            Assert.AreEqual(op.z, (float)(left.z + right.z));
        }

        [Test]
        public static void float4()
        {
            Random32 rng = Random32.New;

            float4 left  = rng.NextFloat4();
            float4 right = rng.NextFloat4();
            float4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (float)(left.x + right.x));
            Assert.AreEqual(op.y, (float)(left.y - right.y));
            Assert.AreEqual(op.z, (float)(left.z + right.z));
            Assert.AreEqual(op.w, (float)(left.w - right.w));
        }

        [Test]
        public static void float8()
        {
            Random32 rng = Random32.New;

            float8 left  = rng.NextFloat8();
            float8 right = rng.NextFloat8();
            float8 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x0, (float)(left.x0 + right.x0));
            Assert.AreEqual(op.x1, (float)(left.x1 - right.x1));
            Assert.AreEqual(op.x2, (float)(left.x2 + right.x2));
            Assert.AreEqual(op.x3, (float)(left.x3 - right.x3));
            Assert.AreEqual(op.x4, (float)(left.x4 + right.x4));
            Assert.AreEqual(op.x5, (float)(left.x5 - right.x5));
            Assert.AreEqual(op.x6, (float)(left.x6 + right.x6));
            Assert.AreEqual(op.x7, (float)(left.x7 - right.x7));
        }


        [Test]
        public static void double2()
        {
            Random64 rng = Random64.New;

            double2 left  = rng.NextDouble2();
            double2 right = rng.NextDouble2();
            double2 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (double)(left.x + right.x));
            Assert.AreEqual(op.y, (double)(left.y - right.y));
        }

        [Test]
        public static void double3()
        {
            Random64 rng = Random64.New;

            double3 left  = rng.NextDouble3();
            double3 right = rng.NextDouble3();
            double3 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (double)(left.x + right.x));
            Assert.AreEqual(op.y, (double)(left.y - right.y));
            Assert.AreEqual(op.z, (double)(left.z + right.z));
        }

        [Test]
        public static void double4()
        {
            Random64 rng = Random64.New;

            double4 left  = rng.NextDouble4();
            double4 right = rng.NextDouble4();
            double4 op = maxmath.addsub(left, right);
            
            Assert.AreEqual(op.x, (double)(left.x + right.x));
            Assert.AreEqual(op.y, (double)(left.y - right.y));
            Assert.AreEqual(op.z, (double)(left.z + right.z));
            Assert.AreEqual(op.w, (double)(left.w - right.w));
        }
    }
}