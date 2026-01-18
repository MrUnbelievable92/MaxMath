using System.Runtime.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
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

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="float4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 fastrcp(float4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.rcp_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rcp(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="float3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 fastrcp(float3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.rcp_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rcp(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="float2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 fastrcp(float2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat2(Xse.rcp_ps(RegisterConversion.ToV128(x)));
            }
            else
            {
                return math.rcp(x);
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="float"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float fastrcp(float x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rcp_ss(RegisterConversion.ToV128(x)).Float0;
            }
            else
            {
                return math.rcp(x);
            }
        }


        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="double4"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 fastrcp(double4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_rcp_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double4(fastrcp(x.xy), fastrcp(x.zw));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="double3"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 fastrcp(double3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_rcp_pd(RegisterConversion.ToV256(x)));
            }
            else
            {
                return new double3(fastrcp(x.xy), fastrcp(x.z));
            }
        }

        /// <summary>       Returns the componentwise fast approximate reciprocal a <see cref="double2"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 fastrcp(double2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToDouble2(Xse.rcp_pd(RegisterConversion.ToV128(x)));
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
                return Xse.rcp_sd(RegisterConversion.ToV128(x)).Double0;
            }
            else
            {
                ulong guess = Xse.MAGIC_RCP_PD - *(ulong*)&x;

                return *(double*)&guess * (2d - (*(double*)&guess * x));
            }
        }
    }
}