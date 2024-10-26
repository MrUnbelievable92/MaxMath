using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_u8(byte x, ushort mul, byte divisor, DividerPromise promises)
        {
            if (promises.Pow2)
            {
                return pow2_rem_u8(x, divisor) == 0;
            }
            else
            {
                if (constexpr.IS_TRUE(divisor >= 1 << 7))
                {
                    return (x == 0) | (x == divisor);
                }

                return (ushort)(x * mul) <= (ushort)(mul - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_u16(ushort x, uint mul, ushort divisor, DividerPromise promises)
        {
            if (promises.Pow2)
            {
                return pow2_rem_u16(x, divisor) == 0;
            }
            else
            {
                if (constexpr.IS_TRUE(divisor >= 1 << 15))
                {
                    return (x == 0) | (x == divisor);
                }

                return x * mul <= mul - 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_u32(uint x, ulong mul, uint divisor, DividerPromise promises)
        {
            if (promises.Pow2)
            {
                return pow2_rem_u32(x, divisor) == 0;
            }
            else
            {
                if (constexpr.IS_TRUE(divisor >= 1u << 31))
                {
                    return (x == 0) | (x == divisor);
                }

                return x * mul <= mul - 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_u64(ulong x, UInt128 mul, ulong divisor, DividerPromise promises)
        {
            if (promises.Pow2)
            {
                return pow2_rem_u64(x, divisor) == 0;
            }
            else
            {
                if (constexpr.IS_TRUE(divisor >= 1ul << 63))
                {
                    return (x == 0) | (x == divisor);
                }

                return x * mul <= mul - 1;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool bmdivisible_u128(UInt128 x, __UInt256__ mul, UInt128 divisor, DividerPromise promises)
        {
            if (promises.Pow2)
            {
                return pow2_rem_u128(x, divisor).IsZero;
            }
            else
            {
                if (constexpr.IS_TRUE(divisor >= (UInt128)1u << 127))
                {
                    return (x.IsZero) | (x == divisor);
                }

                return x * mul <= mul - 1u;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epu8(v128 a, v128 divisor, v128 mul, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu8(a, divisor, out v128 constVersion, promises, elements))
                {
                    return constVersion;
                }

                v128 cast = Xse.cvtepu8_epi16(a);
                v128 cmp = Xse.cmple_epu16(Xse.mullo_epi16(mul, cast), Xse.dec_epi16(mul), elements);

                return Xse.packs_epi16(cmp, cmp);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epu8(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu8(a, divisor, out v128 constVersion, promises, 16))
                {
                    return constVersion;
                }

                v128 lo = Xse.cvt2x2epu8_epi16(a, out v128 hi);

                v128 cmpLo = Xse.cmple_epu16(Xse.mullo_epi16(mulLo, lo), Xse.dec_epi16(mulLo));
                v128 cmpHi = Xse.cmple_epu16(Xse.mullo_epi16(mulHi, hi), Xse.dec_epi16(mulHi));

                return Xse.packs_epi16(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdivisible_epu8(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (mm256_initconstcheck_epu8(a, divisor, out v256 constVersion, promises))
                {
                    return constVersion;
                }

                v256 lo = Xse.mm256_cvt2x2epu8_epi16(a, out v256 hi);

                v256 cmpLo = Xse.mm256_cmple_epu16(Avx2.mm256_mullo_epi16(new v256(mulLo.Lo128, mulHi.Lo128), lo), Xse.mm256_dec_epi16(new v256(mulLo.Lo128, mulHi.Lo128)));
                v256 cmpHi = Xse.mm256_cmple_epu16(Avx2.mm256_mullo_epi16(new v256(mulLo.Hi128, mulHi.Hi128), hi), Xse.mm256_dec_epi16(new v256(mulLo.Hi128, mulHi.Hi128)));

                return Avx2.mm256_packs_epi16(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epu16(v128 a, v128 divisor, v128 mul, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu16(a, divisor, out v128 constVersion, promises, elements))
                {
                    return constVersion;
                }

                v128 cast = Xse.cvtepu16_epi32(a);
                v128 cmp = Xse.cmple_epu32(Xse.mullo_epi32(mul, cast, elements), Xse.dec_epi32(mul), elements);

                return Xse.packs_epi32(cmp, cmp);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epu16(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu16(a, divisor, out v128 constVersion, promises))
                {
                    return constVersion;
                }

                v128 lo = Xse.cvt2x2epu16_epi32(a, out v128 hi);

                v128 cmpLo = Xse.cmple_epu32(Xse.mullo_epi32(mulLo, lo), Xse.dec_epi32(mulLo));
                v128 cmpHi = Xse.cmple_epu32(Xse.mullo_epi32(mulHi, hi), Xse.dec_epi32(mulHi));

                return Xse.packs_epi32(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmdivisible_epu16(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (mm256_initconstcheck_epu16(a, divisor, out v256 constVersion, promises))
                {
                    return constVersion;
                }

                v256 lo = Xse.mm256_cvt2x2epu16_epi32(a, out v256 hi);

                v256 cmpLo = Xse.mm256_cmple_epu32(Avx2.mm256_mullo_epi32(new v256(mulLo.Lo128, mulHi.Lo128), lo), Xse.mm256_dec_epi32(new v256(mulLo.Lo128, mulHi.Lo128)));
                v256 cmpHi = Xse.mm256_cmple_epu32(Avx2.mm256_mullo_epi32(new v256(mulLo.Hi128, mulHi.Hi128), hi), Xse.mm256_dec_epi32(new v256(mulLo.Hi128, mulHi.Hi128)));

                return Avx2.mm256_packs_epi32(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmnotdivisible_epu32(v128 a, v128 divisor, v128 mul, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu32(a, divisor, out v128 constVersion, promises, 2))
                {
                    return Xse.not_si128(constVersion);
                }

                v128 cast = Xse.cvtepu32_epi64(a);
                v128 cmp = Xse.cmpgt_epu64(Xse.mullo_epi64(mul, cast, unsigned_B_lessequalU32Max: true), Xse.dec_epi64(mul));

                return Xse.cvtepi64_epi32(cmp);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmnotdivisible_epu32(v128 a, v128 divisor, v128 mulLo, v128 mulHi, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu32(a, divisor, out v128 constVersion, promises, elements))
                {
                    return Xse.not_si128(constVersion);
                }

                v128 lo = Xse.cvt2x2epu32_epi64(a, out v128 hi);

                v128 cmpLo = Xse.cmpgt_epu64(Xse.mullo_epi64(mulLo, lo, unsigned_B_lessequalU32Max: true), Xse.dec_epi64(mulLo));
                v128 cmpHi = Xse.cmpgt_epu64(Xse.mullo_epi64(mulHi, hi, unsigned_B_lessequalU32Max: true), Xse.dec_epi64(mulHi));

                return Xse.cvt2x2epi64_epi32(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmnotdivisible_epu32(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (mm256_initconstcheck_epu32(a, divisor, out v256 constVersion, promises))
                {
                    return Xse.mm256_not_si256(constVersion);
                }

                v256 lo = Xse.mm256_cvt2x2epu32_epi64(a, out v256 hi);

                v256 cmpLo = Xse.mm256_cmpgt_epu64(Xse.mm256_mullo_epi64(new v256(mulLo.Lo128, mulHi.Lo128), lo, unsigned_B_lessequalU32Max: true), Xse.mm256_dec_epi64(new v256(mulLo.Lo128, mulHi.Lo128)));
                v256 cmpHi = Xse.mm256_cmpgt_epu64(Xse.mm256_mullo_epi64(new v256(mulLo.Hi128, mulHi.Hi128), hi, unsigned_B_lessequalU32Max: true), Xse.mm256_dec_epi64(new v256(mulLo.Hi128, mulHi.Hi128)));

                return Xse.mm256_cvt2x2epi64_epi32(cmpLo, cmpHi);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v128 bmdivisible_epu64(v128 a, v128 divisor, UInt128 mulLo, UInt128 mulHi, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (initconstcheck_epu64(a, divisor, out v128 constVersion, promises))
                {
                    return constVersion;
                }

                ulong lo = Xse.extract_epi64(a, 0);
                ulong hi = Xse.extract_epi64(a, 1);

                long cmpLo = tobyte(lo * mulLo <= mulLo - 1);
                long cmpHi = tobyte(hi * mulHi <= mulHi - 1);

                return Xse.neg_epi64(Xse.unpacklo_epi64(Xse.cvtsi64x_si128(cmpLo), Xse.cvtsi64x_si128(cmpHi)));
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static v256 mm256_bmnotdivisible_epu64(v256 a, v256 divisor, v256 mulLo, v256 mulHi, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (mm256_initconstcheck_epu64(a, divisor, out v256 constVersion, promises, elements))
                {
                    return Xse.mm256_not_si256(constVersion);
                }

                Xse.mm256_mulloepu128_epu64(mulLo, mulHi, a, out v256 u128Lo64, out v256 u128Hi64, elements);
                Xse.mm256_dec_epu128(mulLo, mulHi, out mulLo, out mulHi);

                return Xse.mm256_cmpgt_epu128(u128Lo64, u128Hi64, mulLo, mulHi, elements);
            }
            else throw new IllegalInstructionException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool initconstcheck_epu8(v128 a, v128 divisor, out v128 result, DividerPromise promises, byte elements = 16)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU8(divisor, 1, elements))
                {
                    result = Xse.setall_si128();

                    return true;
                }
                if (Ssse3.IsSsse3Supported)
                {
                    if (constexpr.ALL_EQ_EPU8(divisor, 16, elements)
                     && constexpr.ALL_LT_EPU8(a, 128, elements))
                    {
                        v128 LUT = new v128(-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                        result = Xse.shuffle_epi8(LUT, a);

                        return true;
                    }
                    if (constexpr.ALL_EQ_EPU8(divisor, 8, elements)
                     && constexpr.ALL_LT_EPU8(a, 128, elements))
                    {
                        v128 LUT = new v128(-1, 0, 0, 0, 0, 0, 0, 0,
                                            -1, 0, 0, 0, 0, 0, 0, 0);

                        result = Xse.shuffle_epi8(LUT, a);

                        return true;
                    }
                    if (constexpr.ALL_EQ_EPU8(divisor, 4, elements)
                     && constexpr.ALL_LT_EPU8(a, 128, elements))
                    {
                        v128 LUT = new v128(-1, 0, 0, 0,
                                            -1, 0, 0, 0,
                                            -1, 0, 0, 0,
                                            -1, 0, 0, 0);

                        result = Xse.shuffle_epi8(LUT, a);

                        return true;
                    }
                    if (constexpr.ALL_EQ_EPU8(divisor, 2, elements)
                     && constexpr.ALL_LT_EPU8(a, 128, elements))
                    {
                        v128 LUT = new v128(-1, 0,
                                            -1, 0,
                                            -1, 0,
                                            -1, 0,
                                            -1, 0,
                                            -1, 0,
                                            -1, 0,
                                            -1, 0);

                        result = Xse.shuffle_epi8(LUT, a);

                        return true;
                    }
                }
                if (promises.Pow2)
                {
                    result = Xse.cmpeq_epi8(Xse.setzero_si128(), pow2_rem_epu8(a, divisor, elements));

                    return true;
                }
                if (constexpr.ALL_GE_EPU8(divisor, 128, elements))
                {
                    result = Xse.or_si128(Xse.cmpeq_epi8(a, divisor), Xse.cmpeq_epi8(a, Xse.setzero_si128()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool mm256_initconstcheck_epu8(v256 a, v256 divisor, out v256 result, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU8(divisor, 1))
                {
                    result = Xse.mm256_setall_si256();

                    return true;
                }
                if (constexpr.ALL_EQ_EPU8(divisor, 16)
                 && constexpr.ALL_LT_EPU8(a, 128))
                {
                    v256 LUT = new v256(-1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                        -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LUT, a);

                    return true;
                }
                if (constexpr.ALL_EQ_EPU8(divisor, 8)
                 && constexpr.ALL_LT_EPU8(a, 128))
                {
                    v256 LUT = new v256(-1, 0, 0, 0, 0, 0, 0, 0,
                                        -1, 0, 0, 0, 0, 0, 0, 0,
                                        -1, 0, 0, 0, 0, 0, 0, 0,
                                        -1, 0, 0, 0, 0, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LUT, a);

                    return true;
                }
                if (constexpr.ALL_EQ_EPU8(divisor, 4)
                 && constexpr.ALL_LT_EPU8(a, 128))
                {
                    v256 LUT = new v256(-1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0,
                                        -1, 0, 0, 0);

                    result = Avx2.mm256_shuffle_epi8(LUT, a);

                    return true;
                }
                if (constexpr.ALL_EQ_EPU8(divisor, 2)
                 && constexpr.ALL_LT_EPU8(a, 128))
                {
                    v256 LUT = new v256(-1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0,
                                        -1, 0);

                    result = Avx2.mm256_shuffle_epi8(LUT, a);

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Avx2.mm256_cmpeq_epi8(Avx.mm256_setzero_si256(), mm256_pow2_rem_epu8(a, divisor));

                    return true;
                }
                if (constexpr.ALL_GE_EPU8(divisor, 128))
                {
                    result = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi8(a, divisor), Avx2.mm256_cmpeq_epi8(a, Avx.mm256_setzero_si256()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool initconstcheck_epu16(v128 a, v128 divisor, out v128 result, DividerPromise promises, byte elements = 8)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU16(divisor, 1, elements))
                {
                    result = Xse.setall_si128();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Xse.cmpeq_epi16(Xse.setzero_si128(), pow2_rem_epu16(a, divisor, elements));

                    return true;
                }
                if (constexpr.ALL_GE_EPU16(divisor, 1 << 15, elements))
                {
                    result = Xse.or_si128(Xse.cmpeq_epi16(a, divisor), Xse.cmpeq_epi16(a, Xse.setzero_si128()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool mm256_initconstcheck_epu16(v256 a, v256 divisor, out v256 result, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU16(divisor, 1))
                {
                    result = Xse.mm256_setall_si256();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Avx2.mm256_cmpeq_epi16(Avx.mm256_setzero_si256(), mm256_pow2_rem_epu16(a, divisor));

                    return true;
                }
                if (constexpr.ALL_GE_EPU16(divisor, 1 << 15))
                {
                    result = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi16(a, divisor), Avx2.mm256_cmpeq_epi16(a, Avx.mm256_setzero_si256()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool initconstcheck_epu32(v128 a, v128 divisor, out v128 result, DividerPromise promises, byte elements = 4)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU32(divisor, 1, elements))
                {
                    result = Xse.setall_si128();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Xse.cmpeq_epi32(Xse.setzero_si128(), pow2_rem_epu32(a, divisor, elements));

                    return true;
                }
                if (constexpr.ALL_GE_EPU32(divisor, 1u << 31, elements))
                {
                    result = Xse.or_si128(Xse.cmpeq_epi32(a, divisor), Xse.cmpeq_epi32(a, Xse.setzero_si128()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool mm256_initconstcheck_epu32(v256 a, v256 divisor, out v256 result, DividerPromise promises)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU32(divisor, 1))
                {
                    result = Xse.mm256_setall_si256();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), mm256_pow2_rem_epu32(a, divisor));

                    return true;
                }
                if (constexpr.ALL_GE_EPU32(divisor, 1u << 31))
                {
                    result = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi32(a, divisor), Avx2.mm256_cmpeq_epi32(a, Avx.mm256_setzero_si256()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool initconstcheck_epu64(v128 a, v128 divisor, out v128 result, DividerPromise promises)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.ALL_LE_EPU64(divisor, 1))
                {
                    result = Xse.setall_si128();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Xse.cmpeq_epi64(Xse.setzero_si128(), pow2_rem_epu64(a, divisor));

                    return true;
                }
                if (constexpr.ALL_GE_EPU64(divisor, 1ul << 63))
                {
                    result = Xse.or_si128(Xse.cmpeq_epi64(a, divisor), Xse.cmpeq_epi64(a, Xse.setzero_si128()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool mm256_initconstcheck_epu64(v256 a, v256 divisor, out v256 result, DividerPromise promises, byte elements = 4)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.ALL_LE_EPU64(divisor, 1, elements))
                {
                    result = Xse.mm256_setall_si256();

                    return true;
                }
                if (promises.Pow2)
                {
                    result = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), mm256_pow2_rem_epu64(a, divisor, elements));

                    return true;
                }
                if (constexpr.ALL_GE_EPU64(divisor, 1ul << 63, elements))
                {
                    result = Avx2.mm256_or_si256(Avx2.mm256_cmpeq_epi64(a, divisor), Avx2.mm256_cmpeq_epi64(a, Avx.mm256_setzero_si256()));

                    return true;
                }

                result = default;
                return false;
            }
            else throw new IllegalInstructionException();
        }
    }


    unsafe public static partial class Extensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<UInt128> d, UInt128 x)
        {
d.AssertOperationMatchesInitialization(sizeof(UInt128), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            return Divider<UInt128>.bmdivisible_u128(x, *(__UInt256__*)&d._bigM, d._divisor, d._promises);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<byte> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            return Divider<byte>.bmdivisible_u8(x, *(ushort*)&d._bigM, d._divisor, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<byte2> d, byte2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort2 mul = *(ushort2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<byte2>.bmdivisible_epu8(x, d.Divisor, mul, d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<byte>.bmdivisible_u8(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<byte3> d, byte3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort3 mul = *(ushort3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<byte3>.bmdivisible_epu8(x, d.Divisor, mul, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<byte>.bmdivisible_u8(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<byte4> d, byte4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort4 mul = *(ushort4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<byte4>.bmdivisible_epu8(x, d.Divisor, mul, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<byte>.bmdivisible_u8(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[3], mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<byte8> d, byte8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort8 mul = *(ushort8*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte8>.bmdivisible_epu8(x, d.Divisor, mul, d._promises, 8));
            }
            else
            {
                return new bool8(Divider<byte>.bmdivisible_u8(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[3], mul[3], d._divisor[3], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[4], mul[4], d._divisor[4], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[5], mul[5], d._divisor[5], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[6], mul[6], d._divisor[6], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[7], mul[7], d._divisor[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<byte16> d, byte16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort16 mul = *(ushort16*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte16>.bmdivisible_epu8(x, d.Divisor, mul.v8_0, mul.v8_8, d._promises));
            }
            else
            {
                return new bool16(Divider<byte>.bmdivisible_u8(x[0],  mul[0],  d._divisor[0],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[1],  mul[1],  d._divisor[1],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[2],  mul[2],  d._divisor[2],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[3],  mul[3],  d._divisor[3],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[4],  mul[4],  d._divisor[4],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[5],  mul[5],  d._divisor[5],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[6],  mul[6],  d._divisor[6],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[7],  mul[7],  d._divisor[7],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[8],  mul[8],  d._divisor[8],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[9],  mul[9],  d._divisor[9],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[10], mul[10], d._divisor[10], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[11], mul[11], d._divisor[11], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[12], mul[12], d._divisor[12], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[13], mul[13], d._divisor[13], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[14], mul[14], d._divisor[14], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[15], mul[15], d._divisor[15], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<byte32> d, byte32 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Divider<byte32>.mm256_bmdivisible_epu8(x, d.Divisor, *(ushort16*)&d._bigM._mulLo, *(ushort16*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool32(d.GetInnerDivider<byte16>(0).EvenlyDivides(x.v16_0),
                                  d.GetInnerDivider<byte16>(16).EvenlyDivides(x.v16_16));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<byte2> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort2 mul = *(ushort2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<byte2>.bmdivisible_epu8((byte2)x, d.Divisor, mul, d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<byte>.bmdivisible_u8(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<byte3> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort3 mul = *(ushort3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<byte3>.bmdivisible_epu8((byte3)x, d.Divisor, mul, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<byte>.bmdivisible_u8(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<byte4> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort4 mul = *(ushort4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<byte4>.bmdivisible_epu8((byte4)x, d.Divisor, mul, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<byte>.bmdivisible_u8(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<byte8> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort8 mul = *(ushort8*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte8>.bmdivisible_epu8((byte8)x, d.Divisor, mul, d._promises, 8));
            }
            else
            {
                return new bool8(Divider<byte>.bmdivisible_u8(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[3], d._divisor[3], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[4], d._divisor[4], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[5], d._divisor[5], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[6], d._divisor[6], (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x, mul[7], d._divisor[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<byte16> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort16 mul = *(ushort16*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte16>.bmdivisible_epu8((byte16)x, d.Divisor, mul.v8_0, mul.v8_8, d._promises));
            }
            else
            {
                return new bool16(Divider<byte>.bmdivisible_u8(x, mul[0],  d._divisor[0],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[1],  d._divisor[1],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[2],  d._divisor[2],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[3],  d._divisor[3],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[4],  d._divisor[4],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[5],  d._divisor[5],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[6],  d._divisor[6],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[7],  d._divisor[7],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[8],  d._divisor[8],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[9],  d._divisor[9],  (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[10], d._divisor[10], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[11], d._divisor[11], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[12], d._divisor[12], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[13], d._divisor[13], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[14], d._divisor[14], (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x, mul[15], d._divisor[15], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<byte32> d, byte x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue8(Divider<byte32>.mm256_bmdivisible_epu8((byte32)x, d.Divisor, *(ushort16*)&d._bigM._mulLo, *(ushort16*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool32(d.GetInnerDivider<byte16>(0).EvenlyDivides(x),
                                  d.GetInnerDivider<byte16>(16).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<byte> d, byte2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue8(Divider<byte2>.bmdivisible_epu8(x, (byte2)d.Divisor, (ushort2)mul, (Promise)d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<byte>.bmdivisible_u8(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<byte> d, byte3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue8(Divider<byte3>.bmdivisible_epu8(x, (byte3)d.Divisor, (ushort3)mul, (Promise)d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<byte>.bmdivisible_u8(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<byte> d, byte4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(Divider<byte4>.bmdivisible_epu8(x, (byte4)d.Divisor, (ushort4)mul, (Promise)d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<byte>.bmdivisible_u8(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[3], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<byte> d, byte8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte8>.bmdivisible_epu8(x, (byte8)d.Divisor, (ushort8)mul, (Promise)d._promises, 8));
            }
            else
            {
                return new bool8(Divider<byte>.bmdivisible_u8(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[2], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[3], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[4], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[5], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[6], mul, d._divisor, (Promise)d._promises),
                                 Divider<byte>.bmdivisible_u8(x[7], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<byte> d, byte16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ushort mul = *(ushort*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue8(Divider<byte16>.bmdivisible_epu8(x, (byte16)d.Divisor, (ushort8)mul, (ushort8)mul, (Promise)d._promises));
            }
            else
            {
                return new bool16(Divider<byte>.bmdivisible_u8(x[0],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[1],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[2],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[3],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[4],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[5],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[6],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[7],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[8],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[9],  mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[10], mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[11], mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[12], mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[13], mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[14], mul, d._divisor, (Promise)d._promises),
                                  Divider<byte>.bmdivisible_u8(x[15], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool32 EvenlyDivides(this Divider<byte> d, byte32 x)
        {
d.AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                ushort mul = *(ushort*)&d._bigM;

                return RegisterConversion.IsTrue8(Divider<byte32>.mm256_bmdivisible_epu8(x, (byte32)d.Divisor, (ushort16)mul, (ushort16)mul, (Promise)d._promises));
            }
            else
            {
                return new bool32(d.EvenlyDivides(x.v16_0),
                                  d.EvenlyDivides(x.v16_16));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<ushort> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            return Divider<ushort>.bmdivisible_u16(x, *(uint*)&d._bigM, d._divisor, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ushort2> d, ushort2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint2 mul = *(uint2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<ushort2>.bmdivisible_epu16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<ushort>.bmdivisible_u16(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ushort3> d, ushort3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint3 mul = *(uint3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<ushort3>.bmdivisible_epu16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<ushort>.bmdivisible_u16(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ushort4> d, ushort4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint4 mul = *(uint4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<ushort4>.bmdivisible_epu16(x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<ushort>.bmdivisible_u16(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[3], mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<ushort8> d, ushort8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint8 mul = *(uint8*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<ushort8>.bmdivisible_epu16(x, d.Divisor, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), d._promises));
            }
            else
            {
                return new bool8(Divider<ushort>.bmdivisible_u16(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[3], mul[3], d._divisor[3], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[4], mul[4], d._divisor[4], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[5], mul[5], d._divisor[5], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[6], mul[6], d._divisor[6], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[7], mul[7], d._divisor[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<ushort16> d, ushort16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Divider<ushort16>.mm256_bmdivisible_epu16(x, d.Divisor, *(uint8*)&d._bigM._mulLo, *(uint8*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool16(d.GetInnerDivider<ushort8>(0).EvenlyDivides(x.v8_0),
                                  d.GetInnerDivider<ushort8>(8).EvenlyDivides(x.v8_8));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ushort2> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint2 mul = *(uint2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<ushort2>.bmdivisible_epu16((ushort2)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<ushort>.bmdivisible_u16(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ushort3> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint3 mul = *(uint3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<ushort3>.bmdivisible_epu16((ushort3)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<ushort>.bmdivisible_u16(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ushort4> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint4 mul = *(uint4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<ushort4>.bmdivisible_epu16((ushort4)x, d.Divisor, RegisterConversion.ToV128(mul), d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<ushort>.bmdivisible_u16(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<ushort8> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint8 mul = *(uint8*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<ushort8>.bmdivisible_epu16((ushort8)x, d.Divisor, RegisterConversion.ToV128(mul.v4_0), RegisterConversion.ToV128(mul.v4_4), d._promises));
            }
            else
            {
                return new bool8(Divider<ushort>.bmdivisible_u16(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[3], d._divisor[3], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[4], d._divisor[4], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[5], d._divisor[5], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[6], d._divisor[6], (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x, mul[7], d._divisor[7], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<ushort16> d, ushort x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsTrue16(Divider<ushort16>.mm256_bmdivisible_epu16((ushort16)x, d.Divisor, *(uint8*)&d._bigM._mulLo, *(uint8*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool16(d.GetInnerDivider<ushort8>(0).EvenlyDivides(x),
                                  d.GetInnerDivider<ushort8>(8).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ushort> d, ushort2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue16(Divider<ushort2>.bmdivisible_epu16(x, (ushort2)d.Divisor, RegisterConversion.ToV128((uint2)mul), (Promise)d._promises, 2)));
            }
            else
            {
                return new bool2(Divider<ushort>.bmdivisible_u16(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ushort> d, ushort3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue16(Divider<ushort3>.bmdivisible_epu16(x, (ushort3)d.Divisor, RegisterConversion.ToV128((uint3)mul), (Promise)d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<ushort>.bmdivisible_u16(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ushort> d, ushort4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue16(Divider<ushort4>.bmdivisible_epu16(x, (ushort4)d.Divisor, RegisterConversion.ToV128((uint4)mul), (Promise)d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<ushort>.bmdivisible_u16(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[3], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<ushort> d, ushort8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            uint mul = *(uint*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.IsTrue16(Divider<ushort8>.bmdivisible_epu16(x, (ushort8)d.Divisor, RegisterConversion.ToV128((uint4)mul), RegisterConversion.ToV128((uint4)mul), (Promise)d._promises));
            }
            else
            {
                return new bool8(Divider<ushort>.bmdivisible_u16(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[2], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[3], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[4], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[5], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[6], mul, d._divisor, (Promise)d._promises),
                                 Divider<ushort>.bmdivisible_u16(x[7], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool16 EvenlyDivides(this Divider<ushort> d, ushort16 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                uint mul = *(uint*)&d._bigM;

                return RegisterConversion.IsTrue16(Divider<ushort16>.mm256_bmdivisible_epu16(x, (ushort16)d.Divisor, (uint8)mul, (uint8)mul, (Promise)d._promises));
            }
            else
            {
                return new bool16(d.EvenlyDivides(x.v8_0),
                                  d.EvenlyDivides(x.v8_8));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<uint> d, uint x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            return Divider<uint>.bmdivisible_u32(x, *(ulong*)&d._bigM, d._divisor, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<uint2> d, uint2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong2 mul = *(ulong2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<uint2>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul, d._promises)));
            }
            else
            {
                return new bool2(Divider<uint>.bmdivisible_u32(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<uint3> d, uint3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong3 mul = *(ulong3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<uint3>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zz, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<uint>.bmdivisible_u32(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[2], mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<uint4> d, uint4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong4 mul = *(ulong4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<uint4>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zw, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<uint>.bmdivisible_u32(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[2], mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[3], mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<uint8> d, uint8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Divider<uint8>.mm256_bmnotdivisible_epu32(x, d.Divisor, *(ulong4*)&d._bigM._mulLo, *(ulong4*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool8(d.GetInnerDivider<uint4>(0).EvenlyDivides(x.v4_0),
                                 d.GetInnerDivider<uint4>(4).EvenlyDivides(x.v4_4));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<uint2> d, uint x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong2 mul = *(ulong2*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<uint2>.bmnotdivisible_epu32(RegisterConversion.ToV128((uint2)x), RegisterConversion.ToV128(d.Divisor), mul, d._promises)));
            }
            else
            {
                return new bool2(Divider<uint>.bmdivisible_u32(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<uint3> d, uint x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong3 mul = *(ulong3*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<uint3>.bmnotdivisible_epu32(RegisterConversion.ToV128((uint3)x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zz, d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<uint>.bmdivisible_u32(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[2], d._divisor[2], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<uint4> d, uint x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong4 mul = *(ulong4*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<uint4>.bmnotdivisible_epu32(RegisterConversion.ToV128((uint4)x), RegisterConversion.ToV128(d.Divisor), mul.xy, mul.zw, d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<uint>.bmdivisible_u32(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[1], d._divisor[1], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[2], d._divisor[2], (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x, mul[3], d._divisor[3], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<uint8> d, uint x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.IsFalse32(Divider<uint8>.mm256_bmnotdivisible_epu32((uint8)x, d.Divisor, *(ulong4*)&d._bigM._mulLo, *(ulong4*)&d._bigM._mulHi, d._promises));
            }
            else
            {
                return new bool8(d.GetInnerDivider<uint4>(0).EvenlyDivides(x),
                                 d.GetInnerDivider<uint4>(4).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<uint> d, uint2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsFalse32(Divider<uint2>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((uint2)d.Divisor), (ulong2)mul, (Promise)d._promises)));
            }
            else
            {
                return new bool2(Divider<uint>.bmdivisible_u32(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<uint> d, uint3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse32(Divider<uint3>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((uint3)d.Divisor), (ulong2)mul, (ulong2)mul, (Promise)d._promises, 3)));
            }
            else
            {
                return new bool3(Divider<uint>.bmdivisible_u32(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[2], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<uint> d, uint4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            ulong mul = *(ulong*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsFalse32(Divider<uint4>.bmnotdivisible_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128((uint4)d.Divisor), (ulong2)mul, (ulong2)mul, (Promise)d._promises, 4)));
            }
            else
            {
                return new bool4(Divider<uint>.bmdivisible_u32(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[1], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[2], mul, d._divisor, (Promise)d._promises),
                                 Divider<uint>.bmdivisible_u32(x[3], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool8 EvenlyDivides(this Divider<uint> d, uint8 x)
        {
d.AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                ulong mul = *(ulong*)&d._bigM;

                return RegisterConversion.IsFalse32(Divider<uint8>.mm256_bmnotdivisible_epu32(x, (uint8)d.Divisor, (ulong4)mul, (ulong4)mul, (Promise)d._promises));
            }
            else
            {
                return new bool8(d.EvenlyDivides(x.v4_0),
                                 d.EvenlyDivides(x.v4_4));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool EvenlyDivides(this Divider<ulong> d, ulong x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            return Divider<ulong>.bmdivisible_u64(x, *(UInt128*)&d._bigM, d._divisor, d._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ulong2> d, ulong2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64(x, d.Divisor, mul[0], mul[1], d._promises)));
            }
            else
            {
                return new bool2(Divider<ulong>.bmdivisible_u64(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ulong>.bmdivisible_u64(x[1], mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ulong3> d, ulong3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<ulong3>.mm256_bmnotdivisible_epu64(x, d.Divisor, default(v256), default(v256), d._promises, 3)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64(x.xy, d.Divisor.xy, default(UInt128), default(UInt128), (Promise)d._promises))),
                                     Divider<ulong>.bmdivisible_u64(x[2], mul[2], d._divisor[2], (Promise)d._promises));
                }
            }

            return new bool3(Divider<ulong>.bmdivisible_u64(x[0], mul[0], d._divisor[0], (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x[1], mul[1], d._divisor[1], (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x[2], mul[2], d._divisor[2], (Promise)d._promises));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ulong4> d, ulong4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Avx2.IsAvx2Supported)
            {
                ulong4 mulLo = Avx2.mm256_i64gather_epi64(mul, new ulong4(0, 2, 4, 6), sizeof(ulong));
                ulong4 mulHi = Avx2.mm256_i64gather_epi64(mul, new ulong4(1, 3, 5, 7), sizeof(ulong));

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<ulong4>.mm256_bmnotdivisible_epu64(x, d.Divisor, mulLo, mulHi, d._promises)));
            }
            else
            {
                return new bool4(d.GetInnerDivider<ulong2>(0).EvenlyDivides(x.xy),
                                 d.GetInnerDivider<ulong2>(2).EvenlyDivides(x.zw));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ulong2> d, ulong x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64((ulong2)x, d.Divisor, mul[0], mul[1], d._promises)));
            }
            else
            {
                return new bool2(Divider<ulong>.bmdivisible_u64(x, mul[0], d._divisor[0], (Promise)d._promises),
                                 Divider<ulong>.bmdivisible_u64(x, mul[1], d._divisor[1], (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ulong3> d, ulong x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<ulong3>.mm256_bmnotdivisible_epu64((ulong3)x, d.Divisor, default(v256), default(v256), d._promises, 3)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64((ulong2)x, d.Divisor.xy, default(UInt128), default(UInt128), (Promise)d._promises))),
                                     Divider<ulong>.bmdivisible_u64(x, mul[2], d._divisor[2], (Promise)d._promises));
                }
            }

            return new bool3(Divider<ulong>.bmdivisible_u64(x, mul[0], d._divisor[0], (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x, mul[1], d._divisor[1], (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x, mul[2], d._divisor[2], (Promise)d._promises));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ulong4> d, ulong x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128* mul = (UInt128*)&d._bigM;

            if (Avx2.IsAvx2Supported)
            {
                ulong4 mulLo = Avx2.mm256_i64gather_epi64(mul, new ulong4(0, 2, 4, 6), sizeof(ulong));
                ulong4 mulHi = Avx2.mm256_i64gather_epi64(mul, new ulong4(1, 3, 5, 7), sizeof(ulong));

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<ulong4>.mm256_bmnotdivisible_epu64((ulong4)x, d.Divisor, mulLo, mulHi, d._promises)));
            }
            else
            {
                return new bool4(d.GetInnerDivider<ulong2>(0).EvenlyDivides(x),
                                 d.GetInnerDivider<ulong2>(2).EvenlyDivides(x));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool2 EvenlyDivides(this Divider<ulong> d, ulong2 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128 mul = *(UInt128*)&d._bigM;

            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64(x, (ulong2)d.Divisor, mul, mul, (Promise)d._promises)));
            }
            else
            {
                return new bool2(Divider<ulong>.bmdivisible_u64(x[0], mul, d._divisor, (Promise)d._promises),
                                 Divider<ulong>.bmdivisible_u64(x[1], mul, d._divisor, (Promise)d._promises));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 EvenlyDivides(this Divider<ulong> d, ulong3 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            UInt128 mul = *(UInt128*)&d._bigM;

            if (d._promises.Pow2)
            {
                if (Avx2.IsAvx2Supported)
                {
                    return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Divider<ulong3>.mm256_bmnotdivisible_epu64(x, Xse.mm256_set1_epi64x(d.Divisor), default(v256), default(v256), (Promise)d._promises, 3)));
                }
                else if (Architecture.IsSIMDSupported)
                {
                    return new bool3(RegisterConversion.ToBool2(RegisterConversion.IsTrue64(Divider<ulong2>.bmdivisible_epu64(x.xy, Xse.set1_epi64x(d.Divisor), default(UInt128), default(UInt128), (Promise)d._promises))),
                                     Divider<ulong>.bmdivisible_u64(x[2], mul, d._divisor, (Promise)d._promises));
                }
            }

            return new bool3(Divider<ulong>.bmdivisible_u64(x[0], mul, d._divisor, (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x[1], mul, d._divisor, (Promise)d._promises),
                             Divider<ulong>.bmdivisible_u64(x[2], mul, d._divisor, (Promise)d._promises));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 EvenlyDivides(this Divider<ulong> d, ulong4 x)
        {
d.AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);

            if (Avx2.IsAvx2Supported)
            {
                UInt128 mul = *(UInt128*)&d._bigM;

                return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Divider<ulong4>.mm256_bmnotdivisible_epu64(x, (ulong4)d.Divisor, (ulong4)mul.lo64, (ulong4)mul.hi64, (Promise)d._promises)));
            }
            else
            {
                return new bool4(d.EvenlyDivides(x.xy),
                                 d.EvenlyDivides(x.zw));
            }
        }
    }
}
