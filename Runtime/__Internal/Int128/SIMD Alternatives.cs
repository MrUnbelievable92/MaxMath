using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    unsafe public readonly partial struct UInt128
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 blendmask(bool b)
        {
            long _64 = -maxmath.tolong(b);

            return new UInt128(_64, _64);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 signmask(long x)
        {
            return new UInt128(x >> 63, x >> 63);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 shl_SIMD(UInt128 x, int n)
        {
Assert.IsBetween(n, 0, 128);
            
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_TRUE(n % 8 == 0))
                {
                    return Xse.bslli_si128(x.Reinterpret<UInt128, v128>(), n / 8).Reinterpret<v128, UInt128>();
                }
            }

            return x << n;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 shrl_SIMD(UInt128 x, int n)
        {
Assert.IsBetween(n, 0, 128);

            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_TRUE(n % 8 == 0))
                {
                    return Xse.bsrli_si128(x.Reinterpret<UInt128, v128>(), n / 8).Reinterpret<v128, UInt128>();
                }
            }

            return x >> n;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Int128 shra_SIMD(Int128 x, int n)
        {
Assert.IsBetween(n, 0, 128);

            if (Architecture.IsTableLookupSupported)
            {
                if (constexpr.IS_TRUE(n % 8 == 0))
                {
                    switch (n % 128)
                    {
                        case 8:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 1), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 16:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 2), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 24:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 3), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 32:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 4), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 40:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 5), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 48:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 6), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 56:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 7), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 64:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 8), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 72:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 9), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 80:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 10), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 88:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 11), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 96:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 12), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 104:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 13), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 112:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, -1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 14), signSplat);

                            return *(Int128*)&sse;
                        }
                        case 120:
                        {
                            v128 sse = new v128(x.lo64, x.hi64);

                            v128 signSplat = Xse.shuffle_epi8(Xse.srai_epi32(sse, 31), new v128(-1, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15));
                            sse = Xse.or_si128(Xse.bsrli_si128(sse, 15), signSplat);

                            return *(Int128*)&sse;
                        }

                        default: return x;
                    }
                }
            }

            return x >> n;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 ror_SIMD(UInt128 x, int n)
        {
            if (constexpr.IS_TRUE(n % 8 == 0))
            {
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.bror_si128(x.Reinterpret<UInt128, v128>(), n / 8).Reinterpret<v128, UInt128>();
                }
            }

            return maxmath.ror(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 rol_SIMD(UInt128 x, int n)
        {
            if (constexpr.IS_TRUE(n % 8 == 0))
            {
                if (Architecture.IsSIMDSupported)
                {
                    return Xse.brol_si128(x.Reinterpret<UInt128, v128>(), n / 8).Reinterpret<v128, UInt128>();
                }
            }

            return maxmath.rol(x, n);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 not_SIMD(UInt128 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.not_si128(new v128(x.lo64, x.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return ~x ;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 and_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.and_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return x & y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 or_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.or_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return x | y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 xor_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.xor_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return x ^ y;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 nand_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.nand_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return ~(x & y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 nor_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.nor_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return ~(x | y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 xnor_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.xnor_si128(new v128(x.lo64, x.hi64), new v128(y.lo64, y.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return ~(x ^ y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static UInt128 andn_SIMD(UInt128 x, UInt128 y)
        {
            if (Architecture.IsSIMDSupported)
            {
                v128 t = Xse.andnot_si128(new v128(y.lo64, y.hi64), new v128(x.lo64, x.hi64));

                return *(UInt128*)&t;
            }
            else
            {
                return maxmath.andnot(x, y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_mix_ones_zeroes(UInt128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int i = Xse.test_mix_ones_zeroes(new v128(x.lo64, x.hi64), Xse.setall_si128());

                return *(bool*)&i;
            }

            return x.IsNotZero & x.IsNotMaxValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_mix_ones_zeroes(Int128 x)
        {
            return test_mix_ones_zeroes(x.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_all_ones(UInt128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int i = Xse.test_all_ones(new v128(x.lo64, x.hi64));

                return *(bool*)&i;
            }

            return x.IsMaxValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_all_ones(Int128 x)
        {
            return test_all_ones(x.value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_all_zeros(UInt128 x)
        {
            if (Sse4_1.IsSse41Supported)
            {
                int i = Xse.test_all_zeros(new v128(x.lo64, x.hi64), Xse.setall_si128());

                return *(bool*)&i;
            }

            return x.IsZero;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool test_all_zeros(Int128 x)
        {
            return test_all_zeros(x.value);
        }
    }
}