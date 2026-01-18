using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_bits_select
    {
        private static void TestSelect(UInt128 a, UInt128 b, UInt128 c, UInt128 testResult)
        {
            for (int i = 0; i < 128; i++)
            {
                UInt128 bit = (UInt128)1 << i;
                if ((c & bit) == 0)
                {
                    Assert.AreEqual((testResult & bit), (a & bit));
                }
                else
                {
                    Assert.AreEqual((testResult & bit), (b & bit));
                }
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 r = Random128.New;

            for (int i = 0; i < 12; i++)
            {
                UInt128 a = r.NextUInt128();
                UInt128 b = r.NextUInt128();
                UInt128 c = r.NextUInt128();

                TestSelect(a, b, c, maxmath.bits_select(a, b, c));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte a = r.NextByte();
                byte b = r.NextByte();
                byte c = r.NextByte();

                TestSelect(a, b, c, maxmath.bits_select(a, b, c));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 a = r.NextByte2();
                byte2 b = r.NextByte2();
                byte2 c = r.NextByte2();
                byte2 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 2; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte3 a = r.NextByte3();
                byte3 b = r.NextByte3();
                byte3 c = r.NextByte3();
                byte3 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 3; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte4 a = r.NextByte4();
                byte4 b = r.NextByte4();
                byte4 c = r.NextByte4();
                byte4 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 4; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte8 a = r.NextByte8();
                byte8 b = r.NextByte8();
                byte8 c = r.NextByte8();
                byte8 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 8; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte16 a = r.NextByte16();
                byte16 b = r.NextByte16();
                byte16 c = r.NextByte16();
                byte16 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 16; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte32 a = r.NextByte32();
                byte32 b = r.NextByte32();
                byte32 c = r.NextByte32();
                byte32 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 32; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort a = r.NextUShort();
                ushort b = r.NextUShort();
                ushort c = r.NextUShort();

                TestSelect(a, b, c, maxmath.bits_select(a, b, c));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 a = r.NextUShort2();
                ushort2 b = r.NextUShort2();
                ushort2 c = r.NextUShort2();
                ushort2 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 2; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort3 a = r.NextUShort3();
                ushort3 b = r.NextUShort3();
                ushort3 c = r.NextUShort3();
                ushort3 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 3; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort4 a = r.NextUShort4();
                ushort4 b = r.NextUShort4();
                ushort4 c = r.NextUShort4();
                ushort4 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 4; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort8 a = r.NextUShort8();
                ushort8 b = r.NextUShort8();
                ushort8 c = r.NextUShort8();
                ushort8 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 8; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort16 a = r.NextUShort16();
                ushort16 b = r.NextUShort16();
                ushort16 c = r.NextUShort16();
                ushort16 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 16; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint a = r.NextUInt();
                uint b = r.NextUInt();
                uint c = r.NextUInt();

                TestSelect(a, b, c, maxmath.bits_select(a, b, c));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 a = r.NextUInt2();
                uint2 b = r.NextUInt2();
                uint2 c = r.NextUInt2();
                uint2 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 2; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint3 a = r.NextUInt3();
                uint3 b = r.NextUInt3();
                uint3 c = r.NextUInt3();
                uint3 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 3; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint4 a = r.NextUInt4();
                uint4 b = r.NextUInt4();
                uint4 c = r.NextUInt4();
                uint4 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 4; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint8 a = r.NextUInt8();
                uint8 b = r.NextUInt8();
                uint8 c = r.NextUInt8();
                uint8 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 8; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong a = r.NextULong();
                ulong b = r.NextULong();
                ulong c = r.NextULong();

                TestSelect(a, b, c, maxmath.bits_select(a, b, c));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 a = r.NextULong2();
                ulong2 b = r.NextULong2();
                ulong2 c = r.NextULong2();
                ulong2 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 2; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong3 a = r.NextULong3();
                ulong3 b = r.NextULong3();
                ulong3 c = r.NextULong3();
                ulong3 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 3; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong4 a = r.NextULong4();
                ulong4 b = r.NextULong4();
                ulong4 c = r.NextULong4();
                ulong4 test = maxmath.bits_select(a, b, c);

                for (int j = 0; j < 4; j++)
                {
                    TestSelect(a[j], b[j], c[j], test[j]);
                }
            }
        }
    }
}
