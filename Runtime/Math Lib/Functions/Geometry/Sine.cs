using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the sine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float sin(float x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sin(float2 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sin(float3 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sin(float4 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sin(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = sin(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(sin(x.v4_0), sin(x.v4_4));
            }
        }

        
        /// <summary>       Returns the sine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double sin(double x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sin(double2 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sin(double3 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sin(double4 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
    }
}