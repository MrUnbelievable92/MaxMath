using System.Runtime.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the arccosine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float acos(float x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 acos(float2 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 acos(float3 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 acos(float4 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 acos(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = acos(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(acos(x.v4_0), acos(x.v4_4));
            }
        }

        
        /// <summary>       Returns the arccosine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double acos(double x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 acos(double2 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 acos(double3 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 acos(double4 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
    }
}