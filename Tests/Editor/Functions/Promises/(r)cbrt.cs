using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_r_cbrt
    {
        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float2 l = math.abs(rng.NextFloat2() * 1_000_000f);

                Assert.AreEqual(maxmath.cbrt(l), maxmath.cbrt(l, maxmath.Promise.NoOverflow));
                Assert.AreEqual(maxmath.rcbrt(l), maxmath.rcbrt(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float3 l = math.abs(rng.NextFloat3() * 1_000_000f);

                Assert.AreEqual(maxmath.cbrt(l), maxmath.cbrt(l, maxmath.Promise.NoOverflow));
                Assert.AreEqual(maxmath.rcbrt(l), maxmath.rcbrt(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float4 l = math.abs(rng.NextFloat4() * 1_000_000f);

                Assert.AreEqual(maxmath.cbrt(l), maxmath.cbrt(l, maxmath.Promise.NoOverflow));
                Assert.AreEqual(maxmath.rcbrt(l), maxmath.rcbrt(l, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                float8 l = maxmath.abs(rng.NextFloat8() * 1_000_000f);

                Assert.AreEqual(maxmath.cbrt(l), maxmath.cbrt(l, maxmath.Promise.NoOverflow));
                Assert.AreEqual(maxmath.rcbrt(l), maxmath.rcbrt(l, maxmath.Promise.NoOverflow));
            }
        }
    }
}
