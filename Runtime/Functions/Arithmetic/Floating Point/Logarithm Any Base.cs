using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;

namespace MaxMath
{
    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the base <paramref name="b"/> logarithm of a <see cref="float"/> <paramref name="x"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float log(float x, float b)
        {
            if (Constant.IsConstantExpression(b))
            {
                switch (b)
                {
                    case math.E: return math.log(x);
                    case 2f:     return math.log2(x);
                    case 10f:    return math.log10(x);

                    default:     break;
                }
            }

            float2 ln = math.log(new float2(x, b));

            return ln.x / ln.y;
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 log(float2 x, float2 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E: return math.log(x);
                    case 2f:     return math.log2(x);
                    case 10f:    return math.log10(x);

                    default:     break;
                }
            }

            float4 ln = math.log(new float4(x, b));

            return ln.xy / ln.zw;
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 log(float3 x, float3 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E: return math.log(x);
                    case 2f:     return math.log2(x);
                    case 10f:    return math.log10(x);

                    default:     break;
                }
            }

            //if (Avx.IsAvxSupported)
            //{
            //    float8 ln = log(Avx.mm256_set_m128(UnityMathematicsLink.Tov128(b), UnityMathematicsLink.Tov128(x)));
            //    
            //    v128 _x = Avx.mm256_castps256_ps128(ln);
            //    v128 _b = Avx.mm256_extractf128_ps(ln, 1);
            //
            //    return *(float3*)&_x / *(float3*)&_b; 
            //}
            //else
            //{
            //    return math.log(x) / math.log(b);
            //}

            return math.log(x) / math.log(b);
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 log(float4 x, float4 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E: return math.log(x);
                    case 2f:     return math.log2(x);
                    case 10f:    return math.log10(x);

                    default:     break;
                }
            }

            //float8 ln = log(new float8(x, b));
            //
            //return ln.v4_0 / ln.v4_4;

            return math.log(x) / math.log(b);
        }

        /// <summary>       Returns the logarithm of each <see cref="float"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 log(float8 x, float8 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x0)
                {
                    case math.E: return log(x);
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
            if (Constant.IsConstantExpression(b))
            {
                switch (b)
                {
                    case math.E_DBL: return math.log(x);
                    case 2f:         return math.log2(x);
                    case 10f:        return math.log10(x);

                    default:         break;
                }
            }

            double2 ln = math.log(new double2(x, b));

            return ln.x / ln.y;
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 log(double2 x, double2 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E_DBL: return math.log(x);
                    case 2f:         return math.log2(x);
                    case 10f:        return math.log10(x);

                    default:         break;
                }
            }

            double4 ln = math.log(new double4(x, b));

            return ln.xy / ln.zw;
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 log(double3 x, double3 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E_DBL: return math.log(x);
                    case 2f:         return math.log2(x);
                    case 10f:        return math.log10(x);

                    default:         break;
                }
            }

            return math.log(x) / math.log(b);
        }

        /// <summary>       Returns the logarithm of each <see cref="double"/> component in <paramref name="x"/> to the corresponding logarithm base in <paramref name="b"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 log(double4 x, double4 b)
        {
            if (Constant.IsConstantExpression(b) && all_eq(b))
            {
                switch (b.x)
                {
                    case math.E_DBL: return math.log(x);
                    case 2f:         return math.log2(x);
                    case 10f:        return math.log10(x);

                    default:         break;
                }
            }
            
            return math.log(x) / math.log(b);
        }
    }
}