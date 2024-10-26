using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_trunc
    {
        [Test]
        public static void _quarter()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter q = maxmath.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q) && !maxmath.isinf(q))
                {
                    p |= Promise.Unsafe0;
                }

                quarter std = maxmath.trunc(q);
                quarter usf = maxmath.trunc(q, p);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN(std);
                    Assert.IsNaN(usf);
                }
                else
                {
                    Assert.AreEqual(std.value, usf.value);
                }
            }
        }

        [Test]
        public static void _quarter2()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter2 q = maxmath.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter2 std = maxmath.trunc(q);
                quarter2 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);
                    }
                }
            }
        }

        [Test]
        public static void _quarter3()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter3 q = maxmath.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter3 std = maxmath.trunc(q);
                quarter3 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);
                    }
                }
            }
        }

        [Test]
        public static void _quarter4()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter4 q = maxmath.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter4 std = maxmath.trunc(q);
                quarter4 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }

        [Test]
        public static void _quarter8()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter8 q = maxmath.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x0) && !maxmath.isinf(q.x0))
                {
                    p |= Promise.Unsafe0;
                }

                quarter8 std = maxmath.trunc(q);
                quarter8 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }


        [Test]
        public static void _half()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half q = maxmath.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q) && !maxmath.isinf(q))
                {
                    p |= Promise.Unsafe0;
                }

                half std = maxmath.trunc(q);
                half usf = maxmath.trunc(q, p);

                if (maxmath.isnan(q))
                {
                    Assert.IsNaN(std);
                    Assert.IsNaN(usf);
                }
                else
                {
                    Assert.AreEqual(std.value, usf.value);
                }
            }
        }

        [Test]
        public static void _half2()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half2 q = maxmath.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                half2 std = maxmath.trunc(q);
                half2 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 2; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }

        [Test]
        public static void _half3()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half3 q = maxmath.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                half3 std = maxmath.trunc(q);
                half3 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 3; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }

        [Test]
        public static void _half4()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half4 q = maxmath.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x) && !maxmath.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                half4 std = maxmath.trunc(q);
                half4 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 4; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }

        [Test]
        public static void _half8()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half8 q = maxmath.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                if (!maxmath.isnan(q.x0) && !maxmath.isinf(q.x0))
                {
                    p |= Promise.Unsafe0;
                }

                half8 std = maxmath.trunc(q);
                half8 usf = maxmath.trunc(q, p);

                for (int j = 0; j < 8; j++)
                {
                    if (maxmath.isnan(q[j]))
                    {
                        Assert.IsNaN(std[j]);
                        Assert.IsNaN(usf[j]);
                    }
                    else
                    {
                        Assert.AreEqual(std[j].value, usf[j].value);;
                    }
                }
            }
        }
    }
}
