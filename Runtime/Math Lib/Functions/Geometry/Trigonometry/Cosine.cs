using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using Unity.Burst.CompilerServices;

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
        
        /// <summary>       Returns the componentwise cosine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 cos(float2 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 cos(float3 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 cos(float4 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise cosine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 cos(double2 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 cos(double3 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        
        /// <summary>       Returns the componentwise cosine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 cos(double4 x)
        {
            return Unity.Mathematics.math.cos(x);
        }
        

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static quadruple.ConstChecked cos_kernel(quadruple.ConstChecked x, quadruple.ConstChecked y)
        {
            quadruple.ConstChecked SCOS1 = new quadruple(0x0000_0000_0000_0000, 0xBFFE_0000_0000_0000);
            quadruple.ConstChecked SCOS2 = new quadruple(0x5555_5555_5539_5023, 0x3FFA_5555_5555_5555);
            quadruple.ConstChecked SCOS3 = new quadruple(0x6C16_A566_E42C_0375, 0xBFF5_6C16_C16C_16C1);
            quadruple.ConstChecked SCOS4 = new quadruple(0x02DC_F7DA_2D6D_5444, 0x3FEF_A01A_01A0_19EE);
            quadruple.ConstChecked SCOS5 = new quadruple(0xCB0B_5490_8754_BDE0, 0xBFE9_27E4_F5DC_E637);
            quadruple.ConstChecked COS1  = new quadruple(0xFFFF_FFFF_FFFF_FFFB, 0xBFFD_FFFF_FFFF_FFFF);
            quadruple.ConstChecked COS2  = new quadruple(0x5555_5555_5551_6F30, 0x3FFA_5555_5555_5555);
            quadruple.ConstChecked COS3  = new quadruple(0x6C16_C16A_463D_FD0D, 0xBFF5_6C16_C16C_16C1);
            quadruple.ConstChecked COS4  = new quadruple(0xA019_5CEB_E6F3_D3A5, 0x3FEF_A01A_01A0_1A01);
            quadruple.ConstChecked COS5  = new quadruple(0xAA81_42A2_2044_B51F, 0xBFE9_27E4_FB77_89F5);
            quadruple.ConstChecked COS6  = new quadruple(0x1E92_62D7_ADFF_4373, 0x3FE2_1EED_8EFF_881D);
            quadruple.ConstChecked COS7  = new quadruple(0x601E_D3D4_CA48_944B, 0xBFDA_9397_4969_22A9);
            quadruple.ConstChecked COS8  = new quadruple(0xCAF7_C3FB_4523_414C, 0x3FD2_AE5F_8197_CBCD);
            quadruple.ConstChecked SSIN1 = new quadruple(0x5555_5555_5555_5555, 0xBFFC_5555_5555_5555);
            quadruple.ConstChecked SSIN2 = new quadruple(0x1111_1111_10FE_195D, 0x3FF8_1111_1111_1111);
            quadruple.ConstChecked SSIN3 = new quadruple(0xA019_E712_1E08_0D88, 0xBFF2_A01A_01A0_1A01);
            quadruple.ConstChecked SSIN4 = new quadruple(0x0C6A_AA51_AA02_AB41, 0x3FEC_71DE_3A55_6C64);
            quadruple.ConstChecked SSIN5 = new quadruple(0xDC71_839D_E75B_2787, 0xBFE5_AE64_4EE9_0C47);

            quadruple.ConstChecked l, z, sin_l, cos_l_m1;
            uint tix, hix, index;

            long ix = (long)x.Value.value.hi64;
            tix = (uint)(ix >> 32);
            tix &= 0x7FFF_FFFF;
            if (tix < 0x3FFC_3000)
            {
                if (tix < 0x3FC6_0000)
                {
                    if ((int)x.Value == 0) 
                    {
                        return 1;
                    }
                }

                z = square(x);
                return quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(
                       quadruple.fmadd(COS8, z, COS7), z, COS6), z, COS5), z, COS4), z, COS3), z, COS2), z, COS1), z, 1);
            }
            else
            {
                index = 0x3FFE - (tix >> 16);
                hix = (tix + (0x0200u << (int)index)) & (0xFFFF_FC00u << (int)index);
                ulong sign = x.Value.value.hi64 & (1ul << 63);
                x.Value = new quadruple(x.Value.value.lo64, x.Value.value.hi64 ^ sign);
                y.Value = new quadruple(y.Value.value.lo64, y.Value.value.hi64 ^ sign);
                
                switch (index)
        	    {
        	        case 0:  index = ((45 << 10) + hix - 0x3FFE_0000) >> 8; break;
        	        case 1:  index = ((13 << 11) + hix - 0x3FFD_0000) >> 9; break;
        	        default: index = (hix - 0x3FFC_3000) >> 10;             break;
        	    }
        
                quadruple.ConstChecked h = new quadruple(0, (ulong)hix << 32);
                l = y - (h - x);
                z = square(l);

                sin_l = l * quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(SSIN5, z, SSIN4), z, SSIN3), z, SSIN2), z, SSIN1), z, 1);
                cos_l_m1 = z * quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(SCOS5, z, SCOS4), z, SCOS3), z, SCOS2), z, SCOS1);

                return LUT.QUADRUPLE.sincos((int)index)
	                 + (LUT.QUADRUPLE.sincos((int)index + 1)
		              - quadruple.fmsub(LUT.QUADRUPLE.sincos((int)index + 2), sin_l, LUT.QUADRUPLE.sincos((int)index) * cos_l_m1));
            }
        }
        
        /// <summary>       Returns the cosine of a <see cref="quadruple"/>.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple cos(quadruple x)
        {
            long ix = (long)x.value.hi64;
        	ix &= 0x7FFF_FFFF_FFFF_FFF;

	        if (ix <= 0x3FFE_921F_B544_42D1)
            {
	            return cos_kernel(x, 0);
            }
        	else if (ix >= 0x7FFF_0000_0000_0000)
            {
        	    return x;
        	}
        	else 
            {
        	    quadruple* y = stackalloc quadruple[2];
        	    int n = rem_pio2(x, y);

                quadruple result = (n & 1) != 0 
                                 ? sin_kernel(y[0], y[1], true)
                                 : cos_kernel(y[0], y[1]);

                return negateif(result, isinrange(n, 1, 2));
        	}
	    }
    }
}