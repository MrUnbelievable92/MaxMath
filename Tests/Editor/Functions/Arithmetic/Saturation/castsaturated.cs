#pragma warning disable CS0652

using System.Numerics;
using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_tobytesaturated
    {
        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tobytesaturated(sb), (byte)(sb < byte.MinValue ? byte.MinValue : sb > byte.MaxValue ? byte.MaxValue : (byte)sb));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 sb = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(sb)[j], (byte)(sb[j] < byte.MinValue ? byte.MinValue : sb[j] > byte.MaxValue ? byte.MaxValue : (byte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 _0 = rng.NextUShort8();
                ushort8 _1 = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _short8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ushort16x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 _0 = rng.NextUShort16();
                ushort16 _1 = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 16], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _short16x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 _0 = rng.NextShort16();
                short16 _1 = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 16], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _int8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                uint8 _2 = rng.NextUInt8();
                uint8 _3 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _int8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                int8 _2 = rng.NextInt8();
                int8 _3 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _uint4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _int4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _long4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                ulong4 _4 = rng.NextULong4();
                ulong4 _5 = rng.NextULong4();
                ulong4 _6 = rng.NextULong4();
                ulong4 _7 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j]));
                }
            }
        }

        [Test]
        public static void _long4x8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                long4 _4 = rng.NextLong4();
                long4 _5 = rng.NextLong4();
                long4 _6 = rng.NextLong4();
                long4 _7 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j]));
                }
            }
        }

        [Test]
        public static void _quarter8x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _quarter8x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                quarter8 _2 = maxmath.asquarter(rng.NextByte8());
                quarter8 _3 = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _quarter4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }


        [Test]
        public static void _half8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _half8x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                half8 _2 = maxmath.ashalf(rng.NextUShort8());
                half8 _3 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _half4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _2 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _3 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 16], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 24], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }
            }
        }

        [Test]
        public static void _double4x8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _4 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _5 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _6 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _7 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (byte)(_0[j] < byte.MinValue ? byte.MinValue : _0[j] > byte.MaxValue ? byte.MaxValue : (byte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (byte)(_1[j] < byte.MinValue ? byte.MinValue : _1[j] > byte.MaxValue ? byte.MaxValue : (byte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (byte)(_2[j] < byte.MinValue ? byte.MinValue : _2[j] > byte.MaxValue ? byte.MaxValue : (byte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (byte)(_3[j] < byte.MinValue ? byte.MinValue : _3[j] > byte.MaxValue ? byte.MaxValue : (byte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (byte)(_4[j] < byte.MinValue ? byte.MinValue : _4[j] > byte.MaxValue ? byte.MaxValue : (byte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (byte)(_5[j] < byte.MinValue ? byte.MinValue : _5[j] > byte.MaxValue ? byte.MaxValue : (byte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (byte)(_6[j] < byte.MinValue ? byte.MinValue : _6[j] > byte.MaxValue ? byte.MaxValue : (byte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tobytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (byte)(_7[j] < byte.MinValue ? byte.MinValue : _7[j] > byte.MaxValue ? byte.MaxValue : (byte)_7[j]));
                }
            }
        }
    }

    unsafe public static class f_tosbytesaturated
    {
        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte sb = rng.NextByte();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)((Int128)sb < sbyte.MinValue ? sbyte.MinValue : (Int128)sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)((BigInteger)sb < sbyte.MinValue ? sbyte.MinValue : (BigInteger)sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }


        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tosbytesaturated(sb), (sbyte)(sb < sbyte.MinValue ? sbyte.MinValue : sb > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb));
            }
        }


        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 sb = rng.NextByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 sb = rng.NextByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 sb = rng.NextByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)((Int128)sb[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 sb = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte16 sb = rng.NextByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(sb)[j], (sbyte)(sb[j] < sbyte.MinValue ? sbyte.MinValue : sb[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 _0 = rng.NextUShort8();
                ushort8 _1 = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _short8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ushort16x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 _0 = rng.NextUShort16();
                ushort16 _1 = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 16], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _short16x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 _0 = rng.NextShort16();
                short16 _1 = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 16], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _int8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();
                uint8 _2 = rng.NextUInt8();
                uint8 _3 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _int8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();
                int8 _2 = rng.NextInt8();
                int8 _3 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _uint4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _int4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)((Int128)_2[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)((Int128)_3[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _long4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();
                ulong4 _4 = rng.NextULong4();
                ulong4 _5 = rng.NextULong4();
                ulong4 _6 = rng.NextULong4();
                ulong4 _7 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)((Int128)_0[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)((Int128)_1[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)((Int128)_2[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)((Int128)_3[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)((Int128)_4[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)((Int128)_5[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)((Int128)_6[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)((Int128)_7[j] < sbyte.MinValue ? sbyte.MinValue : (Int128)_7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j]));
                }
            }
        }

        [Test]
        public static void _long4x8()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();
                long4 _4 = rng.NextLong4();
                long4 _5 = rng.NextLong4();
                long4 _6 = rng.NextLong4();
                long4 _7 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)(_4[j] < sbyte.MinValue ? sbyte.MinValue : _4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)(_5[j] < sbyte.MinValue ? sbyte.MinValue : _5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)(_6[j] < sbyte.MinValue ? sbyte.MinValue : _6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)(_7[j] < sbyte.MinValue ? sbyte.MinValue : _7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j]));
                }
            }
        }


        [Test]
        public static void _quarter8x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _quarter8x4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());
                quarter8 _2 = maxmath.asquarter(rng.NextByte8());
                quarter8 _3 = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _quarter4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }


        [Test]
        public static void _half8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _half8x4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());
                half8 _2 = maxmath.ashalf(rng.NextUShort8());
                half8 _3 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_2[j]))
                    {
                        _2[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_3[j]))
                    {
                        _3[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _half4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _2 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _3 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 16], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 24], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }
            }
        }

        [Test]
        public static void _double4x8()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _4 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _5 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _6 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _7 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j], (sbyte)(_0[j] < sbyte.MinValue ? sbyte.MinValue : _0[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 4], (sbyte)(_1[j] < sbyte.MinValue ? sbyte.MinValue : _1[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 8], (sbyte)(_2[j] < sbyte.MinValue ? sbyte.MinValue : _2[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 12], (sbyte)(_3[j] < sbyte.MinValue ? sbyte.MinValue : _3[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_3[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 16], (sbyte)(_4[j] < sbyte.MinValue ? sbyte.MinValue : _4[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_4[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 20], (sbyte)(_5[j] < sbyte.MinValue ? sbyte.MinValue : _5[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_5[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 24], (sbyte)(_6[j] < sbyte.MinValue ? sbyte.MinValue : _6[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_6[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tosbytesaturated(_0, _1, _2, _3, _4, _5, _6, _7)[j + 28], (sbyte)(_7[j] < sbyte.MinValue ? sbyte.MinValue : _7[j] > sbyte.MaxValue ? sbyte.MaxValue : (sbyte)_7[j]));
                }
            }
        }
    }

    unsafe public static class f_toushortsaturated
    {
        [Test]
        public static void _sbytetoushort()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _shorttoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _inttoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _longtoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _Int128toushort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }


        [Test]
        public static void _ushorttoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _uinttoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _ulongtoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _UInt128toushort()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }


        [Test]
        public static void _quartertoushort()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _halftoushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _floattoushort()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }

        [Test]
        public static void _doubletoushort()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toushortsaturated(sb), (ushort)(sb < ushort.MinValue ? ushort.MinValue : sb > ushort.MaxValue ? ushort.MaxValue : (ushort)sb));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte16 sb = rng.NextSByte16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short16 sb = rng.NextShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(sb)[j], (ushort)(sb[j] < ushort.MinValue ? ushort.MinValue : sb[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 _0 = rng.NextShort8();
                short8 _1 = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _int8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _int4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j]));
                }
            }
        }

        [Test]
        public static void _long4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j]));
                }
            }
        }

        [Test]
        public static void _quarter8x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 _0 = maxmath.asquarter(rng.NextByte8());
                quarter8 _1 = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.asquarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _quarter4x2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 _0 = maxmath.asquarter(rng.NextByte4());
                quarter4 _1 = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }


        [Test]
        public static void _half8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _half4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 8], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j], (ushort)(_0[j] < ushort.MinValue ? ushort.MinValue : _0[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 4], (ushort)(_1[j] < ushort.MinValue ? ushort.MinValue : _1[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 8], (ushort)(_2[j] < ushort.MinValue ? ushort.MinValue : _2[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toushortsaturated(_0, _1, _2, _3)[j + 12], (ushort)(_3[j] < ushort.MinValue ? ushort.MinValue : _3[j] > ushort.MaxValue ? ushort.MaxValue : (ushort)_3[j]));
                }
            }
        }
    }

    unsafe public static class f_toshortsaturated
    {
        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)((Int128)sb < short.MinValue ? short.MinValue : (Int128)sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)((BigInteger)sb < short.MinValue ? short.MinValue : (BigInteger)sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }


        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toshortsaturated(sb), (short)(sb < short.MinValue ? short.MinValue : sb > short.MaxValue ? short.MaxValue : (short)sb));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)((Int128)sb[j] < short.MinValue ? short.MinValue : (Int128)sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort16 sb = rng.NextUShort16();

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(sb)[j], (short)(sb[j] < short.MinValue ? short.MinValue : sb[j] > short.MaxValue ? short.MaxValue : (short)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 _0 = rng.NextUInt8();
                uint8 _1 = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _int8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 _0 = rng.NextInt8();
                int8 _1 = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _uint4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 _0 = rng.NextUInt4();
                uint4 _1 = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _int4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 _0 = rng.NextInt4();
                int4 _1 = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)((Int128)_0[j] < short.MinValue ? short.MinValue : (Int128)_0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)((Int128)_1[j] < short.MinValue ? short.MinValue : (Int128)_1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _ulong4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();
                ulong4 _2 = rng.NextULong4();
                ulong4 _3 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)((Int128)_0[j] < short.MinValue ? short.MinValue : (Int128)_0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)((Int128)_1[j] < short.MinValue ? short.MinValue : (Int128)_1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)((Int128)_2[j] < short.MinValue ? short.MinValue : (Int128)_2[j] > short.MaxValue ? short.MaxValue : (short)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)((Int128)_3[j] < short.MinValue ? short.MinValue : (Int128)_3[j] > short.MaxValue ? short.MaxValue : (short)_3[j]));
                }
            }
        }

        [Test]
        public static void _long4x4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();
                long4 _2 = rng.NextLong4();
                long4 _3 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)(_2[j] < short.MinValue ? short.MinValue : _2[j] > short.MaxValue ? short.MaxValue : (short)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)(_3[j] < short.MinValue ? short.MinValue : _3[j] > short.MaxValue ? short.MaxValue : (short)_3[j]));
                }
            }
        }


        [Test]
        public static void _half8x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 _0 = maxmath.ashalf(rng.NextUShort8());
                half8 _1 = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _half4x2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 _0 = maxmath.ashalf(rng.NextUShort4());
                half4 _1 = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_0[j]))
                    {
                        _0[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(_1[j]))
                    {
                        _1[j] = maxmath.ashalf(rng.NextUShort());
                    }

                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _float8x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 _0 = rng.NextFloat8(float.MinValue, float.MaxValue);
                float8 _1 = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 8], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _float4x2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 _0 = rng.NextFloat4(float.MinValue, float.MaxValue);
                float4 _1 = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _2 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _3 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j], (short)(_0[j] < short.MinValue ? short.MinValue : _0[j] > short.MaxValue ? short.MaxValue : (short)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 4], (short)(_1[j] < short.MinValue ? short.MinValue : _1[j] > short.MaxValue ? short.MaxValue : (short)_1[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 8], (short)(_2[j] < short.MinValue ? short.MinValue : _2[j] > short.MaxValue ? short.MaxValue : (short)_2[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toshortsaturated(_0, _1, _2, _3)[j + 12], (short)(_3[j] < short.MinValue ? short.MinValue : _3[j] > short.MaxValue ? short.MaxValue : (short)_3[j]));
                }
            }
        }
    }

    unsafe public static class f_touintsaturated
    {
        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }


        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.touintsaturated(sb), (uint)(sb < uint.MinValue ? uint.MinValue : sb > uint.MaxValue ? uint.MaxValue : (uint)sb));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter8 sb = maxmath.asquarter(rng.NextByte8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(sb)[j], (uint)(sb[j] < uint.MinValue ? uint.MinValue : sb[j] > uint.MaxValue ? uint.MaxValue : (uint)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j], (uint)(_0[j] < uint.MinValue ? uint.MinValue : _0[j] > uint.MaxValue ? uint.MaxValue : (uint)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.touintsaturated(_0, _1)[j + 4], (uint)(_1[j] < uint.MinValue ? uint.MinValue : _1[j] > uint.MaxValue ? uint.MaxValue : (uint)_1[j]));
                }
            }
        }
    }

    unsafe public static class f_tointsaturated
    {
        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }


        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)((Int128)sb < int.MinValue ? int.MinValue : (Int128)sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)((BigInteger)sb < int.MinValue ? int.MinValue : (BigInteger)sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }


        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tointsaturated(sb), (int)(sb < int.MinValue ? int.MinValue : sb > int.MaxValue ? int.MaxValue : (int)sb));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)((Int128)sb[j] < int.MinValue ? int.MinValue : (Int128)sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(sb)[j], (int)(sb[j] < int.MinValue ? int.MinValue : sb[j] > int.MaxValue ? int.MaxValue : (int)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)((Int128)_0[j] < int.MinValue ? int.MinValue : (Int128)_0[j] > int.MaxValue ? int.MaxValue : (int)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)((Int128)_1[j] < int.MinValue ? int.MinValue : (Int128)_1[j] > int.MaxValue ? int.MaxValue : (int)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)(_0[j] < int.MinValue ? int.MinValue : _0[j] > int.MaxValue ? int.MaxValue : (int)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)(_1[j] < int.MinValue ? int.MinValue : _1[j] > int.MaxValue ? int.MaxValue : (int)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j], (int)(_0[j] < int.MinValue ? int.MinValue : _0[j] > int.MaxValue ? int.MaxValue : (int)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tointsaturated(_0, _1)[j + 4], (int)(_1[j] < int.MinValue ? int.MinValue : _1[j] > int.MaxValue ? int.MaxValue : (int)_1[j]));
                }
            }
        }
    }

    unsafe public static class f_toulongsaturated
    {
        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)((Int128)sb < ulong.MinValue ? ulong.MinValue : (Int128)sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }


        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }


        [Test]
        public static void _quarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter sb = new quarter(rng.NextByte());

                while (maxmath.isnan(sb))
                {
                    sb = new quarter(rng.NextByte());
                }

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toulongsaturated(sb), (ulong)(sb < ulong.MinValue ? ulong.MinValue : sb > ulong.MaxValue ? ulong.MaxValue : (ulong)sb));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }


        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter2 sb = maxmath.asquarter(rng.NextByte2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter3 sb = maxmath.asquarter(rng.NextByte3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)((Int128)sb[j] < ulong.MinValue ? ulong.MinValue : (Int128)sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                quarter4 sb = maxmath.asquarter(rng.NextByte4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new quarter(rng.NextByte());
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toulongsaturated(sb)[j], (ulong)(sb[j] < ulong.MinValue ? ulong.MinValue : sb[j] > ulong.MaxValue ? ulong.MaxValue : (ulong)sb[j]));
                }
            }
        }
    }

    unsafe public static class f_tolongsaturated
    {
        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)((Int128)sb < long.MinValue ? long.MinValue : (Int128)sb > long.MaxValue ? long.MaxValue : (long)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)((BigInteger)sb < long.MinValue ? long.MinValue : (BigInteger)sb > long.MaxValue ? long.MaxValue : (long)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tolongsaturated(sb), (long)(sb < long.MinValue ? long.MinValue : sb > long.MaxValue ? long.MaxValue : (long)sb));
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)((Int128)sb[j] < long.MinValue ? long.MinValue : (Int128)sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }


        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tolongsaturated(sb)[j], (long)(sb[j] < long.MinValue ? long.MinValue : sb[j] > long.MaxValue ? long.MaxValue : (long)sb[j]));
                }
            }
        }
    }

    unsafe public static class f_touint128saturated
    {
        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.touint128saturated(sb), (UInt128)(sb < UInt128.MinValue ? UInt128.MinValue : (UInt128)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.touint128saturated(sb), (UInt128)(sb < UInt128.MinValue ? UInt128.MinValue : sb > UInt128.MaxValue ? UInt128.MaxValue : (UInt128)sb));
            }
        }
    }

    unsafe public static class f_toint128saturated
    {
        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toint128saturated(sb), (Int128)(sb < Int128.MinValue ? Int128.MinValue : sb > Int128.MaxValue ? Int128.MaxValue : (Int128)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toint128saturated(sb), (Int128)(sb < Int128.MinValue ? Int128.MinValue : sb > Int128.MaxValue ? Int128.MaxValue : (Int128)sb));
            }
        }
    }

    unsafe public static class f_toquartersaturated
    {
        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte sb = rng.NextSByte();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte sb = rng.NextByte();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short sb = rng.NextShort();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }


        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half sb = new half { value = rng.NextUShort() };

                while (maxmath.isnan(sb))
                {
                    sb = new half { value = rng.NextUShort() };
                }

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.toquartersaturated(sb), (quarter)(sb < quarter.MinValue ? quarter.MinValue : sb > quarter.MaxValue ? quarter.MaxValue : (quarter)sb));
            }
        }


        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte2 sb = rng.NextSByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte2 sb = rng.NextByte2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short2 sb = rng.NextShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half2 sb = maxmath.ashalf(rng.NextUShort2());

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte3 sb = rng.NextSByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte3 sb = rng.NextByte3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short3 sb = rng.NextShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half3 sb = maxmath.ashalf(rng.NextUShort3());

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte4 sb = rng.NextSByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte4 sb = rng.NextByte4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short4 sb = rng.NextShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half4 sb = maxmath.ashalf(rng.NextUShort4());

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                sbyte8 sb = rng.NextSByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 25; i++)
            {
                byte8 sb = rng.NextByte8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                short8 sb = rng.NextShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                half8 sb = maxmath.ashalf(rng.NextUShort8());

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(sb[j]))
                    {
                        sb[j] = new half { value = rng.NextUShort() };
                    }

                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(sb)[j], (quarter)(sb[j] < quarter.MinValue ? quarter.MinValue : sb[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j], (quarter)(_0[j] < quarter.MinValue ? quarter.MinValue : _0[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.toquartersaturated(_0, _1)[j + 4], (quarter)(_1[j] < quarter.MinValue ? quarter.MinValue : _1[j] > quarter.MaxValue ? quarter.MaxValue : (quarter)_1[j]));
                }
            }
        }
    }

    unsafe public static class f_tohalfsaturated
    {
        [Test]
        public static void _int()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int sb = rng.NextInt();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _long()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long sb = rng.NextLong();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _Int128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                Int128 sb = rng.NextInt128();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort sb = rng.NextUShort();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _uint()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint sb = rng.NextUInt();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _ulong()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong sb = rng.NextULong();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float sb = rng.NextFloat(float.MinValue, float.MaxValue);

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tohalfsaturated(sb), (half)(sb < half.MinValue ? half.MinValue : sb > half.MaxValue ? half.MaxValue : (half)sb));
            }
        }


        [Test]
        public static void _int2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int2 sb = rng.NextInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long2 sb = rng.NextLong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort2 sb = rng.NextUShort2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint2 sb = rng.NextUInt2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong2 sb = rng.NextULong2();

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float2 sb = rng.NextFloat2(float.MinValue, float.MaxValue);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _int3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int3 sb = rng.NextInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long3 sb = rng.NextLong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort3 sb = rng.NextUShort3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint3 sb = rng.NextUInt3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong3 sb = rng.NextULong3();

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float3 sb = rng.NextFloat3(float.MinValue, float.MaxValue);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _int4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int4 sb = rng.NextInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                long4 sb = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort4 sb = rng.NextUShort4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint4 sb = rng.NextUInt4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                ulong4 sb = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float4 sb = rng.NextFloat4(float.MinValue, float.MaxValue);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _int8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                int8 sb = rng.NextInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 25; i++)
            {
                ushort8 sb = rng.NextUShort8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                uint8 sb = rng.NextUInt8();

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 25; i++)
            {
                float8 sb = rng.NextFloat8(float.MinValue, float.MaxValue);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(sb)[j], (half)(sb[j] < half.MinValue ? half.MinValue : sb[j] > half.MaxValue ? half.MaxValue : (half)sb[j]));
                }
            }
        }


        [Test]
        public static void _ulong4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                ulong4 _0 = rng.NextULong4();
                ulong4 _1 = rng.NextULong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j]));
                }
            }
        }

        [Test]
        public static void _long4x2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 25; i++)
            {
                long4 _0 = rng.NextLong4();
                long4 _1 = rng.NextLong4();

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j], (half)(_0[j] < half.MinValue ? half.MinValue : _0[j] > half.MaxValue ? half.MaxValue : (half)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tohalfsaturated(_0, _1)[j + 4], (half)(_1[j] < half.MinValue ? half.MinValue : _1[j] > half.MaxValue ? half.MaxValue : (half)_1[j]));
                }
            }
        }
    }

    unsafe public static class f_tofloatsaturated
    {
        [Test]
        public static void _UInt128()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 25; i++)
            {
                UInt128 sb = rng.NextUInt128();

                Assert.AreEqual(maxmath.tofloatsaturated(sb), (math.isinf((float)sb) ? float.MaxValue : (float)sb));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double sb = rng.NextDouble(double.MinValue / 2d, double.MaxValue / 2d);

                Assert.AreEqual(maxmath.tofloatsaturated(sb), (float)(sb < float.MinValue ? float.MinValue : sb > float.MaxValue ? float.MaxValue : (float)sb));
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double2 sb = rng.NextDouble2(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double3 sb = rng.NextDouble3(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 sb = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(sb)[j], (float)(sb[j] < float.MinValue ? float.MinValue : sb[j] > float.MaxValue ? float.MaxValue : (float)sb[j]));
                }
            }
        }

        [Test]
        public static void _double4x2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 25; i++)
            {
                double4 _0 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);
                double4 _1 = rng.NextDouble4(double.MinValue / 2d, double.MaxValue / 2d);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(_0)[j], (float)(_0[j] < float.MinValue ? float.MinValue : _0[j] > float.MaxValue ? float.MaxValue : (float)_0[j]));
                }

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(maxmath.tofloatsaturated(_1)[j], (float)(_1[j] < float.MinValue ? float.MinValue : _1[j] > float.MaxValue ? float.MaxValue : (float)_1[j]));
                }
            }
        }
    }
}