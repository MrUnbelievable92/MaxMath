using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public partial struct UInt128
    {
        internal static partial class Common
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 ror_SSE(UInt128 x, int n)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (Xse.constexpr.IS_TRUE(n % 8 == 0))
                    {
                        v128 sse = *(v128*)&x;

                        switch (n % 128)
                        {
                            case 8:   sse = Ssse3.alignr_epi8(sse, sse,  1 * sizeof(byte));   break;
                            case 16:  sse = Ssse3.alignr_epi8(sse, sse,  2 * sizeof(byte));   break;
                            case 24:  sse = Ssse3.alignr_epi8(sse, sse,  3 * sizeof(byte));   break;
                            case 32:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(0, 3, 2, 1)); break;
                            case 40:  sse = Ssse3.alignr_epi8(sse, sse,  5 * sizeof(byte));   break;
                            case 48:  sse = Ssse3.alignr_epi8(sse, sse,  6 * sizeof(byte));   break;
                            case 56:  sse = Ssse3.alignr_epi8(sse, sse,  7 * sizeof(byte));   break;
                            case 64:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(1, 0, 3, 2)); break;
                            case 72:  sse = Ssse3.alignr_epi8(sse, sse,  9 * sizeof(byte));   break;
                            case 80:  sse = Ssse3.alignr_epi8(sse, sse, 10 * sizeof(byte));   break;
                            case 88:  sse = Ssse3.alignr_epi8(sse, sse, 11 * sizeof(byte));   break;
                            case 96:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(2, 1, 0, 3)); break;
                            case 104: sse = Ssse3.alignr_epi8(sse, sse, 13 * sizeof(byte));   break;
                            case 112: sse = Ssse3.alignr_epi8(sse, sse, 14 * sizeof(byte));   break;
                            case 120: sse = Ssse3.alignr_epi8(sse, sse, 15 * sizeof(byte));   break;

                            default: break;
                        }

                        return *(UInt128*)&sse;
                    }
                }

                return maxmath.ror(x, n);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 rol_SSE(UInt128 x, int n)
            {
                if (Ssse3.IsSsse3Supported)
                {
                    if (Xse.constexpr.IS_TRUE(n % 8 == 0))
                    {
                        v128 sse = *(v128*)&x;

                        switch (n % 128)
                        {
                            case 8:   sse = Ssse3.alignr_epi8(sse, sse, 15 * sizeof(byte));   break;
                            case 16:  sse = Ssse3.alignr_epi8(sse, sse, 14 * sizeof(byte));   break;
                            case 24:  sse = Ssse3.alignr_epi8(sse, sse, 13 * sizeof(byte));   break;
                            case 32:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(2, 1, 0, 3)); break;
                            case 40:  sse = Ssse3.alignr_epi8(sse, sse, 11 * sizeof(byte));   break;
                            case 48:  sse = Ssse3.alignr_epi8(sse, sse, 10 * sizeof(byte));   break;
                            case 56:  sse = Ssse3.alignr_epi8(sse, sse,  9 * sizeof(byte));   break;
                            case 64:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(1, 0, 3, 2)); break;
                            case 72:  sse = Ssse3.alignr_epi8(sse, sse,  7 * sizeof(byte));   break;
                            case 80:  sse = Ssse3.alignr_epi8(sse, sse,  6 * sizeof(byte));   break;
                            case 88:  sse = Ssse3.alignr_epi8(sse, sse,  5 * sizeof(byte));   break;
                            case 96:  sse = Sse2.shuffle_epi32(sse, Sse.SHUFFLE(0, 3, 2, 1)); break;
                            case 104: sse = Ssse3.alignr_epi8(sse, sse,  3 * sizeof(byte));   break;
                            case 112: sse = Ssse3.alignr_epi8(sse, sse,  2 * sizeof(byte));   break;
                            case 120: sse = Ssse3.alignr_epi8(sse, sse,  1 * sizeof(byte));   break;

                            default: break;
                        }

                        return *(UInt128*)&sse;
                    }
                }

                return maxmath.rol(x, n);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 and_SSE(UInt128 x, UInt128 y)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 t = Sse2.and_si128(*(v128*)&x, *(v128*)&y);

                    return *(UInt128*)&t;
                }
                else 
                {
                    return x & y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 or_SSE(UInt128 x, UInt128 y)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 t = Sse2.or_si128(*(v128*)&x, *(v128*)&y);

                    return *(UInt128*)&t;
                }
                else 
                {
                    return x | y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 xor_SSE(UInt128 x, UInt128 y)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 t = Sse2.xor_si128(*(v128*)&x, *(v128*)&y);

                    return *(UInt128*)&t;
                }
                else 
                {
                    return x ^ y;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 andn_SSE(UInt128 x, UInt128 y)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 t = Sse2.andnot_si128(*(v128*)&y, *(v128*)&x);

                    return *(UInt128*)&t;
                }
                else 
                {
                    return maxmath.andnot(x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 shl_SSE(UInt128 x, int n)
            {
Assert.IsBetween(n, 0, 128);
            
                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.IS_TRUE(n % 8 == 0))
                    {
                        switch (n % 128)
                        {
                            case 8:   { v128 sse = Sse2.bslli_si128(*(v128*)&x, 1);  return *(UInt128*)&sse; }
                            case 16:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 2);  return *(UInt128*)&sse; }
                            case 24:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 3);  return *(UInt128*)&sse; }
                            case 32:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 4);  return *(UInt128*)&sse; }
                            case 40:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 5);  return *(UInt128*)&sse; }
                            case 48:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 6);  return *(UInt128*)&sse; }
                            case 56:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 7);  return *(UInt128*)&sse; }                                     
                            case 64:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 8);  return *(UInt128*)&sse; }
                            case 72:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 9);  return *(UInt128*)&sse; }
                            case 80:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 10); return *(UInt128*)&sse; }
                            case 88:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 11); return *(UInt128*)&sse; }
                            case 96:  { v128 sse = Sse2.bslli_si128(*(v128*)&x, 12); return *(UInt128*)&sse; }
                            case 104: { v128 sse = Sse2.bslli_si128(*(v128*)&x, 13); return *(UInt128*)&sse; }
                            case 112: { v128 sse = Sse2.bslli_si128(*(v128*)&x, 14); return *(UInt128*)&sse; }
                            case 120: { v128 sse = Sse2.bslli_si128(*(v128*)&x, 15); return *(UInt128*)&sse; }
            
                            default: return x;
                        }
                    }
                }
                
                return x << n;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static UInt128 shrl_SSE(UInt128 x, int n)
            {
Assert.IsBetween(n, 0, 128);

                if (Sse2.IsSse2Supported)
                {
                    if (Xse.constexpr.IS_TRUE(n % 8 == 0))
                    {
                        switch (n % 128)
                        {
                            case 8:   { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 1);  return *(UInt128*)&sse; }
                            case 16:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 2);  return *(UInt128*)&sse; }
                            case 24:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 3);  return *(UInt128*)&sse; }
                            case 32:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 4);  return *(UInt128*)&sse; }
                            case 40:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 5);  return *(UInt128*)&sse; }
                            case 48:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 6);  return *(UInt128*)&sse; }
                            case 56:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 7);  return *(UInt128*)&sse; }                                     
                            case 64:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 8);  return *(UInt128*)&sse; }
                            case 72:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 9);  return *(UInt128*)&sse; }
                            case 80:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 10); return *(UInt128*)&sse; }
                            case 88:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 11); return *(UInt128*)&sse; }
                            case 96:  { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 12); return *(UInt128*)&sse; }
                            case 104: { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 13); return *(UInt128*)&sse; }
                            case 112: { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 14); return *(UInt128*)&sse; }
                            case 120: { v128 sse = Sse2.bsrli_si128(*(v128*)&x, 15); return *(UInt128*)&sse; }

                            default: return x;
                        }
                    }
                }
                
                return x >> n;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static Int128 shra_SSE(Int128 x, int n)
            {
Assert.IsBetween(n, 0, 128);

                if (Ssse3.IsSsse3Supported)
                {
                    if (Xse.constexpr.IS_TRUE(n % 8 == 0))
                    {
                        switch (n % 128)
                        {
                            case 8:   
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 1), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 16:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 2), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 24:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 3), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 32:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 4), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 40:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 5), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 48:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 6), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 56:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 7), signSplat);

                                return *(Int128*)&sse;
                            }                                      
                            case 64:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 8), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 72:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 9), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 80:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 10), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 88:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 11), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 96:  
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 12), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 104: 
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 13), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 112: 
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 14), signSplat);

                                return *(Int128*)&sse;
                            }
                            case 120: 
                            { 
                                v128 sse = *(v128*)&x;

                                v128 signSplat = Ssse3.shuffle_epi8(Sse2.srai_epi32(sse, 31), new v128(-1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                                sse = Sse2.or_si128(Sse2.bsrli_si128(sse, 15), signSplat);

                                return *(Int128*)&sse;
                            }

                            default: return x;
                        }
                    }
                }
                
                return x >> n;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_mix_ones_zeroes(UInt128 x)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    int i = Sse4_1.test_mix_ones_zeroes(*(v128*)&x, Xse.setall_si128());
            
                    return *(bool*)&i;
                }

                return x.IsNotZero & x.IsNotMaxValue;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_mix_ones_zeroes(Int128 x)
            {
                return test_mix_ones_zeroes(x.intern);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_all_ones(UInt128 x)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    int i = Sse4_1.test_all_ones(*(v128*)&x);
            
                    return *(bool*)&i;
                }
                
                return x.IsMaxValue;
            }
            
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_all_ones(Int128 x)
            {
                return test_all_ones(x.intern);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_all_zeros(UInt128 x)
            {
                if (Sse4_1.IsSse41Supported)
                {
                    int i = Sse4_1.test_all_zeros(*(v128*)&x, Xse.setall_si128());
            
                    return *(bool*)&i;
                }
                
                return x.IsZero;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal static bool test_all_zeros(Int128 x)
            {
                return test_all_zeros(x.intern);
            }
        }
    }
}