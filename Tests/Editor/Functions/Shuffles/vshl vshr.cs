using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class vshr
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < __byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 shr = maxmath.vshr(__byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : __byte2.TestData_LHS[i][j + k]));
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
                    byte3 shr = maxmath.vshr(__byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : __byte3.TestData_LHS[i][j + k]));
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
                    byte4 shr = maxmath.vshr(__byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : __byte4.TestData_LHS[i][j + k]));
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
                    byte8 shr = maxmath.vshr(__byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : __byte8.TestData_LHS[i][j + k]));
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
                    byte16 shr = maxmath.vshr(__byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 16) ? 0 : __byte16.TestData_LHS[i][j + k]));
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
                    byte32 shr = maxmath.vshr(__byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 32) ? 0 : __byte32.TestData_LHS[i][j + k]));
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
                    ushort2 shr = maxmath.vshr(__ushort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : __ushort2.TestData_LHS[i][j + k]));
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
                    ushort3 shr = maxmath.vshr(__ushort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : __ushort3.TestData_LHS[i][j + k]));
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
                    ushort4 shr = maxmath.vshr(__ushort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : __ushort4.TestData_LHS[i][j + k]));
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
                    ushort8 shr = maxmath.vshr(__ushort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : __ushort8.TestData_LHS[i][j + k]));
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
                    ushort16 shr = maxmath.vshr(__ushort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 16) ? 0 : __ushort16.TestData_LHS[i][j + k]));
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
                    uint2 shr = maxmath.vshr(__uint2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : __uint2.TestData_LHS[i][j + k]));
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
                    uint3 shr = maxmath.vshr(__uint3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : __uint3.TestData_LHS[i][j + k]));
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
                    uint4 shr = maxmath.vshr(__uint4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : __uint4.TestData_LHS[i][j + k]));
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
                    uint8 shr = maxmath.vshr(__uint8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : __uint8.TestData_LHS[i][j + k]));
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
                    ulong2 shr = maxmath.vshr(__ulong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : __ulong2.TestData_LHS[i][j + k]));
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
                    ulong3 shr = maxmath.vshr(__ulong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : __ulong3.TestData_LHS[i][j + k]));
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
                    ulong4 shr = maxmath.vshr(__ulong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : __ulong4.TestData_LHS[i][j + k]));
                    }
                }
            }
        }
    }


    public static class vshl
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < __byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 shl = maxmath.vshl(__byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte2.TestData_LHS[i][k - j]));
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
                    byte3 shl = maxmath.vshl(__byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte3.TestData_LHS[i][k - j]));
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
                    byte4 shl = maxmath.vshl(__byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte4.TestData_LHS[i][k - j]));
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
                    byte8 shl = maxmath.vshl(__byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte8.TestData_LHS[i][k - j]));
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
                    byte16 shl = maxmath.vshl(__byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte16.TestData_LHS[i][k - j]));
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
                    byte32 shl = maxmath.vshl(__byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __byte32.TestData_LHS[i][k - j]));
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
                    ushort2 shl = maxmath.vshl(__ushort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ushort2.TestData_LHS[i][k - j]));
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
                    ushort3 shl = maxmath.vshl(__ushort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ushort3.TestData_LHS[i][k - j]));
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
                    ushort4 shl = maxmath.vshl(__ushort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ushort4.TestData_LHS[i][k - j]));
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
                    ushort8 shl = maxmath.vshl(__ushort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ushort8.TestData_LHS[i][k - j]));
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
                    ushort16 shl = maxmath.vshl(__ushort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ushort16.TestData_LHS[i][k - j]));
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
                    uint2 shl = maxmath.vshl(__uint2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __uint2.TestData_LHS[i][k - j]));
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
                    uint3 shl = maxmath.vshl(__uint3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __uint3.TestData_LHS[i][k - j]));
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
                    uint4 shl = maxmath.vshl(__uint4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __uint4.TestData_LHS[i][k - j]));
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
                    uint8 shl = maxmath.vshl(__uint8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __uint8.TestData_LHS[i][k - j]));
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
                    ulong2 shl = maxmath.vshl(__ulong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ulong2.TestData_LHS[i][k - j]));
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
                    ulong3 shl = maxmath.vshl(__ulong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ulong3.TestData_LHS[i][k - j]));
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
                    ulong4 shl = maxmath.vshl(__ulong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : __ulong4.TestData_LHS[i][k - j]));
                    }
                }
            }
        }
    }
}
