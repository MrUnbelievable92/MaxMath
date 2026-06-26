using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the arcsine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asin(float x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 asin(float2 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 asin(float3 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 asin(float4 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asin(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = asin(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(asin(x.v4_0), asin(x.v4_4));
            }
        }

        
        /// <summary>       Returns the arcsine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asin(double x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asin(double2 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asin(double3 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asin(double4 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
    }
}