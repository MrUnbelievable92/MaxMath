using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

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
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 acos(float2 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 acos(float3 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 acos(float4 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="float8"/>.     </summary>
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
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 acos(double2 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 acos(double3 x)
        {
            return Unity.Mathematics.math.acos(x);
        }
        
        /// <summary>       Returns the componentwise arccosine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 acos(double4 x)
        {
            return Unity.Mathematics.math.acos(x);
        }

        
        /// <summary>       Returns the arccosine of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple acos(quadruple x)
        {
            quadruple.ConstChecked pio2_hi      = new quadruple(0x8469_898C_C517_01B8, 0x3FFF_921F_B544_42D1);
            quadruple.ConstChecked pio2_lo      = new quadruple(0xA67C_C740_20BB_EA64, 0x3F8C_CD12_9024_E088);
            quadruple.ConstChecked rS0          = new quadruple(0x583D_D4F9_225E_8685, 0x4001_679E_8126_24F4);
            quadruple.ConstChecked rS1          = new quadruple(0x6878_39B3_91B0_AE90, 0xC004_64D7_2010_A02D);
            quadruple.ConstChecked rS2          = new quadruple(0x76DA_DBA2_01FC_D33F, 0x4006_0788_ADBD_753C);
            quadruple.ConstChecked rS3          = new quadruple(0x4BDA_0C99_F606_6FBF, 0xC006_454E_77DD_459C);
            quadruple.ConstChecked rS4          = new quadruple(0xD35B_7C86_47ED_D725, 0x4003_F72B_47B7_A9DF);
            quadruple.ConstChecked rS5          = new quadruple(0x853D_735E_3BC4_A8CC, 0x4005_8844_58A7_3108);
            quadruple.ConstChecked rS6          = new quadruple(0x299A_3433_1DCC_4511, 0xC004_C8AD_6F49_A0C9);
            quadruple.ConstChecked rS7          = new quadruple(0x1A13_EDCF_B97B_3203, 0xC002_BEE4_9902_AD77);
            quadruple.ConstChecked rS8          = new quadruple(0x389F_B025_3698_CF5A, 0x4002_6865_D9AA_AAEB);
            quadruple.ConstChecked rS9          = new quadruple(0xF275_2BF4_0686_3E30, 0x3FFD_FB83_47C2_4866);
            quadruple.ConstChecked rS10         = new quadruple(0x41D4_1BC1_5FCB_9856, 0xBFFD_5346_466C_8C70);
            quadruple.ConstChecked sS0          = new quadruple(0xC082_D558_121A_186E, 0xC001_2955_075B_21A1);
            quadruple.ConstChecked sS1          = new quadruple(0x9D6E_4093_5A32_4203, 0x4004_3653_73CE_1F6C);
            quadruple.ConstChecked sS2          = new quadruple(0x5737_0238_F7F4_4296, 0xC005_E8CB_6D36_7B66);
            quadruple.ConstChecked sS3          = new quadruple(0x45BC_A61D_9D3F_5949, 0x4006_4BC3_A494_F34F);
            quadruple.ConstChecked sS4          = new quadruple(0x74E8_3B6F_2F48_3D96, 0xC004_8059_B1E1_315F);
            quadruple.ConstChecked sS5          = new quadruple(0xA218_3F34_54CF_FA70, 0xC005_91B7_F401_1493);
            quadruple.ConstChecked sS6          = new quadruple(0x0334_602E_6CB9_6B64, 0x4005_2D36_1560_F868);
            quadruple.ConstChecked sS7          = new quadruple(0x0813_4EF2_017C_B070, 0x4002_96A2_A8F4_31FE);
            quadruple.ConstChecked sS8          = new quadruple(0x073A_D891_0B79_9D48, 0xC003_226C_5527_5D7F);
            quadruple.ConstChecked sS9          = new quadruple(0xD136_EE99_694D_0F8E, 0xBFFB_405F_6478_F29E);
            quadruple.ConstChecked acosr5625    = new quadruple(0x38B0_F59F_8FF4_7E35, 0x3FFE_F260_298C_B286);
            quadruple.ConstChecked pimacosr5625 = new quadruple(0xF63D_4C24_E119_E22B, 0x4000_1587_AAE1_162F);
            quadruple.ConstChecked P0           = new quadruple(0x8531_B4D6_3FF4_CD91, 0x4000_16BE_8D5E_3C4B);
            quadruple.ConstChecked P1           = new quadruple(0xB37F_C6D7_8197_31BF, 0xC003_C7CA_ADE8_3D4B);
            quadruple.ConstChecked P2           = new quadruple(0x074E_C2F4_3F85_4F8D, 0x4005_A007_D4D0_DB43);
            quadruple.ConstChecked P3           = new quadruple(0xE297_8364_F868_0FFD, 0xC006_1804_7C4E_C04E);
            quadruple.ConstChecked P4           = new quadruple(0xD9DF_0885_BDF5_D027, 0x4003_635E_1F69_C7A4);
            quadruple.ConstChecked P5           = new quadruple(0x445D_9EFD_0A6A_E323, 0x4005_81BF_A3DF_86BC);
            quadruple.ConstChecked P6           = new quadruple(0x2C02_F515_2078_29EB, 0xC004_9CAC_2B00_FB12);
            quadruple.ConstChecked P7           = new quadruple(0xA591_E104_475A_D416, 0xC002_F92B_2864_19C5);
            quadruple.ConstChecked P8           = new quadruple(0xFA72_A034_FFDC_FD8E, 0x4002_5DF6_645F_CD98);
            quadruple.ConstChecked P9           = new quadruple(0xD1CC_8EFE_0E73_2856, 0x3FFE_16FC_27F2_E6A7);
            quadruple.ConstChecked P10          = new quadruple(0x4CA9_392F_60E3_8816, 0xBFFD_538B_F644_C9B6);
            quadruple.ConstChecked Q0           = new quadruple(0x7A03_20D1_5D0A_56E1, 0xBFFF_F54D_D90A_D458);
            quadruple.ConstChecked Q1           = new quadruple(0xC642_4A51_CBE7_0153, 0x4003_A255_1C03_6C95);
            quadruple.ConstChecked Q2           = new quadruple(0x4E3E_3686_7FF0_32A0, 0xC005_8FA2_6462_A4F2);
            quadruple.ConstChecked Q3           = new quadruple(0xEAA8_D20E_DE40_2E22, 0x4006_20CA_B003_C452);
            quadruple.ConstChecked Q4           = new quadruple(0x2747_12C2_AFC3_BD9A, 0xC004_0083_E974_9DD5);
            quadruple.ConstChecked Q5           = new quadruple(0x31F1_5939_463A_883C, 0xC005_A36C_A279_0331);
            quadruple.ConstChecked Q6           = new quadruple(0x035D_F084_64BE_0D39, 0x4005_0DD5_D9F9_7693);
            quadruple.ConstChecked Q7           = new quadruple(0x87EE_4492_0EF8_D916, 0x4003_2116_EC6C_0E4B);
            quadruple.ConstChecked Q8           = new quadruple(0xB064_1161_3EF1_EB2D, 0xC003_1B39_5F4E_570B);
            quadruple.ConstChecked Q9           = new quadruple(0x5571_9A2C_01A7_F28F, 0xBFFE_21BF_B218_0017);
            quadruple.ConstChecked acosr4375    = new quadruple(0x092F_853C_5FC6_BAD0, 0x3FFF_1E33_EB72_BED7);
            quadruple.ConstChecked pimacosr4375 = new quadruple(0xFFD1_C6EE_9533_A450, 0x4000_0305_BF8A_E365);
            quadruple.ConstChecked pS0          = new quadruple(0xCDEF_35CE_DBC4_8DBE, 0xC008_A1E7_AAD8_1492);
            quadruple.ConstChecked pS1          = new quadruple(0x4F4B_8BA6_2A7A_5120, 0x400A_CB5F_2AA9_5113);
            quadruple.ConstChecked pS2          = new quadruple(0xE4F8_66C4_B33D_59D4, 0xC00B_A4AB_AA5F_5296);
            quadruple.ConstChecked pS3          = new quadruple(0xF7A9_88CF_FF30_6CE5, 0x400B_9F3D_802F_67B6);
            quadruple.ConstChecked pS4          = new quadruple(0x9F0A_1AE1_E717_BE4B, 0xC00A_DD2A_F196_F5BC);
            quadruple.ConstChecked pS5          = new quadruple(0xF1E1_A742_393F_527F, 0x4009_4128_AA34_1E69);
            quadruple.ConstChecked pS6          = new quadruple(0x87BD_0CAC_F1F9_7802, 0xC006_E225_B08A_670D);
            quadruple.ConstChecked pS7          = new quadruple(0xAABA_FEA6_FBDA_3DAB, 0x4003_6312_1A62_86EB);
            quadruple.ConstChecked pS8          = new quadruple(0x2B44_7257_AC72_96BD, 0xBFFE_7326_D489_6D23);
            quadruple.ConstChecked pS9          = new quadruple(0xE3A3_4AE2_B27E_8F86, 0x3FF5_14CD_D4D1_27BF);
            quadruple.ConstChecked qS0          = new quadruple(0x1A73_685B_24D3_654B, 0xC00B_396D_C022_0F6E);
            quadruple.ConstChecked qS1          = new quadruple(0x44D8_D7AD_4730_BC97, 0x400D_7BCA_1F36_04F1);
            quadruple.ConstChecked qS2          = new quadruple(0x575C_7BD2_E2A2_CC29, 0xC00E_8676_1841_226C);
            quadruple.ConstChecked qS3          = new quadruple(0x7256_2D04_255A_A3E8, 0x400E_BB6A_3F29_2FCB);
            quadruple.ConstChecked qS4          = new quadruple(0xA8CB_9F83_328C_D351, 0xC00E_2F3E_765D_AB8F);
            quadruple.ConstChecked qS5          = new quadruple(0x88C5_706E_FA77_6D64, 0x400C_FEB0_2CF3_92ED);
            quadruple.ConstChecked qS6          = new quadruple(0x9575_EEDA_A7C3_A427, 0xC00B_0377_3E1A_F8AF);
            quadruple.ConstChecked qS7          = new quadruple(0xB973_CC9E_139B_F2DE, 0x4008_29CD_7378_A9E8);
            quadruple.ConstChecked qS8          = new quadruple(0x4713_A586_0091_29CA, 0xC004_4E07_B227_CD1B);

            quadruple.ConstChecked z, r, w, p, q, s, t, f2;
            quadruple.ConstChecked u;
            
            ulong sign = x.value.hi64 & (1ul << 63);
            u = abs(x);
            int ix = (int)(u.Value.value.hi64 >> 32);
            if (ix >= 0x3FFF_0000)
            {
                if (u == 1)
                {
                    return sign == 0 ? 0 : PI_QUAD;
                }
                else
                {
                    return quadruple.NaN;
                }
            }
            else if (ix < 0x3FFE_0000)
            {
                if (ix < 0x3F8E_0000)
                {
                    return pio2_hi + pio2_lo;
                }
                if (ix < 0x3FFD_E000)
                {
                    z = square(x);
                    p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(pS9, z, pS8), z, pS7), z, pS6), z, pS5), z, pS4), z, pS3), z, pS2), z, pS1), z, pS0) * z;
                    q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(z + qS8, z, qS7), z, qS6), z, qS5), z, qS4), z, qS3), z, qS2), z, qS1), z, qS0);

                    r = quadruple.fmadd(p / q, x, x);
                    z = pio2_hi - (r - pio2_lo);

                    return z;
                }

                t = u - 0.4375;
                p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(P10, t, P9), t, P8), t, P7), t, P6), t, P5), t, P4), t, P3), t, P2), t, P1), t, P0) * t;
                q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(t + Q9, t, Q8), t, Q7), t, Q6), t, Q5), t, Q4), t, Q3), t, Q2), t, Q1), t, Q0);
                r = p / q;
                
                return sign != 0 
                     ? pimacosr4375 - r
                     : acosr4375 + r;
            }
            else if (ix < 0x3FFE_4000)
            {
                t = u - 0.5625;
                p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(rS10, t, rS9), t, rS8), t, rS7), t, rS6), t, rS5), t, rS4), t, rS3), t, rS2), t, rS1), t, rS0) * t;
                q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(t + sS9, t, sS8), t, sS7), t, sS6), t, sS5), t, sS4), t, sS3), t, sS2), t, sS1), t, sS0);

                p /= q;

                return sign != 0 
                     ? pimacosr5625 - p
                     : acosr5625 + p;
            }
            else
            {
                z = (1 - u) * 0.5;
                s = sqrt(z);
                u = new quadruple.ConstChecked(new quadruple(0, s.Value.value.hi64), s.Promise);
                f2 = s - u;
                w = quadruple.fnmadd(u, u, z);
                w = quadruple.fnmadd(2 * u, f2, w);
                w = quadruple.fnmadd(f2, f2, w);
                w /= 2 * s;

                p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(pS9, z, pS8), z, pS7), z, pS6), z, pS5), z, pS4), z, pS3), z, pS2), z, pS1), z, pS0) * z;
                q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(z + qS8, z, qS7), z, qS6), z, qS5), z, qS4), z, qS3), z, qS2), z, qS1), z, qS0);
                r = s + quadruple.fmadd(s, p / q, w);
            
                if (sign != 0)
                {
                    r = pio2_hi + (pio2_lo - r);
                }
                
                return 2 * r;
            }
        }
    }
}