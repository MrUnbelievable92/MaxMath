using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_exp2_int
    {
        [Test]
        public static void IntToFloat()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int inRange = rng.NextInt(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Int2ToFloat2()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int2 inRange = rng.NextInt2(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Int3ToFloat3()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int3 inRange = rng.NextInt3(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Int4ToFloat4()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int4 inRange = rng.NextInt4(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Int8ToFloat8()
        {
            Random32 rng = Random32.New;

            for (int i = 0; i < 24; i++)
            {
                int8 inRange = rng.NextInt8(-127, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void UIntToFloat()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint inRange = rng.NextUInt(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void UInt2ToFloat2()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint2 inRange = rng.NextUInt2(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void UInt3ToFloat3()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint3 inRange = rng.NextUInt3(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void UInt4ToFloat4()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint4 inRange = rng.NextUInt4(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void UInt8ToFloat8()
        {
            Random32 rng = Random32.New;

            for (uint i = 0; i < 24; i++)
            {
                uint8 inRange = rng.NextUInt8(0, 129);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void LongToDouble()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long inRange = rng.NextLong(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Long2ToDouble2()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long2 inRange = rng.NextLong2(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Long3ToDouble3()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long3 inRange = rng.NextLong3(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void Long4ToDouble4()
        {
            Random64 rng = Random64.New;

            for (long i = 0; i < 24; i++)
            {
                long4 inRange = rng.NextLong4(-1023, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }


        [Test]
        public static void ULongToDouble()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong inRange = rng.NextULong(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void ULong2ToDouble2()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong2 inRange = rng.NextULong2(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void ULong3ToDouble3()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong3 inRange = rng.NextULong3(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }

        [Test]
        public static void ULong4ToDouble4()
        {
            Random64 rng = Random64.New;

            for (ulong i = 0; i < 24; i++)
            {
                ulong4 inRange = rng.NextULong4(0, 1025);

                Assert.AreEqual(maxmath.exp2(inRange), maxmath.exp2(inRange, maxmath.Promise.NoOverflow));
            }
        }
    }
}
