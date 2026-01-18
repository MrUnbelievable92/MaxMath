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
            public static v128 cmp_epu8(v128 a, v128 b, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi8(cmpge_epu8(b, a, elements), cmpge_epu8(a, b, elements));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epu8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi8(mm256_cmpge_epu8(b, a), mm256_cmpge_epu8(a, b));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epi8(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi8(cmpgt_epi8(b, a), cmpgt_epi8(a, b));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epi8(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi8(Avx2.mm256_cmpgt_epi8(b, a), Avx2.mm256_cmpgt_epi8(a, b));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epu16(v128 a, v128 b, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi16(cmpge_epu16(b, a, elements), cmpge_epu16(a, b, elements));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epu16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi16(mm256_cmpge_epu16(b, a), mm256_cmpge_epu16(a, b));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epi16(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi16(cmpgt_epi16(b, a), cmpgt_epi16(a, b));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epi16(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi16(Avx2.mm256_cmpgt_epi16(b, a), Avx2.mm256_cmpgt_epi16(a, b));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epu32(v128 a, v128 b, byte elements = 4)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp;

                    if (Sse4_1.IsSse41Supported)
                    {
                        cmp = sub_epi32(cmpge_epu32(b, a, elements), cmpge_epu32(a, b, elements));
                    }
                    else
                    {
                        cmp = sub_epi32(cmpgt_epu32(b, a, elements), cmpgt_epu32(a, b, elements));
                    }

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epu32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi32(mm256_cmpge_epu32(b, a), mm256_cmpge_epu32(a, b));

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epi32(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi32(cmpgt_epi32(b, a), cmpgt_epi32(a, b));

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epi32(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi32(Avx2.mm256_cmpgt_epi32(b, a), Avx2.mm256_cmpgt_epi32(a, b));

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epu64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi64(cmpgt_epu64(b, a), cmpgt_epu64(a, b));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epu64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi64(mm256_cmpgt_epu64(b, a, elements), mm256_cmpgt_epu64(a, b, elements));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_epi64(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi64(cmpgt_epi64(b, a), cmpgt_epi64(a, b));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_epi64(v256 a, v256 b, byte elements = 4)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi64(mm256_cmpgt_epi64(b, a, elements), mm256_cmpgt_epi64(a, b, elements));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_pq(v128 a, v128 b, byte elements = 16)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi8(cmpgt_pq(b, a, elements: elements), cmpgt_pq(a, b, elements: elements));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_pq(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi8(mm256_cmpgt_pq(b, a), mm256_cmpgt_pq(a, b));

                    constexpr.ASSUME_RANGE_EPI8(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_ph(v128 a, v128 b, byte elements = 8)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi16(cmpgt_ph(b, a, elements: elements), cmpgt_ph(a, b, elements: elements));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_ph(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi16(mm256_cmpgt_ph(b, a), mm256_cmpgt_ph(a, b));

                    constexpr.ASSUME_RANGE_EPI16(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_ps(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi32(cmpgt_ps(b, a), cmpgt_ps(a, b));

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_ps(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi32(mm256_cmpgt_ps(b, a), mm256_cmpgt_ps(a, b));

                    constexpr.ASSUME_RANGE_EPI32(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }


            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 cmp_pd(v128 a, v128 b)
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    v128 cmp = sub_epi64(cmpgt_pd(b, a), cmpgt_pd(a, b));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_cmp_pd(v256 a, v256 b)
            {
                if (Avx2.IsAvx2Supported)
                {
                    v256 cmp = Avx2.mm256_sub_epi64(mm256_cmpgt_pd(b, a), mm256_cmpgt_pd(a, b));

                    constexpr.ASSUME_RANGE_EPI64(cmp, -1, 1);
                    return cmp;
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(UInt128 x, UInt128 y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(Int128 x, Int128 y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(sbyte x, sbyte y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(byte x, byte y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(short x, short y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(ushort x, ushort y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(int x, int y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(uint x, uint y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(long x, long y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(ulong x, ulong y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(quarter x, quarter y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(half x, half y)
        {
            return tobyte(x.IsGreaterThan(y)) - tobyte(x.IsLessThan(y));
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(float x, float y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }

        /// <summary>       Returns -1 if <paramref name="x"/> is smaller than <paramref name="y"/>, 1 if <paramref name="x"/> is greater than <paramref name="y"/> or 0 if both are equal.      </summary>
        [return: AssumeRange(-1, 1)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int compareto(double x, double y)
        {
            return tobyte(x > y) - tobyte(x < y);
        }


        /// <summary>       Returns an <see cref="MaxMath.sbyte2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(sbyte2 x, sbyte2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi8(x, y);
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(sbyte3 x, sbyte3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi8(x, y);
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(sbyte4 x, sbyte4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi8(x, y);
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(sbyte8 x, sbyte8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi8(x, y);
            }
            else
            {
                return new sbyte8((sbyte)compareto(x.x0, y.x0),
                                  (sbyte)compareto(x.x1, y.x1),
                                  (sbyte)compareto(x.x2, y.x2),
                                  (sbyte)compareto(x.x3, y.x3),
                                  (sbyte)compareto(x.x4, y.x4),
                                  (sbyte)compareto(x.x5, y.x5),
                                  (sbyte)compareto(x.x6, y.x6),
                                  (sbyte)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(sbyte16 x, sbyte16 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi8(x, y);
            }
            else
            {
                return new sbyte16((sbyte)compareto(x.x0,  y.x0),
                                   (sbyte)compareto(x.x1,  y.x1),
                                   (sbyte)compareto(x.x2,  y.x2),
                                   (sbyte)compareto(x.x3,  y.x3),
                                   (sbyte)compareto(x.x4,  y.x4),
                                   (sbyte)compareto(x.x5,  y.x5),
                                   (sbyte)compareto(x.x6,  y.x6),
                                   (sbyte)compareto(x.x7,  y.x7),
                                   (sbyte)compareto(x.x8,  y.x8),
                                   (sbyte)compareto(x.x9,  y.x9),
                                   (sbyte)compareto(x.x10, y.x10),
                                   (sbyte)compareto(x.x11, y.x11),
                                   (sbyte)compareto(x.x12, y.x12),
                                   (sbyte)compareto(x.x13, y.x13),
                                   (sbyte)compareto(x.x14, y.x14),
                                   (sbyte)compareto(x.x15, y.x15));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte32"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(sbyte32 x, sbyte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epi8(x, y);
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns an <see cref="MaxMath.sbyte2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(byte2 x, byte2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu8(x, y, 2);
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(byte3 x, byte3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu8(x, y, 3);
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(byte4 x, byte4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu8(x, y, 4);
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(byte8 x, byte8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu8(x, y, 8);
            }
            else
            {
                return new sbyte8((sbyte)compareto(x.x0, y.x0),
                                  (sbyte)compareto(x.x1, y.x1),
                                  (sbyte)compareto(x.x2, y.x2),
                                  (sbyte)compareto(x.x3, y.x3),
                                  (sbyte)compareto(x.x4, y.x4),
                                  (sbyte)compareto(x.x5, y.x5),
                                  (sbyte)compareto(x.x6, y.x6),
                                  (sbyte)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(byte16 x, byte16 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu8(x, y, 16);
            }
            else
            {
                return new sbyte16((sbyte)compareto(x.x0,  y.x0),
                                   (sbyte)compareto(x.x1,  y.x1),
                                   (sbyte)compareto(x.x2,  y.x2),
                                   (sbyte)compareto(x.x3,  y.x3),
                                   (sbyte)compareto(x.x4,  y.x4),
                                   (sbyte)compareto(x.x5,  y.x5),
                                   (sbyte)compareto(x.x6,  y.x6),
                                   (sbyte)compareto(x.x7,  y.x7),
                                   (sbyte)compareto(x.x8,  y.x8),
                                   (sbyte)compareto(x.x9,  y.x9),
                                   (sbyte)compareto(x.x10, y.x10),
                                   (sbyte)compareto(x.x11, y.x11),
                                   (sbyte)compareto(x.x12, y.x12),
                                   (sbyte)compareto(x.x13, y.x13),
                                   (sbyte)compareto(x.x14, y.x14),
                                   (sbyte)compareto(x.x15, y.x15));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte32"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(byte32 x, byte32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epu8(x, y);
            }
            else
            {
                return new sbyte32(compareto(x.v16_0,  y.v16_0),
                                   compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.short2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(short2 x, short2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi16(x, y);
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(short3 x, short3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi16(x, y);
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(short4 x, short4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi16(x, y);
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(short8 x, short8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi16(x, y);
            }
            else
            {
                return new short8((short)compareto(x.x0, y.x0),
                                  (short)compareto(x.x1, y.x1),
                                  (short)compareto(x.x2, y.x2),
                                  (short)compareto(x.x3, y.x3),
                                  (short)compareto(x.x4, y.x4),
                                  (short)compareto(x.x5, y.x5),
                                  (short)compareto(x.x6, y.x6),
                                  (short)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(short16 x, short16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epi16(x, y);
            }
            else
            {
                return new short16(compareto(x.v8_0,  y.v8_0),
                                   compareto(x.v8_8,  y.v8_8));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.short2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(ushort2 x, ushort2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu16(x, y, 2);
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(ushort3 x, ushort3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu16(x, y, 3);
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(ushort4 x, ushort4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu16(x, y, 4);
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(ushort8 x, ushort8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu16(x, y, 8);
            }
            else
            {
                return new short8((short)compareto(x.x0, y.x0),
                                  (short)compareto(x.x1, y.x1),
                                  (short)compareto(x.x2, y.x2),
                                  (short)compareto(x.x3, y.x3),
                                  (short)compareto(x.x4, y.x4),
                                  (short)compareto(x.x5, y.x5),
                                  (short)compareto(x.x6, y.x6),
                                  (short)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(ushort16 x, ushort16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epu16(x, y);
            }
            else
            {
                return new short16(compareto(x.v8_0, y.v8_0),
                                   compareto(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(int2 x, int2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cmp_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(int3 x, int3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cmp_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(int4 x, int4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cmp_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(int8 x, int8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epi32(x, y);
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(uint2 x, uint2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cmp_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(uint3 x, uint3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cmp_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(uint4 x, uint4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cmp_epu32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(uint8 x, uint8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epu32(x, y);
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(long2 x, long2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epi64(x, y);
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(long3 x, long3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epi64(x, y, 3);
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(long4 x, long4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epi64(x, y, 4);
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(ulong2 x, ulong2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_epu64(x, y);
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(ulong3 x, ulong3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epu64(x, y, 3);
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z,  y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(ulong4 x, ulong4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_epu64(x, y, 4);
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }


        /// <summary>       Returns an <see cref="MaxMath.sbyte2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 compareto(quarter2 x, quarter2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pq(x, y, 2);
            }
            else
            {
                return new sbyte2((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 compareto(quarter3 x, quarter3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pq(x, y, 3);
            }
            else
            {
                return new sbyte3((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 compareto(quarter4 x, quarter4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pq(x, y, 4);
            }
            else
            {
                return new sbyte4((sbyte)compareto(x.x, y.x),
                                  (sbyte)compareto(x.y, y.y),
                                  (sbyte)compareto(x.z, y.z),
                                  (sbyte)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 compareto(quarter8 x, quarter8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pq(x, y, 8);
            }
            else
            {
                return new sbyte8((sbyte)compareto(x.x0, y.x0),
                                  (sbyte)compareto(x.x1, y.x1),
                                  (sbyte)compareto(x.x2, y.x2),
                                  (sbyte)compareto(x.x3, y.x3),
                                  (sbyte)compareto(x.x4, y.x4),
                                  (sbyte)compareto(x.x5, y.x5),
                                  (sbyte)compareto(x.x6, y.x6),
                                  (sbyte)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 compareto(quarter16 x, quarter16 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pq(x, y);
            }
            else
            {
                return new sbyte16((sbyte)compareto(x.x0,  y.x0),
                                   (sbyte)compareto(x.x1,  y.x1),
                                   (sbyte)compareto(x.x2,  y.x2),
                                   (sbyte)compareto(x.x3,  y.x3),
                                   (sbyte)compareto(x.x4,  y.x4),
                                   (sbyte)compareto(x.x5,  y.x5),
                                   (sbyte)compareto(x.x6,  y.x6),
                                   (sbyte)compareto(x.x7,  y.x7),
                                   (sbyte)compareto(x.x8,  y.x8),
                                   (sbyte)compareto(x.x9,  y.x9),
                                   (sbyte)compareto(x.x10, y.x10),
                                   (sbyte)compareto(x.x11, y.x11),
                                   (sbyte)compareto(x.x12, y.x12),
                                   (sbyte)compareto(x.x13, y.x13),
                                   (sbyte)compareto(x.x14, y.x14),
                                   (sbyte)compareto(x.x15, y.x15));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.sbyte32"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 compareto(quarter32 x, quarter32 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_pq(x, y);
            }
            else
            {
                return new sbyte32(compareto(x.v16_0, y.v16_0), compareto(x.v16_16, y.v16_16));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.short2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 compareto(half2 x, half2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 2);
            }
            else
            {
                return new short2((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 compareto(half3 x, half3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 3);
            }
            else
            {
                return new short3((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 compareto(half4 x, half4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_ph(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y), 4);
            }
            else
            {
                return new short4((short)compareto(x.x, y.x),
                                  (short)compareto(x.y, y.y),
                                  (short)compareto(x.z, y.z),
                                  (short)compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 compareto(half8 x, half8 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_ph(x, y, 8);
            }
            else
            {
                return new short8((short)compareto(x.x0, y.x0),
                                  (short)compareto(x.x1, y.x1),
                                  (short)compareto(x.x2, y.x2),
                                  (short)compareto(x.x3, y.x3),
                                  (short)compareto(x.x4, y.x4),
                                  (short)compareto(x.x5, y.x5),
                                  (short)compareto(x.x6, y.x6),
                                  (short)compareto(x.x7, y.x7));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.short16"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 compareto(half16 x, half16 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_ph(x, y);
            }
            else
            {
                return new short16(compareto(x.v8_0, y.v8_0), compareto(x.v8_8, y.v8_8));
            }
        }


        /// <summary>       Returns an <see cref="int2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 compareto(float2 x, float2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt2(Xse.cmp_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int2(compareto(x.x, y.x),
                                compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns an <see cref="int3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 compareto(float3 x, float3 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cmp_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int3(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns an <see cref="int4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 compareto(float4 x, float4 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt4(Xse.cmp_ps(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y)));
            }
            else
            {
                return new int4(compareto(x.x, y.x),
                                compareto(x.y, y.y),
                                compareto(x.z, y.z),
                                compareto(x.w, y.w));
            }
        }

        /// <summary>       Returns an <see cref="MaxMath.int8"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 compareto(float8 x, float8 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_ps(x, y);
            }
            else
            {
                return new int8(compareto(x.v4_0, y.v4_0),
                                compareto(x.v4_4, y.v4_4));
            }
        }


        /// <summary>       Returns a <see cref="MaxMath.long2"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 compareto(double2 x, double2 y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmp_pd(RegisterConversion.ToV128(x), RegisterConversion.ToV128(y));
            }
            else
            {
                return new long2(compareto(x.x, y.x),
                                 compareto(x.y, y.y));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long3"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 compareto(double3 x, double3 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y));
            }
            else
            {
                return new long3(compareto(x.xy, y.xy),
                                 compareto(x.z, y.z));
            }
        }

        /// <summary>       Returns a <see cref="MaxMath.long4"/> with each element set to -1 if the corresponding value in <paramref name="x"/> is smaller than the corresponding value in <paramref name="y"/>, 1 if the corresponding value in <paramref name="x"/> is greater than the corresponding value in <paramref name="y"/> or 0 if both are equal.      </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 compareto(double4 x, double4 y)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmp_pd(RegisterConversion.ToV256(x), RegisterConversion.ToV256(y));
            }
            else
            {
                return new long4(compareto(x.xy, y.xy),
                                 compareto(x.zw, y.zw));
            }
        }
    }
}