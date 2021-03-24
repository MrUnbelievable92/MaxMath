using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class vshr
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < Byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 shr = maxmath.vshr(Byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : Byte2.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void byte3()
        {
            for (int i = 0; i < Byte3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    byte3 shr = maxmath.vshr(Byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : Byte3.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void byte4()
        {
            for (int i = 0; i < Byte4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    byte4 shr = maxmath.vshr(Byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : Byte4.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void byte8()
        {
            for (int i = 0; i < Byte8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    byte8 shr = maxmath.vshr(Byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : Byte8.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0; i < Byte16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    byte16 shr = maxmath.vshr(Byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 16) ? 0 : Byte16.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void byte32()
        {
            for (int i = 0; i < Byte32.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    byte32 shr = maxmath.vshr(Byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 32) ? 0 : Byte32.TestData_LHS[i][j + k]));
                    }
                }
            }
        }


        [Test]
        public static void ushort2()
        {
            for (int i = 0; i < UShort2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ushort2 shr = maxmath.vshr(UShort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : UShort2.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ushort3()
        {
            for (int i = 0; i < UShort3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ushort3 shr = maxmath.vshr(UShort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : UShort3.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ushort4()
        {
            for (int i = 0; i < UShort4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ushort4 shr = maxmath.vshr(UShort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : UShort4.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ushort8()
        {
            for (int i = 0; i < UShort8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    ushort8 shr = maxmath.vshr(UShort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : UShort8.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ushort16()
        {
            for (int i = 0; i < UShort16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    ushort16 shr = maxmath.vshr(UShort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 16) ? 0 : UShort16.TestData_LHS[i][j + k]));
                    }
                }
            }
        }


        [Test]
        public static void uint2()
        {
            for (int i = 0; i < UInt2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    uint2 shr = maxmath.vshr(UInt2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : UInt2.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void uint3()
        {
            for (int i = 0; i < UInt3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    uint3 shr = maxmath.vshr(UInt3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : UInt3.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void uint4()
        {
            for (int i = 0; i < UInt4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    uint4 shr = maxmath.vshr(UInt4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : UInt4.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void uint8()
        {
            for (int i = 0; i < UInt8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    uint8 shr = maxmath.vshr(UInt8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 8) ? 0 : UInt8.TestData_LHS[i][j + k]));
                    }
                }
            }
        }


        [Test]
        public static void ulong2()
        {
            for (int i = 0; i < ULong2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ulong2 shr = maxmath.vshr(ULong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 2) ? 0 : ULong2.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ulong3()
        {
            for (int i = 0; i < ULong3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ulong3 shr = maxmath.vshr(ULong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 3) ? 0 : ULong3.TestData_LHS[i][j + k]));
                    }
                }
            }
        }

        [Test]
        public static void ulong4()
        {
            for (int i = 0; i < ULong4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ulong4 shr = maxmath.vshr(ULong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shr[k] == ((j + k >= 4) ? 0 : ULong4.TestData_LHS[i][j + k]));
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
            for (int i = 0; i < Byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 shl = maxmath.vshl(Byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte2.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void byte3()
        {
            for (int i = 0; i < Byte3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    byte3 shl = maxmath.vshl(Byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte3.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void byte4()
        {
            for (int i = 0; i < Byte4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    byte4 shl = maxmath.vshl(Byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte4.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void byte8()
        {
            for (int i = 0; i < Byte8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    byte8 shl = maxmath.vshl(Byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte8.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void byte16()
        {
            for (int i = 0; i < Byte16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    byte16 shl = maxmath.vshl(Byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte16.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void byte32()
        {
            for (int i = 0; i < Byte32.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 32; j++)
                {
                    byte32 shl = maxmath.vshl(Byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : Byte32.TestData_LHS[i][k - j]));
                    }
                }
            }
        }


        [Test]
        public static void ushort2()
        {
            for (int i = 0; i < UShort2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ushort2 shl = maxmath.vshl(UShort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UShort2.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ushort3()
        {
            for (int i = 0; i < UShort3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ushort3 shl = maxmath.vshl(UShort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UShort3.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ushort4()
        {
            for (int i = 0; i < UShort4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ushort4 shl = maxmath.vshl(UShort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UShort4.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ushort8()
        {
            for (int i = 0; i < UShort8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    ushort8 shl = maxmath.vshl(UShort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UShort8.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ushort16()
        {
            for (int i = 0; i < UShort16.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 16; j++)
                {
                    ushort16 shl = maxmath.vshl(UShort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UShort16.TestData_LHS[i][k - j]));
                    }
                }
            }
        }


        [Test]
        public static void uint2()
        {
            for (int i = 0; i < UInt2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    uint2 shl = maxmath.vshl(UInt2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UInt2.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void uint3()
        {
            for (int i = 0; i < UInt3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    uint3 shl = maxmath.vshl(UInt3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UInt3.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void uint4()
        {
            for (int i = 0; i < UInt4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    uint4 shl = maxmath.vshl(UInt4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UInt4.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void uint8()
        {
            for (int i = 0; i < UInt8.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    uint8 shl = maxmath.vshl(UInt8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : UInt8.TestData_LHS[i][k - j]));
                    }
                }
            }
        }


        [Test]
        public static void ulong2()
        {
            for (int i = 0; i < ULong2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    ulong2 shl = maxmath.vshl(ULong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : ULong2.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ulong3()
        {
            for (int i = 0; i < ULong3.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    ulong3 shl = maxmath.vshl(ULong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : ULong3.TestData_LHS[i][k - j]));
                    }
                }
            }
        }

        [Test]
        public static void ulong4()
        {
            for (int i = 0; i < ULong4.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    ulong4 shl = maxmath.vshl(ULong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.IsTrue(shl[k] == ((k - j < 0) ? 0 : ULong4.TestData_LHS[i][k - j]));
                    }
                }
            }
        }
    }
}
