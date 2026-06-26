using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_floor
    {
        [Test]
        public static void _quarter()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q) && !math.isinf(q))
                {
                    p |= Promise.Unsafe0;
                }

                quarter std = math.floor(q);
                quarter usf = math.floor(q, p);

                if (math.isnan(q))
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
                quarter2 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x) && !math.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter2 std = math.floor(q);
                quarter2 usf = math.floor(q, p);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
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
                quarter3 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x) && !math.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter3 std = math.floor(q);
                quarter3 usf = math.floor(q, p);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
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
                quarter4 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x) && !math.isinf(q.x))
                {
                    p |= Promise.Unsafe0;
                }

                quarter4 std = math.floor(q);
                quarter4 usf = math.floor(q, p);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _quarter8()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter8 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x0) && !math.isinf(q.x0))
                {
                    p |= Promise.Unsafe0;
                }

                quarter8 std = math.floor(q);
                quarter8 usf = math.floor(q, p);

                for (int j = 0; j < 8; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _quarter16()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter16 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x0) && !math.isinf(q.x0))
                {
                    p |= Promise.Unsafe0;
                }

                quarter16 std = math.floor(q);
                quarter16 usf = math.floor(q, p);

                for (int j = 0; j < 16; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _quarter32()
        {
            for (int i = 0; i < byte.MaxValue + 1; i++)
            {
                quarter32 q = math.asquarter((byte)i);
                Promise p = Promise.Nothing;

                if (i < 0b1000_0000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0b1000_0000)
                {
                    p |= Promise.Negative;
                }

                if (!math.isnan(q.x0) && !math.isinf(q.x0))
                {
                    p |= Promise.Unsafe0;
                }

                quarter32 std = math.floor(q);
                quarter32 usf = math.floor(q, p);

                for (int j = 0; j < 32; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _half()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half std = math.floor(q);
                half usf = math.floor(q, p);

                if (math.isnan(q))
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
                half2 q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half2 std = math.floor(q);
                half2 usf = math.floor(q, p);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _half3()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half3 q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half3 std = math.floor(q);
                half3 usf = math.floor(q, p);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _half4()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half4 q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half4 std = math.floor(q);
                half4 usf = math.floor(q, p);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _half8()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half8 q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half8 std = math.floor(q);
                half8 usf = math.floor(q, p);

                for (int j = 0; j < 8; j++)
                {
                    if (math.isnan(q[j]))
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
        public static void _half16()
        {
            for (int i = 0; i < ushort.MaxValue + 1; i++)
            {
                half16 q = math.ashalf((ushort)i);
                Promise p = Promise.Nothing;

                if (i < 0x8000)
                {
                    p |= Promise.Positive;
                }
                else if (i != 0x8000)
                {
                    p |= Promise.Negative;
                }

                half16 std = math.floor(q);
                half16 usf = math.floor(q, p);

                for (int j = 0; j < 16; j++)
                {
                    if (math.isnan(q[j]))
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
    }
}
