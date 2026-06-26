using NUnit.Framework;


namespace MaxMath.Tests
{
    unsafe public static class f_approx
    {
        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(math.approx(float.NaN, rng.NextFloat()));
            Assert.IsFalse(math.approx(rng.NextFloat(), float.NaN));
            Assert.IsFalse(math.approx(rng.NextFloat(), float.PositiveInfinity));
            Assert.IsFalse(math.approx(float.NegativeInfinity, rng.NextFloat()));
            Assert.IsTrue( math.approx(float.NegativeInfinity, float.NegativeInfinity));
            Assert.IsTrue( math.approx(float.PositiveInfinity, float.PositiveInfinity));
            Assert.IsFalse(math.approx(float.PositiveInfinity, float.NegativeInfinity));
            Assert.IsFalse(math.approx(float.NegativeInfinity, float.PositiveInfinity));
            Assert.IsFalse(math.approx(-1f, 1f));
            Assert.IsTrue( math.approx(math.asfloat(1 << 31), 0f));

            for (int i = 0; i < 16; i++)
            {
                float f = rng.NextFloat();

                Assert.IsTrue(math.approx(f, f));
                Assert.IsTrue(math.approx(f, f + 5 * float.Epsilon));
                Assert.IsTrue(math.approx(f, f - 5 * float.Epsilon));

                f = rng.NextFloat(float.MinValue + 5 * float.Epsilon, float.MaxValue - 5 * float.Epsilon);

                Assert.IsTrue(math.approx(f, f));
                Assert.IsTrue(math.approx(f, f + 5 * float.Epsilon));
                Assert.IsTrue(math.approx(f, f - 5 * float.Epsilon));
            }
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(math.any(math.approx((float2)float.NaN, rng.NextFloat2())));
            Assert.IsFalse(math.any(math.approx((float2)rng.NextFloat(), (float2)float.NaN)));
            Assert.IsFalse(math.any(math.approx((float2)rng.NextFloat(), (float2)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float2)float.NegativeInfinity, rng.NextFloat2())));
            Assert.IsTrue( math.all(math.approx((float2)float.NegativeInfinity, (float2)float.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((float2)float.PositiveInfinity, (float2)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float2)float.PositiveInfinity, (float2)float.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((float2)float.NegativeInfinity, (float2)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float2)(-1f), (float2)1f)));
            Assert.IsTrue( math.all(math.approx((float2)math.asfloat(1 << 31), (float2)0f)));

