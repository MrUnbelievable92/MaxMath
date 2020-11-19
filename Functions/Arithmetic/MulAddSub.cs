using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 maddsub(float2 a, float2 b, float2 c)
        {
            v128 temp = X86.Fma.fmsubadd_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float2*)&temp;
        }

        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 maddsub(float3 a, float3 b, float3 c)
        {
            v128 temp = X86.Fma.fmsubadd_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float3*)&temp;
        }

        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 maddsub(float4 a, float4 b, float4 c)
        {
            v128 temp = X86.Fma.fmsubadd_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float4*)&temp;
        }

        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 maddsub(float8 a, float8 b, float8 c)
        {
            return X86.Fma.mm256_fmsubadd_ps(a, b, c);
        }


        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 maddsub(double2 a, double2 b, double2 c)
        {
            v128 temp = X86.Fma.fmsubadd_pd(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(double2*)&temp;
        }

        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 maddsub(double3 a, double3 b, double3 c)
        {
            v256 temp = X86.Fma.mm256_fmsubadd_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double3*)&temp;
        }

        /// <summary> Multipliy a with b, add evenly indexed - and subtract oddly indexed components </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 maddsub(double4 a, double4 b, double4 c)
        {
            v256 temp = X86.Fma.mm256_fmsubadd_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double4*)&temp;
        }
    }
}