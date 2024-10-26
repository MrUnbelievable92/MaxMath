using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_negate
    {
        [Test]
        public static void _Int128()
        {
            Random128 x = Random128.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                Int128 __int = x.NextInt128();

                Assert.AreEqual(maxmath.negate(__int, b), b ? -__int : __int);
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                sbyte __int = x.NextSByte();

                Assert.AreEqual(maxmath.negate(__int, b), (sbyte)(b ? -__int : __int));
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                sbyte2 __int = x.NextSByte2();

                sbyte2 test = maxmath.negate(__int, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                sbyte3 __int = x.NextSByte3();

                sbyte3 test = maxmath.negate(__int, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                sbyte4 __int = x.NextSByte4();

                sbyte4 test = maxmath.negate(__int, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                sbyte8 __int = x.NextSByte8();

                sbyte8 test = maxmath.negate(__int, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _sbyte16()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool16 b = x.NextBool16();
                sbyte16 __int = x.NextSByte16();

                sbyte16 test = maxmath.negate(__int, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _sbyte32()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool32 b = x.NextBool32();
                sbyte32 __int = x.NextSByte32();

                sbyte32 test = maxmath.negate(__int, b);

                for (int j = 0; j < 32; j++)
                {
                    Assert.AreEqual(test[j], (sbyte)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                short __int = x.NextShort();

                Assert.AreEqual(maxmath.negate(__int, b), (short)(b ? -__int : __int));
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                short2 __int = x.NextShort2();

                short2 test = maxmath.negate(__int, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (short)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                short3 __int = x.NextShort3();

                short3 test = maxmath.negate(__int, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (short)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                short4 __int = x.NextShort4();

                short4 test = maxmath.negate(__int, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (short)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                short8 __int = x.NextShort8();

                short8 test = maxmath.negate(__int, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (short)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _short16()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool16 b = x.NextBool16();
                short16 __int = x.NextShort16();

                short16 test = maxmath.negate(__int, b);

                for (int j = 0; j < 16; j++)
                {
                    Assert.AreEqual(test[j], (short)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }


        [Test]
        public static void _int()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                int __int = x.NextInt();

                Assert.AreEqual(maxmath.negate(__int, b), (int)(b ? -__int : __int));
            }
        }

        [Test]
        public static void _int2()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                int2 __int = x.NextInt2();

                int2 test = maxmath.negate(__int, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (int)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _int3()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                int3 __int = x.NextInt3();

                int3 test = maxmath.negate(__int, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (int)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _int4()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                int4 __int = x.NextInt4();

                int4 test = maxmath.negate(__int, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (int)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }

        [Test]
        public static void _int8()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                int8 __int = x.NextInt8();

                int8 test = maxmath.negate(__int, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (int)(b[j] ? -__int[j] : __int[j]));
                }
            }
        }


        [Test]
        public static void _long()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                long __long = x.NextLong();

                Assert.AreEqual(maxmath.negate(__long, b), (long)(b ? -__long : __long));
            }
        }

        [Test]
        public static void _long2()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                long2 __long = x.NextLong2();

                long2 test = maxmath.negate(__long, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (long)(b[j] ? -__long[j] : __long[j]));
                }
            }
        }

        [Test]
        public static void _long3()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                long3 __long = x.NextLong3();

                long3 test = maxmath.negate(__long, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (long)(b[j] ? -__long[j] : __long[j]));
                }
            }
        }

        [Test]
        public static void _long4()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                long4 __long = x.NextLong4();

                long4 test = maxmath.negate(__long, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (long)(b[j] ? -__long[j] : __long[j]));
                }
            }
        }


        [Test]
        public static void _quarter()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                quarter __float = maxmath.asquarter(x.NextSByte());

                if (!maxmath.isnan(maxmath.negate(__float, b)))
                {
                    Assert.AreEqual(maxmath.negate(__float, b), (quarter)(b ? -__float : __float));
                }
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                quarter2 __float = maxmath.asquarter(x.NextSByte2());

                quarter2 test = maxmath.negate(__float, b);

                for (int j = 0; j < 2; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (quarter)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                quarter3 __float = maxmath.asquarter(x.NextSByte3());

                quarter3 test = maxmath.negate(__float, b);

                for (int j = 0; j < 3; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (quarter)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                quarter4 __float = maxmath.asquarter(x.NextSByte4());

                quarter4 test = maxmath.negate(__float, b);

                for (int j = 0; j < 4; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (quarter)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random8 x = Random8.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                quarter8 __float = maxmath.asquarter(x.NextSByte8());

                quarter8 test = maxmath.negate(__float, b);

                for (int j = 0; j < 8; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (quarter)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }


        [Test]
        public static void _half()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                half __float = maxmath.ashalf(x.NextShort());

                if (!maxmath.isnan(maxmath.negate(__float, b)))
                {
                    Assert.AreEqual(maxmath.negate(__float, b), (half)(b ? -__float : __float));
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                half2 __float = maxmath.ashalf(x.NextShort2());

                half2 test = maxmath.negate(__float, b);

                for (int j = 0; j < 2; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (half)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                half3 __float = maxmath.ashalf(x.NextShort3());

                half3 test = maxmath.negate(__float, b);

                for (int j = 0; j < 3; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (half)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                half4 __float = maxmath.ashalf(x.NextShort4());

                half4 test = maxmath.negate(__float, b);

                for (int j = 0; j < 4; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (half)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 x = Random16.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                half8 __float = maxmath.ashalf(x.NextShort8());

                half8 test = maxmath.negate(__float, b);

                for (int j = 0; j < 8; j++)
                {
                    if (!maxmath.isnan(test[j]))
                    {
                        Assert.AreEqual(test[j], (half)(b[j] ? -__float[j] : __float[j]));
                    }
                }
            }
        }


        [Test]
        public static void _float()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                float __float = x.NextFloat();

                Assert.AreEqual(maxmath.negate(__float, b), (float)(b ? -__float : __float));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                float2 __float = x.NextFloat2();

                float2 test = maxmath.negate(__float, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (float)(b[j] ? -__float[j] : __float[j]));
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                float3 __float = x.NextFloat3();

                float3 test = maxmath.negate(__float, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (float)(b[j] ? -__float[j] : __float[j]));
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                float4 __float = x.NextFloat4();

                float4 test = maxmath.negate(__float, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (float)(b[j] ? -__float[j] : __float[j]));
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 x = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                bool8 b = x.NextBool8();
                float8 __float = x.NextFloat8();

                float8 test = maxmath.negate(__float, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], (float)(b[j] ? -__float[j] : __float[j]));
                }
            }
        }


        [Test]
        public static void _double()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool b = x.NextBool();
                double __double= x.NextDouble();

                Assert.AreEqual(maxmath.negate(__double, b), (double)(b ? -__double: __double));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool2 b = x.NextBool2();
                double2 __double= x.NextDouble2();

                double2 test = maxmath.negate(__double, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], (double)(b[j] ? -__double[j] : __double[j]));
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool3 b = x.NextBool3();
                double3 __double= x.NextDouble3();

                double3 test = maxmath.negate(__double, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], (double)(b[j] ? -__double[j] : __double[j]));
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 x = Random64.New;

            for (int i = 0; i < 16; i++)
            {
                bool4 b = x.NextBool4();
                double4 __double= x.NextDouble4();

                double4 test = maxmath.negate(__double, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], (double)(b[j] ? -__double[j] : __double[j]));
                }
            }
        }
    }
}