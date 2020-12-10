using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of a multiply-subtract operation (a * b - c) on 3 float values.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float msub(float a, float b, float c)
        {
            v128 temp = Fma.fmsub_ss(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 float2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 msub(float2 a, float2 b, float2 c)
        {
            v128 temp = Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 float3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 msub(float3 a, float3 b, float3 c)
        {
            v128 temp = Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 float4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 msub(float4 a, float4 b, float4 c)
        {
            v128 temp = Fma.fmsub_ps(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(float4*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 float8 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 msub(float8 a, float8 b, float8 c)
        {
            return Fma.mm256_fmsub_ps(a, b, c);
        }


        /// <summary>       Returns the result of a multiply-subtract operation (a * b - c) on 3 double values.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double msub(double a, double b, double c)
        {
            v128 temp = Fma.fmsub_sd(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(double*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 double2 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 msub(double2 a, double2 b, double2 c)
        {
            v128 temp = Fma.fmsub_pd(*(v128*)&a, *(v128*)&b, *(v128*)&c);

            return *(double2*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 double3 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 msub(double3 a, double3 b, double3 c)
        {
            v256 temp = Fma.mm256_fmsub_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double3*)&temp;
        }

        /// <summary>       Returns the result of a componentwise multiply-subtract operation (a * b - c) on 3 double4 vectors.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 msub(double4 a, double4 b, double4 c)
        {
            v256 temp = Fma.mm256_fmsub_pd(*(v256*)&a, *(v256*)&b, *(v256*)&c);

            return *(double4*)&temp;
        }
    }
}