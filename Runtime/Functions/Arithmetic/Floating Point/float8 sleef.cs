using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    // all loops are correctly translated to sleef calls to AVX(2) functions
    // EXCEPT for sincos() => transcribed manually and suboptimally IF any abs(x[i]) is greater than 39000 
    unsafe public static partial class maxmath
    { 
        /// <summary>       Returns the componentwise floating point remainder of <paramref name="x"/>/<paramref name="y"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 fmod(float8 x, float8 y)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = x[i] % y[i];
                }

                return x;
            }
            else
            {
                return new float8(x.v4_0 % y.v4_0, x.v4_4 % y.v4_4);
            }
        }

        /// <summary>       Returns the componentwise tangent of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.tan(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.tan(x.v4_0), math.tan(x.v4_4));
            }
        }
        
        /// <summary>       Returns the componentwise hyperbolic tangent of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 tanh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.tanh(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.tanh(x.v4_0), math.tanh(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise arctangent of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.atan(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.atan(x.v4_0), math.atan(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise 2-argument arctangent of a pair of <see cref="MaxMath.float8"/>s.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 atan2(float8 y, float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.atan2(y[i], x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.atan2(y.v4_0, x.v4_0), math.atan2(y.v4_4, x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise cosine of a <see cref="MaxMath.float8"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cos(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.cos(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.cos(x.v4_0), math.cos(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise hyperbolic cosine of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 cosh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.cosh(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.cosh(x.v4_0), math.cosh(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise arccosine of a <see cref="MaxMath.float8"/>.       </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 acos(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.acos(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.acos(x.v4_0), math.acos(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise sine of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sin(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.sin(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.sin(x.v4_0), math.sin(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise hyperbolic sine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sinh(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.sinh(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.sinh(x.v4_0), math.sinh(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise arcsine of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 asin(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.asin(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.asin(x.v4_0), math.asin(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise sine and cosine of the input <see cref="MaxMath.float8"/> <paramref name="x"/> through the <see langword="out" /> parameters <paramref name="s"/> and <paramref name="c"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void sincos(float8 x, out float8 s, out float8 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                // transcribed from Burst generated code for float4 sincos;
                // results can differ by (actualResult * 10 ^ (-6)); this is the version with the highest precision
            
                v256 ymm0, ymm1, ymm2, ymm3, ymm4, ymm5;
            
                ymm0 = x;
                ymm2 = Avx.mm256_and_ps(ymm0, Avx.mm256_set1_epi32(0x7FFF_FFFF));
                ymm1 = Avx.mm256_set1_epi32(0x42FA_0000);
                ymm1 = Avx.mm256_cmp_ps(ymm2, ymm1, (int)Avx.CMP.LT_OQ);
            
                if (Hint.Unlikely(Avx.mm256_movemask_ps(ymm1) != 0b1111_1111))
                {
                    goto LBB0_2;
                }
            
                ymm1 = Avx.mm256_set1_epi32(0x3F22_F983);
                ymm1 = Avx.mm256_mul_ps(ymm0, ymm1);
                ymm1 = Avx.mm256_cvtps_epi32(ymm1);
                ymm3 = Avx.mm256_cvtepi32_ps(ymm1);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xBFC9_0E00));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm0);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0xB86D_5000));
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xB088_5A31));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
            
            LBB0_5:
                ymm3 = Avx.mm256_mul_ps(ymm2, ymm2);
                ymm4 = Avx.mm256_set1_epi32(0x3C08_839A);
                ymm5 = Avx.mm256_set1_epi32(unchecked((int)0xB94C_A65B));
                ymm5 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0xBE2A_AAA2));
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm3, ymm4);
                ymm4 = Fma.mm256_fmadd_ps(ymm2, ymm4, ymm2);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0x8000_0000));
                ymm0 = Avx2.mm256_cmpeq_epi32(ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm4, ymm2, ymm0);
                ymm2 = Avx.mm256_set1_epi32(0x37D0_078B);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0xB491_ED89));
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xBAB6_0B58));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm4 = Avx.mm256_set1_epi32(0x3D2A_AAAA);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm4 = Avx.mm256_set1_epi32(0x3F80_0000);
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm4);
                ymm2 = Avx.mm256_set1_epi32(0x0000_0001);
                ymm2 = Avx2.mm256_and_si256(ymm1, ymm2);
                ymm3 = Avx.mm256_setzero_ps();
                ymm2 = Avx2.mm256_cmpeq_epi32(ymm2, ymm3);
                ymm3 = Avx.mm256_blendv_ps(ymm4, ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm4, ymm2);
                ymm2 = Avx2.mm256_slli_epi32(ymm1, 30);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0x8000_0000));
                ymm2 = Avx2.mm256_and_si256(ymm2, ymm4);
                ymm2 = Avx2.mm256_xor_si256(ymm2, ymm3);
                ymm3 = Avx2.mm256_cmpeq_epi32(default(v256), default(v256));
                ymm1 = Avx2.mm256_sub_epi32(ymm1, ymm3);
                ymm1 = Avx2.mm256_slli_epi32(ymm1, 30);
                ymm1 = Avx2.mm256_and_si256(ymm1, ymm4);
                ymm0 = Avx2.mm256_xor_si256(ymm1, ymm0);
            
                s = ymm2;
                c = ymm0;
                return;
            
            
            LBB0_2:
                ymm1 = Avx.mm256_set1_epi32(0x4718_5800);
                ymm1 = Avx.mm256_cmp_ps(ymm2, ymm1, (int)Avx.CMP.LT_OQ);
            
                if (Hint.Unlikely(Avx.mm256_movemask_ps(ymm1) != 0b1111_1111))
                {
                    goto LBB0_4;
                }
            
                ymm1 = Avx.mm256_set1_epi32(0x3F22_F983);
                ymm1 = Avx.mm256_mul_ps(ymm0, ymm1);
                ymm1 = Avx.mm256_cvtps_epi32(ymm1);
                ymm3 = Avx.mm256_cvtepi32_ps(ymm1);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xBFC9_0000));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm0);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0xB9FD_8000));
                ymm4 = Fma.mm256_fmadd_ps(ymm3, ymm4, ymm2);
                ymm5 = Avx.mm256_set1_epi32(unchecked((int)0xB4A8_8000));
                ymm5 = Fma.mm256_fmadd_ps(ymm3, ymm5, ymm4);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0xAE85_A309));
                ymm2 = Fma.mm256_fmadd_ps(ymm3, ymm2, ymm5);
            
                goto LBB0_5;
            }
            else if (Avx.IsAvxSupported)
            {
                // transcribed from Burst generated code for float4 sincos;
                // results can differ by (actualResult * 10 ^ (-6)); this is the version with the highest precision

                v256 ymm0, ymm1, ymm2, ymm3, ymm4;

                ymm1 = x;
                ymm0 = Avx.mm256_and_ps(ymm1, Avx.mm256_set1_epi32(0x7FFF_FFFF));
                ymm2 = Avx.mm256_cmp_ps(ymm0, Avx.mm256_set1_epi32(0x42FA_0000), (int)Avx.CMP.LT_OQ);

                if (Hint.Unlikely(Avx.mm256_movemask_ps(ymm2) != 0b1111_1111))
                {
                    goto LBB0_2;
                }

                ymm0 = Avx.mm256_mul_ps(ymm1, Avx.mm256_set1_epi32(0x3F22_F983));
                ymm3 = Avx.mm256_cvtps_epi32(ymm0);
                ymm0 = Avx.mm256_cvtepi32_ps(ymm3);
                ymm2 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xBFC9_0E00)));
                ymm2 = Avx.mm256_add_ps(ymm1, ymm2);
                ymm4 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xB86D_5000)));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm0 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xB088_5A31)));

            LBB0_5:
                ymm0 = Avx.mm256_add_ps(ymm2, ymm0);
                ymm2 = Avx.mm256_mul_ps(ymm0, ymm0);
                ymm4 = Avx.mm256_mul_ps(ymm2, Avx.mm256_set1_epi32(unchecked((int)0xB94C_A65B)));
                ymm4 = Avx.mm256_add_ps(ymm4, Avx.mm256_set1_epi32(0x3C08_839A));
                ymm4 = Avx.mm256_mul_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_add_ps(ymm4, Avx.mm256_set1_epi32(unchecked((int)0xBE2A_AAA2)));
                ymm4 = Avx.mm256_mul_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm0, ymm4);
                ymm0 = Avx.mm256_add_ps(ymm0, ymm4);
                ymm4 = Avx.mm256_set1_epi32(unchecked((int)0x8000_0000));
                v128 xmm1  = Sse2.cmpeq_epi32(Avx.mm256_castsi256_si128(ymm1), Avx.mm256_castsi256_si128(ymm4));
                v128 xmm11 = Sse2.cmpeq_epi32(Avx.mm256_extractf128_si256(ymm1, 1), Avx.mm256_castsi256_si128(ymm4));
                ymm1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm1), xmm11, 1);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm4, ymm1);
                ymm1 = Avx.mm256_mul_ps(ymm2, Avx.mm256_set1_epi32(unchecked((int)0xB491_ED89)));
                ymm1 = Avx.mm256_add_ps(ymm1, Avx.mm256_set1_epi32(0x37D0_078B));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Avx.mm256_set1_epi32(unchecked((int)0xBAB6_0B58)));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Avx.mm256_set1_epi32(0x3D2A_AAAA));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Avx.mm256_set1_epi32(unchecked((int)0xBF00_0000)));
                ymm1 = Avx.mm256_mul_ps(ymm2, ymm1);
                ymm1 = Avx.mm256_add_ps(ymm1, Avx.mm256_set1_epi32(0x3F80_0000));
                ymm2 = Avx.mm256_and_ps(ymm3, Avx.mm256_set1_epi32(0x0000_0001));
                v128 xmm4  = Sse2.setzero_si128();
                v128 xmm2  = Sse2.cmpeq_epi32(Avx.mm256_castsi256_si128(ymm2), xmm4);
                v128 xmm12 = Sse2.cmpeq_epi32(Avx.mm256_extractf128_si256(ymm2, 1), xmm4);
                ymm2 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm2), xmm12, 1);
                ymm4 = Avx.mm256_blendv_ps(ymm1, ymm0, ymm2);
                ymm0 = Avx.mm256_blendv_ps(ymm0, ymm1, ymm2);
                v128 xmm13 = Avx.mm256_extractf128_si256(ymm3, 1);
                xmm1  = Sse2.slli_epi32(Avx.mm256_castsi256_si128(ymm3), 30);
                xmm11 = Sse2.slli_epi32(xmm13, 30);
                ymm2 = Avx.mm256_set1_epi32(unchecked((int)0x8000_0000));
                ymm1 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm1), xmm11, 1);
                ymm1 = Avx.mm256_and_ps(ymm1, ymm2);
                ymm1 = Avx.mm256_xor_ps(ymm1, ymm4);
                xmm4 = Sse2.cmpeq_epi32(default(v128), default(v128));
                v128 xmm3 = Sse2.sub_epi32(Avx.mm256_castsi256_si128(ymm3), xmm4);
                xmm13 = Sse2.sub_epi32(xmm13, xmm4);
                xmm3  = Sse2.slli_epi32(xmm3, 30);
                xmm13 = Sse2.slli_epi32(xmm13, 30);
                ymm3 = Avx.mm256_insertf128_si256(Avx.mm256_castsi128_si256(xmm3), xmm13, 1);
                ymm2 = Avx.mm256_and_ps(ymm3, ymm2);
                ymm0 = Avx.mm256_xor_ps(ymm2, ymm0);

                s = ymm1;
                c = ymm0;
                return;


            LBB0_2:
                ymm2 = Avx.mm256_cmp_ps(ymm0, Avx.mm256_set1_epi32(0x4718_5800), (int)Avx.CMP.LT_OQ);

                if (Hint.Unlikely(Avx.mm256_movemask_ps(ymm2) != 0b1111_1111))
                {
                    goto LBB0_4;
                }

                ymm0 = Avx.mm256_mul_ps(ymm1, Avx.mm256_set1_epi32(0x3F22_F983));
                ymm3 = Avx.mm256_cvtps_epi32(ymm0);
                ymm0 = Avx.mm256_cvtepi32_ps(ymm3);
                ymm2 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xBFC9_0000)));
                ymm2 = Avx.mm256_add_ps(ymm1, ymm2);
                ymm4 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xB9FD_8000)));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm4 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xB4A8_8000)));
                ymm2 = Avx.mm256_add_ps(ymm2, ymm4);
                ymm0 = Avx.mm256_mul_ps(ymm0, Avx.mm256_set1_epi32(unchecked((int)0xAE85_A309)));

                goto LBB0_5;
            }

        LBB0_4:
            math.sincos(x.v4_0, out float4 sinLo, out float4 cosLo);
            math.sincos(x.v4_4, out float4 sinHi, out float4 cosHi);
            
            s = new float8(sinLo, sinHi);
            c = new float8(cosLo, cosHi);
        }


        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="y"/>.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, float8 y)
        {
            if (Constant.IsConstantExpression(y))
            {
                if (y.x0 == y.x1 && 
                    y.x0 == y.x2 && 
                    y.x0 == y.x3 &&
                    y.x0 == y.x4 &&
                    y.x0 == y.x5 && 
                    y.x0 == y.x6 && 
                    y.x0 == y.x7)
                {
                    return pow(x, y.x0);
                }
            }

            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.pow(x[i], y[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.pow(x.v4_0, y.v4_0), math.pow(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns the componentwise base-e exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.exp(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.exp(x.v4_0), math.exp(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise base-2 exponential of <paramref name="x"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp2(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.exp2(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.exp2(x.v4_0), math.exp2(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise base-10 exponential of <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 exp10(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.exp10(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.exp10(x.v4_0), math.exp10(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.log(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.log(x.v4_0), math.log(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.float8"/>.     </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log2(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.log2(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.log2(x.v4_0), math.log2(x.v4_4));
            }
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log10(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                for (int i = 0; i < 8; i++)
                {
                    x[i] = math.log10(x[i]);
                }

                return x;
            }
            else
            {
                return new float8(math.log10(x.v4_0), math.log10(x.v4_4));
            }
        }
    }
}