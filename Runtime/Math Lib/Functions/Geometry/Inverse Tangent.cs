using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the arctangent of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float atan(float x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 atan(float2 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 atan(float3 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 atan(float4 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = atan(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(atan(x.v4_0), atan(x.v4_4));
            }
        }

        
        /// <summary>       Returns the arctangent of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double atan(double x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 atan(double2 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 atan(double3 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
        
        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 atan(double4 x)
        {
            return Unity.Mathematics.math.atan(x);
        }
    }
}