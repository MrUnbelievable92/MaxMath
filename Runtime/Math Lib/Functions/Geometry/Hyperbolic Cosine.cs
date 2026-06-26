using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the hyperbolic cosine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cosh(float x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cosh(float2 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cosh(float3 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cosh(float4 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cosh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = cosh(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(cosh(x.v4_0), cosh(x.v4_4));
            }
        }

        
        /// <summary>       Returns the hyperbolic cosine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cosh(double x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cosh(double2 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cosh(double3 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cosh(double4 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
    }
}