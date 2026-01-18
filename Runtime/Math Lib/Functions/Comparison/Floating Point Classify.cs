using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_pq(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi8(quarter.SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi8(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi8(cmp, set1_epi8(quarter.SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_ph(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi16(F16_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi16(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi16(cmp, set1_epi16(F16_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_ps(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi32(F32_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi32(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi32(cmp, set1_epi32(F32_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpnorm_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = and_si128(a, set1_epi64x(F64_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi64(cmp, setzero_si128());
                    v128 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = setzero_si128();
                    }
                    else
                    {
                        nanOrInf = cmpeq_epi64(cmp, set1_epi64x(F64_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return not_si128(zeroExponent);
                    }
                    else
                    {
                        return nor_si128(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi8(quarter.SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi8(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi8(cmp, mm256_set1_epi8(quarter.SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi16(F16_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi16(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi16(cmp, mm256_set1_epi16(F16_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi32(F32_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi32(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi32(cmp, mm256_set1_epi32(F32_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else if (Avx.IsAvxSupported)
                {
                    return mm256_cmprange_ps(mm256_abs_ps(a), mm256_set1_ps(math.FLT_MIN_NORMAL), mm256_set1_ps(float.MaxValue));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpnorm_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi64(cmp, Avx.mm256_setzero_si256());
                    v256 nanOrInf;
                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        nanOrInf = Avx.mm256_setzero_si256();
                    }
                    else
                    {
                        nanOrInf = Avx2.mm256_cmpeq_epi64(cmp, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));
                    }

                    if (COMPILATION_OPTIONS.FLOAT_NO_NAN
                     && COMPILATION_OPTIONS.FLOAT_NO_INF)
                    {
                        return mm256_not_si256(zeroExponent);
                    }
                    else
                    {
                        return mm256_nor_si256(zeroExponent, nanOrInf);
                    }
                }
                else if (Avx.IsAvxSupported)
                {
                    return mm256_cmprange_pd(mm256_abs_pd(a), mm256_set1_pd(math.DBL_MIN_NORMAL), mm256_set1_pd(double.MaxValue));
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_pq(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi8(quarter.SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi8(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi8(add_epi8(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi8(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_ph(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi16(F16_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi16(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi16(add_epi16(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi16(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_ps(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi32(F32_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi32(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi32(add_epi32(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi32(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpsubnorm_pd(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return setzero_si128();
                    }

                    v128 cmp = and_si128(a, set1_epi64x(F64_SIGNALING_EXPONENT));

                    v128 zeroExponent = cmpeq_epi64(cmp, setzero_si128());
                    v128 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = cmpeq_epi64(add_epi64(a, a), setzero_si128());
                    }
                    else
                    {
                        zero = cmpeq_epi64(a, setzero_si128());
                    }

                    return andnot_si128(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi8(quarter.SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi8(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi8(Avx2.mm256_add_epi8(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi16(F16_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi16(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi16(Avx2.mm256_add_epi16(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_ps(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi32(F32_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi32(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi32(Avx2.mm256_add_epi32(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else if (Avx.IsAvxSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    return Avx.mm256_and_ps(mm256_cmpneq_ps(a, Avx.mm256_setzero_ps()),
                                            mm256_cmpgt_ps(mm256_set1_ps(math.FLT_MIN_NORMAL), mm256_abs_ps(a)));
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpsubnorm_pd(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    v256 cmp = Avx2.mm256_and_si256(a, mm256_set1_epi64x(F64_SIGNALING_EXPONENT));

                    v256 zeroExponent = Avx2.mm256_cmpeq_epi64(cmp, Avx.mm256_setzero_si256());
                    v256 zero;
                    if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
                    {
                        zero = Avx2.mm256_cmpeq_epi64(Avx2.mm256_add_epi64(a, a), Avx.mm256_setzero_si256());
                    }
                    else
                    {
                        zero = Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256());
                    }

                    return Avx2.mm256_andnot_si256(zero, zeroExponent);
                }
                else if (Avx.IsAvxSupported)
                {
                    if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
                    {
                        return Avx.mm256_setzero_si256();
                    }

                    return Avx.mm256_and_pd(mm256_cmpneq_pd(a, Avx.mm256_setzero_pd()),
                                            mm256_cmpgt_pd(mm256_set1_pd(math.DBL_MIN_NORMAL), mm256_abs_pd(a)));
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if the <see cref="MaxMath.quarter"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(quarter x)
        {
            int cmp = asbyte(x) & quarter.SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != quarter.SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="half"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(half x)
        {
            int cmp = asushort(x) & F16_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F16_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="float"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(float x)
        {
            int cmp = math.asint(x) & F32_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F32_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="double"/> <paramref name="x"/> is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isnormal(double x)
        {
            long cmp = math.aslong(x) & F64_SIGNALING_EXPONENT;

            bool nonZeroExponent = cmp != 0;
            bool notNanInf;
            if (COMPILATION_OPTIONS.FLOAT_NO_NAN
             && COMPILATION_OPTIONS.FLOAT_NO_INF)
            {
                notNanInf = true;
            }
            else
            {
                notNanInf = cmp != F64_SIGNALING_EXPONENT;
            }

            return notNanInf & nonZeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> if the <see cref="MaxMath.quarter"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(quarter x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = asbyte(x) & quarter.SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = asbyte(x) << 25 != 0;
            }
            else
            {
                nonZero = asbyte(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="half"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(half x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = asushort(x) & F16_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = asushort(x) << 17 != 0;
            }
            else
            {
                nonZero = asushort(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="float"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(float x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            int cmp = math.asint(x) & F32_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = math.asint(x) << 1 != 0;
            }
            else
            {
                nonZero = math.asint(x) != 0;
            }

            return nonZero & zeroExponent;
        }

        /// <summary>       Returns <see langword="true"/> if the <see cref="double"/> <paramref name="x"/> is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool issubnormal(double x)
        {
            if (COMPILATION_OPTIONS.FLOAT_DENORMALS_ARE_ZERO)
            {
                return false;
            }

            long cmp = math.aslong(x) & F64_SIGNALING_EXPONENT;

            bool zeroExponent = cmp == 0;
            bool nonZero;
            if (COMPILATION_OPTIONS.FLOAT_SIGNED_ZERO)
            {
                nonZero = math.aslong(x) << 1 != 0;
            }
            else
            {
                nonZero = math.aslong(x) != 0;
            }

            return nonZero & zeroExponent;
        }


        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnormal(quarter2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmpnorm_pq(x)));
        	}
        	else
        	{
        		return new bool2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnormal(quarter3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.cmpnorm_pq(x)));
        	}
        	else
        	{
        		return new bool3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnormal(quarter4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.cmpnorm_pq(x)));
        	}
        	else
        	{
        		return new bool4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnormal(quarter8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue8(Xse.cmpnorm_pq(x));
        	}
        	else
        	{
        		return new bool8(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isnormal(quarter16 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue8(Xse.cmpnorm_pq(x));
        	}
        	else
        	{
        		return new bool16(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7), isnormal(x.x8), isnormal(x.x9), isnormal(x.x10), isnormal(x.x11), isnormal(x.x12), isnormal(x.x13), isnormal(x.x14), isnormal(x.x15));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 isnormal(quarter32 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue8(Xse.mm256_cmpnorm_pq(x));
        	}
        	else
        	{
        		return new bool32(isnormal(x.v16_0), isnormal(x.v16_16));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnormal(half2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.cmpnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnormal(half3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.cmpnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnormal(half4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.cmpnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnormal(half8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue16(Xse.cmpnorm_ph(x));
        	}
        	else
        	{
        		return new bool8(isnormal(x.x0), isnormal(x.x1), isnormal(x.x2), isnormal(x.x3), isnormal(x.x4), isnormal(x.x5), isnormal(x.x6), isnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 isnormal(half16 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue16(Xse.mm256_cmpnorm_ph(x));
        	}
        	else
        	{
        		return new bool16(isnormal(x.v8_0), isnormal(x.v8_8));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnormal(float2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmpnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnormal(float3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmpnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool3(isnormal(x.x), isnormal(x.y), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnormal(float4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmpnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool4(isnormal(x.x), isnormal(x.y), isnormal(x.z), isnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 isnormal(float8 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue32(Xse.mm256_cmpnorm_ps(x));
        	}
        	else
        	{
        		return new bool8(isnormal(x.v4_0), isnormal(x.v4_4));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 isnormal(double2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmpnorm_pd(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(isnormal(x.x), isnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 isnormal(double3 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpnorm_pd(RegisterConversion.ToV256(x))));
        	}
        	else
        	{
        		return new bool3(isnormal(x.xy), isnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, subnormal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 isnormal(double4 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmpnorm_pd(RegisterConversion.ToV256(x))));
        	}
        	else
        	{
        		return new bool4(isnormal(x.xy), isnormal(x.zw));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 issubnormal(quarter2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Xse.cmpsubnorm_pq(x)));
        	}
        	else
        	{
        		return new bool2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 issubnormal(quarter3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Xse.cmpsubnorm_pq(x)));
        	}
        	else
        	{
        		return new bool3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 issubnormal(quarter4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Xse.cmpsubnorm_pq(x)));
        	}
        	else
        	{
        		return new bool4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 issubnormal(quarter8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue8(Xse.cmpsubnorm_pq(x));
        	}
        	else
        	{
        		return new bool8(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 issubnormal(quarter16 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue8(Xse.cmpsubnorm_pq(x));
        	}
        	else
        	{
        		return new bool16(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7), issubnormal(x.x8), issubnormal(x.x9), issubnormal(x.x10), issubnormal(x.x11), issubnormal(x.x12), issubnormal(x.x13), issubnormal(x.x14), issubnormal(x.x15));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="MaxMath.quarter"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 issubnormal(quarter32 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue8(Xse.mm256_cmpsubnorm_pq(x));
        	}
        	else
        	{
        		return new bool32(issubnormal(x.v16_0), issubnormal(x.v16_16));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 issubnormal(half2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Xse.cmpsubnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 issubnormal(half3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Xse.cmpsubnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 issubnormal(half4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Xse.cmpsubnorm_ph(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 issubnormal(half8 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.IsTrue16(Xse.cmpsubnorm_ph(x));
        	}
        	else
        	{
        		return new bool8(issubnormal(x.x0), issubnormal(x.x1), issubnormal(x.x2), issubnormal(x.x3), issubnormal(x.x4), issubnormal(x.x5), issubnormal(x.x6), issubnormal(x.x7));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="half"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 issubnormal(half16 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue16(Xse.mm256_cmpsubnorm_ph(x));
        	}
        	else
        	{
        		return new bool16(issubnormal(x.v8_0), issubnormal(x.v8_8));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 issubnormal(float2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmpsubnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 issubnormal(float3 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmpsubnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool3(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 issubnormal(float4 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmpsubnorm_ps(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool4(issubnormal(x.x), issubnormal(x.y), issubnormal(x.z), issubnormal(x.w));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="float"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 issubnormal(float8 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.IsTrue32(Xse.mm256_cmpsubnorm_ps(x));
        	}
        	else
        	{
        		return new bool8(issubnormal(x.v4_0), issubnormal(x.v4_4));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 issubnormal(double2 x)
        {
        	if (BurstArchitecture.IsSIMDSupported)
        	{
        		return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmpsubnorm_pd(RegisterConversion.ToV128(x))));
        	}
        	else
        	{
        		return new bool2(issubnormal(x.x), issubnormal(x.y));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 issubnormal(double3 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpsubnorm_pd(RegisterConversion.ToV256(x))));
        	}
        	else
        	{
        		return new bool3(issubnormal(x.xy), issubnormal(x.z));
        	}
        }

        /// <summary>       Returns <see langword="true"/> for each <see cref="double"/> component in <paramref name="x"/> if it is neither 0, normal, infinite, nor NaN.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 issubnormal(double4 x)
        {
        	if (Avx2.IsAvx2Supported)
        	{
        		return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmpsubnorm_pd(RegisterConversion.ToV256(x))));
        	}
        	else
        	{
        		return new bool4(issubnormal(x.xy), issubnormal(x.zw));
        	}
        }
    }
}
