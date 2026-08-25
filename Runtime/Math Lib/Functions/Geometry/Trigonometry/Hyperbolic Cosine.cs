using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

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
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cosh(float2 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cosh(float3 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cosh(float4 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cosh(double2 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cosh(double3 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        
        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cosh(double4 x)
        {
            return Unity.Mathematics.math.cosh(x);
        }
        

        /// <summary>       Returns the hyperbolic cosine of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple cosh(quadruple x)
        {
            quadruple.ConstChecked ovf_thresh = new quadruple(0x4981_5192_2505_CB5F, 0x7F94_5D24_084E_B26F);
            quadruple.ConstChecked huge       = new quadruple(0x81D3_6125_B64D_A4A6, 0x400C_62E9_BB80_635D);

            quadruple t, w;

            long ex = (long)abs(x).value.hi64;
            if (ex >= 0x7FFF_0000_0000_0000)
            {
                return x;
            }

            x = abs(x);

            if (ex < 0x3FFD_62E4_0000_0000)
            {
                if (ex < 0x3FB8_0000_0000_0000)
                {
                    return 1;
                }
	            
                t = expm1(x);
                w = 1 + t;

                return 1 + square(t) / (2 * w);
            }
            if (ex < 0x4004_4000_0000_0000)
            {
                t = exp(x);

                return quadruple.fmadd(0.5, t, 0.5 / t);
            }
            if (ex <= 0x400C_62E3_0000_0000)
            {
                return 0.5 * exp(x);
            }
            if (x <= ovf_thresh)
            {
                w = exp(0.5 * x);
                t = 0.5 * w;

                return t * w;
            }

            return huge * huge;
        }
    }
}