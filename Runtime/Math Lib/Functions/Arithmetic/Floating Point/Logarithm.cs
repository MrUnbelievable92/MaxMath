using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
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

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log(float2 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log(float3 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log(float4 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.float8"/>.    </summary>
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

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log(double2 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log(double3 x)
        {
            return Unity.Mathematics.math.log(x);
        }

        /// <summary>       Returns the componentwise natural logarithm of a <see cref="MaxMath.double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log(double4 x)
        {
            return Unity.Mathematics.math.log(x);
        }


        /// <summary>       Returns the base-2 logarithm of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log2(float x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log2(float2 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log2(float3 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log2(float4 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.float8"/>.    </summary>
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

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log2(double2 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log2(double3 x)
        {
            return Unity.Mathematics.math.log2(x);
        }

        /// <summary>       Returns the componentwise base-2 logarithm of a <see cref="MaxMath.double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log2(double4 x)
        {
            return Unity.Mathematics.math.log2(x);
        }


        /// <summary>       Returns the base-10 logarithm of a <see cref="float"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log10(float x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.float2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log10(float2 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.float3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log10(float3 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.float4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log10(float4 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.float8"/>.    </summary>
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

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.double2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log10(double2 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.double3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log10(double3 x)
        {
            return Unity.Mathematics.math.log10(x);
        }

        /// <summary>       Returns the componentwise base-10 logarithm of a <see cref="MaxMath.double4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log10(double4 x)
        {
            return Unity.Mathematics.math.log10(x);
        }
    }
}