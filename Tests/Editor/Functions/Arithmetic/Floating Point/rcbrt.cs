using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_rcbrt
    {
        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnan(math.rcbrt(float.NaN)));
            Assert.AreEqual(math.rcbrt(0f), float.PositiveInfinity);
            Assert.AreEqual(math.asint(math.rcbrt(math.asfloat(1 << 31))), math.asint(float.NegativeInfinity));

            Assert.AreEqual(math.rcbrt(float.PositiveInfinity), 0f);
            Assert.AreEqual(math.asint(math.rcbrt(float.NegativeInfinity)), 1 << 31);

            Helper.TestFloat(test => Assert.IsTrue(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1f / test)));
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((float2)float.NaN))));
            Assert.AreEqual(math.rcbrt((float2)0f), (float2)float.PositiveInfinity);
            Assert.AreEqual(math.asint(math.rcbrt((float2)math.asfloat(1 << 31))), math.asint((float2)float.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((float2)float.PositiveInfinity), (float2)0f);
            Assert.AreEqual(math.asint(math.rcbrt((float2)float.NegativeInfinity)), (int2)1 << 31);

            Helper.TestFloat2(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1f / test))));
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((float3)float.NaN))));
            Assert.AreEqual(math.rcbrt((float3)0f), (float3)float.PositiveInfinity);
            Assert.AreEqual(math.asint(math.rcbrt((float3)math.asfloat(1 << 31))), math.asint((float3)float.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((float3)float.PositiveInfinity), (float3)0f);
            Assert.AreEqual(math.asint(math.rcbrt((float3)float.NegativeInfinity)), (int3)1 << 31);

            Helper.TestFloat3(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1f / test))));
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((float4)float.NaN))));
            Assert.AreEqual(math.rcbrt((float4)0f), (float4)float.PositiveInfinity);
            Assert.AreEqual(math.asint(math.rcbrt((float4)math.asfloat(1 << 31))), math.asint((float4)float.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((float4)float.PositiveInfinity), (float4)0f);
            Assert.AreEqual(math.asint(math.rcbrt((float4)float.NegativeInfinity)), (int4)1 << 31);

            Helper.TestFloat4(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1f / test))));
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((float8)float.NaN))));
            Assert.AreEqual(math.rcbrt((float8)0f), (float8)float.PositiveInfinity);
            Assert.AreEqual(math.asint(math.rcbrt((float8)math.asfloat(1 << 31))), math.asint((float8)float.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((float8)float.PositiveInfinity), (float8)0f);
            Assert.AreEqual(math.asint(math.rcbrt((float8)float.NegativeInfinity)), (int8)1 << 31);

            Helper.TestFloat8(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1f / test))));
        }


        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnan(math.rcbrt(double.NaN)));
            Assert.AreEqual(math.rcbrt(0d), double.PositiveInfinity);
            Assert.AreEqual(math.aslong(math.rcbrt(math.asdouble(1L << 63))), math.aslong(double.NegativeInfinity));

            Assert.AreEqual(math.rcbrt(double.PositiveInfinity), 0d);
            Assert.AreEqual(math.aslong(math.rcbrt(double.NegativeInfinity)), 1L << 63);

            Helper.TestDouble(test => Assert.IsTrue(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1d / test)));
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((double2)double.NaN))));
            Assert.AreEqual(math.rcbrt((double2)0d), (double2)double.PositiveInfinity);
            Assert.AreEqual(math.aslong(math.rcbrt((double2)math.asdouble(1L << 63))), math.aslong((double2)double.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((double2)double.PositiveInfinity), (double2)0d);
            Assert.AreEqual(math.aslong(math.rcbrt((double2)double.NegativeInfinity)), (long2)1L << 63);

            Helper.TestDouble2(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1d / test))));
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((double3)double.NaN))));
            Assert.AreEqual(math.rcbrt((double3)0d), (double3)double.PositiveInfinity);
            Assert.AreEqual(math.aslong(math.rcbrt((double3)math.asdouble(1L << 63))), math.aslong((double3)double.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((double3)double.PositiveInfinity), (double3)0d);
            Assert.AreEqual(math.aslong(math.rcbrt((double3)double.NegativeInfinity)), (long3)1L << 63);

            Helper.TestDouble3(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1d / test))));
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnan(math.rcbrt((double4)double.NaN))));
            Assert.AreEqual(math.rcbrt((double4)0d), (double4)double.PositiveInfinity);
            Assert.AreEqual(math.aslong(math.rcbrt((double4)math.asdouble(1L << 63))), math.aslong((double4)double.NegativeInfinity));

            Assert.AreEqual(math.rcbrt((double4)double.PositiveInfinity), (double4)0d);
            Assert.AreEqual(math.aslong(math.rcbrt((double4)double.NegativeInfinity)), (long4)1L << 63);

            Helper.TestDouble4(test => Assert.IsTrue(math.all(math.approx(math.rcbrt(test) * math.rcbrt(test) * math.rcbrt(test), 1d / test))));
        }
    }
}
