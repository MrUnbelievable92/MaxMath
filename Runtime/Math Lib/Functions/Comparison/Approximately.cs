using MaxMath.Intrinsics;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.FLOATING_POINT;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpapprox_ps(v128 a, v128 b, v128 t, bool promiseNotInf)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 SIGN_MASK = set1_epi32(1 << 31);
                    v128 INFINITY = set1_ps(float.PositiveInfinity);

                    v128 absA = andnot_ps(SIGN_MASK, a);
                    v128 absB = andnot_ps(SIGN_MASK, b);

                    v128 cmp = andnot_ps(SIGN_MASK, sub_ps(b, a));

                    if (!promiseNotInf)
                    {
                        v128 ainf = cmpeq_epi32(absA, INFINITY);
                        v128 binf = cmpeq_epi32(absB, INFINITY);
                        v128 eitherInfResult = ternarylogic_si128(cmp, ainf, binf, TernaryOperation.OxFE);
                        v128 bothInfResult = cmpneq_ps(a, b);
                        cmp = blendv_si128(eitherInfResult, bothInfResult, and_ps(ainf, binf));
                    }

                    return cmple_ps(cmp, t);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpapprox_ps(v256 a, v256 b, v256 t, bool promiseNotInf)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_MASK = mm256_set1_epi32(1 << 31);
                    v256 INFINITY = mm256_set1_ps(float.PositiveInfinity);

                    v256 absA = Avx.mm256_andnot_ps(SIGN_MASK, a);
                    v256 absB = Avx.mm256_andnot_ps(SIGN_MASK, b);

                    v256 cmp = Avx.mm256_andnot_ps(SIGN_MASK, Avx.mm256_sub_ps(b, a));

                    if (!promiseNotInf)
                    {
                        v256 ainf;
                        v256 binf;
                        if (Avx2.IsAvx2Supported)
                        {
                            ainf = Avx2.mm256_cmpeq_epi32(absA, INFINITY);
                            binf = Avx2.mm256_cmpeq_epi32(absB, INFINITY);
                        }
                        else
                        {
                            ainf = Xse.mm256_cmpeq_ps(absA, INFINITY);
                            binf = Xse.mm256_cmpeq_ps(absB, INFINITY);
                        }

                        v256 eitherInfResult = mm256_ternarylogic_si256(cmp, ainf, binf, TernaryOperation.OxFE);
                        v256 bothInfResult = Xse.mm256_cmpneq_ps(a, b);
                        cmp = Avx.mm256_blendv_ps(eitherInfResult, bothInfResult, Avx.mm256_and_ps(ainf, binf));
                    }

                    return Xse.mm256_cmple_ps(cmp, t);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpapprox_pd(v128 a, v128 b, v128 t, bool promiseNotInf)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 SIGN_MASK = set1_epi64x(1L << 63);
                    v128 INFINITY = set1_pd(double.PositiveInfinity);

                    v128 absA = andnot_pd(SIGN_MASK, a);
                    v128 absB = andnot_pd(SIGN_MASK, b);

                    v128 cmp = andnot_pd(SIGN_MASK, sub_pd(b, a));

                    if (!promiseNotInf)
                    {
                        v128 ainf;
                        v128 binf;
                        if (Architecture.IsCMP64Supported)
                        {
                            ainf = cmpeq_epi64(absA, INFINITY);
                            binf = cmpeq_epi64(absB, INFINITY);
                        }
                        else
                        {
                            ainf = cmpeq_epi32(absA, INFINITY);
                            binf = cmpeq_epi32(absB, INFINITY);
                            ainf = shuffle_epi32(ainf, Sse.SHUFFLE(3, 3, 1, 1));
                            binf = shuffle_epi32(binf, Sse.SHUFFLE(3, 3, 1, 1));
                        }

                        v128 eitherInfResult = ternarylogic_si128(cmp, ainf, binf, TernaryOperation.OxFE);
                        v128 bothInfResult = cmpneq_pd(a, b);
                        cmp = blendv_si128(eitherInfResult, bothInfResult, and_pd(ainf, binf));
                    }

                    return cmple_pd(cmp, t);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpapprox_pd(v256 a, v256 b, v256 t, bool promiseNotInf)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_MASK = mm256_set1_epi32(1 << 31);
                    v256 INFINITY = mm256_set1_pd(double.PositiveInfinity);

                    v256 absA = Avx.mm256_andnot_pd(SIGN_MASK, a);
                    v256 absB = Avx.mm256_andnot_pd(SIGN_MASK, b);

                    v256 cmp = Avx.mm256_andnot_pd(SIGN_MASK, Avx.mm256_sub_pd(b, a));

                    if (!promiseNotInf)
                    {
                        v256 ainf;
                        v256 binf;
                        if (Avx2.IsAvx2Supported)
                        {
                            ainf = Avx2.mm256_cmpeq_epi64(absA, INFINITY);
                            binf = Avx2.mm256_cmpeq_epi64(absB, INFINITY);
                        }
                        else
                        {
                            ainf = Xse.mm256_cmpeq_pd(absA, INFINITY);
                            binf = Xse.mm256_cmpeq_pd(absB, INFINITY);
                        }

                        v256 eitherInfResult = mm256_ternarylogic_si256(cmp, ainf, binf, TernaryOperation.OxFE);
                        v256 bothInfResult = Xse.mm256_cmpneq_pd(a, b);
                        cmp = Avx.mm256_blendv_pd(eitherInfResult, bothInfResult, Avx.mm256_and_pd(ainf, binf));
                    }

                    return Xse.mm256_cmple_pd(cmp, t);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpapprox_ps(v128 a, v128 b, bool promiseNotInf)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 SIGN_MASK = set1_epi32(1 << 31);
                    v128 MAX_RANGE_M1 = set1_ps(math.asfloat(maxmath.bitmask32((uint)MANTISSA_ROUNDING_BITS)));
                    v128 GUARANTEED_DECIMALS_M1 = set1_ps(F32_TO_LAST_DIGIT);

                    v128 absA = andnot_ps(SIGN_MASK, a);
                    v128 absB = andnot_ps(SIGN_MASK, b);

                    v128 range = max_ps(MAX_RANGE_M1, mul_ps(GUARANTEED_DECIMALS_M1, max_ps(absA, absB)));

                    return cmpapprox_ps(a, b, range, promiseNotInf);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpapprox_ps(v256 a, v256 b, bool promiseNotInf)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_MASK = mm256_set1_epi32(1 << 31);
                    v256 MAX_RANGE_M1 = mm256_set1_ps(math.asfloat(maxmath.bitmask32((uint)MANTISSA_ROUNDING_BITS)));
                    v256 GUARANTEED_DECIMALS_M1 = mm256_set1_ps(F32_TO_LAST_DIGIT);

                    v256 absA = Avx.mm256_andnot_ps(SIGN_MASK, a);
                    v256 absB = Avx.mm256_andnot_ps(SIGN_MASK, b);

                    v256 range = Avx.mm256_max_ps(MAX_RANGE_M1, Avx.mm256_mul_ps(GUARANTEED_DECIMALS_M1, Avx.mm256_max_ps(absA, absB)));

                    return mm256_cmpapprox_ps(a, b, range, promiseNotInf);
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmpapprox_pd(v128 a, v128 b, bool promiseNotInf)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 SIGN_MASK = set1_epi64x(1L << 63);
                    v128 MAX_RANGE_M1 = set1_pd(math.asdouble(maxmath.bitmask64((ulong)MANTISSA_ROUNDING_BITS)));
                    v128 GUARANTEED_DECIMALS_M1 = set1_pd(F64_TO_LAST_DIGIT);

                    v128 absA = andnot_pd(SIGN_MASK, a);
                    v128 absB = andnot_pd(SIGN_MASK, b);

                    v128 range = max_pd(MAX_RANGE_M1, mul_pd(GUARANTEED_DECIMALS_M1, max_pd(absA, absB)));

                    return cmpapprox_pd(a, b, range, promiseNotInf);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmpapprox_pd(v256 a, v256 b, bool promiseNotInf)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 SIGN_MASK = mm256_set1_epi32(1 << 31);
                    v256 MAX_RANGE_M1 = mm256_set1_pd(math.asdouble(maxmath.bitmask64((ulong)MANTISSA_ROUNDING_BITS)));
                    v256 GUARANTEED_DECIMALS_M1 = mm256_set1_pd(F64_TO_LAST_DIGIT);

                    v256 absA = Avx.mm256_andnot_pd(SIGN_MASK, a);
                    v256 absB = Avx.mm256_andnot_pd(SIGN_MASK, b);

                    v256 range = Avx.mm256_max_pd(MAX_RANGE_M1, Avx.mm256_mul_pd(GUARANTEED_DECIMALS_M1, Avx.mm256_max_pd(absA, absB)));

                    return mm256_cmpapprox_pd(a, b, range, promiseNotInf);
                }
                else throw new IllegalInstructionException();
            }
        }
    }

    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <see langword="true"/> if the two <see cref="float"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other, given a <paramref name="tolerance"/>. .
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(float a, float b, float tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return tobool(1 & Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0)).SInt0);
            }
            else
            {
                float cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool ainf = math.isinf(a);
                    bool binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asfloat(-1), ainf | binf), math.select(0f, math.asfloat(-1), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float2"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(float2 a, float2 b, float2 tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                float2 cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool2 ainf = math.isinf(a);
                    bool2 binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asfloat(-1), ainf | binf), math.select(0f, math.asfloat(-1), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float3"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(float3 a, float3 b, float3 tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                float3 cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool3 ainf = math.isinf(a);
                    bool3 binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asfloat(-1), ainf | binf), math.select(0f, math.asfloat(-1), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float4"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(float4 a, float4 b, float4 tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                float4 cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool4 ainf = math.isinf(a);
                    bool4 binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asfloat(-1), ainf | binf), math.select(0f, math.asfloat(-1), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="MaxMath.float8"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 approx(float8 a, float8 b, float8 tolerance, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmpapprox_ps(a, b, tolerance, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new bool8(approx(a.v4_0, b.v4_0, tolerance.v4_0, promises), approx(a.v4_4, b.v4_4, tolerance.v4_4, promises));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the two <see cref="double"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other, given a <paramref name="tolerance"/>. .
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(double a, double b, double tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return tobool(1 & Xse.cmpapprox_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0)).SLong0);
            }
            else
            {
                double cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool ainf = math.isinf(a);
                    bool binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asdouble(-1L), ainf | binf), math.select(0d, math.asdouble(-1L), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double2"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(double2 a, double2 b, double2 tolerance, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmpapprox_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), RegisterConversion.ToV128(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                double2 cmp = math.abs(b - a);

                if (!promises.Promises(Promise.Unsafe0))
                {
                    bool2 ainf = math.isinf(a);
                    bool2 binf = math.isinf(b);
                    cmp = math.select(math.select(cmp, math.asdouble(-1L), ainf | binf), math.select(0d, math.asdouble(-1L), a != b), ainf & binf);
                }

                return cmp <= tolerance;
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double3"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(double3 a, double3 b, double3 tolerance, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpapprox_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), RegisterConversion.ToV256(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return new bool3(approx(a.xy, b.xy, tolerance.xy, promises), approx(a.z, b.z, tolerance.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double4"/> <paramref name="b"/>, given a <paramref name="tolerance"/> component.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(double4 a, double4 b, double4 tolerance, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmpapprox_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), RegisterConversion.ToV256(tolerance), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return new bool4(approx(a.xy, b.xy, tolerance.xy, promises), approx(a.zw, b.zw, tolerance.zw, promises));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the two <see cref="float"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other. .
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(float a, float b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return tobool(1 & Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0)).SInt0);
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F32_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asfloat(maxmath.bitmask32((uint)MANTISSA_ROUNDING_BITS))), promises);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="float2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float2"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(float2 a, float2 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F32_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asfloat(maxmath.bitmask32((uint)MANTISSA_ROUNDING_BITS))), promises);
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="float3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float3"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(float3 a, float3 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F32_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asfloat(maxmath.bitmask32((uint)MANTISSA_ROUNDING_BITS))), promises);
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="float4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="float4"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(float4 a, float4 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue32(Xse.cmpapprox_ps(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F32_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asfloat(7u)), promises);
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.bool8"/> indicating for each component of a <see cref="MaxMath.float8"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="MaxMath.float8"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="float.PositiveInfinity"/>, and <see cref="float.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 approx(float8 a, float8 b, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.IsTrue32(Xse.mm256_cmpapprox_ps(a, b, promises.Promises(Promise.Unsafe0)));
            }
            else
            {
                return new bool8(approx(a.v4_0, b.v4_0, promises), approx(a.v4_4, b.v4_4, promises));
            }
        }


        /// <summary>       Returns <see langword="true"/> if the two <see cref="double"/>s <paramref name="a"/> and <paramref name="b"/> are approximately equal to each other .
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool approx(double a, double b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return tobool(1 & Xse.cmpapprox_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0)).SLong0);
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F64_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asdouble(maxmath.bitmask64((ulong)MANTISSA_ROUNDING_BITS))), promises);
            }
        }

        /// <summary>       Returns a <see cref="bool2"/> indicating for each component of a <see cref="double2"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double2"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 approx(double2 a, double2 b, Promise promises = Promise.Nothing)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Xse.cmpapprox_pd(RegisterConversion.ToV128(a), RegisterConversion.ToV128(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return approx(a, b, UnsafeFunctions.max(F64_TO_LAST_DIGIT * UnsafeFunctions.max(math.abs(a), math.abs(b)), math.asdouble(7ul)), promises);
            }
        }

        /// <summary>       Returns a <see cref="bool3"/> indicating for each component of a <see cref="double3"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double3"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 approx(double3 a, double3 b, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpapprox_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return new bool3(approx(a.xy, b.xy, promises), approx(a.z, b.z, promises));
            }
        }

        /// <summary>       Returns a <see cref="bool4"/> indicating for each component of a <see cref="double4"/> <paramref name="a"/> whether it is approximately equal to the corresponding component in the <see cref="double4"/> <paramref name="b"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for <see cref="double.PositiveInfinity"/>, and <see cref="double.NegativeInfinity"/>.     </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 approx(double4 a, double4 b, Promise promises = Promise.Nothing)
        {
            if (Avx.IsAvxSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmpapprox_pd(RegisterConversion.ToV256(a), RegisterConversion.ToV256(b), promises.Promises(Promise.Unsafe0))));
            }
            else
            {
                return new bool4(approx(a.xy, b.xy, promises), approx(a.zw, b.zw, promises));
            }
        }
    }
}