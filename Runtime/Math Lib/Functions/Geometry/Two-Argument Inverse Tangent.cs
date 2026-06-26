using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the 2-argument arctangent of a pair of <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float atan2(float y, float x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 atan2(float2 y, float2 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 atan2(float3 y, float3 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 atan2(float4 y, float4 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan2(float8 y, float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = atan2(*((float*)&y + i), *((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(atan2(y.v4_0, x.v4_0), atan2(y.v4_4, x.v4_4));
            }
        }

        
        /// <summary>       Returns the 2-argument arctangent of a pair of <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double atan2(double y, double x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 atan2(double2 y, double2 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 atan2(double3 y, double3 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 atan2(double4 y, double4 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
    }
}