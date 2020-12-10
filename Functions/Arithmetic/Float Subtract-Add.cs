using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two float2 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 subadd(float2 a, float2 b)
        {
            v128 temp = Sse3.addsub_ps(*(v128*)&a, *(v128*)&b);

            return *(float2*)&temp;
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two float3 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 subadd(float3 a, float3 b)
        {
            v128 temp = Sse3.addsub_ps(*(v128*)&a, *(v128*)&b);

            return *(float3*)&temp;
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two float4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 subadd(float4 a, float4 b)
        {
            v128 temp = Sse3.addsub_ps(*(v128*)&a, *(v128*)&b);

            return *(float4*)&temp;
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two float8 vectors       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 subadd(float8 a, float8 b)
        {
            return Avx.mm256_addsub_ps(a, b);
        }


        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two double2 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 subadd(double2 a, double2 b)
        {
            v128 temp = Sse3.addsub_pd(*(v128*)&a, *(v128*)&b);

            return *(double2*)&temp;
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two double3 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 subadd(double3 a, double3 b)
        {
            v256 temp = Avx.mm256_addsub_pd(*(v256*)&a, *(v256*)&b);

            return *(double3*)&temp;
        }

        /// <summary>       Subtracts even indexed and adds odd indexed components (zero based) of two double4 vectors        </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 subadd(double4 a, double4 b)
        {
            v256 temp = Avx.mm256_addsub_pd(*(v256*)&a, *(v256*)&b);

            return *(double4*)&temp;
        }
    }
}