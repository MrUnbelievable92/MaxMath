using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;
using Unity.Burst.CompilerServices;

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
        
        /// <summary>       Returns the componentwise sine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 sin(float2 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 sin(float3 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 sin(float4 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise sine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 sin(double2 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 sin(double3 x)
        {
            return Unity.Mathematics.math.sin(x);
        }
        
        /// <summary>       Returns the componentwise sine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 sin(double4 x)
        {
            return Unity.Mathematics.math.sin(x);
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private static quadruple.ConstChecked sin_kernel(quadruple.ConstChecked x, quadruple.ConstChecked y, bool iy)
        {
            quadruple.ConstChecked SCOS1 = new quadruple(0x0000_0000_0000_0000, 0xBFFE_0000_0000_0000);
            quadruple.ConstChecked SCOS2 = new quadruple(0x5555_5555_5539_5023, 0x3FFA_5555_5555_5555);
            quadruple.ConstChecked SCOS3 = new quadruple(0x6C16_A566_E42C_0375, 0xBFF5_6C16_C16C_16C1);
            quadruple.ConstChecked SCOS4 = new quadruple(0x02DC_F7DA_2D6D_5444, 0x3FEF_A01A_01A0_19EE);
            quadruple.ConstChecked SCOS5 = new quadruple(0xCB0B_5490_8754_BDE0, 0xBFE9_27E4_F5DC_E637);
            quadruple.ConstChecked SIN1  = new quadruple(0x5555_5555_5555_5550, 0xBFFC_5555_5555_5555);
            quadruple.ConstChecked SIN2  = new quadruple(0x1111_1111_110E_7340, 0x3FF8_1111_1111_1111);
            quadruple.ConstChecked SIN3  = new quadruple(0xA01A_019E_7A62_6296, 0xBFF2_A01A_01A0_1A01);
            quadruple.ConstChecked SIN4  = new quadruple(0x38FA_3852_7474_B8F5, 0x3FEC_71DE_3A55_6C73);
            quadruple.ConstChecked SIN5  = new quadruple(0x16C7_DE65_C2EA_551F, 0xBFE5_AE64_567F_544E);
            quadruple.ConstChecked SIN6  = new quadruple(0x8053_8A9A_4195_7115, 0x3FDE_6124_613A_8114);
            quadruple.ConstChecked SIN7  = new quadruple(0xC7BC_660B_060E_F365, 0xBFD6_AE7F_3D5A_EF30);
            quadruple.ConstChecked SIN8  = new quadruple(0x7ACE_B202_2A9A_9180, 0x3FCE_9510_115A_ABF8);
            quadruple.ConstChecked SSIN1 = new quadruple(0x5555_5555_5555_5555, 0xBFFC_5555_5555_5555);
            quadruple.ConstChecked SSIN2 = new quadruple(0x1111_1111_10FE_195D, 0x3FF8_1111_1111_1111);
            quadruple.ConstChecked SSIN3 = new quadruple(0xA019_E712_1E08_0D88, 0xBFF2_A01A_01A0_1A01);
            quadruple.ConstChecked SSIN4 = new quadruple(0x0C6A_AA51_AA02_AB41, 0x3FEC_71DE_3A55_6C64);
            quadruple.ConstChecked SSIN5 = new quadruple(0xDC71_839D_E75B_2787, 0xBFE5_AE64_4EE9_0C47);

            quadruple.ConstChecked h, l, z, sin_l, cos_l_m1;
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
                        return x;
                    }
                }
                z = square(x);

                return quadruple.fmadd(x, z * quadruple.fmadd(
                                              quadruple.fmadd(
                                              quadruple.fmadd(
                                              quadruple.fmadd(
                                              quadruple.fmadd(
                                              quadruple.fmadd(
                                              quadruple.fmadd(SIN8, z, SIN7), z, SIN6), z, SIN5), z, SIN4), z, SIN3), z, SIN2), z, SIN1), x);
            }
            else
            {
                index = 0x3FFE - (tix >> 16);
                hix = (tix + (0x0200u << (int)index)) & (0xFFFF_FC00u << (int)index);
                x = abs(x);

                h = new quadruple(0, (ulong)hix << 32);
                l = x - h;
                if (iy)
                {
        	        l = (ix < 0 ? -y : y) + l;
                }
        	    
                z = square(l);
                sin_l = l * quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(SSIN5, z, SSIN4), z, SSIN3), z, SSIN2), z, SSIN1), z, 1);
                cos_l_m1 = z * quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(SCOS5, z, SCOS4), z, SCOS3), z, SCOS2), z, SCOS1);

                switch (index)
        	    {
        	        case 0:  index = ((45 << 10) + hix - 0x3FFE_0000) >> 8; break;
        	        case 1:  index = ((13 << 11) + hix - 0x3FFD_0000) >> 9; break;
        	        default: index = (hix - 0x3FFC_3000) >> 10;             break;
        	    }

                z = LUT.QUADRUPLE.sincos((int)index + 2)
        	      + (LUT.QUADRUPLE.sincos((int)index + 3)
                   + quadruple.fmadd(sin_l, LUT.QUADRUPLE.sincos((int)index), LUT.QUADRUPLE.sincos((int)index + 2) * cos_l_m1));

                return negateif(z, ix < 0);
            }
        }
        
        /// <summary>       Returns the sine of a <see cref="quadruple"/>.     </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quadruple sin(quadruple x)
        {
            long ix = (long)x.value.hi64;
        	ix &= 0x7FFF_FFFF_FFFF_FFF;

        	if (ix <= 0x3FFE_921F_B544_42D1)
            {
        	    return sin_kernel(x, 0, false);
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
                                 ? cos_kernel(y[0], y[1])
                                 : sin_kernel(y[0], y[1], true);

                return negateif(result, n > 1);
        	}
        }
    }
}