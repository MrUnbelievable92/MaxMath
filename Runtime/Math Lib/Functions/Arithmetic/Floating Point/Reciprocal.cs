using System.Runtime.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 rcp(float8 x)
        {
            // replaced by rcp + 2 fma instructions (Newton-Raphson) when floatmode fast is enabled
            return 1f / x;
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 rcp(float4 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 rcp(float3 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 rcp(float2 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the reciprocal a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float rcp(float x)
        {
            return Unity.Mathematics.math.rcp(x);
        }


        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 rcp(double4 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 rcp(double3 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 rcp(double2 x)
        {
            return Unity.Mathematics.math.rcp(x);
        }

        /// <summary>       Returns the componentwise reciprocal a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double rcp(double x)
        {
            return Unity.Mathematics.math.rcp(x);
        }


        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fastrcp(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_rcp_ps(x);
            }
            else
            {
                return new float8(fastrcp(x.v4_0), fastrcp(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastrcp(float4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_ps(x);
            }
            else
            {
                return rcp(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastrcp(float3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_ps(x);
            }
            else
            {
                return rcp(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastrcp(float2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_ps(x);
            }
            else
            {
                return rcp(x);
            }
        }

        /// <summary>       Returns the fast approximate reciprocal a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrcp(float x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_ss(Xse.set_ss(x)).Float0;
            }
            else
            {
                return rcp(x);
            }
        }


        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastrcp(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rcp_pd(x);
            }
            else
            {
                return new double4(fastrcp(x.xy), fastrcp(x.zw));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastrcp(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rcp_pd(x);
            }
            else
            {
                return new double3(fastrcp(x.xy), fastrcp(x.z));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="MaxMath.double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastrcp(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_pd(x);
            }
            else
            {
                return new double2(fastrcp(x.x), fastrcp(x.y));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="double"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double fastrcp(double x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_sd(Xse.set_sd(x)).Double0;
            }
            else
            {
                ulong guess = Xse.MAGIC_RCP_PD - *(ulong*)&x;

                return *(double*)&guess * (2d - (*(double*)&guess * x));
            }
        }
    }
}