using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the sine and cosine of the input <see cref="float"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float x, out float s, out float c)
        {
            Unity.Mathematics.math.sincos(x, out s, out c);
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="float2"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float2 x, out float2 s, out float2 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float2 _s, out Unity.Mathematics.float2 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="float3"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float3 x, out float3 s, out float3 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float3 _s, out Unity.Mathematics.float3 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="float4"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float4 x, out float4 s, out float4 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float4 _s, out Unity.Mathematics.float4 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="float8"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float8 x, out float8 s, out float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                // transcribed from Burst generated code for float4 sincos;
                // results can differ by (actualResult * 10 ^ (-6)); this is the version with the highest precision
            
                v256 ymm0, ymm1, ymm2, ymm3, ymm4, ymm5;
            
                ymm0 = x;
                ymm2 = Avx.mm256_and_ps(ymm0, Xse.mm256_set1_epi32(0x7FFF_FFFF));
                ymm1 = Xse.mm256_set1_epi32(0x42FA_0000);
                ymm1 = Xse.mm256_cmplt_ps(ymm2, ymm1);
            
                if (Hint.Unlikely(Xse.mm256_notalltrue_f256<float>(ymm1)))
                {
                    goto LBB0_2;
                }
            
                ymm1 = Xse.mm256_set1_epi32(0x3F22_F983);
                ymm1 = Avx.mm256_mul_ps(ymm0, ymm1);
                ymm1 = Avx.mm256_cvtps_epi32(ymm1);
                ymm3 = Avx.mm256_cvtepi32_ps(ymm1);
                ymm2 = Xse.mm256_set1_epi32(0xBFC9_0E00);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm0);
                ymm4 = Xse.mm256_set1_epi32(0xB86D_5000);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm2 = Xse.mm256_set1_epi32(0xB088_5A31);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
            
            LBB0_5:
                ymm3 = Avx.mm256_mul_ps(ymm2, ymm2);
                ymm4 = Xse.mm256_set1_epi32(0x3C08_839A);
                ymm5 = Xse.mm256_set1_epi32(0xB94C_A65B);
                ymm5 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm4 = Xse.mm256_set1_epi32(0xBE2A_AAA2);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm3, ymm4);
                ymm4 = Fma.mm256_fmadd_ps(ymm2, ymm4, ymm2);
                ymm2 = Xse.mm256_set1_epi32(0x8000_0000);
                ymm0 = Avx2.mm256_cmpeq_epi32(ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm4, ymm2, ymm0);
                ymm2 = Xse.mm256_set1_epi32(0x37D0_078B);
                ymm4 = Xse.mm256_set1_epi32(0xB491_ED89);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm2 = Xse.mm256_set1_epi32(0xBAB6_0B58);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm4 = Xse.mm256_set1_epi32(0x3D2A_AAAA);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
                ymm2 = Xse.mm256_set1_epi32(0xBF00_0000);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm4 = Xse.mm256_set1_epi32(0x3F80_0000);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
                ymm2 = Xse.mm256_set1_epi32(0x0000_0001);
                ymm2 = Avx2.mm256_and_si256(ymm1, ymm2);
                ymm3 = Avx.mm256_setzero_ps();
                ymm2 = Avx2.mm256_cmpeq_epi32(ymm2, ymm3);
                ymm3 = Avx.mm256_blendv_ps(ymm4, ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm4, ymm2);
                ymm2 = Avx2.mm256_slli_epi32(ymm1, 30);
                ymm4 = Xse.mm256_set1_epi32(0x8000_0000);
                ymm2 = Avx2.mm256_and_si256(ymm2, ymm4);
                ymm2 = Avx2.mm256_xor_si256(ymm2, ymm3);
                ymm3 = Xse.mm256_setall_si256();
                ymm1 = Avx2.mm256_sub_epi32(ymm1, ymm3);
                ymm1 = Avx2.mm256_slli_epi32(ymm1, 30);
                ymm1 = Avx2.mm256_and_si256(ymm1, ymm4);
                ymm0 = Avx2.mm256_xor_si256(ymm1, ymm0);
            
                s = ymm2;
                c = ymm0;
                return;
            
            
            LBB0_2:
                ymm1 = Xse.mm256_set1_epi32(0x4718_5800);
                ymm1 = Xse.mm256_cmplt_ps(ymm2, ymm1);
            
                if (Hint.Unlikely(Xse.mm256_notalltrue_f256<float>(ymm1)))
                {
                    goto LBB0_4;
                }
            
                ymm1 = Xse.mm256_set1_epi32(0x3F22_F983);
                ymm1 = Avx.mm256_mul_ps(ymm0, ymm1);
                ymm1 = Avx.mm256_cvtps_epi32(ymm1);
                ymm3 = Avx.mm256_cvtepi32_ps(ymm1);
                ymm2 = Xse.mm256_set1_epi32(0xBFC9_0000);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm0);
                ymm4 = Xse.mm256_set1_epi32(0xB9FD_8000);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm5 = Xse.mm256_set1_epi32(0xB4A8_8000);
                ymm5 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm2 = Xse.mm256_set1_epi32(0xAE85_A309);
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm5);
            
                goto LBB0_5;
            }
            else if (Avx.IsAvxSupported)
            {
                // transcribed from Burst generated code for float4 sincos;
                // results can differ by (actualResult * 10 ^ (-6)); this is the version with the highest precision
            
                v256 ymm0, ymm1, ymm2, ymm3, ymm4;
            
                ymm1 = x;
                ymm0 = Avx.mm256_and_ps(ymm1, Xse.mm256_set1_epi32(0x7FFF_FFFF));
                ymm2 = Xse.mm256_cmplt_ps(ymm0, Xse.mm256_set1_epi32(0x42FA_0000));
            
                if (Hint.Unlikely(Xse.mm256_notalltrue_f256<float>(ymm2)))
                {
                    goto LBB0_2;
                }
            
                ymm0 = Avx.mm256_mul_ps(ymm1, Xse.mm256_set1_epi32(0x3F22_F983));
                ymm3 = Avx.mm256_cvtps_epi32(ymm0);
                ymm0 = Avx.mm256_cvtepi32_ps(ymm3);
                ymm2 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xBFC9_0E00));
                ymm2 = Avx.mm256_add_ps(ymm1, ymm2);
                ymm4 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xB86D_5000));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm0 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xB088_5A31));
            
            LBB0_5:
                ymm0 = Avx.mm256_add_ps(ymm2, ymm0);
                ymm2 = Avx.mm256_mul_ps(ymm0, ymm0);
                ymm4 = Avx.mm256_mul_ps(ymm2, Xse.mm256_set1_epi32(0xB94C_A65B));
                ymm4 = Avx.mm256_add_ps(ymm4, Xse.mm256_set1_epi32(0x3C08_839A));
                ymm4 = Avx.mm256_mul_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_add_ps(ymm4, Xse.mm256_set1_epi32(0xBE2A_AAA2));
                ymm4 = Avx.mm256_mul_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm0, ymm4);
                ymm0 = Avx.mm256_add_ps(ymm0, ymm4);
                ymm4 = Xse.mm256_set1_epi32(0x8000_0000);
                v128 xmm1  = Xse.cmpeq_epi32(Avx.mm256_castsi256_si128(ymm1), Avx.mm256_castsi256_si128(ymm4));
                v128 xmm11 = Xse.cmpeq_epi32(Avx.mm256_extractf128_si256(ymm1, 1), Avx.mm256_castsi256_si128(ymm4));
                ymm1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm1), xmm11, 1);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm4, ymm1);
                ymm1 = Avx.mm256_mul_ps(ymm2, Xse.mm256_set1_epi32(0xB491_ED89));
                ymm1 = Avx.mm256_add_ps(ymm1, Xse.mm256_set1_epi32(0x37D0_078B));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Xse.mm256_set1_epi32(0xBAB6_0B58));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Xse.mm256_set1_epi32(0x3D2A_AAAA));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Xse.mm256_set1_epi32(0xBF00_0000));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Xse.mm256_set1_epi32(0x3F80_0000));
                ymm2 = Avx.mm256_and_ps(ymm3, Xse.mm256_set1_epi32(0x0000_0001));
                v128 xmm4  = Xse.setzero_si128();
                v128 xmm2  = Xse.cmpeq_epi32(Avx.mm256_castsi256_si128(ymm2), xmm4);
                v128 xmm12 = Xse.cmpeq_epi32(Avx.mm256_extractf128_si256(ymm2, 1), xmm4);
                ymm2 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm2), xmm12, 1);
                ymm4 = Avx.mm256_blendv_ps(ymm1, ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm1, ymm2);
                v128 xmm13 = Avx.mm256_extractf128_si256(ymm3, 1);
                xmm1  = Xse.slli_epi32(Avx.mm256_castsi256_si128(ymm3), 30);
                xmm11 = Xse.slli_epi32(xmm13, 30);
                ymm2 = Xse.mm256_set1_epi32(0x8000_0000);
                ymm1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm1), xmm11, 1);
                ymm1 = Avx.mm256_and_ps(ymm1, ymm2);
                ymm1 = Avx.mm256_xor_ps(ymm1, ymm4);
                xmm4 = Xse.setall_si128();
                v128 xmm3 = Xse.sub_epi32(Avx.mm256_castsi256_si128(ymm3), xmm4);
                xmm13 = Xse.sub_epi32(xmm13, xmm4);
                xmm3  = Xse.slli_epi32(xmm3, 30);
                xmm13 = Xse.slli_epi32(xmm13, 30);
                ymm3 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm3), xmm13, 1);
                ymm2 = Avx.mm256_and_ps(ymm3, ymm2);
                ymm0 = Avx.mm256_xor_ps(ymm2, ymm0);
            
                s = ymm1;
                c = ymm0;
                return;
            
            
            LBB0_2:
                ymm2 = Xse.mm256_cmplt_ps(ymm0, Xse.mm256_set1_epi32(0x4718_5800));
            
                if (Hint.Unlikely(Xse.mm256_notalltrue_f256<float>(ymm2)))
                {
                    goto LBB0_4;
                }
            
                ymm0 = Avx.mm256_mul_ps(ymm1, Xse.mm256_set1_epi32(0x3F22_F983));
                ymm3 = Avx.mm256_cvtps_epi32(ymm0);
                ymm0 = Avx.mm256_cvtepi32_ps(ymm3);
                ymm2 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xBFC9_0000));
                ymm2 = Avx.mm256_add_ps(ymm1, ymm2);
                ymm4 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xB9FD_8000));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xB4A8_8000));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm0 = Avx.mm256_mul_ps(ymm0, Xse.mm256_set1_epi32(0xAE85_A309));
            
                goto LBB0_5;
            }

        LBB0_4:
            sincos(x.v4_0, out float4 sinLo, out float4 cosLo);
            sincos(x.v4_4, out float4 sinHi, out float4 cosHi);

            s = new float8(sinLo, sinHi);
            c = new float8(cosLo, cosHi);
        }

        
        /// <summary>       Returns the sine and cosine of the input <see cref="double"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double x, out double s, out double c)
        {
            Unity.Mathematics.math.sincos(x, out s, out c);
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="double2"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double2 x, out double2 s, out double2 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double2 _s, out Unity.Mathematics.double2 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="double3"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double3 x, out double3 s, out double3 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double3 _s, out Unity.Mathematics.double3 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="double4"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double4 x, out double4 s, out double4 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double4 _s, out Unity.Mathematics.double4 _c);
            s = _s;
            c = _c;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void sincos_kernel(quadruple.ConstChecked x, quadruple.ConstChecked y, out quadruple.ConstChecked s, out quadruple.ConstChecked c, bool iy)
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
            quadruple.ConstChecked COS1  = new quadruple(0xFFFF_FFFF_FFFF_FFFB, 0xBFFD_FFFF_FFFF_FFFF);
            quadruple.ConstChecked COS2  = new quadruple(0x5555_5555_5551_6F30, 0x3FFA_5555_5555_5555);
            quadruple.ConstChecked COS3  = new quadruple(0x6C16_C16A_463D_FD0D, 0xBFF5_6C16_C16C_16C1);
            quadruple.ConstChecked COS4  = new quadruple(0xA019_5CEB_E6F3_D3A5, 0x3FEF_A01A_01A0_1A01);
            quadruple.ConstChecked COS5  = new quadruple(0xAA81_42A2_2044_B51F, 0xBFE9_27E4_FB77_89F5);
            quadruple.ConstChecked COS6  = new quadruple(0x1E92_62D7_ADFF_4373, 0x3FE2_1EED_8EFF_881D);
            quadruple.ConstChecked COS7  = new quadruple(0x601E_D3D4_CA48_944B, 0xBFDA_9397_4969_22A9);
            quadruple.ConstChecked COS8  = new quadruple(0xCAF7_C3FB_4523_414C, 0x3FD2_AE5F_8197_CBCD);

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
                        s = x;
                        c = 1;
                        return;
                    }
                }
                z = square(x);

                s = quadruple.fmadd(x, z * quadruple.fmadd(
                                           quadruple.fmadd(
                                           quadruple.fmadd(
                                           quadruple.fmadd(
                                           quadruple.fmadd(
                                           quadruple.fmadd(
                                           quadruple.fmadd(SIN8, z, SIN7), z, SIN6), z, SIN5), z, SIN4), z, SIN3), z, SIN2), z, SIN1), x);
                c =  quadruple.fmadd(
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
                
                s = negateif(z, ix < 0);

                c = LUT.QUADRUPLE.sincos((int)index)
	              + (LUT.QUADRUPLE.sincos((int)index + 1)
		           - quadruple.fmsub(LUT.QUADRUPLE.sincos((int)index + 2), sin_l, LUT.QUADRUPLE.sincos((int)index) * cos_l_m1));
            }
        }
        
        /// <summary>       Returns the sine and cosine of the input <see cref="quadruple"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(quadruple x, out quadruple s, out quadruple c)
        {
            long ix = (long)x.value.hi64;
        	ix &= 0x7FFF_FFFF_FFFF_FFF;

	        if (ix <= 0x3FFE_921F_B544_42D1)
            {
                sincos_kernel(x, 0, out quadruple.ConstChecked __s, out quadruple.ConstChecked __c, false);
                s = __s;
                c = __c;
            }
        	else if (ix >= 0x7FFF_0000_0000_0000)
            {
        	    s = c = x;
        	}
            else
            {
        	    quadruple* y = stackalloc quadruple[2];
        	    int n = rem_pio2(x, y);

                sincos_kernel(y[0], y[1], out quadruple.ConstChecked __s, out quadruple.ConstChecked __c, true);

                s = (n & 1) == 0 ? __s : __c;
                c = (n & 1) == 0 ? __c : __s;

                s = negateif(s, n > 1);
                c = negateif(c, isinrange(n, 1, 2));
            }
        }
    }
}