using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the square root of a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sqrt(float x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sqrt(float2 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sqrt(float3 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sqrt(float4 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }

        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sqrt(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_sqrt_ps(x);
            }
            else
            {
                return new float8(sqrt(x.v4_0), sqrt(x.v4_4));
            }
        }


        /// <summary>       Returns the square root of a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sqrt(double x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sqrt(double2 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sqrt(double3 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }
        
        /// <summary>       Returns the componentwise square root of a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sqrt(double4 x)
        {
            return Unity.Mathematics.math.sqrt(x);
        }


        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rsqrt(float8 x)
        {
            // replaced by rsqrt + 2 fma instructions (Newton-Raphson) when floatmode fast is enabled
            return 1f / sqrt(x);
        }

        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rsqrt(float4 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rsqrt(float3 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 rsqrt(float2 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the inverse square root a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float rsqrt(float x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }


        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 rsqrt(double4 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 rsqrt(double3 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the componentwise inverse square root a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 rsqrt(double2 x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }

        /// <summary>       Returns the inverse square root a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double rsqrt(double x)
        {
            return Unity.Mathematics.math.rsqrt(x);
        }


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

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastrsqrt(float4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_ps(x);
            }
            else
            {
                return rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastrsqrt(float3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_ps(x);
            }
            else
            {
                return rsqrt(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastrsqrt(float2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_ps(x);
            }
            else
            {
                return rsqrt(x);
            }
        }

        /// <summary>       Returns the fast approximate inverse square root a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrsqrt(float x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_ss(Xse.set_ss(x)).Float0;
            }
            else
            {
                return rsqrt(x);
            }
        }


        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastrsqrt(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rsqrt_pd(x);
            }
            else
            {
                return new double4(fastrsqrt(x.xy), fastrsqrt(x.zw));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastrsqrt(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rsqrt_pd(x);
            }
            else
            {
                return new double3(fastrsqrt(x.xy), fastrsqrt(x.z));
            }
        }

        /// <summary>       Returns the componentwise fast approximate inverse square root a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastrsqrt(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rsqrt_pd(x);
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
                return Xse.rsqrt_sd(Xse.set_sd(x)).Double0;
            }
            else
            {
                ulong y = Xse.MAGIC_RSQRT_PD - (asulong(x) >> 1);

                double g = *(double*)&y;

                double mHalfA = -0.5d * x;
                double gSq = g * g;
                double threeHalfsG = (3d / 2d) * g;

                return mad(g * mHalfA, gSq, threeHalfsG);
            }
        }
    }
}