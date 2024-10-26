using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_exp2_int
    {
        [Test]
        public static void _intToFloat()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int inRange = rng.NextInt(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int2ToFloat2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 inRange = rng.NextInt2(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int3ToFloat3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 inRange = rng.NextInt3(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int4ToFloat4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 inRange = rng.NextInt4(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _int8ToFloat8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 inRange = rng.NextInt8(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _uintToFloat()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint inRange = rng.NextUInt(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint2ToFloat2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint2 inRange = rng.NextUInt2(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint3ToFloat3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint3 inRange = rng.NextUInt3(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint4ToFloat4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint4 inRange = rng.NextUInt4(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _uint8ToFloat8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint8 inRange = rng.NextUInt8(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _longToDouble()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long inRange = rng.NextLong(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long2ToDouble2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long2 inRange = rng.NextLong2(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long3ToDouble3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long3 inRange = rng.NextLong3(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _long4ToDouble4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long4 inRange = rng.NextLong4(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }


        [Test]
        public static void _ulongToDouble()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong inRange = rng.NextULong(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong2ToDouble2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong2 inRange = rng.NextULong2(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong3ToDouble3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong3 inRange = rng.NextULong3(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }

        [Test]
        public static void _ulong4ToDouble4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong4 inRange = rng.NextULong4(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, Promise.NoOverflow));
            }
        }
    }
}
