using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 impl_udivrem128_epu64(v128 aHi, v128 b, out v128 c, bool useFPU = false, bool unsafeRange = false)
        {
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong2, ulong>(aHi, b, 2);
}

            if (Architecture.IsSIMDSupported)
            {
                v128 U32_MASK = set1_epi64x(0xFFFF_FFFFu);

                v128 shift = lzcnt_epi64(b);
                aHi = sllv_epi64(aHi, shift, inRange: true);
                b = sllv_epi64(b, shift, inRange: true);
                v128 bLo = and_si128(b, U32_MASK);
                v128 bHi = srli_epi64(b, 32);

                v128 qHi;
                v128 remdiv;
                if (useFPU)
                {
                    qHi = impl_divrem_epu64(aHi, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, mullo_epi64(qHi, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qHi = impl_divrem_epu64(aHi, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, new v128(qHi.ULong0 * bLo.ULong0, qHi.ULong1 * bLo.ULong1));
                }
                v128 b1 = cmpgt_epu64(c, remdiv);
                v128 b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), b));
                qHi = add_epi64(qHi, b2);
                qHi = add_epi64(qHi, b1);
                c = add_epi64(c, and_si128(b1, b));
                c = add_epi64(c, and_si128(b2, b));

                v128 qLo;
                if (useFPU)
                {
                    qLo = impl_divrem_epu64(c, bHi, out remdiv, useFPU: true, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, mullo_epi64(qLo, bLo, unsigned_B_lessequalU32Max: true));
                }
                else
                {
                    qLo = impl_divrem_epu64(c, bHi, out remdiv, useFPU: false, bLEu32max: true);
                    remdiv = slli_epi64(remdiv, 32);
                    c = sub_epi64(remdiv, new v128(qLo.ULong0 * bLo.ULong0, qLo.ULong1 * bLo.ULong1));
                }
                b1 = cmpgt_epu64(c, remdiv);
                b2 = and_si128(b1, cmpgt_epu64(neg_epi64(c), b));
                qLo = add_epi64(qLo, b2);
                qLo = add_epi64(qLo, b1);
                c = add_epi64(c, and_si128(b1, b));
                c = add_epi64(c, and_si128(b2, b));

                c = srlv_epi64(c, shift, inRange: true);
                constexpr.ASSUME_LT_EPU64(c, b);
                return ternarylogic_si128(slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_impl_udivrem128_epu64(v256 aHi, v256 b, out v256 c, byte elements = 4, bool unsafeRange = false)
        {
if (!unsafeRange)
{
    VectorAssert.IsSmaller<ulong4, ulong>(aHi, b, elements);
}

            if (Avx2.IsAvx2Supported)
            {
                v256 U32_MASK = mm256_set1_epi64x(0xFFFF_FFFFu);

                v256 shift = mm256_lzcnt_epi64(b);
                aHi = Avx2.mm256_sllv_epi64(aHi, shift);
                b = Avx2.mm256_sllv_epi64(b, shift);
                v256 bLo = Avx2.mm256_and_si256(b, U32_MASK);
                v256 bHi = Avx2.mm256_srli_epi64(b, 32);

                v256 qHi = mm256_impl_divrem_epu64(aHi, bHi, out v256 remdiv, bLEu32max: true, elements: elements);
                remdiv = Avx2.mm256_slli_epi64(remdiv, 32);
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qHi, bLo, elements, unsigned_B_lessequalU32Max: true));
                v256 b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                v256 b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qHi = Avx2.mm256_add_epi64(qHi, b2);
                qHi = Avx2.mm256_add_epi64(qHi, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                v256 qLo = mm256_impl_divrem_epu64(c, bHi, out remdiv, bLEu32max: true, elements: elements);
                remdiv = Avx2.mm256_slli_epi64(remdiv, 32);
                c = Avx2.mm256_sub_epi64(remdiv, mm256_mullo_epi64(qLo, bLo, elements, unsigned_B_lessequalU32Max: true));
                b1 = mm256_cmpgt_epu64(c, remdiv, elements);
                b2 = Avx2.mm256_and_si256(b1, mm256_cmpgt_epu64(mm256_neg_epi64(c), b, elements));
                qLo = Avx2.mm256_add_epi64(qLo, b2);
                qLo = Avx2.mm256_add_epi64(qLo, b1);
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b1, b));
                c = Avx2.mm256_add_epi64(c, Avx2.mm256_and_si256(b2, b));

                c = Avx2.mm256_srlv_epi64(c, shift);
                constexpr.ASSUME_LT_EPU64(c, b, elements);
                return mm256_ternarylogic_si256(Avx2.mm256_slli_epi64(qHi, 32), qLo, U32_MASK, TernaryOperation.OxF8);
            }
            else throw new IllegalInstructionException();
        }
    }
}
