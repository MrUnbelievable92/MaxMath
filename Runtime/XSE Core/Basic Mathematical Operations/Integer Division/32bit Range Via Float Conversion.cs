using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epu32(v128 a, v128 b, byte elements = 4)
        {
VectorAssert.AreNotEqual<uint4, uint>(RegisterConversion.ToUInt4(b), 0, elements);

            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epu32(a, b, elements);
                }

                return impl_div_epu32(a, b, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epu32(v256 a, v256 b, uint maxValuePromise = uint.MaxValue)
        {
VectorAssert.AreNotEqual<uint8, uint>(b, 0, 8);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epu32(a, b);
                }

                return mm256_impl_div_epu32(a, b, maxValuePromise);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 div_epi32(v128 a, v128 b, byte elements = 4)
        {
VectorAssert.AreNotEqual<int4, int>(RegisterConversion.ToInt4(b), 0, elements);
            
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constdiv_epi32(a, b, elements);
                }

                return impl_div_epi32(a, b, elements);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_div_epi32(v256 a, v256 b)
        {
VectorAssert.AreNotEqual<int8, int>(b, 0, 8);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constdiv_epi32(a, b);
                }

                return mm256_impl_div_epi32(a, b);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constrem_epu32(a, b, elements);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue)
                 && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return rem_epi32(a, b);
                }


                v128 result = sub_epi32(a, mullo_epi32(div_epu32(a, b), b, elements));
                constexpr.ASSUME_LT_EPU32(result, b, elements);
                return result;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epu32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epu32(a, b);
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue)
                 && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue))
                {
                    return mm256_rem_epi32(a, b);
                }


                v256 result = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epu32(a, b), b));
                constexpr.ASSUME_LT_EPU32(result, b);
                return result;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 rem_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return constrem_epi32(a, b, elements);
                }


                return sub_epi32(a, mullo_epi32(div_epi32(a, b), b, elements));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_rem_epi32(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(b))
                {
                    return mm256_constrem_epi32(a, b);
                }


                return Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(mm256_div_epi32(a, b), b));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epu32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 quotient = div_epu32(a, b, elements);
                rem = sub_epi32(a, mullo_epi32(quotient, b, elements));
                constexpr.ASSUME_LT_EPU32(rem, b, elements);

                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epu32(v256 a, v256 b, out v256 rem)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = mm256_div_epu32(a, b);
                rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));
                constexpr.ASSUME_LT_EPU32(rem, b);

                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 divrem_epi32(v128 a, v128 b, out v128 rem, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 quotient = div_epi32(a, b, elements);
                rem = sub_epi32(a, mullo_epi32(quotient, b, elements));

                return quotient;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_divrem_epi32(v256 a, v256 b, out v256 rem)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 quotient = mm256_div_epi32(a, b);
                rem = Avx2.mm256_sub_epi32(a, Avx2.mm256_mullo_epi32(quotient, b));

                return quotient;
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epu32(v128 a, v128 b, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements)
                 && constexpr.ALL_LE_EPU32(b, ushort.MaxValue, elements))
                {
                    return DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }
                if (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue, elements)
                 && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue, elements))
                {
                    return impl_div_epi32(a, b, elements);
                }

                if (elements >= 3)
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        v256 a64 = Avx2.mm256_cvtepu32_epi64(a);
                        v256 b64 = Avx2.mm256_cvtepu32_epi64(b);

                        v256 r64 = mm256_cvttpd_epu64(Avx.mm256_div_pd(mm256_usfcvtepu64_pd(a64), mm256_usfcvtepu64_pd(b64)), elements);

                        return mm256_cvtepi64_epi32(r64);
                    }
                    else
                    {
                        v128 aLo = cvt2x2epu32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epu32_pd(b, out v128 bHi);

                        return cvtt2x2pd_epu32(div_pd(aLo, bLo), div_pd(aHi, bHi));
                    }
                }
                else
                {
                    return cvtepi64_epi32(cvttpd_epu64(div_pd(cvtepu32_pd(a), cvtepu32_pd(b))));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epu32(v256 a, v256 b, uint maxValuePromise = uint.MaxValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_TRUE(maxValuePromise <= ushort.MaxValue)
                 || (constexpr.ALL_LE_EPU32(a, ushort.MaxValue) && constexpr.ALL_LE_EPU32(b, ushort.MaxValue)))
                {
                    return DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                }
                if (constexpr.IS_TRUE(maxValuePromise <= (uint)int.MaxValue)
                 || (constexpr.ALL_LE_EPU32(a, (uint)int.MaxValue) && constexpr.ALL_LE_EPU32(b, (uint)int.MaxValue)))
                {
                    return mm256_impl_div_epi32(a, b);
                }

                v256 a64Lo = mm256_cvt2x2epu32_pd(a, out v256 a64Hi);
                v256 b64Lo = mm256_cvt2x2epu32_pd(b, out v256 b64Hi);

                return mm256_cvtt2x2pd_epu32(Avx.mm256_div_pd(a64Lo, b64Lo), Avx.mm256_div_pd(a64Hi, b64Hi));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 impl_div_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue, elements)
                 && constexpr.ALL_LE_EPI32(a, ushort.MaxValue, elements)
                 && constexpr.ALL_GE_EPI32(b, -ushort.MaxValue, elements)
                 && constexpr.ALL_LE_EPI32(b, ushort.MaxValue, elements))
                {
                    return DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(cvtepi32_ps(a), cvtepi32_ps(b));
                }

                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(Avx.mm256_cvtepi32_pd(a), Avx.mm256_cvtepi32_pd(b)));
                }
                else
                {
                    if (elements >= 3)
                    {
                        v128 aLo = cvt2x2epi32_pd(a, out v128 aHi);
                        v128 bLo = cvt2x2epi32_pd(b, out v128 bHi);

                        return cvtt2x2pd_epi32(div_pd(aLo, bLo), div_pd(aHi, bHi));
                    }
                    else
                    {
                        return cvttpd_epi32(div_pd(cvtepi32_pd(a), cvtepi32_pd(b)));
                    }
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_impl_div_epi32(v256 a, v256 b, uint maxValuePromise = uint.MaxValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GE_EPI32(a, -ushort.MinValue)
                 && constexpr.ALL_LE_EPI32(a, ushort.MaxValue)
                 && constexpr.ALL_GE_EPI32(b, -ushort.MinValue)
                 && constexpr.ALL_LE_EPI32(b, ushort.MaxValue))
                {
                    return DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(Avx.mm256_cvtepi32_ps(a), Avx.mm256_cvtepi32_ps(b));
                }

                v256 a64Lo = mm256_cvt2x2epi32_pd(a, out v256 a64Hi);
                v256 b64Lo = mm256_cvt2x2epi32_pd(b, out v256 b64Hi);
                
                return Avx.mm256_set_m128i(Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(a64Hi, b64Hi)), Avx.mm256_cvttpd_epi32(Avx.mm256_div_pd(a64Lo, b64Lo)));
            }
            else throw new IllegalInstructionException();
        }
    }
}
