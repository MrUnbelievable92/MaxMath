using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the cosine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float cos(float x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cos(float2 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cos(float3 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cos(float4 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cos(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = cos(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(cos(x.v4_0), cos(x.v4_4));
            }
        }

        
        /// <summary>       Returns the cosine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double cos(double x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cos(double2 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cos(double3 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cos(double4 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
    }
}