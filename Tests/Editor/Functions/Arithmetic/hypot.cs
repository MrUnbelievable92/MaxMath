using NUnit.Framework;
using Unity.Mathematics;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath.Tests
{
    unsafe public static class f_hypot
    {
        private static double realhypot(float a, float b)
        {
            return sqrt(((double)a * a) + ((double)b * b));
        }
        private static quadruple realhypot(double a, double b)
        {
            return sqrt(((quadruple)a * a) + ((quadruple)b * b));
        }

        private static void TestFloat(float a, float b, float test)
        {
            if (realhypot(a, b) <= float.MaxValue)
            {
                Assert.IsTrue(asuint(test) >> 31 == 0);
                Assert.IsTrue(approx((float)realhypot(a, b), test));
            }
        }

        private static void TestDouble(double a, double b, double test)
        {
            if (realhypot(a, b) <= double.MaxValue)
            {
                Assert.IsTrue(asulong(test) >> 63 == 0);
                Assert.IsTrue(approx((double)realhypot(a, b), test));
            }
        }

        private static void TestByte(byte a, byte b, float test)
        {
            if (realhypot(a, b) <= byte.MaxValue)
            {
                Assert.IsTrue(asuint(test) >> 31 == 0);
                Assert.IsTrue(approx(hypot(a, b), test));
            }
        }

        private static void TestUShort(ushort a, ushort b, float test)
        {
            if (realhypot(a, b) <= ushort.MaxValue)
            {
                Assert.IsTrue(asuint(test) >> 31 == 0);
                Assert.IsTrue(approx(hypot(a, b), test));
            }
        }

        private static void TestSByte(sbyte a, sbyte b, float test)
        {
            if (realhypot(a, b) <= sbyte.MaxValue)
            {
                Assert.IsTrue(asuint(test) >> 31 == 0);
                Assert.IsTrue(approx(hypot(a, b), test));
            }
        }

        private static void TestShort(short a, short b, float test)
        {
            if (realhypot(a, b) <= short.MaxValue)
            {
                Assert.IsTrue(asuint(test) >> 31 == 0);
                Assert.IsTrue(approx(hypot(a, b), test));
            }
        }

        [Test]
        public static void _float()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(isnan(hypot(float.NaN, float.NaN)));
            Assert.IsTrue(isnan(hypot(float.NaN, 0f)));
            Assert.IsTrue(isnan(hypot(float.NaN, -0f)));
            Assert.IsTrue(isnan(hypot(0f, float.NaN)));
            Assert.IsTrue(isnan(hypot(-0f, float.NaN)));
            Assert.IsTrue(isnan(hypot(float.NaN, rng.NextFloat())));
            Assert.IsTrue(isnan(hypot(rng.NextFloat(), float.NaN)));

            Assert.IsTrue(float.PositiveInfinity == hypot(float.PositiveInfinity, float.PositiveInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.PositiveInfinity, 0f));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.PositiveInfinity, -0f));
            Assert.IsTrue(float.PositiveInfinity == hypot(0f, float.PositiveInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(-0f, float.PositiveInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.PositiveInfinity, rng.NextFloat()));
            Assert.IsTrue(float.PositiveInfinity == hypot(rng.NextFloat(), float.PositiveInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.NegativeInfinity, float.NegativeInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.NegativeInfinity, 0f));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.NegativeInfinity, -0f));
            Assert.IsTrue(float.PositiveInfinity == hypot(0f, float.NegativeInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(-0f, float.NegativeInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.NegativeInfinity, rng.NextFloat()));
            Assert.IsTrue(float.PositiveInfinity == hypot(rng.NextFloat(), float.NegativeInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.PositiveInfinity, float.NegativeInfinity));
            Assert.IsTrue(float.PositiveInfinity == hypot(float.NegativeInfinity, float.PositiveInfinity));

            Assert.IsTrue(asuint(+0f) == asuint(hypot(+0f, +0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(+0f, -0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(-0f, +0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(-0f, -0f)));

            Helper.TestFloat((test0, test1) => TestFloat(test0, test1, hypot(test0, test1)));
        }

        [Test]
        public static void _float2()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(all(isnan(hypot((float2)float.NaN, (float2)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float2)float.NaN, (float2)0f))));
            Assert.IsTrue(all(isnan(hypot((float2)float.NaN, (float2)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((float2)0f, (float2)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float2)(-0f), (float2)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float2)float.NaN, (float2)rng.NextFloat2()))));
            Assert.IsTrue(all(isnan(hypot((float2)rng.NextFloat2(), (float2)float.NaN))));

            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.PositiveInfinity, (float2)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.PositiveInfinity, (float2)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.PositiveInfinity, (float2)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)0f, (float2)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)(-0f), (float2)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.PositiveInfinity, (float2)rng.NextFloat2())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)rng.NextFloat2(), (float2)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.NegativeInfinity, (float2)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.NegativeInfinity, (float2)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.NegativeInfinity, (float2)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)0f, (float2)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)(-0f), (float2)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.NegativeInfinity, (float2)rng.NextFloat2())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)rng.NextFloat2(), (float2)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.PositiveInfinity, (float2)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float2)float.NegativeInfinity, (float2)float.PositiveInfinity)));

            Assert.IsTrue(all(asuint((float2)(+0f)) == asuint(hypot((float2)(+0f), (float2)(+0f)))));
            Assert.IsTrue(all(asuint((float2)(+0f)) == asuint(hypot((float2)(+0f), (float2)(-0f)))));
            Assert.IsTrue(all(asuint((float2)(+0f)) == asuint(hypot((float2)(-0f), (float2)(+0f)))));
            Assert.IsTrue(all(asuint((float2)(+0f)) == asuint(hypot((float2)(-0f), (float2)(-0f)))));

            Helper.TestFloat2(
            (test0, test1) =>
            {
                for (int i = 0; i < 2; i++)
                {
                    TestFloat(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _float3()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(all(isnan(hypot((float3)float.NaN, (float3)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float3)float.NaN, (float3)0f))));
            Assert.IsTrue(all(isnan(hypot((float3)float.NaN, (float3)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((float3)0f, (float3)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float3)(-0f), (float3)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float3)float.NaN, (float3)rng.NextFloat3()))));
            Assert.IsTrue(all(isnan(hypot((float3)rng.NextFloat3(), (float3)float.NaN))));

            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.PositiveInfinity, (float3)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.PositiveInfinity, (float3)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.PositiveInfinity, (float3)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)0f, (float3)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)(-0f), (float3)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.PositiveInfinity, (float3)rng.NextFloat3())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)rng.NextFloat3(), (float3)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.NegativeInfinity, (float3)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.NegativeInfinity, (float3)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.NegativeInfinity, (float3)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)0f, (float3)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)(-0f), (float3)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.NegativeInfinity, (float3)rng.NextFloat3())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)rng.NextFloat3(), (float3)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.PositiveInfinity, (float3)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float3)float.NegativeInfinity, (float3)float.PositiveInfinity)));

            Assert.IsTrue(all(asuint((float3)(+0f)) == asuint(hypot((float3)(+0f), (float3)(+0f)))));
            Assert.IsTrue(all(asuint((float3)(+0f)) == asuint(hypot((float3)(+0f), (float3)(-0f)))));
            Assert.IsTrue(all(asuint((float3)(+0f)) == asuint(hypot((float3)(-0f), (float3)(+0f)))));
            Assert.IsTrue(all(asuint((float3)(+0f)) == asuint(hypot((float3)(-0f), (float3)(-0f)))));

            Helper.TestFloat3(
            (test0, test1) =>
            {
                for (int i = 0; i < 3; i++)
                {
                    TestFloat(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _float4()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(all(isnan(hypot((float4)float.NaN, (float4)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float4)float.NaN, (float4)0f))));
            Assert.IsTrue(all(isnan(hypot((float4)float.NaN, (float4)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((float4)0f, (float4)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float4)(-0f), (float4)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float4)float.NaN, (float4)rng.NextFloat4()))));
            Assert.IsTrue(all(isnan(hypot((float4)rng.NextFloat4(), (float4)float.NaN))));

            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.PositiveInfinity, (float4)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.PositiveInfinity, (float4)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.PositiveInfinity, (float4)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)0f, (float4)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)(-0f), (float4)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.PositiveInfinity, (float4)rng.NextFloat4())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)rng.NextFloat4(), (float4)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.NegativeInfinity, (float4)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.NegativeInfinity, (float4)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.NegativeInfinity, (float4)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)0f, (float4)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)(-0f), (float4)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.NegativeInfinity, (float4)rng.NextFloat4())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)rng.NextFloat4(), (float4)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.PositiveInfinity, (float4)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float4)float.NegativeInfinity, (float4)float.PositiveInfinity)));

            Assert.IsTrue(all(asuint((float4)(+0f)) == asuint(hypot((float4)(+0f), (float4)(+0f)))));
            Assert.IsTrue(all(asuint((float4)(+0f)) == asuint(hypot((float4)(+0f), (float4)(-0f)))));
            Assert.IsTrue(all(asuint((float4)(+0f)) == asuint(hypot((float4)(-0f), (float4)(+0f)))));
            Assert.IsTrue(all(asuint((float4)(+0f)) == asuint(hypot((float4)(-0f), (float4)(-0f)))));

            Helper.TestFloat4(
            (test0, test1) =>
            {
                for (int i = 0; i < 4; i++)
                {
                    TestFloat(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _float8()
        {
            Random32 rng = Random32.New;

            Assert.IsTrue(all(isnan(hypot((float8)float.NaN, (float8)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float8)float.NaN, (float8)0f))));
            Assert.IsTrue(all(isnan(hypot((float8)float.NaN, (float8)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((float8)0f, (float8)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float8)(-0f), (float8)float.NaN))));
            Assert.IsTrue(all(isnan(hypot((float8)float.NaN, (float8)rng.NextFloat8()))));
            Assert.IsTrue(all(isnan(hypot((float8)rng.NextFloat8(), (float8)float.NaN))));

            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.PositiveInfinity, (float8)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.PositiveInfinity, (float8)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.PositiveInfinity, (float8)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)0f, (float8)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)(-0f), (float8)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.PositiveInfinity, (float8)rng.NextFloat8())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)rng.NextFloat8(), (float8)float.PositiveInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.NegativeInfinity, (float8)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.NegativeInfinity, (float8)0f)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.NegativeInfinity, (float8)(-0f))));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)0f, (float8)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)(-0f), (float8)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.NegativeInfinity, (float8)rng.NextFloat8())));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)rng.NextFloat8(), (float8)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.PositiveInfinity, (float8)float.NegativeInfinity)));
            Assert.IsTrue(all(float.PositiveInfinity == hypot((float8)float.NegativeInfinity, (float8)float.PositiveInfinity)));

            Assert.IsTrue(all(asuint((float8)(+0f)) == asuint(hypot((float8)(+0f), (float8)(+0f)))));
            Assert.IsTrue(all(asuint((float8)(+0f)) == asuint(hypot((float8)(+0f), (float8)(-0f)))));
            Assert.IsTrue(all(asuint((float8)(+0f)) == asuint(hypot((float8)(-0f), (float8)(+0f)))));
            Assert.IsTrue(all(asuint((float8)(+0f)) == asuint(hypot((float8)(-0f), (float8)(-0f)))));

            Helper.TestFloat8(
            (test0, test1) =>
            {
                for (int i = 0; i < 8; i++)
                {
                    TestFloat(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _double()
        {
            Random64 rng = Random64.New;

            Assert.IsTrue(isnan(hypot(double.NaN, double.NaN)));
            Assert.IsTrue(isnan(hypot(double.NaN, 0f)));
            Assert.IsTrue(isnan(hypot(double.NaN, -0f)));
            Assert.IsTrue(isnan(hypot(0f, double.NaN)));
            Assert.IsTrue(isnan(hypot(-0f, double.NaN)));
            Assert.IsTrue(isnan(hypot(double.NaN, rng.NextDouble())));
            Assert.IsTrue(isnan(hypot(rng.NextDouble(), double.NaN)));

            Assert.IsTrue(double.PositiveInfinity == hypot(double.PositiveInfinity, double.PositiveInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.PositiveInfinity, 0f));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.PositiveInfinity, -0f));
            Assert.IsTrue(double.PositiveInfinity == hypot(0f, double.PositiveInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(-0f, double.PositiveInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.PositiveInfinity, rng.NextDouble()));
            Assert.IsTrue(double.PositiveInfinity == hypot(rng.NextDouble(), double.PositiveInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.NegativeInfinity, double.NegativeInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.NegativeInfinity, 0f));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.NegativeInfinity, -0f));
            Assert.IsTrue(double.PositiveInfinity == hypot(0f, double.NegativeInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(-0f, double.NegativeInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.NegativeInfinity, rng.NextDouble()));
            Assert.IsTrue(double.PositiveInfinity == hypot(rng.NextDouble(), double.NegativeInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.PositiveInfinity, double.NegativeInfinity));
            Assert.IsTrue(double.PositiveInfinity == hypot(double.NegativeInfinity, double.PositiveInfinity));

            Assert.IsTrue(asuint(+0f) == asuint(hypot(+0f, +0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(+0f, -0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(-0f, +0f)));
            Assert.IsTrue(asuint(+0f) == asuint(hypot(-0f, -0f)));

            Helper.TestDouble((test0, test1) => TestDouble(test0, test1, hypot(test0, test1)));
        }

        [Test]
        public static void _double2()
        {
            Random64 rng = Random64.New;

            Assert.IsTrue(all(isnan(hypot((double2)double.NaN, (double2)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double2)double.NaN, (double2)0f))));
            Assert.IsTrue(all(isnan(hypot((double2)double.NaN, (double2)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((double2)0f, (double2)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double2)(-0f), (double2)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double2)double.NaN, (double2)rng.NextDouble2()))));
            Assert.IsTrue(all(isnan(hypot((double2)rng.NextDouble2(), (double2)double.NaN))));

            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.PositiveInfinity, (double2)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.PositiveInfinity, (double2)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.PositiveInfinity, (double2)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)0f, (double2)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)(-0f), (double2)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.PositiveInfinity, (double2)rng.NextDouble2())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)rng.NextDouble2(), (double2)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.NegativeInfinity, (double2)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.NegativeInfinity, (double2)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.NegativeInfinity, (double2)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)0f, (double2)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)(-0f), (double2)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.NegativeInfinity, (double2)rng.NextDouble2())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)rng.NextDouble2(), (double2)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.PositiveInfinity, (double2)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double2)double.NegativeInfinity, (double2)double.PositiveInfinity)));

            Assert.IsTrue(all(asulong((double2)(+0f)) == asulong(hypot((double2)(+0f), (double2)(+0f)))));
            Assert.IsTrue(all(asulong((double2)(+0f)) == asulong(hypot((double2)(+0f), (double2)(-0f)))));
            Assert.IsTrue(all(asulong((double2)(+0f)) == asulong(hypot((double2)(-0f), (double2)(+0f)))));
            Assert.IsTrue(all(asulong((double2)(+0f)) == asulong(hypot((double2)(-0f), (double2)(-0f)))));

            Helper.TestDouble2(
            (test0, test1) =>
            {
                for (int i = 0; i < 2; i++)
                {
                    TestDouble(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _double3()
        {
            Random64 rng = Random64.New;

            Assert.IsTrue(all(isnan(hypot((double3)double.NaN, (double3)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double3)double.NaN, (double3)0f))));
            Assert.IsTrue(all(isnan(hypot((double3)double.NaN, (double3)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((double3)0f, (double3)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double3)(-0f), (double3)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double3)double.NaN, (double3)rng.NextDouble3()))));
            Assert.IsTrue(all(isnan(hypot((double3)rng.NextDouble3(), (double3)double.NaN))));

            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.PositiveInfinity, (double3)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.PositiveInfinity, (double3)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.PositiveInfinity, (double3)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)0f, (double3)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)(-0f), (double3)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.PositiveInfinity, (double3)rng.NextDouble3())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)rng.NextDouble3(), (double3)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.NegativeInfinity, (double3)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.NegativeInfinity, (double3)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.NegativeInfinity, (double3)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)0f, (double3)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)(-0f), (double3)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.NegativeInfinity, (double3)rng.NextDouble3())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)rng.NextDouble3(), (double3)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.PositiveInfinity, (double3)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double3)double.NegativeInfinity, (double3)double.PositiveInfinity)));

            Assert.IsTrue(all(asulong((double3)(+0f)) == asulong(hypot((double3)(+0f), (double3)(+0f)))));
            Assert.IsTrue(all(asulong((double3)(+0f)) == asulong(hypot((double3)(+0f), (double3)(-0f)))));
            Assert.IsTrue(all(asulong((double3)(+0f)) == asulong(hypot((double3)(-0f), (double3)(+0f)))));
            Assert.IsTrue(all(asulong((double3)(+0f)) == asulong(hypot((double3)(-0f), (double3)(-0f)))));

            Helper.TestDouble3(
            (test0, test1) =>
            {
                for (int i = 0; i < 3; i++)
                {
                    TestDouble(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _double4()
        {
            Random64 rng = Random64.New;

            Assert.IsTrue(all(isnan(hypot((double4)double.NaN, (double4)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double4)double.NaN, (double4)0f))));
            Assert.IsTrue(all(isnan(hypot((double4)double.NaN, (double4)(-0f)))));
            Assert.IsTrue(all(isnan(hypot((double4)0f, (double4)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double4)(-0f), (double4)double.NaN))));
            Assert.IsTrue(all(isnan(hypot((double4)double.NaN, (double4)rng.NextDouble4()))));
            Assert.IsTrue(all(isnan(hypot((double4)rng.NextDouble4(), (double4)double.NaN))));

            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.PositiveInfinity, (double4)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.PositiveInfinity, (double4)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.PositiveInfinity, (double4)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)0f, (double4)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)(-0f), (double4)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.PositiveInfinity, (double4)rng.NextDouble4())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)rng.NextDouble4(), (double4)double.PositiveInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.NegativeInfinity, (double4)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.NegativeInfinity, (double4)0f)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.NegativeInfinity, (double4)(-0f))));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)0f, (double4)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)(-0f), (double4)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.NegativeInfinity, (double4)rng.NextDouble4())));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)rng.NextDouble4(), (double4)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.PositiveInfinity, (double4)double.NegativeInfinity)));
            Assert.IsTrue(all(double.PositiveInfinity == hypot((double4)double.NegativeInfinity, (double4)double.PositiveInfinity)));

            Assert.IsTrue(all(asulong((double4)(+0f)) == asulong(hypot((double4)(+0f), (double4)(+0f)))));
            Assert.IsTrue(all(asulong((double4)(+0f)) == asulong(hypot((double4)(+0f), (double4)(-0f)))));
            Assert.IsTrue(all(asulong((double4)(+0f)) == asulong(hypot((double4)(-0f), (double4)(+0f)))));
            Assert.IsTrue(all(asulong((double4)(+0f)) == asulong(hypot((double4)(-0f), (double4)(-0f)))));

            Helper.TestDouble4(
            (test0, test1) =>
            {
                for (int i = 0; i < 4; i++)
                {
                    TestDouble(test0[i], test1[i], hypot(test0[i], test1[i]));
                }
            });
        }

        [Test]
        public static void _byte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte a = rng.NextByte();
                byte b = rng.NextByte();
                float test = hypot(a, b);

                TestByte(a, b, test);
            }
        }

        [Test]
        public static void _byte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte2 a = rng.NextByte2();
                byte2 b = rng.NextByte2();
                float2 test = hypot(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte3 a = rng.NextByte3();
                byte3 b = rng.NextByte3();
                float3 test = hypot(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte4 a = rng.NextByte4();
                byte4 b = rng.NextByte4();
                float4 test = hypot(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _byte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                byte8 a = rng.NextByte8();
                byte8 b = rng.NextByte8();
                float8 test = hypot(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestByte(a[j], b[j], test[j]);
                }
            }
        }


        [Test]
        public static void _sbyte()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte a = rng.NextSByte();
                sbyte b = rng.NextSByte();
                float test = hypot(a, b);

                TestSByte(a, b, test);
            }
        }

        [Test]
        public static void _sbyte2()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte2 a = rng.NextSByte2();
                sbyte2 b = rng.NextSByte2();
                float2 test = hypot(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestSByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _sbyte3()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte3 a = rng.NextSByte3();
                sbyte3 b = rng.NextSByte3();
                float3 test = hypot(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestSByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _sbyte4()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte4 a = rng.NextSByte4();
                sbyte4 b = rng.NextSByte4();
                float4 test = hypot(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestSByte(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _sbyte8()
        {
            Random8 rng = Random8.New;

            for (int i = 0; i < 32; i++)
            {
                sbyte8 a = rng.NextSByte8();
                sbyte8 b = rng.NextSByte8();
                float8 test = hypot(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestSByte(a[j], b[j], test[j]);
                }
            }
        }


        [Test]
        public static void _ushort()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort a = rng.NextUShort();
                ushort b = rng.NextUShort();
                float test = hypot(a, b);

                TestUShort(a, b, test);
            }
        }

        [Test]
        public static void _ushort2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort2 a = rng.NextUShort2();
                ushort2 b = rng.NextUShort2();
                float2 test = hypot(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestUShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort3 a = rng.NextUShort3();
                ushort3 b = rng.NextUShort3();
                float3 test = hypot(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestUShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort4 a = rng.NextUShort4();
                ushort4 b = rng.NextUShort4();
                float4 test = hypot(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestUShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _ushort8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                ushort8 a = rng.NextUShort8();
                ushort8 b = rng.NextUShort8();
                float8 test = hypot(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestUShort(a[j], b[j], test[j]);
                }
            }
        }


        [Test]
        public static void _short()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short a = rng.NextShort();
                short b = rng.NextShort();
                float test = hypot(a, b);

                TestShort(a, b, test);
            }
        }

        [Test]
        public static void _short2()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short2 a = rng.NextShort2();
                short2 b = rng.NextShort2();
                float2 test = hypot(a, b);

                for (int j = 0; j < 2; j++)
                {
                    TestShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _short3()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short3 a = rng.NextShort3();
                short3 b = rng.NextShort3();
                float3 test = hypot(a, b);

                for (int j = 0; j < 3; j++)
                {
                    TestShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _short4()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short4 a = rng.NextShort4();
                short4 b = rng.NextShort4();
                float4 test = hypot(a, b);

                for (int j = 0; j < 4; j++)
                {
                    TestShort(a[j], b[j], test[j]);
                }
            }
        }

        [Test]
        public static void _short8()
        {
            Random16 rng = Random16.New;

            for (int i = 0; i < 32; i++)
            {
                short8 a = rng.NextShort8();
                short8 b = rng.NextShort8();
                float8 test = hypot(a, b);

                for (int j = 0; j < 8; j++)
                {
                    TestShort(a[j], b[j], test[j]);
                }
            }
        }
    }
}
