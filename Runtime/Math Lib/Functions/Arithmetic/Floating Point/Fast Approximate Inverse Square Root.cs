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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.rsqrt_ps(RegisterConversion.ToV128(x)));
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.rsqrt_ps(RegisterConversion.ToV128(x)));
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.rsqrt_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rsqrt(x);
            }
        }

        /// <summary>       Returns the fast approximate inverse square root a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrsqrt(float x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_ss(RegisterConversion.ToV128(x)).Float0;
            }
            else
            {
                return math.rsqrt(x);
            }
        }


        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastrsqrt(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_rsqrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double4(fastrsqrt(x.xy), fastrsqrt(x.zw));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastrsqrt(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_rsqrt_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double3(fastrsqrt(x.xy), fastrsqrt(x.z));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastrsqrt(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.rsqrt_pd(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new double2(fastrsqrt(x.x), fastrsqrt(x.y));
            }
        }

        /// <summary>       Returns the fast approximate inverse square root a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fastrsqrt(double x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_sd(RegisterConversion.ToV128(x)).Double0;
            }
            else
            {
                ulong y = Xse.MAGIC_RSQRT_PD - (math.asulong(x) >> 1);

                double g = *(double*)&y;

                double mHalfA = -0.5d * x;
                double gSq = g * g;
                double threeHalfsG = (3d / 2d) * g;

                return math.mad(g * mHalfA, gSq, threeHalfsG);
            }
        }
    }
}