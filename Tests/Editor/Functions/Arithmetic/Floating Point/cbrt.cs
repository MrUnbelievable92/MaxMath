using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_cbrt
    {
        [Test]
        public static void _float()
        {
            Assert.IsTrue(math.isnan(math.cbrt(float.NaN)));
            Assert.AreEqual(math.cbrt(0f), 0f);
            Assert.AreEqual(math.asint(math.cbrt(math.asfloat(1 << 31))), 1 << 31);

            Assert.AreEqual(math.cbrt(float.PositiveInfinity), float.PositiveInfinity);
            Assert.AreEqual(math.cbrt(float.NegativeInfinity), float.NegativeInfinity);

            Helper.TestFloat(test => Assert.IsTrue(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test)));
        }

        [Test]
        public static void _float2()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((float2)float.NaN))));
            Assert.AreEqual(math.cbrt((float2)0f), (float2)0f);
            Assert.AreEqual(math.asint(math.cbrt((float2)math.asfloat(1 << 31))), math.asint((float2)math.asfloat(1 << 31)));

            Assert.AreEqual(math.cbrt((float2)float.PositiveInfinity), (float2)float.PositiveInfinity);
            Assert.AreEqual(math.cbrt((float2)float.NegativeInfinity), (float2)float.NegativeInfinity);

            Helper.TestFloat2(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }

        [Test]
        public static void _float3()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((float3)float.NaN))));
            Assert.AreEqual(math.cbrt((float3)0f), (float3)0f);
            Assert.AreEqual(math.asint(math.cbrt((float3)math.asfloat(1 << 31))), math.asint((float3)math.asfloat(1 << 31)));

            Assert.AreEqual(math.cbrt((float3)float.PositiveInfinity), (float3)float.PositiveInfinity);
            Assert.AreEqual(math.cbrt((float3)float.NegativeInfinity), (float3)float.NegativeInfinity);

            Helper.TestFloat3(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }

        [Test]
        public static void _float4()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((float4)float.NaN))));
            Assert.AreEqual(math.cbrt((float4)0f), (float4)0f);
            Assert.AreEqual(math.asint(math.cbrt((float4)math.asfloat(1 << 31))), math.asint((float4)math.asfloat(1 << 31)));

            Assert.AreEqual(math.cbrt((float4)float.PositiveInfinity), (float4)float.PositiveInfinity);
            Assert.AreEqual(math.cbrt((float4)float.NegativeInfinity), (float4)float.NegativeInfinity);

            Helper.TestFloat4(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }

        [Test]
        public static void _float8()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((float8)float.NaN))));
            Assert.AreEqual(math.cbrt((float8)0f), (float8)0f);
            Assert.AreEqual(math.asint(math.cbrt((float8)math.asfloat(1 << 31))), math.asint((float8)math.asfloat(1 << 31)));

            Assert.AreEqual(math.cbrt((float8)float.PositiveInfinity), (float8)float.PositiveInfinity);
            Assert.AreEqual(math.cbrt((float8)float.NegativeInfinity), (float8)float.NegativeInfinity);

            Helper.TestFloat8(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }


        [Test]
        public static void _double()
        {
            Assert.IsTrue(math.isnan(math.cbrt(float.NaN)));
            Assert.AreEqual(math.cbrt(0d), 0d);
            Assert.AreEqual(math.aslong(math.cbrt(math.asdouble(1L << 63))), 1L << 63);

            Assert.AreEqual(math.cbrt(double.PositiveInfinity), double.PositiveInfinity);
            Assert.AreEqual(math.cbrt(double.NegativeInfinity), double.NegativeInfinity);

            Helper.TestDouble(test => Assert.IsTrue(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test)));
        }

        [Test]
        public static void _double2()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((double2)double.NaN))));
            Assert.AreEqual(math.cbrt((double2)0d), (double2)0d);
            Assert.AreEqual(math.aslong(math.cbrt((double2)math.asdouble(1L << 63))), math.aslong((double2)math.asdouble(1L << 63)));

            Assert.AreEqual(math.cbrt((double2)double.PositiveInfinity), (double2)double.PositiveInfinity);
            Assert.AreEqual(math.cbrt((double2)double.NegativeInfinity), (double2)double.NegativeInfinity);

            Helper.TestDouble2(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }

        [Test]
        public static void _double3()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((double3)double.NaN))));
            Assert.AreEqual(math.cbrt((double3)0d), (double3)0d);
            Assert.AreEqual(math.aslong(math.cbrt((double3)math.asdouble(1L << 63))), math.aslong((double3)math.asdouble(1L << 63)));

            Assert.AreEqual(math.cbrt((double3)double.PositiveInfinity), (double3)double.PositiveInfinity);
            Assert.AreEqual(math.cbrt((double3)double.NegativeInfinity), (double3)double.NegativeInfinity);

            Helper.TestDouble3(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }

        [Test]
        public static void _double4()
        {
            Assert.IsTrue(math.all(math.isnan(math.cbrt((double4)double.NaN))));
            Assert.AreEqual(math.cbrt((double4)0d), (double4)0d);
            Assert.AreEqual(math.aslong(math.cbrt((double4)math.asdouble(1L << 63))), math.aslong((double4)math.asdouble(1L << 63)));

            Assert.AreEqual(math.cbrt((double4)double.PositiveInfinity), (double4)double.PositiveInfinity);
            Assert.AreEqual(math.cbrt((double4)double.NegativeInfinity), (double4)double.NegativeInfinity);

            Helper.TestDouble4(test => Assert.IsTrue(math.all(math.approx(math.cbrt(test) * math.cbrt(test) * math.cbrt(test), test))));
        }
    }
}
