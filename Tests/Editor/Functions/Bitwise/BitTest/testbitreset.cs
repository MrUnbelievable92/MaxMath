using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class testbitreset
    {
        private static bool btr(ref UInt128 x, int i)
        {
            UInt128 mask = (UInt128)1 << i;
            bool ret = (x & mask) != 0;
            x &= ~mask;

            return ret;
        }
        private static bool btr(ref ulong x, int i)
        {
            ulong mask = (ulong)1 << i;
            bool ret = (x & mask) != 0;
            x &= ~mask;

            return ret;
        }
        private static bool btr(ref uint x, int i)
        {
            uint mask = (uint)1 << i;
            bool ret = (x & mask) != 0;
            x &= ~mask;

            return ret;
        }
        private static bool btr(ref ushort x, int i)
        {
            uint mask = (uint)1 << i;
            bool ret = (x & mask) != 0;
            x &= (ushort)~mask;

            return ret;
        }
        private static bool btr(ref byte x, int i)
        {
            uint mask = (uint)1 << i;
            bool ret = (x & mask) != 0;
            x &= (byte)~mask;

            return ret;
        }

        
        [Test]
        public static void _uint128()
        {
            Random128 r = Random128.New;

            for (int i = 0; i < 12; i++)
            {
                UInt128 val = r.NextUInt128();

                for (int j = 0; j < 128; j++)
                {
                    bool test = maxmath.testbit(val, (uint)j);
                    Assert.AreEqual(btr(ref val, j), test);
                    Assert.IsFalse(maxmath.testbit(val, (uint)j));
                }
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte val = r.NextByte();

                for (int j = 0; j < 8; j++)
                {
                    bool test = maxmath.testbit(val, (uint)j);
                    Assert.AreEqual(btr(ref val, j), test);
                    Assert.IsFalse(maxmath.testbit(val, (uint)j));
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 val = r.NextByte2();
                byte2 idx = r.NextByte2(0, 8);
                bool2 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 2; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte3 val = r.NextByte3();
                byte3 idx = r.NextByte3(0, 8);
                bool3 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 3; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte4 val = r.NextByte4();
                byte4 idx = r.NextByte4(0, 8);
                bool4 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 4; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte8 val = r.NextByte8();
                byte8 idx = r.NextByte8(0, 8);
                bool8 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 8; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte16 val = r.NextByte16();
                byte16 idx = r.NextByte16(0, 8);
                bool16 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 16; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte32 val = r.NextByte32();
                byte32 idx = r.NextByte32(0, 8);
                bool32 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 32; k++)
                {
                    byte b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort val = r.NextUShort();

                for (int j = 0; j < 16; j++)
                {
                    bool test = maxmath.testbit(val, (uint)j);
                    Assert.AreEqual(btr(ref val, j), test);
                    Assert.IsFalse(maxmath.testbit(val, (uint)j));
                }
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 val = r.NextUShort2();
                ushort2 idx = r.NextUShort2(0, 16);
                bool2 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 2; k++)
                {
                    ushort b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort3 val = r.NextUShort3();
                ushort3 idx = r.NextUShort3(0, 16);
                bool3 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 3; k++)
                {
                    ushort b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort4 val = r.NextUShort4();
                ushort4 idx = r.NextUShort4(0, 16);
                bool4 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 4; k++)
                {
                    ushort b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort8 val = r.NextUShort8();
                ushort8 idx = r.NextUShort8(0, 16);
                bool8 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 8; k++)
                {
                    ushort b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort16 val = r.NextUShort16();
                ushort16 idx = r.NextUShort16(0, 16);
                bool16 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 16; k++)
                {
                    ushort b = val[k];
                    Assert.AreEqual(btr(ref b, idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        
        [Test]
        public static void _uint()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint val = r.NextUInt();

                for (int j = 0; j < 32; j++)
                {
                    bool test = maxmath.testbit(val, (uint)j);
                    Assert.AreEqual(btr(ref val, j), test);
                    Assert.IsFalse(maxmath.testbit(val, (uint)j));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 val = r.NextUInt2();
                uint2 idx = r.NextUInt2(0, 32);
                bool2 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 2; k++)
                {
                    uint b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint3 val = r.NextUInt3();
                uint3 idx = r.NextUInt3(0, 32);
                bool3 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 3; k++)
                {
                    uint b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint4 val = r.NextUInt4();
                uint4 idx = r.NextUInt4(0, 32);
                bool4 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 4; k++)
                {
                    uint b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint8 val = r.NextUInt8();
                uint8 idx = r.NextUInt8(0, 32);
                bool8 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 8; k++)
                {
                    uint b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong val = r.NextULong();

                for (int j = 0; j < 64; j++)
                {
                    bool test = maxmath.testbit(val, (ulong)j);
                    Assert.AreEqual(btr(ref val, j), test);
                    Assert.IsFalse(maxmath.testbit(val, (ulong)j));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 val = r.NextULong2();
                ulong2 idx = r.NextULong2(0, 64);
                bool2 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 2; k++)
                {
                    ulong b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong3 val = r.NextULong3();
                ulong3 idx = r.NextULong3(0, 64);
                bool3 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 3; k++)
                {
                    ulong b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong4 val = r.NextULong4();
                ulong4 idx = r.NextULong4(0, 64);
                bool4 res = maxmath.testbit(val, idx);

                for (int k = 0; k < 4; k++)
                {
                    ulong b = val[k];
                    Assert.AreEqual(btr(ref b, (int)idx[k]), res[k]);
                    val[k] = b;
                    Assert.IsFalse(maxmath.testbit(val[k], idx[k]));
                }
            }
        }
    }
}
