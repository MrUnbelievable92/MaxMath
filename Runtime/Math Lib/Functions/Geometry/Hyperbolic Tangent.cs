using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the hyperbolic tangent of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float tanh(float x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tanh(float2 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tanh(float3 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tanh(float4 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tanh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = tanh(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(tanh(x.v4_0), tanh(x.v4_4));
            }
        }

        
        /// <summary>       Returns the hyperbolic tangent of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double tanh(double x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tanh(double2 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tanh(double3 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tanh(double4 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
    }
}