            for (int i = 0; i < 16; i++)
            {
                float2 f = rng.NextFloat2();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));

                f = rng.NextFloat2(float.MinValue + 5 * float.Epsilon, float.MaxValue - 5 * float.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));
            }
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(math.any(math.approx((float3)float.NaN, rng.NextFloat3())));
            Assert.IsFalse(math.any(math.approx((float3)rng.NextFloat(), (float3)float.NaN)));
            Assert.IsFalse(math.any(math.approx((float3)rng.NextFloat(), (float3)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float3)float.NegativeInfinity, rng.NextFloat3())));
            Assert.IsTrue( math.all(math.approx((float3)float.NegativeInfinity, (float3)float.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((float3)float.PositiveInfinity, (float3)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float3)float.PositiveInfinity, (float3)float.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((float3)float.NegativeInfinity, (float3)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float3)(-1f), (float3)1f)));
            Assert.IsTrue( math.all(math.approx((float3)math.asfloat(1 << 31), (float3)0f)));

            for (int i = 0; i < 16; i++)
            {
                float3 f = rng.NextFloat3();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));

                f = rng.NextFloat3(float.MinValue + 5 * float.Epsilon, float.MaxValue - 5 * float.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));
            }
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(math.any(math.approx((float4)float.NaN, rng.NextFloat4())));
            Assert.IsFalse(math.any(math.approx((float4)rng.NextFloat(), (float4)float.NaN)));
            Assert.IsFalse(math.any(math.approx((float4)rng.NextFloat(), (float4)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float4)float.NegativeInfinity, rng.NextFloat4())));
            Assert.IsTrue( math.all(math.approx((float4)float.NegativeInfinity, (float4)float.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((float4)float.PositiveInfinity, (float4)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float4)float.PositiveInfinity, (float4)float.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((float4)float.NegativeInfinity, (float4)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float4)(-1f), (float4)1f)));
            Assert.IsTrue( math.all(math.approx((float4)math.asfloat(1 << 31), (float4)0f)));

            for (int i = 0; i < 16; i++)
            {
                float4 f = rng.NextFloat4();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));

                f = rng.NextFloat4(float.MinValue + 5 * float.Epsilon, float.MaxValue - 5 * float.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));
            }
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            Assert.IsFalse(math.any(math.approx((float8)float.NaN, rng.NextFloat8())));
            Assert.IsFalse(math.any(math.approx((float8)rng.NextFloat(), (float8)float.NaN)));
            Assert.IsFalse(math.any(math.approx((float8)rng.NextFloat(), (float8)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float8)float.NegativeInfinity, rng.NextFloat8())));
            Assert.IsTrue( math.all(math.approx((float8)float.NegativeInfinity, (float8)float.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((float8)float.PositiveInfinity, (float8)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float8)float.PositiveInfinity, (float8)float.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((float8)float.NegativeInfinity, (float8)float.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((float8)(-1f), (float8)1f)));
            Assert.IsTrue( math.all(math.approx((float8)math.asfloat(1 << 31), (float8)0f)));

            for (int i = 0; i < 16; i++)
            {
                float8 f = rng.NextFloat8();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));

                f = rng.NextFloat8(float.MinValue + 5 * float.Epsilon, float.MaxValue - 5 * float.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * float.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * float.Epsilon)));
            }
        }


        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            Assert.IsFalse(math.approx(double.NaN, rng.NextDouble()));
            Assert.IsFalse(math.approx(rng.NextDouble(), double.NaN));
            Assert.IsFalse(math.approx(rng.NextDouble(), double.PositiveInfinity));
            Assert.IsFalse(math.approx(double.NegativeInfinity, rng.NextDouble()));
            Assert.IsTrue( math.approx(double.NegativeInfinity, double.NegativeInfinity));
            Assert.IsTrue( math.approx(double.PositiveInfinity, double.PositiveInfinity));
            Assert.IsFalse(math.approx(double.PositiveInfinity, double.NegativeInfinity));
            Assert.IsFalse(math.approx(double.NegativeInfinity, double.PositiveInfinity));
            Assert.IsFalse(math.approx(-1f, 1f));
            Assert.IsTrue( math.approx(math.asdouble(1L << 63), 0f));

            for (int i = 0; i < 16; i++)
            {
                double f = rng.NextDouble();

                Assert.IsTrue(math.approx(f, f));
                Assert.IsTrue(math.approx(f, f + 5 * double.Epsilon));
                Assert.IsTrue(math.approx(f, f - 5 * double.Epsilon));

                f = rng.NextDouble(double.MinValue + 5 * double.Epsilon, double.MaxValue - 5 * double.Epsilon);

                Assert.IsTrue(math.approx(f, f));
                Assert.IsTrue(math.approx(f, f + 5 * double.Epsilon));
                Assert.IsTrue(math.approx(f, f - 5 * double.Epsilon));
            }
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            Assert.IsFalse(math.any(math.approx((double2)double.NaN, rng.NextDouble2())));
            Assert.IsFalse(math.any(math.approx((double2)rng.NextDouble(), (double2)double.NaN)));
            Assert.IsFalse(math.any(math.approx((double2)rng.NextDouble(), (double2)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double2)double.NegativeInfinity, rng.NextDouble2())));
            Assert.IsTrue( math.all(math.approx((double2)double.NegativeInfinity, (double2)double.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((double2)double.PositiveInfinity, (double2)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double2)double.PositiveInfinity, (double2)double.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((double2)double.NegativeInfinity, (double2)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double2)(-1f), (double2)1f)));
            Assert.IsTrue( math.all(math.approx((double2)math.asdouble(1L << 63), (double2)0f)));

            for (int i = 0; i < 16; i++)
            {
                double2 f = rng.NextDouble2();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));

                f = rng.NextDouble2(double.MinValue + 5 * double.Epsilon, double.MaxValue - 5 * double.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));
            }
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            Assert.IsFalse(math.any(math.approx((double3)double.NaN, rng.NextDouble3())));
            Assert.IsFalse(math.any(math.approx((double3)rng.NextDouble(), (double3)double.NaN)));
            Assert.IsFalse(math.any(math.approx((double3)rng.NextDouble(), (double3)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double3)double.NegativeInfinity, rng.NextDouble3())));
            Assert.IsTrue( math.all(math.approx((double3)double.NegativeInfinity, (double3)double.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((double3)double.PositiveInfinity, (double3)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double3)double.PositiveInfinity, (double3)double.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((double3)double.NegativeInfinity, (double3)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double3)(-1f), (double3)1f)));
            Assert.IsTrue( math.all(math.approx((double3)math.asdouble(1L << 63), (double3)0f)));

            for (int i = 0; i < 16; i++)
            {
                double3 f = rng.NextDouble3();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));

                f = rng.NextDouble3(double.MinValue + 5 * double.Epsilon, double.MaxValue - 5 * double.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));
            }
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            Assert.IsFalse(math.any(math.approx((double4)double.NaN, rng.NextDouble4())));
            Assert.IsFalse(math.any(math.approx((double4)rng.NextDouble(), (double4)double.NaN)));
            Assert.IsFalse(math.any(math.approx((double4)rng.NextDouble(), (double4)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double4)double.NegativeInfinity, rng.NextDouble4())));
            Assert.IsTrue( math.all(math.approx((double4)double.NegativeInfinity, (double4)double.NegativeInfinity)));
            Assert.IsTrue( math.all(math.approx((double4)double.PositiveInfinity, (double4)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double4)double.PositiveInfinity, (double4)double.NegativeInfinity)));
            Assert.IsFalse(math.any(math.approx((double4)double.NegativeInfinity, (double4)double.PositiveInfinity)));
            Assert.IsFalse(math.any(math.approx((double4)(-1f), (double4)1f)));
            Assert.IsTrue( math.all(math.approx((double4)math.asdouble(1L << 63), (double4)0f)));

            for (int i = 0; i < 16; i++)
            {
                double4 f = rng.NextDouble4();

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));

                f = rng.NextDouble4(double.MinValue + 5 * double.Epsilon, double.MaxValue - 5 * double.Epsilon);

                Assert.IsTrue(math.all(math.approx(f, f)));
                Assert.IsTrue(math.all(math.approx(f, f + 5 * double.Epsilon)));
                Assert.IsTrue(math.all(math.approx(f, f - 5 * double.Epsilon)));
            }
        }
    }
}
