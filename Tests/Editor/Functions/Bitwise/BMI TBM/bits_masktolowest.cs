using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_bits_masktolowest
    {
        [Test]
        public static void _UInt128()
        {
            Random128 r = Random128.New;

            for (int i = 0; i < 12; i++)
            {
                UInt128 val = r.NextUInt128();

                Assert.AreEqual(maxmath.tzcnt(val << 1), maxmath.tzcnt(~maxmath.bits_masktolowest(val)));
                Assert.AreEqual(maxmath.tzcnt(val << 1), maxmath.countbits(maxmath.bits_masktolowest(val)));
            }
        }


        [Test]
        public static void _byte()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte val = r.NextByte();

                Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val), maxmath.bits_masktolowest(val));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 val = r.NextByte2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 32; k++)
                {
                    Assert.AreEqual((byte)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val), maxmath.bits_masktolowest(val));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 val = r.NextUShort2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual((ushort)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                Assert.AreEqual((uint)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val), maxmath.bits_masktolowest(val));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 val = r.NextUInt2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual((uint)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual((uint)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual((uint)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual((uint)Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val), maxmath.bits_masktolowest(val));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 val = r.NextULong2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
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

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi1.blsmsk_u64(val[k]), maxmath.bits_masktolowest(val)[k]);
                }
            }
        }
    }
}
