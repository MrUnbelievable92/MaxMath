using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the hyperbolic sine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sinh(float x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sinh(float2 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sinh(float3 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sinh(float4 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sinh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = sinh(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(sinh(x.v4_0), sinh(x.v4_4));
            }
        }

        
        /// <summary>       Returns the hyperbolic sine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sinh(double x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sinh(double2 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sinh(double3 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sinh(double4 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
    }
}