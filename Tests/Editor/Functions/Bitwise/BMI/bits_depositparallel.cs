using System.Collections.Generic;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class bits_depositparallel
    {
        [Test]
        public static void _uint128()
        {
            Random128 r = Random128.New;
            
            for (int i = 0; i < 12; i++)
            {
                UInt128 val = r.NextUInt128();
                UInt128 idx = r.NextUInt128();
                UInt128 res = maxmath.bits_depositparallel(val, idx);

                List<int> oneBitsInMask = new List<int>(1);

                for (int j = 0; j < 128; j++)
                {
                    if (maxmath.testbit(idx, (uint)j))
                    {
                        oneBitsInMask.Add(j);
                    }
                }

                int current = 0;

                for (int j = 0; j < oneBitsInMask.Count; j++)
                {
                    Assert.AreEqual(maxmath.testbit(val, (uint)current), maxmath.testbit(res, (uint)oneBitsInMask[j])); 

                    current++;
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
                byte idx = r.NextByte();

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val, idx), maxmath.bits_depositparallel(val, idx));
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 r = Random8.New;

            for (int i = 0; i < 12; i++)
            {
                byte2 val = r.NextByte2();
                byte2 idx = r.NextByte2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                byte3 idx = r.NextByte3();

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                byte4 idx = r.NextByte4();

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                byte8 idx = r.NextByte8();

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                byte16 idx = r.NextByte16();

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                byte32 idx = r.NextByte32();

                for (int k = 0; k < 32; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ushort idx = r.NextUShort();

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val, idx), maxmath.bits_depositparallel(val, idx));
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 r = Random16.New;

            for (int i = 0; i < 12; i++)
            {
                ushort2 val = r.NextUShort2();
                ushort2 idx = r.NextUShort2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ushort3 idx = r.NextUShort3();

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ushort4 idx = r.NextUShort4();

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ushort8 idx = r.NextUShort8();

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ushort16 idx = r.NextUShort16();

                for (int k = 0; k < 16; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                uint idx = r.NextUInt();

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val, idx), maxmath.bits_depositparallel(val, idx));
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 r = Random32.New;

            for (int i = 0; i < 12; i++)
            {
                uint2 val = r.NextUInt2();
                uint2 idx = r.NextUInt2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                uint3 idx = r.NextUInt3();

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                uint4 idx = r.NextUInt4();

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                uint8 idx = r.NextUInt8();

                for (int k = 0; k < 8; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ulong idx = r.NextULong();

                Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val, idx), maxmath.bits_depositparallel(val, idx));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 r = Random64.New;

            for (int i = 0; i < 12; i++)
            {
                ulong2 val = r.NextULong2();
                ulong2 idx = r.NextULong2();

                for (int k = 0; k < 2; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ulong3 idx = r.NextULong3();

                for (int k = 0; k < 3; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
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
                ulong4 idx = r.NextULong4();

                for (int k = 0; k < 4; k++)
                {
                    Assert.AreEqual(Unity.Burst.Intrinsics.X86.Bmi2.pdep_u64(val[k], idx[k]), maxmath.bits_depositparallel(val, idx)[k]);
                }
            }
        }
    }
}
