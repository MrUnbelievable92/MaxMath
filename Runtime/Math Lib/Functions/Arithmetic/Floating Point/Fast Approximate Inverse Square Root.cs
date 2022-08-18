using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fastrsqrt(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_rsqrt_ps(x);
            }
            else
            {
                return new float8(fastrsqrt(x.v4_0), fastrsqrt(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastrsqrt(float4 x)
        {
            if (Sse.IsSseSupported)
            {
                return RegisterConversion.ToType<float4>(Sse.rsqrt_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastrsqrt(float3 x)
        {
            if (Sse.IsSseSupported)
            {
                return RegisterConversion.ToType<float3>(Sse.rsqrt_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastrsqrt(float2 x)
        {
            if (Sse.IsSseSupported)
            {
                return RegisterConversion.ToType<float2>(Sse.rsqrt_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrsqrt(float x)
        {
            if (Sse.IsSseSupported)
            {
                return Sse.rsqrt_ss(RegisterConversion.ToV128(x)).Float0;
            }
            else
            {
                return math.rsqrt(x);
            }
        }


        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastrsqrt(double4 x)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToType<double4>(Xse.mm256_rsqrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double4(fastrsqrt(x.xy), fastrsqrt(x.zw));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastrsqrt(double3 x)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToType<double3>(Xse.mm256_rsqrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double3(fastrsqrt(x.xy), fastrsqrt(x.z));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastrsqrt(double2 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToType<double2>(Xse.rsqrt_pd(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new double2(fastrsqrt(x.x), fastrsqrt(x.y));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fastrsqrt(double x)
        {
            if (Sse.IsSseSupported)
            {
                return Xse.rsqrt_sd(RegisterConversion.ToV128(x)).Double0;
            }
            else
            {
                ulong guess = Xse.MAGIC_RSQRT_PD_GUESS - (math.asulong(x) >> 1);
	            x = math.asdouble(guess) * Xse.MAGIC_RSQRT_PD_MUL * (Xse.MAGIC_RSQRT_PD_SUB - x * math.asdouble(guess) * math.asdouble(guess));
	            
                return x;
            }
        }
    }
}