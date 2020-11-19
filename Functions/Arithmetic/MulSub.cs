using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float msub(float a, float b, float c)
        {
            v128 temp = X86.Fma.fmsub_ss(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 msub(float2 a, float2 b, float2 c)
        {
            v128 temp = X86.Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 msub(float3 a, float3 b, float3 c)
        {
            v128 temp = X86.Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 msub(float4 a, float4 b, float4 c)
        {
            v128 temp = X86.Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float4*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 msub(float8 a, float8 b, float8 c)
        {
            return X86.Fma.mm256_fmsub_ps(a, b, c);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double msub(double a, double b, double c)
        {
            v128 temp = X86.Fma.fmsub_sd(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(double*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 msub(double2 a, double2 b, double2 c)
        {
            v128 temp = X86.Fma.fmsub_pd(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(double2*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 msub(double3 a, double3 b, double3 c)
        {
            v256 temp = X86.Fma.mm256_fmsub_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double3*)&temp;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 msub(double4 a, double4 b, double4 c)
        {
            v256 temp = X86.Fma.mm256_fmsub_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double4*)&temp;
        }
    }
}