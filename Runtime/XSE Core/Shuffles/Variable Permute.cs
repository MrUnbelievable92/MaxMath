using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst;

using static Unity.Burst.Intrinsics.X86;
using static Unity.Burst.Intrinsics.Arm.Neon;

namespace MaxMath.Intrinsics
{
    unsafe public static partial class Xse
    {
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static v128 shuffle_epi8(v128 a, v128 b, byte elements = 16)
		{
			if (Ssse3.IsSsse3Supported)
			{
				return Ssse3.shuffle_epi8(a, b);
			}
            else if (IsNeonSupported)
            {
                return vqtbl1q_s8(a, vandq_u8(b, vdupq_n_u8(0x8F)));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 r0 = and_si128(broadcasti_epi8(a, 0, elements), cmpeq_epi8(b, set1_epi8(0)));
                v128 r1 = and_si128(broadcasti_epi8(a, 1, elements), cmpeq_epi8(b, set1_epi8(1)));

                v128 r01 = or_si128(r0, r1);

                if (elements == 2)
                {
                    return r01;
                }

                v128 r2 = and_si128(broadcasti_epi8(a, 2, elements), cmpeq_epi8(b, set1_epi8(2)));

                if (elements == 3)
                {
                    return or_si128(r01, r2);
                }

                v128 r3 = and_si128(broadcasti_epi8(a, 3, elements), cmpeq_epi8(b, set1_epi8(3)));

                v128 r23 = or_si128(r2, r3);
                v128 r0123 = or_si128(r01, r23);

                if (elements == 4)
                {
                    return r0123;
                }

                v128 r4 = and_si128(broadcasti_epi8(a, 4, elements), cmpeq_epi8(b, set1_epi8(4)));
                v128 r5 = and_si128(broadcasti_epi8(a, 5, elements), cmpeq_epi8(b, set1_epi8(5)));

                v128 r45 = or_si128(r4, r5);

                v128 r6 = and_si128(broadcasti_epi8(a, 6, elements), cmpeq_epi8(b, set1_epi8(6)));
                v128 r7 = and_si128(broadcasti_epi8(a, 7, elements), cmpeq_epi8(b, set1_epi8(7)));

                v128 r67 = or_si128(r6, r7);
                v128 r4567 = or_si128(r45, r67);
                v128 r01234567 = or_si128(r0123, r4567);

                if (elements == 8)
                {
                    return r01234567;
                }

                v128 r8 = and_si128(broadcasti_epi8(a, 8, elements), cmpeq_epi8(b, set1_epi8(8)));
                v128 r9 = and_si128(broadcasti_epi8(a, 9, elements), cmpeq_epi8(b, set1_epi8(9)));

                v128 r89 = or_si128(r8, r9);

                v128 r_10 = and_si128(broadcasti_epi8(a, 10, elements), cmpeq_epi8(b, set1_epi8(10)));
                v128 r_11 = and_si128(broadcasti_epi8(a, 11, elements), cmpeq_epi8(b, set1_epi8(11)));

                v128 r_10_11 = or_si128(r_10, r_11);
                v128 r89_10_11 = or_si128(r89, r_10_11);

                v128 r_12 = and_si128(broadcasti_epi8(a, 12, elements), cmpeq_epi8(b, set1_epi8(12)));
                v128 r_13 = and_si128(broadcasti_epi8(a, 13, elements), cmpeq_epi8(b, set1_epi8(13)));

                v128 r_12_13 = or_si128(r_12, r_13);

                v128 r_14 = and_si128(broadcasti_epi8(a, 14, elements), cmpeq_epi8(b, set1_epi8(14)));
                v128 r_15 = and_si128(broadcasti_epi8(a, 15, elements), cmpeq_epi8(b, set1_epi8(15)));

                v128 r_14_15 = or_si128(r_14, r_15);
                v128 r_12_13_14_15 = or_si128(r_12_13, r_14_15);
                v128 r89_10_11_12_13_14_15 = or_si128(r89_10_11, r_12_13_14_15);

                return or_si128(r01234567, r89_10_11_12_13_14_15);
            }
			else throw new IllegalInstructionException();
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 shuffle_epi16(v128 a, v128 b, byte elements = 8)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                b = adds_epu16(b, b);
                b = shuffle_epi8(b, new v128(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                b = adds_epu8(b, new v128(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));

                return shuffle_epi8(a, b);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 r0 = and_si128(broadcasti_epi16(a, 0, elements), cmpeq_epi16(b, set1_epi16(0)));
                v128 r1 = and_si128(broadcasti_epi16(a, 1, elements), cmpeq_epi16(b, set1_epi16(1)));

                v128 r01 = or_si128(r0, r1);

                if (elements == 2)
                {
                    return r01;
                }

                v128 r2 = and_si128(broadcasti_epi16(a, 2, elements), cmpeq_epi16(b, set1_epi16(2)));

                if (elements == 3)
                {
                    return or_si128(r01, r2);
                }

                v128 r3 = and_si128(broadcasti_epi16(a, 3, elements), cmpeq_epi16(b, set1_epi16(3)));

                v128 r23 = or_si128(r2, r3);
                v128 r0123 = or_si128(r01, r23);

                if (elements == 4)
                {
                    return r0123;
                }

                v128 r4 = and_si128(broadcasti_epi16(a, 4, elements), cmpeq_epi16(b, set1_epi16(4)));
                v128 r5 = and_si128(broadcasti_epi16(a, 5, elements), cmpeq_epi16(b, set1_epi16(5)));

                v128 r45 = or_si128(r4, r5);

                v128 r6 = and_si128(broadcasti_epi16(a, 6, elements), cmpeq_epi16(b, set1_epi16(6)));
                v128 r7 = and_si128(broadcasti_epi16(a, 7, elements), cmpeq_epi16(b, set1_epi16(7)));

                v128 r67 = or_si128(r6, r7);
                v128 r4567 = or_si128(r45, r67);

                return or_si128(r0123, r4567);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_shuffle_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                b = Avx2.mm256_adds_epu16(b, b);
                b = Avx2.mm256_shuffle_epi8(b, new v256(0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14, 0, 0, 2, 2, 4, 4, 6, 6, 8, 8, 10, 10, 12, 12, 14, 14));
                b = Avx2.mm256_adds_epu8(b, new v256(0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1));

                return Avx2.mm256_shuffle_epi8(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_permutevar_epi8(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_IDX = mm256_set1_epi8(15);

                v256 alolo = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                v256 ahihi = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));

                v256 wantsHi = Avx2.mm256_cmpgt_epi8(b, MAX_IDX);
                b = Avx2.mm256_sub_epi8(Avx2.mm256_add_epi8(b, wantsHi), Avx2.mm256_and_si256(MAX_IDX, wantsHi));
                v256 shufflelo = Avx2.mm256_shuffle_epi8(alolo, b);
                v256 shufflehi = Avx2.mm256_shuffle_epi8(ahihi, b);

                return mm256_blendv_si256(shufflelo, shufflehi, wantsHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_permutevar_epi16(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 MAX_IDX = mm256_set1_epi16(7);

                v256 alolo = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(1, 0, 1, 0));
                v256 ahihi = Avx2.mm256_permute4x64_epi64(a, Sse.SHUFFLE(3, 2, 3, 2));

                v256 wantsHi = Avx2.mm256_cmpgt_epi16(b, MAX_IDX);
                b = Avx2.mm256_sub_epi16(Avx2.mm256_add_epi16(b, wantsHi), Avx2.mm256_and_si256(MAX_IDX, wantsHi));
                v256 shufflelo = mm256_shuffle_epi16(alolo, b);
                v256 shufflehi = mm256_shuffle_epi16(ahihi, b);

                return mm256_blendv_si256(shufflelo, shufflehi, wantsHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 permutevar_epi32(v128 a, v128 b, byte elements = 4)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.permutevar_ps(a, b);
            }
            else if (BurstArchitecture.IsTableLookupSupported)
            {
                b = slli_epi32(b, 2);
                b = shuffle_epi8(b, new v128(0, 0, 0, 0, 4, 4, 4, 4, 8, 8, 8, 8, 12, 12, 12, 12));
                b = adds_epu8(b, new v128(0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3));

                return shuffle_epi8(a, b);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 r0 = and_si128(broadcasti_epi32(a, 0), cmpeq_epi32(b, set1_epi32(0)));
                v128 r1 = and_si128(broadcasti_epi32(a, 1), cmpeq_epi32(b, set1_epi32(1)));

                v128 r01 = or_si128(r0, r1);

                if (elements == 2)
                {
                    return r01;
                }

                v128 r2 = and_si128(broadcasti_epi32(a, 2), cmpeq_epi32(b, set1_epi32(2)));

                if (elements == 3)
                {
                    return or_si128(r01, r2);
                }

                v128 r3 = and_si128(broadcasti_epi32(a, 3), cmpeq_epi32(b, set1_epi32(3)));

                v128 r23 = or_si128(r2, r3);

                return or_si128(r01, r23);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v128 permutevar_epi64(v128 a, v128 b)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.permutevar_pd(a, add_epi64(b, b));
            }
            else if (BurstArchitecture.IsTableLookupSupported)
            {
                b = slli_epi64(b, 3);
                b = shuffle_epi8(b, new v128(0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8));
                b = adds_epu8(b, new v128(0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7));

                return shuffle_epi8(a, b);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 r0 = and_si128(broadcasti_epi64(a, 0), cmpeq_epi64(b, set1_epi64x(0)));
                v128 r1 = and_si128(broadcasti_epi64(a, 1), cmpeq_epi64(b, set1_epi64x(1)));

                return or_si128(r0, r1);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static v256 mm256_permutevar_epi64(v256 a, v256 b)
        {
            if (Avx2.IsAvx2Supported)
            {
                b = Avx2.mm256_add_epi32(b, b);
                b = Avx2.mm256_shuffle_epi32(b, Sse.SHUFFLE(2, 2, 0, 0));
                b = Avx2.mm256_add_epi32(b, new v256(0, 1, 0, 1, 0, 1, 0, 1));

                return Avx2.mm256_permutevar8x32_epi32(a, b);
            }
            else throw new IllegalInstructionException();
        }


	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
	    public static void dshuffle_epi8(v128 a0, v128 a1, v128 i0, v128 i1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
	    {
	    	if (BurstArchitecture.IsSIMDSupported)
	    	{
	    		v128 xlolo = shuffle_epi8(a0, i0);
	    		v128 xlohi = shuffle_epi8(a0, i1);
	    		v128 hi0 = sub_epi8(i0, set1_epi8(16));
	    		v128 hi1 = sub_epi8(i1, set1_epi8(16));
	    		v128 xhilo = shuffle_epi8(a1, hi0);
	    		v128 xhihi = shuffle_epi8(a1, hi1);
	    
	    		v128 selectHi0;
	    		v128 selectHi1;
	    		if (Arm.Neon.IsNeonSupported)
	    		{
	    			selectHi0 = cmpge_epu8(i0, set1_epi8(16));
	    			selectHi1 = cmpge_epu8(i1, set1_epi8(16));
	    		}
	    		else
	    		{
	    			selectHi0 = cmpgt_epi8(i0, set1_epi8(15));
	    			selectHi1 = cmpgt_epi8(i1, set1_epi8(15));
	    		}

	    		r0 = blendv_si128(xlolo, xhilo, selectHi0);
	    		r1 = blendv_si128(xlohi, xhihi, selectHi1);
	    	}
	    	else throw new IllegalInstructionException();
	    }

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
	    public static void dshuffle_epi16(v128 a0, v128 a1, v128 i0, v128 i1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
	    {
	    	if (BurstArchitecture.IsSIMDSupported)
	    	{
	    		v128 xlolo = shuffle_epi16(a0, i0);
	    		v128 xlohi = shuffle_epi16(a0, i1);
	    		v128 hi0 = sub_epi16(i0, set1_epi16(8));
	    		v128 hi1 = sub_epi16(i1, set1_epi16(8));
	    		v128 xhilo = shuffle_epi16(a1, hi0);
	    		v128 xhihi = shuffle_epi16(a1, hi1);
	    
	    		v128 selectHi0;
	    		v128 selectHi1;
	    		if (Arm.Neon.IsNeonSupported)
	    		{
	    			selectHi0 = cmpge_epu16(i0, set1_epi16(8));
	    			selectHi1 = cmpge_epu16(i1, set1_epi16(8));
	    		}
	    		else
	    		{
	    			selectHi0 = cmpgt_epi16(i0, set1_epi16(7));
	    			selectHi1 = cmpgt_epi16(i1, set1_epi16(7));
	    		}

	    		r0 = blendv_si128(xlolo, xhilo, selectHi0);
	    		r1 = blendv_si128(xlohi, xhihi, selectHi1);
	    	}
	    	else throw new IllegalInstructionException();
	    }

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
	    public static void dshuffle_epi32(v128 a0, v128 a1, v128 i0, v128 i1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
	    {
	    	if (BurstArchitecture.IsSIMDSupported)
	    	{
	    		v128 xlolo = permutevar_epi32(a0, i0);
	    		v128 xlohi = permutevar_epi32(a0, i1);
	    		v128 hi0 = sub_epi32(i0, set1_epi32(4));
	    		v128 hi1 = sub_epi32(i1, set1_epi32(4));
	    		v128 xhilo = permutevar_epi32(a1, hi0);
	    		v128 xhihi = permutevar_epi32(a1, hi1);
	    
	    		v128 selectHi0;
	    		v128 selectHi1;
	    		if (Arm.Neon.IsNeonSupported)
	    		{
	    			selectHi0 = cmpge_epu32(i0, set1_epi32(4));
	    			selectHi1 = cmpge_epu32(i1, set1_epi32(4));
	    		}
	    		else
	    		{
	    			selectHi0 = cmpgt_epi32(i0, set1_epi32(3));
	    			selectHi1 = cmpgt_epi32(i1, set1_epi32(3));
	    		}

	    		r0 = blendv_si128(xlolo, xhilo, selectHi0);
	    		r1 = blendv_si128(xlohi, xhihi, selectHi1);
	    	}
	    	else throw new IllegalInstructionException();
	    }

	    [MethodImpl(MethodImplOptions.AggressiveInlining)]
	    public static void dshuffle_epi64(v128 a0, v128 a1, v128 i0, v128 i1, [NoAlias] out v128 r0, [NoAlias] out v128 r1)
	    {
	    	if (BurstArchitecture.IsSIMDSupported)
	    	{
	    		v128 xlolo = permutevar_epi64(a0, i0);
	    		v128 xlohi = permutevar_epi64(a0, i1);
	    		v128 hi0 = sub_epi64(i0, set1_epi64x(2));
	    		v128 hi1 = sub_epi64(i1, set1_epi64x(2));
	    		v128 xhilo = permutevar_epi64(a1, hi0);
	    		v128 xhihi = permutevar_epi64(a1, hi1);
	    
	    		v128 selectHi0;
	    		v128 selectHi1;
	    		if (Arm.Neon.IsNeonSupported)
	    		{
	    			selectHi0 = vcgeq_u64(i0, set1_epi64x(2));
	    			selectHi1 = vcgeq_u64(i1, set1_epi64x(2));
	    		}
	    		else
	    		{
	    			selectHi0 = shuffle_epi32(cmpgt_epi32(i0, set1_epi64x(1)), Sse.SHUFFLE(2, 2, 0, 0));
	    			selectHi1 = shuffle_epi32(cmpgt_epi32(i1, set1_epi64x(1)), Sse.SHUFFLE(2, 2, 0, 0));
	    		}

	    		r0 = blendv_si128(xlolo, xhilo, selectHi0);
	    		r1 = blendv_si128(xlohi, xhihi, selectHi1);
	    	}
	    	else throw new IllegalInstructionException();
	    }
    }
}
