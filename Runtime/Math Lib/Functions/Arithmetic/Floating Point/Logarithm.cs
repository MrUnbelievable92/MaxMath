using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public static partial class math
    {
        /// <summary>       Returns the base <paramref name="b"/> logarithm of a <see cref="float"/> <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log(float x, float b)
        {
            if (constexpr.IS_CONST(b))
            {
                switch (b)
                {
                    case E: return log(x);
                    case 2f:     return log2(x);
                    case 10f:    return log10(x);

                    default:     break;
                }
            }

            float2 ln = log(new float2(x, b));

            return ln.x / ln.y;
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log(float2 x, float2 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E: return log(x);
                    case 2f:     return log2(x);
                    case 10f:    return log10(x);

                    default:     break;
                }
            }

            float4 ln = log(new float4(x, b));

            return ln.xy / ln.zw;
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log(float3 x, float3 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E: return log(x);
                    case 2f:     return log2(x);
                    case 10f:    return log10(x);

                    default:     break;
                }
            }

            if (Avx.IsAvxSupported)
            {
                float8 ln = math.log((float8)Avx.mm256_set_m128(b, x));

                v128 _x = Avx.mm256_castps256_ps128(ln);
                v128 _b = Avx.mm256_extractf128_ps(ln, 1);

                return Sse.div_ps(_x, _b);
            }
            else
            {
                return log(x) / log(b);
            }
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log(float4 x, float4 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E: return log(x);
                    case 2f:     return log2(x);
                    case 10f:    return log10(x);

                    default:     break;
                }
            }

            float8 ln = log(new float8(x, b));

            return ln.v4_0 / ln.v4_4;
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log(float8 x, float8 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x0)
                {
                    case E: return log(x);
                    case 2f:     return log2(x);
                    case 10f:    return log10(x);

                    default:     break;
                }
            }

            return log(x) / log(b);
        }


        /// <summary>       Returns the base <paramref name="b"/> logarithm of a <see cref="double"/> <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double log(double x, double b)
        {
            if (constexpr.IS_CONST(b))
            {
                switch (b)
                {
                    case E_DBL: return log(x);
                    case 2d:         return log2(x);
                    case 10d:        return log10(x);

                    default:         break;
                }
            }

            double2 ln = log(new double2(x, b));

            return ln.x / ln.y;
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log(double2 x, double2 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E_DBL: return log(x);
                    case 2d:         return log2(x);
                    case 10d:        return log10(x);

                    default:         break;
                }
            }

            double4 ln = log(new double4(x, b));

            return ln.xy / ln.zw;
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log(double3 x, double3 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E_DBL: return log(x);
                    case 2d:         return log2(x);
                    case 10d:        return log10(x);

                    default:         break;
                }
            }

            return log(x) / log(b);
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log(double4 x, double4 b)
        {
            if (constexpr.IS_TRUE(all_eq(b)))
            {
                switch (b.x)
                {
                    case E_DBL: return log(x);
                    case 2d:         return log2(x);
                    case 10d:        return log10(x);

                    default:         break;
                }
            }

            return log(x) / log(b);
        }


        /// <summary>       Returns the natural logarithm of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log(float x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log(float2 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log(float3 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log(float4 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = log(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(log(x.v4_0), log(x.v4_4));
            }
        }


        /// <summary>       Returns the natural logarithm of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double log(double x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log(double2 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log(double3 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log(double4 x)
        {
            return Unity.Mathematics.math.log(x);
        }
        
        
        /// <summary>       Returns the natural logarithm of a <see cref="quadruple"/>.    </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple log(quadruple x)
        {
            quadruple.ConstChecked z = default;
            quadruple.ConstChecked y = default;
            quadruple.ConstChecked w = default;
            z.Promise.MakeFiniteNotNaN();
            y.Promise.MakeFiniteNotNaN();
            w.Promise.MakeFiniteNotNaN();

            ulong m = x.value.hi64;
            long k = (long)x.value.hi64 & 0x7FFF_FFFF_FFFF_FFFF;

            if (quadruple.IsZero(x))
            {
                return quadruple.NegativeInfinity;
            }
            if ((long)m < 0)
            {
                return quadruple.NaN;
            }
            if (!(COMPILATION_OPTIONS.FLOAT_NO_NAN 
             && COMPILATION_OPTIONS.FLOAT_NO_INF) 
             && k >= 0x7FFF_0000_0000_0000)
            {
                return x;
            }
            
            quadruple.ConstChecked __x = x;
            __x.Promise.MakeFiniteNotNaN();
            __x.Promise.Positive = true;
            quadruple.ConstChecked t = default;
            t.Promise.MakeFiniteNotNaN();

            quadruple.ConstChecked u = frexp(__x, out int e);
            m = (ushort)(u.Value.value.hi64 >> 32);
            m |= 0x0001_0000;
            if (m < 0x0001_6800)
            {
                k = (long)((m - 0xFF00) >> 9);
                t.Value = new quadruple(0, 0x3FFF_0000_0000_0000 + ((ulong)k << 41));
                u.Value = new quadruple(u.Value.value.lo64, u.Value.value.hi64 + 0x0001_0000_0000_0000);
                e -= 1;
                k += 64;
            }
            else
            {
                k = (long)((m - 0xFE00) >> 10);
                t.Value = new quadruple(0, 0x3FFE_0000_0000_0000 + ((ulong)k << 42));
            }
            
            bool keepE = Hint.Likely(__x > 1.0078125 | __x < 0.9921875);
            if (keepE)
            {
                z = (u - t) / t;
                keepE = true;
            }
            else
            {
                if (__x == 1)
                {
                    return 0;
                }
                z = __x - 1;
                k = 64;
                keepE = false;
            }
            
            y = quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(
                quadruple.fmadd(new quadruple(0xF18C_C4D6_16B5_2FE2, 0x3FFB_111F_A6CD_0A24), z, new quadruple(0x307C_EFA7_DCE4_19CB, 0xBFFB_24A0_D09D_6DF5)), 
                                                                                             z, new quadruple(0x9525_86EA_703C_0A32, 0x3FFB_3B13_B0E0_15DF)), 
                                                                                             z, new quadruple(0x2ABC_4CD1_817A_9E2A, 0xBFFB_5555_5501_D424)), 
                                                                                             z, new quadruple(0xFCA7_7D04_8B59_5AEE, 0x3FFB_745D_1745_D297)), 
                                                                                             z, new quadruple(0xA16D_45E0_32B4_00DF, 0xBFFB_9999_9999_9A89)), 
                                                                                             z, new quadruple(0xC521_DFBA_DAA4_4000, 0x3FFB_C71C_71C7_1C71)), 
                                                                                             z, new quadruple(0xFE9A_6B0B_CC10_95B3, 0xBFFB_FFFF_FFFF_FFFF)), 
                                                                                             z, new quadruple(0x2492_4A0A_48BA_103F, 0x3FFC_2492_4924_9249)), 
                                                                                             z, new quadruple(0x5555_55D4_C8E6_392D, 0xBFFC_5555_5555_5555)), 
                                                                                             z, new quadruple(0x9999_9999_993B_7E9B, 0x3FFC_9999_9999_9999)), 
                                                                                             z, new quadruple(0xFFFF_FFFF_FFDF_79B7, 0xBFFC_FFFF_FFFF_FFFF)),
                                                                                             z, new quadruple(0x5555_5555_5555_555B, 0x3FFD_5555_5555_5555));
            w = square(z);
            y *= w * z;
            y = quadruple.fnmadd(0.5, w, y);
            if (keepE)
            {
                y = quadruple.fmadd(e, new quadruple(0x9E3B_3980_3F2F_6AF4, 0x3FEB_7F7D_1CF7_9ABC), y);
            }
            y += z;
            y += LUT.QUADRUPLE.log((int)k - 26);
            if (keepE)
            {
                y += t - 1;
                y = quadruple.fmadd(e, new quadruple(0x0000_0000_0000_0000, 0x3FFE_62E4_0000_0000), y);
            }
            return y;
        }


        /// <summary>       Returns the base-2 logarithm of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log2(float x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log2(float2 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log2(float3 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log2(float4 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log2(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = log2(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(log2(x.v4_0), log2(x.v4_4));
            }
        }


        /// <summary>       Returns the base-2 logarithm of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double log2(double x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log2(double2 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log2(double3 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log2(double4 x)
        {
            return Unity.Mathematics.math.log2(x);
        }
        
        
        /// <summary>       Returns the base-2 logarithm of a <see cref="quadruple"/>.    </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple log2(quadruple x)
        {
            return log_Base(x, 2);
        }


        /// <summary>       Returns the base-10 logarithm of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log10(float x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log10(float2 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log10(float3 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log10(float4 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log10(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                float8 r = Uninitialized<float8>.Create();

                for (int i = 0; i < 8; i++)
                {
                    *((float*)&r + i) = log10(*((float*)&x + i));
                }

                return r;
            }
            else
            {
                return new float8(log10(x.v4_0), log10(x.v4_4));
            }
        }


        /// <summary>       Returns the base-10 logarithm of a <see cref="double"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double log10(double x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log10(double2 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log10(double3 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log10(double4 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        
        /// <summary>       Returns the base-10 logarithm of a <see cref="quadruple"/>.    </summary>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static quadruple log10(quadruple x)
        {
            return log_Base(x, 10);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static quadruple log_Base(quadruple x, int __base)
        {
            quadruple.ConstChecked z = default;
            quadruple.ConstChecked y = default;
            z.Promise.MakeFiniteNotNaN();
            y.Promise.MakeFiniteNotNaN();
            
            if (Hint.Unlikely(quadruple.IsZero(x)))
            {
                return quadruple.NegativeInfinity;
            }
            if (Hint.Unlikely((long)x.value.hi64 < 0))
            {
                return quadruple.NaN;
            }
            if (!COMPILATION_OPTIONS.FLOAT_NO_NAN 
             && !COMPILATION_OPTIONS.FLOAT_NO_INF
             && Hint.Unlikely(x.value.hi64 >= 0x7FFF_0000_0000_0000))
            {
                return x;
            }
            if (Hint.Unlikely(x == 1))
            {
                return 0;
            }

            quadruple.ConstChecked __x = x;
            __x.Promise.MakeFiniteNotNaN();
            __x.Promise.Positive = true;

            __x = frexp(__x, out int e);
            bool lt = __x < new quadruple(0xC908_B2FB_1366_EA95, 0x3FFE_6A09_E667_F3BC);
            quadruple.ConstChecked p = default;
            quadruple.ConstChecked q = default;
            p.Promise.MakeFiniteNotNaN();
            q.Promise.MakeFiniteNotNaN();

            if (Hint.Likely(!isinrange(e, -2, 2)))
            {
                e -= tobyte(lt);
                z = __x - (lt ? 0.5 : 1);
	            y = quadruple.fmadd(0.5, lt ? z : __x, 0.5);

                __x = z / y;
                z = square(__x);
                
                p = quadruple.fmadd(z, new quadruple(0x6847_9D54_E4CE_D708, 0xBFFE_C40A_1C87_4F5A), new quadruple(0x565B_5611_A30D_F628, 0x4005_4247_B533_971E));
                p = quadruple.fmadd(z, p, new quadruple(0xB690_EDDD_457E_03B0, 0xC009_FA13_50A9_210E));
                p = quadruple.fmadd(z, p, new quadruple(0xEA12_30D4_DC2A_41C8, 0x400D_4020_CBB3_C4ED));
                p = quadruple.fmadd(z, p, new quadruple(0x388E_5D3A_E806_C32A, 0xC00F_5EAC_9478_0E23));
                p = quadruple.fmadd(z, p, new quadruple(0x6802_A6FB_3250_B4FD, 0x4010_14FA_B5E2_E8C1));
                q = z + new quadruple(0x2575_CD7C_ADD5_2C63, 0xC005_DA8B_3410_8B63);
                q = quadruple.fmadd(z, q, new quadruple(0x9022_BF51_E9D2_0AEC, 0x400A_F3D0_DB24_DF08));
                q = quadruple.fmadd(z, q, new quadruple(0xEB27_FC10_32BB_267D, 0xC00E_C11A_D77C_C51C));
                q = quadruple.fmadd(z, q, new quadruple(0xAEEC_5BD6_A521_1CBD, 0x4011_86C6_F13D_F72E));
                q = quadruple.fmadd(z, q, new quadruple(0xEE9E_91E4_B302_0178, 0xC013_4553_71E0_4BC5));
                q = quadruple.fmadd(z, q, new quadruple(0x1C03_FA78_CB79_1730, 0x4013_9F78_10D4_5D22));

                y = __x * (z * p / q);
            }
            else
            {
                e -= tobyte(lt);

                if (lt)
                {
                    __x *= 2;
                }

                __x -= 1;
                z = square(__x);
                
                p = quadruple.fmadd(__x, new quadruple(0x9543_4922_0085_60FC, 0x3FEB_9D04_A0D6_ED82), new quadruple(0x2E9C_B5E9_1A8C_2FA0, 0x3FFD_FFD7_E213_47CC));
                p = quadruple.fmadd(__x, p, new quadruple(0x674C_43EA_62A5_92E7, 0x4003_7361_5178_FE96));
                p = quadruple.fmadd(__x, p, new quadruple(0xFA53_9715_D5FD_0560, 0x4007_9B73_A863_9C28));
                p = quadruple.fmadd(__x, p, new quadruple(0x5EC5_C60D_38B7_FA2A, 0x400A_DE1E_79B3_AE12));
                p = quadruple.fmadd(__x, p, new quadruple(0x6369_F0CA_DA64_EEEC, 0x400D_4CA2_4F05_50CF));
                p = quadruple.fmadd(__x, p, new quadruple(0x1151_04B6_44C1_F464, 0x400F_28A7_9182_2D40));
                p = quadruple.fmadd(__x, p, new quadruple(0x95EC_4348_8121_AFF8, 0x4010_5F19_6A49_F171));
                p = quadruple.fmadd(__x, p, new quadruple(0xA248_4B71_71AB_5034, 0x4011_16CA_BA9F_2757));
                p = quadruple.fmadd(__x, p, new quadruple(0xE49B_2BF8_646A_8A1E, 0x4011_25A7_2EB0_5BA7));
                p = quadruple.fmadd(__x, p, new quadruple(0x17AC_5C73_7D1B_8AD4, 0x4010_897C_A319_418D));
                p = quadruple.fmadd(__x, p, new quadruple(0x9FF1_5925_DA76_D408, 0x400F_2F8F_8BFB_F9A1));
                p = quadruple.fmadd(__x, p, new quadruple(0xE740_B854_4D79_077C, 0x400C_9A7D_CAD5_D0EF));
                q = __x + new quadruple(0x4A21_13DA_AC8D_7FA5, 0x4004_8322_FBDA_4D3F);
                q = quadruple.fmadd(__x, q, new quadruple(0x9EFB_2FE2_C778_F56F, 0x4008_C73F_1477_7E56));
                q = quadruple.fmadd(__x, q, new quadruple(0xF23A_98D4_34D3_A705, 0x400C_1DD9_33EA_5565));
                q = quadruple.fmadd(__x, q, new quadruple(0x4B44_059A_3B76_F461, 0x400E_B5F4_D77A_ED02));
                q = quadruple.fmadd(__x, q, new quadruple(0x2962_234D_48FF_F0BC, 0x4010_B71B_B67F_5EFF));
                q = quadruple.fmadd(__x, q, new quadruple(0xE673_C713_BCF2_4EE3, 0x4012_2B6C_5DDA_C3B8));
                q = quadruple.fmadd(__x, q, new quadruple(0x34D8_D36E_8DE3_7C71, 0x4013_1AB8_3FA3_B03B));
                q = quadruple.fmadd(__x, q, new quadruple(0x0613_38BB_0E95_B314, 0x4013_71D8_273F_762A));
                q = quadruple.fmadd(__x, q, new quadruple(0xE379_B5D8_E707_1D74, 0x4013_48FB_E89D_38E2));
                q = quadruple.fmadd(__x, q, new quadruple(0x412E_AFAF_EA23_3277, 0x4012_7BC5_2116_88C1));
                q = quadruple.fmadd(__x, q, new quadruple(0x1637_8FD2_514B_A129, 0x4011_0088_8140_03EA));
                q = quadruple.fmadd(__x, q, new quadruple(0xED70_8A3F_3A1A_C5CA, 0x400E_33DE_5820_5CB3));
                
                y = __x * (z * p / q);
                y = quadruple.fnmadd(0.5, z, y);
            }

            if (__base == 2)
            {
                quadruple LOG2EA = new quadruple(0x85DD_F43F_F683_48EA, 0x3FFD_C551_D94A_E0BF);

                z = y * LOG2EA;
                z = quadruple.fmadd(__x, LOG2EA, z);
                z += y;
                z += __x;
                z += e;

                return z;
            }
            else
            {
                z = y * new quadruple(0x7356_5522_AA82_9661, 0xBFFB_0D21_3AB6_46BC);
                z = quadruple.fmadd(__x, new quadruple(0x7356_5522_AA82_9661, 0xBFFB_0D21_3AB6_46BC), z);
                z = quadruple.fmadd(e, new quadruple(0x19DC_1DA9_94FD_20DC, 0xBFF8_77D9_5EC1_0C02), z);
                z = quadruple.fmadd(y, 0.5, z);
                z = quadruple.fmadd(__x, 0.5, z);
                z = quadruple.fmadd(e, 0.3125, z);

                return z;
            }
        }
    }
}