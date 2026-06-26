using NUnit.Framework;


namespace MaxMath.Tests
{
    public static class f_PROMISE_nextgreater
    {
        [Test]
        public static void _quarter()
        {
            Assert.AreEqual(math.nextgreater((quarter)(1.747f)),  math.nextgreater((quarter)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter)(1.747f)),  math.nextgreater((quarter)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter)(1.747f)),  math.nextgreater((quarter)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter)(-1.747f)), math.nextgreater((quarter)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter)(1.747f)),  math.nextgreater((quarter)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter)(1.747f)),  math.nextgreater((quarter)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter)(-1.747f)), math.nextgreater((quarter)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter2()
        {
            Assert.AreEqual(math.nextgreater((quarter2)(1.747f)),  math.nextgreater((quarter2)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter2)(1.747f)),  math.nextgreater((quarter2)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter2)(1.747f)),  math.nextgreater((quarter2)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter2)(-1.747f)), math.nextgreater((quarter2)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter2)(1.747f)),  math.nextgreater((quarter2)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter2)(1.747f)),  math.nextgreater((quarter2)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter2)(-1.747f)), math.nextgreater((quarter2)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter3()
        {
            Assert.AreEqual(math.nextgreater((quarter3)(1.747f)),  math.nextgreater((quarter3)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter3)(1.747f)),  math.nextgreater((quarter3)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter3)(1.747f)),  math.nextgreater((quarter3)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter3)(-1.747f)), math.nextgreater((quarter3)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter3)(1.747f)),  math.nextgreater((quarter3)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter3)(1.747f)),  math.nextgreater((quarter3)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter3)(-1.747f)), math.nextgreater((quarter3)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter4()
        {
            Assert.AreEqual(math.nextgreater((quarter4)(1.747f)),  math.nextgreater((quarter4)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter4)(1.747f)),  math.nextgreater((quarter4)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter4)(1.747f)),  math.nextgreater((quarter4)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter4)(-1.747f)), math.nextgreater((quarter4)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter4)(1.747f)),  math.nextgreater((quarter4)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter4)(1.747f)),  math.nextgreater((quarter4)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter4)(-1.747f)), math.nextgreater((quarter4)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter8()
        {
            Assert.AreEqual(math.nextgreater((quarter8)(1.747f)),  math.nextgreater((quarter8)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter8)(1.747f)),  math.nextgreater((quarter8)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter8)(1.747f)),  math.nextgreater((quarter8)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter8)(-1.747f)), math.nextgreater((quarter8)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter8)(1.747f)),  math.nextgreater((quarter8)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter8)(1.747f)),  math.nextgreater((quarter8)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter8)(-1.747f)), math.nextgreater((quarter8)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter16()
        {
            Assert.AreEqual(math.nextgreater((quarter16)(1.747f)),  math.nextgreater((quarter16)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter16)(1.747f)),  math.nextgreater((quarter16)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter16)(1.747f)),  math.nextgreater((quarter16)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter16)(-1.747f)), math.nextgreater((quarter16)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter16)(1.747f)),  math.nextgreater((quarter16)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter16)(1.747f)),  math.nextgreater((quarter16)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter16)(-1.747f)), math.nextgreater((quarter16)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _quarter32()
        {
            Assert.AreEqual(math.nextgreater((quarter32)(1.747f)),  math.nextgreater((quarter32)(1.747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((quarter32)(1.747f)),  math.nextgreater((quarter32)(1.747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter32)(1.747f)),  math.nextgreater((quarter32)(1.747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((quarter32)(-1.747f)), math.nextgreater((quarter32)(-1.747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((quarter32)(1.747f)),  math.nextgreater((quarter32)(1.747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter32)(1.747f)),  math.nextgreater((quarter32)(1.747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((quarter32)(-1.747f)), math.nextgreater((quarter32)(-1.747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _half()
        {
            Assert.AreEqual(math.nextgreater((half)(1747f)),  math.nextgreater((half)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half)(1747f)),  math.nextgreater((half)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half)(1747f)),  math.nextgreater((half)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half)(-1747f)), math.nextgreater((half)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half)(1747f)),  math.nextgreater((half)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half)(1747f)),  math.nextgreater((half)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half)(-1747f)), math.nextgreater((half)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half2()
        {
            Assert.AreEqual(math.nextgreater((half2)(1747f)),  math.nextgreater((half2)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half2)(1747f)),  math.nextgreater((half2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half2)(1747f)),  math.nextgreater((half2)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half2)(-1747f)), math.nextgreater((half2)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half2)(1747f)),  math.nextgreater((half2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half2)(1747f)),  math.nextgreater((half2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half2)(-1747f)), math.nextgreater((half2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half3()
        {
            Assert.AreEqual(math.nextgreater((half3)(1747f)),  math.nextgreater((half3)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half3)(1747f)),  math.nextgreater((half3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half3)(1747f)),  math.nextgreater((half3)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half3)(-1747f)), math.nextgreater((half3)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half3)(1747f)),  math.nextgreater((half3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half3)(1747f)),  math.nextgreater((half3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half3)(-1747f)), math.nextgreater((half3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half4()
        {
            Assert.AreEqual(math.nextgreater((half4)(1747f)),  math.nextgreater((half4)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half4)(1747f)),  math.nextgreater((half4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half4)(1747f)),  math.nextgreater((half4)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half4)(-1747f)), math.nextgreater((half4)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half4)(1747f)),  math.nextgreater((half4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half4)(1747f)),  math.nextgreater((half4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half4)(-1747f)), math.nextgreater((half4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half8()
        {
            Assert.AreEqual(math.nextgreater((half8)(1747f)),  math.nextgreater((half8)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half8)(1747f)),  math.nextgreater((half8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half8)(1747f)),  math.nextgreater((half8)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half8)(-1747f)), math.nextgreater((half8)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half8)(1747f)),  math.nextgreater((half8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half8)(1747f)),  math.nextgreater((half8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half8)(-1747f)), math.nextgreater((half8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _half16()
        {
            Assert.AreEqual(math.nextgreater((half16)(1747f)),  math.nextgreater((half16)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((half16)(1747f)),  math.nextgreater((half16)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half16)(1747f)),  math.nextgreater((half16)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((half16)(-1747f)), math.nextgreater((half16)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((half16)(1747f)),  math.nextgreater((half16)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half16)(1747f)),  math.nextgreater((half16)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((half16)(-1747f)), math.nextgreater((half16)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _float()
        {
            Assert.AreEqual(math.nextgreater(1747f),  math.nextgreater(1747f, Promise.NonZero));
            Assert.AreEqual(math.nextgreater(1747f),  math.nextgreater(1747f, Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(1747f),  math.nextgreater(1747f, Promise.Positive));
            Assert.AreEqual(math.nextgreater(-1747f), math.nextgreater(-1747f, Promise.Negative));

            Assert.AreEqual(math.nextgreater(1747f),  math.nextgreater(1747f, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(1747f),  math.nextgreater(1747f, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(-1747f), math.nextgreater(-1747f, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float2()
        {
            Assert.AreEqual(math.nextgreater((float2)(1747f)),  math.nextgreater((float2)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((float2)(1747f)),  math.nextgreater((float2)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float2)(1747f)),  math.nextgreater((float2)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((float2)(-1747f)), math.nextgreater((float2)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((float2)(1747f)),  math.nextgreater((float2)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float2)(1747f)),  math.nextgreater((float2)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float2)(-1747f)), math.nextgreater((float2)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float3()
        {
            Assert.AreEqual(math.nextgreater((float3)(1747f)),  math.nextgreater((float3)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((float3)(1747f)),  math.nextgreater((float3)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float3)(1747f)),  math.nextgreater((float3)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((float3)(-1747f)), math.nextgreater((float3)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((float3)(1747f)),  math.nextgreater((float3)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float3)(1747f)),  math.nextgreater((float3)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float3)(-1747f)), math.nextgreater((float3)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float4()
        {
            Assert.AreEqual(math.nextgreater((float4)(1747f)),  math.nextgreater((float4)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((float4)(1747f)),  math.nextgreater((float4)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float4)(1747f)),  math.nextgreater((float4)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((float4)(-1747f)), math.nextgreater((float4)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((float4)(1747f)),  math.nextgreater((float4)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float4)(1747f)),  math.nextgreater((float4)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float4)(-1747f)), math.nextgreater((float4)(-1747f), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _float8()
        {
            Assert.AreEqual(math.nextgreater((float8)(1747f)),  math.nextgreater((float8)(1747f), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((float8)(1747f)),  math.nextgreater((float8)(1747f), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float8)(1747f)),  math.nextgreater((float8)(1747f), Promise.Positive));
            Assert.AreEqual(math.nextgreater((float8)(-1747f)), math.nextgreater((float8)(-1747f), Promise.Negative));

            Assert.AreEqual(math.nextgreater((float8)(1747f)),  math.nextgreater((float8)(1747f), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float8)(1747f)),  math.nextgreater((float8)(1747f), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((float8)(-1747f)), math.nextgreater((float8)(-1747f), Promise.Negative | Promise.Unsafe0));
        }


        [Test]
        public static void _double()
        {
            Assert.AreEqual(math.nextgreater(1747d),  math.nextgreater(1747d, Promise.NonZero));
            Assert.AreEqual(math.nextgreater(1747d),  math.nextgreater(1747d, Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(1747d),  math.nextgreater(1747d, Promise.Positive));
            Assert.AreEqual(math.nextgreater(-1747d), math.nextgreater(-1747d, Promise.Negative));

            Assert.AreEqual(math.nextgreater(1747d),  math.nextgreater(1747d, Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(1747d),  math.nextgreater(1747d, Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater(-1747d), math.nextgreater(-1747d, Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double2()
        {
            Assert.AreEqual(math.nextgreater((double2)(1747d)),  math.nextgreater((double2)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((double2)(1747d)),  math.nextgreater((double2)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double2)(1747d)),  math.nextgreater((double2)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextgreater((double2)(-1747d)), math.nextgreater((double2)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextgreater((double2)(1747d)),  math.nextgreater((double2)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double2)(1747d)),  math.nextgreater((double2)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double2)(-1747d)), math.nextgreater((double2)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double3()
        {
            Assert.AreEqual(math.nextgreater((double3)(1747d)),  math.nextgreater((double3)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((double3)(1747d)),  math.nextgreater((double3)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double3)(1747d)),  math.nextgreater((double3)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextgreater((double3)(-1747d)), math.nextgreater((double3)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextgreater((double3)(1747d)),  math.nextgreater((double3)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double3)(1747d)),  math.nextgreater((double3)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double3)(-1747d)), math.nextgreater((double3)(-1747d), Promise.Negative | Promise.Unsafe0));
        }

        [Test]
        public static void _double4()
        {
            Assert.AreEqual(math.nextgreater((double4)(1747d)),  math.nextgreater((double4)(1747d), Promise.NonZero));
            Assert.AreEqual(math.nextgreater((double4)(1747d)),  math.nextgreater((double4)(1747d), Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double4)(1747d)),  math.nextgreater((double4)(1747d), Promise.Positive));
            Assert.AreEqual(math.nextgreater((double4)(-1747d)), math.nextgreater((double4)(-1747d), Promise.Negative));

            Assert.AreEqual(math.nextgreater((double4)(1747d)),  math.nextgreater((double4)(1747d), Promise.NonZero | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double4)(1747d)),  math.nextgreater((double4)(1747d), Promise.Positive | Promise.Unsafe0));
            Assert.AreEqual(math.nextgreater((double4)(-1747d)), math.nextgreater((double4)(-1747d), Promise.Negative | Promise.Unsafe0));
        }
    }
}
