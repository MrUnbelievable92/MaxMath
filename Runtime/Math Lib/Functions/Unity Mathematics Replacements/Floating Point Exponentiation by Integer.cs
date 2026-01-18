using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using DevTools;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_powps_epu32(v128 a, [NoAlias] ref v128 b, [NoAlias] out v128 y, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi32(1);

                    y = blendv_si128(set1_ps(1f), a, cmpeq_epi32(ONE, and_si128(b, ONE)));
                    b = srli_epi32(b, 1);

                    if (Sse4_1.IsSse41Supported)
                    {
                        b = zeromissing_epi32(b, elements);
                    }

                    doneMask = cmpeq_epi32(ZERO, b);
                    result = and_si128(y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_powpd_epu64(v128 a, [NoAlias] ref v128 b, [NoAlias] out v128 y, [NoAlias] out v128 doneMask, [NoAlias] out v128 result, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1);

                    y = blendv_si128(set1_pd(1d), a, cmpeq_epi64(ONE, and_si128(b, ONE)));
                    b = srli_epi64(b, 1);

                    if (Sse4_1.IsSse41Supported)
                    {
                        if (elements == 1)
                        {
                            b = and_si128(b, new v128(-1L, 0));
                        }
                    }

                    doneMask = cmpeq_epi64(ZERO, b);
                    result = and_si128(y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_powps_epu32([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 y, [NoAlias] ref v128 doneMask, [NoAlias] ref v128 result, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi32(1);

                    a = mul_ps(a, a);
                    v128 y_times_x = mul_ps(y, a);
                    y = blendv_si128(y, y_times_x, cmpeq_epi32(ONE, and_si128(ONE, b)));
                    b = srli_epi32(b, 1);
                    doneMask = cmpeq_epi32(ZERO, b);
                    result = blendv_si128(result, y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_powpd_epu64([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 y, [NoAlias] ref v128 doneMask, [NoAlias] ref v128 result, byte elements = 2)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1);

                    a = mul_pd(a, a);
                    v128 y_times_x = mul_pd(y, a);
                    y = blendv_si128(y, y_times_x, cmpeq_epi64(ONE, and_si128(ONE, b)));
                    b = srli_epi64(b, 1);
                    doneMask = cmpeq_epi64(ZERO, b);
                    result = blendv_si128(result, y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 powps_epu32(v128 a, v128 b, bool lowPrecision = false, byte elements = 4)
            {
                static bool ContinueLoop32(v128 b, v128 doneMask, byte elements)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Hint.Likely(testz_si128(b, b) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<uint>(doneMask, elements));
                    }
                    else throw new IllegalInstructionException();
                }

                static bool ContinueLoop64(v128 b, v128 doneMask)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Hint.Likely(testz_si128(b, b) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<ulong>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }

                static bool ContinueLoop64x2(v128 bLo, v128 bHi, v128 doneMaskLo, v128 doneMaskHi)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 test = or_si128(bLo, bHi);
                        return Hint.Likely(testz_si128(test, test) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(doneMaskLo, doneMaskHi);
                        return Hint.Likely(notalltrue_epi128<ulong>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 1, elements))
                    {
                        return set1_epi32(1);
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 2, elements))
                    {
                        return sllv_epi32(set1_epi32(1), b, elements: elements);
                    }

                    if (constexpr.ALL_SAME_EPU32(b, elements))
                    {

                    }


                    if (lowPrecision)
                    {
                        PRELOOP_powps_epu32(a, ref b, out v128 y, out v128 doneMask, out v128 result, elements);

                        while (ContinueLoop32(b, doneMask, elements))
                        {
                            LOOP_powps_epu32(ref a, ref b, ref y, ref doneMask, ref result, elements);
                        }

                        return result;
                    }
                    else
                    {
                        switch (elements)
                        {
                            case 2:
                            {
                                v128 a64 = cvtps_pd(a);
                                v128 b64 = cvtepu32_epi64(a);

                                PRELOOP_powpd_epu64(a64, ref b64, out v128 y, out v128 doneMask, out v128 result);

                                while (ContinueLoop64(b64, doneMask))
                                {
                                    LOOP_powpd_epu64(ref a64, ref b64, ref y, ref doneMask, ref result);
                                }

                                return cvtpd_ps(result);
                            }
                            case 3:
                            case 4:
                            {
                                v128 a64Lo = cvtps_pd(a);
                                v128 a64Hi = cvtps_pd(bsrli_si128(a, 2 * sizeof(float)));
                                v128 b64Lo = cvtepu32_epi64(b);
                                v128 b64Hi = cvtepu32_epi64(bsrli_si128(b, 2 * sizeof(float)));

                                PRELOOP_powpd_epu64(a64Lo, ref b64Lo, out v128 yLo, out v128 doneMaskLo, out v128 resultLo, 2);
                                PRELOOP_powpd_epu64(a64Hi, ref b64Hi, out v128 yHi, out v128 doneMaskHi, out v128 resultHi, (byte)(elements == 3 ? 1 : 2));

                                while (ContinueLoop64x2(b64Lo, b64Hi, doneMaskLo, doneMaskHi))
                                {
                                    LOOP_powpd_epu64(ref a64Lo, ref b64Lo, ref yLo, ref doneMaskLo, ref resultLo);
                                    LOOP_powpd_epu64(ref a64Hi, ref b64Hi, ref yHi, ref doneMaskHi, ref resultHi);
                                }

                                return unpacklo_epi64(cvtpd_ps(resultLo), cvtpd_ps(resultHi));
                            }

                            default: throw Assert.Unreachable();
                        }
                    }

                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void powps_epu32x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 b0, v128 b1, v128 doneMask0, v128 doneMask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 b = or_si128(b0, b1);

                        return Hint.Likely(testz_si128(b, b) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(doneMask0, doneMask1);

                        return Hint.Likely(notalltrue_epi128<int>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    PRELOOP_powps_epu32(a0, ref b0, out v128 y0, out v128 doneMask0, out r0);
                    PRELOOP_powps_epu32(a1, ref b1, out v128 y1, out v128 doneMask1, out r1);

                    while (ContinueLoop(b0, b1, doneMask0, doneMask1))
                    {
                        LOOP_powps_epu32(ref a0, ref b0, ref y0, ref doneMask0, ref r0);
                        LOOP_powps_epu32(ref a1, ref b1, ref y1, ref doneMask1, ref r1);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_powps_epu32(v256 a, v256 b, bool lowPrecision = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_PS(a, 1))
                    {
                        return mm256_set1_ps(1);
                    }

                    if (constexpr.ALL_SAME_EPU32(b))
                    {

                    }

                    lowPrecision |= COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low;
                    lowPrecision |= constexpr.ALL_LE_EPU32(b, 16);

                    if (lowPrecision)
                    {
                        v256 ZERO = Avx.mm256_setzero_si256();
                        v256 ONE = mm256_set1_epi32(1);

                        v256 y = mm256_blendv_si256(mm256_set1_ps(1f), a, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(b, ONE)));
                        b = Avx2.mm256_srli_epi32(b, 1);
                        v256 result = Avx.mm256_and_ps(y, Avx2.mm256_cmpeq_epi32(ZERO, b));

                        while (Hint.Likely(Avx.mm256_testz_si256(b, b) == 0))
                        {
                            a = Avx.mm256_mul_ps(a, a);
                            v256 y_times_x = Avx.mm256_mul_ps(y, a);
                            y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(b, ONE)));
                            b = Avx2.mm256_srli_epi32(b, 1);
                            result = mm256_blendv_si256(result, y, Avx2.mm256_cmpeq_epi32(ZERO, b));
                        }

                        return result;
                    }
                    else
                    {
                        v256 ZERO = Avx.mm256_setzero_si256();
                        v256 ONE = mm256_set1_epi64x(1);

                        v256 aDblLO = Avx.mm256_cvtps_pd(a.Lo128);
                        v256 aDblHI = Avx.mm256_cvtps_pd(a.Hi128);
                        v256 b64LO = Avx2.mm256_cvtepu32_epi64(b.Lo128);
                        v256 b64HI = Avx2.mm256_cvtepu32_epi64(b.Hi128);

                        v256 yLO = mm256_blendv_si256(mm256_set1_pd(1d), aDblLO, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b64LO, ONE)));
                        v256 yHI = mm256_blendv_si256(mm256_set1_pd(1d), aDblHI, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b64HI, ONE)));
                        b64LO = Avx2.mm256_srli_epi64(b64LO, 1);
                        b64HI = Avx2.mm256_srli_epi64(b64HI, 1);
                        v256 resultLO = Avx.mm256_and_ps(yLO, Avx2.mm256_cmpeq_epi64(ZERO, b64LO));
                        v256 resultHI = Avx.mm256_and_ps(yHI, Avx2.mm256_cmpeq_epi64(ZERO, b64HI));

                        while (Hint.Likely(Avx.mm256_testz_si256(Avx2.mm256_or_si256(b64LO, b64HI), Avx2.mm256_or_si256(b64LO, b64HI)) == 0))
                        {
                            aDblLO = Avx.mm256_mul_pd(aDblLO, aDblLO);
                            aDblHI = Avx.mm256_mul_pd(aDblHI, aDblHI);
                            v256 y_times_xLO = Avx.mm256_mul_pd(yLO, aDblLO);
                            v256 y_times_xHI = Avx.mm256_mul_pd(yHI, aDblHI);
                            yLO = mm256_blendv_si256(yLO, y_times_xLO, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b64LO, ONE)));
                            yHI = mm256_blendv_si256(yHI, y_times_xHI, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b64HI, ONE)));
                            b64LO = Avx2.mm256_srli_epi64(b64LO, 1);
                            b64HI = Avx2.mm256_srli_epi64(b64HI, 1);
                            resultLO = mm256_blendv_si256(resultLO, yLO, Avx2.mm256_cmpeq_epi64(ZERO, b64LO));
                            resultHI = mm256_blendv_si256(resultHI, yHI, Avx2.mm256_cmpeq_epi64(ZERO, b64HI));
                        }

                        v128 castLO = Avx.mm256_cvtpd_ps(resultLO);
                        v128 castHI = Avx.mm256_cvtpd_ps(resultHI);
                        return new v256(castLO, castHI);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void PRELOOP_powpd_epu64(v128 a, [NoAlias] ref v128 b, [NoAlias] out v128 y, [NoAlias] out v128 doneMask, [NoAlias] out v128 result)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1);

                    y = blendv_si128(ONE, a, cmpeq_epi64(ONE, and_si128(b, ONE)));
                    b = srli_epi64(b, 1);

                    doneMask = cmpeq_epi64(ZERO, b);
                    result = and_si128(y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static void LOOP_powpd_epu64([NoAlias] ref v128 a, [NoAlias] ref v128 b, [NoAlias] ref v128 y, [NoAlias] ref v128 doneMask, [NoAlias] ref v128 result)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 ZERO = setzero_si128();
                    v128 ONE = set1_epi64x(1);

                    a = square_epi64(a);
                    v128 y_times_x = mullo_epi64(y, a);
                    y = blendv_si128(y, y_times_x, cmpeq_epi64(ONE, and_si128(b, ONE)));
                    b = srli_epi64(b, 1);
                    doneMask = cmpeq_epi64(ZERO, b);
                    result = blendv_si128(result, y, doneMask);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 powpd_epu64(v128 a, v128 b)
            {
                static bool ContinueLoop(v128 b, v128 doneMask)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        return Hint.Likely(testz_si128(b, b) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Hint.Likely(notalltrue_epi128<ulong>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 1))
                    {
                        return set1_epi64x(1);
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 2))
                    {
                        return sllv_epi64(set1_epi64x(1), b);
                    }


                    if (constexpr.ALL_SAME_EPU64(b))
                    {
                        switch (b.ULong0)
                        {
                            case 0:  { return set1_epi64x(1); }

                            case 1:  { return a; }
                            case 2:  { return square_epi64(a); }
                            case 3:  { return mullo_epi64(a, square_epi64(a)); }
                            case 4:  { v128 a2 = square_epi64(a); return square_epi64(a2); }
                            case 5:  { v128 a2 = square_epi64(a); return mullo_epi64(a, square_epi64(a2)); }
                            case 6:  { v128 a2 = square_epi64(a); return mullo_epi64(a2, square_epi64(a2)); }
                            case 7:  { v128 a2 = square_epi64(a); return mullo_epi64(mullo_epi64(a, a2), square_epi64(a2)); }
                            case 8:  { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return square_epi64(a4); }
                            case 9:  { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(a, square_epi64(a4)); }
                            case 10: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(a2, square_epi64(a4)); }
                            case 11: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(mullo_epi64(a, a2), square_epi64(a4)); }
                            case 12: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(a4, square_epi64(a4)); }
                            case 13: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(mullo_epi64(a, a4), square_epi64(a4)); }
                            case 14: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(mullo_epi64(a2, a4), square_epi64(a4)); }
                            case 15: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), square_epi64(a4)); }
                            case 16: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return square_epi64(a8); }
                            case 17: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(a, square_epi64(a8)); }
                            case 18: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(a2, square_epi64(a8)); }
                            case 19: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a, a2), square_epi64(a8)); }
                            case 20: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(a4, square_epi64(a8)); }
                            case 21: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a, a4), square_epi64(a8)); }
                            case 22: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a2, a4), square_epi64(a8)); }
                            case 23: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), square_epi64(a8)); }
                            case 24: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(a8, square_epi64(a8)); }
                            case 25: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a, a8), square_epi64(a8)); }
                            case 26: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a2, a8), square_epi64(a8)); }
                            case 27: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), square_epi64(a8)); }
                            case 28: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(a4, a8), square_epi64(a8)); }
                            case 29: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), square_epi64(a8)); }
                            case 30: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), square_epi64(a8)); }
                            case 31: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a4, a8)), square_epi64(a8)); }
                            case 32: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return square_epi64(a16); }
                            case 33: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(a, square_epi64(a16)); }
                            case 34: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(a2, square_epi64(a16)); }
                            case 35: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a, a2), square_epi64(a16)); }
                            case 36: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(a4, square_epi64(a16)); }
                            case 37: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a, a4), square_epi64(a16)); }
                            case 38: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a2, a4), square_epi64(a16)); }
                            case 39: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), square_epi64(a16)); }
                            case 40: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(a8, square_epi64(a16)); }
                            case 41: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a, a8), square_epi64(a16)); }
                            case 42: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a2, a8), square_epi64(a16)); }
                            case 43: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), square_epi64(a16)); }
                            case 44: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a4, a8), square_epi64(a16)); }
                            case 45: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), square_epi64(a16)); }
                            case 46: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), square_epi64(a16)); }
                            case 47: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a8), square_epi64(a16)); }
                            case 48: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(a16, square_epi64(a16)); }
                            case 49: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a, a16), square_epi64(a16)); }
                            case 50: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a2, a16), square_epi64(a16)); }
                            case 51: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a16), square_epi64(a16)); }
                            case 52: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a4, a16), square_epi64(a16)); }
                            case 53: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a16), square_epi64(a16)); }
                            case 54: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a16), square_epi64(a16)); }
                            case 55: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a16), square_epi64(a16)); }
                            case 56: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(a8, a16), square_epi64(a16)); }
                            case 57: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a8), a16), square_epi64(a16)); }
                            case 58: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a8), a16), square_epi64(a16)); }
                            case 59: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), a16), square_epi64(a16)); }
                            case 60: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(a4, a8), a16), square_epi64(a16)); }
                            case 61: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), a16), square_epi64(a16)); }
                            case 62: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), a16), square_epi64(a16)); }
                            case 63: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a8), a16), square_epi64(a16)); }
                            case 64: { v128 a2 = square_epi64(a); v128 a4 = square_epi64(a2); v128 a8 = square_epi64(a4); v128 a16 = square_epi64(a8); v128 a32 = square_epi64(a16); return square_epi64(a32); }

                            default: break;
                        }
                    }


                    PRELOOP_powpd_epu64(a, ref b, out v128 y, out v128 doneMask, out v128 result);

                    while (ContinueLoop(b, doneMask))
                    {
                        LOOP_powpd_epu64(ref a, ref b, ref y, ref doneMask, ref result);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void powpd_epu64x2(v128 a0, v128 a1, v128 b0, v128 b1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
            {
                static bool ContinueLoop(v128 b0, v128 b1, v128 doneMask0, v128 doneMask1)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        v128 b = or_si128(b0, b1);

                        return Hint.Likely(testz_si128(b, b) == 0);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        v128 doneMask = and_si128(doneMask0, doneMask1);

                        return Hint.Likely(notalltrue_epi128<long>(doneMask));
                    }
                    else throw new IllegalInstructionException();
                }


                if (BurstArchitecture.IsSIMDSupported)
                {
                    PRELOOP_powpd_epu64(a0, ref b0, out v128 y0, out v128 doneMask0, out r0);
                    PRELOOP_powpd_epu64(a1, ref b1, out v128 y1, out v128 doneMask1, out r1);

                    while (ContinueLoop(b0, b1, doneMask0, doneMask1))
                    {
                        LOOP_powpd_epu64(ref a0, ref b0, ref y0, ref doneMask0, ref r0);
                        LOOP_powpd_epu64(ref a1, ref b1, ref y1, ref doneMask1, ref r1);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_powpd_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 1, elements))
                    {
                        return mm256_set1_epi64x(1);
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 2, elements))
                    {
                        return Avx2.mm256_sllv_epi64(mm256_set1_epi64x(1), b);
                    }

                    if (constexpr.ALL_SAME_EPU64(b, elements))
                    {
                        switch (b.ULong0)
                        {
                            case 0:  { return mm256_set1_epi64x(1); }

                            case 1:  { return a; }
                            case 2:  { return mm256_square_epi64(a, elements); }
                            case 3:  { return mm256_mullo_epi64(a, mm256_square_epi64(a, elements)); }
                            case 4:  { v256 a2 = mm256_square_epi64(a, elements); return mm256_square_epi64(a2, elements); }
                            case 5:  { v256 a2 = mm256_square_epi64(a, elements); return mm256_mullo_epi64(a, mm256_square_epi64(a2, elements)); }
                            case 6:  { v256 a2 = mm256_square_epi64(a, elements); return mm256_mullo_epi64(a2, mm256_square_epi64(a2, elements)); }
                            case 7:  { v256 a2 = mm256_square_epi64(a, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_square_epi64(a2, elements)); }
                            case 8:  { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_square_epi64(a4, elements); }
                            case 9:  { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(a, mm256_square_epi64(a4, elements)); }
                            case 10: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(a2, mm256_square_epi64(a4, elements)); }
                            case 11: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_square_epi64(a4, elements)); }
                            case 12: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(a4, mm256_square_epi64(a4, elements)); }
                            case 13: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_square_epi64(a4, elements)); }
                            case 14: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_square_epi64(a4, elements)); }
                            case 15: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_square_epi64(a4, elements)); }
                            case 16: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_square_epi64(a8, elements); }
                            case 17: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(a, mm256_square_epi64(a8, elements)); }
                            case 18: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(a2, mm256_square_epi64(a8, elements)); }
                            case 19: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_square_epi64(a8, elements)); }
                            case 20: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(a4, mm256_square_epi64(a8, elements)); }
                            case 21: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_square_epi64(a8, elements)); }
                            case 22: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_square_epi64(a8, elements)); }
                            case 23: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_square_epi64(a8, elements)); }
                            case 24: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(a8, mm256_square_epi64(a8, elements)); }
                            case 25: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), mm256_square_epi64(a8, elements)); }
                            case 26: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), mm256_square_epi64(a8, elements)); }
                            case 27: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), mm256_square_epi64(a8, elements)); }
                            case 28: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), mm256_square_epi64(a8, elements)); }
                            case 29: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), mm256_square_epi64(a8, elements)); }
                            case 30: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), mm256_square_epi64(a8, elements)); }
                            case 31: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a4, a8, elements)), mm256_square_epi64(a8, elements)); }
                            case 32: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_square_epi64(a16, elements); }
                            case 33: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(a, mm256_square_epi64(a16, elements)); }
                            case 34: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(a2, mm256_square_epi64(a16, elements)); }
                            case 35: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_square_epi64(a16, elements)); }
                            case 36: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(a4, mm256_square_epi64(a16, elements)); }
                            case 37: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_square_epi64(a16, elements)); }
                            case 38: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_square_epi64(a16, elements)); }
                            case 39: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_square_epi64(a16, elements)); }
                            case 40: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(a8, mm256_square_epi64(a16, elements)); }
                            case 41: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), mm256_square_epi64(a16, elements)); }
                            case 42: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), mm256_square_epi64(a16, elements)); }
                            case 43: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), mm256_square_epi64(a16, elements)); }
                            case 44: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), mm256_square_epi64(a16, elements)); }
                            case 45: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), mm256_square_epi64(a16, elements)); }
                            case 46: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), mm256_square_epi64(a16, elements)); }
                            case 47: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a8, elements), mm256_square_epi64(a16, elements)); }
                            case 48: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(a16, mm256_square_epi64(a16, elements)); }
                            case 49: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a16, elements), mm256_square_epi64(a16, elements)); }
                            case 50: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a16, elements), mm256_square_epi64(a16, elements)); }
                            case 51: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 52: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a16, elements), mm256_square_epi64(a16, elements)); }
                            case 53: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 54: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 55: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 56: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a8, a16, elements), mm256_square_epi64(a16, elements)); }
                            case 57: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 58: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 59: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 60: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 61: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 62: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 63: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a8, elements), a16, elements), mm256_square_epi64(a16, elements)); }
                            case 64: { v256 a2 = mm256_square_epi64(a, elements); v256 a4 = mm256_square_epi64(a2, elements); v256 a8 = mm256_square_epi64(a4, elements); v256 a16 = mm256_square_epi64(a8, elements); v256 a32 = mm256_square_epi64(a16, elements); return mm256_square_epi64(a32, elements); }

                            default: break;
                        }
                    }

                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = mm256_set1_epi64x(1);

                    v256 y = mm256_blendv_si256(ONE, a, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b, ONE)));
                    b = Avx2.mm256_srli_epi64(b, 1);
                    v256 result = Avx2.mm256_and_si256(y, Avx2.mm256_cmpeq_epi64(ZERO, b));

                    b = mm256_zeromissing_epi64(b, elements);

                    while (Hint.Likely(Avx.mm256_testz_si256(b, b) == 0))
                    {
                        a = mm256_square_epi64(a, elements);
                        v256 y_times_x = mm256_mullo_epi64(y, a, elements);
                        y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b, ONE)));
                        b = Avx2.mm256_srli_epi64(b, 1);
                        result = mm256_blendv_si256(result, y, Avx2.mm256_cmpeq_epi64(ZERO, b));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { float x2 = math.square(x); return math.square(x2); }
                case 5:   { float x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { float x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { float x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4); }
                case 9:   { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { float x2 = math.square(x); float x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { float x2 = math.square(x); float x4 = math.square(x2); float x8 = math.square(x4); float x16 = math.square(x8); float x32 = math.square(x16); float x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                float c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                double xDbl = x;
                double c = (y & 1) == 0 ? 1d : xDbl;
                y >>= 1;

                while (y != 0)
                {
                    xDbl *= xDbl;
                    if ((y & 1) != 0)
                    {
                        c *= xDbl;
                    }

                    y >>= 1;
                }

                return (float)c;
            }
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float pow(float x, int y, Promise yRange = Promise.Nothing)
        {
            if (y < 0)
            {
                x = math.rcp(x);
                y = -y;
            }

            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { float2 x2 = math.square(x); return math.square(x2); }
                case 5:   { float2 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { float2 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { float2 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4); }
                case 9:   { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { float2 x2 = math.square(x); float2 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { float2 x2 = math.square(x); float2 x4 = math.square(x2); float2 x8 = math.square(x4); float2 x16 = math.square(x8); float2 x32 = math.square(x16); float2 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                float2 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                double2 xDbl = x;
                double2 c = (y & 1) == 0 ? 1d : xDbl;
                y >>= 1;

                while (y != 0)
                {
                    xDbl *= xDbl;
                    if ((y & 1) != 0)
                    {
                        c *= xDbl;
                    }

                    y >>= 1;
                }

                return (float2)c;
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 pow(float2 x, int y, Promise yRange = Promise.Nothing)
        {
            if (y < 0)
            {
                x = math.rcp(x);
                y = -y;
            }

            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { float3 x2 = math.square(x); return math.square(x2); }
                case 5:   { float3 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { float3 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { float3 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4); }
                case 9:   { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { float3 x2 = math.square(x); float3 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { float3 x2 = math.square(x); float3 x4 = math.square(x2); float3 x8 = math.square(x4); float3 x16 = math.square(x8); float3 x32 = math.square(x16); float3 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                float3 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                double3 xDbl = x;
                double3 c = (y & 1) == 0 ? 1d : xDbl;
                y >>= 1;

                while (y != 0)
                {
                    xDbl *= xDbl;
                    if ((y & 1) != 0)
                    {
                        c *= xDbl;
                    }

                    y >>= 1;
                }

                return (float3)c;
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 pow(float3 x, int y, Promise yRange = Promise.Nothing)
        {
            if (y < 0)
            {
                x = math.rcp(x);
                y = -y;
            }

            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { float4 x2 = math.square(x); return math.square(x2); }
                case 5:   { float4 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { float4 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { float4 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4); }
                case 9:   { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { float4 x2 = math.square(x); float4 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { float4 x2 = math.square(x); float4 x4 = math.square(x2); float4 x8 = math.square(x4); float4 x16 = math.square(x8); float4 x32 = math.square(x16); float4 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                float4 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                double4 xDbl = x;
                double4 c = (y & 1) == 0 ? 1d : xDbl;
                y >>= 1;

                while (y != 0)
                {
                    xDbl *= xDbl;
                    if ((y & 1) != 0)
                    {
                        c *= xDbl;
                    }

                    y >>= 1;
                }

                return (float4)c;
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 pow(float4 x, int y, Promise yRange = Promise.Nothing)
        {
            if (y < 0)
            {
                x = math.rcp(x);
                y = -y;
            }

            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return square(x); }
                case 3:   { return square(x) * x; }
                case 4:   { float8 x2 = square(x); return square(x2); }
                case 5:   { float8 x2 = square(x); return square(x2) * x; }
                case 6:   { float8 x2 = square(x); return square(x2) * x2; }
                case 7:   { float8 x2 = square(x); return square(x2) * (x * x2); }
                case 8:   { float8 x2 = square(x); float8 x4 = square(x2); return square(x4); }
                case 9:   { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * x; }
                case 10:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * x2; }
                case 11:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * (x * x2); }
                case 12:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * x4; }
                case 13:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * (x * x4); }
                case 14:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * (x2 * x4); }
                case 15:  { float8 x2 = square(x); float8 x4 = square(x2); return square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); return square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); return square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); return square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { float8 x2 = square(x); float8 x4 = square(x2); float8 x8 = square(x4); float8 x16 = square(x8); float8 x32 = square(x16); float8 x64 = square(x32); return square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                float8 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                double4 xDblLO = x.v4_0;
                double4 xDblHI = x.v4_4;
                double4 cLO = (y & 1) == 0 ? 1d : xDblLO;
                double4 cHI = (y & 1) == 0 ? 1d : xDblHI;
                y >>= 1;

                while (y != 0)
                {
                    xDblLO *= xDblLO;
                    xDblHI *= xDblHI;
                    if ((y & 1) != 0)
                    {
                        cLO *= xDblLO;
                        cHI *= xDblHI;
                    }

                    y >>= 1;
                }

                return new float8((float4)cLO, (float4)cHI);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 pow(float8 x, int y, Promise yRange = Promise.Nothing)
        {
            if (y < 0)
            {
                x = rcp(x);
                y = -y;
            }

            return pow(x, (uint)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, byte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, sbyte y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, ushort y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (uint)y, yRange);
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, short y, Promise yRange = Promise.Nothing)
        {
            return pow(x, (int)y, yRange);
        }


        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { double x2 = math.square(x); return math.square(x2); }
                case 5:   { double x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { double x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { double x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4); }
                case 9:   { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { double x2 = math.square(x); double x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { double x2 = math.square(x); double x4 = math.square(x2); double x8 = math.square(x4); double x16 = math.square(x8); double x32 = math.square(x16); double x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                double c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising <paramref name="x"/> to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double pow(double x, int y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            if (LOW_PRECISION)
            {
                if (y < 0)
                {
                    x = math.rcp(x);
                    y = -y;
                }

                return pow(x, (uint)y, yRange);
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { double2 x2 = math.square(x); return math.square(x2); }
                case 5:   { double2 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { double2 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { double2 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4); }
                case 9:   { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { double2 x2 = math.square(x); double2 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { double2 x2 = math.square(x); double2 x4 = math.square(x2); double2 x8 = math.square(x4); double2 x16 = math.square(x8); double2 x32 = math.square(x16); double2 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                double2 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 pow(double2 x, int y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            if (LOW_PRECISION)
            {
                if (y < 0)
                {
                    x = math.rcp(x);
                    y = -y;
                }

                return pow(x, (uint)y, yRange);
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { double3 x2 = math.square(x); return math.square(x2); }
                case 5:   { double3 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { double3 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { double3 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4); }
                case 9:   { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { double3 x2 = math.square(x); double3 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { double3 x2 = math.square(x); double3 x4 = math.square(x2); double3 x8 = math.square(x4); double3 x16 = math.square(x8); double3 x32 = math.square(x16); double3 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                double3 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 pow(double3 x, int y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            if (LOW_PRECISION)
            {
                if (y < 0)
                {
                    x = math.rcp(x);
                    y = -y;
                }

                return pow(x, (uint)y, yRange);
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, uint y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            switch (y)
            {
                case 0:   { return 1f; }
                case 1:   { return x; }
                case 2:   { return math.square(x); }
                case 3:   { return math.square(x) * x; }
                case 4:   { double4 x2 = math.square(x); return math.square(x2); }
                case 5:   { double4 x2 = math.square(x); return math.square(x2) * x; }
                case 6:   { double4 x2 = math.square(x); return math.square(x2) * x2; }
                case 7:   { double4 x2 = math.square(x); return math.square(x2) * (x * x2); }
                case 8:   { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4); }
                case 9:   { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * x; }
                case 10:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * x2; }
                case 11:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * (x * x2); }
                case 12:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * x4; }
                case 13:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * (x * x4); }
                case 14:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * (x2 * x4); }
                case 15:  { double4 x2 = math.square(x); double4 x4 = math.square(x2); return math.square(x4) * ((x * x2) * x4); }
                case 16:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8); }                                                                                                          break;
                case 17:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * x; }                                                                                                      break;
                case 18:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * x2; }                                                                                                     break;
                case 19:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x * x2); }                                                                                               break;
                case 20:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * x4; }                                                                                                     break;
                case 21:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x * x4); }                                                                                               break;
                case 22:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x2 * x4); }                                                                                              break;
                case 23:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x4); }                                                                                        break;
                case 24:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * x8; }                                                                                                     break;
                case 25:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x * x8); }                                                                                               break;
                case 26:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x2 * x8); }                                                                                              break;
                case 27:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * x8); }                                                                                        break;
                case 28:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * (x4 * x8); }                                                                                              break;
                case 29:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * ((x * x4) * x8); }                                                                                        break;
                case 30:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * ((x2 * x4) * x8); }                                                                                       break;
                case 31:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); return math.square(x8) * ((x * x2) * (x4 * x8)); }                                                                                 break;
                case 32:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16); }                                                                            break;
                case 33:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * x; }                                                                        break;
                case 34:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * x2; }                                                                       break;
                case 35:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x * x2); }                                                                 break;
                case 36:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * x4; }                                                                       break;
                case 37:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x * x4); }                                                                 break;
                case 38:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x2 * x4); }                                                                break;
                case 39:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x4); }                                                          break;
                case 40:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * x8; }                                                                       break;
                case 41:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x * x8); }                                                                 break;
                case 42:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x2 * x8); }                                                                break;
                case 43:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x8); }                                                          break;
                case 44:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x4 * x8); }                                                                break;
                case 45:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x8); }                                                          break;
                case 46:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x8); }                                                         break;
                case 47:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x8); }                                                   break;
                case 48:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * x16; }                                                                      break;
                case 49:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x * x16); }                                                                break;
                case 50:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x2 * x16); }                                                               break;
                case 51:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x2) * x16); }                                                         break;
                case 52:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x4 * x16); }                                                               break;
                case 53:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x4) * x16); }                                                         break;
                case 54:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x2 * x4) * x16); }                                                        break;
                case 55:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x4) * x16); }                                                  break;
                case 56:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (x8 * x16); }                                                               break;
                case 57:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x * x8) * x16); }                                                         break;
                case 58:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x2 * x8) * x16); }                                                        break;
                case 59:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (((x * x2) * x8) * x16); }                                                  break;
                case 60:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((x4 * x8) * x16); }                                                        break;
                case 61:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (((x * x4) * x8) * x16); }                                                  break;
                case 62:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * (((x2 * x4) * x8) * x16); }                                                 break;
                case 63:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); return math.square(x16) * ((((x * x2) * x4) * x8) * x16); }                                           break;
                case 64:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32); }                                              break;
                case 65:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x; }                                          break;
                case 66:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x2; }                                         break;
                case 67:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x * x2); }                                   break;
                case 68:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x4; }                                         break;
                case 69:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x * x4); }                                   break;
                case 70:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x2 * x4); }                                  break;
                case 71:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x4); }                            break;
                case 72:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x8; }                                         break;
                case 73:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x * x8); }                                   break;
                case 74:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x2 * x8); }                                  break;
                case 75:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x8); }                            break;
                case 76:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x4 * x8); }                                  break;
                case 77:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x8); }                            break;
                case 78:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x8); }                           break;
                case 79:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x8); }                     break;
                case 80:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x16; }                                        break;
                case 81:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x * x16); }                                  break;
                case 82:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x2 * x16); }                                 break;
                case 83:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x2) * x16); }                           break;
                case 84:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x4 * x16); }                                 break;
                case 85:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x4) * x16); }                           break;
                case 86:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x2 * x4) * x16); }                          break;
                case 87:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x4) * x16); }                    break;
                case 88:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x8 * x16); }                                 break;
                case 89:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x * x8) * x16); }                           break;
                case 90:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x2 * x8) * x16); }                          break;
                case 91:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (((x * x2) * x8) * x16); }                    break;
                case 92:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((x4 * x8) * x16); }                          break;
                case 93:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (((x * x4) * x8) * x16); }                    break;
                case 94:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (((x2 * x4) * x8) * x16); }                   break;
                case 95:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * ((((x * x2) * x4) * x8) * x16); }             break;
                case 96:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * x32; }                                        break;
                case 97:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * x); }                                  break;
                case 98:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * x2); }                                 break;
                case 99:  if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x2)); }                           break;
                case 100: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * x4); }                                 break;
                case 101: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x4)); }                           break;
                case 102: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x4)); }                          break;
                case 103: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x4)); }                    break;
                case 104: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * x8); }                                 break;
                case 105: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x8)); }                           break;
                case 106: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x8)); }                          break;
                case 107: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x8)); }                    break;
                case 108: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x8)); }                          break;
                case 109: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x8)); }                    break;
                case 110: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x8)); }                   break;
                case 111: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x8)); }             break;
                case 112: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * x16); }                                break;
                case 113: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x * x16)); }                          break;
                case 114: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x2 * x16)); }                         break;
                case 115: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x2) * x16)); }                   break;
                case 116: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x4 * x16)); }                         break;
                case 117: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x4) * x16)); }                   break;
                case 118: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x4) * x16)); }                  break;
                case 119: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x4) * x16)); }            break;
                case 120: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (x8 * x16)); }                         break;
                case 121: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x * x8) * x16)); }                   break;
                case 122: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x2 * x8) * x16)); }                  break;
                case 123: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x2) * x8) * x16)); }            break;
                case 124: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((x4 * x8) * x16)); }                  break;
                case 125: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x * x4) * x8) * x16)); }            break;
                case 126: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }           break;
                case 127: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); return math.square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }     break;
                case 128: if (LOW_PRECISION) { double4 x2 = math.square(x); double4 x4 = math.square(x2); double4 x8 = math.square(x4); double4 x16 = math.square(x8); double4 x32 = math.square(x16); double4 x64 = math.square(x32); return math.square(x64); }                break;
            }


            if (LOW_PRECISION
             || constexpr.IS_TRUE(y < 16))
            {
                double4 c = (y & 1) == 0 ? 1f : x;
                y >>= 1;

                while (y != 0)
                {
                    x *= x;
                    if ((y & 1) != 0)
                    {
                        c *= x;
                    }

                    y >>= 1;
                }

                return c;
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }

        /// <summary>       Returns the result of raising each <paramref name="x"/> component to the power <paramref name="y"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="yRange"/>' with its <see cref="Promise.Unsafe0"/> flag set may return imprecise results if <paramref name="y"/> is outside the interval [-16, 16].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 pow(double4 x, int y, Promise yRange = Promise.Nothing)
        {
            bool LOW_PRECISION = COMPILATION_OPTIONS.FLOAT_PRECISION == FloatPrecision.Low
                              || yRange.Promises(Promise.Unsafe0);

            if (LOW_PRECISION)
            {
                if (y < 0)
                {
                    x = math.rcp(x);
                    y = -y;
                }

                return pow(x, (uint)y, yRange);
            }
            else
            {
                return math.pow(x, (double)y);
            }
        }
    }
}