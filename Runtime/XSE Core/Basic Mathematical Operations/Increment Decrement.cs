using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 inc_epi8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epi8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.subs_epi8(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epu8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu8(a, Sse2.set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 inc_epi16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epi16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.subs_epi16(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epu16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epu16(a, Sse2.set1_epi16(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 inc_epi32(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi32(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epi32(v128 a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPI32(a, int.MaxValue, elements))
                {
                    return Sse2.sub_epi32(a, setall_si128());
                }
                else
                {
                    return subs_epi32(a, setall_si128(), elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epu32(v128 a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU32(a, uint.MaxValue, elements))
                {
                    return Sse2.sub_epi32(a, setall_si128());
                }
                else
                {
                    return adds_epu32(a, Sse2.set1_epi32(1));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 inc_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi64(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPI64(a, long.MaxValue))
                {
                    return Sse2.sub_epi64(a, setall_si128());
                }
                else
                {
                    return subs_epi64(a, setall_si128());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 incs_epu64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_LT_EPU64(a, ulong.MaxValue))
                {
                    return Sse2.sub_epi64(a, setall_si128());
                }
                else
                {
                    return adds_epu64(a, Sse2.set1_epi64x(1));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_inc_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi8(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epi8(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epu8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epu8(a, Avx.mm256_set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_inc_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi16(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epi16(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epu16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epu16(a, Avx.mm256_set1_epi16(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_inc_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPI32(a, int.MaxValue))
                {
                    return Avx2.mm256_sub_epi32(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_subs_epi32(a, mm256_setall_si256());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epu32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU32(a, uint.MaxValue))
                {
                    return Avx2.mm256_sub_epi32(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_adds_epu32(a, Avx.mm256_set1_epi32(1));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_inc_epi64(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epi64(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPI64(a, long.MaxValue, elements))
                {
                    return Avx2.mm256_sub_epi64(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_subs_epi64(a, mm256_setall_si256());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_incs_epu64(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LT_EPU64(a, ulong.MaxValue, elements))
                {
                    return Avx2.mm256_sub_epi64(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_adds_epu64(a, Avx.mm256_set1_epi64x(1), elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 dec_epi8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epi8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi8(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epu8(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.subs_epu8(a, Sse2.set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 dec_epi16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epi16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.adds_epi16(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epu16(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.subs_epu16(a, Sse2.set1_epi16(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 dec_epi32(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi32(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epi32(v128 a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GT_EPI32(a, int.MinValue, elements))
                {
                    return Sse2.add_epi32(a, setall_si128());
                }
                else
                {
                    return adds_epi32(a, setall_si128(), elements);
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epu32(v128 a, byte elements = 4)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GT_EPU32(a, uint.MinValue, elements))
                {
                    return Sse2.add_epi32(a, setall_si128());
                }
                else
                {
                    return subs_epu32(a, Sse2.set1_epi32(1));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 dec_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi64(a, setall_si128());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epi64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GT_EPI64(a, long.MinValue))
                {
                    return Sse2.add_epi64(a, setall_si128());
                }
                else
                {
                    return adds_epi64(a, setall_si128());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 decs_epu64(v128 a)
        {
            if (Sse2.IsSse2Supported)
            {
                if (constexpr.ALL_GT_EPU64(a, ulong.MinValue))
                {
                    return Sse2.add_epi64(a, setall_si128());
                }
                else
                {
                    return subs_epu64(a, Sse2.set1_epi64x(1));
                }
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_dec_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi8(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epi8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epi8(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epu8(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epu8(a, Avx.mm256_set1_epi8(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_dec_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi16(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epi16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_adds_epi16(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epu16(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_subs_epu16(a, Avx.mm256_set1_epi16(1));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_dec_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi32(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epi32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GT_EPI32(a, int.MinValue))
                {
                    return Avx2.mm256_add_epi32(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_adds_epi32(a, mm256_setall_si256());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epu32(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GT_EPU32(a, uint.MinValue))
                {
                    return Avx2.mm256_add_epi32(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_subs_epu32(a, Avx.mm256_set1_epi32(1));
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_dec_epi64(v256 a)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi64(a, mm256_setall_si256());
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epi64(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GT_EPI64(a, long.MinValue, elements))
                {
                    return Avx2.mm256_add_epi64(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_adds_epi64(a, mm256_setall_si256());
                }
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_decs_epu64(v256 a, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_GT_EPU64(a, ulong.MinValue, elements))
                {
                    return Avx2.mm256_add_epi64(a, mm256_setall_si256());
                }
                else
                {
                    return mm256_subs_epu64(a, Avx.mm256_set1_epi64x(1), elements);
                }
            }
            else throw new IllegalInstructionException();
        }
    }
}
