using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

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
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 tanh(float2 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 tanh(float3 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 tanh(float4 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 tanh(double2 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 tanh(double3 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 tanh(double4 x)
        {
            return Unity.Mathematics.math.tanh(x);
        }

        
        /// <summary>       Returns the hyperbolic tangent of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple tanh(quadruple x)
        {
            quadruple.ConstChecked tiny = new quadruple(0x52E4_D255_44B1_042E, 0x0069_7769_BEAD_75EC);
            quadruple t, z;

            ulong ix = abs(x).value.hi64;
            if (ix >= 0x7FFF_0000_0000_0000)
            {
                return isnan(x) ? x : copysign(1, x);
            }

            if (ix < 0x4004_4000_0000_0000)
            {
                if (ix < 0x3FC6_0000_0000_0000)
	            {
                    if (x == 0)
                    {
                        return x;
                    }

	                return x * (1 + tiny);
	            }

                quadruple __x = abs(x);

                if (ix >= 0x3FFF_0000_0000_0000)
	            {
	                t = expm1(2 * __x);
	                z = 1 - 2 / (t + 2);
	            }
                else
	            {
	                t = expm1(-2 * __x);
	                z = -t / (t + 2);
	            }
            }
            else
            {
                z = 1 - tiny;
            }

            return copysign(z, x);
        }
    }
}