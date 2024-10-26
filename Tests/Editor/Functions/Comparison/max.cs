using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    unsafe public static class f_max
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                float f1 = rng.NextFloat(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                float f2 = rng.NextFloat(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                quarter a = (quarter)f1;
                quarter b = (quarter)f2;

                quarter test = maxmath.max(a, b);

                if (maxmath.isnan(a) || maxmath.isnan(b) || maxmath.isnan(test) || math.isnan(f1) || math.isnan(f2))
                {
                    UnityEngine.Debug.Log(a);
                    UnityEngine.Debug.Log(b);
                    UnityEngine.Debug.Log(test);
                    UnityEngine.Debug.Log(f1);
                    UnityEngine.Debug.Log(f2);
                }
                if (a >= b)
                {
                    Assert.AreEqual(test, a);
                }
                else
                {
                    Assert.AreEqual(test, b);
                }
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter2 a = (quarter2)rng.NextFloat2(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                quarter2 b = (quarter2)rng.NextFloat2(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);

                quarter2 test = maxmath.max(a, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter3 a = (quarter3)rng.NextFloat3(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                quarter3 b = (quarter3)rng.NextFloat3(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);

                quarter3 test = maxmath.max(a, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter4 a = (quarter4)rng.NextFloat4(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                quarter4 b = (quarter4)rng.NextFloat4(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);

                quarter4 test = maxmath.max(a, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                quarter8 a = (quarter8)rng.NextFloat8(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);
                quarter8 b = (quarter8)rng.NextFloat8(quarter.MinValue - 2.5f, quarter.MaxValue + 2.5f);

                quarter8 test = maxmath.max(a, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half a = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                half b = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);

                while (maxmath.isnan(a))
                {
                    a = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                }
                while (maxmath.isnan(b))
                {
                    b = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                }

                half test = maxmath.max(a, b);

                if (a >= b)
                {
                    Assert.AreEqual(test, a);
                }
                else
                {
                    Assert.AreEqual(test, b);
                }
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half2 a = (half2)rng.NextFloat2(half.MinValue - 2000f, half.MaxValue + 2000f);
                half2 b = (half2)rng.NextFloat2(half.MinValue - 2000f, half.MaxValue + 2000f);

                for (int j = 0; j < 2; j++)
                {
                    while (maxmath.isnan(a[j]))
                    {
                        a[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                    while (maxmath.isnan(b[j]))
                    {
                        b[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                }

                half2 test = maxmath.max(a, b);

                for (int j = 0; j < 2; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half3 a = (half3)rng.NextFloat3(half.MinValue - 2000f, half.MaxValue + 2000f);
                half3 b = (half3)rng.NextFloat3(half.MinValue - 2000f, half.MaxValue + 2000f);

                for (int j = 0; j < 3; j++)
                {
                    while (maxmath.isnan(a[j]))
                    {
                        a[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                    while (maxmath.isnan(b[j]))
                    {
                        b[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                }

                half3 test = maxmath.max(a, b);

                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half4 a = (half4)rng.NextFloat4(half.MinValue - 2000f, half.MaxValue + 2000f);
                half4 b = (half4)rng.NextFloat4(half.MinValue - 2000f, half.MaxValue + 2000f);

                for (int j = 0; j < 4; j++)
                {
                    while (maxmath.isnan(a[j]))
                    {
                        a[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                    while (maxmath.isnan(b[j]))
                    {
                        b[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                }

                half4 test = maxmath.max(a, b);

                for (int j = 0; j < 4; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 16; i++)
            {
                half8 a = (half8)rng.NextFloat8(half.MinValue - 2000f, half.MaxValue + 2000f);
                half8 b = (half8)rng.NextFloat8(half.MinValue - 2000f, half.MaxValue + 2000f);

                for (int j = 0; j < 8; j++)
                {
                    while (maxmath.isnan(a[j]))
                    {
                        a[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                    while (maxmath.isnan(b[j]))
                    {
                        b[j] = (half)rng.NextFloat(half.MinValue - 2000f, half.MaxValue + 2000f);
                    }
                }

                half8 test = maxmath.max(a, b);

                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(test[j], maxmath.max(a[j], b[j]));
                }
            }
        }
    }
}
