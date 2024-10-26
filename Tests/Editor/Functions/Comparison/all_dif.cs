using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_all_dif
    {
        [Test]
        public static void _byte2_byte2()
        {
            byte2 l = new byte2(0, 1);
            byte2 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    byte2 cpyL = l;
                    byte2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _byte3_byte3()
        {
            byte3 l = new byte3(0, 1, 2);
            byte3 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    byte3 cpyL = l;
                    byte3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _byte4_byte4()
        {
            byte4 l = new byte4(0, 1, 2, 3);
            byte4 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    byte4 cpyL = l;
                    byte4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _byte8_byte8()
        {
            byte8 l = new byte8(0, 1, 2, 3, 4, 5, 6, 7);
            byte8 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 8; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 8; j++)
                {
                    byte8 cpyL = l;
                    byte8 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _byte16_byte16()
        {
            byte16 l = new byte16(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            byte16 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 16; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 16; j++)
                {
                    byte16 cpyL = l;
                    byte16 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _byte32_byte32()
        {
            byte32 l = new byte32(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31);
            byte32 r = byte.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 32; i++)
            {
                byte extractL = l[i];
                byte extractR = r[i];

                for (int j = 0; j < 32; j++)
                {
                    byte32 cpyL = l;
                    byte32 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _ushort2_ushort2()
        {
            ushort2 l = new ushort2(0, 1);
            ushort2 r = ushort.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                ushort extractL = l[i];
                ushort extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    ushort2 cpyL = l;
                    ushort2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ushort3_ushort3()
        {
            ushort3 l = new ushort3(0, 1, 2);
            ushort3 r = ushort.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                ushort extractL = l[i];
                ushort extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    ushort3 cpyL = l;
                    ushort3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ushort4_ushort4()
        {
            ushort4 l = new ushort4(0, 1, 2, 3);
            ushort4 r = ushort.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                ushort extractL = l[i];
                ushort extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    ushort4 cpyL = l;
                    ushort4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ushort8_ushort8()
        {
            ushort8 l = new ushort8(0, 1, 2, 3, 4, 5, 6, 7);
            ushort8 r = ushort.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 8; i++)
            {
                ushort extractL = l[i];
                ushort extractR = r[i];

                for (int j = 0; j < 8; j++)
                {
                    ushort8 cpyL = l;
                    ushort8 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ushort16_ushort16()
        {
            ushort16 l = new ushort16(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            ushort16 r = ushort.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 16; i++)
            {
                ushort extractL = l[i];
                ushort extractR = r[i];

                for (int j = 0; j < 16; j++)
                {
                    ushort16 cpyL = l;
                    ushort16 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _uint2_uint2()
        {
            uint2 l = new uint2(0, 1);
            uint2 r = uint.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                uint extractL = l[i];
                uint extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    uint2 cpyL = l;
                    uint2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _uint3_uint3()
        {
            uint3 l = new uint3(0, 1, 2);
            uint3 r = uint.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                uint extractL = l[i];
                uint extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    uint3 cpyL = l;
                    uint3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _uint4_uint4()
        {
            uint4 l = new uint4(0, 1, 2, 3);
            uint4 r = uint.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                uint extractL = l[i];
                uint extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    uint4 cpyL = l;
                    uint4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _uint8_uint8()
        {
            uint8 l = new uint8(0, 1, 2, 3, 4, 5, 6, 7);
            uint8 r = uint.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 8; i++)
            {
                uint extractL = l[i];
                uint extractR = r[i];

                for (int j = 0; j < 8; j++)
                {
                    uint8 cpyL = l;
                    uint8 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _ulong2_ulong2()
        {
            ulong2 l = new ulong2(0, 1);
            ulong2 r = ulong.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                ulong extractL = l[i];
                ulong extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    ulong2 cpyL = l;
                    ulong2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ulong3_ulong3()
        {
            ulong3 l = new ulong3(0, 1, 2);
            ulong3 r = ulong.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                ulong extractL = l[i];
                ulong extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    ulong3 cpyL = l;
                    ulong3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _ulong4_ulong4()
        {
            ulong4 l = new ulong4(0, 1, 2, 3);
            ulong4 r = ulong.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                ulong extractL = l[i];
                ulong extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    ulong4 cpyL = l;
                    ulong4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _float2_float2()
        {
            float2 l = new float2(0, 1);
            float2 r = float.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                float extractL = l[i];
                float extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    float2 cpyL = l;
                    float2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _float3_float3()
        {
            float3 l = new float3(0, 1, 2);
            float3 r = float.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                float extractL = l[i];
                float extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    float3 cpyL = l;
                    float3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _float4_float4()
        {
            float4 l = new float4(0, 1, 2, 3);
            float4 r = float.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                float extractL = l[i];
                float extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    float4 cpyL = l;
                    float4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _float8_float8()
        {
            float8 l = new float8(0, 1, 2, 3, 4, 5, 6, 7);
            float8 r = float.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 8; i++)
            {
                float extractL = l[i];
                float extractR = r[i];

                for (int j = 0; j < 8; j++)
                {
                    float8 cpyL = l;
                    float8 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _double2_double2()
        {
            double2 l = new double2(0, 1);
            double2 r = double.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 2; i++)
            {
                double extractL = l[i];
                double extractR = r[i];

                for (int j = 0; j < 2; j++)
                {
                    double2 cpyL = l;
                    double2 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _double3_double3()
        {
            double3 l = new double3(0, 1, 2);
            double3 r = double.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 3; i++)
            {
                double extractL = l[i];
                double extractR = r[i];

                for (int j = 0; j < 3; j++)
                {
                    double3 cpyL = l;
                    double3 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }

        [Test]
        public static void _double4_double4()
        {
            double4 l = new double4(0, 1, 2, 3);
            double4 r = double.MaxValue - l;

            Assert.IsTrue(maxmath.all_dif(l, r));
            Assert.IsTrue(maxmath.all_dif(r, l));

            for (int i = 0; i < 4; i++)
            {
                double extractL = l[i];
                double extractR = r[i];

                for (int j = 0; j < 4; j++)
                {
                    double4 cpyL = l;
                    double4 cpyR = r;
                    cpyL[j] = extractR;
                    cpyR[j] = extractL;

                    Assert.IsFalse(maxmath.all_dif(cpyL, r));
                    Assert.IsFalse(maxmath.all_dif(l, cpyR));
                }
            }
        }


        [Test]
        public static void _byte2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    byte2 a = 0;

                    for (int j = 0; j < 2; j++)
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
        public static void _byte3()
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
        public static void _byte4()
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
        public static void _byte8()
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
        public static void _byte16()
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
        public static void _byte32()
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
        public static void _short2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    short2 a = 0;

                    for (int j = 0; j < 2; j++)
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
        public static void _short3()
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
        public static void _short4()
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
        public static void _short8()
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
        public static void _short16()
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
        }


        [Test]
        public static void _int2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    int2 a = 0;

                    for (int j = 0; j < 2; j++)
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
        public static void _int3()
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
        public static void _int4()
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
        public static void _int8()
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


        [Test]
        public static void _long2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    long2 a = 0;

                    for (int j = 0; j < 2; j++)
                    {
                        a[j] = (long)j;
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
        public static void _long3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    long3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (long)j;
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
        public static void _long4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    long4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (long)j;
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
        public static void _float2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    float2 a = 0;

                    for (int j = 0; j < 2; j++)
                    {
                        a[j] = (float)j;
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
        public static void _float3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    float3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (float)j;
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
        public static void _float4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    float4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (float)j;
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
        public static void _float8()
        {
            for (int K = 0; K < 8; K++)
            {
                for (int i = 0; i < 8; i++)
                {
                    float8 a = 0;

                    for (int j = 0; j < 8; j++)
                    {
                        a[j] = (float)j;
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
        public static void _double2()
        {
            for (int K = 0; K < 2; K++)
            {
                for (int i = 0; i < 2; i++)
                {
                    double2 a = 0;

                    for (int j = 0; j < 2; j++)
                    {
                        a[j] = (double)j;
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
        public static void _double3()
        {
            for (int K = 0; K < 3; K++)
            {
                for (int i = 0; i < 3; i++)
                {
                    double3 a = 0;

                    for (int j = 0; j < 3; j++)
                    {
                        a[j] = (double)j;
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
        public static void _double4()
        {
            for (int K = 0; K < 4; K++)
            {
                for (int i = 0; i < 4; i++)
                {
                    double4 a = 0;

                    for (int j = 0; j < 4; j++)
                    {
                        a[j] = (double)j;
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
    }
}