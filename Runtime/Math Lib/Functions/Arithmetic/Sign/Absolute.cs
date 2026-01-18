using System.Runtime.CompilerServices;
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
            public static v128 abs_epi8(v128 a, byte elements = 16)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_GE_EPI8(a, 0, elements))
                    {
                        result = a;
                    }
                    else if (Ssse3.IsSsse3Supported)
                    {
                        result = Ssse3.abs_epi8(a);
                    }
                    else
                    {
                        if (constexpr.ALL_LE_EPI8(a, 0, elements))
                        {
                            result = neg_epi8(a);
                        }
                        else
                        {
                            v128 sign = srai_epi8(a, 7);
                            result = xor_si128(sign, add_epi8(a, sign));
                        }
                    }

                    if (constexpr.ALL_NEQ_EPI8(a, sbyte.MinValue, elements))
                    {
                        constexpr.ASSUME_GE_EPI8(result, 0, elements);
                    }
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_s8(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_GE_EPI8(a, 0))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Avx2.mm256_abs_epi8(a);
                    }

                    if (constexpr.ALL_NEQ_EPI8(a, sbyte.MinValue))
                    {
                        constexpr.ASSUME_GE_EPI8(result, 0);
                    }
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi16(v128 a, byte elements = 8)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_GE_EPI16(a, 0, elements))
                    {
                        result = a;
                    }
                    else if (Ssse3.IsSsse3Supported)
                    {
                        result = Ssse3.abs_epi16(a);
                    }
                    else
                    {
                        if (constexpr.ALL_LE_EPI16(a, 0, elements))
                        {
                            result = neg_epi16(a);
                        }
                        else
                        {
                            result = max_epi16(neg_epi16(a), a);
                        }
                    }

                    if (constexpr.ALL_NEQ_EPI16(a, short.MinValue, elements))
                    {
                        constexpr.ASSUME_GE_EPI16(result, 0, elements);
                    }
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_s16(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_GE_EPI16(a, 0))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Avx2.mm256_abs_epi16(a);
                    }

                    if (constexpr.ALL_NEQ_EPI16(a, short.MinValue))
                    {
                        constexpr.ASSUME_GE_EPI16(result, 0);
                    }
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi32(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_GE_EPI32(a, 0, elements))
                    {
                        result = a;
                    }
                    else if (Ssse3.IsSsse3Supported)
                    {
                        result = Ssse3.abs_epi32(a);
                    }
                    else
                    {
                        if (constexpr.ALL_LE_EPI32(a, 0, elements))
                        {
                            result = neg_epi32(a);
                        }
                        else
                        {
                            v128 mask = srai_epi32(a, 31);
                            result = xor_si128(mask, add_epi32(a, mask));
                        }
                    }

                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue, elements))
                    {
                        constexpr.ASSUME_GE_EPI32(result, 0, elements);
                    }
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_s32(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_GE_EPI32(a, 0))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Avx2.mm256_abs_epi32(a);
                    }

                    if (constexpr.ALL_NEQ_EPI32(a, int.MinValue))
                    {
                        constexpr.ASSUME_GE_EPI32(result, 0);
                    }
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_epi64(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_GE_EPI64(a, 0))
                    {
                        result = a;
                    }
                    else if (constexpr.ALL_LE_EPI64(a, 0))
                    {
                        result = neg_epi64(a);
                    }
                    else
                    {
                        if (Sse4_1.IsSse41Supported)
                        {
                            result = blendv_pd(a, neg_epi64(a), a);
                        }
                        else
                        {
                            v128 sign = srai_epi64(a, 63);
                            result = xor_si128(sign, add_epi64(a, sign));
                        }
                    }

                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue))
                    {
                        constexpr.ASSUME_GE_EPI64(result, 0);
                    }
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_s64(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_epi64(v256 a, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result;

                    if (constexpr.ALL_GE_EPI64(a, 0, elements))
                    {
                        result = a;
                    }
                    else if (constexpr.ALL_LE_EPI64(a, 0, elements))
                    {
                        result = mm256_neg_epi64(a);
                    }
                    else
                    {
                        result = Avx.mm256_blendv_pd(a, mm256_neg_epi64(a), a);
                    }

                    if (constexpr.ALL_NEQ_EPI64(a, long.MinValue, elements))
                    {
                        constexpr.ASSUME_GE_EPI64(result, 0, elements);
                    }
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_pq(v128 a, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7, elements))
                    {
                        return a;
                    }
                    else
                    {
                        return and_si128(a, set1_epi8(0b0111_1111));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_pq(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU8(a, 1 << 7))
                    {
                        return a;
                    }
                    else
                    {
                        return Avx2.mm256_and_si256(a, mm256_set1_epi8(0b0111_1111));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_ph(v128 a, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 1 << 15, elements))
                    {
                        return a;
                    }
                    else
                    {
                        return and_si128(a, set1_epi16(0x7FFF));
                    }
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_ph(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (constexpr.ALL_LT_EPU16(a, 1 << 15))
                    {
                        return a;
                    }
                    else
                    {
                        return Avx2.mm256_and_si256(a, mm256_set1_epi16(0x7FFF));
                    }
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_ps(v128 a, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_LT_EPU32(a, 1u << 31, elements))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Sse.and_ps(a, new v128(0x7FFF_FFFF));
                    }

                    constexpr.ASSUME_GE_PS(result, 0f, elements);
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_f32(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_ps(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 result;

                    if (constexpr.ALL_LT_EPU32(a, 1u << 31))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Avx.mm256_and_ps(a, new v256(0x7FFF_FFFF));
                    }

                    constexpr.ASSUME_GE_PS(result, 0f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 abs_pd(v128 a)
            {
                if (Sse2.IsSse2Supported)
                {
                    v128 result;

                    if (constexpr.ALL_LT_EPU64(a, 1ul << 63))
                    {
                        result = a;
                    }
                    else
                    {
                        result = and_pd(a, new v128(0x7FFF_FFFF_FFFF_FFFF));
                    }

                    constexpr.ASSUME_GE_PD(result, 0d);
                    return result;
                }
                else if (Arm.Neon.IsNeonSupported)
                {
                    return Arm.Neon.vabsq_f64(a);
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_abs_pd(v256 a, byte elements = 4)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 result;

                    if (constexpr.ALL_LT_EPU64(a, 1ul << 63, elements))
                    {
                        result = a;
                    }
                    else
                    {
                        result = Avx.mm256_and_pd(a, new v256(0x7FFF_FFFF_FFFF_FFFF));
                    }

                    constexpr.ASSUME_GE_PD(result, 0f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the absolute value of an <see cref="Int128"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 abs(Int128 x)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                Int128 result = select(x, -x, (long)x.hi64 < 0);
                if (constexpr.IS_TRUE(x != Int128.MinValue))
                {
                    constexpr.ASSUME(result > 0);
                }
                return result;
            }
        }


        /// <summary>       Returns the absolute value of an <see cref="sbyte"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte abs(sbyte x)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                sbyte result = (sbyte)(x < 0 ? -x : x);
                if (constexpr.IS_TRUE(x != sbyte.MinValue))
                {
                    constexpr.ASSUME(result > 0);
                }
                return result;
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 abs(sbyte2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi8(x, 2);
            }
            else
            {
                return new sbyte2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 abs(sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi8(x, 3);
            }
            else
            {
                return new sbyte3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 abs(sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi8(x, 4);
            }
            else
            {
                return new sbyte4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 abs(sbyte8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi8(x, 8);
            }
            else
            {
                return new sbyte8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 abs(sbyte16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi8(x, 16);
            }
            else
            {
                return new sbyte16(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7), abs(x.x8), abs(x.x9), abs(x.x10), abs(x.x11), abs(x.x12), abs(x.x13), abs(x.x14), abs(x.x15));
            }
        }

        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.sbyte32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 abs(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi8(x);
            }
            else
            {
                return new sbyte32(abs(x.v16_0), abs(x.v16_16));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="short"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short abs(short x)
        {
            if (constexpr.IS_TRUE(x >= 0))
            {
                return x;
            }
            else
            {
                short result = (short)(x < 0 ? -x : x);
                if (constexpr.IS_TRUE(x != short.MinValue))
                {
                    constexpr.ASSUME(result > 0);
                }
                return result;
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 abs(short2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi16(x, 2);
            }
            else
            {
                return new short2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 abs(short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi16(x, 3);
            }
            else
            {
                return new short3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 abs(short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi16(x, 4);
            }
            else
            {
                return new short4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 abs(short8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi16(x, 8);
            }
            else
            {
                return new short8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.short16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 abs(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi16(x);
            }
            else
            {
                return new short16(abs(x.v8_0), abs(x.v8_8));
            }
        }


        /// <summary>       Returns the componentwise absolute value of an <see cref="MaxMath.int8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 abs(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi32(x);
            }
            else
            {
                return new int8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 abs(long2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_epi64(x);
            }
            else
            {
                return new long2(math.abs(x.x), math.abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 abs(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi64(x, 3);
            }
            else
            {
                return new long3(abs(x.xy), math.abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.long4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 abs(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_epi64(x, 4);
            }
            else
            {
                return new long4(abs(x.xy), abs(x.zw));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="MaxMath.quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter abs(quarter x)
        {
            if (constexpr.IS_TRUE(x >= 0f))
            {
                return x;
            }
            else
            {
                return asquarter((byte)(asbyte(x) & 0b0111_1111));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 abs(quarter2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_pq(x, 2);
            }
            else
            {
                return new quarter2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 abs(quarter3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_pq(x, 3);
            }
            else
            {
                return new quarter3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 abs(quarter4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_pq(x, 4);
            }
            else
            {
                return new quarter4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 abs(quarter8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_pq(x, 8);
            }
            else
            {
                return new quarter8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter16 abs(quarter16 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_pq(x, 16);
            }
            else
            {
                return new quarter16(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7), abs(x.x8), abs(x.x9), abs(x.x10), abs(x.x11), abs(x.x12), abs(x.x13), abs(x.x14), abs(x.x15));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.quarter32"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter32 abs(quarter32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_pq(x);
            }
            else
            {
                return new quarter32(abs(x.v16_0), abs(x.v16_16));
            }
        }


        /// <summary>       Returns the absolute value of a <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half abs(half x)
        {
            if (constexpr.IS_TRUE(x >= 0f))
            {
                return x;
            }
            else
            {
                return new half { value = ((ushort)(x.value & 0x7FFF)) };
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half2"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 abs(half2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.abs_ph(RegisterConversion.ToV128(x), 2));
            }
            else
            {
                return new half2(abs(x.x), abs(x.y));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half3"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 abs(half3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.abs_ph(RegisterConversion.ToV128(x), 3));
            }
            else
            {
                return new half3(abs(x.x), abs(x.y), abs(x.z));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="half4"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 abs(half4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.abs_ph(RegisterConversion.ToV128(x), 4));
            }
            else
            {
                return new half4(abs(x.x), abs(x.y), abs(x.z), abs(x.w));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.half8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 abs(half8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.abs_ph(x, 8);
            }
            else
            {
                return new half8(abs(x.x0), abs(x.x1), abs(x.x2), abs(x.x3), abs(x.x4), abs(x.x5), abs(x.x6), abs(x.x7));
            }
        }

        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.half16"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half16 abs(half16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_abs_ph(x);
            }
            else
            {
                return new half16(abs(x.v8_0), abs(x.v8_8));
            }
        }


        /// <summary>       Returns the componentwise absolute value of a <see cref="MaxMath.float8"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 abs(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_abs_ps(x);
            }
            else
            {
                return new float8(math.abs(x.v4_0), math.abs(x.v4_4));
            }
        }
    }
}