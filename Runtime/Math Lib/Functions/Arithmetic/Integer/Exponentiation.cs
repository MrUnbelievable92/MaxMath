using System.Runtime.CompilerServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow_epi8(v128 a, v128 b, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI8(a, 1, elements))
                    {
                        return Sse2.set1_epi8(1);
                    }
                    if (constexpr.ALL_EQ_EPI8(a, 2, elements))
                    {
                        return sllv_epi8(Sse2.set1_epi8(1), b, elements);
                    }

                    if (constexpr.ALL_SAME_EPU8(b, elements))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Sse2.set1_epi8(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return mullo_epi8(a, a); }
                            case 3:  { return mullo_epi8(a, mullo_epi8(a, a)); }
                            case 4:  { v128 a2 = mullo_epi8(a, a); return mullo_epi8(a2, a2); }
                            case 5:  { v128 a2 = mullo_epi8(a, a); return mullo_epi8(a, mullo_epi8(a2, a2)); }
                            case 6:  { v128 a2 = mullo_epi8(a, a); return mullo_epi8(a2, mullo_epi8(a2, a2)); }
                            case 7:  { v128 a2 = mullo_epi8(a, a); return mullo_epi8(mullo_epi8(a, a2), mullo_epi8(a2, a2)); }
                            case 8:  { v128 a2 = mullo_epi8(a, a); v128 a4 = mullo_epi8(a2, a2); return mullo_epi8(a4, a4); }
                            
                            default: break;
                        }
                    }

                    if (elements != sizeof(v128) / sizeof(byte))
                    {
                        return cvtepi16_epi8(pow_epi16(cvtepi8_epi16(a), cvtepu8_epi16(b)));
                    }
                    else if (Avx2.IsAvx2Supported)
                    {
                        return mm256_cvtepi16_epi8(mm256_pow_epi16(Avx2.mm256_cvtepi8_epi16(a), Avx2.mm256_cvtepi8_epi16(b)));
                    }
                    else
                    {
                        v128 ZERO = Sse2.setzero_si128();
                        v128 ONE = Sse2.set1_epi8(1);

                        v128 y = blendv_si128(ONE, a, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(b, ONE)));
                        b = srli_epi8(b, 1);
                        v128 doneMask = Sse2.cmpeq_epi8(ZERO, a);
                        v128 result = Sse2.and_si128(y, doneMask);
                        
                        if (Hint.Likely(notalltrue_epi128<byte>(doneMask, elements)))
                        {
                            a = mullo_epi8(a, a);
                        }
                        else
                        {
                            return result;
                        }

                        while (true)
                        {
                            v128 y_times_x = mullo_epi8(y, a);
                            y = blendv_si128(y, y_times_x, Sse2.cmpeq_epi8(ONE, Sse2.and_si128(ONE, b)));

                            b = srli_epi8(b, 1);

                            v128 n_is_zero = Sse2.cmpeq_epi8(ZERO, b);
                            result = blendv_si128(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                            doneMask = n_is_zero;
                            
                            if (Hint.Unlikely(alltrue_epi128<byte>(n_is_zero, elements)))
                            {
                                return result;
                            }

                            a = mullo_epi8(a, a);
                        }
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI8(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI8(a, 1))
                    {
                        return Avx.mm256_set1_epi8(1);
                    }
                    if (constexpr.ALL_EQ_EPI8(a, 2))
                    {
                        return mm256_sllv_epi8(Avx.mm256_set1_epi8(1), b);
                    }

                    if (constexpr.ALL_SAME_EPU8(b))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Avx.mm256_set1_epi8(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return mm256_mullo_epi8(a, a); }
                            case 3:  { return mm256_mullo_epi8(a, mm256_mullo_epi8(a, a)); }
                            case 4:  { v256 a2 = mm256_mullo_epi8(a, a); return mm256_mullo_epi8(a2, a2); }
                            case 5:  { v256 a2 = mm256_mullo_epi8(a, a); return mm256_mullo_epi8(a, mm256_mullo_epi8(a2, a2)); }
                            case 6:  { v256 a2 = mm256_mullo_epi8(a, a); return mm256_mullo_epi8(a2, mm256_mullo_epi8(a2, a2)); }
                            case 7:  { v256 a2 = mm256_mullo_epi8(a, a); return mm256_mullo_epi8(mm256_mullo_epi8(a, a2), mm256_mullo_epi8(a2, a2)); }
                            case 8:  { v256 a2 = mm256_mullo_epi8(a, a); v256 a4 = mm256_mullo_epi8(a2, a2); return mm256_mullo_epi8(a4, a4); }
                            
                            default: break;
                        }
                    }
                    
                    v256 ZERO = Avx.mm256_setzero_si256();
                    sbyte32 ONE = new sbyte32(1);

                    v256 y = mm256_blendv_si256(ONE, a, Avx2.mm256_cmpeq_epi8(ONE, Avx2.mm256_and_si256(b, ONE)));
                    b = mm256_srli_epi8(b, 1);
                    v256 doneMask = Avx2.mm256_cmpeq_epi8(ZERO, a);
                    v256 result = Avx2.mm256_and_si256(y, doneMask);
                    
                    if (Hint.Likely(mm256_notalltrue_epi256<byte>(doneMask, 32)))
                    {
                        a = mm256_mullo_epi8(a, a);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v256 y_times_x = mm256_mullo_epi8(a, y);
                        y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi8(ONE, Avx2.mm256_and_si256(ONE, b)));

                        b = mm256_srli_epi8(b, 1);

                        v256 n_is_zero = Avx2.mm256_cmpeq_epi8(ZERO, b);
                        result = mm256_blendv_si256(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                        doneMask = n_is_zero;

                        if (Hint.Unlikely(mm256_alltrue_epi256<byte>(n_is_zero, 32)))
                        {
                            return result;
                        }

                        a = mm256_mullo_epi8(a, a);
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow_epi16(v128 a, v128 b, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI16(a, 1, elements))
                    {
                        return Sse2.set1_epi16(1);
                    }
                    if (constexpr.ALL_EQ_EPI16(a, 2, elements))
                    {
                        return sllv_epi16(Sse2.set1_epi16(1), b, elements);
                    }

                    if (constexpr.ALL_SAME_EPU16(b, elements))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Sse2.set1_epi16(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return Sse2.mullo_epi16(a, a); }
                            case 3:  { return Sse2.mullo_epi16(a, Sse2.mullo_epi16(a, a)); }
                            case 4:  { v128 a2 = Sse2.mullo_epi16(a, a); return Sse2.mullo_epi16(a2, a2); }
                            case 5:  { v128 a2 = Sse2.mullo_epi16(a, a); return Sse2.mullo_epi16(a, Sse2.mullo_epi16(a2, a2)); }
                            case 6:  { v128 a2 = Sse2.mullo_epi16(a, a); return Sse2.mullo_epi16(a2, Sse2.mullo_epi16(a2, a2)); }
                            case 7:  { v128 a2 = Sse2.mullo_epi16(a, a); return Sse2.mullo_epi16(Sse2.mullo_epi16(a, a2), Sse2.mullo_epi16(a2, a2)); }
                            case 8:  { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(a4, a4); }
                            case 9:  { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(a, Sse2.mullo_epi16(a4, a4)); }
                            case 10: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(a2, Sse2.mullo_epi16(a4, a4)); }
                            case 11: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(Sse2.mullo_epi16(a, a2), Sse2.mullo_epi16(a4, a4)); }
                            case 12: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(a4, Sse2.mullo_epi16(a4, a4)); }
                            case 13: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(Sse2.mullo_epi16(a, a4), Sse2.mullo_epi16(a4, a4)); }
                            case 14: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(Sse2.mullo_epi16(a2, a4), Sse2.mullo_epi16(a4, a4)); }
                            case 15: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); return Sse2.mullo_epi16(Sse2.mullo_epi16(Sse2.mullo_epi16(a, a2), a4), Sse2.mullo_epi16(a4, a4)); }
                            case 16: { v128 a2 = Sse2.mullo_epi16(a, a); v128 a4 = Sse2.mullo_epi16(a2, a2); v128 a8 = Sse2.mullo_epi16(a4, a4); return Sse2.mullo_epi16(a8, a8); }
                            
                            default: break;
                        }
                    }

                    v128 ZERO = Sse2.setzero_si128();
                    v128 ONE = Sse2.set1_epi16(1);

                    v128 y = blendv_si128(ONE, a, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(b, ONE)));
                    b = Sse2.srli_epi16(b, 1);
                    v128 doneMask = Sse2.cmpeq_epi16(ZERO, a);
                    v128 result = Sse2.and_si128(y, doneMask);
                    
                    if (Hint.Likely(notalltrue_epi128<short>(doneMask, elements)))
                    {
                        a = Sse2.mullo_epi16(a, a);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v128 y_times_x = Sse2.mullo_epi16(y, a);
                        y = blendv_si128(y, y_times_x, Sse2.cmpeq_epi16(ONE, Sse2.and_si128(ONE, b)));

                        b = Sse2.srli_epi16(b, 1);

                        v128 n_is_zero = Sse2.cmpeq_epi16(ZERO, b);
                        result = blendv_si128(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                        doneMask = n_is_zero;
                        
                        if (Hint.Unlikely(alltrue_epi128<short>(n_is_zero, elements)))
                        {
                            return result;
                        }

                        a = Sse2.mullo_epi16(a, a);
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI16(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI16(a, 1))
                    {
                        return Avx.mm256_set1_epi16(1);
                    }
                    if (constexpr.ALL_EQ_EPI16(a, 2))
                    {
                        return mm256_sllv_epi16(Avx.mm256_set1_epi16(1), b);
                    }

                    if (constexpr.ALL_SAME_EPU16(b))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Avx.mm256_set1_epi16(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return Avx2.mm256_mullo_epi16(a, a); }
                            case 3:  { return Avx2.mm256_mullo_epi16(a, Avx2.mm256_mullo_epi16(a, a)); }
                            case 4:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); return Avx2.mm256_mullo_epi16(a2, a2); }
                            case 5:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); return Avx2.mm256_mullo_epi16(a, Avx2.mm256_mullo_epi16(a2, a2)); }
                            case 6:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); return Avx2.mm256_mullo_epi16(a2, Avx2.mm256_mullo_epi16(a2, a2)); }
                            case 7:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); return Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(a, a2), Avx2.mm256_mullo_epi16(a2, a2)); }
                            case 8:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(a4, a4); }
                            case 9:  { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(a, Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 10: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(a2, Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 11: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(a, a2), Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 12: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(a4, Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 13: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(a, a4), Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 14: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(a2, a4), Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 15: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); return Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(Avx2.mm256_mullo_epi16(a, a2), a4), Avx2.mm256_mullo_epi16(a4, a4)); }
                            case 16: { v256 a2 = Avx2.mm256_mullo_epi16(a, a); v256 a4 = Avx2.mm256_mullo_epi16(a2, a2); v256 a8 = Avx2.mm256_mullo_epi16(a4, a4); return Avx2.mm256_mullo_epi16(a8, a8); }
                            
                            default: break;
                        }
                    }
                    
                    v256 ZERO = Avx.mm256_setzero_si256();
                    short16 ONE = new short16(1);

                    v256 y = mm256_blendv_si256(ONE, a, Avx2.mm256_cmpeq_epi16(ONE, Avx2.mm256_and_si256(b, ONE)));
                    b = Avx2.mm256_srli_epi16(b, 1);
                    v256 doneMask = Avx2.mm256_cmpeq_epi16(ZERO, a);
                    v256 result = Avx2.mm256_and_si256(y, doneMask);
                    
                    if (Hint.Likely(mm256_notalltrue_epi256<short>(doneMask, 16)))
                    {
                        a = Avx2.mm256_mullo_epi16(a, a);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v256 y_times_x = Avx2.mm256_mullo_epi16(a, y);
                        y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi16(ONE, Avx2.mm256_and_si256(ONE, b)));

                        b = Avx2.mm256_srli_epi16(b, 1);

                        v256 n_is_zero = Avx2.mm256_cmpeq_epi16(ZERO, b);
                        result = mm256_blendv_si256(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                        doneMask = n_is_zero;

                        if (Hint.Unlikely(mm256_alltrue_epi256<short>(n_is_zero, 16)))
                        {
                            return result;
                        }

                        a = Avx2.mm256_mullo_epi16(a, a);
                    }
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow_epi32(v128 a, v128 b, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 1, elements))
                    {
                        return Sse2.set1_epi32(1);
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 2, elements))
                    {
                        return sllv_epi32(Sse2.set1_epi32(1), b, elements);
                    }

                    if (constexpr.ALL_SAME_EPU32(b, elements))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Sse2.set1_epi32(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return mullo_epi32(a, a, elements); }
                            case 3:  { return mullo_epi32(a, mullo_epi32(a, a), elements); }
                            case 4:  { v128 a2 = mullo_epi32(a, a, elements); return mullo_epi32(a2, a2, elements); }
                            case 5:  { v128 a2 = mullo_epi32(a, a, elements); return mullo_epi32(a, mullo_epi32(a2, a2), elements); }
                            case 6:  { v128 a2 = mullo_epi32(a, a, elements); return mullo_epi32(a2, mullo_epi32(a2, a2), elements); }
                            case 7:  { v128 a2 = mullo_epi32(a, a, elements); return mullo_epi32(mullo_epi32(a, a2), mullo_epi32(a2, a2), elements); }
                            case 8:  { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(a4, a4, elements); }
                            case 9:  { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(a, mullo_epi32(a4, a4), elements); }
                            case 10: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(a2, mullo_epi32(a4, a4), elements); }
                            case 11: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(mullo_epi32(a, a2), mullo_epi32(a4, a4), elements); }
                            case 12: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(a4, mullo_epi32(a4, a4), elements); }
                            case 13: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(mullo_epi32(a, a4), mullo_epi32(a4, a4), elements); }
                            case 14: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(mullo_epi32(a2, a4), mullo_epi32(a4, a4), elements); }
                            case 15: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a, a2), a4), mullo_epi32(a4, a4), elements); }
                            case 16: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(a8, a8, elements); }
                            case 17: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(a, mullo_epi32(a8, a8), elements); }
                            case 18: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(a2, mullo_epi32(a8, a8), elements); }
                            case 19: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a, a2), mullo_epi32(a8, a8), elements); }
                            case 20: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(a4, mullo_epi32(a8, a8), elements); }
                            case 21: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a, a4), mullo_epi32(a8, a8), elements); }
                            case 22: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a2, a4), mullo_epi32(a8, a8), elements); }
                            case 23: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a, a2), a4), mullo_epi32(a8, a8), elements); }
                            case 24: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(a8, mullo_epi32(a8, a8), elements); }
                            case 25: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a, a8), mullo_epi32(a8, a8), elements); }
                            case 26: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a2, a8), mullo_epi32(a8, a8), elements); }
                            case 27: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a, a2), a8), mullo_epi32(a8, a8), elements); }
                            case 28: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(a4, a8), mullo_epi32(a8, a8), elements); }
                            case 29: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a, a4), a8), mullo_epi32(a8, a8), elements); }
                            case 30: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a2, a4), a8), mullo_epi32(a8, a8), elements); }
                            case 31: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); return mullo_epi32(mullo_epi32(mullo_epi32(a, a2), mullo_epi32(a4, a8)), mullo_epi32(a8, a8), elements); }
                            case 32: { v128 a2 = mullo_epi32(a, a, elements); v128 a4 = mullo_epi32(a2, a2, elements); v128 a8 = mullo_epi32(a4, a4, elements); v128 a16 = mullo_epi32(a8, a8, elements); return mullo_epi32(a16, a16, elements); }
                        
                            default: break;
                        }
                    }

                    v128 ZERO = Sse2.setzero_si128();
                    v128 ONE = new v128(1);
                    int BITMASK = truemsk<int>(elements);

                    v128 y = blendv_si128(ONE, a, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(b, ONE)));
                    b = Sse2.srli_epi32(b, 1);
                    v128 doneMask = Sse2.cmpeq_epi32(ZERO, b);
                    v128 result = Sse2.and_si128(y, doneMask);
                    
                    if (Hint.Likely(notalltrue_epi128<int>(doneMask, elements)))
                    {
                        a = mullo_epi32(a, a, elements);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v128 y_times_x = mullo_epi32(y, a);
                        y = blendv_si128(y, y_times_x, Sse2.cmpeq_epi32(ONE, Sse2.and_si128(ONE, b)));

                        b = Sse2.srli_epi32(b, 1);

                        v128 n_is_zero = Sse2.cmpeq_epi32(ZERO, b);
                        result = blendv_si128(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                        doneMask = n_is_zero;
                        
                        if (Hint.Unlikely(alltrue_epi128<int>(n_is_zero, elements)))
                        {
                            return result;
                        }

                        a = mullo_epi32(a, a, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI32(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 1))
                    {
                        return Avx.mm256_set1_epi32(1);
                    }
                    if (constexpr.ALL_EQ_EPI32(a, 2))
                    {
                        return Avx2.mm256_sllv_epi32(Avx.mm256_set1_epi32(1), b);
                    }

                    if (constexpr.ALL_SAME_EPU32(b))
                    {
                        switch (b.SInt0)
                        {
                            case 0:  { return Avx.mm256_set1_epi32(1); }
                                 
                            case 1:  { return a; }
                            case 2:  { return Avx2.mm256_mullo_epi32(a, a); }
                            case 3:  { return Avx2.mm256_mullo_epi32(a, Avx2.mm256_mullo_epi32(a, a)); }
                            case 4:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); return Avx2.mm256_mullo_epi32(a2, a2); }
                            case 5:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); return Avx2.mm256_mullo_epi32(a, Avx2.mm256_mullo_epi32(a2, a2)); }
                            case 6:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); return Avx2.mm256_mullo_epi32(a2, Avx2.mm256_mullo_epi32(a2, a2)); }
                            case 7:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), Avx2.mm256_mullo_epi32(a2, a2)); }
                            case 8:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(a4, a4); }
                            case 9:  { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(a, Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 10: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(a2, Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 11: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 12: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(a4, Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 13: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a4), Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 14: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a2, a4), Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 15: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), a4), Avx2.mm256_mullo_epi32(a4, a4)); }
                            case 16: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(a8, a8); }
                            case 17: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(a, Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 18: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(a2, Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 19: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 20: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(a4, Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 21: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a4), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 22: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a2, a4), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 23: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), a4), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 24: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(a8, Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 25: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 26: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a2, a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 27: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 28: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a4, a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 29: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a4), a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 30: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a2, a4), a8), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 31: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); return Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(Avx2.mm256_mullo_epi32(a, a2), Avx2.mm256_mullo_epi32(a4, a8)), Avx2.mm256_mullo_epi32(a8, a8)); }
                            case 32: { v256 a2 = Avx2.mm256_mullo_epi32(a, a); v256 a4 = Avx2.mm256_mullo_epi32(a2, a2); v256 a8 = Avx2.mm256_mullo_epi32(a4, a4); v256 a16 = Avx2.mm256_mullo_epi32(a8, a8); return Avx2.mm256_mullo_epi32(a16, a16); }
                        
                            default: break;
                        }
                    }
                    
                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = new int8(1);
                    
                    v256 y = mm256_blendv_si256(ONE, a, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(b, ONE)));
                    b = Avx2.mm256_srli_epi32(b, 1);
                    v256 doneMask = Avx2.mm256_cmpeq_epi32(ZERO, b);
                    v256 result = Avx2.mm256_and_si256(y, doneMask);
                    
                    if (Hint.Likely(mm256_notalltrue_epi256<int>(doneMask, 8)))
                    {
                        a = Avx2.mm256_mullo_epi32(a, a);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v256 y_times_x = Avx2.mm256_mullo_epi32(y, a);
                        y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi32(ONE, Avx2.mm256_and_si256(b, ONE)));

                        b = Avx2.mm256_srli_epi32(b, 1);

                        v256 n_is_zero = Avx2.mm256_cmpeq_epi32(ZERO, b);
                        result = mm256_blendv_si256(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                        doneMask = n_is_zero;

                        if (Hint.Unlikely(mm256_alltrue_epi256<int>(n_is_zero, 8)))
                        {
                            return result;
                        }
                        
                        a = Avx2.mm256_mullo_epi32(a, a);
                    }
                }
                else throw new IllegalInstructionException();
            }
            

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 pow_epi64(v128 a, v128 b)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 0))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 1))
                    {
                        return Sse2.set1_epi64x(1);
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 2))
                    {
                        return sllv_epi64(Sse2.set1_epi64x(1), b);
                    }

                    
                    if (constexpr.ALL_SAME_EPU64(b))
                    {
                        switch (b.SLong0)
                        {
                            case 0:  { return Sse2.set1_epi64x(1); }
                             
                            case 1:  { return a; }
                            case 2:  { return mullo_epi64(a, a); }
                            case 3:  { return mullo_epi64(a, mullo_epi64(a, a)); }
                            case 4:  { v128 a2 = mullo_epi64(a, a); return mullo_epi64(a2, a2); }
                            case 5:  { v128 a2 = mullo_epi64(a, a); return mullo_epi64(a, mullo_epi64(a2, a2)); }
                            case 6:  { v128 a2 = mullo_epi64(a, a); return mullo_epi64(a2, mullo_epi64(a2, a2)); }
                            case 7:  { v128 a2 = mullo_epi64(a, a); return mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a2, a2)); }
                            case 8:  { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(a4, a4); }
                            case 9:  { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(a, mullo_epi64(a4, a4)); }
                            case 10: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(a2, mullo_epi64(a4, a4)); }
                            case 11: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a4, a4)); }
                            case 12: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(a4, mullo_epi64(a4, a4)); }
                            case 13: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(mullo_epi64(a, a4), mullo_epi64(a4, a4)); }
                            case 14: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(mullo_epi64(a2, a4), mullo_epi64(a4, a4)); }
                            case 15: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), mullo_epi64(a4, a4)); }
                            case 16: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(a8, a8); }
                            case 17: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(a, mullo_epi64(a8, a8)); }
                            case 18: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(a2, mullo_epi64(a8, a8)); }
                            case 19: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a8, a8)); }
                            case 20: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(a4, mullo_epi64(a8, a8)); }
                            case 21: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a, a4), mullo_epi64(a8, a8)); }
                            case 22: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a2, a4), mullo_epi64(a8, a8)); }
                            case 23: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), mullo_epi64(a8, a8)); }
                            case 24: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(a8, mullo_epi64(a8, a8)); }
                            case 25: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a, a8), mullo_epi64(a8, a8)); }
                            case 26: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a2, a8), mullo_epi64(a8, a8)); }
                            case 27: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), mullo_epi64(a8, a8)); }
                            case 28: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(a4, a8), mullo_epi64(a8, a8)); }
                            case 29: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), mullo_epi64(a8, a8)); }
                            case 30: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), mullo_epi64(a8, a8)); }
                            case 31: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a4, a8)), mullo_epi64(a8, a8)); }
                            case 32: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a16, a16); }
                            case 33: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a, mullo_epi64(a16, a16)); }
                            case 34: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a2, mullo_epi64(a16, a16)); }
                            case 35: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a, a2), mullo_epi64(a16, a16)); }
                            case 36: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a4, mullo_epi64(a16, a16)); }
                            case 37: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a, a4), mullo_epi64(a16, a16)); }
                            case 38: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a2, a4), mullo_epi64(a16, a16)); }
                            case 39: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), mullo_epi64(a16, a16)); }
                            case 40: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a8, mullo_epi64(a16, a16)); }
                            case 41: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a, a8), mullo_epi64(a16, a16)); }
                            case 42: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a2, a8), mullo_epi64(a16, a16)); }
                            case 43: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), mullo_epi64(a16, a16)); }
                            case 44: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a4, a8), mullo_epi64(a16, a16)); }
                            case 45: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), mullo_epi64(a16, a16)); }
                            case 46: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), mullo_epi64(a16, a16)); }
                            case 47: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a8), mullo_epi64(a16, a16)); }
                            case 48: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(a16, mullo_epi64(a16, a16)); }
                            case 49: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a, a16), mullo_epi64(a16, a16)); }
                            case 50: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a2, a16), mullo_epi64(a16, a16)); }
                            case 51: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a16), mullo_epi64(a16, a16)); }
                            case 52: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a4, a16), mullo_epi64(a16, a16)); }
                            case 53: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a16), mullo_epi64(a16, a16)); }
                            case 54: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a16), mullo_epi64(a16, a16)); }
                            case 55: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a16), mullo_epi64(a16, a16)); }
                            case 56: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(a8, a16), mullo_epi64(a16, a16)); }
                            case 57: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a, a8), a16), mullo_epi64(a16, a16)); }
                            case 58: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a2, a8), a16), mullo_epi64(a16, a16)); }
                            case 59: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a8), a16), mullo_epi64(a16, a16)); }
                            case 60: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(a4, a8), a16), mullo_epi64(a16, a16)); }
                            case 61: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a4), a8), a16), mullo_epi64(a16, a16)); }
                            case 62: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a2, a4), a8), a16), mullo_epi64(a16, a16)); }
                            case 63: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); return mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(mullo_epi64(a, a2), a4), a8), a16), mullo_epi64(a16, a16)); }
                            case 64: { v128 a2 = mullo_epi64(a, a); v128 a4 = mullo_epi64(a2, a2); v128 a8 = mullo_epi64(a4, a4); v128 a16 = mullo_epi64(a8, a8); v128 a32 = mullo_epi64(a16, a16); return mullo_epi64(a32, a32); }

                            default: break;
                        }
                    }

                    v128 ZERO = Sse2.setzero_si128();
                    v128 ONE = new long2(1);

                    v128 y = blendv_si128(ONE, a, cmpeq_epi64(ONE, Sse2.and_si128(b, ONE)));
                    b = Sse2.srli_epi64(b, 1);
                    v128 doneMask = Xse.cmpeq_epi64(ZERO, b);
                    v128 result = Sse2.and_si128(y, doneMask);

                    if (Hint.Likely(notalltrue_epi128<long>(doneMask, 2)))
                    {
                        a = mullo_epi64(a, a);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v128 y_times_x = mullo_epi64(y, a);
                        y = blendv_si128(y, y_times_x, cmpeq_epi64(ONE, Sse2.and_si128(b, ONE)));

                        b = Sse2.srli_epi64(b, 1);
                        
                        v128 n_is_zero = cmpeq_epi64(ZERO, b);
                        result = blendv_si128(result, y, Sse2.andnot_si128(doneMask, n_is_zero));
                        doneMask = n_is_zero;

                        if (Hint.Unlikely(alltrue_epi128<long>(n_is_zero, 2)))
                        {
                            return result;
                        }

                        a = mullo_epi64(a, a);
                    }
                }
                else throw new IllegalInstructionException();
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_pow_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_EQ_EPI64(a, 0, elements))
                    {
                        return a;
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 1, elements))
                    {
                        return Avx.mm256_set1_epi64x(1);
                    }
                    if (constexpr.ALL_EQ_EPI64(a, 2, elements))
                    {
                        return Avx2.mm256_sllv_epi64(Avx.mm256_set1_epi64x(1), b);
                    }

                    if (constexpr.ALL_SAME_EPU64(b, elements))
                    {
                        switch (b.SLong0)
                        {
                            case 0:  { return Avx.mm256_set1_epi64x(1); }
                             
                            case 1:  { return a; }
                            case 2:  { return mm256_mullo_epi64(a, a, elements); }
                            case 3:  { return mm256_mullo_epi64(a, mm256_mullo_epi64(a, a, elements)); }
                            case 4:  { v256 a2 = mm256_mullo_epi64(a, a, elements); return mm256_mullo_epi64(a2, a2, elements); }
                            case 5:  { v256 a2 = mm256_mullo_epi64(a, a, elements); return mm256_mullo_epi64(a, mm256_mullo_epi64(a2, a2, elements)); }
                            case 6:  { v256 a2 = mm256_mullo_epi64(a, a, elements); return mm256_mullo_epi64(a2, mm256_mullo_epi64(a2, a2, elements)); }
                            case 7:  { v256 a2 = mm256_mullo_epi64(a, a, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a2, a2, elements)); }
                            case 8:  { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(a4, a4, elements); }
                            case 9:  { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(a, mm256_mullo_epi64(a4, a4, elements)); }
                            case 10: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(a2, mm256_mullo_epi64(a4, a4, elements)); }
                            case 11: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a4, a4, elements)); }
                            case 12: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(a4, mm256_mullo_epi64(a4, a4, elements)); }
                            case 13: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_mullo_epi64(a4, a4, elements)); }
                            case 14: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_mullo_epi64(a4, a4, elements)); }
                            case 15: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_mullo_epi64(a4, a4, elements)); }
                            case 16: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(a8, a8, elements); }
                            case 17: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(a, mm256_mullo_epi64(a8, a8, elements)); }
                            case 18: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(a2, mm256_mullo_epi64(a8, a8, elements)); }
                            case 19: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 20: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(a4, mm256_mullo_epi64(a8, a8, elements)); }
                            case 21: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 22: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 23: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 24: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(a8, mm256_mullo_epi64(a8, a8, elements)); }
                            case 25: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 26: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 27: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 28: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 29: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 30: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), mm256_mullo_epi64(a8, a8, elements)); }
                            case 31: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a4, a8, elements)), mm256_mullo_epi64(a8, a8, elements)); }
                            case 32: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a16, a16, elements); }
                            case 33: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a, mm256_mullo_epi64(a16, a16, elements)); }
                            case 34: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a2, mm256_mullo_epi64(a16, a16, elements)); }
                            case 35: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 36: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a4, mm256_mullo_epi64(a16, a16, elements)); }
                            case 37: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 38: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 39: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 40: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a8, mm256_mullo_epi64(a16, a16, elements)); }
                            case 41: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 42: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 43: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 44: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 45: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 46: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 47: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a8, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 48: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(a16, mm256_mullo_epi64(a16, a16, elements)); }
                            case 49: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a, a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 50: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a2, a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 51: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 52: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a4, a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 53: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 54: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 55: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 56: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(a8, a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 57: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 58: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 59: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 60: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a4, a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 61: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a4, elements), a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 62: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a2, a4, elements), a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 63: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); return mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(mm256_mullo_epi64(a, a2, elements), a4, elements), a8, elements), a16, elements), mm256_mullo_epi64(a16, a16, elements)); }
                            case 64: { v256 a2 = mm256_mullo_epi64(a, a, elements); v256 a4 = mm256_mullo_epi64(a2, a2, elements); v256 a8 = mm256_mullo_epi64(a4, a4, elements); v256 a16 = mm256_mullo_epi64(a8, a8, elements); v256 a32 = mm256_mullo_epi64(a16, a16, elements); return mm256_mullo_epi64(a32, a32, elements); }

                            default: break;
                        }
                    }

                    v256 ZERO = Avx.mm256_setzero_si256();
                    v256 ONE = Avx.mm256_set1_epi64x(1);
                    
                    v256 y = mm256_blendv_si256(ONE, a, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b, ONE)));
                    b = Avx2.mm256_srli_epi64(b, 1);
                    v256 doneMask = Avx2.mm256_cmpeq_epi64(ZERO, b);
                    v256 result = Avx2.mm256_and_si256(y, doneMask);
                    
                    if (Hint.Likely(mm256_notalltrue_epi256<long>(doneMask, elements)))
                    {
                        a = mm256_mullo_epi64(a, a, elements);
                    }
                    else
                    {
                        return result;
                    }

                    while (true)
                    {
                        v256 y_times_x = mm256_mullo_epi64(y, a, elements);
                        y = mm256_blendv_si256(y, y_times_x, Avx2.mm256_cmpeq_epi64(ONE, Avx2.mm256_and_si256(b, ONE)));

                        b = Avx2.mm256_srli_epi64(b, 1);
                        
                        v256 n_is_zero = Avx2.mm256_cmpeq_epi64(ZERO, b);
                        result = mm256_blendv_si256(result, y, Avx2.mm256_andnot_si256(doneMask, n_is_zero));
                        doneMask = n_is_zero;

                        if (Hint.Unlikely(mm256_alltrue_epi256<long>(n_is_zero, elements)))
                        {
                            return result;
                        }

                        a = mm256_mullo_epi64(a, a, elements);
                    }
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 intpow(UInt128 x, ulong n)
        {
            if (Constant.IsConstantExpression(x))
            {
                if (x == 0) return 0;
                if (x == 1) return 1;
                //if (x == 2) return (UInt128)1 << (int)n;
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:   { return 1; }
                             
                    case 1:   { return x; }
                    case 2:   { return square(x); }
                    case 3:   { return square(x) * x; }
                    case 4:   { UInt128 x2 = square(x); return square(x2); }
                    case 5:   { UInt128 x2 = square(x); return square(x2) * x; }
                    case 6:   { UInt128 x2 = square(x); return square(x2) * x2; }
                    case 7:   { UInt128 x2 = square(x); return square(x2) * (x * x2); }
                    case 8:   { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4); }
                    case 9:   { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x; }
                    case 10:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x2; }
                    case 11:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x * x2); }
                    case 12:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * x4; }
                    case 13:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x * x4); }
                    case 14:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * (x2 * x4); }
                    case 15:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); return square(x4) * ((x * x2) * x4); }
                    case 16:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8); }
                    case 17:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x; }
                    case 18:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x2; }
                    case 19:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x2); }
                    case 20:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x4; }
                    case 21:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x4); }
                    case 22:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x2 * x4); }
                    case 23:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * x4); }
                    case 24:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * x8; }
                    case 25:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x * x8); }
                    case 26:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x2 * x8); }
                    case 27:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * x8); }
                    case 28:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * (x4 * x8); }
                    case 29:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x4) * x8); }
                    case 30:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x2 * x4) * x8); }
                    case 31:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); return square(x8) * ((x * x2) * (x4 * x8)); }
                    case 32:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16); }
                    case 33:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x; }
                    case 34:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x2; }
                    case 35:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x2); }
                    case 36:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x4; }
                    case 37:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x4); }
                    case 38:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x4); }
                    case 39:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x4); }
                    case 40:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x8; }
                    case 41:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x8); }
                    case 42:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x8); }
                    case 43:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x8); }
                    case 44:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x4 * x8); }
                    case 45:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x4) * x8); }
                    case 46:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x4) * x8); }
                    case 47:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x8); }
                    case 48:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * x16; }
                    case 49:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x * x16); }
                    case 50:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x2 * x16); }
                    case 51:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x2) * x16); }
                    case 52:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x4 * x16); }
                    case 53:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x4) * x16); }
                    case 54:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x4) * x16); }
                    case 55:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x4) * x16); }
                    case 56:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (x8 * x16); }
                    case 57:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x * x8) * x16); }
                    case 58:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x2 * x8) * x16); }
                    case 59:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x2) * x8) * x16); }
                    case 60:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((x4 * x8) * x16); }
                    case 61:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x * x4) * x8) * x16); }
                    case 62:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * (((x2 * x4) * x8) * x16); }
                    case 63:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); return square(x16) * ((((x * x2) * x4) * x8) * x16); }
                    case 64:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32); }
                    case 65:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x; }
                    case 66:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x2; }
                    case 67:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x2); }
                    case 68:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x4; }
                    case 69:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x4); }
                    case 70:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x4); }
                    case 71:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x4); }
                    case 72:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x8; }
                    case 73:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x8); }
                    case 74:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x8); }
                    case 75:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x8); }
                    case 76:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x4 * x8); }
                    case 77:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x4) * x8); }
                    case 78:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x4) * x8); }
                    case 79:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x8); }
                    case 80:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x16; }
                    case 81:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x * x16); }
                    case 82:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x2 * x16); }
                    case 83:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x2) * x16); }
                    case 84:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x4 * x16); }
                    case 85:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x4) * x16); }
                    case 86:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x4) * x16); }
                    case 87:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x4) * x16); }
                    case 88:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x8 * x16); }
                    case 89:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x * x8) * x16); }
                    case 90:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x2 * x8) * x16); }
                    case 91:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x2) * x8) * x16); }
                    case 92:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((x4 * x8) * x16); }
                    case 93:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x * x4) * x8) * x16); }
                    case 94:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (((x2 * x4) * x8) * x16); }
                    case 95:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * ((((x * x2) * x4) * x8) * x16); }
                    case 96:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * x32; }
                    case 97:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x); }
                    case 98:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x2); }
                    case 99:  { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x2)); }
                    case 100: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x4); }
                    case 101: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x4)); }
                    case 102: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x4)); }
                    case 103: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x4)); }
                    case 104: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x8); }
                    case 105: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x8)); }
                    case 106: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x8)); }
                    case 107: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x8)); }
                    case 108: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x4 * x8)); }
                    case 109: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x8)); }
                    case 110: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x8)); }
                    case 111: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x8)); }
                    case 112: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * x16); }
                    case 113: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x * x16)); }
                    case 114: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x2 * x16)); }
                    case 115: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x2) * x16)); }
                    case 116: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x4 * x16)); }
                    case 117: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x4) * x16)); }
                    case 118: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x4) * x16)); }
                    case 119: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x4) * x16)); }
                    case 120: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (x8 * x16)); }
                    case 121: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x * x8) * x16)); }
                    case 122: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x2 * x8) * x16)); }
                    case 123: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x2) * x8) * x16)); }
                    case 124: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((x4 * x8) * x16)); }
                    case 125: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x * x4) * x8) * x16)); }
                    case 126: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * (((x2 * x4) * x8) * x16)); }
                    case 127: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); return square(x32) * (x32 * ((((x * x2) * x4) * x8) * x16)); }
                    case 128: { UInt128 x2 = square(x); UInt128 x4 = square(x2); UInt128 x8 = square(x4); UInt128 x16 = square(x8); UInt128 x32 = square(x16); UInt128 x64 = square(x32); return square(x64); }

                    default: break;
                }
            }

            UInt128 y = isdivisible(n, 2) ? 1 : x;
            x = square(x);
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }

                n >>= 1;

                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }

                x = square(x);
            }
        }
        
        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 intpow(Int128 x, ulong n)
        {
            return (Int128)intpow((UInt128)x, n);
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long intpow(long x, ulong n)
        {
            if (Constant.IsConstantExpression(x))
            {
                switch (x)
                {
                    case 0: return 0;
                    case 1: return 1;
                    //case 2: return 1L << (int)n;

                    default: break;
                }
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:  { return 1; }
                             
                    case 1:  { return x; }
                    case 2:  { return x * x; }
                    case 3:  { return x * x * x; }
                    case 4:  { long x2 = x * x; return x2 * x2; }
                    case 5:  { long x2 = x * x; return x * (x2 * x2); }
                    case 6:  { long x2 = x * x; return x2 * (x2 * x2); }
                    case 7:  { long x2 = x * x; return (x * x2) * (x2 * x2); }
                    case 8:  { long x2 = x * x; long x4 = x2 * x2; return x4 * x4; }
                    case 9:  { long x2 = x * x; long x4 = x2 * x2; return x * (x4 * x4); }
                    case 10: { long x2 = x * x; long x4 = x2 * x2; return x2 * (x4 * x4); }
                    case 11: { long x2 = x * x; long x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                    case 12: { long x2 = x * x; long x4 = x2 * x2; return x4 * (x4 * x4); }
                    case 13: { long x2 = x * x; long x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                    case 14: { long x2 = x * x; long x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                    case 15: { long x2 = x * x; long x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                    case 16: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x8 * x8; }
                    case 17: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x * (x8 * x8); }
                    case 18: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x2 * (x8 * x8); }
                    case 19: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                    case 20: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x4 * (x8 * x8); }
                    case 21: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                    case 22: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                    case 23: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                    case 24: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return x8 * (x8 * x8); }
                    case 25: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                    case 26: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                    case 27: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                    case 28: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                    case 29: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                    case 30: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                    case 31: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                    case 32: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x16 * x16; }
                    case 33: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x * (x16 * x16); }
                    case 34: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x2 * (x16 * x16); }
                    case 35: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x2) * (x16 * x16); }
                    case 36: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x4 * (x16 * x16); }
                    case 37: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x4) * (x16 * x16); }
                    case 38: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x4) * (x16 * x16); }
                    case 39: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x4) * (x16 * x16); }
                    case 40: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x8 * (x16 * x16); }
                    case 41: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x8) * (x16 * x16); }
                    case 42: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x8) * (x16 * x16); }
                    case 43: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x8) * (x16 * x16); }
                    case 44: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x4 * x8) * (x16 * x16); }
                    case 45: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x4) * x8) * (x16 * x16); }
                    case 46: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x4) * x8) * (x16 * x16); }
                    case 47: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x4) * x8) * (x16 * x16); }
                    case 48: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return x16 * (x16 * x16); }
                    case 49: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x * x16) * (x16 * x16); }
                    case 50: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x2 * x16) * (x16 * x16); }
                    case 51: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x2) * x16) * (x16 * x16); }
                    case 52: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x4 * x16) * (x16 * x16); }
                    case 53: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x4) * x16) * (x16 * x16); }
                    case 54: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x4) * x16) * (x16 * x16); }
                    case 55: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x4) * x16) * (x16 * x16); }
                    case 56: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (x8 * x16) * (x16 * x16); }
                    case 57: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x * x8) * x16) * (x16 * x16); }
                    case 58: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x2 * x8) * x16) * (x16 * x16); }
                    case 59: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x2) * x8) * x16) * (x16 * x16); }
                    case 60: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((x4 * x8) * x16) * (x16 * x16); }
                    case 61: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x * x4) * x8) * x16) * (x16 * x16); }
                    case 62: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return (((x2 * x4) * x8) * x16) * (x16 * x16); }
                    case 63: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; return ((((x * x2) * x4) * x8) * x16) * (x16 * x16); }
                    case 64: { long x2 = x * x; long x4 = x2 * x2; long x8 = x4 * x4; long x16 = x8 * x8; long x32 = x16 * x16; return x32 * x32; }

                    default: break;
                }
            }

            long y = isdivisible(n, 2) ? 1 : x;
            x *= x;
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }

                n >>= 1;
                
                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }

                x *= x;
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 intpow(long2 x, ulong2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi64(x, n);
            }
            else
            {
                return new long2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 intpow(long3 x, ulong3 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow_epi64(x, n, 3);
            }
            else
            {
                return new long3(intpow(x.xy, n.xy), intpow(x.z, n.z));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 intpow(long4 x, ulong4 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow_epi64(x, n, 4);
            }
            else
            {
                return new long4(intpow(x.xy, n.xy), intpow(x.zw, n.zw));
            }
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong intpow(ulong x, ulong n)
        {
            return (ulong)intpow((long)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 intpow(ulong2 x, ulong2 n)
        {
            return (ulong2)intpow((long2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 intpow(ulong3 x, ulong3 n)
        {
            return (ulong3)intpow((long3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 intpow(ulong4 x, ulong4 n)
        {
            return (ulong4)intpow((long4)x, n);
        }


        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(int x, uint n)
        {
            if (Constant.IsConstantExpression(x))
            {
                switch (x)
                {
                    case 0: return 0;
                    case 1: return 1;
                    //case 2: return 1 << (int)n;

                    default: break;
                }
            }

            if (Constant.IsConstantExpression(n))
            {
                switch (n)
                {
                    case 0:  { return 1; }
                             
                    case 1:  { return x; }
                    case 2:  { return x * x; }
                    case 3:  { return x * x * x; }
                    case 4:  { int x2 = x * x; return x2 * x2; }
                    case 5:  { int x2 = x * x; return x * (x2 * x2); }
                    case 6:  { int x2 = x * x; return x2 * (x2 * x2); }
                    case 7:  { int x2 = x * x; return (x * x2) * (x2 * x2); }
                    case 8:  { int x2 = x * x; int x4 = x2 * x2; return x4 * x4; }
                    case 9:  { int x2 = x * x; int x4 = x2 * x2; return x * (x4 * x4); }
                    case 10: { int x2 = x * x; int x4 = x2 * x2; return x2 * (x4 * x4); }
                    case 11: { int x2 = x * x; int x4 = x2 * x2; return (x * x2) * (x4 * x4); }
                    case 12: { int x2 = x * x; int x4 = x2 * x2; return x4 * (x4 * x4); }
                    case 13: { int x2 = x * x; int x4 = x2 * x2; return (x * x4) * (x4 * x4); }
                    case 14: { int x2 = x * x; int x4 = x2 * x2; return (x2 * x4) * (x4 * x4); }
                    case 15: { int x2 = x * x; int x4 = x2 * x2; return ((x * x2) * x4) * (x4 * x4); }
                    case 16: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x8 * x8; }
                    case 17: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x * (x8 * x8); }
                    case 18: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x2 * (x8 * x8); }
                    case 19: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x2) * (x8 * x8); }
                    case 20: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x4 * (x8 * x8); }
                    case 21: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x4) * (x8 * x8); }
                    case 22: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x2 * x4) * (x8 * x8); }
                    case 23: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * x4) * (x8 * x8); }
                    case 24: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return x8 * (x8 * x8); }
                    case 25: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x * x8) * (x8 * x8); }
                    case 26: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x2 * x8) * (x8 * x8); }
                    case 27: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * x8) * (x8 * x8); }
                    case 28: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return (x4 * x8) * (x8 * x8); }
                    case 29: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x4) * x8) * (x8 * x8); }
                    case 30: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x2 * x4) * x8) * (x8 * x8); }
                    case 31: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; return ((x * x2) * (x4 * x8)) * (x8 * x8); }
                    case 32: { int x2 = x * x; int x4 = x2 * x2; int x8 = x4 * x4; int x16 = x8 * x8; return x16 * x16; }

                    default: break;
                }
            }

            int y = isdivisible(n, 2) ? 1 : x;
            x *= x;
            n >>= 1;
            if (Hint.Unlikely(n == 0))
            {
                return y;
            }

            while (true)
            {
                if (!isdivisible(n, 2))
                {
                    y *= x;
                }
            
                n >>= 1;
            
                if (Hint.Unlikely(n == 0))
                {
                    return y;
                }
            
                x *= x;
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 intpow(int2 x, uint2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.pow_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 2));
            }
            else
            {
                return new int2(intpow(x.x, n.x), intpow(x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 intpow(int3 x, uint3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.pow_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 3));
            }
            else
            {
                return new int3(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 intpow(int4 x, uint4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                
                return RegisterConversion.ToInt4(Xse.pow_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), 4));
            }
            else
            {
                return new int4(intpow(x.x, n.x), intpow(x.y, n.y), intpow(x.z, n.z), intpow(x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 intpow(int8 x, uint8 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow_epi32(x, n);
            }
            else
            {
                return new int8(intpow(x.v4_0, n.v4_0), intpow(x.v4_4, n.v4_4));
            }
        }
        

        /// <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(uint x, uint n)
        {
            return (uint)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 intpow(uint2 x, uint2 n)
        {
            return (uint2)intpow((int2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 intpow(uint3 x, uint3 n)
        {
            return (uint3)intpow((int3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 intpow(uint4 x, uint4 n)
        {
            return (uint4)intpow((int4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 intpow(uint8 x, uint8 n)
        {
            return (uint8)intpow((int8)x, n);
        }


        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(short x, uint n)
        {
            return (int)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 intpow(short2 x, ushort2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi16(x, n, 2);
            }
            else
            {
                return new short2((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y));
            }
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 intpow(short3 x, ushort3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi16(x, n, 3);
            }
            else
            {
                return new short3((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 intpow(short4 x, ushort4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi16(x, n, 4);
            }
            else
            {
                return new short4((short)intpow((int)x.x, n.x), (short)intpow((int)x.y, n.y), (short)intpow((int)x.z, n.z), (short)intpow((int)x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 intpow(short8 x, ushort8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi16(x, n, 8);
            }
            else
            {
                return new short8((short)intpow((int)x.x0, n.x0), 
                                  (short)intpow((int)x.x1, n.x1), 
                                  (short)intpow((int)x.x2, n.x2),
                                  (short)intpow((int)x.x3, n.x3),
                                  (short)intpow((int)x.x4, n.x4),
                                  (short)intpow((int)x.x5, n.x5),
                                  (short)intpow((int)x.x6, n.x6),
                                  (short)intpow((int)x.x7, n.x7));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 intpow(short16 x, ushort16 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow_epi16(x, n);
            }
            else
            {
                return new short16(intpow(x.v8_0, n.v8_0), intpow(x.v8_8, n.v8_8));
            }
        }
        

        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(ushort x, uint n)
        {
            return (uint)intpow((uint)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 intpow(ushort2 x, ushort2 n)
        {
            return (ushort2)intpow((short2)x, n);
        }

        /// <summary>       Computes <paramref name="x"/> to the power of <paramref name="n"/> for each corresponding component.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 intpow(ushort3 x, ushort3 n)
        {
            return (ushort3)intpow((short3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 intpow(ushort4 x, ushort4 n)
        {
            return (ushort4)intpow((short4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 intpow(ushort8 x, ushort8 n)
        {
            return (ushort8)intpow((short8)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 intpow(ushort16 x, ushort16 n)
        {
            return (ushort16)intpow((short16)x, n);
        }


        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int intpow(sbyte x, uint n)
        {
            return (int)intpow((int)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 intpow(sbyte2 x, byte2 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi8(x, n, 2);
            }
            else
            {
                return new sbyte2((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 intpow(sbyte3 x, byte3 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi8(x, n, 3);
            }
            else
            {
                return new sbyte3((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 intpow(sbyte4 x, byte4 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi8(x, n, 4);
            }
            else
            {
                return new sbyte4((sbyte)intpow((int)x.x, n.x), (sbyte)intpow((int)x.y, n.y), (sbyte)intpow((int)x.z, n.z), (sbyte)intpow((int)x.w, n.w));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 intpow(sbyte8 x, byte8 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi8(x, n, 8);
            }
            else
            {
                return new sbyte8((sbyte)intpow((int)x.x0, n.x0),
                                  (sbyte)intpow((int)x.x1, n.x1),
                                  (sbyte)intpow((int)x.x2, n.x2),
                                  (sbyte)intpow((int)x.x3, n.x3),
                                  (sbyte)intpow((int)x.x4, n.x4),
                                  (sbyte)intpow((int)x.x5, n.x5),
                                  (sbyte)intpow((int)x.x6, n.x6),
                                  (sbyte)intpow((int)x.x7, n.x7));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 intpow(sbyte16 x, byte16 n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.pow_epi8(x, n, 16);
            }
            else
            {
                return new sbyte16((sbyte)intpow((int)x.x0,  n.x0),
                                   (sbyte)intpow((int)x.x1,  n.x1),
                                   (sbyte)intpow((int)x.x2,  n.x2),
                                   (sbyte)intpow((int)x.x3,  n.x3),
                                   (sbyte)intpow((int)x.x4,  n.x4),
                                   (sbyte)intpow((int)x.x5,  n.x5),
                                   (sbyte)intpow((int)x.x6,  n.x6),
                                   (sbyte)intpow((int)x.x7,  n.x7),
                                   (sbyte)intpow((int)x.x8,  n.x8),
                                   (sbyte)intpow((int)x.x9,  n.x9),
                                   (sbyte)intpow((int)x.x10, n.x10),
                                   (sbyte)intpow((int)x.x11, n.x11),
                                   (sbyte)intpow((int)x.x12, n.x12),
                                   (sbyte)intpow((int)x.x13, n.x13),
                                   (sbyte)intpow((int)x.x14, n.x14),
                                   (sbyte)intpow((int)x.x15, n.x15));
            }
        }
        
        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 intpow(sbyte32 x, byte32 n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_pow_epi8(x, n);
            }
            else
            {
                return new sbyte32(intpow(x.v16_0, n.v16_0), intpow(x.v16_16, n.v16_16));
            }
        }
        

        // <summary>       Returns <paramref name="x"/> raised to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint intpow(byte x, uint n)
        {
            return intpow((uint)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 intpow(byte2 x, byte2 n)
        {
            return (byte2)intpow((sbyte2)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 intpow(byte3 x, byte3 n)
        {
            return (byte3)intpow((sbyte3)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 intpow(byte4 x, byte4 n)
        {
            return (byte4)intpow((sbyte4)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 intpow(byte8 x, byte8 n)
        {
            return (byte8)intpow((sbyte8)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 intpow(byte16 x, byte16 n)
        {
            return (byte16)intpow((sbyte16)x, n);
        }

        /// <summary>       Returns the componentwise result of raising <paramref name="x"/> to the power <paramref name="n"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 intpow(byte32 x, byte32 n)
        {
            return (byte32)intpow((sbyte32)x, n);
        }
    }
}