using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the tangent of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tan(float x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tan(float2 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tan(float3 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tan(float4 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = tan(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(tan(x.v4_0), tan(x.v4_4));
            }
        }

        
        /// <summary>       Returns the tangent of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double tan(double x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tan(double2 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tan(double3 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
        
        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tan(double4 x)
        {
            return Unity.Mathematics.math.tan(x);
        }
    }
}