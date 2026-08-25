using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.CompilerServices;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 cbrt_epu8_takingAndReturning_epu16(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 6 * 6 * 6, elements))
                    {
                        return cbrt_absepi8_takingAndReturning_epu16(a);
                    }

                    v128 cb1 = set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi16(5 * 5 * 5 - 1);
                    v128 cb6 = set1_epi16(6 * 6 * 6 - 1);

                    v128 result = sub_epi16(        neg_epi16(cmpgt_epi16(a, cb1)),cmpgt_epi16(a, cb2));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb3), cmpgt_epi16(a, cb4)));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb5), cmpgt_epi16(a, cb6)));

                    constexpr.ASSUME_LE_EPU16(result, 6);

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0 * result.UShort0 * result.UShort0 <= a.UShort0);
                    constexpr.ASSUME(result.UShort1 * result.UShort1 * result.UShort1 <= a.UShort1);
                    constexpr.ASSUME(result.UShort2 * result.UShort2 * result.UShort2 <= a.UShort2);
                    constexpr.ASSUME(result.UShort3 * result.UShort3 * result.UShort3 <= a.UShort3);
                    constexpr.ASSUME(result.UShort4 * result.UShort4 * result.UShort4 <= a.UShort4);
                    constexpr.ASSUME(result.UShort5 * result.UShort5 * result.UShort5 <= a.UShort5);
                    constexpr.ASSUME(result.UShort6 * result.UShort6 * result.UShort6 <= a.UShort6);
                    constexpr.ASSUME(result.UShort7 * result.UShort7 * result.UShort7 <= a.UShort7);

                    constexpr.ASSUME((result.UShort0 + 1) * (result.UShort0 + 1) * (result.UShort0 + 1) > a.UShort0);
                    constexpr.ASSUME((result.UShort1 + 1) * (result.UShort1 + 1) * (result.UShort1 + 1) > a.UShort1);
                    constexpr.ASSUME((result.UShort2 + 1) * (result.UShort2 + 1) * (result.UShort2 + 1) > a.UShort2);
                    constexpr.ASSUME((result.UShort3 + 1) * (result.UShort3 + 1) * (result.UShort3 + 1) > a.UShort3);
                    constexpr.ASSUME((result.UShort4 + 1) * (result.UShort4 + 1) * (result.UShort4 + 1) > a.UShort4);
                    constexpr.ASSUME((result.UShort5 + 1) * (result.UShort5 + 1) * (result.UShort5 + 1) > a.UShort5);
                    constexpr.ASSUME((result.UShort6 + 1) * (result.UShort6 + 1) * (result.UShort6 + 1) > a.UShort6);
                    constexpr.ASSUME((result.UShort7 + 1) * (result.UShort7 + 1) * (result.UShort7 + 1) > a.UShort7);

                    constexpr.ASSUME((a.UShort0 <= 1) == (result.UShort0 == a.UShort0));
                    constexpr.ASSUME((a.UShort1 <= 1) == (result.UShort1 == a.UShort1));
                    constexpr.ASSUME((a.UShort2 <= 1) == (result.UShort2 == a.UShort2));
                    constexpr.ASSUME((a.UShort3 <= 1) == (result.UShort3 == a.UShort3));
                    constexpr.ASSUME((a.UShort4 <= 1) == (result.UShort4 == a.UShort4));
                    constexpr.ASSUME((a.UShort5 <= 1) == (result.UShort5 == a.UShort5));
                    constexpr.ASSUME((a.UShort6 <= 1) == (result.UShort6 == a.UShort6));
                    constexpr.ASSUME((a.UShort7 <= 1) == (result.UShort7 == a.UShort7));

                    constexpr.ASSUME((a.UShort0 != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1 != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2 != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3 != 0) == (result.UShort3 > 0));
                    constexpr.ASSUME((a.UShort4 != 0) == (result.UShort4 > 0));
                    constexpr.ASSUME((a.UShort5 != 0) == (result.UShort5 > 0));
                    constexpr.ASSUME((a.UShort6 != 0) == (result.UShort6 > 0));
                    constexpr.ASSUME((a.UShort7 != 0) == (result.UShort7 > 0));

                    //constexpr.ASSUME((math.ispow2(a.UShort0) && (math.intlog2(a.UShort0) % 3u == 0)) ? math.ispow2(result.UShort0) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort1) && (math.intlog2(a.UShort1) % 3u == 0)) ? math.ispow2(result.UShort1) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort2) && (math.intlog2(a.UShort2) % 3u == 0)) ? math.ispow2(result.UShort2) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort3) && (math.intlog2(a.UShort3) % 3u == 0)) ? math.ispow2(result.UShort3) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort4) && (math.intlog2(a.UShort4) % 3u == 0)) ? math.ispow2(result.UShort4) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort5) && (math.intlog2(a.UShort5) % 3u == 0)) ? math.ispow2(result.UShort5) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort6) && (math.intlog2(a.UShort6) % 3u == 0)) ? math.ispow2(result.UShort6) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort7) && (math.intlog2(a.UShort7) % 3u == 0)) ? math.ispow2(result.UShort7) : true);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 cbrt_epu8_takingAndReturning_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 6 * 6 * 6))
                    {
                        return cbrt_absepi8_takingAndReturning_epu16(a);
                    }

                    v256 cb1 = mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi16(5 * 5 * 5 - 1);
                    v256 cb6 = mm256_set1_epi16(6 * 6 * 6 - 1);

                    v256 result = Avx2.mm256_sub_epi16(        mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb5), Avx2.mm256_cmpgt_epi16(a, cb6)));

                    constexpr.ASSUME_LE_EPU16(result, 6);

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0  * result.UShort0  * result.UShort0  <= a.UShort0);
                    constexpr.ASSUME(result.UShort1  * result.UShort1  * result.UShort1  <= a.UShort1);
                    constexpr.ASSUME(result.UShort2  * result.UShort2  * result.UShort2  <= a.UShort2);
                    constexpr.ASSUME(result.UShort3  * result.UShort3  * result.UShort3  <= a.UShort3);
                    constexpr.ASSUME(result.UShort4  * result.UShort4  * result.UShort4  <= a.UShort4);
                    constexpr.ASSUME(result.UShort5  * result.UShort5  * result.UShort5  <= a.UShort5);
                    constexpr.ASSUME(result.UShort6  * result.UShort6  * result.UShort6  <= a.UShort6);
                    constexpr.ASSUME(result.UShort7  * result.UShort7  * result.UShort7  <= a.UShort7);
                    constexpr.ASSUME(result.UShort8  * result.UShort8  * result.UShort8  <= a.UShort8);
                    constexpr.ASSUME(result.UShort9  * result.UShort9  * result.UShort9  <= a.UShort9);
                    constexpr.ASSUME(result.UShort10 * result.UShort10 * result.UShort10 <= a.UShort10);
                    constexpr.ASSUME(result.UShort11 * result.UShort11 * result.UShort11 <= a.UShort11);
                    constexpr.ASSUME(result.UShort12 * result.UShort12 * result.UShort12 <= a.UShort12);
                    constexpr.ASSUME(result.UShort13 * result.UShort13 * result.UShort13 <= a.UShort13);
                    constexpr.ASSUME(result.UShort14 * result.UShort14 * result.UShort14 <= a.UShort14);
                    constexpr.ASSUME(result.UShort15 * result.UShort15 * result.UShort15 <= a.UShort15);

                    constexpr.ASSUME((result.UShort0  + 1) * (result.UShort0  + 1) * (result.UShort0  + 1) > a.UShort0);
                    constexpr.ASSUME((result.UShort1  + 1) * (result.UShort1  + 1) * (result.UShort1  + 1) > a.UShort1);
                    constexpr.ASSUME((result.UShort2  + 1) * (result.UShort2  + 1) * (result.UShort2  + 1) > a.UShort2);
                    constexpr.ASSUME((result.UShort3  + 1) * (result.UShort3  + 1) * (result.UShort3  + 1) > a.UShort3);
                    constexpr.ASSUME((result.UShort4  + 1) * (result.UShort4  + 1) * (result.UShort4  + 1) > a.UShort4);
                    constexpr.ASSUME((result.UShort5  + 1) * (result.UShort5  + 1) * (result.UShort5  + 1) > a.UShort5);
                    constexpr.ASSUME((result.UShort6  + 1) * (result.UShort6  + 1) * (result.UShort6  + 1) > a.UShort6);
                    constexpr.ASSUME((result.UShort7  + 1) * (result.UShort7  + 1) * (result.UShort7  + 1) > a.UShort7);
                    constexpr.ASSUME((result.UShort8  + 1) * (result.UShort8  + 1) * (result.UShort8  + 1) > a.UShort8);
                    constexpr.ASSUME((result.UShort9  + 1) * (result.UShort9  + 1) * (result.UShort9  + 1) > a.UShort9);
                    constexpr.ASSUME((result.UShort10 + 1) * (result.UShort10 + 1) * (result.UShort10 + 1) > a.UShort10);
                    constexpr.ASSUME((result.UShort11 + 1) * (result.UShort11 + 1) * (result.UShort11 + 1) > a.UShort11);
                    constexpr.ASSUME((result.UShort12 + 1) * (result.UShort12 + 1) * (result.UShort12 + 1) > a.UShort12);
                    constexpr.ASSUME((result.UShort13 + 1) * (result.UShort13 + 1) * (result.UShort13 + 1) > a.UShort13);
                    constexpr.ASSUME((result.UShort14 + 1) * (result.UShort14 + 1) * (result.UShort14 + 1) > a.UShort14);
                    constexpr.ASSUME((result.UShort15 + 1) * (result.UShort15 + 1) * (result.UShort15 + 1) > a.UShort15);

                    constexpr.ASSUME((a.UShort0  <= 1) == (result.UShort0  == a.UShort0));
                    constexpr.ASSUME((a.UShort1  <= 1) == (result.UShort1  == a.UShort1));
                    constexpr.ASSUME((a.UShort2  <= 1) == (result.UShort2  == a.UShort2));
                    constexpr.ASSUME((a.UShort3  <= 1) == (result.UShort3  == a.UShort3));
                    constexpr.ASSUME((a.UShort4  <= 1) == (result.UShort4  == a.UShort4));
                    constexpr.ASSUME((a.UShort5  <= 1) == (result.UShort5  == a.UShort5));
                    constexpr.ASSUME((a.UShort6  <= 1) == (result.UShort6  == a.UShort6));
                    constexpr.ASSUME((a.UShort7  <= 1) == (result.UShort7  == a.UShort7));
                    constexpr.ASSUME((a.UShort8  <= 1) == (result.UShort8  == a.UShort8));
                    constexpr.ASSUME((a.UShort9  <= 1) == (result.UShort9  == a.UShort9));
                    constexpr.ASSUME((a.UShort10 <= 1) == (result.UShort10 == a.UShort10));
                    constexpr.ASSUME((a.UShort11 <= 1) == (result.UShort11 == a.UShort11));
                    constexpr.ASSUME((a.UShort12 <= 1) == (result.UShort12 == a.UShort12));
                    constexpr.ASSUME((a.UShort13 <= 1) == (result.UShort13 == a.UShort13));
                    constexpr.ASSUME((a.UShort14 <= 1) == (result.UShort14 == a.UShort14));
                    constexpr.ASSUME((a.UShort15 <= 1) == (result.UShort15 == a.UShort15));

                    constexpr.ASSUME((a.UShort0  != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1  != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2  != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3  != 0) == (result.UShort3 > 0));
                    constexpr.ASSUME((a.UShort4  != 0) == (result.UShort4 > 0));
                    constexpr.ASSUME((a.UShort5  != 0) == (result.UShort5 > 0));
                    constexpr.ASSUME((a.UShort6  != 0) == (result.UShort6 > 0));
                    constexpr.ASSUME((a.UShort7  != 0) == (result.UShort7 > 0));
                    constexpr.ASSUME((a.UShort8  != 0) == (result.UShort8 > 0));
                    constexpr.ASSUME((a.UShort9  != 0) == (result.UShort9 > 0));
                    constexpr.ASSUME((a.UShort10 != 0) == (result.UShort10> 0));
                    constexpr.ASSUME((a.UShort11 != 0) == (result.UShort11> 0));
                    constexpr.ASSUME((a.UShort12 != 0) == (result.UShort12> 0));
                    constexpr.ASSUME((a.UShort13 != 0) == (result.UShort13> 0));
                    constexpr.ASSUME((a.UShort14 != 0) == (result.UShort14> 0));
                    constexpr.ASSUME((a.UShort15 != 0) == (result.UShort15> 0));

                    //constexpr.ASSUME((math.ispow2(a.UShort0)  && (math.intlog2(a.UShort0)  % 3u == 0)) ? math.ispow2(result.UShort0)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort1)  && (math.intlog2(a.UShort1)  % 3u == 0)) ? math.ispow2(result.UShort1)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort2)  && (math.intlog2(a.UShort2)  % 3u == 0)) ? math.ispow2(result.UShort2)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort3)  && (math.intlog2(a.UShort3)  % 3u == 0)) ? math.ispow2(result.UShort3)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort4)  && (math.intlog2(a.UShort4)  % 3u == 0)) ? math.ispow2(result.UShort4)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort5)  && (math.intlog2(a.UShort5)  % 3u == 0)) ? math.ispow2(result.UShort5)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort6)  && (math.intlog2(a.UShort6)  % 3u == 0)) ? math.ispow2(result.UShort6)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort7)  && (math.intlog2(a.UShort7)  % 3u == 0)) ? math.ispow2(result.UShort7)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort8)  && (math.intlog2(a.UShort8)  % 3u == 0)) ? math.ispow2(result.UShort8)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort9)  && (math.intlog2(a.UShort9)  % 3u == 0)) ? math.ispow2(result.UShort9)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort10) && (math.intlog2(a.UShort10) % 3u == 0)) ? math.ispow2(result.UShort10) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort11) && (math.intlog2(a.UShort11) % 3u == 0)) ? math.ispow2(result.UShort11) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort12) && (math.intlog2(a.UShort12) % 3u == 0)) ? math.ispow2(result.UShort12) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort13) && (math.intlog2(a.UShort13) % 3u == 0)) ? math.ispow2(result.UShort13) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort14) && (math.intlog2(a.UShort14) % 3u == 0)) ? math.ispow2(result.UShort14) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort15) && (math.intlog2(a.UShort15) % 3u == 0)) ? math.ispow2(result.UShort15) : true);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v128 cbrt_absepi8_takingAndReturning_epu16(v128 a)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cb1 = set1_epi16(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi16(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi16(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi16(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi16(5 * 5 * 5 - 1);

                    v128 result = sub_epi16(        neg_epi16(cmpgt_epi16(a, cb1)),cmpgt_epi16(a, cb2));
                    result      = sub_epi16(result, add_epi16(cmpgt_epi16(a, cb3), cmpgt_epi16(a, cb4)));
                    result      = sub_epi16(result, cmpgt_epi16(a, cb5));

                    constexpr.ASSUME_LE_EPU16(result, 5);

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0 * result.UShort0 * result.UShort0 <= a.UShort0);
                    constexpr.ASSUME(result.UShort1 * result.UShort1 * result.UShort1 <= a.UShort1);
                    constexpr.ASSUME(result.UShort2 * result.UShort2 * result.UShort2 <= a.UShort2);
                    constexpr.ASSUME(result.UShort3 * result.UShort3 * result.UShort3 <= a.UShort3);
                    constexpr.ASSUME(result.UShort4 * result.UShort4 * result.UShort4 <= a.UShort4);
                    constexpr.ASSUME(result.UShort5 * result.UShort5 * result.UShort5 <= a.UShort5);
                    constexpr.ASSUME(result.UShort6 * result.UShort6 * result.UShort6 <= a.UShort6);
                    constexpr.ASSUME(result.UShort7 * result.UShort7 * result.UShort7 <= a.UShort7);

                    constexpr.ASSUME((result.UShort0 + 1) * (result.UShort0 + 1) * (result.UShort0 + 1) > a.UShort0);
                    constexpr.ASSUME((result.UShort1 + 1) * (result.UShort1 + 1) * (result.UShort1 + 1) > a.UShort1);
                    constexpr.ASSUME((result.UShort2 + 1) * (result.UShort2 + 1) * (result.UShort2 + 1) > a.UShort2);
                    constexpr.ASSUME((result.UShort3 + 1) * (result.UShort3 + 1) * (result.UShort3 + 1) > a.UShort3);
                    constexpr.ASSUME((result.UShort4 + 1) * (result.UShort4 + 1) * (result.UShort4 + 1) > a.UShort4);
                    constexpr.ASSUME((result.UShort5 + 1) * (result.UShort5 + 1) * (result.UShort5 + 1) > a.UShort5);
                    constexpr.ASSUME((result.UShort6 + 1) * (result.UShort6 + 1) * (result.UShort6 + 1) > a.UShort6);
                    constexpr.ASSUME((result.UShort7 + 1) * (result.UShort7 + 1) * (result.UShort7 + 1) > a.UShort7);

                    constexpr.ASSUME((a.UShort0 <= 1) == (result.UShort0 == a.UShort0));
                    constexpr.ASSUME((a.UShort1 <= 1) == (result.UShort1 == a.UShort1));
                    constexpr.ASSUME((a.UShort2 <= 1) == (result.UShort2 == a.UShort2));
                    constexpr.ASSUME((a.UShort3 <= 1) == (result.UShort3 == a.UShort3));
                    constexpr.ASSUME((a.UShort4 <= 1) == (result.UShort4 == a.UShort4));
                    constexpr.ASSUME((a.UShort5 <= 1) == (result.UShort5 == a.UShort5));
                    constexpr.ASSUME((a.UShort6 <= 1) == (result.UShort6 == a.UShort6));
                    constexpr.ASSUME((a.UShort7 <= 1) == (result.UShort7 == a.UShort7));

                    constexpr.ASSUME((a.UShort0 != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1 != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2 != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3 != 0) == (result.UShort3 > 0));
                    constexpr.ASSUME((a.UShort4 != 0) == (result.UShort4 > 0));
                    constexpr.ASSUME((a.UShort5 != 0) == (result.UShort5 > 0));
                    constexpr.ASSUME((a.UShort6 != 0) == (result.UShort6 > 0));
                    constexpr.ASSUME((a.UShort7 != 0) == (result.UShort7 > 0));

                    //constexpr.ASSUME((math.ispow2(a.UShort0) && (math.intlog2(a.UShort0) % 3u == 0)) ? math.ispow2(result.UShort0) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort1) && (math.intlog2(a.UShort1) % 3u == 0)) ? math.ispow2(result.UShort1) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort2) && (math.intlog2(a.UShort2) % 3u == 0)) ? math.ispow2(result.UShort2) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort3) && (math.intlog2(a.UShort3) % 3u == 0)) ? math.ispow2(result.UShort3) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort4) && (math.intlog2(a.UShort4) % 3u == 0)) ? math.ispow2(result.UShort4) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort5) && (math.intlog2(a.UShort5) % 3u == 0)) ? math.ispow2(result.UShort5) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort6) && (math.intlog2(a.UShort6) % 3u == 0)) ? math.ispow2(result.UShort6) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort7) && (math.intlog2(a.UShort7) % 3u == 0)) ? math.ispow2(result.UShort7) : true);

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private static v256 cbrt_absepi8_takingAndReturning_epu16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cb1 = mm256_set1_epi16(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi16(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi16(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi16(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi16(5 * 5 * 5 - 1);

                    v256 result = Avx2.mm256_sub_epi16(        mm256_neg_epi16(Avx2.mm256_cmpgt_epi16(a, cb1)),Avx2.mm256_cmpgt_epi16(a, cb2));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_add_epi16(Avx2.mm256_cmpgt_epi16(a, cb3), Avx2.mm256_cmpgt_epi16(a, cb4)));
                    result = Avx2.mm256_sub_epi16(result, Avx2.mm256_cmpgt_epi16(a, cb5));

                    constexpr.ASSUME_LE_EPU16(result, 5);

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0  * result.UShort0  * result.UShort0  <= a.UShort0);
                    constexpr.ASSUME(result.UShort1  * result.UShort1  * result.UShort1  <= a.UShort1);
                    constexpr.ASSUME(result.UShort2  * result.UShort2  * result.UShort2  <= a.UShort2);
                    constexpr.ASSUME(result.UShort3  * result.UShort3  * result.UShort3  <= a.UShort3);
                    constexpr.ASSUME(result.UShort4  * result.UShort4  * result.UShort4  <= a.UShort4);
                    constexpr.ASSUME(result.UShort5  * result.UShort5  * result.UShort5  <= a.UShort5);
                    constexpr.ASSUME(result.UShort6  * result.UShort6  * result.UShort6  <= a.UShort6);
                    constexpr.ASSUME(result.UShort7  * result.UShort7  * result.UShort7  <= a.UShort7);
                    constexpr.ASSUME(result.UShort8  * result.UShort8  * result.UShort8  <= a.UShort8);
                    constexpr.ASSUME(result.UShort9  * result.UShort9  * result.UShort9  <= a.UShort9);
                    constexpr.ASSUME(result.UShort10 * result.UShort10 * result.UShort10 <= a.UShort10);
                    constexpr.ASSUME(result.UShort11 * result.UShort11 * result.UShort11 <= a.UShort11);
                    constexpr.ASSUME(result.UShort12 * result.UShort12 * result.UShort12 <= a.UShort12);
                    constexpr.ASSUME(result.UShort13 * result.UShort13 * result.UShort13 <= a.UShort13);
                    constexpr.ASSUME(result.UShort14 * result.UShort14 * result.UShort14 <= a.UShort14);
                    constexpr.ASSUME(result.UShort15 * result.UShort15 * result.UShort15 <= a.UShort15);

                    constexpr.ASSUME((result.UShort0  + 1) * (result.UShort0  + 1) * (result.UShort0  + 1) > a.UShort0);
                    constexpr.ASSUME((result.UShort1  + 1) * (result.UShort1  + 1) * (result.UShort1  + 1) > a.UShort1);
                    constexpr.ASSUME((result.UShort2  + 1) * (result.UShort2  + 1) * (result.UShort2  + 1) > a.UShort2);
                    constexpr.ASSUME((result.UShort3  + 1) * (result.UShort3  + 1) * (result.UShort3  + 1) > a.UShort3);
                    constexpr.ASSUME((result.UShort4  + 1) * (result.UShort4  + 1) * (result.UShort4  + 1) > a.UShort4);
                    constexpr.ASSUME((result.UShort5  + 1) * (result.UShort5  + 1) * (result.UShort5  + 1) > a.UShort5);
                    constexpr.ASSUME((result.UShort6  + 1) * (result.UShort6  + 1) * (result.UShort6  + 1) > a.UShort6);
                    constexpr.ASSUME((result.UShort7  + 1) * (result.UShort7  + 1) * (result.UShort7  + 1) > a.UShort7);
                    constexpr.ASSUME((result.UShort8  + 1) * (result.UShort8  + 1) * (result.UShort8  + 1) > a.UShort8);
                    constexpr.ASSUME((result.UShort9  + 1) * (result.UShort9  + 1) * (result.UShort9  + 1) > a.UShort9);
                    constexpr.ASSUME((result.UShort10 + 1) * (result.UShort10 + 1) * (result.UShort10 + 1) > a.UShort10);
                    constexpr.ASSUME((result.UShort11 + 1) * (result.UShort11 + 1) * (result.UShort11 + 1) > a.UShort11);
                    constexpr.ASSUME((result.UShort12 + 1) * (result.UShort12 + 1) * (result.UShort12 + 1) > a.UShort12);
                    constexpr.ASSUME((result.UShort13 + 1) * (result.UShort13 + 1) * (result.UShort13 + 1) > a.UShort13);
                    constexpr.ASSUME((result.UShort14 + 1) * (result.UShort14 + 1) * (result.UShort14 + 1) > a.UShort14);
                    constexpr.ASSUME((result.UShort15 + 1) * (result.UShort15 + 1) * (result.UShort15 + 1) > a.UShort15);

                    constexpr.ASSUME((a.UShort0  <= 1) == (result.UShort0  == a.UShort0));
                    constexpr.ASSUME((a.UShort1  <= 1) == (result.UShort1  == a.UShort1));
                    constexpr.ASSUME((a.UShort2  <= 1) == (result.UShort2  == a.UShort2));
                    constexpr.ASSUME((a.UShort3  <= 1) == (result.UShort3  == a.UShort3));
                    constexpr.ASSUME((a.UShort4  <= 1) == (result.UShort4  == a.UShort4));
                    constexpr.ASSUME((a.UShort5  <= 1) == (result.UShort5  == a.UShort5));
                    constexpr.ASSUME((a.UShort6  <= 1) == (result.UShort6  == a.UShort6));
                    constexpr.ASSUME((a.UShort7  <= 1) == (result.UShort7  == a.UShort7));
                    constexpr.ASSUME((a.UShort8  <= 1) == (result.UShort8  == a.UShort8));
                    constexpr.ASSUME((a.UShort9  <= 1) == (result.UShort9  == a.UShort9));
                    constexpr.ASSUME((a.UShort10 <= 1) == (result.UShort10 == a.UShort10));
                    constexpr.ASSUME((a.UShort11 <= 1) == (result.UShort11 == a.UShort11));
                    constexpr.ASSUME((a.UShort12 <= 1) == (result.UShort12 == a.UShort12));
                    constexpr.ASSUME((a.UShort13 <= 1) == (result.UShort13 == a.UShort13));
                    constexpr.ASSUME((a.UShort14 <= 1) == (result.UShort14 == a.UShort14));
                    constexpr.ASSUME((a.UShort15 <= 1) == (result.UShort15 == a.UShort15));

                    constexpr.ASSUME((a.UShort0  != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1  != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2  != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3  != 0) == (result.UShort3 > 0));
                    constexpr.ASSUME((a.UShort4  != 0) == (result.UShort4 > 0));
                    constexpr.ASSUME((a.UShort5  != 0) == (result.UShort5 > 0));
                    constexpr.ASSUME((a.UShort6  != 0) == (result.UShort6 > 0));
                    constexpr.ASSUME((a.UShort7  != 0) == (result.UShort7 > 0));
                    constexpr.ASSUME((a.UShort8  != 0) == (result.UShort8 > 0));
                    constexpr.ASSUME((a.UShort9  != 0) == (result.UShort9 > 0));
                    constexpr.ASSUME((a.UShort10 != 0) == (result.UShort10> 0));
                    constexpr.ASSUME((a.UShort11 != 0) == (result.UShort11> 0));
                    constexpr.ASSUME((a.UShort12 != 0) == (result.UShort12> 0));
                    constexpr.ASSUME((a.UShort13 != 0) == (result.UShort13> 0));
                    constexpr.ASSUME((a.UShort14 != 0) == (result.UShort14> 0));
                    constexpr.ASSUME((a.UShort15 != 0) == (result.UShort15> 0));

                    //constexpr.ASSUME((math.ispow2(a.UShort0)  && (math.intlog2(a.UShort0)  % 3u == 0)) ? math.ispow2(result.UShort0)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort1)  && (math.intlog2(a.UShort1)  % 3u == 0)) ? math.ispow2(result.UShort1)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort2)  && (math.intlog2(a.UShort2)  % 3u == 0)) ? math.ispow2(result.UShort2)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort3)  && (math.intlog2(a.UShort3)  % 3u == 0)) ? math.ispow2(result.UShort3)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort4)  && (math.intlog2(a.UShort4)  % 3u == 0)) ? math.ispow2(result.UShort4)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort5)  && (math.intlog2(a.UShort5)  % 3u == 0)) ? math.ispow2(result.UShort5)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort6)  && (math.intlog2(a.UShort6)  % 3u == 0)) ? math.ispow2(result.UShort6)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort7)  && (math.intlog2(a.UShort7)  % 3u == 0)) ? math.ispow2(result.UShort7)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort8)  && (math.intlog2(a.UShort8)  % 3u == 0)) ? math.ispow2(result.UShort8)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort9)  && (math.intlog2(a.UShort9)  % 3u == 0)) ? math.ispow2(result.UShort9)  : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort10) && (math.intlog2(a.UShort10) % 3u == 0)) ? math.ispow2(result.UShort10) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort11) && (math.intlog2(a.UShort11) % 3u == 0)) ? math.ispow2(result.UShort11) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort12) && (math.intlog2(a.UShort12) % 3u == 0)) ? math.ispow2(result.UShort12) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort13) && (math.intlog2(a.UShort13) % 3u == 0)) ? math.ispow2(result.UShort13) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort14) && (math.intlog2(a.UShort14) % 3u == 0)) ? math.ispow2(result.UShort14) : true);
                    //constexpr.ASSUME((math.ispow2(a.UShort15) && (math.intlog2(a.UShort15) % 3u == 0)) ? math.ispow2(result.UShort15) : true);

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu8(v128 a, bool promiseEPI8range = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (elements > 8)
                    {
                        if (promiseEPI8range || constexpr.ALL_LT_EPU8(a, 128, elements))
                        {
                            return cbrt_epi8(a, true, elements);
                        }

                        v128 cb1 = set1_epi8(1 * 1 * 1);
                        v128 cb2 = set1_epi8(2 * 2 * 2);
                        v128 cb3 = set1_epi8(3 * 3 * 3);
                        v128 cb4 = set1_epi8(4 * 4 * 4);
                        v128 cb5 = set1_epi8(5 * 5 * 5);
                        v128 cb6 = set1_epi8(6 * 6 * 6);

                        result = sub_epi8(        neg_epi8(cmpge_epu8(a, cb1)),cmpge_epu8(a, cb2));
                        result = sub_epi8(result, add_epi8(cmpge_epu8(a, cb3), cmpge_epu8(a, cb4)));
                        result = sub_epi8(result, add_epi8(cmpge_epu8(a, cb5), cmpge_epu8(a, cb6)));
                    }
                    else
                    {
                        v128 x = cbrt_epu8_takingAndReturning_epu16(cvtepu8_epi16(a), elements);
                        result = packus_epi16(x, x);
                    }

                    constexpr.ASSUME_LE_EPU8(result, 6);

                    constexpr.ASSUME_LE_EPU8(result, a, elements);
                    if (constexpr.ALL_GT_EPU8(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a, elements);
                    }
                    
                    constexpr.ASSUME(result.Byte0  * result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  * result.Byte7  <= a.Byte7 );
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    
                    if (elements > 8)
                    {
                        constexpr.ASSUME(result.Byte8  * result.Byte8  * result.Byte8  <= a.Byte8 );
                        constexpr.ASSUME(result.Byte9  * result.Byte9  * result.Byte9  <= a.Byte9 );
                        constexpr.ASSUME(result.Byte10 * result.Byte10 * result.Byte10 <= a.Byte10);
                        constexpr.ASSUME(result.Byte11 * result.Byte11 * result.Byte11 <= a.Byte11);
                        constexpr.ASSUME(result.Byte12 * result.Byte12 * result.Byte12 <= a.Byte12);
                        constexpr.ASSUME(result.Byte13 * result.Byte13 * result.Byte13 <= a.Byte13);
                        constexpr.ASSUME(result.Byte14 * result.Byte14 * result.Byte14 <= a.Byte14);
                        constexpr.ASSUME(result.Byte15 * result.Byte15 * result.Byte15 <= a.Byte15);
                        
                        constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                        constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                        constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                        constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                        constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                        constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                        constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                        constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                        
                        constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                        constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                        constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                        constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                        constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                        constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                        constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                        constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                        
                        constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                        constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                        constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                        constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                        constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                        constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                        constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                        constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu8(v256 a, bool promiseEPI8range = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (promiseEPI8range || constexpr.ALL_LT_EPU8(a, 128))
                    {
                        return mm256_cbrt_epi8(a, true);
                    }

                    v256 cb1 = mm256_set1_epi8(1 * 1 * 1);
                    v256 cb2 = mm256_set1_epi8(2 * 2 * 2);
                    v256 cb3 = mm256_set1_epi8(3 * 3 * 3);
                    v256 cb4 = mm256_set1_epi8(4 * 4 * 4);
                    v256 cb5 = mm256_set1_epi8(5 * 5 * 5);
                    v256 cb6 = mm256_set1_epi8(6 * 6 * 6);

                    v256 result = Avx2.mm256_sub_epi8(        mm256_neg_epi8(mm256_cmpge_epu8(a, cb1)),mm256_cmpge_epu8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb3), mm256_cmpge_epu8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(mm256_cmpge_epu8(a, cb5), mm256_cmpge_epu8(a, cb6)));

                    constexpr.ASSUME_LE_EPU8(result, 6);

                    constexpr.ASSUME_LE_EPU8(result, a);
                    if (constexpr.ALL_GT_EPU8(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU8(result, a);
                    }

                    constexpr.ASSUME(result.Byte0  * result.Byte0  * result.Byte0  <= a.Byte0 );
                    constexpr.ASSUME(result.Byte1  * result.Byte1  * result.Byte1  <= a.Byte1 );
                    constexpr.ASSUME(result.Byte2  * result.Byte2  * result.Byte2  <= a.Byte2 );
                    constexpr.ASSUME(result.Byte3  * result.Byte3  * result.Byte3  <= a.Byte3 );
                    constexpr.ASSUME(result.Byte4  * result.Byte4  * result.Byte4  <= a.Byte4 );
                    constexpr.ASSUME(result.Byte5  * result.Byte5  * result.Byte5  <= a.Byte5 );
                    constexpr.ASSUME(result.Byte6  * result.Byte6  * result.Byte6  <= a.Byte6 );
                    constexpr.ASSUME(result.Byte7  * result.Byte7  * result.Byte7  <= a.Byte7 );
                    constexpr.ASSUME(result.Byte8  * result.Byte8  * result.Byte8  <= a.Byte8 );
                    constexpr.ASSUME(result.Byte9  * result.Byte9  * result.Byte9  <= a.Byte9 );
                    constexpr.ASSUME(result.Byte10 * result.Byte10 * result.Byte10 <= a.Byte10);
                    constexpr.ASSUME(result.Byte11 * result.Byte11 * result.Byte11 <= a.Byte11);
                    constexpr.ASSUME(result.Byte12 * result.Byte12 * result.Byte12 <= a.Byte12);
                    constexpr.ASSUME(result.Byte13 * result.Byte13 * result.Byte13 <= a.Byte13);
                    constexpr.ASSUME(result.Byte14 * result.Byte14 * result.Byte14 <= a.Byte14);
                    constexpr.ASSUME(result.Byte15 * result.Byte15 * result.Byte15 <= a.Byte15);
                    constexpr.ASSUME(result.Byte16 * result.Byte16 * result.Byte16 <= a.Byte16);
                    constexpr.ASSUME(result.Byte17 * result.Byte17 * result.Byte17 <= a.Byte17);
                    constexpr.ASSUME(result.Byte18 * result.Byte18 * result.Byte18 <= a.Byte18);
                    constexpr.ASSUME(result.Byte19 * result.Byte19 * result.Byte19 <= a.Byte19);
                    constexpr.ASSUME(result.Byte20 * result.Byte20 * result.Byte20 <= a.Byte20);
                    constexpr.ASSUME(result.Byte21 * result.Byte21 * result.Byte21 <= a.Byte21);
                    constexpr.ASSUME(result.Byte22 * result.Byte22 * result.Byte22 <= a.Byte22);
                    constexpr.ASSUME(result.Byte23 * result.Byte23 * result.Byte23 <= a.Byte23);
                    constexpr.ASSUME(result.Byte24 * result.Byte24 * result.Byte24 <= a.Byte24);
                    constexpr.ASSUME(result.Byte25 * result.Byte25 * result.Byte25 <= a.Byte25);
                    constexpr.ASSUME(result.Byte26 * result.Byte26 * result.Byte26 <= a.Byte26);
                    constexpr.ASSUME(result.Byte27 * result.Byte27 * result.Byte27 <= a.Byte27);
                    constexpr.ASSUME(result.Byte28 * result.Byte28 * result.Byte28 <= a.Byte28);
                    constexpr.ASSUME(result.Byte29 * result.Byte29 * result.Byte29 <= a.Byte29);
                    constexpr.ASSUME(result.Byte30 * result.Byte30 * result.Byte30 <= a.Byte30);
                    constexpr.ASSUME(result.Byte31 * result.Byte31 * result.Byte31 <= a.Byte31);
                    
                    constexpr.ASSUME((result.Byte0  + 1) * (result.Byte0  + 1) * (result.Byte0  + 1) > a.Byte0 );
                    constexpr.ASSUME((result.Byte1  + 1) * (result.Byte1  + 1) * (result.Byte1  + 1) > a.Byte1 );
                    constexpr.ASSUME((result.Byte2  + 1) * (result.Byte2  + 1) * (result.Byte2  + 1) > a.Byte2 );
                    constexpr.ASSUME((result.Byte3  + 1) * (result.Byte3  + 1) * (result.Byte3  + 1) > a.Byte3 );
                    constexpr.ASSUME((result.Byte4  + 1) * (result.Byte4  + 1) * (result.Byte4  + 1) > a.Byte4 );
                    constexpr.ASSUME((result.Byte5  + 1) * (result.Byte5  + 1) * (result.Byte5  + 1) > a.Byte5 );
                    constexpr.ASSUME((result.Byte6  + 1) * (result.Byte6  + 1) * (result.Byte6  + 1) > a.Byte6 );
                    constexpr.ASSUME((result.Byte7  + 1) * (result.Byte7  + 1) * (result.Byte7  + 1) > a.Byte7 );
                    constexpr.ASSUME((result.Byte8  + 1) * (result.Byte8  + 1) * (result.Byte8  + 1) > a.Byte8 );
                    constexpr.ASSUME((result.Byte9  + 1) * (result.Byte9  + 1) * (result.Byte9  + 1) > a.Byte9 );
                    constexpr.ASSUME((result.Byte10 + 1) * (result.Byte10 + 1) * (result.Byte10 + 1) > a.Byte10);
                    constexpr.ASSUME((result.Byte11 + 1) * (result.Byte11 + 1) * (result.Byte11 + 1) > a.Byte11);
                    constexpr.ASSUME((result.Byte12 + 1) * (result.Byte12 + 1) * (result.Byte12 + 1) > a.Byte12);
                    constexpr.ASSUME((result.Byte13 + 1) * (result.Byte13 + 1) * (result.Byte13 + 1) > a.Byte13);
                    constexpr.ASSUME((result.Byte14 + 1) * (result.Byte14 + 1) * (result.Byte14 + 1) > a.Byte14);
                    constexpr.ASSUME((result.Byte15 + 1) * (result.Byte15 + 1) * (result.Byte15 + 1) > a.Byte15);
                    constexpr.ASSUME((result.Byte16 + 1) * (result.Byte16 + 1) * (result.Byte16 + 1) > a.Byte16);
                    constexpr.ASSUME((result.Byte17 + 1) * (result.Byte17 + 1) * (result.Byte17 + 1) > a.Byte17);
                    constexpr.ASSUME((result.Byte18 + 1) * (result.Byte18 + 1) * (result.Byte18 + 1) > a.Byte18);
                    constexpr.ASSUME((result.Byte19 + 1) * (result.Byte19 + 1) * (result.Byte19 + 1) > a.Byte19);
                    constexpr.ASSUME((result.Byte20 + 1) * (result.Byte20 + 1) * (result.Byte20 + 1) > a.Byte20);
                    constexpr.ASSUME((result.Byte21 + 1) * (result.Byte21 + 1) * (result.Byte21 + 1) > a.Byte21);
                    constexpr.ASSUME((result.Byte22 + 1) * (result.Byte22 + 1) * (result.Byte22 + 1) > a.Byte22);
                    constexpr.ASSUME((result.Byte23 + 1) * (result.Byte23 + 1) * (result.Byte23 + 1) > a.Byte23);
                    constexpr.ASSUME((result.Byte24 + 1) * (result.Byte24 + 1) * (result.Byte24 + 1) > a.Byte24);
                    constexpr.ASSUME((result.Byte25 + 1) * (result.Byte25 + 1) * (result.Byte25 + 1) > a.Byte25);
                    constexpr.ASSUME((result.Byte26 + 1) * (result.Byte26 + 1) * (result.Byte26 + 1) > a.Byte26);
                    constexpr.ASSUME((result.Byte27 + 1) * (result.Byte27 + 1) * (result.Byte27 + 1) > a.Byte27);
                    constexpr.ASSUME((result.Byte28 + 1) * (result.Byte28 + 1) * (result.Byte28 + 1) > a.Byte28);
                    constexpr.ASSUME((result.Byte29 + 1) * (result.Byte29 + 1) * (result.Byte29 + 1) > a.Byte29);
                    constexpr.ASSUME((result.Byte30 + 1) * (result.Byte30 + 1) * (result.Byte30 + 1) > a.Byte30);
                    constexpr.ASSUME((result.Byte31 + 1) * (result.Byte31 + 1) * (result.Byte31 + 1) > a.Byte31);
                    
                    constexpr.ASSUME((a.Byte0  <= 1) == (result.Byte0  == a.Byte0 ));
                    constexpr.ASSUME((a.Byte1  <= 1) == (result.Byte1  == a.Byte1 ));
                    constexpr.ASSUME((a.Byte2  <= 1) == (result.Byte2  == a.Byte2 ));
                    constexpr.ASSUME((a.Byte3  <= 1) == (result.Byte3  == a.Byte3 ));
                    constexpr.ASSUME((a.Byte4  <= 1) == (result.Byte4  == a.Byte4 ));
                    constexpr.ASSUME((a.Byte5  <= 1) == (result.Byte5  == a.Byte5 ));
                    constexpr.ASSUME((a.Byte6  <= 1) == (result.Byte6  == a.Byte6 ));
                    constexpr.ASSUME((a.Byte7  <= 1) == (result.Byte7  == a.Byte7 ));
                    constexpr.ASSUME((a.Byte8  <= 1) == (result.Byte8  == a.Byte8 ));
                    constexpr.ASSUME((a.Byte9  <= 1) == (result.Byte9  == a.Byte9 ));
                    constexpr.ASSUME((a.Byte10 <= 1) == (result.Byte10 == a.Byte10));
                    constexpr.ASSUME((a.Byte11 <= 1) == (result.Byte11 == a.Byte11));
                    constexpr.ASSUME((a.Byte12 <= 1) == (result.Byte12 == a.Byte12));
                    constexpr.ASSUME((a.Byte13 <= 1) == (result.Byte13 == a.Byte13));
                    constexpr.ASSUME((a.Byte14 <= 1) == (result.Byte14 == a.Byte14));
                    constexpr.ASSUME((a.Byte15 <= 1) == (result.Byte15 == a.Byte15));
                    constexpr.ASSUME((a.Byte16 <= 1) == (result.Byte16 == a.Byte16));
                    constexpr.ASSUME((a.Byte17 <= 1) == (result.Byte17 == a.Byte17));
                    constexpr.ASSUME((a.Byte18 <= 1) == (result.Byte18 == a.Byte18));
                    constexpr.ASSUME((a.Byte19 <= 1) == (result.Byte19 == a.Byte19));
                    constexpr.ASSUME((a.Byte20 <= 1) == (result.Byte20 == a.Byte20));
                    constexpr.ASSUME((a.Byte21 <= 1) == (result.Byte21 == a.Byte21));
                    constexpr.ASSUME((a.Byte22 <= 1) == (result.Byte22 == a.Byte22));
                    constexpr.ASSUME((a.Byte23 <= 1) == (result.Byte23 == a.Byte23));
                    constexpr.ASSUME((a.Byte24 <= 1) == (result.Byte24 == a.Byte24));
                    constexpr.ASSUME((a.Byte25 <= 1) == (result.Byte25 == a.Byte25));
                    constexpr.ASSUME((a.Byte26 <= 1) == (result.Byte26 == a.Byte26));
                    constexpr.ASSUME((a.Byte27 <= 1) == (result.Byte27 == a.Byte27));
                    constexpr.ASSUME((a.Byte28 <= 1) == (result.Byte28 == a.Byte28));
                    constexpr.ASSUME((a.Byte29 <= 1) == (result.Byte29 == a.Byte29));
                    constexpr.ASSUME((a.Byte30 <= 1) == (result.Byte30 == a.Byte30));
                    constexpr.ASSUME((a.Byte31 <= 1) == (result.Byte31 == a.Byte31));
                    
                    constexpr.ASSUME((a.Byte0  != 0) == (result.Byte0  > 0));
                    constexpr.ASSUME((a.Byte1  != 0) == (result.Byte1  > 0));
                    constexpr.ASSUME((a.Byte2  != 0) == (result.Byte2  > 0));
                    constexpr.ASSUME((a.Byte3  != 0) == (result.Byte3  > 0));
                    constexpr.ASSUME((a.Byte4  != 0) == (result.Byte4  > 0));
                    constexpr.ASSUME((a.Byte5  != 0) == (result.Byte5  > 0));
                    constexpr.ASSUME((a.Byte6  != 0) == (result.Byte6  > 0));
                    constexpr.ASSUME((a.Byte7  != 0) == (result.Byte7  > 0));
                    constexpr.ASSUME((a.Byte8  != 0) == (result.Byte8  > 0));
                    constexpr.ASSUME((a.Byte9  != 0) == (result.Byte9  > 0));
                    constexpr.ASSUME((a.Byte10 != 0) == (result.Byte10 > 0));
                    constexpr.ASSUME((a.Byte11 != 0) == (result.Byte11 > 0));
                    constexpr.ASSUME((a.Byte12 != 0) == (result.Byte12 > 0));
                    constexpr.ASSUME((a.Byte13 != 0) == (result.Byte13 > 0));
                    constexpr.ASSUME((a.Byte14 != 0) == (result.Byte14 > 0));
                    constexpr.ASSUME((a.Byte15 != 0) == (result.Byte15 > 0));
                    constexpr.ASSUME((a.Byte16 != 0) == (result.Byte16 > 0));
                    constexpr.ASSUME((a.Byte17 != 0) == (result.Byte17 > 0));
                    constexpr.ASSUME((a.Byte18 != 0) == (result.Byte18 > 0));
                    constexpr.ASSUME((a.Byte19 != 0) == (result.Byte19 > 0));
                    constexpr.ASSUME((a.Byte20 != 0) == (result.Byte20 > 0));
                    constexpr.ASSUME((a.Byte21 != 0) == (result.Byte21 > 0));
                    constexpr.ASSUME((a.Byte22 != 0) == (result.Byte22 > 0));
                    constexpr.ASSUME((a.Byte23 != 0) == (result.Byte23 > 0));
                    constexpr.ASSUME((a.Byte24 != 0) == (result.Byte24 > 0));
                    constexpr.ASSUME((a.Byte25 != 0) == (result.Byte25 > 0));
                    constexpr.ASSUME((a.Byte26 != 0) == (result.Byte26 > 0));
                    constexpr.ASSUME((a.Byte27 != 0) == (result.Byte27 > 0));
                    constexpr.ASSUME((a.Byte28 != 0) == (result.Byte28 > 0));
                    constexpr.ASSUME((a.Byte29 != 0) == (result.Byte29 > 0));
                    constexpr.ASSUME((a.Byte30 != 0) == (result.Byte30 > 0));
                    constexpr.ASSUME((a.Byte31 != 0) == (result.Byte31 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi8(v128 a, bool promisePositive = false, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 negative = a;
                    bool NEED_TO_SAVE_SIGN = !(promisePositive || constexpr.ALL_GE_EPI8(a, 0, elements));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        a = abs_epi8(a);
                    }

                    v128 cb1 = set1_epi8(1 * 1 * 1 - 1);
                    v128 cb2 = set1_epi8(2 * 2 * 2 - 1);
                    v128 cb3 = set1_epi8(3 * 3 * 3 - 1);
                    v128 cb4 = set1_epi8(4 * 4 * 4 - 1);
                    v128 cb5 = set1_epi8(5 * 5 * 5 - 1);

                    v128 result = sub_epi8(        neg_epi8(cmpgt_epi8(a, cb1)),cmpgt_epi8(a, cb2));
                    result      = sub_epi8(result, add_epi8(cmpgt_epi8(a, cb3), cmpgt_epi8(a, cb4)));
                    result      = sub_epi8(result, cmpgt_epi8(a, cb5));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi8(result, negative);
                        }
                        else
                        {
                            negative = srai_epi8(negative, 7, elements: elements);

                            result = xor_si128(add_epi8(result, negative), negative);
                        }
                    }

                    constexpr.ASSUME_RANGE_EPI8(result, NEED_TO_SAVE_SIGN ? -5 : 0, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi8(v256 a, bool promisePositive = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 negative = a;
                    bool NEED_TO_SAVE_SIGN = !(promisePositive || constexpr.ALL_GE_EPI8(a, 0));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        a = mm256_abs_epi8(a);
                    }

                    v256 cb1 = mm256_set1_epi8(1 * 1 * 1 - 1);
                    v256 cb2 = mm256_set1_epi8(2 * 2 * 2 - 1);
                    v256 cb3 = mm256_set1_epi8(3 * 3 * 3 - 1);
                    v256 cb4 = mm256_set1_epi8(4 * 4 * 4 - 1);
                    v256 cb5 = mm256_set1_epi8(5 * 5 * 5 - 1);

                    v256 result = Avx2.mm256_sub_epi8(        mm256_neg_epi8(Avx2.mm256_cmpgt_epi8(a, cb1)),Avx2.mm256_cmpgt_epi8(a, cb2));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_add_epi8(Avx2.mm256_cmpgt_epi8(a, cb3), Avx2.mm256_cmpgt_epi8(a, cb4)));
                    result = Avx2.mm256_sub_epi8(result, Avx2.mm256_cmpgt_epi8(a, cb5));

                    if (NEED_TO_SAVE_SIGN)
                    {
                        result = Avx2.mm256_sign_epi8(result, negative);
                    }

                    constexpr.ASSUME_RANGE_EPI8(result, NEED_TO_SAVE_SIGN ? -5 : 0, 5);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu16(v128 a, bool promiseByteRange = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;
                    if (promiseByteRange || constexpr.ALL_LE_EPU16(a, byte.MaxValue, elements))
                    {
                        result = cbrt_epu8_takingAndReturning_epu16(a, elements);
                    }
                    else
                    {
                        v128 __a = a;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = setzero_si128();

                            for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = add_epi16(result, result);
                                v128 y3 = add_epi16(result, slli_epi16(result, 1));
                                b = inc_epi16(mullo_epi16(y3, inc_epi16(result)));

                                v128 greaterEqualMask = cmpgt_epi16(b, srli_epi16(__a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, c, inRange: true));
                                v128 addToY = inc_epi16(greaterEqualMask);
                                __a = sub_epi16(__a, subFromX);
                                result = add_epi16(result, addToY);
                            }
                        }
                        else
                        {
                            v128 greaterEqualMask = srai_epi16(__a, 15);
                            result = srli_epi16(__a, 15);
                            __a = and_si128(__a, set1_epi16(0x7FFF));
                            v128 y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(result, y4);
                            b = add_epi16(inc_epi16(b), and_si128(greaterEqualMask, slli_epi16(b, 1)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(__a, 12));
                            v128 subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 12));
                            v128 addToY = inc_epi16(greaterEqualMask);
                            __a = sub_epi16(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = inc_epi16(mullo_epi16(add_epi16(result, y4), inc_epi16(result)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(__a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 9));
                            addToY = inc_epi16(greaterEqualMask);
                            __a = sub_epi16(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = inc_epi16(mullo_epi16(add_epi16(result, y4), inc_epi16(result)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(__a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 6));
                            addToY = inc_epi16(greaterEqualMask);
                            __a = sub_epi16(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = inc_epi16(mullo_epi16(add_epi16(result, y4), inc_epi16(result)));

                            greaterEqualMask = cmpgt_epi16(b, srli_epi16(__a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi16(b, 3));
                            addToY = inc_epi16(greaterEqualMask);
                            __a = sub_epi16(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = inc_epi16(mullo_epi16(add_epi16(result, y4), inc_epi16(result)));

                            greaterEqualMask = cmpgt_epi16(b, __a);
                            addToY = inc_epi16(greaterEqualMask);
                            result = add_epi16(result, addToY);
                        }
                    }
                    
                    constexpr.ASSUME_LE_EPU16(result, 40);

                    constexpr.ASSUME_LE_EPU16(result, a, elements);
                    if (constexpr.ALL_GT_EPU16(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a, elements);
                    }

                    constexpr.ASSUME(result.UShort0 * result.UShort0 * result.UShort0 <= a.UShort0);
                    constexpr.ASSUME(result.UShort1 * result.UShort1 * result.UShort1 <= a.UShort1);
                    constexpr.ASSUME(result.UShort2 * result.UShort2 * result.UShort2 <= a.UShort2);
                    constexpr.ASSUME(result.UShort3 * result.UShort3 * result.UShort3 <= a.UShort3);
                    constexpr.ASSUME(result.UShort4 * result.UShort4 * result.UShort4 <= a.UShort4);
                    constexpr.ASSUME(result.UShort5 * result.UShort5 * result.UShort5 <= a.UShort5);
                    constexpr.ASSUME(result.UShort6 * result.UShort6 * result.UShort6 <= a.UShort6);
                    constexpr.ASSUME(result.UShort7 * result.UShort7 * result.UShort7 <= a.UShort7);
                    
                    constexpr.ASSUME((result.UShort0 + 1) * (result.UShort0 + 1) * (result.UShort0 + 1) > a.UShort0);
                    constexpr.ASSUME((result.UShort1 + 1) * (result.UShort1 + 1) * (result.UShort1 + 1) > a.UShort1);
                    constexpr.ASSUME((result.UShort2 + 1) * (result.UShort2 + 1) * (result.UShort2 + 1) > a.UShort2);
                    constexpr.ASSUME((result.UShort3 + 1) * (result.UShort3 + 1) * (result.UShort3 + 1) > a.UShort3);
                    constexpr.ASSUME((result.UShort4 + 1) * (result.UShort4 + 1) * (result.UShort4 + 1) > a.UShort4);
                    constexpr.ASSUME((result.UShort5 + 1) * (result.UShort5 + 1) * (result.UShort5 + 1) > a.UShort5);
                    constexpr.ASSUME((result.UShort6 + 1) * (result.UShort6 + 1) * (result.UShort6 + 1) > a.UShort6);
                    constexpr.ASSUME((result.UShort7 + 1) * (result.UShort7 + 1) * (result.UShort7 + 1) > a.UShort7);
                    
                    constexpr.ASSUME((a.UShort0 <= 1) == (result.UShort0 == a.UShort0));
                    constexpr.ASSUME((a.UShort1 <= 1) == (result.UShort1 == a.UShort1));
                    constexpr.ASSUME((a.UShort2 <= 1) == (result.UShort2 == a.UShort2));
                    constexpr.ASSUME((a.UShort3 <= 1) == (result.UShort3 == a.UShort3));
                    constexpr.ASSUME((a.UShort4 <= 1) == (result.UShort4 == a.UShort4));
                    constexpr.ASSUME((a.UShort5 <= 1) == (result.UShort5 == a.UShort5));
                    constexpr.ASSUME((a.UShort6 <= 1) == (result.UShort6 == a.UShort6));
                    constexpr.ASSUME((a.UShort7 <= 1) == (result.UShort7 == a.UShort7));
                    
                    constexpr.ASSUME((a.UShort0 != 0) == (result.UShort0 > 0));
                    constexpr.ASSUME((a.UShort1 != 0) == (result.UShort1 > 0));
                    constexpr.ASSUME((a.UShort2 != 0) == (result.UShort2 > 0));
                    constexpr.ASSUME((a.UShort3 != 0) == (result.UShort3 > 0));
                    constexpr.ASSUME((a.UShort4 != 0) == (result.UShort4 > 0));
                    constexpr.ASSUME((a.UShort5 != 0) == (result.UShort5 > 0));
                    constexpr.ASSUME((a.UShort6 != 0) == (result.UShort6 > 0));
                    constexpr.ASSUME((a.UShort7 != 0) == (result.UShort7 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu16(v256 a, bool promiseByteRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseByteRange || constexpr.ALL_LE_EPU16(a, byte.MaxValue))
                    {
                        result = cbrt_epu8_takingAndReturning_epu16(a);
                    }
                    else
                    {
                        v256 __a = a;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = Avx.mm256_setzero_si256();

                            for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = Avx2.mm256_add_epi16(result, result);
                                v256 y3 = Avx2.mm256_add_epi16(result, mm256_slli_epi16(result, 1));
                                b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(y3, mm256_inc_epi16(result)));

                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, mm256_srli_epi16(__a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi16(b, c));
                                v256 addToY = mm256_inc_epi16(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi16(__a, subFromX);
                                result = Avx2.mm256_add_epi16(result, addToY);
                            }
                        }
                        else
                        {
                            v256 greaterEqualMask = Avx2.mm256_srai_epi16(__a, 15);
                            result = Avx2.mm256_srli_epi16(__a, 15);
                            __a = Avx2.mm256_and_si256(__a, mm256_set1_epi16(0x7FFF));
                            v256 y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(result, y4);
                            b = Avx2.mm256_add_epi16(mm256_inc_epi16(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(__a, 12));
                            v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 12));
                            v256 addToY = mm256_inc_epi16(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi16(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), mm256_inc_epi16(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(__a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 9));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi16(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), mm256_inc_epi16(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(__a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 6));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi16(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), mm256_inc_epi16(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, Avx2.mm256_srli_epi16(__a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi16(b, 3));
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi16(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = mm256_inc_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), mm256_inc_epi16(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi16(b, __a);
                            addToY = mm256_inc_epi16(greaterEqualMask);
                            result = Avx2.mm256_add_epi16(result, addToY);
                        }
                    }

                    constexpr.ASSUME_LE_EPU16(result, 40);

                    constexpr.ASSUME_LE_EPU16(result, a);
                    if (constexpr.ALL_GT_EPU16(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU16(result, a);
                    }

                    constexpr.ASSUME(result.UShort0  * result.UShort0  * result.UShort0  <= a.UShort0 );
                    constexpr.ASSUME(result.UShort1  * result.UShort1  * result.UShort1  <= a.UShort1 );
                    constexpr.ASSUME(result.UShort2  * result.UShort2  * result.UShort2  <= a.UShort2 );
                    constexpr.ASSUME(result.UShort3  * result.UShort3  * result.UShort3  <= a.UShort3 );
                    constexpr.ASSUME(result.UShort4  * result.UShort4  * result.UShort4  <= a.UShort4 );
                    constexpr.ASSUME(result.UShort5  * result.UShort5  * result.UShort5  <= a.UShort5 );
                    constexpr.ASSUME(result.UShort6  * result.UShort6  * result.UShort6  <= a.UShort6 );
                    constexpr.ASSUME(result.UShort7  * result.UShort7  * result.UShort7  <= a.UShort7 );
                    constexpr.ASSUME(result.UShort8  * result.UShort8  * result.UShort8  <= a.UShort8 );
                    constexpr.ASSUME(result.UShort9  * result.UShort9  * result.UShort9  <= a.UShort9 );
                    constexpr.ASSUME(result.UShort10 * result.UShort10 * result.UShort10 <= a.UShort10);
                    constexpr.ASSUME(result.UShort11 * result.UShort11 * result.UShort11 <= a.UShort11);
                    constexpr.ASSUME(result.UShort12 * result.UShort12 * result.UShort12 <= a.UShort12);
                    constexpr.ASSUME(result.UShort13 * result.UShort13 * result.UShort13 <= a.UShort13);
                    constexpr.ASSUME(result.UShort14 * result.UShort14 * result.UShort14 <= a.UShort14);
                    constexpr.ASSUME(result.UShort15 * result.UShort15 * result.UShort15 <= a.UShort15);
                    
                    constexpr.ASSUME((result.UShort0  + 1) * (result.UShort0  + 1) * (result.UShort0  + 1) > a.UShort0 );
                    constexpr.ASSUME((result.UShort1  + 1) * (result.UShort1  + 1) * (result.UShort1  + 1) > a.UShort1 );
                    constexpr.ASSUME((result.UShort2  + 1) * (result.UShort2  + 1) * (result.UShort2  + 1) > a.UShort2 );
                    constexpr.ASSUME((result.UShort3  + 1) * (result.UShort3  + 1) * (result.UShort3  + 1) > a.UShort3 );
                    constexpr.ASSUME((result.UShort4  + 1) * (result.UShort4  + 1) * (result.UShort4  + 1) > a.UShort4 );
                    constexpr.ASSUME((result.UShort5  + 1) * (result.UShort5  + 1) * (result.UShort5  + 1) > a.UShort5 );
                    constexpr.ASSUME((result.UShort6  + 1) * (result.UShort6  + 1) * (result.UShort6  + 1) > a.UShort6 );
                    constexpr.ASSUME((result.UShort7  + 1) * (result.UShort7  + 1) * (result.UShort7  + 1) > a.UShort7 );
                    constexpr.ASSUME((result.UShort8  + 1) * (result.UShort8  + 1) * (result.UShort8  + 1) > a.UShort8 );
                    constexpr.ASSUME((result.UShort9  + 1) * (result.UShort9  + 1) * (result.UShort9  + 1) > a.UShort9 );
                    constexpr.ASSUME((result.UShort10 + 1) * (result.UShort10 + 1) * (result.UShort10 + 1) > a.UShort10);
                    constexpr.ASSUME((result.UShort11 + 1) * (result.UShort11 + 1) * (result.UShort11 + 1) > a.UShort11);
                    constexpr.ASSUME((result.UShort12 + 1) * (result.UShort12 + 1) * (result.UShort12 + 1) > a.UShort12);
                    constexpr.ASSUME((result.UShort13 + 1) * (result.UShort13 + 1) * (result.UShort13 + 1) > a.UShort13);
                    constexpr.ASSUME((result.UShort14 + 1) * (result.UShort14 + 1) * (result.UShort14 + 1) > a.UShort14);
                    constexpr.ASSUME((result.UShort15 + 1) * (result.UShort15 + 1) * (result.UShort15 + 1) > a.UShort15);
                    
                    constexpr.ASSUME((a.UShort0  <= 1) == (result.UShort0  == a.UShort0 ));
                    constexpr.ASSUME((a.UShort1  <= 1) == (result.UShort1  == a.UShort1 ));
                    constexpr.ASSUME((a.UShort2  <= 1) == (result.UShort2  == a.UShort2 ));
                    constexpr.ASSUME((a.UShort3  <= 1) == (result.UShort3  == a.UShort3 ));
                    constexpr.ASSUME((a.UShort4  <= 1) == (result.UShort4  == a.UShort4 ));
                    constexpr.ASSUME((a.UShort5  <= 1) == (result.UShort5  == a.UShort5 ));
                    constexpr.ASSUME((a.UShort6  <= 1) == (result.UShort6  == a.UShort6 ));
                    constexpr.ASSUME((a.UShort7  <= 1) == (result.UShort7  == a.UShort7 ));
                    constexpr.ASSUME((a.UShort8  <= 1) == (result.UShort8  == a.UShort8 ));
                    constexpr.ASSUME((a.UShort9  <= 1) == (result.UShort9  == a.UShort9 ));
                    constexpr.ASSUME((a.UShort10 <= 1) == (result.UShort10 == a.UShort10));
                    constexpr.ASSUME((a.UShort11 <= 1) == (result.UShort11 == a.UShort11));
                    constexpr.ASSUME((a.UShort12 <= 1) == (result.UShort12 == a.UShort12));
                    constexpr.ASSUME((a.UShort13 <= 1) == (result.UShort13 == a.UShort13));
                    constexpr.ASSUME((a.UShort14 <= 1) == (result.UShort14 == a.UShort14));
                    constexpr.ASSUME((a.UShort15 <= 1) == (result.UShort15 == a.UShort15));
                    
                    constexpr.ASSUME((a.UShort0  != 0) == (result.UShort0  > 0));
                    constexpr.ASSUME((a.UShort1  != 0) == (result.UShort1  > 0));
                    constexpr.ASSUME((a.UShort2  != 0) == (result.UShort2  > 0));
                    constexpr.ASSUME((a.UShort3  != 0) == (result.UShort3  > 0));
                    constexpr.ASSUME((a.UShort4  != 0) == (result.UShort4  > 0));
                    constexpr.ASSUME((a.UShort5  != 0) == (result.UShort5  > 0));
                    constexpr.ASSUME((a.UShort6  != 0) == (result.UShort6  > 0));
                    constexpr.ASSUME((a.UShort7  != 0) == (result.UShort7  > 0));
                    constexpr.ASSUME((a.UShort8  != 0) == (result.UShort8  > 0));
                    constexpr.ASSUME((a.UShort9  != 0) == (result.UShort9  > 0));
                    constexpr.ASSUME((a.UShort10 != 0) == (result.UShort10 > 0));
                    constexpr.ASSUME((a.UShort11 != 0) == (result.UShort11 > 0));
                    constexpr.ASSUME((a.UShort12 != 0) == (result.UShort12 > 0));
                    constexpr.ASSUME((a.UShort13 != 0) == (result.UShort13 > 0));
                    constexpr.ASSUME((a.UShort14 != 0) == (result.UShort14 > 0));
                    constexpr.ASSUME((a.UShort15 != 0) == (result.UShort15 > 0));
                    
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi16(v128 a, bool promiseAbs = false, bool promise8BitRange = false, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI16(a, 0, elements))
                    {
                        result = cbrt_epu16(a, promise8BitRange, elements);

                        constexpr.ASSUME_RANGE_EPI16(result, 0, 32);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi16(cbrt_epu16(abs_epi16(a), promise8BitRange, elements), a);
                        }
                        else
                        {
                            v128 negative = srai_epi16(a, 15);
                            v128 cbrtAbs = cbrt_epu16(xor_si128(add_epi16(a, negative), negative), promise8BitRange, elements);

                            result = xor_si128(add_epi16(cbrtAbs, negative), negative);
                        }

                        constexpr.ASSUME_RANGE_EPI16(result, -32, 32);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi16(v256 a, bool promiseAbs = false, bool promise8BitRange = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI16(a, 0))
                    {
                        result = mm256_cbrt_epu16(a, promise8BitRange);

                        constexpr.ASSUME_RANGE_EPI16(result, 0, 32);
                    }
                    else
                    {
                        result = Avx2.mm256_sign_epi16(mm256_cbrt_epu16(mm256_abs_epi16(a), promise8BitRange), a);

                        constexpr.ASSUME_RANGE_EPI16(result, -32, 32);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu32(v128 a, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue, elements))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue, elements))
                        {
                            result = cbrt_epu8_takingAndReturning_epu16(a);
                            constexpr.ASSUME_LE_EPU32(result, 6);
                        }
                        else
                        {
                            v128 __a = a;
                            v128 b;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                result = setzero_si128();

                                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3)
                                {
                                    result = add_epi32(result, result);
                                    v128 y3 = add_epi32(result, slli_epi32(result, 1));
                                    b = inc_epi32(mullo_epi32(y3, inc_epi32(result)));

                                    v128 greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, c, inRange: true));
                                    v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, c, inRange: true));
                                    v128 addToY = inc_epi32(greaterEqualMask);
                                    __a = sub_epi32(__a, subFromX);
                                    result = add_epi32(result, addToY);
                                }
                            }
                            else
                            {
                                v128 ONE = set1_epi32(1);

                                v128 greaterEqualMask = srai_epi32(slli_epi32(__a, 16), 31);
                                v128 subFromX = and_si128(greaterEqualMask, slli_epi32(ONE, 15));
                                result = srli_epi32(__a, 15);
                                __a = sub_epi32(__a, subFromX);
                                v128 y4 = slli_epi32(result, 2);
                                result = add_epi32(result, result);
                                b = add_epi32(result, y4);
                                b = add_epi32(inc_epi32(b), and_si128(greaterEqualMask, slli_epi32(b, 1)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 12));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 12));
                                v128 addToY = inc_epi32(greaterEqualMask);
                                __a = sub_epi32(__a, subFromX);
                                result = add_epi16(result, addToY);
                                y4 = slli_epi16(result, 2);
                                result = add_epi16(result, result);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 9));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 9));
                                addToY = inc_epi32(greaterEqualMask);
                                __a = sub_epi32(__a, subFromX);
                                result = add_epi16(result, addToY);
                                y4 = slli_epi16(result, 2);
                                result = add_epi16(result, result);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                                greaterEqualMask = cmpgt_epi32(b,srli_epi32(__a, 6));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 6));
                                addToY = inc_epi32(greaterEqualMask);
                                __a = sub_epi32(__a, subFromX);
                                result = add_epi16(result, addToY);
                                y4 = slli_epi16(result, 2);
                                result = add_epi16(result, result);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                                greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 3));
                                subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 3));
                                addToY = inc_epi32(greaterEqualMask);
                                __a = sub_epi32(__a, subFromX);
                                result = add_epi16(result, addToY);
                                y4 = slli_epi16(result, 2);
                                result = add_epi16(result, result);
                                b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                                greaterEqualMask = cmpgt_epi32(b, __a);
                                addToY = inc_epi32(greaterEqualMask);
                                result = add_epi32(result, addToY);
                            }

                            constexpr.ASSUME_LE_EPU32(result, 40);
                        }
                    }
                    else
                    {
                        v128 __a = a;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = setzero_si128();

                            for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = add_epi32(result, result);
                                v128 y3 = add_epi32(result, slli_epi32(result, 1));
                                b = inc_epi32(mullo_epi32(y3, inc_epi32(result)));

                                v128 greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, c, inRange: true));
                                v128 addToY = inc_epi32(greaterEqualMask);
                                __a = sub_epi32(__a, subFromX);
                                result = add_epi32(result, addToY);
                            }
                        }
                        else
                        {
                            v128 ONE = set1_epi32(1);

                            v128 greaterEqualMask = cmpgt_epi32(ONE, srli_epi32(__a, 30));
                            v128 subFromX = andnot_si128(greaterEqualMask, slli_epi32(ONE, 30));
                            result = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            v128 y4 = slli_epi32(result, 2);
                            result = add_epi32(result, result);
                            b = add_epi32(result, y4);
                            b = add_epi32(inc_epi32(b), andnot_si128(greaterEqualMask, slli_epi32(b, 1)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 27));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 27));
                            v128 addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 24));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 24));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 21));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 21));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 18));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 18));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 15));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 15));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 12));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 12));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi32(result, addToY);
                            y4 = slli_epi32(result, 2);
                            result = add_epi32(result, result);
                            b = inc_epi32(mullo_epi32(add_epi32(result, y4), inc_epi32(result), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 9));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi32(result, addToY);
                            y4 = slli_epi32(result, 2);
                            result = add_epi32(result, result);
                            b = inc_epi32(mullo_epi32(add_epi32(result, y4), inc_epi32(result), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 6));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi32(result, addToY);
                            y4 = slli_epi32(result, 2);
                            result = add_epi32(result, result);
                            b = inc_epi32(mullo_epi32(add_epi32(result, y4), inc_epi32(result), elements));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi32(__a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi32(b, 3));
                            addToY = inc_epi32(greaterEqualMask);
                            __a = sub_epi32(__a, subFromX);
                            result = add_epi32(result, addToY);
                            y4 = slli_epi32(result, 2);
                            result = add_epi32(result, result);
                            b = inc_epi32(mullo_epi32(add_epi32(result, y4), inc_epi32(result), elements));

                            greaterEqualMask = cmpgt_epi32(b, __a);
                            addToY = inc_epi32(greaterEqualMask);
                            result = add_epi32(result, addToY);
                        }

                        constexpr.ASSUME_LE_EPU32(result, 1_625);
                    }

                    constexpr.ASSUME_LE_EPU32(result, a, elements);
                    if (constexpr.ALL_GT_EPU32(a, 1, elements))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a, elements);
                    }

                    constexpr.ASSUME(result.UInt0 * result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 * result.UInt3 <= a.UInt3);
                    
                    constexpr.ASSUME((ulong)(result.UInt0 + 1) * (result.UInt0 + 1) * (result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME((ulong)(result.UInt1 + 1) * (result.UInt1 + 1) * (result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME((ulong)(result.UInt2 + 1) * (result.UInt2 + 1) * (result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME((ulong)(result.UInt3 + 1) * (result.UInt3 + 1) * (result.UInt3 + 1) > a.UInt3);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu32(v256 a, byte rangePromiseLevel = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU32(a, ushort.MaxValue))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU32(a, byte.MaxValue))
                        {
                            result = cbrt_epu8_takingAndReturning_epu16(a);
                            constexpr.ASSUME_LE_EPU32(result, 6);
                        }
                        else
                        {
                            v256 __a = a;
                            v256 b;
                            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                            {
                                result = Avx.mm256_setzero_si256();

                                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3)
                                {
                                    result = Avx2.mm256_add_epi32(result, result);
                                    v256 y3 = Avx2.mm256_add_epi32(result, mm256_slli_epi32(result, 1));
                                    b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(y3, mm256_inc_epi32(result)));

                                    v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, mm256_srli_epi32(__a, c));
                                    v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi32(b, c));
                                    v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                    __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                    result = Avx2.mm256_add_epi32(result, addToY);
                                }
                            }
                            else
                            {
                                v256 ONE = mm256_set1_epi32(1);

                                v256 greaterEqualMask = Avx2.mm256_srai_epi32(Avx2.mm256_slli_epi32(__a, 16), 31);
                                v256 subFromX = Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi16(ONE, 15));
                                result = Avx2.mm256_srli_epi32(__a, 15);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                v256 y4 = Avx2.mm256_slli_epi32(result, 2);
                                result = Avx2.mm256_add_epi32(result, result);
                                b = Avx2.mm256_add_epi32(result, y4);
                                b = Avx2.mm256_add_epi32(mm256_inc_epi32(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 1)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 12));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 12));
                                v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                result = Avx2.mm256_add_epi16(result, addToY);
                                y4 = Avx2.mm256_slli_epi16(result, 2);
                                result = Avx2.mm256_add_epi16(result, result);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 9));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 9));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                result = Avx2.mm256_add_epi16(result, addToY);
                                y4 = Avx2.mm256_slli_epi16(result, 2);
                                result = Avx2.mm256_add_epi16(result, result);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 6));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 6));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                result = Avx2.mm256_add_epi16(result, addToY);
                                y4 = Avx2.mm256_slli_epi16(result, 2);
                                result = Avx2.mm256_add_epi16(result, result);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 3));
                                subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                result = Avx2.mm256_add_epi16(result, addToY);
                                y4 = Avx2.mm256_slli_epi16(result, 2);
                                result = Avx2.mm256_add_epi16(result, result);
                                b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                                greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, __a);
                                addToY = mm256_inc_epi32(greaterEqualMask);
                                result = Avx2.mm256_add_epi32(result, addToY);
                            }

                            constexpr.ASSUME_LE_EPU32(result, 40);
                        }
                    }
                    else
                    {
                        v256 __a = a;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = Avx.mm256_setzero_si256();

                            for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = Avx2.mm256_add_epi32(result, result);
                                v256 y3 = Avx2.mm256_add_epi32(result, mm256_slli_epi32(result, 1));
                                b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(y3, mm256_inc_epi32(result)));

                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, mm256_srli_epi32(__a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi32(b, c));
                                v256 addToY = mm256_inc_epi32(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi32(__a, subFromX);
                                result = Avx2.mm256_add_epi32(result, addToY);
                            }
                        }
                        else
                        {
                            v256 ONE = mm256_set1_epi32(1);

                            v256 greaterEqualMask = Avx2.mm256_cmpgt_epi32(ONE, Avx2.mm256_srli_epi32(__a, 30));
                            v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(ONE, 30));
                            result = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            v256 y4 = Avx2.mm256_slli_epi32(result, 2);
                            result = Avx2.mm256_add_epi32(result, result);
                            b = Avx2.mm256_add_epi32(result, y4);
                            b = Avx2.mm256_add_epi32(mm256_inc_epi32(b), Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 27));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 27));
                            v256 addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 24));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 24));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 21));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 21));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 18));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 18));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 15));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 15));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 12));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 12));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi32(result, addToY);
                            y4 = Avx2.mm256_slli_epi32(result, 2);
                            result = Avx2.mm256_add_epi32(result, result);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(result, y4), mm256_inc_epi32(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 9));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi32(result, addToY);
                            y4 = Avx2.mm256_slli_epi32(result, 2);
                            result = Avx2.mm256_add_epi32(result, result);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(result, y4), mm256_inc_epi32(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 6));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi32(result, addToY);
                            y4 = Avx2.mm256_slli_epi32(result, 2);
                            result = Avx2.mm256_add_epi32(result, result);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(result, y4), mm256_inc_epi32(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi32(__a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi32(b, 3));
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            __a = Avx2.mm256_sub_epi32(__a, subFromX);
                            result = Avx2.mm256_add_epi32(result, addToY);
                            y4 = Avx2.mm256_slli_epi32(result, 2);
                            result = Avx2.mm256_add_epi32(result, result);
                            b = mm256_inc_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_add_epi32(result, y4), mm256_inc_epi32(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, __a);
                            addToY = mm256_inc_epi32(greaterEqualMask);
                            result = Avx2.mm256_add_epi32(result, addToY);
                        }

                        constexpr.ASSUME_LE_EPU32(result, 1_625);
                    }

                    constexpr.ASSUME_LE_EPU32(result, a);
                    if (constexpr.ALL_GT_EPU32(a, 1))
                    {
                        constexpr.ASSUME_LT_EPU32(result, a);
                    }

                    constexpr.ASSUME(result.UInt0 * result.UInt0 * result.UInt0 <= a.UInt0);
                    constexpr.ASSUME(result.UInt1 * result.UInt1 * result.UInt1 <= a.UInt1);
                    constexpr.ASSUME(result.UInt2 * result.UInt2 * result.UInt2 <= a.UInt2);
                    constexpr.ASSUME(result.UInt3 * result.UInt3 * result.UInt3 <= a.UInt3);
                    constexpr.ASSUME(result.UInt4 * result.UInt4 * result.UInt4 <= a.UInt4);
                    constexpr.ASSUME(result.UInt5 * result.UInt5 * result.UInt5 <= a.UInt5);
                    constexpr.ASSUME(result.UInt6 * result.UInt6 * result.UInt6 <= a.UInt6);
                    constexpr.ASSUME(result.UInt7 * result.UInt7 * result.UInt7 <= a.UInt7);
                    
                    constexpr.ASSUME((ulong)(result.UInt0 + 1) * (result.UInt0 + 1) * (result.UInt0 + 1) > a.UInt0);
                    constexpr.ASSUME((ulong)(result.UInt1 + 1) * (result.UInt1 + 1) * (result.UInt1 + 1) > a.UInt1);
                    constexpr.ASSUME((ulong)(result.UInt2 + 1) * (result.UInt2 + 1) * (result.UInt2 + 1) > a.UInt2);
                    constexpr.ASSUME((ulong)(result.UInt3 + 1) * (result.UInt3 + 1) * (result.UInt3 + 1) > a.UInt3);
                    constexpr.ASSUME((ulong)(result.UInt4 + 1) * (result.UInt4 + 1) * (result.UInt4 + 1) > a.UInt4);
                    constexpr.ASSUME((ulong)(result.UInt5 + 1) * (result.UInt5 + 1) * (result.UInt5 + 1) > a.UInt5);
                    constexpr.ASSUME((ulong)(result.UInt6 + 1) * (result.UInt6 + 1) * (result.UInt6 + 1) > a.UInt6);
                    constexpr.ASSUME((ulong)(result.UInt7 + 1) * (result.UInt7 + 1) * (result.UInt7 + 1) > a.UInt7);
                    
                    constexpr.ASSUME((a.UInt0 <= 1) == (result.UInt0 == a.UInt0));
                    constexpr.ASSUME((a.UInt1 <= 1) == (result.UInt1 == a.UInt1));
                    constexpr.ASSUME((a.UInt2 <= 1) == (result.UInt2 == a.UInt2));
                    constexpr.ASSUME((a.UInt3 <= 1) == (result.UInt3 == a.UInt3));
                    constexpr.ASSUME((a.UInt4 <= 1) == (result.UInt4 == a.UInt4));
                    constexpr.ASSUME((a.UInt5 <= 1) == (result.UInt5 == a.UInt5));
                    constexpr.ASSUME((a.UInt6 <= 1) == (result.UInt6 == a.UInt6));
                    constexpr.ASSUME((a.UInt7 <= 1) == (result.UInt7 == a.UInt7));
                    
                    constexpr.ASSUME((a.UInt0 != 0) == (result.UInt0 > 0));
                    constexpr.ASSUME((a.UInt1 != 0) == (result.UInt1 > 0));
                    constexpr.ASSUME((a.UInt2 != 0) == (result.UInt2 > 0));
                    constexpr.ASSUME((a.UInt3 != 0) == (result.UInt3 > 0));
                    constexpr.ASSUME((a.UInt4 != 0) == (result.UInt4 > 0));
                    constexpr.ASSUME((a.UInt5 != 0) == (result.UInt5 > 0));
                    constexpr.ASSUME((a.UInt6 != 0) == (result.UInt6 > 0));
                    constexpr.ASSUME((a.UInt7 != 0) == (result.UInt7 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi32(v128 a, bool promiseAbs = false, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI32(a, 0, elements))
                    {
                        result = cbrt_epu32(a, rangePromiseLevel, elements);

                        constexpr.ASSUME_RANGE_EPI32(result, 0, 1_290);
                    }
                    else
                    {
                        if (Ssse3.IsSsse3Supported)
                        {
                            result = sign_epi32(cbrt_epu32(abs_epi32(a), rangePromiseLevel, elements), a);
                        }
                        else
                        {
                            v128 negative = srai_epi32(a, 31);
                            v128 cbrtAbs = cbrt_epu32(xor_si128(add_epi32(a, negative), negative), rangePromiseLevel, elements);

                            result = xor_si128(add_epi32(cbrtAbs, negative), negative);
                        }

                        constexpr.ASSUME_RANGE_EPI32(result, -1_290, 1_290);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi32(v256 a, bool promiseAbs = false, byte rangePromiseLevel = 0)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI32(a, 0))
                    {
                        result = mm256_cbrt_epu32(a);

                        constexpr.ASSUME_RANGE_EPI32(result, 0, 1_290);
                    }
                    else
                    {
                        result = Avx2.mm256_sign_epi32(mm256_cbrt_epu32(mm256_abs_epi32(a), rangePromiseLevel), a);

                        constexpr.ASSUME_RANGE_EPI32(result, -1_290, 1_290);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epu64(v128 a, byte rangePromiseLevel = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 48))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue))
                        {
                            if (rangePromiseLevel > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue))
                            {
                                if (rangePromiseLevel > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue))
                                {
                                    result = cbrt_epu8_takingAndReturning_epu16(a, 8);
                                    constexpr.ASSUME_LE_EPU64(result, 6);
                                }
                                else
                                {
                                    result = cbrt_epu16(a);
                                    constexpr.ASSUME_LE_EPU64(result, 40);
                                }
                            }
                            else
                            {
                                result = cbrt_epu32(a, 0, 4);
                                constexpr.ASSUME_LE_EPU64(result, 1_625);
                            }
                        }
                        else
                        {
                            // results within [0, 1ul << 48] have been proven to be correct empirically both with and without FMA instructions
                            result = cvttpd_epu64(cbrt_pd(usfcvtepu64_pd(a), promisePositive: true, promiseNormalized: true));

                            constexpr.ASSUME_LE_EPU64(result, 65536 /*maxintcbrt(1ul << 48)*/);
                        }
                    }
                    else
                    {
                        v128 __a = a;
                        v128 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = setzero_si128();

                            for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = add_epi64(result, result);
                                v128 y3 = add_epi64(result, slli_epi64(result, 1));
                                b = inc_epi64(mul_epu32(y3, inc_epi64(result)));

                                v128 greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, c, inRange: true));
                                v128 subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, c, inRange: true));
                                v128 addToY = inc_epi64(greaterEqualMask);
                                __a = sub_epi64(__a, subFromX);
                                result = add_epi64(result, addToY);
                            }
                        }
                        else
                        {
                            v128 ONE = set1_epi64x(1);

                            result = srli_epi64(__a, 63);
                            v128 greaterEqualMask = neg_epi64(result);
                            __a = and_si128(__a, set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                            v128 y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = add_epi64(result, y4);
                            b = add_epi64(inc_epi64(b), and_si128(greaterEqualMask, slli_epi64(b, 1)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 60));
                            v128 subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 60));
                            v128 addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 57));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 57));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 54));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 54));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 51));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 51));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 48));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 48));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi16(result, addToY);
                            y4 = slli_epi16(result, 2);
                            result = add_epi16(result, result);
                            b = add_epi16(ONE, mullo_epi16(add_epi16(result, y4), add_epi16(ONE, result))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 45));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 45));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 42));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 42));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 39));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 39));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 36));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 36));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi32(b, srli_epi64(__a, 33));
                            subFromX = andnot_si128(shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), slli_epi64(b, 33));
                            addToY   = andnot_si128(greaterEqualMask, ONE);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 30));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 30));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 27));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 27));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 24));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 24));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 21));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 21));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 18));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 18));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 15));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 15));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 12));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 12));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 9));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 9));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 6));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 6));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, srli_epi64(__a, 3));
                            subFromX = andnot_si128(greaterEqualMask, slli_epi64(b, 3));
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            __a = sub_epi64(__a, subFromX);
                            result = add_epi64(result, addToY);
                            y4 = slli_epi64(result, 2);
                            result = add_epi64(result, result);
                            b = inc_epi64(mul_epu32(add_epi64(result, y4), inc_epi64(result)));

                            greaterEqualMask = cmpgt_epi64(b, __a);
                            addToY   = add_epi64(ONE, greaterEqualMask);
                            result = add_epi64(result, addToY);
                        }

                        constexpr.ASSUME_LE_EPU64(result, 2_642_245);
                    }

                    constexpr.ASSUME_LE_EPU64(result, a);
                    if (constexpr.ALL_GT_EPU64(a, 1))
                    {
                        constexpr.ASSUME_LE_EPU64(result, a);
                    }

                    constexpr.ASSUME(result.ULong0 * result.ULong0 * result.ULong0 <= a.ULong0);
                    constexpr.ASSUME(result.ULong1 * result.ULong1 * result.ULong1 <= a.ULong1);
                    
                    constexpr.ASSUME((UInt128)(result.ULong0 + 1) * (result.ULong0 + 1) * (result.ULong0 + 1) > a.ULong0);
                    constexpr.ASSUME((UInt128)(result.ULong1 + 1) * (result.ULong1 + 1) * (result.ULong1 + 1) > a.ULong1);
                    
                    constexpr.ASSUME((a.ULong0 <= 1) == (result.ULong0 == a.ULong0));
                    constexpr.ASSUME((a.ULong1 <= 1) == (result.ULong1 == a.ULong1));
                    
                    constexpr.ASSUME((a.ULong0 != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((a.ULong1 != 0) == (result.ULong1 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epu64(v256 a, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (rangePromiseLevel > 0 || constexpr.ALL_LE_EPU64(a, 1ul << 48, elements))
                    {
                        if (rangePromiseLevel > 1 || constexpr.ALL_LE_EPU64(a, uint.MaxValue, elements))
                        {
                            if (rangePromiseLevel > 2 || constexpr.ALL_LE_EPU64(a, ushort.MaxValue, elements))
                            {
                                if (rangePromiseLevel > 3 || constexpr.ALL_LE_EPU64(a, byte.MaxValue, elements))
                                {
                                    result = cbrt_epu8_takingAndReturning_epu16(a);
                                    constexpr.ASSUME_LE_EPU64(result, 6);
                                }
                                else
                                {
                                    result = mm256_cbrt_epu16(a);
                                    constexpr.ASSUME_LE_EPU64(result, 40);
                                }
                            }
                            else
                            {
                                result = mm256_cbrt_epu32(a);
                                constexpr.ASSUME_LE_EPU64(result, 1_625);
                            }
                        }
                        else
                        {
                            // results within [0, 1ul << 48] have been proven to be correct empirically both with and without FMA instructions
                            result = mm256_cvttpd_epu64(mm256_cbrt_pd(mm256_usfcvtepu64_pd(a), promisePositive: true, promiseNormalized: true), elements);

                            constexpr.ASSUME_LE_EPU64(result, 65536 /*maxintcbrt(1ul << 48)*/, elements);
                        }
                    }
                    else
                    {
                        v256 __a = a;
                        v256 b;
                        if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
                        {
                            result = Avx.mm256_setzero_si256();

                            for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3)
                            {
                                result = Avx2.mm256_add_epi64(result, result);
                                v256 y3 = Avx2.mm256_add_epi64(result, mm256_slli_epi64(result, 1));
                                b = mm256_inc_epi64(Avx2.mm256_mul_epu32(y3, mm256_inc_epi64(result)));

                                v256 greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, mm256_srli_epi64(__a, c));
                                v256 subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, mm256_slli_epi64(b, c));
                                v256 addToY = mm256_inc_epi64(greaterEqualMask);
                                __a = Avx2.mm256_sub_epi64(__a, subFromX);
                                result = Avx2.mm256_add_epi64(result, addToY);
                            }
                        }
                        else
                        {
                            v256 ONE = mm256_set1_epi64x(1);

                            result = Avx2.mm256_srli_epi64(__a, 63);
                            v256 greaterEqualMask = mm256_neg_epi64(result);
                            __a = Avx2.mm256_and_si256(__a, mm256_set1_epi64x(0x7FFF_FFFF_FFFF_FFFF));
                            v256 y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = Avx2.mm256_add_epi64(result, y4);
                            b = Avx2.mm256_add_epi64(mm256_inc_epi64(b), Avx2.mm256_and_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 1)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 60));
                            v256 subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 60));
                            v256 addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 57));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 57));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 54));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 54));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 51));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 51));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 48));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 48));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi16(result, addToY);
                            y4 = Avx2.mm256_slli_epi16(result, 2);
                            result = Avx2.mm256_add_epi16(result, result);
                            b = Avx2.mm256_add_epi16(ONE, Avx2.mm256_mullo_epi16(Avx2.mm256_add_epi16(result, y4), Avx2.mm256_add_epi16(ONE, result))); // max(y) = 126    =>     3y * (y + 1)    ^=     last safe 16 bit multiplication

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 45));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 45));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 42));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 42));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 39));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 39));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 36));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 36));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi32(b, Avx2.mm256_srli_epi64(__a, 33));
                            subFromX = Avx2.mm256_andnot_si256(Avx2.mm256_shuffle_epi32(greaterEqualMask, Sse.SHUFFLE(2, 2, 0, 0)), Avx2.mm256_slli_epi64(b, 33));
                            addToY   = Avx2.mm256_andnot_si256(greaterEqualMask, ONE);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 30));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 30));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 27));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 27));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 24));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 24));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 21));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 21));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 18));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 18));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 15));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 15));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 12));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 12));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 9));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 9));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 6));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 6));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, Avx2.mm256_srli_epi64(__a, 3));
                            subFromX = Avx2.mm256_andnot_si256(greaterEqualMask, Avx2.mm256_slli_epi64(b, 3));
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            __a = Avx2.mm256_sub_epi64(__a, subFromX);
                            result = Avx2.mm256_add_epi64(result, addToY);
                            y4 = Avx2.mm256_slli_epi64(result, 2);
                            result = Avx2.mm256_add_epi64(result, result);
                            b = mm256_inc_epi64(Avx2.mm256_mul_epu32(Avx2.mm256_add_epi64(result, y4), mm256_inc_epi64(result)));

                            greaterEqualMask = Avx2.mm256_cmpgt_epi64(b, __a);
                            addToY   = Avx2.mm256_add_epi64(ONE, greaterEqualMask);
                            result = Avx2.mm256_add_epi64(result, addToY);
                        }

                        constexpr.ASSUME_LE_EPU64(result, 2_642_245);
                    }

                    constexpr.ASSUME_LE_EPU64(result, a, elements);
                    if (constexpr.ALL_GT_EPU64(a, 1, elements))
                    {
                        constexpr.ASSUME_LE_EPU64(result, a, elements);
                    }

                    constexpr.ASSUME(result.ULong0 * result.ULong0 * result.ULong0 <= a.ULong0);
                    constexpr.ASSUME(result.ULong1 * result.ULong1 * result.ULong1 <= a.ULong1);
                    constexpr.ASSUME(result.ULong2 * result.ULong2 * result.ULong2 <= a.ULong2);
                    constexpr.ASSUME(result.ULong3 * result.ULong3 * result.ULong3 <= a.ULong3);
                    
                    constexpr.ASSUME((UInt128)(result.ULong0 + 1) * (result.ULong0 + 1) * (result.ULong0 + 1) > a.ULong0);
                    constexpr.ASSUME((UInt128)(result.ULong1 + 1) * (result.ULong1 + 1) * (result.ULong1 + 1) > a.ULong1);
                    constexpr.ASSUME((UInt128)(result.ULong2 + 1) * (result.ULong2 + 1) * (result.ULong2 + 1) > a.ULong2);
                    constexpr.ASSUME((UInt128)(result.ULong3 + 1) * (result.ULong3 + 1) * (result.ULong3 + 1) > a.ULong3);
                    
                    constexpr.ASSUME((a.ULong0 <= 1) == (result.ULong0 == a.ULong0));
                    constexpr.ASSUME((a.ULong1 <= 1) == (result.ULong1 == a.ULong1));
                    constexpr.ASSUME((a.ULong2 <= 1) == (result.ULong2 == a.ULong2));
                    constexpr.ASSUME((a.ULong3 <= 1) == (result.ULong3 == a.ULong3));
                    
                    constexpr.ASSUME((a.ULong0 != 0) == (result.ULong0 > 0));
                    constexpr.ASSUME((a.ULong1 != 0) == (result.ULong1 > 0));
                    constexpr.ASSUME((a.ULong2 != 0) == (result.ULong2 > 0));
                    constexpr.ASSUME((a.ULong3 != 0) == (result.ULong3 > 0));

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cbrt_epi64(v128 a, bool promiseAbs = false, byte rangePromiseLevel = 0)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0))
                    {
                        result = cbrt_epu64(a, rangePromiseLevel);

                        constexpr.ASSUME_RANGE_EPI64(result, 0, 2_097_152);
                    }
                    else
                    {
                        v128 negative = srai_epi64(a, 63);
                        v128 cbrtAbs = cbrt_epu64(xor_si128(add_epi64(a, negative), negative), rangePromiseLevel);

                        result = xor_si128(add_epi64(cbrtAbs, negative), negative);

                        constexpr.ASSUME_RANGE_EPI64(result, -2_097_152, 2_097_152);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cbrt_epi64(v256 a, bool promiseAbs = false, byte rangePromiseLevel = 0, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (promiseAbs || constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        result = mm256_cbrt_epu64(a, rangePromiseLevel, elements);

                        constexpr.ASSUME_RANGE_EPI64(result, 0, 2_097_152);
                    }
                    else
                    {
                        v256 negative = mm256_srai_epi64(a, 63, elements);
                        v256 cbrtAbs = mm256_cbrt_epu64(Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(a, negative), negative), rangePromiseLevel, elements);

                        result = Avx2.mm256_xor_si256(Avx2.mm256_add_epi64(cbrtAbs, negative), negative);

                        constexpr.ASSUME_RANGE_EPI64(result, -2_097_152, 2_097_152);
                    }

                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class math
    {
        /// <summary>       Computes the integer cube root ⌊∛<paramref name="__x"/>⌋ of a <see cref="UInt128"/>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 6_981_463_658_331ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intcbrt(UInt128 x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x.hi64 == 0))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt(x.lo64, promises);
            }

            UInt128 __x = x;
            ulong y = 0;
            UInt128 b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(UInt128) * 8 / 3 * 3; c >= 0; c -= 3)
                {
                    y += y;
                    b = ((UInt128)(3 * y) * (y + 1)) + 1;
                    if (__x >> c >= b)
                    {
                        __x -= b << c;
                        y++;
                    }
                }
            }
            else
            {
                b = (UInt128)1 << 126;

                if ((__x.hi64 >> (126 - 64)) != 0)
                {
                    __x -= b;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (123 - 64)) >= b.lo64)
                {
                    __x -= b << 123;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (120 - 64)) >= b.lo64)
                {
                    __x -= b << 120;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (117 - 64)) >= b.lo64)
                {
                    __x -= b << 117;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (114 - 64)) >= b.lo64)
                {
                    __x -= b << 114;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (111 - 64)) >= b.lo64)
                {
                    __x -= b << 111;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (108 - 64)) >= b.lo64)
                {
                    __x -= b << 108;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (105 - 64)) >= b.lo64)
                {
                    __x -= b << 105;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (102 - 64)) >= b.lo64)
                {
                    __x -= b << 102;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (99 - 64)) >= b.lo64)
                {
                    __x -= b << 99;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (96 - 64)) >= b.lo64)
                {
                    __x -= b << 96;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (93 - 64)) >= b.lo64)
                {
                    __x -= b << 93;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (90 - 64)) >= b.lo64)
                {
                    __x -= b << 90;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (87 - 64)) >= b.lo64)
                {
                    __x -= b << 87;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (84 - 64)) >= b.lo64)
                {
                    __x -= b << 84;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (81 - 64)) >= b.lo64)
                {
                    __x -= b << 81;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (78 - 64)) >= b.lo64)
                {
                    __x -= b << 78;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (75 - 64)) >= b.lo64)
                {
                    __x -= b << 75;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (72 - 64)) >= b.lo64)
                {
                    __x -= b << 72;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (69 - 64)) >= b.lo64)
                {
                    __x -= b << 69;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x.hi64 >> (66 - 64)) >= b.lo64)
                {
                    __x -= b << 66;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 63) >= b.lo64)
                {
                    __x -= b << 63;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 60) >= b.lo64)
                {
                    __x -= b << 60;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 57) >= b.lo64)
                {
                    __x -= b << 57;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 54) >= b.lo64)
                {
                    __x -= b << 54;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 51) >= b.lo64)
                {
                    __x -= b << 51;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 48) >= b.lo64)
                {
                    __x -= b << 48;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 45) >= b.lo64)
                {
                    __x -= b << 45;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 42) >= b.lo64)
                {
                    __x -= b << 42;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 39) >= b.lo64)
                {
                    __x -= b << 39;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;    // ((1704458887ul * 3) * (1704458887ul + 1)) + 1 at max; last safe ulong

                if ((__x >> 36) >= b.lo64)
                {
                    __x -= b << 36;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 33) >= b)
                {
                    __x -= b << 33;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 30) >= b)
                {
                    __x -= b << 30;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 27) >= b)
                {
                    __x -= b << 27;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 24) >= b)
                {
                    __x -= b << 24;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 21) >= b)
                {
                    __x -= b << 21;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 18) >= b)
                {
                    __x -= b << 18;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 15) >= b)
                {
                    __x -= b << 15;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 12) >= b)
                {
                    __x -= b << 12;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 9) >= b)
                {
                    __x -= b << 9;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 6) >= b)
                {
                    __x -= b << 6;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                if ((__x >> 3) >= b)
                {
                    __x -= b << 3;
                    y++;
                }

                y += y;
                b = 1 + UInt128.umul128(3 * y, y + 1);

                y += tobyte(__x >= b);
            }
            
            //constexpr.ASSUME(y * y * y <= x);
            //constexpr.ASSUME((y + 1) * (y + 1) * (y + 1) > x);
            constexpr.ASSUME(y <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(y < x);
            }
            constexpr.ASSUME((x <= 1) == (x == y));
            constexpr.ASSUME((x != 0) == (y > 0));
            if (constexpr.IS_TRUE(ispow2(x) && ((uint)intlog2(x) % 3u == 0)))
            {
                constexpr.ASSUME(ispow2(y));
            }

            return y;
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="Int128"/>
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ulong.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ulong.MaxValue"/>, <see cref="ulong.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-5_541_191_377_756L, 5_541_191_377_756L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intcbrt(Int128 x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                promises.DemoteUnsafeLevels();
                promises |= Promise.ZeroOrGreater;

                return (long)intcbrt((UInt128)x, promises);
            }
            else
            {
                bool negative = (long)x.hi64 < 0;
                ulong cbrtAbs = intcbrt((UInt128)abs(x), promises);

                return select((long)cbrtAbs, -(long)cbrtAbs, negative);
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte"/>.   </summary>
        [return: AssumeRange(0ul, 6ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte intcbrt(byte x)
        {
            uint __x = x;
            uint y = 0;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(byte) * 8 / 3 * 3; c >= 0; c -= 3)
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (__x >> c >= b)
                    {
                        __x -= b << c;
                        y++;
                    }
                }
            }
            else
            {
                b = 1;

                if ((__x >> 6) != 0)
                {
                    __x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 3) >= b)
                {
                    __x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(__x >= b);
            }

            constexpr.ASSUME(y * y * y <= x);
            constexpr.ASSUME((y + 1) * (y + 1) * (y + 1) > x);
            constexpr.ASSUME(y <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(y < x);
            }
            constexpr.ASSUME((x <= 1) == (x == y));
            constexpr.ASSUME((x != 0) == (y > 0));
            if (constexpr.IS_TRUE(ispow2(x) && ((uint)intlog2(x) % 3u == 0)))
            {
                constexpr.ASSUME(ispow2(y));
            }

            return (byte)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intcbrt(byte2 x, Promise absSByteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new byte2(intcbrt(x.x), intcbrt(x.y));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intcbrt(byte3 x, Promise absSByteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new byte3(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intcbrt(byte4 x, Promise absSByteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new byte4(intcbrt(x.x), intcbrt(x.y), intcbrt(x.z), intcbrt(x.w));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intcbrt(byte8 x, Promise absSByteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new byte8(intcbrt(x.x0),
                                 intcbrt(x.x1),
                                 intcbrt(x.x2),
                                 intcbrt(x.x3),
                                 intcbrt(x.x4),
                                 intcbrt(x.x5),
                                 intcbrt(x.x6),
                                 intcbrt(x.x7));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte16"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intcbrt(byte16 x, Promise absSByteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0), 16);
            }
            else
            {
                return new byte16(intcbrt(x.x0),
                                  intcbrt(x.x1),
                                  intcbrt(x.x2),
                                  intcbrt(x.x3),
                                  intcbrt(x.x4),
                                  intcbrt(x.x5),
                                  intcbrt(x.x6),
                                  intcbrt(x.x7),
                                  intcbrt(x.x8),
                                  intcbrt(x.x9),
                                  intcbrt(x.x10),
                                  intcbrt(x.x11),
                                  intcbrt(x.x12),
                                  intcbrt(x.x13),
                                  intcbrt(x.x14),
                                  intcbrt(x.x15));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="byte32"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="absSByteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="sbyte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intcbrt(byte32 x, Promise absSByteRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu8(x, absSByteRange.Promises(Promise.Unsafe0));
            }
            else
            {
                return new byte32(intcbrt(x.v16_0, absSByteRange), intcbrt(x.v16_16, absSByteRange));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-5, 5)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte intcbrt(sbyte x, Promise nonNegative = Promise.Nothing)
        {
            if (nonNegative.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (sbyte)intcbrt((byte)x);
            }
            else
            {
                bool negative = x < 0;
                byte cbrtAbs = intcbrt((byte)select(x, -x, negative));

                return select((sbyte)cbrtAbs, (sbyte)-(sbyte)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intcbrt(sbyte2 x, Promise nonNegative = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 2);
            }
            else
            {
                return new sbyte2(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intcbrt(sbyte3 x, Promise nonNegative = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 3);
            }
            else
            {
                return new sbyte3(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intcbrt(sbyte4 x, Promise nonNegative = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 4);
            }
            else
            {
                return new sbyte4(intcbrt(x.x, nonNegative), intcbrt(x.y, nonNegative),  intcbrt(x.z, nonNegative),  intcbrt(x.w, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intcbrt(sbyte8 x, Promise nonNegative = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 8);
            }
            else
            {
                return new sbyte8(intcbrt(x.x0, nonNegative),
                                  intcbrt(x.x1, nonNegative),
                                  intcbrt(x.x2, nonNegative),
                                  intcbrt(x.x3, nonNegative),
                                  intcbrt(x.x4, nonNegative),
                                  intcbrt(x.x5, nonNegative),
                                  intcbrt(x.x6, nonNegative),
                                  intcbrt(x.x7, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte16"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intcbrt(sbyte16 x, Promise nonNegative = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater), 16);
            }
            else
            {
                return new sbyte16(intcbrt(x.x0,  nonNegative),
                                   intcbrt(x.x1,  nonNegative),
                                   intcbrt(x.x2,  nonNegative),
                                   intcbrt(x.x3,  nonNegative),
                                   intcbrt(x.x4,  nonNegative),
                                   intcbrt(x.x5,  nonNegative),
                                   intcbrt(x.x6,  nonNegative),
                                   intcbrt(x.x7,  nonNegative),
                                   intcbrt(x.x8,  nonNegative),
                                   intcbrt(x.x9,  nonNegative),
                                   intcbrt(x.x10, nonNegative),
                                   intcbrt(x.x11, nonNegative),
                                   intcbrt(x.x12, nonNegative),
                                   intcbrt(x.x13, nonNegative),
                                   intcbrt(x.x14, nonNegative),
                                   intcbrt(x.x15, nonNegative));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="sbyte32"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="nonNegative"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intcbrt(sbyte32 x, Promise nonNegative = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi8(x, nonNegative.Promises(Promise.ZeroOrGreater));
            }
            else
            {
                return new sbyte32(intcbrt(x.v16_0, nonNegative), intcbrt(x.v16_16, nonNegative));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 40ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort intcbrt(ushort x, Promise byteRange = Promise.Nothing)
        {
            if (byteRange.Promises(Promise.Unsafe0) || constexpr.IS_TRUE(x <= byte.MaxValue))
            {
                return intcbrt((byte)x);
            }

            uint __x = x;
            uint y;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                y = 0;

                for (int c = sizeof(ushort) * 8 / 3 * 3; c >= 0; c -= 3)
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (__x >> c >= b)
                    {
                        __x -= b << c;
                        y++;
                    }
                }
            }
            else
            {
                y = __x >> 15;
                __x &= 0x7FFF;

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 12) >= b)
                {
                    __x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 9) >= b)
                {
                    __x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 6) >= b)
                {
                    __x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 3) >= b)
                {
                    __x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(__x >= b);
            }

            constexpr.ASSUME(y * y * y <= x);
            constexpr.ASSUME((y + 1) * (y + 1) * (y + 1) > x);
            constexpr.ASSUME(y <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(y < x);
            }
            constexpr.ASSUME((x <= 1) == (x == y));
            constexpr.ASSUME((x != 0) == (y > 0));
            if (constexpr.IS_TRUE(ispow2(x) && ((uint)intlog2(x) % 3u == 0)))
            {
                constexpr.ASSUME(ispow2(y));
            }

            return (ushort)y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intcbrt(ushort2 x, Promise byteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new ushort2(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intcbrt(ushort3 x, Promise byteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new ushort3(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intcbrt(ushort4 x, Promise byteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new ushort4(intcbrt(x.x, byteRange), intcbrt(x.y, byteRange), intcbrt(x.z, byteRange), intcbrt(x.w, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intcbrt(ushort8 x, Promise byteRange = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new ushort8(intcbrt(x.x0, byteRange),
                                   intcbrt(x.x1, byteRange),
                                   intcbrt(x.x2, byteRange),
                                   intcbrt(x.x3, byteRange),
                                   intcbrt(x.x4, byteRange),
                                   intcbrt(x.x5, byteRange),
                                   intcbrt(x.x6, byteRange),
                                   intcbrt(x.x7, byteRange));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ushort16"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="byteRange"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intcbrt(ushort16 x, Promise byteRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu16(x, byteRange.Promises(Promise.Unsafe0));
            }
            else
            {
                return new ushort16(intcbrt(x.v8_0, byteRange), intcbrt(x.v8_8, byteRange));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-32, 32)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short intcbrt(short x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (short)intcbrt((ushort)x, promises);
            }
            else
            {
                bool negative = x < 0;
                ushort cbrtAbs = intcbrt((ushort)select(x, -x, negative), promises);

                return select((short)cbrtAbs, (short)-(short)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intcbrt(short2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 2);
            }
            else
            {
                return new short2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intcbrt(short3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 3);
            }
            else
            {
                return new short3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intcbrt(short4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 4);
            }
            else
            {
                return new short4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intcbrt(short8 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0), 8);
            }
            else
            {
                return new short8(intcbrt(x.x0, promises),
                                  intcbrt(x.x1, promises),
                                  intcbrt(x.x2, promises),
                                  intcbrt(x.x3, promises),
                                  intcbrt(x.x4, promises),
                                  intcbrt(x.x5, promises),
                                  intcbrt(x.x6, promises),
                                  intcbrt(x.x7, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="short16"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intcbrt(short16 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi16(x, promises.Promises(Promise.ZeroOrGreater), promises.Promises(Promise.Unsafe0));
            }
            else
            {
                return new short16(intcbrt(x.v8_0, promises), intcbrt(x.v8_8, promises));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="__x"/>⌋ of a <see cref="uint"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 1_625ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intcbrt(uint x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x <= ushort.MaxValue))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt((ushort)x, promises);
            }

            uint __x = x;
            uint y = 0;
            uint b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                for (int c = sizeof(uint) * 8 / 3 * 3; c >= 0; c -= 3)
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (__x >> c >= b)
                    {
                        __x -= b << c;
                        y++;
                    }
                }
            }
            else
            {
                b = 1;

                if ((__x >> 30) != 0)
                {
                    __x -= b << 30;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 27) >= b)
                {
                    __x -= b << 27;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 24) >= b)
                {
                    __x -= b << 24;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 21) >= b)
                {
                    __x -= b << 21;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 18) >= b)
                {
                    __x -= b << 18;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 15) >= b)
                {
                    __x -= b << 15;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 12) >= b)
                {
                    __x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 9) >= b)
                {
                    __x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 6) >= b)
                {
                    __x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 3) >= b)
                {
                    __x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(__x >= b);
            }
            
            constexpr.ASSUME(y * y * y <= x);
            constexpr.ASSUME((ulong)(y + 1) * (y + 1) * (y + 1) > x);
            constexpr.ASSUME(y <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(y < x);
            }
            constexpr.ASSUME((x <= 1) == (x == y));
            constexpr.ASSUME((x != 0) == (y > 0));
            if (constexpr.IS_TRUE(ispow2(x) && ((uint)intlog2(x) % 3u == 0)))
            {
                constexpr.ASSUME(ispow2(y));
            }

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intcbrt(uint2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu32(x, promises.CountUnsafeLevels(), 2);
            }
            else
            {
                return new uint2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intcbrt(uint3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu32(x, promises.CountUnsafeLevels(), 3);
            }
            else
            {
                return new uint3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intcbrt(uint4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu32(x, promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new uint4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="uint8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intcbrt(uint8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu32(x, promises.CountUnsafeLevels());
            }
            else
            {
                return new uint8(intcbrt(x.v4_0, promises), intcbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-1_290, 1_290)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intcbrt(int x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (int)intcbrt((uint)x, promises);
            }
            else
            {
                bool negative = x < 0;
                uint cbrtAbs = intcbrt((uint)select(x, -x, negative), promises);

                return select((int)cbrtAbs, -(int)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intcbrt(int2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi32(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 2);
            }
            else
            {
                return new int2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intcbrt(int3 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi32(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 3);
            }
            else
            {
                return new int3(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intcbrt(int4 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi32(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new int4(intcbrt(x.x, promises), intcbrt(x.y, promises), intcbrt(x.z, promises), intcbrt(x.w, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of an <see cref="int8"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intcbrt(int8 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi32(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels());
            }
            else
            {
                return new int8(intcbrt(x.v4_0, promises), intcbrt(x.v4_4, promises));
            }
        }


        /// <summary>       Computes the integer cube root ⌊∛<paramref name="__x"/>⌋ of a <see cref="ulong"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(0ul, 2_642_245ul)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intcbrt(ulong x, Promise promises = Promise.Nothing)
        {
            if (promises.CountUnsafeLevels() > 0 || constexpr.IS_TRUE(x <= uint.MaxValue))
            {
                promises.DemoteUnsafeLevels();

                return intcbrt((uint)x, promises);
            }

            ulong __x = x;
            ulong y;
            ulong b;
            if (COMPILATION_OPTIONS.OPTIMIZE_FOR == OptimizeFor.Size)
            {
                y = 0;
                for (int c = sizeof(ulong) * 8 / 3 * 3; c >= 0; c -= 3)
                {
                    y += y;
                    b = ((3 * y) * (y + 1)) + 1;
                    if (__x >> c >= b)
                    {
                        __x -= b << c;
                        y++;
                    }
                }
            }
            else
            {
                y = __x >> 63;
                __x &= 0x7FFF_FFFF_FFFF_FFFF;

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 60) >= b)
                {
                    __x -= b << 60;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 57) >= b)
                {
                    __x -= b << 57;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 54) >= b)
                {
                    __x -= b << 54;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 51) >= b)
                {
                    __x -= b << 51;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 48) >= b)
                {
                    __x -= b << 48;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 45) >= b)
                {
                    __x -= b << 45;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 42) >= b)
                {
                    __x -= b << 42;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 39) >= b)
                {
                    __x -= b << 39;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 36) >= b)
                {
                    __x -= b << 36;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 33) >= b)
                {
                    __x -= b << 33;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 30) >= b)
                {
                    __x -= b << 30;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 27) >= b)
                {
                    __x -= b << 27;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 24) >= b)
                {
                    __x -= b << 24;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 21) >= b)
                {
                    __x -= b << 21;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 18) >= b)
                {
                    __x -= b << 18;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 15) >= b)
                {
                    __x -= b << 15;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 12) >= b)
                {
                    __x -= b << 12;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 9) >= b)
                {
                    __x -= b << 9;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 6) >= b)
                {
                    __x -= b << 6;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;

                if ((__x >> 3) >= b)
                {
                    __x -= b << 3;
                    y++;
                }

                y += y;
                b = ((3 * y) * (y + 1)) + 1;
                y += tobyte(__x >= b);
            }
            
            constexpr.ASSUME(y * y * y <= x);
            constexpr.ASSUME((UInt128)(y + 1) * (y + 1) * (y + 1) > x);
            constexpr.ASSUME(y <= x);
            if (constexpr.IS_TRUE(x > 1))
            {
                constexpr.ASSUME(y < x);
            }
            constexpr.ASSUME((x <= 1) == (x == y));
            constexpr.ASSUME((x != 0) == (y > 0));
            if (constexpr.IS_TRUE(ispow2(x) && ((uint)intlog2(x) % 3u == 0)))
            {
                constexpr.ASSUME(ispow2(y));
            }

            return y;
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intcbrt(ulong2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epu64(x, promises.CountUnsafeLevels());
            }
            else
            {
                promises.DemoteUnsafeLevels();

                return new ulong2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intcbrt(ulong3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, promises.CountUnsafeLevels(), 3);
            }
            else
            {
                ulong2 xy = intcbrt(x.xy, promises);

                promises.DemoteUnsafeLevels();

                ulong z = intcbrt(x.z, promises);

                return new ulong3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root ⌊∛<paramref name="x"/>⌋ of a <see cref="ulong4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>].        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>].        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intcbrt(ulong4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epu64(x, promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new ulong4(intcbrt(x.xy, promises), intcbrt(x.zw, promises));
            }
        }


        /// <summary>       Computes the integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [return: AssumeRange(-2_097_152, 2_097_152)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intcbrt(long x, Promise promises = Promise.Nothing)
        {
            if (promises.Promises(Promise.ZeroOrGreater) || constexpr.IS_TRUE(x >= 0))
            {
                return (long)intcbrt((ulong)x, promises);
            }
            else
            {
                bool negative = x < 0;
                ulong cbrtAbs = intcbrt((ulong)select(x, -x, negative), promises);

                return select((long)cbrtAbs, -(long)cbrtAbs, negative);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long2"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 48] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intcbrt(long2 x, Promise promises = Promise.Nothing)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels());
            }
            else
            {
                promises.DemoteUnsafeLevels();
                promises |= promises.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing;

                return new long2(intcbrt(x.x, promises), intcbrt(x.y, promises));
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long3"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 47] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intcbrt(long3 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 3);
            }
            else
            {
                long2 xy = intcbrt(x.xy, promises);

                promises.DemoteUnsafeLevels();
                promises = promises.Promises(Promise.ZeroOrGreater) ? Promise.ZeroOrGreater : Promise.Nothing;

                long z = intcbrt(x.z, promises);

                return new long3(xy, z);
            }
        }

        /// <summary>       Computes the componentwise integer cube root sgn(<paramref name="x"/>) * ⌊|∛<paramref name="x"/>|⌋ of a <see cref="long4"/>.
        /// <remarks>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.ZeroOrGreater"/> flag set returns undefined results for negative input values.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe0"/> flag set returns undefined results for input values outside the interval [0, 1ul &lt;&lt; 47] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-(1ul &lt;&lt; 48), 1ul &lt;&lt; 48] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe1"/> flag set returns undefined results for input values outside the interval [0, <see cref="uint.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="uint.MaxValue"/>, <see cref="uint.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe2"/> flag set returns undefined results for input values outside the interval [0, <see cref="ushort.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="ushort.MaxValue"/>, <see cref="ushort.MaxValue"/>] otherwise.        </para>
        /// <para>          A <see cref="Promise"/> '<paramref name="promises"/>' with its <see cref="Promise.Unsafe3"/> flag set returns undefined results for input values outside the interval [0, <see cref="byte.MaxValue"/>] if the <see cref="Promise.ZeroOrGreater"/> flag is also set, [-<see cref="byte.MaxValue"/>, <see cref="byte.MaxValue"/>] otherwise.        </para>
        /// </remarks>
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intcbrt(long4 x, Promise promises = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cbrt_epi64(x, promises.Promises(Promise.ZeroOrGreater), promises.CountUnsafeLevels(), 4);
            }
            else
            {
                return new long4(intcbrt(x.xy, promises), intcbrt(x.zw, promises));
            }
        }
    }
}