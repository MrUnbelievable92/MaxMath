using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

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
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sinh(float2 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sinh(float3 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sinh(float4 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sinh(double2 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sinh(double3 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sinh(double4 x)
        {
            return Unity.Mathematics.math.sinh(x);
        }

            
        /// <summary>       Returns the hyperbolic sine of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple sinh(quadruple x)
        {
            quadruple.ConstChecked shuge      = new quadruple(0xF147_D9C6_4FD9_D5F7, 0x7FFB_5847_8442_2D97);
            quadruple.ConstChecked ovf_thresh = new quadruple(0x81D3_6125_B64D_A4A6, 0x400C_62E9_BB80_635D);
            quadruple t, w, h;
            quadruple u;

            ulong jx = x.value.hi64;
            ulong ix = jx & 0x7FFF_FFFF_FFFF_FFFF;

            if (ix >= 0x7FFF_0000_0000_0000)
            {
                return x;
            }

            h = copysign(0.5, x);
            u = abs(x);

            if (ix <= 0x4004_4000_0000_0000)
            {
                if (ix < 0x3FC6_0000_0000_0000)
	            {
	                if (shuge + x > 1)
                    {
                        return x;
                    }
	            }

                t = expm1(u);

                if (ix < 0x3FFF_0000_0000_0000)
                {
                    return h * (2 * t - square(t) / (t + 1));
                }
	            else
                {
                    return h * (t + t / (t + 1));
                }
            }
            if (ix <= 0x400C_62E3_0000_0000)
            {
                return h * exp(u);
            }
            if (u <= ovf_thresh)
            {
                w = exp(0.5 * u);
                t = h * w;
                return t * w;
            }

            return x * shuge;
        }
    }
}