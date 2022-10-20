using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class bits_extract
    {
        [Test]
        public static void _uint128()
        {
            Random128 r = Random128.New;
            
            for (int i = 0; i < 12; i++)
            {
                UInt128 val = r.NextUInt128();
                UInt128 length = r.NextUInt128(1, 127);
                UInt128 idx = r.NextUInt128(0, (byte)(128 + 1 - length));
                UInt128 res = maxmath.bits_extract(val, (int)idx, (int)length);

                for (int j = 0; j < length; j++)
                {
                    Assert.AreEqual(maxmath.testbit(val, (uint)(idx + j)), maxmath.testbit(res, (uint)j));
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
                byte length = r.NextByte(1, 7);
                byte idx = r.NextByte(0, (byte)(8 + 1 - length));

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val, idx, length), maxmath.bits_extract(val, idx, length));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 val = r.NextByte2();
                byte2 length = r.NextByte2(1, 7);
                byte2 idx = r.NextByte2(0, 8 + 1 - length);

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                byte3 length = r.NextByte3(1, 7);
                byte3 idx = r.NextByte3(0, 8 + 1 - length);

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                byte4 length = r.NextByte4(1, 7);
                byte4 idx = r.NextByte4(0, 8 + 1 - length);

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                byte8 length = r.NextByte8(1, 7);
                byte8 idx = r.NextByte8(0, 8 + 1 - length);

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                byte16 length = r.NextByte16(1, 7);
                byte16 idx = r.NextByte16(0, 8 + 1 - length);

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                byte32 length = r.NextByte32(1, 7);
                byte32 idx = r.NextByte32(0, 8 + 1 - length);

                for (int k = 0; k < 32; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ushort length = r.NextUShort(1, 15);
                ushort idx = r.NextUShort(0, (ushort)(16 + 1 - length));

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val, idx, length), maxmath.bits_extract(val, idx, length));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 val = r.NextUShort2();
                ushort2 length = r.NextUShort2(1, 15);
                ushort2 idx = r.NextUShort2(0, 16 + 1 - length);

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ushort3 length = r.NextUShort3(1, 15);
                ushort3 idx = r.NextUShort3(0, 16 + 1 - length);

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ushort4 length = r.NextUShort4(1, 15);
                ushort4 idx = r.NextUShort4(0, 16 + 1 - length);

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ushort8 length = r.NextUShort8(1, 15);
                ushort8 idx = r.NextUShort8(0, 16 + 1 - length);

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ushort16 length = r.NextUShort16(1, 15);
                ushort16 idx = r.NextUShort16(0, 16 + 1 - length);

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                uint length = r.NextUInt(1, 31);
                uint idx = r.NextUInt(0, (uint)(32 + 1 - length));

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val, idx, length), maxmath.bits_extract(val, (int)idx, (int)length));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 val = r.NextUInt2();
                uint2 length = r.NextUInt2(1, 31);
                uint2 idx = r.NextUInt2(0, 32 + 1 - length);

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                uint3 length = r.NextUInt3(1, 31);
                uint3 idx = r.NextUInt3(0, 32 + 1 - length);

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                uint4 length = r.NextUInt4(1, 31);
                uint4 idx = r.NextUInt4(0, 32 + 1 - length);

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                uint8 length = r.NextUInt8(1, 31);
                uint8 idx = r.NextUInt8(0, 32 + 1 - length);

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], idx[k], length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ulong length = r.NextULong(1, 63);
                ulong idx = r.NextULong(0, (ulong)(64 + 1 - length));

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val, (uint)idx, (uint)length), maxmath.bits_extract(val, (int)idx, (int)length));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 val = r.NextULong2();
                ulong2 length = r.NextULong2(1, 63);
                ulong2 idx = r.NextULong2(0, 64 + 1 - length);

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], (uint)idx[k], (uint)length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ulong3 length = r.NextULong3(1, 63);
                ulong3 idx = r.NextULong3(0, 64 + 1 - length);

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], (uint)idx[k], (uint)length[k]), maxmath.bits_extract(val, idx, length)[k]);
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
                ulong4 length = r.NextULong4(1, 63);
                ulong4 idx = r.NextULong4(0, 64 + 1 - length);

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.bextr_u64(val[k], (uint)idx[k], (uint)length[k]), maxmath.bits_extract(val, idx, length)[k]);
                }
            }
        }
    }
}
