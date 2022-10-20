using NUnit.Framework;
using Unity.Mathematics;

namespace MaxMath.Tests
{
    public static class PROMISE_nextsmaller
    {
        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(maxmath.nextsmaller((quarter)(1.747f)),  maxmath.nextsmaller((quarter)(1.747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((quarter)(1.747f)),  maxmath.nextsmaller((quarter)(1.747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter)(1.747f)),  maxmath.nextsmaller((quarter)(1.747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((quarter)(-1.747f)), maxmath.nextsmaller((quarter)(-1.747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((quarter)(1.747f)),  maxmath.nextsmaller((quarter)(1.747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter)(1.747f)),  maxmath.nextsmaller((quarter)(1.747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter)(-1.747f)), maxmath.nextsmaller((quarter)(-1.747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(1.747f)),  maxmath.nextsmaller((quarter2)(1.747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(1.747f)),  maxmath.nextsmaller((quarter2)(1.747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(1.747f)),  maxmath.nextsmaller((quarter2)(1.747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(-1.747f)), maxmath.nextsmaller((quarter2)(-1.747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((quarter2)(1.747f)),  maxmath.nextsmaller((quarter2)(1.747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(1.747f)),  maxmath.nextsmaller((quarter2)(1.747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter2)(-1.747f)), maxmath.nextsmaller((quarter2)(-1.747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(1.747f)),  maxmath.nextsmaller((quarter3)(1.747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(1.747f)),  maxmath.nextsmaller((quarter3)(1.747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(1.747f)),  maxmath.nextsmaller((quarter3)(1.747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(-1.747f)), maxmath.nextsmaller((quarter3)(-1.747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((quarter3)(1.747f)),  maxmath.nextsmaller((quarter3)(1.747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(1.747f)),  maxmath.nextsmaller((quarter3)(1.747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter3)(-1.747f)), maxmath.nextsmaller((quarter3)(-1.747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(1.747f)),  maxmath.nextsmaller((quarter4)(1.747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(1.747f)),  maxmath.nextsmaller((quarter4)(1.747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(1.747f)),  maxmath.nextsmaller((quarter4)(1.747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(-1.747f)), maxmath.nextsmaller((quarter4)(-1.747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((quarter4)(1.747f)),  maxmath.nextsmaller((quarter4)(1.747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(1.747f)),  maxmath.nextsmaller((quarter4)(1.747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter4)(-1.747f)), maxmath.nextsmaller((quarter4)(-1.747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(1.747f)),  maxmath.nextsmaller((quarter8)(1.747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(1.747f)),  maxmath.nextsmaller((quarter8)(1.747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(1.747f)),  maxmath.nextsmaller((quarter8)(1.747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(-1.747f)), maxmath.nextsmaller((quarter8)(-1.747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((quarter8)(1.747f)),  maxmath.nextsmaller((quarter8)(1.747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(1.747f)),  maxmath.nextsmaller((quarter8)(1.747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((quarter8)(-1.747f)), maxmath.nextsmaller((quarter8)(-1.747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(maxmath.nextsmaller((half)(1747f)),  maxmath.nextsmaller((half)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((half)(1747f)),  maxmath.nextsmaller((half)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half)(1747f)),  maxmath.nextsmaller((half)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((half)(-1747f)), maxmath.nextsmaller((half)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((half)(1747f)),  maxmath.nextsmaller((half)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half)(1747f)),  maxmath.nextsmaller((half)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half)(-1747f)), maxmath.nextsmaller((half)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual(maxmath.nextsmaller((half2)(1747f)),  maxmath.nextsmaller((half2)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((half2)(1747f)),  maxmath.nextsmaller((half2)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half2)(1747f)),  maxmath.nextsmaller((half2)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((half2)(-1747f)), maxmath.nextsmaller((half2)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((half2)(1747f)),  maxmath.nextsmaller((half2)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half2)(1747f)),  maxmath.nextsmaller((half2)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half2)(-1747f)), maxmath.nextsmaller((half2)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual(maxmath.nextsmaller((half3)(1747f)),  maxmath.nextsmaller((half3)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((half3)(1747f)),  maxmath.nextsmaller((half3)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half3)(1747f)),  maxmath.nextsmaller((half3)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((half3)(-1747f)), maxmath.nextsmaller((half3)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((half3)(1747f)),  maxmath.nextsmaller((half3)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half3)(1747f)),  maxmath.nextsmaller((half3)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half3)(-1747f)), maxmath.nextsmaller((half3)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual(maxmath.nextsmaller((half4)(1747f)),  maxmath.nextsmaller((half4)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((half4)(1747f)),  maxmath.nextsmaller((half4)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half4)(1747f)),  maxmath.nextsmaller((half4)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((half4)(-1747f)), maxmath.nextsmaller((half4)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((half4)(1747f)),  maxmath.nextsmaller((half4)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half4)(1747f)),  maxmath.nextsmaller((half4)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half4)(-1747f)), maxmath.nextsmaller((half4)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual(maxmath.nextsmaller((half8)(1747f)),  maxmath.nextsmaller((half8)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((half8)(1747f)),  maxmath.nextsmaller((half8)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half8)(1747f)),  maxmath.nextsmaller((half8)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((half8)(-1747f)), maxmath.nextsmaller((half8)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((half8)(1747f)),  maxmath.nextsmaller((half8)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half8)(1747f)),  maxmath.nextsmaller((half8)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((half8)(-1747f)), maxmath.nextsmaller((half8)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }


        [Test]
        public static void _float()
        {
            Assert.AreEqual(maxmath.nextsmaller(1747f),  maxmath.nextsmaller(1747f, maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller(1747f),  maxmath.nextsmaller(1747f, maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(1747f),  maxmath.nextsmaller(1747f, maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller(-1747f), maxmath.nextsmaller(-1747f, maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller(1747f),  maxmath.nextsmaller(1747f, maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(1747f),  maxmath.nextsmaller(1747f, maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(-1747f), maxmath.nextsmaller(-1747f, maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _float2()
        {
            Assert.AreEqual(maxmath.nextsmaller((float2)(1747f)),  maxmath.nextsmaller((float2)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((float2)(1747f)),  maxmath.nextsmaller((float2)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float2)(1747f)),  maxmath.nextsmaller((float2)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((float2)(-1747f)), maxmath.nextsmaller((float2)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((float2)(1747f)),  maxmath.nextsmaller((float2)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float2)(1747f)),  maxmath.nextsmaller((float2)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float2)(-1747f)), maxmath.nextsmaller((float2)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _float3()
        {
            Assert.AreEqual(maxmath.nextsmaller((float3)(1747f)),  maxmath.nextsmaller((float3)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((float3)(1747f)),  maxmath.nextsmaller((float3)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float3)(1747f)),  maxmath.nextsmaller((float3)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((float3)(-1747f)), maxmath.nextsmaller((float3)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((float3)(1747f)),  maxmath.nextsmaller((float3)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float3)(1747f)),  maxmath.nextsmaller((float3)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float3)(-1747f)), maxmath.nextsmaller((float3)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _float4()
        {
            Assert.AreEqual(maxmath.nextsmaller((float4)(1747f)),  maxmath.nextsmaller((float4)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((float4)(1747f)),  maxmath.nextsmaller((float4)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float4)(1747f)),  maxmath.nextsmaller((float4)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((float4)(-1747f)), maxmath.nextsmaller((float4)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((float4)(1747f)),  maxmath.nextsmaller((float4)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float4)(1747f)),  maxmath.nextsmaller((float4)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float4)(-1747f)), maxmath.nextsmaller((float4)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _float8()
        {
            Assert.AreEqual(maxmath.nextsmaller((float8)(1747f)),  maxmath.nextsmaller((float8)(1747f), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((float8)(1747f)),  maxmath.nextsmaller((float8)(1747f), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float8)(1747f)),  maxmath.nextsmaller((float8)(1747f), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((float8)(-1747f)), maxmath.nextsmaller((float8)(-1747f), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((float8)(1747f)),  maxmath.nextsmaller((float8)(1747f), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float8)(1747f)),  maxmath.nextsmaller((float8)(1747f), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((float8)(-1747f)), maxmath.nextsmaller((float8)(-1747f), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        
        [Test]
        public static void _double()
        {
            Assert.AreEqual(maxmath.nextsmaller(1747d),  maxmath.nextsmaller(1747d, maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller(1747d),  maxmath.nextsmaller(1747d, maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(1747d),  maxmath.nextsmaller(1747d, maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller(-1747d), maxmath.nextsmaller(-1747d, maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller(1747d),  maxmath.nextsmaller(1747d, maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(1747d),  maxmath.nextsmaller(1747d, maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller(-1747d), maxmath.nextsmaller(-1747d, maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _double2()
        {
            Assert.AreEqual(maxmath.nextsmaller((double2)(1747d)),  maxmath.nextsmaller((double2)(1747d), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((double2)(1747d)),  maxmath.nextsmaller((double2)(1747d), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double2)(1747d)),  maxmath.nextsmaller((double2)(1747d), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((double2)(-1747d)), maxmath.nextsmaller((double2)(-1747d), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((double2)(1747d)),  maxmath.nextsmaller((double2)(1747d), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double2)(1747d)),  maxmath.nextsmaller((double2)(1747d), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double2)(-1747d)), maxmath.nextsmaller((double2)(-1747d), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _double3()
        {
            Assert.AreEqual(maxmath.nextsmaller((double3)(1747d)),  maxmath.nextsmaller((double3)(1747d), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((double3)(1747d)),  maxmath.nextsmaller((double3)(1747d), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double3)(1747d)),  maxmath.nextsmaller((double3)(1747d), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((double3)(-1747d)), maxmath.nextsmaller((double3)(-1747d), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((double3)(1747d)),  maxmath.nextsmaller((double3)(1747d), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double3)(1747d)),  maxmath.nextsmaller((double3)(1747d), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double3)(-1747d)), maxmath.nextsmaller((double3)(-1747d), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }

        [Test]
        public static void _double4()
        {
            Assert.AreEqual(maxmath.nextsmaller((double4)(1747d)),  maxmath.nextsmaller((double4)(1747d), maxmath.Promise.NonZero));
            Assert.AreEqual(maxmath.nextsmaller((double4)(1747d)),  maxmath.nextsmaller((double4)(1747d), maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double4)(1747d)),  maxmath.nextsmaller((double4)(1747d), maxmath.Promise.Positive));
            Assert.AreEqual(maxmath.nextsmaller((double4)(-1747d)), maxmath.nextsmaller((double4)(-1747d), maxmath.Promise.Negative));

            Assert.AreEqual(maxmath.nextsmaller((double4)(1747d)),  maxmath.nextsmaller((double4)(1747d), maxmath.Promise.NonZero | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double4)(1747d)),  maxmath.nextsmaller((double4)(1747d), maxmath.Promise.Positive | maxmath.Promise.Unsafe0));
            Assert.AreEqual(maxmath.nextsmaller((double4)(-1747d)), maxmath.nextsmaller((double4)(-1747d), maxmath.Promise.Negative | maxmath.Promise.Unsafe0));
        }
    }
}
