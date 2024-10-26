using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_vror
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2 test = rng.NextByte2();

                for (int j = 1; j < 2; j++)
                {
                    byte2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3 test = rng.NextByte3();

                for (int j = 1; j < 3; j++)
                {
                    byte3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4 test = rng.NextByte4();

                for (int j = 1; j < 4; j++)
                {
                    byte4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte8 test = rng.NextByte8();

                for (int j = 1; j < 8; j++)
                {
                    byte8 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte16 test = rng.NextByte16();

                for (int j = 1; j < 16; j++)
                {
                    byte16 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 16]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte32 test = rng.NextByte32();

                for (int j = 1; j < 32; j++)
                {
                    byte32 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 32]);
                    }
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2 test = rng.NextUShort2();

                for (int j = 1; j < 2; j++)
                {
                    ushort2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 test = rng.NextUShort3();

                for (int j = 1; j < 3; j++)
                {
                    ushort3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4 test = rng.NextUShort4();

                for (int j = 1; j < 4; j++)
                {
                    ushort4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort8 test = rng.NextUShort8();

                for (int j = 1; j < 8; j++)
                {
                    ushort8 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort16 test = rng.NextUShort16();

                for (int j = 1; j < 16; j++)
                {
                    ushort16 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 16]);
                    }
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2 test = rng.NextUInt2();

                for (int j = 1; j < 2; j++)
                {
                    uint2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3 test = rng.NextUInt3();

                for (int j = 1; j < 3; j++)
                {
                    uint3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4 test = rng.NextUInt4();

                for (int j = 1; j < 4; j++)
                {
                    uint4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint8 test = rng.NextUInt8();

                for (int j = 1; j < 8; j++)
                {
                    uint8 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2 test = rng.NextULong2();

                for (int j = 1; j < 2; j++)
                {
                    ulong2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3 test = rng.NextULong3();

                for (int j = 1; j < 3; j++)
                {
                    ulong3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4 test = rng.NextULong4();

                for (int j = 1; j < 4; j++)
                {
                    ulong4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }


        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2 test = rng.NextFloat2();

                for (int j = 1; j < 2; j++)
                {
                    float2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3 test = rng.NextFloat3();

                for (int j = 1; j < 3; j++)
                {
                    float3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4 test = rng.NextFloat4();

                for (int j = 1; j < 4; j++)
                {
                    float4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float8 test = rng.NextFloat8();

                for (int j = 1; j < 8; j++)
                {
                    float8 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2 test = rng.NextDouble2();

                for (int j = 1; j < 2; j++)
                {
                    double2 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3 test = rng.NextDouble3();

                for (int j = 1; j < 3; j++)
                {
                    double3 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4 test = rng.NextDouble4();

                for (int j = 1; j < 4; j++)
                {
                    double4 ror = maxmath.vror(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], test[(j + k) % 4]);
                    }
                }
            }
        }
    }


    public static class f_vrol
    {
        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte2 test = rng.NextByte2();

                for (int j = 1; j < 2; j++)
                {
                    byte2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte3 test = rng.NextByte3();

                for (int j = 1; j < 3; j++)
                {
                    byte3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte4 test = rng.NextByte4();

                for (int j = 1; j < 4; j++)
                {
                    byte4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte8 test = rng.NextByte8();

                for (int j = 1; j < 8; j++)
                {
                    byte8 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], test[((8 - j) + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void _byte16()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte16 test = rng.NextByte16();

                for (int j = 1; j < 16; j++)
                {
                    byte16 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], test[((16 - j) + k) % 16]);
                    }
                }
            }
        }

        [Test]
        public static void _byte32()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                byte32 test = rng.NextByte32();

                for (int j = 1; j < 32; j++)
                {
                    byte32 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(rol[k], test[((32 - j) + k) % 32]);
                    }
                }
            }
        }


        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort2 test = rng.NextUShort2();

                for (int j = 1; j < 2; j++)
                {
                    ushort2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort3 test = rng.NextUShort3();

                for (int j = 1; j < 3; j++)
                {
                    ushort3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort4 test = rng.NextUShort4();

                for (int j = 1; j < 4; j++)
                {
                    ushort4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort8 test = rng.NextUShort8();

                for (int j = 1; j < 8; j++)
                {
                    ushort8 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], test[((8 - j) + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void _ushort16()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                ushort16 test = rng.NextUShort16();

                for (int j = 1; j < 16; j++)
                {
                    ushort16 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], test[((16 - j) + k) % 16]);
                    }
                }
            }
        }


        [Test]
        public static void _uint2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint2 test = rng.NextUInt2();

                for (int j = 1; j < 2; j++)
                {
                    uint2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _uint3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint3 test = rng.NextUInt3();

                for (int j = 1; j < 3; j++)
                {
                    uint3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _uint4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint4 test = rng.NextUInt4();

                for (int j = 1; j < 4; j++)
                {
                    uint4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _uint8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                uint8 test = rng.NextUInt8();

                for (int j = 1; j < 8; j++)
                {
                    uint8 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], test[((8 - j) + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void _ulong2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong2 test = rng.NextULong2();

                for (int j = 1; j < 2; j++)
                {
                    ulong2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong3 test = rng.NextULong3();

                for (int j = 1; j < 3; j++)
                {
                    ulong3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _ulong4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                ulong4 test = rng.NextULong4();

                for (int j = 1; j < 4; j++)
                {
                    ulong4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }


        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float2 test = rng.NextFloat2();

                for (int j = 1; j < 2; j++)
                {
                    float2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float3 test = rng.NextFloat3();

                for (int j = 1; j < 3; j++)
                {
                    float3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float4 test = rng.NextFloat4();

                for (int j = 1; j < 4; j++)
                {
                    float4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float8 test = rng.NextFloat8();

                for (int j = 1; j < 8; j++)
                {
                    float8 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], test[((8 - j) + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double2 test = rng.NextDouble2();

                for (int j = 1; j < 2; j++)
                {
                    double2 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], test[((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double3 test = rng.NextDouble3();

                for (int j = 1; j < 3; j++)
                {
                    double3 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], test[((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                double4 test = rng.NextDouble4();

                for (int j = 1; j < 4; j++)
                {
                    double4 rol = maxmath.vrol(test, j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], test[((4 - j) + k) % 4]);
                    }
                }
            }
        }
    }
}