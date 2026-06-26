using MaxMath.Intrinsics;
using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the result of a step function where the result is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float step(float y, float x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 step(float2 y, float2 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 step(float3 y, float3 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 step(float4 y, float4 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }

        /// <summary>       Returns the result of a componentwise step function where each component is 1.0f when <paramref name="x"/> >= <paramref name="y"/> and 0.0f otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 step(float8 y, float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(new float8(1f), Xse.mm256_cmpge_ps(x, y));
            }
            else
            {
                return new float8(step(x.v4_0, y.v4_0), step(x.v4_4, y.v4_4));
            }
        }

        
        /// <summary>       Returns the result of a step function where the result is 1.0d when <paramref name="x"/> >= <paramref name="y"/> and 0.0d otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double step(double y, double x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0d when <paramref name="x"/> >= <paramref name="y"/> and 0.0d otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 step(double2 y, double2 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0d when <paramref name="x"/> >= <paramref name="y"/> and 0.0d otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 step(double3 y, double3 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
        
        /// <summary>       Returns the result of a componentwise step function where each component is 1.0d when <paramref name="x"/> >= <paramref name="y"/> and 0.0d otherwise.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 step(double4 y, double4 x)
        {
            return Unity.Mathematics.math.step(y, x);
        }
    }
}