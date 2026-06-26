using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_nextsmaller
    {
        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(math.nextsmaller((quarter)(1.747f)),  math.nextsmaller((quarter)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter)(1.747f)),  math.nextsmaller((quarter)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter)(1.747f)),  math.nextsmaller((quarter)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter)(-1.747f)), math.nextsmaller((quarter)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter)(1.747f)),  math.nextsmaller((quarter)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter)(1.747f)),  math.nextsmaller((quarter)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter)(-1.747f)), math.nextsmaller((quarter)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual(math.nextsmaller((quarter2)(1.747f)),  math.nextsmaller((quarter2)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter2)(1.747f)),  math.nextsmaller((quarter2)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter2)(1.747f)),  math.nextsmaller((quarter2)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter2)(-1.747f)), math.nextsmaller((quarter2)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter2)(1.747f)),  math.nextsmaller((quarter2)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter2)(1.747f)),  math.nextsmaller((quarter2)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter2)(-1.747f)), math.nextsmaller((quarter2)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual(math.nextsmaller((quarter3)(1.747f)),  math.nextsmaller((quarter3)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter3)(1.747f)),  math.nextsmaller((quarter3)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter3)(1.747f)),  math.nextsmaller((quarter3)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter3)(-1.747f)), math.nextsmaller((quarter3)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter3)(1.747f)),  math.nextsmaller((quarter3)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter3)(1.747f)),  math.nextsmaller((quarter3)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter3)(-1.747f)), math.nextsmaller((quarter3)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual(math.nextsmaller((quarter4)(1.747f)),  math.nextsmaller((quarter4)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter4)(1.747f)),  math.nextsmaller((quarter4)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter4)(1.747f)),  math.nextsmaller((quarter4)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter4)(-1.747f)), math.nextsmaller((quarter4)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter4)(1.747f)),  math.nextsmaller((quarter4)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter4)(1.747f)),  math.nextsmaller((quarter4)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter4)(-1.747f)), math.nextsmaller((quarter4)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual(math.nextsmaller((quarter8)(1.747f)),  math.nextsmaller((quarter8)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter8)(1.747f)),  math.nextsmaller((quarter8)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter8)(1.747f)),  math.nextsmaller((quarter8)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter8)(-1.747f)), math.nextsmaller((quarter8)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter8)(1.747f)),  math.nextsmaller((quarter8)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter8)(1.747f)),  math.nextsmaller((quarter8)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter8)(-1.747f)), math.nextsmaller((quarter8)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.AreEqual(math.nextsmaller((quarter16)(1.747f)),  math.nextsmaller((quarter16)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter16)(1.747f)),  math.nextsmaller((quarter16)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter16)(1.747f)),  math.nextsmaller((quarter16)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter16)(-1.747f)), math.nextsmaller((quarter16)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter16)(1.747f)),  math.nextsmaller((quarter16)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter16)(1.747f)),  math.nextsmaller((quarter16)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter16)(-1.747f)), math.nextsmaller((quarter16)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.AreEqual(math.nextsmaller((quarter32)(1.747f)),  math.nextsmaller((quarter32)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((quarter32)(1.747f)),  math.nextsmaller((quarter32)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter32)(1.747f)),  math.nextsmaller((quarter32)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((quarter32)(-1.747f)), math.nextsmaller((quarter32)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((quarter32)(1.747f)),  math.nextsmaller((quarter32)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter32)(1.747f)),  math.nextsmaller((quarter32)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((quarter32)(-1.747f)), math.nextsmaller((quarter32)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(math.nextsmaller((half)(1747f)),  math.nextsmaller((half)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half)(1747f)),  math.nextsmaller((half)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half)(1747f)),  math.nextsmaller((half)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half)(-1747f)), math.nextsmaller((half)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half)(1747f)),  math.nextsmaller((half)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half)(1747f)),  math.nextsmaller((half)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half)(-1747f)), math.nextsmaller((half)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual(math.nextsmaller((half2)(1747f)),  math.nextsmaller((half2)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half2)(1747f)),  math.nextsmaller((half2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half2)(1747f)),  math.nextsmaller((half2)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half2)(-1747f)), math.nextsmaller((half2)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half2)(1747f)),  math.nextsmaller((half2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half2)(1747f)),  math.nextsmaller((half2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half2)(-1747f)), math.nextsmaller((half2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual(math.nextsmaller((half3)(1747f)),  math.nextsmaller((half3)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half3)(1747f)),  math.nextsmaller((half3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half3)(1747f)),  math.nextsmaller((half3)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half3)(-1747f)), math.nextsmaller((half3)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half3)(1747f)),  math.nextsmaller((half3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half3)(1747f)),  math.nextsmaller((half3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half3)(-1747f)), math.nextsmaller((half3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual(math.nextsmaller((half4)(1747f)),  math.nextsmaller((half4)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half4)(1747f)),  math.nextsmaller((half4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half4)(1747f)),  math.nextsmaller((half4)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half4)(-1747f)), math.nextsmaller((half4)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half4)(1747f)),  math.nextsmaller((half4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half4)(1747f)),  math.nextsmaller((half4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half4)(-1747f)), math.nextsmaller((half4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual(math.nextsmaller((half8)(1747f)),  math.nextsmaller((half8)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half8)(1747f)),  math.nextsmaller((half8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half8)(1747f)),  math.nextsmaller((half8)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half8)(-1747f)), math.nextsmaller((half8)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half8)(1747f)),  math.nextsmaller((half8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half8)(1747f)),  math.nextsmaller((half8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half8)(-1747f)), math.nextsmaller((half8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half16()
        {
            Assert.AreEqual(math.nextsmaller((half16)(1747f)),  math.nextsmaller((half16)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((half16)(1747f)),  math.nextsmaller((half16)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half16)(1747f)),  math.nextsmaller((half16)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((half16)(-1747f)), math.nextsmaller((half16)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((half16)(1747f)),  math.nextsmaller((half16)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half16)(1747f)),  math.nextsmaller((half16)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((half16)(-1747f)), math.nextsmaller((half16)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _float()
        {
            Assert.AreEqual(math.nextsmaller(1747f),  math.nextsmaller(1747f, Promise.NonZero));
            Assert.AreEqual(math.nextsmaller(1747f),  math.nextsmaller(1747f, Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(1747f),  math.nextsmaller(1747f, Promise.Positive));
            Assert.AreEqual(math.nextsmaller(-1747f), math.nextsmaller(-1747f, Promise.Negative));

            Assert.AreEqual(math.nextsmaller(1747f),  math.nextsmaller(1747f, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(1747f),  math.nextsmaller(1747f, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(-1747f), math.nextsmaller(-1747f, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float2()
        {
            Assert.AreEqual(math.nextsmaller((float2)(1747f)),  math.nextsmaller((float2)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((float2)(1747f)),  math.nextsmaller((float2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float2)(1747f)),  math.nextsmaller((float2)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((float2)(-1747f)), math.nextsmaller((float2)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((float2)(1747f)),  math.nextsmaller((float2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float2)(1747f)),  math.nextsmaller((float2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float2)(-1747f)), math.nextsmaller((float2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float3()
        {
            Assert.AreEqual(math.nextsmaller((float3)(1747f)),  math.nextsmaller((float3)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((float3)(1747f)),  math.nextsmaller((float3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float3)(1747f)),  math.nextsmaller((float3)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((float3)(-1747f)), math.nextsmaller((float3)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((float3)(1747f)),  math.nextsmaller((float3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float3)(1747f)),  math.nextsmaller((float3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float3)(-1747f)), math.nextsmaller((float3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float4()
        {
            Assert.AreEqual(math.nextsmaller((float4)(1747f)),  math.nextsmaller((float4)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((float4)(1747f)),  math.nextsmaller((float4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float4)(1747f)),  math.nextsmaller((float4)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((float4)(-1747f)), math.nextsmaller((float4)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((float4)(1747f)),  math.nextsmaller((float4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float4)(1747f)),  math.nextsmaller((float4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float4)(-1747f)), math.nextsmaller((float4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float8()
        {
            Assert.AreEqual(math.nextsmaller((float8)(1747f)),  math.nextsmaller((float8)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((float8)(1747f)),  math.nextsmaller((float8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float8)(1747f)),  math.nextsmaller((float8)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((float8)(-1747f)), math.nextsmaller((float8)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((float8)(1747f)),  math.nextsmaller((float8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float8)(1747f)),  math.nextsmaller((float8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((float8)(-1747f)), math.nextsmaller((float8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _double()
        {
            Assert.AreEqual(math.nextsmaller(1747d),  math.nextsmaller(1747d, Promise.NonZero));
            Assert.AreEqual(math.nextsmaller(1747d),  math.nextsmaller(1747d, Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(1747d),  math.nextsmaller(1747d, Promise.Positive));
            Assert.AreEqual(math.nextsmaller(-1747d), math.nextsmaller(-1747d, Promise.Negative));

            Assert.AreEqual(math.nextsmaller(1747d),  math.nextsmaller(1747d, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(1747d),  math.nextsmaller(1747d, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller(-1747d), math.nextsmaller(-1747d, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double2()
        {
            Assert.AreEqual(math.nextsmaller((double2)(1747d)),  math.nextsmaller((double2)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((double2)(1747d)),  math.nextsmaller((double2)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double2)(1747d)),  math.nextsmaller((double2)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((double2)(-1747d)), math.nextsmaller((double2)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((double2)(1747d)),  math.nextsmaller((double2)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double2)(1747d)),  math.nextsmaller((double2)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double2)(-1747d)), math.nextsmaller((double2)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double3()
        {
            Assert.AreEqual(math.nextsmaller((double3)(1747d)),  math.nextsmaller((double3)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((double3)(1747d)),  math.nextsmaller((double3)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double3)(1747d)),  math.nextsmaller((double3)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((double3)(-1747d)), math.nextsmaller((double3)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((double3)(1747d)),  math.nextsmaller((double3)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double3)(1747d)),  math.nextsmaller((double3)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double3)(-1747d)), math.nextsmaller((double3)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double4()
        {
            Assert.AreEqual(math.nextsmaller((double4)(1747d)),  math.nextsmaller((double4)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextsmaller((double4)(1747d)),  math.nextsmaller((double4)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double4)(1747d)),  math.nextsmaller((double4)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextsmaller((double4)(-1747d)), math.nextsmaller((double4)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextsmaller((double4)(1747d)),  math.nextsmaller((double4)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double4)(1747d)),  math.nextsmaller((double4)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextsmaller((double4)(-1747d)), math.nextsmaller((double4)(-1747d), Promise.Negative | Promise.Unsafe0));
        }
    }
}
