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
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.float2"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float2 x, out float2 s, out float2 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float2 _s, out Unity.Mathematics.float2 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.float3"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float3 x, out float3 s, out float3 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float3 _s, out Unity.Mathematics.float3 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.float4"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float4 x, out float4 s, out float4 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.float4 _s, out Unity.Mathematics.float4 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.float8"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
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
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.double2"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double2 x, out double2 s, out double2 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double2 _s, out Unity.Mathematics.double2 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.double3"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double3 x, out double3 s, out double3 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double3 _s, out Unity.Mathematics.double3 _c);
            s = _s;
            c = _c;
        }
        
        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.double4"/> <paramref name="x"/> through the <see langword="out"/> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(double4 x, out double4 s, out double4 c)
        {
            Unity.Mathematics.math.sincos(x, out Unity.Mathematics.double4 _s, out Unity.Mathematics.double4 _c);
            s = _s;
            c = _c;
        }
    }
}