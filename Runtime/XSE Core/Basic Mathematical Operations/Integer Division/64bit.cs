using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.LUT.CVT_INT_FP;

namespace MaxMath.Intrinsics
{
    // David Monniaux, Alice Pain. Formally verified 32- and 64-bit integer division using double-precision floating-point arithmetic. 2022 IEEE 29th Symposium on Computer Arithmetic (ARITH), Sep 2022, Lyon, France. pp.128-132, ￿10.1109/ARITH54963.2022.00032￿. ￿hal-03722203￿
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu64(v128 a, v128 b, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epu64(aIsDbl ? cvttpd_epu64(a) : a, bIsDbl ? cvttpd_epu64(b) : b);
                }

                return impl_divrem_epu64(a, b, out _, nonDivBy1, useFPU, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu64(v256 a, v256 b, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epu64(aIsDbl ? mm256_cvttpd_epu64(a, elements) : a, bIsDbl ? mm256_cvttpd_epu64(b, elements) : b, elements);
                }

                return mm256_impl_divrem_epu64(a, b, out _, nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu64(v128 a, v128 b, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constrem_epu64(aIsDbl ? cvttpd_epu64(a) : a, bIsDbl ? cvttpd_epu64(b) : b);
                }

                v128 result;
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT)) && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT))))
                {
                    v128 quotient = cvttpd_epu64(div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));

                    result = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }
                else
                {
                    if (bIsDbl || useFPU)
                    {
                        impl_divrem_epu64(a, b, out result, nonDivBy1, useFPU, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);
                    }
                    else
                    {
                        if (aIsDbl)
                        {
                            a = cvttpd_epu64(a);
                        }
                        if (bIsDbl)
                        {
                            b = cvttpd_epu64(b);
                        }

                        result = new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
                    }
                }

                if (!bIsDbl)
                {
                    constexpr.ASSUME_LT_EPU64(result, b);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu64(v256 a, v256 b, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epu64(aIsDbl ? mm256_cvttpd_epu64(a, elements) : a, bIsDbl ? mm256_cvttpd_epu64(b, elements) : b, elements);
                }

                v256 result;

                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements)) && ((bUSFcvt || bLEu32max) || constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements))))
                {
                    v256 quotient = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)), elements: elements);

                    result = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }
                else
                {
                    mm256_impl_divrem_epu64(a, b, out result, nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);
                }

                if (!bIsDbl)
                {
                    constexpr.ASSUME_LT_EPU64(result, b, elements);
                }

                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu64(v128 a, v128 b, out v128 rem, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<ulong2, ulong>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    rem =  constrem_epu64(aIsDbl ? cvttpd_epu64(a) : a, bIsDbl ? cvttpd_epu64(b) : b);
                    return constdiv_epu64(aIsDbl ? cvttpd_epu64(a) : a, bIsDbl ? cvttpd_epu64(b) : b);
                }

                return impl_divrem_epu64(a, b, out rem, nonDivBy1, useFPU, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu64(v256 a, v256 b, out v256 rem, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<ulong4, ulong>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    rem =  mm256_constrem_epu64(aIsDbl ? mm256_cvttpd_epu64(a, elements) : a, bIsDbl ? mm256_cvttpd_epu64(b, elements) : b, elements);
                    return mm256_constdiv_epu64(aIsDbl ? mm256_cvttpd_epu64(a, elements) : a, bIsDbl ? mm256_cvttpd_epu64(b, elements) : b, elements);
                }

                return mm256_impl_divrem_epu64(a, b, out rem, nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi64(v128 a, v128 b, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epi64(aIsDbl ? cvttpd_epi64(a) : a, bIsDbl ? cvttpd_epi64(b) : b);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))  && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))))
                {
                    return cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                }

                if (!(constexpr.IS_CONST(a) && constexpr.IS_CONST(b))
                  && (bIsDbl || useFPU))
                {
                    v128 unsignedQuotient = div_epu64(aNonNegative ? a : (aIsDbl ? abs_pd(a) : abs_epi64(a)), bNonNegative ? b : (bIsDbl ? abs_pd(b) : abs_epi64(b)), nonDivBy1, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);

                    return SIGNED_FROM_UNSIGNED_DIV_EPI64(out _, a, b, unsignedQuotient, default(v128), dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);
                }
                else
                {
                    if (aIsDbl)
                    {
                        if (bIsDbl)
                        {
                            return new v128((long)a.Double0 / (long)b.Double0, (long)a.Double1 / (long)b.Double1);
                        }
                        else
                        {
                            return new v128((long)a.Double0 / b.SLong0, (long)a.Double1 / b.SLong1);
                        }
                    }
                    else if (bIsDbl)
                    {
                        return new v128(a.SLong0 / (long)b.Double0, a.SLong1 / (long)b.Double1);
                    }
                    else
                    {
                        return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi64(v256 a, v256 b, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epi64(aIsDbl ? mm256_cvttpd_epi64(a, elements) : a, bIsDbl ? mm256_cvttpd_epi64(b, elements) : b, elements);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))) && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))))
                {
                    return mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);
                }

                v256 unsignedQuotient = mm256_div_epu64(aNonNegative ? a : (aIsDbl ? mm256_abs_pd(a, elements) : mm256_abs_epi64(a, elements)), bNonNegative ? b : (bIsDbl ? mm256_abs_pd(b, elements) : mm256_abs_epi64(b, elements)), nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI64(out _, a, b, unsignedQuotient, default(v256), elements: elements, dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi64(v128 a, v128 b, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    return constrem_epi64(aIsDbl ? cvttpd_epi64(a) : a, bIsDbl ? cvttpd_epi64(b) : b);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))) && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))))
                {
                    v128 quotient = cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));

                    return sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }

                if (!(constexpr.IS_CONST(a) && constexpr.IS_CONST(b))
                  && (bIsDbl || useFPU))
                {
                    v128 unsignedRemainder = rem_epu64(aNonNegative ? a : (aIsDbl ? abs_pd(a) : abs_epi64(a)), bNonNegative ? b : (bIsDbl ? abs_pd(b) : abs_epi64(b)), nonDivBy1, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);

                    SIGNED_FROM_UNSIGNED_DIV_EPI64(out v128 signedRemainder, a, b, default(v128), unsignedRemainder, dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);

                    return signedRemainder;
                }
                else
                {
                    if (aIsDbl)
                    {
                        if (bIsDbl)
                        {
                            return new v128((long)a.Double0 % (long)b.Double0, (long)a.Double1 % (long)b.Double1);
                        }
                        else
                        {
                            return new v128((long)a.Double0 % b.SLong0, (long)a.Double1 % b.SLong1);
                        }
                    }
                    else if (bIsDbl)
                    {
                        return new v128(a.SLong0 % (long)b.Double0, a.SLong1 % (long)b.Double1);
                    }
                    else
                    {
                        return new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi64(v256 a, v256 b, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epi64(aIsDbl ? mm256_cvttpd_epi64(a, elements) : a, bIsDbl ? mm256_cvttpd_epi64(b, elements) : b, elements);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))) && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))))
                {
                    v256 quotient = mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);

                    return Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));
                }

                v256 unsignedRemainder = mm256_rem_epu64(aNonNegative ? a : (aIsDbl ? mm256_abs_pd(a, elements) : mm256_abs_epi64(a, elements)), bNonNegative ? b : (bIsDbl ? mm256_abs_pd(b, elements) : mm256_abs_epi64(b, elements)), nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);

                SIGNED_FROM_UNSIGNED_DIV_EPI64(out v256 signedRemainder, a, b, default(v256), unsignedRemainder, elements: elements, dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);

                return signedRemainder;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi64(v128 a, v128 b, out v128 rem, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
VectorAssert.AreNotEqual<long2, long>(b, 0, 2);

                if (constexpr.IS_CONST(b))
                {
                    rem =  constrem_epi64(aIsDbl ? cvttpd_epi64(a) : a, bIsDbl ? cvttpd_epi64(b) : b);
                    return constdiv_epi64(aIsDbl ? cvttpd_epi64(a) : a, bIsDbl ? cvttpd_epi64(b) : b);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT))) && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT)))))
                {
                    v128 quotient = cvttpd_epi64(div_pd(usfcvtepi64_pd(a), usfcvtepi64_pd(b)));
                    rem = sub_epi64(a, mullo_epi64(quotient, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                    return quotient;
                }

                if (!(constexpr.IS_CONST(a) && constexpr.IS_CONST(b))
                  && (bIsDbl || useFPU))
                {
                    v128 unsignedQuotient = divrem_epu64(aNonNegative ? a : (aIsDbl ? abs_pd(a) : abs_epi64(a)), bNonNegative ? b : (bIsDbl ? abs_pd(b) : abs_epi64(b)), out v128 unsigendRemainder, nonDivBy1, true, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl);

                    return SIGNED_FROM_UNSIGNED_DIV_EPI64(out rem, a, b, unsignedQuotient, unsigendRemainder, dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);
                }
                else
                {
                    if (aIsDbl)
                    {
                        if (bIsDbl)
                        {
                            rem = new v128((long)a.Double0 % (long)b.Double0, (long)a.Double1 % (long)b.Double1);
                            return new v128((long)a.Double0 / (long)b.Double0, (long)a.Double1 / (long)b.Double1);
                        }
                        else
                        {
                            rem = new v128((long)a.Double0 % b.SLong0, (long)a.Double1 % b.SLong1);
                            return new v128((long)a.Double0 / b.SLong0, (long)a.Double1 / b.SLong1);
                        }
                    }
                    else if (bIsDbl)
                    {
                        rem = new v128(a.SLong0 % (long)b.Double0, a.SLong1 % (long)b.Double1);
                        return new v128(a.SLong0 / (long)b.Double0, a.SLong1 / (long)b.Double1);
                    }
                    else
                    {
                        rem = new v128(a.SLong0 % b.SLong0, a.SLong1 % b.SLong1);
                        return new v128(a.SLong0 / b.SLong0, a.SLong1 / b.SLong1);
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi64(v256 a, v256 b, out v256 rem, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, bool aNonNegative = false, bool bNonNegative = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
VectorAssert.AreNotEqual<long4, long>(b, 0, elements);

                if (constexpr.IS_CONST(b))
                {
                    rem =  mm256_constrem_epi64(aIsDbl ? mm256_cvttpd_epi64(a, elements) : a, bIsDbl ? mm256_cvttpd_epi64(b, elements) : b, elements);
                    return mm256_constdiv_epi64(aIsDbl ? mm256_cvttpd_epi64(a, elements) : a, bIsDbl ? mm256_cvttpd_epi64(b, elements) : b, elements);
                }
                if ((!aIsDbl && !bIsDbl)
                 && (((aUSFcvt || aLEu32max) || (constexpr.ALL_GE_EPI64(a, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(a, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements))) && ((bUSFcvt || bLEu32max) || (constexpr.ALL_GE_EPI64(b, -ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements) && constexpr.ALL_LE_EPI64(b, ABS_MASK_USF_CVT_EPI64_PD_LIMIT, elements)))))
                {
                    v256 quotient = mm256_cvttpd_epi64(Avx.mm256_div_pd(mm256_usfcvtepi64_pd(a), mm256_usfcvtepi64_pd(b)), elements: elements);
                    rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(quotient, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                    return quotient;
                }

                v256 unsignedQuotient = mm256_divrem_epu64(aNonNegative ? a : (aIsDbl ? mm256_abs_pd(a, elements) : mm256_abs_epi64(a, elements)), bNonNegative ? b : (bIsDbl ? mm256_abs_pd(b, elements) : mm256_abs_epi64(b, elements)), out v256 unsigendRemainder, nonDivBy1, aUSFcvt, bUSFcvt, aLEu32max, bLEu32max, aIsDbl, bIsDbl, elements);

                return SIGNED_FROM_UNSIGNED_DIV_EPI64(out rem, a, b, unsignedQuotient, unsigendRemainder, elements: elements, dividendPositive: aNonNegative, divisorPositive: bNonNegative, aIsDbl : aIsDbl, bIsDbl : bIsDbl);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_divrem_epu64(v128 a, v128 b, out v128 rem, bool nonDivBy1 = false, bool useFPU = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                nonDivBy1 |= bIsDbl ? constexpr.ALL_NEQ_PD(b, 1d) : constexpr.ALL_NEQ_EPU64(b, 1ul);
                aUSFcvt |= aLEu32max | constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT);
                bUSFcvt |= bLEu32max | constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT);

                v128 aInt64 = aIsDbl ? cvttpd_epu64(a) : a;
                v128 bInt64 = bIsDbl ? cvttpd_epu64(b) : b;
if (aIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong2, ulong>(aInt64, 0, 2);
}
if (bIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong2, ulong>(bInt64, 0, 2);
}
                v128 q;
                if (!aIsDbl && !bIsDbl)
                {
                    if ((aUSFcvt || aLEu32max)
                     && (bUSFcvt || bLEu32max))
                    {
                        q = cvttpd_epu64(div_pd(usfcvtepu64_pd(a), usfcvtepu64_pd(b)));
                        rem = sub_epi64(a, mullo_epi64(q, b, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                        return q;
                    }
                }
                if ((!useFPU && !bIsDbl)
                 || (constexpr.IS_CONST(a) && constexpr.IS_CONST(b)))
                {
                    if (aIsDbl)
                    {
                        if (bIsDbl)
                        {
                            q = new v128(aInt64.ULong0 / bInt64.ULong0, aInt64.ULong1 / bInt64.ULong1);
                            rem = new v128(aInt64.ULong0 % bInt64.ULong0, aInt64.ULong1 % bInt64.ULong1);
                        }
                        else
                        {
                            q = new v128(aInt64.ULong0 / b.ULong0, aInt64.ULong1 / b.ULong1);
                            rem = new v128(aInt64.ULong0 % b.ULong0, aInt64.ULong1 % b.ULong1);
                        }
                    }
                    else if (bIsDbl)
                    {
                        q = new v128(a.ULong0 / bInt64.ULong0, a.ULong1 / bInt64.ULong1);
                        rem = new v128(a.ULong0 % bInt64.ULong0, a.ULong1 % bInt64.ULong1);
                    }
                    else
                    {
                        q = new v128(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1);
                        rem = new v128(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1);
                    }

                    return q;
                }

                v128 rcpB = div_pd(set1_pd(1d), bIsDbl ? b : ((bUSFcvt || bLEu32max) ? usfcvtepu64_pd(b) : cvtepu64_pd(b)));
                v128 q1d = mul_pd(aIsDbl ? a : ((aUSFcvt || aLEu32max) ? usfcvtepu64_pd(a) : cvtepu64_pd(a)), rcpB);

                //if (Avx512.IsAvx512Supported)
                //{
                //
                //}
                //else
                //{
                      long bLo = (long)extract_epi64(bInt64, 0);
                      long bHi = (long)extract_epi64(bInt64, 1);
                      long loQ1;
                      long hiQ1;
                      if (Avx2.IsAvx2Supported)
                      {
                          v128 q1 = cvttpd_epu64(q1d);
                          loQ1 = (long)extract_epi64(q1, 0);
                          hiQ1 = (long)extract_epi64(q1, 1);
                      }
                      else if (Arm.Neon.IsNeonSupported)
                      {
                          v128 q1 = cvttpd_epu64(q1d);
                          loQ1 = (long)extract_epi64(q1, 0);
                          hiQ1 = (long)extract_epi64(q1, 1);
                      }
                      else
                      {
                          loQ1 = (long)(ulong)q1d.Double0;
                          hiQ1 = (long)(ulong)q1d.Double1;
                      }

                      long loR1 = (long)extract_epi64(aInt64, 0) - (bLo * loQ1);
                      long hiR1 = (long)extract_epi64(aInt64, 1) - (bHi * hiQ1);
                      v128 loR1d = cvtsi64x_sd(setzero_si128(), loR1);
                      v128 hiR1d = cvtsi64x_sd(setzero_si128(), hiR1);
                      v128 loQ3d = mul_sd(loR1d, rcpB);
                      v128 hiQ3d = mul_sd(hiR1d, bsrli_si128(rcpB, sizeof(double)));

                      v128 aLTb = cmplt_epu64(aInt64, bInt64);

                      long loQ3 = cvtsd_si64x(loQ3d);
                      long hiQ3 = cvtsd_si64x(hiQ3d);

                      long loR3 = loR1 - (bLo * loQ3);
                      long hiR3 = hiR1 - (bHi * hiQ3);
                      long loQ2 = loQ1 + loQ3;
                      long hiQ2 = hiQ1 + hiQ3;
                      long loQ = loQ2 + (loR3 >> 63);
                      long hiQ = hiQ2 + (hiR3 >> 63);
                      loR3 += loR3 < 0 ? bLo : 0;
                      hiR3 += hiR3 < 0 ? bHi : 0;

                      rem = unpacklo_epi64(cvtsi64x_si128(loR3), cvtsi64x_si128(hiR3));
                      rem = blendv_si128(rem, aInt64, aLTb);

                      q = unpacklo_epi64(cvtsi64x_si128(loQ), cvtsi64x_si128(hiQ));
                //}

                constexpr.ASSUME_LT_EPU64(rem, bInt64);

                v128 ONE = set1_epi64x(1);
                v128 qEither0or1 = bIsDbl ? cmpge_pd(b, set1_pd(1ul << 63)) : cmpgt_epi64(setzero_si128(), bInt64);
                v128 specialResult = aInt64;
                v128 blendMSK = qEither0or1;

                if (!nonDivBy1)
                {
                    blendMSK = or_si128(blendMSK, cmpeq_epi64(bInt64, ONE));
                }
                if (!(bUSFcvt
                  || (bIsDbl ? constexpr.ALL_LT_PD(b, 1ul << 63) : constexpr.ALL_LT_EPU64(b, 1ul << 63))))
                {
                    specialResult = blendv_si128(specialResult, andnot_si128(aLTb, ONE), qEither0or1);
                }
                if (!(nonDivBy1 && bUSFcvt))
                {
                    q = blendv_si128(q, specialResult, blendMSK);
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_divrem_epu64(v256 a, v256 b, out v256 rem, bool nonDivBy1 = false, bool aUSFcvt = false, bool bUSFcvt = false, bool aLEu32max = false, bool bLEu32max = false, bool aIsDbl = false, bool bIsDbl = false, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                nonDivBy1 |= bIsDbl ? constexpr.ALL_NEQ_PD(b, 1d, elements) : constexpr.ALL_NEQ_EPU64(b, 1ul, elements);
                aUSFcvt |= aLEu32max | constexpr.ALL_LE_EPU64(a, USF_CVT_EPU64_PD_LIMIT, elements);
                bUSFcvt |= bLEu32max | constexpr.ALL_LE_EPU64(b, USF_CVT_EPU64_PD_LIMIT, elements);

                v256 aInt64 = aIsDbl ? mm256_cvttpd_epu64(a, elements) : a;
                v256 bInt64 = bIsDbl ? mm256_cvttpd_epu64(b, elements) : b;

if (aIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong4, ulong>(aInt64, 0, elements);
}
if (bIsDbl)
{
    // Caller is responsible
    VectorAssert.AreNotEqual<ulong4, ulong>(bInt64, 0, elements);
}
                v256 q;
                if (!aIsDbl && !bIsDbl)
                {
                    if ((aUSFcvt || aLEu32max)
                     && (bUSFcvt || bLEu32max))
                    {
                        q = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a), mm256_usfcvtepu64_pd(b)), elements: elements);
                        rem = Avx2.mm256_sub_epi64(a, mm256_mullo_epi64(q, b, elements, unsigned_A_lessequalU32Max: aLEu32max, unsigned_B_lessequalU32Max: bLEu32max));

                        return q;
                    }
                }
                if (constexpr.IS_CONST(a) && constexpr.IS_CONST(b))
                {
                    if (aIsDbl)
                    {
                        if (bIsDbl)
                        {
                            q = new v256(aInt64.ULong0 / bInt64.ULong0, aInt64.ULong1 / bInt64.ULong1, aInt64.ULong2 / bInt64.ULong2, elements == 3 ? 0 : aInt64.ULong3 / bInt64.ULong3);
                            rem = new v256(aInt64.ULong0 % bInt64.ULong0, aInt64.ULong1 % bInt64.ULong1, aInt64.ULong2 % bInt64.ULong2, elements == 3 ? 0 : aInt64.ULong3 % bInt64.ULong3);
                        }
                        else
                        {
                            q = new v256(aInt64.ULong0 / b.ULong0, aInt64.ULong1 / b.ULong1, aInt64.ULong2 / b.ULong2, elements == 3 ? 0 : aInt64.ULong3 / b.ULong3);
                            rem = new v256(aInt64.ULong0 % b.ULong0, aInt64.ULong1 % b.ULong1, aInt64.ULong2 % b.ULong2, elements == 3 ? 0 : aInt64.ULong3 % b.ULong3);
                        }
                    }
                    else if (bIsDbl)
                    {
                        q = new v256(a.ULong0 / bInt64.ULong0, a.ULong1 / bInt64.ULong1, a.ULong2 / bInt64.ULong2, elements == 3 ? 0 : a.ULong3 / bInt64.ULong3);
                        rem = new v256(a.ULong0 % bInt64.ULong0, a.ULong1 % bInt64.ULong1, a.ULong2 % bInt64.ULong2, elements == 3 ? 0 : a.ULong3 % bInt64.ULong3);
                    }
                    else
                    {
                        q = new v256(a.ULong0 / b.ULong0, a.ULong1 / b.ULong1, a.ULong2 / b.ULong2, elements == 3 ? 0 : a.ULong3 / b.ULong3);
                        rem = new v256(a.ULong0 % b.ULong0, a.ULong1 % b.ULong1, a.ULong2 % b.ULong2, elements == 3 ? 0 : a.ULong3 % b.ULong3);
                    }

                    return q;
                }

                v256 rcpB = Avx.mm256_div_pd(mm256_set1_pd(1d), bIsDbl ? b : ((bUSFcvt || bLEu32max) ? mm256_usfcvtepu64_pd(b) : mm256_cvtepu64_pd(b, elements)));
                v256 q1d = Avx.mm256_mul_pd(aIsDbl ? a : ((aUSFcvt || aLEu32max) ? mm256_usfcvtepu64_pd(a) : mm256_cvtepu64_pd(a, elements)), rcpB);

                v256 q1;
                //if (Avx512.IsAvx512Supported)
                //{
                //    q1 = mm256_cvtpd_epu64(q1d, elements, promise: true, evenOnTie: true);
                //}
                //else
                //{
                      q1 = mm256_cvtpd_epu64(q1d, elements: elements, evenOnTie: false);
                //}
                v256 r1 = Avx2.mm256_sub_epi64(aInt64, mm256_mullo_epi64(bInt64, q1, elements, unsigned_A_lessequalU32Max: bLEu32max));
                v256 r1d = mm256_cvtepi64_pd(r1, elements);
                v256 q3d = Avx.mm256_mul_pd(r1d, rcpB);

                v256 q3;
                //if (Avx512.IsAvx512Supported)
                //{
                //    q3 = mm256_cvtpd_epi64(q3d, elements, promise: true, evenOnTie: true);
                //}
                //else
                //{
                      q3 = mm256_cvtpd_epi64(q3d, elements: elements, evenOnTie: false);
                //}

                v256 aLTb = mm256_cmplt_epu64(aInt64, bInt64, elements);

                rem = Avx2.mm256_sub_epi64(r1, mm256_mullo_epi64(bInt64, q3, elements, unsigned_A_lessequalU32Max: bLEu32max));
                v256 q2 = Avx2.mm256_add_epi64(q1, q3);
                v256 remSign = Avx2.mm256_srli_epi64(rem, 63);
                q = Avx2.mm256_sub_epi64(q2, remSign);
                rem = Avx2.mm256_add_epi64(rem, Avx2.mm256_and_si256(bInt64, mm256_neg_epi64(remSign)));
                rem = mm256_blendv_si256(rem, aInt64, aLTb);

                constexpr.ASSUME_LT_EPU64(rem, bInt64, elements);

                v256 ONE = mm256_set1_epi64x(1);
                v256 qEither0or1 = bIsDbl ? mm256_cmpge_pd(b, mm256_set1_pd(1ul << 63)) : Avx2.mm256_cmpgt_epi64(Avx.mm256_setzero_si256(), bInt64);
                v256 specialResult = aInt64;
                v256 blendMSK = qEither0or1;

                if (!nonDivBy1)
                {
                    blendMSK = Avx2.mm256_or_si256(blendMSK, Avx2.mm256_cmpeq_epi64(bInt64, ONE));
                }
                if (!(bUSFcvt
                  || (bIsDbl ? constexpr.ALL_LT_PD(b, 1ul << 63, elements) : constexpr.ALL_LT_EPU64(b, 1ul << 63, elements))))
                {
                    specialResult = mm256_blendv_si256(aInt64, Avx2.mm256_andnot_si256(aLTb, ONE), qEither0or1);
                }
                if (!(nonDivBy1 && bUSFcvt))
                {
                    q = mm256_blendv_si256(q, specialResult, blendMSK);
                }

                return q;
            }
            else throw new IllegalInstructionException();
        }
    }
}
