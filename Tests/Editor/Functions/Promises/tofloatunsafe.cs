using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_tofloatunsafe
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 24; i++)
            {
                quarter b = (quarter)rng.NextFloat(-15.5f, 15.5f);

                Assert.AreEqual((float)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.asbyte(b) != 1 << 7 ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 24; i++)
            {
                quarter2 b = (quarter2)rng.NextFloat2(-15.5f, 15.5f);

                Assert.AreEqual((float2)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float2)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 24; i++)
            {
                quarter3 b = (quarter3)rng.NextFloat3(-15.5f, 15.5f);

                Assert.AreEqual((float3)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float3)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 24; i++)
            {
                quarter4 b = (quarter4)rng.NextFloat4(-15.5f, 15.5f);

                Assert.AreEqual((float4)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float4)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random32 rng = Random32.New;

            for (float i = 0; i < 24; i++)
            {
                quarter8 b = (quarter8)rng.NextFloat8(-15.5f, 15.5f);

                Assert.AreEqual((float8)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float8)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half b = (half)rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual((float)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float)math.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.asushort(b) != 1 << 15 ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half2 b = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                Assert.AreEqual((float2)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float2)math.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half3 b = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                Assert.AreEqual((float3)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float3)math.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half4 b = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                Assert.AreEqual((float4)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float4)math.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half8 b = (half8)rng.NextFloat8(half.MinValue, half.MaxValue);

                Assert.AreEqual((float8)b, maxmath.tofloatunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((float8)maxmath.abs(b), maxmath.tofloatunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }
    }
}
