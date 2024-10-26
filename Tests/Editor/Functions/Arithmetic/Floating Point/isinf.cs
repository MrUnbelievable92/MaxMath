using NUnit.Framework;
using Unity.Mathematics;

using static MaxMath.maxmath;
using static Unity.Mathematics.math;

namespace MaxMath.Tests
{
    public static class f_isinf
    {
        [Test]
        public static void _quarter()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                quarter q = asquarter(rng.NextByte());

                Assert.AreEqual(isinf(q), isinf((float)q));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                quarter2 q = asquarter(rng.NextByte2());

                Assert.AreEqual(isinf(q), isinf((float2)q));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                quarter3 q = asquarter(rng.NextByte3());

                Assert.AreEqual(isinf(q), isinf((float3)q));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                quarter4 q = asquarter(rng.NextByte4());

                Assert.AreEqual(isinf(q), isinf((float4)q));
            }
        }

        [Test]
        public static void _quarter8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 64; i++)
            {
                quarter8 q = asquarter(rng.NextByte8());

                Assert.AreEqual(isinf(q), isinf((float8)q));
            }
        }


        [Test]
        public static void _half()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                half q = ashalf(rng.NextUShort());

                Assert.AreEqual(isinf(q), isinf((float)q));
            }
        }

        [Test]
        public static void _half2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                half2 q = ashalf(rng.NextUShort2());

                Assert.AreEqual(isinf(q), isinf((float2)q));
            }
        }

        [Test]
        public static void _half3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                half3 q = ashalf(rng.NextUShort3());

                Assert.AreEqual(isinf(q), isinf((float3)q));
            }
        }

        [Test]
        public static void _half4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                half4 q = ashalf(rng.NextUShort4());

                Assert.AreEqual(isinf(q), isinf((float4)q));
            }
        }

        [Test]
        public static void _half8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 64; i++)
            {
                half8 q = ashalf(rng.NextUShort8());

                Assert.AreEqual(isinf(q), isinf((float8)q));
            }
        }
    }
}
