using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the 2-argument arctangent of a pair of <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float atan2(float y, float x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 atan2(float2 y, float2 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 atan2(float3 y, float3 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 atan2(float4 y, float4 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan2(float8 y, float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = atan2(*((float*)&y + i), *((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(atan2(y.v4_0, x.v4_0), atan2(y.v4_4, x.v4_4));
            }
        }

        
        /// <summary>       Returns the 2-argument arctangent of a pair of <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double atan2(double y, double x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 atan2(double2 y, double2 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 atan2(double3 y, double3 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }
        
        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 atan2(double4 y, double4 x)
        {
            return Unity.Mathematics.math.atan2(y, x);
        }

        
        /// <summary>       Returns the 2-argument arctangent of a pair of <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple atan2(quadruple y, quadruple x)
        {
            quadruple tiny   = new quadruple(0x52E4_D255_44B1_042E, 0x0069_7769_BEAD_75EC);
            quadruple pi_o_4 = new quadruple(0x8469_898C_C517_01B8, 0x3FFE_921F_B544_42D1);
            quadruple pi_o_2 = new quadruple(0x8469_898C_C517_01B8, 0x3FFF_921F_B544_42D1);
            quadruple pi     = new quadruple(0x8469_898C_C517_01B8, 0x4000_921F_B544_42D1);
            quadruple pi_lo  = new quadruple(0xA67C_C740_20BB_EA64, 0x3F8D_CD12_9024_E088);

	        quadruple.ConstChecked z;
	        long k, m, ix, iy;

            ulong lx = x.value.lo64;
            ulong ly = y.value.lo64;
            long hx = (long)x.value.hi64;
            long hy = (long)y.value.hi64;

	        ix = hx & (long)~(1ul << 63);
	        iy = hy & (long)~(1ul << 63);

	        if (isnan(x) | isnan(y))
            {
                return quadruple.NaN;
            }
	        else if (x == 1) 
            {
                return atan(y);
            }

	        m = ((hy >> 63) & 1) | ((hx >> 62) & 2);
            constexpr.ASSUME(m >= 0);
            constexpr.ASSUME(m <= 3);

	        if (y == 0) 
            {
	            switch(m) 
                {
	        	    case 0:
	        	    case 1:  return y;
	        	    case 2:  return  PI_QUAD + tiny;
	        	    default: return -PI_QUAD - tiny;
	            }
	        }
	        if (x == 0)
            {
                return hy < 0
                     ? -pi_o_2 - tiny
                     :  pi_o_2 + tiny;
            }

	        if (isinf(x)) 
            {
	            if (isinf(y)) 
                {
	        	    switch(m) 
                    {
	        	        case 0:  return  pi_o_4 + tiny;
	        	        case 1:  return -pi_o_4 - tiny;
	        	        case 2:  return quadruple.fmadd( 3, pi_o_4, tiny);
	        	        default: return quadruple.fmsub(-3, pi_o_4, tiny);
	        	    }
	            } 
                else 
                {
	        	    switch(m) 
                    {
	        	        case 0:  return  0d;
	        	        case 1:  return -0d;
	        	        case 2:  return  PI_QUAD + tiny;
	        	        default: return -PI_QUAD - tiny;
	        	    }
	            }
	        }

	        if (isinf(y)) 
            {
                return hy < 0
                     ? -pi_o_2 - tiny
                     :  pi_o_2 + tiny;
            }

	        k = (iy - ix) >> quadruple.MANTISSA_BITS_HI64;

	        if (k > 120)
            {
                z = quadruple.fmadd(0.5, pi_lo, pi_o_2);
            }
	        else if ((hx < 0) & (k < -120))
            {
	            switch (m) 
                {
	                case 0:  return 0;
	                case 1:  return -0d;
	                case 2:  return PI_QUAD + pi_lo;
	                default: return -pi_lo - PI_QUAD;
	            }
            }
	        else
            {
                z = atan(abs(y / x));
            }

	        switch (m) 
            {
	            case 0:  return z;
	            case 1:  return -z;
	            case 2:  return PI_QUAD - (z - pi_lo);
	            default: return (z - pi_lo) - PI_QUAD;
	        }
        }
    }
}