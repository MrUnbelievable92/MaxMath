using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_perm
    {
        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 n = rng.NextULong2(1, 100);
                ulong2 k = rng.NextULong2(0, maxmath.min(rng.NextULong2(0, 100), n));

                ulong2 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);

                p = maxmath.perm(n, new ulong2(1, k.y));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 n = rng.NextULong3(1, 100);
                ulong3 k = rng.NextULong3(0, maxmath.min(rng.NextULong3(0, 100), n));

                ulong3 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, maxmath.perm(n.z, k.z));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);

                p = maxmath.perm(n, new ulong3(1, k.y, 1));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, n.z);
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 n = rng.NextULong4(1, 100);
                ulong4 k = rng.NextULong4(0, maxmath.min(rng.NextULong4(0, 100), n));

                ulong4 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, maxmath.perm(n.z, k.z));
                Assert.AreEqual(p.w, maxmath.perm(n.w, k.w));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, n.w);

                p = maxmath.perm(n, new ulong4(1, k.y, 1, k.w));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, maxmath.perm(n.w, k.w));
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 n = rng.NextUInt2(1, 100);
                uint2 k = rng.NextUInt2(0, math.min(rng.NextUInt2(0, 100), n));

                uint2 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);

                p = maxmath.perm(n, new uint2(1, k.y));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 n = rng.NextUInt3(1, 100);
                uint3 k = rng.NextUInt3(0, math.min(rng.NextUInt3(0, 100), n));

                uint3 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, maxmath.perm(n.z, k.z));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);

                p = maxmath.perm(n, new uint3(1, k.y, 1));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, n.z);
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 n = rng.NextUInt4(1, 100);
                uint4 k = rng.NextUInt4(0, math.min(rng.NextUInt4(0, 100), n));

                uint4 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, maxmath.perm(n.x, k.x));
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, maxmath.perm(n.z, k.z));
                Assert.AreEqual(p.w, maxmath.perm(n.w, k.w));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, n.w);

                p = maxmath.perm(n, new uint4(1, k.y, 1, k.w));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, maxmath.perm(n.y, k.y));
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, maxmath.perm(n.w, k.w));
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 n = rng.NextUInt8(1, 100);
                uint8 k = rng.NextUInt8(0, maxmath.min(rng.NextUInt8(0, 100), n));

                uint8 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0, maxmath.perm(n.x0, k.x0));
                Assert.AreEqual(p.x1, maxmath.perm(n.x1, k.x1));
                Assert.AreEqual(p.x2, maxmath.perm(n.x2, k.x2));
                Assert.AreEqual(p.x3, maxmath.perm(n.x3, k.x3));
                Assert.AreEqual(p.x4, maxmath.perm(n.x4, k.x4));
                Assert.AreEqual(p.x5, maxmath.perm(n.x5, k.x5));
                Assert.AreEqual(p.x6, maxmath.perm(n.x6, k.x6));
                Assert.AreEqual(p.x7, maxmath.perm(n.x7, k.x7));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, n.x1);
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, n.x3);
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, n.x5);
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, n.x7);

                p = maxmath.perm(n, new uint8(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7));

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, maxmath.perm(n.x1, k.x1));
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, maxmath.perm(n.x3, k.x3));
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, maxmath.perm(n.x5, k.x5));
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, maxmath.perm(n.x7, k.x7));
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 n = rng.NextUShort2(1, 100);
                ushort2 k = rng.NextUShort2(0, maxmath.min(rng.NextUShort2(0, 100), n));

                ushort2 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (ushort)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);

                p = maxmath.perm(n, new ushort2(1, k.y));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 n = rng.NextUShort3(1, 100);
                ushort3 k = rng.NextUShort3(0, maxmath.min(rng.NextUShort3(0, 100), n));

                ushort3 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (ushort)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, (ushort)maxmath.perm((uint)n.z, (uint)k.z));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);

                p = maxmath.perm(n, new ushort3(1, k.y, 1));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, n.z);
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 n = rng.NextUShort4(1, 100);
                ushort4 k = rng.NextUShort4(0, maxmath.min(rng.NextUShort4(0, 100), n));

                ushort4 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (ushort)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, (ushort)maxmath.perm((uint)n.z, (uint)k.z));
                Assert.AreEqual(p.w, (ushort)maxmath.perm((uint)n.w, (uint)k.w));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, n.w);

                p = maxmath.perm(n, new ushort4(1, k.y, 1, k.w));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (ushort)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, (ushort)maxmath.perm((uint)n.w, (uint)k.w));
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 n = rng.NextUShort8(1, 100);
                ushort8 k = rng.NextUShort8(0, maxmath.min(rng.NextUShort8(0, 100), n));

                ushort8 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0, (ushort)maxmath.perm((uint)n.x0, (uint)k.x0));
                Assert.AreEqual(p.x1, (ushort)maxmath.perm((uint)n.x1, (uint)k.x1));
                Assert.AreEqual(p.x2, (ushort)maxmath.perm((uint)n.x2, (uint)k.x2));
                Assert.AreEqual(p.x3, (ushort)maxmath.perm((uint)n.x3, (uint)k.x3));
                Assert.AreEqual(p.x4, (ushort)maxmath.perm((uint)n.x4, (uint)k.x4));
                Assert.AreEqual(p.x5, (ushort)maxmath.perm((uint)n.x5, (uint)k.x5));
                Assert.AreEqual(p.x6, (ushort)maxmath.perm((uint)n.x6, (uint)k.x6));
                Assert.AreEqual(p.x7, (ushort)maxmath.perm((uint)n.x7, (uint)k.x7));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, n.x1);
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, n.x3);
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, n.x5);
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, n.x7);

                p = maxmath.perm(n, new ushort8(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7));

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, (ushort)maxmath.perm((uint)n.x1, (uint)k.x1));
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, (ushort)maxmath.perm((uint)n.x3, (uint)k.x3));
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, (ushort)maxmath.perm((uint)n.x5, (uint)k.x5));
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, (ushort)maxmath.perm((uint)n.x7, (uint)k.x7));
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 n = rng.NextUShort16(1, 100);
                ushort16 k = rng.NextUShort16(0, maxmath.min(rng.NextUShort16(0, 100), n));

                ushort16 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0,  (ushort)maxmath.perm((uint)n.x0,  (uint)k.x0));
                Assert.AreEqual(p.x1,  (ushort)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  (ushort)maxmath.perm((uint)n.x2,  (uint)k.x2));
                Assert.AreEqual(p.x3,  (ushort)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  (ushort)maxmath.perm((uint)n.x4,  (uint)k.x4));
                Assert.AreEqual(p.x5,  (ushort)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  (ushort)maxmath.perm((uint)n.x6,  (uint)k.x6));
                Assert.AreEqual(p.x7,  (ushort)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  (ushort)maxmath.perm((uint)n.x8,  (uint)k.x8));
                Assert.AreEqual(p.x9,  (ushort)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, (ushort)maxmath.perm((uint)n.x10, (uint)k.x10));
                Assert.AreEqual(p.x11, (ushort)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, (ushort)maxmath.perm((uint)n.x12, (uint)k.x12));
                Assert.AreEqual(p.x13, (ushort)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, (ushort)maxmath.perm((uint)n.x14, (uint)k.x14));
                Assert.AreEqual(p.x15, (ushort)maxmath.perm((uint)n.x15, (uint)k.x15));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  n.x1);
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  n.x3);
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  n.x5);
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  n.x7);
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  n.x9);
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, n.x11);
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, n.x13);
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, n.x15);

                p = maxmath.perm(n, new ushort16(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7, 1, k.x9, 1, k.x11, 1, k.x13, 1, k.x15));

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  (ushort)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  (ushort)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  (ushort)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  (ushort)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  (ushort)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, (ushort)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, (ushort)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, (ushort)maxmath.perm((uint)n.x15, (uint)k.x15));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 n = rng.NextByte2(1, 100);
                byte2 k = rng.NextByte2(0, maxmath.min(rng.NextByte2(0, 100), n));

                byte2 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (byte)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);

                p = maxmath.perm(n, new byte2(1, k.y));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 n = rng.NextByte3(1, 100);
                byte3 k = rng.NextByte3(0, maxmath.min(rng.NextByte3(0, 100), n));

                byte3 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (byte)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, (byte)maxmath.perm((uint)n.z, (uint)k.z));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);

                p = maxmath.perm(n, new byte3(1, k.y, 1));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, n.z);
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 n = rng.NextByte4(1, 100);
                byte4 k = rng.NextByte4(0, maxmath.min(rng.NextByte4(0, 100), n));

                byte4 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x, (byte)maxmath.perm((uint)n.x, (uint)k.x));
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, (byte)maxmath.perm((uint)n.z, (uint)k.z));
                Assert.AreEqual(p.w, (byte)maxmath.perm((uint)n.w, (uint)k.w));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, n.y);
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, n.w);

                p = maxmath.perm(n, new byte4(1, k.y, 1, k.w));

                Assert.AreEqual(p.x, n.x);
                Assert.AreEqual(p.y, (byte)maxmath.perm((uint)n.y, (uint)k.y));
                Assert.AreEqual(p.z, n.z);
                Assert.AreEqual(p.w, (byte)maxmath.perm((uint)n.w, (uint)k.w));
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 n = rng.NextByte8(1, 100);
                byte8 k = rng.NextByte8(0, maxmath.min(rng.NextByte8(0, 100), n));

                byte8 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0, (byte)maxmath.perm((uint)n.x0, (uint)k.x0));
                Assert.AreEqual(p.x1, (byte)maxmath.perm((uint)n.x1, (uint)k.x1));
                Assert.AreEqual(p.x2, (byte)maxmath.perm((uint)n.x2, (uint)k.x2));
                Assert.AreEqual(p.x3, (byte)maxmath.perm((uint)n.x3, (uint)k.x3));
                Assert.AreEqual(p.x4, (byte)maxmath.perm((uint)n.x4, (uint)k.x4));
                Assert.AreEqual(p.x5, (byte)maxmath.perm((uint)n.x5, (uint)k.x5));
                Assert.AreEqual(p.x6, (byte)maxmath.perm((uint)n.x6, (uint)k.x6));
                Assert.AreEqual(p.x7, (byte)maxmath.perm((uint)n.x7, (uint)k.x7));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, n.x1);
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, n.x3);
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, n.x5);
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, n.x7);

                p = maxmath.perm(n, new byte8(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7));

                Assert.AreEqual(p.x0, n.x0);
                Assert.AreEqual(p.x1, (byte)maxmath.perm((uint)n.x1, (uint)k.x1));
                Assert.AreEqual(p.x2, n.x2);
                Assert.AreEqual(p.x3, (byte)maxmath.perm((uint)n.x3, (uint)k.x3));
                Assert.AreEqual(p.x4, n.x4);
                Assert.AreEqual(p.x5, (byte)maxmath.perm((uint)n.x5, (uint)k.x5));
                Assert.AreEqual(p.x6, n.x6);
                Assert.AreEqual(p.x7, (byte)maxmath.perm((uint)n.x7, (uint)k.x7));
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 n = rng.NextByte16(1, 100);
                byte16 k = rng.NextByte16(0, maxmath.min(rng.NextByte16(0, 100), n));

                byte16 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0,  (byte)maxmath.perm((uint)n.x0,  (uint)k.x0));
                Assert.AreEqual(p.x1,  (byte)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  (byte)maxmath.perm((uint)n.x2,  (uint)k.x2));
                Assert.AreEqual(p.x3,  (byte)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  (byte)maxmath.perm((uint)n.x4,  (uint)k.x4));
                Assert.AreEqual(p.x5,  (byte)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  (byte)maxmath.perm((uint)n.x6,  (uint)k.x6));
                Assert.AreEqual(p.x7,  (byte)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  (byte)maxmath.perm((uint)n.x8,  (uint)k.x8));
                Assert.AreEqual(p.x9,  (byte)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, (byte)maxmath.perm((uint)n.x10, (uint)k.x10));
                Assert.AreEqual(p.x11, (byte)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, (byte)maxmath.perm((uint)n.x12, (uint)k.x12));
                Assert.AreEqual(p.x13, (byte)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, (byte)maxmath.perm((uint)n.x14, (uint)k.x14));
                Assert.AreEqual(p.x15, (byte)maxmath.perm((uint)n.x15, (uint)k.x15));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  n.x1);
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  n.x3);
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  n.x5);
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  n.x7);
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  n.x9);
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, n.x11);
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, n.x13);
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, n.x15);

                p = maxmath.perm(n, new byte16(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7, 1, k.x9, 1, k.x11, 1, k.x13, 1, k.x15));

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  (byte)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  (byte)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  (byte)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  (byte)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  (byte)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, (byte)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, (byte)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, (byte)maxmath.perm((uint)n.x15, (uint)k.x15));
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte32 n = rng.NextByte32(1, 100);
                byte32 k = rng.NextByte32(0, maxmath.min(rng.NextByte32(0, 100), n));

                byte32 p = maxmath.perm(n, k);

                Assert.AreEqual(p.x0,  (byte)maxmath.perm((uint)n.x0,  (uint)k.x0));
                Assert.AreEqual(p.x1,  (byte)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  (byte)maxmath.perm((uint)n.x2,  (uint)k.x2));
                Assert.AreEqual(p.x3,  (byte)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  (byte)maxmath.perm((uint)n.x4,  (uint)k.x4));
                Assert.AreEqual(p.x5,  (byte)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  (byte)maxmath.perm((uint)n.x6,  (uint)k.x6));
                Assert.AreEqual(p.x7,  (byte)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  (byte)maxmath.perm((uint)n.x8,  (uint)k.x8));
                Assert.AreEqual(p.x9,  (byte)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, (byte)maxmath.perm((uint)n.x10, (uint)k.x10));
                Assert.AreEqual(p.x11, (byte)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, (byte)maxmath.perm((uint)n.x12, (uint)k.x12));
                Assert.AreEqual(p.x13, (byte)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, (byte)maxmath.perm((uint)n.x14, (uint)k.x14));
                Assert.AreEqual(p.x15, (byte)maxmath.perm((uint)n.x15, (uint)k.x15));
                Assert.AreEqual(p.x16, (byte)maxmath.perm((uint)n.x16, (uint)k.x16));
                Assert.AreEqual(p.x17, (byte)maxmath.perm((uint)n.x17, (uint)k.x17));
                Assert.AreEqual(p.x18, (byte)maxmath.perm((uint)n.x18, (uint)k.x18));
                Assert.AreEqual(p.x19, (byte)maxmath.perm((uint)n.x19, (uint)k.x19));
                Assert.AreEqual(p.x20, (byte)maxmath.perm((uint)n.x20, (uint)k.x20));
                Assert.AreEqual(p.x21, (byte)maxmath.perm((uint)n.x21, (uint)k.x21));
                Assert.AreEqual(p.x22, (byte)maxmath.perm((uint)n.x22, (uint)k.x22));
                Assert.AreEqual(p.x23, (byte)maxmath.perm((uint)n.x23, (uint)k.x23));
                Assert.AreEqual(p.x24, (byte)maxmath.perm((uint)n.x24, (uint)k.x24));
                Assert.AreEqual(p.x25, (byte)maxmath.perm((uint)n.x25, (uint)k.x25));
                Assert.AreEqual(p.x26, (byte)maxmath.perm((uint)n.x26, (uint)k.x26));
                Assert.AreEqual(p.x27, (byte)maxmath.perm((uint)n.x27, (uint)k.x27));
                Assert.AreEqual(p.x28, (byte)maxmath.perm((uint)n.x28, (uint)k.x28));
                Assert.AreEqual(p.x29, (byte)maxmath.perm((uint)n.x29, (uint)k.x29));
                Assert.AreEqual(p.x30, (byte)maxmath.perm((uint)n.x30, (uint)k.x30));
                Assert.AreEqual(p.x31, (byte)maxmath.perm((uint)n.x31, (uint)k.x31));

                p = maxmath.perm(n, 1);

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  n.x1);
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  n.x3);
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  n.x5);
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  n.x7);
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  n.x9);
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, n.x11);
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, n.x13);
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, n.x15);
                Assert.AreEqual(p.x16, n.x16);
                Assert.AreEqual(p.x17, n.x17);
                Assert.AreEqual(p.x18, n.x18);
                Assert.AreEqual(p.x19, n.x19);
                Assert.AreEqual(p.x20, n.x20);
                Assert.AreEqual(p.x21, n.x21);
                Assert.AreEqual(p.x22, n.x22);
                Assert.AreEqual(p.x23, n.x23);
                Assert.AreEqual(p.x24, n.x24);
                Assert.AreEqual(p.x25, n.x25);
                Assert.AreEqual(p.x26, n.x26);
                Assert.AreEqual(p.x27, n.x27);
                Assert.AreEqual(p.x28, n.x28);
                Assert.AreEqual(p.x29, n.x29);
                Assert.AreEqual(p.x30, n.x30);
                Assert.AreEqual(p.x31, n.x31);

                p = maxmath.perm(n, new byte32(1, k.x1, 1, k.x3, 1, k.x5, 1, k.x7, 1, k.x9, 1, k.x11, 1, k.x13, 1, k.x15, 1, k.x17, 1, k.x19, 1, k.x21, 1, k.x23, 1, k.x25, 1, k.x27, 1, k.x29, 1, k.x31));

                Assert.AreEqual(p.x0,  n.x0);
                Assert.AreEqual(p.x1,  (byte)maxmath.perm((uint)n.x1,  (uint)k.x1));
                Assert.AreEqual(p.x2,  n.x2);
                Assert.AreEqual(p.x3,  (byte)maxmath.perm((uint)n.x3,  (uint)k.x3));
                Assert.AreEqual(p.x4,  n.x4);
                Assert.AreEqual(p.x5,  (byte)maxmath.perm((uint)n.x5,  (uint)k.x5));
                Assert.AreEqual(p.x6,  n.x6);
                Assert.AreEqual(p.x7,  (byte)maxmath.perm((uint)n.x7,  (uint)k.x7));
                Assert.AreEqual(p.x8,  n.x8);
                Assert.AreEqual(p.x9,  (byte)maxmath.perm((uint)n.x9,  (uint)k.x9));
                Assert.AreEqual(p.x10, n.x10);
                Assert.AreEqual(p.x11, (byte)maxmath.perm((uint)n.x11, (uint)k.x11));
                Assert.AreEqual(p.x12, n.x12);
                Assert.AreEqual(p.x13, (byte)maxmath.perm((uint)n.x13, (uint)k.x13));
                Assert.AreEqual(p.x14, n.x14);
                Assert.AreEqual(p.x15, (byte)maxmath.perm((uint)n.x15, (uint)k.x15));
                Assert.AreEqual(p.x16, n.x16);
                Assert.AreEqual(p.x17, (byte)maxmath.perm((uint)n.x17, (uint)k.x17));
                Assert.AreEqual(p.x18, n.x18);
                Assert.AreEqual(p.x19, (byte)maxmath.perm((uint)n.x19, (uint)k.x19));
                Assert.AreEqual(p.x20, n.x20);
                Assert.AreEqual(p.x21, (byte)maxmath.perm((uint)n.x21, (uint)k.x21));
                Assert.AreEqual(p.x22, n.x22);
                Assert.AreEqual(p.x23, (byte)maxmath.perm((uint)n.x23, (uint)k.x23));
                Assert.AreEqual(p.x24, n.x24);
                Assert.AreEqual(p.x25, (byte)maxmath.perm((uint)n.x25, (uint)k.x25));
                Assert.AreEqual(p.x26, n.x26);
                Assert.AreEqual(p.x27, (byte)maxmath.perm((uint)n.x27, (uint)k.x27));
                Assert.AreEqual(p.x28, n.x28);
                Assert.AreEqual(p.x29, (byte)maxmath.perm((uint)n.x29, (uint)k.x29));
                Assert.AreEqual(p.x30, n.x30);
                Assert.AreEqual(p.x31, (byte)maxmath.perm((uint)n.x31, (uint)k.x31));
            }
        }
    }
}
