using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.Intrinsics.Xse;

namespace MaxMath
{
    unsafe internal static class Join
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v2_epi8(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi16(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v4v4_epi8(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi32(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v8v8_epi8(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi64(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v3v3_epi8(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hi;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(byte)), c, 16 - 3 * sizeof(byte) - 2 * sizeof(byte));
                }
                else
                {
                    v128 mid = bslli_si128(b, 2 * sizeof(byte));
                    hi  = bslli_si128(c, 5 * sizeof(byte));

                    hi = blendv_si128(mid, hi, new v128(0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0));
                }

                return blend_epi16(a, hi, 0b0000_1110);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v2v3_epi8(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 hi = alignr_epi8(bslli_si128(b, 16 - 2 * sizeof(byte)), c, 16 - 2 * sizeof(byte));
                return alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), hi, 16 - 3 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hi = bslli_si128(c, 2 * sizeof(byte));
                hi = blend_epi16(b, hi, 0b0000_0110);
                hi = bslli_si128(hi, 3 * sizeof(byte));
                
                return blendv_si128(a, hi, new v128(0, 0, 0, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v3v2_epi8(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(byte)), c, 16 - 3 * sizeof(byte));
                return alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), hi, 16 - 3 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 mid = bslli_si128(b, 3 * sizeof(byte));
                v128 hi  = bslli_si128(c, 6 * sizeof(byte));

                mid = blendv_si128(a, mid, new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

                return blend_epi16(mid, hi, 0b0000_1000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v4v3v3v3v3_epi8(v128 a, v128 b, v128 c, v128 d, v128 e)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_6 = v4v4_epi8(a, b);
                v128 _0_9 = alignr_epi8(bslli_si128(_0_6, 16 - 7 * sizeof(byte)), c, 16 - 13 * sizeof(byte));
                v128 _10_15 = alignr_epi8(bslli_si128(d, 16 - 3 * sizeof(byte)), e, 16 - 3 * sizeof(byte));

                return alignr_epi8(_0_9, _10_15, 16 - 10 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _0_6   = v4v4_epi8(a, b);
                v128 _7_9   = bslli_si128(c,  7 * sizeof(byte));
                v128 _10_12 = bslli_si128(d, 10 * sizeof(byte));
                v128 _13_15 = bslli_si128(e, 13 * sizeof(byte));

                v128 lo = blendv_si128(_0_6,   _7_9,   new v128(0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = blendv_si128(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                return blend_epi16(lo, hi, 0b1110_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v4v3v3v3_epi8(v128 a, v128 b, v128 c, v128 d, v128 e)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_6 = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), b, 4 * sizeof(byte));
                v128 _0_9 = alignr_epi8(_0_6, c, 3 * sizeof(byte));
                v128 _10_15 = alignr_epi8(bslli_si128(d, 16 - 3 * sizeof(byte)), e, 16 - 3 * sizeof(byte));

                return alignr_epi8(_0_9, _10_15, 16 - 10 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _3_9   = unpacklo_epi32(b, c);
                _3_9        = bslli_si128(_3_9, 3 * sizeof(byte));
                v128 _10_12 = bslli_si128(d, 10 * sizeof(byte));
                v128 _13_15 = bslli_si128(e, 13 * sizeof(byte));

                v128 lo = blendv_si128(a, _3_9, new v128(0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0, 0, 0));
                v128 hi = blendv_si128(_10_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                return blend_epi16(lo, hi, 0b1110_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v3v4v3v3_epi8(v128 a, v128 b, v128 c, v128 d, v128 e)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_5 = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), b, 3 * sizeof(byte));
                v128 _0_9 = alignr_epi8(_0_5, c, 4 * sizeof(byte));
                v128 _10_15 = alignr_epi8(bslli_si128(d, 16 - 3 * sizeof(byte)), e, 16 - 3 * sizeof(byte));

                return alignr_epi8(_0_9, _10_15, 16 - 10 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _3_5   = bslli_si128(b, 3 * sizeof(byte));
                v128 _6_12  = unpacklo_epi32(c, d);
                _6_12       = bslli_si128(_6_12, 6 * sizeof(byte));
                v128 _13_15 = bslli_si128(e, 13 * sizeof(byte));

                v128 lo = blendv_si128(a, _3_5, new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = blendv_si128(_6_12, _13_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255));

                return blend_epi16(lo, hi, 0b1111_1000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v3v3v4v3_epi8(v128 a, v128 b, v128 c, v128 d, v128 e)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_5 = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), b, 3 * sizeof(byte));
                v128 _0_8 = alignr_epi8(_0_5, c, 3 * sizeof(byte));
                v128 _9_15 = alignr_epi8(bslli_si128(d, 16 - 4 * sizeof(byte)), e, 16 - 4 * sizeof(byte));

                return alignr_epi8(_0_8, _9_15, 16 - 9 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _3_5  = bslli_si128(b, 3 * sizeof(byte));
                v128 _6_8  = bslli_si128(c, 6 * sizeof(byte));
                v128 _9_15 = unpacklo_epi32(d, e);
                _9_15      = bslli_si128(_9_15, 9 * sizeof(byte));

                v128 lo = blendv_si128(a, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 hi = blendv_si128(_6_8, _9_15, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255));

                return blendv_si128(lo, hi, new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v3v3v3v4_epi8(v128 a, v128 b, v128 c, v128 d, v128 e)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_5 = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(byte)), b, 3 * sizeof(byte));
                v128 _0_8 = alignr_epi8(_0_5, c, 3 * sizeof(byte));
                v128 _9_15 = alignr_epi8(bslli_si128(d, 16 - 3 * sizeof(byte)), e, 16 - 3 * sizeof(byte));

                return alignr_epi8(_0_8, _9_15, 16 - 9 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _3_5   = bslli_si128(b, 3 * sizeof(byte));
                v128 _6_8   = bslli_si128(c, 6 * sizeof(byte));
                v128 _9_11  = bslli_si128(d, 9 * sizeof(byte));
                v128 _12_15 = bslli_si128(e, 12 * sizeof(byte));

                v128 lo  = blendv_si128(a, _3_5,  new v128(0, 0, 0, 255, 255, 255, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
                v128 mid = blendv_si128(_6_8, _9_11, new v128(0, 0, 0, 0, 0, 0, 0, 0, 0, 255, 255, 255, 0, 0, 0, 0));
                lo       = blendv_si128(lo, mid,     new v128(0, 0, 0, 0, 0, 0, 255, 255, 255, 255, 255, 255, 0, 0, 0, 0));

                return blend_epi16(lo, _12_15, 0b1100_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v4v8v4_epi8(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 _0_11 = alignr_epi8(bslli_si128(a, 16 - 4 * sizeof(byte)), b, 8 * sizeof(byte));

                return alignr_epi8(_0_11, c, 16 - 12 * sizeof(byte));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return v8v8_epi8(v4v4_epi8(a, b),
                                 v4v4_epi8(bsrli_si128(b, 4 * sizeof(byte)), c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v4v2_epi8(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 hi = alignr_epi8(bslli_si128(b, 16 - 4 * sizeof(byte)), c, 16 - 4 * sizeof(byte) - 2 * sizeof(byte));
                return blend_epi16(a, hi, 0b0000_1110);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return v4v4_epi8(unpacklo_epi16(a, b),
                                 unpacklo_epi16(bsrli_si128(b, 2 * sizeof(byte)), c));
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v2_epi16(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi32(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v4v4_epi16(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi64(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v3v3_epi16(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hi;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(ushort)), c, 16 - 3 * sizeof(ushort) - 2 * sizeof(ushort));
                }
                else
                {
                    v128 mid = bslli_si128(b, 2 * sizeof(ushort));
                    hi = bslli_si128(c, 5 * sizeof(ushort));

                    hi = blend_epi16(mid, hi, 0b1110_0000);
                }
                
                return blend_epi16(a, hi, 0b1111_1100);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v2v3_epi16(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hi;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    hi = alignr_epi8(bslli_si128(b, 16 - 2 * sizeof(ushort)), c, 16 - 2 * sizeof(ushort) - 3 * sizeof(ushort));
                }
                else
                {
                    hi = bslli_si128(c, 2 * sizeof(short));
                    
                    hi = blend_epi16(b, hi, 0b0001_1100);
                    hi = bslli_si128(hi, 3 * sizeof(short));
                }
                
                return blend_epi16(a, hi, 0b1111_1000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v3v3v2_epi16(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 hi;
                if (BurstArchitecture.IsTableLookupSupported)
                {
                    hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(ushort)), c, 16 - 3 * sizeof(ushort) - 3 * sizeof(ushort));
                }
                else
                {
                    v128 mid = bslli_si128(b, 3 * sizeof(ushort));
                    hi = bslli_si128(c, 6 * sizeof(ushort));
                    hi = blend_epi16(hi, mid, 0b0011_1000);
                }
                
                return blend_epi16(a, hi, 0b1111_1000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v4v2_epi16(v128 a, v128 b, v128 c)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                v128 hi = alignr_epi8(bslli_si128(b, 16 - 4 * sizeof(ushort)), c, 16 - 4 * sizeof(ushort) - 2 * sizeof(ushort));
                return blend_epi16(a, hi, 0b1111_1100);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return v4v4_epi16(unpacklo_epi32(a, b),
                                  unpacklo_epi32(Xse.bsrli_si128(b, 2 * sizeof(ushort)), c));
            }
            else throw new IllegalInstructionException();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 v2v2_epi32(v128 a, v128 b)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return unpacklo_epi64(a, b);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void v2v3v3_epi32(v128 a, v128 b, v128 c, out v128 lo, out v128 hi)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                lo = v2v2_epi32(a, b);
                hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(uint)), c, 16 - 1 * sizeof(uint));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                lo = unpacklo_epi64(a, b);
                v128 mid = bsrli_si128(b, 2 * sizeof(uint));
                hi = bslli_si128(c, sizeof(uint));

                hi = blend_epi16(mid, hi, 0b1111_1100);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void v3v2v3_epi32(v128 a, v128 b, v128 c, out v128 lo, out v128 hi)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                lo = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(uint)), b, 16 - 3 * sizeof(uint));
                hi = alignr_epi8(bslli_si128(b, 16 - 2 * sizeof(uint)), c, 16 - 1 * sizeof(uint));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 mid = bslli_si128(b, 3 * sizeof(uint));
                lo = blend_epi16(a, mid, 0b1100_0000);

                mid = bsrli_si128(b, sizeof(uint));

                hi = bslli_si128(c, sizeof(uint));
                hi = blend_epi16(mid, hi, 0b1111_1100);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void v3v3v2_epi32(v128 a, v128 b, v128 c, out v128 lo, out v128 hi)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                lo = alignr_epi8(bslli_si128(a, 16 - 3 * sizeof(uint)), b, 16 - 3 * sizeof(uint));
                hi = alignr_epi8(bslli_si128(b, 16 - 3 * sizeof(uint)), c, 16 - 2 * sizeof(uint));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 mid = bsrli_si128(b, sizeof(uint));
                hi = unpacklo_epi64(mid, c);

                mid = bslli_si128(b, 3 * sizeof(uint));
                lo = blend_epi16(a, mid, 0b1100_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void v2v4v2_epi32(v128 a, v128 b, v128 c, out v128 lo, out v128 hi)
        {
            if (BurstArchitecture.IsTableLookupSupported)
            {
                lo = v2v2_epi32(a, b);
                hi = alignr_epi8(b, c, 16 - 2 * sizeof(uint));
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                lo = unpacklo_epi64(a, b);
                hi = bslli_si128(c, 2 * sizeof(uint));
                hi = unpackhi_epi64(b, hi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_v2v3v3_epi32(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Avx.mm256_castsi128_si256(a);
                v256 mid = Avx.mm256_castsi128_si256(b);
                v256 hi = Avx.mm256_castsi128_si256(c);

                mid = Avx2.mm256_permute4x64_epi64(mid, Sse.SHUFFLE(1, 1, 0, 0));
                hi  = Avx2.mm256_permutevar8x32_epi32(hi,  new v256(0, 0, 0, 0, 0, 0, 1, 2));

                return Avx2.mm256_blend_epi32(Avx2.mm256_blend_epi32(lo, mid, 0b0001_1100), hi, 0b1110_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_v3v2v3_epi32(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Avx.mm256_castsi128_si256(a);
                v256 mid = Avx.mm256_castsi128_si256(b);
                v256 hi = Avx.mm256_castsi128_si256(c);

                mid = Avx2.mm256_permutevar8x32_epi32(mid, new v256(0, 0, 0, 0, 1, 0, 0, 0));
                hi  = Avx2.mm256_permutevar8x32_epi32(hi,  new v256(0, 0, 0, 0, 0, 0, 1, 2));

                return Avx2.mm256_blend_epi32(Avx2.mm256_blend_epi32(lo, mid, 0b0001_1000), hi, 0b1110_0000);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_v3v3v2_epi32(v128 a, v128 b, v128 c)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 lo = Avx.mm256_castsi128_si256(a);
                v256 mid = Avx.mm256_castsi128_si256(b);
                v256 hi = Avx.mm256_castsi128_si256(c);

                mid = Avx2.mm256_permutevar8x32_epi32(mid, new v256(0, 0, 0, 0, 1, 2, 0, 0));
                hi  = Avx2.mm256_permute4x64_epi64(hi, Sse.SHUFFLE(0, 0, 0, 0));

                return Avx2.mm256_blend_epi32(Avx2.mm256_blend_epi32(lo, mid, 0b0011_1000), hi, 0b1100_0000);
            }
            else throw new IllegalInstructionException();
        }
    }
}
