using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    /// __float/__double implicitly tested by testing Int/__long
    unsafe public static class all_dif
    {
        [Test]
        public static void Byte3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    byte3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (byte)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Byte4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    byte4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (byte)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Byte8()
        {
            for (int K = 0; K < 8; K++)
            {
                for (int i = 0; i < 8; i++)
                {
                    byte8 a = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        a[j] = (byte)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Byte16()
        {
            for (int K = 0; K < 16; K++)
            {
                for (int i = 0; i < 16; i++)
                {
                    byte16 a = 0;

                    for (int j = 0; j < 16; j++)
                    {
                        a[j] = (byte)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Byte32()
        {
            for (int K = 0; K < 32; K++)
            {
                for (int i = 0; i < 32; i++)
                {
                    byte32 a = 0;

                    for (int j = 0; j < 32; j++)
                    {
                        a[j] = (byte)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }

            byte32 xxx = new byte32(new byte16(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15), new byte16(16));
            Assert.IsFalse(maxmath.all_dif(xxx));
        }


        [Test]
        public static void Short3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    short3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (short)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Short4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    short4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (short)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Short8()
        {
            for (int K = 0; K < 8; K++)
            {
                for (int i = 0; i < 8; i++)
                {
                    short8 a = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        a[j] = (short)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Short16()
        {
            for (int K = 0; K < 16; K++)
            {
                for (int i = 0; i < 16; i++)
                {
                    short16 a = 0;

                    for (int j = 0; j < 16; j++)
                    {
                        a[j] = (short)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }

            short16 xxx = new short16(new short8(0, 1, 2, 3, 4, 5, 6, 7), new short8(8));
            Assert.IsFalse(maxmath.all_dif(xxx));
        }


        [Test]
        public static void Int3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    int3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (int)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Int4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    int4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (int)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }
        }

        [Test]
        public static void Int8()
        {
            for (int K = 0; K < 8; K++)
            {
                for (int i = 0; i < 8; i++)
                {
                    int8 a = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        a[j] = (int)j;
                    }

                    Assert.IsTrue(maxmath.all_dif(a));

                    if (a[i] != a[K])
                    {
                        a[i] = a[K];
                        Assert.IsFalse(maxmath.all_dif(a));
                    }
                }
            }

            int8 xxx = new int8(new int4(0, 1, 2, 3), new int4(4));
            Assert.IsFalse(maxmath.all_dif(xxx));
        }
    }
}