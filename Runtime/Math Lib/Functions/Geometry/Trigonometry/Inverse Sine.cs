using System.Runtime.CompilerServices;
using MaxMath.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the arcsine of a <see cref="float"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float asin(float x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="float2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 asin(float2 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="float3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 asin(float3 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="float4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 asin(float4 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asin(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = asin(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(asin(x.v4_0), asin(x.v4_4));
            }
        }

        
        /// <summary>       Returns the arcsine of a <see cref="double"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double asin(double x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="double2"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 asin(double2 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="double3/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 asin(double3 x)
        {
            return Unity.Mathematics.math.asin(x);
        }
        
        /// <summary>       Returns the componentwise arcsine of a <see cref="double4"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 asin(double4 x)
        {
            return Unity.Mathematics.math.asin(x);
        }

        
        /// <summary>       Returns the arcsine of a <see cref="quadruple"/>.     </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple asin(quadruple x)
        {
            quadruple.ConstChecked pio2_hi   = new quadruple(0x8469_898C_C517_01B8, 0x3FFF_921F_B544_42D1);
            quadruple.ConstChecked pio2_lo   = new quadruple(0xA67C_C740_20BB_EA64, 0x3F8C_CD12_9024_E088);
            quadruple.ConstChecked pio4_hi   = new quadruple(0x8469_898C_C517_01B8, 0x3FFE_921F_B544_42D1);
            quadruple.ConstChecked pS0       = new quadruple(0xCDEF_35CE_DBC4_8DBE, 0xC008_A1E7_AAD8_1492);
            quadruple.ConstChecked pS1       = new quadruple(0x4F4B_8BA6_2A7A_5120, 0x400A_CB5F_2AA9_5113);
            quadruple.ConstChecked pS2       = new quadruple(0xE4F8_66C4_B33D_59D4, 0xC00B_A4AB_AA5F_5296);
            quadruple.ConstChecked pS3       = new quadruple(0xF7A9_88CF_FF30_6CE5, 0x400B_9F3D_802F_67B6);
            quadruple.ConstChecked pS4       = new quadruple(0x9F0A_1AE1_E717_BE4B, 0xC00A_DD2A_F196_F5BC);
            quadruple.ConstChecked pS5       = new quadruple(0xF1E1_A742_393F_527F, 0x4009_4128_AA34_1E69);
            quadruple.ConstChecked pS6       = new quadruple(0x87BD_0CAC_F1F9_7802, 0xC006_E225_B08A_670D);
            quadruple.ConstChecked pS7       = new quadruple(0xAABA_FEA6_FBDA_3DAB, 0x4003_6312_1A62_86EB);
            quadruple.ConstChecked pS8       = new quadruple(0x2B44_7257_AC72_96BD, 0xBFFE_7326_D489_6D23);
            quadruple.ConstChecked pS9       = new quadruple(0xE3A3_4AE2_B27E_8F86, 0x3FF5_14CD_D4D1_27BF);
            quadruple.ConstChecked qS0       = new quadruple(0x1A73_685B_24D3_654B, 0xC00B_396D_C022_0F6E);
            quadruple.ConstChecked qS1       = new quadruple(0x44D8_D7AD_4730_BC97, 0x400D_7BCA_1F36_04F1);
            quadruple.ConstChecked qS2       = new quadruple(0x575C_7BD2_E2A2_CC29, 0xC00E_8676_1841_226C);
            quadruple.ConstChecked qS3       = new quadruple(0x7256_2D04_255A_A3E8, 0x400E_BB6A_3F29_2FCB);
            quadruple.ConstChecked qS4       = new quadruple(0xA8CB_9F83_328C_D351, 0xC00E_2F3E_765D_AB8F);
            quadruple.ConstChecked qS5       = new quadruple(0x88C5_706E_FA77_6D64, 0x400C_FEB0_2CF3_92ED);
            quadruple.ConstChecked qS6       = new quadruple(0x9575_EEDA_A7C3_A427, 0xC00B_0377_3E1A_F8AF);
            quadruple.ConstChecked qS7       = new quadruple(0xB973_CC9E_139B_F2DE, 0x4008_29CD_7378_A9E8);
            quadruple.ConstChecked qS8       = new quadruple(0x4713_A586_0091_29CA, 0xC004_4E07_B227_CD1B);
            quadruple.ConstChecked rS0       = new quadruple(0x583D_D4F9_225E_8685, 0xC001_679E_8126_24F4);
            quadruple.ConstChecked rS1       = new quadruple(0x6878_39B3_91B0_AE90, 0x4004_64D7_2010_A02D);
            quadruple.ConstChecked rS2       = new quadruple(0x76DA_DBA2_01FC_D33F, 0xC006_0788_ADBD_753C);
            quadruple.ConstChecked rS3       = new quadruple(0x4BDA_0C99_F606_6FBF, 0x4006_454E_77DD_459C);
            quadruple.ConstChecked rS4       = new quadruple(0xD35B_7C86_47ED_D725, 0xC003_F72B_47B7_A9DF);
            quadruple.ConstChecked rS5       = new quadruple(0x853D_735E_3BC4_A8CC, 0xC005_8844_58A7_3108);
            quadruple.ConstChecked rS6       = new quadruple(0x299A_3433_1DCC_4511, 0x4004_C8AD_6F49_A0C9);
            quadruple.ConstChecked rS7       = new quadruple(0x1A13_EDCF_B97B_3203, 0x4002_BEE4_9902_AD77);
            quadruple.ConstChecked rS8       = new quadruple(0x389F_B025_3698_CF5A, 0xC002_6865_D9AA_AAEB);
            quadruple.ConstChecked rS9       = new quadruple(0xF275_2BF4_0686_3E30, 0xBFFD_FB83_47C2_4866);
            quadruple.ConstChecked rS10      = new quadruple(0x41D4_1BC1_5FCB_9856, 0x3FFD_5346_466C_8C70);
            quadruple.ConstChecked sS0       = new quadruple(0xC082_D558_121A_186E, 0xC001_2955_075B_21A1);
            quadruple.ConstChecked sS1       = new quadruple(0x9D6E_4093_5A32_4203, 0x4004_3653_73CE_1F6C);
            quadruple.ConstChecked sS2       = new quadruple(0x5737_0238_F7F4_4296, 0xC005_E8CB_6D36_7B66);
            quadruple.ConstChecked sS3       = new quadruple(0x45BC_A61D_9D3F_5949, 0x4006_4BC3_A494_F34F);
            quadruple.ConstChecked sS4       = new quadruple(0x74E8_3B6F_2F48_3D96, 0xC004_8059_B1E1_315F);
            quadruple.ConstChecked sS5       = new quadruple(0xA218_3F34_54CF_FA70, 0xC005_91B7_F401_1493);
            quadruple.ConstChecked sS6       = new quadruple(0x0334_602E_6CB9_6B64, 0x4005_2D36_1560_F868);
            quadruple.ConstChecked sS7       = new quadruple(0x0813_4EF2_017C_B070, 0x4002_96A2_A8F4_31FE);
            quadruple.ConstChecked sS8       = new quadruple(0x073A_D891_0B79_9D48, 0xC003_226C_5527_5D7F);
            quadruple.ConstChecked sS9       = new quadruple(0xD136_EE99_694D_0F8E, 0xBFFB_405F_6478_F29E);
            quadruple.ConstChecked asinr5625 = new quadruple(0xD022_1D79_FA39_853B, 0x3FFE_31DF_40FB_D31C);

            quadruple.ConstChecked t, t2, w, p, q, c, r, s;
            quadruple.ConstChecked u;

            bool flag = false;
            ulong sign = x.value.hi64 & (1ul << 63);
            u = abs(x);
            int ix = (int)(u.Value.value.hi64 >> 32);
            if (ix >= 0x3FFF_0000)
            {
                if (abs(x) == 1)
                {
	                return copysign(PIHALF_QUAD, x);
                }
                else
                {
                    return quadruple.NaN;
                }
            }
            else if (ix < 0x3FFE_0000)
            {
                if (ix < 0x3FC6_0000)
	            {
	                return x;
	            }
                else
	            {
                    t = square(x);
                    t2 = quadruple.fmadd(x, x, qS8);
	                flag = true;
	            }
            }
            else if (ix < 0x3FFE_4000)
            {
                t = u - 0.5625;
                p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(rS10, t, rS9), t, rS8), t, rS7), t, rS6), t, rS5), t, rS4), t, rS3), t, rS2), t, rS1), t, rS0) * t;
                q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(t + sS9, t, sS8), t, sS7), t, sS6), t, sS5), t, sS4), t, sS3), t, sS2), t, sS1), t, sS0);
                t = asinr5625 + p / q;

	            return new quadruple(t.Value.value.lo64, t.Value.value.hi64 ^ sign);
            }
            else
            {
                w = 1 - u;
                t = w * 0.5;
                t2 = quadruple.fmadd(0.5, w, qS8);
            }

            p = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(pS9, t, pS8), t, pS7), t, pS6), t, pS5), t, pS4), t, pS3), t, pS2), t, pS1), t, pS0) * t;
            q = quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(quadruple.fmadd(t2, t, qS7), t, qS6), t, qS5), t, qS4), t, qS3), t, qS2), t, qS1), t, qS0);

            if (flag)
            {
                w = p / q;
                return quadruple.fmadd(w, x, x);
            }

            s = sqrt(t);
            if (ix >= 0x3FFE_F333)
            {
                w = p / q;
                t = pio2_hi - quadruple.fmsub(2.0, quadruple.fmadd(w, s, s), pio2_lo);
            }
            else
            {
                w = new quadruple.ConstChecked(new quadruple(0, s.Value.value.hi64), s.Promise);
                c = quadruple.fnmadd(w, w, t) / (s + w);
                r = p / q;
                p = quadruple.fmsub(2 * s, r, quadruple.fnmadd(2, c, pio2_lo));
                q = quadruple.fnmadd(2, w, pio4_hi);
                t = pio4_hi - (p - q);
            }
            
            return new quadruple(t.Value.value.lo64, t.Value.value.hi64 ^ sign);
        }
    }
}