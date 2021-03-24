using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class vror
    {
        [Test]
        public static void byte2()
        {
            for (int i = 0; i < Byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 ror = maxmath.vror(Byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], Byte2.TestData_LHS[i][(j + k) % 2]);
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
                    byte3 ror = maxmath.vror(Byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], Byte3.TestData_LHS[i][(j + k) % 3]);
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
                    byte4 ror = maxmath.vror(Byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], Byte4.TestData_LHS[i][(j + k) % 4]);
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
                    byte8 ror = maxmath.vror(Byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], Byte8.TestData_LHS[i][(j + k) % 8]);
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
                    byte16 ror = maxmath.vror(Byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], Byte16.TestData_LHS[i][(j + k) % 16]);
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
                    byte32 ror = maxmath.vror(Byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(ror[k], Byte32.TestData_LHS[i][(j + k) % 32]);
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
                    ushort2 ror = maxmath.vror(UShort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], UShort2.TestData_LHS[i][(j + k) % 2]);
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
                    ushort3 ror = maxmath.vror(UShort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], UShort3.TestData_LHS[i][(j + k) % 3]);
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
                    ushort4 ror = maxmath.vror(UShort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], UShort4.TestData_LHS[i][(j + k) % 4]);
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
                    ushort8 ror = maxmath.vror(UShort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], UShort8.TestData_LHS[i][(j + k) % 8]);
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
                    ushort16 ror = maxmath.vror(UShort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(ror[k], UShort16.TestData_LHS[i][(j + k) % 16]);
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
                    uint2 ror = maxmath.vror(UInt2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], UInt2.TestData_LHS[i][(j + k) % 2]);
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
                    uint3 ror = maxmath.vror(UInt3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], UInt3.TestData_LHS[i][(j + k) % 3]);
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
                    uint4 ror = maxmath.vror(UInt4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], UInt4.TestData_LHS[i][(j + k) % 4]);
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
                    uint8 ror = maxmath.vror(UInt8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(ror[k], UInt8.TestData_LHS[i][(j + k) % 8]);
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
                    ulong2 ror = maxmath.vror(ULong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(ror[k], ULong2.TestData_LHS[i][(j + k) % 2]);
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
                    ulong3 ror = maxmath.vror(ULong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(ror[k], ULong3.TestData_LHS[i][(j + k) % 3]);
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
                    ulong4 ror = maxmath.vror(ULong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(ror[k], ULong4.TestData_LHS[i][(j + k) % 4]);
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
            for (int i = 0; i < Byte2.TestData_LHS.Length; i++)
            {
                for (int j = 1; j < 2; j++)
                {
                    byte2 rol = maxmath.vrol(Byte2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], Byte2.TestData_LHS[i][((2 - j) + k) % 2]);
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
                    byte3 rol = maxmath.vrol(Byte3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], Byte3.TestData_LHS[i][((3 - j) + k) % 3]);
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
                    byte4 rol = maxmath.vrol(Byte4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], Byte4.TestData_LHS[i][((4 - j) + k) % 4]);
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
                    byte8 rol = maxmath.vrol(Byte8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], Byte8.TestData_LHS[i][((8 - j) + k) % 8]);
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
                    byte16 rol = maxmath.vrol(Byte16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], Byte16.TestData_LHS[i][((16 - j) + k) % 16]);
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
                    byte32 rol = maxmath.vrol(Byte32.TestData_LHS[i], j);

                    for (int k = 0; k < 32; k++)
                    {
                        Assert.AreEqual(rol[k], Byte32.TestData_LHS[i][((32 - j) + k) % 32]);
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
                    ushort2 rol = maxmath.vrol(UShort2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], UShort2.TestData_LHS[i][((2 - j) + k) % 2]);
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
                    ushort3 rol = maxmath.vrol(UShort3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], UShort3.TestData_LHS[i][((3 - j) + k) % 3]);
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
                    ushort4 rol = maxmath.vrol(UShort4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], UShort4.TestData_LHS[i][((4 - j) + k) % 4]);
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
                    ushort8 rol = maxmath.vrol(UShort8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], UShort8.TestData_LHS[i][((8 - j) + k) % 8]);
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
                    ushort16 rol = maxmath.vrol(UShort16.TestData_LHS[i], j);

                    for (int k = 0; k < 16; k++)
                    {
                        Assert.AreEqual(rol[k], UShort16.TestData_LHS[i][((16 - j) + k) % 16]);
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
                    uint2 rol = maxmath.vrol(UInt2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], UInt2.TestData_LHS[i][((2 - j) + k) % 2]);
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
                    uint3 rol = maxmath.vrol(UInt3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], UInt3.TestData_LHS[i][((3 - j) + k) % 3]);
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
                    uint4 rol = maxmath.vrol(UInt4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], UInt4.TestData_LHS[i][((4 - j) + k) % 4]);
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
                    uint8 rol = maxmath.vrol(UInt8.TestData_LHS[i], j);

                    for (int k = 0; k < 8; k++)
                    {
                        Assert.AreEqual(rol[k], UInt8.TestData_LHS[i][((8 - j) + k) % 8]);
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
                    ulong2 rol = maxmath.vrol(ULong2.TestData_LHS[i], j);

                    for (int k = 0; k < 2; k++)
                    {
                        Assert.AreEqual(rol[k], ULong2.TestData_LHS[i][((2 - j) + k) % 2]);
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
                    ulong3 rol = maxmath.vrol(ULong3.TestData_LHS[i], j);

                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(rol[k], ULong3.TestData_LHS[i][((3 - j) + k) % 3]);
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
                    ulong4 rol = maxmath.vrol(ULong4.TestData_LHS[i], j);

                    for (int k = 0; k < 4; k++)
                    {
                        Assert.AreEqual(rol[k], ULong4.TestData_LHS[i][((4 - j) + k) % 4]);
                    }
                }
            }
        }
    }
}
