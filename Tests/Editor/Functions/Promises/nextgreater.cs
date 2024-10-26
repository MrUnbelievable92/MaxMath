using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class f_PROMISE_nextgreater
    {
        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(maxmath.nextgreater((quarter)(1.747f)),  maxmath.nextgreater((quarter)(1.747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((quarter)(1.747f)),  maxmath.nextgreater((quarter)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter)(1.747f)),  maxmath.nextgreater((quarter)(1.747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((quarter)(-1.747f)), maxmath.nextgreater((quarter)(-1.747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((quarter)(1.747f)),  maxmath.nextgreater((quarter)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter)(1.747f)),  maxmath.nextgreater((quarter)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter)(-1.747f)), maxmath.nextgreater((quarter)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual(maxmath.nextgreater((quarter2)(1.747f)),  maxmath.nextgreater((quarter2)(1.747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((quarter2)(1.747f)),  maxmath.nextgreater((quarter2)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter2)(1.747f)),  maxmath.nextgreater((quarter2)(1.747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((quarter2)(-1.747f)), maxmath.nextgreater((quarter2)(-1.747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((quarter2)(1.747f)),  maxmath.nextgreater((quarter2)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter2)(1.747f)),  maxmath.nextgreater((quarter2)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter2)(-1.747f)), maxmath.nextgreater((quarter2)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual(maxmath.nextgreater((quarter3)(1.747f)),  maxmath.nextgreater((quarter3)(1.747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((quarter3)(1.747f)),  maxmath.nextgreater((quarter3)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter3)(1.747f)),  maxmath.nextgreater((quarter3)(1.747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((quarter3)(-1.747f)), maxmath.nextgreater((quarter3)(-1.747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((quarter3)(1.747f)),  maxmath.nextgreater((quarter3)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter3)(1.747f)),  maxmath.nextgreater((quarter3)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter3)(-1.747f)), maxmath.nextgreater((quarter3)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual(maxmath.nextgreater((quarter4)(1.747f)),  maxmath.nextgreater((quarter4)(1.747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((quarter4)(1.747f)),  maxmath.nextgreater((quarter4)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter4)(1.747f)),  maxmath.nextgreater((quarter4)(1.747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((quarter4)(-1.747f)), maxmath.nextgreater((quarter4)(-1.747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((quarter4)(1.747f)),  maxmath.nextgreater((quarter4)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter4)(1.747f)),  maxmath.nextgreater((quarter4)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter4)(-1.747f)), maxmath.nextgreater((quarter4)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual(maxmath.nextgreater((quarter8)(1.747f)),  maxmath.nextgreater((quarter8)(1.747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((quarter8)(1.747f)),  maxmath.nextgreater((quarter8)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter8)(1.747f)),  maxmath.nextgreater((quarter8)(1.747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((quarter8)(-1.747f)), maxmath.nextgreater((quarter8)(-1.747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((quarter8)(1.747f)),  maxmath.nextgreater((quarter8)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter8)(1.747f)),  maxmath.nextgreater((quarter8)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((quarter8)(-1.747f)), maxmath.nextgreater((quarter8)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(maxmath.nextgreater((half)(1747f)),  maxmath.nextgreater((half)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((half)(1747f)),  maxmath.nextgreater((half)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half)(1747f)),  maxmath.nextgreater((half)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((half)(-1747f)), maxmath.nextgreater((half)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((half)(1747f)),  maxmath.nextgreater((half)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half)(1747f)),  maxmath.nextgreater((half)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half)(-1747f)), maxmath.nextgreater((half)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual(maxmath.nextgreater((half2)(1747f)),  maxmath.nextgreater((half2)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((half2)(1747f)),  maxmath.nextgreater((half2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half2)(1747f)),  maxmath.nextgreater((half2)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((half2)(-1747f)), maxmath.nextgreater((half2)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((half2)(1747f)),  maxmath.nextgreater((half2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half2)(1747f)),  maxmath.nextgreater((half2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half2)(-1747f)), maxmath.nextgreater((half2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual(maxmath.nextgreater((half3)(1747f)),  maxmath.nextgreater((half3)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((half3)(1747f)),  maxmath.nextgreater((half3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half3)(1747f)),  maxmath.nextgreater((half3)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((half3)(-1747f)), maxmath.nextgreater((half3)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((half3)(1747f)),  maxmath.nextgreater((half3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half3)(1747f)),  maxmath.nextgreater((half3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half3)(-1747f)), maxmath.nextgreater((half3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual(maxmath.nextgreater((half4)(1747f)),  maxmath.nextgreater((half4)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((half4)(1747f)),  maxmath.nextgreater((half4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half4)(1747f)),  maxmath.nextgreater((half4)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((half4)(-1747f)), maxmath.nextgreater((half4)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((half4)(1747f)),  maxmath.nextgreater((half4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half4)(1747f)),  maxmath.nextgreater((half4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half4)(-1747f)), maxmath.nextgreater((half4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual(maxmath.nextgreater((half8)(1747f)),  maxmath.nextgreater((half8)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((half8)(1747f)),  maxmath.nextgreater((half8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half8)(1747f)),  maxmath.nextgreater((half8)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((half8)(-1747f)), maxmath.nextgreater((half8)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((half8)(1747f)),  maxmath.nextgreater((half8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half8)(1747f)),  maxmath.nextgreater((half8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((half8)(-1747f)), maxmath.nextgreater((half8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _float()
        {
            Assert.AreEqual(maxmath.nextgreater(1747f),  maxmath.nextgreater(1747f, Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater(1747f),  maxmath.nextgreater(1747f, Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(1747f),  maxmath.nextgreater(1747f, Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater(-1747f), maxmath.nextgreater(-1747f, Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater(1747f),  maxmath.nextgreater(1747f, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(1747f),  maxmath.nextgreater(1747f, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(-1747f), maxmath.nextgreater(-1747f, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float2()
        {
            Assert.AreEqual(maxmath.nextgreater((float2)(1747f)),  maxmath.nextgreater((float2)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((float2)(1747f)),  maxmath.nextgreater((float2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float2)(1747f)),  maxmath.nextgreater((float2)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((float2)(-1747f)), maxmath.nextgreater((float2)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((float2)(1747f)),  maxmath.nextgreater((float2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float2)(1747f)),  maxmath.nextgreater((float2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float2)(-1747f)), maxmath.nextgreater((float2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float3()
        {
            Assert.AreEqual(maxmath.nextgreater((float3)(1747f)),  maxmath.nextgreater((float3)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((float3)(1747f)),  maxmath.nextgreater((float3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float3)(1747f)),  maxmath.nextgreater((float3)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((float3)(-1747f)), maxmath.nextgreater((float3)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((float3)(1747f)),  maxmath.nextgreater((float3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float3)(1747f)),  maxmath.nextgreater((float3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float3)(-1747f)), maxmath.nextgreater((float3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float4()
        {
            Assert.AreEqual(maxmath.nextgreater((float4)(1747f)),  maxmath.nextgreater((float4)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((float4)(1747f)),  maxmath.nextgreater((float4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float4)(1747f)),  maxmath.nextgreater((float4)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((float4)(-1747f)), maxmath.nextgreater((float4)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((float4)(1747f)),  maxmath.nextgreater((float4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float4)(1747f)),  maxmath.nextgreater((float4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float4)(-1747f)), maxmath.nextgreater((float4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float8()
        {
            Assert.AreEqual(maxmath.nextgreater((float8)(1747f)),  maxmath.nextgreater((float8)(1747f), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((float8)(1747f)),  maxmath.nextgreater((float8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float8)(1747f)),  maxmath.nextgreater((float8)(1747f), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((float8)(-1747f)), maxmath.nextgreater((float8)(-1747f), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((float8)(1747f)),  maxmath.nextgreater((float8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float8)(1747f)),  maxmath.nextgreater((float8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((float8)(-1747f)), maxmath.nextgreater((float8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _double()
        {
            Assert.AreEqual(maxmath.nextgreater(1747d),  maxmath.nextgreater(1747d, Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater(1747d),  maxmath.nextgreater(1747d, Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(1747d),  maxmath.nextgreater(1747d, Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater(-1747d), maxmath.nextgreater(-1747d, Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater(1747d),  maxmath.nextgreater(1747d, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(1747d),  maxmath.nextgreater(1747d, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater(-1747d), maxmath.nextgreater(-1747d, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double2()
        {
            Assert.AreEqual(maxmath.nextgreater((double2)(1747d)),  maxmath.nextgreater((double2)(1747d), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((double2)(1747d)),  maxmath.nextgreater((double2)(1747d), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double2)(1747d)),  maxmath.nextgreater((double2)(1747d), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((double2)(-1747d)), maxmath.nextgreater((double2)(-1747d), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((double2)(1747d)),  maxmath.nextgreater((double2)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double2)(1747d)),  maxmath.nextgreater((double2)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double2)(-1747d)), maxmath.nextgreater((double2)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double3()
        {
            Assert.AreEqual(maxmath.nextgreater((double3)(1747d)),  maxmath.nextgreater((double3)(1747d), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((double3)(1747d)),  maxmath.nextgreater((double3)(1747d), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double3)(1747d)),  maxmath.nextgreater((double3)(1747d), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((double3)(-1747d)), maxmath.nextgreater((double3)(-1747d), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((double3)(1747d)),  maxmath.nextgreater((double3)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double3)(1747d)),  maxmath.nextgreater((double3)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double3)(-1747d)), maxmath.nextgreater((double3)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double4()
        {
            Assert.AreEqual(maxmath.nextgreater((double4)(1747d)),  maxmath.nextgreater((double4)(1747d), Promise.NonZero));
            Assert.AreEqual(maxmath.nextgreater((double4)(1747d)),  maxmath.nextgreater((double4)(1747d), Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double4)(1747d)),  maxmath.nextgreater((double4)(1747d), Promise.Positive));
            Assert.AreEqual(maxmath.nextgreater((double4)(-1747d)), maxmath.nextgreater((double4)(-1747d), Promise.Negative));

            Assert.AreEqual(maxmath.nextgreater((double4)(1747d)),  maxmath.nextgreater((double4)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double4)(1747d)),  maxmath.nextgreater((double4)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextgreater((double4)(-1747d)), maxmath.nextgreater((double4)(-1747d), Promise.Negative | Promise.Unsafe0));
        }
    }
}
