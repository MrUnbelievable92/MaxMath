using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class vror
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < __byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 ror = maxmath.vror(__byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], __byte2.TestData_LHS[i][(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void byte3()
        {
            for (int i = 0; i < __byte3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    byte3 ror = maxmath.vror(__byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], __byte3.TestData_LHS[i][(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void byte4()
        {
            for (int i = 0; i < __byte4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    byte4 ror = maxmath.vror(__byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], __byte4.TestData_LHS[i][(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void byte8()
        {
            for (int i = 0; i < __byte8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    byte8 ror = maxmath.vror(__byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], __byte8.TestData_LHS[i][(j + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0; i < __byte16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    byte16 ror = maxmath.vror(__byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], __byte16.TestData_LHS[i][(j + k) % 16]);
                    }
                }
            }
        }

        [Test]
        public static void byte32()
        {
            for (int i = 0; i < __byte32.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    byte32 ror = maxmath.vror(__byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(ror[k], __byte32.TestData_LHS[i][(j + k) % 32]);
                    }
                }
            }
        }


        [Test]
        public static void ushort2()
        {
            for (int i = 0; i < __ushort2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ushort2 ror = maxmath.vror(__ushort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], __ushort2.TestData_LHS[i][(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void ushort3()
        {
            for (int i = 0; i < __ushort3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ushort3 ror = maxmath.vror(__ushort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], __ushort3.TestData_LHS[i][(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void ushort4()
        {
            for (int i = 0; i < __ushort4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ushort4 ror = maxmath.vror(__ushort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], __ushort4.TestData_LHS[i][(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void ushort8()
        {
            for (int i = 0; i < __ushort8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    ushort8 ror = maxmath.vror(__ushort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], __ushort8.TestData_LHS[i][(j + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void ushort16()
        {
            for (int i = 0; i < __ushort16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    ushort16 ror = maxmath.vror(__ushort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], __ushort16.TestData_LHS[i][(j + k) % 16]);
                    }
                }
            }
        }


        [Test]
        public static void uint2()
        {
            for (int i = 0; i < __uint2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    uint2 ror = maxmath.vror(__uint2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], __uint2.TestData_LHS[i][(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void uint3()
        {
            for (int i = 0; i < __uint3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    uint3 ror = maxmath.vror(__uint3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], __uint3.TestData_LHS[i][(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void uint4()
        {
            for (int i = 0; i < __uint4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    uint4 ror = maxmath.vror(__uint4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], __uint4.TestData_LHS[i][(j + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void uint8()
        {
            for (int i = 0; i < __uint8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    uint8 ror = maxmath.vror(__uint8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], __uint8.TestData_LHS[i][(j + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void ulong2()
        {
            for (int i = 0; i < __ulong2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ulong2 ror = maxmath.vror(__ulong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], __ulong2.TestData_LHS[i][(j + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void ulong3()
        {
            for (int i = 0; i < __ulong3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ulong3 ror = maxmath.vror(__ulong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], __ulong3.TestData_LHS[i][(j + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void ulong4()
        {
            for (int i = 0; i < __ulong4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ulong4 ror = maxmath.vror(__ulong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], __ulong4.TestData_LHS[i][(j + k) % 4]);
                    }
                }
            }
        }
    }


    public static class vrol
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < __byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 rol = maxmath.vrol(__byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], __byte2.TestData_LHS[i][((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void byte3()
        {
            for (int i = 0; i < __byte3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    byte3 rol = maxmath.vrol(__byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], __byte3.TestData_LHS[i][((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void byte4()
        {
            for (int i = 0; i < __byte4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    byte4 rol = maxmath.vrol(__byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], __byte4.TestData_LHS[i][((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void byte8()
        {
            for (int i = 0; i < __byte8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    byte8 rol = maxmath.vrol(__byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], __byte8.TestData_LHS[i][((8 - j) + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0; i < __byte16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    byte16 rol = maxmath.vrol(__byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], __byte16.TestData_LHS[i][((16 - j) + k) % 16]);
                    }
                }
            }
        }

        [Test]
        public static void byte32()
        {
            for (int i = 0; i < __byte32.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    byte32 rol = maxmath.vrol(__byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(rol[k], __byte32.TestData_LHS[i][((32 - j) + k) % 32]);
                    }
                }
            }
        }


        [Test]
        public static void ushort2()
        {
            for (int i = 0; i < __ushort2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ushort2 rol = maxmath.vrol(__ushort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], __ushort2.TestData_LHS[i][((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void ushort3()
        {
            for (int i = 0; i < __ushort3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ushort3 rol = maxmath.vrol(__ushort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], __ushort3.TestData_LHS[i][((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void ushort4()
        {
            for (int i = 0; i < __ushort4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ushort4 rol = maxmath.vrol(__ushort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], __ushort4.TestData_LHS[i][((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void ushort8()
        {
            for (int i = 0; i < __ushort8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    ushort8 rol = maxmath.vrol(__ushort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], __ushort8.TestData_LHS[i][((8 - j) + k) % 8]);
                    }
                }
            }
        }

        [Test]
        public static void ushort16()
        {
            for (int i = 0; i < __ushort16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    ushort16 rol = maxmath.vrol(__ushort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], __ushort16.TestData_LHS[i][((16 - j) + k) % 16]);
                    }
                }
            }
        }


        [Test]
        public static void uint2()
        {
            for (int i = 0; i < __uint2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    uint2 rol = maxmath.vrol(__uint2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], __uint2.TestData_LHS[i][((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void uint3()
        {
            for (int i = 0; i < __uint3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    uint3 rol = maxmath.vrol(__uint3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], __uint3.TestData_LHS[i][((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void uint4()
        {
            for (int i = 0; i < __uint4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    uint4 rol = maxmath.vrol(__uint4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], __uint4.TestData_LHS[i][((4 - j) + k) % 4]);
                    }
                }
            }
        }

        [Test]
        public static void uint8()
        {
            for (int i = 0; i < __uint8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    uint8 rol = maxmath.vrol(__uint8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], __uint8.TestData_LHS[i][((8 - j) + k) % 8]);
                    }
                }
            }
        }


        [Test]
        public static void ulong2()
        {
            for (int i = 0; i < __ulong2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ulong2 rol = maxmath.vrol(__ulong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], __ulong2.TestData_LHS[i][((2 - j) + k) % 2]);
                    }
                }
            }
        }

        [Test]
        public static void ulong3()
        {
            for (int i = 0; i < __ulong3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ulong3 rol = maxmath.vrol(__ulong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], __ulong3.TestData_LHS[i][((3 - j) + k) % 3]);
                    }
                }
            }
        }

        [Test]
        public static void ulong4()
        {
            for (int i = 0; i < __ulong4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ulong4 rol = maxmath.vrol(__ulong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], __ulong4.TestData_LHS[i][((4 - j) + k) % 4]);
                    }
                }
            }
        }
    }
}
