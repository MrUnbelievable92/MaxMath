using NUnit.Framework;

namespace MaxMath.Tests
{
    unsafe public static class f_isint
    {
        [Test]
        public static void _quarter()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter q = math.asquarter((byte)b);
                bool result = math.isint(q);

                if (math.isinf(q) || math.isnan(q))
                {
                    Assert.IsFalse(result);
                }
                else
                {
                    Assert.IsTrue(result == (math.trunc(q) == q));
                }

                b++;
            }
        }

        [Test]
        public static void _half()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half q = math.ashalf((ushort)b);
                bool result = math.isint(q);

                if (math.isinf(q) || math.isnan(q))
                {
                    Assert.IsFalse(result);
                }
                else
                {
                    Assert.IsTrue(result == (math.trunc(q) == q));
                }

                b++;
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint alias = rng.NextUInt();
                float f = math.asfloat(alias);
                bool result = math.isint(f);

                if (math.isinf(f) || math.isnan(f))
                {
                    Assert.IsFalse(result);
                }
                else
                {
                    Assert.IsTrue(result == (math.trunc(f) == f));
                }
            }
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                ulong alias = rng.NextULong();
                double f = math.asdouble(alias);
                bool result = math.isint(f);

                if (math.isinf(f) || math.isnan(f))
                {
                    Assert.IsFalse(result);
                }
                else
                {
                    Assert.IsTrue(result == (math.trunc(f) == f));
                }
            }
        }

        [Test]
        public static void _quadruple()
        {
            Random128 rng = Random128.New;

            for (int i = 0; i < 1000; i++)
            {
                UInt128 alias = rng.NextUInt128();
                quadruple f = math.asquadruple(alias);
                bool result = math.isint(f);

                if (math.isinf(f) || math.isnan(f))
                {
                    Assert.IsFalse(result);
                }
                else
                {
                    Assert.IsTrue(result == (math.trunc(f) == f));
                }
            }
        }

        [Test]
        public static void _quarter2()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter2 q = math.asquarter((byte)b);
                bool2 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _quarter3()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter3 q = math.asquarter((byte)b);
                bool3 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _quarter4()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter4 q = math.asquarter((byte)b);
                bool4 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _quarter8()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter8 q = math.asquarter((byte)b);
                bool8 result = math.isint(q);

                if (math.isinf(q.x0) || math.isnan(q.x0))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _quarter16()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter16 q = math.asquarter((byte)b);
                bool16 result = math.isint(q);

                if (math.isinf(q.x0) || math.isnan(q.x0))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _quarter32()
        {
            uint b = 0;

            while (b <= byte.MaxValue)
            {
                quarter32 q = math.asquarter((byte)b);
                bool32 result = math.isint(q);

                if (math.isinf(q.x0) || math.isnan(q.x0))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _half2()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half2 q = math.ashalf((ushort)b);
                bool2 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _half3()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half3 q = math.ashalf((ushort)b);
                bool3 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _half4()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half4 q = math.ashalf((ushort)b);
                bool4 result = math.isint(q);

                if (math.isinf(q.x) || math.isnan(q.x))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _half8()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half8 q = math.ashalf((ushort)b);
                bool8 result = math.isint(q);

                if (math.isinf(q.x0) || math.isnan(q.x0))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _half16()
        {
            uint b = 0;

            while (b <= ushort.MaxValue)
            {
                half16 q = math.ashalf((ushort)b);
                bool16 result = math.isint(q);

                if (math.isinf(q.x0) || math.isnan(q.x0))
                {
                    Assert.IsFalse(math.any(result));
                }
                else
                {
                    Assert.IsTrue(math.all(result == (math.trunc(q) == q)));
                }

                b++;
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint2 alias = rng.NextUInt2();
                float2 f = math.asfloat(alias);
                bool2 result = math.isint(f);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint3 alias = rng.NextUInt3();
                float3 f = math.asfloat(alias);
                bool3 result = math.isint(f);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint4 alias = rng.NextUInt4();
                float4 f = math.asfloat(alias);
                bool4 result = math.isint(f);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 1000; i++)
            {
                uint8 alias = rng.NextUInt8();
                float8 f = math.asfloat(alias);
                bool8 result = math.isint(f);

                for (int j = 0; j < 8; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                ulong2 alias = rng.NextULong2();
                double2 f = math.asdouble(alias);
                bool2 result = math.isint(f);

                for (int j = 0; j < 2; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                ulong3 alias = rng.NextULong3();
                double3 f = math.asdouble(alias);
                bool3 result = math.isint(f);

                for (int j = 0; j < 3; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            for (int i = 0; i < 1000; i++)
            {
                ulong4 alias = rng.NextULong4();
                double4 f = math.asdouble(alias);
                bool4 result = math.isint(f);

                for (int j = 0; j < 4; j++)
                {
                    if (math.isinf(f[j]) || math.isnan(f[j]))
                    {
                        Assert.IsFalse(result[j]);
                    }
                    else
                    {
                        Assert.IsTrue(result[j] == (math.trunc(f[j]) == f[j]));
                    }
                }
            }
        }
    }
}
