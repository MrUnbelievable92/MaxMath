using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_todoubleunsafe
    {
        [Test]
        public static void _quarter()
        {
            Random32 rng = Random32.New;

            for (double i = 0; i < 24; i++)
            {
                quarter b = (quarter)rng.NextFloat(-15.5f, 15.5f);

                Assert.AreEqual((double)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double)maxmath.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.asbyte(b) != 1 << 7 ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter2()
        {
            Random32 rng = Random32.New;

            for (double i = 0; i < 24; i++)
            {
                quarter2 b = (quarter2)rng.NextFloat2(-15.5f, 15.5f);

                Assert.AreEqual((double2)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double2)maxmath.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter3()
        {
            Random32 rng = Random32.New;

            for (double i = 0; i < 24; i++)
            {
                quarter3 b = (quarter3)rng.NextFloat3(-15.5f, 15.5f);

                Assert.AreEqual((double3)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double3)maxmath.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _quarter4()
        {
            Random32 rng = Random32.New;

            for (double i = 0; i < 24; i++)
            {
                quarter4 b = (quarter4)rng.NextFloat4(-15.5f, 15.5f);

                Assert.AreEqual((double4)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double4)maxmath.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asbyte(b) != 1 << 7) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }


        [Test]
        public static void _half()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half b = (half)rng.NextFloat(half.MinValue, half.MaxValue);

                Assert.AreEqual((double)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double)math.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (maxmath.asushort(b) != 1 << 15 ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half2 b = (half2)rng.NextFloat2(half.MinValue, half.MaxValue);

                Assert.AreEqual((double2)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double2)math.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half3 b = (half3)rng.NextFloat3(half.MinValue, half.MaxValue);

                Assert.AreEqual((double3)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double3)math.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }

        [Test]
        public static void _half4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                half4 b = (half4)rng.NextFloat4(half.MinValue, half.MaxValue);

                Assert.AreEqual((double4)b, maxmath.todoubleunsafe(b, Promise.NoOverflow));
                Assert.AreEqual((double4)math.abs(b), maxmath.todoubleunsafe(maxmath.abs(b), Promise.NoOverflow | (math.all(maxmath.asushort(b) != 1 << 15) ? Promise.ZeroOrGreater : Promise.Nothing)));
            }
        }
    }
}
