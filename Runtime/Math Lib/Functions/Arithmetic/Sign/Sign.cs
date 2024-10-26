using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
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
            public static v128 soz_epi8(v128 a, byte elements = 16)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi8(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi8(ONE, a);
                    }
                    else
                    {
                        result = add_epi8(and_si128(cmpgt_epi8(a, setzero_si128()), ONE), srai_epi8(a, 7, elements: elements));
                    }

                    constexpr.ASSUME_RANGE_EPI8(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi8(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi8(mm256_set1_epi8(1), a);

                    constexpr.ASSUME_RANGE_EPI8(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi16(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi16(ONE, a);
                    }
                    else
                    {
                        result = add_epi16(and_si128(cmpgt_epi16(a, setzero_si128()), ONE), srai_epi16(a, 15));
                    }

                    constexpr.ASSUME_RANGE_EPI16(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi16(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi16(mm256_set1_epi16(1), a);

                    constexpr.ASSUME_RANGE_EPI16(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi32(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi32(1);

                    v128 result;

                    if (Ssse3.IsSsse3Supported)
                    {
                        result = sign_epi32(ONE, a);
                    }
                    else
                    {
                        result = add_epi32(and_si128(cmpgt_epi32(a, setzero_si128()), ONE), srai_epi32(a, 31));
                    }

                    constexpr.ASSUME_RANGE_EPI32(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi32(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_sign_epi32(mm256_set1_epi32(1), a);

                    constexpr.ASSUME_RANGE_EPI32(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_epi64(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 result = add_epi64(and_si128(cmpgt_epi64(a, setzero_si128()), set1_epi64x(1)), srai_epi64(a, 63));

                    constexpr.ASSUME_RANGE_EPI64(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_epi64(v256 a)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 result = Avx2.mm256_add_epi64(Avx2.mm256_and_si256(mm256_cmpgt_epi64(a, Avx.mm256_setzero_si256()), mm256_set1_epi64x(1)), mm256_srai_epi64(a, 63));

                    constexpr.ASSUME_RANGE_EPI64(result, -1, 1);
                    return result;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_pq(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi8(maxmath.ONE_AS_QUARTER);
                    v128 SIGN_BIT = set1_epi8(1 << 7);

                    v128 signedOne = ternarylogic_si128(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v128 zeroMask = cmpeq_epi8(setzero_si128(), andnot_si128(SIGN_BIT, a));

                    v128 result = andnot_si128(zeroMask, signedOne);

                    //constexpr.ASSUME_RANGE_PQ(result, -1f, 1f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_ph(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_epi16(maxmath.ONE_AS_HALF);
                    v128 SIGN_BIT = set1_epi16(1 << 15);

                    v128 signedOne = ternarylogic_si128(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v128 zeroMask = cmpeq_epi16(setzero_si128(), andnot_si128(SIGN_BIT, a));

                    v128 result = andnot_si128(zeroMask, signedOne);
                    
                    //constexpr.ASSUME_RANGE_PH(result, -1f, 1f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_ps(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_ps(1f);
                    v128 SIGN_BIT = set1_epi32(1 << 31);

                    v128 signedOne = ternarylogic_si128(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v128 zeroMask = cmpeq_epi32(setzero_si128(), andnot_si128(SIGN_BIT, a));
                    v128 result = andnot_ps(zeroMask, signedOne);

                    constexpr.ASSUME_RANGE_PS(result, -1f, 1f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 soz_pd(v128 a)
            {
                if (Architecture.IsSIMDSupported)
                {
                    v128 ONE = set1_pd(1d);
                    v128 SIGN_BIT = set1_epi64x(1ul << 63);

                    v128 signedOne = ternarylogic_si128(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v128 zeroMask = cmpeq_epi64(setzero_si128(), andnot_si128(SIGN_BIT, a));
                    v128 result = andnot_pd(zeroMask, signedOne);

                    constexpr.ASSUME_RANGE_PD(result, -1d, 1d);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_ps(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 ONE = mm256_set1_ps(1f);
                    v256 SIGN_BIT = mm256_set1_epi32(1 << 31);

                    v256 signedOne = mm256_ternarylogic_si256(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v256 zeroMask;
                    if (Avx2.IsAvx2Supported)
                    {
                        zeroMask = Avx2.mm256_cmpeq_epi32(Avx.mm256_setzero_si256(), Avx2.mm256_andnot_si256(SIGN_BIT, a));
                    }
                    else
                    {
                        zeroMask = mm256_cmpeq_ps(a, Avx.mm256_setzero_ps());
                    }

                    v256 result = Avx.mm256_andnot_ps(zeroMask, signedOne);

                    constexpr.ASSUME_RANGE_PS(result, -1f, 1f);
                    return result;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_soz_pd(v256 a)
            {
                if (Avx.IsAvxSupported)
                {
                    v256 ONE = mm256_set1_pd(1d);
                    v256 SIGN_BIT = mm256_set1_epi64x(1ul << 63);

                    v256 signedOne = mm256_ternarylogic_si256(ONE, a, SIGN_BIT, TernaryOperation.OxF8);
                    v256 zeroMask;
                    if (Avx2.IsAvx2Supported)
                    {
                        zeroMask = Avx2.mm256_cmpeq_epi64(Avx.mm256_setzero_si256(), Avx2.mm256_andnot_si256(SIGN_BIT, a));
                    }
                    else
                    {
                        zeroMask = mm256_cmpeq_pd(a, Avx.mm256_setzero_pd());
                    }

                    v256 result = Avx.mm256_andnot_pd(zeroMask, signedOne);

                    constexpr.ASSUME_RANGE_PD(result, -1d, 1d);
                    return result;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the sign of an <see cref="Int128"/>. 1 for a positive <see cref="Int128"/>, 0 for zero and -1 for a negative <see cref="Int128"/>.    </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long sign(Int128 x)
        {
            return ((long)x.hi64 >> 63) | (long)((-x).hi64 >> 63);
        }


        /// <summary>       Returns the sign of an <see cref="sbyte"/>. 1 for a positive <see cref="sbyte"/>, 0 for zero and -1 for a negative <see cref="sbyte"/>.    </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(sbyte x)
        {
            return sign((int)x);
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte2"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 sign(sbyte2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, 2);
            }
            else
            {
                return (x >> 7) | (sbyte2)((byte2)(-x) >> 7);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte3"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 sign(sbyte3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, 3);
            }
            else
            {
                return (x >> 7) | (sbyte3)((byte3)(-x) >> 7);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte4"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 sign(sbyte4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, 4);
            }
            else
            {
                return (x >> 7) | (sbyte4)((byte4)(-x) >> 7);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte8"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 sign(sbyte8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, 8);
            }
            else
            {
                return (x >> 7) | (sbyte8)((byte8)(-x) >> 7);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte16"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 sign(sbyte16 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi8(x, 16);
            }
            else
            {
                return (x >> 7) | (sbyte16)((byte16)(-x) >> 7);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.sbyte32"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 sign(sbyte32 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi8(x);
            }
            else
            {
                return new sbyte32(sign(x.v16_0), sign(x.v16_16));
            }
        }


        /// <summary>       Returns the sign of a <see cref="short"/>. 1 for a positive <see cref="short"/>, 0 for zero and -1 for a negative <see cref="short"/>.    </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(short x)
        {
            return sign((int)x);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short2"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 sign(short2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x);
            }
            else
            {
                return (x >> 15) | (short2)((ushort2)(-x) >> 15);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short3"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 sign(short3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x);
            }
            else
            {
                return (x >> 15) | (short3)((ushort3)(-x) >> 15);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short4"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 sign(short4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x);
            }
            else
            {
                return (x >> 15) | (short4)((ushort4)(-x) >> 15);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short8"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 sign(short8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi16(x);
            }
            else
            {
                return (x >> 15) | (short8)((ushort8)(-x) >> 15);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.short16"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 sign(short16 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi16(x);
            }
            else
            {
                return new short16(sign(x.v8_0), sign(x.v8_8));
            }
        }


        /// <summary>       Returns the sign of an <see cref="int"/>. 1 for a positive <see cref="int"/>, 0 for zero and -1 for a negative <see cref="int"/>.    </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int x)
        {
            return (x >> 31) | (int)((uint)(-x) >> 31);
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int2"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.soz_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return (x >> 31) | (int2)((uint2)(-x) >> 31);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int3"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.soz_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return (x >> 31) | (int3)((uint3)(-x) >> 31);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="int4"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(int4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.soz_epi32(RegisterConversion.ToV128(x)));
            }
            else
            {
                return (x >> 31) | (int4)((uint4)(-x) >> 31);
            }
        }

        /// <summary>       Returns the componentwise sign of an <see cref="MaxMath.int8"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 sign(int8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi32(x);
            }
            else
            {
                return new int8(sign(x.v4_0), sign(x.v4_4));
            }
        }


        /// <summary>       Returns the sign of a <see cref="long"/>. 1 for a positive <see cref="long"/>, 0 for zero and -1 for a negative <see cref="long"/>.    </summary>
        [return: AssumeRange(-1L, 1L)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long sign(long x)
        {
            return (x >> 63) | (long)((ulong)(-x) >> 63);
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long2"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 sign(long2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_epi64(x);
            }
            else
            {
                return (x >> 63) | (long2)((ulong2)(-x) >> 63);
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long3"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 sign(long3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi64(x);
            }
            else
            {
                return new long3(sign(x.xy), sign(x.z));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.long4"/>. 1 for positive components, 0 for zero components and -1 for a negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 sign(long4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_soz_epi64(x);
            }
            else
            {
                return new long4(sign(x.xy), sign(x.zw));
            }
        }


        /// <summary>       Returns the sign of a <see cref="quarter"/>. 1.0f for a positive <see cref="quarter"/>, 0.0f for zero and -1.0f for a negative <see cref="quarter"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter sign(quarter x)
        {
            byte signedOne = (byte)(ONE_AS_QUARTER | (asbyte(x) & 0b1000_0000));

            return asquarter((byte)(-tobyte(x.IsNotZero) & signedOne));
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter2 sign(quarter2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x);
            }
            else
            {
                return new quarter2(sign(x.x), sign(x.y));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 sign(quarter3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x);
            }
            else
            {
                return new quarter3(sign(x.x), sign(x.y), sign(x.z));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 sign(quarter4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x);
            }
            else
            {
                return new quarter4(sign(x.x), sign(x.y), sign(x.z), sign(x.w));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.quarter8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter8 sign(quarter8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_pq(x);
            }
            else
            {
                return new quarter8(sign(x.x0), sign(x.x1), sign(x.x2), sign(x.x3), sign(x.x4), sign(x.x5), sign(x.x6), sign(x.x7));
            }
        }


        /// <summary>       Returns the sign of a <see cref="half"/>. 1.0f for a positive <see cref="half"/>, 0.0f for zero and -1.0f for a negative <see cref="half"/>.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half sign(half x)
        {
            ushort signedOne = (ushort)(ONE_AS_HALF | (asushort(x) & (1 << 15)));

            return ashalf((ushort)(-tobyte(x.IsNotZero()) & signedOne));
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half2"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half2 sign(half2 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf2(Xse.soz_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half2(sign(x.x), sign(x.y));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half3"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half3 sign(half3 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.soz_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half3(sign(x.x), sign(x.y), sign(x.z));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="half4"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half4 sign(half4 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.soz_ph(RegisterConversion.ToV128(x)));
            }
            else
            {
                return new half4(sign(x.x), sign(x.y), sign(x.z), sign(x.w));
            }
        }

        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.half8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static half8 sign(half8 x)
        {
            if (Architecture.IsSIMDSupported)
            {
                return Xse.soz_ph(x);
            }
            else
            {
                return new half8(sign(x.x0), sign(x.x1), sign(x.x2), sign(x.x3), sign(x.x4), sign(x.x5), sign(x.x6), sign(x.x7));
            }
        }


        /// <summary>       Returns the componentwise sign of a <see cref="MaxMath.float8"/>. 1.0f for positive components, 0.0f for zero components and -1.0f for negative components.    </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float8 sign(float8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_soz_ps(x);
            }
            else
            {
                return new float8(math.sign(x.v4_0), math.sign(x.v4_4));
            }
        }
    }
}